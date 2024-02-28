using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baPhotoGraphersInfo
        {
        public long Id { get; set; }
        public int PS_User_pkey { get; set; }
        public string PS_User_Role { get; set; }
        public string PS_User_Name { get; set; }
        public string PS_User_First_Name { get; set; }
        public string PS_User_Last_Name { get; set; }
        public string PS_User_Password { get; set; }
        public int PS_User_Roles_Id { get; set; }
        public bool? PS_User_Status { get; set; }
        public string PS_User_PhoneNo { get; set; }
        public string PS_User_Email { get; set; }
        public int PS_Location_pkey { get; set; }
        public string PS_Location_Name { get; set; }
        public int PS_Store_ID { get; set; }
        public string PS_Store_Name { get; set; }
        public string CountryCode { get; set; }
        public string StoreCode { get; set; }
        public string UserName { get; set; }
        public string StatusName { get; set; }
        public string Photograper { get; set; }
        public int PS_Substore_ID { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<photographersinfo> lst_photographersinfo = new List<photographersinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    photographersinfo photographersinfo = new photographersinfo();
                    
                    photographersinfo.Id = 1;
                    photographersinfo.PS_User_pkey = 2;
                    photographersinfo.PS_User_Role = "";
                    photographersinfo.PS_User_Name = "";
                    photographersinfo.PS_User_First_Name = "";
                    photographersinfo.PS_User_Last_Name = "";
                    photographersinfo.PS_User_Password = "";
                    photographersinfo.PS_User_Roles_Id = 2;
                    photographersinfo.PS_User_Status =  false;
                    photographersinfo.PS_User_PhoneNo = "";
                    photographersinfo.PS_User_Email = "";
                    photographersinfo.PS_Location_pkey = 2;
                    photographersinfo.PS_Location_Name = "";
                    photographersinfo.PS_Store_ID = 4;
                    photographersinfo.PS_Store_Name = "";
                    photographersinfo.CountryCode = "";
                    photographersinfo.StoreCode = "";
                    photographersinfo.UserName = "";
                    photographersinfo.StatusName = "";
                    photographersinfo.Photograper = "";
                    photographersinfo.PS_Substore_ID = 5;
                    photographersinfo.IsActive = true; 

                    lst_photographersinfo.Add(photographersinfo);

                    var Id = lst_photographersinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PhotoGraphersInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.PhotoGraphersInfos.AddRange(lst_photographersinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.PhotoGraphersInfos.AddRange(lst_photographersinfo);
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

        public static baPhotoGraphersInfo GetPhotoGraphersInfoById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PhotoGraphersInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPhotoGraphersInfo
                        {
                        Id = p.Id,
                        PS_User_pkey = p.PS_User_pkey,
                        PS_User_Role = p.PS_User_Role,
                        PS_User_Name = p.PS_User_Name,
                        PS_User_First_Name = p.PS_User_First_Name,
                        PS_User_Last_Name = p.PS_User_Last_Name,
                        PS_User_Password = p.PS_User_Password,
                        PS_User_Roles_Id = p.PS_User_Roles_Id,
                        PS_User_Status = p.PS_User_Status,
                        PS_User_PhoneNo = p.PS_User_PhoneNo,
                        PS_User_Email = p.PS_User_Email,
                        PS_Location_pkey = p.PS_Location_pkey,
                        PS_Location_Name = p.PS_Location_Name,
                        PS_Store_ID = p.PS_Store_ID,
                        PS_Store_Name = p.PS_Store_Name,
                        CountryCode = p.CountryCode,
                        StoreCode = p.StoreCode,
                        UserName = p.UserName,
                        StatusName = p.StatusName,
                        Photograper = p.Photograper,
                        PS_Substore_ID = p.PS_Substore_ID,
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

        public static List<baPhotoGraphersInfo> GetPhotoGraphersInfoData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PhotoGraphersInfos.Where(p => p.IsActive == true).Select(p => new baPhotoGraphersInfo
                        {
                        Id = p.Id,
                        PS_User_pkey = p.PS_User_pkey,
                        PS_User_Role = p.PS_User_Role,
                        PS_User_Name = p.PS_User_Name,
                        PS_User_First_Name = p.PS_User_First_Name,
                        PS_User_Last_Name = p.PS_User_Last_Name,
                        PS_User_Password = p.PS_User_Password,
                        PS_User_Roles_Id = p.PS_User_Roles_Id,
                        PS_User_Status = p.PS_User_Status,
                        PS_User_PhoneNo = p.PS_User_PhoneNo,
                        PS_User_Email = p.PS_User_Email,
                        PS_Location_pkey = p.PS_Location_pkey,
                        PS_Location_Name = p.PS_Location_Name,
                        PS_Store_ID = p.PS_Store_ID,
                        PS_Store_Name = p.PS_Store_Name,
                        CountryCode = p.CountryCode,
                        StoreCode = p.StoreCode,
                        UserName = p.UserName,
                        StatusName = p.StatusName,
                        Photograper = p.Photograper,
                        PS_Substore_ID = p.PS_Substore_ID,
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

        public static bool Insert ( baPhotoGraphersInfo baPhotoGraphersInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    photographersinfo photographersinfo = new photographersinfo();

                    photographersinfo.Id = baPhotoGraphersInfo.Id;
                    photographersinfo.PS_User_pkey = baPhotoGraphersInfo.PS_User_pkey;
                    photographersinfo.PS_User_Role = baPhotoGraphersInfo.PS_User_Role;
                    photographersinfo.PS_User_Name = baPhotoGraphersInfo.PS_User_Name;
                    photographersinfo.PS_User_First_Name = baPhotoGraphersInfo.PS_User_First_Name;
                    photographersinfo.PS_User_Last_Name = baPhotoGraphersInfo.PS_User_Last_Name;
                    photographersinfo.PS_User_Password = baPhotoGraphersInfo.PS_User_Password;
                    photographersinfo.PS_User_Roles_Id = baPhotoGraphersInfo.PS_User_Roles_Id;
                    photographersinfo.PS_User_Status = baPhotoGraphersInfo.PS_User_Status;
                    photographersinfo.PS_User_PhoneNo = baPhotoGraphersInfo.PS_User_PhoneNo;
                    photographersinfo.PS_User_Email = baPhotoGraphersInfo.PS_User_Email;
                    photographersinfo.PS_Location_pkey = baPhotoGraphersInfo.PS_Location_pkey;
                    photographersinfo.PS_Location_Name = baPhotoGraphersInfo.PS_Location_Name;
                    photographersinfo.PS_Store_ID = baPhotoGraphersInfo.PS_Store_ID;
                    photographersinfo.PS_Store_Name = baPhotoGraphersInfo.PS_Store_Name;
                    photographersinfo.CountryCode = baPhotoGraphersInfo.CountryCode;
                    photographersinfo.StoreCode = baPhotoGraphersInfo.StoreCode;
                    photographersinfo.UserName = baPhotoGraphersInfo.UserName;
                    photographersinfo.StatusName = baPhotoGraphersInfo.StatusName;
                    photographersinfo.Photograper = baPhotoGraphersInfo.Photograper;
                    photographersinfo.PS_Substore_ID = baPhotoGraphersInfo.PS_Substore_ID;
                    photographersinfo.IsActive = baPhotoGraphersInfo.IsActive;

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

        public static bool Update ( baPhotoGraphersInfo baPhotoGraphersInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PhotoGraphersInfos.Where(p => p.Id == baPhotoGraphersInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        photographersinfo photographersinfo = new photographersinfo();

                        photographersinfo.Id = baPhotoGraphersInfo.Id;
                        photographersinfo.PS_User_pkey = baPhotoGraphersInfo.PS_User_pkey;
                        photographersinfo.PS_User_Role = baPhotoGraphersInfo.PS_User_Role;
                        photographersinfo.PS_User_Name = baPhotoGraphersInfo.PS_User_Name;
                        photographersinfo.PS_User_First_Name = baPhotoGraphersInfo.PS_User_First_Name;
                        photographersinfo.PS_User_Last_Name = baPhotoGraphersInfo.PS_User_Last_Name;
                        photographersinfo.PS_User_Password = baPhotoGraphersInfo.PS_User_Password;
                        photographersinfo.PS_User_Roles_Id = baPhotoGraphersInfo.PS_User_Roles_Id;
                        photographersinfo.PS_User_Status = baPhotoGraphersInfo.PS_User_Status;
                        photographersinfo.PS_User_PhoneNo = baPhotoGraphersInfo.PS_User_PhoneNo;
                        photographersinfo.PS_User_Email = baPhotoGraphersInfo.PS_User_Email;
                        photographersinfo.PS_Location_pkey = baPhotoGraphersInfo.PS_Location_pkey;
                        photographersinfo.PS_Location_Name = baPhotoGraphersInfo.PS_Location_Name;
                        photographersinfo.PS_Store_ID = baPhotoGraphersInfo.PS_Store_ID;
                        photographersinfo.PS_Store_Name = baPhotoGraphersInfo.PS_Store_Name;
                        photographersinfo.CountryCode = baPhotoGraphersInfo.CountryCode;
                        photographersinfo.StoreCode = baPhotoGraphersInfo.StoreCode;
                        photographersinfo.UserName = baPhotoGraphersInfo.UserName;
                        photographersinfo.StatusName = baPhotoGraphersInfo.StatusName;
                        photographersinfo.Photograper = baPhotoGraphersInfo.Photograper;
                        photographersinfo.PS_Substore_ID = baPhotoGraphersInfo.PS_Substore_ID;
                        photographersinfo.IsActive = baPhotoGraphersInfo.IsActive;

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
