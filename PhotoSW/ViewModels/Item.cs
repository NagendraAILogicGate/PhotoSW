using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.ViewModels
{
    public class Item
    {
        public string ItemName
        {
            get;
            set;
        }

        public string ItemCode
        {
            get;
            set;
        }

        public string ItemDescription
        {
            get;
            set;
        }

        public bool IsPackage
        {
            get;
            set;
        }

        public bool IsAccessory
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }

        public string ItemSyncCode
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public string ItemSiteSyncCode
        {
            get;
            set;
        }

        public List<PackageDetail> PackageKittingDetails
        {
            get;
            set;
        }
    }
}
