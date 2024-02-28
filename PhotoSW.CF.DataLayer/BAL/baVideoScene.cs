using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baVideoScene
        {
        public int Id { get; set; }
        public int SceneId { get; set; }
        public string Name { get; set; }
        public string ScenePath { get; set; }
        public int LocationId { get; set; }
        public string Settings { get; set; }
        public int VideoLength { get; set; }
        public bool IsActiveForAdvanceProcessing { get; set; }
        public string IsActiveForAdvanceProcessingStatus { get; set; }
        public string LocationName { get; set; }
        public bool IsMixerScene { get; set; }
        public int CG_ConfigID { get; set; }
        public List<videosceneobject> lstVideoSceneObject { get; set; }
        public bool IsActive { get; set; }

        public static bool Marge ()
            {
            List<videoscene> lst_videoscene = new List<videoscene>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    videoscene videoscene = new videoscene();

                    videoscene.Id = 1;
                    videoscene.SceneId = 5;
                    videoscene.Name = "";
                    videoscene.ScenePath = "";
                    videoscene.LocationId = 2;
                    videoscene.Settings = "";
                    videoscene.VideoLength = 2;
                    videoscene.IsActiveForAdvanceProcessing = false;
                    videoscene.IsActiveForAdvanceProcessingStatus = "";
                    videoscene.LocationName = "";
                    videoscene.IsMixerScene = false;
                    videoscene.CG_ConfigID = 4;
                    videoscene.IsActive = true;

                    lst_videoscene.Add(videoscene);

                    var Id = lst_videoscene.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.TripCamSettingInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.VideoScenes.AddRange(lst_videoscene);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.VideoScenes.AddRange(lst_videoscene);
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

        public static baVideoScene GetVideoSceneDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VideoScenes.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baVideoScene
                        {
                        Id = p.Id,
                        SceneId = p.SceneId,
                        Name = p.Name,
                        ScenePath = p.ScenePath,
                        LocationId = p.LocationId,
                        VideoLength = p.VideoLength,
                        Settings = p.Settings,
                        IsActiveForAdvanceProcessing = p.IsActiveForAdvanceProcessing,
                        IsActiveForAdvanceProcessingStatus = p.IsActiveForAdvanceProcessingStatus,
                        LocationName = p.LocationName,
                        IsMixerScene = p.IsMixerScene,
                        CG_ConfigID = p.CG_ConfigID,
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

        public static List<baVideoScene> GetVideoSceneData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VideoScenes.Where(p => p.IsActive == true).Select(p => new baVideoScene
                        {
                        Id = p.Id,
                        SceneId = p.SceneId,
                        Name = p.Name,
                        ScenePath = p.ScenePath,
                        LocationId = p.LocationId,
                        VideoLength = p.VideoLength,
                        Settings = p.Settings,
                        IsActiveForAdvanceProcessing = p.IsActiveForAdvanceProcessing,
                        IsActiveForAdvanceProcessingStatus = p.IsActiveForAdvanceProcessingStatus,
                        LocationName = p.LocationName,
                        IsMixerScene = p.IsMixerScene,
                        CG_ConfigID = p.CG_ConfigID,
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


        public static bool Insert ( baVideoScene baVideoScene )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    videoscene videoscene = new videoscene();

                    videoscene.Id = baVideoScene.Id;
                    videoscene.SceneId = baVideoScene.SceneId;
                    videoscene.Name = baVideoScene.Name;
                    videoscene.ScenePath = baVideoScene.ScenePath;
                    videoscene.LocationId = baVideoScene.LocationId;
                    videoscene.Settings = baVideoScene.Settings;
                    videoscene.VideoLength = baVideoScene.VideoLength;
                    videoscene.IsActiveForAdvanceProcessing = baVideoScene.IsActiveForAdvanceProcessing;
                    videoscene.IsActiveForAdvanceProcessingStatus = baVideoScene.IsActiveForAdvanceProcessingStatus;
                    videoscene.LocationName = baVideoScene.LocationName;
                    videoscene.IsMixerScene = baVideoScene.IsMixerScene;
                    videoscene.CG_ConfigID = baVideoScene.CG_ConfigID;
                    videoscene.IsActive = baVideoScene.IsActive;

                    db.VideoScenes.Add(videoscene);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baVideoScene baVideoScene )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VideoScenes.Where(p => p.Id == baVideoScene.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        videoscene videoscene = new videoscene();

                        videoscene.Id = baVideoScene.Id;
                        videoscene.SceneId = baVideoScene.SceneId;
                        videoscene.Name = baVideoScene.Name;
                        videoscene.ScenePath = baVideoScene.ScenePath;
                        videoscene.LocationId = baVideoScene.LocationId;
                        videoscene.Settings = baVideoScene.Settings;
                        videoscene.VideoLength = baVideoScene.VideoLength;
                        videoscene.IsActiveForAdvanceProcessing = baVideoScene.IsActiveForAdvanceProcessing;
                        videoscene.IsActiveForAdvanceProcessingStatus = baVideoScene.IsActiveForAdvanceProcessingStatus;
                        videoscene.LocationName = baVideoScene.LocationName;
                        videoscene.IsMixerScene = baVideoScene.IsMixerScene;
                        videoscene.CG_ConfigID = baVideoScene.CG_ConfigID;
                        videoscene.IsActive = baVideoScene.IsActive;

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
                    var obj = db.VideoScenes.Where(p => p.Id == Id).FirstOrDefault();
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
