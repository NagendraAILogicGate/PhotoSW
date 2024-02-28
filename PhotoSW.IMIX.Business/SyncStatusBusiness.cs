using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class SyncStatusBusiness
    {
        public List<PhotoSW.IMIX.Model.SyncStatusInfo> GetFormSyncStatusList(DateTime FrmDate, DateTime ToDate)
        {
            try
                {
                var obj = baSyncStatusInfo.GetSyncStatusInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.SyncStatusInfo
                        {
                        Syncstatus = p.Syncstatus,
                        SyncOrderNumber = p.SyncOrderNumber,
                        QRCode = p.QRCode,
                        SyncOrderdate = p.SyncOrderdate,
                        PhotoRfid = p.PhotoRfid,
                        Syncdate = p.Syncdate,
                        SyncStatusID = p.SyncStatusID,
                        IsAvailable = p.IsAvailable,
                        ChangeTrackingId = p.ChangeTrackingId,
                        ImageSynced = p.ImageSynced,
                        SyncFormID = p.SyncFormID,
                        SyncFormTransDate = p.SyncFormTransDate,
                        Form = p.Form

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<Model.SyncStatusInfo>();
                }
            // return new List<Model.SyncStatusInfo>();
            }
        public List<PhotoSW.IMIX.Model.SyncStatusInfo> GetOrdersyncStatus(DateTime? FrmDate, DateTime? ToDate)
        {
            try
                {
                var obj = baSyncStatusInfo.GetSyncStatusInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.SyncStatusInfo
                        {
                        Syncstatus = p.Syncstatus,
                        SyncOrderNumber = p.SyncOrderNumber,
                        QRCode = p.QRCode,
                        SyncOrderdate = p.SyncOrderdate,
                        PhotoRfid = p.PhotoRfid,
                        Syncdate = p.Syncdate,
                        SyncStatusID = p.SyncStatusID,
                        IsAvailable = p.IsAvailable,
                        ChangeTrackingId = p.ChangeTrackingId,
                        ImageSynced = p.ImageSynced,
                        SyncFormID = p.SyncFormID,
                        SyncFormTransDate = p.SyncFormTransDate,
                        Form = p.Form

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<Model.SyncStatusInfo>();
                }

            //  return new List<Model.SyncStatusInfo>();
            }
        public List<PhotoSW.IMIX.Model.SyncStatusInfo> GetSyncStatusList(DateTime FrmDate, DateTime ToDate)
        {
            try
                {
                var obj = baSyncStatusInfo.GetSyncStatusInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.SyncStatusInfo
                        {
                        Syncstatus = p.Syncstatus,
                        SyncOrderNumber = p.SyncOrderNumber,
                        QRCode = p.QRCode,
                        SyncOrderdate = p.SyncOrderdate,
                        PhotoRfid = p.PhotoRfid,
                        Syncdate = p.Syncdate,
                        SyncStatusID = p.SyncStatusID,
                        IsAvailable = p.IsAvailable,
                        ChangeTrackingId = p.ChangeTrackingId,
                        ImageSynced = p.ImageSynced,
                        SyncFormID = p.SyncFormID,
                        SyncFormTransDate = p.SyncFormTransDate,
                        Form = p.Form

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<Model.SyncStatusInfo>();
                }
            //return new List<Model.SyncStatusInfo>();
            }
        public bool ReSync(string ReSyncId)
        {
            return false;
        }
        public bool ReSyncImages(string OrderId)
        {
            return false;
        }
        public bool SetResyncHistory(DateTime ResyncDatetime, int ResyncStatus, int ResyncType)
        {
            return false;
        }
    }
}
