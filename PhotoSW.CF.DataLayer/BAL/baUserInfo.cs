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
    public class baUserInfo
    {
       
        public long Id { get; set; }
        public int UserId { get; set; }
        public string Photographer { get; set; }
        public string UserName { get; set; }
        public int Role_ID { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<userinfo> lst_userinfo = new List<userinfo>();

            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    //foreach (var item in lst_str)
                    //{
                    userinfo userinfo = new userinfo();
                    userinfo.Id = 1;
                    userinfo.UserId = 1;
                    userinfo.Photographer = "PG";
                    userinfo.UserName = "Test";
                    userinfo.Role_ID = 1;
                    userinfo.IsActive = true;



                    lst_userinfo.Add(userinfo);

                    var Id = lst_userinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.UserInfos.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.UserInfos.AddRange(lst_userinfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.UserInfos.AddRange(lst_userinfo);
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

        public static bool Delete ( int Id )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.UserInfos.Where(p => p.Id == Id).FirstOrDefault();
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
