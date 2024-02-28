using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("DiscountTypeInfo")]
    public class discounttypeinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int PS_Orders_DiscountType_Pkey { get; set; }

        public string PS_Orders_DiscountType_Name { get; set; }

        public string PS_Orders_DiscountType_Desc { get; set; }

        public bool? PS_Orders_DiscountType_Active { get; set; }

        public bool? PS_Orders_DiscountType_Secure { get; set; }

        public bool? PS_Orders_DiscountType_ItemLevel { get; set; }

        public bool? PS_Orders_DiscountType_AsPercentage { get; set; }

        public string PS_Orders_DiscountType_Code { get; set; }

        public string SyncCode { get; set; }

        public bool IsSynced { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
