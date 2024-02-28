using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baBackGroundInfo
        {
            public long Id { get; set; }
            public int BackgroundId { get; set; }
            public int ProductId { get; set; }
            public string BackgroundImageName { get; set; }
            public string BackgroundImageDisplayName { get; set; }
            public int? BackgroundGroupId { get; set; }
            public string SyncCode { get; set; }
            public bool IsSynced { get; set; }
            public string BackgroundPath { get; set; }
            public bool? BackgroundIsActive { get; set; }
            public int? CreatedBy { get; set; }
            public int? ModifiedBy { get; set; }
            public DateTime? CreatedDate { get; set; }
            public DateTime? ModifiedDate { get; set; }
            public bool? IsActive { get; set; }

        public static bool Marge ()
            {

            string path = AppDomain.CurrentDomain.BaseDirectory + "BackGrounds\\";
            var file_obj = System.IO.Directory.GetFiles(path, "*.jpg").Select(System.IO.Path.GetFileName);
            List<backgroundinfo> lst_backgroundinfo = new List<backgroundinfo>();
            List<long> lst_Ids = new List<long>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    int i = 0;
                    foreach(var item in file_obj)
                        {
                        backgroundinfo backgroundinfo = new backgroundinfo();
                        backgroundinfo.Id = ++i;
                        backgroundinfo.BackgroundId = i;
                        backgroundinfo.ProductId = 1;
                        backgroundinfo.BackgroundImageName = item;
                        backgroundinfo.BackgroundImageDisplayName = item.Replace(".jpg", "");
                        backgroundinfo.BackgroundGroupId = 1;
                        backgroundinfo.SyncCode = "001";
                        backgroundinfo.IsSynced = false;
                        backgroundinfo.BackgroundPath = "Backgrounds\\";
                        backgroundinfo.BackgroundIsActive = true;
                        backgroundinfo.CreatedBy = 1;
                        backgroundinfo.ModifiedBy = 1;
                        backgroundinfo.CreatedDate = DateTime.Now;
                        backgroundinfo.ModifiedDate = DateTime.Now;
                        backgroundinfo.IsActive = true;
                        lst_Ids.Add(backgroundinfo.Id);
                        lst_backgroundinfo.Add(backgroundinfo);
                        }
                    // var Id = lst_graphicsinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.BackGroundInfos.Where(p => lst_Ids.Contains(p.Id)).ToList();
                    if(IsExist == null)
                        {
                        db.BackGroundInfos.AddRange(lst_backgroundinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.BackGroundInfos.AddRange(lst_backgroundinfo);
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

        public static baBackGroundInfo GetBackGroundInfoDataById(long Id)
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                        var obj = db.BackGroundInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baBackGroundInfo
                        {
                          Id = p.Id,
                          BackgroundId =p.BackgroundId,
                          ProductId =p.ProductId,
                          BackgroundImageName =p.BackgroundImageName,
                          BackgroundImageDisplayName =p.BackgroundImageDisplayName,
                          BackgroundGroupId =p.BackgroundGroupId,
                          SyncCode =p.SyncCode,
                          IsSynced =p.IsSynced,
                          BackgroundPath =p.BackgroundPath,
                          BackgroundIsActive =p.BackgroundIsActive,
                          CreatedBy =p.CreatedBy,
                          ModifiedBy =p.ModifiedBy,
                          CreatedDate =p.CreatedDate,
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

        public static List<baBackGroundInfo> GetBackGroundInfoData()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                        var obj = db.BackGroundInfos.Where(p => p.IsActive == true).Select(p => new baBackGroundInfo
                        {
                            Id = p.Id,
                            BackgroundId = p.BackgroundId,
                            ProductId = p.ProductId,
                            BackgroundImageName = p.BackgroundImageName,
                            BackgroundImageDisplayName = p.BackgroundImageDisplayName,
                            BackgroundGroupId = p.BackgroundGroupId,
                            SyncCode = p.SyncCode,
                            IsSynced = p.IsSynced,
                            BackgroundPath = p.BackgroundPath,
                            BackgroundIsActive = p.BackgroundIsActive,
                            CreatedBy = p.CreatedBy,
                            ModifiedBy = p.ModifiedBy,
                            CreatedDate = p.CreatedDate,
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


        }
    }
