using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baVenueTaxValueModel
        {
        public int Id { get; set; }
        public int VenueTaxValueId { get; set; }
        public int TaxId { get; set; }
        public decimal TaxPercentage { get; set; }
        public int VenueId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public static bool Marge ()
            {
            List<venuetaxvaluemodel> lst_venuetaxvaluemodel = new List<venuetaxvaluemodel>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    venuetaxvaluemodel venuetaxvaluemodel = new venuetaxvaluemodel();

                    venuetaxvaluemodel.Id = 1;
                    venuetaxvaluemodel.VenueTaxValueId = 5;
                    venuetaxvaluemodel.TaxId = 8;
                    venuetaxvaluemodel.TaxPercentage = 5;
                    venuetaxvaluemodel.VenueId = 5;
                    venuetaxvaluemodel.ModifiedDate = DateTime.Now;
                    venuetaxvaluemodel.IsActive = true;

                    lst_venuetaxvaluemodel.Add(venuetaxvaluemodel);

                    var Id = lst_venuetaxvaluemodel.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.VenueTaxValueModels.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.VenueTaxValueModels.AddRange(lst_venuetaxvaluemodel);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.VenueTaxValueModels.AddRange(lst_venuetaxvaluemodel);
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

        public static baVenueTaxValueModel GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VenueTaxValueModels.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baVenueTaxValueModel
                        {
                        Id = p.Id,
                        VenueTaxValueId = p.VenueTaxValueId,
                        TaxId = p.TaxId,
                        TaxPercentage = p.TaxPercentage,
                        VenueId = p.VenueId,
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

        public static List<baVenueTaxValueModel> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VenueTaxValueModels.Where(p => p.IsActive == true).Select(p => new baVenueTaxValueModel
                        {
                        Id = p.Id,
                        VenueTaxValueId = p.VenueTaxValueId,
                        TaxId = p.TaxId,
                        TaxPercentage = p.TaxPercentage,
                        VenueId = p.VenueId,
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


        public static bool Insert ( baVenueTaxValueModel baVenueTaxValueModel )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    venuetaxvaluemodel venuetaxvaluemodel = new venuetaxvaluemodel();

                    venuetaxvaluemodel.Id = baVenueTaxValueModel.Id;
                    venuetaxvaluemodel.VenueTaxValueId = baVenueTaxValueModel.VenueTaxValueId;
                    venuetaxvaluemodel.TaxId = baVenueTaxValueModel.TaxId;
                    venuetaxvaluemodel.TaxPercentage = baVenueTaxValueModel.TaxPercentage;
                    venuetaxvaluemodel.VenueId = baVenueTaxValueModel.VenueId;
                    venuetaxvaluemodel.ModifiedDate = baVenueTaxValueModel.ModifiedDate;
                    venuetaxvaluemodel.IsActive = baVenueTaxValueModel.IsActive;

                    db.VenueTaxValueModels.Add(venuetaxvaluemodel);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baVenueTaxValueModel baVenueTaxValueModel )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.VenueTaxValueModels.Where(p => p.Id == baVenueTaxValueModel.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        venuetaxvaluemodel venuetaxvaluemodel = new venuetaxvaluemodel();

                        venuetaxvaluemodel.Id = baVenueTaxValueModel.Id;
                        venuetaxvaluemodel.VenueTaxValueId = baVenueTaxValueModel.VenueTaxValueId;
                        venuetaxvaluemodel.TaxId = baVenueTaxValueModel.TaxId;
                        venuetaxvaluemodel.TaxPercentage = baVenueTaxValueModel.TaxPercentage;
                        venuetaxvaluemodel.VenueId = baVenueTaxValueModel.VenueId;
                        venuetaxvaluemodel.ModifiedDate = baVenueTaxValueModel.ModifiedDate;
                        venuetaxvaluemodel.IsActive = baVenueTaxValueModel.IsActive;

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
                    var obj = db.VenueTaxValueModels.Where(p => p.Id == Id).FirstOrDefault();
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
