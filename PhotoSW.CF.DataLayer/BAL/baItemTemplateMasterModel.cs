using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baItemTemplateMasterModel
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SubtemplateCount { get; set; }
        public int PathType { get; set; }
        public int TemplateType { get; set; }
        public string ThumbnailImagePath { get; set; }
        public string ThumbnailImageName { get; set; }
        public int Status { get; set; }
        public string BasePath { get; set; }
        public List<itemtemplatedetailmodel> ItemTemplateDetailList { get; set; }
        public bool? IsActive { get; set; }


        public static bool Marge ()
            {
            List<itemtemplatemastermodel> lst_itemtemplatemastermodel = new List<itemtemplatemastermodel>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    itemtemplatemastermodel itemtemplatemastermodel = new itemtemplatemastermodel();

                    itemtemplatemastermodel.Id = 1;
                    itemtemplatemastermodel.Name = "";
                    itemtemplatemastermodel.Description = "";
                    itemtemplatemastermodel.SubtemplateCount = 2;
                    itemtemplatemastermodel.PathType = 4;
                    itemtemplatemastermodel.TemplateType = 2;
                    itemtemplatemastermodel.ThumbnailImagePath = "";
                    itemtemplatemastermodel.ThumbnailImageName = "";
                    itemtemplatemastermodel.Status = 5;
                    itemtemplatemastermodel.BasePath = "";
                    itemtemplatemastermodel.IsActive = true;

                    lst_itemtemplatemastermodel.Add(itemtemplatemastermodel);

                    var Id = lst_itemtemplatemastermodel.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ItemTemplateMasterModels.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.ItemTemplateMasterModels.AddRange(lst_itemtemplatemastermodel);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ItemTemplateMasterModels.AddRange(lst_itemtemplatemastermodel);
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

        public static baItemTemplateMasterModel GetItemTemplateMasterModelInfoById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ItemTemplateMasterModels.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baItemTemplateMasterModel
                        {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        SubtemplateCount = p.SubtemplateCount,
                        PathType = p.PathType,
                        TemplateType = p.TemplateType,
                        ThumbnailImagePath = p.ThumbnailImagePath,
                        ThumbnailImageName = p.ThumbnailImageName,
                        Status = p.Status,
                        BasePath = p.BasePath,
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

        public static List<baItemTemplateMasterModel> GetItemTemplateMasterModelInfoData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ItemTemplateMasterModels.Where(p => p.IsActive == true).Select(p => new baItemTemplateMasterModel
                        {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        SubtemplateCount = p.SubtemplateCount,
                        PathType = p.PathType,
                        TemplateType = p.TemplateType,
                        ThumbnailImagePath = p.ThumbnailImagePath,
                        ThumbnailImageName = p.ThumbnailImageName,
                        Status = p.Status,
                        BasePath = p.BasePath,
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

        public static bool Insert ( baItemTemplateMasterModel baItemTemplateMasterModel )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    itemtemplatemastermodel itemtemplatemastermodel = new itemtemplatemastermodel();

                    itemtemplatemastermodel.Id = baItemTemplateMasterModel.Id;
                    itemtemplatemastermodel.Name = baItemTemplateMasterModel.Name;
                    itemtemplatemastermodel.Description = baItemTemplateMasterModel.Description;
                    itemtemplatemastermodel.SubtemplateCount = baItemTemplateMasterModel.SubtemplateCount;
                    itemtemplatemastermodel.PathType = baItemTemplateMasterModel.PathType;
                    itemtemplatemastermodel.TemplateType = baItemTemplateMasterModel.TemplateType;
                    itemtemplatemastermodel.ThumbnailImagePath = baItemTemplateMasterModel.ThumbnailImagePath;
                    itemtemplatemastermodel.ThumbnailImageName = baItemTemplateMasterModel.ThumbnailImageName;
                    itemtemplatemastermodel.Status = baItemTemplateMasterModel.Status;
                    itemtemplatemastermodel.BasePath = baItemTemplateMasterModel.BasePath;
                    itemtemplatemastermodel.IsActive = baItemTemplateMasterModel.IsActive;

                    db.ItemTemplateMasterModels.Add(itemtemplatemastermodel);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baItemTemplateMasterModel baItemTemplateMasterModel )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ItemTemplateMasterModels.Where(p => p.Id == baItemTemplateMasterModel.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        itemtemplatemastermodel itemtemplatemastermodel = new itemtemplatemastermodel();

                        itemtemplatemastermodel.Id = baItemTemplateMasterModel.Id;
                        itemtemplatemastermodel.Name = baItemTemplateMasterModel.Name;
                        itemtemplatemastermodel.Description = baItemTemplateMasterModel.Description;
                        itemtemplatemastermodel.SubtemplateCount = baItemTemplateMasterModel.SubtemplateCount;
                        itemtemplatemastermodel.PathType = baItemTemplateMasterModel.PathType;
                        itemtemplatemastermodel.TemplateType = baItemTemplateMasterModel.TemplateType;
                        itemtemplatemastermodel.ThumbnailImagePath = baItemTemplateMasterModel.ThumbnailImagePath;
                        itemtemplatemastermodel.ThumbnailImageName = baItemTemplateMasterModel.ThumbnailImageName;
                        itemtemplatemastermodel.Status = baItemTemplateMasterModel.Status;
                        itemtemplatemastermodel.BasePath = baItemTemplateMasterModel.BasePath;
                        itemtemplatemastermodel.IsActive = baItemTemplateMasterModel.IsActive;

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
                    var obj = db.ItemTemplateMasterModels.Where(p => p.Id == Id).FirstOrDefault();
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
