using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.BAL;
using PhotoSW.IMIX.Model;
namespace PhotoSW.IMIX.Business
{
    public class SemiOrderBusiness
    {
        public bool DeleteSpecSetting(int id)
        {
            return false;
        }
        public List<PhotoSW.IMIX.Model.SemiOrderSettings> GetLstSemiOrderSettings(int? substoreId)
        {
           // List<PhotoSW.IMIX.Model.SemiOrderSettings> obj = new List<PhotoSW.IMIX.Model.SemiOrderSettings>();
            try
            {
                return baSemiOrderSetting.GetSemiOrderSettingData()
                    .Where(p => p.PS_SubStoreId == substoreId)
                    .Select(p => new PhotoSW.IMIX.Model.SemiOrderSettings
                    {
                       // Id = p.Id,
                       
                        PS_SemiOrder_Settings_Pkey = p.PS_SemiOrder_Settings_Pkey,
                        PS_SemiOrder_Settings_AutoBright = p.PS_SemiOrder_Settings_AutoBright,
                        PS_SemiOrder_Settings_AutoBright_Value = p.PS_SemiOrder_Settings_AutoBright_Value,
                        PS_SemiOrder_Settings_AutoContrast = p.PS_SemiOrder_Settings_AutoContrast,
                        PS_SemiOrder_Settings_AutoContrast_Value = p.PS_SemiOrder_Settings_AutoContrast_Value,
                        PS_SemiOrder_Settings_ImageFrame = p.PS_SemiOrder_Settings_ImageFrame,
                        PS_SemiOrder_Settings_IsImageFrame = p.PS_SemiOrder_Settings_IsImageFrame,
                        PS_SemiOrder_ProductTypeId = p.PS_SemiOrder_ProductTypeId,
                        PS_SemiOrder_Settings_ImageFrame_Vertical = p.PS_SemiOrder_Settings_ImageFrame_Vertical,
                        PS_SemiOrder_Environment = p.PS_SemiOrder_Environment,
                        PS_SemiOrder_BG = p.PS_SemiOrder_BG,
                        PS_SemiOrder_Settings_IsImageBG = p.PS_SemiOrder_Settings_IsImageBG,
                        PS_SemiOrder_Graphics_layer = p.PS_SemiOrder_Graphics_layer,
                        PS_SemiOrder_Image_ZoomInfo = p.PS_SemiOrder_Image_ZoomInfo,
                        PS_SubStoreId = p.PS_SubStoreId,
                        PS_SemiOrder_IsPrintActive = p.PS_SemiOrder_IsPrintActive,
                        PS_SemiOrder_IsCropActive = p.PS_SemiOrder_IsCropActive,
                        VerticalCropValues = p.VerticalCropValues,
                        HorizontalCropValues = p.HorizontalCropValues,
                        PS_LocationId = p.PS_LocationId,
                        ChromaColor = p.ChromaColor,
                        ColorCode = p.ColorCode,
                        ClrTolerance = p.ClrTolerance,
                        ProductName = p.ProductName,
                        TextLogos = p.TextLogos
                    }) .ToList();
            }
            catch 
            {
                return null;
            }
            
           
        }
        public List<PhotoSW.IMIX.Model.SpecProfileProductMappingInfo> GetSemiOrderProfileProductMapping(int ProfileId)
        {
            try
            {
              return   baSpecProfileProductMappingInfo.GetSpecProfileProductMappingInfoData()
                    .Where(p => p.SemiOrderProfileId == ProfileId)
                    .Select(p => new SpecProfileProductMappingInfo
                    {
                     
                        SemiOrderProfileId = p.SemiOrderProfileId,
                        ProductTypeId = p.ProductTypeId,
                      
                    }).ToList();
            }
            catch (Exception)
            {

                return null; 
            }
        }
        public List<PhotoSW.IMIX.Model.SemiOrderSettings> GetSemiOrderSetting(int? substoreId, int locationId)
        {
            try
            {
                return baSemiOrderSetting.GetSemiOrderSettingData()
                    .Where(p => p.PS_SubStoreId == substoreId && p.PS_LocationId == locationId)
                    .Select(p => new PhotoSW.IMIX.Model.SemiOrderSettings
                    {
                        // Id = p.Id,

                        PS_SemiOrder_Settings_Pkey = p.PS_SemiOrder_Settings_Pkey,
                        PS_SemiOrder_Settings_AutoBright = p.PS_SemiOrder_Settings_AutoBright,
                        PS_SemiOrder_Settings_AutoBright_Value = p.PS_SemiOrder_Settings_AutoBright_Value,
                        PS_SemiOrder_Settings_AutoContrast = p.PS_SemiOrder_Settings_AutoContrast,
                        PS_SemiOrder_Settings_AutoContrast_Value = p.PS_SemiOrder_Settings_AutoContrast_Value,
                        PS_SemiOrder_Settings_ImageFrame = p.PS_SemiOrder_Settings_ImageFrame,
                        PS_SemiOrder_Settings_IsImageFrame = p.PS_SemiOrder_Settings_IsImageFrame,
                        PS_SemiOrder_ProductTypeId = p.PS_SemiOrder_ProductTypeId,
                        PS_SemiOrder_Settings_ImageFrame_Vertical = p.PS_SemiOrder_Settings_ImageFrame_Vertical,
                        PS_SemiOrder_Environment = p.PS_SemiOrder_Environment,
                        PS_SemiOrder_BG = p.PS_SemiOrder_BG,
                        PS_SemiOrder_Settings_IsImageBG = p.PS_SemiOrder_Settings_IsImageBG,
                        PS_SemiOrder_Graphics_layer = p.PS_SemiOrder_Graphics_layer,
                        PS_SemiOrder_Image_ZoomInfo = p.PS_SemiOrder_Image_ZoomInfo,
                        PS_SubStoreId = p.PS_SubStoreId,
                        PS_SemiOrder_IsPrintActive = p.PS_SemiOrder_IsPrintActive,
                        PS_SemiOrder_IsCropActive = p.PS_SemiOrder_IsCropActive,
                        VerticalCropValues = p.VerticalCropValues,
                        HorizontalCropValues = p.HorizontalCropValues,
                        PS_LocationId = p.PS_LocationId,
                        ChromaColor = p.ChromaColor,
                        ColorCode = p.ColorCode,
                        ClrTolerance = p.ClrTolerance,
                        ProductName = p.ProductName,
                        TextLogos = p.TextLogos
                    }).ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<PhotoSW.IMIX.Model.SemiOrderSettingsInfo> GetSemiOrderSettings()
        {
            try
            {
                var obj = baSemiOrderSettingsInfo.GetSemiOrderSettingsInfoData()
                    .Where(p => p.IsActive == true)
                    .Select(p => new PhotoSW.IMIX.Model.SemiOrderSettingsInfo
                    {
                        // Id = p.Id,

                        IsBrightActive = p.IsBrightActive,
                        BrightValue = p.BrightValue,
                        IsContrastActive = p.IsContrastActive,
                        ContrastValue = p.ContrastValue,
                        BorderName = p.BorderName,
                        IsBorderActive = p.IsBorderActive,
                        ProductTypeId = p.ProductTypeId,
                        VerticalBorderName = p.VerticalBorderName,
                        IsGreenScreenActive = p.IsGreenScreenActive,
                        BackgroundName = p.BackgroundName,
                        IsChromaActive = p.IsChromaActive,
                        GraphicsLayer = p.GraphicsLayer,
                        ZoomInfo = p.ZoomInfo,
                        SubstoreId = p.SubstoreId,
                        IsPrintActive = p.IsPrintActive,
                        IsCropActive = p.IsCropActive,
                        VerticalCropValues = p.VerticalCropValues,
                        HorizontalCropValues = p.HorizontalCropValues,
                        LocationId = p.LocationId,
                        ChromaColor = p.ChromaColor,
                        ColorCode = p.ColorCode,
                        ClrTolerance = p.ClrTolerance,
                        Environment = p.Environment,
                    }).ToList();
                return obj;
            }
            catch
            {
                return null;
            }
        }
        public List<PhotoSW.IMIX.Model.SemiOrderSettings> GetSemiOrderSettings(int? substoreId, int locationId)
        {
            try
            {
                return baSemiOrderSetting.GetSemiOrderSettingData()
                    .Where(p => p.PS_SubStoreId == substoreId && p.PS_LocationId==locationId)
                    .Select(p => new PhotoSW.IMIX.Model.SemiOrderSettings
                    {
                        // Id = p.Id,

                        PS_SemiOrder_Settings_Pkey = p.PS_SemiOrder_Settings_Pkey,
                        PS_SemiOrder_Settings_AutoBright = p.PS_SemiOrder_Settings_AutoBright,
                        PS_SemiOrder_Settings_AutoBright_Value = p.PS_SemiOrder_Settings_AutoBright_Value,
                        PS_SemiOrder_Settings_AutoContrast = p.PS_SemiOrder_Settings_AutoContrast,
                        PS_SemiOrder_Settings_AutoContrast_Value = p.PS_SemiOrder_Settings_AutoContrast_Value,
                        PS_SemiOrder_Settings_ImageFrame = p.PS_SemiOrder_Settings_ImageFrame,
                        PS_SemiOrder_Settings_IsImageFrame = p.PS_SemiOrder_Settings_IsImageFrame,
                        PS_SemiOrder_ProductTypeId = p.PS_SemiOrder_ProductTypeId,
                        PS_SemiOrder_Settings_ImageFrame_Vertical = p.PS_SemiOrder_Settings_ImageFrame_Vertical,
                        PS_SemiOrder_Environment = p.PS_SemiOrder_Environment,
                        PS_SemiOrder_BG = p.PS_SemiOrder_BG,
                        PS_SemiOrder_Settings_IsImageBG = p.PS_SemiOrder_Settings_IsImageBG,
                        PS_SemiOrder_Graphics_layer = p.PS_SemiOrder_Graphics_layer,
                        PS_SemiOrder_Image_ZoomInfo = p.PS_SemiOrder_Image_ZoomInfo,
                        PS_SubStoreId = p.PS_SubStoreId,
                        PS_SemiOrder_IsPrintActive = p.PS_SemiOrder_IsPrintActive,
                        PS_SemiOrder_IsCropActive = p.PS_SemiOrder_IsCropActive,
                        VerticalCropValues = p.VerticalCropValues,
                        HorizontalCropValues = p.HorizontalCropValues,
                        PS_LocationId = p.PS_LocationId,
                        ChromaColor = p.ChromaColor,
                        ColorCode = p.ColorCode,
                        ClrTolerance = p.ClrTolerance,
                        ProductName = p.ProductName,
                        TextLogos = p.TextLogos
                    }).ToList();
            }
            catch
            {
                return null;
            }
        }
        public bool IsSemiOrderImage(int OrderDetailsID)
        {
            try
            {
                var obj= baSemiOrderSetting.GetSemiOrderSettingData()
                    .Where(p => p.PS_SemiOrder_Settings_Pkey == OrderDetailsID)
                   .FirstOrDefault().PS_SemiOrder_Settings_IsImageFrame;
                return Convert.ToBoolean(obj);
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
