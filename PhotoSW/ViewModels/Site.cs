using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.ViewModels
{
    public class Site
    {
        public string SiteName
        {
            get;
            set;
        }

        public string SiteCode
        {
            get;
            set;
        }

        public string SiteSyncCode
        {
            get;
            set;
        }

        public bool IsLogical
        {
            get;
            set;
        }

        public string LogicalSyncCode
        {
            get;
            set;
        }

        public List<Item> ItemDetails
        {
            get;
            set;
        }
    }
}
