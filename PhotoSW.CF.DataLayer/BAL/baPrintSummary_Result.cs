using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baPrintSummary_Result
        {
        public int Id { get; set; }
        public string PS_Orders_ProductType_Name { get; set; }
        public int PrintedQuantity { get; set; }
        public int PrintedSold { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<printsummary_result> lst_printsummary = new List<printsummary_result>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    printsummary_result printsummary_result = new printsummary_result();

                    printsummary_result.Id = 1;
                    printsummary_result.PS_Orders_ProductType_Name = "";
                    printsummary_result.PrintedQuantity = 5;
                    printsummary_result.PrintedSold = 3;
                    printsummary_result.IsActive = true;

                    lst_printsummary.Add(printsummary_result);

                    var Id = lst_printsummary.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PrintSummary_Results.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.PrintSummary_Results.AddRange(lst_printsummary);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.PrintSummary_Results.AddRange(lst_printsummary);
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

        public static baPrintSummary_Result GetPrintSummary_ResultDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrintSummary_Results.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPrintSummary_Result
                        {
                        Id = p.Id,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        PrintedQuantity = p.PrintedQuantity,
                        PrintedSold = p.PrintedSold,
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

        public static List<baPrintSummary_Result> GetPrintSummary_ResultData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrintSummary_Results.Where(p => p.IsActive == true).Select(p => new baPrintSummary_Result
                        {
                        Id = p.Id,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        PrintedQuantity = p.PrintedQuantity,
                        PrintedSold = p.PrintedSold,
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
        public static bool Insert ( baPrintSummary_Result baPrintSummary_Result )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    printsummary_result printsummary_result = new printsummary_result();

                    printsummary_result.Id = baPrintSummary_Result.Id;
                    printsummary_result.PS_Orders_ProductType_Name = baPrintSummary_Result.PS_Orders_ProductType_Name;
                    printsummary_result.PrintedQuantity = baPrintSummary_Result.PrintedQuantity;
                    printsummary_result.PrintedSold = baPrintSummary_Result.PrintedSold;
                    printsummary_result.IsActive = baPrintSummary_Result.IsActive;

                    db.PrintSummary_Results.Add(printsummary_result);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPrintSummary_Result baPrintSummary_Result )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrintSummary_Results.Where(p => p.Id == baPrintSummary_Result.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        printsummary_result printsummary_result = new printsummary_result();

                        printsummary_result.Id = baPrintSummary_Result.Id;
                        printsummary_result.PS_Orders_ProductType_Name = baPrintSummary_Result.PS_Orders_ProductType_Name;
                        printsummary_result.PrintedQuantity = baPrintSummary_Result.PrintedQuantity;
                        printsummary_result.PrintedSold = baPrintSummary_Result.PrintedSold;
                        printsummary_result.IsActive = baPrintSummary_Result.IsActive;

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
                    var obj = db.PrintSummary_Results.Where(p => p.Id == Id).FirstOrDefault();
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
