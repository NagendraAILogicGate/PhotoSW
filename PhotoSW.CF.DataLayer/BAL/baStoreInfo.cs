using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
{
 
	public class baStoreInfo
    {
        public long Id { get; set; }
        public int Store_pkey { get; set; }
        public string Store_Name { get; set; }
        public string Country { get; set; }
        public string CentralServerIP { get; set; }
        public string StoreCode { get; set; }
        public string CenetralServerUName { get; set; }
        public string CenetralServerPassword { get; set; }
        public decimal? PreferredTimeToSyncFrom { get; set; }
        public decimal? PreferredTimeToSyncTo { get; set; }
        public string QRCodeWebUrl { get; set; }
        public string CountryCode { get; set; }
        public string Address { get; set; }
        public string BillReceiptTitle { get; set; }
        public bool? IsSequenceNoRequired { get; set; }
        public bool IsTaxEnabled { get; set; }
        public string PhoneNo { get; set; }
        public string PS_StoreCode { get; set; }
        public string StoreName { get; set; }
        public long TaxMaxSequenceNo { get; set; }
        public long TaxMinSequenceNo { get; set; }
        public string TaxRegistrationNumber { get; set; }
        public string TaxRegistrationText { get; set; }
        public string WebsiteURL { get; set; }
        public string EmailID { get; set; }
        public bool RunApplicationsSubStoreLevel { get; set; }
        public string ServerHotFolderPath { get; set; }
        public bool IsActiveStockShot { get; set; }
        public bool RunImageProcessingEngineLocationWise { get; set; }
        public bool RunVideoProcessingEngineLocationWise { get; set; }
        public bool IsTaxIncluded { get; set; }
        public bool IsOnline { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<storeinfo> lst_storeinfo = new List<storeinfo>();
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    //foreach (var item in lst_str)
                    //{
                    storeinfo storeinfo = new storeinfo();
                    storeinfo.Id = 1;
                    storeinfo.Store_pkey = 1;
                    storeinfo.Store_Name = "Store Name";
                    storeinfo.Country = "India";
                    storeinfo.CentralServerIP = "";
                    storeinfo.StoreCode = "001";
                    storeinfo.CenetralServerUName = "";
                    storeinfo.CenetralServerPassword = "";
                    storeinfo.PreferredTimeToSyncFrom = 0;
                    storeinfo.PreferredTimeToSyncTo = 0;
                    storeinfo.QRCodeWebUrl = "";
                    storeinfo.CountryCode = "";
                    storeinfo.Address = "";
                    storeinfo.BillReceiptTitle = "";
                    storeinfo.IsSequenceNoRequired = false;// "";
                    storeinfo.IsTaxEnabled = false;//"";
                    storeinfo.PhoneNo = "";
                    storeinfo.PS_StoreCode = "";
                    storeinfo.StoreName = "Store Name";
                    storeinfo.TaxMaxSequenceNo = 0;
                    storeinfo.TaxMinSequenceNo = 0;
                    storeinfo.TaxRegistrationNumber = "";
                    storeinfo.TaxRegistrationText = "";
                    storeinfo.WebsiteURL = "";
                    storeinfo.EmailID = "";
                    storeinfo.RunApplicationsSubStoreLevel = false;
                    storeinfo.ServerHotFolderPath = "";
                    storeinfo.IsActiveStockShot = false;
                    storeinfo.RunImageProcessingEngineLocationWise = false;
                    storeinfo.RunVideoProcessingEngineLocationWise = false;
                    storeinfo.IsTaxIncluded = false;
                    storeinfo.IsOnline = false;
                    storeinfo.IsActive = true;
                    lst_storeinfo.Add(storeinfo);

                    // }
                    var Id = lst_storeinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.StoreInfos.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.StoreInfos.AddRange(lst_storeinfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.StoreInfos.AddRange(lst_storeinfo);
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static baStoreInfo GetStoreInfoDataById(int Id)
        {
            try
            {

                storeinfo storeinfo = new storeinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.StoreInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baStoreInfo
                    {
                        Id = p.Id,
                        Store_pkey = p.Store_pkey,
                        Store_Name = p.Store_Name,
                        Country = p.Country,
                        CentralServerIP = p.CentralServerIP,
                        StoreCode = p.StoreCode,
                        CenetralServerUName = p.CenetralServerUName,
                        CenetralServerPassword = p.CenetralServerPassword,
                        PreferredTimeToSyncFrom = p.PreferredTimeToSyncFrom,
                        PreferredTimeToSyncTo = p.PreferredTimeToSyncTo,
                        QRCodeWebUrl = p.QRCodeWebUrl,
                        CountryCode = p.CountryCode,
                        Address = p.Address,
                        BillReceiptTitle = p.BillReceiptTitle,
                        IsSequenceNoRequired = p.IsSequenceNoRequired,
                        IsTaxEnabled = p.IsTaxEnabled,
                        PhoneNo = p.PhoneNo,
                        PS_StoreCode = p.PS_StoreCode,
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
        public static List<baStoreInfo> GetStoreInfoData()
        {
            try
            {
                
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.StoreInfos.Where(p => p.IsActive == true).Select(p => new baStoreInfo
                    {
                        Id = p.Id,
                        Store_pkey = p.Store_pkey,
                        Store_Name = p.Store_Name,
                        Country = p.Country,
                        CentralServerIP = p.CentralServerIP,
                        StoreCode = p.StoreCode,
                        CenetralServerUName = p.CenetralServerUName,
                        CenetralServerPassword = p.CenetralServerPassword,
                        PreferredTimeToSyncFrom = p.PreferredTimeToSyncFrom,
                        PreferredTimeToSyncTo = p.PreferredTimeToSyncTo,
                        QRCodeWebUrl = p.QRCodeWebUrl,
                        CountryCode = p.CountryCode,
                        Address = p.Address,
                        BillReceiptTitle = p.BillReceiptTitle,
                        IsSequenceNoRequired = p.IsSequenceNoRequired,
                        IsTaxEnabled = p.IsTaxEnabled,
                        PhoneNo = p.PhoneNo,
                        PS_StoreCode = p.PS_StoreCode,
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

        public static bool Insert ( baStoreInfo baStoreInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    storeinfo storeinfo = new storeinfo();
                    storeinfo.Id = baStoreInfo.Id;
                    storeinfo.Store_pkey = baStoreInfo.Store_pkey;
                    storeinfo.Store_Name = baStoreInfo.Store_Name;
                    storeinfo.Country = baStoreInfo.Country;
                    storeinfo.CentralServerIP = baStoreInfo.CentralServerIP;
                    storeinfo.StoreCode = baStoreInfo.StoreCode;
                    storeinfo.CenetralServerUName = baStoreInfo.CenetralServerUName;
                    storeinfo.CenetralServerPassword = baStoreInfo.CenetralServerPassword;
                    storeinfo.PreferredTimeToSyncFrom = baStoreInfo.PreferredTimeToSyncFrom;
                    storeinfo.PreferredTimeToSyncTo = baStoreInfo.PreferredTimeToSyncTo;
                    storeinfo.QRCodeWebUrl = baStoreInfo.QRCodeWebUrl;
                    storeinfo.CountryCode = baStoreInfo.CountryCode;
                    storeinfo.Address = baStoreInfo.Address;
                    storeinfo.BillReceiptTitle = baStoreInfo.BillReceiptTitle;
                    storeinfo.IsSequenceNoRequired = baStoreInfo.IsSequenceNoRequired;
                    storeinfo.IsTaxEnabled = baStoreInfo.IsTaxEnabled;
                    storeinfo.PhoneNo = baStoreInfo.PhoneNo;
                    storeinfo.PS_StoreCode = baStoreInfo.PS_StoreCode;
                    storeinfo.StoreName = baStoreInfo.StoreName;
                    storeinfo.TaxMaxSequenceNo = baStoreInfo.TaxMaxSequenceNo;
                    storeinfo.TaxMinSequenceNo = baStoreInfo.TaxMinSequenceNo;
                    storeinfo.TaxRegistrationNumber = baStoreInfo.TaxRegistrationNumber;
                    storeinfo.TaxRegistrationText = baStoreInfo.TaxRegistrationText;
                    storeinfo.WebsiteURL = baStoreInfo.WebsiteURL;
                    storeinfo.EmailID = baStoreInfo.EmailID;
                    storeinfo.RunApplicationsSubStoreLevel = baStoreInfo.RunApplicationsSubStoreLevel;
                    storeinfo.ServerHotFolderPath = baStoreInfo.ServerHotFolderPath;
                    storeinfo.IsActiveStockShot = baStoreInfo.IsActiveStockShot;
                    storeinfo.RunImageProcessingEngineLocationWise = baStoreInfo.RunImageProcessingEngineLocationWise;
                    storeinfo.RunVideoProcessingEngineLocationWise = baStoreInfo.RunVideoProcessingEngineLocationWise;
                    storeinfo.IsTaxIncluded = baStoreInfo.IsTaxIncluded;
                    storeinfo.IsOnline = baStoreInfo.IsOnline;
                    storeinfo.IsActive = baStoreInfo.IsActive;

                    db.StoreInfos.Add(storeinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baStoreInfo baStoreInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.StoreInfos.Where(p => p.Id == baStoreInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        storeinfo storeinfo = new storeinfo();
                        storeinfo.Id = baStoreInfo.Id;
                        storeinfo.Store_pkey = baStoreInfo.Store_pkey;
                        storeinfo.Store_Name = baStoreInfo.Store_Name;
                        storeinfo.Country = baStoreInfo.Country;
                        storeinfo.CentralServerIP = baStoreInfo.CentralServerIP;
                        storeinfo.StoreCode = baStoreInfo.StoreCode;
                        storeinfo.CenetralServerUName = baStoreInfo.CenetralServerUName;
                        storeinfo.CenetralServerPassword = baStoreInfo.CenetralServerPassword;
                        storeinfo.PreferredTimeToSyncFrom = baStoreInfo.PreferredTimeToSyncFrom;
                        storeinfo.PreferredTimeToSyncTo = baStoreInfo.PreferredTimeToSyncTo;
                        storeinfo.QRCodeWebUrl = baStoreInfo.QRCodeWebUrl;
                        storeinfo.CountryCode = baStoreInfo.CountryCode;
                        storeinfo.Address = baStoreInfo.Address;
                        storeinfo.BillReceiptTitle = baStoreInfo.BillReceiptTitle;
                        storeinfo.IsSequenceNoRequired = baStoreInfo.IsSequenceNoRequired;
                        storeinfo.IsTaxEnabled = baStoreInfo.IsTaxEnabled;
                        storeinfo.PhoneNo = baStoreInfo.PhoneNo;
                        storeinfo.PS_StoreCode = baStoreInfo.PS_StoreCode;
                        storeinfo.StoreName = baStoreInfo.StoreName;
                        storeinfo.TaxMaxSequenceNo = baStoreInfo.TaxMaxSequenceNo;
                        storeinfo.TaxMinSequenceNo = baStoreInfo.TaxMinSequenceNo;
                        storeinfo.TaxRegistrationNumber = baStoreInfo.TaxRegistrationNumber;
                        storeinfo.TaxRegistrationText = baStoreInfo.TaxRegistrationText;
                        storeinfo.WebsiteURL = baStoreInfo.WebsiteURL;
                        storeinfo.EmailID = baStoreInfo.EmailID;
                        storeinfo.RunApplicationsSubStoreLevel = baStoreInfo.RunApplicationsSubStoreLevel;
                        storeinfo.ServerHotFolderPath = baStoreInfo.ServerHotFolderPath;
                        storeinfo.IsActiveStockShot = baStoreInfo.IsActiveStockShot;
                        storeinfo.RunImageProcessingEngineLocationWise = baStoreInfo.RunImageProcessingEngineLocationWise;
                        storeinfo.RunVideoProcessingEngineLocationWise = baStoreInfo.RunVideoProcessingEngineLocationWise;
                        storeinfo.IsTaxIncluded = baStoreInfo.IsTaxIncluded;
                        storeinfo.IsOnline = baStoreInfo.IsOnline;
                        storeinfo.IsActive = baStoreInfo.IsActive;

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
                    var obj = db.StoreInfos.Where(p => p.Id == Id).FirstOrDefault();
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


        }
    }
