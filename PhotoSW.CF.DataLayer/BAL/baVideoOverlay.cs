using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baVideoOverlay
        {
        public int Id { get; set; }
        public long VideoOverlayId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public long VideoLength { get; set; }
        public int CreatedBy { get; set; }
        public int MediaType { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string IsActiveDisplay { get; set; }
        public bool IsActive { get; set; }

        public static bool Marge ()
            {
            List<videooverlay> lst_videooverlay = new List<videooverlay>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    videooverlay videooverlay = new videooverlay();

                    videooverlay.Id = 1;
                    videooverlay.VideoOverlayId = 5;
                    videooverlay.Name = "";
                    videooverlay.DisplayName = "";
                    videooverlay.Description = "";
                    videooverlay.VideoLength = 2;
                    videooverlay.CreatedBy = 2;
                    videooverlay.MediaType = 3;
                    videooverlay.CreatedOn = DateTime.Now;
                    videooverlay.ModifiedBy = 4;
                    videooverlay.ModifiedOn = DateTime.Now;
                    videooverlay.IsActiveDisplay = "";
                    videooverlay.IsActive = true;

                    lst_videooverlay.Add(videooverlay);

                    var Id = lst_videooverlay.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.TripCamSettingInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.VideoOverlays.AddRange(lst_videooverlay);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.VideoOverlays.AddRange(lst_videooverlay);
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

        public static baVideoOverlay GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VideoOverlays.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baVideoOverlay
                        {
                        Id = p.Id,
                        VideoOverlayId = p.VideoOverlayId,
                        Name = p.Name,
                        DisplayName = p.DisplayName,
                        Description = p.Description,
                        VideoLength = p.VideoLength,
                        CreatedBy = p.CreatedBy,
                        MediaType = p.MediaType,
                        CreatedOn = p.CreatedOn,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedOn = p.ModifiedOn,
                        IsActiveDisplay = p.IsActiveDisplay,
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

        public static List<baVideoOverlay> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VideoOverlays.Where(p => p.IsActive == true).Select(p => new baVideoOverlay
                        {
                        Id = p.Id,
                        VideoOverlayId = p.VideoOverlayId,
                        Name = p.Name,
                        DisplayName = p.DisplayName,
                        Description = p.Description,
                        VideoLength = p.VideoLength,
                        CreatedBy = p.CreatedBy,
                        MediaType = p.MediaType,
                        CreatedOn = p.CreatedOn,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedOn = p.ModifiedOn,
                        IsActiveDisplay = p.IsActiveDisplay,
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


        public static bool Insert ( baVideoOverlay baVideoOverlay )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    videooverlay videooverlay = new videooverlay();

                    videooverlay.Id = baVideoOverlay.Id;
                    videooverlay.VideoOverlayId = baVideoOverlay.VideoOverlayId;
                    videooverlay.Name = baVideoOverlay.Name;
                    videooverlay.DisplayName = baVideoOverlay.DisplayName;
                    videooverlay.Description = baVideoOverlay.Description;
                    videooverlay.VideoLength = baVideoOverlay.VideoLength;
                    videooverlay.CreatedBy = baVideoOverlay.CreatedBy;
                    videooverlay.MediaType = baVideoOverlay.MediaType;
                    videooverlay.CreatedOn = baVideoOverlay.CreatedOn;
                    videooverlay.ModifiedBy = baVideoOverlay.ModifiedBy;
                    videooverlay.ModifiedOn = baVideoOverlay.ModifiedOn;
                    videooverlay.IsActiveDisplay = baVideoOverlay.IsActiveDisplay;
                    videooverlay.IsActive = baVideoOverlay.IsActive;

                    db.VideoOverlays.Add(videooverlay);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baVideoOverlay baVideoOverlay )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VideoOverlays.Where(p => p.Id == baVideoOverlay.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        videooverlay videooverlay = new videooverlay();

                        videooverlay.Id = baVideoOverlay.Id;
                        videooverlay.VideoOverlayId = baVideoOverlay.VideoOverlayId;
                        videooverlay.Name = baVideoOverlay.Name;
                        videooverlay.DisplayName = baVideoOverlay.DisplayName;
                        videooverlay.Description = baVideoOverlay.Description;
                        videooverlay.VideoLength = baVideoOverlay.VideoLength;
                        videooverlay.CreatedBy = baVideoOverlay.CreatedBy;
                        videooverlay.MediaType = baVideoOverlay.MediaType;
                        videooverlay.CreatedOn = baVideoOverlay.CreatedOn;
                        videooverlay.ModifiedBy = baVideoOverlay.ModifiedBy;
                        videooverlay.ModifiedOn = baVideoOverlay.ModifiedOn;
                        videooverlay.IsActiveDisplay = baVideoOverlay.IsActiveDisplay;
                        videooverlay.IsActive = baVideoOverlay.IsActive;

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
                    var obj = db.VideoOverlays.Where(p => p.Id == Id).FirstOrDefault();
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
