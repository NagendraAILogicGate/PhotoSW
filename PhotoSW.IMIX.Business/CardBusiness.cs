using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;
using PhotoSW.CF.DataLayer.BAL;

namespace PhotoSW.IMIX.Business
{
    public class CardBusiness
    {
        public Dictionary<string, int> GetCardCodeTypes()
        {
            Dictionary<string, int> obj = new Dictionary<string, int>();
            obj.Add("Test1", 1);
            obj.Add("Test2", 2);
            obj.Add("Test3", 3);
            obj.Add("Test4", 4);
            return obj;
        }
        public string GetCardCode(int ImageIdentificationType)
        {
           // throw new NotImplementedException();
            try
            {
                List < baImageCardTypeInfo> List= new List < baImageCardTypeInfo>();
                List = baImageCardTypeInfo.GetImageCardTypeInfoData();
                return  List==null ?null :  List.Where(p => p.ImageIdentificationType == ImageIdentificationType)?.FirstOrDefault()?.CardIdentificationDigit;
                //return  baImageCardTypeInfo.GetImageCardTypeInfoData().
                //    Where(p => p.ImageIdentificationType == ImageIdentificationType)?.FirstOrDefault()?.CardIdentificationDigit;
            }
            catch
            {
                return "";
            }
        }

        public bool ChangeCardStatus(int cardId)
        {
            return false;
        }
      
        public int GetCardImageLimit(string code)
        {
            return 0;
        }
        public int GetCardImageSold(string code)
        {
            return 0;
        }
        public List<PhotoSW.IMIX.Model.iMixImageCardTypeInfo> GetCardTypeList()
        {
            try
                {
                var obj = baiMixImageCardTypeInfo.GetiMixImageCardTypeInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.iMixImageCardTypeInfo
                        {
                       // Id = p.Id,
                        IMIXImageCardTypeId = p.IMIXImageCardTypeId,
                        Name = p.Name,
                        CardIdentificationDigit = p.CardIdentificationDigit,
                        ImageIdentificationType = p.ImageIdentificationType,
                        MaxImages = p.MaxImages,
                        Description = p.Description,
                        CreatedOn = p.CreatedOn,
                        IsWaterMark = p.IsWaterMark,
                        IsPrepaid = p.IsPrepaid,
                        PackageId = p.PackageId,
                        IsActive = p.IsActive

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.iMixImageCardTypeInfo>();
                }
            // return new List<PhotoSW.IMIX.Model.iMixImageCardTypeInfo>();
            }
        public PhotoSW.IMIX.Model.iMixImageCardTypeInfo GetCardTypeList(int ID)
        {
            try
                {
                var obj = baiMixImageCardTypeInfo.GetiMixImageCardTypeInfoData()
                    .Where(p=>p.Id == ID)
                    .Select(p => new PhotoSW.IMIX.Model.iMixImageCardTypeInfo
                        {
                        // Id = p.Id,
                        IMIXImageCardTypeId = p.IMIXImageCardTypeId,
                        Name = p.Name,
                        CardIdentificationDigit = p.CardIdentificationDigit,
                        ImageIdentificationType = p.ImageIdentificationType,
                        MaxImages = p.MaxImages,
                        Description = p.Description,
                        CreatedOn = p.CreatedOn,
                        IsWaterMark = p.IsWaterMark,
                        IsPrepaid = p.IsPrepaid,
                        PackageId = p.PackageId,
                        IsActive = p.IsActive

                        }).FirstOrDefault();
                return obj;
                }
            catch
                {
                return new PhotoSW.IMIX.Model.iMixImageCardTypeInfo();
                }
            //  return new  PhotoSW.IMIX.Model.iMixImageCardTypeInfo();
            }
        public List<PhotoSW.IMIX.Model.ImageCardTypeInfo> GetCardTypeListview()
        {
            try
                {
                var obj = baImageCardTypeInfo.GetImageCardTypeInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.ImageCardTypeInfo
                        {
                      //  Id = p.Id,
                        IMIXImageCardTypeId = p.IMIXImageCardTypeId,
                        Name = p.Name,
                        CardIdentificationDigit = p.CardIdentificationDigit,
                        ImageIdentificationType = p.ImageIdentificationType,
                        IsWaterMark = p.IsWaterMark,
                        MaxImages = p.MaxImages,
                        Description = p.Description,
                        CreatedOn = p.CreatedOn,
                        IsPrepaid = p.IsPrepaid,
                        PackageId = p.PackageId,
                        Status = p.Status,
                        ImageIdentificationTypeName = p.ImageIdentificationTypeName,
                      //  IsActive = p.IsActive

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.ImageCardTypeInfo>();
                }
            // return new List<PhotoSW.IMIX.Model.ImageCardTypeInfo>();
            }
        public List<PhotoSW.IMIX.Model.ValueTypeInfo> GetCardTypes()
        {
            try
                {
                var obj = baValueTypeInfo.GetValueTypeInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.ValueTypeInfo
                        {
                      //  Id = p.Id,
                        ValueTypeId = p.ValueTypeId,
                        ValueTypeGroupId = p.ValueTypeGroupId,
                        Name = p.Name,
                        DisplayOrder = p.DisplayOrder,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedDate = p.ModifiedDate,
                     //   IsActive = p.IsActive

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.ValueTypeInfo>();
                }
            // return new List<PhotoSW.IMIX.Model.ValueTypeInfo>();
            }
        public bool IsCardSeriesExits(string series)
        {
            return false;
        }
        public bool IsValidCodeType(string QRCode, int CardTypeId)
        {
            return false;
        }
        public bool IsValidPrepaidCodeType(string QRCode, int CardTypeId)
        {
            return false;
        }
        public bool SetCardTypeInfo(int cardId, string strCardTypeName, string strCardSeries,
            int strcodeType, bool? status, int maxImage, string strDescription, bool IsPrepaid, int PackageId, bool IsWaterMark)
        {
            return false;
        }
    
    }
}
