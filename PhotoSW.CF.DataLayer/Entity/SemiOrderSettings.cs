using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("SemiOrderSetting")]

    public class semiordersetting
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PS_SemiOrder_Settings_Pkey { get; set; }

        public bool? PS_SemiOrder_Settings_AutoBright { get; set; }

        public double? PS_SemiOrder_Settings_AutoBright_Value { get; set; }

        public bool? PS_SemiOrder_Settings_AutoContrast { get; set; }

        public double? PS_SemiOrder_Settings_AutoContrast_Value { get; set; }

        public string PS_SemiOrder_Settings_ImageFrame { get; set; }

        public bool? PS_SemiOrder_Settings_IsImageFrame { get; set; }

        public string PS_SemiOrder_ProductTypeId { get; set; }

        public string PS_SemiOrder_Settings_ImageFrame_Vertical { get; set; }

        public bool? PS_SemiOrder_Environment { get; set; }

        public string PS_SemiOrder_BG { get; set; }

        public bool? PS_SemiOrder_Settings_IsImageBG { get; set; }

        public string PS_SemiOrder_Graphics_layer { get; set; }

        public string PS_SemiOrder_Image_ZoomInfo { get; set; }

        public int? PS_SubStoreId { get; set; }

        public bool? PS_SemiOrder_IsPrintActive { get; set; }

        public bool? PS_SemiOrder_IsCropActive { get; set; }

        public string VerticalCropValues { get; set; }

        public string HorizontalCropValues { get; set; }

        public int? PS_LocationId { get; set; }

        public string ChromaColor { get; set; }

        public string ColorCode { get; set; }

        public string ClrTolerance { get; set; }

        public string ProductName { get; set; }

        public string TextLogos { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
