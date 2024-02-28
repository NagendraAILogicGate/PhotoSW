using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.ViewModels
{
    public class PackageDetail
    {
        public int MaxImages
        {
            get;
            set;
        }

        public Item BaseProduct
        {
            get;
            set;
        }

        public string PkgSiteSyncCode
        {
            get;
            set;
        }

        public string pkgitemcode
        {
            get;
            set;
        }
    }
}
