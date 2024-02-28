using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class PrinterTypeBusiness //: BaseBusiness
    {
        public bool DeleteAssociatedPrinters(int SubstoreId)
        {
            return false;
        }
        public bool DeletePrinterType(int PrinterTypeId)
        {
            bool result = baPrinterTypeInfo.Delete(PrinterTypeId);

            return result;
        }
        public List<PhotoSW.IMIX.Model.PrinterTypeInfo> GetPrinterTypeList(int PrinterTypeId)
            {
            try
                {
                var obj = baPrinterTypeInfo.GetPrinterTypeInfoInfoData()
                    .Where(p => p.PrinterTypeID == PrinterTypeId)
                    .Select(p => new PhotoSW.IMIX.Model.PrinterTypeInfo()
                        {
                        PrinterTypeID = p.PrinterTypeID,
                        PrinterType = p.PrinterType,
                        ProductTypeID = p.ProductTypeID,
                        ProductName = p.ProductName,
                        IsActive = p.IsActive
                        }).ToList();


                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.PrinterTypeInfo>();
                }
            }
        public List<PhotoSW.IMIX.Model.PrinterTypeInfo> GetPrinterTypeList (  )
            {
            try
                {
                //var obj = baPrinterTypeInfo.GetPrinterTypeInfoInfoData()
                //    .Where(p => p.PrinterTypeID == PrinterTypeId)
                //    .Select(p => new PhotoSW.IMIX.Model.PrinterTypeInfo()
                //        {
                //        PrinterTypeID = p.PrinterTypeID,
                //        PrinterType = p.PrinterType,
                //        ProductTypeID = p.ProductTypeID,
                //        ProductName = p.ProductName
                //        }).ToList();

                var obj = baPrinterTypeInfo.GetPrinterTypeInfoInfoData()
                  .Where(p => p.IsActive == true)
                  .Select(p => new PhotoSW.IMIX.Model.PrinterTypeInfo()
                      {
                      PrinterTypeID = p.PrinterTypeID,
                      PrinterType = p.PrinterType,
                      ProductTypeID = p.ProductTypeID,
                      ProductName = p.ProductName,
                      IsActive = p.IsActive
                      }).ToList();

                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.PrinterTypeInfo>();
                }
            //return new List<PhotoSW.IMIX.Model.PrinterTypeInfo>();
            }
        public bool RemapNewPrinter(string PrinterName, int SubstoreId, bool active)
        {
            return true;
        }
        public bool SaveOrActivateNewPrinter(string PrinterName, int SubstoreId, bool active)
        {
            return true;
        }
        public bool SavePrinterType(PhotoSW.IMIX.Model.PrinterTypeInfo lstPrinterInfo)
        {
            int id = lstPrinterInfo.PrinterTypeID;
            if(id == 0)
                {
                baPrinterTypeInfo obj = new baPrinterTypeInfo();

                obj.PrinterType = lstPrinterInfo.PrinterType;
                obj.PrinterTypeID = lstPrinterInfo.PrinterTypeID;
                obj.ProductName = lstPrinterInfo.ProductName;
                obj.ProductTypeID = lstPrinterInfo.ProductTypeID;
                obj.IsActive = lstPrinterInfo.IsActive;

                baPrinterTypeInfo.Insert(obj);
                }
            else
                {
                baPrinterTypeInfo obj = new baPrinterTypeInfo();
              
                obj.PrinterType = lstPrinterInfo.PrinterType;
                obj.PrinterTypeID = lstPrinterInfo.PrinterTypeID;
                obj.ProductName = lstPrinterInfo.ProductName;
                obj.ProductTypeID = lstPrinterInfo.ProductTypeID;
                obj.IsActive = lstPrinterInfo.IsActive;

                baPrinterTypeInfo.Update(obj);

                }
            
            return true;
        }
    }
}
