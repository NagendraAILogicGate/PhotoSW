using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
     public class baGraphicsInfo
        {
        public long Id { get; set; }
        public int PS_Graphics_pkey { get; set; }
        public string PS_Graphics_Name { get; set; }
        public string PS_Graphics_Displayname { get; set; }
        public bool? PS_Graphics_IsActive { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {

                string path = AppDomain.CurrentDomain.BaseDirectory + "Graphics\\";
                var file_obj = System.IO.Directory.GetFiles(path, "*.png").Select(System.IO.Path.GetFileName);
                List<graphicsinfo> lst_graphicsinfo = new List<graphicsinfo>();
                List<long> lst_Ids = new List<long>();

           

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    { 
                    int i = 0;
                    foreach (var item in file_obj)
                    {
                        graphicsinfo graphicsinfo = new graphicsinfo();

                        graphicsinfo.Id = ++i;
                        graphicsinfo.PS_Graphics_pkey = i;
                        graphicsinfo.PS_Graphics_Name = item;
                        graphicsinfo.PS_Graphics_Displayname = item.Replace(".png","");
                        graphicsinfo.PS_Graphics_IsActive = false;
                        graphicsinfo.SyncCode = "";
                        graphicsinfo.IsSynced = false;
                        graphicsinfo.CreatedBy = 1;
                        graphicsinfo.CreatedDate = DateTime.Now;
                        graphicsinfo.ModifiedBy = 1;
                        graphicsinfo.ModifiedDate = DateTime.Now;
                        graphicsinfo.IsActive = true;
                        lst_Ids.Add(graphicsinfo.Id);
                        lst_graphicsinfo.Add(graphicsinfo);
                    }
                   // var Id = lst_graphicsinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.GraphicsInfos.Where(p => lst_Ids.Contains(p.Id)).ToList();
                    if(IsExist == null)
                        {
                        db.GraphicsInfos.AddRange(lst_graphicsinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.GraphicsInfos.AddRange(lst_graphicsinfo);
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

        public static baGraphicsInfo GetGraphicsInfoDataById(long Id)
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.GraphicsInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baGraphicsInfo
                        {
                        Id = p.Id,
                        PS_Graphics_pkey = p.PS_Graphics_pkey,
                        PS_Graphics_Name = p.PS_Graphics_Name,
                        PS_Graphics_Displayname = p.PS_Graphics_Displayname,
                        PS_Graphics_IsActive = p.PS_Graphics_IsActive,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedDate = p.ModifiedDate,                       
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

        public static List<baGraphicsInfo> GetGraphicsInfoData()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GraphicsInfos.Where(p => p.IsActive == true).Select(p => new baGraphicsInfo
                        {
                        Id = p.Id,
                        PS_Graphics_pkey = p.PS_Graphics_pkey,
                        PS_Graphics_Name = p.PS_Graphics_Name,
                        PS_Graphics_Displayname = p.PS_Graphics_Displayname,
                        PS_Graphics_IsActive = p.PS_Graphics_IsActive,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedDate = p.ModifiedDate,
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

        public static bool Insert ( baGraphicsInfo baGraphicsInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    graphicsinfo graphicsinfo = new graphicsinfo();

                    graphicsinfo.Id = graphicsinfo.Id;
                    graphicsinfo.PS_Graphics_pkey = graphicsinfo.PS_Graphics_pkey;
                    graphicsinfo.PS_Graphics_Name = graphicsinfo.PS_Graphics_Name;
                    graphicsinfo.PS_Graphics_Displayname = graphicsinfo.PS_Graphics_Displayname;
                    graphicsinfo.PS_Graphics_IsActive = graphicsinfo.PS_Graphics_IsActive;
                    graphicsinfo.SyncCode = graphicsinfo.SyncCode;
                    graphicsinfo.IsSynced = graphicsinfo.IsSynced;
                    graphicsinfo.CreatedBy = graphicsinfo.CreatedBy;
                    graphicsinfo.CreatedDate = graphicsinfo.CreatedDate;
                    graphicsinfo.ModifiedBy = graphicsinfo.ModifiedBy;
                    graphicsinfo.ModifiedDate = graphicsinfo.ModifiedDate;
                    graphicsinfo.IsActive = graphicsinfo.IsActive;

                    db.GraphicsInfos.Add(graphicsinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baGraphicsInfo baGraphicsInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GraphicsInfos.Where(p => p.Id == baGraphicsInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        graphicsinfo graphicsinfo = new graphicsinfo();

                        graphicsinfo.Id = graphicsinfo.Id;
                        graphicsinfo.PS_Graphics_pkey = graphicsinfo.PS_Graphics_pkey;
                        graphicsinfo.PS_Graphics_Name = graphicsinfo.PS_Graphics_Name;
                        graphicsinfo.PS_Graphics_Displayname = graphicsinfo.PS_Graphics_Displayname;
                        graphicsinfo.PS_Graphics_IsActive = graphicsinfo.PS_Graphics_IsActive;
                        graphicsinfo.SyncCode = graphicsinfo.SyncCode;
                        graphicsinfo.IsSynced = graphicsinfo.IsSynced;
                        graphicsinfo.CreatedBy = graphicsinfo.CreatedBy;
                        graphicsinfo.CreatedDate = graphicsinfo.CreatedDate;
                        graphicsinfo.ModifiedBy = graphicsinfo.ModifiedBy;
                        graphicsinfo.ModifiedDate = graphicsinfo.ModifiedDate;
                        graphicsinfo.IsActive = graphicsinfo.IsActive;

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
                    var obj = db.GraphicsInfos.Where(p => p.Id == Id).FirstOrDefault();
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
