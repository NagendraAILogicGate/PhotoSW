using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baProductTypeInfo
        {
        public int Id { get; set; }
        public int PS_Orders_ProductType_pkey { get; set; }
        public string PS_Orders_ProductType_Name { get; set; }
        public string PS_Orders_ProductType_Desc { get; set; }
        public bool? PS_Orders_ProductType_IsBundled { get; set; }
        public bool? PS_Orders_ProductType_DiscountApplied { get; set; }
        public string PS_Orders_ProductType_Image { get; set; }
        public bool PS_IsPackage { get; set; }
        public int PS_MaxQuantity { get; set; }
        public bool? PS_Orders_ProductType_Active { get; set; }
        public bool? PS_IsActive { get; set; }
        public bool? PS_IsAccessory { get; set; }
        public bool? PS_IsTaxEnabled { get; set; }
        public bool? PS_IsPrimary { get; set; }
        public string PS_Orders_ProductCode { get; set; }
        public int? PS_Orders_ProductNumber { get; set; }
        public bool? PS_IsBorder { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public double PS_Product_Pricing_ProductPrice { get; set; }
        public int PS_Product_Pricing_Currency_ID { get; set; }
        public int Itemcount { get; set; }
        public int IsPrintType { get; set; }
        public bool IsChecked { get; set; }
        public bool? PS_IsWaterMarkIncluded { get; set; }
        public int PS_SubStore_pkey { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<producttypeinfo> lst_producttypeinfo = new List<producttypeinfo>();
            List<int> lst_str = new List<int>();
            lst_str.Add(1);
            lst_str.Add(2);
            lst_str.Add(3);
            lst_str.Add(4);
            lst_str.Add(5);
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    foreach(var item in lst_str)
                        {
                        producttypeinfo producttypeinfo = new producttypeinfo();

                        producttypeinfo.Id = item;
                        producttypeinfo.PS_Orders_ProductType_pkey = item;
                       

                        if(item == 1)
                            {
                            producttypeinfo.PS_Orders_ProductType_Name = "6X8 Photo + QR Code";
                            producttypeinfo.PS_Orders_ProductType_Desc = "6X8 Photo + QR Code";
                            producttypeinfo.PS_Orders_ProductCode = "001";
                            } 
                        if(item == 2)
                            {
                            producttypeinfo.PS_Orders_ProductType_Name = "4X6 Photo + QR Code";
                            producttypeinfo.PS_Orders_ProductType_Desc = "4X6 Photo + QR Code";
                            producttypeinfo.PS_Orders_ProductCode = "002";
                            } 
                        if(item == 3)
                            {
                            producttypeinfo.PS_Orders_ProductType_Name = "8X10 Photo + QR Code";
                            producttypeinfo.PS_Orders_ProductType_Desc = "8X10 Photo + QR Code";
                            producttypeinfo.PS_Orders_ProductCode = "003";
                            } 
                        if(item == 4)
                            {
                            producttypeinfo.PS_Orders_ProductType_Name = "Globe + Wallet";
                            producttypeinfo.PS_Orders_ProductType_Desc = "Globe + Wallet";
                            producttypeinfo.PS_Orders_ProductCode = "004";
                            } 
                        if(item == 5)
                            {
                            producttypeinfo.PS_Orders_ProductType_Name = "HC Folder + QR Code";
                            producttypeinfo.PS_Orders_ProductType_Desc = "HC Folder + QR Code";
                            producttypeinfo.PS_Orders_ProductCode = "005";
                            }
                        producttypeinfo.PS_Orders_ProductType_IsBundled = false;
                        producttypeinfo.PS_Orders_ProductType_DiscountApplied = false;
                        producttypeinfo.PS_Orders_ProductType_Image = "print-icon.png";
                        producttypeinfo.PS_IsPackage = false;
                        producttypeinfo.PS_MaxQuantity = 1;
                        producttypeinfo.PS_Orders_ProductType_Active = false;
                        producttypeinfo.PS_IsActive = false;
                        producttypeinfo.PS_IsAccessory = false;
                        producttypeinfo.PS_IsTaxEnabled = false;
                        producttypeinfo.PS_IsPrimary = false;
                     
                        producttypeinfo.PS_Orders_ProductNumber = 1;
                        producttypeinfo.PS_IsBorder = false;
                        producttypeinfo.SyncCode = "001";
                        producttypeinfo.IsSynced = false;
                        producttypeinfo.PS_Product_Pricing_ProductPrice = 1;
                        producttypeinfo.PS_Product_Pricing_Currency_ID = 1;
                        producttypeinfo.Itemcount = 1;
                        producttypeinfo.IsPrintType = 1;
                        producttypeinfo.IsChecked = false;
                        producttypeinfo.PS_IsWaterMarkIncluded = false;
                        producttypeinfo.PS_SubStore_pkey = 1;
                        producttypeinfo.IsActive = true;

                        lst_producttypeinfo.Add(producttypeinfo);
                        }
                    var Id = lst_producttypeinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ProductTypeInfos.Where(p => lst_str.Contains(p.Id)).ToList();
                    if(IsExist == null)
                        {
                        db.ProductTypeInfos.AddRange(lst_producttypeinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ProductTypeInfos.AddRange(lst_producttypeinfo);
                        db.SaveChanges();
                        }
                    return true;
                    }
                }
            catch(Exception ex)
                {
                return false;
                }
            }

        public static baProductTypeInfo GetProductTypeDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ProductTypeInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baProductTypeInfo
                        {
                        Id = p.Id,
                        PS_Orders_ProductType_pkey = p.PS_Orders_ProductType_pkey,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        PS_Orders_ProductType_Desc = p.PS_Orders_ProductType_Desc,
                        PS_Orders_ProductType_IsBundled = p.PS_Orders_ProductType_IsBundled,
                        PS_Orders_ProductType_DiscountApplied = p.PS_Orders_ProductType_DiscountApplied,
                        PS_Orders_ProductType_Image = p.PS_Orders_ProductType_Image,
                        PS_IsPackage = p.PS_IsPackage,
                        PS_MaxQuantity = p.PS_MaxQuantity,
                        PS_Orders_ProductType_Active = p.PS_Orders_ProductType_Active,
                        PS_IsActive = p.PS_IsActive,
                        PS_IsAccessory = p.PS_IsAccessory,
                        PS_IsTaxEnabled = p.PS_IsTaxEnabled,
                        PS_IsPrimary = p.PS_IsPrimary,
                        PS_Orders_ProductCode = p.PS_Orders_ProductCode,
                        PS_Orders_ProductNumber = p.PS_Orders_ProductNumber,
                        PS_IsBorder = p.PS_IsBorder,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        PS_Product_Pricing_ProductPrice = p.PS_Product_Pricing_ProductPrice,
                        PS_Product_Pricing_Currency_ID = p.PS_Product_Pricing_Currency_ID,
                        Itemcount = p.Itemcount,
                        IsPrintType = p.IsPrintType,
                        IsChecked = p.IsChecked,
                        PS_IsWaterMarkIncluded = p.PS_IsWaterMarkIncluded,
                        PS_SubStore_pkey = p.PS_SubStore_pkey,
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

        public static List<baProductTypeInfo> GetProductTypeInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ProductTypeInfos.Where(p => p.IsActive == true).Select(p => new baProductTypeInfo
                        {
                        Id = p.Id,
                        PS_Orders_ProductType_pkey = p.PS_Orders_ProductType_pkey,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        PS_Orders_ProductType_Desc = p.PS_Orders_ProductType_Desc,
                        PS_Orders_ProductType_IsBundled = p.PS_Orders_ProductType_IsBundled,
                        PS_Orders_ProductType_DiscountApplied = p.PS_Orders_ProductType_DiscountApplied,
                        PS_Orders_ProductType_Image = p.PS_Orders_ProductType_Image,
                        PS_IsPackage = p.PS_IsPackage,
                        PS_MaxQuantity = p.PS_MaxQuantity,
                        PS_Orders_ProductType_Active = p.PS_Orders_ProductType_Active,
                        PS_IsActive = p.PS_IsActive,
                        PS_IsAccessory = p.PS_IsAccessory,
                        PS_IsTaxEnabled = p.PS_IsTaxEnabled,
                        PS_IsPrimary = p.PS_IsPrimary,
                        PS_Orders_ProductCode = p.PS_Orders_ProductCode,
                        PS_Orders_ProductNumber = p.PS_Orders_ProductNumber,
                        PS_IsBorder = p.PS_IsBorder,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        PS_Product_Pricing_ProductPrice = p.PS_Product_Pricing_ProductPrice,
                        PS_Product_Pricing_Currency_ID = p.PS_Product_Pricing_Currency_ID,
                        Itemcount = p.Itemcount,
                        IsPrintType = p.IsPrintType,
                        IsChecked = p.IsChecked,
                        PS_IsWaterMarkIncluded = p.PS_IsWaterMarkIncluded,
                        PS_SubStore_pkey = p.PS_SubStore_pkey,
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

        public static bool Insert ( baProductTypeInfo baProductTypeInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    producttypeinfo producttypeinfo = new producttypeinfo();

                    producttypeinfo.Id = baProductTypeInfo.Id;
                    producttypeinfo.PS_Orders_ProductType_Name = baProductTypeInfo.PS_Orders_ProductType_Name;
                    producttypeinfo.PS_Orders_ProductType_Desc = baProductTypeInfo.PS_Orders_ProductType_Desc;
                    producttypeinfo.PS_Orders_ProductType_IsBundled = baProductTypeInfo.PS_Orders_ProductType_IsBundled;
                    producttypeinfo.PS_Orders_ProductType_DiscountApplied = baProductTypeInfo.PS_Orders_ProductType_DiscountApplied;
                    producttypeinfo.PS_Orders_ProductType_Image = baProductTypeInfo.PS_Orders_ProductType_Image;
                    producttypeinfo.PS_IsPackage = baProductTypeInfo.PS_IsPackage;
                    producttypeinfo.PS_MaxQuantity = baProductTypeInfo.PS_MaxQuantity;
                    producttypeinfo.PS_Orders_ProductType_Active = baProductTypeInfo.PS_Orders_ProductType_Active;
                    producttypeinfo.PS_IsActive = baProductTypeInfo.PS_IsActive;
                    producttypeinfo.PS_IsAccessory = baProductTypeInfo.PS_IsAccessory;
                    producttypeinfo.PS_IsTaxEnabled = baProductTypeInfo.PS_IsTaxEnabled;
                    producttypeinfo.PS_IsPrimary = baProductTypeInfo.PS_IsPrimary;
                    producttypeinfo.PS_Orders_ProductCode = baProductTypeInfo.PS_Orders_ProductCode;
                    producttypeinfo.PS_Orders_ProductNumber = baProductTypeInfo.PS_Orders_ProductNumber;
                    producttypeinfo.PS_IsBorder = baProductTypeInfo.PS_IsBorder;
                    producttypeinfo.SyncCode = baProductTypeInfo.SyncCode;
                    producttypeinfo.IsSynced = baProductTypeInfo.IsSynced;
                    producttypeinfo.PS_Product_Pricing_ProductPrice = baProductTypeInfo.PS_Product_Pricing_ProductPrice;
                    producttypeinfo.PS_Product_Pricing_Currency_ID = baProductTypeInfo.PS_Product_Pricing_Currency_ID;
                    producttypeinfo.Itemcount = baProductTypeInfo.Itemcount;
                    producttypeinfo.IsPrintType = baProductTypeInfo.IsPrintType;
                    producttypeinfo.IsChecked = baProductTypeInfo.IsChecked;
                    producttypeinfo.PS_IsWaterMarkIncluded = baProductTypeInfo.PS_IsWaterMarkIncluded;
                    producttypeinfo.PS_SubStore_pkey = baProductTypeInfo.PS_SubStore_pkey;
                    producttypeinfo.IsActive = baProductTypeInfo.IsActive;

                    db.ProductTypeInfos.Add(producttypeinfo);
                    db.SaveChanges();

                    producttypeinfo.PS_Orders_ProductType_pkey = Convert.ToInt32(db.ProductTypeInfos.OrderByDescending(v=>v.Id).FirstOrDefault().Id);
                    db.SaveChanges();


                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baProductTypeInfo baProductTypeInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ProductTypeInfos.Where(p => p.Id == baProductTypeInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        //producttypeinfo producttypeinfo = new producttypeinfo();

                        obj.PS_Orders_ProductType_Name = baProductTypeInfo.PS_Orders_ProductType_Name;
                        obj.PS_Orders_ProductType_Desc = baProductTypeInfo.PS_Orders_ProductType_Desc;
                        obj.PS_Orders_ProductType_IsBundled = baProductTypeInfo.PS_Orders_ProductType_IsBundled;
                        obj.PS_Orders_ProductType_DiscountApplied = baProductTypeInfo.PS_Orders_ProductType_DiscountApplied;
                        obj.PS_Orders_ProductType_Image = baProductTypeInfo.PS_Orders_ProductType_Image;
                        obj.PS_IsPackage = baProductTypeInfo.PS_IsPackage;
                        obj.PS_MaxQuantity = baProductTypeInfo.PS_MaxQuantity;
                        obj.PS_Orders_ProductType_Active = baProductTypeInfo.PS_Orders_ProductType_Active;
                        obj.PS_IsActive = baProductTypeInfo.PS_IsActive;
                        obj.PS_IsAccessory = baProductTypeInfo.PS_IsAccessory;
                        obj.PS_IsTaxEnabled = baProductTypeInfo.PS_IsTaxEnabled;
                        obj.PS_IsPrimary = baProductTypeInfo.PS_IsPrimary;
                        obj.PS_Orders_ProductCode = baProductTypeInfo.PS_Orders_ProductCode;
                        obj.PS_Orders_ProductNumber = baProductTypeInfo.PS_Orders_ProductNumber;
                        obj.PS_IsBorder = baProductTypeInfo.PS_IsBorder;
                        obj.SyncCode = baProductTypeInfo.SyncCode;
                        obj.IsSynced = baProductTypeInfo.IsSynced;
                        obj.PS_Product_Pricing_ProductPrice = baProductTypeInfo.PS_Product_Pricing_ProductPrice;
                        obj.PS_Product_Pricing_Currency_ID = baProductTypeInfo.PS_Product_Pricing_Currency_ID;
                        obj.Itemcount = baProductTypeInfo.Itemcount;
                        obj.IsPrintType = baProductTypeInfo.IsPrintType;
                        obj.IsChecked = baProductTypeInfo.IsChecked;
                        obj.PS_IsWaterMarkIncluded = baProductTypeInfo.PS_IsWaterMarkIncluded;
                        obj.PS_SubStore_pkey = baProductTypeInfo.PS_SubStore_pkey;
                        obj.IsActive = baProductTypeInfo.IsActive;

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
                    var obj = db.ProductTypeInfos.Where(p => p.Id == Id).FirstOrDefault();
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
