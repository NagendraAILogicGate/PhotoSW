using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
{
    public class baPhotoInfo
    {
        public int Id { get; set; }
        public int PS_Photos_pkey { get; set; }
        public string PS_Photos_FileName { get; set; }
        public DateTime PS_Photos_CreatedOn { get; set; }
        public string PS_Photos_RFID { get; set; }
        public int? PS_Photos_UserID { get; set; }
        public string PS_Photos_Background { get; set; }
        public string PS_Photos_Frame { get; set; }
        public DateTime? PS_Photos_DateTime { get; set; }
        public string PS_Photos_Layering { get; set; }
        public string PS_Photos_Effects { get; set; }
        public bool? PS_Photos_IsCroped { get; set; }
        public bool? PS_Photos_IsRedEye { get; set; }
        public bool? PS_Photos_IsGreen { get; set; }
        public string PS_Photos_MetaData { get; set; }
        public string PS_Photos_Sizes { get; set; }
        public bool? PS_Photos_Archive { get; set; }
        public int? PS_Location_Id { get; set; }
        public int? PS_SubStoreId { get; set; }
        public bool PS_IsCodeType { get; set; }
        public DateTime? DateTaken { get; set; }
        public int? RfidScanType { get; set; }
        public string PS_Orders_Number { get; set; }
        public int PS_Order_SubStoreId { get; set; }
        public long IMIXImageAssociationId { get; set; }
        public long PS_Group_pkey { get; set; }
        public string PS_Group_Name { get; set; }
        public int PS_Photo_ID { get; set; }
        public int? IsImageProcessed { get; set; }
        public string PS_User_Name { get; set; }
        public string HotFolderPath { get; set; }
        public string PS_Photos_CharacterID { get; set; }
        public int PS_MediaType { get; set; }
        public long? PS_VideoLength { get; set; }
        public int SemiOrderProfileId { get; set; }
        public bool IsGumRideShow { get; set; }

        public bool IsCollageShow { get; set; }
        public string OnlineQRCode { get; set; } 
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {

            string effects = "<image brightness = '0' contrast = '1' Crop='##' colourvalue = '##' rotatewidth='##' rotateheight='##' rotate='##' flipMode='0' flipModeY='0' _centerx ='0' _centery='0'><effects sharpen='##'></effects></image>";
            //string effects = "<image brightness = '0' contrast = '1' Crop='##' colourvalue = '##' rotatewidth='##' rotateheight='##' rotate='##' flipMode='0' flipModeY='0' _centerx ='0' _centery='0'><effects sharpen='##' greyscale='0' digimagic='0' sepia='0' defog='0' underwater='0' emboss='0' invert = '0' granite='0' hue ='##' cartoon = '0' firstredeye= 'false' firstradius='0' firstcenterx='0' firstcentery='0' secondredeye= 'false' secondradius='0' secondcenterx='0' secondcentery='0' multipleredeye1='false' multipleredeye2='false' multipleredeye3='false' multipleredeye4='false' multipleredeye5='false' multipleredeye6='false' multipleradius1='0' multipleradius2='0' multipleradius3='0' multipleradius4='0' multipleradius5='0' multipleradius6='0' multiplecenterx1='0' multiplecentery1='0' multiplecenterx2='0' multiplecentery2='0' multiplecenterx3='0' multiplecentery3='0' multiplecenterx4='0' multiplecentery4='0' multiplecenterx5='0' multiplecentery5='0' multiplecenterx6='0' multiplecentery6='0'></effects></image>";
            //string effects = "<image brightness = '0' contrast = '1' Crop='##' colourvalue = '##' rotatewidth='##' rotateheight='##' rotate='##' flipMode='0' flipModeY='0' _centerx ='0' _centery='0'><effects sharpen='##' greyscale='0' digimagic='0' sepia='0' defog='0' underwater='0' emboss='0' invert = '0' granite='0' hue ='##' cartoon = '0' firstredeye= 'false' firstradius='.0105' firstcenterx='.5' firstcentery='.5' secondredeye= 'false' secondradius='.0105' secondcenterx='.5' secondcentery='.5' multipleredeye1='false' multipleredeye2='false' multipleredeye3='false' multipleredeye4='false' multipleredeye5='false' multipleredeye6='false' multipleradius1='.0105' multipleradius2='0' multipleradius3='0' multipleradius4='0.0125' multipleradius5='0' multipleradius6='0' multiplecenterx1='.5' multiplecentery1='.5' multiplecenterx2='0' multiplecentery2='0' multiplecenterx3='0' multiplecentery3='0' multiplecenterx4='.5' multiplecentery4='.5' multiplecenterx5='0' multiplecentery5='0' multiplecenterx6='0' multiplecentery6='0'></effects></image>";
            string str1 = "2017-12-02 19:04:11.9474026";
            DateTime dt = DateTime.Now;
            
            DateTime dt1 = Convert.ToDateTime(str1);
           // string strdt = Convert.ToString();
            List<photoinfo> lst_photoinfo = new List<photoinfo>();
            List<int> lst_str = new List<int>();
            lst_str.Add(1);
            lst_str.Add(2);
            lst_str.Add(3);
            lst_str.Add(4);
            lst_str.Add(5);
            lst_str.Add(6);
            lst_str.Add(7);
            lst_str.Add(8);
            lst_str.Add(9);
            lst_str.Add(10);
            lst_str.Add(11);
            lst_str.Add(12);
            lst_str.Add(11);
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    foreach(var item in lst_str)
                        {
                        photoinfo photoinfo = new photoinfo();

                        photoinfo.Id = item;
                        photoinfo.PS_Photos_pkey = item;
                        photoinfo.PS_Photos_FileName = "test" + item + ".jpg";
                        photoinfo.PS_Photos_CreatedOn = dt1;
                        photoinfo.PS_Photos_RFID = "3021";
                        photoinfo.PS_Photos_UserID = 1;
                        photoinfo.PS_Photos_Background = "#00808080";
                        photoinfo.PS_Photos_Frame = "A_The-Top_CNY_8x10.png";
                        photoinfo.PS_Photos_DateTime = dt1;
                        photoinfo.PS_Photos_Layering = effects;
                        photoinfo.PS_Photos_Effects = effects;
                        photoinfo.PS_Photos_IsCroped = false;
                        photoinfo.PS_Photos_IsRedEye = false;
                        photoinfo.PS_Photos_IsGreen = false;
                        photoinfo.PS_Photos_MetaData = "meta data";
                        photoinfo.PS_Photos_Sizes = "123";
                        photoinfo.PS_Photos_Archive = true;
                        photoinfo.PS_Location_Id = 1;
                        photoinfo.PS_SubStoreId = 3;
                        photoinfo.PS_IsCodeType = true;
                        photoinfo.DateTaken = dt1;
                        photoinfo.RfidScanType = 1;
                        photoinfo.PS_Orders_Number = "1";
                        photoinfo.PS_Order_SubStoreId = 3;
                        photoinfo.IMIXImageAssociationId = 1;
                        photoinfo.PS_Group_pkey = 1;
                        photoinfo.PS_Group_Name = "Test";
                        photoinfo.PS_Photo_ID = item;
                        photoinfo.IsImageProcessed = 1;
                        photoinfo.PS_User_Name = "Test";
                        photoinfo.HotFolderPath = "HotFolderPath\\";//AppDomain.CurrentDomain.BaseDirectory;
                      //  photoinfo.HotFolderPath = "Thumbnails_Big\\";
                        photoinfo.PS_Photos_CharacterID = "1";
                        photoinfo.PS_MediaType = 1;
                        photoinfo.PS_VideoLength = 1;
                        photoinfo.SemiOrderProfileId = 1;
                        photoinfo.IsGumRideShow = true;
                        
                        photoinfo.OnlineQRCode = "";
                        photoinfo.IsActive = true;

                        lst_photoinfo.Add(photoinfo);


                        }
                    var Id = lst_photoinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PhotoInfos.Where(p => lst_str.Contains(p.Id)).ToList();
                    if(IsExist == null)
                        {
                        db.PhotoInfos.AddRange(lst_photoinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.PhotoInfos.AddRange(lst_photoinfo);
                        db.SaveChanges();
                        }
                    return true;
                    }
                }
            catch(Exception ex)
                {
                return false;
                }
            }
        public static baPhotoInfo GetPhotoInfoDataById(int Id)
        {
            try
            {

                photoinfo photoinfo = new photoinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.PhotoInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPhotoInfo
                    {
                             Id = p.Id,
                             PS_Photos_pkey = p.PS_Photos_pkey,
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
                             PS_Photos_CharacterID = p.PS_Photos_CharacterID,
                             PS_MediaType = p.PS_MediaType,
                             PS_VideoLength = p.PS_VideoLength,
                             SemiOrderProfileId = p.SemiOrderProfileId,
                             IsGumRideShow = p.IsGumRideShow,
                             IsCollageShow = p.IsCollageShow,
                             OnlineQRCode = p.OnlineQRCode,
                             IsActive = p.IsActive



                    }).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }

        public static List<baPhotoInfo> GetStartNoPhotoInfo ()
            {
            photoinfo photoinfo = new photoinfo();
            using(PhotoSWEntities db = new PhotoSWEntities())
                {
                var obj = db.PhotoInfos.Where(p => p.IsActive == true).Select(p => new baPhotoInfo
                    {
                    PS_Photos_RFID = p.PS_Photos_RFID,
                    PS_Photo_ID = p.PS_Photo_ID
                }).ToList();

                return obj;
                }
            }
        public static List<baPhotoInfo> GetPhotoInfoData()
        {
            try
            {

                photoinfo photoinfo = new photoinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.PhotoInfos.Where(p => p.IsActive == true).Select(p => new baPhotoInfo
                    {
                        Id = p.Id,
                        PS_Photos_pkey = p.PS_Photos_pkey,
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
                        PS_Photos_CharacterID = p.PS_Photos_CharacterID,
                        PS_MediaType = p.PS_MediaType,
                        PS_VideoLength = p.PS_VideoLength,
                        SemiOrderProfileId = p.SemiOrderProfileId,
                        IsGumRideShow = p.IsGumRideShow,
                        IsCollageShow = p.IsCollageShow,
                        OnlineQRCode = p.OnlineQRCode,
                        IsActive = p.IsActive

                    }).ToList();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }

        public static bool Insert ( baPhotoInfo baPhotoInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    photoinfo photoinfo = new photoinfo();

                    photoinfo.Id = baPhotoInfo.Id;
                    photoinfo.PS_Photos_pkey = baPhotoInfo.PS_Photos_pkey;
                    photoinfo.PS_Photos_FileName = baPhotoInfo.PS_Photos_FileName;
                    photoinfo.PS_Photos_CreatedOn = baPhotoInfo.PS_Photos_CreatedOn;
                    photoinfo.PS_Photos_RFID = baPhotoInfo.PS_Photos_RFID;
                    photoinfo.PS_Photos_UserID = baPhotoInfo.PS_Photos_UserID;
                    photoinfo.PS_Photos_Background = baPhotoInfo.PS_Photos_Background;
                    photoinfo.PS_Photos_Frame = baPhotoInfo.PS_Photos_Frame;
                    photoinfo.PS_Photos_DateTime = baPhotoInfo.PS_Photos_DateTime;
                    photoinfo.PS_Photos_Layering = baPhotoInfo.PS_Photos_Layering;
                    photoinfo.PS_Photos_Effects = baPhotoInfo.PS_Photos_Effects;
                    photoinfo.PS_Photos_IsCroped = baPhotoInfo.PS_Photos_IsCroped;
                    photoinfo.PS_Photos_IsRedEye = baPhotoInfo.PS_Photos_IsRedEye;
                    photoinfo.PS_Photos_IsGreen = baPhotoInfo.PS_Photos_IsGreen;
                    photoinfo.PS_Photos_MetaData = baPhotoInfo.PS_Photos_MetaData;
                    photoinfo.PS_Photos_Sizes = baPhotoInfo.PS_Photos_Sizes;
                    photoinfo.PS_Photos_Archive = baPhotoInfo.PS_Photos_Archive;
                    photoinfo.PS_Location_Id = baPhotoInfo.PS_Location_Id;
                    photoinfo.PS_SubStoreId = baPhotoInfo.PS_SubStoreId;
                    photoinfo.PS_IsCodeType = baPhotoInfo.PS_IsCodeType;
                    photoinfo.DateTaken = baPhotoInfo.DateTaken;
                    photoinfo.RfidScanType = baPhotoInfo.RfidScanType;
                    photoinfo.PS_Orders_Number = baPhotoInfo.PS_Orders_Number;
                    photoinfo.PS_Order_SubStoreId = baPhotoInfo.PS_Order_SubStoreId;
                    photoinfo.IMIXImageAssociationId = baPhotoInfo.IMIXImageAssociationId;
                    photoinfo.PS_Group_pkey = baPhotoInfo.PS_Group_pkey;
                    photoinfo.PS_Group_Name = baPhotoInfo.PS_Group_Name;
                    photoinfo.PS_Photo_ID = baPhotoInfo.PS_Photo_ID;
                    photoinfo.IsImageProcessed = baPhotoInfo.IsImageProcessed;
                    photoinfo.PS_User_Name = baPhotoInfo.PS_User_Name;
                    photoinfo.HotFolderPath = baPhotoInfo.HotFolderPath;
                    photoinfo.PS_Photos_CharacterID = baPhotoInfo.PS_Photos_CharacterID;
                    photoinfo.PS_MediaType = baPhotoInfo.PS_MediaType;
                    photoinfo.PS_VideoLength = baPhotoInfo.PS_VideoLength;
                    photoinfo.SemiOrderProfileId = baPhotoInfo.SemiOrderProfileId;
                    photoinfo.IsGumRideShow = baPhotoInfo.IsGumRideShow;
                    photoinfo.IsCollageShow = baPhotoInfo.IsCollageShow;
                    photoinfo.OnlineQRCode = baPhotoInfo.OnlineQRCode;
                    photoinfo.IsActive = baPhotoInfo.IsActive;

                    db.PhotoInfos.Add(photoinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPhotoInfo baPhotoInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PhotoInfos.Where(p => p.Id == baPhotoInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        photoinfo photoinfo = new photoinfo();

                        photoinfo.Id = baPhotoInfo.Id;
                        photoinfo.PS_Photos_pkey = baPhotoInfo.PS_Photos_pkey;
                        photoinfo.PS_Photos_FileName = baPhotoInfo.PS_Photos_FileName;
                        photoinfo.PS_Photos_CreatedOn = baPhotoInfo.PS_Photos_CreatedOn;
                        photoinfo.PS_Photos_RFID = baPhotoInfo.PS_Photos_RFID;
                        photoinfo.PS_Photos_UserID = baPhotoInfo.PS_Photos_UserID;
                        photoinfo.PS_Photos_Background = baPhotoInfo.PS_Photos_Background;
                        photoinfo.PS_Photos_Frame = baPhotoInfo.PS_Photos_Frame;
                        photoinfo.PS_Photos_DateTime = baPhotoInfo.PS_Photos_DateTime;
                        photoinfo.PS_Photos_Layering = baPhotoInfo.PS_Photos_Layering;
                        photoinfo.PS_Photos_Effects = baPhotoInfo.PS_Photos_Effects;
                        photoinfo.PS_Photos_IsCroped = baPhotoInfo.PS_Photos_IsCroped;
                        photoinfo.PS_Photos_IsRedEye = baPhotoInfo.PS_Photos_IsRedEye;
                        photoinfo.PS_Photos_IsGreen = baPhotoInfo.PS_Photos_IsGreen;
                        photoinfo.PS_Photos_MetaData = baPhotoInfo.PS_Photos_MetaData;
                        photoinfo.PS_Photos_Sizes = baPhotoInfo.PS_Photos_Sizes;
                        photoinfo.PS_Photos_Archive = baPhotoInfo.PS_Photos_Archive;
                        photoinfo.PS_Location_Id = baPhotoInfo.PS_Location_Id;
                        photoinfo.PS_SubStoreId = baPhotoInfo.PS_SubStoreId;
                        photoinfo.PS_IsCodeType = baPhotoInfo.PS_IsCodeType;
                        photoinfo.DateTaken = baPhotoInfo.DateTaken;
                        photoinfo.RfidScanType = baPhotoInfo.RfidScanType;
                        photoinfo.PS_Orders_Number = baPhotoInfo.PS_Orders_Number;
                        photoinfo.PS_Order_SubStoreId = baPhotoInfo.PS_Order_SubStoreId;
                        photoinfo.IMIXImageAssociationId = baPhotoInfo.IMIXImageAssociationId;
                        photoinfo.PS_Group_pkey = baPhotoInfo.PS_Group_pkey;
                        photoinfo.PS_Group_Name = baPhotoInfo.PS_Group_Name;
                        photoinfo.PS_Photo_ID = baPhotoInfo.PS_Photo_ID;
                        photoinfo.IsImageProcessed = baPhotoInfo.IsImageProcessed;
                        photoinfo.PS_User_Name = baPhotoInfo.PS_User_Name;
                        photoinfo.HotFolderPath = baPhotoInfo.HotFolderPath;
                        photoinfo.PS_Photos_CharacterID = baPhotoInfo.PS_Photos_CharacterID;
                        photoinfo.PS_MediaType = baPhotoInfo.PS_MediaType;
                        photoinfo.PS_VideoLength = baPhotoInfo.PS_VideoLength;
                        photoinfo.SemiOrderProfileId = baPhotoInfo.SemiOrderProfileId;
                        photoinfo.IsGumRideShow = baPhotoInfo.IsGumRideShow;
                        photoinfo.IsCollageShow = baPhotoInfo.IsCollageShow;
                        photoinfo.OnlineQRCode = baPhotoInfo.OnlineQRCode;
                        photoinfo.IsActive = baPhotoInfo.IsActive;

                        db.SaveChanges();

                        return true;
                        }
                    else
                        {
                        return false;
                        }
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Delete ( int Id )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PhotoInfos.Where(p => p.Id == Id).FirstOrDefault();
                    if(obj != null)
                        {
                        obj.IsActive = false;
                        db.SaveChanges();

                        }
                    return true;

                    }
                }
            catch(Exception)
                {
                throw;
                }

            }

        public static int MaxId()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    int intIdt = db.PhotoInfos.Max(u => u.Id);
                    return intIdt;

                    }
                }
            catch(Exception)
                {
                throw;
                }
            }
        public static bool UpdateCollage ( int Id )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PhotoInfos.Where(p => p.Id == Id).FirstOrDefault();
                    if(obj != null)
                        {
                        obj.IsCollageShow = true;
                        db.SaveChanges();

                        }
                    return true;

                    }
                }
            catch(Exception)
                {
                throw;
                }

            }


        }
    }
