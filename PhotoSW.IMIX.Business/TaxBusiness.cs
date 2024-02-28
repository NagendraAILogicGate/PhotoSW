using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class TaxBusiness
    {
        public List<PhotoSW.IMIX.Model.TaxDetailInfo> GetApplicableTaxes(int taxID)
        {
            try
                {
                var obj = baTaxDetailInfo.GetTaxDetailInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.TaxDetailInfo
                        {
                        TaxId = p.TaxId,
                        TaxAmount = p.TaxAmount,
                        TaxPercentage = p.TaxPercentage,
                        TaxName = p.TaxName,
                        CurrencyName = p.CurrencyName

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<Model.TaxDetailInfo>();
                }
            //return new List<Model.TaxDetailInfo>();
            }
        public List<PhotoSW.IMIX.Model.TaxDetailInfo> GetReportTaxDetail(DateTime FromDate, DateTime ToDate, int subStoreID)
        {
            try
                {
                var obj = baTaxDetailInfo.GetTaxDetailInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.TaxDetailInfo
                        {
                        TaxId = p.TaxId,
                        TaxAmount = p.TaxAmount,
                        TaxPercentage = p.TaxPercentage,
                        TaxName = p.TaxName,
                        CurrencyName = p.CurrencyName

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<Model.TaxDetailInfo>();
                }
            //  return new List<Model.TaxDetailInfo>();
            }
        public PhotoSW.IMIX.Model.StoreInfo getTaxConfigData()
        {
            try
                {
                var obj = baStoreInfo.GetStoreInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.StoreInfo
                        {
                        DG_Store_pkey = p.Store_pkey,
                        DG_Store_Name = p.Store_Name,
                        Country = p.Country,
                        DG_CentralServerIP = p.CentralServerIP,
                        StoreCode = p.StoreCode,
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
                        DG_StoreCode = p.PS_StoreCode,
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
                        IsOnline = p.IsOnline

                        }).FirstOrDefault();
                return obj;
                }
            catch
                {
                return new PhotoSW.IMIX.Model.StoreInfo(); 
                }
            // return new PhotoSW.IMIX.Model.StoreInfo();
            }
        public ObservableCollection<PhotoSW.IMIX.Model.TaxDetailInfo> GetTaxDetail()
        {            
            return new ObservableCollection<Model.TaxDetailInfo>();
        }
        public List<PhotoSW.IMIX.Model.TaxDetailInfo> GetTaxDetail(int? orderId)
        {
            try
                {
                var obj = baTaxDetailInfo.GetTaxDetailInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.TaxDetailInfo
                        {
                        TaxId = p.TaxId,
                        TaxAmount = p.TaxAmount,
                        TaxPercentage = p.TaxPercentage,
                        TaxName = p.TaxName,
                        CurrencyName = p.CurrencyName

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<Model.TaxDetailInfo>();
                }
          //  return new List<Model.TaxDetailInfo>();
        }
        public bool SaveOrderTaxDetails(int StoreId, int OrderId, int SubStoreId)
        {
            return false;
        }
        public bool SaveTaxDetails(int VenueId, int TaxId, decimal TaxPercentage, bool Status, DateTime modifiedate)
        {
            return false;
        }
        public bool UpdateStoreTaxData(PhotoSW.IMIX.Model.StoreInfo store)
        {
            try
                {
                bool result = false;
                baStoreInfo obj = new baStoreInfo();

                obj.Store_pkey = store.DG_Store_pkey;
                obj.Store_Name = store.DG_Store_Name;
                obj.Country = store.Country;
                obj.CentralServerIP = store.DG_CentralServerIP;
                obj.StoreCode = store.StoreCode;
                obj.CenetralServerUName = store.DG_CenetralServerUName;
                obj.CenetralServerPassword = store.DG_CenetralServerPassword;
                obj.PreferredTimeToSyncFrom = store.DG_PreferredTimeToSyncTo;
                obj.QRCodeWebUrl = store.DG_QRCodeWebUrl;
                obj.CountryCode = store.CountryCode;
                obj.Address = store.Address;
                obj.BillReceiptTitle = store.BillReceiptTitle;
                obj.IsSequenceNoRequired = store.IsSequenceNoRequired;
                obj.IsTaxEnabled = store.IsTaxEnabled;
                obj.PhoneNo = store.PhoneNo;
                obj.PS_StoreCode = store.DG_StoreCode;
                obj.TaxMaxSequenceNo = store.TaxMaxSequenceNo;
                obj.TaxMinSequenceNo = store.TaxMinSequenceNo;
                obj.TaxRegistrationNumber = store.TaxRegistrationNumber;
                obj.TaxRegistrationText = store.TaxRegistrationText;
                obj.WebsiteURL = store.WebsiteURL;
                obj.EmailID = store.EmailID;
                obj.RunApplicationsSubStoreLevel = store.RunApplicationsSubStoreLevel;
                obj.ServerHotFolderPath = store.ServerHotFolderPath;
                obj.IsActiveStockShot = store.IsActiveStockShot;
                obj.RunImageProcessingEngineLocationWise = store.RunImageProcessingEngineLocationWise;
                obj.RunVideoProcessingEngineLocationWise = store.RunVideoProcessingEngineLocationWise;
                obj.IsTaxIncluded = store.IsTaxIncluded;
                obj.IsOnline = store.IsOnline;
                obj.IsActive = true;

                result  = baStoreInfo.Insert(obj);

                return result;
                }
            catch
                {
                return false;
                }
            
        }
    }
}
