
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baVideoSceneObject
        {
        public int Id { get; set; }
        public int VideoObject_Pkey { get; set; }
        public string VideoObjectId { get; set; }
        public int SceneId { get; set; }
        public bool GuestVideoObject { get; set; }
        public videoobjectfilemapping ObjectFileMapping { get; set; }
        public bool streamAudioEnabled { get; set; }
        public string FileName { get; set; }
        public bool IsActive { get; set; }

        public static bool Marge ()
            {
            List<videosceneobject> lst_videosceneobject = new List<videosceneobject>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    videosceneobject videosceneobject = new videosceneobject();

                    videosceneobject.Id = 1;
                    videosceneobject.VideoObject_Pkey = 5;
                    videosceneobject.VideoObjectId = "";
                    videosceneobject.SceneId = 4;
                    videosceneobject.GuestVideoObject = false;
                    videosceneobject.streamAudioEnabled = false;
                    videosceneobject.FileName = "";
                    videosceneobject.IsActive = true;

                    lst_videosceneobject.Add(videosceneobject);

                    var Id = lst_videosceneobject.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.VideoSceneObjects.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.VideoSceneObjects.AddRange(lst_videosceneobject);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.VideoSceneObjects.AddRange(lst_videosceneobject);
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

        public static baVideoSceneObject GetVideoSceneObjectDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VideoSceneObjects.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baVideoSceneObject
                        {
                        Id = p.Id,
                        VideoObject_Pkey = p.VideoObject_Pkey,
                        VideoObjectId = p.VideoObjectId,
                        SceneId = p.SceneId,
                        GuestVideoObject = p.GuestVideoObject,
                        streamAudioEnabled = p.streamAudioEnabled,
                        FileName = p.FileName,                       
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

        public static List<baVideoSceneObject> GetVideoSceneObjectData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VideoSceneObjects.Where(p => p.IsActive == true).Select(p => new baVideoSceneObject
                        {
                        Id = p.Id,
                        VideoObject_Pkey = p.VideoObject_Pkey,
                        VideoObjectId = p.VideoObjectId,
                        SceneId = p.SceneId,
                        GuestVideoObject = p.GuestVideoObject,
                        streamAudioEnabled = p.streamAudioEnabled,
                        FileName = p.FileName,
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


        public static bool Insert ( baVideoSceneObject baVideoSceneObject )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    videosceneobject videosceneobject = new videosceneobject();

                    videosceneobject.Id = baVideoSceneObject.Id;
                    videosceneobject.VideoObject_Pkey = baVideoSceneObject.VideoObject_Pkey;
                    videosceneobject.VideoObjectId = baVideoSceneObject.VideoObjectId;
                    videosceneobject.SceneId = baVideoSceneObject.SceneId;
                    videosceneobject.GuestVideoObject = baVideoSceneObject.GuestVideoObject;
                    videosceneobject.streamAudioEnabled = baVideoSceneObject.streamAudioEnabled;
                    videosceneobject.FileName = baVideoSceneObject.FileName;
                    videosceneobject.IsActive = baVideoSceneObject.IsActive;

                    db.VideoSceneObjects.Add(videosceneobject);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baVideoSceneObject baVideoSceneObject )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VideoSceneObjects.Where(p => p.Id == baVideoSceneObject.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        videosceneobject videosceneobject = new videosceneobject();

                        videosceneobject.Id = baVideoSceneObject.Id;
                        videosceneobject.VideoObject_Pkey = baVideoSceneObject.VideoObject_Pkey;
                        videosceneobject.VideoObjectId = baVideoSceneObject.VideoObjectId;
                        videosceneobject.SceneId = baVideoSceneObject.SceneId;
                        videosceneobject.GuestVideoObject = baVideoSceneObject.GuestVideoObject;
                        videosceneobject.streamAudioEnabled = baVideoSceneObject.streamAudioEnabled;
                        videosceneobject.FileName = baVideoSceneObject.FileName;
                        videosceneobject.IsActive = baVideoSceneObject.IsActive;

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
                    var obj = db.VideoSceneObjects.Where(p => p.Id == Id).FirstOrDefault();
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
