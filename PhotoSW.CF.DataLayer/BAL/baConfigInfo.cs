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

    public class baConfigInfo
    {
        public long Id { get; set; }
        public int ConfigID { get; set; }
        public int SubStoreID { get; set; }
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
        public int MasterID { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<configinfo> lst_configinfo = new List<configinfo>();

            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    //foreach (var item in lst_str)
                    //{
                    configinfo configinfo = new configinfo();

                    configinfo.Id = 1;
                    configinfo.ConfigID = 1;
                    configinfo.SubStoreID =3;
                    configinfo.ConfigKey ="";
                    configinfo.ConfigValue ="";
                    configinfo.MasterID =1;
                   
                    configinfo.IsActive = true;


                    lst_configinfo.Add(configinfo);
                    // }
                    var Id = lst_configinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ConfigInfos.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.ConfigInfos.AddRange(lst_configinfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.ConfigInfos.AddRange(lst_configinfo);
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
        public static baConfigInfo GetConfigInfoDataById(int Id)
        {
            try
            {

                configinfo configinfo = new configinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.ConfigInfos.Where(p => p.IsActive == true).Select(p => new baConfigInfo
                    {
                        Id = p.Id,
                        ConfigID = p.ConfigID,
                        SubStoreID = p.SubStoreID,
                        ConfigKey = p.ConfigKey,
                        ConfigValue = p.ConfigValue,
                        MasterID = p.MasterID,
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
        public static baConfigInfo GetConfigInfoDataBySubStoreId(int SubStoreID)
        {
            try
            {

                configinfo configinfo = new configinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.ConfigInfos.Where(p =>p.SubStoreID==SubStoreID && p.IsActive == true)
                        .Select(p => new baConfigInfo
                    {
                        Id = p.Id,
                        ConfigID = p.ConfigID,
                        SubStoreID = p.SubStoreID,
                        ConfigKey = p.ConfigKey,
                        ConfigValue = p.ConfigValue,
                        MasterID = p.MasterID,
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
        public static List<baConfigInfo> GetConfigInfoData()
        {
            try
            {

                configinfo configinfo = new configinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.ConfigInfos.Where(p => p.IsActive == true).Select(p => new baConfigInfo
                    {
                        Id = p.Id,
                        ConfigID = p.ConfigID,
                        SubStoreID = p.SubStoreID,
                        ConfigKey = p.ConfigKey,
                        ConfigValue = p.ConfigValue,
                        MasterID = p.MasterID,
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

        public static bool Delete ( int Id )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ConfigInfos.Where(p => p.Id == Id).FirstOrDefault();
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
