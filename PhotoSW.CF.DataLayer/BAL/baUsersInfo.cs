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

    public class baUsersInfo
    {
        public long Id { get; set; }
        public int PS_User_pkey { get; set; }
        public string PS_User_Name { get; set; }
        public string PS_User_First_Name { get; set; }
        public string PS_User_Last_Name { get; set; }
        public string PS_User_Password { get; set; }
        public int PS_User_Roles_Id { get; set; }
        public int PS_Location_ID { get; set; }
        public bool? PS_User_Status { get; set; }
        public string PS_User_PhoneNo { get; set; }
        public string PS_User_Email { get; set; }
        public DateTime? User_CreatedDate { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public string User_Role { get; set; }
        public string Location_Name { get; set; }
        public int Store_ID { get; set; }
        public int Location_pkey { get; set; }
        public string UserName { get; set; }
        public string StatusName { get; set; }
        public string Store_Name { get; set; }
        public string CountryCode { get; set; }
        public string StoreCode { get; set; }
        public string UserFullName { get; set; }
        public int Substore_ID { get; set; }
        public string ServerHotFolderPath { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<usersinfo> lst_usersinfo = new List<usersinfo>();

            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    usersinfo usersinfo = new usersinfo();
                    usersinfo.Id = 1;
                    usersinfo.PS_User_pkey = 1;
                    usersinfo.PS_User_Name = "admin";
                    usersinfo.PS_User_First_Name = "Jay";
                    usersinfo.PS_User_Last_Name = "Sukla";
                    usersinfo.PS_User_Password = "Fgwzi7hZtWU=";
                    usersinfo.PS_User_Roles_Id = 1;
                    usersinfo.PS_Location_ID = 1;
                    usersinfo.PS_User_Status = true;
                    usersinfo.PS_User_PhoneNo = "9826536632";
                    usersinfo.PS_User_Email = "raj@gmail.com";
                    usersinfo.User_CreatedDate = DateTime.Now;
                    usersinfo.SyncCode = "001";
                    usersinfo.IsSynced = true;
                    usersinfo.User_Role = "Admin";
                    usersinfo.Location_Name = "Bhopal";
                    usersinfo.Store_ID = 3;
                    usersinfo.Location_pkey = 2;
                    usersinfo.UserName = "Admin";
                    usersinfo.StatusName = "Active";
                    usersinfo.Store_Name = "Store Bhopal";
                    usersinfo.CountryCode = "91";
                    usersinfo.StoreCode = "Store Bhopal";
                    usersinfo.UserFullName = "";
                    usersinfo.Substore_ID = 1;
                    usersinfo.ServerHotFolderPath = "";

                    usersinfo.IsActive = true;
                    lst_usersinfo.Add(usersinfo);

                    var Id = lst_usersinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.UsersInfos.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.UsersInfos.AddRange(lst_usersinfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.UsersInfos.AddRange(lst_usersinfo);
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

        public static baUsersInfo GetUsersInfoDataById(long Id)
        {
            try
            {

                using (PhotoSWEntities db = new PhotoSWEntities())
                {

                    var obj = db.UsersInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baUsersInfo
                    {
                        Id = p.Id,
                        PS_User_pkey = p.PS_User_pkey,
                        PS_User_Name = p.PS_User_Name,
                        PS_User_First_Name = p.PS_User_First_Name,
                        PS_User_Last_Name = p.PS_User_Last_Name,
                        PS_User_Password = p.PS_User_Password,
                        PS_User_Roles_Id = p.PS_User_Roles_Id,
                        PS_Location_ID = p.PS_Location_ID,
                        PS_User_Status = p.PS_User_Status,
                        PS_User_PhoneNo = p.PS_User_PhoneNo,
                        PS_User_Email = p.PS_User_Email,
                        User_CreatedDate = p.User_CreatedDate,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        User_Role = p.User_Role,
                        Location_Name = p.Location_Name,
                        Store_ID = p.Store_ID,
                        Location_pkey = p.Location_pkey,
                        UserName = p.UserName,
                        StatusName = p.StatusName,
                        Store_Name = p.Store_Name,
                        CountryCode = p.CountryCode,
                        StoreCode = p.StoreCode,
                        UserFullName = p.UserFullName,
                        Substore_ID = p.Substore_ID,
                        ServerHotFolderPath = p.ServerHotFolderPath,
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

        public static List<baUsersInfo> GetUsersInfoData()
        {
            try
            {

                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.UsersInfos.Where(p => p.IsActive == true).Select(p => new baUsersInfo
                    {
                        Id = p.Id,
                        PS_User_pkey = p.PS_User_pkey,
                        PS_User_Name = p.PS_User_Name,
                        PS_User_First_Name = p.PS_User_First_Name,
                        PS_User_Last_Name = p.PS_User_Last_Name,
                        PS_User_Password = p.PS_User_Password,
                        PS_User_Roles_Id = p.PS_User_Roles_Id,
                        PS_Location_ID = p.PS_Location_ID,
                        PS_User_Status = p.PS_User_Status,
                        PS_User_PhoneNo = p.PS_User_PhoneNo,
                        PS_User_Email = p.PS_User_Email,
                        User_CreatedDate = p.User_CreatedDate,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        User_Role = p.User_Role,
                        Location_Name = p.Location_Name,
                        Store_ID = p.Store_ID,
                        Location_pkey = p.Location_pkey,
                        UserName = p.UserName,
                        StatusName = p.StatusName,
                        Store_Name = p.Store_Name,
                        CountryCode = p.CountryCode,
                        StoreCode = p.StoreCode,
                        UserFullName = p.UserFullName,
                        Substore_ID = p.Substore_ID,
                        ServerHotFolderPath = p.ServerHotFolderPath,
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

        public static bool Insert(baUsersInfo baUsersInfo)
        {
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    usersinfo usersinfo = new usersinfo();

                    usersinfo.Id = baUsersInfo.Id;
                    usersinfo.PS_User_Name = baUsersInfo.PS_User_Name;
                    usersinfo.PS_User_First_Name = baUsersInfo.PS_User_First_Name;
                    usersinfo.PS_User_Last_Name = baUsersInfo.PS_User_Last_Name;
                    usersinfo.PS_User_Password = baUsersInfo.PS_User_Password;
                    usersinfo.PS_User_Roles_Id = baUsersInfo.PS_User_Roles_Id;
                    usersinfo.PS_Location_ID = baUsersInfo.PS_Location_ID;
                    usersinfo.PS_User_Status = baUsersInfo.PS_User_Status;
                    usersinfo.PS_User_PhoneNo = baUsersInfo.PS_User_PhoneNo;
                    usersinfo.PS_User_Email = baUsersInfo.PS_User_Email;
                    usersinfo.User_CreatedDate = baUsersInfo.User_CreatedDate;
                    usersinfo.SyncCode = baUsersInfo.SyncCode;
                    usersinfo.IsSynced = baUsersInfo.IsSynced;
                    usersinfo.User_Role = baUsersInfo.User_Role;
                    usersinfo.Location_Name = baUsersInfo.Location_Name;
                    usersinfo.Store_ID = baUsersInfo.Store_ID;
                    usersinfo.Location_pkey = baUsersInfo.Location_pkey;
                    usersinfo.UserName = baUsersInfo.UserName;
                    usersinfo.StatusName = baUsersInfo.StatusName;
                    usersinfo.Store_Name = baUsersInfo.Store_Name;
                    usersinfo.CountryCode = baUsersInfo.CountryCode;
                    usersinfo.StoreCode = baUsersInfo.StoreCode;
                    usersinfo.UserFullName = baUsersInfo.UserFullName;
                    usersinfo.Substore_ID = baUsersInfo.Substore_ID;
                    usersinfo.ServerHotFolderPath = baUsersInfo.ServerHotFolderPath;
                    usersinfo.IsActive = baUsersInfo.IsActive;
                    db.UsersInfos.Add(usersinfo);
                    db.SaveChanges();

                    usersinfo.PS_User_pkey = Convert.ToInt32(db.UsersInfos.OrderByDescending(v => v.Id).FirstOrDefault().Id);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool Update(baUsersInfo baUsersInfo)
        {
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.UsersInfos.Where(p => p.PS_User_pkey == baUsersInfo.PS_User_pkey).FirstOrDefault();
                    if (obj != null)
                    {
                        usersinfo usersinfo = new usersinfo();
                        obj.PS_User_Name = baUsersInfo.PS_User_Name;
                        obj.PS_User_First_Name = baUsersInfo.PS_User_First_Name;
                        obj.PS_User_Last_Name = baUsersInfo.PS_User_Last_Name;
                        obj.PS_User_Password = baUsersInfo.PS_User_Password;
                        obj.PS_User_Roles_Id = baUsersInfo.PS_User_Roles_Id;
                        obj.PS_Location_ID = baUsersInfo.PS_Location_ID;
                        obj.PS_User_Status = baUsersInfo.PS_User_Status;
                        obj.PS_User_PhoneNo = baUsersInfo.PS_User_PhoneNo;
                        obj.PS_User_Email = baUsersInfo.PS_User_Email;
                        obj.User_CreatedDate = baUsersInfo.User_CreatedDate;
                        obj.SyncCode = baUsersInfo.SyncCode;
                        obj.IsSynced = baUsersInfo.IsSynced;
                        obj.User_Role = baUsersInfo.User_Role;
                        obj.Location_Name = baUsersInfo.Location_Name;
                        obj.Store_ID = baUsersInfo.Store_ID;
                        obj.Location_pkey = baUsersInfo.Location_pkey;
                        obj.UserName = baUsersInfo.UserName;
                        obj.StatusName = baUsersInfo.StatusName;
                        obj.Store_Name = baUsersInfo.Store_Name;
                        obj.CountryCode = baUsersInfo.CountryCode;
                        obj.StoreCode = baUsersInfo.StoreCode;
                        obj.UserFullName = baUsersInfo.UserFullName;
                        obj.Substore_ID = baUsersInfo.Substore_ID;
                        obj.ServerHotFolderPath = baUsersInfo.ServerHotFolderPath;
                        obj.IsActive = baUsersInfo.IsActive;

                        db.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
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
                    var obj = db.UsersInfos.Where(p => p.Id == Id).FirstOrDefault();
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
