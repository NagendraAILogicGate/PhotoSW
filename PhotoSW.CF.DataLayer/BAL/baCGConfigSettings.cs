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
    public class baCGConfigSettings
        {
        public long Id { get; set; }
        public string ConfigFileName { get; set; }
        public string Extension { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }

        public static bool Marge ()
            {
            List<cgconfigsettings> lst_cgconfigsettings = new List<cgconfigsettings>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    cgconfigsettings burnorderinfo = new cgconfigsettings();

                    burnorderinfo.Id = 1;
                    burnorderinfo.ConfigFileName = "";
                    burnorderinfo.Extension = "";
                    burnorderinfo.DisplayName = "";
                    burnorderinfo.IsActive = true;

                    lst_cgconfigsettings.Add(burnorderinfo);

                    var Id = lst_cgconfigsettings.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.CGConfigSettingses.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.CGConfigSettingses.AddRange(lst_cgconfigsettings);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.CGConfigSettingses.AddRange(lst_cgconfigsettings);
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

        public static baCGConfigSettings GetCGConfigSettingsDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.CGConfigSettingses.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baCGConfigSettings
                        {
                        Id = p.Id,
                        ConfigFileName = p.ConfigFileName,
                        Extension = p.Extension,
                        DisplayName = p.DisplayName,
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

        public static List<baCGConfigSettings> GetCGConfigSettingsData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.CGConfigSettingses.Where(p => p.IsActive == true).Select(p => new baCGConfigSettings
                        {
                        Id = p.Id,
                        ConfigFileName = p.ConfigFileName,
                        Extension = p.Extension,
                        DisplayName = p.DisplayName,
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

        public static bool Insert ( baCGConfigSettings baCGConfigSettings )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    cgconfigsettings cgconfigsettings = new cgconfigsettings();

                    cgconfigsettings.Id = baCGConfigSettings.Id;
                    cgconfigsettings.ConfigFileName = baCGConfigSettings.ConfigFileName;
                    cgconfigsettings.Extension = baCGConfigSettings.ConfigFileName;
                    cgconfigsettings.DisplayName = baCGConfigSettings.DisplayName;
                    cgconfigsettings.IsActive = baCGConfigSettings.IsActive;

                    db.CGConfigSettingses.Add(cgconfigsettings);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baCGConfigSettings baCGConfigSettings )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.CGConfigSettingses.Where(p => p.Id == baCGConfigSettings.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        cgconfigsettings cgconfigsettings = new cgconfigsettings();
                        cgconfigsettings.Id = baCGConfigSettings.Id;
                        cgconfigsettings.ConfigFileName = baCGConfigSettings.ConfigFileName;
                        cgconfigsettings.Extension = baCGConfigSettings.ConfigFileName;
                        cgconfigsettings.DisplayName = baCGConfigSettings.DisplayName;
                        cgconfigsettings.IsActive = baCGConfigSettings.IsActive;

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
                    var obj = db.CGConfigSettingses.Where(p => p.Id == Id).FirstOrDefault();
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
