using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
         public class baReportTypeDetail
             {
             private int Id { get; set; }
             private string ReportTypeName { get; set; }
             private string ReportLabel { get; set; }
             public bool? IsActive { get; set; }


       
        }
    }
