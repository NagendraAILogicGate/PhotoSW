using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baiMIXStoreConfigurationInfo
        {
        public long Id { get; set; }
        public long iMIXStoreConfigurationValueId { get; set; }
        public long IMIXConfigurationMasterId { get; set; }
        public string ConfigurationValue { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<imixstoreconfigurationinfo> lst_imixstoreconfigurationinfo = new List<imixstoreconfigurationinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    imixstoreconfigurationinfo imixstoreconfigurationinfo = new imixstoreconfigurationinfo();

                    imixstoreconfigurationinfo.Id = 1;
                    imixstoreconfigurationinfo.iMIXStoreConfigurationValueId = 2;
                    imixstoreconfigurationinfo.IMIXConfigurationMasterId = 3;
                    imixstoreconfigurationinfo.ConfigurationValue = "";
                    imixstoreconfigurationinfo.SyncCode = "";
                    imixstoreconfigurationinfo.IsSynced = false;
                    imixstoreconfigurationinfo.ModifiedDate = DateTime.Now;
                    imixstoreconfigurationinfo.IsActive = true;

                    lst_imixstoreconfigurationinfo.Add(imixstoreconfigurationinfo);

                    var Id = lst_imixstoreconfigurationinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.iMIXStoreConfigurationInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.iMIXStoreConfigurationInfos.AddRange(lst_imixstoreconfigurationinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.iMIXStoreConfigurationInfos.AddRange(lst_imixstoreconfigurationinfo);
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

        public static baiMIXStoreConfigurationInfo GetiMIXStoreConfigurationInfoById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.iMIXStoreConfigurationInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baiMIXStoreConfigurationInfo
                        {
                        Id = p.Id,
                        iMIXStoreConfigurationValueId = p.iMIXStoreConfigurationValueId,
                        IMIXConfigurationMasterId = p.IMIXConfigurationMasterId,
                        ConfigurationValue = p.ConfigurationValue,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        ModifiedDate = p.ModifiedDate,                      
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

        public static List<baiMIXStoreConfigurationInfo> GetiMIXStoreConfigurationInfoData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.iMIXStoreConfigurationInfos.Where(p => p.IsActive == true).Select(p => new baiMIXStoreConfigurationInfo
                        {
                        Id = p.Id,
                        iMIXStoreConfigurationValueId = p.iMIXStoreConfigurationValueId,
                        IMIXConfigurationMasterId = p.IMIXConfigurationMasterId,
                        ConfigurationValue = p.ConfigurationValue,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        ModifiedDate = p.ModifiedDate,
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

        public static bool Insert ( baiMIXStoreConfigurationInfo baiMIXStoreConfigurationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    imixstoreconfigurationinfo imixstoreconfigurationinfo = new imixstoreconfigurationinfo();

                    imixstoreconfigurationinfo.Id = baiMIXStoreConfigurationInfo.Id;
                    imixstoreconfigurationinfo.iMIXStoreConfigurationValueId = baiMIXStoreConfigurationInfo.iMIXStoreConfigurationValueId;
                    imixstoreconfigurationinfo.IMIXConfigurationMasterId = baiMIXStoreConfigurationInfo.IMIXConfigurationMasterId;
                    imixstoreconfigurationinfo.ConfigurationValue = baiMIXStoreConfigurationInfo.ConfigurationValue;
                    imixstoreconfigurationinfo.SyncCode = baiMIXStoreConfigurationInfo.SyncCode;
                    imixstoreconfigurationinfo.IsSynced = baiMIXStoreConfigurationInfo.IsSynced;
                    imixstoreconfigurationinfo.ModifiedDate = baiMIXStoreConfigurationInfo.ModifiedDate;
                    imixstoreconfigurationinfo.IsActive = baiMIXStoreConfigurationInfo.IsActive;

                    db.iMIXStoreConfigurationInfos.Add(imixstoreconfigurationinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baiMIXStoreConfigurationInfo baiMIXStoreConfigurationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.iMIXStoreConfigurationInfos.Where(p => p.Id == baiMIXStoreConfigurationInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        imixstoreconfigurationinfo imixstoreconfigurationinfo = new imixstoreconfigurationinfo();

                        imixstoreconfigurationinfo.Id = baiMIXStoreConfigurationInfo.Id;
                        imixstoreconfigurationinfo.iMIXStoreConfigurationValueId = baiMIXStoreConfigurationInfo.iMIXStoreConfigurationValueId;
                        imixstoreconfigurationinfo.IMIXConfigurationMasterId = baiMIXStoreConfigurationInfo.IMIXConfigurationMasterId;
                        imixstoreconfigurationinfo.ConfigurationValue = baiMIXStoreConfigurationInfo.ConfigurationValue;
                        imixstoreconfigurationinfo.SyncCode = baiMIXStoreConfigurationInfo.SyncCode;
                        imixstoreconfigurationinfo.IsSynced = baiMIXStoreConfigurationInfo.IsSynced;
                        imixstoreconfigurationinfo.ModifiedDate = baiMIXStoreConfigurationInfo.ModifiedDate;
                        imixstoreconfigurationinfo.IsActive = baiMIXStoreConfigurationInfo.IsActive;


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
                    var obj = db.iMIXStoreConfigurationInfos.Where(p => p.Id == Id).FirstOrDefault();
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
