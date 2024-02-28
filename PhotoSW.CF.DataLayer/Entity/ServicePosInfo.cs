using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("ServicePosInfo")]

    public class serviceposinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public long ImixPosId { get; set; }

        public int SubstoreId { get; set; }

        public string ServiceName { get; set; }

        public string SystemName { get; set; }

        public string SubStoremName { get; set; }

        public string UniqueCode { get; set; }

        public int RunLevel { get; set; }

        public string Status { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
