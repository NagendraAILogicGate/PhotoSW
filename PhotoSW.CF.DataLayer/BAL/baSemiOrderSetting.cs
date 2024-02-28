using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
{
    public class baSemiOrderSetting
    {
        public int Id { get; set; }
        public int PS_SemiOrder_Settings_Pkey { get; set; }
        public bool? PS_SemiOrder_Settings_AutoBright { get; set; }
        public double? PS_SemiOrder_Settings_AutoBright_Value { get; set; }
        public bool? PS_SemiOrder_Settings_AutoContrast { get; set; }
        public double? PS_SemiOrder_Settings_AutoContrast_Value { get; set; }
        public string PS_SemiOrder_Settings_ImageFrame { get; set; }
        public bool? PS_SemiOrder_Settings_IsImageFrame { get; set; }
        public string PS_SemiOrder_ProductTypeId { get; set; }
        public string PS_SemiOrder_Settings_ImageFrame_Vertical { get; set; }
        public bool? PS_SemiOrder_Environment { get; set; }
        public string PS_SemiOrder_BG { get; set; }
        public bool? PS_SemiOrder_Settings_IsImageBG { get; set; }
        public string PS_SemiOrder_Graphics_layer { get; set; }
        public string PS_SemiOrder_Image_ZoomInfo { get; set; }
        public int? PS_SubStoreId { get; set; }
        public bool? PS_SemiOrder_IsPrintActive { get; set; }
        public bool? PS_SemiOrder_IsCropActive { get; set; }
        public string VerticalCropValues { get; set; }
        public string HorizontalCropValues { get; set; }
        public int? PS_LocationId { get; set; }
        public string ChromaColor { get; set; }
        public string ColorCode { get; set; }
        public string ClrTolerance { get; set; }
        public string ProductName { get; set; }
        public string TextLogos { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<semiordersetting> lst_semiordersetting = new List<semiordersetting>();
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    //foreach (var item in lst_str)
                    //{
                    semiordersetting semiordersetting = new semiordersetting();

                        semiordersetting.Id = 1;
                        semiordersetting.PS_SemiOrder_Settings_Pkey =1;
                        semiordersetting.PS_SemiOrder_Settings_AutoBright =true;
                        semiordersetting.PS_SemiOrder_Settings_AutoBright_Value =1;
                        semiordersetting.PS_SemiOrder_Settings_AutoContrast =true;
                        semiordersetting.PS_SemiOrder_Settings_AutoContrast_Value =1;
                        semiordersetting.PS_SemiOrder_Settings_ImageFrame ="test";
                        semiordersetting.PS_SemiOrder_Settings_IsImageFrame =true;
                        semiordersetting.PS_SemiOrder_ProductTypeId ="prdid";
                        semiordersetting.PS_SemiOrder_Settings_ImageFrame_Vertical ="Test";
                        semiordersetting.PS_SemiOrder_Environment =true;
                        semiordersetting.PS_SemiOrder_BG ="black";
                        semiordersetting.PS_SemiOrder_Settings_IsImageBG =true;
                        semiordersetting.PS_SemiOrder_Graphics_layer ="";
                        semiordersetting.PS_SemiOrder_Image_ZoomInfo ="";
                        semiordersetting.PS_SubStoreId =3;
                        semiordersetting.PS_SemiOrder_IsPrintActive =true;
                        semiordersetting.PS_SemiOrder_IsCropActive =true;
                        semiordersetting.VerticalCropValues ="123";
                        semiordersetting.HorizontalCropValues= "123";
                        semiordersetting.PS_LocationId =1;
                        semiordersetting.ChromaColor ="Blue";
                        semiordersetting.ColorCode ="#000000";
                        semiordersetting.ClrTolerance ="";
                        semiordersetting.ProductName ="Test";
                        semiordersetting.TextLogos ="Test";
                        semiordersetting.IsActive = true;
                    // }
                    var Id = lst_semiordersetting.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.SemiOrderSettings.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.SemiOrderSettings.AddRange(lst_semiordersetting);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.SemiOrderSettings.AddRange(lst_semiordersetting);
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static baSemiOrderSetting GetSemiOrderSettingDataById(int Id)
        {
            try
            {

                semiordersetting semiordersetting = new semiordersetting();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SemiOrderSettings.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baSemiOrderSetting
                    {
                        Id = p.Id,
                        PS_SemiOrder_Settings_Pkey =p.PS_SemiOrder_Settings_Pkey,
                        PS_SemiOrder_Settings_AutoBright =p.PS_SemiOrder_Settings_AutoBright,
                        PS_SemiOrder_Settings_AutoBright_Value =p.PS_SemiOrder_Settings_AutoBright_Value,
                        PS_SemiOrder_Settings_AutoContrast =p.PS_SemiOrder_Settings_AutoContrast,
                        PS_SemiOrder_Settings_AutoContrast_Value =p.PS_SemiOrder_Settings_AutoContrast_Value,
                        PS_SemiOrder_Settings_ImageFrame =p.PS_SemiOrder_Settings_ImageFrame,
                        PS_SemiOrder_Settings_IsImageFrame =p.PS_SemiOrder_Settings_IsImageFrame,
                        PS_SemiOrder_ProductTypeId =p.PS_SemiOrder_ProductTypeId,
                        PS_SemiOrder_Settings_ImageFrame_Vertical =p.PS_SemiOrder_Settings_ImageFrame_Vertical,
                        PS_SemiOrder_Environment =p.PS_SemiOrder_Environment,
                        PS_SemiOrder_BG =p.PS_SemiOrder_BG,
                        PS_SemiOrder_Settings_IsImageBG =p.PS_SemiOrder_Settings_IsImageBG,
                        PS_SemiOrder_Graphics_layer =p.PS_SemiOrder_Graphics_layer,
                        PS_SemiOrder_Image_ZoomInfo =p.PS_SemiOrder_Image_ZoomInfo,
                        PS_SubStoreId =p.PS_SubStoreId,
                        PS_SemiOrder_IsPrintActive =p.PS_SemiOrder_IsPrintActive,
                        PS_SemiOrder_IsCropActive =p.PS_SemiOrder_IsCropActive,
                        VerticalCropValues =p.VerticalCropValues,
                        HorizontalCropValues =p.HorizontalCropValues,
                        PS_LocationId =p.PS_LocationId,
                        ChromaColor =p.ChromaColor,
                        ColorCode =p.ColorCode,
                        ClrTolerance =p.ClrTolerance,
                        ProductName =p.ProductName,
                        TextLogos =p.TextLogos,
                        IsActive = p.IsActive

                    }).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }
        public static List<baSemiOrderSetting> GetSemiOrderSettingData()
        {
            try
            {

                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SemiOrderSettings.Where(p => p.IsActive == true).Select(p => new baSemiOrderSetting
                    {
                        Id = p.Id,
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
                        TextLogos = p.TextLogos,
                        IsActive = p.IsActive

                    }).ToList();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }

        public static bool Insert ( baSemiOrderSetting baSemiOrderSetting )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    semiordersetting semiordersetting = new semiordersetting();

                    semiordersetting.Id = semiordersetting.Id;
                    semiordersetting.PS_SemiOrder_Settings_Pkey = semiordersetting.PS_SemiOrder_Settings_Pkey;
                    semiordersetting.PS_SemiOrder_Settings_AutoBright = semiordersetting.PS_SemiOrder_Settings_AutoBright;
                    semiordersetting.PS_SemiOrder_Settings_AutoBright_Value = semiordersetting.PS_SemiOrder_Settings_AutoBright_Value;
                    semiordersetting.PS_SemiOrder_Settings_AutoContrast = semiordersetting.PS_SemiOrder_Settings_AutoContrast;
                    semiordersetting.PS_SemiOrder_Settings_AutoContrast_Value = semiordersetting.PS_SemiOrder_Settings_AutoContrast_Value;
                    semiordersetting.PS_SemiOrder_Settings_ImageFrame = semiordersetting.PS_SemiOrder_Settings_ImageFrame;
                    semiordersetting.PS_SemiOrder_Settings_IsImageFrame = semiordersetting.PS_SemiOrder_Settings_IsImageFrame;
                    semiordersetting.PS_SemiOrder_ProductTypeId = semiordersetting.PS_SemiOrder_ProductTypeId;
                    semiordersetting.PS_SemiOrder_Settings_ImageFrame_Vertical = semiordersetting.PS_SemiOrder_Settings_ImageFrame_Vertical;
                    semiordersetting.PS_SemiOrder_Environment = semiordersetting.PS_SemiOrder_Environment;
                    semiordersetting.PS_SemiOrder_BG = semiordersetting.PS_SemiOrder_BG;
                    semiordersetting.PS_SemiOrder_Settings_IsImageBG = semiordersetting.PS_SemiOrder_Settings_IsImageBG;
                    semiordersetting.PS_SemiOrder_Graphics_layer = semiordersetting.PS_SemiOrder_Graphics_layer;
                    semiordersetting.PS_SemiOrder_Image_ZoomInfo = semiordersetting.PS_SemiOrder_Image_ZoomInfo;
                    semiordersetting.PS_SubStoreId = semiordersetting.PS_SubStoreId;
                    semiordersetting.PS_SemiOrder_IsPrintActive = semiordersetting.PS_SemiOrder_IsPrintActive;
                    semiordersetting.PS_SemiOrder_IsCropActive = semiordersetting.PS_SemiOrder_IsCropActive;
                    semiordersetting.VerticalCropValues = semiordersetting.VerticalCropValues;
                    semiordersetting.HorizontalCropValues = semiordersetting.HorizontalCropValues;
                    semiordersetting.PS_LocationId = semiordersetting.PS_LocationId;
                    semiordersetting.ChromaColor = semiordersetting.ChromaColor;
                    semiordersetting.ColorCode = semiordersetting.ColorCode;
                    semiordersetting.ClrTolerance = semiordersetting.ClrTolerance;
                    semiordersetting.ProductName = semiordersetting.ProductName;
                    semiordersetting.TextLogos = semiordersetting.TextLogos;
                    semiordersetting.IsActive = semiordersetting.IsActive;

                    db.SemiOrderSettings.Add(semiordersetting);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baSemiOrderSetting baSemiOrderSetting )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SemiOrderSettings.Where(p => p.Id == baSemiOrderSetting.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        semiordersetting semiordersetting = new semiordersetting();

                        semiordersetting.Id = semiordersetting.Id;
                        semiordersetting.PS_SemiOrder_Settings_Pkey = semiordersetting.PS_SemiOrder_Settings_Pkey;
                        semiordersetting.PS_SemiOrder_Settings_AutoBright = semiordersetting.PS_SemiOrder_Settings_AutoBright;
                        semiordersetting.PS_SemiOrder_Settings_AutoBright_Value = semiordersetting.PS_SemiOrder_Settings_AutoBright_Value;
                        semiordersetting.PS_SemiOrder_Settings_AutoContrast = semiordersetting.PS_SemiOrder_Settings_AutoContrast;
                        semiordersetting.PS_SemiOrder_Settings_AutoContrast_Value = semiordersetting.PS_SemiOrder_Settings_AutoContrast_Value;
                        semiordersetting.PS_SemiOrder_Settings_ImageFrame = semiordersetting.PS_SemiOrder_Settings_ImageFrame;
                        semiordersetting.PS_SemiOrder_Settings_IsImageFrame = semiordersetting.PS_SemiOrder_Settings_IsImageFrame;
                        semiordersetting.PS_SemiOrder_ProductTypeId = semiordersetting.PS_SemiOrder_ProductTypeId;
                        semiordersetting.PS_SemiOrder_Settings_ImageFrame_Vertical = semiordersetting.PS_SemiOrder_Settings_ImageFrame_Vertical;
                        semiordersetting.PS_SemiOrder_Environment = semiordersetting.PS_SemiOrder_Environment;
                        semiordersetting.PS_SemiOrder_BG = semiordersetting.PS_SemiOrder_BG;
                        semiordersetting.PS_SemiOrder_Settings_IsImageBG = semiordersetting.PS_SemiOrder_Settings_IsImageBG;
                        semiordersetting.PS_SemiOrder_Graphics_layer = semiordersetting.PS_SemiOrder_Graphics_layer;
                        semiordersetting.PS_SemiOrder_Image_ZoomInfo = semiordersetting.PS_SemiOrder_Image_ZoomInfo;
                        semiordersetting.PS_SubStoreId = semiordersetting.PS_SubStoreId;
                        semiordersetting.PS_SemiOrder_IsPrintActive = semiordersetting.PS_SemiOrder_IsPrintActive;
                        semiordersetting.PS_SemiOrder_IsCropActive = semiordersetting.PS_SemiOrder_IsCropActive;
                        semiordersetting.VerticalCropValues = semiordersetting.VerticalCropValues;
                        semiordersetting.HorizontalCropValues = semiordersetting.HorizontalCropValues;
                        semiordersetting.PS_LocationId = semiordersetting.PS_LocationId;
                        semiordersetting.ChromaColor = semiordersetting.ChromaColor;
                        semiordersetting.ColorCode = semiordersetting.ColorCode;
                        semiordersetting.ClrTolerance = semiordersetting.ClrTolerance;
                        semiordersetting.ProductName = semiordersetting.ProductName;
                        semiordersetting.TextLogos = semiordersetting.TextLogos;
                        semiordersetting.IsActive = semiordersetting.IsActive;

                        db.SaveChanges();

                        return true;
                        }
                    else
                        {
                        return false;
                        }
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Delete ( int Id )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SemiOrderSettings.Where(p => p.Id == Id).FirstOrDefault();
                    if(obj != null)
                        {
                        obj.IsActive = false;
                        db.SaveChanges();

                        }
                    return true;

                    }
                }
            catch(Exception)
                {
                throw;
                }

            }


        }
    }
