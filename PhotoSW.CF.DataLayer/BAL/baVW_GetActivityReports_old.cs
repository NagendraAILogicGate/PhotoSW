using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baVW_GetActivityReports_old
        {
        public int Id { get; set; }
        public int PS_Acitivity_Action_Pkey { get; set; }
        public int PS_Acitivity_ActionType { get; set; }
        public DateTime PS_Acitivity_Date { get; set; }
        public int PS_Acitivity_By { get; set; }
        public string PS_Acitivity_Descrption { get; set; }
        public int PS_Reference_ID { get; set; }
        public int PS_User_pkey { get; set; }
        public string PS_User_Name { get; set; }
        public string PS_User_First_Name { get; set; }
        public string PS_User_Last_Name { get; set; }
        public int PS_Actions_pkey { get; set; }
        public string PS_Actions_Name { get; set; }
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<vw_getactivityreports> lst_vw_getactivityreports = new List<vw_getactivityreports>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    vw_getactivityreports vw_getactivityreports = new vw_getactivityreports();

                    vw_getactivityreports.Id = 1;
                    vw_getactivityreports.PS_Acitivity_Action_Pkey = 5;
                    vw_getactivityreports.PS_Acitivity_ActionType = 4;
                    vw_getactivityreports.PS_Acitivity_Date = DateTime.Now;
                    vw_getactivityreports.PS_Acitivity_By = 2;
                    vw_getactivityreports.PS_Acitivity_Descrption = "";
                    vw_getactivityreports.PS_Reference_ID = 2;
                    vw_getactivityreports.PS_User_pkey = 2;
                    vw_getactivityreports.PS_User_Name = "";
                    vw_getactivityreports.PS_User_First_Name = "";
                    vw_getactivityreports.PS_User_Last_Name = "";
                    vw_getactivityreports.PS_Actions_pkey = 4;
                    vw_getactivityreports.PS_Actions_Name = "";
                    vw_getactivityreports.Name = "";
                    vw_getactivityreports.ActivityDate = DateTime.Now;
                    vw_getactivityreports.SyncCode = "";
                    vw_getactivityreports.IsSynced = false;
                    vw_getactivityreports.IsActive = true;

                    lst_vw_getactivityreports.Add(vw_getactivityreports);

                    var Id = lst_vw_getactivityreports.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.vw_GetActivityReportses.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.vw_GetActivityReportses.AddRange(lst_vw_getactivityreports);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.vw_GetActivityReportses.AddRange(lst_vw_getactivityreports);
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

        public static baVW_GetActivityReports_old GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.vw_GetActivityReportses.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baVW_GetActivityReports_old
                        {
                        Id = p.Id,
                        PS_Acitivity_Action_Pkey = p.PS_Acitivity_Action_Pkey,
                        PS_Acitivity_ActionType = p.PS_Acitivity_ActionType,
                        PS_Acitivity_Date = p.PS_Acitivity_Date,
                        PS_Acitivity_By = p.PS_Acitivity_By,
                        PS_Acitivity_Descrption = p.PS_Acitivity_Descrption,
                        PS_Reference_ID = p.PS_Reference_ID,
                        PS_User_pkey = p.PS_User_pkey,
                        PS_User_Name = p.PS_User_Name,
                        PS_User_First_Name = p.PS_User_First_Name,
                        PS_User_Last_Name = p.PS_User_Last_Name,
                        PS_Actions_pkey = p.PS_Actions_pkey,
                        PS_Actions_Name = p.PS_Actions_Name,
                        Name = p.Name,
                        ActivityDate = p.ActivityDate,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
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

        public static List<baVW_GetActivityReports_old> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.vw_GetActivityReportses.Where(p => p.IsActive == true).Select(p => new baVW_GetActivityReports_old
                        {
                        Id = p.Id,
                        PS_Acitivity_Action_Pkey = p.PS_Acitivity_Action_Pkey,
                        PS_Acitivity_ActionType = p.PS_Acitivity_ActionType,
                        PS_Acitivity_Date = p.PS_Acitivity_Date,
                        PS_Acitivity_By = p.PS_Acitivity_By,
                        PS_Acitivity_Descrption = p.PS_Acitivity_Descrption,
                        PS_Reference_ID = p.PS_Reference_ID,
                        PS_User_pkey = p.PS_User_pkey,
                        PS_User_Name = p.PS_User_Name,
                        PS_User_First_Name = p.PS_User_First_Name,
                        PS_User_Last_Name = p.PS_User_Last_Name,
                        PS_Actions_pkey = p.PS_Actions_pkey,
                        PS_Actions_Name = p.PS_Actions_Name,
                        Name = p.Name,
                        ActivityDate = p.ActivityDate,
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

        public static bool Insert ( baVW_GetActivityReports_old baVW_GetActivityReports )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    vw_getactivityreports vw_getactivityreports = new vw_getactivityreports();

                    vw_getactivityreports.Id = baVW_GetActivityReports.Id;
                    vw_getactivityreports.PS_Acitivity_Action_Pkey = baVW_GetActivityReports.PS_Acitivity_Action_Pkey;
                    vw_getactivityreports.PS_Acitivity_ActionType = baVW_GetActivityReports.PS_Acitivity_ActionType;
                    vw_getactivityreports.PS_Acitivity_Date = baVW_GetActivityReports.PS_Acitivity_Date;
                    vw_getactivityreports.PS_Acitivity_By = baVW_GetActivityReports.PS_Acitivity_By;
                    vw_getactivityreports.PS_Acitivity_Descrption = baVW_GetActivityReports.PS_Acitivity_Descrption;
                    vw_getactivityreports.PS_Reference_ID = baVW_GetActivityReports.PS_Reference_ID;
                    vw_getactivityreports.PS_User_pkey = baVW_GetActivityReports.PS_User_pkey;
                    vw_getactivityreports.PS_User_Name = baVW_GetActivityReports.PS_User_Name;
                    vw_getactivityreports.PS_User_First_Name = baVW_GetActivityReports.PS_User_First_Name;
                    vw_getactivityreports.PS_User_Last_Name = baVW_GetActivityReports.PS_User_Last_Name;
                    vw_getactivityreports.PS_Actions_pkey = baVW_GetActivityReports.PS_Actions_pkey;
                    vw_getactivityreports.PS_Actions_Name = baVW_GetActivityReports.PS_Actions_Name;
                    vw_getactivityreports.Name = baVW_GetActivityReports.Name;
                    vw_getactivityreports.ActivityDate = baVW_GetActivityReports.ActivityDate;
                    vw_getactivityreports.SyncCode = baVW_GetActivityReports.SyncCode;
                    vw_getactivityreports.IsSynced = baVW_GetActivityReports.IsSynced;
                    vw_getactivityreports.IsActive = baVW_GetActivityReports.IsActive;

                    db.vw_GetActivityReportses.Add(vw_getactivityreports);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baVW_GetActivityReports_old baVW_GetActivityReports )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.vw_GetActivityReportses.Where(p => p.Id == baVW_GetActivityReports.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        vw_getactivityreports vw_getactivityreports = new vw_getactivityreports();

                        vw_getactivityreports.Id = baVW_GetActivityReports.Id;
                        vw_getactivityreports.PS_Acitivity_Action_Pkey = baVW_GetActivityReports.PS_Acitivity_Action_Pkey;
                        vw_getactivityreports.PS_Acitivity_ActionType = baVW_GetActivityReports.PS_Acitivity_ActionType;
                        vw_getactivityreports.PS_Acitivity_Date = baVW_GetActivityReports.PS_Acitivity_Date;
                        vw_getactivityreports.PS_Acitivity_By = baVW_GetActivityReports.PS_Acitivity_By;
                        vw_getactivityreports.PS_Acitivity_Descrption = baVW_GetActivityReports.PS_Acitivity_Descrption;
                        vw_getactivityreports.PS_Reference_ID = baVW_GetActivityReports.PS_Reference_ID;
                        vw_getactivityreports.PS_User_pkey = baVW_GetActivityReports.PS_User_pkey;
                        vw_getactivityreports.PS_User_Name = baVW_GetActivityReports.PS_User_Name;
                        vw_getactivityreports.PS_User_First_Name = baVW_GetActivityReports.PS_User_First_Name;
                        vw_getactivityreports.PS_User_Last_Name = baVW_GetActivityReports.PS_User_Last_Name;
                        vw_getactivityreports.PS_Actions_pkey = baVW_GetActivityReports.PS_Actions_pkey;
                        vw_getactivityreports.PS_Actions_Name = baVW_GetActivityReports.PS_Actions_Name;
                        vw_getactivityreports.Name = baVW_GetActivityReports.Name;
                        vw_getactivityreports.ActivityDate = baVW_GetActivityReports.ActivityDate;
                        vw_getactivityreports.SyncCode = baVW_GetActivityReports.SyncCode;
                        vw_getactivityreports.IsSynced = baVW_GetActivityReports.IsSynced;
                        vw_getactivityreports.IsActive = baVW_GetActivityReports.IsActive;

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
                    var obj = db.vw_GetActivityReportses.Where(p => p.Id == Id).FirstOrDefault();
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
