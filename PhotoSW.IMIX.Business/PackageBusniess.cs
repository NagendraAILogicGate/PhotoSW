using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class PackageBusniess
    {
        public string GetChildProductType(int parentid)
        {
            return "";
        }
        public string GetChildProductTypeQuantity(int Child, int parentId)
        {
            return "";
        }
        public int GetMaxQuantityofIteminaPackage(int pkgId, int productTypeId)
        {
            return 0;
        }
        public bool SetPackageDetails(int packageId, int ProductTypeId, int? PackageQuantity, int? PackageMaxQuanity, int? VideoLength)
        {
            return false;
        }
        public bool SetPackageMasterDetails(int packageId, string packageName, string Packageprice)
        {
            return false;
        }
    }
}
