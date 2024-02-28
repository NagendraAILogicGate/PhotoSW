using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("BorderInfo")]

    public class borderinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int PS_Borders_pkey { get; set; }

        public string PS_Border { get; set; }

        public int PS_ProductTypeID { get; set; }

        public bool PS_IsActive { get; set; }

        public string SyncCode { get; set; }

        public bool IsSynced { get; set; }

        public int PS_Orders_ProductType_pkey { get; set; }

        public string PS_Orders_ProductType_Name { get; set; }

        //public ProductTypeInfo ProductTypeInfo
        //{
        //	get;
        //	set;
        //}

        public string FilePath { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
