using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
   public class baProductPriceInfo
        {
        public int Id { get; set; }
        public int PS_Product_Pricing_Pkey { get; set; }
        public int? PS_Product_Pricing_ProductType { get; set; }
        public double? PS_Product_Pricing_ProductPrice { get; set; }
        public int? PS_Product_Pricing_Currency_ID { get; set; }
        public DateTime? PS_Product_Pricing_UpdateDate { get; set; }
        public int? PS_Product_Pricing_CreatedBy { get; set; }
        public int? PS_Product_Pricing_StoreId { get; set; }
        public bool? PS_Product_Pricing_IsAvaliable { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<productpriceinfo> lst_productpriceinfo = new List<productpriceinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    productpriceinfo productpriceinfo = new productpriceinfo();

                    productpriceinfo.Id = 1;
                    productpriceinfo.PS_Product_Pricing_Pkey = 2;
                    productpriceinfo.PS_Product_Pricing_ProductType = 3;
                    productpriceinfo.PS_Product_Pricing_ProductPrice = 2;
                    productpriceinfo.PS_Product_Pricing_Currency_ID = 3;
                    productpriceinfo.PS_Product_Pricing_UpdateDate = DateTime.Now;
                    productpriceinfo.PS_Product_Pricing_CreatedBy = 1;
                    productpriceinfo.PS_Product_Pricing_StoreId = 1;
                    productpriceinfo.PS_Product_Pricing_IsAvaliable = false;
                    productpriceinfo.IsActive = true;

                    lst_productpriceinfo.Add(productpriceinfo);

                    var Id = lst_productpriceinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ProductPriceInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.ProductPriceInfos.AddRange(lst_productpriceinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ProductPriceInfos.AddRange(lst_productpriceinfo);
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

        public static baProductPriceInfo GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ProductPriceInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baProductPriceInfo
                        {
                        Id = p.Id,
                        PS_Product_Pricing_Pkey = p.PS_Product_Pricing_Pkey,
                        PS_Product_Pricing_ProductType = p.PS_Product_Pricing_ProductType,
                        PS_Product_Pricing_ProductPrice = p.PS_Product_Pricing_ProductPrice,
                        PS_Product_Pricing_Currency_ID = p.PS_Product_Pricing_Currency_ID,
                        PS_Product_Pricing_UpdateDate = p.PS_Product_Pricing_UpdateDate,
                        PS_Product_Pricing_CreatedBy = p.PS_Product_Pricing_CreatedBy,
                        PS_Product_Pricing_StoreId = p.PS_Product_Pricing_StoreId,
                        PS_Product_Pricing_IsAvaliable = p.PS_Product_Pricing_IsAvaliable,                       
                        IsActive = p.IsActive,

                        }).FirstOrDefault();
                    return obj;
                    }
                }
            catch
                {
                return null; ;
                }
            }

        public static List<baProductPriceInfo> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ProductPriceInfos.Where(p => p.IsActive == true).Select(p => new baProductPriceInfo
                        {
                        Id = p.Id,
                        PS_Product_Pricing_Pkey = p.PS_Product_Pricing_Pkey,
                        PS_Product_Pricing_ProductType = p.PS_Product_Pricing_ProductType,
                        PS_Product_Pricing_ProductPrice = p.PS_Product_Pricing_ProductPrice,
                        PS_Product_Pricing_Currency_ID = p.PS_Product_Pricing_Currency_ID,
                        PS_Product_Pricing_UpdateDate = p.PS_Product_Pricing_UpdateDate,
                        PS_Product_Pricing_CreatedBy = p.PS_Product_Pricing_CreatedBy,
                        PS_Product_Pricing_StoreId = p.PS_Product_Pricing_StoreId,
                        PS_Product_Pricing_IsAvaliable = p.PS_Product_Pricing_IsAvaliable,
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

        public static bool Insert ( baProductPriceInfo baProductPriceInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    productpriceinfo productpriceinfo = new productpriceinfo();

                    productpriceinfo.Id = baProductPriceInfo.Id;
                    productpriceinfo.PS_Product_Pricing_Pkey = baProductPriceInfo.PS_Product_Pricing_Pkey;
                    productpriceinfo.PS_Product_Pricing_ProductType = baProductPriceInfo.PS_Product_Pricing_ProductType;
                    productpriceinfo.PS_Product_Pricing_ProductPrice = baProductPriceInfo.PS_Product_Pricing_ProductPrice;
                    productpriceinfo.PS_Product_Pricing_Currency_ID = baProductPriceInfo.PS_Product_Pricing_Currency_ID;
                    productpriceinfo.PS_Product_Pricing_UpdateDate = baProductPriceInfo.PS_Product_Pricing_UpdateDate;
                    productpriceinfo.PS_Product_Pricing_CreatedBy = baProductPriceInfo.PS_Product_Pricing_CreatedBy;
                    productpriceinfo.PS_Product_Pricing_StoreId = baProductPriceInfo.PS_Product_Pricing_StoreId;
                    productpriceinfo.PS_Product_Pricing_IsAvaliable = baProductPriceInfo.PS_Product_Pricing_IsAvaliable;
                    productpriceinfo.IsActive = baProductPriceInfo.IsActive;

                    db.ProductPriceInfos.Add(productpriceinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baProductPriceInfo baProductPriceInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ProductPriceInfos.Where(p => p.Id == baProductPriceInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        productpriceinfo productpriceinfo = new productpriceinfo();

                        productpriceinfo.Id = baProductPriceInfo.Id;
                        productpriceinfo.PS_Product_Pricing_Pkey = baProductPriceInfo.PS_Product_Pricing_Pkey;
                        productpriceinfo.PS_Product_Pricing_ProductType = baProductPriceInfo.PS_Product_Pricing_ProductType;
                        productpriceinfo.PS_Product_Pricing_ProductPrice = baProductPriceInfo.PS_Product_Pricing_ProductPrice;
                        productpriceinfo.PS_Product_Pricing_Currency_ID = baProductPriceInfo.PS_Product_Pricing_Currency_ID;
                        productpriceinfo.PS_Product_Pricing_UpdateDate = baProductPriceInfo.PS_Product_Pricing_UpdateDate;
                        productpriceinfo.PS_Product_Pricing_CreatedBy = baProductPriceInfo.PS_Product_Pricing_CreatedBy;
                        productpriceinfo.PS_Product_Pricing_StoreId = baProductPriceInfo.PS_Product_Pricing_StoreId;
                        productpriceinfo.PS_Product_Pricing_IsAvaliable = baProductPriceInfo.PS_Product_Pricing_IsAvaliable;
                        productpriceinfo.IsActive = baProductPriceInfo.IsActive;

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
                    var obj = db.ProductPriceInfos.Where(p => p.Id == Id).FirstOrDefault();
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
