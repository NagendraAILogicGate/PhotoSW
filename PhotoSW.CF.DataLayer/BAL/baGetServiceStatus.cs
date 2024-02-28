using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baGetServiceStatus
        {
        public long Id { get; set; }
        public int ServiceId { get; set; }
        public long SubStoreID { get; set; }
        public int Runlevel { get; set; }
        public long iMixPosId { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<getservicestatus> lst_getservicestatus = new List<getservicestatus>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    getservicestatus getservicestatus = new getservicestatus();

                    getservicestatus.Id = 1;
                    getservicestatus.ServiceId = 2;
                    getservicestatus.SubStoreID = 3;
                    getservicestatus.Runlevel = 4;
                    getservicestatus.iMixPosId = 5;
                    getservicestatus.IsActive = true;

                    lst_getservicestatus.Add(getservicestatus);

                    var Id = lst_getservicestatus.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.GetServiceStatuses.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.GetServiceStatuses.AddRange(lst_getservicestatus);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.GetServiceStatuses.AddRange(lst_getservicestatus);
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

        public static baGetServiceStatus GetServiceStatusDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.GetServiceStatuses.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baGetServiceStatus
                        {
                        Id = p.Id,
                        ServiceId = p.ServiceId,
                        SubStoreID = p.SubStoreID,
                        Runlevel = p.Runlevel,
                        iMixPosId = p.iMixPosId,
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

        public static List<baGetServiceStatus> GetServiceStatusData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GetServiceStatuses.Where(p => p.IsActive == true).Select(p => new baGetServiceStatus
                        {
                        Id = p.Id,
                        ServiceId = p.ServiceId,
                        SubStoreID = p.SubStoreID,
                        Runlevel = p.Runlevel,
                        iMixPosId = p.iMixPosId,
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

        public static bool Insert ( baGetServiceStatus baGetServiceStatus )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    getservicestatus getservicestatus = new getservicestatus();

                    getservicestatus.Id = baGetServiceStatus.Id;
                    getservicestatus.ServiceId = baGetServiceStatus.ServiceId;
                    getservicestatus.SubStoreID = baGetServiceStatus.SubStoreID;
                    getservicestatus.Runlevel = baGetServiceStatus.Runlevel;
                    getservicestatus.iMixPosId = baGetServiceStatus.iMixPosId;
                    getservicestatus.IsActive = baGetServiceStatus.IsActive;

                    db.GetServiceStatuses.Add(getservicestatus);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baGetServiceStatus baGetServiceStatus )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GetServiceStatuses.Where(p => p.Id == baGetServiceStatus.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        getservicestatus getservicestatus = new getservicestatus();

                        getservicestatus.Id = baGetServiceStatus.Id;
                        getservicestatus.ServiceId = baGetServiceStatus.ServiceId;
                        getservicestatus.SubStoreID = baGetServiceStatus.SubStoreID;
                        getservicestatus.Runlevel = baGetServiceStatus.Runlevel;
                        getservicestatus.iMixPosId = baGetServiceStatus.iMixPosId;
                        getservicestatus.IsActive = baGetServiceStatus.IsActive;

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
                    var obj = db.GetServiceStatuses.Where(p => p.Id == Id).FirstOrDefault();
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
