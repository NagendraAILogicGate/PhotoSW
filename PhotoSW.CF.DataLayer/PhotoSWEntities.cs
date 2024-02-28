using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;
using SQLite.CodeFirst;

namespace PhotoSW.CF.DataLayer
{
    public class PhotoSWEntities : DbContext
    {
       // public DbSet<invoicetype> InvoiceTypes { get; set; }
        public DbSet<activityinfo> ActivityInfos { get; set; }

        public DbSet<alreadyrefundinfo> AlreadyrefundInfos { get; set; }

        public DbSet<archivedphotoinfo> ArchivedPhotoInfos { get; set; }

        public DbSet<associatedprintersinfo> AssociatedPrintersInfos { get; set; }

        public DbSet<audiotemplateinfo> AudioTemplateInfos { get; set; }

        public DbSet<backgroundinfo> BackGroundInfos { get; set; }

        public DbSet<backuphistory> BackupHistorys { get; set; }

        public DbSet<billformatinfo> BillFormatInfos { get; set; }

        public DbSet<borderinfo> BorderInfos { get; set; }

        public DbSet<burnimagesinfo> BurnImagesInfos { get; set; }

        public DbSet<burnorderinfo> BurnOrderInfos { get; set; }

        public DbSet<cameradeviceassociationinfo> CameraDeviceAssociationInfos { get; set; }

        public DbSet<camerainfo> CameraInfos { get; set; }

        public DbSet<cashboxinfo> CashBoxInfos { get; set; }

       public DbSet<cgconfigsettings> CGConfigSettingses { get; set; }

        public DbSet<characterinfo> CharacterInfos { get; set; }

        public DbSet<checkeditems> CheckedItemses { get; set; }

        public DbSet<chromakeytemplateinfo> ChromaKeyTemplateInfos { get; set; }
        public DbSet<configurationinfo> ConfigurationInfos { get; set; }

        public DbSet<currencyexchangeinfo> CurrencyExchangeinfos { get; set; }

        public DbSet<currencyinfo> CurrencyInfos { get; set; }

        public DbSet<discounttypeinfo> DiscountTypeInfos { get; set; }

        public DbSet<downloadfileinfo> DownloadFileInfos { get; set; }

        public DbSet<emaildetailinfo> EmailDetailInfos { get; set; }

        public DbSet<emailinfo> EMailInfos { get; set; }

        public DbSet<emailsettingsinfo> EmailSettingsInfos { get; set; }

        public DbSet<emailstatusinfo> EmailStatusInfos { get; set; }

        public DbSet<exportservicelog> ExportServiceLogs { get; set; }

        public DbSet<filephotoinfo> FilePhotoInfos { get; set; }

        public DbSet<financialaudittrail_result> FinancialAuditTrail_Results { get; set; }

        public DbSet<findcommandparameters> FindCommandParameterses { get; set; }

        public DbSet<folderdsructureinfo> FolderStructureInfos { get; set; }

        public DbSet<getlocationperformance_result> GetLocationPerformance_Results { get; set; }

        public DbSet<getphotgrapherperformance_result> GetPhotgrapherPerformance_Results { get; set; }

        public DbSet<getprintedproduct_result> GetPrintedProduct_Results { get; set; }

        public DbSet<getservicestatus> GetServiceStatuses { get; set; }

        public DbSet<generalbackgroundinfo> GeneralBackgroundInfos { get; set; }

        public DbSet<graphicsinfo> GraphicsInfos { get; set; }

        public DbSet<groupdetails> GroupDetailses { get; set; }

        public DbSet<groupinfo> GroupInfos { get; set; }

        public DbSet<gumride> GumRides { get; set; }

        public DbSet<imagecardtypeinfo> ImageCardTypeInfos { get; set; }
        public DbSet<iMIXconfigurationinfo> iMIXConfigurationInfos { get; set; }

        public DbSet<imixconfigurationlocationinfo> iMixConfigurationLocationInfos { get; set; }

        public DbSet<imixconfigurationlocationinfolist> iMixConfigurationLocationInfoLists { get; set; }

        public DbSet<imiximageassociationinfo> iMixImageAssociationInfos { get; set; }

        public DbSet<imiximagecardtypeinfo> iMixImageCardTypeInfos { get; set; }

        public DbSet<imixposdetail> ImixPOSDetails { get; set; }

        public DbSet<imixstoreconfigurationinfo> iMIXStoreConfigurationInfos { get; set; }

        public DbSet<inventoryconsumables> InventoryConsumableses { get; set; }

        public DbSet<itemtemplatedetailmodel> ItemTemplateDetailModels { get; set; }

        public DbSet<itemtemplatemastermodel> ItemTemplateMasterModels { get; set; }

