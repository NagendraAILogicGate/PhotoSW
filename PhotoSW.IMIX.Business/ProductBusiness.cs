using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.BAL;

namespace PhotoSW.IMIX.Business
{
    public class ProductBusiness
    {
        public bool BulkSaveProduct(DataTable productDataTable, int createdBy, int storeId)
        {

            return false;
        }
        public bool CheckIsVisibleProductForBackGround(int BGID, int ProductID)
        {
            return false;
        }
        public bool DeleteProductType(int ProductTypeId)
        {
            return false;
        }
        public List<PhotoSW.IMIX.Model.GroupInfo> GetGroupList()
        {
            try
            {
                var obj = baGroupInfo.GetGroupInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.GroupInfo()
                    {
                        GroupID = p.GroupID,
                        GroupName = p.GroupName
                    }).ToList();
                return obj;
            }
            catch
            {
                return new List<PhotoSW.IMIX.Model.GroupInfo>();
            }

            //  return new List<PhotoSW.IMIX.Model.GroupInfo>();
        }
        public List<PhotoSW.IMIX.Model.PackageDetailsViewInfo> GetPackagDetails(int PackageId)
        {
            try
            {
                var obj = baPackageDetailsViewInfo.GetPackageDetailsViewInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.PackageDetailsViewInfo()
                    {
                        DG_Package_Details_Pkey = p.PS_Package_Details_Pkey,
                        DG_ProductTypeId = p.PS_ProductTypeId,
                        DG_PackageId = p.PS_PackageId,
                        DG_Product_Quantity = p.PS_Product_Quantity,
                        DG_Orders_ProductType_pkey = p.PS_Orders_ProductType_pkey,
                        DG_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        DG_Product_MaxImage = p.PS_Product_MaxImage,
                        DG_Orders_ProductType_IsBundled = p.PS_Orders_ProductType_IsBundled,
                        DG_IsAccessory = p.PS_IsAccessory,
                        DG_IsActive = p.PS_IsActive,
                        DG_Video_Length = p.PS_Video_Length
                    }).ToList();
                return obj;
            }
            catch
            {
                return new List<PhotoSW.IMIX.Model.PackageDetailsViewInfo>();
            }
            //return new List<PhotoSW.IMIX.Model.PackageDetailsViewInfo>();
        }
        public List<PhotoSW.IMIX.Model.ProductTypeInfo> GetPackageNames(bool IsPackage)
        {
            try
            {
                var obj = baProductTypeInfo.GetProductTypeInfoData()
                    .Where(p => p.PS_IsPackage == IsPackage)
                    .Select(p => new PhotoSW.IMIX.Model.ProductTypeInfo
                    {
                       //Id = p.Id,

                       DG_Orders_ProductType_pkey = p.Id,
                        DG_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        DG_Orders_ProductType_Desc = p.PS_Orders_ProductType_Desc,
                        DG_Orders_ProductType_IsBundled = p.PS_Orders_ProductType_IsBundled,
                        DG_Orders_ProductType_DiscountApplied = p.PS_Orders_ProductType_DiscountApplied,
                        DG_Orders_ProductType_Image = p.PS_Orders_ProductType_Image,
                        DG_IsPackage = p.PS_IsPackage,
                        DG_MaxQuantity = p.PS_MaxQuantity,
                        DG_Orders_ProductType_Active = p.PS_Orders_ProductType_Active,
                        DG_IsActive = p.PS_IsActive,
                        DG_IsAccessory = p.PS_IsAccessory,
                        DG_IsTaxEnabled = p.PS_IsTaxEnabled,
                        DG_IsPrimary = p.PS_IsPrimary,
                        DG_Orders_ProductCode = p.PS_Orders_ProductCode,
                        DG_Orders_ProductNumber = p.PS_Orders_ProductNumber,
                        DG_IsBorder = p.PS_IsBorder,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_Product_Pricing_ProductPrice = p.PS_Product_Pricing_ProductPrice,
                        DG_Product_Pricing_Currency_ID = p.PS_Product_Pricing_Currency_ID,
                        Itemcount = p.Itemcount,
                        IsPrintType = p.IsPrintType,
                        IsChecked = p.IsChecked,
                        DG_IsWaterMarkIncluded = p.PS_IsWaterMarkIncluded,
                        DG_SubStore_pkey = p.PS_SubStore_pkey,

                       //IsActive = p.IsActive
                   }).ToList();
                return obj;
            }
            catch
            {
                return new List<Model.ProductTypeInfo>();
            }
        }
        public List<PhotoSW.IMIX.Model.ProductTypeInfo> GetPackageType()
        {
            try
            {
                var obj = baProductTypeInfo.GetProductTypeInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.ProductTypeInfo
                    {
                       //Id = p.Id,
                       DG_Orders_ProductType_pkey = p.Id,
                        DG_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        DG_Orders_ProductType_Desc = p.PS_Orders_ProductType_Desc,
                        DG_Orders_ProductType_IsBundled = p.PS_Orders_ProductType_IsBundled,
                        DG_Orders_ProductType_DiscountApplied = p.PS_Orders_ProductType_DiscountApplied,
                        DG_Orders_ProductType_Image = p.PS_Orders_ProductType_Image,
                        DG_IsPackage = p.PS_IsPackage,
                        DG_MaxQuantity = p.PS_MaxQuantity,
                        DG_Orders_ProductType_Active = p.PS_Orders_ProductType_Active,
                        DG_IsActive = p.PS_IsActive,
                        DG_IsAccessory = p.PS_IsAccessory,
                        DG_IsTaxEnabled = p.PS_IsTaxEnabled,
                        DG_IsPrimary = p.PS_IsPrimary,
                        DG_Orders_ProductCode = p.PS_Orders_ProductCode,
                        DG_Orders_ProductNumber = p.PS_Orders_ProductNumber,
                        DG_IsBorder = p.PS_IsBorder,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_Product_Pricing_ProductPrice = p.PS_Product_Pricing_ProductPrice,
                        DG_Product_Pricing_Currency_ID = p.PS_Product_Pricing_Currency_ID,
                        Itemcount = p.Itemcount,
                        IsPrintType = p.IsPrintType,
                        IsChecked = p.IsChecked,
                        DG_IsWaterMarkIncluded = p.PS_IsWaterMarkIncluded,
                        DG_SubStore_pkey = p.PS_SubStore_pkey,
                       //IsActive = p.IsActive
                   }).ToList();
                return obj;
            }
            catch
            {
                return new List<Model.ProductTypeInfo>();
            }
        }
        public PhotoSW.IMIX.Model.ProductTypeInfo GetProductByID(int productid)
        {
            try
            {
                var obj = baProductTypeInfo.GetProductTypeInfoData()
                    .Where(p => p.Id == productid)
                    .Select(p => new PhotoSW.IMIX.Model.ProductTypeInfo
                    {
                       //Id = p.Id,

                       DG_Orders_ProductType_pkey = p.Id,
                        DG_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        DG_Orders_ProductType_Desc = p.PS_Orders_ProductType_Desc,
                        DG_Orders_ProductType_IsBundled = p.PS_Orders_ProductType_IsBundled,
                        DG_Orders_ProductType_DiscountApplied = p.PS_Orders_ProductType_DiscountApplied,
                        DG_Orders_ProductType_Image = p.PS_Orders_ProductType_Image,
                        DG_IsPackage = p.PS_IsPackage,
                        DG_MaxQuantity = p.PS_MaxQuantity,
                        DG_Orders_ProductType_Active = p.PS_Orders_ProductType_Active,
                        DG_IsActive = p.PS_IsActive,
                        DG_IsAccessory = p.PS_IsAccessory,
                        DG_IsTaxEnabled = p.PS_IsTaxEnabled,
                        DG_IsPrimary = p.PS_IsPrimary,
                        DG_Orders_ProductCode = p.PS_Orders_ProductCode,
                        DG_Orders_ProductNumber = p.PS_Orders_ProductNumber,
                        DG_IsBorder = p.PS_IsBorder,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_Product_Pricing_ProductPrice = p.PS_Product_Pricing_ProductPrice,
                        DG_Product_Pricing_Currency_ID = p.PS_Product_Pricing_Currency_ID,
                        Itemcount = p.Itemcount,
                        IsPrintType = p.IsPrintType,
                        IsChecked = p.IsChecked,
                        DG_IsWaterMarkIncluded = p.PS_IsWaterMarkIncluded,
                        DG_SubStore_pkey = p.PS_SubStore_pkey,

                       //IsActive = p.IsActive
                   }).FirstOrDefault();
                return obj;
            }
            catch
            {
                return new Model.ProductTypeInfo();
            }
        }
        public int GetProductID(string ProductTypeName)
        {
            try
            {
                //var obj = baProductTypeInfo.GetProductTypeInfoData().Where(p => p.PS_Orders_ProductType_Name == ProductTypeName)
                //    .Select(p => p.PS_Product_Pricing_Currency_ID).First();
                //jayendra
                var obj = baProductTypeInfo.GetProductTypeInfoData().Where(p => p.PS_Orders_ProductType_Name == ProductTypeName)
                 .Select(p => p.Id).First();
                int productType = obj;
                return productType;
            }
            catch
            {
                return 0;
            }
        }
        public double GetProductPricing(int ProductTypeID)
        {
            try
            {
                var obj = baProductTypeInfo.GetProductTypeInfoData().Where(p => p.PS_Orders_ProductType_pkey == ProductTypeID)
                    .Select(p => p.PS_Product_Pricing_ProductPrice).First();
                double productType = obj;
                return productType;
            }
            catch
            {
                return 0;
            }
        }
        public List<PhotoSW.IMIX.Model.ProductPriceInfo> GetProductPricingStoreWise(int StoreId)
        {
            try
            {
                var obj = baProductPriceInfo.GetPhotoGroupInfoData().Where(p => p.PS_Product_Pricing_StoreId == StoreId)

                    .Select(p => new PhotoSW.IMIX.Model.ProductPriceInfo
                    {
                   //Id = p.Id,

                   DG_Product_Pricing_Pkey = p.Id,
                        DG_Product_Pricing_ProductType = p.PS_Product_Pricing_ProductType,
                        DG_Product_Pricing_ProductPrice = p.PS_Product_Pricing_ProductPrice,
                        DG_Product_Pricing_Currency_ID = p.PS_Product_Pricing_Currency_ID,
                        DG_Product_Pricing_UpdateDate = p.PS_Product_Pricing_UpdateDate,
                        DG_Product_Pricing_CreatedBy = p.PS_Product_Pricing_CreatedBy,
                        DG_Product_Pricing_StoreId = p.PS_Product_Pricing_StoreId,
                        DG_Product_Pricing_IsAvaliable = p.PS_Product_Pricing_IsAvaliable

                   //IsActive = p.IsActive
               }).ToList();
                return obj;
            }
            catch
            {
                return new List<PhotoSW.IMIX.Model.ProductPriceInfo>();
            }
        }
        public DataSet GetProductSummary(DateTime FromDate, DateTime ToDate,
            string StoreName, string UserName, int SubStorePKey)
        {

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            baProductSummary_Result test = new baProductSummary_Result();

            var obj = baProductSummary_Result.GetPhotoGroupInfoData();
            //var obj1 = obj.Where(c => c.FROMDate == FromDate && c.Todate == ToDate && c.StoreName == StoreName && c.UserName == UserName);

            // dt.Columns.Add();

            // ds.Tables.Add(dt);
            //   return ds;

            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ProductName", typeof(string));
            // dataTable.Columns.Add("Product Code",typeof(string));
            dataTable.Columns.Add("TotalQuantity", typeof(int));
            dataTable.Columns.Add("UnitPrice", typeof(decimal));
            dataTable.Columns.Add("TotalCost", typeof(decimal));
            dataTable.Columns.Add("Discount", typeof(decimal));
            dataTable.Columns.Add("NetPrice", typeof(decimal));
            dataTable.Columns.Add("TotalRevenue", typeof(decimal));
            dataTable.Columns.Add("Revpercentage", typeof(decimal));
            dataTable.Columns.Add("FromDate", typeof(DateTime));
            dataTable.Columns.Add("Todate", typeof(DateTime));
            dataTable.Columns.Add("UserName", typeof(string));
            dataTable.Columns.Add("StoreName", typeof(string));
            dataTable.Columns.Add("Flag", typeof(int));
            dataTable.Columns.Add("PS_SubStore_Name", typeof(string));
            dataTable.Columns.Add("PS_Orders_ProductCode", typeof(string));
            // dataTable.Columns.Add("IsActive", typeof(BitConverter));
            //  dataTable.Rows.Add("Photo", "", 3,3,4,5,6,7,8,"1/11/2018", "1/11/2018",0);   table.PS_Orders_ProductCode,
            foreach (var table in obj)
            {
                dataTable.Rows.Add(table.ProductName, table.TotalQuantity, table.UnitPrice, table.TotalCost, table.Discount, table.NetPrice, table.TotalRevenue, table.Revpercentage, table.FROMDate, table.Todate, table.UserName, table.StoreName, table.Flag, table.PS_SubStore_Name, table.PS_Orders_ProductCode);
            }


            dataSet.Tables.Add(dataTable);

            return dataSet;

            //  return new DataSet();
        }
        public int GetProductsynccodeName(string ProductTypeName)
        {
            try
            {
                var obj = baProductTypeInfo.GetProductTypeInfoData().Where(p => p.PS_Orders_ProductType_Name == ProductTypeName)
                    .Select(p => p.SyncCode).First();
                int SyncCode = Convert.ToInt32(obj);
                return SyncCode;
            }
            catch
            {
                return 0;
            }

        }
        public List<PhotoSW.IMIX.Model.ProductTypeInfo> GetProductType()
        {
            try
            {
                var obj = baProductTypeInfo.GetProductTypeInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.ProductTypeInfo
                    {
                       //Id = p.Id,

                       DG_Orders_ProductType_pkey = p.Id,
                        DG_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        DG_Orders_ProductType_Desc = p.PS_Orders_ProductType_Desc,
                        DG_Orders_ProductType_IsBundled = p.PS_Orders_ProductType_IsBundled,
                        DG_Orders_ProductType_DiscountApplied = p.PS_Orders_ProductType_DiscountApplied,
                        DG_Orders_ProductType_Image = p.PS_Orders_ProductType_Image,
                        DG_IsPackage = p.PS_IsPackage,
                        DG_MaxQuantity = p.PS_MaxQuantity,
                        DG_Orders_ProductType_Active = p.PS_Orders_ProductType_Active,
                        DG_IsActive = p.PS_IsActive,
                        DG_IsAccessory = p.PS_IsAccessory,
                        DG_IsTaxEnabled = p.PS_IsTaxEnabled,
                        DG_IsPrimary = p.PS_IsPrimary,
                        DG_Orders_ProductCode = p.PS_Orders_ProductCode,
                        DG_Orders_ProductNumber = p.PS_Orders_ProductNumber,
                        DG_IsBorder = p.PS_IsBorder,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_Product_Pricing_ProductPrice = p.PS_Product_Pricing_ProductPrice,
                        DG_Product_Pricing_Currency_ID = p.PS_Product_Pricing_Currency_ID,
                        Itemcount = p.Itemcount,
                        IsPrintType = p.IsPrintType,
                        IsChecked = p.IsChecked,
                        DG_IsWaterMarkIncluded = p.PS_IsWaterMarkIncluded,
                        DG_SubStore_pkey = p.PS_SubStore_pkey,

                       //IsActive = p.IsActive
                   }).ToList();
                return obj;
            }
            catch
            {
                return new List<Model.ProductTypeInfo>();
            }
            // return new List<PhotoSW.IMIX.Model.ProductTypeInfo>();
        }
        public PhotoSW.IMIX.Model.ProductTypeInfo GetProductType(int productId)
        {
            try
            {
                var obj = baProductTypeInfo.GetProductTypeInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.ProductTypeInfo
                    {
                        DG_Orders_ProductType_pkey = p.Id,
                        DG_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        DG_Orders_ProductType_Desc = p.PS_Orders_ProductType_Desc,
                        DG_Orders_ProductType_IsBundled = p.PS_Orders_ProductType_IsBundled,
                        DG_Orders_ProductType_DiscountApplied = p.PS_Orders_ProductType_DiscountApplied,
                        DG_Orders_ProductType_Image = p.PS_Orders_ProductType_Image,
                        DG_IsPackage = p.PS_IsPackage,
                        DG_MaxQuantity = p.PS_MaxQuantity,
                        DG_Orders_ProductType_Active = p.PS_Orders_ProductType_Active,
                        DG_IsActive = p.PS_IsActive,
                        DG_IsAccessory = p.PS_IsAccessory,
                        DG_IsTaxEnabled = p.PS_IsTaxEnabled,
                        DG_IsPrimary = p.PS_IsPrimary,
                        DG_Orders_ProductCode = p.PS_Orders_ProductCode,
                        DG_Orders_ProductNumber = p.PS_Orders_ProductNumber,
                        DG_IsBorder = p.PS_IsBorder,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_Product_Pricing_ProductPrice = p.PS_Product_Pricing_ProductPrice,
                        DG_Product_Pricing_Currency_ID = p.PS_Product_Pricing_Currency_ID,
                        Itemcount = p.Itemcount,
                        IsPrintType = p.IsPrintType,
                        IsChecked = p.IsChecked,
                        DG_IsWaterMarkIncluded = p.PS_IsWaterMarkIncluded,
                        DG_SubStore_pkey = p.PS_SubStore_pkey,

                        //IsActive = p.IsActive
                    }).FirstOrDefault();
                return obj;
            }
            catch
            {
                return new Model.ProductTypeInfo();
            }
            // return new PhotoSW.IMIX.Model.ProductTypeInfo();
        }
        public List<PhotoSW.IMIX.Model.ProductTypeInfo> GetProductTypeforOrder(int SubStoreID)
        {
            try
            {
                var obj = baProductTypeInfo.GetProductTypeInfoData().Where(p => p.PS_SubStore_pkey == SubStoreID)
                    .Select(p => new PhotoSW.IMIX.Model.ProductTypeInfo
                    {
                        DG_Orders_ProductType_pkey = p.Id,
                        DG_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        DG_Orders_ProductType_Desc = p.PS_Orders_ProductType_Desc,
                        DG_Orders_ProductType_IsBundled = p.PS_Orders_ProductType_IsBundled,
                        DG_Orders_ProductType_DiscountApplied = p.PS_Orders_ProductType_DiscountApplied,
                        DG_Orders_ProductType_Image = AppDomain.CurrentDomain.BaseDirectory + "print_icon\\" + p.PS_Orders_ProductType_Image,
                        DG_IsPackage = p.PS_IsPackage,
                        DG_MaxQuantity = p.PS_MaxQuantity,
                        DG_Orders_ProductType_Active = p.PS_Orders_ProductType_Active,
                        DG_IsActive = p.PS_IsActive,
                        DG_IsAccessory = p.PS_IsAccessory,
                        DG_IsTaxEnabled = p.PS_IsTaxEnabled,
                        DG_IsPrimary = p.PS_IsPrimary,
                        DG_Orders_ProductCode = p.PS_Orders_ProductCode,
                        DG_Orders_ProductNumber = p.PS_Orders_ProductNumber,
                        DG_IsBorder = p.PS_IsBorder,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_Product_Pricing_ProductPrice = p.PS_Product_Pricing_ProductPrice,
                        DG_Product_Pricing_Currency_ID = p.PS_Product_Pricing_Currency_ID,
                        Itemcount = p.Itemcount,
                        IsPrintType = p.IsPrintType,
                        IsChecked = p.IsChecked,
                        DG_IsWaterMarkIncluded = p.PS_IsWaterMarkIncluded,
                        DG_SubStore_pkey = p.PS_SubStore_pkey,

                        //IsActive = p.IsActive
                    }).ToList();
                return obj;
            }
            catch
            {
                return new List<PhotoSW.IMIX.Model.ProductTypeInfo>();
            }
            //  return new List<PhotoSW.IMIX.Model.ProductTypeInfo>();
        }
        public List<PhotoSW.IMIX.Model.ProductTypeInfo> GetProductTypeList(bool? IsPackage)
        {
            try
            {
                var obj = baProductTypeInfo.GetProductTypeInfoData().Where(p => p.PS_IsPackage == IsPackage)
                    .Select(p => new PhotoSW.IMIX.Model.ProductTypeInfo
                    {
                        DG_Orders_ProductType_pkey = p.Id,
                        DG_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        DG_Orders_ProductType_Desc = p.PS_Orders_ProductType_Desc,
                        DG_Orders_ProductType_IsBundled = p.PS_Orders_ProductType_IsBundled,
                        DG_Orders_ProductType_DiscountApplied = p.PS_Orders_ProductType_DiscountApplied,
                        DG_Orders_ProductType_Image = p.PS_Orders_ProductType_Image,
                        DG_IsPackage = p.PS_IsPackage,
                        DG_MaxQuantity = p.PS_MaxQuantity,
                        DG_Orders_ProductType_Active = p.PS_Orders_ProductType_Active,
                        DG_IsActive = p.PS_IsActive,
                        DG_IsAccessory = p.PS_IsAccessory,
                        DG_IsTaxEnabled = p.PS_IsTaxEnabled,
                        DG_IsPrimary = p.PS_IsPrimary,
                        DG_Orders_ProductCode = p.PS_Orders_ProductCode,
                        DG_Orders_ProductNumber = p.PS_Orders_ProductNumber,
                        DG_IsBorder = p.PS_IsBorder,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_Product_Pricing_ProductPrice = p.PS_Product_Pricing_ProductPrice,
                        DG_Product_Pricing_Currency_ID = p.PS_Product_Pricing_Currency_ID,
                        Itemcount = p.Itemcount,
                        IsPrintType = p.IsPrintType,
                        IsChecked = p.IsChecked,
                        DG_IsWaterMarkIncluded = p.PS_IsWaterMarkIncluded,
                        DG_SubStore_pkey = p.PS_SubStore_pkey,

                    }).ToList();
                return obj;
            }
            catch
            {
                return new List<PhotoSW.IMIX.Model.ProductTypeInfo>();
            }

            // return new List<PhotoSW.IMIX.Model.ProductTypeInfo>();
        }
        public PhotoSW.IMIX.Model.ProductTypeInfo GetProductTypeListById(int ProductId)
        {
            try
            {
                var obj = baProductTypeInfo.GetProductTypeInfoData().Where(p => p.PS_Orders_ProductType_pkey == ProductId)
                    .Select(p => new PhotoSW.IMIX.Model.ProductTypeInfo
                    {
                        DG_Orders_ProductType_pkey = p.Id,
                        DG_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        DG_Orders_ProductType_Desc = p.PS_Orders_ProductType_Desc,
                        DG_Orders_ProductType_IsBundled = p.PS_Orders_ProductType_IsBundled,
                        DG_Orders_ProductType_DiscountApplied = p.PS_Orders_ProductType_DiscountApplied,
                        DG_Orders_ProductType_Image = p.PS_Orders_ProductType_Image,
                        DG_IsPackage = p.PS_IsPackage,
                        DG_MaxQuantity = p.PS_MaxQuantity,
                        DG_Orders_ProductType_Active = p.PS_Orders_ProductType_Active,
                        DG_IsActive = p.PS_IsActive,
                        DG_IsAccessory = p.PS_IsAccessory,
                        DG_IsTaxEnabled = p.PS_IsTaxEnabled,
                        DG_IsPrimary = p.PS_IsPrimary,
                        DG_Orders_ProductCode = p.PS_Orders_ProductCode,
                        DG_Orders_ProductNumber = p.PS_Orders_ProductNumber,
                        DG_IsBorder = p.PS_IsBorder,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_Product_Pricing_ProductPrice = p.PS_Product_Pricing_ProductPrice,
                        DG_Product_Pricing_Currency_ID = p.PS_Product_Pricing_Currency_ID,
                        Itemcount = p.Itemcount,
                        IsPrintType = p.IsPrintType,
                        IsChecked = p.IsChecked,
                        DG_IsWaterMarkIncluded = p.PS_IsWaterMarkIncluded,
                        DG_SubStore_pkey = p.PS_SubStore_pkey,

                    }).FirstOrDefault();
                return obj;
            }
            catch
            {
                return new PhotoSW.IMIX.Model.ProductTypeInfo();
            }


        }
        public bool IsChkSpecOnlinePackage(int PackageId)
        {
            return false;
        }
        public bool SaveBorderFor4Images(bool chk4Large, bool chkUniq4, bool chk4small, bool chk3by3, bool chkUniq4SW)
        {
            return false;
        }
        public bool SetProductPricingData(int? ProductTypeId, double? ProductPrice,
            int? CurrencyId, int? CreatedBy, int? storeId, bool? Isavailable)
        {
            return false;
        }
        public bool SetProductTypeInfo(int ProductTypeId, string ProductTypeName,
            string ProductTypeDesc, bool? IsDiscount,
            string ProductPrice, int stroreId,
            int UserId, bool ispackage,
            bool? Isactive, bool? IsAccessory,
            bool? IsTaxIncluded, string Productcode,
            string SyncCode, string syncodeforPackage,
            int? IsInvisible, bool? IschkWaterMarked,
            int SubStoreID, int ProductTypePkey)
        {
            baProductTypeInfo baProductTypeInfo = new baProductTypeInfo();
            baProductTypeInfo.Id = ProductTypeId;
            baProductTypeInfo.PS_Orders_ProductType_pkey = ProductTypePkey;
            baProductTypeInfo.PS_Orders_ProductType_Name = ProductTypeName;
            baProductTypeInfo.PS_Orders_ProductType_Desc = ProductTypeDesc;
            baProductTypeInfo.PS_Orders_ProductType_DiscountApplied = IsDiscount;
            baProductTypeInfo.PS_IsPackage = ispackage;
            baProductTypeInfo.PS_IsAccessory = IsAccessory;
            baProductTypeInfo.PS_IsTaxEnabled = IsTaxIncluded;
            baProductTypeInfo.PS_Orders_ProductCode = Productcode;
            baProductTypeInfo.SyncCode = SyncCode;
            baProductTypeInfo.PS_Product_Pricing_ProductPrice = Convert.ToDouble(ProductPrice);
            baProductTypeInfo.IsActive = Isactive;
            baProductTypeInfo.PS_SubStore_pkey = SubStoreID;
            baProductTypeInfo.PS_IsWaterMarkIncluded = IschkWaterMarked;
            baProductTypeInfo.PS_Orders_ProductType_pkey = ProductTypePkey;
            //baProductTypeInfo.PS_Orders_ProductNumber =                 
            //baProductTypeInfo.PS_MaxQuantity =                          
            //baProductTypeInfo.PS_IsActive = 
            //baProductTypeInfo.PS_Orders_ProductType_IsBundled =
            //baProductTypeInfo.PS_Orders_ProductType_Image =             
            //baProductTypeInfo.PS_Orders_ProductType_Active = 
            //baProductTypeInfo.PS_IsPrimary =                            
            //baProductTypeInfo.PS_IsBorder =                             
            //baProductTypeInfo.IsSynced =                                
            //baProductTypeInfo.PS_Product_Pricing_Currency_ID =          
            //baProductTypeInfo.Itemcount =
            //baProductTypeInfo.IsPrintType =
            //baProductTypeInfo.IsChecked =
            if (ProductTypePkey == 0)
            {
                return baProductTypeInfo.Insert(baProductTypeInfo);
            }
            else
            {
                return baProductTypeInfo.Update(baProductTypeInfo);
            }

        }

    }
}
