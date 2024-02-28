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
    public class baPhotoGrapherInfo
    {
        public long Id { get; set; }
        public string CountryCode { get; set; }
        public string PS_Location_Name { get; set; }
        public int PS_Location_pkey { get; set; }
        public int PS_Store_ID { get; set; }
        public string PS_Store_Name { get; set; }
        public int PS_Substore_ID { get; set; }
        public string PS_User_Email { get; set; }
        public string PS_User_First_Name { get; set; }
        public string PS_User_Last_Name { get; set; }
        public string PS_User_Name { get; set; }
        public string PS_User_Password { get; set; }
        public string PS_User_PhoneNo { get; set; }
        public int PS_User_pkey { get; set; }
        public string PS_User_Role { get; set; }
        public int PS_User_Roles_Id { get; set; }
        public bool? PS_User_Status { get; set; }
        public string FullName { get; set; }
        public string Photograper { get; set; }
        public string StatusName { get; set; }
        public string StoreCode { get; set; }
        public string UserName { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<photographersinfo> lst_photographersinfo = new List<photographersinfo>();

            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    //foreach (var item in lst_str)
                    //{
                    photographersinfo photographersinfo = new photographersinfo();

                    photographersinfo.Id = 1;
                    photographersinfo.CountryCode = "1";
                    photographersinfo.PS_Location_Name = "Bhopal";
                    photographersinfo.PS_Location_pkey = 1;
                    photographersinfo.PS_Store_ID = 1;
                    photographersinfo.PS_Store_Name = "Bhopal";
                    photographersinfo.PS_Substore_ID = 1;
                    photographersinfo.PS_User_Email = "test@test.com";
                    photographersinfo.PS_User_First_Name = "Test";
                    photographersinfo.PS_User_Last_Name = "Test";
                    photographersinfo.PS_User_Name = "test";
                    photographersinfo.PS_User_Password = "123456";
                    photographersinfo.PS_User_PhoneNo = "12345";
                    photographersinfo.PS_User_pkey = 1;
                    photographersinfo.PS_User_Role = "1";
                    photographersinfo.PS_User_Roles_Id = 1;
                    photographersinfo.PS_User_Status = false;
                    photographersinfo.FullName = "";
                    photographersinfo.Photograper = "Test";
                    photographersinfo.StatusName = "Running";
                    photographersinfo.StoreCode = "23";
                    photographersinfo.UserName = "test";

                    photographersinfo.IsActive = true;


                    lst_photographersinfo.Add(photographersinfo);
                    // }
                    var Id = lst_photographersinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PhotoGraphersInfos.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.PhotoGraphersInfos.AddRange(lst_photographersinfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.PhotoGraphersInfos.AddRange(lst_photographersinfo);
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
        public static baPhotoGrapherInfo GetPhotoGrapherInfoById(int Id)
        {
            try
            {

                photographersinfo photographersinfo = new photographersinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.PhotoGraphersInfos.Where(p => p.IsActive == true).Select(p => new baPhotoGrapherInfo
                    {
                        Id = p.Id,
                       CountryCode = p.CountryCode,
                       PS_Location_Name = p.PS_Location_Name,
                       PS_Location_pkey = p.PS_Location_pkey,
                       PS_Store_ID = p.PS_Store_ID,
                       PS_Store_Name = p.PS_Store_Name,
                       PS_Substore_ID = p.PS_Substore_ID,
                       PS_User_Email = p.PS_User_Email,
                       PS_User_First_Name =p.PS_User_First_Name,
                       PS_User_Last_Name =p.PS_User_Last_Name,
                       PS_User_Name = p.PS_User_Name,
                       PS_User_Password = p.PS_User_Password,
                       PS_User_PhoneNo = p.PS_User_PhoneNo,
                       PS_User_pkey = p.PS_User_pkey,
                       PS_User_Role = p.PS_User_Role,
                       PS_User_Roles_Id = p.PS_User_Roles_Id,
                       PS_User_Status = p.PS_User_Status,
                       FullName = p.FullName,
                       Photograper = p.Photograper,
                       StatusName = p.StatusName,
                       StoreCode = p.StoreCode,
                       UserName = p.UserName,

                        IsActive = p.IsActive,


                    }).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }
        public static baPhotoGrapherInfo GetPhotoGrapherInfoBySubStoreId(int SubStoreID)
        {
            try
            {
                photographersinfo photographersinfo = new photographersinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.PhotoGraphersInfos.Where(p =>p.PS_Substore_ID==SubStoreID && p.IsActive == true).Select(p => new baPhotoGrapherInfo
                    {
                        
                            Id = p.Id,
                            CountryCode = p.CountryCode,
                            PS_Location_Name = p.PS_Location_Name,
                            PS_Location_pkey = p.PS_Location_pkey,
                            PS_Store_ID = p.PS_Store_ID,
                            PS_Store_Name = p.PS_Store_Name,
                            PS_Substore_ID = p.PS_Substore_ID,
                            PS_User_Email = p.PS_User_Email,
                            PS_User_First_Name = p.PS_User_First_Name,
                            PS_User_Last_Name = p.PS_User_Last_Name,
                            PS_User_Name = p.PS_User_Name,
                            PS_User_Password = p.PS_User_Password,
                            PS_User_PhoneNo = p.PS_User_PhoneNo,
                            PS_User_pkey = p.PS_User_pkey,
                            PS_User_Role = p.PS_User_Role,
                            PS_User_Roles_Id = p.PS_User_Roles_Id,
                            PS_User_Status = p.PS_User_Status,
                            FullName = p.FullName,
                            Photograper = p.Photograper,
                            StatusName = p.StatusName,
                            StoreCode = p.StoreCode,
                            UserName = p.UserName,

                            IsActive = p.IsActive,

                        }).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }
        public static List<baPhotoGrapherInfo> GetPhotoGrapherInfoData()
        {
            try
            {

                configinfo configinfo = new configinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.PhotoGraphersInfos.Where(p => p.IsActive == true).Select(p => new baPhotoGrapherInfo
                    {

                        Id = p.Id,
                        CountryCode = p.CountryCode,
                        PS_Location_Name = p.PS_Location_Name,
                        PS_Location_pkey = p.PS_Location_pkey,
                        PS_Store_ID = p.PS_Store_ID,
                        PS_Store_Name = p.PS_Store_Name,
                        PS_Substore_ID = p.PS_Substore_ID,
                        PS_User_Email = p.PS_User_Email,
                        PS_User_First_Name = p.PS_User_First_Name,
                        PS_User_Last_Name = p.PS_User_Last_Name,
                        PS_User_Name = p.PS_User_Name,
                        PS_User_Password = p.PS_User_Password,
                        PS_User_PhoneNo = p.PS_User_PhoneNo,
                        PS_User_pkey = p.PS_User_pkey,
                        PS_User_Role = p.PS_User_Role,
                        PS_User_Roles_Id = p.PS_User_Roles_Id,
                        PS_User_Status = p.PS_User_Status,
                        FullName = p.FullName,
                        Photograper = p.Photograper,
                        StatusName = p.StatusName,
                        StoreCode = p.StoreCode,
                        UserName = p.UserName,

                        IsActive = p.IsActive,

                    }).ToList();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }

        public static bool Insert ( baPhotoGrapherInfo baPhotoGrapherInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    photographersinfo photographersinfo = new photographersinfo();

                    photographersinfo.Id = baPhotoGrapherInfo.Id;
                    photographersinfo.CountryCode = baPhotoGrapherInfo.CountryCode;
                    photographersinfo.PS_Location_Name = baPhotoGrapherInfo.PS_Location_Name;
                    photographersinfo.PS_Location_pkey = baPhotoGrapherInfo.PS_Location_pkey;
                    photographersinfo.PS_Store_ID = baPhotoGrapherInfo.PS_Store_ID;
                    photographersinfo.PS_Store_Name = baPhotoGrapherInfo.PS_Store_Name;
                    photographersinfo.PS_Substore_ID = baPhotoGrapherInfo.PS_Substore_ID;
                    photographersinfo.PS_User_Email = baPhotoGrapherInfo.PS_User_Email;
                    photographersinfo.PS_User_First_Name = baPhotoGrapherInfo.PS_User_First_Name;
                    photographersinfo.PS_User_Last_Name = baPhotoGrapherInfo.PS_User_Last_Name;
                    photographersinfo.PS_User_Name = baPhotoGrapherInfo.PS_User_Name;
                    photographersinfo.PS_User_Password = baPhotoGrapherInfo.PS_User_Password;
                    photographersinfo.PS_User_PhoneNo = baPhotoGrapherInfo.PS_User_PhoneNo;
                    photographersinfo.PS_User_pkey = baPhotoGrapherInfo.PS_User_pkey;
                    photographersinfo.PS_User_Role = baPhotoGrapherInfo.PS_User_Role;
                    photographersinfo.PS_User_Roles_Id = baPhotoGrapherInfo.PS_User_Roles_Id;
                    photographersinfo.PS_User_Status = baPhotoGrapherInfo.PS_User_Status;
                    photographersinfo.FullName = baPhotoGrapherInfo.FullName;
                    photographersinfo.Photograper = baPhotoGrapherInfo.Photograper;
                    photographersinfo.StatusName = baPhotoGrapherInfo.StatusName;
                    photographersinfo.StoreCode = baPhotoGrapherInfo.StoreCode;
                    photographersinfo.UserName = baPhotoGrapherInfo.UserName;
                    photographersinfo.IsActive = baPhotoGrapherInfo.IsActive;

                    db.PhotoGraphersInfos.Add(photographersinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPhotoGrapherInfo baPhotoGrapherInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PhotoGroupInfos.Where(p => p.Id == baPhotoGrapherInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        photographersinfo photographersinfo = new photographersinfo();

                        photographersinfo.Id = baPhotoGrapherInfo.Id;
                        photographersinfo.CountryCode = baPhotoGrapherInfo.CountryCode;
                        photographersinfo.PS_Location_Name = baPhotoGrapherInfo.PS_Location_Name;
                        photographersinfo.PS_Location_pkey = baPhotoGrapherInfo.PS_Location_pkey;
                        photographersinfo.PS_Store_ID = baPhotoGrapherInfo.PS_Store_ID;
                        photographersinfo.PS_Store_Name = baPhotoGrapherInfo.PS_Store_Name;
                        photographersinfo.PS_Substore_ID = baPhotoGrapherInfo.PS_Substore_ID;
                        photographersinfo.PS_User_Email = baPhotoGrapherInfo.PS_User_Email;
                        photographersinfo.PS_User_First_Name = baPhotoGrapherInfo.PS_User_First_Name;
                        photographersinfo.PS_User_Last_Name = baPhotoGrapherInfo.PS_User_Last_Name;
                        photographersinfo.PS_User_Name = baPhotoGrapherInfo.PS_User_Name;
                        photographersinfo.PS_User_Password = baPhotoGrapherInfo.PS_User_Password;
                        photographersinfo.PS_User_PhoneNo = baPhotoGrapherInfo.PS_User_PhoneNo;
                        photographersinfo.PS_User_pkey = baPhotoGrapherInfo.PS_User_pkey;
                        photographersinfo.PS_User_Role = baPhotoGrapherInfo.PS_User_Role;
                        photographersinfo.PS_User_Roles_Id = baPhotoGrapherInfo.PS_User_Roles_Id;
                        photographersinfo.PS_User_Status = baPhotoGrapherInfo.PS_User_Status;
                        photographersinfo.FullName = baPhotoGrapherInfo.FullName;
                        photographersinfo.Photograper = baPhotoGrapherInfo.Photograper;
                        photographersinfo.StatusName = baPhotoGrapherInfo.StatusName;
                        photographersinfo.StoreCode = baPhotoGrapherInfo.StoreCode;
                        photographersinfo.UserName = baPhotoGrapherInfo.UserName;
                        photographersinfo.IsActive = baPhotoGrapherInfo.IsActive;

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
                    var obj = db.PhotoGraphersInfos.Where(p => p.Id == Id).FirstOrDefault();
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
