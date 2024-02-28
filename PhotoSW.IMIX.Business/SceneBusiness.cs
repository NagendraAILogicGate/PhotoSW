using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class SceneBusiness //: BaseBusiness
    {

        public bool DeleteScene(int id)
        {
            return false;
        }
        public List<PhotoSW.IMIX.Model.SceneInfo> GetSceneDetails()
        {
            try
                {
                var obj = baSceneInfo.GetSceneInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.SceneInfo
                        {
                        SceneId = p.SceneId,
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        BackGroundId = p.BackGroundId,
                        BackgroundName = p.BackgroundName,
                        BorderId = p.BorderId,
                        BorderName = p.BorderName,
                        GraphicsId = p.GraphicsId,
                        GraphicName = p.GraphicName,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        SceneName = p.SceneName

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.SceneInfo>();
                }

            //return new List<Model.SceneInfo>();
            }
        public PhotoSW.IMIX.Model.SceneInfo GetSceneNameFromID(int id)
        {
            try
                {
                var obj = baSceneInfo.GetSceneInfoData()
                    .Where(p=>p.Id == id)
                    .Select(p => new PhotoSW.IMIX.Model.SceneInfo
                        {
                        SceneId = p.SceneId,
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        BackGroundId = p.BackGroundId,
                        BackgroundName = p.BackgroundName,
                        BorderId = p.BorderId,
                        BorderName = p.BorderName,
                        GraphicsId = p.GraphicsId,
                        GraphicName = p.GraphicName,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        SceneName = p.SceneName

                        }).FirstOrDefault();
                return obj;
                }
            catch
                {
                return new Model.SceneInfo();
                }
            // return new Model.SceneInfo();
            }
        public void SetSceneDetails(PhotoSW.IMIX.Model.SceneInfo sceneInfo)
        {
        }
    }
}
