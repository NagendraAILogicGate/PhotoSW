using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.BAL;
//using PhotoSW.CF.DataLayer.BAL;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.Business
{
    public class UserBusiness
    {
        public List<PhotoGraphersInfo> GetPhotoGraphersList(int storeId)
        {
            var obj = baPhotoGrapherInfo.GetPhotoGrapherInfoData().Where(p => p.PS_Store_ID == storeId)
                 .Select(p => new PhotoGraphersInfo
                 {

                     //Id = p.Id,
                     CountryCode = p.CountryCode,
                     DG_Location_Name = p.PS_Location_Name,
                     DG_Location_pkey = p.PS_Location_pkey,
                     DG_Store_ID = p.PS_Store_ID,
                     DG_Store_Name = p.PS_Store_Name,
                     DG_Substore_ID = p.PS_Substore_ID,
                     DG_User_Email = p.PS_User_Email,
                     DG_User_First_Name = p.PS_User_First_Name,
                     DG_User_Last_Name = p.PS_User_Last_Name,
                     DG_User_Name = p.PS_User_Name,
                     DG_User_Password = p.PS_User_Password,
                     DG_User_PhoneNo = p.PS_User_PhoneNo,
                     DG_User_pkey = p.PS_User_pkey,
                     DG_User_Role = p.PS_User_Role,
                     DG_User_Roles_Id = p.PS_User_Roles_Id,
                     DG_User_Status = p.PS_User_Status,
                     //FullName = p.FullName,
                     Photograper = p.Photograper,
                     StatusName = p.StatusName,
                     StoreCode = p.StoreCode,
                     UserName = p.UserName,

                     // IsActive = p.IsActive,

                 }).ToList();
            return obj;
        }
        public bool AddUpdateUserDetails(int DG_User_pkey, string DG_User_Name,
           string DG_User_First_Name, string DG_User_Last_Name,
           string DG_User_Password, int DG_User_Roles_Id,
           int DG_Location_ID, bool? DG_User_Status,
           string DG_User_PhoneNo, string DG_User_Email,
           string SyncCode, string LocationName, string UserRole,int StoreID,int LocationPkey)
        {
            bool retval = false;
            try
            {
                baUsersInfo userinfo = new baUsersInfo();
                userinfo.PS_User_pkey = DG_User_pkey;
                userinfo.PS_User_Name = DG_User_Name;
                userinfo.PS_User_First_Name = DG_User_First_Name;
                userinfo.PS_User_Last_Name = DG_User_Last_Name;
                userinfo.PS_User_Password = DG_User_Password;
                userinfo.PS_User_Roles_Id = DG_User_Roles_Id;
                userinfo.PS_Location_ID = DG_Location_ID;
                userinfo.PS_User_Status = DG_User_Status;
                userinfo.PS_User_PhoneNo = DG_User_PhoneNo;
                userinfo.PS_User_Email = DG_User_Email;
                userinfo.Location_Name = LocationName;
                userinfo.Store_ID = StoreID;
                userinfo.User_Role = UserRole;
                userinfo.User_CreatedDate = System.DateTime.Now;
                userinfo.SyncCode = SyncCode;
                userinfo.IsSynced = true;
                userinfo.User_Role = UserRole;
                userinfo.StatusName = DG_User_Status == true ? "Active" : "Inactive";
                userinfo.CountryCode = "91";
                userinfo.Store_Name = LocationName;
                userinfo.UserFullName = DG_User_First_Name + " " + DG_User_Last_Name;
                userinfo.IsActive = true;
                userinfo.UserName = DG_User_Name;
                userinfo.Location_pkey = LocationPkey;
                if (DG_User_pkey == 0)
                {
                    retval = baUsersInfo.Insert(userinfo);
                }
                else
                {
                    retval = baUsersInfo.Update(userinfo);
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return retval;

        }



        public bool DeleteUsers(int userID)
        {
            return false;
        }
        public bool EncryptUsersPwd(Dictionary<int, string> ltEncryptedpwd)
        {
            return false;
        }
        public List<PhotoSW.IMIX.Model.UsersInfo> GetChildUserDetailByUserId(int roleId)
        {

            List<PhotoSW.IMIX.Model.UsersInfo> obj = new List<PhotoSW.IMIX.Model.UsersInfo>();
            try
            {
                while (true)
                {
                    if (roleId == 1)
                    {
                        return baUsersInfo.GetUsersInfoData().Where(v => v.IsActive == true).Select(p => new UsersInfo
                        {
                            DG_User_pkey = p.PS_User_pkey,
                            DG_User_Name = p.PS_User_Name,
                            DG_User_First_Name = p.PS_User_First_Name,
                            DG_User_Last_Name = p.PS_User_Last_Name,
                            DG_User_Password = p.PS_User_Password,
                            DG_User_Roles_Id = p.PS_User_Roles_Id,
                            DG_Location_ID = p.PS_Location_ID,
                            DG_User_Status = p.PS_User_Status,
                            DG_User_PhoneNo = p.PS_User_PhoneNo,
                            DG_User_Email = p.PS_User_Email,
                            DG_User_CreatedDate = p.User_CreatedDate,
                            SyncCode = p.SyncCode,
                            IsSynced = p.IsSynced,
                            DG_User_Role = p.User_Role,
                            DG_Location_Name = p.Location_Name,
                            DG_Store_ID = p.Store_ID,
                            DG_Location_pkey = p.Location_pkey,
                            UserName = p.UserName,
                            StatusName = p.StatusName,
                            DG_Store_Name = p.Store_Name,
                            CountryCode = p.CountryCode,
                            StoreCode = p.StoreCode,
                            UserFullName = p.UserFullName,
                            DG_Substore_ID = p.Substore_ID,
                            ServerHotFolderPath = p.ServerHotFolderPath,
                        }).ToList();
                    }
                    obj = baUsersInfo.GetUsersInfoData().Where(p => p.PS_User_Roles_Id == roleId).Select(p => new UsersInfo
                    {
                        DG_User_pkey = p.PS_User_pkey,
                        DG_User_Name = p.PS_User_Name,
                        DG_User_First_Name = p.PS_User_First_Name,
                        DG_User_Last_Name = p.PS_User_Last_Name,
                        DG_User_Password = p.PS_User_Password,
                        DG_User_Roles_Id = p.PS_User_Roles_Id,
                        DG_Location_ID = p.PS_Location_ID,
                        DG_User_Status = p.PS_User_Status,
                        DG_User_PhoneNo = p.PS_User_PhoneNo,
                        DG_User_Email = p.PS_User_Email,
                        DG_User_CreatedDate = p.User_CreatedDate,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_User_Role = p.User_Role,
                        DG_Location_Name = p.Location_Name,
                        DG_Store_ID = p.Store_ID,
                        DG_Location_pkey = p.Location_pkey,
                        UserName = p.UserName,
                        StatusName = p.StatusName,
                        DG_Store_Name = p.Store_Name,
                        CountryCode = p.CountryCode,
                        StoreCode = p.StoreCode,
                        UserFullName = p.UserFullName,
                        DG_Substore_ID = p.Substore_ID,
                        ServerHotFolderPath = p.ServerHotFolderPath,
                    }).ToList();

                    break;
                }


                return obj;
            }
            catch (Exception)
            {

                return new List<PhotoSW.IMIX.Model.UsersInfo>();
            }

        }
        public List<PhotoSW.IMIX.Model.UserInfo> GetPhotoGrapher()
        {

            return new List<PhotoSW.IMIX.Model.UserInfo>();


        }
        public List<PhotoSW.IMIX.Model.UserInfo> GetPhotoGraphersList()
        {
            return new List<PhotoSW.IMIX.Model.UserInfo>();

        }
        //GetUsersInfoDataById
        public PhotoSW.IMIX.Model.UsersInfo GetUsersInfoDataById(long ID)
        {
            PhotoSW.IMIX.Model.UsersInfo obj = new PhotoSW.IMIX.Model.UsersInfo();
            try
            {
                obj = baUsersInfo.GetUsersInfoData().Where(p => p.Id == ID).Select(p => new UsersInfo
                {
                    DG_User_pkey = p.PS_User_pkey,
                    DG_User_Name = p.PS_User_Name,
                    DG_User_First_Name = p.PS_User_First_Name,
                    DG_User_Last_Name = p.PS_User_Last_Name,
                    DG_User_Password = p.PS_User_Password,
                    DG_User_Roles_Id = p.PS_User_Roles_Id,
                    DG_Location_ID = p.PS_Location_ID,
                    DG_User_Status = p.PS_User_Status,
                    DG_User_PhoneNo = p.PS_User_PhoneNo,
                    DG_User_Email = p.PS_User_Email,
                    DG_User_CreatedDate = p.User_CreatedDate,
                    SyncCode = p.SyncCode,
                    IsSynced = p.IsSynced,
                    DG_User_Role = p.User_Role,
                    DG_Location_Name = p.Location_Name,
                    DG_Store_ID = p.Store_ID,
                    DG_Location_pkey = p.Location_pkey,
                    UserName = p.UserName,
                    StatusName = p.StatusName,
                    DG_Store_Name = p.Store_Name,
                    CountryCode = p.CountryCode,
                    StoreCode = p.StoreCode,
                    UserFullName = p.UserFullName,
                    DG_Substore_ID = p.Substore_ID,
                    ServerHotFolderPath = p.ServerHotFolderPath,
                }).FirstOrDefault();

                return obj;
            }
            catch (Exception)
            {

                return new PhotoSW.IMIX.Model.UsersInfo();
            }
        }
        public List<PhotoSW.IMIX.Model.UsersInfo> GetUserDetailByUserId(int userId, string userName, int roleId)
        {
            List<PhotoSW.IMIX.Model.UsersInfo> obj = new List<PhotoSW.IMIX.Model.UsersInfo>();
            try
            {
                obj = baUsersInfo.GetUsersInfoData().Where(p => p.Id == userId && p.UserName == userName && p.PS_User_Roles_Id == roleId).Select(p => new UsersInfo
                {
                    DG_User_pkey = p.PS_User_pkey,
                    DG_User_Name = p.PS_User_Name,
                    DG_User_First_Name = p.PS_User_First_Name,
                    DG_User_Last_Name = p.PS_User_Last_Name,
                    DG_User_Password = p.PS_User_Password,
                    DG_User_Roles_Id = p.PS_User_Roles_Id,
                    DG_Location_ID = p.PS_Location_ID,
                    DG_User_Status = p.PS_User_Status,
                    DG_User_PhoneNo = p.PS_User_PhoneNo,
                    DG_User_Email = p.PS_User_Email,
                    DG_User_CreatedDate = p.User_CreatedDate,
                    SyncCode = p.SyncCode,
                    IsSynced = p.IsSynced,
                    DG_User_Role = p.User_Role,
                    DG_Location_Name = p.Location_Name,
                    DG_Store_ID = p.Store_ID,
                    DG_Location_pkey = p.Location_pkey,
                    UserName = p.UserName,
                    StatusName = p.StatusName,
                    DG_Store_Name = p.Store_Name,
                    CountryCode = p.CountryCode,
                    StoreCode = p.StoreCode,
                    UserFullName = p.UserFullName,
                    DG_Substore_ID = p.Substore_ID,
                    ServerHotFolderPath = p.ServerHotFolderPath,
                }).ToList();

                return obj;
            }
            catch (Exception)
            {

                return new List<PhotoSW.IMIX.Model.UsersInfo>();
            }


            //  return new List<PhotoSW.IMIX.Model.UsersInfo>();
        }
        public PhotoSW.IMIX.Model.UsersInfo GetUserDetails(string username, string password)
        {
            PhotoSW.IMIX.Model.UsersInfo obj = new PhotoSW.IMIX.Model.UsersInfo();
            try
            {
                obj = baUsersInfo.GetUsersInfoData().Where(p => p.UserName == username && p.PS_User_Password == password).Select(p => new UsersInfo
                {
                    DG_User_pkey = p.PS_User_pkey,
                    DG_User_Name = p.PS_User_Name,
                    DG_User_First_Name = p.PS_User_First_Name,
                    DG_User_Last_Name = p.PS_User_Last_Name,
                    DG_User_Password = p.PS_User_Password,
                    DG_User_Roles_Id = p.PS_User_Roles_Id,
                    DG_Location_ID = p.PS_Location_ID,
                    DG_User_Status = p.PS_User_Status,
                    DG_User_PhoneNo = p.PS_User_PhoneNo,
                    DG_User_Email = p.PS_User_Email,
                    DG_User_CreatedDate = p.User_CreatedDate,
                    SyncCode = p.SyncCode,
                    IsSynced = p.IsSynced,
                    DG_User_Role = p.User_Role,
                    DG_Location_Name = p.Location_Name,
                    DG_Store_ID = p.Store_ID,
                    DG_Location_pkey = p.Location_pkey,
                    UserName = p.UserName,
                    StatusName = p.StatusName,
                    DG_Store_Name = p.Store_Name,
                    CountryCode = p.CountryCode,
                    StoreCode = p.StoreCode,
                    UserFullName = p.UserFullName,
                    DG_Substore_ID = p.Substore_ID,
                    ServerHotFolderPath = p.ServerHotFolderPath,
                }).FirstOrDefault();

                return obj;
            }
            catch (Exception)
            {

                return new PhotoSW.IMIX.Model.UsersInfo();
            }
        }
        public Dictionary<string, int> GetUserDetailsByUserId(int userId)
        {
            Dictionary<string, int> dicObj = new Dictionary<string, int>();
            var obj = baUser.GetUserData();
            obj.Where(c => c.Id == userId);
            foreach (var i in obj)
            {
                dicObj.Add(i.User_First_Name, (int)i.Id);
            }
            return dicObj;
            //  return new Dictionary<string, int>();
        }
        public List<PhotoSW.IMIX.Model.UsersInfo> GetUserDetailsByUserIddetail(int userId)
        {
            return new List<PhotoSW.IMIX.Model.UsersInfo>();
        }
        public Dictionary<int, string> GetUsersPwdDetails()
        {
            return new Dictionary<int, string>();
        }
        public List<PhotoSW.IMIX.Model.UsersInfo> SearchUserDetails(string FName, string LName,
            int StoreId, string Status, int RoleId, string MobileNumber,
            string EmailId, int locationId, string userName)
        {
            List<PhotoSW.IMIX.Model.UsersInfo> obj = new List<PhotoSW.IMIX.Model.UsersInfo>();
            try
            {
                obj = baUsersInfo.GetUsersInfoData().Where(p =>
                    p.PS_User_First_Name == FName ||
                    p.PS_User_Last_Name == LName ||
                    p.Store_ID == StoreId ||
                    p.PS_User_Roles_Id == RoleId ||
                    p.PS_User_PhoneNo == MobileNumber ||
                    p.PS_User_Email == EmailId ||
                    p.PS_Location_ID == locationId ||
                    p.UserName == userName

                    ).Select(p => new UsersInfo
                    {
                        DG_User_pkey = p.PS_User_pkey,
                        DG_User_Name = p.PS_User_Name,
                        DG_User_First_Name = p.PS_User_First_Name,
                        DG_User_Last_Name = p.PS_User_Last_Name,
                        DG_User_Password = p.PS_User_Password,
                        DG_User_Roles_Id = p.PS_User_Roles_Id,
                        DG_Location_ID = p.PS_Location_ID,
                        DG_User_Status = p.PS_User_Status,
                        DG_User_PhoneNo = p.PS_User_PhoneNo,
                        DG_User_Email = p.PS_User_Email,
                        DG_User_CreatedDate = p.User_CreatedDate,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_User_Role = p.User_Role,
                        DG_Location_Name = p.Location_Name,
                        DG_Store_ID = p.Store_ID,
                        DG_Location_pkey = p.Location_pkey,
                        UserName = p.UserName,
                        StatusName = p.StatusName,
                        DG_Store_Name = p.Store_Name,
                        CountryCode = p.CountryCode,
                        StoreCode = p.StoreCode,
                        UserFullName = p.UserFullName,
                        DG_Substore_ID = p.Substore_ID,
                        ServerHotFolderPath = p.ServerHotFolderPath,
                    }).ToList();

                return obj;
            }
            catch (Exception)
            {

                return new List<PhotoSW.IMIX.Model.UsersInfo>();
            }
        }

    }
}
