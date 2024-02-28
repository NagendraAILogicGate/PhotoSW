using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baGroupInfo
        {
        public long Id { get; set; }
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<groupinfo> lst_groupinfo = new List<groupinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    groupinfo groupdetails = new groupinfo();

                    groupdetails.Id = 1;
                    groupdetails.GroupID = 2;
                    groupdetails.GroupName = "Test";
                    groupdetails.IsActive = true;

                    lst_groupinfo.Add(groupdetails);

                    var Id = lst_groupinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.GroupInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.GroupInfos.AddRange(lst_groupinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.GroupInfos.AddRange(lst_groupinfo);
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

        public static baGroupInfo GetGroupInfoDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.GroupInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baGroupInfo
                        {
                        Id = p.Id,
                        GroupID = p.GroupID,
                        GroupName = p.GroupName,                     
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

        public static List<baGroupInfo> GetGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GroupInfos.Where(p => p.IsActive == true).Select(p => new baGroupInfo
                        {
                        Id = p.Id,
                        GroupID = p.GroupID,
                        GroupName = p.GroupName,
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

        public static bool Insert ( baGroupInfo baGroupInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    groupinfo groupinfo = new groupinfo();

                    groupinfo.Id = baGroupInfo.Id;
                    groupinfo.GroupID = baGroupInfo.GroupID;
                    groupinfo.GroupName = baGroupInfo.GroupName;
                    groupinfo.IsActive = baGroupInfo.IsActive;
                    db.GroupInfos.Add(groupinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baGroupInfo baGroupInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GroupInfos.Where(p => p.Id == baGroupInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        groupinfo groupinfo = new groupinfo();

                        groupinfo.Id = baGroupInfo.Id;
                        groupinfo.GroupID = baGroupInfo.GroupID;
                        groupinfo.GroupName = baGroupInfo.GroupName;
                        groupinfo.IsActive = baGroupInfo.IsActive;

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
                    var obj = db.GroupInfos.Where(p => p.Id == Id).FirstOrDefault();
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
