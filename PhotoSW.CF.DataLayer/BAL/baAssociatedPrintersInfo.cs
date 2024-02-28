using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baAssociatedPrintersInfo
        {
        public long Id { get; set; }
        public int PS_AssociatedPrinters_Pkey { get; set; }
        public string PS_AssociatedPrinters_Name { get; set; }
        public int PS_AssociatedPrinters_ProductType_ID { get; set; }
        public bool PS_AssociatedPrinters_IsActive { get; set; }
        public string PS_AssociatedPrinters_PaperSize { get; set; }
        public int? PS_AssociatedPrinters_SubStoreID { get; set; }
        public string PS_Orders_ProductType_Name { get; set; }     
        public bool? IsActive { get; set; }
        public static bool Marge ()
            {
            List<associatedprintersinfo> lst_associatedprintersinfo = new List<associatedprintersinfo>();
            List<producttypeinfo> lst_producttypeinfo = new List<producttypeinfo>();
            List<int> lst_str = new List<int>();
            lst_str.Add(1);
            lst_str.Add(2);
            lst_str.Add(3);
            lst_str.Add(4);
            lst_str.Add(5);
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    foreach(var item in lst_str)
                        {
                        associatedprintersinfo associatedprintersinfo = new associatedprintersinfo();

                        associatedprintersinfo.Id = item;
                        associatedprintersinfo.PS_AssociatedPrinters_Pkey = item;
                        associatedprintersinfo.PS_AssociatedPrinters_Name = "Test";
                        associatedprintersinfo.PS_AssociatedPrinters_ProductType_ID = 1;
                        associatedprintersinfo.PS_AssociatedPrinters_SubStoreID = item;
                        associatedprintersinfo.PS_AssociatedPrinters_IsActive = true;
                        associatedprintersinfo.PS_AssociatedPrinters_PaperSize = "8*8";
                      
                        associatedprintersinfo.PS_Orders_ProductType_Name = "Test";
                        associatedprintersinfo.IsActive = true;

                        lst_associatedprintersinfo.Add(associatedprintersinfo);
                        }
                    var Id = lst_associatedprintersinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.AssociatedPrintersInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.AssociatedPrintersInfos.AddRange(lst_associatedprintersinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.AssociatedPrintersInfos.AddRange(lst_associatedprintersinfo);
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

        public static baAssociatedPrintersInfo GetAssociatedPrintersInfoDataById ( long Id )
            {
            try
                {

                associatedprintersinfo associatedprintersinfo = new associatedprintersinfo();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.AssociatedPrintersInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baAssociatedPrintersInfo
                        {
                        Id = p.Id,
                        PS_AssociatedPrinters_Pkey = p.PS_AssociatedPrinters_Pkey,
                        PS_AssociatedPrinters_Name = p.PS_AssociatedPrinters_Name,
                        PS_AssociatedPrinters_ProductType_ID = p.PS_AssociatedPrinters_ProductType_ID,
                        PS_AssociatedPrinters_IsActive = p.PS_AssociatedPrinters_IsActive,
                        PS_AssociatedPrinters_PaperSize = p.PS_AssociatedPrinters_PaperSize,
                        PS_AssociatedPrinters_SubStoreID = p.PS_AssociatedPrinters_SubStoreID,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
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

        public static List<baAssociatedPrintersInfo> GetAssociatedPrintersInfoData ()
            {
            try
                {

                associatedprintersinfo associatedprintersinfo = new associatedprintersinfo();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.AssociatedPrintersInfos.Where(p => p.IsActive == true).Select(p => new baAssociatedPrintersInfo
                        {
                        Id = p.Id,
                        PS_AssociatedPrinters_Pkey = p.PS_AssociatedPrinters_Pkey,
                        PS_AssociatedPrinters_Name = p.PS_AssociatedPrinters_Name,
                        PS_AssociatedPrinters_ProductType_ID = p.PS_AssociatedPrinters_ProductType_ID,
                        PS_AssociatedPrinters_IsActive = p.PS_AssociatedPrinters_IsActive,
                        PS_AssociatedPrinters_PaperSize = p.PS_AssociatedPrinters_PaperSize,
                        PS_AssociatedPrinters_SubStoreID = p.PS_AssociatedPrinters_SubStoreID,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
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

        public static bool Insert ( baAssociatedPrintersInfo baAssociatedPrintersInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    associatedprintersinfo associatedprintersinfo = new associatedprintersinfo();

                    associatedprintersinfo.Id = baAssociatedPrintersInfo.Id;
                    associatedprintersinfo.PS_AssociatedPrinters_Pkey = baAssociatedPrintersInfo.PS_AssociatedPrinters_Pkey;
                    associatedprintersinfo.PS_AssociatedPrinters_Name = baAssociatedPrintersInfo.PS_AssociatedPrinters_Name;
                    associatedprintersinfo.PS_AssociatedPrinters_ProductType_ID = baAssociatedPrintersInfo.PS_AssociatedPrinters_ProductType_ID;
                    associatedprintersinfo.PS_AssociatedPrinters_IsActive = baAssociatedPrintersInfo.PS_AssociatedPrinters_IsActive;
                    associatedprintersinfo.PS_AssociatedPrinters_PaperSize = baAssociatedPrintersInfo.PS_AssociatedPrinters_PaperSize;
                    associatedprintersinfo.PS_AssociatedPrinters_SubStoreID = baAssociatedPrintersInfo.PS_AssociatedPrinters_SubStoreID;
                    associatedprintersinfo.PS_Orders_ProductType_Name = baAssociatedPrintersInfo.PS_Orders_ProductType_Name;
                    associatedprintersinfo.IsActive = baAssociatedPrintersInfo.IsActive;
                    db.AssociatedPrintersInfos.Add(associatedprintersinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baAssociatedPrintersInfo baAssociatedPrintersInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.AssociatedPrintersInfos.Where(p => p.Id == baAssociatedPrintersInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        associatedprintersinfo associatedprintersinfo = new associatedprintersinfo();

                        obj.Id = baAssociatedPrintersInfo.Id;
                        obj.PS_AssociatedPrinters_Pkey = baAssociatedPrintersInfo.PS_AssociatedPrinters_Pkey;
                        obj.PS_AssociatedPrinters_Name = baAssociatedPrintersInfo.PS_AssociatedPrinters_Name;
                        obj.PS_AssociatedPrinters_ProductType_ID = baAssociatedPrintersInfo.PS_AssociatedPrinters_ProductType_ID;
                        obj.PS_AssociatedPrinters_IsActive = baAssociatedPrintersInfo.PS_AssociatedPrinters_IsActive;
                        obj.PS_AssociatedPrinters_PaperSize = baAssociatedPrintersInfo.PS_AssociatedPrinters_PaperSize;
                        obj.PS_AssociatedPrinters_SubStoreID = baAssociatedPrintersInfo.PS_AssociatedPrinters_SubStoreID;
                        obj.PS_Orders_ProductType_Name = baAssociatedPrintersInfo.PS_Orders_ProductType_Name;
                        // obj.IsActive = baAssociatedPrintersInfo.IsActive;
                        obj.IsActive = true;

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
                    var obj = db.AssociatedPrintersInfos.Where(p => p.Id == Id).FirstOrDefault();
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
