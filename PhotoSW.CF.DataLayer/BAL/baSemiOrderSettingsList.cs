using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baSemiOrderSettingsList
        {
        public int Id { get; set; }
       // public semiordersettings SemiOrderSetting { get; set; }
        public int LocationId { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<semiordersettingslist> lst_semiordersettingslist = new List<semiordersettingslist>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    semiordersettingslist semiordersettingslist = new semiordersettingslist();

                    semiordersettingslist.Id = 1;
                  //  semiordersettingslist.SemiOrderSetting = "";
                    semiordersettingslist.LocationId = 2;
                    semiordersettingslist.IsActive = true;

                    lst_semiordersettingslist.Add(semiordersettingslist);

                    var Id = lst_semiordersettingslist.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.SemiOrderSettingsLists.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.SemiOrderSettingsLists.AddRange(lst_semiordersettingslist);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.SemiOrderSettingsLists.AddRange(lst_semiordersettingslist);
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

        public static baSemiOrderSettingsList GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SemiOrderSettingsLists.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baSemiOrderSettingsList
                        {
                        Id = p.Id,
                      //  SemiOrderSetting = p.SemiOrderSetting,
                        LocationId = p.LocationId,                      
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

        public static List<baSemiOrderSettingsList> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SemiOrderSettingsLists.Where(p => p.IsActive == true).Select(p => new baSemiOrderSettingsList
                        {
                        Id = p.Id,
                        //SemiOrderSetting = p.SemiOrderSetting,
                        LocationId = p.LocationId,
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


        public static bool Insert ( baSemiOrderSettingsList baSemiOrderSettingsList )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    semiordersettingslist semiordersettingslist = new semiordersettingslist();

                    semiordersettingslist.Id = semiordersettingslist.Id;
                    semiordersettingslist.LocationId = semiordersettingslist.LocationId;
                    semiordersettingslist.IsActive = semiordersettingslist.IsActive;

                    db.SemiOrderSettingsLists.Add(semiordersettingslist);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baSemiOrderSettingsList baSemiOrderSettingsList )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SemiOrderSettingsLists.Where(p => p.Id == baSemiOrderSettingsList.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        semiordersettingslist semiordersettingslist = new semiordersettingslist();

                        semiordersettingslist.Id = semiordersettingslist.Id;
                        semiordersettingslist.LocationId = semiordersettingslist.LocationId;
                        semiordersettingslist.IsActive = semiordersettingslist.IsActive;

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
                    var obj = db.SemiOrderSettingsLists.Where(p => p.Id == Id).FirstOrDefault();
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
