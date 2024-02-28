using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baDownloadFileInfo
        {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isVideo { get; set; }
        public string fileName { get; set; }
        public string filePath { get; set; }
        public string videoPath { get; set; }
        public string fileExtension { get; set; }
        public string drivePath { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<downloadfileinfo> lst_downloadfileinfo = new List<downloadfileinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    downloadfileinfo downloadfileinfo = new downloadfileinfo();

                    downloadfileinfo.Id = 1;
                    downloadfileinfo.CreatedDate = DateTime.Now;
                    downloadfileinfo.isVideo = false;
                    downloadfileinfo.fileName = "";
                    downloadfileinfo.filePath = "";
                    downloadfileinfo.videoPath = "";
                    downloadfileinfo.fileExtension = "";
                    downloadfileinfo.drivePath = "";                   
                    downloadfileinfo.IsActive = true;

                    lst_downloadfileinfo.Add(downloadfileinfo);

                    var Id = lst_downloadfileinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.DownloadFileInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.DownloadFileInfos.AddRange(lst_downloadfileinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.DownloadFileInfos.AddRange(lst_downloadfileinfo);
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

        public static baDownloadFileInfo GetDownloadFileInfoDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.DownloadFileInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baDownloadFileInfo
                        {
                        Id = p.Id,
                        CreatedDate = p.CreatedDate,
                        isVideo = p.isVideo,
                        fileName = p.fileName,
                        filePath = p.filePath,
                        videoPath = p.videoPath,
                        fileExtension = p.fileExtension,
                        drivePath = p.drivePath,                      
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

        public static List<baDownloadFileInfo> GetDownloadFileInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.DownloadFileInfos.Where(p => p.IsActive == true).Select(p => new baDownloadFileInfo
                        {
                        Id = p.Id,
                        CreatedDate = p.CreatedDate,
                        isVideo = p.isVideo,
                        fileName = p.fileName,
                        filePath = p.filePath,
                        videoPath = p.videoPath,
                        fileExtension = p.fileExtension,
                        drivePath = p.drivePath,
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

        public static bool Insert ( baDownloadFileInfo baDownloadFileInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    downloadfileinfo downloadfileinfo = new downloadfileinfo();

                    downloadfileinfo.Id = baDownloadFileInfo.Id;
                    downloadfileinfo.CreatedDate = baDownloadFileInfo.CreatedDate;
                    downloadfileinfo.isVideo = baDownloadFileInfo.isVideo;
                    downloadfileinfo.fileName = baDownloadFileInfo.fileName;
                    downloadfileinfo.filePath = baDownloadFileInfo.filePath;
                    downloadfileinfo.videoPath = baDownloadFileInfo.videoPath;
                    downloadfileinfo.fileExtension = downloadfileinfo.fileExtension;
                    downloadfileinfo.drivePath = baDownloadFileInfo.drivePath;
                    downloadfileinfo.IsActive = baDownloadFileInfo.IsActive;

                    db.DownloadFileInfos.Add(downloadfileinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baDownloadFileInfo baDownloadFileInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.DownloadFileInfos.Where(p => p.Id == baDownloadFileInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        downloadfileinfo downloadfileinfo = new downloadfileinfo();

                        downloadfileinfo.Id = baDownloadFileInfo.Id;
                        downloadfileinfo.CreatedDate = baDownloadFileInfo.CreatedDate;
                        downloadfileinfo.isVideo = baDownloadFileInfo.isVideo;
                        downloadfileinfo.fileName = baDownloadFileInfo.fileName;
                        downloadfileinfo.filePath = baDownloadFileInfo.filePath;
                        downloadfileinfo.videoPath = baDownloadFileInfo.videoPath;
                        downloadfileinfo.fileExtension = downloadfileinfo.fileExtension;
                        downloadfileinfo.drivePath = baDownloadFileInfo.drivePath;
                        downloadfileinfo.IsActive = baDownloadFileInfo.IsActive;

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
                    var obj = db.DownloadFileInfos.Where(p => p.Id == Id).FirstOrDefault();
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
