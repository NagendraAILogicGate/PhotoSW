using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
   public class CurrencyBusiness
    {
       public string CurrentCurrencyConversionRate()
       {
          return "0";
       }
       public bool DeleteCurrency(int id)
       {
           return false;
       }
       public string GetCurrencyDetailFromID(int currencyId)
       {
           return "0";
       }
       public List<PhotoSW.IMIX.Model.CurrencyInfo> GetCurrencyDetails()
       {
       try
           {
           var obj =baCurrencyInfo.GetCurrencyInfoData()

               .Select(p => new PhotoSW.IMIX.Model.CurrencyInfo
               {
                   //Id = p.Id,

                   DG_Currency_pkey = p.PS_Currency_pkey,
                   DG_Currency_Name = p.PS_Currency_Name,
                   DG_Currency_Rate = p.PS_Currency_Rate,
                   DG_Currency_Symbol = p.PS_Currency_Symbol,
                   DG_Currency_UpdatedDate = p.PS_Currency_UpdatedDate,
                   DG_Currency_ModifiedBy = p.PS_Currency_ModifiedBy,
                   DG_Currency_Default = p.PS_Currency_Default,
                   DG_Currency_Icon = p.PS_Currency_Icon,
                   DG_Currency_Code = p.PS_Currency_Code,
                   DG_Currency_IsActive = p.PS_Currency_IsActive,
                   SyncCode = p.SyncCode,
                   IsSynced = p.IsSynced,

                   //IsActive = p.IsActive
               }).ToList();
           return obj;
           }
       catch
           {
           return new List<PhotoSW.IMIX.Model.CurrencyInfo>();
           }
           // List<PhotoSW.IMIX.Model.CurrencyInfo> obj = new List<PhotoSW.IMIX.Model.CurrencyInfo>();
           // return null;
       }
       public List<PhotoSW.IMIX.Model.CurrencyInfo> GetCurrencyList()
       {
       try
           {
           var obj = baCurrencyInfo.GetCurrencyInfoData()

               .Select(p => new PhotoSW.IMIX.Model.CurrencyInfo
               {
                   //Id = p.Id,

                   DG_Currency_pkey = p.PS_Currency_pkey,
                   DG_Currency_Name = p.PS_Currency_Name,
                   DG_Currency_Rate = p.PS_Currency_Rate,
                   DG_Currency_Symbol = p.PS_Currency_Symbol,
                   DG_Currency_UpdatedDate = p.PS_Currency_UpdatedDate,
                   DG_Currency_ModifiedBy = p.PS_Currency_ModifiedBy,
                   DG_Currency_Default = p.PS_Currency_Default,
                   DG_Currency_Icon = p.PS_Currency_Icon,
                   DG_Currency_Code = p.PS_Currency_Code,
                   DG_Currency_IsActive = p.PS_Currency_IsActive,
                   SyncCode = p.SyncCode,
                   IsSynced = p.IsSynced,

                   //IsActive = p.IsActive
               }).ToList();
           return obj;
           }
       catch
           {
           return new List<PhotoSW.IMIX.Model.CurrencyInfo>();
           }
       }
       public List<PhotoSW.IMIX.Model.CurrencyInfo> GetCurrencyListforconfig()
       {
       try
           {
           var obj = baCurrencyInfo.GetCurrencyInfoData()

               .Select(p => new PhotoSW.IMIX.Model.CurrencyInfo
               {
                   //Id = p.Id,

                   DG_Currency_pkey = p.PS_Currency_pkey,
                   DG_Currency_Name = p.PS_Currency_Name,
                   DG_Currency_Rate = p.PS_Currency_Rate,
                   DG_Currency_Symbol = p.PS_Currency_Symbol,
                   DG_Currency_UpdatedDate = p.PS_Currency_UpdatedDate,
                   DG_Currency_ModifiedBy = p.PS_Currency_ModifiedBy,
                   DG_Currency_Default = p.PS_Currency_Default,
                   DG_Currency_Icon = p.PS_Currency_Icon,
                   DG_Currency_Code = p.PS_Currency_Code,
                   DG_Currency_IsActive = p.PS_Currency_IsActive,
                   SyncCode = p.SyncCode,
                   IsSynced = p.IsSynced,

                   //IsActive = p.IsActive
               }).ToList();
           return obj;
           }
       catch
           {
           return new List<PhotoSW.IMIX.Model.CurrencyInfo>();
           }
       }
       public List<PhotoSW.IMIX.Model.CurrencyInfo> GetCurrencyOnly()
       {
       try
           {
           var obj = baCurrencyInfo.GetCurrencyInfoData()

               .Select(p => new PhotoSW.IMIX.Model.CurrencyInfo
               {
                   //Id = p.Id,

                   DG_Currency_pkey = p.PS_Currency_pkey,
                   DG_Currency_Name = p.PS_Currency_Name,
                   DG_Currency_Rate = p.PS_Currency_Rate,
                   DG_Currency_Symbol = p.PS_Currency_Symbol,
                   DG_Currency_UpdatedDate = p.PS_Currency_UpdatedDate,
                   DG_Currency_ModifiedBy = p.PS_Currency_ModifiedBy,
                   DG_Currency_Default = p.PS_Currency_Default,
                   DG_Currency_Icon = p.PS_Currency_Icon,
                   DG_Currency_Code = p.PS_Currency_Code,
                   DG_Currency_IsActive = p.PS_Currency_IsActive,
                   SyncCode = p.SyncCode,
                   IsSynced = p.IsSynced,

                   //IsActive = p.IsActive
               }).ToList();
           return obj;
           }
       catch
           {
           return new List<PhotoSW.IMIX.Model.CurrencyInfo>();
           }
       }
       public int GetDefaultCurrency()
       {
           //List<PhotoSW.IMIX.Model.CurrencyInfo> obj = new List<PhotoSW.IMIX.Model.CurrencyInfo>();
           return 0;
       }
       public string GetDefaultCurrencyName()
       {
           //List<PhotoSW.IMIX.Model.CurrencyInfo> obj = new List<PhotoSW.IMIX.Model.CurrencyInfo>();
           return "INR";
       }
       public void SetCurrencyDetails(
           string CurrencyName, float rate,
           string symbol, int id, int modifiedby,
           bool IsDefault, DateTime UpdateDate,
           string Icon, string Currencycode,
           string SyncCode)
       {
       }
    
    }
}
