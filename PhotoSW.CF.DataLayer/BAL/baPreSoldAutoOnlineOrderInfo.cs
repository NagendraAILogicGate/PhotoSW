using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baPreSoldAutoOnlineOrderInfo
        {
        public long Id { get; set; }
        public long IMIXImageAssociationId { get; set; }
        public int PhotoId { get; set; }
        public int IsOrdered { get; set; }
        public string CardUniqueIdentifier { get; set; }
        public string Name { get; set; }
        public int MaxImages { get; set; }
        public int PackageId { get; set; }
        public float PS_Product_Pricing_ProductPrice { get; set; }
        public int ImageIdentificationType { get; set; }
        public bool IsWaterMarked { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<presoldautoonlineorderinfo> lst_presoldautoonlineorderinfo = new List<presoldautoonlineorderinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    presoldautoonlineorderinfo presoldautoonlineorderinfo = new presoldautoonlineorderinfo();

                    presoldautoonlineorderinfo.Id = 1;
                    presoldautoonlineorderinfo.IMIXImageAssociationId = 2;
                    presoldautoonlineorderinfo.PhotoId = 3;
                    presoldautoonlineorderinfo.IsOrdered = 5;
                    presoldautoonlineorderinfo.CardUniqueIdentifier = "";
                    presoldautoonlineorderinfo.Name = "";
                    presoldautoonlineorderinfo.MaxImages = 3;
                    presoldautoonlineorderinfo.PackageId = 3;
                    presoldautoonlineorderinfo.PS_Product_Pricing_ProductPrice= 5;
                    presoldautoonlineorderinfo.ImageIdentificationType = 2;
                    presoldautoonlineorderinfo.IsWaterMarked = false;
                    presoldautoonlineorderinfo.IsActive = true;

                    lst_presoldautoonlineorderinfo.Add(presoldautoonlineorderinfo);

                    var Id = lst_presoldautoonlineorderinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PreSoldAutoOnlineOrderInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.PreSoldAutoOnlineOrderInfos.AddRange(lst_presoldautoonlineorderinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.PreSoldAutoOnlineOrderInfos.AddRange(lst_presoldautoonlineorderinfo);
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

        public static baPreSoldAutoOnlineOrderInfo GetPreSoldAutoOnlineOrderInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PreSoldAutoOnlineOrderInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPreSoldAutoOnlineOrderInfo
                        {
                        Id = p.Id,
                        IMIXImageAssociationId = p.IMIXImageAssociationId,
                        PhotoId = p.PhotoId,
                        IsOrdered = p.IsOrdered,
                        CardUniqueIdentifier = p.CardUniqueIdentifier,
                        Name = p.Name,
                        MaxImages = p.MaxImages,
                        PackageId = p.PackageId,
                        PS_Product_Pricing_ProductPrice = p.PS_Product_Pricing_ProductPrice,
                        ImageIdentificationType = p.ImageIdentificationType,
                        IsWaterMarked = p.IsWaterMarked,
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

        public static List<baPreSoldAutoOnlineOrderInfo> GetPreSoldAutoOnlineOrderInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PreSoldAutoOnlineOrderInfos.Where(p => p.IsActive == true).Select(p => new baPreSoldAutoOnlineOrderInfo
                        {
                        Id = p.Id,
                        IMIXImageAssociationId = p.IMIXImageAssociationId,
                        PhotoId = p.PhotoId,
                        IsOrdered = p.IsOrdered,
                        CardUniqueIdentifier = p.CardUniqueIdentifier,
                        Name = p.Name,
                        MaxImages = p.MaxImages,
                        PackageId = p.PackageId,
                        PS_Product_Pricing_ProductPrice = p.PS_Product_Pricing_ProductPrice,
                        ImageIdentificationType = p.ImageIdentificationType,
                        IsWaterMarked = p.IsWaterMarked,
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

        public static bool Insert ( baPreSoldAutoOnlineOrderInfo baPreSoldAutoOnlineOrderInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    presoldautoonlineorderinfo presoldautoonlineorderinfo = new presoldautoonlineorderinfo();

                    presoldautoonlineorderinfo.Id = baPreSoldAutoOnlineOrderInfo.Id;
                    presoldautoonlineorderinfo.IMIXImageAssociationId = baPreSoldAutoOnlineOrderInfo.IMIXImageAssociationId;
                    presoldautoonlineorderinfo.PhotoId = baPreSoldAutoOnlineOrderInfo.PhotoId;
                    presoldautoonlineorderinfo.IsOrdered = baPreSoldAutoOnlineOrderInfo.IsOrdered;
                    presoldautoonlineorderinfo.CardUniqueIdentifier = baPreSoldAutoOnlineOrderInfo.CardUniqueIdentifier;
                    presoldautoonlineorderinfo.Name = baPreSoldAutoOnlineOrderInfo.Name;
                    presoldautoonlineorderinfo.MaxImages = baPreSoldAutoOnlineOrderInfo.MaxImages;
                    presoldautoonlineorderinfo.PackageId = baPreSoldAutoOnlineOrderInfo.PackageId;
                    presoldautoonlineorderinfo.PS_Product_Pricing_ProductPrice = baPreSoldAutoOnlineOrderInfo.PS_Product_Pricing_ProductPrice;
                    presoldautoonlineorderinfo.ImageIdentificationType = baPreSoldAutoOnlineOrderInfo.ImageIdentificationType;
                    presoldautoonlineorderinfo.IsWaterMarked = baPreSoldAutoOnlineOrderInfo.IsWaterMarked;
                    presoldautoonlineorderinfo.IsActive = baPreSoldAutoOnlineOrderInfo.IsActive;

                    db.PreSoldAutoOnlineOrderInfos.Add(presoldautoonlineorderinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPreSoldAutoOnlineOrderInfo baPreSoldAutoOnlineOrderInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PreSoldAutoOnlineOrderInfos.Where(p => p.Id == baPreSoldAutoOnlineOrderInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        presoldautoonlineorderinfo presoldautoonlineorderinfo = new presoldautoonlineorderinfo();

                        presoldautoonlineorderinfo.Id = baPreSoldAutoOnlineOrderInfo.Id;
                        presoldautoonlineorderinfo.IMIXImageAssociationId = baPreSoldAutoOnlineOrderInfo.IMIXImageAssociationId;
                        presoldautoonlineorderinfo.PhotoId = baPreSoldAutoOnlineOrderInfo.PhotoId;
                        presoldautoonlineorderinfo.IsOrdered = baPreSoldAutoOnlineOrderInfo.IsOrdered;
                        presoldautoonlineorderinfo.CardUniqueIdentifier = baPreSoldAutoOnlineOrderInfo.CardUniqueIdentifier;
                        presoldautoonlineorderinfo.Name = baPreSoldAutoOnlineOrderInfo.Name;
                        presoldautoonlineorderinfo.MaxImages = baPreSoldAutoOnlineOrderInfo.MaxImages;
                        presoldautoonlineorderinfo.PackageId = baPreSoldAutoOnlineOrderInfo.PackageId;
                        presoldautoonlineorderinfo.PS_Product_Pricing_ProductPrice = baPreSoldAutoOnlineOrderInfo.PS_Product_Pricing_ProductPrice;
                        presoldautoonlineorderinfo.ImageIdentificationType = baPreSoldAutoOnlineOrderInfo.ImageIdentificationType;
                        presoldautoonlineorderinfo.IsWaterMarked = baPreSoldAutoOnlineOrderInfo.IsWaterMarked;
                        presoldautoonlineorderinfo.IsActive = baPreSoldAutoOnlineOrderInfo.IsActive;

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
                    var obj = db.PreSoldAutoOnlineOrderInfos.Where(p => p.Id == Id).FirstOrDefault();
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
