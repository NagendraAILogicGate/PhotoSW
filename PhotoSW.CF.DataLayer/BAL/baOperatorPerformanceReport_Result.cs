
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baOperatorPerformanceReport_Result
        {
        public long Id { get; set; }
        public string CurrencySymbol { get; set; }
        public string StoreName { get; set; }
        public string UserName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Data1 { get; set; }
        public decimal Revenue { get; set; }
        public long TotalSale { get; set; }
        public long Images_Sold { get; set; }
        public int Capture { get; set; }
        public int Shots_Previewed { get; set; }
        public int TotalBurned { get; set; }
        public string OperatorName { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<operatorperformancereport_result> lst_operatorperformancereport = new List<operatorperformancereport_result>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    operatorperformancereport_result operatorperformancereport_result = new operatorperformancereport_result();

                    operatorperformancereport_result.Id = 1;
                    operatorperformancereport_result.CurrencySymbol = "";
                    operatorperformancereport_result.StoreName = "";
                    operatorperformancereport_result.UserName = "";
                    operatorperformancereport_result.FromDate = DateTime.Now;
                    operatorperformancereport_result.ToDate = DateTime.Now;
                    operatorperformancereport_result.Data1 = 2;
                    operatorperformancereport_result.Revenue = 2;
                    operatorperformancereport_result.TotalSale = 5;
                    operatorperformancereport_result.Images_Sold = 3;
                    operatorperformancereport_result.Capture = 4;
                    operatorperformancereport_result.Shots_Previewed = 4;
                    operatorperformancereport_result.TotalBurned = 5;
                    operatorperformancereport_result.OperatorName = "";
                    operatorperformancereport_result.IsActive = true;


                    lst_operatorperformancereport.Add(operatorperformancereport_result);

                    var Id = lst_operatorperformancereport.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.OperatorPerformanceReport_Results.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.OperatorPerformanceReport_Results.AddRange(lst_operatorperformancereport);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.OperatorPerformanceReport_Results.AddRange(lst_operatorperformancereport);
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

        public static baOperatorPerformanceReport_Result GetOperatorPerformanceReport_ResultById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OperatorPerformanceReport_Results.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baOperatorPerformanceReport_Result
                        {

                        Id = p.Id,
                        CurrencySymbol = p.CurrencySymbol,
                        StoreName = p.StoreName,
                        UserName = p.UserName,
                        FromDate = p.FromDate,
                        ToDate = p.ToDate,
                        Data1 = p.Data1,
                        Revenue = p.Revenue,
                        TotalSale = p.TotalSale,
                        Images_Sold = p.Images_Sold,
                        Capture = p.Capture,
                        Shots_Previewed = p.Shots_Previewed,
                        TotalBurned = p.TotalBurned,
                        OperatorName = p.OperatorName,
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

        public static List<baOperatorPerformanceReport_Result> GetOperatorPerformanceReport_ResultData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OperatorPerformanceReport_Results.Where(p => p.IsActive == true).Select(p => new baOperatorPerformanceReport_Result
                        {
                        Id = p.Id,
                        CurrencySymbol = p.CurrencySymbol,
                        StoreName = p.StoreName,
                        UserName = p.UserName,
                        FromDate = p.FromDate,
                        ToDate = p.ToDate,
                        Data1 = p.Data1,
                        Revenue = p.Revenue,
                        TotalSale = p.TotalSale,
                        Images_Sold = p.Images_Sold,
                        Capture = p.Capture,
                        Shots_Previewed = p.Shots_Previewed,
                        TotalBurned = p.TotalBurned,
                        OperatorName = p.OperatorName,
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

        public static bool Insert ( baOperatorPerformanceReport_Result baOperatorPerformanceReport_Result )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    operatorperformancereport_result operatorperformancereport_result = new operatorperformancereport_result();

                    operatorperformancereport_result.Id = baOperatorPerformanceReport_Result.Id;
                    operatorperformancereport_result.CurrencySymbol = baOperatorPerformanceReport_Result.CurrencySymbol;
                    operatorperformancereport_result.StoreName = baOperatorPerformanceReport_Result.StoreName;
                    operatorperformancereport_result.UserName = baOperatorPerformanceReport_Result.UserName;
                    operatorperformancereport_result.FromDate = baOperatorPerformanceReport_Result.FromDate;
                    operatorperformancereport_result.ToDate = baOperatorPerformanceReport_Result.ToDate;
                    operatorperformancereport_result.Data1 = baOperatorPerformanceReport_Result.Data1;
                    operatorperformancereport_result.Revenue = baOperatorPerformanceReport_Result.Revenue;
                    operatorperformancereport_result.TotalSale = baOperatorPerformanceReport_Result.TotalSale;
                    operatorperformancereport_result.Images_Sold = baOperatorPerformanceReport_Result.Images_Sold;
                    operatorperformancereport_result.Capture = baOperatorPerformanceReport_Result.Capture;
                    operatorperformancereport_result.Shots_Previewed = baOperatorPerformanceReport_Result.Shots_Previewed;
                    operatorperformancereport_result.TotalBurned = baOperatorPerformanceReport_Result.TotalBurned;
                    operatorperformancereport_result.OperatorName = baOperatorPerformanceReport_Result.OperatorName;
                    operatorperformancereport_result.IsActive = baOperatorPerformanceReport_Result.IsActive;

                    db.OperatorPerformanceReport_Results.Add(operatorperformancereport_result);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baOperatorPerformanceReport_Result baOperatorPerformanceReport_Result )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OperatorPerformanceReport_Results.Where(p => p.Id == baOperatorPerformanceReport_Result.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        operatorperformancereport_result operatorperformancereport_result = new operatorperformancereport_result();

                        operatorperformancereport_result.Id = baOperatorPerformanceReport_Result.Id;
                        operatorperformancereport_result.CurrencySymbol = baOperatorPerformanceReport_Result.CurrencySymbol;
                        operatorperformancereport_result.StoreName = baOperatorPerformanceReport_Result.StoreName;
                        operatorperformancereport_result.UserName = baOperatorPerformanceReport_Result.UserName;
                        operatorperformancereport_result.FromDate = baOperatorPerformanceReport_Result.FromDate;
                        operatorperformancereport_result.ToDate = baOperatorPerformanceReport_Result.ToDate;
                        operatorperformancereport_result.Data1 = baOperatorPerformanceReport_Result.Data1;
                        operatorperformancereport_result.Revenue = baOperatorPerformanceReport_Result.Revenue;
                        operatorperformancereport_result.TotalSale = baOperatorPerformanceReport_Result.TotalSale;
                        operatorperformancereport_result.Images_Sold = baOperatorPerformanceReport_Result.Images_Sold;
                        operatorperformancereport_result.Capture = baOperatorPerformanceReport_Result.Capture;
                        operatorperformancereport_result.Shots_Previewed = baOperatorPerformanceReport_Result.Shots_Previewed;
                        operatorperformancereport_result.TotalBurned = baOperatorPerformanceReport_Result.TotalBurned;
                        operatorperformancereport_result.OperatorName = baOperatorPerformanceReport_Result.OperatorName;
                        operatorperformancereport_result.IsActive = baOperatorPerformanceReport_Result.IsActive;

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
                    var obj = db.OperatorPerformanceReport_Results.Where(p => p.Id == Id).FirstOrDefault();
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
