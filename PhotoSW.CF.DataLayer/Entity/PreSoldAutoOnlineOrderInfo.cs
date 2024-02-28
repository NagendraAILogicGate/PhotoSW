using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("PreSoldAutoOnlineOrderInfo")]
    public class presoldautoonlineorderinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long IMIXImageAssociationId { get; set; }

        public int PhotoId { get; set; }

        public int IsOrdered { get; set; }

        public string CardUniqueIdentifier { get; set; }

        public string Name { get; set; }

        public int MaxImages { get; set; }

        public int PackageId { get; set; }

        public float PS_Product_Pricing_ProductPrice { get; set; }

        public int ImageIdentificationType { get; set; }

        public bool IsWaterMarked { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
