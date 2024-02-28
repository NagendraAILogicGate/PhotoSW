using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baItemTemplateDetailModel
        {
        public int Id { get; set; }
        public int AssociationPhotoId { get; set; }
        public string AssociationPhotoName { get; set; }
        public string AssociationPhotoFileName { get; set; }
        public string AssociationPhotoFilePath { get; set; }
        public int FileOrder { get; set; }
        public int MasterTemplateId { get; set; }
        public int TemplateType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int Status { get; set; }
        public int I1_X1 { get; set; }
        public int I1_Y1 { get; set; }
        public int I1_X2 { get; set; }
        public int I1_Y2 { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<itemtemplatedetailmodel> lst_itemtemplatedetailmodel = new List<itemtemplatedetailmodel>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    itemtemplatedetailmodel itemtemplatedetailmodel = new itemtemplatedetailmodel();

                    itemtemplatedetailmodel.Id = 1;
                    itemtemplatedetailmodel.AssociationPhotoId = 2;
                    itemtemplatedetailmodel.AssociationPhotoName = "";
                    itemtemplatedetailmodel.AssociationPhotoFileName = "";
                    itemtemplatedetailmodel.AssociationPhotoFilePath = "";
                    itemtemplatedetailmodel.FileOrder = 2;
                    itemtemplatedetailmodel.MasterTemplateId = 3;
                    itemtemplatedetailmodel.TemplateType = 3;
                    itemtemplatedetailmodel.FileName = "";
                    itemtemplatedetailmodel.FilePath = "";
                    itemtemplatedetailmodel.Status = 2;
                    itemtemplatedetailmodel.I1_X1 = 1;
                    itemtemplatedetailmodel.I1_Y1 = 2;
                    itemtemplatedetailmodel.I1_X2 = 3;
                    itemtemplatedetailmodel.I1_Y2 = 4;
                    itemtemplatedetailmodel.IsActive = true;

                    lst_itemtemplatedetailmodel.Add(itemtemplatedetailmodel);

                    var Id = lst_itemtemplatedetailmodel.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ItemTemplateDetailModels.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.ItemTemplateDetailModels.AddRange(lst_itemtemplatedetailmodel);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ItemTemplateDetailModels.AddRange(lst_itemtemplatedetailmodel);
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

        public static baItemTemplateDetailModel GetItemTemplateDetailModelInfoById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ItemTemplateDetailModels.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baItemTemplateDetailModel
                        {
                        Id = p.Id,
                        AssociationPhotoId = p.AssociationPhotoId,
                        AssociationPhotoName = p.AssociationPhotoName,
                        AssociationPhotoFileName = p.AssociationPhotoFileName,
                        AssociationPhotoFilePath = p.AssociationPhotoFilePath,
                        FileOrder = p.FileOrder,
                        MasterTemplateId = p.MasterTemplateId,
                        TemplateType = p.TemplateType,
                        FileName = p.FileName,
                        FilePath = p.FilePath,
                        Status = p.Status,
                        I1_X1 = p.I1_X1,
                        I1_Y1 = p.I1_Y1,
                        I1_X2 =  p.I1_X2,
                        I1_Y2 = p.I1_Y2,
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

        public static List<baItemTemplateDetailModel> GetItemTemplateDetailModelInfoData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ItemTemplateDetailModels.Where(p => p.IsActive == true).Select(p => new baItemTemplateDetailModel
                        {
                        Id = p.Id,
                        AssociationPhotoId = p.AssociationPhotoId,
                        AssociationPhotoName = p.AssociationPhotoName,
                        AssociationPhotoFileName = p.AssociationPhotoFileName,
                        AssociationPhotoFilePath = p.AssociationPhotoFilePath,
                        FileOrder = p.FileOrder,
                        MasterTemplateId = p.MasterTemplateId,
                        TemplateType = p.TemplateType,
                        FileName = p.FileName,
                        FilePath = p.FilePath,
                        Status = p.Status,
                        I1_X1 = p.I1_X1,
                        I1_Y1 = p.I1_Y1,
                        I1_X2 = p.I1_X2,
                        I1_Y2 = p.I1_Y2,
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

        public static bool Insert ( baItemTemplateDetailModel baItemTemplateDetailModel )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    itemtemplatedetailmodel itemtemplatedetailmodel = new itemtemplatedetailmodel();

                    itemtemplatedetailmodel.Id = baItemTemplateDetailModel.Id;
                    itemtemplatedetailmodel.AssociationPhotoId = baItemTemplateDetailModel.AssociationPhotoId;
                    itemtemplatedetailmodel.AssociationPhotoName = baItemTemplateDetailModel.AssociationPhotoName;
                    itemtemplatedetailmodel.AssociationPhotoFileName = baItemTemplateDetailModel.AssociationPhotoFileName;
                    itemtemplatedetailmodel.AssociationPhotoFilePath = baItemTemplateDetailModel.AssociationPhotoFilePath;
                    itemtemplatedetailmodel.FileOrder = baItemTemplateDetailModel.FileOrder;
                    itemtemplatedetailmodel.MasterTemplateId = baItemTemplateDetailModel.MasterTemplateId;
                    itemtemplatedetailmodel.TemplateType = baItemTemplateDetailModel.TemplateType;
                    itemtemplatedetailmodel.FileName = baItemTemplateDetailModel.FileName;
                    itemtemplatedetailmodel.FilePath = baItemTemplateDetailModel.FilePath;
                    itemtemplatedetailmodel.Status = baItemTemplateDetailModel.Status;
                    itemtemplatedetailmodel.I1_X1 = baItemTemplateDetailModel.I1_X1;
                    itemtemplatedetailmodel.I1_Y1 = baItemTemplateDetailModel.I1_Y1;
                    itemtemplatedetailmodel.I1_X2 = baItemTemplateDetailModel.I1_X2;
                    itemtemplatedetailmodel.I1_Y2 = baItemTemplateDetailModel.I1_Y2;
                    itemtemplatedetailmodel.IsActive = baItemTemplateDetailModel.IsActive;

                    db.ItemTemplateDetailModels.Add(itemtemplatedetailmodel);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baItemTemplateDetailModel baItemTemplateDetailModel )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ItemTemplateDetailModels.Where(p => p.Id == baItemTemplateDetailModel.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        itemtemplatedetailmodel itemtemplatedetailmodel = new itemtemplatedetailmodel();

                        itemtemplatedetailmodel.Id = baItemTemplateDetailModel.Id;
                        itemtemplatedetailmodel.AssociationPhotoId = baItemTemplateDetailModel.AssociationPhotoId;
                        itemtemplatedetailmodel.AssociationPhotoName = baItemTemplateDetailModel.AssociationPhotoName;
                        itemtemplatedetailmodel.AssociationPhotoFileName = baItemTemplateDetailModel.AssociationPhotoFileName;
                        itemtemplatedetailmodel.AssociationPhotoFilePath = baItemTemplateDetailModel.AssociationPhotoFilePath;
                        itemtemplatedetailmodel.FileOrder = baItemTemplateDetailModel.FileOrder;
                        itemtemplatedetailmodel.MasterTemplateId = baItemTemplateDetailModel.MasterTemplateId;
                        itemtemplatedetailmodel.TemplateType = baItemTemplateDetailModel.TemplateType;
                        itemtemplatedetailmodel.FileName = baItemTemplateDetailModel.FileName;
                        itemtemplatedetailmodel.FilePath = baItemTemplateDetailModel.FilePath;
                        itemtemplatedetailmodel.Status = baItemTemplateDetailModel.Status;
                        itemtemplatedetailmodel.I1_X1 = baItemTemplateDetailModel.I1_X1;
                        itemtemplatedetailmodel.I1_Y1 = baItemTemplateDetailModel.I1_Y1;
                        itemtemplatedetailmodel.I1_X2 = baItemTemplateDetailModel.I1_X2;
                        itemtemplatedetailmodel.I1_Y2 = baItemTemplateDetailModel.I1_Y2;
                        itemtemplatedetailmodel.IsActive = baItemTemplateDetailModel.IsActive;

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
                    var obj = db.ItemTemplateDetailModels.Where(p => p.Id == Id).FirstOrDefault();
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
