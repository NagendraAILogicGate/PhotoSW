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

    public class baRoleInfo
    {
        public long Id { get; set; }
        public int User_Roles_pkey { get; set; }
        public string User_Role { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public bool? IsActive { get; set; }
        public static bool Marge()
        {
            List<roleinfo> lst_roleinfo = new List<roleinfo>();
            List<long> lst_str = new List<long>();
            lst_str.Add(1);
            lst_str.Add(2);
            lst_str.Add(3);
            lst_str.Add(4);
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    foreach (var item in lst_str)
                    {
                        roleinfo roleinfo = new roleinfo();
                        if (item == 1)

                        {
                            roleinfo.Id = item;

                            roleinfo.User_Roles_pkey = (int)item;
                            roleinfo.User_Role = "Admin";
                            roleinfo.SyncCode = "001";

                            roleinfo.IsActive = true;
                        }
                        if (item == 2)
                        {
                            roleinfo.Id = item;

                            roleinfo.User_Roles_pkey = (int)item;
                            roleinfo.User_Role = "Manager";
                            roleinfo.SyncCode = "002";

                            roleinfo.IsActive = true;
                        }
                        if (item == 3)

                        {
                            roleinfo.Id = item;

                            roleinfo.User_Roles_pkey = (int)item;
                            roleinfo.User_Role = "Store";
                            roleinfo.SyncCode = "003";

                            roleinfo.IsActive = true;
                        }
                        if (item == 4)

                        {
                            roleinfo.Id = item;

                            roleinfo.User_Roles_pkey = (int)item;
                            roleinfo.User_Role = "User";
                            roleinfo.SyncCode = "004";

                            roleinfo.IsActive = true;
                        }

                        lst_roleinfo.Add(roleinfo);
                    }
                    var Id = lst_roleinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.RoleInfos.Where(p => lst_str.Contains(p.Id)).ToList();
                    if (IsExist == null)
                    {
                        db.RoleInfos.AddRange(lst_roleinfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.RoleInfos.AddRange(lst_roleinfo);
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

        public static baRoleInfo GetRoleInfoDataById(int Id)
        {
            try
            {

                roleinfo roleinfo = new roleinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.RoleInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baRoleInfo
                    {
                        Id = p.Id,
                        User_Roles_pkey = p.User_Roles_pkey,
                        User_Role = p.User_Role,
                        SyncCode = p.SyncCode,

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
        public static List<baRoleInfo> GetRoleInfoData()
        {
            try
            {

                photogroupinfo photogroupinfo = new photogroupinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.RoleInfos.Where(p => p.IsActive == true).Select(p => new baRoleInfo
                    {
                        Id = p.Id,
                        User_Roles_pkey = p.User_Roles_pkey,
                        User_Role = p.User_Role,
                        SyncCode = p.SyncCode,
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


        public static bool Insert(baRoleInfo baRoleInfo)
        {
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    roleinfo roleinfo = new roleinfo();

                    roleinfo.Id = baRoleInfo.Id;
                    roleinfo.User_Role = baRoleInfo.User_Role;
                    roleinfo.SyncCode = baRoleInfo.SyncCode;
                    roleinfo.IsActive = baRoleInfo.IsActive;

                    db.RoleInfos.Add(roleinfo);
                    db.SaveChanges();

                    roleinfo.User_Roles_pkey =Convert.ToInt32(db.RoleInfos.OrderByDescending(v => v.Id).FirstOrDefault().Id);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public static bool Update(baRoleInfo baRoleInfo)
        {
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.RoleInfos.Where(p => p.User_Roles_pkey == baRoleInfo.User_Roles_pkey).FirstOrDefault();
                    if (obj != null)
                    {
                        roleinfo roleinfo = new roleinfo();
                        obj.User_Role = baRoleInfo.User_Role;
                        obj.SyncCode = baRoleInfo.SyncCode;
                        //obj.IsActive = baRoleInfo.IsActive;

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
                return false;
                throw;
            }
        }

        public static bool Delete(int Id)
        {
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.RoleInfos.Where(p => p.User_Roles_pkey == Id).FirstOrDefault();
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