        public DbSet<itemtemplateprintordermodel> ItemTemplatePrintOrderModels { get; set; }

        public DbSet<mappedpos> MappedPoses { get; set; }

        public DbSet<modratephotoinfo> ModratePhotoInfos { get; set; }

        public DbSet<operationalaudit_result> OperationalAudit_Results { get; set; }

        public DbSet<operatorperformancereport_result> OperatorPerformanceReport_Results { get; set; }

        public DbSet<orderdetaileddiscount_get_result> OrderDetailedDiscount_Get_Results { get; set; }

        public DbSet<orderdetailinfo> OrderDetailInfos { get; set; }

        public DbSet<orderdetails> OrderDetailses { get; set; }

        public DbSet<orderdetailsviewinfo> OrderDetailsViewInfos { get; set; }

        public DbSet<orderinfo> OrderInfos { get; set; }

        public DbSet<orderreceiptreprintinfo> OrderReceiptReprintInfos { get; set; }

        public DbSet<packagedetailsinfo> PackageDetailsInfos { get; set; }

        public DbSet<packagedetailsviewinfo> PackageDetailsViewInfos { get; set; }

        public DbSet<paymentsummaryinfo> PaymentSummaryInfos { get; set; }

        public DbSet<permisiionlist> PermisiionLists { get; set; }

       public DbSet<photocaptureinfo> PhotoCaptureInfos { get; set; }

       public DbSet<photodetail> PhotoDetails { get; set; }
       public DbSet<photographerRFIDassociationinfo> PhotographerRFIDAssociationInfos { get; set; }

        public DbSet<photographersinfo> PhotoGraphersInfos { get; set; }

        public DbSet<photoinfo> PhotoInfos { get; set; }

        public DbSet<presoldautoonlineorderinfo> PreSoldAutoOnlineOrderInfos { get; set; }

        //public DbSet<printer6850> Printer6850s { get; set; }

        //public DbSet<printer8810> Printer8810s { get; set; }

        public DbSet<printerdetails> PrinterDetailses { get; set; }

        public DbSet<printerdetailsinfo> PrinterDetailsInfos { get; set; }
        /////////////////********
       // public DbSet<printerjobinfo> PrinterJobInfos { get; set; }

        public DbSet<printerqueuedetailsinfo> PrinterQueueDetailsInfos { get; set; }

        //public DbSet<printerqueueforprint> PrinterQueueforPrints { get; set; }

        //public DbSet<printerqueueinfo> PrinterQueueInfos { get; set; }

        public DbSet<printertypeinfo> PrinterTypeInfos { get; set; }

        public DbSet<printloginfo> PrintLogInfos { get; set; }
        public DbSet<printsummary_result> PrintSummary_Results { get; set; }
        public DbSet<printsummarydetail> PrintSummaryDetails { get; set; }
        public DbSet<processedvideodetailsinfo> ProcessedVideoDetailsInfos { get; set; }

        //public DbSet<processedvideoinfo> ProcessedVideoInfos { get; set; }
       //////************ ///////////////


        public DbSet<product> Products { get; set; }

        public DbSet<productpriceinfo> ProductPriceInfos { get; set; }

        public DbSet<productsummary_result> ProductSummary_Results { get; set; }

        public DbSet<producttypeinfo> ProductTypeInfos { get; set; }

        public DbSet<ratedetailinfo> RateDetailInfos { get; set; }

        public DbSet<refunddetailinfo> RefundDetailInfos { get; set; }

        public DbSet<refundinfo> RefundInfos { get; set; }

        public DbSet<reportparams> ReportParamses { get; set; }

        public DbSet<rfidfield> RFIDFields { get; set; }

        public DbSet<rfidflushhistotyinfo> RfidFlushHistotyInfos { get; set; }

        public DbSet<rfidimageassociationinfo> RFIDImageAssociationInfos { get; set; }

        public DbSet<rfidinfo> RfidInfos { get; set; }

        public DbSet<rfidphotodetails> RFIDPhotoDetailses { get; set; }

        public DbSet<rfidtaginfo> RFIDTagInfos { get; set; }

        public DbSet<ridecamerasettinginfo> RideCameraSettingInfos { get; set; }

        public DbSet<sceneinfo> SceneInfos { get; set; }

        public DbSet<searchdetailinfo> SearchDetailInfos { get; set; }

        public DbSet<semiordersetting> SemiOrderSettings { get; set; }

        public DbSet<semiordersettingsinfo> SemiOrderSettingsInfos { get; set; }

        public DbSet<semiordersettingslist> SemiOrderSettingsLists { get; set; }

        public DbSet<seperatortaginfo> SeperatorTagInfos { get; set; }

        public DbSet<serviceemailcontent> ServiceEmailContents { get; set; }

        public DbSet<serviceposinfo> ServicePosInfos { get; set; }

