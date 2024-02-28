using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baServicePOSMapping
        {
        public int Id { get; set; }
        public long ServicePOSMappingID { get; set; }
        public long ServiceID { get; set; }
        public long ImixPOSDetailID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Status { get; set; }
        public bool? IsActive { get; set; }


        public static bool Marge ()
            {
            List<serviceposmapping> lst_serviceposmapping = new List<serviceposmapping>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    serviceposmapping serviceposmapping = new serviceposmapping();

                    serviceposmapping.Id = 1;
                    serviceposmapping.ServicePOSMappingID = 1;
                    serviceposmapping.ServiceID = 5;
                    serviceposmapping.ImixPOSDetailID = 5;
                    serviceposmapping.CreatedBy = "";
                    serviceposmapping.UpdatedBy = "";
                    serviceposmapping.UpdatedOn = DateTime.Now;
                    serviceposmapping.Status = false;
                    serviceposmapping.IsActive = true;

                    lst_serviceposmapping.Add(serviceposmapping);

                    var Id = lst_serviceposmapping.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ServicePOSMappings.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.ServicePOSMappings.AddRange(lst_serviceposmapping);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ServicePOSMappings.AddRange(lst_serviceposmapping);
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

        public static baServicePOSMapping GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ServicePOSMappings.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baServicePOSMapping
                        {
                        Id = p.Id,
                        ServicePOSMappingID = p.ServicePOSMappingID,
                        ServiceID = p.ServiceID,
                        ImixPOSDetailID = p.ImixPOSDetailID,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        UpdatedBy = p.UpdatedBy,
                        UpdatedOn = p.UpdatedOn,
                        Status = p.Status,
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

        public static List<baServicePOSMapping> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ServicePOSMappings.Where(p => p.IsActive == true).Select(p => new baServicePOSMapping
                        {
                        Id = p.Id,
                        ServicePOSMappingID = p.ServicePOSMappingID,
                        ServiceID = p.ServiceID,
                        ImixPOSDetailID = p.ImixPOSDetailID,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        UpdatedBy = p.UpdatedBy,
                        UpdatedOn = p.UpdatedOn,
                        Status = p.Status,
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


        public static bool Insert ( baServicePOSMapping baServicePOSMapping )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    serviceposmapping serviceposmapping = new serviceposmapping();

                    serviceposmapping.Id = baServicePOSMapping.Id;
                    serviceposmapping.ServicePOSMappingID = baServicePOSMapping.ServicePOSMappingID;
                    serviceposmapping.ServiceID = baServicePOSMapping.ServiceID;
                    serviceposmapping.ImixPOSDetailID = baServicePOSMapping.ImixPOSDetailID;
                    serviceposmapping.CreatedBy = baServicePOSMapping.CreatedBy;
                    serviceposmapping.UpdatedBy = baServicePOSMapping.UpdatedBy;
                    serviceposmapping.UpdatedOn = baServicePOSMapping.UpdatedOn;
                    serviceposmapping.Status = baServicePOSMapping.Status;
                    serviceposmapping.IsActive = baServicePOSMapping.IsActive;

                    db.ServicePOSMappings.Add(serviceposmapping);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baServicePOSMapping baServicePOSMapping )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ServicePOSMappings.Where(p => p.Id == baServicePOSMapping.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        serviceposmapping serviceposmapping = new serviceposmapping();

                        serviceposmapping.Id = baServicePOSMapping.Id;
                        serviceposmapping.ServicePOSMappingID = baServicePOSMapping.ServicePOSMappingID;
                        serviceposmapping.ServiceID = baServicePOSMapping.ServiceID;
                        serviceposmapping.ImixPOSDetailID = baServicePOSMapping.ImixPOSDetailID;
                        serviceposmapping.CreatedBy = baServicePOSMapping.CreatedBy;
                        serviceposmapping.UpdatedBy = baServicePOSMapping.UpdatedBy;
                        serviceposmapping.UpdatedOn = baServicePOSMapping.UpdatedOn;
                        serviceposmapping.Status = baServicePOSMapping.Status;
                        serviceposmapping.IsActive = baServicePOSMapping.IsActive;

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
                    var obj = db.ServicePOSMappings.Where(p => p.Id == Id).FirstOrDefault();
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
