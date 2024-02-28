using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baPhotographerRFIDAssociationInfo
        {
        public long Id { get; set; }
        public int PhotographerID { get; set; }
        public string PhotographerName { get; set; }
        public string Location { get; set; }
        public int TotalCaptured { get; set; }
        public int TotalAssociated { get; set; }
        public int TotalNonAssociated { get; set; }
        public DateTime? LastAssociatedOn { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<photographerRFIDassociationinfo> lst_photographerRFIDassociationinfo = new List<photographerRFIDassociationinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    photographerRFIDassociationinfo photographerRFIDassociationinfo = new photographerRFIDassociationinfo();

                    photographerRFIDassociationinfo.Id = 1;
                    photographerRFIDassociationinfo.PhotographerID = 2;
                    photographerRFIDassociationinfo.PhotographerName = "";
                    photographerRFIDassociationinfo.Location = "";
                    photographerRFIDassociationinfo.TotalCaptured = 2;
                    photographerRFIDassociationinfo.TotalAssociated = 3;
                    photographerRFIDassociationinfo.TotalNonAssociated = 4;
                    photographerRFIDassociationinfo.LastAssociatedOn = DateTime.Now;
                    photographerRFIDassociationinfo.IsActive = true;


                    lst_photographerRFIDassociationinfo.Add(photographerRFIDassociationinfo);

                    var Id = lst_photographerRFIDassociationinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PhotographerRFIDAssociationInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.PhotographerRFIDAssociationInfos.AddRange(lst_photographerRFIDassociationinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.PhotographerRFIDAssociationInfos.AddRange(lst_photographerRFIDassociationinfo);
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

        public static baPhotographerRFIDAssociationInfo GetPhotographerRFIDAssociationInfoById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PhotographerRFIDAssociationInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPhotographerRFIDAssociationInfo
                        {
                        Id = p.Id,
                        PhotographerID = p.PhotographerID,
                        PhotographerName = p.PhotographerName,
                        Location = p.Location,
                        TotalCaptured = p.TotalCaptured,
                        TotalAssociated = p.TotalAssociated,
                        TotalNonAssociated = p.TotalNonAssociated,
                        LastAssociatedOn = p.LastAssociatedOn,
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

        public static List<baPhotographerRFIDAssociationInfo> GetPhotographerRFIDAssociationInfoData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PhotographerRFIDAssociationInfos.Where(p => p.IsActive == true).Select(p => new baPhotographerRFIDAssociationInfo
                        {
                        Id = p.Id,
                        PhotographerID = p.PhotographerID,
                        PhotographerName = p.PhotographerName,
                        Location = p.Location,
                        TotalCaptured = p.TotalCaptured,
                        TotalAssociated = p.TotalAssociated,
                        TotalNonAssociated = p.TotalNonAssociated,
                        LastAssociatedOn = p.LastAssociatedOn,
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

        public static bool Insert ( baPhotographerRFIDAssociationInfo baPhotographerRFIDAssociationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    photographerRFIDassociationinfo photographerRFIDassociationinfo = new photographerRFIDassociationinfo();

                    photographerRFIDassociationinfo.Id = baPhotographerRFIDAssociationInfo.Id;
                    photographerRFIDassociationinfo.PhotographerID = baPhotographerRFIDAssociationInfo.PhotographerID;
                    photographerRFIDassociationinfo.PhotographerName = baPhotographerRFIDAssociationInfo.PhotographerName;
                    photographerRFIDassociationinfo.Location = baPhotographerRFIDAssociationInfo.Location;
                    photographerRFIDassociationinfo.TotalCaptured = baPhotographerRFIDAssociationInfo.TotalCaptured;
                    photographerRFIDassociationinfo.TotalAssociated = baPhotographerRFIDAssociationInfo.TotalAssociated;
                    photographerRFIDassociationinfo.TotalNonAssociated = baPhotographerRFIDAssociationInfo.TotalNonAssociated;
                    photographerRFIDassociationinfo.LastAssociatedOn = baPhotographerRFIDAssociationInfo.LastAssociatedOn;
                    photographerRFIDassociationinfo.IsActive = baPhotographerRFIDAssociationInfo.IsActive;

                    db.PhotographerRFIDAssociationInfos.Add(photographerRFIDassociationinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPhotographerRFIDAssociationInfo baPhotographerRFIDAssociationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PhotographerRFIDAssociationInfos.Where(p => p.Id == baPhotographerRFIDAssociationInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        photographerRFIDassociationinfo photographerRFIDassociationinfo = new photographerRFIDassociationinfo();

                        photographerRFIDassociationinfo.Id = baPhotographerRFIDAssociationInfo.Id;
                        photographerRFIDassociationinfo.PhotographerID = baPhotographerRFIDAssociationInfo.PhotographerID;
                        photographerRFIDassociationinfo.PhotographerName = baPhotographerRFIDAssociationInfo.PhotographerName;
                        photographerRFIDassociationinfo.Location = baPhotographerRFIDAssociationInfo.Location;
                        photographerRFIDassociationinfo.TotalCaptured = baPhotographerRFIDAssociationInfo.TotalCaptured;
                        photographerRFIDassociationinfo.TotalAssociated = baPhotographerRFIDAssociationInfo.TotalAssociated;
                        photographerRFIDassociationinfo.TotalNonAssociated = baPhotographerRFIDAssociationInfo.TotalNonAssociated;
                        photographerRFIDassociationinfo.LastAssociatedOn = baPhotographerRFIDAssociationInfo.LastAssociatedOn;
                        photographerRFIDassociationinfo.IsActive = baPhotographerRFIDAssociationInfo.IsActive;

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
                    var obj = db.PhotographerRFIDAssociationInfos.Where(p => p.Id == Id).FirstOrDefault();
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
