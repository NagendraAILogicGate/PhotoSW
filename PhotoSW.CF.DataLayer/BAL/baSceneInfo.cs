using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baSceneInfo
        {
        public int Id { get; set; }
        public int SceneId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int BackGroundId { get; set; }
        public string BackgroundName { get; set; }
        public int BorderId { get; set; }
        public string BorderName { get; set; }
        public int GraphicsId { get; set; }
        public string GraphicName { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public string SceneName { get; set; }
        public bool IsActive { get; set; }

        public static bool Marge ()
            {
            List<sceneinfo> lst_sceneinfo = new List<sceneinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    sceneinfo sceneinfo = new sceneinfo();

                    sceneinfo.Id = 1;
                    sceneinfo.SceneId = 1;
                    sceneinfo.ProductId = 2;
                    sceneinfo.ProductName = "";
                    sceneinfo.BackGroundId = 3;
                    sceneinfo.BackgroundName = "";
                    sceneinfo.BorderId = 2;
                    sceneinfo.BorderName = "";
                    sceneinfo.GraphicsId = 5;
                    sceneinfo.GraphicName = "";
                    sceneinfo.SyncCode = "";
                    sceneinfo.IsSynced = false;
                    sceneinfo.SceneName = "";
                    sceneinfo.IsActive = true;

                    lst_sceneinfo.Add(sceneinfo);

                    var Id = lst_sceneinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.SceneInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.SceneInfos.AddRange(lst_sceneinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.SceneInfos.AddRange(lst_sceneinfo);
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

        public static baSceneInfo GetSceneInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SceneInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baSceneInfo
                        {
                        Id = p.Id,
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
                        SceneName = p.SceneName,
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

        public static List<baSceneInfo> GetSceneInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SceneInfos.Where(p => p.IsActive == true).Select(p => new baSceneInfo
                        {
                        Id = p.Id,
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
                        SceneName = p.SceneName,
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


        public static bool Insert ( baSceneInfo baSceneInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    sceneinfo sceneinfo = new sceneinfo();

                    sceneinfo.Id = baSceneInfo.Id;
                    sceneinfo.SceneId = baSceneInfo.SceneId;
                    sceneinfo.ProductId = baSceneInfo.ProductId;
                    sceneinfo.ProductName = baSceneInfo.ProductName;
                    sceneinfo.BackGroundId = baSceneInfo.BackGroundId;
                    sceneinfo.BackgroundName = baSceneInfo.BackgroundName;
                    sceneinfo.BorderId = baSceneInfo.BorderId;
                    sceneinfo.BorderName = baSceneInfo.BorderName;
                    sceneinfo.GraphicsId = baSceneInfo.GraphicsId;
                    sceneinfo.GraphicName = baSceneInfo.GraphicName;
                    sceneinfo.SyncCode = baSceneInfo.SyncCode;
                    sceneinfo.IsSynced = baSceneInfo.IsSynced;
                    sceneinfo.SceneName = baSceneInfo.SceneName;
                    sceneinfo.IsActive = baSceneInfo.IsActive;

                    db.SceneInfos.Add(sceneinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baSceneInfo baSceneInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SceneInfos.Where(p => p.Id == baSceneInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        sceneinfo sceneinfo = new sceneinfo();

                        sceneinfo.Id = baSceneInfo.Id;
                        sceneinfo.SceneId = baSceneInfo.SceneId;
                        sceneinfo.ProductId = baSceneInfo.ProductId;
                        sceneinfo.ProductName = baSceneInfo.ProductName;
                        sceneinfo.BackGroundId = baSceneInfo.BackGroundId;
                        sceneinfo.BackgroundName = baSceneInfo.BackgroundName;
                        sceneinfo.BorderId = baSceneInfo.BorderId;
                        sceneinfo.BorderName = baSceneInfo.BorderName;
                        sceneinfo.GraphicsId = baSceneInfo.GraphicsId;
                        sceneinfo.GraphicName = baSceneInfo.GraphicName;
                        sceneinfo.SyncCode = baSceneInfo.SyncCode;
                        sceneinfo.IsSynced = baSceneInfo.IsSynced;
                        sceneinfo.SceneName = baSceneInfo.SceneName;
                        sceneinfo.IsActive = baSceneInfo.IsActive;

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
                    var obj = db.SceneInfos.Where(p => p.Id == Id).FirstOrDefault();
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
