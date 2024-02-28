using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baPrinterDetailsInfo
        {
        public long Id { get; set; }
        public string PrinterName { get; set; }
        public int PrinterID { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<printerdetailsinfo> lst_printerdetailsinfo = new List<printerdetailsinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    printerdetailsinfo printerdetailsinfo = new printerdetailsinfo();

                    printerdetailsinfo.Id = 1;
                    printerdetailsinfo.PrinterName = "";
                    printerdetailsinfo.PrinterID = 3;
                    printerdetailsinfo.IsActive = true;

                    lst_printerdetailsinfo.Add(printerdetailsinfo);

                    var Id = lst_printerdetailsinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PrinterDetailsInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.PrinterDetailsInfos.AddRange(lst_printerdetailsinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.PrinterDetailsInfos.AddRange(lst_printerdetailsinfo);
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

        public static baPrinterDetailsInfo GetPrinterDetailsInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrinterDetailsInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPrinterDetailsInfo
                        {
                        Id = p.Id,
                        PrinterName = p.PrinterName,
                        PrinterID = p.PrinterID,
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

        public static List<baPrinterDetailsInfo> GetPrinterDetailsInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrinterDetailsInfos.Where(p => p.IsActive == true).Select(p => new baPrinterDetailsInfo
                        {
                        Id = p.Id,
                        PrinterName = p.PrinterName,
                        PrinterID = p.PrinterID,
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

        public static bool Insert ( baPrinterDetailsInfo baPrinterDetailsInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    printerdetailsinfo printerdetailsinfo = new printerdetailsinfo();

                    printerdetailsinfo.Id = printerdetailsinfo.Id;
                    printerdetailsinfo.PrinterName = printerdetailsinfo.PrinterName;
                    printerdetailsinfo.PrinterID = printerdetailsinfo.PrinterID;
                    printerdetailsinfo.IsActive = printerdetailsinfo.IsActive;

                    db.PrinterDetailsInfos.Add(printerdetailsinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPrinterDetailsInfo baPrinterDetailsInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrinterDetailsInfos.Where(p => p.Id == baPrinterDetailsInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        printerdetailsinfo printerdetailsinfo = new printerdetailsinfo();

                        printerdetailsinfo.Id = printerdetailsinfo.Id;
                        printerdetailsinfo.PrinterName = printerdetailsinfo.PrinterName;
                        printerdetailsinfo.PrinterID = printerdetailsinfo.PrinterID;
                        printerdetailsinfo.IsActive = printerdetailsinfo.IsActive;

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
                    var obj = db.PrinterDetailsInfos.Where(p => p.Id == Id).FirstOrDefault();
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
