using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("SemiOrderSettingsInfo")]

    public class semiordersettingsinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

     //   public int Id { get; set; }

        public bool IsBrightActive { get; set; }

        public double BrightValue { get; set; }

        public bool IsContrastActive { get; set; }

        public double ContrastValue { get; set; }

        public string BorderName { get; set; }

        public bool IsBorderActive { get; set; }

        public string ProductTypeId { get; set; }

        public string VerticalBorderName { get; set; }

        public bool IsGreenScreenActive { get; set; }

        public string BackgroundName { get; set; }

        public bool IsChromaActive { get; set; }

        public string GraphicsLayer { get; set; }

        public string ZoomInfo { get; set; }

        public int SubstoreId { get; set; }

        public bool IsPrintActive { get; set; }

        public bool IsCropActive { get; set; }

        public string VerticalCropValues { get; set; }

        public string HorizontalCropValues { get; set; }

        public int LocationId { get; set; }

        public string ChromaColor { get; set; }

        public string ColorCode { get; set; }

        public string ClrTolerance { get; set; }

        public bool? Environment { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
