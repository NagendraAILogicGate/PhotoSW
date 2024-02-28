using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class CommonBusiness
    {
        public DataTable CopyGenericToDataTable<T>(IEnumerable<T> items) 
        {
            DataTable dt = new DataTable();
            return dt;
        }
        public List<PhotoSW.IMIX.Model.TableBaseInfo> GetAllTable()
        {
            try
                {
                var obj1 = baTableBaseInfo.GetTableBaseInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.TableBaseInfo
                        {
                        // Id = p.Id,
                        name = p.name,
                        //    IsActive = p.IsActive

                        }).ToList();
                return obj1;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.TableBaseInfo>();
                }
            //List<PhotoSW.IMIX.Model.TableBaseInfo> obj = new List<PhotoSW.IMIX.Model.TableBaseInfo>();
            //return obj;

            }
        public Dictionary<string, int> GetCardCodeTypes()
        {
            Dictionary<string, int> obj = new Dictionary<string, int>();
            return obj;
        }
        public bool ImportMasterData(DataTable dtSite, DataTable dtItem, DataTable dtpkg)
        {
            return false;
        
        }
    }
}
