using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhotoSW.ViewModels
{
    public class ProductTypeList
    {
        public int PackageDetailsID
        {
            get;
            set;
        }

        public bool IsPackage
        {
            get;
            set;
        }

        public int ProductTypeId
        {
            get;
            set;
        }

        public string ProductTypeName
        {
            get;
            set;
        }

        public bool IsSeletedPack
        {
            get;
            set;
        }

        public int? Quantity
        {
            get;
            set;
        }

        public int? MaxQuantity
        {
            get;
            set;
        }

        public bool? Isactive
        {
            get;
            set;
        }

        public int? VideoLength
        {
            get;
            set;
        }

        public Visibility visibleVideoLength
        {
            get;
            set;
        }

        public Visibility visibleMaxImagesVideos
        {
            get;
            set;
        }
    }
}
