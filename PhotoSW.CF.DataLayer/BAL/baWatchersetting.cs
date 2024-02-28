using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baWatchersetting
        {
        public int Id { get; set; }
        public bool Isstream { get; set; }
        public bool Dg_Semiorder { get; set; }
        public string SceneName { get; set; }
        public string ProfileName { get; set; }
        public bool IsMixerScene { get; set; }
        public bool? IsActive { get; set; }
        

        public static bool Marge ()
            {
            List<watchersetting> lst_watchersetting = new List<watchersetting>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    watchersetting watchersetting = new watchersetting();

                    watchersetting.Id = 1;
                    watchersetting.Isstream = false;
                    watchersetting.Dg_Semiorder = false;
                    watchersetting.SceneName = "";
                    watchersetting.ProfileName = "";
                    watchersetting.IsMixerScene = false;
                    watchersetting.IsActive = true;

                    lst_watchersetting.Add(watchersetting);

                    var Id = lst_watchersetting.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.vw_TakingReports.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.WatcherSettings.AddRange(lst_watchersetting);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.WatcherSettings.AddRange(lst_watchersetting);
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

        public static baWatchersetting GetWatchersettingDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.WatcherSettings.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baWatchersetting
                        {
                        Id = p.Id,
                        Isstream = p.Isstream,
                        Dg_Semiorder = p.Dg_Semiorder,
                        SceneName = p.SceneName,
                        ProfileName = p.ProfileName,
                        IsMixerScene = p.IsMixerScene,                      
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

        public static List<baWatchersetting> GetWatchersettingData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.WatcherSettings.Where(p => p.IsActive == true).Select(p => new baWatchersetting
                        {
                        Id = p.Id,
                        Isstream = p.Isstream,
                        Dg_Semiorder = p.Dg_Semiorder,
                        SceneName = p.SceneName,
                        ProfileName = p.ProfileName,
                        IsMixerScene = p.IsMixerScene,
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

        public static bool Insert ( baWatchersetting baWatchersetting )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    watchersetting watchersetting = new watchersetting();

                    watchersetting.Id = watchersetting.Id;
                    watchersetting.Isstream = watchersetting.Isstream;
                    watchersetting.Dg_Semiorder = watchersetting.Dg_Semiorder;
                    watchersetting.SceneName = watchersetting.SceneName;
                    watchersetting.ProfileName = watchersetting.ProfileName;
                    watchersetting.IsMixerScene = watchersetting.IsMixerScene;
                    watchersetting.IsActive = watchersetting.IsActive;

                    db.WatcherSettings.Add(watchersetting);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baWatchersetting baWatchersetting )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.WatcherSettings.Where(p => p.Id == baWatchersetting.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        watchersetting watchersetting = new watchersetting();

                        watchersetting.Id = watchersetting.Id;
                        watchersetting.Isstream = watchersetting.Isstream;
                        watchersetting.Dg_Semiorder = watchersetting.Dg_Semiorder;
                        watchersetting.SceneName = watchersetting.SceneName;
                        watchersetting.ProfileName = watchersetting.ProfileName;
                        watchersetting.IsMixerScene = watchersetting.IsMixerScene;
                        watchersetting.IsActive = watchersetting.IsActive;

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
                    var obj = db.WatcherSettings.Where(p => p.Id == Id).FirstOrDefault();
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
