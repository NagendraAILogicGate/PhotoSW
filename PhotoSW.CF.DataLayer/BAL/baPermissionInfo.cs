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
    public class baPermissionInfo
    {
       
        public long Id { get; set; }
        public int PS_Permission_pkey { get; set; }
        public string PS_Permission_Name { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<permissioninfo> lst_permissioninfo = new List<permissioninfo>();

            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    //foreach (var item in lst_str)
                    //{
                    permissioninfo permissioninfo = new permissioninfo();
                    permissioninfo.Id = 1;
                    permissioninfo.PS_Permission_pkey = 1;
                    permissioninfo.PS_Permission_Name = "";
                    permissioninfo.SyncCode = "001";
                    permissioninfo.IsSynced = true;
                    permissioninfo.IsActive = true;



                    lst_permissioninfo.Add(permissioninfo);

                    var Id = lst_permissioninfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PermissionInfos.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.PermissionInfos.AddRange(lst_permissioninfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.PermissionInfos.AddRange(lst_permissioninfo);
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static baPermissionInfo GetPermissionInfoById(int Id)
        {
            try
            {

                permissioninfo permissioninfo = new permissioninfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.PermissionInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPermissionInfo
                    {
                        Id = p.Id,
                        PS_Permission_pkey =p.PS_Permission_pkey,
                        PS_Permission_Name =p.PS_Permission_Name,
                        SyncCode =p.SyncCode,
                        IsSynced =p.IsSynced,
                        IsActive = true,

                    }).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }
        public static List<baPermissionInfo> GetPermissionInfoData()
        {
            try
            {

                permissioninfo permissioninfo = new permissioninfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.PermissionInfos.Where(p => p.IsActive == true).Select(p => new baPermissionInfo
                    {
                        Id = p.Id,
                        PS_Permission_pkey = p.PS_Permission_pkey,
                        PS_Permission_Name = p.PS_Permission_Name,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        IsActive = true,

                    }).ToList();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }

        public static bool Insert ( baPermissionInfo baPermissionInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    permissioninfo permissioninfo = new permissioninfo();
                    permissioninfo.Id = baPermissionInfo.Id;
                    permissioninfo.PS_Permission_Name = baPermissionInfo.PS_Permission_Name;
                    permissioninfo.SyncCode = baPermissionInfo.SyncCode;
                    permissioninfo.IsSynced = baPermissionInfo.IsSynced;
                    permissioninfo.IsActive = baPermissionInfo.IsActive;

                    db.PermissionInfos.Add(permissioninfo);
                    db.SaveChanges();

                    permissioninfo.PS_Permission_pkey = Convert.ToInt32(db.PermissionInfos.OrderByDescending(v=>v.Id).FirstOrDefault().Id);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPermissionInfo baPermissionInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PermissionInfos.Where(p => p.Id == baPermissionInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        permissioninfo permissioninfo = new permissioninfo();

                        permissioninfo.Id = baPermissionInfo.Id;
                        permissioninfo.PS_Permission_pkey = baPermissionInfo.PS_Permission_pkey;
                        permissioninfo.PS_Permission_Name = baPermissionInfo.PS_Permission_Name;
                        permissioninfo.SyncCode = baPermissionInfo.SyncCode;
                        permissioninfo.IsSynced = baPermissionInfo.IsSynced;
                        permissioninfo.IsActive = baPermissionInfo.IsActive;

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
                    var obj = db.PermissionInfos.Where(p => p.Id == Id).FirstOrDefault();
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
