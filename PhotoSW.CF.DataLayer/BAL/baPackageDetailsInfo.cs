using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baPackageDetailsInfo
        {
        public long Id { get; set; }
        public int PS_Package_Details_Pkey { get; set; }
        public int PS_ProductTypeId { get; set; }
        public int PS_PackageId { get; set; }
        public int PS_Product_Quantity { get; set; }
        public int PS_Product_MaxImage { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public string PS_ProductTypeIdComa { get; set; }
        public int PS_Orders_ProductType_pkey { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<packagedetailsinfo> lst_packagedetailsinfo = new List<packagedetailsinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    packagedetailsinfo packagedetailsinfo = new packagedetailsinfo();

                    packagedetailsinfo.Id = 1;
                    packagedetailsinfo.PS_Package_Details_Pkey = 2;
                    packagedetailsinfo.PS_ProductTypeId = 3;
                    packagedetailsinfo.PS_PackageId = 4;
                    packagedetailsinfo.PS_Product_Quantity = 5;
                    packagedetailsinfo.PS_Product_MaxImage = 6;
                    packagedetailsinfo.SyncCode = "";
                    packagedetailsinfo.IsSynced = false;
                    packagedetailsinfo.PS_ProductTypeIdComa = "";
                    packagedetailsinfo.PS_Orders_ProductType_pkey = 5;
                    packagedetailsinfo.IsActive = true;

                    lst_packagedetailsinfo.Add(packagedetailsinfo);

                    var Id = lst_packagedetailsinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PackageDetailsInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.PackageDetailsInfos.AddRange(lst_packagedetailsinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.PackageDetailsInfos.AddRange(lst_packagedetailsinfo);
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

        public static baPackageDetailsInfo GetPackageDetailsInfoById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PackageDetailsInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPackageDetailsInfo
                        {

                        Id = p.Id,
                        PS_Package_Details_Pkey = p.PS_Package_Details_Pkey,
                        PS_ProductTypeId = p.PS_ProductTypeId,
                        PS_PackageId = p.PS_PackageId,
                        PS_Product_Quantity = p.PS_Product_Quantity,
                        PS_Product_MaxImage = p.PS_Product_MaxImage,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        PS_ProductTypeIdComa = p.PS_ProductTypeIdComa,
                        PS_Orders_ProductType_pkey = p.PS_Orders_ProductType_pkey,
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

        public static List<baPackageDetailsInfo> GetPackageDetailsInfoData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PackageDetailsInfos.Where(p => p.IsActive == true).Select(p => new baPackageDetailsInfo
                        {
                        Id = p.Id,
                        PS_Package_Details_Pkey = p.PS_Package_Details_Pkey,
                        PS_ProductTypeId = p.PS_ProductTypeId,
                        PS_PackageId = p.PS_PackageId,
                        PS_Product_Quantity = p.PS_Product_Quantity,
                        PS_Product_MaxImage = p.PS_Product_MaxImage,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        PS_ProductTypeIdComa = p.PS_ProductTypeIdComa,
                        PS_Orders_ProductType_pkey = p.PS_Orders_ProductType_pkey,
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

        public static bool Insert ( baPackageDetailsInfo baPackageDetailsInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    packagedetailsinfo packagedetailsinfo = new packagedetailsinfo();

                    packagedetailsinfo.Id = baPackageDetailsInfo.Id;
                    packagedetailsinfo.PS_Package_Details_Pkey = baPackageDetailsInfo.PS_Package_Details_Pkey;
                    packagedetailsinfo.PS_ProductTypeId = baPackageDetailsInfo.PS_ProductTypeId;
                    packagedetailsinfo.PS_PackageId = baPackageDetailsInfo.PS_PackageId;
                    packagedetailsinfo.PS_Product_Quantity = baPackageDetailsInfo.PS_Product_Quantity;
                    packagedetailsinfo.PS_Product_MaxImage = baPackageDetailsInfo.PS_Product_MaxImage;
                    packagedetailsinfo.SyncCode = baPackageDetailsInfo.SyncCode;
                    packagedetailsinfo.IsSynced = baPackageDetailsInfo.IsSynced;
                    packagedetailsinfo.PS_ProductTypeIdComa = baPackageDetailsInfo.PS_ProductTypeIdComa;
                    packagedetailsinfo.PS_Orders_ProductType_pkey = baPackageDetailsInfo.PS_Orders_ProductType_pkey;
                    packagedetailsinfo.IsActive = baPackageDetailsInfo.IsActive;

                    db.PackageDetailsInfos.Add(packagedetailsinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPackageDetailsInfo baPackageDetailsInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PackageDetailsInfos.Where(p => p.Id == baPackageDetailsInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        packagedetailsinfo packagedetailsinfo = new packagedetailsinfo();

                        packagedetailsinfo.Id = baPackageDetailsInfo.Id;
                        packagedetailsinfo.PS_Package_Details_Pkey = baPackageDetailsInfo.PS_Package_Details_Pkey;
                        packagedetailsinfo.PS_ProductTypeId = baPackageDetailsInfo.PS_ProductTypeId;
                        packagedetailsinfo.PS_PackageId = baPackageDetailsInfo.PS_PackageId;
                        packagedetailsinfo.PS_Product_Quantity = baPackageDetailsInfo.PS_Product_Quantity;
                        packagedetailsinfo.PS_Product_MaxImage = baPackageDetailsInfo.PS_Product_MaxImage;
                        packagedetailsinfo.SyncCode = baPackageDetailsInfo.SyncCode;
                        packagedetailsinfo.IsSynced = baPackageDetailsInfo.IsSynced;
                        packagedetailsinfo.PS_ProductTypeIdComa = baPackageDetailsInfo.PS_ProductTypeIdComa;
                        packagedetailsinfo.PS_Orders_ProductType_pkey = baPackageDetailsInfo.PS_Orders_ProductType_pkey;
                        packagedetailsinfo.IsActive = baPackageDetailsInfo.IsActive;

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
                    var obj = db.PackageDetailsInfos.Where(p => p.Id == Id).FirstOrDefault();
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
