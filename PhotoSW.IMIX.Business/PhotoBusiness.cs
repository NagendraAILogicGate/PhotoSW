using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.BAL;
using PhotoSW.IMIX.Model;
namespace PhotoSW.IMIX.Business
{
    public class PhotoBusiness
    {

        private string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

        public bool CheckIsCodeType(int PhotoId)
        {
            try
            {
                return baPhotoInfo.GetPhotoInfoData().Where(p => p.PS_Photo_ID == PhotoId).FirstOrDefault().PS_IsCodeType;
            }
            catch (Exception)
            {
                return false;
            }
          
        }
        public bool CheckPhotos(string Photono, int PhotographerID)
        {
            try
            {
                // PhotoInfo //DG_Photos_RFID
                return baPhotoInfo.GetPhotoInfoData().Where(p => p.PS_Photos_RFID == Photono && p.PS_Photos_UserID == PhotographerID).FirstOrDefault().Id > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }
        public bool DeletePhotoByPhotoId(int PhotoId)
        {
            return false;
        }
        public bool DeletePhotoGroupByName(string name)
        {
            return false;
        }
        public List<PhotoSW.IMIX.Model.PhotoInfo> GetAllPhotosByPage
            (string substoreId, int startIndex,
            int pazeSize, bool isNext, out long maxPhotoId,
            out bool IsMoreImages, out long minPhotoId,
            int mediaType)
        {
            try
            {
                int _SubStoreId = Convert.ToInt32(substoreId);
                var obj1 = baPhotoInfo.GetPhotoInfoData();
                var obj = obj1.
                    Where(p => p.PS_SubStoreId == _SubStoreId
                    && p.PS_MediaType == 1)    // p.PS_MediaType == mediaType
                    .Skip(startIndex).Take(pazeSize)
                    .Select(p => new PhotoSW.IMIX.Model.PhotoInfo
            {
                DG_Photos_pkey = p.Id,
                DG_Photos_FileName = p.PS_Photos_FileName,
                DG_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                DG_Photos_RFID = p.PS_Photos_RFID,
                DG_Photos_UserID = p.PS_Photos_UserID,
                DG_Photos_Background = p.PS_Photos_Background,
                DG_Photos_Frame = p.PS_Photos_Frame,
                DG_Photos_DateTime = p.PS_Photos_DateTime,
                DG_Photos_Layering = p.PS_Photos_Layering,
                DG_Photos_Effects = p.PS_Photos_Effects,
                DG_Photos_IsCroped = p.PS_Photos_IsCroped,
                DG_Photos_IsRedEye = p.PS_Photos_IsRedEye,
                DG_Photos_IsGreen = p.PS_Photos_IsGreen,
                DG_Photos_MetaData = p.PS_Photos_MetaData,
                DG_Photos_Sizes = p.PS_Photos_Sizes,
                DG_Photos_Archive = p.PS_Photos_Archive,
                DG_Location_Id = p.PS_Location_Id,
                DG_SubStoreId = p.PS_SubStoreId,
                DG_IsCodeType = p.PS_IsCodeType,
                DateTaken = p.DateTaken,
                RfidScanType = p.RfidScanType,
                DG_Orders_Number = p.PS_Orders_Number,
                DG_Order_SubStoreId = p.PS_Order_SubStoreId,
                IMIXImageAssociationId = p.IMIXImageAssociationId,
                DG_Group_pkey = p.PS_Group_pkey,
                DG_Group_Name = p.PS_Group_Name,
                DG_Photo_ID = p.PS_Photo_ID,
                IsImageProcessed = p.IsImageProcessed,
                DG_User_Name = p.PS_User_Name,
                HotFolderPath = AppDomain.CurrentDomain.BaseDirectory + p.HotFolderPath,
                DG_Photos_CharacterID = p.PS_Photos_CharacterID,
                DG_MediaType = p.PS_MediaType,
                DG_VideoLength = p.PS_VideoLength,
                SemiOrderProfileId = p.SemiOrderProfileId,
                IsGumRideShow = p.IsGumRideShow,
                OnlineQRCode = p.OnlineQRCode,
              

            }).ToList();
                maxPhotoId = obj.Max(p => p.DG_Photos_pkey);
                IsMoreImages = obj.Count() > 1 ? true : false;
                minPhotoId = obj.Min(p => p.DG_Photos_pkey);
                return obj;
            }
            catch (Exception)
            {
                maxPhotoId = 0;
                IsMoreImages =  false;
                minPhotoId = 0;
                return null;
            }
        }
        public List<PhotoSW.IMIX.Model.PhotoInfo> GetAllPhotosforSearch
            (
            string substoreId,
            long imgRfid,
            int NoOfImg,
            bool isAnyRfidSearch,
            long StartIndex,
            int RfidSearch,
            int NewRecord,
            out long maxPhotoId,
            out long minPhotoId,
            int mediaType
            )
        {
            try
            {

                int startIndex =Convert.ToInt32( StartIndex);
                string Photos_RFID = Convert.ToString(imgRfid);
                int _SubStoreId = Convert.ToInt32(substoreId);
                var obj = baPhotoInfo.GetPhotoInfoData().ToList();
                if (Photos_RFID != "0" && RfidSearch != 0 && mediaType != 0)
                {
                    obj = obj.Where(p => p.PS_SubStoreId == _SubStoreId
                         && p.PS_Photos_RFID == Photos_RFID
                        && p.RfidScanType == RfidSearch
                     && p.PS_MediaType == mediaType).ToList();
                }
                else if (  RfidSearch != 0 && mediaType != 0)
                {
                    obj = obj.Where(p => p.PS_SubStoreId == _SubStoreId
                            && p.PS_Photos_RFID == Photos_RFID
                           && p.RfidScanType == RfidSearch
                        && p.PS_MediaType == mediaType).ToList();
                }
                else if (RfidSearch != 0 && mediaType == 0)
                {
                    obj = obj.Where(p => p.PS_SubStoreId == _SubStoreId
                            && p.PS_Photos_RFID == Photos_RFID
                           && p.RfidScanType == RfidSearch
                       ).ToList();
                }
                else if (RfidSearch == 0 && mediaType != 0)
                {
                    obj = obj.Where(p => p.PS_SubStoreId == _SubStoreId
                            && p.PS_Photos_RFID == Photos_RFID
                           
                        && p.PS_MediaType == mediaType).ToList();
                }
                else if (RfidSearch == 0 && mediaType == 0)
                {
                    obj = obj.Where(p => p.PS_SubStoreId == _SubStoreId
                            && p.PS_Photos_RFID == Photos_RFID
                          ).ToList();
                }
                else if ( mediaType == 0)
                {
                    obj = obj.Where(p => p.PS_SubStoreId == _SubStoreId
                            && p.PS_Photos_RFID == Photos_RFID
                           && p.RfidScanType == RfidSearch
                        ).ToList();
                }
                else if (RfidSearch == 0)
                {
                    obj = obj.Where(p => p.PS_SubStoreId == _SubStoreId
                            && p.PS_Photos_RFID == Photos_RFID
                        && p.PS_MediaType == mediaType).ToList();
                }
                else
                {
                    obj = obj.Where(p => p.PS_SubStoreId == _SubStoreId
                            && p.PS_Photos_RFID == Photos_RFID
                      ).ToList();
                }
               // var obj2 = baRFIDField.GetPhotoGroupInfoData().ToList();
               //// var  obj1 = obj
               // var q = (from tblRfIds in obj2.AsEnumerable()
               //          join tblPhotos in obj.AsEnumerable() on tblRfIds.RFId.ToString() equals tblPhotos.PS_Photos_RFID 
                   
               //          select new PhotoSW.IMIX.Model.PhotoInfo
               //          {
               //              DG_Photos_pkey = tblPhotos.Id,
               //              DG_Photos_FileName = tblPhotos.PS_Photos_FileName,
               //              DG_Photos_CreatedOn = tblPhotos.PS_Photos_CreatedOn,
               //              DG_Photos_RFID = tblPhotos.PS_Photos_RFID,
               //              DG_Photos_UserID = tblPhotos.PS_Photos_UserID,
               //              DG_Photos_Background = tblPhotos.PS_Photos_Background,
               //              DG_Photos_Frame = tblPhotos.PS_Photos_Frame,
               //              DG_Photos_DateTime = tblPhotos.PS_Photos_DateTime,
               //              DG_Photos_Layering = tblPhotos.PS_Photos_Layering,
               //              DG_Photos_Effects = tblPhotos.PS_Photos_Effects,
               //              DG_Photos_IsCroped = tblPhotos.PS_Photos_IsCroped,
               //              DG_Photos_IsRedEye = tblPhotos.PS_Photos_IsRedEye,
               //              DG_Photos_IsGreen = tblPhotos.PS_Photos_IsGreen,
               //              DG_Photos_MetaData = tblPhotos.PS_Photos_MetaData,
               //              DG_Photos_Sizes = tblPhotos.PS_Photos_Sizes,
               //              DG_Photos_Archive = tblPhotos.PS_Photos_Archive,
               //              DG_Location_Id = tblPhotos.PS_Location_Id,
               //              DG_SubStoreId = tblPhotos.PS_SubStoreId,
               //              DG_IsCodeType = tblPhotos.PS_IsCodeType,
               //              DateTaken = tblPhotos.DateTaken,
               //              RfidScanType = tblPhotos.RfidScanType,
               //              DG_Orders_Number = tblPhotos.PS_Orders_Number,
               //              DG_Order_SubStoreId = tblPhotos.PS_Order_SubStoreId,
               //              IMIXImageAssociationId = tblPhotos.IMIXImageAssociationId,
               //              DG_Group_pkey = tblPhotos.PS_Group_pkey,
               //              DG_Group_Name = tblPhotos.PS_Group_Name,
               //              DG_Photo_ID = tblPhotos.PS_Photo_ID,
               //              IsImageProcessed = tblPhotos.IsImageProcessed,
               //              DG_User_Name = tblPhotos.PS_User_Name,
               //              HotFolderPath = AppDomain.CurrentDomain.BaseDirectory + tblPhotos.HotFolderPath,
               //              DG_Photos_CharacterID = tblPhotos.PS_Photos_CharacterID,
               //              DG_MediaType = tblPhotos.PS_MediaType,
               //              DG_VideoLength = tblPhotos.PS_VideoLength,
               //              SemiOrderProfileId = tblPhotos.SemiOrderProfileId,
               //              IsGumRideShow = tblPhotos.IsGumRideShow,
               //              OnlineQRCode = tblPhotos.OnlineQRCode,
               //          }).ToList(); 
               var  obj1 = obj
                    .Skip(startIndex)
                    .Select(p => new PhotoSW.IMIX.Model.PhotoInfo
                    {
                        DG_Photos_pkey = p.Id,
                        DG_Photos_FileName = p.PS_Photos_FileName,
                        DG_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                        DG_Photos_RFID = p.PS_Photos_RFID,
                        DG_Photos_UserID = p.PS_Photos_UserID,
                        DG_Photos_Background = p.PS_Photos_Background,
                        DG_Photos_Frame = p.PS_Photos_Frame,
                        DG_Photos_DateTime = p.PS_Photos_DateTime,
                        DG_Photos_Layering = p.PS_Photos_Layering,
                        DG_Photos_Effects = p.PS_Photos_Effects,
                        DG_Photos_IsCroped = p.PS_Photos_IsCroped,
                        DG_Photos_IsRedEye = p.PS_Photos_IsRedEye,
                        DG_Photos_IsGreen = p.PS_Photos_IsGreen,
                        DG_Photos_MetaData = p.PS_Photos_MetaData,
                        DG_Photos_Sizes = p.PS_Photos_Sizes,
                        DG_Photos_Archive = p.PS_Photos_Archive,
                        DG_Location_Id = p.PS_Location_Id,
                        DG_SubStoreId = p.PS_SubStoreId,
                        DG_IsCodeType = p.PS_IsCodeType,
                        DateTaken = p.DateTaken,
                        RfidScanType = p.RfidScanType,
                        DG_Orders_Number = p.PS_Orders_Number,
                        DG_Order_SubStoreId = p.PS_Order_SubStoreId,
                        IMIXImageAssociationId = p.IMIXImageAssociationId,
                        DG_Group_pkey = p.PS_Group_pkey,
                        DG_Group_Name = p.PS_Group_Name,
                        DG_Photo_ID = p.PS_Photo_ID,
                        IsImageProcessed = p.IsImageProcessed,
                        DG_User_Name = p.PS_User_Name,
                        HotFolderPath = AppDomain.CurrentDomain.BaseDirectory + p.HotFolderPath,
                        DG_Photos_CharacterID = p.PS_Photos_CharacterID,
                        DG_MediaType = p.PS_MediaType,
                        DG_VideoLength = p.PS_VideoLength,
                        SemiOrderProfileId = p.SemiOrderProfileId,
                        IsGumRideShow = p.IsGumRideShow,
                        OnlineQRCode = p.OnlineQRCode,


                    }).ToList();

                if(obj1.Count !=0)
                {
                    maxPhotoId = obj1.Max(p => p.DG_Photos_pkey);
                    //IsMoreImages = obj.Count() > 1 ? true : false;
                    minPhotoId = obj1.Min(p => p.DG_Photos_pkey);
                    return obj1;
                }
                else
                {
                    maxPhotoId = 0;
                    // IsMoreImages = false;
                    minPhotoId = 0;
                    return obj1;
                }
               
               // return obj1;
            }
            catch (Exception)
            {
                maxPhotoId = 0;
               // IsMoreImages = false;
                minPhotoId = 0;
                return null;
            } 
        }
        public List<PhotoSW.IMIX.Model.PhotoInfo> GetArchiveImages()
        { try
            {
                //int _SubStoreId=Convert.ToInt32(substoreId);
                var obj = baPhotoInfo.GetPhotoInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.PhotoInfo
            {
                DG_Photos_pkey = p.Id,
                DG_Photos_FileName = p.PS_Photos_FileName,
                DG_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                DG_Photos_RFID = p.PS_Photos_RFID,
                DG_Photos_UserID = p.PS_Photos_UserID,
                DG_Photos_Background = p.PS_Photos_Background,
                DG_Photos_Frame = p.PS_Photos_Frame,
                DG_Photos_DateTime = p.PS_Photos_DateTime,
                DG_Photos_Layering = p.PS_Photos_Layering,
                DG_Photos_Effects = p.PS_Photos_Effects,
                DG_Photos_IsCroped = p.PS_Photos_IsCroped,
                DG_Photos_IsRedEye = p.PS_Photos_IsRedEye,
                DG_Photos_IsGreen = p.PS_Photos_IsGreen,
                DG_Photos_MetaData = p.PS_Photos_MetaData,
                DG_Photos_Sizes = p.PS_Photos_Sizes,
                DG_Photos_Archive = p.PS_Photos_Archive,
                DG_Location_Id = p.PS_Location_Id,
                DG_SubStoreId = p.PS_SubStoreId,
                DG_IsCodeType = p.PS_IsCodeType,
                DateTaken = p.DateTaken,
                RfidScanType = p.RfidScanType,
                DG_Orders_Number = p.PS_Orders_Number,
                DG_Order_SubStoreId = p.PS_Order_SubStoreId,
                IMIXImageAssociationId = p.IMIXImageAssociationId,
                DG_Group_pkey = p.PS_Group_pkey,
                DG_Group_Name = p.PS_Group_Name,
                DG_Photo_ID = p.PS_Photo_ID,
                IsImageProcessed = p.IsImageProcessed,
                DG_User_Name = p.PS_User_Name,
                HotFolderPath = AppDomain.CurrentDomain.BaseDirectory + p.HotFolderPath,
                DG_Photos_CharacterID = p.PS_Photos_CharacterID,
                DG_MediaType = p.PS_MediaType,
                DG_VideoLength = p.PS_VideoLength,
                SemiOrderProfileId = p.SemiOrderProfileId,
                IsGumRideShow = p.IsGumRideShow,
                OnlineQRCode = p.OnlineQRCode,
              

            }).ToList();
               
                return obj;
            }
            catch (Exception)
            {
               
                return null;
            }
        }

