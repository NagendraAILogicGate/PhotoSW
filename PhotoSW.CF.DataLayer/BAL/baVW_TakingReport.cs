using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baVW_TakingReport
        {
        public int Id { get; set; }
        public string PS_Orders_Number { get; set; }
        public DateTime? PS_Orders_Date { get; set; }
        public string PS_Orders_PaymentMode { get; set; }
        public string PS_Orders_Currency_ID { get; set; }
        public decimal NetCost { get; set; }
        public string ItemDetail { get; set; }
        public int State { get; set; }
        public int PS_Orders_pkey { get; set; }
        public string s1 { get; set; }
        public string PS_SubStore_Name { get; set; }
        public string ItemCode { get; set; }
        public bool? IsActive { get; set; }



        public static bool Marge ()
            {
            List<vw_takingreport> lst_vw_takingreport = new List<vw_takingreport>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    vw_takingreport vw_takingreport = new vw_takingreport();

                    vw_takingreport.Id = 1;
                    vw_takingreport.DG_Orders_Number = "2";
                    vw_takingreport.DG_Orders_Date = DateTime.Now;
                    vw_takingreport.DG_Orders_PaymentMode = "3";
                    vw_takingreport.DG_Orders_Currency_ID = "101";
                    vw_takingreport.NetCost = 4;
                    vw_takingreport.ItemDetail = "ItemDetail";
                    vw_takingreport.State = 2;
                    vw_takingreport.DG_Orders_pkey = 6;
                    vw_takingreport.s1 = "s1";
                    vw_takingreport.DG_SubStore_Name = "Bhopal";
                    vw_takingreport.ItemCode = "12345";                    
                    vw_takingreport.IsActive = true;

                    lst_vw_takingreport.Add(vw_takingreport);

                    var Id = lst_vw_takingreport.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.vw_TakingReports.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.vw_TakingReports.AddRange(lst_vw_takingreport);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.vw_TakingReports.AddRange(lst_vw_takingreport);
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

        public static baVW_TakingReport GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.vw_TakingReports.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baVW_TakingReport
                        {
                        Id = p.Id,
                        PS_Orders_Number = p.DG_Orders_Number,
                        PS_Orders_Date = p.DG_Orders_Date,
                        PS_Orders_PaymentMode = p.DG_Orders_PaymentMode,
                        PS_Orders_Currency_ID = p.DG_Orders_Currency_ID,
                        NetCost = p.NetCost,
                        ItemDetail = p.ItemDetail,
                        State = p.State,
                        PS_Orders_pkey = p.DG_Orders_pkey,
                        s1 = p.s1,
                        PS_SubStore_Name = p.DG_SubStore_Name,
                        ItemCode = p.ItemCode,                        
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

        public static List<baVW_TakingReport> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.vw_TakingReports.Where(p => p.IsActive == true).Select(p => new baVW_TakingReport
                        {
                        Id = p.Id,
                        PS_Orders_Number = p.DG_Orders_Number,
                        PS_Orders_Date = p.DG_Orders_Date,
                        PS_Orders_PaymentMode = p.DG_Orders_PaymentMode,
                        PS_Orders_Currency_ID = p.DG_Orders_Currency_ID,
                        NetCost = p.NetCost,
                        ItemDetail = p.ItemDetail,
                        State = p.State,
                        PS_Orders_pkey = p.DG_Orders_pkey,
                        s1 = p.s1,
                        PS_SubStore_Name = p.DG_SubStore_Name,
                        ItemCode = p.ItemCode,
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

        public static bool Insert ( baVW_TakingReport baVW_TakingReport )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    vw_takingreport vw_takingreport = new vw_takingreport();

                    vw_takingreport.Id = baVW_TakingReport.Id;
                    vw_takingreport.DG_Orders_Number = baVW_TakingReport.PS_Orders_Number;
                    vw_takingreport.DG_Orders_Date = baVW_TakingReport.PS_Orders_Date;
                    vw_takingreport.DG_Orders_PaymentMode = baVW_TakingReport.PS_Orders_PaymentMode;
                    vw_takingreport.DG_Orders_Currency_ID = baVW_TakingReport.PS_Orders_Currency_ID;
                    vw_takingreport.NetCost = baVW_TakingReport.NetCost;
                    vw_takingreport.ItemDetail = baVW_TakingReport.ItemDetail;
                    vw_takingreport.State = baVW_TakingReport.State;
                    vw_takingreport.DG_Orders_pkey = baVW_TakingReport.PS_Orders_pkey;
                    vw_takingreport.s1 = baVW_TakingReport.s1;
                    vw_takingreport.DG_SubStore_Name = baVW_TakingReport.PS_SubStore_Name;
                    vw_takingreport.ItemCode = baVW_TakingReport.ItemCode;
                    vw_takingreport.IsActive = baVW_TakingReport.IsActive;

                    db.vw_TakingReports.Add(vw_takingreport);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baVW_TakingReport baVW_TakingReport )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.vw_TakingReports.Where(p => p.Id == baVW_TakingReport.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        vw_takingreport vw_takingreport = new vw_takingreport();

                        vw_takingreport.Id = baVW_TakingReport.Id;
                        vw_takingreport.DG_Orders_Number = baVW_TakingReport.PS_Orders_Number;
                        vw_takingreport.DG_Orders_Date = baVW_TakingReport.PS_Orders_Date;
                        vw_takingreport.DG_Orders_PaymentMode = baVW_TakingReport.PS_Orders_PaymentMode;
                        vw_takingreport.DG_Orders_Currency_ID = baVW_TakingReport.PS_Orders_Currency_ID;
                        vw_takingreport.NetCost = baVW_TakingReport.NetCost;
                        vw_takingreport.ItemDetail = baVW_TakingReport.ItemDetail;
                        vw_takingreport.State = baVW_TakingReport.State;
                        vw_takingreport.DG_Orders_pkey = baVW_TakingReport.PS_Orders_pkey;
                        vw_takingreport.s1 = baVW_TakingReport.s1;
                        vw_takingreport.DG_SubStore_Name = baVW_TakingReport.PS_SubStore_Name;
                        vw_takingreport.ItemCode = baVW_TakingReport.ItemCode;
                        vw_takingreport.IsActive = baVW_TakingReport.IsActive;

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
                    var obj = db.vw_TakingReports.Where(p => p.Id == Id).FirstOrDefault();
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
