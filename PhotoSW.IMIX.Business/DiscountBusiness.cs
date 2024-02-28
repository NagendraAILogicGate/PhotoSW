using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
   public class DiscountBusiness
    {
       public bool DeleteDiscount(int id) { return false; }
       public List<PhotoSW.IMIX.Model.DiscountTypeInfo> GetDiscountDetails() 
       {
           return new List<PhotoSW.IMIX.Model.DiscountTypeInfo>();
       }
       public string GetDiscountDetailsFromID(int id)
       {
           return "";
       }
       public List<PhotoSW.IMIX.Model.DiscountTypeInfo> GetDiscountType()
       {
            try
                {
                var obj = baDiscountTypeInfo.GetDiscountTypeInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.DiscountTypeInfo()
                        {
                        DG_Orders_DiscountType_Pkey = p.PS_Orders_DiscountType_Pkey,
                        DG_Orders_DiscountType_Name = p.PS_Orders_DiscountType_Name,
                        DG_Orders_DiscountType_Desc = p.PS_Orders_DiscountType_Desc,
                        DG_Orders_DiscountType_Active = p.PS_Orders_DiscountType_Active,
                        DG_Orders_DiscountType_Secure = p.PS_Orders_DiscountType_Secure,
                        DG_Orders_DiscountType_ItemLevel = p.PS_Orders_DiscountType_ItemLevel,
                        DG_Orders_DiscountType_AsPercentage = p.PS_Orders_DiscountType_AsPercentage,
                        DG_Orders_DiscountType_Code = p.PS_Orders_DiscountType_Code,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.DiscountTypeInfo>();
                }
            // return new List<PhotoSW.IMIX.Model.DiscountTypeInfo>();
            }
       public void SetDiscountDetails(string DiscountName, string DiscountDesc,
           bool isactive, bool issecure, bool isitemlevel,
           bool isaspercentage, string Discountcode,
           string SyncCode)
       {
       }
   
    }
}
