using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baVideoBackgroundInfo
        {
        public long Id { get; set; }
        public long VideoBackgroundId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int MediaType { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string IsActiveDisplay { get; set; }
        public string MediaTypeDisplay { get; set; }
        public int VideoLength { get; set; }
        public bool IsActive { get; set; }

        public static bool Marge ()
            {
            List<videobackgroundinfo> lst_videobackgroundinfo = new List<videobackgroundinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    videobackgroundinfo videobackgroundinfo = new videobackgroundinfo();

                    videobackgroundinfo.Id = 1;
                    videobackgroundinfo.VideoBackgroundId = 5;
                    videobackgroundinfo.Name = "";
                    videobackgroundinfo.DisplayName = "";
                    videobackgroundinfo.Description = "";
                    videobackgroundinfo.MediaType = 2;
                    videobackgroundinfo.CreatedBy = 2;
                    videobackgroundinfo.CreatedOn = DateTime.Now;
                    videobackgroundinfo.ModifiedBy = 3;
                    videobackgroundinfo.ModifiedOn = DateTime.Now;
                    videobackgroundinfo.IsActiveDisplay = "";
                    videobackgroundinfo.MediaTypeDisplay = "";
                    videobackgroundinfo.VideoLength = 5;
                    videobackgroundinfo.IsActive = true;

                    lst_videobackgroundinfo.Add(videobackgroundinfo);

                    var Id = lst_videobackgroundinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.TripCamSettingInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.VideoBackgroundInfos.AddRange(lst_videobackgroundinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.VideoBackgroundInfos.AddRange(lst_videobackgroundinfo);
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

        public static baVideoBackgroundInfo GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VideoBackgroundInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baVideoBackgroundInfo
                        {
                        Id = p.Id,
                        VideoBackgroundId = p.VideoBackgroundId,
                        Name = p.Name,
                        DisplayName = p.DisplayName,
                        Description = p.Description,
                        MediaType = p.MediaType,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedOn = p.ModifiedOn,
                        IsActiveDisplay = p.IsActiveDisplay,
                        MediaTypeDisplay = p.MediaTypeDisplay,
                        VideoLength = p.VideoLength,
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

        public static List<baVideoBackgroundInfo> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VideoBackgroundInfos.Where(p => p.IsActive == true).Select(p => new baVideoBackgroundInfo
                        {
                        Id = p.Id,
                        VideoBackgroundId = p.VideoBackgroundId,
                        Name = p.Name,
                        DisplayName = p.DisplayName,
                        Description = p.Description,
                        MediaType = p.MediaType,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedOn = p.ModifiedOn,
                        IsActiveDisplay = p.IsActiveDisplay,
                        MediaTypeDisplay = p.MediaTypeDisplay,
                        VideoLength = p.VideoLength,
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


        public static bool Insert ( baVideoBackgroundInfo baVideoBackgroundInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    videobackgroundinfo videobackgroundinfo = new videobackgroundinfo();

                    videobackgroundinfo.Id = baVideoBackgroundInfo.Id;
                    videobackgroundinfo.VideoBackgroundId = baVideoBackgroundInfo.VideoBackgroundId;
                    videobackgroundinfo.Name = baVideoBackgroundInfo.Name;
                    videobackgroundinfo.DisplayName = baVideoBackgroundInfo.DisplayName;
                    videobackgroundinfo.Description = baVideoBackgroundInfo.Description;
                    videobackgroundinfo.MediaType = baVideoBackgroundInfo.MediaType;
                    videobackgroundinfo.CreatedBy = baVideoBackgroundInfo.CreatedBy;
                    videobackgroundinfo.CreatedOn = baVideoBackgroundInfo.CreatedOn;
                    videobackgroundinfo.ModifiedBy = baVideoBackgroundInfo.ModifiedBy;
                    videobackgroundinfo.ModifiedOn = baVideoBackgroundInfo.ModifiedOn;
                    videobackgroundinfo.IsActiveDisplay = baVideoBackgroundInfo.IsActiveDisplay;
                    videobackgroundinfo.MediaTypeDisplay = baVideoBackgroundInfo.MediaTypeDisplay;
                    videobackgroundinfo.VideoLength = baVideoBackgroundInfo.VideoLength;
                    videobackgroundinfo.IsActive = baVideoBackgroundInfo.IsActive;

                    db.VideoBackgroundInfos.Add(videobackgroundinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baVideoBackgroundInfo baVideoBackgroundInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VideoBackgroundInfos.Where(p => p.Id == baVideoBackgroundInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        videobackgroundinfo videobackgroundinfo = new videobackgroundinfo();

                        videobackgroundinfo.Id = baVideoBackgroundInfo.Id;
                        videobackgroundinfo.VideoBackgroundId = baVideoBackgroundInfo.VideoBackgroundId;
                        videobackgroundinfo.Name = baVideoBackgroundInfo.Name;
                        videobackgroundinfo.DisplayName = baVideoBackgroundInfo.DisplayName;
                        videobackgroundinfo.Description = baVideoBackgroundInfo.Description;
                        videobackgroundinfo.MediaType = baVideoBackgroundInfo.MediaType;
                        videobackgroundinfo.CreatedBy = baVideoBackgroundInfo.CreatedBy;
                        videobackgroundinfo.CreatedOn = baVideoBackgroundInfo.CreatedOn;
                        videobackgroundinfo.ModifiedBy = baVideoBackgroundInfo.ModifiedBy;
                        videobackgroundinfo.ModifiedOn = baVideoBackgroundInfo.ModifiedOn;
                        videobackgroundinfo.IsActiveDisplay = baVideoBackgroundInfo.IsActiveDisplay;
                        videobackgroundinfo.MediaTypeDisplay = baVideoBackgroundInfo.MediaTypeDisplay;
                        videobackgroundinfo.VideoLength = baVideoBackgroundInfo.VideoLength;
                        videobackgroundinfo.IsActive = baVideoBackgroundInfo.IsActive;

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
                    var obj = db.VideoBackgroundInfos.Where(p => p.Id == Id).FirstOrDefault();
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
