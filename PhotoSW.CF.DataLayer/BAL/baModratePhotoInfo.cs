using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baModratePhotoInfo
        {
        public long Id { get; set; }
        public int PS_Mod_Photo_pkey { get; set; }
        public int PS_Mod_Photo_ID { get; set; }
        public DateTime PS_Mod_Date { get; set; }
        public int PS_Mod_User_ID { get; set; }
        public bool? IsActive { get; set; }
        
        public static bool Marge ()
            {
            List<modratephotoinfo> lst_modratephotoinfo = new List<modratephotoinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    modratephotoinfo modratephotoinfo = new modratephotoinfo();

                    modratephotoinfo.Id = 1;
                    modratephotoinfo.PS_Mod_Photo_pkey = 2;
                    modratephotoinfo.PS_Mod_Photo_ID = 3;
                    modratephotoinfo.PS_Mod_Date = DateTime.Now;
                    modratephotoinfo.PS_Mod_User_ID = 4;
                    modratephotoinfo.IsActive = true;

                    lst_modratephotoinfo.Add(modratephotoinfo);

                    var Id = lst_modratephotoinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ModratePhotoInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.ModratePhotoInfos.AddRange(lst_modratephotoinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ModratePhotoInfos.AddRange(lst_modratephotoinfo);
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

        public static baModratePhotoInfo GetModratePhotoInfoById(int Id)
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ModratePhotoInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baModratePhotoInfo
                        {

                        Id = p.Id,
                        PS_Mod_Photo_pkey = p.PS_Mod_Photo_pkey,
                        PS_Mod_Photo_ID = p.PS_Mod_Photo_ID,
                        PS_Mod_Date = p.PS_Mod_Date,
                        PS_Mod_User_ID = p.PS_Mod_User_ID,
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

        public static List<baModratePhotoInfo> GetModratePhotoInfoData()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ModratePhotoInfos.Where(p => p.IsActive == true).Select(p => new baModratePhotoInfo
                        {
                        Id = p.Id,
                        PS_Mod_Photo_pkey = p.PS_Mod_Photo_pkey,
                        PS_Mod_Photo_ID = p.PS_Mod_Photo_ID,
                        PS_Mod_Date = p.PS_Mod_Date,
                        PS_Mod_User_ID = p.PS_Mod_User_ID,
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

        public static bool Insert ( baModratePhotoInfo baModratePhotoInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    modratephotoinfo modratephotoinfo = new modratephotoinfo();

                    modratephotoinfo.Id = modratephotoinfo.Id;
                    modratephotoinfo.PS_Mod_Photo_pkey = modratephotoinfo.PS_Mod_Photo_pkey;
                    modratephotoinfo.PS_Mod_Photo_ID = modratephotoinfo.PS_Mod_Photo_ID;
                    modratephotoinfo.PS_Mod_Date = modratephotoinfo.PS_Mod_Date;
                    modratephotoinfo.PS_Mod_User_ID = modratephotoinfo.PS_Mod_User_ID;
                    modratephotoinfo.IsActive = modratephotoinfo.IsActive;

                    db.ModratePhotoInfos.Add(modratephotoinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baModratePhotoInfo baModratePhotoInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ModratePhotoInfos.Where(p => p.Id == baModratePhotoInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        modratephotoinfo modratephotoinfo = new modratephotoinfo();

                        modratephotoinfo.Id = modratephotoinfo.Id;
                        modratephotoinfo.PS_Mod_Photo_pkey = modratephotoinfo.PS_Mod_Photo_pkey;
                        modratephotoinfo.PS_Mod_Photo_ID = modratephotoinfo.PS_Mod_Photo_ID;
                        modratephotoinfo.PS_Mod_Date = modratephotoinfo.PS_Mod_Date;
                        modratephotoinfo.PS_Mod_User_ID = modratephotoinfo.PS_Mod_User_ID;
                        modratephotoinfo.IsActive = modratephotoinfo.IsActive;

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
                    var obj = db.ModratePhotoInfos.Where(p => p.Id == Id).FirstOrDefault();
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
