using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baPrinterTypeInfo
        {
        public long Id { get; set; }
        public int PrinterTypeID { get; set; }
        public string PrinterType { get; set; }
        public int ProductTypeID { get; set; }
        public string ProductName { get; set; }
        public bool IsActive { get; set; }

        public static bool Marge ()
            {
            List<printertypeinfo> lst_printertypeinfo = new List<printertypeinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    printertypeinfo printertypeinfo = new printertypeinfo();

                   // printertypeinfo.Id = 1;
                    printertypeinfo.PrinterTypeID = 1;
                    printertypeinfo.PrinterType = "Office Printer";
                    printertypeinfo.ProductTypeID = 3;
                    printertypeinfo.ProductName = "Test";
                    printertypeinfo.IsActive = true;

                    lst_printertypeinfo.Add(printertypeinfo);

                    //var Id = lst_printertypeinfo.Where(t => t.Id == 1).First().Id;
                    //var IsExist = db.PrinterTypeInfos.Where(p => p.Id == Id).ToList();
                    var Id = lst_printertypeinfo.Where(t => t.PrinterTypeID == 1).First().PrinterTypeID;
                    var IsExist = db.PrinterTypeInfos.Where(p => p.PrinterTypeID == Id).ToList();
                    if(IsExist == null)
                        {
                        db.PrinterTypeInfos.AddRange(lst_printertypeinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.PrinterTypeInfos.AddRange(lst_printertypeinfo);
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

        public static baPrinterTypeInfo GetPrinterTypeInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrinterTypeInfos.Where(p => p.PrinterTypeID == Id && p.IsActive == true).Select(p => new baPrinterTypeInfo
                        {
                       // Id = p.Id,
                        PrinterTypeID = p.PrinterTypeID,
                        PrinterType = p.PrinterType,
                        ProductTypeID = p.ProductTypeID,
                        ProductName = p.ProductName,
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

        public static List<baPrinterTypeInfo> GetPrinterTypeInfoInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrinterTypeInfos.Where(p => p.IsActive == true).Select(p => new baPrinterTypeInfo
                        {
                      //  Id = p.Id,
                        PrinterTypeID = p.PrinterTypeID,
                        PrinterType = p.PrinterType,
                        ProductTypeID = p.ProductTypeID,
                        ProductName = p.ProductName,
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

        public static bool Insert ( baPrinterTypeInfo baPrinterTypeInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    printertypeinfo printertypeinfo = new printertypeinfo();

                  //  printertypeinfo.Id = baPrinterTypeInfo.Id;
                    printertypeinfo.PrinterTypeID = baPrinterTypeInfo.PrinterTypeID;
                    printertypeinfo.PrinterType = baPrinterTypeInfo.PrinterType;
                    printertypeinfo.ProductTypeID = baPrinterTypeInfo.ProductTypeID;
                    printertypeinfo.ProductName = baPrinterTypeInfo.ProductName;
                    printertypeinfo.IsActive = baPrinterTypeInfo.IsActive;

                    db.PrinterTypeInfos.Add(printertypeinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPrinterTypeInfo baPrinterTypeInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                   // var obj = db.PrinterTypeInfos.Where(p => p.Id == baPrinterTypeInfo.Id).FirstOrDefault();
                    var obj = db.PrinterTypeInfos.Where(p => p.PrinterTypeID == baPrinterTypeInfo.PrinterTypeID).FirstOrDefault();
                    if(obj != null)
                        {
                        printertypeinfo printertypeinfo = new printertypeinfo();

                      //  obj.Id = baPrinterTypeInfo.Id;
                        obj.PrinterTypeID = baPrinterTypeInfo.PrinterTypeID;
                        obj.PrinterType = baPrinterTypeInfo.PrinterType;
                        obj.ProductTypeID = baPrinterTypeInfo.ProductTypeID;
                        obj.ProductName = baPrinterTypeInfo.ProductName;
                        obj.IsActive = baPrinterTypeInfo.IsActive;

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
                    //var obj = db.PrinterTypeInfos.Where(p => p.Id == Id).FirstOrDefault();
                    var obj = db.PrinterTypeInfos.Where(p => p.PrinterTypeID == Id).FirstOrDefault();
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
