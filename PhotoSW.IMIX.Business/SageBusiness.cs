using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.BAL;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.Business
{
    public class SageBusiness
    {
        public SageInfo GetOpenCloseProcDetail(int SubStoreID)
        {
            try
            {
                var obj = baSageInfo.GetSageInfoData().Where(p => p.SubStoreID == SubStoreID)
                    .Select(p => new PhotoSW.IMIX.Model.SageInfo
                    {
                        
                        OpeningFormDetailID = p.OpenCloseProcDetailID,
                        sixEightStartingNumber = p.sixEightStartingNumber,
                        eightTenStartingNumber = p.eightTenAutoStartingNumber,
                        sixEightAutoStartingNumber = p.sixEightAutoStartingNumber,
                        eightTenAutoStartingNumber = p.eightTenAutoStartingNumber,
                        PosterStartingNumber = p.PosterStartingNumber,
                        CashFloatAmount = p.CashFloatAmount,
                        SubStoreID = p.SubStoreID,
                        OpeningDate = p.OpeningDate,
                        FilledBySyncCode = p.FilledBySyncCode,
                        FilledBy = p.FilledBy,
                        OpenCloseProcDetailID = p.OpenCloseProcDetailID,
                        FormTypeID = p.FormTypeID,
                        FilledOn = p.FilledOn,
                        TransDate = p.TransDate,
                        FormID = p.FormID,
                        SyncCode = p.SyncCode,
                        BusinessDate = p.BusinessDate,
                        ServerTime = p.ServerTime,

                     
                    }).FirstOrDefault();
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int GetCaptureBySubStoreAndDateRange(DateTime FromDate, DateTime ToDate, int SubStoreID)
{ return 0;}
      
        public int GetPreviewBySubStoreAndDateRange(DateTime FromDate, DateTime ToDate, int SubStoreID)
{ return 0;}
        public List<PhotoSW.IMIX.Model.ImixPOSDetail> GetPrintServerDetails(int SubStoreID)
        {
            try
                {
                var obj = baImixPOSDetail.GetImixPOSDetailData()
                    .Where(p=>p.SubStoreID == SubStoreID)
                    .Select(p => new PhotoSW.IMIX.Model.ImixPOSDetail
                        {
                        ImixPOSDetailID = p.ImixPOSDetailID,
                        SystemName = p.SystemName,
                        IPAddress = p.IPAddress,
                        MacAddress = p.MacAddress,
                        SubStoreID = p.SubStoreID,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        UpdatedBy = p.UpdatedBy,
                        UpdatedOn = p.UpdatedOn,
                        IsStart = p.IsStart,
                        StartStopTime = p.StartStopTime,
                        SyncCode = p.SyncCode

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.ImixPOSDetail>();
                }
           // return new List<PhotoSW.IMIX.Model.ImixPOSDetail>();
        }
        public long GetTotalSoldBySubStoreAndDateRange(DateTime FromDate, DateTime ToDate, int SubStoreID)
{ return 0;}
        public List<PhotoSW.IMIX.Model.SageInfoWestage> ProductTypeWestage(DateTime FromDate, DateTime ToDate, int SubStoreID)
        {
            try
                {
                var obj = baSageInfoWestage.GetSageInfoWestageData()
                    .Select(p => new PhotoSW.IMIX.Model.SageInfoWestage
                        {
                        ProductType = p.ProductType,
                        Printed = p.Printed,
                        Reprint = p.Reprint

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.SageInfoWestage>();
                }
            // return new List<PhotoSW.IMIX.Model.SageInfoWestage>();
            }
        public bool SaveClosingForm(PhotoSW.IMIX.Model.SageOpenClose objOpenClose, List<PhotoSW.IMIX.Model.Printer6850> lst6850Printer, 
 List<PhotoSW.IMIX.Model.Printer8810> lst8810Printer)
        { return false;}
        public string SaveOpeningForm(PhotoSW.IMIX.Model.SageInfo _sageInfo, List<PhotoSW.IMIX.Model.Printer6850> lst6850Printer, 
List<PhotoSW.IMIX.Model.Printer8810> lst8810Printer){ return "";}
 
    }
}
