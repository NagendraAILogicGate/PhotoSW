using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("GetLocationPerformance_Result")]
    public class getlocationperformance_result
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string selectedSubStore { get; set; }

        public int Number_of_Capture { get; set; }

        public int Number_of_Sales { get; set; }

        public int ImageSold { get; set; }

        public decimal Revenue { get; set; }

        public string PS_Location_Name { get; set; }

        public string StoreName { get; set; }

        public string Printedby { get; set; }

        public int PS_Location_pkey { get; set; }

        public string PS_SubStore_Name { get; set; }

        public int Shots_Previewed { get; set; }

        public string DataFlag { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime SecondFromDate { get; set; }

        public DateTime SecondToDate { get; set; }

        public decimal AveragePrice { get; set; }

        public decimal SellThru { get; set; }

        public string defaultCurrency { get; set; }

        public decimal TotalSiteRevenue { get; set; }

        public string UserName { get; set; }

        public int PS_User_pkey { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
