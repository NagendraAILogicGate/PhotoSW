using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baPackageDetailsViewInfo
        {
        public long Id { get; set; }
        public int PS_Package_Details_Pkey { get; set; }
        public int PS_ProductTypeId { get; set; }
        public int PS_PackageId { get; set; }
        public int PS_Product_Quantity { get; set; }
        public int PS_Orders_ProductType_pkey { get; set; }
        public string PS_Orders_ProductType_Name { get; set; }
        public int PS_Product_MaxImage { get; set; }
        public bool PS_Orders_ProductType_IsBundled { get; set; }
        public bool PS_IsAccessory { get; set; }
        public bool PS_IsActive { get; set; }
        public int? PS_Video_Length { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<packagedetailsviewinfo> lst_packagedetailsviewinfo = new List<packagedetailsviewinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    packagedetailsviewinfo packagedetailsviewinfo = new packagedetailsviewinfo();

                    packagedetailsviewinfo.Id = 1;
                    packagedetailsviewinfo.PS_Package_Details_Pkey = 2;
                    packagedetailsviewinfo.PS_ProductTypeId = 3;
                    packagedetailsviewinfo.PS_PackageId = 4;
                    packagedetailsviewinfo.PS_Product_Quantity = 5;
                    packagedetailsviewinfo.PS_Orders_ProductType_pkey = 6;
                    packagedetailsviewinfo.PS_Orders_ProductType_Name = "";
                    packagedetailsviewinfo.PS_Product_MaxImage = 5;
                    packagedetailsviewinfo.PS_Orders_ProductType_IsBundled = false;
                    packagedetailsviewinfo.PS_IsAccessory = false;
                    packagedetailsviewinfo.PS_IsActive = false;
                    packagedetailsviewinfo.PS_Video_Length = 3;
                    packagedetailsviewinfo.IsActive = true;

                    lst_packagedetailsviewinfo.Add(packagedetailsviewinfo);

                    var Id = lst_packagedetailsviewinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PackageDetailsViewInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.PackageDetailsViewInfos.AddRange(lst_packagedetailsviewinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.PackageDetailsViewInfos.AddRange(lst_packagedetailsviewinfo);
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

        public static baPackageDetailsViewInfo GetPackageDetailsViewInfoById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PackageDetailsViewInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPackageDetailsViewInfo
                        {

                        Id = p.Id,
                        PS_Package_Details_Pkey = p.PS_Package_Details_Pkey,
                        PS_ProductTypeId = p.PS_ProductTypeId,
                        PS_PackageId = p.PS_PackageId,
                        PS_Product_Quantity = p.PS_Product_Quantity,
                        PS_Orders_ProductType_pkey =p.PS_Orders_ProductType_pkey,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        PS_Product_MaxImage = p.PS_Product_MaxImage,
                        PS_Orders_ProductType_IsBundled = p.PS_Orders_ProductType_IsBundled,
                        PS_IsAccessory = p.PS_IsAccessory,
                        PS_IsActive = p.PS_IsActive,
                        PS_Video_Length = p.PS_Video_Length,
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

        public static List<baPackageDetailsViewInfo> GetPackageDetailsViewInfoData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PackageDetailsViewInfos.Where(p => p.IsActive == true).Select(p => new baPackageDetailsViewInfo
                        {
                        Id = p.Id,
                        PS_Package_Details_Pkey = p.PS_Package_Details_Pkey,
                        PS_ProductTypeId = p.PS_ProductTypeId,
                        PS_PackageId = p.PS_PackageId,
                        PS_Product_Quantity = p.PS_Product_Quantity,
                        PS_Orders_ProductType_pkey = p.PS_Orders_ProductType_pkey,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        PS_Product_MaxImage = p.PS_Product_MaxImage,
                        PS_Orders_ProductType_IsBundled = p.PS_Orders_ProductType_IsBundled,
                        PS_IsAccessory = p.PS_IsAccessory,
                        PS_IsActive = p.PS_IsActive,
                        PS_Video_Length = p.PS_Video_Length,
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

        public static bool Insert ( baPackageDetailsViewInfo baPackageDetailsViewInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    packagedetailsviewinfo packagedetailsviewinfo = new packagedetailsviewinfo();

                    packagedetailsviewinfo.Id = baPackageDetailsViewInfo.Id;
                    packagedetailsviewinfo.PS_Package_Details_Pkey = baPackageDetailsViewInfo.PS_Package_Details_Pkey;
                    packagedetailsviewinfo.PS_ProductTypeId = baPackageDetailsViewInfo.PS_ProductTypeId;
                    packagedetailsviewinfo.PS_PackageId = baPackageDetailsViewInfo.PS_PackageId;
                    packagedetailsviewinfo.PS_Product_Quantity = baPackageDetailsViewInfo.PS_Product_Quantity;
                    packagedetailsviewinfo.PS_Orders_ProductType_pkey = baPackageDetailsViewInfo.PS_Orders_ProductType_pkey;
                    packagedetailsviewinfo.PS_Orders_ProductType_Name = baPackageDetailsViewInfo.PS_Orders_ProductType_Name;
                    packagedetailsviewinfo.PS_Product_MaxImage = baPackageDetailsViewInfo.PS_Product_MaxImage;
                    packagedetailsviewinfo.PS_Orders_ProductType_IsBundled = baPackageDetailsViewInfo.PS_Orders_ProductType_IsBundled;
                    packagedetailsviewinfo.PS_IsAccessory = baPackageDetailsViewInfo.PS_IsAccessory;
                    packagedetailsviewinfo.PS_IsActive = baPackageDetailsViewInfo.PS_IsActive;
                    packagedetailsviewinfo.PS_Video_Length = baPackageDetailsViewInfo.PS_Video_Length;
                    packagedetailsviewinfo.IsActive = baPackageDetailsViewInfo.IsActive;

                    db.PackageDetailsViewInfos.Add(packagedetailsviewinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPackageDetailsViewInfo baPackageDetailsViewInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PackageDetailsViewInfos.Where(p => p.Id == baPackageDetailsViewInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        packagedetailsviewinfo packagedetailsviewinfo = new packagedetailsviewinfo();

                        packagedetailsviewinfo.Id = baPackageDetailsViewInfo.Id;
                        packagedetailsviewinfo.PS_Package_Details_Pkey = baPackageDetailsViewInfo.PS_Package_Details_Pkey;
                        packagedetailsviewinfo.PS_ProductTypeId = baPackageDetailsViewInfo.PS_ProductTypeId;
                        packagedetailsviewinfo.PS_PackageId = baPackageDetailsViewInfo.PS_PackageId;
                        packagedetailsviewinfo.PS_Product_Quantity = baPackageDetailsViewInfo.PS_Product_Quantity;
                        packagedetailsviewinfo.PS_Orders_ProductType_pkey = baPackageDetailsViewInfo.PS_Orders_ProductType_pkey;
                        packagedetailsviewinfo.PS_Orders_ProductType_Name = baPackageDetailsViewInfo.PS_Orders_ProductType_Name;
                        packagedetailsviewinfo.PS_Product_MaxImage = baPackageDetailsViewInfo.PS_Product_MaxImage;
                        packagedetailsviewinfo.PS_Orders_ProductType_IsBundled = baPackageDetailsViewInfo.PS_Orders_ProductType_IsBundled;
                        packagedetailsviewinfo.PS_IsAccessory = baPackageDetailsViewInfo.PS_IsAccessory;
                        packagedetailsviewinfo.PS_IsActive = baPackageDetailsViewInfo.PS_IsActive;
                        packagedetailsviewinfo.PS_Video_Length = baPackageDetailsViewInfo.PS_Video_Length;
                        packagedetailsviewinfo.IsActive = baPackageDetailsViewInfo.IsActive;

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
                    var obj = db.PackageDetailsViewInfos.Where(p => p.Id == Id).FirstOrDefault();
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
