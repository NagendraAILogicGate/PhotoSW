using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baValueTypeInfo
        {
        public int Id { get; set; }
        public int ValueTypeId { get; set; }
        public int ValueTypeGroupId { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public static bool Marge ()
            {
            List<valuetypeinfo> lst_valuetypeinfo = new List<valuetypeinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    valuetypeinfo valuetypeinfo = new valuetypeinfo();

                    valuetypeinfo.Id = 1;
                    valuetypeinfo.ValueTypeId = 5;
                    valuetypeinfo.ValueTypeGroupId = 8;
                    valuetypeinfo.Name = "";
                    valuetypeinfo.DisplayOrder = 5;
                    valuetypeinfo.CreatedBy = 2;
                    valuetypeinfo.CreatedDate = DateTime.Now;
                    valuetypeinfo.ModifiedBy = 2;
                    valuetypeinfo.ModifiedDate = DateTime.Now;
                    valuetypeinfo.IsActive = true;

                    lst_valuetypeinfo.Add(valuetypeinfo);

                    var Id = lst_valuetypeinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.TripCamSettingInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.ValueTypeInfos.AddRange(lst_valuetypeinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ValueTypeInfos.AddRange(lst_valuetypeinfo);
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

        public static baValueTypeInfo GetValueTypeInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ValueTypeInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baValueTypeInfo
                        {
                        Id = p.Id,
                        ValueTypeId = p.ValueTypeId,
                        ValueTypeGroupId = p.ValueTypeGroupId,
                        Name = p.Name,
                        DisplayOrder = p.DisplayOrder,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedBy = p.ModifiedBy,
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

        public static List<baValueTypeInfo> GetValueTypeInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ValueTypeInfos.Where(p => p.IsActive == true).Select(p => new baValueTypeInfo
                        {
                        Id = p.Id,
                        ValueTypeId = p.ValueTypeId,
                        ValueTypeGroupId = p.ValueTypeGroupId,
                        Name = p.Name,
                        DisplayOrder = p.DisplayOrder,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedBy = p.ModifiedBy,
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


        public static bool Insert ( baValueTypeInfo baValueTypeInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    valuetypeinfo valuetypeinfo = new valuetypeinfo();

                    valuetypeinfo.Id = baValueTypeInfo.Id;
                    valuetypeinfo.ValueTypeId = baValueTypeInfo.ValueTypeId;
                    valuetypeinfo.ValueTypeGroupId = baValueTypeInfo.ValueTypeGroupId;
                    valuetypeinfo.Name = baValueTypeInfo.Name;
                    valuetypeinfo.DisplayOrder = baValueTypeInfo.DisplayOrder;
                    valuetypeinfo.CreatedBy = baValueTypeInfo.CreatedBy;
                    valuetypeinfo.CreatedDate = baValueTypeInfo.CreatedDate;
                    valuetypeinfo.ModifiedBy = baValueTypeInfo.ModifiedBy;
                    valuetypeinfo.ModifiedDate = baValueTypeInfo.ModifiedDate;
                    valuetypeinfo.IsActive = baValueTypeInfo.IsActive;

                    db.ValueTypeInfos.Add(valuetypeinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baValueTypeInfo baValueTypeInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ValueTypeInfos.Where(p => p.Id == baValueTypeInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        valuetypeinfo valuetypeinfo = new valuetypeinfo();

                        valuetypeinfo.Id = baValueTypeInfo.Id;
                        valuetypeinfo.ValueTypeId = baValueTypeInfo.ValueTypeId;
                        valuetypeinfo.ValueTypeGroupId = baValueTypeInfo.ValueTypeGroupId;
                        valuetypeinfo.Name = baValueTypeInfo.Name;
                        valuetypeinfo.DisplayOrder = baValueTypeInfo.DisplayOrder;
                        valuetypeinfo.CreatedBy = baValueTypeInfo.CreatedBy;
                        valuetypeinfo.CreatedDate = baValueTypeInfo.CreatedDate;
                        valuetypeinfo.ModifiedBy = baValueTypeInfo.ModifiedBy;
                        valuetypeinfo.ModifiedDate = baValueTypeInfo.ModifiedDate;
                        valuetypeinfo.IsActive = baValueTypeInfo.IsActive;

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
                    var obj = db.ValueTypeInfos.Where(p => p.Id == Id).FirstOrDefault();
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
