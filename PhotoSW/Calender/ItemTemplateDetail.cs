using System;
using System.Collections.Generic;

namespace PhotoSW.Calender
{
    public class ItemTemplateDetail
    {
        public string AssociationPhotoFilePath { get; set; }     

        public string AssociationPhotoFileName { get; set; }

        public int AssociationPhotoId { get; set; }

        public string AssociationPhotoName { get; set; }

        public int Id { get; set; }

        public int MasterTemplateId { get; set; }

        public int TemplateType { get; set; }

        public string FileName { get; set; }

        public string FileNameWithotExtension { get; set; }

        public string FilePath { get; set; }

        public int Status { get; set; }

        public int I1_X1 { get; set; }

        public int I1_Y1 { get; set; }

        public int I1_X2 { get; set; }

        public int I1_Y2 { get; set; }

        public int FileOrder { get; set; }

        public virtual ItemTemplateMaster ItemTemplateMaster { get; set; }

        public virtual ICollection<ItemTemplatePrintOrder> ItemTemplatePrintOrders { get; set; }

        public ItemTemplateDetail()
        {
            this.ItemTemplatePrintOrders = new HashSet<ItemTemplatePrintOrder>();
        }
    }
}
