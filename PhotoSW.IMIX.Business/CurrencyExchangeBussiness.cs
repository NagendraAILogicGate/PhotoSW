using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class CurrencyExchangeBussiness
    {

        public List<PhotoSW.IMIX.Model.CurrencyExchangeinfo> GetCurrencyProfileList()
        {
            
           return new List<PhotoSW.IMIX.Model.CurrencyExchangeinfo>();
        }
        public List<PhotoSW.IMIX.Model.RateDetailInfo> GetProfilerateDetailList(long profileAuditID)
        {
            try
                {
                var obj = baRateDetailInfo.GetPhotoGroupInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.RateDetailInfo()
                        {
                        ProfileAuditID = p.ProfileAuditID,
                        DG_Currency_Name = p.DG_Currency_Name,
                        DG_Currency_Code = p.DG_Currency_Code,
                        ExchangeRate = p.ExchangeRate
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.RateDetailInfo>();
                }
            // return new List<Model.RateDetailInfo>();
            }
        public bool UpdateInsertProfile(long CreatedBy)
        {
            return false;
        }
        public bool UploadCurrencyData(long CreatedBy, DateTime CreatedOn, DataTable dtCurrencyExchange)
        {
            return false;
        }
    }
}
