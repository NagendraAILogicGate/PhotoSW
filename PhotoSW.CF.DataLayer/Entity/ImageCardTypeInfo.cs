using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("ImageCardTypeInfo")]
    public class imagecardtypeinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int IMIXImageCardTypeId { get; set; }

        public string Name { get; set; }

        public string CardIdentificationDigit { get; set; }

        public int ImageIdentificationType { get; set; }

      //  public bool? IsActive { get; set; }

        public bool? IsWaterMark { get; set; }

        public int? MaxImages { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool? IsPrepaid { get; set; }

        public int? PackageId { get; set; }

        public string Status { get; set; }

        public string ImageIdentificationTypeName { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
