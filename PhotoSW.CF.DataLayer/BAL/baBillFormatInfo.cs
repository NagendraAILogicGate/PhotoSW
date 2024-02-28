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
    public class baBillFormatInfo
        {
        public long Id { get; set; }
        public int PS_Bill_Format_pkey { get; set; }
        public int? PS_Bill_Type { get; set; }
        public string PS_Refund_Slogan { get; set; }      
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<billformatinfo> lst_billformatinfo = new List<billformatinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    billformatinfo billformatinfo = new billformatinfo();

                    billformatinfo.Id = 1;
                    billformatinfo.PS_Bill_Format_pkey = 3;
                    billformatinfo.PS_Bill_Type = 1;
                    billformatinfo.PS_Refund_Slogan = "";
                    billformatinfo.IsActive = true;

                    lst_billformatinfo.Add(billformatinfo);

                    var Id = lst_billformatinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.BillFormatInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.BillFormatInfos.AddRange(lst_billformatinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.BillFormatInfos.AddRange(lst_billformatinfo);
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

        public static baBillFormatInfo GetBillFormatInfoDataById ( long Id )
            {
            try
                {

                billformatinfo billformatinfo = new billformatinfo();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.BillFormatInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baBillFormatInfo
                        {
                        Id = p.Id,
                        PS_Bill_Format_pkey = p.PS_Bill_Format_pkey,
                        PS_Bill_Type = p.PS_Bill_Type,
                        PS_Refund_Slogan = p.PS_Refund_Slogan,
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

        public static List<baBillFormatInfo> GetBillFormatInfoData ()
            {
            try
                {
                billformatinfo billformatinfo = new billformatinfo();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.BillFormatInfos.Where(p => p.IsActive == true).Select(p => new baBillFormatInfo
                        {
                        Id = p.Id,
                        PS_Bill_Format_pkey = p.PS_Bill_Format_pkey,
                        PS_Bill_Type = p.PS_Bill_Type,
                        PS_Refund_Slogan = p.PS_Refund_Slogan,
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

        public static bool Insert ( baBillFormatInfo baBillFormatInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    billformatinfo billformatinfo = new billformatinfo();

                    billformatinfo.Id = baBillFormatInfo.Id;
                    billformatinfo.PS_Bill_Format_pkey = baBillFormatInfo.PS_Bill_Format_pkey;
                    billformatinfo.PS_Bill_Type = baBillFormatInfo.PS_Bill_Type;
                    billformatinfo.PS_Refund_Slogan = baBillFormatInfo.PS_Refund_Slogan;
                    billformatinfo.IsActive = baBillFormatInfo.IsActive;

                    db.BillFormatInfos.Add(billformatinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baBillFormatInfo baBillFormatInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.BillFormatInfos.Where(p => p.Id == baBillFormatInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        billformatinfo billformatinfo = new billformatinfo();

                        billformatinfo.Id = baBillFormatInfo.Id;
                        billformatinfo.PS_Bill_Format_pkey = baBillFormatInfo.PS_Bill_Format_pkey;
                        billformatinfo.PS_Bill_Type = baBillFormatInfo.PS_Bill_Type;
                        billformatinfo.PS_Refund_Slogan = baBillFormatInfo.PS_Refund_Slogan;
                        billformatinfo.IsActive = baBillFormatInfo.IsActive;

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
                    var obj = db.BillFormatInfos.Where(p => p.Id == Id).FirstOrDefault();
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
