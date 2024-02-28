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
    public class baActivityInfo
        {
        public long Id { get; set; }
        public int PS_Acitivity_Action_Pkey { get; set; }
        public int PS_Acitivity_ActionType { get; set; }
        public DateTime PS_Acitivity_Date { get; set; }
        public int PS_Acitivity_By { get; set; }
        public string PS_Acitivity_Descrption { get; set; }
        public int PS_Reference_ID { get; set; }
        public int PS_Actions_pkey { get; set; }
        public string PS_Actions_Name { get; set; }
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public string Version { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<activityinfo> lst_activityinfo = new List<activityinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    //foreach (var item in lst_str)
                    //{
                    activityinfo activityinfo = new activityinfo();

                    activityinfo.Id = 1;
                    activityinfo.PS_Acitivity_Action_Pkey = 1;
                    activityinfo.PS_Acitivity_ActionType = 3;
                    activityinfo.PS_Acitivity_Date = DateTime.Now;
                    activityinfo.PS_Acitivity_By = 0;
                    activityinfo.PS_Acitivity_Descrption = "Photo description";
                    activityinfo.PS_Reference_ID = 1;
                    activityinfo.PS_Actions_pkey = 1;
                    activityinfo.PS_Actions_Name = "Action Name";
                    activityinfo.Name = "";
                    activityinfo.ActivityDate = DateTime.Now;
                    activityinfo.SyncCode = "";

                    activityinfo.IsSynced = true;
                    activityinfo.Version = "";                   

                    activityinfo.IsActive = true;

                    lst_activityinfo.Add(activityinfo);
                    // }
                    var Id = lst_activityinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ActivityInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.ActivityInfos.AddRange(lst_activityinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ActivityInfos.AddRange(lst_activityinfo);
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
        public static baActivityInfo GetActivityInfoDataById ( long Id )
            {
            try
                {

                activityinfo activityinfo = new activityinfo();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ActivityInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baActivityInfo
                        {
                        Id = p.Id,
                        PS_Acitivity_Action_Pkey = p.PS_Acitivity_Action_Pkey,
                        PS_Acitivity_ActionType = p.PS_Acitivity_ActionType,
                        PS_Acitivity_Date = p.ActivityDate,
                        PS_Acitivity_By = p.PS_Acitivity_By,
                        PS_Acitivity_Descrption = p.PS_Acitivity_Descrption,
                        PS_Reference_ID = p.PS_Reference_ID,
                        PS_Actions_pkey = p.PS_Actions_pkey,
                        PS_Actions_Name = p.PS_Actions_Name,
                        Name = p.Name,
                        ActivityDate = p.ActivityDate,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        Version = p.Version,
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
        public static baActivityInfo GetActivityInfoDataBySubStoreId ( int ID )
            {
            try
                {

                activityinfo activityinfo = new activityinfo();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ActivityInfos.Where(p => p.Id == ID && p.IsActive == true)
                        .Select(p => new baActivityInfo
                            {
                            Id = p.Id,
                            PS_Acitivity_Action_Pkey = p.PS_Acitivity_Action_Pkey,
                            PS_Acitivity_ActionType = p.PS_Acitivity_ActionType,
                            PS_Acitivity_Date = p.ActivityDate,
                            PS_Acitivity_By = p.PS_Acitivity_By,
                            PS_Acitivity_Descrption = p.PS_Acitivity_Descrption,
                            PS_Reference_ID = p.PS_Reference_ID,
                            PS_Actions_pkey = p.PS_Actions_pkey,
                            PS_Actions_Name = p.PS_Actions_Name,
                            Name = p.Name,
                            ActivityDate = p.ActivityDate,
                            SyncCode = p.SyncCode,
                            IsSynced = p.IsSynced,
                            Version = p.Version,
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
        public static List<baActivityInfo> GetActivityInfoData ()
            {
            try
                {

                activityinfo activityinfo = new activityinfo();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ActivityInfos.Where(p => p.IsActive == true).Select(p => new baActivityInfo
                        {
                            Id = p.Id,
                            PS_Acitivity_Action_Pkey = p.PS_Acitivity_Action_Pkey,
                            PS_Acitivity_ActionType = p.PS_Acitivity_ActionType,
                            PS_Acitivity_Date = p.ActivityDate,
                            PS_Acitivity_By = p.PS_Acitivity_By,
                            PS_Acitivity_Descrption = p.PS_Acitivity_Descrption,
                            PS_Reference_ID = p.PS_Reference_ID,
                            PS_Actions_pkey = p.PS_Actions_pkey,
                            PS_Actions_Name = p.PS_Actions_Name,
                            Name = p.Name,
                            ActivityDate = p.ActivityDate,
                            SyncCode = p.SyncCode,
                            IsSynced = p.IsSynced,
                            Version = p.Version,
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
        public static bool Insert ( baActivityInfo baActivityInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    activityinfo activityinfo = new activityinfo();

                    activityinfo.Id = baActivityInfo.Id;
                    activityinfo.PS_Acitivity_Action_Pkey = baActivityInfo.PS_Acitivity_Action_Pkey;
                    activityinfo.PS_Acitivity_ActionType = baActivityInfo.PS_Acitivity_ActionType;
                    activityinfo.PS_Acitivity_Date = baActivityInfo.PS_Acitivity_Date;
                    activityinfo.PS_Acitivity_By = baActivityInfo.PS_Acitivity_By;
                    activityinfo.PS_Acitivity_Descrption = baActivityInfo.PS_Acitivity_Descrption;
                    activityinfo.PS_Reference_ID = baActivityInfo.PS_Reference_ID;
                    activityinfo.PS_Actions_pkey = baActivityInfo.PS_Actions_pkey;
                    activityinfo.PS_Actions_Name = baActivityInfo.PS_Actions_Name;
                    activityinfo.Name = baActivityInfo.Name;
                    activityinfo.ActivityDate = baActivityInfo.ActivityDate;
                    activityinfo.SyncCode = baActivityInfo.SyncCode;

                    activityinfo.IsSynced = true;
                    activityinfo.Version = "";

                    activityinfo.IsActive = true;
                    db.ActivityInfos.Add(activityinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baActivityInfo baActivityInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ActivityInfos.Where(p => p.Id == baActivityInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        activityinfo activityinfo = new activityinfo();

                        activityinfo.Id = baActivityInfo.Id;
                        activityinfo.PS_Acitivity_Action_Pkey = baActivityInfo.PS_Acitivity_Action_Pkey;
                        activityinfo.PS_Acitivity_ActionType = baActivityInfo.PS_Acitivity_ActionType;
                        activityinfo.PS_Acitivity_Date = baActivityInfo.PS_Acitivity_Date;
                        activityinfo.PS_Acitivity_By = baActivityInfo.PS_Acitivity_By;
                        activityinfo.PS_Acitivity_Descrption = baActivityInfo.PS_Acitivity_Descrption;
                        activityinfo.PS_Reference_ID = baActivityInfo.PS_Reference_ID;
                        activityinfo.PS_Actions_pkey = baActivityInfo.PS_Actions_pkey;
                        activityinfo.PS_Actions_Name = baActivityInfo.PS_Actions_Name;
                        activityinfo.Name = baActivityInfo.Name;
                        activityinfo.ActivityDate = baActivityInfo.ActivityDate;
                        activityinfo.SyncCode = baActivityInfo.SyncCode;

                        activityinfo.IsSynced = true;
                        activityinfo.Version = "";

                        activityinfo.IsActive = true;

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
                    var obj = db.ActivityInfos.Where(p => p.Id == Id).FirstOrDefault();
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
