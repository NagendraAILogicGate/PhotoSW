using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baServiceEmailContent
        {
        public int Id { get; set; }
        public string ReportType { get; set; }
        public string Status { get; set; }
        public string StatusDetails { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<serviceemailcontent> lst_serviceemailcontent = new List<serviceemailcontent>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    serviceemailcontent serviceemailcontent = new serviceemailcontent();

                    serviceemailcontent.Id = 1;
                    serviceemailcontent.ReportType = "";
                    serviceemailcontent.Status = "";
                    serviceemailcontent.StatusDetails = "";
                    serviceemailcontent.IsActive = true;

                    lst_serviceemailcontent.Add(serviceemailcontent);

                    var Id = lst_serviceemailcontent.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ServiceEmailContents.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.ServiceEmailContents.AddRange(lst_serviceemailcontent);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ServiceEmailContents.AddRange(lst_serviceemailcontent);
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

        public static baServiceEmailContent GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ServiceEmailContents.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baServiceEmailContent
                        {
                        Id = p.Id,
                        ReportType = p.ReportType,
                        Status = p.Status,
                        StatusDetails = p.StatusDetails,                      
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

        public static List<baServiceEmailContent> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ServiceEmailContents.Where(p => p.IsActive == true).Select(p => new baServiceEmailContent
                        {
                        Id = p.Id,
                        ReportType = p.ReportType,
                        Status = p.Status,
                        StatusDetails = p.StatusDetails,
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

        public static bool Insert ( baServiceEmailContent baServiceEmailContent )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    serviceemailcontent serviceemailcontent = new serviceemailcontent();

                    serviceemailcontent.Id = serviceemailcontent.Id;
                    serviceemailcontent.ReportType = serviceemailcontent.ReportType;
                    serviceemailcontent.Status = serviceemailcontent.Status;
                    serviceemailcontent.StatusDetails = serviceemailcontent.StatusDetails;
                    serviceemailcontent.IsActive = serviceemailcontent.IsActive;

                    db.ServiceEmailContents.Add(serviceemailcontent);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baServiceEmailContent baServiceEmailContent )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ServiceEmailContents.Where(p => p.Id == baServiceEmailContent.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        serviceemailcontent serviceemailcontent = new serviceemailcontent();

                        serviceemailcontent.Id = serviceemailcontent.Id;
                        serviceemailcontent.ReportType = serviceemailcontent.ReportType;
                        serviceemailcontent.Status = serviceemailcontent.Status;
                        serviceemailcontent.StatusDetails = serviceemailcontent.StatusDetails;
                        serviceemailcontent.IsActive = serviceemailcontent.IsActive;


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
                    var obj = db.ServiceEmailContents.Where(p => p.Id == Id).FirstOrDefault();
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
