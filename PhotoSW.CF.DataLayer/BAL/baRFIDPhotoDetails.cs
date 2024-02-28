using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baRFIDPhotoDetails
        {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PhotoGrapherId { get; set; }
        public string FileName { get; set; }
        public bool? IsActive { get; set; }


        public static bool Marge ()
            {
            List<rfidphotodetails> lst_rfidphotodetails = new List<rfidphotodetails>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    rfidphotodetails rfidphotodetails = new rfidphotodetails();

                    rfidphotodetails.Id = 1;
                    rfidphotodetails.StartDate = DateTime.Now;
                    rfidphotodetails.EndDate = DateTime.Now;
                    rfidphotodetails.PhotoGrapherId = 2;
                    rfidphotodetails.FileName = "";
                    rfidphotodetails.IsActive = true;

                    lst_rfidphotodetails.Add(rfidphotodetails);

                    var Id = lst_rfidphotodetails.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.RFIDPhotoDetailses.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.RFIDPhotoDetailses.AddRange(lst_rfidphotodetails);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.RFIDPhotoDetailses.AddRange(lst_rfidphotodetails);
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

        public static baRFIDPhotoDetails GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RFIDPhotoDetailses.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baRFIDPhotoDetails
                        {
                        Id = p.Id,
                        StartDate = p.StartDate,
                        EndDate = p.EndDate,
                        PhotoGrapherId = p.PhotoGrapherId,
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

        public static List<baRFIDPhotoDetails> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RFIDPhotoDetailses.Where(p => p.IsActive == true).Select(p => new baRFIDPhotoDetails
                        {
                        Id = p.Id,
                        StartDate = p.StartDate,
                        EndDate = p.EndDate,
                        PhotoGrapherId = p.PhotoGrapherId,
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


        public static bool Insert ( baRFIDPhotoDetails baRFIDPhotoDetails )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    rfidphotodetails rfidphotodetails = new rfidphotodetails();

                    rfidphotodetails.Id = rfidphotodetails.Id;
                    rfidphotodetails.StartDate = rfidphotodetails.StartDate;
                    rfidphotodetails.EndDate = rfidphotodetails.EndDate;
                    rfidphotodetails.PhotoGrapherId = rfidphotodetails.PhotoGrapherId;
                    rfidphotodetails.FileName = rfidphotodetails.FileName;
                    rfidphotodetails.IsActive = rfidphotodetails.IsActive;

                    db.RFIDPhotoDetailses.Add(rfidphotodetails);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baRFIDPhotoDetails baRFIDPhotoDetails )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RFIDPhotoDetailses.Where(p => p.Id == baRFIDPhotoDetails.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        rfidphotodetails rfidphotodetails = new rfidphotodetails();

                        rfidphotodetails.Id = rfidphotodetails.Id;
                        rfidphotodetails.StartDate = rfidphotodetails.StartDate;
                        rfidphotodetails.EndDate = rfidphotodetails.EndDate;
                        rfidphotodetails.PhotoGrapherId = rfidphotodetails.PhotoGrapherId;
                        rfidphotodetails.FileName = rfidphotodetails.FileName;
                        rfidphotodetails.IsActive = rfidphotodetails.IsActive;

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
                    var obj = db.RFIDPhotoDetailses.Where(p => p.Id == Id).FirstOrDefault();
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
