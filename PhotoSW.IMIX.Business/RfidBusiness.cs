using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.BAL;
using PhotoSW.IMIX.Model;
namespace PhotoSW.IMIX.Business
{
    public class RfidBusiness
    {
        public int? GetPhotographerRFIDEnabledLocation(int photographerID)
        {
            try
            {
                return baRfidInfo.GetRfidInfoData().Where(p => p.LocationId == photographerID).FirstOrDefault().LocationId;
            }
            catch
            {
                return null;
            }
        }



        public bool ArchiveRFIDTags(int subStoreId)
        {
            return false;
        }
        public bool AssociateRFIDtoPhotos()
        {
            return false;
        }
        public bool AssociateRFIDtoPhotosAdvance(DataTable dt_Rfid, string SerailNo)
        {
            return false;
        }
        public bool DeleteDummyRFIDTags(int DummyRFIDTagID)
        {
            return false;
        }
        public bool DeleteSeperatorTag(int seperatorTagID)
        {
            return false;
        }
        public List<PhotoSW.IMIX.Model.LocationInfo> GetAllLocations()
        {
            try
                {
                var obj = baLocationInfo.GetLocationInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.LocationInfo
                        {
                        DG_Location_pkey = p.Location_pkey,
                        DG_Location_Name = p.Location_Name,
                        DG_Store_ID = p.Store_ID,
                        DG_SubStore_Location_Pkey = p.SubStore_Location_Pkey,
                        DG_Location_PhoneNumber = p.Location_PhoneNumber,
                        DG_Location_IsActive = p.Location_IsActive,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_SubStore_ID = p.SubStore_ID,
                        DG_Location_ID = p.Location_ID

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.LocationInfo>();
                }
            
        // return new List<PhotoSW.IMIX.Model.LocationInfo>();
        }
        public List<PhotoSW.IMIX.Model.RFIDTagInfo> GetDummyRFIDTags(int DummyRFIDTagID)
        {
            try
                {
                var obj = baRFIDTagInfo.GetRFIDTagInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.RFIDTagInfo
                        {
                        IdentifierId = p.IdentifierId,
                        DeviceID = p.DeviceID,
                        TagId = p.TagId,
                        ScanningTime = p.ScanningTime,
                        Status = p.Status,
                        RawData = p.RawData,
                        SerialNo = p.SerialNo,
                        DummyRFIDTagID = p.DummyRFIDTagID

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.RFIDTagInfo>();
                }
            // return new List<PhotoSW.IMIX.Model.RFIDTagInfo>();
            }
        public List<PhotoSW.IMIX.Model.RfidFlushHistotyInfo> GetFlushHistoryData(int SubStoreId, DateTime fromDate, DateTime toDate)
        {
            try
                {
                var obj = baRfidFlushHistotyInfo.GetRfidFlushHistotyInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.RfidFlushHistotyInfo
                        {
                        FlushId = p.FlushId,
                        ScheduleDate = p.ScheduleDate,
                        StartDate = p.StartDate,
                        EndDate = p.EndDate,
                        Status = p.Status,
                        ErrorMessage = p.ErrorMessage,
                        SubStoreId = p.SubStoreId,
                        StrStatus = p.StrStatus,
                        SubStore = p.SubStore,
                        LocationId = p.LocationId,
                        LocationName = p.LocationName

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.RfidFlushHistotyInfo>();
                }
          //  return new List<PhotoSW.IMIX.Model.RfidFlushHistotyInfo>();
        }
        public List<PhotoSW.IMIX.Model.PhotographerRFIDAssociationInfo> GetPhotographerRFIDAssociation(int? photoGrapherId, DateTime dtFrom, DateTime dtTo)
        {
            try
                {
                var obj = baPhotographerRFIDAssociationInfo.GetPhotographerRFIDAssociationInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.PhotographerRFIDAssociationInfo
                        {
                        PhotographerID = p.PhotographerID,
                        PhotographerName = p.PhotographerName,
                        Location = p.Location,
                        TotalCaptured = p.TotalCaptured,
                        TotalAssociated = p.TotalAssociated,
                        TotalNonAssociated = p.TotalNonAssociated,
                        LastAssociatedOn = p.LastAssociatedOn

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.PhotographerRFIDAssociationInfo>();
                }
            //return new List<PhotoSW.IMIX.Model.PhotographerRFIDAssociationInfo>();
            }
        public List<PhotoSW.IMIX.Model.RFIDImageAssociationInfo> GetRFIDAssociationSearch(int photoGrapherId, int deviceId, DateTime dtFrom, DateTime dtTo)
        {
            try
                {
                var obj = baRFIDImageAssociationInfo.GetRFIDImageAssociationInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.RFIDImageAssociationInfo
                        {
                        DeviceId = p.DeviceId,
                        DeviceName = p.DeviceName,
                        RFID = p.RFID,
                        Count = p.Count,
                        PhotoIds = p.PhotoIds,
                        IsShowDetailActive = p.IsShowDetailActive

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.RFIDImageAssociationInfo>();
                }
            // return new List<PhotoSW.IMIX.Model.RFIDImageAssociationInfo>();
            }
        public List<PhotoSW.IMIX.Model.PhotoDetail> GetRFIDNotAssociatedPhotos(PhotoSW.IMIX.Model.RFIDPhotoDetails RFIDPhotoObj)
        {
            try
                {
                var obj = baPhotoDetail.GetPhotoDetailData()
                    .Select(p => new PhotoSW.IMIX.Model.PhotoDetail
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
                        HotFolderPath = p.HotFolderPath,
                        MediaType = p.MediaType,
                        PhotoGrapherId = p.PhotoGrapherId,
                        VideoLength = p.VideoLength,
                        PhotoIdSequence = p.PhotoIdSequence,
                        SemiOrderProfileId = p.SemiOrderProfileId,
                        IsGumRideShow = p.IsGumRideShow

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.PhotoDetail>();
                }
          //  return new List<PhotoSW.IMIX.Model.PhotoDetail>();
        }
        public List<PhotoSW.IMIX.Model.SeperatorTagInfo> GetSeperatorRFIDTags(int seperatorRFIDTagID)
        {
            return new List<PhotoSW.IMIX.Model.SeperatorTagInfo>();
        }
        public List<PhotoSW.IMIX.Model.RFIDField> GetSubStoreList()
        {
            return new List<PhotoSW.IMIX.Model.RFIDField>();
        }
        public bool MapNonAssociatedImages(string cardUniqueIdentifier, string photoIDS)
        {
            return false;
        }
        public bool RfidFlushNow(int SubStoreId, int LocationId, int NoOfExcludeDays)
        {
            return false;
        }
        public bool SaveRfidFlushHistory(PhotoSW.IMIX.Model.RfidFlushHistotyInfo rfidFlush)
        {
            return false;
        }
        public bool SaveRfidTag(PhotoSW.IMIX.Model.RFIDTagInfo rfidTag)
        {
            return false;
        }
        public bool SaveSeperatorRFIDTagsInfo(PhotoSW.IMIX.Model.SeperatorTagInfo rfidTag)
        {
            return false;
        }
        public bool SaveUpdateDummyRFIDTags(PhotoSW.IMIX.Model.RFIDTagInfo rfidTag)
        {
            return false;
        }
    }
}
