using System;

namespace PhotoSW
{
    public class DiscountItem
    {
        public string DiscountName
        {
            get;
            set;
        }

        public int DiscountID
        {
            get;
            set;
        }

        public string DiscountSyncCode
        {
            get;
            set;
        }

        public int SelectedProductType_ID
        {
            get;
            set;
        }

        public double DiscountAmount
        {
            get;
            set;
        }

        public bool IsPercentageDiscount
        {
            get;
            set;
        }

        public bool IsSecure
        {
            get;
            set;
        }
    }
}
