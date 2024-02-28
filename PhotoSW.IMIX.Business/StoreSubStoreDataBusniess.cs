using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.IMIX.Model;
using PhotoSW.CF.DataLayer.BAL;
namespace PhotoSW.IMIX.Business
{
    public class StoreSubStoreDataBusniess
    {
        public bool DeleteSubstore(int SubStoreId)
        {
            return baSubstoresInfo.Delete(SubStoreId);
        }
        public bool DeleteSubStoreLocations(int SubstoreID)
        {
            return false;
        }
        public List<SubStoresInfo> GetAllLogicalSubstoreName()
        {
            try
            {
                return baSubstoresInfo.GetSubstoresInfoData()
                    .Select(p => new SubStoresInfo
                    {
                        DG_SubStore_pkey = p.PS_SubStore_pkey,
                        DG_SubStore_Name = p.PS_SubStore_Name,
                        DG_SubStore_Description = p.PS_SubStore_Description,
                        DG_SubStore_IsActive = p.PS_SubStore_IsActive,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_SubStore_Locations = p.PS_SubStore_Locations,
                        IsLogicalSubStore = p.IsLogicalSubStore,
                        LogicalSubStoreID = p.LogicalSubStoreID,
                        DG_SubStore_Code = p.PS_SubStore_Code,
                        SiteID = p.SiteID

                    }).ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<SubStoresInfo> GetAllSubstoreName()
        {
            try
            {
                return baSubstoresInfo.GetSubstoresInfoData()
                    .Select(p => new SubStoresInfo
                    {
                        DG_SubStore_pkey = p.PS_SubStore_pkey,
                        DG_SubStore_Name = p.PS_SubStore_Name,
                        DG_SubStore_Description = p.PS_SubStore_Description,
                        DG_SubStore_IsActive = p.PS_SubStore_IsActive,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_SubStore_Locations = p.PS_SubStore_Locations,
                        IsLogicalSubStore = p.IsLogicalSubStore,
                        LogicalSubStoreID = p.LogicalSubStoreID,
                        DG_SubStore_Code = p.PS_SubStore_Code,
                        SiteID = p.SiteID

                    }).ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<LocationInfo> GetAvailableLocationsSubstore(int SubstoreId)
        {
            try
            {
                return baLocationInfo.GetLocationInfoData().Where(p => p.SubStore_ID == SubstoreId)
                    .Select(p => new LocationInfo
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
                        DG_Location_ID = p.Location_ID,

                    }).ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<string> GetBackupsubstorename(int SubStoreId)
        {
            List<string> str = new List<string>();

            //try
            //{
            //    return baLocationInfo.GetLocationInfoData().Where(p => p.SubStore_ID == SubstoreId)
            //        .Select(p => new LocationInfo
            //        {
            //            DG_Location_pkey = p.Location_pkey,
            //            DG_Location_Name = p.Location_Name,
            //            DG_Store_ID = p.Store_ID,
            //            DG_SubStore_Location_Pkey = p.SubStore_Location_Pkey,
            //            DG_Location_PhoneNumber = p.Location_PhoneNumber,
            //            DG_Location_IsActive = p.Location_IsActive,
            //            SyncCode = p.SyncCode,
            //            IsSynced = p.IsSynced,
            //            DG_SubStore_ID = p.SubStore_ID,
            //            DG_Location_ID = p.Location_ID,

            //        }).ToList();
            //}
            //catch
            //{
            //    return null;
            //}
            return str;
        }
        public string GetCountryName()
        {
            return "India";
        }
        public List<LocationInfo> GetLocationSubstoreWise(int SubstoreId)
        {
            try
            {
                return baLocationInfo.GetLocationInfoData().Where(p => p.SubStore_ID == SubstoreId)
                    .Select(p => new LocationInfo
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
                        DG_Location_ID = p.Location_ID,

                    }).ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<SubStoresInfo> GetLogicalSubStore()
        {
            try
            {
                return baSubstoresInfo.GetSubstoresInfoData().Select(p => new SubStoresInfo
                {
                    DG_SubStore_pkey = p.PS_SubStore_pkey,
                    DG_SubStore_Name = p.PS_SubStore_Name,
                    DG_SubStore_Description = p.PS_SubStore_Description,
                    DG_SubStore_IsActive = p.PS_SubStore_IsActive,
                    SyncCode = p.SyncCode,
                    IsSynced = p.IsSynced,
                    DG_SubStore_Locations = p.PS_SubStore_Locations,
                    IsLogicalSubStore = p.IsLogicalSubStore,
                    LogicalSubStoreID = p.LogicalSubStoreID,
                    DG_SubStore_Code = p.PS_SubStore_Code,
                    SiteID = p.SiteID

                }).ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<SubStoresInfo> GetLoginUserDefaultSubstores(int subStoreId)
        {
            try
            {
                return baSubstoresInfo.GetSubstoresInfoData().Where(p => p.LogicalSubStoreID == subStoreId)
                    .Select(p => new SubStoresInfo
                    {
                        DG_SubStore_pkey = p.PS_SubStore_pkey,
                        DG_SubStore_Name = p.PS_SubStore_Name,
                        DG_SubStore_Description = p.PS_SubStore_Description,
                        DG_SubStore_IsActive = p.PS_SubStore_IsActive,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_SubStore_Locations = p.PS_SubStore_Locations,
                        IsLogicalSubStore = p.IsLogicalSubStore,
                        LogicalSubStoreID = p.LogicalSubStoreID,
                        DG_SubStore_Code = p.PS_SubStore_Code,
                        SiteID = p.SiteID

                    }).ToList();
            }
            catch
            {
                return null;
            }
        }
        public string GetQRCodeWebUrl()
        {

            return "";
        }
        public List<RfidInfo> GetRfidInfoBussines(int SubStoreId)
        {
            try
            {
                return baRfidInfo.GetRfidInfoData().Where(p => p.SubStoreId == SubStoreId)
                      .Select(p => new RfidInfo
                      {
                          ImixConfigValueID = p.ImixConfigValueID,
                          ImixConfigMasterID = p.ImixConfigMasterID,
                          ImixConfigMasterName = p.ImixConfigMasterName,
                          ConfigurationValue = p.ConfigurationValue,
                          SubStoreId = p.SubStoreId,
                          SubStoreName = p.SubStoreName,
                          LocationId = p.LocationId,
                          LocationName = p.LocationName,
                      }).ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<LocationInfo> GetSelectedLocationsSubstore(int SubstoreId)
        {
            try
            {
                return baLocationInfo.GetLocationInfoData().Where(p => p.SubStore_ID == SubstoreId)
                    .Select(p => new LocationInfo
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
                        DG_Location_ID = p.Location_ID,

                    }).ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<SiteCodeDetail> GetSiteCodeBusiness()
        {

            List<SiteCodeDetail> SiteCodeDetailsList = new List<SiteCodeDetail>();
            foreach (var item in baSiteCodeDetail.GetPhotoGroupInfoData())
            {
                SiteCodeDetail siteCodeDetail = new SiteCodeDetail();
                siteCodeDetail.SiteId = item.SiteId;
                siteCodeDetail.SiteCode = item.SiteCode;
                SiteCodeDetailsList.Add(siteCodeDetail);
            }
            return SiteCodeDetailsList;
        }
        public StoreInfo GetStore()
        {
            try
            {
                return baStoreInfo.GetStoreInfoData().Select(p => new StoreInfo
                {

                    DG_Store_pkey = p.Store_pkey,
                    DG_Store_Name = p.Store_Name,
                    Country = p.Country,
                    DG_CentralServerIP = p.CentralServerIP,
                    DG_StoreCode = p.StoreCode,
                    DG_CenetralServerUName = p.CenetralServerUName,
                    DG_CenetralServerPassword = p.CenetralServerPassword,
                    DG_PreferredTimeToSyncFrom = p.PreferredTimeToSyncFrom,
                    DG_PreferredTimeToSyncTo = p.PreferredTimeToSyncTo,
                    DG_QRCodeWebUrl = p.QRCodeWebUrl,
                    CountryCode = p.CountryCode,
                    Address = p.Address,
                    BillReceiptTitle = p.BillReceiptTitle,
                    IsSequenceNoRequired = p.IsSequenceNoRequired,
                    IsTaxEnabled = p.IsTaxEnabled,
                    PhoneNo = p.PhoneNo,
                    StoreCode = p.PS_StoreCode,
                    StoreName = p.Store_Name,
                    TaxMaxSequenceNo = p.TaxMaxSequenceNo,
                    TaxMinSequenceNo = p.TaxMinSequenceNo,
                    TaxRegistrationNumber = p.TaxRegistrationNumber,
                    TaxRegistrationText = p.TaxRegistrationText,
                    WebsiteURL = p.WebsiteURL,
                    EmailID = p.EmailID,
                    RunApplicationsSubStoreLevel = p.RunApplicationsSubStoreLevel,
                    ServerHotFolderPath = p.ServerHotFolderPath,
                    IsActiveStockShot = p.IsActiveStockShot,
                    RunImageProcessingEngineLocationWise = p.RunImageProcessingEngineLocationWise,
                    RunVideoProcessingEngineLocationWise = p.RunVideoProcessingEngineLocationWise,
                    IsTaxIncluded = p.IsTaxIncluded,
                    IsOnline = p.IsOnline,

                }).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public Hashtable GetStoreDetails()
        {

            Hashtable obj = new Hashtable();
            foreach (var i in baStoreInfo.GetStoreInfoData())
            {
                obj.Add(i.Id, i.Store_Name);
            }
            return obj;
        }
        public List<StoreInfo> GetStoreName()
        {
            try
            {
                return baStoreInfo.GetStoreInfoData().Select(p => new StoreInfo
                {

                    DG_Store_pkey = p.Store_pkey,
                    DG_Store_Name = p.Store_Name,
                    Country = p.Country,
                    DG_CentralServerIP = p.CentralServerIP,
                    DG_StoreCode = p.StoreCode,
                    DG_CenetralServerUName = p.CenetralServerUName,
                    DG_CenetralServerPassword = p.CenetralServerPassword,
                    DG_PreferredTimeToSyncFrom = p.PreferredTimeToSyncFrom,
                    DG_PreferredTimeToSyncTo = p.PreferredTimeToSyncTo,
                    DG_QRCodeWebUrl = p.QRCodeWebUrl,
                    CountryCode = p.CountryCode,
                    Address = p.Address,
                    BillReceiptTitle = p.BillReceiptTitle,
                    IsSequenceNoRequired = p.IsSequenceNoRequired,
                    IsTaxEnabled = p.IsTaxEnabled,
                    PhoneNo = p.PhoneNo,
                    StoreCode = p.PS_StoreCode,
                    StoreName = p.Store_Name,
                    TaxMaxSequenceNo = p.TaxMaxSequenceNo,
                    TaxMinSequenceNo = p.TaxMinSequenceNo,
                    TaxRegistrationNumber = p.TaxRegistrationNumber,
                    TaxRegistrationText = p.TaxRegistrationText,
                    WebsiteURL = p.WebsiteURL,
                    EmailID = p.EmailID,
                    RunApplicationsSubStoreLevel = p.RunApplicationsSubStoreLevel,
                    ServerHotFolderPath = p.ServerHotFolderPath,
                    IsActiveStockShot = p.IsActiveStockShot,
                    RunImageProcessingEngineLocationWise = p.RunImageProcessingEngineLocationWise,
                    RunVideoProcessingEngineLocationWise = p.RunVideoProcessingEngineLocationWise,
                    IsTaxIncluded = p.IsTaxIncluded,
                    IsOnline = p.IsOnline,

                }).ToList();
            }
            catch
            {
                return null;
            }
        }

        public int GetSubstoreId()
        {
            int val = 0;
            if (baSubstoresInfo.GetSubstoresInfoData().ToList().Count > 0)
            {
                val = Convert.ToInt32(baSubstoresInfo.GetSubstoresInfoData().OrderByDescending(m => m.Id).FirstOrDefault().Id);
            }
            return ++val;
        }

        public List<SubStoresInfo> GetSubstoreData()
        {
            try
            {
                return baSubstoresInfo.GetSubstoresInfoData()
                    .Select(p => new SubStoresInfo
                    {
                        DG_SubStore_pkey = p.PS_SubStore_pkey,
                        DG_SubStore_Name = p.PS_SubStore_Name,
                        DG_SubStore_Description = p.PS_SubStore_Description,
                        DG_SubStore_IsActive = p.PS_SubStore_IsActive,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_SubStore_Locations = p.PS_SubStore_Locations,
                        IsLogicalSubStore = p.IsLogicalSubStore,
                        LogicalSubStoreID = p.LogicalSubStoreID,
                        DG_SubStore_Code = p.PS_SubStore_Code,
                        SiteID = p.SiteID

                    }).ToList();
            }
            catch
            {
                return null;
            }
        }
        public SubStoresInfo GetSubstoreData(int subStoreId)
        {
            try
            {
                return baSubstoresInfo.GetSubstoresInfoData().Where(p => p.Id == subStoreId)
                    .Select(p => new SubStoresInfo
                    {
                        DG_SubStore_pkey = p.PS_SubStore_pkey,
                        DG_SubStore_Name = p.PS_SubStore_Name,
                        DG_SubStore_Description = p.PS_SubStore_Description,
                        DG_SubStore_IsActive = p.PS_SubStore_IsActive,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_SubStore_Locations = p.PS_SubStore_Locations,
                        IsLogicalSubStore = p.IsLogicalSubStore,
                        LogicalSubStoreID = p.LogicalSubStoreID,
                        DG_SubStore_Code = p.PS_SubStore_Code,
                        SiteID = p.SiteID

                    }).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public Dictionary<string, string> GetSubstoreDataDir()
        {
            Dictionary<string, string> obj = new Dictionary<string, string>();
            obj.Add("1", "test1");
            obj.Add("2", "test2");
            obj.Add("3", "test3");
            obj.Add("4", "test4");
            return obj;
        }
        public Dictionary<string, string> GetSubstoreDataDir(Dictionary<string, string> selectDict)
        {
            Dictionary<string, string> obj = new Dictionary<string, string>();
            obj.Add("1", "ENTRANCE");
            obj.Add("2", "ROOFTOP");
            obj.Add("3", "EXPLORER");
            obj.Add("4", "JURASSIC");
            obj.Add("5", "OBSERVATION");
            //obj = selectDict;

            return obj;
        }
        public List<SubStoresInfo> GetSubstoreDataFillGrid()
        {
            try
            {
                return baSubstoresInfo.GetSubstoresInfoData()
                    .Select(p => new SubStoresInfo
                    {
                        DG_SubStore_pkey = p.PS_SubStore_pkey,
                        DG_SubStore_Name = p.PS_SubStore_Name,
                        DG_SubStore_Description = p.PS_SubStore_Description,
                        DG_SubStore_IsActive = p.PS_SubStore_IsActive,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_SubStore_Locations = p.PS_SubStore_Locations,
                        IsLogicalSubStore = p.IsLogicalSubStore,
                        LogicalSubStoreID = p.LogicalSubStoreID,
                        DG_SubStore_Code = p.PS_SubStore_Code,
                        SiteID = p.SiteID

                    }).ToList();
            }
            catch
            {
                return null;
            }
        }
        public string GetSubstoreNameById(int SubstoreId)
        {
            try
            {
                return baSubstoresInfo.GetSubstoresInfoData()
                    .Select(p => p.PS_SubStore_Name).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public List<StoreInfo> SelectStores()
        {
            try
            {
                return baStoreInfo.GetStoreInfoData().Select(p => new StoreInfo
                {

                    DG_Store_pkey = p.Store_pkey,
                    DG_Store_Name = p.Store_Name,
                    Country = p.Country,
                    DG_CentralServerIP = p.CentralServerIP,
                    DG_StoreCode = p.StoreCode,
                    DG_CenetralServerUName = p.CenetralServerUName,
                    DG_CenetralServerPassword = p.CenetralServerPassword,
                    DG_PreferredTimeToSyncFrom = p.PreferredTimeToSyncFrom,
                    DG_PreferredTimeToSyncTo = p.PreferredTimeToSyncTo,
                    DG_QRCodeWebUrl = p.QRCodeWebUrl,
                    CountryCode = p.CountryCode,
                    Address = p.Address,
                    BillReceiptTitle = p.BillReceiptTitle,
                    IsSequenceNoRequired = p.IsSequenceNoRequired,
                    IsTaxEnabled = p.IsTaxEnabled,
                    PhoneNo = p.PhoneNo,
                    StoreCode = p.PS_StoreCode,
                    StoreName = p.Store_Name,
                    TaxMaxSequenceNo = p.TaxMaxSequenceNo,
                    TaxMinSequenceNo = p.TaxMinSequenceNo,
                    TaxRegistrationNumber = p.TaxRegistrationNumber,
                    TaxRegistrationText = p.TaxRegistrationText,
                    WebsiteURL = p.WebsiteURL,
                    EmailID = p.EmailID,
                    RunApplicationsSubStoreLevel = p.RunApplicationsSubStoreLevel,
                    ServerHotFolderPath = p.ServerHotFolderPath,
                    IsActiveStockShot = p.IsActiveStockShot,
                    RunImageProcessingEngineLocationWise = p.RunImageProcessingEngineLocationWise,
                    RunVideoProcessingEngineLocationWise = p.RunVideoProcessingEngineLocationWise,
                    IsTaxIncluded = p.IsTaxIncluded,
                    IsOnline = p.IsOnline,

                }).ToList();
            }
            catch
            {
                return null;
            }
        }

        public Dictionary<string, string> SelStoreDataDir()
        {
            Dictionary<string, string> obj = new Dictionary<string, string>();
            obj.Add("1", "test1");
            obj.Add("2", "test2");
            obj.Add("3", "test3");
            obj.Add("4", "test4");
            return obj;
        }
        public bool SetSubStoreDetails(string SubstoreName,string SubStoreDescription, int Substore_ID,string SyncCode, string Locations, bool islogiaclsubstore,int? logicalsubstoreid, string SiteCode,int SiteID)
        {
            try
            {
                baSubstoresInfo substoresInfo = new baSubstoresInfo();
                substoresInfo.PS_SubStore_Name = SubstoreName;
                substoresInfo.PS_SubStore_Description = SubStoreDescription;
                substoresInfo.PS_SubStore_pkey = Substore_ID;
                substoresInfo.SyncCode = SyncCode;
                substoresInfo.PS_SubStore_Locations = Locations;
                substoresInfo.IsLogicalSubStore = islogiaclsubstore;
                substoresInfo.LogicalSubStoreID = logicalsubstoreid;
                substoresInfo.PS_SubStore_Code = SiteCode;
                substoresInfo.PS_SubStore_IsActive = true;
                substoresInfo.IsActive = true;
                substoresInfo.SiteID = SiteID;
                baSubstoresInfo.Insert(substoresInfo);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SetSubStoreLocationsDetails(int Substore_ID, int LocationId)
        {
            return false;
        }
        public bool UpdateQRCodeWebUrl(string url)
        {
            return false;
        }
        public bool UpdateSubStore(string SubstoreName,string SubStoreDescription, string SubStorePkey,string SiteCode,int SiteID,string StoreLocation,bool IsLogicalSubStore,int LogicalSubStoreID)
        {
            baSubstoresInfo substoresInfo = new baSubstoresInfo();
            substoresInfo.PS_SubStore_Name = SubstoreName;
            substoresInfo.PS_SubStore_Description = SubStoreDescription;
            substoresInfo.PS_SubStore_pkey = Convert.ToInt32(SubStorePkey);
            substoresInfo.PS_SubStore_Code = SiteCode;
            substoresInfo.SiteID = SiteID;
            substoresInfo.PS_SubStore_Locations = StoreLocation;
            substoresInfo.IsLogicalSubStore = IsLogicalSubStore;
            substoresInfo.LogicalSubStoreID = LogicalSubStoreID;

            return baSubstoresInfo.Update(substoresInfo);
        }

    }
}
