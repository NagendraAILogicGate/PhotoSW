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
    public class baBackupHistory
        {
        public long Id { get; set; }
        public int BackupId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public string ErrorMessage { get; set; }
        public int SubStoreId { get; set; }        
        public bool? IsActive { get; set; }


        public static bool Marge ()
            {
            List<backuphistory> lst_backuphistory = new List<backuphistory>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    backuphistory backuphistory = new backuphistory();

                    backuphistory.Id = 1;
                    backuphistory.BackupId = 3;
                    backuphistory.ScheduleDate = DateTime.Now;
                    backuphistory.StartDate = DateTime.Now;
                    backuphistory.EndDate = DateTime.Now; 
                    backuphistory.Status = 1;
                    backuphistory.ErrorMessage = "";
                    backuphistory.SubStoreId = 1;                    
                    backuphistory.IsActive = true;

                    lst_backuphistory.Add(backuphistory);

                    var Id = lst_backuphistory.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.BackupHistorys.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.BackupHistorys.AddRange(lst_backuphistory);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.BackupHistorys.AddRange(lst_backuphistory);
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

        public static baBackupHistory GetBackupHistoryDataById ( long Id )
            {
            try
                {

                backuphistory backuphistory = new backuphistory();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.BackupHistorys.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baBackupHistory
                        {
                        Id = p.Id,
                        BackupId = p.BackupId,
                        ScheduleDate = p.ScheduleDate,
                        StartDate = p.StartDate,
                        EndDate = p.EndDate,
                        Status = p.Status,
                        ErrorMessage = p.ErrorMessage,
                        SubStoreId = p.SubStoreId,                       
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

        public static List<baBackupHistory> GetBackupHistoryData ()
            {
            try
                {
                backuphistory backuphistory = new backuphistory();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.BackupHistorys.Where(p => p.IsActive == true).Select(p => new baBackupHistory
                        {
                        Id = p.Id,
                        BackupId = p.BackupId,
                        ScheduleDate = p.ScheduleDate,
                        StartDate = p.StartDate,
                        EndDate = p.EndDate,
                        Status = p.Status,
                        ErrorMessage = p.ErrorMessage,
                        SubStoreId = p.SubStoreId,                    
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

        public static bool Insert ( baBackupHistory baBackupHistory )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    backuphistory backuphistory = new backuphistory();

                    backuphistory.Id = baBackupHistory.Id;
                    backuphistory.BackupId = baBackupHistory.BackupId;
                    backuphistory.ScheduleDate = baBackupHistory.ScheduleDate;
                    backuphistory.StartDate = baBackupHistory.StartDate;
                    backuphistory.EndDate = baBackupHistory.EndDate;
                    backuphistory.Status = baBackupHistory.Status;
                    backuphistory.ErrorMessage = baBackupHistory.ErrorMessage;
                    backuphistory.SubStoreId = baBackupHistory.SubStoreId;
                    backuphistory.IsActive = baBackupHistory.IsActive;

                    db.BackupHistorys.Add(backuphistory);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baBackupHistory baBackupHistory )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.BackupHistorys.Where(p => p.Id == baBackupHistory.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        backuphistory backuphistory = new backuphistory();

                        backuphistory.Id = baBackupHistory.Id;
                        backuphistory.BackupId = baBackupHistory.BackupId;
                        backuphistory.ScheduleDate = baBackupHistory.ScheduleDate;
                        backuphistory.StartDate = baBackupHistory.StartDate;
                        backuphistory.EndDate = baBackupHistory.EndDate;
                        backuphistory.Status = baBackupHistory.Status;
                        backuphistory.ErrorMessage = baBackupHistory.ErrorMessage;
                        backuphistory.SubStoreId = baBackupHistory.SubStoreId;
                        backuphistory.IsActive = baBackupHistory.IsActive;

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
                    var obj = db.BackupHistorys.Where(p => p.Id == Id).FirstOrDefault();
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
