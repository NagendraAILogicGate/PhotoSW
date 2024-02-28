using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baPrinterDetails
        {
        public long Id { get; set; }
        public string PrinterName { get; set; }
       // public ObservableCollection<printerjobinfo> PrinterJOb { get; set; }
        public string PrinterStatus { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<printerdetails> lst_printerdetails = new List<printerdetails>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    printerdetails printerdetails = new printerdetails();

                    printerdetails.Id = 1;
                    printerdetails.PrinterName = "";
                    printerdetails.PrinterStatus = "";
                    printerdetails.IsActive = true;

                    lst_printerdetails.Add(printerdetails);

                    var Id = lst_printerdetails.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PrinterDetailses.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.PrinterDetailses.AddRange(lst_printerdetails);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.PrinterDetailses.AddRange(lst_printerdetails);
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

        public static baPrinterDetails GetPrinterDetailsDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.PrinterDetailses.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPrinterDetails
                        {
                        Id = p.Id,
                        PrinterName = p.PrinterName,
                        PrinterStatus = p.PrinterStatus,
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

        public static List<baPrinterDetails> GetPrinterDetailsData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrinterDetailses.Where(p => p.IsActive == true).Select(p => new baPrinterDetails
                        {
                        Id = p.Id,
                        PrinterName = p.PrinterName,
                        PrinterStatus = p.PrinterStatus,
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

        public static bool Insert ( baPrinterDetails baPrinterDetails )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    printerdetails printerdetails = new printerdetails();

                    printerdetails.Id = printerdetails.Id;
                    printerdetails.PrinterName = printerdetails.PrinterName;
                    printerdetails.PrinterStatus = printerdetails.PrinterStatus;
                    printerdetails.IsActive = printerdetails.IsActive;

                    db.PrinterDetailses.Add(printerdetails);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPrinterDetails baPrinterDetails )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrinterDetailses.Where(p => p.Id == baPrinterDetails.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        printerdetails printerdetails = new printerdetails();

                        printerdetails.Id = printerdetails.Id;
                        printerdetails.PrinterName = printerdetails.PrinterName;
                        printerdetails.PrinterStatus = printerdetails.PrinterStatus;
                        printerdetails.IsActive = printerdetails.IsActive;

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
                    var obj = db.PrinterDetailses.Where(p => p.Id == Id).FirstOrDefault();
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
