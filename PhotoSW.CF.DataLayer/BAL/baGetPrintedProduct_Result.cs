using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baGetPrintedProduct_Result
        {
        public long Id { get; set; }
        public int PrintedQuantity { get; set; }
        public string PS_Orders_ProductType_Name { get; set; }
        public DateTime? PS_Print_Date { get; set; }
        public string PhotoNumber { get; set; }
        public string PS_SubStore_Name { get; set; }
        public string ProductCode { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<getprintedproduct_result> lst_getprintedproduct_result = new List<getprintedproduct_result>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    getprintedproduct_result getprintedproduct_result = new getprintedproduct_result();

                    getprintedproduct_result.Id = 1;
                    getprintedproduct_result.PrintedQuantity = 2;
                    getprintedproduct_result.PS_Orders_ProductType_Name = "";
                    getprintedproduct_result.PS_Print_Date = DateTime.Now;
                    getprintedproduct_result.PhotoNumber = "";
                    getprintedproduct_result.ProductCode = "";
                    getprintedproduct_result.IsActive = true;

                    lst_getprintedproduct_result.Add(getprintedproduct_result);

                    var Id = lst_getprintedproduct_result.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.GetPrintedProduct_Results.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.GetPrintedProduct_Results.AddRange(lst_getprintedproduct_result);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.GetPrintedProduct_Results.AddRange(lst_getprintedproduct_result);
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

        public static baGetPrintedProduct_Result GetPrintedProduct_ResultDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.GetPrintedProduct_Results.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baGetPrintedProduct_Result
                        {
                        Id = p.Id,
                        PrintedQuantity = p.PrintedQuantity,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        PS_Print_Date = p.PS_Print_Date,
                        PhotoNumber = p.PhotoNumber,
                        ProductCode = p.ProductCode,                       
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

        public static List<baGetPrintedProduct_Result> GetPrintedProduct_ResultData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GetPrintedProduct_Results.Where(p => p.IsActive == true).Select(p => new baGetPrintedProduct_Result
                        {
                        Id = p.Id,
                        PrintedQuantity = p.PrintedQuantity,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        PS_Print_Date = p.PS_Print_Date,
                        PhotoNumber = p.PhotoNumber,
                        ProductCode = p.ProductCode,
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

        public static bool Insert ( baGetPrintedProduct_Result baGetPrintedProduct_Result )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    getprintedproduct_result getprintedproduct_result = new getprintedproduct_result();

                    getprintedproduct_result.Id = baGetPrintedProduct_Result.Id;
                    getprintedproduct_result.PrintedQuantity = baGetPrintedProduct_Result.PrintedQuantity;
                    getprintedproduct_result.PS_Orders_ProductType_Name = baGetPrintedProduct_Result.PS_Orders_ProductType_Name;
                    getprintedproduct_result.PS_Print_Date = baGetPrintedProduct_Result.PS_Print_Date;
                    getprintedproduct_result.PhotoNumber = baGetPrintedProduct_Result.PhotoNumber;
                    getprintedproduct_result.ProductCode = baGetPrintedProduct_Result.ProductCode;
                    getprintedproduct_result.IsActive = baGetPrintedProduct_Result.IsActive;

                    db.GetPrintedProduct_Results.Add(getprintedproduct_result);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baGetPrintedProduct_Result baGetPrintedProduct_Result )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GetPrintedProduct_Results.Where(p => p.Id == baGetPrintedProduct_Result.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        getprintedproduct_result getprintedproduct_result = new getprintedproduct_result();

                        getprintedproduct_result.Id = baGetPrintedProduct_Result.Id;
                        getprintedproduct_result.PrintedQuantity = baGetPrintedProduct_Result.PrintedQuantity;
                        getprintedproduct_result.PS_Orders_ProductType_Name = baGetPrintedProduct_Result.PS_Orders_ProductType_Name;
                        getprintedproduct_result.PS_Print_Date = baGetPrintedProduct_Result.PS_Print_Date;
                        getprintedproduct_result.PhotoNumber = baGetPrintedProduct_Result.PhotoNumber;
                        getprintedproduct_result.ProductCode = baGetPrintedProduct_Result.ProductCode;
                        getprintedproduct_result.IsActive = baGetPrintedProduct_Result.IsActive;

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
                    var obj = db.GetPrintedProduct_Results.Where(p => p.Id == Id).FirstOrDefault();
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
