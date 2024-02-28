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
    public class baiMIXConfigurationInfo
    {
        public long Id { get; set; }
        public long IMIXConfigurationValueId { get; set; }
        public long IMIXConfigurationMasterId { get; set; }
        public string ConfigurationValue { get; set; }
        public int SubstoreId { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<iMIXconfigurationinfo> lst_iMIXconfigurationinfo = new List<iMIXconfigurationinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    //foreach (var item in lst_str)
                    //{
                    iMIXconfigurationinfo iMIXconfigurationinfo = new iMIXconfigurationinfo();

                    iMIXconfigurationinfo.Id = 1;
                    iMIXconfigurationinfo.IMIXConfigurationValueId = 1;
                    iMIXconfigurationinfo.IMIXConfigurationMasterId = 34;
                    iMIXconfigurationinfo.ConfigurationValue = "#008000";
                    iMIXconfigurationinfo.SubstoreId = 3;
                    iMIXconfigurationinfo.SyncCode = "002";
                    iMIXconfigurationinfo.IsSynced = true;
                    iMIXconfigurationinfo.IsActive = true;

                    lst_iMIXconfigurationinfo.Add(iMIXconfigurationinfo);

                    var Id = lst_iMIXconfigurationinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.iMIXConfigurationInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.iMIXConfigurationInfos.AddRange(lst_iMIXconfigurationinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.iMIXConfigurationInfos.AddRange(lst_iMIXconfigurationinfo);
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


        public static baiMIXConfigurationInfo GetiMIXConfigurationInfoById(int Id)
        {
            try
            {

                iMIXconfigurationinfo iMIXconfigurationinfo = new iMIXconfigurationinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.iMIXConfigurationInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baiMIXConfigurationInfo
                    {
                        Id = p.Id,
                        IMIXConfigurationValueId =p.IMIXConfigurationValueId,
                        IMIXConfigurationMasterId =p.IMIXConfigurationMasterId,
                        ConfigurationValue =p.ConfigurationValue,
                        SubstoreId =p.SubstoreId,
                        SyncCode =p.SyncCode,
                        IsSynced =p.IsSynced,
                        IsActive =p.IsActive

                    }).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }
        public static List<baiMIXConfigurationInfo> GetiMIXConfigurationInfoData()
        {
            try
            {

                iMIXconfigurationinfo iMIXconfigurationinfo = new iMIXconfigurationinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.iMIXConfigurationInfos.Where(p => p.IsActive == true).Select(p => new baiMIXConfigurationInfo
                    {
                        Id = p.Id,
                        IMIXConfigurationValueId = p.IMIXConfigurationValueId,
                        IMIXConfigurationMasterId = p.IMIXConfigurationMasterId,
                        ConfigurationValue = p.ConfigurationValue,
                        SubstoreId = p.SubstoreId,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
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

        public static bool Insert ( baiMIXConfigurationInfo baiMIXConfigurationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    iMIXconfigurationinfo iMIXconfigurationinfo = new iMIXconfigurationinfo();

                    iMIXconfigurationinfo.Id = baiMIXConfigurationInfo.Id;
                    iMIXconfigurationinfo.IMIXConfigurationValueId = baiMIXConfigurationInfo.IMIXConfigurationValueId;
                    iMIXconfigurationinfo.IMIXConfigurationMasterId = baiMIXConfigurationInfo.IMIXConfigurationMasterId;
                    iMIXconfigurationinfo.ConfigurationValue = baiMIXConfigurationInfo.ConfigurationValue;
                    iMIXconfigurationinfo.SubstoreId = baiMIXConfigurationInfo.SubstoreId;
                    iMIXconfigurationinfo.SyncCode = baiMIXConfigurationInfo.SyncCode;
                    iMIXconfigurationinfo.IsSynced = baiMIXConfigurationInfo.IsSynced;
                    iMIXconfigurationinfo.IsActive = baiMIXConfigurationInfo.IsActive;

                    db.iMIXConfigurationInfos.Add(iMIXconfigurationinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baiMIXConfigurationInfo baiMIXConfigurationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.iMIXConfigurationInfos.Where(p => p.Id == baiMIXConfigurationInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        iMIXconfigurationinfo iMIXconfigurationinfo = new iMIXconfigurationinfo();

                        iMIXconfigurationinfo.Id = baiMIXConfigurationInfo.Id;
                        iMIXconfigurationinfo.IMIXConfigurationValueId = baiMIXConfigurationInfo.IMIXConfigurationValueId;
                        iMIXconfigurationinfo.IMIXConfigurationMasterId = baiMIXConfigurationInfo.IMIXConfigurationMasterId;
                        iMIXconfigurationinfo.ConfigurationValue = baiMIXConfigurationInfo.ConfigurationValue;
                        iMIXconfigurationinfo.SubstoreId = baiMIXConfigurationInfo.SubstoreId;
                        iMIXconfigurationinfo.SyncCode = baiMIXConfigurationInfo.SyncCode;
                        iMIXconfigurationinfo.IsSynced = baiMIXConfigurationInfo.IsSynced;
                        iMIXconfigurationinfo.IsActive = baiMIXConfigurationInfo.IsActive;

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
                    var obj = db.iMIXConfigurationInfos.Where(p => p.Id == Id).FirstOrDefault();
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
