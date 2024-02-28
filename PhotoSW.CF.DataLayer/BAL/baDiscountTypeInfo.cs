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
    public class baDiscountTypeInfo
        {
        public long Id { get; set; }
        public int PS_Orders_DiscountType_Pkey { get; set; }
        public string PS_Orders_DiscountType_Name { get; set; }
        public string PS_Orders_DiscountType_Desc { get; set; }
        public bool? PS_Orders_DiscountType_Active { get; set; }
        public bool? PS_Orders_DiscountType_Secure { get; set; }
        public bool? PS_Orders_DiscountType_ItemLevel { get; set; }
        public bool? PS_Orders_DiscountType_AsPercentage { get; set; }
        public string PS_Orders_DiscountType_Code { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public bool? IsActive { get; set; }


        public static bool Marge ()
            {
            List<discounttypeinfo> lst_discounttypeinfo = new List<discounttypeinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    discounttypeinfo discounttypeinfo = new discounttypeinfo();

                    discounttypeinfo.Id = 1;
                    discounttypeinfo.PS_Orders_DiscountType_Pkey = 3;
                    discounttypeinfo.PS_Orders_DiscountType_Name = "";
                    discounttypeinfo.PS_Orders_DiscountType_Desc = "";
                    discounttypeinfo.PS_Orders_DiscountType_Active = false;
                    discounttypeinfo.PS_Orders_DiscountType_Secure = false;
                    discounttypeinfo.PS_Orders_DiscountType_ItemLevel = false;
                    discounttypeinfo.PS_Orders_DiscountType_AsPercentage = false;
                    discounttypeinfo.PS_Orders_DiscountType_Code = "";
                    discounttypeinfo.SyncCode = "";
                    discounttypeinfo.IsSynced = false;
                    discounttypeinfo.IsActive = true;

                    lst_discounttypeinfo.Add(discounttypeinfo);

                    var Id = lst_discounttypeinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.DiscountTypeInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.DiscountTypeInfos.AddRange(lst_discounttypeinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.DiscountTypeInfos.AddRange(lst_discounttypeinfo);
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

        public static baDiscountTypeInfo GetDiscountTypeInfoDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.DiscountTypeInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baDiscountTypeInfo
                        {
                        Id = p.Id,
                        PS_Orders_DiscountType_Pkey = p.PS_Orders_DiscountType_Pkey,
                        PS_Orders_DiscountType_Name = p.PS_Orders_DiscountType_Name,
                        PS_Orders_DiscountType_Desc = p.PS_Orders_DiscountType_Desc,
                        PS_Orders_DiscountType_Active = p.PS_Orders_DiscountType_Active,
                        PS_Orders_DiscountType_Secure = p.PS_Orders_DiscountType_Secure,
                        PS_Orders_DiscountType_ItemLevel = p.PS_Orders_DiscountType_ItemLevel,
                        PS_Orders_DiscountType_AsPercentage = p.PS_Orders_DiscountType_AsPercentage,
                        PS_Orders_DiscountType_Code = p.PS_Orders_DiscountType_Code,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,                      
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

        public static List<baDiscountTypeInfo> GetDiscountTypeInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.DiscountTypeInfos.Where(p => p.IsActive == true).Select(p => new baDiscountTypeInfo
                        {
                        Id = p.Id,
                        PS_Orders_DiscountType_Pkey = p.PS_Orders_DiscountType_Pkey,
                        PS_Orders_DiscountType_Name = p.PS_Orders_DiscountType_Name,
                        PS_Orders_DiscountType_Desc = p.PS_Orders_DiscountType_Desc,
                        PS_Orders_DiscountType_Active = p.PS_Orders_DiscountType_Active,
                        PS_Orders_DiscountType_Secure = p.PS_Orders_DiscountType_Secure,
                        PS_Orders_DiscountType_ItemLevel = p.PS_Orders_DiscountType_ItemLevel,
                        PS_Orders_DiscountType_AsPercentage = p.PS_Orders_DiscountType_AsPercentage,
                        PS_Orders_DiscountType_Code = p.PS_Orders_DiscountType_Code,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
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

        public static bool Insert ( baDiscountTypeInfo baDiscountTypeInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    discounttypeinfo discounttypeinfo = new discounttypeinfo();

                    discounttypeinfo.Id = baDiscountTypeInfo.Id;
                    discounttypeinfo.PS_Orders_DiscountType_Pkey = baDiscountTypeInfo.PS_Orders_DiscountType_Pkey;
                    discounttypeinfo.PS_Orders_DiscountType_Name = baDiscountTypeInfo.PS_Orders_DiscountType_Name;
                    discounttypeinfo.PS_Orders_DiscountType_Desc = baDiscountTypeInfo.PS_Orders_DiscountType_Desc;
                    discounttypeinfo.PS_Orders_DiscountType_Active = baDiscountTypeInfo.PS_Orders_DiscountType_Active;
                    discounttypeinfo.PS_Orders_DiscountType_Secure = baDiscountTypeInfo.PS_Orders_DiscountType_Secure;
                    discounttypeinfo.PS_Orders_DiscountType_ItemLevel = baDiscountTypeInfo.PS_Orders_DiscountType_ItemLevel;
                    discounttypeinfo.PS_Orders_DiscountType_AsPercentage = baDiscountTypeInfo.PS_Orders_DiscountType_AsPercentage;
                    discounttypeinfo.PS_Orders_DiscountType_Code = baDiscountTypeInfo.PS_Orders_DiscountType_Code;
                    discounttypeinfo.SyncCode = baDiscountTypeInfo.SyncCode;
                    discounttypeinfo.IsSynced = baDiscountTypeInfo.IsSynced;
                    discounttypeinfo.IsActive = baDiscountTypeInfo.IsActive;

                    db.DiscountTypeInfos.Add(discounttypeinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baDiscountTypeInfo baDiscountTypeInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.DiscountTypeInfos.Where(p => p.Id == baDiscountTypeInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        discounttypeinfo discounttypeinfo = new discounttypeinfo();

                        discounttypeinfo.Id = baDiscountTypeInfo.Id;
                        discounttypeinfo.PS_Orders_DiscountType_Pkey = baDiscountTypeInfo.PS_Orders_DiscountType_Pkey;
                        discounttypeinfo.PS_Orders_DiscountType_Name = baDiscountTypeInfo.PS_Orders_DiscountType_Name;
                        discounttypeinfo.PS_Orders_DiscountType_Desc = baDiscountTypeInfo.PS_Orders_DiscountType_Desc;
                        discounttypeinfo.PS_Orders_DiscountType_Active = baDiscountTypeInfo.PS_Orders_DiscountType_Active;
                        discounttypeinfo.PS_Orders_DiscountType_Secure = baDiscountTypeInfo.PS_Orders_DiscountType_Secure;
                        discounttypeinfo.PS_Orders_DiscountType_ItemLevel = baDiscountTypeInfo.PS_Orders_DiscountType_ItemLevel;
                        discounttypeinfo.PS_Orders_DiscountType_AsPercentage = baDiscountTypeInfo.PS_Orders_DiscountType_AsPercentage;
                        discounttypeinfo.PS_Orders_DiscountType_Code = baDiscountTypeInfo.PS_Orders_DiscountType_Code;
                        discounttypeinfo.SyncCode = baDiscountTypeInfo.SyncCode;
                        discounttypeinfo.IsSynced = baDiscountTypeInfo.IsSynced;
                        discounttypeinfo.IsActive = baDiscountTypeInfo.IsActive;

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
                    var obj = db.DiscountTypeInfos.Where(p => p.Id == Id).FirstOrDefault();
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
