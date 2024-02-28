using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class GraphicsBusiness
    {
        public bool DeleteGraphics(int id)
        {
            return false;
        }
        public List<PhotoSW.IMIX.Model.GraphicsInfo> GetGraphicsDetails()
        {
            try
                {
                var obj = baGraphicsInfo.GetGraphicsInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.GraphicsInfo()
                        {
                        DG_Graphics_pkey = p.PS_Graphics_pkey,
                        DG_Graphics_Name = p.PS_Graphics_Name,
                        DG_Graphics_Displayname = p.PS_Graphics_Displayname,
                        DG_Graphics_IsActive = p.PS_Graphics_IsActive,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedDate = p.ModifiedDate
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.GraphicsInfo>();
                }
            // return new List<PhotoSW.IMIX.Model.GraphicsInfo>();
            }
        public void SetGraphicsDetails(string graphicsname, string graphicsdisplayname, bool isactive, string SyncCode, int userId)
        {
        }
        public void UpdateGraphicsDetails(string graphicsname, string graphicsdisplayname,
            bool isactive, string SyncCode, int graphicsId, int userId)
        {
        }
 
    }
}
