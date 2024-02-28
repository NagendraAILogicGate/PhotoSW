using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baVersionHistoryInfo
        {
        public long Id { get; set; }
        public int PS_Version_Pkey { get; set; }
        public string PS_Version_Number { get; set; }
        public DateTime PS_Version_Date { get; set; }
        public int PS_UpdatedBY { get; set; }
        public string PS_Machine { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<versionhistoryinfo> lst_versionhistoryinfo = new List<versionhistoryinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    versionhistoryinfo versionhistoryinfo = new versionhistoryinfo();

                    versionhistoryinfo.Id = 1;
                    versionhistoryinfo.PS_Version_Pkey = 5;
                    versionhistoryinfo.PS_Version_Number = "";
                    versionhistoryinfo.PS_Version_Date = DateTime.Now;
                    versionhistoryinfo.PS_UpdatedBY = 5;
                    versionhistoryinfo.PS_Machine = "";
                    versionhistoryinfo.IsActive = true;

                    lst_versionhistoryinfo.Add(versionhistoryinfo);

                    var Id = lst_versionhistoryinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.VersionHistoryInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.VersionHistoryInfos.AddRange(lst_versionhistoryinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.VersionHistoryInfos.AddRange(lst_versionhistoryinfo);
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

        public static baVersionHistoryInfo GetVersionHistoryInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VersionHistoryInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baVersionHistoryInfo
                        {
                        Id = p.Id,
                        PS_Version_Pkey = p.PS_Version_Pkey,
                        PS_Version_Number = p.PS_Version_Number,
                        PS_Version_Date = p.PS_Version_Date,
                        PS_UpdatedBY = p.PS_UpdatedBY,
                        PS_Machine = p.PS_Machine,
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

        public static List<baVersionHistoryInfo> GetVersionHistoryInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VersionHistoryInfos.Where(p => p.IsActive == true).Select(p => new baVersionHistoryInfo
                        {
                        Id = p.Id,
                        PS_Version_Pkey = p.PS_Version_Pkey,
                        PS_Version_Number = p.PS_Version_Number,
                        PS_Version_Date = p.PS_Version_Date,
                        PS_UpdatedBY = p.PS_UpdatedBY,
                        PS_Machine = p.PS_Machine,
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


        public static bool Insert ( baVersionHistoryInfo baVersionHistoryInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    versionhistoryinfo versionhistoryinfo = new versionhistoryinfo();

                    versionhistoryinfo.Id = baVersionHistoryInfo.Id;
                    versionhistoryinfo.PS_Version_Pkey = baVersionHistoryInfo.PS_Version_Pkey;
                    versionhistoryinfo.PS_Version_Number = baVersionHistoryInfo.PS_Version_Number;
                    versionhistoryinfo.PS_Version_Date = baVersionHistoryInfo.PS_Version_Date;
                    versionhistoryinfo.PS_UpdatedBY = baVersionHistoryInfo.PS_UpdatedBY;
                    versionhistoryinfo.PS_Machine = baVersionHistoryInfo.PS_Machine;
                    versionhistoryinfo.IsActive = baVersionHistoryInfo.IsActive;

                    db.VersionHistoryInfos.Add(versionhistoryinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baVersionHistoryInfo baVersionHistoryInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VersionHistoryInfos.Where(p => p.Id == baVersionHistoryInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        versionhistoryinfo versionhistoryinfo = new versionhistoryinfo();

                        versionhistoryinfo.Id = baVersionHistoryInfo.Id;
                        versionhistoryinfo.PS_Version_Pkey = baVersionHistoryInfo.PS_Version_Pkey;
                        versionhistoryinfo.PS_Version_Number = baVersionHistoryInfo.PS_Version_Number;
                        versionhistoryinfo.PS_Version_Date = baVersionHistoryInfo.PS_Version_Date;
                        versionhistoryinfo.PS_UpdatedBY = baVersionHistoryInfo.PS_UpdatedBY;
                        versionhistoryinfo.PS_Machine = baVersionHistoryInfo.PS_Machine;
                        versionhistoryinfo.IsActive = baVersionHistoryInfo.IsActive;

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
                    var obj = db.VersionHistoryInfos.Where(p => p.Id == Id).FirstOrDefault();
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
