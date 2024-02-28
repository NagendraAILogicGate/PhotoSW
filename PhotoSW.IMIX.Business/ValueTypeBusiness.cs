using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class ValueTypeBusiness
    {
        public List<PhotoSW.IMIX.Model.ValueTypeInfo> GetReasonType(int valueTypeGroupId)
        {
            try
                {
                var obj = baValueTypeInfo.GetValueTypeInfoData()
                    .Where(p=>p.ValueTypeGroupId == valueTypeGroupId)
                    .Select(p => new PhotoSW.IMIX.Model.ValueTypeInfo
                        {
                        ValueTypeId = p.ValueTypeId,
                        ValueTypeGroupId = p.ValueTypeGroupId,
                        Name = p.Name,
                        DisplayOrder = p.DisplayOrder,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedDate = p.ModifiedDate

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.ValueTypeInfo>();
                }
            // return new  List<PhotoSW.IMIX.Model.ValueTypeInfo>();
            }
        public List<PhotoSW.IMIX.Model.ValueTypeInfo> GetScanTypes()
        {
            try
                {
                var obj = baValueTypeInfo.GetValueTypeInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.ValueTypeInfo
                        {
                        ValueTypeId = p.ValueTypeId,
                        ValueTypeGroupId = p.ValueTypeGroupId,
                        Name = p.Name,
                        DisplayOrder = p.DisplayOrder,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedDate = p.ModifiedDate

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.ValueTypeInfo>();
                }

            //return new List<PhotoSW.IMIX.Model.ValueTypeInfo>();
            }
    }
}
