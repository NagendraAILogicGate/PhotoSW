using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baStockShot
        {
        public int Id { get; set; }
        public long ImageId { get; set; }
        public string ImageName { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string ImageThumbnailPath { get; set; }
        public bool IsActive { get; set; }

        public static bool Marge ()
            {
            return false;
            //List<stockshot> lst_stockshot = new List<stockshot>();

            //try
            //    {
            //    using(PhotoSWEntities db = new PhotoSWEntities())
            //        {
            //        stockshot stockshot = new stockshot();

            //        stockshot.Id = 1;
            //        stockshot.ImageId = 1;
            //        stockshot.ImageName = "";
            //        stockshot.CreatedOn = DateTime.Now;
            //        stockshot.CreatedBy = 5;
            //        stockshot.ModifiedOn = DateTime.Now;
            //        stockshot.ModifiedBy = 2;
            //        stockshot.ImageThumbnailPath = "";
            //        stockshot.IsActive = true;

            //        lst_stockshot.Add(stockshot);

            //        var Id = lst_stockshot.Where(t => t.Id == 1).First().Id;
            //        var IsExist = db.StockShots.Where(p => p.Id == Id).ToList();
            //        if(IsExist == null)
            //            {
            //            db.StockShots.AddRange(lst_stockshot);
            //            db.SaveChanges();
            //            }
            //        else if(IsExist.Count == 0)
            //            {
            //            db.StockShots.AddRange(lst_stockshot);
            //            db.SaveChanges();
            //            }
            //        return true;
            //        }
            //    }
            //catch(Exception ex)
            //    {
            //    return false;
            //    }
            }

        public static baStockShot GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.StockShots.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baStockShot
                        {
                        Id = p.Id,
                        ImageId = p.ImageId,
                        ImageName = p.ImageName,
                        CreatedOn = p.CreatedOn,
                        CreatedBy = p.CreatedBy,
                        ModifiedOn = p.ModifiedOn,
                        ModifiedBy = p.ModifiedBy,
                        ImageThumbnailPath = p.ImageThumbnailPath,
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

        public static List<baStockShot> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.StockShots.Where(p => p.IsActive == true).Select(p => new baStockShot
                        {
                        Id = p.Id,
                        ImageId = p.ImageId,
                        ImageName = p.ImageName,
                        CreatedOn = p.CreatedOn,
                        CreatedBy = p.CreatedBy,
                        ModifiedOn = p.ModifiedOn,
                        ModifiedBy = p.ModifiedBy,
                        ImageThumbnailPath = p.ImageThumbnailPath,
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

        public static long Insert ( baStockShot baStockShot )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    stockshot stockshot = new stockshot();

                    stockshot.Id = baStockShot.Id;
                    stockshot.ImageName = baStockShot.ImageName;
                    stockshot.CreatedOn = baStockShot.CreatedOn;
                    stockshot.CreatedBy = baStockShot.CreatedBy;
                    stockshot.ModifiedOn = baStockShot.ModifiedOn;
                    stockshot.ModifiedBy = baStockShot.ModifiedBy;
                    stockshot.ImageThumbnailPath = baStockShot.ImageThumbnailPath;
                    stockshot.IsActive = baStockShot.IsActive;
                    db.StockShots.Add(stockshot);
                    db.SaveChanges();

                    stockshot.ImageId = db.StockShots.OrderByDescending(v=>v.Id).FirstOrDefault().Id;
                    db.SaveChanges();

                    return stockshot.ImageId;
                    }
                }
            catch(Exception)
                {

                return 0;
                }
            }

        public static long Update ( baStockShot baStockShot )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.StockShots.Where(p => p.ImageId== baStockShot.ImageId).FirstOrDefault();
                    if(obj != null)
                        {
                        //stockshot stockshot = new stockshot();

                        //obj.Id = baStockShot.Id;
                        obj.ImageId = baStockShot.ImageId;
                        obj.ImageName = baStockShot.ImageName;
                        obj.CreatedOn = baStockShot.CreatedOn;
                        obj.CreatedBy = baStockShot.CreatedBy;
                        obj.ModifiedOn = baStockShot.ModifiedOn;
                        obj.ModifiedBy = baStockShot.ModifiedBy;
                        obj.ImageThumbnailPath = baStockShot.ImageThumbnailPath;
                        obj.IsActive = baStockShot.IsActive;

                        db.SaveChanges();

                        return obj.ImageId;
                        }
                    else
                        {
                        return 0;
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
                    var obj = db.StockShots.Where(p => p.Id == Id).FirstOrDefault();
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
