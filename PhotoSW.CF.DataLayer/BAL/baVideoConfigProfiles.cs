using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baVideoConfigProfiles
        {
        public long Id { get; set; }
        public long ProfileId { get; set; }
        public string ProfileName { get; set; }
        public string AspectRatio { get; set; }
        public int FrameRate { get; set; }
        public string OutputFormat { get; set; }
        public string VideoCodec { get; set; }
        public string AudioCodec { get; set; }
        public string AutoVideoEffects { get; set; }
        public int LocationId { get; set; }
        public bool IsActive { get; set; }

        public static bool Marge ()
            {
            List<videoconfigprofiles> lst_videoconfigprofiles = new List<videoconfigprofiles>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    videoconfigprofiles videoconfigprofiles = new videoconfigprofiles();

                    videoconfigprofiles.Id = 1;
                    videoconfigprofiles.ProfileId = 5;
                    videoconfigprofiles.ProfileName = "";
                    videoconfigprofiles.AspectRatio = "";
                    videoconfigprofiles.FrameRate = 2;
                    videoconfigprofiles.OutputFormat = "";
                    videoconfigprofiles.VideoCodec = "";
                    videoconfigprofiles.AudioCodec = "";
                    videoconfigprofiles.AutoVideoEffects = "";
                    videoconfigprofiles.LocationId = 4;                    
                    videoconfigprofiles.IsActive = true;

                    lst_videoconfigprofiles.Add(videoconfigprofiles);

                    var Id = lst_videoconfigprofiles.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.TripCamSettingInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.VideoConfigProfiles.AddRange(lst_videoconfigprofiles);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.VideoConfigProfiles.AddRange(lst_videoconfigprofiles);
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

        public static baVideoConfigProfiles GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VideoConfigProfiles.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baVideoConfigProfiles
                        {
                        Id = p.Id,
                        ProfileId = p.ProfileId,
                        ProfileName = p.ProfileName,
                        AspectRatio = p.AspectRatio,
                        FrameRate = p.FrameRate,
                        OutputFormat = p.OutputFormat,
                        VideoCodec = p.VideoCodec,
                        AudioCodec = p.AudioCodec,
                        AutoVideoEffects = p.AutoVideoEffects,
                        LocationId = p.LocationId,
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

        public static List<baVideoConfigProfiles> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VideoConfigProfiles.Where(p => p.IsActive == true).Select(p => new baVideoConfigProfiles
                        {
                        Id = p.Id,
                        ProfileId = p.ProfileId,
                        ProfileName = p.ProfileName,
                        AspectRatio = p.AspectRatio,
                        FrameRate = p.FrameRate,
                        OutputFormat = p.OutputFormat,
                        VideoCodec = p.VideoCodec,
                        AudioCodec = p.AudioCodec,
                        AutoVideoEffects = p.AutoVideoEffects,
                        LocationId = p.LocationId,
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


        public static bool Insert ( baVideoConfigProfiles baVideoConfigProfiles )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    videoconfigprofiles videoconfigprofiles = new videoconfigprofiles();

                    videoconfigprofiles.Id = baVideoConfigProfiles.Id;
                    videoconfigprofiles.ProfileId = baVideoConfigProfiles.ProfileId;
                    videoconfigprofiles.ProfileName = baVideoConfigProfiles.ProfileName;
                    videoconfigprofiles.AspectRatio = baVideoConfigProfiles.AspectRatio;
                    videoconfigprofiles.FrameRate = baVideoConfigProfiles.FrameRate;
                    videoconfigprofiles.OutputFormat = baVideoConfigProfiles.OutputFormat;
                    videoconfigprofiles.VideoCodec = baVideoConfigProfiles.VideoCodec;
                    videoconfigprofiles.AudioCodec = baVideoConfigProfiles.AudioCodec;
                    videoconfigprofiles.AutoVideoEffects = videoconfigprofiles.AutoVideoEffects;
                    videoconfigprofiles.LocationId = baVideoConfigProfiles.LocationId;
                    videoconfigprofiles.IsActive = baVideoConfigProfiles.IsActive;

                    db.VideoConfigProfiles.Add(videoconfigprofiles);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baVideoConfigProfiles baVideoConfigProfiles )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VideoConfigProfiles.Where(p => p.Id == baVideoConfigProfiles.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        videoconfigprofiles videoconfigprofiles = new videoconfigprofiles();

                        videoconfigprofiles.Id = baVideoConfigProfiles.Id;
                        videoconfigprofiles.ProfileId = baVideoConfigProfiles.ProfileId;
                        videoconfigprofiles.ProfileName = baVideoConfigProfiles.ProfileName;
                        videoconfigprofiles.AspectRatio = baVideoConfigProfiles.AspectRatio;
                        videoconfigprofiles.FrameRate = baVideoConfigProfiles.FrameRate;
                        videoconfigprofiles.OutputFormat = baVideoConfigProfiles.OutputFormat;
                        videoconfigprofiles.VideoCodec = baVideoConfigProfiles.VideoCodec;
                        videoconfigprofiles.AudioCodec = baVideoConfigProfiles.AudioCodec;
                        videoconfigprofiles.AutoVideoEffects = videoconfigprofiles.AutoVideoEffects;
                        videoconfigprofiles.LocationId = baVideoConfigProfiles.LocationId;
                        videoconfigprofiles.IsActive = baVideoConfigProfiles.IsActive;

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
                    var obj = db.VideoConfigProfiles.Where(p => p.Id == Id).FirstOrDefault();
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
