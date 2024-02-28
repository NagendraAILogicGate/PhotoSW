using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baGetPhotgrapherPerformance_Result
        {
        public long Id { get; set; }
        public int NumberofCapture { get; set; }
        public int NumberofSales { get; set; }
        public int ImageSold { get; set; }
        public decimal Revenue { get; set; }
        public string PS_Location_Name { get; set; }
        public string StoreName { get; set; }
        public string Printedby { get; set; }
        public int PS_Location_pkey { get; set; }
        public string PS_SubStore_Name { get; set; }
        public int Shots_Previewed { get; set; }
        public string DataFlag { get; set; }
        public DateTime FromDate1 { get; set; }
        public DateTime ToDate1 { get; set; }
        public DateTime FromDate2 { get; set; }
        public DateTime ToDate2 { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal SellThru { get; set; }
        public string defaultCurrency { get; set; }
        public decimal TotalSiteRevenue { get; set; }
        public string UserName { get; set; }
        public int PS_User_pkey { get; set; }

        public int PrintImageSold { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<getphotgrapherperformance_result> lst_getphotgrapherperformance_result = new List<getphotgrapherperformance_result>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    getphotgrapherperformance_result getphotgrapherperformance_result = new getphotgrapherperformance_result();

                    getphotgrapherperformance_result.Id = 1;
                    getphotgrapherperformance_result.NumberofCapture = 2;
                    getphotgrapherperformance_result.NumberofSales = 1;
                    getphotgrapherperformance_result.ImageSold = 2;
                    getphotgrapherperformance_result.Revenue = 3;
                    getphotgrapherperformance_result.PS_Location_Name = "";
                    getphotgrapherperformance_result.StoreName = "";
                    getphotgrapherperformance_result.Printedby = "";
                    getphotgrapherperformance_result.PS_Location_pkey = 1;
                    getphotgrapherperformance_result.PS_SubStore_Name = "";
                    getphotgrapherperformance_result.Shots_Previewed = 2;
                    getphotgrapherperformance_result.DataFlag = "";
                    getphotgrapherperformance_result.FromDate1 = DateTime.Now;
                    getphotgrapherperformance_result.ToDate1 = DateTime.Now;
                    getphotgrapherperformance_result.FromDate2 = DateTime.Now;
                    getphotgrapherperformance_result.ToDate2 = DateTime.Now;
                    getphotgrapherperformance_result.AveragePrice = 2;
                    getphotgrapherperformance_result.SellThru = 3;
                    getphotgrapherperformance_result.defaultCurrency = "";
                    getphotgrapherperformance_result.TotalSiteRevenue = 2;
                    getphotgrapherperformance_result.UserName = "";
                    getphotgrapherperformance_result.PS_User_pkey = 2;
                    getphotgrapherperformance_result.PrintImageSold = 2;
                    getphotgrapherperformance_result.IsActive = true;

                    lst_getphotgrapherperformance_result.Add(getphotgrapherperformance_result);

                    var Id = lst_getphotgrapherperformance_result.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.GetLocationPerformance_Results.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.GetPhotgrapherPerformance_Results.AddRange(lst_getphotgrapherperformance_result);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.GetPhotgrapherPerformance_Results.AddRange(lst_getphotgrapherperformance_result);
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

        public static baGetPhotgrapherPerformance_Result GetPhotgrapherPerformance_ResultDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.GetPhotgrapherPerformance_Results.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baGetPhotgrapherPerformance_Result
                        {
                        Id = p.Id,
                        NumberofCapture = p.NumberofCapture,
                        NumberofSales = p.NumberofSales,
                        ImageSold = p.ImageSold,
                        Revenue = p.Revenue,
                        PS_Location_Name = p.PS_Location_Name,
                        StoreName = p.StoreName,
                        Printedby = p.Printedby,
                        PS_Location_pkey = p.PS_Location_pkey,
                        PS_SubStore_Name = p.PS_SubStore_Name,
                        Shots_Previewed = p.Shots_Previewed,
                        DataFlag = p.DataFlag,
                        FromDate1 = p.FromDate1,
                        ToDate1 = p.ToDate1,
                        FromDate2 = p.FromDate2,
                        ToDate2 = p.ToDate2,
                        AveragePrice = p.AveragePrice,
                        SellThru = p.SellThru,
                        defaultCurrency = p.defaultCurrency,
                        TotalSiteRevenue = p.TotalSiteRevenue,
                        UserName = p.UserName,
                        PS_User_pkey = p.PS_User_pkey,
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

        public static List<baGetPhotgrapherPerformance_Result> GetPhotgrapherPerformance_ResultData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GetPhotgrapherPerformance_Results.Where(p => p.IsActive == true).Select(p => new baGetPhotgrapherPerformance_Result
                        {
                        Id = p.Id,
                        NumberofCapture = p.NumberofCapture,
                        NumberofSales = p.NumberofSales,
                        ImageSold = p.ImageSold,
                        Revenue = p.Revenue,
                        PS_Location_Name = p.PS_Location_Name,
                        StoreName = p.StoreName,
                        Printedby = p.Printedby,
                        PS_Location_pkey = p.PS_Location_pkey,
                        PS_SubStore_Name = p.PS_SubStore_Name,
                        Shots_Previewed = p.Shots_Previewed,
                        DataFlag = p.DataFlag,
                        FromDate1 = p.FromDate1,
                        ToDate1 = p.ToDate1,
                        FromDate2 = p.FromDate2,
                        ToDate2 = p.ToDate2,
                        AveragePrice = p.AveragePrice,
                        SellThru = p.SellThru,
                        defaultCurrency = p.defaultCurrency,
                        TotalSiteRevenue = p.TotalSiteRevenue,
                        UserName = p.UserName,
                        PS_User_pkey = p.PS_User_pkey,
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

        public static bool Insert ( baGetPhotgrapherPerformance_Result baGetPhotgrapherPerformance_Result )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    getphotgrapherperformance_result getphotgrapherperformance_result = new getphotgrapherperformance_result();

                    getphotgrapherperformance_result.Id = getphotgrapherperformance_result.Id;
                    getphotgrapherperformance_result.NumberofCapture = getphotgrapherperformance_result.NumberofCapture;
                    getphotgrapherperformance_result.NumberofSales = getphotgrapherperformance_result.NumberofSales;
                    getphotgrapherperformance_result.ImageSold = getphotgrapherperformance_result.ImageSold;
                    getphotgrapherperformance_result.Revenue = getphotgrapherperformance_result.Revenue;
                    getphotgrapherperformance_result.PS_Location_Name = getphotgrapherperformance_result.PS_Location_Name;
                    getphotgrapherperformance_result.StoreName = getphotgrapherperformance_result.StoreName;
                    getphotgrapherperformance_result.Printedby = getphotgrapherperformance_result.Printedby;
                    getphotgrapherperformance_result.PS_Location_pkey = getphotgrapherperformance_result.PS_Location_pkey;
                    getphotgrapherperformance_result.PS_SubStore_Name = getphotgrapherperformance_result.PS_SubStore_Name;
                    getphotgrapherperformance_result.Shots_Previewed = getphotgrapherperformance_result.Shots_Previewed;
                    getphotgrapherperformance_result.DataFlag = getphotgrapherperformance_result.DataFlag;
                    getphotgrapherperformance_result.FromDate1 = getphotgrapherperformance_result.FromDate1;
                    getphotgrapherperformance_result.ToDate1 = getphotgrapherperformance_result.ToDate1;
                    getphotgrapherperformance_result.FromDate2 = getphotgrapherperformance_result.FromDate2;
                    getphotgrapherperformance_result.ToDate2 = getphotgrapherperformance_result.ToDate2;
                    getphotgrapherperformance_result.AveragePrice = getphotgrapherperformance_result.AveragePrice;
                    getphotgrapherperformance_result.SellThru = getphotgrapherperformance_result.SellThru;
                    getphotgrapherperformance_result.defaultCurrency = getphotgrapherperformance_result.defaultCurrency;
                    getphotgrapherperformance_result.TotalSiteRevenue = getphotgrapherperformance_result.TotalSiteRevenue;
                    getphotgrapherperformance_result.UserName = getphotgrapherperformance_result.UserName;
                    getphotgrapherperformance_result.PS_User_pkey = getphotgrapherperformance_result.PS_User_pkey;
                    getphotgrapherperformance_result.IsActive = getphotgrapherperformance_result.IsActive;

                    db.GetPhotgrapherPerformance_Results.Add(getphotgrapherperformance_result);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baGetPhotgrapherPerformance_Result baGetPhotgrapherPerformance_Result )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GetPhotgrapherPerformance_Results.Where(p => p.Id == baGetPhotgrapherPerformance_Result.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        getphotgrapherperformance_result getphotgrapherperformance_result = new getphotgrapherperformance_result();

                        getphotgrapherperformance_result.Id = getphotgrapherperformance_result.Id;
                        getphotgrapherperformance_result.NumberofCapture = getphotgrapherperformance_result.NumberofCapture;
                        getphotgrapherperformance_result.NumberofSales = getphotgrapherperformance_result.NumberofSales;
                        getphotgrapherperformance_result.ImageSold = getphotgrapherperformance_result.ImageSold;
                        getphotgrapherperformance_result.Revenue = getphotgrapherperformance_result.Revenue;
                        getphotgrapherperformance_result.PS_Location_Name = getphotgrapherperformance_result.PS_Location_Name;
                        getphotgrapherperformance_result.StoreName = getphotgrapherperformance_result.StoreName;
                        getphotgrapherperformance_result.Printedby = getphotgrapherperformance_result.Printedby;
                        getphotgrapherperformance_result.PS_Location_pkey = getphotgrapherperformance_result.PS_Location_pkey;
                        getphotgrapherperformance_result.PS_SubStore_Name = getphotgrapherperformance_result.PS_SubStore_Name;
                        getphotgrapherperformance_result.Shots_Previewed = getphotgrapherperformance_result.Shots_Previewed;
                        getphotgrapherperformance_result.DataFlag = getphotgrapherperformance_result.DataFlag;
                        getphotgrapherperformance_result.FromDate1 = getphotgrapherperformance_result.FromDate1;
                        getphotgrapherperformance_result.ToDate1 = getphotgrapherperformance_result.ToDate1;
                        getphotgrapherperformance_result.FromDate2 = getphotgrapherperformance_result.FromDate2;
                        getphotgrapherperformance_result.ToDate2 = getphotgrapherperformance_result.ToDate2;
                        getphotgrapherperformance_result.AveragePrice = getphotgrapherperformance_result.AveragePrice;
                        getphotgrapherperformance_result.SellThru = getphotgrapherperformance_result.SellThru;
                        getphotgrapherperformance_result.defaultCurrency = getphotgrapherperformance_result.defaultCurrency;
                        getphotgrapherperformance_result.TotalSiteRevenue = getphotgrapherperformance_result.TotalSiteRevenue;
                        getphotgrapherperformance_result.UserName = getphotgrapherperformance_result.UserName;
                        getphotgrapherperformance_result.PS_User_pkey = getphotgrapherperformance_result.PS_User_pkey;
                        getphotgrapherperformance_result.IsActive = getphotgrapherperformance_result.IsActive;

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
                    var obj = db.GetPhotgrapherPerformance_Results.Where(p => p.Id == Id).FirstOrDefault();
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
