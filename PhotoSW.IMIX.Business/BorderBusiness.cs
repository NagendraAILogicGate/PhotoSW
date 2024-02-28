using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.BAL;

namespace PhotoSW.IMIX.Business
{
    public class BorderBusiness
    {
        public bool DeleteBorder(int borderId)
        {
            return false;
        }
        public List<PhotoSW.IMIX.Model.BorderInfo> GetBorderDetails()
        {
            try
            {
                var obj = baBorderInfo.GetBorderInfoInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.BorderInfo
                    {
                        //Id = p.Id,
                        DG_Borders_pkey = p.PS_Borders_pkey,
                        DG_Border = p.PS_Border,
                        DG_ProductTypeID = p.PS_ProductTypeID,
                        DG_IsActive = p.PS_IsActive,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_Orders_ProductType_pkey = p.PS_Orders_ProductType_pkey,
                        DG_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        FilePath = p.FilePath,
                        CreatedBy = p.CreatedBy,
                        ModifiedBy = p.ModifiedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedDate = p.ModifiedDate,
                        //IsActive = p.IsActive
                    }).ToList();
                return obj;
            }
            catch
            {
                return new List<Model.BorderInfo>();
            }
            //return new List<Model.BorderInfo>();
        }
        public PhotoSW.IMIX.Model.BorderInfo GetBorderNameFromID(int Id)
        {
            try
            {
                var obj = baBorderInfo.GetBorderInfoInfoData()
                    .Where(p => p.Id == Id)
                    .Select(p => new PhotoSW.IMIX.Model.BorderInfo
                    {
                        //Id = p.Id,
                        DG_Borders_pkey =(int)p.Id,
                        DG_Border = p.PS_Border,
                        DG_ProductTypeID = p.PS_ProductTypeID,
                        DG_IsActive = p.PS_IsActive,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        DG_Orders_ProductType_pkey = p.PS_Orders_ProductType_pkey,
                        DG_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        FilePath = p.FilePath,
                        CreatedBy = p.CreatedBy,
                        ModifiedBy = p.ModifiedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedDate = p.ModifiedDate,
                        //IsActive = p.IsActive
                    }).FirstOrDefault();
                return obj;
            }
            catch
            {
                return new Model.BorderInfo();
            }
        }
        public List<PhotoSW.IMIX.Model.VideoOverlay> GetVideoOverlays()
        {
            return new List<PhotoSW.IMIX.Model.VideoOverlay>();
        }
        public void SetBorderDetails(string Bordername, int productType,
            bool isactive, int borderid, string SyncCode, int userId)
        {
        }

    }
}
