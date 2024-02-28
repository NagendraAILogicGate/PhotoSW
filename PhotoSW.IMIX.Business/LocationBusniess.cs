using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;
using PhotoSW.CF.DataLayer.BAL;
using PhotoSW.IMIX.Model;
namespace PhotoSW.IMIX.Business
{
    public class LocationBusniess
    {
        public List<LocationInfo> GetLocationList(int storeId)
        {
            try
            {
                var obj = baLocationInfo.GetLocationInfoData().Where(p => p.Store_ID == storeId)
                    .Select(p => new LocationInfo
                    {
                       // Id = p.Id,

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
                return obj;
            }
            catch
            {
                return null;
            }
        }
        public List<PhotoSW.IMIX.Model.SubStoresInfo> GetSubstoreData()
        {
            try
            {
                var obj = baSubstoresInfo.GetSubstoresInfoData()
                   .Select(p => new PhotoSW.IMIX.Model.SubStoresInfo
                   {
                      //Id = p.Id,
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
                       SiteID = p.SiteID,
                      // IsActive = p.IsActive

                  }).ToList();
                return obj;
            }
            catch
            {
                return null;
            }
        }
        public string GetQRCodeWebUrl()
        {//StoreInfo
            var obj = baStoreInfo.GetStoreInfoData().Select(p => p.QRCodeWebUrl).FirstOrDefault();
            return obj;
        }


        public bool DeleteLocations(int LocationId)
        {
            return baLocationInfo.Delete(LocationId);
        }
        public int GetLocationIdbyUserId(string UserId)
        {
            return 0;
        }

        public List<PhotoSW.IMIX.Model.LocationInfo> GetLocationName(int StoreId)
        {
            try
            {
                var obj = baLocationInfo.GetLocationInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.LocationInfo()
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
        public List<LocationInfo> GetLocationNameDir(int StoreId)
        {
            try
            {
                var obj = baLocationInfo.GetLocationInfoData().Where(p => p.Store_ID == StoreId).Select(v => new LocationInfo() {

                    DG_Location_ID = v.Location_ID,
                    DG_Location_IsActive = v.Location_IsActive,
                    DG_Location_Name = v.Location_Name,
                    DG_Location_PhoneNumber = v.Location_PhoneNumber,
                    DG_Location_pkey = v.Location_pkey,
                    DG_Store_ID = v.Store_ID,
                    DG_SubStore_ID = v.SubStore_ID,
                    DG_SubStore_Location_Pkey =v.SubStore_Location_Pkey,
                    SyncCode = v.SyncCode,
                    IsSynced = v.IsSynced
                    
                }).ToList();

                return obj;
            }
            catch
            {
                return new List<LocationInfo>();
            }
        }
        public List<PhotoSW.IMIX.Model.LocationInfo> GetLocations(int storeId)
        {
            try
            {
                var obj = baLocationInfo.GetLocationInfoData().Where(p => p.Store_ID == storeId)
                    .Select(p => new PhotoSW.IMIX.Model.LocationInfo()
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
        }
        public PhotoSW.IMIX.Model.LocationInfo GetLocationsbyId(int LocationId)
        {
            try
            {
                var obj = baLocationInfo.GetLocationInfoData().Where(p => p.Location_pkey == LocationId)
                    .Select(p => new PhotoSW.IMIX.Model.LocationInfo()
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
                    }).FirstOrDefault();
                return obj;
            }
            catch
            {
                return new PhotoSW.IMIX.Model.LocationInfo();
            }
        }


        public int GetSubStoreIdbyLocationId(int LocationId)
        {
            return 0;
        }
        public bool IsLocationAssociatedToSite(int _locationId)
        {
            return false;
        }
        public bool IsSiteAssociatedToLocation(int subStoreId)
        {
            return false;
        }
        public bool SetLocations(int LocationId, string LocationName, int StoreId, string SyncCode)
        {
            try
            {
                baLocationInfo locationInfo = new baLocationInfo();
                locationInfo.Location_Name = LocationName;
                locationInfo.Store_ID = StoreId;
                locationInfo.SyncCode = SyncCode;
                locationInfo.IsSynced = true;
                locationInfo.IsActive = true;
                locationInfo.Location_IsActive = true;
                locationInfo.Location_ID = LocationId;
                locationInfo.Location_pkey = LocationId;

                baLocationInfo.Insert(locationInfo);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool UpdateLocation(int Id, string LocationName)
        {
            baLocationInfo locationInfo = new baLocationInfo();
            locationInfo.Location_Name = LocationName;
            locationInfo.Location_pkey = Id;

            return baLocationInfo.Update(locationInfo);

        }

        public int GetIdbyLocationPkey(int Pkey)
        {
            int id = 0;
            id = Convert.ToInt32(baLocationInfo.GetLocationInfoData().Where(m => m.Location_pkey == Pkey).FirstOrDefault().Id);
            return id;
        }
    }
}
