using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baFolderStructureInfo
        {
        public long Id { get; set; }
        public string HotFolderPath { get; set; }
        public string BorderPath { get; set; }
        public string BackgroundPath { get; set; }
        public string GraphicPath { get; set; }
        public string CroppedPath { get; set; }
        public string EditedImagePath { get; set; }
        public string ThumbnailsPath { get; set; }
        public string BigThumbnailsPath { get; set; }
        public string PrintImagesPath { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
                List<folderdsructureinfo> lst_folderdsructureinfo = new List<folderdsructureinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                        folderdsructureinfo foldersructureinfo = new folderdsructureinfo();

                    foldersructureinfo.Id = 1;
                    foldersructureinfo.HotFolderPath = "";
                    foldersructureinfo.BorderPath = "";
                    foldersructureinfo.BackgroundPath = "";
                    foldersructureinfo.GraphicPath = "";
                    foldersructureinfo.CroppedPath = "";
                    foldersructureinfo.EditedImagePath = "";
                    foldersructureinfo.ThumbnailsPath = "";
                    foldersructureinfo.BigThumbnailsPath = "";
                    foldersructureinfo.PrintImagesPath = "";
                    foldersructureinfo.IsActive = true;

                    lst_folderdsructureinfo.Add(foldersructureinfo);

                    var Id = lst_folderdsructureinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.FolderStructureInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.FolderStructureInfos.AddRange(lst_folderdsructureinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.FolderStructureInfos.AddRange(lst_folderdsructureinfo);
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

        public static baFolderStructureInfo GetFolderStructureInfoDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.FolderStructureInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baFolderStructureInfo
                        {
                        Id = p.Id,
                        HotFolderPath = p.HotFolderPath,
                        BorderPath = p.BorderPath,
                        BackgroundPath = p.BackgroundPath,
                        GraphicPath = p.GraphicPath,
                        CroppedPath = p.CroppedPath,
                        EditedImagePath = p.EditedImagePath,
                        ThumbnailsPath = p.ThumbnailsPath,
                        BigThumbnailsPath = p.BigThumbnailsPath,
                        PrintImagesPath = p.PrintImagesPath,                       
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

        public static List<baFolderStructureInfo> GetFolderStructureInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.FolderStructureInfos.Where(p => p.IsActive == true).Select(p => new baFolderStructureInfo
                        {
                        Id = p.Id,
                        HotFolderPath = p.HotFolderPath,
                        BorderPath = p.BorderPath,
                        BackgroundPath = p.BackgroundPath,
                        GraphicPath = p.GraphicPath,
                        CroppedPath = p.CroppedPath,
                        EditedImagePath = p.EditedImagePath,
                        ThumbnailsPath = p.ThumbnailsPath,
                        BigThumbnailsPath = p.BigThumbnailsPath,
                        PrintImagesPath = p.PrintImagesPath,
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

        public static bool Insert ( baFolderStructureInfo baFolderStructureInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    folderdsructureinfo foldersructureinfo = new folderdsructureinfo();

                    foldersructureinfo.Id = baFolderStructureInfo.Id;
                    foldersructureinfo.HotFolderPath = baFolderStructureInfo.HotFolderPath;
                    foldersructureinfo.BorderPath = baFolderStructureInfo.BorderPath;
                    foldersructureinfo.BackgroundPath = baFolderStructureInfo.BackgroundPath;
                    foldersructureinfo.GraphicPath = baFolderStructureInfo.GraphicPath;
                    foldersructureinfo.CroppedPath = baFolderStructureInfo.CroppedPath;
                    foldersructureinfo.EditedImagePath = baFolderStructureInfo.EditedImagePath;
                    foldersructureinfo.ThumbnailsPath = baFolderStructureInfo.ThumbnailsPath;
                    foldersructureinfo.BigThumbnailsPath = baFolderStructureInfo.BigThumbnailsPath;
                    foldersructureinfo.PrintImagesPath = baFolderStructureInfo.PrintImagesPath;
                    foldersructureinfo.IsActive = baFolderStructureInfo.IsActive;

                    db.FolderStructureInfos.Add(foldersructureinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baFolderStructureInfo baFolderStructureInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.FolderStructureInfos.Where(p => p.Id == baFolderStructureInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        folderdsructureinfo foldersructureinfo = new folderdsructureinfo();

                        foldersructureinfo.Id = baFolderStructureInfo.Id;
                        foldersructureinfo.HotFolderPath = baFolderStructureInfo.HotFolderPath;
                        foldersructureinfo.BorderPath = baFolderStructureInfo.BorderPath;
                        foldersructureinfo.BackgroundPath = baFolderStructureInfo.BackgroundPath;
                        foldersructureinfo.GraphicPath = baFolderStructureInfo.GraphicPath;
                        foldersructureinfo.CroppedPath = baFolderStructureInfo.CroppedPath;
                        foldersructureinfo.EditedImagePath = baFolderStructureInfo.EditedImagePath;
                        foldersructureinfo.ThumbnailsPath = baFolderStructureInfo.ThumbnailsPath;
                        foldersructureinfo.BigThumbnailsPath = baFolderStructureInfo.BigThumbnailsPath;
                        foldersructureinfo.PrintImagesPath = baFolderStructureInfo.PrintImagesPath;
                        foldersructureinfo.IsActive = baFolderStructureInfo.IsActive;

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
                    var obj = db.FolderStructureInfos.Where(p => p.Id == Id).FirstOrDefault();
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
