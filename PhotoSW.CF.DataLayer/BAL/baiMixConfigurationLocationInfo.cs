using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
     public class baiMixConfigurationLocationInfo
        {
        public long Id { get; set; }
        public long ConfigurationLocationValueId { get; set; }
        public new string ConfigurationValue { get; set; }
        public int LocationId { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<imixconfigurationlocationinfo> lst_imixconfigurationlocationinfo = new List<imixconfigurationlocationinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    //foreach (var item in lst_str)
                    //{
                    imixconfigurationlocationinfo imixconfigurationlocationinfo = new imixconfigurationlocationinfo();

                    imixconfigurationlocationinfo.Id = 1;
                    imixconfigurationlocationinfo.ConfigurationLocationValueId = 1;
                    imixconfigurationlocationinfo.ConfigurationValue = "";
                    imixconfigurationlocationinfo.LocationId = 2;
                    imixconfigurationlocationinfo.IsActive = true;

                    lst_imixconfigurationlocationinfo.Add(imixconfigurationlocationinfo);

                    var Id = lst_imixconfigurationlocationinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.iMixConfigurationLocationInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.iMixConfigurationLocationInfos.AddRange(lst_imixconfigurationlocationinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.iMixConfigurationLocationInfos.AddRange(lst_imixconfigurationlocationinfo);
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

        public static baiMixConfigurationLocationInfo GetiMixConfigurationLocationInfoById ( int Id )
            {
            try
                {

                imixconfigurationlocationinfo imixconfigurationlocationinfo = new imixconfigurationlocationinfo();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.iMixConfigurationLocationInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baiMixConfigurationLocationInfo
                        {
                        Id = p.Id,
                        ConfigurationLocationValueId = p.ConfigurationLocationValueId,
                        ConfigurationValue = p.ConfigurationValue,
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

        public static List<baiMixConfigurationLocationInfo> GetiMixConfigurationLocationInfoData ()
            {
            try
                {

             //   iMIXconfigurationinfo iMIXconfigurationinfo = new iMIXconfigurationinfo();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.iMixConfigurationLocationInfos.Where(p => p.IsActive == true).Select(p => new baiMixConfigurationLocationInfo
                        {
                        Id = p.Id,
                        ConfigurationLocationValueId = p.ConfigurationLocationValueId,
                        ConfigurationValue = p.ConfigurationValue,
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

        public static bool Insert ( baiMixConfigurationLocationInfo baiMixConfigurationLocationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    imixconfigurationlocationinfo imixconfigurationlocationinfo = new imixconfigurationlocationinfo();

                    imixconfigurationlocationinfo.Id = baiMixConfigurationLocationInfo.Id;
                    imixconfigurationlocationinfo.ConfigurationLocationValueId = baiMixConfigurationLocationInfo.ConfigurationLocationValueId;
                    imixconfigurationlocationinfo.ConfigurationValue = baiMixConfigurationLocationInfo.ConfigurationValue;
                    imixconfigurationlocationinfo.LocationId = baiMixConfigurationLocationInfo.LocationId;
                    imixconfigurationlocationinfo.IsActive = baiMixConfigurationLocationInfo.IsActive;

                    db.iMixConfigurationLocationInfos.Add(imixconfigurationlocationinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baiMixConfigurationLocationInfo baiMixConfigurationLocationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.iMixConfigurationLocationInfos.Where(p => p.Id == baiMixConfigurationLocationInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        imixconfigurationlocationinfo imixconfigurationlocationinfo = new imixconfigurationlocationinfo();

                        imixconfigurationlocationinfo.Id = baiMixConfigurationLocationInfo.Id;
                        imixconfigurationlocationinfo.ConfigurationLocationValueId = baiMixConfigurationLocationInfo.ConfigurationLocationValueId;
                        imixconfigurationlocationinfo.ConfigurationValue = baiMixConfigurationLocationInfo.ConfigurationValue;
                        imixconfigurationlocationinfo.LocationId = baiMixConfigurationLocationInfo.LocationId;
                        imixconfigurationlocationinfo.IsActive = baiMixConfigurationLocationInfo.IsActive;

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
                    var obj = db.iMixConfigurationLocationInfos.Where(p => p.Id == Id).FirstOrDefault();
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
