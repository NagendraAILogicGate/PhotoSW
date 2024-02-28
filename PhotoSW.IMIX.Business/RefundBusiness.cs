using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class RefundBusiness
    {
        public double GetOrderRefundedAmount(int Orderid) { return 0; }
        public List<PhotoSW.IMIX.Model.RefundInfo> GetRefundedItems(int OrderId)
        {
            return new List<PhotoSW.IMIX.Model.RefundInfo>();
        }
        public string GetRefundText()
        {
            return "";
        }
        public bool SetRefundDetailsData(int DG_LineItemId, 
            int DG_RefundMaster_ID, string PhotoId, decimal? refundprice,
            string reason)
        {
            return false;
        }
        public int SetRefundMasterData(int OrderId, decimal RefundAmount, DateTime RefundDate, int UserId)
        {
            return 0;
        }
    }
}
