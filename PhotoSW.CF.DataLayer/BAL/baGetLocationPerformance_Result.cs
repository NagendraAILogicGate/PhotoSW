using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;


namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baGetLocationPerformance_Result
        {
        public long Id { get; set; }
        public string selectedSubStore { get; set; }
        public int Number_of_Capture { get; set; }
        public int Number_of_Sales { get; set; }
        public int ImageSold { get; set; }
        public decimal Revenue { get; set; }
        public string PS_Location_Name { get; set; }
        public string StoreName { get; set; }
        public string Printedby { get; set; }
        public int PS_Location_pkey { get; set; }
        public string PS_SubStore_Name { get; set; }
        public int Shots_Previewed { get; set; }
        public string DataFlag { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime SecondFromDate { get; set; }
        public DateTime SecondToDate { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal SellThru { get; set; }
        public string defaultCurrency { get; set; }
        public decimal TotalSiteRevenue { get; set; }
        public string UserName { get; set; }
        public int PS_User_pkey { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<getlocationperformance_result> lst_getlocationperformance_result = new List<getlocationperformance_result>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    getlocationperformance_result getlocationperformance_result = new getlocationperformance_result();

                    getlocationperformance_result.Id = 1;
                    getlocationperformance_result.selectedSubStore = "";
                    getlocationperformance_result.Number_of_Capture = 1;
                    getlocationperformance_result.Number_of_Sales = 2;
                    getlocationperformance_result.ImageSold = 3;
                    getlocationperformance_result.Revenue = 2;
                    getlocationperformance_result.PS_Location_Name = "";
                    getlocationperformance_result.StoreName = "";
                    getlocationperformance_result.Printedby = "";
                    getlocationperformance_result.PS_Location_pkey = 2;
                    getlocationperformance_result.PS_SubStore_Name = "";
                    getlocationperformance_result.Shots_Previewed = 2;
                    getlocationperformance_result.DataFlag = "";
                    getlocationperformance_result.FromDate = DateTime.Now;
                    getlocationperformance_result.ToDate = DateTime.Now;
                    getlocationperformance_result.SecondFromDate = DateTime.Now;
                    getlocationperformance_result.SecondToDate = DateTime.Now;
                    getlocationperformance_result.AveragePrice = 3;
                    getlocationperformance_result.SellThru = 2;
                    getlocationperformance_result.defaultCurrency = "";
                    getlocationperformance_result.TotalSiteRevenue = 4;
                    getlocationperformance_result.UserName = "";
                    getlocationperformance_result.PS_User_pkey = 1;
                    getlocationperformance_result.IsActive = true;

                    lst_getlocationperformance_result.Add(getlocationperformance_result);

                    var Id = lst_getlocationperformance_result.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.GetLocationPerformance_Results.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.GetLocationPerformance_Results.AddRange(lst_getlocationperformance_result);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.GetLocationPerformance_Results.AddRange(lst_getlocationperformance_result);
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

        public static baGetLocationPerformance_Result GetLocationPerformance_ResultDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.GetLocationPerformance_Results.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baGetLocationPerformance_Result
                        {
                        Id = p.Id,
                        selectedSubStore = p.selectedSubStore,
                        Number_of_Capture = p.Number_of_Capture,
                        Number_of_Sales = p.Number_of_Sales,
                        ImageSold = p.ImageSold,
                        Revenue = p.Revenue,
                        PS_Location_Name = p.PS_Location_Name,
                        StoreName = p.StoreName,
                        Printedby = p.Printedby,
                        PS_Location_pkey = p.PS_Location_pkey,
                        PS_SubStore_Name = p.PS_SubStore_Name,
                        Shots_Previewed = p.Shots_Previewed,
                        DataFlag = p.DataFlag,
                        FromDate = p.FromDate,
                        ToDate = p.ToDate,
                        SecondFromDate = p.SecondFromDate,
                        SecondToDate = p.SecondToDate,
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

        public static List<baGetLocationPerformance_Result> GetLocationPerformance_ResultData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GetLocationPerformance_Results.Where(p => p.IsActive == true).Select(p => new baGetLocationPerformance_Result
                        {
                        Id = p.Id,
                        selectedSubStore = p.selectedSubStore,
                        Number_of_Capture = p.Number_of_Capture,
                        Number_of_Sales = p.Number_of_Sales,
                        ImageSold = p.ImageSold,
                        Revenue = p.Revenue,
                        PS_Location_Name = p.PS_Location_Name,
                        StoreName = p.StoreName,
                        Printedby = p.Printedby,
                        PS_Location_pkey = p.PS_Location_pkey,
                        PS_SubStore_Name = p.PS_SubStore_Name,
                        Shots_Previewed = p.Shots_Previewed,
                        DataFlag = p.DataFlag,
                        FromDate = p.FromDate,
                        ToDate = p.ToDate,
                        SecondFromDate = p.SecondFromDate,
                        SecondToDate = p.SecondToDate,
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

        public static bool Insert ( baGetLocationPerformance_Result baGetLocationPerformance_Result )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    getlocationperformance_result getlocationperformance_result = new getlocationperformance_result();

                    getlocationperformance_result.Id = baGetLocationPerformance_Result.Id;
                    getlocationperformance_result.selectedSubStore = baGetLocationPerformance_Result.selectedSubStore;
                    getlocationperformance_result.Number_of_Capture = baGetLocationPerformance_Result.Number_of_Capture;
                    getlocationperformance_result.Number_of_Sales = baGetLocationPerformance_Result.Number_of_Sales;
                    getlocationperformance_result.ImageSold = baGetLocationPerformance_Result.ImageSold;
                    getlocationperformance_result.Revenue = baGetLocationPerformance_Result.Revenue;
                    getlocationperformance_result.PS_Location_Name = baGetLocationPerformance_Result.PS_Location_Name;
                    getlocationperformance_result.StoreName = baGetLocationPerformance_Result.StoreName;
                    getlocationperformance_result.Printedby = baGetLocationPerformance_Result.Printedby;
                    getlocationperformance_result.PS_Location_pkey = baGetLocationPerformance_Result.PS_Location_pkey;
                    getlocationperformance_result.PS_SubStore_Name = baGetLocationPerformance_Result.PS_SubStore_Name;
                    getlocationperformance_result.Shots_Previewed = baGetLocationPerformance_Result.Shots_Previewed;
                    getlocationperformance_result.DataFlag = baGetLocationPerformance_Result.DataFlag;
                    getlocationperformance_result.FromDate = baGetLocationPerformance_Result.FromDate;
                    getlocationperformance_result.ToDate = baGetLocationPerformance_Result.ToDate;
                    getlocationperformance_result.SecondFromDate = baGetLocationPerformance_Result.SecondFromDate;
                    getlocationperformance_result.SecondToDate = baGetLocationPerformance_Result.SecondToDate;
                    getlocationperformance_result.AveragePrice = baGetLocationPerformance_Result.AveragePrice;
                    getlocationperformance_result.SellThru = baGetLocationPerformance_Result.SellThru;
                    getlocationperformance_result.defaultCurrency = baGetLocationPerformance_Result.defaultCurrency;
                    getlocationperformance_result.TotalSiteRevenue = baGetLocationPerformance_Result.TotalSiteRevenue;
                    getlocationperformance_result.UserName = baGetLocationPerformance_Result.UserName;
                    getlocationperformance_result.PS_User_pkey = baGetLocationPerformance_Result.PS_User_pkey;
                    getlocationperformance_result.IsActive = baGetLocationPerformance_Result.IsActive;

                    db.GetLocationPerformance_Results.Add(getlocationperformance_result);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baGetLocationPerformance_Result baGetLocationPerformance_Result )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GetLocationPerformance_Results.Where(p => p.Id == baGetLocationPerformance_Result.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        getlocationperformance_result getlocationperformance_result = new getlocationperformance_result();

                        getlocationperformance_result.Id = baGetLocationPerformance_Result.Id;
                        getlocationperformance_result.selectedSubStore = baGetLocationPerformance_Result.selectedSubStore;
                        getlocationperformance_result.Number_of_Capture = baGetLocationPerformance_Result.Number_of_Capture;
                        getlocationperformance_result.Number_of_Sales = baGetLocationPerformance_Result.Number_of_Sales;
                        getlocationperformance_result.ImageSold = baGetLocationPerformance_Result.ImageSold;
                        getlocationperformance_result.Revenue = baGetLocationPerformance_Result.Revenue;
                        getlocationperformance_result.PS_Location_Name = baGetLocationPerformance_Result.PS_Location_Name;
                        getlocationperformance_result.StoreName = baGetLocationPerformance_Result.StoreName;
                        getlocationperformance_result.Printedby = baGetLocationPerformance_Result.Printedby;
                        getlocationperformance_result.PS_Location_pkey = baGetLocationPerformance_Result.PS_Location_pkey;
                        getlocationperformance_result.PS_SubStore_Name = baGetLocationPerformance_Result.PS_SubStore_Name;
                        getlocationperformance_result.Shots_Previewed = baGetLocationPerformance_Result.Shots_Previewed;
                        getlocationperformance_result.DataFlag = baGetLocationPerformance_Result.DataFlag;
                        getlocationperformance_result.FromDate = baGetLocationPerformance_Result.FromDate;
                        getlocationperformance_result.ToDate = baGetLocationPerformance_Result.ToDate;
                        getlocationperformance_result.SecondFromDate = baGetLocationPerformance_Result.SecondFromDate;
                        getlocationperformance_result.SecondToDate = baGetLocationPerformance_Result.SecondToDate;
                        getlocationperformance_result.AveragePrice = baGetLocationPerformance_Result.AveragePrice;
                        getlocationperformance_result.SellThru = baGetLocationPerformance_Result.SellThru;
                        getlocationperformance_result.defaultCurrency = baGetLocationPerformance_Result.defaultCurrency;
                        getlocationperformance_result.TotalSiteRevenue = baGetLocationPerformance_Result.TotalSiteRevenue;
                        getlocationperformance_result.UserName = baGetLocationPerformance_Result.UserName;
                        getlocationperformance_result.PS_User_pkey = baGetLocationPerformance_Result.PS_User_pkey;
                        getlocationperformance_result.IsActive = baGetLocationPerformance_Result.IsActive;

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
                    var obj = db.GetLocationPerformance_Results.Where(p => p.Id == Id).FirstOrDefault();
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
