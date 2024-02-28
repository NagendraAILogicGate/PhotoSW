using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.ViewModels
{
   public class PhotosDetails
    {
        public string PhotoName { get; set; }
        public string PhotoId { get; set; }
        public System.Windows.Visibility ImageVisibility { get; set; }
        public System.Windows.Visibility OtherVisibility { get; set; }
        public string FilePath { get; set; }
        public decimal? AmountRefunded { get; set; }
        public bool ischekd { get; set; }
    }
}
