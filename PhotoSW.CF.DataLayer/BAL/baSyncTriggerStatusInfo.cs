using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baSyncTriggerStatusInfo
        {
        public int Id { get; set; }
        public long TableId { get; set; }
        public string TableName { get; set; }
        public bool IsSyncTriggerEnable { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<synctriggerstatusinfo> lst_synctriggerstatusinfo = new List<synctriggerstatusinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    synctriggerstatusinfo synctriggerstatusinfo = new synctriggerstatusinfo();

                    synctriggerstatusinfo.Id = 1;
                    synctriggerstatusinfo.TableId = 5;
                    synctriggerstatusinfo.TableName = "";
                    synctriggerstatusinfo.IsSyncTriggerEnable = false;
                    synctriggerstatusinfo.IsActive = true;

                    lst_synctriggerstatusinfo.Add(synctriggerstatusinfo);

                    var Id = lst_synctriggerstatusinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.SyncTriggerStatusInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.SyncTriggerStatusInfos.AddRange(lst_synctriggerstatusinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.SyncTriggerStatusInfos.AddRange(lst_synctriggerstatusinfo);
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

        public static baSyncTriggerStatusInfo GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SyncTriggerStatusInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baSyncTriggerStatusInfo
                        {
                        Id = p.Id,
                        TableId = p.TableId,
                        TableName = p.TableName,
                        IsSyncTriggerEnable = p.IsSyncTriggerEnable,                      
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

        public static List<baSyncTriggerStatusInfo> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SyncTriggerStatusInfos.Where(p => p.IsActive == true).Select(p => new baSyncTriggerStatusInfo
                        {
                        Id = p.Id,
                        TableId = p.TableId,
                        TableName = p.TableName,
                        IsSyncTriggerEnable = p.IsSyncTriggerEnable,
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

        public static bool Insert ( baSyncTriggerStatusInfo baSyncTriggerStatusInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    synctriggerstatusinfo synctriggerstatusinfo = new synctriggerstatusinfo();

                    synctriggerstatusinfo.Id = baSyncTriggerStatusInfo.Id;
                    synctriggerstatusinfo.TableId = baSyncTriggerStatusInfo.TableId;
                    synctriggerstatusinfo.TableName = baSyncTriggerStatusInfo.TableName;
                    synctriggerstatusinfo.IsSyncTriggerEnable = baSyncTriggerStatusInfo.IsSyncTriggerEnable;
                    synctriggerstatusinfo.IsActive = baSyncTriggerStatusInfo.IsActive;

                    db.SyncTriggerStatusInfos.Add(synctriggerstatusinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baSyncTriggerStatusInfo baSyncTriggerStatusInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SyncTriggerStatusInfos.Where(p => p.Id == baSyncTriggerStatusInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        synctriggerstatusinfo synctriggerstatusinfo = new synctriggerstatusinfo();

                        synctriggerstatusinfo.Id = baSyncTriggerStatusInfo.Id;
                        synctriggerstatusinfo.TableId = baSyncTriggerStatusInfo.TableId;
                        synctriggerstatusinfo.TableName = baSyncTriggerStatusInfo.TableName;
                        synctriggerstatusinfo.IsSyncTriggerEnable = baSyncTriggerStatusInfo.IsSyncTriggerEnable;
                        synctriggerstatusinfo.IsActive = baSyncTriggerStatusInfo.IsActive;

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
                    var obj = db.SyncTriggerStatusInfos.Where(p => p.Id == Id).FirstOrDefault();
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