        public string GetFileNameByPhotoID(string PhotoID)
        {
            try
            {
               int Photo_ID= Convert .ToInt32(PhotoID);
               return  baPhotoInfo.GetPhotoInfoData().Where(p => p.PS_Photo_ID == Photo_ID)
                   .FirstOrDefault().PS_Photos_FileName;
            }
            catch
            {
                return "";
            }
        }
        public List<PhotoSW.IMIX.Model.PhotoDetail> GetFilesForAutoVideoProcessing(int substoreID, string PosName)
        {
            try
            {

                var obj = baPhotoDetail.GetPhotoDetailData().Where(p => p.SubstoreId == substoreID).Select(p => new PhotoDetail
                {
                   
                    PhotoId = p.PhotoId,
                    FileName = p.FileName,
                    DG_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                    PhotoRFID = p.PhotoRFID,
                    Layering = p.Layering,
                    Effects = p.Effects,
                    IsCropped = p.IsCropped,
                    IsGreen = p.IsGreen,
                    LocationId = p.LocationId,
                    SubstoreId = p.SubstoreId,
                    IsEnabled = p.IsEnabled,
                    IsChecked = p.IsChecked,
                    HotFolderPath = AppDomain.CurrentDomain.BaseDirectory+ p.HotFolderPath,
                    MediaType = p.MediaType,
                    PhotoGrapherId = p.PhotoGrapherId,
                    VideoLength = p.VideoLength,
                    PhotoIdSequence = p.PhotoIdSequence,
                    SemiOrderProfileId = p.SemiOrderProfileId,
                    IsGumRideShow = p.IsGumRideShow
                }).ToList();
                return obj;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public PhotoSW.IMIX.Model.DG_PhotoGroupInfo GetGroupName(string groupname)
        {
            try
            {
                var obj = baPhotoGroupInfo.GetPhotoGroupInfoData().Where(p => p.Group_Name == groupname)
                    .Select(p => new DG_PhotoGroupInfo
                {
                    DG_Group_pkey = p.Id,
                    DG_Group_Name = p.Group_Name,
                    DG_Photo_ID = p.Photo_ID,
                    DG_Photo_RFID = p.Photo_RFID,
                    DG_CreatedDate = p.CreatedDate,
                    DG_SubstoreId = p.SubstoreId

                }).FirstOrDefault();
                return obj;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<PhotoSW.IMIX.Model.PhotoInfo> GetImagesBYQRCode(string QRCode, bool IsAnonymousQrCodeEnabled)
        {

            try
            {
                var obj = baPhotoInfo.GetPhotoInfoData().Where(p => p.OnlineQRCode == QRCode)
                    .Select(p => new PhotoInfo
                    {
                        DG_Photos_pkey = p.Id,
                        DG_Photos_FileName = p.PS_Photos_FileName,
                        DG_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                        DG_Photos_RFID = p.PS_Photos_RFID,
                        DG_Photos_UserID = p.PS_Photos_UserID,
                        DG_Photos_Background = p.PS_Photos_Background,
                        DG_Photos_Frame = p.PS_Photos_Frame,
                        DG_Photos_DateTime = p.PS_Photos_DateTime,
                        DG_Photos_Layering = p.PS_Photos_Layering,
                        DG_Photos_Effects = p.PS_Photos_Effects,
                        DG_Photos_IsCroped = p.PS_Photos_IsCroped,
                        DG_Photos_IsRedEye = p.PS_Photos_IsRedEye,
                        DG_Photos_IsGreen = p.PS_Photos_IsGreen,
                        DG_Photos_MetaData = p.PS_Photos_MetaData,
                        DG_Photos_Sizes = p.PS_Photos_Sizes,
                        DG_Photos_Archive = p.PS_Photos_Archive,
                        DG_Location_Id = p.PS_Location_Id,
                        DG_SubStoreId = p.PS_SubStoreId,
                        DG_IsCodeType = p.PS_IsCodeType,
                        DateTaken = p.DateTaken,
                        RfidScanType = p.RfidScanType,
                        DG_Orders_Number = p.PS_Orders_Number,
                        DG_Order_SubStoreId = p.PS_Order_SubStoreId,
                        IMIXImageAssociationId = p.IMIXImageAssociationId,
                        DG_Group_pkey = p.PS_Group_pkey,
                        DG_Group_Name = p.PS_Group_Name,
                        DG_Photo_ID = p.PS_Photo_ID,
                        IsImageProcessed = p.IsImageProcessed,
                        DG_User_Name = p.PS_User_Name,
                        HotFolderPath = AppDomain.CurrentDomain.BaseDirectory+ p.HotFolderPath,
                        DG_Photos_CharacterID = p.PS_Photos_CharacterID,
                        DG_MediaType = p.PS_MediaType,
                        DG_VideoLength = p.PS_VideoLength,
                        SemiOrderProfileId = p.SemiOrderProfileId,
                        IsGumRideShow = p.IsGumRideShow,
                        OnlineQRCode = p.OnlineQRCode,

                    }).ToList();
                return obj;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<PhotoSW.IMIX.Model.PhotoDetail> GetImagesInfoForEditing(int SubStoreId, string PosName)
        {
            try
            {

                var obj = baPhotoDetail.GetPhotoDetailData().Where(p => p.SubstoreId == SubStoreId).Select(p => new PhotoDetail
                {

                    PhotoId = p.PhotoId,
                    FileName = p.FileName,
                    DG_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                    PhotoRFID = p.PhotoRFID,
                    Layering = p.Layering,
                    Effects = p.Effects,
                    IsCropped = p.IsCropped,
                    IsGreen = p.IsGreen,
                    LocationId = p.LocationId,
                    SubstoreId = p.SubstoreId,
                    IsEnabled = p.IsEnabled,
                    IsChecked = p.IsChecked,
                    HotFolderPath = AppDomain.CurrentDomain.BaseDirectory+ p.HotFolderPath,
                    MediaType = p.MediaType,
                    PhotoGrapherId = p.PhotoGrapherId,
                    VideoLength = p.VideoLength,
                    PhotoIdSequence = p.PhotoIdSequence,
                    SemiOrderProfileId = p.SemiOrderProfileId,
                    IsGumRideShow = p.IsGumRideShow
                }).ToList();
                return obj;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public int GetLocationIdByPhotoId(int PhotoId)
        {
            try
            {

                var obj = baPhotoInfo.GetPhotoInfoData().Where(p => p.Id == PhotoId).FirstOrDefault().PS_Location_Id;
               
                return Convert.ToInt32(obj);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public void GetMaxId(string substoreId, out long maxPhotoId, int mediaType)
        {
            try
            {
                int _SubStoreId = Convert.ToInt32(substoreId);
                var obj = baPhotoInfo.GetPhotoInfoData().
                    Where(p => p.PS_SubStoreId == _SubStoreId
                    )
                    .Select(p => new PhotoSW.IMIX.Model.PhotoInfo
                    {
                        DG_Photos_pkey = p.Id,
                        DG_Photos_FileName = p.PS_Photos_FileName,
                        DG_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                        DG_Photos_RFID = p.PS_Photos_RFID,
                        DG_Photos_UserID = p.PS_Photos_UserID,
                        DG_Photos_Background = p.PS_Photos_Background,
                        DG_Photos_Frame = p.PS_Photos_Frame,
                        DG_Photos_DateTime = p.PS_Photos_DateTime,
                        DG_Photos_Layering = p.PS_Photos_Layering,
                        DG_Photos_Effects = p.PS_Photos_Effects,
                        DG_Photos_IsCroped = p.PS_Photos_IsCroped,
                        DG_Photos_IsRedEye = p.PS_Photos_IsRedEye,
                        DG_Photos_IsGreen = p.PS_Photos_IsGreen,
                        DG_Photos_MetaData = p.PS_Photos_MetaData,
                        DG_Photos_Sizes = p.PS_Photos_Sizes,
                        DG_Photos_Archive = p.PS_Photos_Archive,
                        DG_Location_Id = p.PS_Location_Id,
                        DG_SubStoreId = p.PS_SubStoreId,
                        DG_IsCodeType = p.PS_IsCodeType,
                        DateTaken = p.DateTaken,
                        RfidScanType = p.RfidScanType,
                        DG_Orders_Number = p.PS_Orders_Number,
                        DG_Order_SubStoreId = p.PS_Order_SubStoreId,
                        IMIXImageAssociationId = p.IMIXImageAssociationId,
                        DG_Group_pkey = p.PS_Group_pkey,
                        DG_Group_Name = p.PS_Group_Name,
                        DG_Photo_ID = p.PS_Photo_ID,
                        IsImageProcessed = p.IsImageProcessed,
                        DG_User_Name = p.PS_User_Name,
                        HotFolderPath = AppDomain.CurrentDomain.BaseDirectory+ p.HotFolderPath,
                        DG_Photos_CharacterID = p.PS_Photos_CharacterID,
                        DG_MediaType = p.PS_MediaType,
                        DG_VideoLength = p.PS_VideoLength,
                        SemiOrderProfileId = p.SemiOrderProfileId,
                        IsGumRideShow = p.IsGumRideShow,
                        OnlineQRCode = p.OnlineQRCode,


                    }).ToList();
                maxPhotoId = obj.Max(p => p.DG_Photos_pkey);
              
            }
            catch (Exception)
            {
                maxPhotoId = 0; 
            }
        }
        public int GetMaxPhotoIdsequence()
        {
            int maxPhotoId = 0;
            try
            {
                var obj = baPhotoInfo.GetPhotoInfoData().ToList();
                maxPhotoId = obj.Max(p => p.Id);

               return maxPhotoId;
            }
            catch (Exception)
            {
                return maxPhotoId = 0;
               
            }
        }
        public int GetMaxUserIdsequence(long frmImgId, long toImgId, string PhotoGrapherID)
        {
            int maxPhotoId = 0;
            try
            {
                int PhotoGrapher_ID =Convert.ToInt32( PhotoGrapherID);
                var obj =baPhotoGrapherInfo.GetPhotoGrapherInfoData().Where (p=>p.Id==PhotoGrapher_ID)
                    .ToList();
                maxPhotoId = obj.Max(p => p.PS_User_pkey);

                return maxPhotoId;
            }
            catch (Exception)
            {
                return maxPhotoId = 0;

            }
        }
        public List<PhotoSW.IMIX.Model.ModratePhotoInfo> GetModeratePhotos()
        {

            try
            {
                var obj = baModratePhotoInfo.GetModratePhotoInfoData().Select(p => new ModratePhotoInfo
                    {
                        DG_Mod_Photo_pkey =(int)p.Id,
                        DG_Mod_Photo_ID = p.PS_Mod_Photo_ID,
                        DG_Mod_Date = p.PS_Mod_Date,
                        DG_Mod_User_ID = p.PS_Mod_User_ID,
                    }).ToList();
                    
                    //.ToList();


                return obj;
            }
            catch (Exception)
            {
                return null;

            }
            //List<PhotoSW.IMIX.Model.ModratePhotoInfo> obj = new List<ModratePhotoInfo>();
            //return obj;
        }
        public bool GetModeratePhotos(long PhotoId)
        {
            return false;
        }
        public PhotoSW.IMIX.Model.PhotoInfo GetNextPreviousPhoto(int PhotoId, string Flag)
        {
            try
            {
                var obj = baPhotoInfo.GetPhotoInfoData().
                    Where(p => p.Id == PhotoId
                    )
                    .Select(p => new PhotoSW.IMIX.Model.PhotoInfo
                    {
                        DG_Photos_pkey = p.Id,
                        DG_Photos_FileName = p.PS_Photos_FileName,
                        DG_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                        DG_Photos_RFID = p.PS_Photos_RFID,
                        DG_Photos_UserID = p.PS_Photos_UserID,
                        DG_Photos_Background = p.PS_Photos_Background,
                        DG_Photos_Frame = p.PS_Photos_Frame,
                        DG_Photos_DateTime = p.PS_Photos_DateTime,
                        DG_Photos_Layering = p.PS_Photos_Layering,
                        DG_Photos_Effects = p.PS_Photos_Effects,
                        DG_Photos_IsCroped = p.PS_Photos_IsCroped,
                        DG_Photos_IsRedEye = p.PS_Photos_IsRedEye,
                        DG_Photos_IsGreen = p.PS_Photos_IsGreen,
                        DG_Photos_MetaData = p.PS_Photos_MetaData,
                        DG_Photos_Sizes = p.PS_Photos_Sizes,
                        DG_Photos_Archive = p.PS_Photos_Archive,
                        DG_Location_Id = p.PS_Location_Id,
                        DG_SubStoreId = p.PS_SubStoreId,
                        DG_IsCodeType = p.PS_IsCodeType,
                        DateTaken = p.DateTaken,
                        RfidScanType = p.RfidScanType,
                        DG_Orders_Number = p.PS_Orders_Number,
                        DG_Order_SubStoreId = p.PS_Order_SubStoreId,
                        IMIXImageAssociationId = p.IMIXImageAssociationId,
                        DG_Group_pkey = p.PS_Group_pkey,
                        DG_Group_Name = p.PS_Group_Name,
                        DG_Photo_ID = p.PS_Photo_ID,
                        IsImageProcessed = p.IsImageProcessed,
                        DG_User_Name = p.PS_User_Name,
                        HotFolderPath = AppDomain.CurrentDomain.BaseDirectory+ p.HotFolderPath,
                        DG_Photos_CharacterID = p.PS_Photos_CharacterID,
                        DG_MediaType = p.PS_MediaType,
                        DG_VideoLength = p.PS_VideoLength,
                        SemiOrderProfileId = p.SemiOrderProfileId,
                        IsGumRideShow = p.IsGumRideShow,
                        OnlineQRCode = p.OnlineQRCode,


                    }).FirstOrDefault();
                return obj;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public PhotoSW.IMIX.Model.PhotoInfo GetPhotoByPhotoID(string PhotoID)
        {
            try
            {
                int Id = Convert.ToInt32(PhotoID);
                var obj = baPhotoInfo.GetPhotoInfoData().
                    Where(p => p.Id == Id
                    )
                    .Select(p => new PhotoSW.IMIX.Model.PhotoInfo
                    {
                        DG_Photos_pkey = p.Id,
                        DG_Photos_FileName = p.PS_Photos_FileName,
                        DG_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                        DG_Photos_RFID = p.PS_Photos_RFID,
                        DG_Photos_UserID = p.PS_Photos_UserID,
                        DG_Photos_Background = p.PS_Photos_Background,
                        DG_Photos_Frame = p.PS_Photos_Frame,
                        DG_Photos_DateTime = p.PS_Photos_DateTime,
                        DG_Photos_Layering = p.PS_Photos_Layering,
                        DG_Photos_Effects = p.PS_Photos_Effects,
                        DG_Photos_IsCroped = p.PS_Photos_IsCroped,
                        DG_Photos_IsRedEye = p.PS_Photos_IsRedEye,
                        DG_Photos_IsGreen = p.PS_Photos_IsGreen,
                        DG_Photos_MetaData = p.PS_Photos_MetaData,
                        DG_Photos_Sizes = p.PS_Photos_Sizes,
                        DG_Photos_Archive = p.PS_Photos_Archive,
                        DG_Location_Id = p.PS_Location_Id,
                        DG_SubStoreId = p.PS_SubStoreId,
                        DG_IsCodeType = p.PS_IsCodeType,
                        DateTaken = p.DateTaken,
                        RfidScanType = p.RfidScanType,
                        DG_Orders_Number = p.PS_Orders_Number,
                        DG_Order_SubStoreId = p.PS_Order_SubStoreId,
                        IMIXImageAssociationId = p.IMIXImageAssociationId,
                        DG_Group_pkey = p.PS_Group_pkey,
                        DG_Group_Name = p.PS_Group_Name,
                        DG_Photo_ID = p.PS_Photo_ID,
                        IsImageProcessed = p.IsImageProcessed,
                        DG_User_Name = p.PS_User_Name,
                        HotFolderPath = AppDomain.CurrentDomain.BaseDirectory+ p.HotFolderPath,
                        DG_Photos_CharacterID = p.PS_Photos_CharacterID,
                        DG_MediaType = p.PS_MediaType,
                        DG_VideoLength = p.PS_VideoLength,
                        SemiOrderProfileId = p.SemiOrderProfileId,
                        IsGumRideShow = p.IsGumRideShow,
                        OnlineQRCode = p.OnlineQRCode,


                    }).FirstOrDefault();
                return obj;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<PhotoSW.IMIX.Model.PhotoCaptureInfo> GetphotoCapturedetails(int pkey)
        {
            List<PhotoSW.IMIX.Model.PhotoCaptureInfo> obj = new List<PhotoCaptureInfo>();
            return obj;
        }
        public PhotoSW.IMIX.Model.PhotoInfo GetPhotoDetailsbyPhotoId(int PhotoId)
        {
            try
            {
                var obj = baPhotoInfo.GetPhotoInfoData().
                    Where(p => p.Id == PhotoId
                    )
                    .Select(p => new PhotoSW.IMIX.Model.PhotoInfo
                    {
                        DG_Photos_pkey = p.PS_Photos_pkey,
                        DG_Photos_FileName = p.PS_Photos_FileName,
                        DG_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                        DG_Photos_RFID = p.PS_Photos_RFID,
                        DG_Photos_UserID = p.PS_Photos_UserID,
                        DG_Photos_Background = p.PS_Photos_Background,
                        DG_Photos_Frame = p.PS_Photos_Frame,
                        DG_Photos_DateTime = p.PS_Photos_DateTime,
                        DG_Photos_Layering = p.PS_Photos_Layering,
                        DG_Photos_Effects = p.PS_Photos_Effects,
                        DG_Photos_IsCroped = p.PS_Photos_IsCroped,
                        DG_Photos_IsRedEye = p.PS_Photos_IsRedEye,
                        DG_Photos_IsGreen = p.PS_Photos_IsGreen,
                        DG_Photos_MetaData = p.PS_Photos_MetaData,
                        DG_Photos_Sizes = p.PS_Photos_Sizes,
                        DG_Photos_Archive = p.PS_Photos_Archive,
                        DG_Location_Id = p.PS_Location_Id,
                        DG_SubStoreId = p.PS_SubStoreId,
                        DG_IsCodeType = p.PS_IsCodeType,
                        DateTaken = p.DateTaken,
                        RfidScanType = p.RfidScanType,
                        DG_Orders_Number = p.PS_Orders_Number,
                        DG_Order_SubStoreId = p.PS_Order_SubStoreId,
                        IMIXImageAssociationId = p.IMIXImageAssociationId,
                        DG_Group_pkey = p.PS_Group_pkey,
                        DG_Group_Name = p.PS_Group_Name,
                        DG_Photo_ID = p.PS_Photo_ID,
                        IsImageProcessed = p.IsImageProcessed,
                        DG_User_Name = p.PS_User_Name,
                      //  HotFolderPath = p.HotFolderPath,
                        HotFolderPath = AppDomain.CurrentDomain.BaseDirectory+ p.HotFolderPath,
                        DG_Photos_CharacterID = p.PS_Photos_CharacterID,
                        DG_MediaType = p.PS_MediaType,
                        DG_VideoLength = p.PS_VideoLength,
                        SemiOrderProfileId = p.SemiOrderProfileId,
                        IsGumRideShow = p.IsGumRideShow,
                        OnlineQRCode = p.OnlineQRCode,
                        IsCollageShow = p.IsCollageShow
                        }).FirstOrDefault();
                return obj;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public PhotoSW.CF.DataLayer.BAL.baPhotoInfo GetPhotoCollagebyPhotoId ( int PhotoId )
            {
            try
                {
                var obj = baPhotoInfo.GetPhotoInfoData().
                    Where(p => p.Id == PhotoId
                    )
                    .Select(p => new PhotoSW.CF.DataLayer.BAL.baPhotoInfo
                        {
                        PS_Photos_pkey = p.Id,
                        PS_Photos_FileName = p.PS_Photos_FileName,
                        PS_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                        PS_Photos_RFID = p.PS_Photos_RFID,
                        PS_Photos_UserID = p.PS_Photos_UserID,
                        PS_Photos_Background = p.PS_Photos_Background,
                        PS_Photos_Frame = p.PS_Photos_Frame,
                        PS_Photos_DateTime = p.PS_Photos_DateTime,
                        PS_Photos_Layering = p.PS_Photos_Layering,
                        PS_Photos_Effects = p.PS_Photos_Effects,
                        PS_Photos_IsCroped = p.PS_Photos_IsCroped,
                        PS_Photos_IsRedEye = p.PS_Photos_IsRedEye,
                        PS_Photos_IsGreen = p.PS_Photos_IsGreen,
                        PS_Photos_MetaData = p.PS_Photos_MetaData,
                        PS_Photos_Sizes = p.PS_Photos_Sizes,
                        PS_Photos_Archive = p.PS_Photos_Archive,
                        PS_Location_Id = p.PS_Location_Id,
                        PS_SubStoreId = p.PS_SubStoreId,
                        PS_IsCodeType = p.PS_IsCodeType,
                        DateTaken = p.DateTaken,
                        RfidScanType = p.RfidScanType,
                        PS_Orders_Number = p.PS_Orders_Number,
                        PS_Order_SubStoreId = p.PS_Order_SubStoreId,
                        IMIXImageAssociationId = p.IMIXImageAssociationId,
                        PS_Group_pkey = p.PS_Group_pkey,
                        PS_Group_Name = p.PS_Group_Name,
                        PS_Photo_ID = p.PS_Photo_ID,
                        IsImageProcessed = p.IsImageProcessed,
                        PS_User_Name = p.PS_User_Name,
                        HotFolderPath = p.HotFolderPath,
                       // HotFolderPath = AppDomain.CurrentDomain.BaseDirectory + p.HotFolderPath,
                        PS_Photos_CharacterID = p.PS_Photos_CharacterID,
                        PS_MediaType = p.PS_MediaType,
                        PS_VideoLength = p.PS_VideoLength,
                        SemiOrderProfileId = p.SemiOrderProfileId,
                        IsGumRideShow = p.IsGumRideShow,
                        OnlineQRCode = p.OnlineQRCode,

                        }).FirstOrDefault();
                return obj;
                }
            catch(Exception)
                {

                return null;
                }
            }
        public List<PhotoSW.IMIX.Model.PhotoDetail> GetPhotoDetailsByPhotoIds(PhotoSW.IMIX.Model.PhotoDetail photoDetailObj)
        {
            List<PhotoSW.IMIX.Model.PhotoDetail> obj = new List<PhotoDetail>();
            return obj;
            }
        public List<PhotoSW.IMIX.Model.PhotoDetail> GetPhotoDetailsByPhotoIds(string PhotoIds)
        {
            List<PhotoSW.IMIX.Model.PhotoDetail> obj = new List<PhotoDetail>();
            return obj;
        }
        public List<PhotoSW.IMIX.Model.PhotoGraphersInfo> GetPhotoGrapher()
        {
            List<PhotoSW.IMIX.Model.PhotoGraphersInfo> obj = new List<PhotoGraphersInfo>();
            return obj;
        }


        public string GetSearchNoPhotoInfo()
        {
            try
            {
                // PhotoInfo //DG_Photos_RFID
                return baPhotoInfo.GetStartNoPhotoInfo().Last().PS_Photos_RFID; ;
            }
            catch
            {
                return "";
            }
        }

        public string GetStartNoPhotoInfo()
        {
            try
            {
                // PhotoInfo //DG_Photos_RFID
                int max = baPhotoInfo.GetStartNoPhotoInfo().Max(p => p.PS_Photo_ID);
                if (max > 0)
                {
                    max = max + 1;
                    return max.ToString();
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }

        public string GetPhotoGrapherLastImageId(int photographerid)
        {
            try
            {
                // PhotoInfo //DG_Photos_RFID
                return baPhotoInfo.GetPhotoInfoDataById(photographerid).PS_Photos_RFID;
            }
            catch
            {
                return "";
            }
        }
        public PhotoSW.IMIX.Model.PhotoInfo GetPhotoNameByPhotoID(long PhotoId)
        {
            try
            {
                var obj = baPhotoInfo.GetPhotoInfoData().
                    Where(p => p.Id == PhotoId
                    )
                    .Select(p => new PhotoSW.IMIX.Model.PhotoInfo
                    {
                        DG_Photos_pkey = p.Id,
                        DG_Photos_FileName = p.PS_Photos_FileName,
                        DG_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                        DG_Photos_RFID = p.PS_Photos_RFID,
                        DG_Photos_UserID = p.PS_Photos_UserID,
                        DG_Photos_Background = p.PS_Photos_Background,
                        DG_Photos_Frame = p.PS_Photos_Frame,
                        DG_Photos_DateTime = p.PS_Photos_DateTime,
                        DG_Photos_Layering = p.PS_Photos_Layering,
                        DG_Photos_Effects = p.PS_Photos_Effects,
                        DG_Photos_IsCroped = p.PS_Photos_IsCroped,
                        DG_Photos_IsRedEye = p.PS_Photos_IsRedEye,
                        DG_Photos_IsGreen = p.PS_Photos_IsGreen,
                        DG_Photos_MetaData = p.PS_Photos_MetaData,
                        DG_Photos_Sizes = p.PS_Photos_Sizes,
                        DG_Photos_Archive = p.PS_Photos_Archive,
                        DG_Location_Id = p.PS_Location_Id,
                        DG_SubStoreId = p.PS_SubStoreId,
                        DG_IsCodeType = p.PS_IsCodeType,
                        DateTaken = p.DateTaken,
                        RfidScanType = p.RfidScanType,
                        DG_Orders_Number = p.PS_Orders_Number,
                        DG_Order_SubStoreId = p.PS_Order_SubStoreId,
                        IMIXImageAssociationId = p.IMIXImageAssociationId,
                        DG_Group_pkey = p.PS_Group_pkey,
                        DG_Group_Name = p.PS_Group_Name,
                        DG_Photo_ID = p.PS_Photo_ID,
                        IsImageProcessed = p.IsImageProcessed,
                        DG_User_Name = p.PS_User_Name,
                        HotFolderPath = AppDomain.CurrentDomain.BaseDirectory+ p.HotFolderPath,
                        DG_Photos_CharacterID = p.PS_Photos_CharacterID,
                        DG_MediaType = p.PS_MediaType,
                        DG_VideoLength = p.PS_VideoLength,
                        SemiOrderProfileId = p.SemiOrderProfileId,
                        IsGumRideShow = p.IsGumRideShow,
                        OnlineQRCode = p.OnlineQRCode,


                    }).FirstOrDefault();
                return obj;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public string GetPhotoPlayerScore(string photoId)
        {
            return "";
        }
        public PhotoSW.IMIX.Model.PhotoInfo GetPhotoRFIDByPhotoID(long PhotoId)
        {
            try
            {
                var obj = baPhotoInfo.GetPhotoInfoData().
                    Where(p => p.Id == PhotoId
                    )
                    .Select(p => new PhotoSW.IMIX.Model.PhotoInfo
                    {
                        DG_Photos_pkey = p.Id,
                        DG_Photos_FileName = p.PS_Photos_FileName,
                        DG_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                        DG_Photos_RFID = p.PS_Photos_RFID,
                        DG_Photos_UserID = p.PS_Photos_UserID,
                        DG_Photos_Background = p.PS_Photos_Background,
                        DG_Photos_Frame = p.PS_Photos_Frame,
                        DG_Photos_DateTime = p.PS_Photos_DateTime,
                        DG_Photos_Layering = p.PS_Photos_Layering,
                        DG_Photos_Effects = p.PS_Photos_Effects,
                        DG_Photos_IsCroped = p.PS_Photos_IsCroped,
                        DG_Photos_IsRedEye = p.PS_Photos_IsRedEye,
                        DG_Photos_IsGreen = p.PS_Photos_IsGreen,
                        DG_Photos_MetaData = p.PS_Photos_MetaData,
                        DG_Photos_Sizes = p.PS_Photos_Sizes,
                        DG_Photos_Archive = p.PS_Photos_Archive,
                        DG_Location_Id = p.PS_Location_Id,
                        DG_SubStoreId = p.PS_SubStoreId,
                        DG_IsCodeType = p.PS_IsCodeType,
                        DateTaken = p.DateTaken,
                        RfidScanType = p.RfidScanType,
                        DG_Orders_Number = p.PS_Orders_Number,
                        DG_Order_SubStoreId = p.PS_Order_SubStoreId,
                        IMIXImageAssociationId = p.IMIXImageAssociationId,
                        DG_Group_pkey = p.PS_Group_pkey,
                        DG_Group_Name = p.PS_Group_Name,
                        DG_Photo_ID = p.PS_Photo_ID,
                        IsImageProcessed = p.IsImageProcessed,
                        DG_User_Name = p.PS_User_Name,
                        HotFolderPath = AppDomain.CurrentDomain.BaseDirectory+ p.HotFolderPath,
                        DG_Photos_CharacterID = p.PS_Photos_CharacterID,
                        DG_MediaType = p.PS_MediaType,
                        DG_VideoLength = p.PS_VideoLength,
                        SemiOrderProfileId = p.SemiOrderProfileId,
                        IsGumRideShow = p.IsGumRideShow,
                        OnlineQRCode = p.OnlineQRCode,


                    }).FirstOrDefault();
                return obj;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<PhotoSW.IMIX.Model.PhotoInfo> GetPhotoRFIDByPhotoIDList(string photoIdList)
        {
        string[] source = photoIdList.Split(new char[]
				{
					','
				});
        var lstStr = source.ToList();
            List<int> lstIntIds=new List<int> ();
        foreach(var i in lstStr)
            {
            lstIntIds.Add(Convert.ToInt32(i));
            }
        try
            {
            var obj = baPhotoInfo.GetPhotoInfoData().
                Where(p => lstIntIds.Contains(p.Id)
                )
                .Select(p => new PhotoSW.IMIX.Model.PhotoInfo
                {
                    DG_Photos_pkey = p.Id,
                    DG_Photos_FileName = p.PS_Photos_FileName,
                    DG_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                    DG_Photos_RFID = p.PS_Photos_RFID,
                    DG_Photos_UserID = p.PS_Photos_UserID,
                    DG_Photos_Background = p.PS_Photos_Background,
                    DG_Photos_Frame = p.PS_Photos_Frame,
                    DG_Photos_DateTime = p.PS_Photos_DateTime,
                    DG_Photos_Layering = p.PS_Photos_Layering,
                    DG_Photos_Effects = p.PS_Photos_Effects,
                    DG_Photos_IsCroped = p.PS_Photos_IsCroped,
                    DG_Photos_IsRedEye = p.PS_Photos_IsRedEye,
                    DG_Photos_IsGreen = p.PS_Photos_IsGreen,
                    DG_Photos_MetaData = p.PS_Photos_MetaData,
                    DG_Photos_Sizes = p.PS_Photos_Sizes,
                    DG_Photos_Archive = p.PS_Photos_Archive,
                    DG_Location_Id = p.PS_Location_Id,
                    DG_SubStoreId = p.PS_SubStoreId,
                    DG_IsCodeType = p.PS_IsCodeType,
                    DateTaken = p.DateTaken,
                    RfidScanType = p.RfidScanType,
                    DG_Orders_Number = p.PS_Orders_Number,
                    DG_Order_SubStoreId = p.PS_Order_SubStoreId,
                    IMIXImageAssociationId = p.IMIXImageAssociationId,
                    DG_Group_pkey = p.PS_Group_pkey,
                    DG_Group_Name = p.PS_Group_Name,
                    DG_Photo_ID = p.PS_Photo_ID,
                    IsImageProcessed = p.IsImageProcessed,
                    DG_User_Name = p.PS_User_Name,
                    HotFolderPath = AppDomain.CurrentDomain.BaseDirectory + p.HotFolderPath,
                    DG_Photos_CharacterID = p.PS_Photos_CharacterID,
                    DG_MediaType = p.PS_MediaType,
                    DG_VideoLength = p.PS_VideoLength,
                    SemiOrderProfileId = p.SemiOrderProfileId,
                    IsGumRideShow = p.IsGumRideShow,
                    OnlineQRCode = p.OnlineQRCode,


                }).ToList();
            return obj;
            }
        catch(Exception)
            {

            return null;
            }
        }
        public List<PhotoSW.IMIX.Model.PhotoInfo> GetPhotosBasedonRFID(int substoreId, string RFID)
        {
            try
            {
                var obj = baPhotoInfo.GetPhotoInfoData().
                    Where(p => p.PS_Photos_RFID == RFID && p.PS_SubStoreId==substoreId
                    )
                    .Select(p => new PhotoSW.IMIX.Model.PhotoInfo
                    {
                        DG_Photos_pkey = p.Id,
                        DG_Photos_FileName = p.PS_Photos_FileName,
                        DG_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                        DG_Photos_RFID = p.PS_Photos_RFID,
                        DG_Photos_UserID = p.PS_Photos_UserID,
                        DG_Photos_Background = p.PS_Photos_Background,
                        DG_Photos_Frame = p.PS_Photos_Frame,
                        DG_Photos_DateTime = p.PS_Photos_DateTime,
                        DG_Photos_Layering = p.PS_Photos_Layering,
                        DG_Photos_Effects = p.PS_Photos_Effects,
                        DG_Photos_IsCroped = p.PS_Photos_IsCroped,
                        DG_Photos_IsRedEye = p.PS_Photos_IsRedEye,
                        DG_Photos_IsGreen = p.PS_Photos_IsGreen,
                        DG_Photos_MetaData = p.PS_Photos_MetaData,
                        DG_Photos_Sizes = p.PS_Photos_Sizes,
                        DG_Photos_Archive = p.PS_Photos_Archive,
                        DG_Location_Id = p.PS_Location_Id,
                        DG_SubStoreId = p.PS_SubStoreId,
                        DG_IsCodeType = p.PS_IsCodeType,
                        DateTaken = p.DateTaken,
                        RfidScanType = p.RfidScanType,
                        DG_Orders_Number = p.PS_Orders_Number,
                        DG_Order_SubStoreId = p.PS_Order_SubStoreId,
                        IMIXImageAssociationId = p.IMIXImageAssociationId,
                        DG_Group_pkey = p.PS_Group_pkey,
                        DG_Group_Name = p.PS_Group_Name,
                        DG_Photo_ID = p.PS_Photo_ID,
                        IsImageProcessed = p.IsImageProcessed,
                        DG_User_Name = p.PS_User_Name,
                        HotFolderPath =AppDomain.CurrentDomain.BaseDirectory+ p.HotFolderPath,
                        DG_Photos_CharacterID = p.PS_Photos_CharacterID,
                        DG_MediaType = p.PS_MediaType,
                        DG_VideoLength = p.PS_VideoLength,
                        SemiOrderProfileId = p.SemiOrderProfileId,
                        IsGumRideShow = p.IsGumRideShow,
                        OnlineQRCode = p.OnlineQRCode,


                    }).ToList();
                return obj;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<string> GetQRCodeBYImages(string PhotoId)
        {
            List<string> obj = new List<string>();
            return obj;
        }
        public List<PhotoSW.IMIX.Model.PhotoInfo> GetSavedGroupImages(string GroupName)
        {
            try
            {
                var obj = baPhotoInfo.GetPhotoInfoData().
                    Where(p => p.PS_Group_Name == GroupName
                    )
                    .Select(p => new PhotoSW.IMIX.Model.PhotoInfo
                    {
                        DG_Photos_pkey = p.Id,
                        DG_Photos_FileName = p.PS_Photos_FileName,
                        DG_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                        DG_Photos_RFID = p.PS_Photos_RFID,
                        DG_Photos_UserID = p.PS_Photos_UserID,
                        DG_Photos_Background = p.PS_Photos_Background,
                        DG_Photos_Frame = p.PS_Photos_Frame,
                        DG_Photos_DateTime = p.PS_Photos_DateTime,
                        DG_Photos_Layering = p.PS_Photos_Layering,
                        DG_Photos_Effects = p.PS_Photos_Effects,
                        DG_Photos_IsCroped = p.PS_Photos_IsCroped,
                        DG_Photos_IsRedEye = p.PS_Photos_IsRedEye,
                        DG_Photos_IsGreen = p.PS_Photos_IsGreen,
                        DG_Photos_MetaData = p.PS_Photos_MetaData,
                        DG_Photos_Sizes = p.PS_Photos_Sizes,
                        DG_Photos_Archive = p.PS_Photos_Archive,
                        DG_Location_Id = p.PS_Location_Id,
                        DG_SubStoreId = p.PS_SubStoreId,
                        DG_IsCodeType = p.PS_IsCodeType,
                        DateTaken = p.DateTaken,
                        RfidScanType = p.RfidScanType,
                        DG_Orders_Number = p.PS_Orders_Number,
                        DG_Order_SubStoreId = p.PS_Order_SubStoreId,
                        IMIXImageAssociationId = p.IMIXImageAssociationId,
                        DG_Group_pkey = p.PS_Group_pkey,
                        DG_Group_Name = p.PS_Group_Name,
                        DG_Photo_ID = p.PS_Photo_ID,
                        IsImageProcessed = p.IsImageProcessed,
                        DG_User_Name = p.PS_User_Name,
                        HotFolderPath = AppDomain.CurrentDomain.BaseDirectory + p.HotFolderPath,
                        DG_Photos_CharacterID = p.PS_Photos_CharacterID,
                        DG_MediaType = p.PS_MediaType,
                        DG_VideoLength = p.PS_VideoLength,
                        SemiOrderProfileId = p.SemiOrderProfileId,
                        IsGumRideShow = p.IsGumRideShow,
                        OnlineQRCode = p.OnlineQRCode,


                    }).ToList();
                return obj;
            }
            catch (Exception)
            {

                return null;
            }
        }
        //public List<PhotoSW.IMIX.Model.PhotoInfo> GetSearchedPhoto(DateTime? fromTime, 
        //    DateTime? ToTime, int? UserId, int? LocationId, string substoreId)
        //{
        //    try
        //    {

        //        int substore_Id = Convert.ToInt32(substoreId);
        //        var obj = baPhotoInfo.GetPhotoInfoData().
        //            Where(p => p.PS_Photos_UserID == UserId 
        //                && p.PS_Location_Id== LocationId
        //                && p.PS_SubStoreId== substore_Id
        //                && p.PS_Photos_CreatedOn >= Convert.ToDateTime(fromTime) 
        //                && p.PS_Photos_CreatedOn >= Convert.ToDateTime(ToTime)
        //            )
        //            .Select(p => new PhotoSW.IMIX.Model.PhotoInfo
        //            {
        //                DG_Photos_pkey = p.Id,
        //                DG_Photos_FileName = p.PS_Photos_FileName,
        //                DG_Photos_CreatedOn = p.PS_Photos_CreatedOn,
        //                DG_Photos_RFID = p.PS_Photos_RFID,
        //                DG_Photos_UserID = p.PS_Photos_UserID,
        //                DG_Photos_Background = p.PS_Photos_Background,
        //                DG_Photos_Frame = p.PS_Photos_Frame,
        //                DG_Photos_DateTime = p.PS_Photos_DateTime,
        //                DG_Photos_Layering = p.PS_Photos_Layering,
        //                DG_Photos_Effects = p.PS_Photos_Effects,
        //                DG_Photos_IsCroped = p.PS_Photos_IsCroped,
        //                DG_Photos_IsRedEye = p.PS_Photos_IsRedEye,
        //                DG_Photos_IsGreen = p.PS_Photos_IsGreen,
        //                DG_Photos_MetaData = p.PS_Photos_MetaData,
        //                DG_Photos_Sizes = p.PS_Photos_Sizes,
        //                DG_Photos_Archive = p.PS_Photos_Archive,
        //                DG_Location_Id = p.PS_Location_Id,
        //                DG_SubStoreId = p.PS_SubStoreId,
        //                DG_IsCodeType = p.PS_IsCodeType,
        //                DateTaken = p.DateTaken,
        //                RfidScanType = p.RfidScanType,
        //                DG_Orders_Number = p.PS_Orders_Number,
        //                DG_Order_SubStoreId = p.PS_Order_SubStoreId,
        //                IMIXImageAssociationId = p.IMIXImageAssociationId,
        //                DG_Group_pkey = p.PS_Group_pkey,
        //                DG_Group_Name = p.PS_Group_Name,
        //                DG_Photo_ID = p.PS_Photo_ID,
        //                IsImageProcessed = p.IsImageProcessed,
        //                DG_User_Name = p.PS_User_Name,
        //                HotFolderPath = AppDomain.CurrentDomain.BaseDirectory + p.HotFolderPath,
        //                DG_Photos_CharacterID = p.PS_Photos_CharacterID,
        //                DG_MediaType = p.PS_MediaType,
        //                DG_VideoLength = p.PS_VideoLength,
        //                SemiOrderProfileId = p.SemiOrderProfileId,
        //                IsGumRideShow = p.IsGumRideShow,
        //                OnlineQRCode = p.OnlineQRCode,


        //            }).ToList();
        //        return obj;
        //    }
        //    catch (Exception)
        //    {

        //        return null;
        //    }
        //}

        public List<PhotoSW.IMIX.Model.PhotoInfo> GetSearchedPhoto ( DateTime? fromTime,
       DateTime? ToTime, int? UserId, int? LocationId, string substoreId )
            {
            try
                {
                //===============Senki======================
                int substore_Id = Convert.ToInt32(substoreId);
                List<baPhotoInfo> obj = baPhotoInfo.GetPhotoInfoData();
                if(UserId > 0)
                    obj = obj.Where(p => p.PS_Photos_UserID == UserId).ToList();
                if(LocationId > 0)
                    obj = obj.Where(p => p.PS_Location_Id == LocationId).ToList();
                if(substore_Id > 0)
                    obj = obj.Where(p => p.PS_SubStoreId == substore_Id).ToList();

                obj = obj.Where(p => p.DateTaken >= Convert.ToDateTime(fromTime)
                        && p.DateTaken <= Convert.ToDateTime(ToTime)).ToList();

                //===============================================================

                var obj1 = obj.Select(p => new PhotoSW.IMIX.Model.PhotoInfo
                    {
                    DG_Photos_pkey = p.Id,
                    DG_Photos_FileName = p.PS_Photos_FileName,
                    DG_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                    DG_Photos_RFID = p.PS_Photos_RFID,
                    DG_Photos_UserID = p.PS_Photos_UserID,
                    DG_Photos_Background = p.PS_Photos_Background,
                    DG_Photos_Frame = p.PS_Photos_Frame,
                    DG_Photos_DateTime = p.PS_Photos_DateTime,
                    DG_Photos_Layering = p.PS_Photos_Layering,
                    DG_Photos_Effects = p.PS_Photos_Effects,
                    DG_Photos_IsCroped = p.PS_Photos_IsCroped,
                    DG_Photos_IsRedEye = p.PS_Photos_IsRedEye,
                    DG_Photos_IsGreen = p.PS_Photos_IsGreen,
                    DG_Photos_MetaData = p.PS_Photos_MetaData,
                    DG_Photos_Sizes = p.PS_Photos_Sizes,
                    DG_Photos_Archive = p.PS_Photos_Archive,
                    DG_Location_Id = p.PS_Location_Id,
                    DG_SubStoreId = p.PS_SubStoreId,
                    DG_IsCodeType = p.PS_IsCodeType,
                    DateTaken = p.DateTaken,
                    RfidScanType = p.RfidScanType,
                    DG_Orders_Number = p.PS_Orders_Number,
                    DG_Order_SubStoreId = p.PS_Order_SubStoreId,
                    IMIXImageAssociationId = p.IMIXImageAssociationId,
                    DG_Group_pkey = p.PS_Group_pkey,
                    DG_Group_Name = p.PS_Group_Name,
                    DG_Photo_ID = p.PS_Photo_ID,
                    IsImageProcessed = p.IsImageProcessed,
                    DG_User_Name = p.PS_User_Name,
                    HotFolderPath = AppDomain.CurrentDomain.BaseDirectory + p.HotFolderPath,
                    DG_Photos_CharacterID = p.PS_Photos_CharacterID,
                    DG_MediaType = p.PS_MediaType,
                    DG_VideoLength = p.PS_VideoLength,
                    SemiOrderProfileId = p.SemiOrderProfileId,
                    IsGumRideShow = p.IsGumRideShow,
                    OnlineQRCode = p.OnlineQRCode,


                    }).ToList();
                return obj1;
                }
            catch(Exception)
                {

                return null;
                }
            }
        public string GetVideoFrameCropRatio ( int locationid )
            { return ""; }
        public void immoderate(long PhotoId)
        {
        }
        public bool ResetImageProcessedStatus(int PhotoId, int SubStoreId)
        {
            return false;
        }
        public bool SaveCroppedPhotoInfo(long PhotoId, object value, string effects)
        {
            return false;
        }
        public void SaveGroupData(Dictionary<string, string> _objPhotoDetails, string groupname, int SubStoreId)
        {
        }
        public bool SaveIsCropedPhotos(long PhotoId, object value, string operation)
        {
            return false;
        }
        public bool SaveIsGreenPhotos(long PhotoId, bool value)
        {
            return false;
        }
        public void SetArchiveDetails(string imgname)
        {
           
        }
        public bool SetEffectsonPhoto(string value, int photoId, bool isgumballshow)
        {
            return false;
        }
        public long SetImageAssociationInfo(int PhotoId, string Format, string Code, bool IsAnonymousCodeActive)
        {
            return 1;
        }
        public bool SetImageAssociationInfoForPostScan(List<int> PhotoIdList, string Format, string Code, bool IsAnonymousCodeActive)
        {
            return false;
        }
        public bool SetModerateImage(int PhotoId, int userid)
        {
            return false;
        }

        public int SetPhotoDetails1 ( int subStoreId, string DG_Photos_RFID, string DG_Photos_FileName,
           DateTime DG_Photos_CreatedOn, string userid, string imgmetadata, int locationid,
           string photolayer, string DG_Photos_Effects, DateTime? DateTaken, int? RfidScanType,
           int? CharacterID, int? Photos_No)
            {
            baPhotoInfo baPhotoInfo = new baPhotoInfo();
            string effects = "<image brightness = '0' contrast = '1' Crop='##' colourvalue = '##' rotatewidth='##' rotateheight='##' rotate='##' flipMode='0' flipModeY='0' _centerx ='0' _centery='0'><effects sharpen='##'></effects></image>";
            //string effects = "<image brightness = '0' contrast = '1' Crop='##' colourvalue = '##' rotatewidth='##' rotateheight='##' rotate='##' flipMode='0' flipModeY='0' _centerx ='0' _centery='0'><effects sharpen='##' greyscale='0' digimagic='0' sepia='0' defog='0' underwater='0' emboss='0' invert = '0' granite='0' hue ='##' cartoon = '0' firstredeye= 'false' firstradius='.0105' firstcenterx='.5' firstcentery='.5' secondredeye= 'false' secondradius='.0105' secondcenterx='.5' secondcentery='.5' multipleredeye1='false' multipleredeye2='false' multipleredeye3='false' multipleredeye4='false' multipleredeye5='false' multipleredeye6='false' multipleradius1='.0105' multipleradius2='0' multipleradius3='0' multipleradius4='0.0125' multipleradius5='0' multipleradius6='0' multiplecenterx1='.5' multiplecentery1='.5' multiplecenterx2='0' multiplecentery2='0' multiplecenterx3='0' multiplecentery3='0' multiplecenterx4='.5' multiplecentery4='.5' multiplecenterx5='0' multiplecentery5='0' multiplecenterx6='0' multiplecentery6='0'></effects></image>";

            //baPhotoInfo.Id = subStoreId;
            //baPhotoInfo.PS_Photos_pkey = item;
            baPhotoInfo.PS_Photos_FileName = DG_Photos_FileName;
            baPhotoInfo.PS_Photos_CreatedOn = DG_Photos_CreatedOn;
            baPhotoInfo.PS_Photos_RFID = DG_Photos_RFID;
            baPhotoInfo.PS_Photos_UserID = Convert.ToInt32(userid);
            baPhotoInfo.PS_Photos_Background =  "#00808080";
            baPhotoInfo.PS_Photos_Frame = "";
            baPhotoInfo.PS_Photos_DateTime = DateTime.Now;
            baPhotoInfo.PS_Photos_Layering = effects;
            baPhotoInfo.PS_Photos_Effects =effects;
            baPhotoInfo.PS_Photos_IsCroped = false;
            baPhotoInfo.PS_Photos_IsRedEye = false;
            baPhotoInfo.PS_Photos_IsGreen = false;
            baPhotoInfo.PS_Photos_MetaData = imgmetadata;
            baPhotoInfo.PS_Photos_Sizes = "123";
            baPhotoInfo.PS_Photos_Archive = true;
            baPhotoInfo.PS_Location_Id = 1;
            baPhotoInfo.PS_SubStoreId = subStoreId;
            baPhotoInfo.PS_IsCodeType = true;
            baPhotoInfo.DateTaken = DateTaken;
            baPhotoInfo.RfidScanType = RfidScanType;
            baPhotoInfo.PS_Orders_Number = "1";
            baPhotoInfo.PS_Order_SubStoreId = 3;
            baPhotoInfo.IMIXImageAssociationId = 1;
            baPhotoInfo.PS_Group_pkey = 1;
            baPhotoInfo.PS_Group_Name = "Test";
            baPhotoInfo.PS_Photo_ID =(int) Photos_No;
            baPhotoInfo.IsImageProcessed = 1;
            baPhotoInfo.PS_User_Name = "Test";
            baPhotoInfo.HotFolderPath = "HotFolderPath\\";
            baPhotoInfo.PS_Photos_CharacterID = Convert.ToString(CharacterID);
            baPhotoInfo.PS_MediaType = 1;
            baPhotoInfo.PS_VideoLength = 1;
            baPhotoInfo.SemiOrderProfileId = 1;
            baPhotoInfo.IsGumRideShow = true;
            baPhotoInfo.OnlineQRCode = "";
            baPhotoInfo.IsActive = true;

            baPhotoInfo.Insert(baPhotoInfo);

            return 0;
            }
        public int SetPhotoDetails(int subStoreId, string DG_Photos_RFID, string DG_Photos_FileName,
            DateTime DG_Photos_CreatedOn, string userid, string imgmetadata, int locationid,
            string photolayer, string DG_Photos_Effects, DateTime? DateTaken, int? RfidScanType,
            int? CharacterID)
        {
             baPhotoInfo baPhotoInfo = new baPhotoInfo();
             //string effects = "<image brightness = '0' contrast = '1' Crop='##' colourvalue = '##' rotatewidth='##' rotateheight='##' rotate='##' flipMode='0' flipModeY='0' _centerx ='0' _centery='0'><effects sharpen='##' greyscale='0' digimagic='0' sepia='0' defog='0' underwater='0' emboss='0' invert = '0' granite='0' hue ='##' cartoon = '0' firstredeye= 'false' firstradius='.0105' firstcenterx='.5' firstcentery='.5' secondredeye= 'false' secondradius='.0105' secondcenterx='.5' secondcentery='.5' multipleredeye1='false' multipleredeye2='false' multipleredeye3='false' multipleredeye4='false' multipleredeye5='false' multipleredeye6='false' multipleradius1='.0105' multipleradius2='0' multipleradius3='0' multipleradius4='0.0125' multipleradius5='0' multipleradius6='0' multiplecenterx1='.5' multiplecentery1='.5' multiplecenterx2='0' multiplecentery2='0' multiplecenterx3='0' multiplecentery3='0' multiplecenterx4='.5' multiplecentery4='.5' multiplecenterx5='0' multiplecentery5='0' multiplecenterx6='0' multiplecentery6='0'></effects></image>";
           
                        //baPhotoInfo.Id = subStoreId;
                        //baPhotoInfo.PS_Photos_pkey = item;
             baPhotoInfo.PS_Photos_FileName = DG_Photos_FileName;
             baPhotoInfo.PS_Photos_CreatedOn = DG_Photos_CreatedOn;
             baPhotoInfo.PS_Photos_RFID = DG_Photos_RFID;
                        baPhotoInfo.PS_Photos_UserID =Convert.ToInt32(userid);
                        baPhotoInfo.PS_Photos_Background = "#00808080";
                        baPhotoInfo.PS_Photos_Frame = "";
                        baPhotoInfo.PS_Photos_DateTime = DateTime.Now;
                        baPhotoInfo.PS_Photos_Layering = photolayer;
                        baPhotoInfo.PS_Photos_Effects = DG_Photos_Effects;
                        baPhotoInfo.PS_Photos_IsCroped = false;
                        baPhotoInfo.PS_Photos_IsRedEye = false;
                        baPhotoInfo.PS_Photos_IsGreen = false;
                        baPhotoInfo.PS_Photos_MetaData = imgmetadata;
                        baPhotoInfo.PS_Photos_Sizes = "123";
                        baPhotoInfo.PS_Photos_Archive = true;
                        baPhotoInfo.PS_Location_Id = 1;
                        baPhotoInfo.PS_SubStoreId = subStoreId;
                        baPhotoInfo.PS_IsCodeType = true;
                        baPhotoInfo.DateTaken = DateTaken;
                        baPhotoInfo.RfidScanType = RfidScanType;
                        baPhotoInfo.PS_Orders_Number = "1";
                        baPhotoInfo.PS_Order_SubStoreId = 3;
                        baPhotoInfo.IMIXImageAssociationId = 1;
                        baPhotoInfo.PS_Group_pkey = 1;
                        baPhotoInfo.PS_Group_Name = "Test";
                        baPhotoInfo.PS_Photo_ID = 1;
                        baPhotoInfo.IsImageProcessed = 1;
                        baPhotoInfo.PS_User_Name = "Test";
                        baPhotoInfo.HotFolderPath = "HotFolderPath\\";
                        baPhotoInfo.PS_Photos_CharacterID =Convert .ToString( CharacterID);
                        baPhotoInfo.PS_MediaType = 1;
                        baPhotoInfo.PS_VideoLength = 1;
                        baPhotoInfo.SemiOrderProfileId = 1;
                        baPhotoInfo.IsGumRideShow = true;
                        baPhotoInfo.OnlineQRCode = "";
                        baPhotoInfo.IsActive = true;

                        baPhotoInfo.Insert(baPhotoInfo);
       
            return 0;
        }
        public int SetPhotoDetails(int subStoreId, string DG_Photos_RFID,
            string DG_Photos_FileName, DateTime DG_Photos_CreatedOn,
            string userid, string imgmetadata, int locationid,
            string photolayer, string DG_Photos_Effects, DateTime? DateTaken,
            int? RfidScanType, int IsImageProcessed, int? CharacterID)
        {
            return 0;
        }
        public int SetPhotoDetails(int subStoreId, string DG_Photos_RFID, string DG_Photos_FileName,
            DateTime DG_Photos_CreatedOn, string userid, string imgmetadata,
            int locationid, string photolayer, string DG_Photos_Effects,
            DateTime? DateTaken, int? RfidScanType, int IsImageProcessed,
            int? CharacterID, long? VideoLength, bool IsVideoProcessed,
            int? mediatype = 1, int? ParentImageId = 0,
            string OriginalFileName = null, int SemiOrderProfileId = 0, bool IsCroped = false)
        {
            return 0;
        }
        public void SetPreviewCounter(int PhotoId)
        {
           
        }
        public bool TruncatePhotoGroupTable(int days, int substoreID)
        {
            return false;
        }
        public bool TruncatePhotoGroupTablefordate(int days, int substoreID)
        {
            return false;
        }
        public void UpdateEffectsSpecPrint(int photoId, string layeringdata,
            string ImageEffect, bool isGreenSreen,
            bool isCrop, bool isgumballshow,
            string GumBallRidetxtContent, string _qrCode)
        {
        }
        public bool UpdateImageProcessedStatus(int PhotoId, int ProcessedStatus)
        {
            return false;
        }
        public bool UpdateLayering(int PhotoId, string value)
        {
            return false;
        }
        public bool UpdateLayeringForSpecPrint(int PhotoId, string value)
        {
            return false;
        }
        public void UpdateOnlineQRCodeForPhoto(int photoId, string OnlineQRCode)
        {
            
        }
        public bool UpdateVideoProcessedStatus(int PhotoId, bool ProcessedStatus)
        {
            return false;
        }
    }
}
