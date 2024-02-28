using PhotoSW.CF.DataLayer.BAL;
using PhotoSW.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
   public class CashBoxBusiness
   {
       public bool SetcashBoxReason(DateTime createddate, int userid, string reason)
       {
            baCashBoxInfo bacashBoxInfo = new baCashBoxInfo();
            bacashBoxInfo.Reason = reason;
            bacashBoxInfo.UserId= userid;
            bacashBoxInfo.CreatedDate = createddate;
            return baCashBoxInfo.Insert(bacashBoxInfo);
       }

    }
}
