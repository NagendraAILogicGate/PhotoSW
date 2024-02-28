using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baItemTemplatePrintOrderModel
        {
        public int Id { get; set; }
        public int OrderLineItemId { get; set; }
        public int MasterTemplateId { get; set; }
        public int DetailTemplateId { get; set; }
        public int PrintTypeId { get; set; }
        public int PhotoId { get; set; }
        public int PageNo { get; set; }
        public int PrintPosition { get; set; }
        public int RotationAngle { get; set; }
        public int Status { get; set; }
        public int PrinterQueueId { get; set; }
        public string CreatedBy { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<itemtemplateprintordermodel> lst_itemtemplateprintordermodel = new List<itemtemplateprintordermodel>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    itemtemplateprintordermodel itemtemplateprintordermodel = new itemtemplateprintordermodel();


                    itemtemplateprintordermodel.Id = 1;
                    itemtemplateprintordermodel.OrderLineItemId = 2;
                    itemtemplateprintordermodel.MasterTemplateId = 2;
                    itemtemplateprintordermodel.DetailTemplateId = 4;
                    itemtemplateprintordermodel.PrintTypeId = 3;
                    itemtemplateprintordermodel.PhotoId = 5;
                    itemtemplateprintordermodel.PageNo = 4;
                    itemtemplateprintordermodel.PrintPosition = 3;
                    itemtemplateprintordermodel.RotationAngle = 2;
                    itemtemplateprintordermodel.Status = 4;
                    itemtemplateprintordermodel.PrinterQueueId = 6;
                    itemtemplateprintordermodel.CreatedBy = "";
                    itemtemplateprintordermodel.IsActive = true;

                    lst_itemtemplateprintordermodel.Add(itemtemplateprintordermodel);

                    var Id = lst_itemtemplateprintordermodel.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ItemTemplateMasterModels.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.ItemTemplatePrintOrderModels.AddRange(lst_itemtemplateprintordermodel);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ItemTemplatePrintOrderModels.AddRange(lst_itemtemplateprintordermodel);
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

        public static baItemTemplatePrintOrderModel GetItemTemplatePrintOrderModelById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ItemTemplatePrintOrderModels.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baItemTemplatePrintOrderModel
                        {

                        Id = p.Id,
                        OrderLineItemId = p.OrderLineItemId,
                        MasterTemplateId = p.MasterTemplateId,
                        DetailTemplateId = p.DetailTemplateId,
                        PrintTypeId = p.PrintTypeId,
                        PhotoId = p.PhotoId,
                        PageNo = p.PageNo,
                        PrintPosition = p.PrintPosition,
                        RotationAngle = p.RotationAngle,
                        Status = p.Status,
                        PrinterQueueId = p.PrinterQueueId,
                        CreatedBy = p.CreatedBy,
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

        public static List<baItemTemplatePrintOrderModel> GetItemTemplatePrintOrderModelData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ItemTemplatePrintOrderModels.Where(p => p.IsActive == true).Select(p => new baItemTemplatePrintOrderModel
                        {
                        Id = p.Id,
                        OrderLineItemId = p.OrderLineItemId,
                        MasterTemplateId = p.MasterTemplateId,
                        DetailTemplateId = p.DetailTemplateId,
                        PrintTypeId = p.PrintTypeId,
                        PhotoId = p.PhotoId,
                        PageNo = p.PageNo,
                        PrintPosition = p.PrintPosition,
                        RotationAngle = p.RotationAngle,
                        Status = p.Status,
                        PrinterQueueId = p.PrinterQueueId,
                        CreatedBy = p.CreatedBy,
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

        public static bool Insert ( baItemTemplatePrintOrderModel baItemTemplatePrintOrderModel )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    itemtemplateprintordermodel itemtemplateprintordermodel = new itemtemplateprintordermodel();

                    itemtemplateprintordermodel.Id = baItemTemplatePrintOrderModel.Id;
                    itemtemplateprintordermodel.OrderLineItemId = baItemTemplatePrintOrderModel.OrderLineItemId;
                    itemtemplateprintordermodel.MasterTemplateId = baItemTemplatePrintOrderModel.MasterTemplateId;
                    itemtemplateprintordermodel.DetailTemplateId = baItemTemplatePrintOrderModel.DetailTemplateId;
                    itemtemplateprintordermodel.PrintTypeId = baItemTemplatePrintOrderModel.PrintTypeId;
                    itemtemplateprintordermodel.PhotoId = baItemTemplatePrintOrderModel.PhotoId;
                    itemtemplateprintordermodel.PageNo = baItemTemplatePrintOrderModel.PageNo;
                    itemtemplateprintordermodel.PrintPosition = baItemTemplatePrintOrderModel.PrintPosition;
                    itemtemplateprintordermodel.RotationAngle = baItemTemplatePrintOrderModel.RotationAngle;
                    itemtemplateprintordermodel.Status = baItemTemplatePrintOrderModel.Status;
                    itemtemplateprintordermodel.PrinterQueueId = baItemTemplatePrintOrderModel.PrinterQueueId;
                    itemtemplateprintordermodel.CreatedBy = baItemTemplatePrintOrderModel.CreatedBy;
                    itemtemplateprintordermodel.IsActive = baItemTemplatePrintOrderModel.IsActive;

                    db.ItemTemplatePrintOrderModels.Add(itemtemplateprintordermodel);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baItemTemplatePrintOrderModel baItemTemplatePrintOrderModel )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ItemTemplatePrintOrderModels.Where(p => p.Id == baItemTemplatePrintOrderModel.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        itemtemplateprintordermodel itemtemplateprintordermodel = new itemtemplateprintordermodel();

                        itemtemplateprintordermodel.Id = baItemTemplatePrintOrderModel.Id;
                        itemtemplateprintordermodel.OrderLineItemId = baItemTemplatePrintOrderModel.OrderLineItemId;
                        itemtemplateprintordermodel.MasterTemplateId = baItemTemplatePrintOrderModel.MasterTemplateId;
                        itemtemplateprintordermodel.DetailTemplateId = baItemTemplatePrintOrderModel.DetailTemplateId;
                        itemtemplateprintordermodel.PrintTypeId = baItemTemplatePrintOrderModel.PrintTypeId;
                        itemtemplateprintordermodel.PhotoId = baItemTemplatePrintOrderModel.PhotoId;
                        itemtemplateprintordermodel.PageNo = baItemTemplatePrintOrderModel.PageNo;
                        itemtemplateprintordermodel.PrintPosition = baItemTemplatePrintOrderModel.PrintPosition;
                        itemtemplateprintordermodel.RotationAngle = baItemTemplatePrintOrderModel.RotationAngle;
                        itemtemplateprintordermodel.Status = baItemTemplatePrintOrderModel.Status;
                        itemtemplateprintordermodel.PrinterQueueId = baItemTemplatePrintOrderModel.PrinterQueueId;
                        itemtemplateprintordermodel.CreatedBy = baItemTemplatePrintOrderModel.CreatedBy;
                        itemtemplateprintordermodel.IsActive = baItemTemplatePrintOrderModel.IsActive;

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
                    var obj = db.ItemTemplatePrintOrderModels.Where(p => p.Id == Id).FirstOrDefault();
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
