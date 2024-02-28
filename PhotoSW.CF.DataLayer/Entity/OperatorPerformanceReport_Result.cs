using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("OperatorPerformanceReport_Result")]
    public class operatorperformancereport_result
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string CurrencySymbol { get; set; }

        public string StoreName { get; set; }

        public string UserName { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int Data1 { get; set; }

        public decimal Revenue { get; set; }

        public long TotalSale { get; set; }

        public long Images_Sold { get; set; }

        public int Capture { get; set; }

        public int Shots_Previewed { get; set; }

        public int TotalBurned { get; set; }

        public string OperatorName { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
