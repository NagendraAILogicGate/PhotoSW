using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
{
    public class baSpecProfileProductMappingInfo
    {
        public int Id { get; set; }
        public int SemiOrderProfileId { get; set; }
        public int ProductTypeId { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<specprofileproductmappinginfo> lst_specprofileproductmappinginfo = new List<specprofileproductmappinginfo>();
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    //foreach (var item in lst_str)
                    //{
                    specprofileproductmappinginfo specprofileproductmappinginfo = new specprofileproductmappinginfo();
                    specprofileproductmappinginfo.Id = 1;
                    specprofileproductmappinginfo.SemiOrderProfileId = 1;
                    specprofileproductmappinginfo.ProductTypeId = 1;
                    specprofileproductmappinginfo.IsActive = true;
                    lst_specprofileproductmappinginfo.Add(specprofileproductmappinginfo);

                    // }
                    var Id = lst_specprofileproductmappinginfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.SpecProfileProductMappingInfos.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.SpecProfileProductMappingInfos.AddRange(lst_specprofileproductmappinginfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.SpecProfileProductMappingInfos.AddRange(lst_specprofileproductmappinginfo);
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static baSpecProfileProductMappingInfo GetspecprofileproductmappinginfoDataById(int Id)
        {
            try
            {

                specprofileproductmappinginfo specprofileproductmappinginfo = new specprofileproductmappinginfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SpecProfileProductMappingInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baSpecProfileProductMappingInfo
                    {
                        Id = p.Id,
                        SemiOrderProfileId = p.SemiOrderProfileId,
                        ProductTypeId = p.ProductTypeId,
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
        public static List<baSpecProfileProductMappingInfo> GetSpecProfileProductMappingInfoData()
        {
            try
            {

                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SpecProfileProductMappingInfos.Where(p => p.IsActive == true).Select(p => new baSpecProfileProductMappingInfo
                    {
                        Id = p.Id,
                        SemiOrderProfileId = p.SemiOrderProfileId,
                        ProductTypeId = p.ProductTypeId,
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


        public static bool Insert ( baSpecProfileProductMappingInfo baSpecProfileProductMappingInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    specprofileproductmappinginfo specprofileproductmappinginfo = new specprofileproductmappinginfo();
                    specprofileproductmappinginfo.Id = specprofileproductmappinginfo.Id;
                    specprofileproductmappinginfo.SemiOrderProfileId = specprofileproductmappinginfo.SemiOrderProfileId;
                    specprofileproductmappinginfo.ProductTypeId = specprofileproductmappinginfo.ProductTypeId;
                    specprofileproductmappinginfo.IsActive = specprofileproductmappinginfo.IsActive;

                    db.SpecProfileProductMappingInfos.Add(specprofileproductmappinginfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baSpecProfileProductMappingInfo baSpecProfileProductMappingInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SpecProfileProductMappingInfos.Where(p => p.Id == baSpecProfileProductMappingInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        specprofileproductmappinginfo specprofileproductmappinginfo = new specprofileproductmappinginfo();
                        specprofileproductmappinginfo.Id = specprofileproductmappinginfo.Id;
                        specprofileproductmappinginfo.SemiOrderProfileId = specprofileproductmappinginfo.SemiOrderProfileId;
                        specprofileproductmappinginfo.ProductTypeId = specprofileproductmappinginfo.ProductTypeId;
                        specprofileproductmappinginfo.IsActive = specprofileproductmappinginfo.IsActive;

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
                    var obj = db.SpecProfileProductMappingInfos.Where(p => p.Id == Id).FirstOrDefault();
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
