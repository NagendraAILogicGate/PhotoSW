using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baPrintLogInfo
        {
        public int Id { get; set; }
        public int PhotoId { get; set; }
        public DateTime PrintTime { get; set; }
        public int ProductTypeId { get; set; }
        public int UserID { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<printloginfo> lst_printloginfo = new List<printloginfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    printloginfo printloginfo = new printloginfo();

                    printloginfo.Id = 1;
                    printloginfo.PhotoId = 2;
                    printloginfo.PrintTime = DateTime.Now;
                    printloginfo.ProductTypeId = 3;
                    printloginfo.UserID = 2;
                    printloginfo.IsActive = true;

                    lst_printloginfo.Add(printloginfo);

                    var Id = lst_printloginfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PrintLogInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.PrintLogInfos.AddRange(lst_printloginfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.PrintLogInfos.AddRange(lst_printloginfo);
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

        public static baPrintLogInfo GetPrintLogInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrintLogInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPrintLogInfo
                        {
                        Id = p.Id,
                        PhotoId = p.PhotoId,
                        PrintTime = p.PrintTime,
                        ProductTypeId = p.ProductTypeId,
                        UserID = p.UserID,
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

        public static List<baPrintLogInfo> GetPrintLogInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrintLogInfos.Where(p => p.IsActive == true).Select(p => new baPrintLogInfo
                        {
                        Id = p.Id,
                        PhotoId = p.PhotoId,
                        PrintTime = p.PrintTime,
                        ProductTypeId = p.ProductTypeId,
                        UserID = p.UserID,
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

        public static bool Insert ( baPrintLogInfo baPrintLogInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    printloginfo printloginfo = new printloginfo();

                    printloginfo.Id = printloginfo.Id;
                    printloginfo.PhotoId = printloginfo.PhotoId;
                    printloginfo.PrintTime = printloginfo.PrintTime;
                    printloginfo.ProductTypeId = printloginfo.ProductTypeId;
                    printloginfo.UserID = printloginfo.UserID;
                    printloginfo.IsActive = printloginfo.IsActive;

                    db.PrintLogInfos.Add(printloginfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPrintLogInfo baPrintLogInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrintLogInfos.Where(p => p.Id == baPrintLogInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        printloginfo printloginfo = new printloginfo();

                        printloginfo.Id = printloginfo.Id;
                        printloginfo.PhotoId = printloginfo.PhotoId;
                        printloginfo.PrintTime = printloginfo.PrintTime;
                        printloginfo.ProductTypeId = printloginfo.ProductTypeId;
                        printloginfo.UserID = printloginfo.UserID;
                        printloginfo.IsActive = printloginfo.IsActive;

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
                    var obj = db.PrintLogInfos.Where(p => p.Id == Id).FirstOrDefault();
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
