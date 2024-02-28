using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class SoftwareHealthCheckBusiness //: BaseBusiness
    {

        public List<PhotoSW.IMIX.Model.ServicesInfo> GetRunningServices()
        {
            try
                {
                var obj = baServicesInfo.GetServicesInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.ServicesInfo
                        {
                        DG_Service_Id = p.PS_Service_Id,
                        DG_Sevice_Name = p.PS_Sevice_Name,
                        DG_Service_Display_Name = p.PS_Service_Display_Name,
                        DG_Service_Path = p.PS_Service_Path,
                        IsInterface = p.IsInterface,
                        RunLevel = p.RunLevel,
                        IsService = p.IsService

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<Model.ServicesInfo>();
                }
            // return new List<Model.ServicesInfo>();
            }
        public List<PhotoSW.IMIX.Model.VersionHistoryInfo> GetVersionDetails(string MachineName)
        {
            try
                {
                var obj = baVersionHistoryInfo.GetVersionHistoryInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.VersionHistoryInfo
                        {
                        DG_Version_Pkey = p.PS_Version_Pkey,
                        DG_Version_Number = p.PS_Version_Number,
                        DG_Version_Date = p.PS_Version_Date,
                        DG_UpdatedBY = p.PS_UpdatedBY,
                        DG_Machine = p.PS_Machine,

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<Model.VersionHistoryInfo>();
                }
            // return new List<Model.VersionHistoryInfo>();
            }
    }
}
