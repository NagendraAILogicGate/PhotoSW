using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baProcessedVideoDetailsInfo
        {
        public int Id { get; set; }
        public long ProcessedVideoDetailId { get; set; }
        public int ProcessedVideoId { get; set; }
        public int FrameTime { get; set; }
        public int DisplayTime { get; set; }
        public long MediaId { get; set; }
        public int MediaType { get; set; }
        public int JoiningOrder { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<processedvideodetailsinfo> lst_processedvideodetailsinfo = new List<processedvideodetailsinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    processedvideodetailsinfo processedvideodetailsinfo = new processedvideodetailsinfo();

                    processedvideodetailsinfo.Id = 1;
                    processedvideodetailsinfo.ProcessedVideoDetailId = 2;
                    processedvideodetailsinfo.ProcessedVideoId = 3;
                    processedvideodetailsinfo.FrameTime = 2;
                    processedvideodetailsinfo.DisplayTime = 4;
                    processedvideodetailsinfo.MediaId = 4;
                    processedvideodetailsinfo.MediaType = 2;
                    processedvideodetailsinfo.JoiningOrder = 5;
                    processedvideodetailsinfo.StartTime = 2;
                    processedvideodetailsinfo.EndTime = 3;
                    processedvideodetailsinfo.IsActive = true;

                    lst_processedvideodetailsinfo.Add(processedvideodetailsinfo);

                    var Id = lst_processedvideodetailsinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ProcessedVideoDetailsInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.ProcessedVideoDetailsInfos.AddRange(lst_processedvideodetailsinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ProcessedVideoDetailsInfos.AddRange(lst_processedvideodetailsinfo);
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

        public static baProcessedVideoDetailsInfo GetProcessedVideoDetailsInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ProcessedVideoDetailsInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baProcessedVideoDetailsInfo
                        {
                        Id = p.Id,
                        ProcessedVideoDetailId = p.ProcessedVideoDetailId,
                        ProcessedVideoId = p.ProcessedVideoId,
                        FrameTime = p.FrameTime,
                        DisplayTime = p.DisplayTime,
                        MediaId = p.MediaId,
                        MediaType = p.MediaType,
                        JoiningOrder = p.JoiningOrder,
                        StartTime = p.StartTime,
                        EndTime = p.EndTime,
                        IsActive = p.IsActive,


                        }).FirstOrDefault();
                    return obj;
                    }
                }
            catch
                {
                return null; ;
                }
            }

        public static List<baProcessedVideoDetailsInfo> GetProcessedVideoDetailsInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ProcessedVideoDetailsInfos.Where(p => p.IsActive == true).Select(p => new baProcessedVideoDetailsInfo
                        {
                        Id = p.Id,
                        ProcessedVideoDetailId = p.ProcessedVideoDetailId,
                        ProcessedVideoId = p.ProcessedVideoId,
                        FrameTime = p.FrameTime,
                        DisplayTime = p.DisplayTime,
                        MediaId = p.MediaId,
                        MediaType = p.MediaType,
                        JoiningOrder = p.JoiningOrder,
                        StartTime = p.StartTime,
                        EndTime = p.EndTime,
                        IsActive = p.IsActive,

                        }).ToList();
                    return obj;
                    }
                }
            catch
                {
                return null; ;
                }
            }

        public static bool Insert ( baProcessedVideoDetailsInfo baProcessedVideoDetailsInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    processedvideodetailsinfo processedvideodetailsinfo = new processedvideodetailsinfo();

                    processedvideodetailsinfo.Id = processedvideodetailsinfo.Id;
                    processedvideodetailsinfo.ProcessedVideoDetailId = processedvideodetailsinfo.ProcessedVideoDetailId;
                    processedvideodetailsinfo.ProcessedVideoId = processedvideodetailsinfo.ProcessedVideoId;
                    processedvideodetailsinfo.FrameTime = processedvideodetailsinfo.FrameTime;
                    processedvideodetailsinfo.DisplayTime = processedvideodetailsinfo.DisplayTime;
                    processedvideodetailsinfo.MediaId = processedvideodetailsinfo.MediaId;
                    processedvideodetailsinfo.MediaType = processedvideodetailsinfo.MediaType;
                    processedvideodetailsinfo.JoiningOrder = processedvideodetailsinfo.JoiningOrder;
                    processedvideodetailsinfo.StartTime = processedvideodetailsinfo.StartTime;
                    processedvideodetailsinfo.EndTime = processedvideodetailsinfo.EndTime;
                    processedvideodetailsinfo.IsActive = processedvideodetailsinfo.IsActive;
                    db.ProcessedVideoDetailsInfos.Add(processedvideodetailsinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baProcessedVideoDetailsInfo baProcessedVideoDetailsInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ProcessedVideoDetailsInfos.Where(p => p.Id == baProcessedVideoDetailsInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        processedvideodetailsinfo processedvideodetailsinfo = new processedvideodetailsinfo();

                        processedvideodetailsinfo.Id = processedvideodetailsinfo.Id;
                        processedvideodetailsinfo.ProcessedVideoDetailId = processedvideodetailsinfo.ProcessedVideoDetailId;
                        processedvideodetailsinfo.ProcessedVideoId = processedvideodetailsinfo.ProcessedVideoId;
                        processedvideodetailsinfo.FrameTime = processedvideodetailsinfo.FrameTime;
                        processedvideodetailsinfo.DisplayTime = processedvideodetailsinfo.DisplayTime;
                        processedvideodetailsinfo.MediaId = processedvideodetailsinfo.MediaId;
                        processedvideodetailsinfo.MediaType = processedvideodetailsinfo.MediaType;
                        processedvideodetailsinfo.JoiningOrder = processedvideodetailsinfo.JoiningOrder;
                        processedvideodetailsinfo.StartTime = processedvideodetailsinfo.StartTime;
                        processedvideodetailsinfo.EndTime = processedvideodetailsinfo.EndTime;
                        processedvideodetailsinfo.IsActive = processedvideodetailsinfo.IsActive;

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
                    var obj = db.ProcessedVideoDetailsInfos.Where(p => p.Id == Id).FirstOrDefault();
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
