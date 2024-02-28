using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
{
    public class baUser
    {
        public long Id { get; set; }
        public int User_pkey { get; set; }
        public string User_Name { get; set; }
        public string User_First_Name { get; set; }
        public string User_Last_Name { get; set; }
        public string User_Password { get; set; }
        public int User_Roles_Id { get; set; }
        public int Location_ID { get; set; }
        public bool? User_Status { get; set; }
        public string User_PhoneNo { get; set; }
        public string User_Email { get; set; }
        public string SyncCode { get; set; }

        public bool? IsActive { get; set; }


        public static bool Marge()
        {
            List<user> lst_companydetail = new List<user>();

            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    //foreach (var item in lst_str)
                    //{
                    user User = new user();
                    User.Id = 1;
                    User.User_pkey = 1;
                    User.User_Name = "Test05";
                    User.User_First_Name = "Jay";
                    User.User_Last_Name = "Shukla";
                    User.User_Password = "123456";
                    User.User_Roles_Id = 1;
                    User.Location_ID = 1;
                    User.User_Status = true;
                    User.User_PhoneNo = "9758421411";
                    User.User_Email = "test@test.com";
                    User.SyncCode = "121";
                  
                    User.IsActive = true;


                    lst_companydetail.Add(User);

                    // }
                    var Id = lst_companydetail.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.Users.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.Users.AddRange(lst_companydetail);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.Users.AddRange(lst_companydetail);
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
       
        //public static string GetUserNameById(int UserId)
        //{
        //    try
        //    {
        //        using (PhotoSWEntities db = new PhotoSWEntities())
        //        {
        //            var obj = db.Users.Where(p => p.UserId == UserId && p.IsActive == true).First().UserName;
        //            return obj;
        //        }
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}
        //public static int GetUserIdById(int UserId)
        //{
        //    try
        //    {
        //        using (PhotoSWEntities db = new PhotoSWEntities())
        //        {
        //            var obj = db.Users.Where(p => p.UserId == UserId && p.IsActive == true).First().Id;
        //            return obj;
        //        }
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}

        public static baUser GetUserDetails(string username, string password)
        {
            try
            {
                user User = new user();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.Users.Where(p => p.User_Name == username && p.User_Password==password && p.IsActive == true).Select(p => new baUser
                    {
                        Id = p.Id,
                        User_pkey = p.User_pkey,
                        User_Name = p.User_Name,
                        User_First_Name = p.User_First_Name,
                        User_Last_Name = p.User_Last_Name,
                        User_Password = p.User_Password,
                        User_Roles_Id = p.User_Roles_Id,
                        Location_ID = p.Location_ID,
                        User_Status = p.User_Status,
                        User_PhoneNo = p.User_PhoneNo,
                        User_Email = p.User_Email,
                        SyncCode = p.SyncCode,

                        IsActive = p.IsActive,

                    }).FirstOrDefault();
                    return obj;
                }
            }
            catch(Exception serviceException)
                {
                return null; ;
            }
        }
        public static baUser GetUserData(int User_Id)
        {
            try
            {

                user User = new user();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.Users.Where(p => p.Id == User_Id && p.IsActive == true).Select(p => new baUser
                    {
                        Id=p.Id,
                       User_pkey = p.User_pkey,
                       User_Name = p.User_Name,
                       User_First_Name = p.User_First_Name,
                       User_Last_Name = p.User_Last_Name,
                       User_Password = p.User_Password,
                       User_Roles_Id = p.User_Roles_Id,
                       Location_ID = p.Location_ID,
                       User_Status = p.User_Status,
                       User_PhoneNo = p.User_PhoneNo,
                       User_Email = p.User_Email,
                       SyncCode = p.SyncCode,
                      
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
        public static baUser GetUserDataById(int Id)
        {
            try
            {

                configurationinfo configurationinfo = new configurationinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.Users.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baUser
                    {
                        Id = p.Id,
                        User_pkey = p.User_pkey,
                        User_Name = p.User_Name,
                        User_First_Name = p.User_First_Name,
                        User_Last_Name = p.User_Last_Name,
                        User_Password = p.User_Password,
                        User_Roles_Id = p.User_Roles_Id,
                        Location_ID = p.Location_ID,
                        User_Status = p.User_Status,
                        User_PhoneNo = p.User_PhoneNo,
                        User_Email = p.User_Email,
                        SyncCode = p.SyncCode,

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

        public static List<baUser> GetUserData()
        {
            try
            {

                configurationinfo configurationinfo = new configurationinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.Users.Where(p => p.IsActive == true).Select(p => new baUser
                    {
                        Id = p.Id,
                        User_pkey = p.User_pkey,
                        User_Name = p.User_Name,
                        User_First_Name = p.User_First_Name,
                        User_Last_Name = p.User_Last_Name,
                        User_Password = p.User_Password,
                        User_Roles_Id = p.User_Roles_Id,
                        Location_ID = p.Location_ID,
                        User_Status = p.User_Status,
                        User_PhoneNo = p.User_PhoneNo,
                        User_Email = p.User_Email,
                        SyncCode = p.SyncCode,

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


        public static int Insert(baUser baUser)
        {
            try
            {

                user User = new user();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                       User.User_pkey = baUser.User_pkey;
                       User.User_Name = baUser.User_Name;
                       User.User_First_Name = baUser.User_First_Name;
                       User.User_Last_Name = baUser.User_Last_Name;
                       User.User_Password = baUser.User_Password;
                       User.User_Roles_Id = baUser.User_Roles_Id;
                       User.Location_ID = baUser.Location_ID;
                       User.User_Status = baUser.User_Status;
                       User.User_PhoneNo = baUser.User_PhoneNo;
                       User.User_Email = baUser.User_Email;
                       User.SyncCode = baUser.SyncCode;
                       User.IsActive = baUser.IsActive;
                       db.Users.Add(User);
                    db.SaveChanges();
                    return (int)User.Id;
                }
            }
            catch
            {
                return 0;
            }
        }

        public static bool Marge(baUser baUser)
        {
            try
            {


                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.Users.Where(p => p.Id == 1).FirstOrDefault();
                    if (obj == null)
                    {
                        user User = new user();
                        
                        User.User_pkey = baUser.User_pkey;
                        User.User_Name = baUser.User_Name;
                        User.User_First_Name = baUser.User_First_Name;
                        User.User_Last_Name = baUser.User_Last_Name;
                        User.User_Password = baUser.User_Password;
                        User.User_Roles_Id = baUser.User_Roles_Id;
                        User.Location_ID = baUser.Location_ID;
                        User.User_Status = baUser.User_Status;
                        User.User_PhoneNo = baUser.User_PhoneNo;
                        User.User_Email = baUser.User_Email;
                        User.SyncCode = baUser.SyncCode;
                        User.IsActive = baUser.IsActive;
                        db.Users.Add(User);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        //obj.Id = baUser.Id;
                        user User = new user();
                        obj.Id = baUser.Id;
                        obj.User_pkey = baUser.User_pkey;
                        obj.User_Name = baUser.User_Name;
                        obj.User_First_Name = baUser.User_First_Name;
                        obj.User_Last_Name = baUser.User_Last_Name;
                        obj.User_Password = baUser.User_Password;
                        obj.User_Roles_Id = baUser.User_Roles_Id;
                        obj.Location_ID = baUser.Location_ID;
                        obj.User_Status = baUser.User_Status;
                        obj.User_PhoneNo = baUser.User_PhoneNo;
                        obj.User_Email = baUser.User_Email;
                        obj.SyncCode = baUser.SyncCode;
                        obj.IsActive = baUser.IsActive;

                        db.SaveChanges();
                        return true;
                    }

                }
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete ( int Id )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.Users.Where(p => p.Id == Id).FirstOrDefault();
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