        public DbSet<serviceposmapping> ServicePOSMappings { get; set; }

        public DbSet<servicerunninghistory> ServiceRunningHistorys { get; set; }
        public DbSet<servicesinfo> ServicesInfos { get; set; }

        public DbSet<sitecodedetail> SiteCodeDetails { get; set; }

        public DbSet<sliderinfo> SliderInfos { get; set; }
        public DbSet<specprofileproductmappinginfo> SpecProfileProductMappingInfos { get; set; }
        public DbSet<stockshot> StockShots { get; set; }

        public DbSet<svcrunninginfo> SvcRunningInfos { get; set; }

        public DbSet<synctriggerstatusinfo> SyncTriggerStatusInfos { get; set; }

        public DbSet<tablebaseinfo> TableBaseInfos { get; set; }

        public DbSet<taxdetailinfo> TaxDetailInfos { get; set; }

        //public DbSet<transdetail> TransDetails { get; set; }

        public DbSet<tripcaminfo> TripCamInfos { get; set; }

        public DbSet<tripcamsettinginfo> TripCamSettingInfos { get; set; }

        public DbSet<valuetypeinfo> ValueTypeInfos { get; set; }

        public DbSet<venuetaxvaluemodel> VenueTaxValueModels { get; set; }

        public DbSet<versionhistoryinfo> VersionHistoryInfos { get; set; }

        public DbSet<videobackgroundinfo> VideoBackgroundInfos { get; set; }

        public DbSet<videoconfigprofiles> VideoConfigProfiles { get; set; }

        public DbSet<videoobjectfilemapping> VideoObjectFileMappings { get; set; }
        //////
        public DbSet<videooverlay> VideoOverlays { get; set; }
        public DbSet<videoproducts> VideoProductses { get; set; }
        public DbSet<videoscene> VideoScenes { get; set; }
        public DbSet<videosceneobject> VideoSceneObjects { get; set; }

        //public DbSet<videosceneviewmodel> VideoSceneViewModels { get; set; }

        public DbSet<vw_getactivityreports> vw_GetActivityReportses { get; set; }

        public DbSet<vw_takingreport> vw_TakingReports { get; set; }

        public DbSet<watchersetting> WatcherSettings { get; set; }
        //////////
        public DbSet<substore> SubStores { get; set; }
        public DbSet<user> Users { get; set; }
        public DbSet<userinfo> UserInfos { get; set; }
        public DbSet<usersinfo> UsersInfos { get; set; }
        public DbSet<configinfo> ConfigInfos { get; set; }
        public DbSet<deviceinfo> DeviceInfos { get; set; }
        public DbSet<locationinfo> LocationInfos { get; set; }
        public DbSet<photogroupinfo> PhotoGroupInfos { get; set; }
        public DbSet<roleinfo> RoleInfos { get; set; }
        public DbSet<sageinfo> SageInfos { get; set; }
        public DbSet<sageinfoclosing> SageInfoClosings { get; set; }
        public DbSet<sageinfowestage> SageInfoWestages { get; set; }
        public DbSet<sageopenclose> SageOpenCloses { get; set; }
        public DbSet<storeinfo> StoreInfos { get; set; }
        public DbSet<substoresinfo> SubStoresInfos { get; set; }
        public DbSet<substorelocationinfo> SubStoreLocationInfos { get; set; }
        public DbSet<syncstatusinfo> SyncStatusInfos { get; set; }

        public DbSet<permissionroleinfo> PermissionRoleInfos { get; set; }
        public DbSet<permissioninfo> PermissionInfos { get; set; }

        public DbSet<associatedimageinfo> AssociatedImageInfos { get; set; }

        //public DbSet<reporttypedetail> ReportTypeDetails { get; set; }
        public PhotoSWEntities ()
            : base(new System.Data.SQLite.SQLiteConnection()
            {

                ConnectionString =
                    new System.Data.SQLite.SQLiteConnectionStringBuilder { DataSource = System.AppDomain.CurrentDomain.BaseDirectory + "db\\" + "PhotoSWDB" + ".db", ForeignKeys = true }
                    .ConnectionString
            }, true)
            {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;

            }

        protected override void OnModelCreating ( DbModelBuilder modelBuilder )
            {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            var initializer = new PhotoSWEntitiesDbInitializer(modelBuilder);
            Database.SetInitializer(initializer);

            }
        }

    public class PhotoSWEntitiesDbInitializer : SqliteCreateDatabaseIfNotExists<PhotoSWEntities>
        {
        public PhotoSWEntitiesDbInitializer ( DbModelBuilder modelBuilder )
            : base(modelBuilder)
        { }

        protected override void Seed ( PhotoSWEntities context )
            {
            base.Seed(context);
            }
        }
    
}
