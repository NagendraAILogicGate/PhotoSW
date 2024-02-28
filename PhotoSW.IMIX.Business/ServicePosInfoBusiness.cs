using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class ServicePosInfoBusiness
    {
        public string CheckRunnignServiceBusiness(long ServiceId, long SubStoreId, int Level, string SystemName)
        {
            return "";
        }
        public int GetAnyRunningServiceByPosIdBusiness(long imixId)
        {
            return 0;
        }
        public List<PhotoSW.IMIX.Model.ImixPOSDetail> GetPOSDetailBusiness(long SubStoreID, int RunLevel)
        {
            try
                {
                var obj = baImixPOSDetail.GetImixPOSDetailData()
                    .Where(p=>p.SubStoreID == SubStoreID)
                    .Select(p => new PhotoSW.IMIX.Model.ImixPOSDetail
                        {
                        ImixPOSDetailID = p.ImixPOSDetailID,
                        SystemName = p.SystemName,
                        IPAddress = p.IPAddress,
                        MacAddress = p.MacAddress,
                        SubStoreID = p.SubStoreID,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        UpdatedBy = p.UpdatedBy,
                        UpdatedOn = p.UpdatedOn,
                        IsStart = p.IsStart,
                        StartStopTime = p.StartStopTime,
                        SyncCode = p.SyncCode

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.ImixPOSDetail>();
                }
            // return new List<Model.ImixPOSDetail>();
            }
        public List<PhotoSW.IMIX.Model.ImixPOSDetail> GetPosDetailsBusiness()
        {
            try
                {
                var obj = baImixPOSDetail.GetImixPOSDetailData()
                    .Select(p => new PhotoSW.IMIX.Model.ImixPOSDetail
                        {
                        ImixPOSDetailID = p.ImixPOSDetailID,
                        SystemName = p.SystemName,
                        IPAddress = p.IPAddress,
                        MacAddress = p.MacAddress,
                        SubStoreID = p.SubStoreID,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        UpdatedBy = p.UpdatedBy,
                        UpdatedOn = p.UpdatedOn,
                        IsStart = p.IsStart,
                        StartStopTime = p.StartStopTime,
                        SyncCode = p.SyncCode

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.ImixPOSDetail>();
                }
            //return new List<Model.ImixPOSDetail>();
            }
        public List<PhotoSW.IMIX.Model.ServicePosInfo> GetRunningServices()
        {
            try
                {
                var obj = baServicePosInfo.GetServicePosInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.ServicePosInfo
                        {
                        ServiceId = p.ServiceId,
                        ImixPosId = p.ImixPosId,
                        SubstoreId = p.SubstoreId,
                        ServiceName = p.ServiceName,
                        SystemName = p.SystemName,
                        SubStoremName = p.SubStoremName,
                        UniqueCode = p.UniqueCode,
                        RunLevel = p.RunLevel,
                        Status = p.Status

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.ServicePosInfo>();
                }
            // return new List<Model.ServicePosInfo>();
            }
        public List<PhotoSW.IMIX.Model.SvcRunningInfo> GetServiceInfoBusiness(long ServiceID, long ImixPOSDetailID, long SubStoreID)
        {
            try
                {
                var obj = baSvcRunningInfo.GetSvcRunningInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.SvcRunningInfo
                        {
                        ServiceName = p.ServiceName,
                        SystemName = p.SystemName,
                        ServicePOSMappingID = p.ServicePOSMappingID,
                        LastStatusOnDate = p.LastStatusOnDate,
                        Status = p.Status,
                        SubStoreName = p.SubStoreName

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.SvcRunningInfo>();
                }
            // return new List<Model.SvcRunningInfo>();
            }
        public string getServiceName(bool IsEXE)
        {
            return "";
        }
        public List<PhotoSW.IMIX.Model.GetServiceStatus> GetServiceStatusBusiness(string MachineName, string ServiceName)
        {
            try
                {
                var obj = baGetServiceStatus.GetServiceStatusData()
                    .Select(p => new PhotoSW.IMIX.Model.GetServiceStatus
                        {
                        ServiceId = p.ServiceId,
                        SubStoreID = p.SubStoreID,
                        Runlevel = p.Runlevel,
                        iMixPosId = p.iMixPosId

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.GetServiceStatus>();
                }
            //  return new List<Model.GetServiceStatus>();
            }
        public List<PhotoSW.IMIX.Model.SubStore> GetSubstoreDetailsBusiness()
        {
            try
                {
                var obj = baSubStore.GetSubstoreData()
                    .Select(p => new PhotoSW.IMIX.Model.SubStore
                        {
                        DG_SubStore_pkey = p.Id,
                        DG_SubStore_Name = p.PS_SubStore_Name,
                        DG_SubStore_Description = p.PS_SubStore_Description,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        ModifiedDate = p.ModifiedDate

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.SubStore>();
                }
            //  return new List<Model.SubStore>();
            }
        public string getSystemName()
        {
            return "";
        }
        public int InsertImixPosBusiness(PhotoSW.IMIX.Model.ImixPOSDetail imixPosDetail)
        {
            return 0;
        }
        public List<PhotoSW.IMIX.Model.MappedPos> MappedPosDetailBusiness()
        {
            try
                {
                var obj = baMappedPos.GetMappedPosData()
                    .Select(p => new PhotoSW.IMIX.Model.MappedPos
                        {
                        ImixPOSDetailID = p.ImixPOSDetailID,
                        SystemName = p.SystemName,
                        SubStoreID = p.SubStoreID,
                        SubStoreName = p.SubStoreName,
                        UniqueCode = p.UniqueCode

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.MappedPos>();
                }
            // return new List<Model.MappedPos>();
            }
        public string ServiceStart(bool IsExe)
        {
            return "";
        }
        public void setPrintServer(string mac, string SystemName, bool isStop)
        {
        }
        public int StartStopServiceByPosIdBusiness(long ServiceId, long SubstoreId, long ImixPosDetailId, bool Status, string CreatedBy)
        {
            return 0;
        }
        public void StartStopSystemBusiness(string mac, string myIP, string SystemName, int Type)
        {
        }
        public void StopService(bool IsExe)
        {
        }
        public int UpdateServiceRunLevelBusiness(int _serviceId, int RunLevel, bool isService)
        {
            return 0;
        }
    }
}
