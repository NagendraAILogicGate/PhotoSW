using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.EntityClient;
using System.Data.Objects;

namespace PhotoSW.DataLayer.Model
    {
    public class DigiphotoEntities : ObjectContext
        {
        private ObjectSet<DG_Albums> ;

		private ObjectSet<DG_Albums_Photos> ;

		private ObjectSet<DG_ApplicationSettings> ;

		private ObjectSet<DG_Borders> ;

		private ObjectSet<DG_ColorCodes> ;

		private ObjectSet<DG_Location> ;

		private ObjectSet<DG_Moderate_Photos> ;

		private ObjectSet<DG_PackageDetails> ;

		private ObjectSet<DG_Permission_Role> ;

		private ObjectSet<DG_Permissions> ;

		private ObjectSet<DG_Photo_Effects> ;

		private ObjectSet<DG_PhotoNumberConfiguration> ;

		private ObjectSet<DG_Photos_Changes> ;

		private ObjectSet<DG_Preview_Counter> ;

		private ObjectSet<DG_Printers> ;

		private ObjectSet<DG_PrintLog> ;

		private ObjectSet<DG_Product_Pricing> ;

		private ObjectSet<DG_SubProducts> ;

		private ObjectSet<DG_User_Roles> ;

		private ObjectSet<DG_Users> ;

		private ObjectSet<tblPhotoDetail> ;

		private ObjectSet<tblprinter> ;

		private ObjectSet<vw_GetBorderDetails> ;

		private ObjectSet<vw_GetPackageDetails> ;

		private ObjectSet<vw_GetPhotoEffects> ;

		private ObjectSet<vw_GetPrintDetails> ;

		private ObjectSet<vw_GetUserDetails> ;

		private ObjectSet<DG_AssociatedPrinters> ;

		private ObjectSet<DG_CameraDetails> ;

		private ObjectSet<DG_Activity> ;

		private ObjectSet<DG_BackGround> ;

		private ObjectSet<vw_GetCameraDetails> ;

		private ObjectSet<DG_Services> ;

		private ObjectSet<DG_Graphics> ;

		private ObjectSet<vw_GetProductNameforOrder> ;

		private ObjectSet<DG_Refund> ;

		private ObjectSet<GetOrderQuantity> ;

		private ObjectSet<vw_OrderBurnedItems> ;

		private ObjectSet<vw_GetOrderDetailsforRefund> ;

		private ObjectSet<DG_Bill_Format> ;

		private ObjectSet<vw_GetPhotoList> ;

		private ObjectSet<DG_PrinterQueue> ;

		private ObjectSet<vw_GetRecordsForArchive> ;

		private ObjectSet<DG_VersionHistory> ;

		private ObjectSet<DG_Currency> ;

		private ObjectSet<DG_Orders_DiscountType> ;

		private ObjectSet<DG_SyncStatus> ;

		private ObjectSet<vw_GetActivityReports> ;

		private ObjectSet<GetServerDateTime> ;

		private ObjectSet<DG_RideCameraConfiguration> ;

		private ObjectSet<vw_ProductPrinters> ;

		private ObjectSet<DG_SubStore_Locations> ;

		private ObjectSet<DG_SubStores> ;

		private ObjectSet<vw_GetSubStoreData> ;

		private ObjectSet<vw_GetSubStoreLocations> ;

		private ObjectSet<DG_EmailSettings> ;

		private ObjectSet<DG_ReceiptPrinter> ;

		private ObjectSet<vw_GetRideCamera> ;

		private ObjectSet<vw_GetGroupedImages> ;

		private ObjectSet<DG_PhotoGroup> ;

		private ObjectSet<DG_CashBox> ;

		private ObjectSet<ValueType> ;

		private ObjectSet<ValueTypeGroup> ;

		private ObjectSet<DG_Orders> ;

		private ObjectSet<DG_RefundDetails> ;

		private ObjectSet<DG_Actions_Type> ;

		private ObjectSet<PhotoAlbumPrintOrder> ;

		private ObjectSet<vw_GetPrinterDetails> ;

		private ObjectSet<vw_GetPrinterQueue> ;

		private ObjectSet<vw_GetFilteredPrinterQueue> ;

		private ObjectSet<vw_GetPrinterQueueforPrint> ;

		private ObjectSet<vw_GetAllTable> ;

		private ObjectSet<DG_Orders_ProductType> ;

		private ObjectSet<vw_GetOrderDetails> ;

		private ObjectSet<vw_GetConfigdata> ;

		private ObjectSet<DG_Configuration> ;

		private ObjectSet<DG_Emails> ;

		private ObjectSet<ClientApplicationVersions> ;

		private ObjectSet<iIMIXConfigurationMaster> ;

		private ObjectSet<iMIXConfigurationValue> ;

		private ObjectSet<BackupHistory> ;

		private ObjectSet<ArchivedPhotos> ;

		private ObjectSet<ChangeTracking> ;

		private ObjectSet<iMixCardRule> ;

		private ObjectSet<iMixImageAssociation> ;

		private ObjectSet<iMIXImageAssociationRule> ;

		private ObjectSet<ErrorLog> ;

		private ObjectSet<iMixImageCardType> ;

		private ObjectSet<DG_SemiOrder_Settings> ;

		private ObjectSet<vw_GetFilteredPrinterQueueForPrint> ;

		private ObjectSet<vw_GetProductTypeData> ;

		private ObjectSet<DG_Orders_Details> ;

		private ObjectSet<DG_Photos> ;

		private ObjectSet<vw_GetPhotographer> ;

		private ObjectSet<vw_TakingReport> ;

		private ObjectSet<DG_Store> ;

		private ObjectSet<vw_GetListAvailableLocations> ;

		[NonSerialized]
        internal static GetString ;

		public ObjectSet<DG_Albums> DG_Albums
            {
            get
                {
                if(this. == null)
				{
                    this. = base.CreateObjectSet<DG_Albums>(DigiphotoEntities.(727));
                    }
                return this.;
                }
            }

        public ObjectSet<DG_Albums_Photos> DG_Albums_Photos
            {
            get
                {
                if(this. == null)
				{
                    this. = base.CreateObjectSet<DG_Albums_Photos>(DigiphotoEntities.(740));
                    }
                return this.;
                }
            }

        public ObjectSet<DG_ApplicationSettings> DG_ApplicationSettings
            {
            get
                {
                if(this. == null)
				{
                    this. = base.CreateObjectSet<DG_ApplicationSettings>(DigiphotoEntities.(765));
                    }
                return this.;
                }
            }

        public ObjectSet<DG_Borders> DG_Borders
            {
            get
                {
                if(this. == null)
				{
                    this. = base.CreateObjectSet<DG_Borders>(DigiphotoEntities.(798));
                    }
                return this.;
                }
            }

        public ObjectSet<DG_ColorCodes> DG_ColorCodes
            {
            get
                {
                if(this. == null)
				{
                    this. = base.CreateObjectSet<DG_ColorCodes>(DigiphotoEntities.(815));
                    }
                return this.;
                }
            }

        public ObjectSet<DG_Location> DG_Location
            {
            get
                {
                if(this. == null)
				{
                    this. = base.CreateObjectSet<DG_Location>(DigiphotoEntities.(836));
                    }
                return this.;
                }
            }

        public ObjectSet<DG_Moderate_Photos> DG_Moderate_Photos
            {
            get
                {
                if(this. == null)
				{
                    this. = base.CreateObjectSet<DG_Moderate_Photos>(DigiphotoEntities.(853));
                    }
                return this.;
                }
            }

        public ObjectSet<DG_PackageDetails> DG_PackageDetails
            {
            get
                {
                if(this. == null)
				{
                    this. = base.CreateObjectSet<DG_PackageDetails>(DigiphotoEntities.(878));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Permission_Role> DG_Permission_Role
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Permission_Role>(DigiphotoEntities.(903));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Permissions> DG_Permissions
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Permissions>(DigiphotoEntities.(928));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Photo_Effects> DG_Photo_Effects
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Photo_Effects>(DigiphotoEntities.(949));
				}
				return this.;
			}
		}

		public ObjectSet<DG_PhotoNumberConfiguration> DG_PhotoNumberConfiguration
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_PhotoNumberConfiguration>(DigiphotoEntities.(974));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Photos_Changes> DG_Photos_Changes
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Photos_Changes>(DigiphotoEntities.(1011));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Preview_Counter> DG_Preview_Counter
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Preview_Counter>(DigiphotoEntities.(1036));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Printers> DG_Printers
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Printers>(DigiphotoEntities.(1061));
				}
				return this.;
			}
		}

		public ObjectSet<DG_PrintLog> DG_PrintLog
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_PrintLog>(DigiphotoEntities.(1078));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Product_Pricing> DG_Product_Pricing
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Product_Pricing>(DigiphotoEntities.(1095));
				}
				return this.;
			}
		}

		public ObjectSet<DG_SubProducts> DG_SubProducts
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_SubProducts>(DigiphotoEntities.(1120));
				}
				return this.;
			}
		}

		public ObjectSet<DG_User_Roles> DG_User_Roles
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_User_Roles>(DigiphotoEntities.(1141));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Users> DG_Users
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Users>(DigiphotoEntities.(1162));
				}
				return this.;
			}
		}

		public ObjectSet<tblPhotoDetail> tblPhotoDetails
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<tblPhotoDetail>(DigiphotoEntities.(1175));
				}
				return this.;
			}
		}

		public ObjectSet<tblprinter> tblprinters
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<tblprinter>(DigiphotoEntities.(1196));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetBorderDetails> vw_GetBorderDetails
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetBorderDetails>(DigiphotoEntities.(1213));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetPackageDetails> vw_GetPackageDetails
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetPackageDetails>(DigiphotoEntities.(1242));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetPhotoEffects> vw_GetPhotoEffects
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetPhotoEffects>(DigiphotoEntities.(1271));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetPrintDetails> vw_GetPrintDetails
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetPrintDetails>(DigiphotoEntities.(1296));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetUserDetails> vw_GetUserDetails
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetUserDetails>(DigiphotoEntities.(1321));
				}
				return this.;
			}
		}

		public ObjectSet<DG_AssociatedPrinters> DG_AssociatedPrinters
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_AssociatedPrinters>(DigiphotoEntities.(1346));
				}
				return this.;
			}
		}

		public ObjectSet<DG_CameraDetails> DG_CameraDetails
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_CameraDetails>(DigiphotoEntities.(1375));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Activity> DG_Activity
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Activity>(DigiphotoEntities.(1400));
				}
				return this.;
			}
		}

		public ObjectSet<DG_BackGround> DG_BackGround
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_BackGround>(DigiphotoEntities.(1417));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetCameraDetails> vw_GetCameraDetails
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetCameraDetails>(DigiphotoEntities.(1438));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Services> DG_Services
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Services>(DigiphotoEntities.(1467));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Graphics> DG_Graphics
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Graphics>(DigiphotoEntities.(1484));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetProductNameforOrder> vw_GetProductNameforOrder
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetProductNameforOrder>(DigiphotoEntities.(1501));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Refund> DG_Refund
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Refund>(DigiphotoEntities.(1538));
				}
				return this.;
			}
		}

		public ObjectSet<GetOrderQuantity> GetOrderQuantities
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<GetOrderQuantity>(DigiphotoEntities.(1551));
				}
				return this.;
			}
		}

		public ObjectSet<vw_OrderBurnedItems> vw_OrderBurnedItems
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_OrderBurnedItems>(DigiphotoEntities.(1576));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetOrderDetailsforRefund> vw_GetOrderDetailsforRefund
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetOrderDetailsforRefund>(DigiphotoEntities.(1605));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Bill_Format> DG_Bill_Format
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Bill_Format>(DigiphotoEntities.(1642));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetPhotoList> vw_GetPhotoList
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetPhotoList>(DigiphotoEntities.(1663));
				}
				return this.;
			}
		}

		public ObjectSet<DG_PrinterQueue> DG_PrinterQueue
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_PrinterQueue>(DigiphotoEntities.(1684));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetRecordsForArchive> vw_GetRecordsForArchive
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetRecordsForArchive>(DigiphotoEntities.(1705));
				}
				return this.;
			}
		}

		public ObjectSet<DG_VersionHistory> DG_VersionHistory
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_VersionHistory>(DigiphotoEntities.(1738));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Currency> DG_Currency
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Currency>(DigiphotoEntities.(1763));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Orders_DiscountType> DG_Orders_DiscountType
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Orders_DiscountType>(DigiphotoEntities.(1780));
				}
				return this.;
			}
		}

		public ObjectSet<DG_SyncStatus> DG_SyncStatus
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_SyncStatus>(DigiphotoEntities.(1813));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetActivityReports> vw_GetActivityReports
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetActivityReports>(DigiphotoEntities.(1834));
				}
				return this.;
			}
		}

		public ObjectSet<GetServerDateTime> GetServerDateTime
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<GetServerDateTime>(DigiphotoEntities.(1863));
				}
				return this.;
			}
		}

		public ObjectSet<DG_RideCameraConfiguration> DG_RideCameraConfiguration
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_RideCameraConfiguration>(DigiphotoEntities.(1888));
				}
				return this.;
			}
		}

		public ObjectSet<vw_ProductPrinters> vw_ProductPrinters
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_ProductPrinters>(DigiphotoEntities.(1925));
				}
				return this.;
			}
		}

		public ObjectSet<DG_SubStore_Locations> DG_SubStore_Locations
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_SubStore_Locations>(DigiphotoEntities.(1950));
				}
				return this.;
			}
		}

		public ObjectSet<DG_SubStores> DG_SubStores
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_SubStores>(DigiphotoEntities.(1979));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetSubStoreData> vw_GetSubStoreData
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetSubStoreData>(DigiphotoEntities.(1996));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetSubStoreLocations> vw_GetSubStoreLocations
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetSubStoreLocations>(DigiphotoEntities.(2021));
				}
				return this.;
			}
		}

		public ObjectSet<DG_EmailSettings> DG_EmailSettings
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_EmailSettings>(DigiphotoEntities.(2054));
				}
				return this.;
			}
		}

		public ObjectSet<DG_ReceiptPrinter> DG_ReceiptPrinter
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_ReceiptPrinter>(DigiphotoEntities.(2079));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetRideCamera> vw_GetRideCamera
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetRideCamera>(DigiphotoEntities.(2104));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetGroupedImages> vw_GetGroupedImages
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetGroupedImages>(DigiphotoEntities.(2129));
				}
				return this.;
			}
		}

		public ObjectSet<DG_PhotoGroup> DG_PhotoGroup
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_PhotoGroup>(DigiphotoEntities.(2158));
				}
				return this.;
			}
		}

		public ObjectSet<DG_CashBox> DG_CashBox
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_CashBox>(DigiphotoEntities.(2179));
				}
				return this.;
			}
		}

		public ObjectSet<ValueType> ValueType
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<ValueType>(DigiphotoEntities.(2196));
				}
				return this.;
			}
		}

		public ObjectSet<ValueTypeGroup> ValueTypeGroup
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<ValueTypeGroup>(DigiphotoEntities.(2209));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Orders> DG_Orders
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Orders>(DigiphotoEntities.(2230));
				}
				return this.;
			}
		}

		public ObjectSet<DG_RefundDetails> DG_RefundDetails
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_RefundDetails>(DigiphotoEntities.(2243));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Actions_Type> DG_Actions_Type
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Actions_Type>(DigiphotoEntities.(2268));
				}
				return this.;
			}
		}

		public ObjectSet<PhotoAlbumPrintOrder> PhotoAlbumPrintOrder
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<PhotoAlbumPrintOrder>(DigiphotoEntities.(2289));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetPrinterDetails> vw_GetPrinterDetails
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetPrinterDetails>(DigiphotoEntities.(2318));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetPrinterQueue> vw_GetPrinterQueue
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetPrinterQueue>(DigiphotoEntities.(2347));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetFilteredPrinterQueue> vw_GetFilteredPrinterQueue
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetFilteredPrinterQueue>(DigiphotoEntities.(2372));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetPrinterQueueforPrint> vw_GetPrinterQueueforPrint
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetPrinterQueueforPrint>(DigiphotoEntities.(2409));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetAllTable> vw_GetAllTable
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetAllTable>(DigiphotoEntities.(2446));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Orders_ProductType> DG_Orders_ProductType
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Orders_ProductType>(DigiphotoEntities.(2467));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetOrderDetails> vw_GetOrderDetails
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetOrderDetails>(DigiphotoEntities.(2496));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetConfigdata> vw_GetConfigdata
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetConfigdata>(DigiphotoEntities.(2521));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Configuration> DG_Configuration
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Configuration>(DigiphotoEntities.(2546));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Emails> DG_Emails
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Emails>(DigiphotoEntities.(2571));
				}
				return this.;
			}
		}

		public ObjectSet<ClientApplicationVersions> ClientApplicationVersions
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<ClientApplicationVersions>(DigiphotoEntities.(2584));
				}
				return this.;
			}
		}

		public ObjectSet<iIMIXConfigurationMaster> iIMIXConfigurationMaster
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<iIMIXConfigurationMaster>(DigiphotoEntities.(2621));
				}
				return this.;
			}
		}

		public ObjectSet<iMIXConfigurationValue> iMIXConfigurationValue
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<iMIXConfigurationValue>(DigiphotoEntities.(2654));
				}
				return this.;
			}
		}

		public ObjectSet<BackupHistory> BackupHistory
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<BackupHistory>(DigiphotoEntities.(2687));
				}
				return this.;
			}
		}

		public ObjectSet<ArchivedPhotos> ArchivedPhotos
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<ArchivedPhotos>(DigiphotoEntities.(2708));
				}
				return this.;
			}
		}

		public ObjectSet<ChangeTracking> ChangeTracking
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<ChangeTracking>(DigiphotoEntities.(2729));
				}
				return this.;
			}
		}

		public ObjectSet<iMixCardRule> iMixCardRule
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<iMixCardRule>(DigiphotoEntities.(2750));
				}
				return this.;
			}
		}

		public ObjectSet<iMixImageAssociation> iMixImageAssociation
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<iMixImageAssociation>(DigiphotoEntities.(2767));
				}
				return this.;
			}
		}

		public ObjectSet<iMIXImageAssociationRule> iMIXImageAssociationRule
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<iMIXImageAssociationRule>(DigiphotoEntities.(2796));
				}
				return this.;
			}
		}

		public ObjectSet<ErrorLog> ErrorLog
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<ErrorLog>(DigiphotoEntities.(2829));
				}
				return this.;
			}
		}

		public ObjectSet<iMixImageCardType> iMixImageCardType
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<iMixImageCardType>(DigiphotoEntities.(2842));
				}
				return this.;
			}
		}

		public ObjectSet<DG_SemiOrder_Settings> DG_SemiOrder_Settings
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_SemiOrder_Settings>(DigiphotoEntities.(2867));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetFilteredPrinterQueueForPrint> vw_GetFilteredPrinterQueueForPrint
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetFilteredPrinterQueueForPrint>(DigiphotoEntities.(2896));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetProductTypeData> vw_GetProductTypeData
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetProductTypeData>(DigiphotoEntities.(2945));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Orders_Details> DG_Orders_Details
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Orders_Details>(DigiphotoEntities.(2974));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Photos> DG_Photos
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Photos>(DigiphotoEntities.(2999));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetPhotographer> vw_GetPhotographer
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetPhotographer>(DigiphotoEntities.(3012));
				}
				return this.;
			}
		}

		public ObjectSet<vw_TakingReport> vw_TakingReport
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_TakingReport>(DigiphotoEntities.(3037));
				}
				return this.;
			}
		}

		public ObjectSet<DG_Store> DG_Store
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<DG_Store>(DigiphotoEntities.(3058));
				}
				return this.;
			}
		}

		public ObjectSet<vw_GetListAvailableLocations> vw_GetListAvailableLocations
		{
			get
			{
				if (this. == null)
				{
					this. = base.CreateObjectSet<vw_GetListAvailableLocations>(DigiphotoEntities.(3071));
				}
				return this.;
			}
		}

		public DigiphotoEntities() : base(DigiphotoEntities.(669), DigiphotoEntities.(702))
		{
			base.ContextOptions.LazyLoadingEnabled = true;
		}

		public DigiphotoEntities(string connectionString) : base(connectionString, DigiphotoEntities.(702))
		{
			base.ContextOptions.LazyLoadingEnabled = true;
		}

		public DigiphotoEntities(EntityConnection connection) : base(connection, DigiphotoEntities.(702))
		{
			base.ContextOptions.LazyLoadingEnabled = true;
		}

		public void AddToDG_Albums(DG_Albums dG_Albums)
		{
			base.AddObject(DigiphotoEntities.(727), dG_Albums);
		}

		public void AddToDG_Albums_Photos(DG_Albums_Photos dG_Albums_Photos)
		{
			base.AddObject(DigiphotoEntities.(740), dG_Albums_Photos);
		}

		public void AddToDG_ApplicationSettings(DG_ApplicationSettings dG_ApplicationSettings)
		{
			base.AddObject(DigiphotoEntities.(765), dG_ApplicationSettings);
		}

		public void AddToDG_Borders(DG_Borders dG_Borders)
		{
			base.AddObject(DigiphotoEntities.(798), dG_Borders);
		}

		public void AddToDG_ColorCodes(DG_ColorCodes dG_ColorCodes)
		{
			base.AddObject(DigiphotoEntities.(815), dG_ColorCodes);
		}

		public void AddToDG_Location(DG_Location dG_Location)
		{
			base.AddObject(DigiphotoEntities.(836), dG_Location);
		}

		public void AddToDG_Moderate_Photos(DG_Moderate_Photos dG_Moderate_Photos)
		{
			base.AddObject(DigiphotoEntities.(853), dG_Moderate_Photos);
		}

		public void AddToDG_PackageDetails(DG_PackageDetails dG_PackageDetails)
		{
			base.AddObject(DigiphotoEntities.(878), dG_PackageDetails);
		}

		public void AddToDG_Permission_Role(DG_Permission_Role dG_Permission_Role)
		{
			base.AddObject(DigiphotoEntities.(903), dG_Permission_Role);
		}

		public void AddToDG_Permissions(DG_Permissions dG_Permissions)
		{
			base.AddObject(DigiphotoEntities.(928), dG_Permissions);
		}

		public void AddToDG_Photo_Effects(DG_Photo_Effects dG_Photo_Effects)
		{
			base.AddObject(DigiphotoEntities.(949), dG_Photo_Effects);
		}

		public void AddToDG_PhotoNumberConfiguration(DG_PhotoNumberConfiguration dG_PhotoNumberConfiguration)
		{
			base.AddObject(DigiphotoEntities.(974), dG_PhotoNumberConfiguration);
		}

		public void AddToDG_Photos_Changes(DG_Photos_Changes dG_Photos_Changes)
		{
			base.AddObject(DigiphotoEntities.(1011), dG_Photos_Changes);
		}

		public void AddToDG_Preview_Counter(DG_Preview_Counter dG_Preview_Counter)
		{
			base.AddObject(DigiphotoEntities.(1036), dG_Preview_Counter);
		}

		public void AddToDG_Printers(DG_Printers dG_Printers)
		{
			base.AddObject(DigiphotoEntities.(1061), dG_Printers);
		}

		public void AddToDG_PrintLog(DG_PrintLog dG_PrintLog)
		{
			base.AddObject(DigiphotoEntities.(1078), dG_PrintLog);
		}

		public void AddToDG_Product_Pricing(DG_Product_Pricing dG_Product_Pricing)
		{
			base.AddObject(DigiphotoEntities.(1095), dG_Product_Pricing);
		}

		public void AddToDG_SubProducts(DG_SubProducts dG_SubProducts)
		{
			base.AddObject(DigiphotoEntities.(1120), dG_SubProducts);
		}

		public void AddToDG_User_Roles(DG_User_Roles dG_User_Roles)
		{
			base.AddObject(DigiphotoEntities.(1141), dG_User_Roles);
		}

		public void AddToDG_Users(DG_Users dG_Users)
		{
			base.AddObject(DigiphotoEntities.(1162), dG_Users);
		}

		public void AddTotblPhotoDetails(tblPhotoDetail tblPhotoDetail)
		{
			base.AddObject(DigiphotoEntities.(1175), tblPhotoDetail);
		}

		public void AddTotblprinters(tblprinter tblprinter)
		{
			base.AddObject(DigiphotoEntities.(1196), tblprinter);
		}

		public void AddTovw_GetBorderDetails(vw_GetBorderDetails vw_GetBorderDetails)
		{
			base.AddObject(DigiphotoEntities.(1213), vw_GetBorderDetails);
		}

		public void AddTovw_GetPackageDetails(vw_GetPackageDetails vw_GetPackageDetails)
		{
			base.AddObject(DigiphotoEntities.(1242), vw_GetPackageDetails);
		}

		public void AddTovw_GetPhotoEffects(vw_GetPhotoEffects vw_GetPhotoEffects)
		{
			base.AddObject(DigiphotoEntities.(1271), vw_GetPhotoEffects);
		}

		public void AddTovw_GetPrintDetails(vw_GetPrintDetails vw_GetPrintDetails)
		{
			base.AddObject(DigiphotoEntities.(1296), vw_GetPrintDetails);
		}

		public void AddTovw_GetUserDetails(vw_GetUserDetails vw_GetUserDetails)
		{
			base.AddObject(DigiphotoEntities.(1321), vw_GetUserDetails);
		}

		public void AddToDG_AssociatedPrinters(DG_AssociatedPrinters dG_AssociatedPrinters)
		{
			base.AddObject(DigiphotoEntities.(1346), dG_AssociatedPrinters);
		}

		public void AddToDG_CameraDetails(DG_CameraDetails dG_CameraDetails)
		{
			base.AddObject(DigiphotoEntities.(1375), dG_CameraDetails);
		}

		public void AddToDG_Activity(DG_Activity dG_Activity)
		{
			base.AddObject(DigiphotoEntities.(1400), dG_Activity);
		}

		public void AddToDG_BackGround(DG_BackGround dG_BackGround)
		{
			base.AddObject(DigiphotoEntities.(1417), dG_BackGround);
		}

		public void AddTovw_GetCameraDetails(vw_GetCameraDetails vw_GetCameraDetails)
		{
			base.AddObject(DigiphotoEntities.(1438), vw_GetCameraDetails);
		}

		public void AddToDG_Services(DG_Services dG_Services)
		{
			base.AddObject(DigiphotoEntities.(1467), dG_Services);
		}

		public void AddToDG_Graphics(DG_Graphics dG_Graphics)
		{
			base.AddObject(DigiphotoEntities.(1484), dG_Graphics);
		}

		public void AddTovw_GetProductNameforOrder(vw_GetProductNameforOrder vw_GetProductNameforOrder)
		{
			base.AddObject(DigiphotoEntities.(1501), vw_GetProductNameforOrder);
		}

		public void AddToDG_Refund(DG_Refund dG_Refund)
		{
			base.AddObject(DigiphotoEntities.(1538), dG_Refund);
		}

		public void AddToGetOrderQuantities(GetOrderQuantity getOrderQuantity)
		{
			base.AddObject(DigiphotoEntities.(1551), getOrderQuantity);
		}

		public void AddTovw_OrderBurnedItems(vw_OrderBurnedItems vw_OrderBurnedItems)
		{
			base.AddObject(DigiphotoEntities.(1576), vw_OrderBurnedItems);
		}

		public void AddTovw_GetOrderDetailsforRefund(vw_GetOrderDetailsforRefund vw_GetOrderDetailsforRefund)
		{
			base.AddObject(DigiphotoEntities.(1605), vw_GetOrderDetailsforRefund);
		}

		public void AddToDG_Bill_Format(DG_Bill_Format dG_Bill_Format)
		{
			base.AddObject(DigiphotoEntities.(1642), dG_Bill_Format);
		}

		public void AddTovw_GetPhotoList(vw_GetPhotoList vw_GetPhotoList)
		{
			base.AddObject(DigiphotoEntities.(1663), vw_GetPhotoList);
		}

		public void AddToDG_PrinterQueue(DG_PrinterQueue dG_PrinterQueue)
		{
			base.AddObject(DigiphotoEntities.(1684), dG_PrinterQueue);
		}

		public void AddTovw_GetRecordsForArchive(vw_GetRecordsForArchive vw_GetRecordsForArchive)
		{
			base.AddObject(DigiphotoEntities.(1705), vw_GetRecordsForArchive);
		}

		public void AddToDG_VersionHistory(DG_VersionHistory dG_VersionHistory)
		{
			base.AddObject(DigiphotoEntities.(1738), dG_VersionHistory);
		}

		public void AddToDG_Currency(DG_Currency dG_Currency)
		{
			base.AddObject(DigiphotoEntities.(1763), dG_Currency);
		}

		public void AddToDG_Orders_DiscountType(DG_Orders_DiscountType dG_Orders_DiscountType)
		{
			base.AddObject(DigiphotoEntities.(1780), dG_Orders_DiscountType);
		}

		public void AddToDG_SyncStatus(DG_SyncStatus dG_SyncStatus)
		{
			base.AddObject(DigiphotoEntities.(1813), dG_SyncStatus);
		}

		public void AddTovw_GetActivityReports(vw_GetActivityReports vw_GetActivityReports)
		{
			base.AddObject(DigiphotoEntities.(1834), vw_GetActivityReports);
		}

		public void AddToGetServerDateTime(GetServerDateTime getServerDateTime)
		{
			base.AddObject(DigiphotoEntities.(1863), getServerDateTime);
		}

		public void AddToDG_RideCameraConfiguration(DG_RideCameraConfiguration dG_RideCameraConfiguration)
		{
			base.AddObject(DigiphotoEntities.(1888), dG_RideCameraConfiguration);
		}

		public void AddTovw_ProductPrinters(vw_ProductPrinters vw_ProductPrinters)
		{
			base.AddObject(DigiphotoEntities.(1925), vw_ProductPrinters);
		}

		public void AddToDG_SubStore_Locations(DG_SubStore_Locations dG_SubStore_Locations)
		{
			base.AddObject(DigiphotoEntities.(1950), dG_SubStore_Locations);
		}

		public void AddToDG_SubStores(DG_SubStores dG_SubStores)
		{
			base.AddObject(DigiphotoEntities.(1979), dG_SubStores);
		}

		public void AddTovw_GetSubStoreData(vw_GetSubStoreData vw_GetSubStoreData)
		{
			base.AddObject(DigiphotoEntities.(1996), vw_GetSubStoreData);
		}

		public void AddTovw_GetSubStoreLocations(vw_GetSubStoreLocations vw_GetSubStoreLocations)
		{
			base.AddObject(DigiphotoEntities.(2021), vw_GetSubStoreLocations);
		}

		public void AddToDG_EmailSettings(DG_EmailSettings dG_EmailSettings)
		{
			base.AddObject(DigiphotoEntities.(2054), dG_EmailSettings);
		}

		public void AddToDG_ReceiptPrinter(DG_ReceiptPrinter dG_ReceiptPrinter)
		{
			base.AddObject(DigiphotoEntities.(2079), dG_ReceiptPrinter);
		}

		public void AddTovw_GetRideCamera(vw_GetRideCamera vw_GetRideCamera)
		{
			base.AddObject(DigiphotoEntities.(2104), vw_GetRideCamera);
		}

		public void AddTovw_GetGroupedImages(vw_GetGroupedImages vw_GetGroupedImages)
		{
			base.AddObject(DigiphotoEntities.(2129), vw_GetGroupedImages);
		}

		public void AddToDG_PhotoGroup(DG_PhotoGroup dG_PhotoGroup)
		{
			base.AddObject(DigiphotoEntities.(2158), dG_PhotoGroup);
		}

		public void AddToDG_CashBox(DG_CashBox dG_CashBox)
		{
			base.AddObject(DigiphotoEntities.(2179), dG_CashBox);
		}

		public void AddToValueType(ValueType valueType)
		{
			base.AddObject(DigiphotoEntities.(2196), valueType);
		}

		public void AddToValueTypeGroup(ValueTypeGroup valueTypeGroup)
		{
			base.AddObject(DigiphotoEntities.(2209), valueTypeGroup);
		}

		public void AddToDG_Orders(DG_Orders dG_Orders)
		{
			base.AddObject(DigiphotoEntities.(2230), dG_Orders);
		}

		public void AddToDG_RefundDetails(DG_RefundDetails dG_RefundDetails)
		{
			base.AddObject(DigiphotoEntities.(2243), dG_RefundDetails);
		}

		public void AddToDG_Actions_Type(DG_Actions_Type dG_Actions_Type)
		{
			base.AddObject(DigiphotoEntities.(2268), dG_Actions_Type);
		}

		public void AddToPhotoAlbumPrintOrder(PhotoAlbumPrintOrder photoAlbumPrintOrder)
		{
			base.AddObject(DigiphotoEntities.(2289), photoAlbumPrintOrder);
		}

		public void AddTovw_GetPrinterDetails(vw_GetPrinterDetails vw_GetPrinterDetails)
		{
			base.AddObject(DigiphotoEntities.(2318), vw_GetPrinterDetails);
		}

		public void AddTovw_GetPrinterQueue(vw_GetPrinterQueue vw_GetPrinterQueue)
		{
			base.AddObject(DigiphotoEntities.(2347), vw_GetPrinterQueue);
		}

		public void AddTovw_GetFilteredPrinterQueue(vw_GetFilteredPrinterQueue vw_GetFilteredPrinterQueue)
		{
			base.AddObject(DigiphotoEntities.(2372), vw_GetFilteredPrinterQueue);
		}

		public void AddTovw_GetPrinterQueueforPrint(vw_GetPrinterQueueforPrint vw_GetPrinterQueueforPrint)
		{
			base.AddObject(DigiphotoEntities.(2409), vw_GetPrinterQueueforPrint);
		}

		public void AddTovw_GetAllTable(vw_GetAllTable vw_GetAllTable)
		{
			base.AddObject(DigiphotoEntities.(2446), vw_GetAllTable);
		}

		public void AddToDG_Orders_ProductType(DG_Orders_ProductType dG_Orders_ProductType)
		{
			base.AddObject(DigiphotoEntities.(2467), dG_Orders_ProductType);
		}

		public void AddTovw_GetOrderDetails(vw_GetOrderDetails vw_GetOrderDetails)
		{
			base.AddObject(DigiphotoEntities.(2496), vw_GetOrderDetails);
		}

		public void AddTovw_GetConfigdata(vw_GetConfigdata vw_GetConfigdata)
		{
			base.AddObject(DigiphotoEntities.(2521), vw_GetConfigdata);
		}

		public void AddToDG_Configuration(DG_Configuration dG_Configuration)
		{
			base.AddObject(DigiphotoEntities.(2546), dG_Configuration);
		}

		public void AddToDG_Emails(DG_Emails dG_Emails)
		{
			base.AddObject(DigiphotoEntities.(2571), dG_Emails);
		}

		public void AddToClientApplicationVersions(ClientApplicationVersions clientApplicationVersions)
		{
			base.AddObject(DigiphotoEntities.(2584), clientApplicationVersions);
		}

		public void AddToiIMIXConfigurationMaster(iIMIXConfigurationMaster iIMIXConfigurationMaster)
		{
			base.AddObject(DigiphotoEntities.(2621), iIMIXConfigurationMaster);
		}

		public void AddToiMIXConfigurationValue(iMIXConfigurationValue iMIXConfigurationValue)
		{
			base.AddObject(DigiphotoEntities.(2654), iMIXConfigurationValue);
		}

		public void AddToBackupHistory(BackupHistory backupHistory)
		{
			base.AddObject(DigiphotoEntities.(2687), backupHistory);
		}

		public void AddToArchivedPhotos(ArchivedPhotos archivedPhotos)
		{
			base.AddObject(DigiphotoEntities.(2708), archivedPhotos);
		}

		public void AddToChangeTracking(ChangeTracking changeTracking)
		{
			base.AddObject(DigiphotoEntities.(2729), changeTracking);
		}

		public void AddToiMixCardRule(iMixCardRule iMixCardRule)
		{
			base.AddObject(DigiphotoEntities.(2750), iMixCardRule);
		}

		public void AddToiMixImageAssociation(iMixImageAssociation iMixImageAssociation)
		{
			base.AddObject(DigiphotoEntities.(2767), iMixImageAssociation);
		}

		public void AddToiMIXImageAssociationRule(iMIXImageAssociationRule iMIXImageAssociationRule)
		{
			base.AddObject(DigiphotoEntities.(2796), iMIXImageAssociationRule);
		}

		public void AddToErrorLog(ErrorLog errorLog)
		{
			base.AddObject(DigiphotoEntities.(2829), errorLog);
		}

		public void AddToiMixImageCardType(iMixImageCardType iMixImageCardType)
		{
			base.AddObject(DigiphotoEntities.(2842), iMixImageCardType);
		}

		public void AddToDG_SemiOrder_Settings(DG_SemiOrder_Settings dG_SemiOrder_Settings)
		{
			base.AddObject(DigiphotoEntities.(2867), dG_SemiOrder_Settings);
		}

		public void AddTovw_GetFilteredPrinterQueueForPrint(vw_GetFilteredPrinterQueueForPrint vw_GetFilteredPrinterQueueForPrint)
		{
			base.AddObject(DigiphotoEntities.(2896), vw_GetFilteredPrinterQueueForPrint);
		}

		public void AddTovw_GetProductTypeData(vw_GetProductTypeData vw_GetProductTypeData)
		{
			base.AddObject(DigiphotoEntities.(2945), vw_GetProductTypeData);
		}

		public void AddToDG_Orders_Details(DG_Orders_Details dG_Orders_Details)
		{
			base.AddObject(DigiphotoEntities.(2974), dG_Orders_Details);
		}

		public void AddToDG_Photos(DG_Photos dG_Photos)
		{
			base.AddObject(DigiphotoEntities.(2999), dG_Photos);
		}

		public void AddTovw_GetPhotographer(vw_GetPhotographer vw_GetPhotographer)
		{
			base.AddObject(DigiphotoEntities.(3012), vw_GetPhotographer);
		}

		public void AddTovw_TakingReport(vw_TakingReport vw_TakingReport)
		{
			base.AddObject(DigiphotoEntities.(3037), vw_TakingReport);
		}

		public void AddToDG_Store(DG_Store dG_Store)
		{
			base.AddObject(DigiphotoEntities.(3058), dG_Store);
		}

		public void AddTovw_GetListAvailableLocations(vw_GetListAvailableLocations vw_GetListAvailableLocations)
		{
			base.AddObject(DigiphotoEntities.(3071), vw_GetListAvailableLocations);
		}

		public ObjectResult<sp_GetActivityReport> GetActivityReports(DateTime? fromDate, DateTime? toDate, int? userId, bool? iSFromDate, bool? isToDate)
		{
			ObjectParameter objectParameter;
			if (fromDate.HasValue)
			{
				if (false)
				{
					goto IL_EA;
				}
				objectParameter = new ObjectParameter(DigiphotoEntities.(3112), fromDate);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3112), typeof(DateTime));
			}
			ObjectParameter objectParameter2;
			if (toDate.HasValue)
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3125), toDate);
			}
			else
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3125), typeof(DateTime));
			}
			ObjectParameter objectParameter3;
			if (userId.HasValue)
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3134), userId);
			}
			else
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3134), typeof(int));
			}
			ObjectParameter objectParameter4;
			if (!iSFromDate.HasValue)
			{
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(3143), typeof(bool));
				goto IL_127;
			}
			IL_EA:
			objectParameter4 = new ObjectParameter(DigiphotoEntities.(3143), iSFromDate);
			IL_127:
			ObjectParameter objectParameter5;
			if (isToDate.HasValue)
			{
				objectParameter5 = new ObjectParameter(DigiphotoEntities.(3160), isToDate);
			}
			else
			{
				objectParameter5 = new ObjectParameter(DigiphotoEntities.(3160), typeof(bool));
			}
			return base.ExecuteFunction<sp_GetActivityReport>(DigiphotoEntities.(3173), new ObjectParameter[]
			{
				objectParameter,
				objectParameter2,
				objectParameter3,
				objectParameter4,
				objectParameter5
			});
		}

		public ObjectResult<GetLastGeneratedNumber_Result> GetLastGeneratedNumber(int? userID)
		{
			ObjectParameter objectParameter;
			if (userID.HasValue)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3198), userID);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3198), typeof(int));
			}
			return base.ExecuteFunction<GetLastGeneratedNumber_Result>(DigiphotoEntities.(3207), new ObjectParameter[]
			{
				objectParameter
			});
		}

		public ObjectResult<GetRefundedItems_Result> GetRefundedItems(int? dG_OrderID)
		{
			ObjectParameter objectParameter;
			if (dG_OrderID.HasValue)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3240), dG_OrderID);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3240), typeof(int));
			}
			return base.ExecuteFunction<GetRefundedItems_Result>(DigiphotoEntities.(3257), new ObjectParameter[]
			{
				objectParameter
			});
		}

		public ObjectResult<GenerateBill_Result> GenerateBill_Result(string lineItems)
		{
			ObjectParameter objectParameter;
			if (lineItems != null)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3282), lineItems);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3282), typeof(string));
			}
			return base.ExecuteFunction<GenerateBill_Result>(DigiphotoEntities.(3295), new ObjectParameter[]
			{
				objectParameter
			});
		}

		public ObjectResult<GetPhotgrapherPerformance_Result> GetPhotgrapherPerformance_Method(DateTime? fromDate, DateTime? toDate, DateTime? secondFromDate, DateTime? secondToDate, string storeName, string userName, bool? comparasion)
		{
			ObjectParameter objectParameter;
			if (fromDate.HasValue)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3112), fromDate);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3112), typeof(DateTime));
			}
			ObjectParameter objectParameter2;
			if (toDate.HasValue)
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3125), toDate);
			}
			else
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3125), typeof(DateTime));
			}
			ObjectParameter objectParameter3;
			if (secondFromDate.HasValue)
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3324), secondFromDate);
			}
			else
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3324), typeof(DateTime));
			}
			ObjectParameter objectParameter4;
			if (secondToDate.HasValue)
			{
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(3345), secondToDate);
			}
			else
			{
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(3345), typeof(DateTime));
			}
			ObjectParameter objectParameter5;
			ObjectParameter objectParameter6;
			ObjectParameter objectParameter7;
			do
			{
				if (storeName != null)
				{
					objectParameter5 = new ObjectParameter(DigiphotoEntities.(3362), storeName);
				}
				else
				{
					objectParameter5 = new ObjectParameter(DigiphotoEntities.(3362), typeof(string));
				}
				if (userName != null)
				{
					objectParameter6 = new ObjectParameter(DigiphotoEntities.(3375), userName);
				}
				else
				{
					objectParameter6 = new ObjectParameter(DigiphotoEntities.(3375), typeof(string));
				}
				if (comparasion.HasValue)
				{
					objectParameter7 = new ObjectParameter(DigiphotoEntities.(3388), comparasion);
				}
				else
				{
					objectParameter7 = new ObjectParameter(DigiphotoEntities.(3388), typeof(bool));
				}
			}
			while (3 == 0);
			return base.ExecuteFunction<GetPhotgrapherPerformance_Result>(DigiphotoEntities.(3405), new ObjectParameter[]
			{
				objectParameter,
				objectParameter2,
				objectParameter3,
				objectParameter4,
				objectParameter5,
				objectParameter6,
				objectParameter7
			});
		}

		public ObjectResult<GetConnectionStatus_Result> GetConnectionStatus(string serverIP, string username, string password)
		{
			ObjectParameter objectParameter;
			if (serverIP != null)
			{
				if (false)
				{
					goto IL_BB;
				}
				ObjectParameter expr_11A = new ObjectParameter(DigiphotoEntities.(3450), serverIP);
				if (!false)
				{
					objectParameter = expr_11A;
				}
				if (8 == 0)
				{
					goto IL_B6;
				}
			}
			else
			{
				ObjectParameter expr_13E = new ObjectParameter(DigiphotoEntities.(3450), typeof(string));
				if (6 != 0)
				{
					objectParameter = expr_13E;
				}
			}
			if (username == null)
			{
				goto IL_7B;
			}
			IL_5D:
			if (-1 == 0)
			{
				goto IL_7B;
			}
			ObjectParameter objectParameter2 = new ObjectParameter(DigiphotoEntities.(3463), username);
			IL_76:
			if (!false)
			{
				goto IL_9A;
			}
			goto IL_9D;
			IL_7B:
			objectParameter2 = new ObjectParameter(DigiphotoEntities.(3463), typeof(string));
			IL_9A:
			if (password == null)
			{
				goto IL_BB;
			}
			IL_9D:
			if (!true)
			{
				goto IL_76;
			}
			ObjectParameter objectParameter3 = new ObjectParameter(DigiphotoEntities.(3476), password);
			IL_B6:
			if (!false)
			{
				goto IL_DA;
			}
			goto IL_5D;
			IL_BB:
			objectParameter3 = new ObjectParameter(DigiphotoEntities.(3476), typeof(string));
			IL_DA:
			return base.ExecuteFunction<GetConnectionStatus_Result>(DigiphotoEntities.(3489), new ObjectParameter[]
			{
				objectParameter,
				objectParameter2,
				objectParameter3
			});
		}

		public ObjectResult<SetDataToCentralServer_Result> SetDataToCentralServer(string servername, string username, string applicationId, string password, string storeName)
		{
			ObjectParameter objectParameter;
			ObjectParameter objectParameter2;
			ObjectParameter objectParameter3;
			ObjectParameter objectParameter4;
			ObjectParameter objectParameter5;
			while (true)
			{
				if (servername != null)
				{
					objectParameter = new ObjectParameter(DigiphotoEntities.(3518), servername);
				}
				else
				{
					objectParameter = new ObjectParameter(DigiphotoEntities.(3518), typeof(string));
				}
				IL_4A:
				if (!false && username != null)
				{
					objectParameter2 = new ObjectParameter(DigiphotoEntities.(3463), username);
				}
				else
				{
					objectParameter2 = new ObjectParameter(DigiphotoEntities.(3463), typeof(string));
				}
				if (applicationId != null)
				{
					goto IL_8A;
				}
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3535), typeof(string));
				IL_C1:
				if (password == null)
				{
					goto IL_DE;
				}
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(3476), password);
				IL_FD:
				if (!false)
				{
					if (false)
					{
						goto IL_8A;
					}
					if (storeName == null)
					{
						if (!false)
						{
							objectParameter5 = new ObjectParameter(DigiphotoEntities.(3362), typeof(string));
							goto IL_14D;
						}
						goto IL_DE;
					}
				}
				objectParameter5 = new ObjectParameter(DigiphotoEntities.(3362), storeName);
				if (6 == 0)
				{
					continue;
				}
				IL_14D:
				if (!false)
				{
					break;
				}
				goto IL_25;
				IL_DE:
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(3476), typeof(string));
				goto IL_FD;
				IL_8A:
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3535), applicationId);
				goto IL_C1;
				IL_25:
				goto IL_4A;
			}
			return base.ExecuteFunction<SetDataToCentralServer_Result>(DigiphotoEntities.(3556), new ObjectParameter[]
			{
				objectParameter,
				objectParameter2,
				objectParameter3,
				objectParameter4,
				objectParameter5
			});
		}

		public ObjectResult<GetPrinterQueueDetails_Result> GetPrinterQueueDetails(int? queueID)
		{
			ObjectParameter objectParameter;
			if (queueID.HasValue)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3589), queueID);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3589), typeof(int));
			}
			return base.ExecuteFunction<GetPrinterQueueDetails_Result>(DigiphotoEntities.(3602), new ObjectParameter[]
			{
				objectParameter
			});
		}

		public ObjectResult<GetLocationPerformance_Result> GetLocationPerformance(DateTime? fromDate, DateTime? toDate, DateTime? secondFromDate, DateTime? secondToDate, string storeName, string userName, bool? comparasion)
		{
			ObjectParameter objectParameter;
			if (fromDate.HasValue)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3112), fromDate);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3112), typeof(DateTime));
			}
			ObjectParameter objectParameter2;
			if (toDate.HasValue)
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3125), toDate);
			}
			else
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3125), typeof(DateTime));
			}
			ObjectParameter objectParameter3;
			if (secondFromDate.HasValue)
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3324), secondFromDate);
			}
			else
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3324), typeof(DateTime));
			}
			ObjectParameter objectParameter4;
			if (secondToDate.HasValue)
			{
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(3345), secondToDate);
			}
			else
			{
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(3345), typeof(DateTime));
			}
			ObjectParameter objectParameter5;
			ObjectParameter objectParameter6;
			ObjectParameter objectParameter7;
			do
			{
				if (storeName != null)
				{
					objectParameter5 = new ObjectParameter(DigiphotoEntities.(3362), storeName);
				}
				else
				{
					objectParameter5 = new ObjectParameter(DigiphotoEntities.(3362), typeof(string));
				}
				if (userName != null)
				{
					objectParameter6 = new ObjectParameter(DigiphotoEntities.(3375), userName);
				}
				else
				{
					objectParameter6 = new ObjectParameter(DigiphotoEntities.(3375), typeof(string));
				}
				if (comparasion.HasValue)
				{
					objectParameter7 = new ObjectParameter(DigiphotoEntities.(3388), comparasion);
				}
				else
				{
					objectParameter7 = new ObjectParameter(DigiphotoEntities.(3388), typeof(bool));
				}
			}
			while (3 == 0);
			return base.ExecuteFunction<GetLocationPerformance_Result>(DigiphotoEntities.(3635), new ObjectParameter[]
			{
				objectParameter,
				objectParameter2,
				objectParameter3,
				objectParameter4,
				objectParameter5,
				objectParameter6,
				objectParameter7
			});
		}

		public ObjectResult<PrintSummary_Result> PrintSummary(DateTime? fromdate, DateTime? todate, string subStore)
		{
			ObjectParameter objectParameter;
			if (fromdate.HasValue)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3668), fromdate);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3668), typeof(DateTime));
			}
			IL_2C:
			ObjectParameter objectParameter2;
			if (todate.HasValue)
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3681), todate);
				if (!false)
				{
					goto IL_99;
				}
			}
			objectParameter2 = new ObjectParameter(DigiphotoEntities.(3681), typeof(DateTime));
			IL_99:
			ObjectParameter objectParameter3;
			if (subStore != null)
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3690), subStore);
			}
			else
			{
				if (false)
				{
					goto IL_2C;
				}
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3690), typeof(string));
			}
			return base.ExecuteFunction<PrintSummary_Result>(DigiphotoEntities.(3703), new ObjectParameter[]
			{
				objectParameter,
				objectParameter2,
				objectParameter3
			});
		}

		public ObjectResult<OrderDetailedDiscount_Get_Result> OrderDetailedDiscount_Get(DateTime? fromDate, DateTime? toDate, string userName, string storeName)
		{
			bool arg_5B_0;
			bool expr_146 = arg_5B_0 = fromDate.HasValue;
			ObjectParameter objectParameter;
			if (8 != 0)
			{
				if (expr_146)
				{
					objectParameter = new ObjectParameter(DigiphotoEntities.(3112), fromDate);
				}
				else
				{
					objectParameter = new ObjectParameter(DigiphotoEntities.(3112), typeof(DateTime));
				}
				arg_5B_0 = toDate.HasValue;
			}
			ObjectParameter objectParameter2;
			if (arg_5B_0)
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3125), toDate);
			}
			else
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3125), typeof(DateTime));
			}
			ObjectParameter objectParameter3;
			if (userName != null)
			{
				do
				{
					objectParameter3 = new ObjectParameter(DigiphotoEntities.(3375), userName);
				}
				while (6 == 0);
			}
			else
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3375), typeof(string));
			}
			ObjectParameter objectParameter4;
			if (storeName != null)
			{
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(3362), storeName);
			}
			else
			{
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(3362), typeof(string));
			}
			return base.ExecuteFunction<OrderDetailedDiscount_Get_Result>(DigiphotoEntities.(3720), new ObjectParameter[]
			{
				objectParameter,
				objectParameter2,
				objectParameter3,
				objectParameter4
			});
		}

		public ObjectResult<GetPrintedProduct_Result> PrintedProduct(DateTime? fromdate, DateTime? todate, string subStoreName)
		{
			ObjectParameter objectParameter;
			if (fromdate.HasValue)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3668), fromdate);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3668), typeof(DateTime));
			}
			IL_2C:
			ObjectParameter objectParameter2;
			if (todate.HasValue)
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3681), todate);
				if (!false)
				{
					goto IL_99;
				}
			}
			objectParameter2 = new ObjectParameter(DigiphotoEntities.(3681), typeof(DateTime));
			IL_99:
			ObjectParameter objectParameter3;
			if (subStoreName != null)
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3757), subStoreName);
			}
			else
			{
				if (false)
				{
					goto IL_2C;
				}
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3757), typeof(string));
			}
			return base.ExecuteFunction<GetPrintedProduct_Result>(DigiphotoEntities.(3774), new ObjectParameter[]
			{
				objectParameter,
				objectParameter2,
				objectParameter3
			});
		}

		public ObjectResult<FinancialAuditTrail_Result> FinancialAuditTrail(string userName, string storeName, DateTime? startDate, DateTime? endDate)
		{
			ObjectParameter objectParameter;
			if (userName != null)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3375), userName);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3375), typeof(string));
			}
			ObjectParameter objectParameter2;
			if (storeName != null)
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3362), storeName);
			}
			else
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3362), typeof(string));
			}
			ObjectParameter objectParameter3;
			if (startDate.HasValue)
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3795), startDate);
			}
			else
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3795), typeof(DateTime));
			}
			ObjectParameter objectParameter4;
			if (endDate.HasValue)
			{
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(3808), endDate);
			}
			else
			{
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(3808), typeof(DateTime));
			}
			return base.ExecuteFunction<FinancialAuditTrail_Result>(DigiphotoEntities.(3821), new ObjectParameter[]
			{
				objectParameter,
				objectParameter2,
				objectParameter3,
				objectParameter4
			});
		}

		public ObjectResult<ProductSummary_Result> ProductSummary(DateTime? toDate, DateTime? fROMDate, string userName, string storeName)
		{
			bool arg_5B_0;
			bool expr_146 = arg_5B_0 = toDate.HasValue;
			ObjectParameter objectParameter;
			if (8 != 0)
			{
				if (expr_146)
				{
					objectParameter = new ObjectParameter(DigiphotoEntities.(3125), toDate);
				}
				else
				{
					objectParameter = new ObjectParameter(DigiphotoEntities.(3125), typeof(DateTime));
				}
				arg_5B_0 = fROMDate.HasValue;
			}
			ObjectParameter objectParameter2;
			if (arg_5B_0)
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3850), fROMDate);
			}
			else
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3850), typeof(DateTime));
			}
			ObjectParameter objectParameter3;
			if (userName != null)
			{
				do
				{
					objectParameter3 = new ObjectParameter(DigiphotoEntities.(3375), userName);
				}
				while (6 == 0);
			}
			else
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3375), typeof(string));
			}
			ObjectParameter objectParameter4;
			if (storeName != null)
			{
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(3362), storeName);
			}
			else
			{
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(3362), typeof(string));
			}
			return base.ExecuteFunction<ProductSummary_Result>(DigiphotoEntities.(3863), new ObjectParameter[]
			{
				objectParameter,
				objectParameter2,
				objectParameter3,
				objectParameter4
			});
		}

		public ObjectResult<OperationalAudit_Result> OperationalAudit(DateTime? fromDate, DateTime? toDate)
		{
			ObjectParameter objectParameter;
			if (fromDate.HasValue)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3112), fromDate);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3112), typeof(DateTime));
			}
			ObjectParameter objectParameter2;
			if (toDate.HasValue)
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3125), toDate);
			}
			else
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3125), typeof(DateTime));
			}
			return base.ExecuteFunction<OperationalAudit_Result>(DigiphotoEntities.(3884), new ObjectParameter[]
			{
				objectParameter,
				objectParameter2
			});
		}

		public ObjectResult<OperatorPerformanceReport_Result> OperatorPerformanceReport(DateTime? fromDate, DateTime? toDate, DateTime? secondFromDate, DateTime? secondToDate, int? currencyId, string storeName, string userName, bool? comparasion)
		{
			ObjectParameter objectParameter;
			if (fromDate.HasValue)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3112), fromDate);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3112), typeof(DateTime));
			}
			ObjectParameter objectParameter2;
			if (toDate.HasValue)
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3125), toDate);
				if (3 == 0)
				{
					goto IL_ED;
				}
			}
			else
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3125), typeof(DateTime));
			}
			ObjectParameter objectParameter3;
			if (secondFromDate.HasValue)
			{
				if (false)
				{
					goto IL_239;
				}
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3324), secondFromDate);
			}
			else
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3324), typeof(DateTime));
			}
			ObjectParameter objectParameter4;
			if (!secondToDate.HasValue)
			{
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(3345), typeof(DateTime));
				goto IL_12A;
			}
			IL_ED:
			objectParameter4 = new ObjectParameter(DigiphotoEntities.(3345), secondToDate);
			IL_12A:
			ObjectParameter objectParameter5;
			if (currencyId.HasValue)
			{
				objectParameter5 = new ObjectParameter(DigiphotoEntities.(3909), currencyId);
				if (false)
				{
					goto IL_1B3;
				}
			}
			else
			{
				objectParameter5 = new ObjectParameter(DigiphotoEntities.(3909), typeof(int));
			}
			ObjectParameter objectParameter6;
			if (storeName != null)
			{
				objectParameter6 = new ObjectParameter(DigiphotoEntities.(3362), storeName);
			}
			else
			{
				objectParameter6 = new ObjectParameter(DigiphotoEntities.(3362), typeof(string));
			}
			IL_1B3:
			ObjectParameter objectParameter7;
			if (userName != null)
			{
				objectParameter7 = new ObjectParameter(DigiphotoEntities.(3375), userName);
			}
			else
			{
				objectParameter7 = new ObjectParameter(DigiphotoEntities.(3375), typeof(string));
			}
			ObjectParameter objectParameter8;
			if (comparasion.HasValue)
			{
				objectParameter8 = new ObjectParameter(DigiphotoEntities.(3388), comparasion);
			}
			else
			{
				objectParameter8 = new ObjectParameter(DigiphotoEntities.(3388), typeof(bool));
			}
			IL_239:
			return base.ExecuteFunction<OperatorPerformanceReport_Result>(DigiphotoEntities.(3926), new ObjectParameter[]
			{
				objectParameter,
				objectParameter2,
				objectParameter3,
				objectParameter4,
				objectParameter5,
				objectParameter6,
				objectParameter7,
				objectParameter8
			});
		}

		public ObjectResult<DG_Photos> GetPhotoDataByPage(int? startIndex, int? pageSize, int? subStoreId, bool? newRecord, ObjectParameter lastKeyIndex)
		{
			ObjectParameter objectParameter;
			if (startIndex.HasValue)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3963), startIndex);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3963), typeof(int));
			}
			ObjectParameter objectParameter2;
			if (pageSize.HasValue)
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3980), pageSize);
			}
			else
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3980), typeof(int));
			}
			ObjectParameter objectParameter3;
			if (subStoreId.HasValue)
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3993), subStoreId);
			}
			else
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3993), typeof(int));
			}
			ObjectParameter objectParameter4;
			if (newRecord.HasValue)
			{
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(4010), newRecord);
			}
			else
			{
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(4010), typeof(bool));
			}
			return base.ExecuteFunction<DG_Photos>(DigiphotoEntities.(4023), new ObjectParameter[]
			{
				objectParameter,
				objectParameter2,
				objectParameter3,
				objectParameter4,
				lastKeyIndex
			});
		}

		public ObjectResult<DG_Photos> GetPhotoDataByPage(int? startIndex, int? pageSize, int? subStoreId, bool? newRecord, ObjectParameter lastKeyIndex, MergeOption mergeOption)
		{
			ObjectParameter objectParameter;
			if (startIndex.HasValue)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3963), startIndex);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3963), typeof(int));
			}
			ObjectParameter objectParameter2;
			if (pageSize.HasValue)
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3980), pageSize);
			}
			else
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3980), typeof(int));
			}
			ObjectParameter objectParameter3;
			if (subStoreId.HasValue)
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3993), subStoreId);
			}
			else
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(3993), typeof(int));
			}
			ObjectParameter objectParameter4;
			if (newRecord.HasValue)
			{
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(4010), newRecord);
			}
			else
			{
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(4010), typeof(bool));
			}
			return base.ExecuteFunction<DG_Photos>(DigiphotoEntities.(4023), mergeOption, new ObjectParameter[]
			{
				objectParameter,
				objectParameter2,
				objectParameter3,
				objectParameter4,
				lastKeyIndex
			});
		}

		public int UpdatePostedOrder(string orderNumber, int? status)
		{
			if (orderNumber == null)
			{
				goto IL_27;
			}
			ObjectParameter objectParameter = new ObjectParameter(DigiphotoEntities.(4048), orderNumber);
			ObjectParameter objectParameter2;
			while (true)
			{
				IL_4A:
				if (!status.HasValue)
				{
					if (!false)
					{
						objectParameter2 = new ObjectParameter(DigiphotoEntities.(4065), typeof(int));
						goto IL_95;
					}
					goto IL_27;
				}
				IL_53:
				if (false)
				{
					continue;
				}
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(4065), status);
				IL_95:
				if (!false)
				{
					break;
				}
				goto IL_53;
			}
			return base.ExecuteFunction(DigiphotoEntities.(4074), new ObjectParameter[]
			{
				objectParameter,
				objectParameter2
			});
			IL_27:
			objectParameter = new ObjectParameter(DigiphotoEntities.(4048), typeof(string));
			goto IL_4A;
		}

		public ObjectResult<GetPrinterQueueDetailsByOrderNo_Result> GetPrinterQueueDetailsByOrderNo(string orderNumber)
		{
			ObjectParameter objectParameter;
			if (orderNumber != null)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4048), orderNumber);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4048), typeof(string));
			}
			return base.ExecuteFunction<GetPrinterQueueDetailsByOrderNo_Result>(DigiphotoEntities.(4099), new ObjectParameter[]
			{
				objectParameter
			});
		}

		public ObjectResult<GetPhotoToUpload_Result> GetPhotoToUpload()
		{
			return base.ExecuteFunction<GetPhotoToUpload_Result>(DigiphotoEntities.(4144), new ObjectParameter[0]);
		}

		public ObjectResult<int?> uspImportBackGround(string backGroundDataXML)
		{
			ObjectParameter objectParameter;
			if (backGroundDataXML != null)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4169), backGroundDataXML);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4169), typeof(string));
			}
			return base.ExecuteFunction<int?>(DigiphotoEntities.(4194), new ObjectParameter[]
			{
				objectParameter
			});
		}

		public ObjectResult<int?> uspImportBorders(string borderDataXML)
		{
			ObjectParameter objectParameter;
			if (borderDataXML != null)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4223), borderDataXML);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4223), typeof(string));
			}
			return base.ExecuteFunction<int?>(DigiphotoEntities.(4244), new ObjectParameter[]
			{
				objectParameter
			});
		}

		public ObjectResult<int?> uspImportCameraDetails(string cameraDetailsDataXML)
		{
			ObjectParameter objectParameter;
			if (cameraDetailsDataXML != null)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4269), cameraDetailsDataXML);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4269), typeof(string));
			}
			return base.ExecuteFunction<int?>(DigiphotoEntities.(4298), new ObjectParameter[]
			{
				objectParameter
			});
		}

		public ObjectResult<int?> uspImportGraphics(string graphicsDataXML)
		{
			ObjectParameter objectParameter;
			if (graphicsDataXML != null)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4331), graphicsDataXML);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4331), typeof(string));
			}
			return base.ExecuteFunction<int?>(DigiphotoEntities.(4352), new ObjectParameter[]
			{
				objectParameter
			});
		}

		public ObjectResult<int?> uspImportPackageDetails(string packageDetailsDataXML)
		{
			ObjectParameter objectParameter;
			if (packageDetailsDataXML != null)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4377), packageDetailsDataXML);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4377), typeof(string));
			}
			return base.ExecuteFunction<int?>(DigiphotoEntities.(4406), new ObjectParameter[]
			{
				objectParameter
			});
		}

		public ObjectResult<int?> uspImportProductPricing(string productPricingDataXML)
		{
			ObjectParameter objectParameter;
			if (productPricingDataXML != null)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4439), productPricingDataXML);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4439), typeof(string));
			}
			return base.ExecuteFunction<int?>(DigiphotoEntities.(4468), new ObjectParameter[]
			{
				objectParameter
			});
		}

		public ObjectResult<int?> uspImportProducts(string productsDataXML)
		{
			ObjectParameter objectParameter;
			if (productsDataXML != null)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4501), productsDataXML);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4501), typeof(string));
			}
			return base.ExecuteFunction<int?>(DigiphotoEntities.(4522), new ObjectParameter[]
			{
				objectParameter
			});
		}

		public ObjectResult<int?> uspImportRolePermissions(string rolePermissionsDataXML)
		{
			ObjectParameter objectParameter;
			if (rolePermissionsDataXML != null)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4547), rolePermissionsDataXML);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4547), typeof(string));
			}
			return base.ExecuteFunction<int?>(DigiphotoEntities.(4580), new ObjectParameter[]
			{
				objectParameter
			});
		}

		public ObjectResult<int?> uspImportUserRoles(string userRolesDataXML)
		{
			ObjectParameter objectParameter;
			if (userRolesDataXML != null)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4613), userRolesDataXML);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4613), typeof(string));
			}
			return base.ExecuteFunction<int?>(DigiphotoEntities.(4638), new ObjectParameter[]
			{
				objectParameter
			});
		}

		public ObjectResult<int?> uspImportUsers(string usersDataXML)
		{
			ObjectParameter objectParameter;
			if (usersDataXML != null)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4663), usersDataXML);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4663), typeof(string));
			}
			return base.ExecuteFunction<int?>(DigiphotoEntities.(4680), new ObjectParameter[]
			{
				objectParameter
			});
		}

		public ObjectResult<uspCheckUpdates_Result> uspCheckUpdates(string version)
		{
			ObjectParameter objectParameter;
			if (version != null)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4701), version);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4701), typeof(string));
			}
			return base.ExecuteFunction<uspCheckUpdates_Result>(DigiphotoEntities.(4714), new ObjectParameter[]
			{
				objectParameter
			});
		}

		public int RestoreDataBase(string dataBaseName, string backupPath)
		{
			ObjectParameter objectParameter;
			if (2 != 0)
			{
				if (dataBaseName != null)
				{
					objectParameter = new ObjectParameter(DigiphotoEntities.(4735), dataBaseName);
					if (false)
					{
						goto IL_69;
					}
				}
				else
				{
					objectParameter = new ObjectParameter(DigiphotoEntities.(4735), typeof(string));
				}
			}
			ObjectParameter objectParameter2;
			if (backupPath == null)
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(4752), typeof(string));
				goto IL_8D;
			}
			IL_53:
			objectParameter2 = new ObjectParameter(DigiphotoEntities.(4752), backupPath);
			IL_69:
			if (false)
			{
				goto IL_53;
			}
			IL_8D:
			return base.ExecuteFunction(DigiphotoEntities.(4769), new ObjectParameter[]
			{
				objectParameter,
				objectParameter2
			});
		}

		public int AddMissingColumnsInOldDB()
		{
			return base.ExecuteFunction(DigiphotoEntities.(4790), new ObjectParameter[0]);
		}

		public ObjectResult<string> uspImportTablesFromOldDBToNew(ObjectParameter log)
		{
			return base.ExecuteFunction<string>(DigiphotoEntities.(4823), new ObjectParameter[]
			{
				log
			});
		}

		public ObjectResult<GetImagesBYQRCode_Result> GetImagesBYQRCode(string qRCode, bool? isAnonymousQrCodeEnabled)
		{
			if (qRCode == null)
			{
				goto IL_27;
			}
			ObjectParameter objectParameter = new ObjectParameter(DigiphotoEntities.(4864), qRCode);
			ObjectParameter objectParameter2;
			while (true)
			{
				IL_4A:
				if (!isAnonymousQrCodeEnabled.HasValue)
				{
					if (!false)
					{
						objectParameter2 = new ObjectParameter(DigiphotoEntities.(4873), typeof(bool));
						goto IL_95;
					}
					goto IL_27;
				}
				IL_53:
				if (false)
				{
					continue;
				}
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(4873), isAnonymousQrCodeEnabled);
				IL_95:
				if (!false)
				{
					break;
				}
				goto IL_53;
			}
			return base.ExecuteFunction<GetImagesBYQRCode_Result>(DigiphotoEntities.(4906), new ObjectParameter[]
			{
				objectParameter,
				objectParameter2
			});
			IL_27:
			objectParameter = new ObjectParameter(DigiphotoEntities.(4864), typeof(string));
			goto IL_4A;
		}

		public ObjectResult<OrderDetailedSyncStaus_Result> OrderDetailedSyncStaus(DateTime? fromDate, DateTime? toDate)
		{
			ObjectParameter objectParameter;
			if (fromDate.HasValue)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3112), fromDate);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(3112), typeof(DateTime));
			}
			ObjectParameter objectParameter2;
			if (toDate.HasValue)
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3125), toDate);
			}
			else
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(3125), typeof(DateTime));
			}
			return base.ExecuteFunction<OrderDetailedSyncStaus_Result>(DigiphotoEntities.(4931), new ObjectParameter[]
			{
				objectParameter,
				objectParameter2
			});
		}

		public int AssociateImage(string uniqueCode, string photoIds, int? overWriteStatus, bool? isAnonymousQrCodeEnabled, ObjectParameter result)
		{
			ObjectParameter objectParameter;
			if (uniqueCode != null)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4964), uniqueCode);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(4964), typeof(string));
			}
			ObjectParameter objectParameter2;
			if (photoIds != null)
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(4981), photoIds);
			}
			else
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(4981), typeof(string));
			}
			ObjectParameter objectParameter3;
			if (overWriteStatus.HasValue)
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(4994), overWriteStatus);
			}
			else
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(4994), typeof(int));
			}
			ObjectParameter objectParameter4;
			if (isAnonymousQrCodeEnabled.HasValue)
			{
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(4873), isAnonymousQrCodeEnabled);
			}
			else
			{
				objectParameter4 = new ObjectParameter(DigiphotoEntities.(4873), typeof(bool));
			}
			return base.ExecuteFunction(DigiphotoEntities.(5015), new ObjectParameter[]
			{
				objectParameter,
				objectParameter2,
				objectParameter3,
				objectParameter4,
				result
			});
		}

		public ObjectResult<string> GetQrOrBarCodeByPhotoID(string photoId)
		{
			ObjectParameter objectParameter;
			if (photoId != null)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(5036), photoId);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(5036), typeof(string));
			}
			return base.ExecuteFunction<string>(DigiphotoEntities.(5049), new ObjectParameter[]
			{
				objectParameter
			});
		}

		public ObjectResult<GetLocationSubstoreWise_Result> GetLocationSubstoreWise(int? substoreId)
		{
			ObjectParameter objectParameter;
			if (substoreId.HasValue)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(5082), substoreId);
			}
			else
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(5082), typeof(int));
			}
			return base.ExecuteFunction<GetLocationSubstoreWise_Result>(DigiphotoEntities.(5099), new ObjectParameter[]
			{
				objectParameter
			});
		}

		public ObjectResult<DG_Photos> GetAllPhotosforSearch(string substoreIds, long? imgRfid, int? noOfImg)
		{
			ObjectParameter objectParameter;
			if (substoreIds != null)
			{
				objectParameter = new ObjectParameter(DigiphotoEntities.(5132), substoreIds);
			}
			else
			{
				if (2 == 0)
				{
					goto IL_75;
				}
				ObjectParameter expr_143 = new ObjectParameter(DigiphotoEntities.(5132), typeof(string));
				if (7 != 0)
				{
					objectParameter = expr_143;
				}
			}
			bool arg_56_0 = imgRfid.HasValue;
			IL_56:
			ObjectParameter objectParameter2;
			if (arg_56_0)
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(5149), imgRfid);
				goto IL_94;
			}
			IL_75:
			objectParameter2 = new ObjectParameter(DigiphotoEntities.(5149), typeof(long));
			IL_94:
			bool expr_96 = arg_56_0 = noOfImg.HasValue;
			if (2 != 0)
			{
				ObjectParameter objectParameter3;
				if (expr_96)
				{
					if (2 != 0)
					{
						objectParameter3 = new ObjectParameter(DigiphotoEntities.(5162), noOfImg);
					}
				}
				else
				{
					objectParameter3 = new ObjectParameter(DigiphotoEntities.(5162), typeof(int));
				}
				return base.ExecuteFunction<DG_Photos>(DigiphotoEntities.(5175), new ObjectParameter[]
				{
					objectParameter,
					objectParameter2,
					objectParameter3
				});
			}
			goto IL_56;
		}

		public ObjectResult<DG_Photos> GetAllPhotosforSearch(string substoreIds, long? imgRfid, int? noOfImg, MergeOption mergeOption)
		{
			ObjectParameter objectParameter;
			if (substoreIds != null)
			{
				ObjectParameter expr_11A = new ObjectParameter(DigiphotoEntities.(5132), substoreIds);
				if (4 != 0)
				{
					objectParameter = expr_11A;
				}
			}
			else
			{
				ObjectParameter expr_13E = new ObjectParameter(DigiphotoEntities.(5132), typeof(string));
				if (8 != 0)
				{
					objectParameter = expr_13E;
				}
			}
			ObjectParameter objectParameter2;
			if (imgRfid.HasValue)
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(5149), imgRfid);
			}
			else
			{
				objectParameter2 = new ObjectParameter(DigiphotoEntities.(5149), typeof(long));
			}
			ObjectParameter objectParameter3;
			if (noOfImg.HasValue)
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(5162), noOfImg);
			}
			else
			{
				objectParameter3 = new ObjectParameter(DigiphotoEntities.(5162), typeof(int));
			}
			return base.ExecuteFunction<DG_Photos>(DigiphotoEntities.(5175), mergeOption, new ObjectParameter[]
			{
				objectParameter,
				objectParameter2,
				objectParameter3
			});
		}

		static DigiphotoEntities()
		{
			// Note: this type is marked as 'beforefieldinit'.
			Strings.CreateGetStringDelegate(typeof(DigiphotoEntities));
		}


        }
    }
