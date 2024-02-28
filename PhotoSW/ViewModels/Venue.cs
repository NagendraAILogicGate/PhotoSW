using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.ViewModels
{
    public class Venue
    {
        public string CountryName
        {
            get;
            set;
        }

        public string CountryCode
        {
            get;
            set;
        }

        public string VenueName
        {
            get;
            set;
        }

        public string VenueCode
        {
            get;
            set;
        }

        public List<Site> SiteDetails
        {
            get;
            set;
        }
    }
}
