using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.IMIX.Model;

namespace PhotoSW.Orders
{
    public class PaymentItem
    {
        public string ItemNumber
        {
            get;
            set;
        }

        public int PaymentType
        {
            get;
            set;
        }

        public double PaidAmount
        {
            get;
            set;
        }

        public int Currency
        {
            get;
            set;
        }

        public string CurrencySyncCode
        {
            get;
            set;
        }

        public string CurrencyCode
        {
            get;
            set;
        }

        public string CurrencyName
        {
            get;
            set;
        }

        public string CardNumber
        {
            get;
            set;
        }

        public string CardType
        {
            get;
            set;
        }

        public string CardYear
        {
            get;
            set;
        }

        public string CardMonth
        {
            get;
            set;
        }

        public string CardExpiryDate
        {
            get;
            set;
        }

        public List<CurrencyInfo> CurrencyList
        {
            get;
            set;
        }

        public string HotelName
        {
            get;
            set;
        }

        public string RoomNumber
        {
            get;
            set;
        }

        public string CandidateName
        {
            get;
            set;
        }

        public string VoucherNumber
        {
            get;
            set;
        }
    }
}
