using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baProductSummary_Result
        {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int TotalQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Discount { get; set; }
        public decimal NetPrice { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal Revpercentage { get; set; }
        public DateTime? FROMDate { get; set; }
        public DateTime? Todate { get; set; }
        public string UserName { get; set; }
        public string StoreName { get; set; }
        public int Flag { get; set; }
        public string PS_SubStore_Name { get; set; }
        public string PS_Orders_ProductCode { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<productsummary_result> lst_productsummary = new List<productsummary_result>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    productsummary_result productsummary_result = new productsummary_result();

                    productsummary_result.Id = 1;
                    productsummary_result.ProductName = "";
                    productsummary_result.TotalQuantity = 3;
                    productsummary_result.UnitPrice = 2;
                    productsummary_result.TotalCost = 3;
                    productsummary_result.Discount = 5;
                    productsummary_result.NetPrice = 1;
                    productsummary_result.TotalRevenue = 2;
                    productsummary_result.Revpercentage = 5;
                    productsummary_result.FROMDate = DateTime.Now;
                    productsummary_result.Todate = DateTime.Now;
                    productsummary_result.UserName = "";
                    productsummary_result.StoreName = "";
                    productsummary_result.Flag = 0;
                    productsummary_result.PS_SubStore_Name = "";
                    productsummary_result.PS_Orders_ProductCode = "";
                    productsummary_result.IsActive = true;

                    lst_productsummary.Add(productsummary_result);

                    var Id = lst_productsummary.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ProductSummary_Results.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.ProductSummary_Results.AddRange(lst_productsummary);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ProductSummary_Results.AddRange(lst_productsummary);
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

        public static baProductSummary_Result GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ProductSummary_Results.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baProductSummary_Result
                        {
                        Id = p.Id,
                        ProductName = p.ProductName,
                        TotalQuantity = p.TotalQuantity,
                        UnitPrice = p.UnitPrice,
                        TotalCost = p.TotalCost,
                        Discount = p.Discount,
                        NetPrice = p.NetPrice,
                        TotalRevenue = p.TotalRevenue,
                        Revpercentage = p.Revpercentage,
                        FROMDate = p.FROMDate,
                        Todate = p.Todate,
                        UserName = p.UserName,
                        StoreName = p.StoreName,
                        Flag = p.Flag,
                        PS_SubStore_Name = p.PS_SubStore_Name,
                        PS_Orders_ProductCode = p.PS_Orders_ProductCode,
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

        public static List<baProductSummary_Result> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ProductSummary_Results.Where(p => p.IsActive == true).Select(p => new baProductSummary_Result
                        {
                        Id = p.Id,
                        ProductName = p.ProductName,
                        TotalQuantity = p.TotalQuantity,
                        UnitPrice = p.UnitPrice,
                        TotalCost = p.TotalCost,
                        Discount = p.Discount,
                        NetPrice = p.NetPrice,
                        TotalRevenue = p.TotalRevenue,
                        Revpercentage = p.Revpercentage,
                        FROMDate = p.FROMDate,
                        Todate = p.Todate,
                        UserName = p.UserName,
                        StoreName = p.StoreName,
                        Flag = p.Flag,
                        PS_SubStore_Name = p.PS_SubStore_Name,
                        PS_Orders_ProductCode = p.PS_Orders_ProductCode,
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

        public static bool Insert ( baProductSummary_Result baProductSummary_Result )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    productsummary_result productsummary_result = new productsummary_result();

                    productsummary_result.Id = baProductSummary_Result.Id;
                    productsummary_result.ProductName = baProductSummary_Result.ProductName;
                    productsummary_result.TotalQuantity = baProductSummary_Result.TotalQuantity;
                    productsummary_result.UnitPrice = baProductSummary_Result.UnitPrice;
                    productsummary_result.TotalCost = baProductSummary_Result.TotalCost;
                    productsummary_result.Discount = baProductSummary_Result.Discount;
                    productsummary_result.NetPrice = baProductSummary_Result.NetPrice;
                    productsummary_result.TotalRevenue = baProductSummary_Result.TotalRevenue;
                    productsummary_result.Revpercentage = baProductSummary_Result.Revpercentage;
                    productsummary_result.FROMDate = baProductSummary_Result.FROMDate;
                    productsummary_result.Todate = baProductSummary_Result.Todate;
                    productsummary_result.UserName = baProductSummary_Result.UserName;
                    productsummary_result.StoreName = baProductSummary_Result.StoreName;
                    productsummary_result.Flag = productsummary_result.Flag;
                    productsummary_result.PS_SubStore_Name = baProductSummary_Result.PS_SubStore_Name;
                    productsummary_result.PS_Orders_ProductCode = baProductSummary_Result.PS_Orders_ProductCode;
                    productsummary_result.IsActive = baProductSummary_Result.IsActive;

                    db.ProductSummary_Results.Add(productsummary_result);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baProductSummary_Result baProductSummary_Result )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ProductSummary_Results.Where(p => p.Id == baProductSummary_Result.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        productsummary_result productsummary_result = new productsummary_result();

                        productsummary_result.Id = baProductSummary_Result.Id;
                        productsummary_result.ProductName = baProductSummary_Result.ProductName;
                        productsummary_result.TotalQuantity = baProductSummary_Result.TotalQuantity;
                        productsummary_result.UnitPrice = baProductSummary_Result.UnitPrice;
                        productsummary_result.TotalCost = baProductSummary_Result.TotalCost;
                        productsummary_result.Discount = baProductSummary_Result.Discount;
                        productsummary_result.NetPrice = baProductSummary_Result.NetPrice;
                        productsummary_result.TotalRevenue = baProductSummary_Result.TotalRevenue;
                        productsummary_result.Revpercentage = baProductSummary_Result.Revpercentage;
                        productsummary_result.FROMDate = baProductSummary_Result.FROMDate;
                        productsummary_result.Todate = baProductSummary_Result.Todate;
                        productsummary_result.UserName = baProductSummary_Result.UserName;
                        productsummary_result.StoreName = baProductSummary_Result.StoreName;
                        productsummary_result.Flag = productsummary_result.Flag;
                        productsummary_result.PS_SubStore_Name = baProductSummary_Result.PS_SubStore_Name;
                        productsummary_result.PS_Orders_ProductCode = baProductSummary_Result.PS_Orders_ProductCode;
                        productsummary_result.IsActive = baProductSummary_Result.IsActive;

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
                    var obj = db.ProductSummary_Results.Where(p => p.Id == Id).FirstOrDefault();
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
