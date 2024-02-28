using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baVideoProducts
        {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductLength { get; set; }
        public int ProductQuantity { get; set; }
        public bool IsActive { get; set; }

        public static bool Marge ()
            {
            List<videoobjectfilemapping> lst_videoobjectfilemapping = new List<videoobjectfilemapping>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    videoobjectfilemapping videoobjectfilemapping = new videoobjectfilemapping();

                    videoobjectfilemapping.Id = 1;
                    videoobjectfilemapping.VideoSceneObjectId = "";
                    videoobjectfilemapping.ValueTypeId = 2;
                    videoobjectfilemapping.ChromaPath = "";
                    videoobjectfilemapping.RoutePath = "";
                    videoobjectfilemapping.StreamAudioEnabled = "";
                    videoobjectfilemapping.ResourcePath = "";
                    videoobjectfilemapping.IsActive = true;

                    lst_videoobjectfilemapping.Add(videoobjectfilemapping);

                    var Id = lst_videoobjectfilemapping.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.VideoObjectFileMappings.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.VideoObjectFileMappings.AddRange(lst_videoobjectfilemapping);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.VideoObjectFileMappings.AddRange(lst_videoobjectfilemapping);
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

        public static baVideoObjectFileMapping GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VideoObjectFileMappings.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baVideoObjectFileMapping
                        {
                        Id = p.Id,
                        VideoSceneObjectId = p.VideoSceneObjectId,
                        ValueTypeId = p.ValueTypeId,
                        ChromaPath = p.ChromaPath,
                        RoutePath = p.RoutePath,
                        StreamAudioEnabled = p.StreamAudioEnabled,
                        ResourcePath = p.ResourcePath,
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

        public static List<baVideoObjectFileMapping> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VideoObjectFileMappings.Where(p => p.IsActive == true).Select(p => new baVideoObjectFileMapping
                        {
                        Id = p.Id,
                        VideoSceneObjectId = p.VideoSceneObjectId,
                        ValueTypeId = p.ValueTypeId,
                        ChromaPath = p.ChromaPath,
                        RoutePath = p.RoutePath,
                        StreamAudioEnabled = p.StreamAudioEnabled,
                        ResourcePath = p.ResourcePath,
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


        public static bool Insert ( baVideoObjectFileMapping baVideoObjectFileMapping )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    videoobjectfilemapping videoobjectfilemapping = new videoobjectfilemapping();

                    videoobjectfilemapping.Id = baVideoObjectFileMapping.Id;
                    videoobjectfilemapping.VideoSceneObjectId = baVideoObjectFileMapping.VideoSceneObjectId;
                    videoobjectfilemapping.ValueTypeId = baVideoObjectFileMapping.ValueTypeId;
                    videoobjectfilemapping.ChromaPath = baVideoObjectFileMapping.ChromaPath;
                    videoobjectfilemapping.RoutePath = baVideoObjectFileMapping.RoutePath;
                    videoobjectfilemapping.StreamAudioEnabled = baVideoObjectFileMapping.StreamAudioEnabled;
                    videoobjectfilemapping.ResourcePath = baVideoObjectFileMapping.ResourcePath;
                    videoobjectfilemapping.IsActive = baVideoObjectFileMapping.IsActive;

                    db.VideoObjectFileMappings.Add(videoobjectfilemapping);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baVideoObjectFileMapping baVideoObjectFileMapping )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VideoObjectFileMappings.Where(p => p.Id == baVideoObjectFileMapping.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        videoobjectfilemapping videoobjectfilemapping = new videoobjectfilemapping();

                        videoobjectfilemapping.Id = baVideoObjectFileMapping.Id;
                        videoobjectfilemapping.VideoSceneObjectId = baVideoObjectFileMapping.VideoSceneObjectId;
                        videoobjectfilemapping.ValueTypeId = baVideoObjectFileMapping.ValueTypeId;
                        videoobjectfilemapping.ChromaPath = baVideoObjectFileMapping.ChromaPath;
                        videoobjectfilemapping.RoutePath = baVideoObjectFileMapping.RoutePath;
                        videoobjectfilemapping.StreamAudioEnabled = baVideoObjectFileMapping.StreamAudioEnabled;
                        videoobjectfilemapping.ResourcePath = baVideoObjectFileMapping.ResourcePath;
                        videoobjectfilemapping.IsActive = baVideoObjectFileMapping.IsActive;

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
                    var obj = db.VideoProductses.Where(p => p.Id == Id).FirstOrDefault();
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
