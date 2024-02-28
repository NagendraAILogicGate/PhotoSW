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
    public class baPermissionRoleInfo
    {

        public long Id { get; set; }
        public int PS_Permission_Role_pkey { get; set; }
        public int PS_User_Roles_Id { get; set; }
        public int PS_Permission_Id { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<permissionroleinfo> lst_permissionroleinfo = new List<permissionroleinfo>();

            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    //foreach (var item in lst_str)
                    //{
                    permissionroleinfo permissionroleinfo = new permissionroleinfo();
                    permissionroleinfo.Id = 1;
                    permissionroleinfo.PS_Permission_Role_pkey = 1;
                    permissionroleinfo.PS_User_Roles_Id = 1;
                    permissionroleinfo.PS_Permission_Id = 1;
                    permissionroleinfo.IsActive = true;



                    lst_permissionroleinfo.Add(permissionroleinfo);

                    var Id = lst_permissionroleinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PermissionRoleInfos.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.PermissionRoleInfos.AddRange(lst_permissionroleinfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.PermissionRoleInfos.AddRange(lst_permissionroleinfo);
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

        public static baPermissionRoleInfo GetPermissionRoleInfoById(int Id)
        {
            try
            {

                permissionroleinfo permissionroleinfo = new permissionroleinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.PermissionRoleInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPermissionRoleInfo
                    {
                        Id = p.Id,
                        PS_Permission_Role_pkey = p.PS_Permission_Role_pkey,
                        PS_User_Roles_Id = p.PS_User_Roles_Id,
                        PS_Permission_Id = p.PS_Permission_Id,
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
        public static List<baPermissionRoleInfo> GetPermissionRoleInfoData()
        {
            try
            {

                permissionroleinfo permissionroleinfo = new permissionroleinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.PermissionRoleInfos.Where(p => p.IsActive == true).Select(p => new baPermissionRoleInfo
                    {
                        Id = p.Id,
                        PS_Permission_Role_pkey = p.PS_Permission_Role_pkey,
                        PS_User_Roles_Id = p.PS_User_Roles_Id,
                        PS_Permission_Id = p.PS_Permission_Id,
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

        public static bool Insert(baPermissionRoleInfo baPermissionRoleInfo)
        {
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    permissionroleinfo permissionroleinfo = new permissionroleinfo();
                    permissionroleinfo.Id = baPermissionRoleInfo.Id;
                    permissionroleinfo.PS_User_Roles_Id = baPermissionRoleInfo.PS_User_Roles_Id;
                    permissionroleinfo.PS_Permission_Id = baPermissionRoleInfo.PS_Permission_Id;
                    permissionroleinfo.IsActive = baPermissionRoleInfo.IsActive;

                    db.PermissionRoleInfos.Add(permissionroleinfo);
                    db.SaveChanges();

                    permissionroleinfo.PS_Permission_Role_pkey = Convert.ToInt32(db.PermissionRoleInfos.OrderByDescending(v => v.Id).FirstOrDefault().Id);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ReSetAllPremission(int ID)
        {
            bool retval = false;
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    db.PermissionRoleInfos.RemoveRange(db.PermissionRoleInfos.Where(v=>v.PS_User_Roles_Id==ID));
                    db.SaveChanges();
                    retval = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return retval;
        }

        public static bool Update(baPermissionRoleInfo baPermissionRoleInfo)
        {
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.PermissionRoleInfos.Where(p => p.PS_Permission_Role_pkey == baPermissionRoleInfo.PS_Permission_Role_pkey).FirstOrDefault();
                    if (obj != null)
                    {
                        //permissionroleinfo permissionroleinfo = new permissionroleinfo();
                        //permissionroleinfo.Id = baPermissionRoleInfo.Id;
                        //permissionroleinfo.PS_Permission_Role_pkey = baPermissionRoleInfo.PS_Permission_Role_pkey;
                        obj.PS_User_Roles_Id = baPermissionRoleInfo.PS_User_Roles_Id;
                        obj.PS_Permission_Id = baPermissionRoleInfo.PS_Permission_Id;
                        obj.IsActive = baPermissionRoleInfo.IsActive;

                        db.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool Delete(int Id)
        {
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.PermissionRoleInfos.Where(p => p.Id == Id).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.IsActive = false;
                        db.SaveChanges();

                    }
                    return true;

                }
            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
