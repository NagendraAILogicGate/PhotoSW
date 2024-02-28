using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class CalenderBusiness
    {
        public bool AddItemTemplatePrintOrder(PhotoSW.IMIX.Model.ItemTemplatePrintOrderModel obj)
        {
            return false;
        }
        public List<PhotoSW.IMIX.Model.ItemTemplateDetailModel> GetItemTemplateDetail()
        {
            try
                {
                var obj = baItemTemplateDetailModel.GetItemTemplateDetailModelInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.ItemTemplateDetailModel
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
                       // IsActive = p.IsActive

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.ItemTemplateDetailModel>();
                }

            // return new List<PhotoSW.IMIX.Model.ItemTemplateDetailModel>();
            }
        public List<PhotoSW.IMIX.Model.ItemTemplateMasterModel> GetItemTemplateMaster()
        {
            try
                {
                var obj = baItemTemplateMasterModel.GetItemTemplateMasterModelInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.ItemTemplateMasterModel
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
                      //  IsActive = p.IsActive

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.ItemTemplateMasterModel>();
                }
            //  return new List<PhotoSW.IMIX.Model.ItemTemplateMasterModel>();
            }
        public List<PhotoSW.IMIX.Model.ItemTemplateDetailModel> GetItemTemplatePath(int Id)
        {
            try
                {
                var obj = baItemTemplateDetailModel.GetItemTemplateDetailModelInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.ItemTemplateDetailModel
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
                        // IsActive = p.IsActive

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.ItemTemplateDetailModel>();
                }
            // return new List<PhotoSW.IMIX.Model.ItemTemplateDetailModel>();
            }
    }
}
