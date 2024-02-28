using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baSeperatorTagInfo
        {
        public int Id { get; set; }
        public int SeparatorRFIDTagID { get; set; }
        public string TagID { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public bool IsActive { get; set; }


        public static bool Marge ()
            {
            List<seperatortaginfo> lst_seperatortaginfo = new List<seperatortaginfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    seperatortaginfo seperatortaginfo = new seperatortaginfo();

                    seperatortaginfo.Id = 1;
                    seperatortaginfo.SeparatorRFIDTagID = 1;
                    seperatortaginfo.TagID = "";
                    seperatortaginfo.CreatedOn = DateTime.Now ;
                    seperatortaginfo.LocationId = 3;
                    seperatortaginfo.LocationName = "";
                    seperatortaginfo.IsActive = true;

                    lst_seperatortaginfo.Add(seperatortaginfo);

                    var Id = lst_seperatortaginfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.SeperatorTagInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.SeperatorTagInfos.AddRange(lst_seperatortaginfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.SeperatorTagInfos.AddRange(lst_seperatortaginfo);
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

        public static baSeperatorTagInfo GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SeperatorTagInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baSeperatorTagInfo
                        {
                        Id = p.Id,
                        SeparatorRFIDTagID = p.SeparatorRFIDTagID,
                        TagID = p.TagID,
                        CreatedOn = p.CreatedOn,
                        LocationId = p.LocationId,
                        LocationName = p.LocationName,                      
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

        public static List<baSeperatorTagInfo> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SeperatorTagInfos.Where(p => p.IsActive == true).Select(p => new baSeperatorTagInfo
                        {
                        Id = p.Id,
                        SeparatorRFIDTagID = p.SeparatorRFIDTagID,
                        TagID = p.TagID,
                        CreatedOn = p.CreatedOn,
                        LocationId = p.LocationId,
                        LocationName = p.LocationName,
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

        public static bool Insert ( baSeperatorTagInfo baSeperatorTagInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    seperatortaginfo seperatortaginfo = new seperatortaginfo();

                    seperatortaginfo.Id = baSeperatorTagInfo.Id;
                    seperatortaginfo.SeparatorRFIDTagID = baSeperatorTagInfo.SeparatorRFIDTagID;
                    seperatortaginfo.TagID = baSeperatorTagInfo.TagID;
                    seperatortaginfo.CreatedOn = baSeperatorTagInfo.CreatedOn;
                    seperatortaginfo.LocationId = baSeperatorTagInfo.LocationId;
                    seperatortaginfo.LocationName = baSeperatorTagInfo.LocationName;
                    seperatortaginfo.IsActive = baSeperatorTagInfo.IsActive;

                    db.SeperatorTagInfos.Add(seperatortaginfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baSeperatorTagInfo baSeperatorTagInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SeperatorTagInfos.Where(p => p.Id == baSeperatorTagInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        seperatortaginfo seperatortaginfo = new seperatortaginfo();

                        seperatortaginfo.Id = baSeperatorTagInfo.Id;
                        seperatortaginfo.SeparatorRFIDTagID = baSeperatorTagInfo.SeparatorRFIDTagID;
                        seperatortaginfo.TagID = baSeperatorTagInfo.TagID;
                        seperatortaginfo.CreatedOn = baSeperatorTagInfo.CreatedOn;
                        seperatortaginfo.LocationId = baSeperatorTagInfo.LocationId;
                        seperatortaginfo.LocationName = baSeperatorTagInfo.LocationName;
                        seperatortaginfo.IsActive = baSeperatorTagInfo.IsActive;

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
                    var obj = db.SeperatorTagInfos.Where(p => p.Id == Id).FirstOrDefault();
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
