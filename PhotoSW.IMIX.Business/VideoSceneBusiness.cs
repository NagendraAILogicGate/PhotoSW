using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public  class VideoSceneBusiness
    {
        public string checkIsActiveForAdvance(int locationId)
        {
            return "";
        }
        public string checkIsActiveForVideoProcessing(int locationId)
        {
            return "";
        }
        public bool CheckProfileName(string name)
        {
            return false;
        }
        public string DeleteVideoSceneDetails(int? Sceneid)
        {
            return "";
        }
        public PhotoSW.IMIX.Model.VideoObjectFileMapping GetobjectVideoDetails(int vidobjectId)
        {
            try
                {
                var obj = baVideoObjectFileMapping.GetVideoObjectFileMappingData()
                    .Select(p => new PhotoSW.IMIX.Model.VideoObjectFileMapping
                        {
                        VideoSceneObjectId = p.VideoSceneObjectId,
                        ValueTypeId = p.ValueTypeId,
                        ChromaPath = p.ChromaPath,
                        RoutePath = p.RoutePath,
                        StreamAudioEnabled = p.StreamAudioEnabled,
                        ResourcePath = p.ResourcePath

                        }).FirstOrDefault();
                return obj;
                }
            catch
                {
                return new PhotoSW.IMIX.Model.VideoObjectFileMapping();
                }
            // return new PhotoSW.IMIX.Model.VideoObjectFileMapping();
            }
        public List<PhotoSW.IMIX.Model.Watchersetting> GetSettingWatcher(int LocationId)
        {
            try
                {
                var obj = baWatchersetting.GetWatchersettingData()
                    .Select(p => new PhotoSW.IMIX.Model.Watchersetting
                        {
                        Isstream = p.Isstream,
                        Dg_Semiorder = p.Dg_Semiorder,
                        SceneName = p.SceneName,
                        ProfileName = p.ProfileName,
                        IsMixerScene = p.IsMixerScene
                        
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.Watchersetting>();
                }
            // return new List<PhotoSW.IMIX.Model.Watchersetting>();
            }
        public List<PhotoSW.IMIX.Model.VideoScene> GetVideoScene(int sceneId, int? substoreId = 0)
        {
            try
                {
                var obj = baVideoScene.GetVideoSceneData()
                    .Select(p => new PhotoSW.IMIX.Model.VideoScene
                        {
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
                        CG_ConfigID = p.CG_ConfigID

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.VideoScene>();
                }
            // return new List<PhotoSW.IMIX.Model.VideoScene>();
            }
        public List<PhotoSW.IMIX.Model.VideoScene> GetVideoSceneByCriteria(int locationId, int sceneId)
        {
            try
                {
                var obj = baVideoScene.GetVideoSceneData()
                    .Select(p => new PhotoSW.IMIX.Model.VideoScene
                        {
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
                        CG_ConfigID = p.CG_ConfigID

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.VideoScene>();
                }
            // return new List<PhotoSW.IMIX.Model.VideoScene>();
            }
        public PhotoSW.IMIX.Model.VideoSceneViewModel GetVideoSceneEditToResource(int? Sceneid)
        {
             return new PhotoSW.IMIX.Model.VideoSceneViewModel();
            }
        public List<PhotoSW.IMIX.Model.VideoScene> GetVideoSceneObjects(PhotoSW.IMIX.Model.VideoScene videoSceneObject )
        {
            try
                {
                var obj = baVideoScene.GetVideoSceneData()
                    .Select(p => new PhotoSW.IMIX.Model.VideoScene
                        {
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
                        CG_ConfigID = p.CG_ConfigID

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.VideoScene>();
                }
            // return new List<PhotoSW.IMIX.Model.VideoSceneObject>();
            }
        public PhotoSW.IMIX.Model.VideoSceneViewModel GetVideoSceneToEdit(int? Sceneid)
        {
            return new PhotoSW.IMIX.Model.VideoSceneViewModel();
        }
        public List<PhotoSW.IMIX.Model.VideoSceneObject> GuestVideoObjectBySceneID(int sceneId)
        {
            try
                {
                var obj = baVideoSceneObject.GetVideoSceneObjectData()
                    .Select(p => new PhotoSW.IMIX.Model.VideoSceneObject
                        {
                        SceneId = p.SceneId,
                        VideoObject_Pkey = p.VideoObject_Pkey,
                        VideoObjectId = p.VideoObjectId,
                        GuestVideoObject = p.GuestVideoObject,
                        streamAudioEnabled = p.streamAudioEnabled,
                        FileName = p.FileName

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.VideoSceneObject>();
                }
            // return new List<PhotoSW.IMIX.Model.VideoSceneObject>();
            }
        public bool SaveMixerScene(PhotoSW.IMIX.Model.VideoSceneViewModel VideoScene)
        {
            return false;
        }
        public bool SaveVideoScene(PhotoSW.IMIX.Model.VideoSceneViewModel VideoScene)
        {
            return false;
        }
        public bool SaveVideoSceneObject(string VideoObjectIds)
        {
            return false;
        }
        public bool UpdateSceneGraphicProfile(int sceneID, int configID)
        {
            return false;
        }
    }
}
