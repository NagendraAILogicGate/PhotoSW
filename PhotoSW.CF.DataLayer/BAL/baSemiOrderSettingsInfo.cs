using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
{
    public class baSemiOrderSettingsInfo
    {
        public int Id { get; set; }
        public bool IsBrightActive { get; set; }
        public double BrightValue { get; set; }
        public bool IsContrastActive { get; set; }
        public double ContrastValue { get; set; }
        public string BorderName { get; set; }
        public bool IsBorderActive { get; set; }
        public string ProductTypeId { get; set; }
        public string VerticalBorderName { get; set; }
        public bool IsGreenScreenActive { get; set; }
        public string BackgroundName { get; set; }
        public bool IsChromaActive { get; set; }
        public string GraphicsLayer { get; set; }
        public string ZoomInfo { get; set; }
        public int SubstoreId { get; set; }
        public bool IsPrintActive { get; set; }
        public bool IsCropActive { get; set; }
        public string VerticalCropValues { get; set; }
        public string HorizontalCropValues { get; set; }
        public int LocationId { get; set; }
        public string ChromaColor { get; set; }
        public string ColorCode { get; set; }
        public string ClrTolerance { get; set; }
        public bool? Environment { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<semiordersettingsinfo> lst_semiordersettingsinfo = new List<semiordersettingsinfo>();
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    //foreach (var item in lst_str)
                    //{
                    semiordersettingsinfo semiordersettingsinfo = new semiordersettingsinfo();
                    semiordersettingsinfo.Id = 1;
                    semiordersettingsinfo.IsBrightActive = true;
                    semiordersettingsinfo.BrightValue = 2;
                    semiordersettingsinfo.IsContrastActive = true;
                    semiordersettingsinfo.ContrastValue = 2;
                    semiordersettingsinfo.BorderName = "Test";
                    semiordersettingsinfo.IsBorderActive = true;
                    semiordersettingsinfo.ProductTypeId = "1";
                    semiordersettingsinfo.VerticalBorderName = "";
                    semiordersettingsinfo.IsGreenScreenActive = true;
                    semiordersettingsinfo.BackgroundName = "";
                    semiordersettingsinfo.IsChromaActive = true;
                    semiordersettingsinfo.GraphicsLayer = "";
                    semiordersettingsinfo.ZoomInfo = "150";
                    semiordersettingsinfo.SubstoreId = 3;
                    semiordersettingsinfo.IsPrintActive = true;
                    semiordersettingsinfo.IsCropActive = true;
                    semiordersettingsinfo.VerticalCropValues = "2";
                    semiordersettingsinfo.HorizontalCropValues = "2";
                    semiordersettingsinfo.LocationId = 1;
                    semiordersettingsinfo.ChromaColor = "Black";
                    semiordersettingsinfo.ColorCode = "#000000";
                    semiordersettingsinfo.ClrTolerance = "";
                    semiordersettingsinfo.Environment = true;
                    semiordersettingsinfo.IsActive = true;
                    lst_semiordersettingsinfo.Add(semiordersettingsinfo);
                    // }
                    var Id = lst_semiordersettingsinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.SemiOrderSettingsInfos.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.SemiOrderSettingsInfos.AddRange(lst_semiordersettingsinfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.SemiOrderSettingsInfos.AddRange(lst_semiordersettingsinfo);
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

        public static baSemiOrderSettingsInfo GetSemiOrderSettingsInfoDataById(int Id)
        {
            try
            {

                semiordersettingsinfo semiordersettingsinfo = new semiordersettingsinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SemiOrderSettingsInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baSemiOrderSettingsInfo
                    {
                            Id = p.Id,
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
                            LocationId =p.LocationId,
                            ChromaColor = p.ChromaColor,
                            ColorCode = p.ColorCode,
                            ClrTolerance = p.ClrTolerance,
                            Environment = p.Environment,
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
        public static List<baSemiOrderSettingsInfo> GetSemiOrderSettingsInfoData()
        {
            try
            {
                semiordersettingsinfo semiordersettingsinfo = new semiordersettingsinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SemiOrderSettingsInfos.Where(p => p.IsActive == true).Select(p => new baSemiOrderSettingsInfo
                    {
                        Id = p.Id,
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


        public static bool Insert ( baSemiOrderSettingsInfo baSemiOrderSettingsInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    semiordersettingsinfo semiordersettingsinfo = new semiordersettingsinfo();
                    semiordersettingsinfo.Id = semiordersettingsinfo.Id;
                    semiordersettingsinfo.IsBrightActive = semiordersettingsinfo.IsBrightActive;
                    semiordersettingsinfo.BrightValue = semiordersettingsinfo.BrightValue;
                    semiordersettingsinfo.IsContrastActive = semiordersettingsinfo.IsContrastActive;
                    semiordersettingsinfo.ContrastValue = semiordersettingsinfo.ContrastValue;
                    semiordersettingsinfo.BorderName = semiordersettingsinfo.BorderName;
                    semiordersettingsinfo.IsBorderActive = semiordersettingsinfo.IsBorderActive;
                    semiordersettingsinfo.ProductTypeId = semiordersettingsinfo.ProductTypeId;
                    semiordersettingsinfo.VerticalBorderName = semiordersettingsinfo.VerticalBorderName;
                    semiordersettingsinfo.IsGreenScreenActive = semiordersettingsinfo.IsGreenScreenActive;
                    semiordersettingsinfo.BackgroundName = semiordersettingsinfo.BackgroundName;
                    semiordersettingsinfo.IsChromaActive = semiordersettingsinfo.IsChromaActive;
                    semiordersettingsinfo.GraphicsLayer = semiordersettingsinfo.GraphicsLayer;
                    semiordersettingsinfo.ZoomInfo = semiordersettingsinfo.ZoomInfo;
                    semiordersettingsinfo.SubstoreId = semiordersettingsinfo.SubstoreId;
                    semiordersettingsinfo.IsPrintActive = semiordersettingsinfo.IsPrintActive;
                    semiordersettingsinfo.IsCropActive = semiordersettingsinfo.IsCropActive;
                    semiordersettingsinfo.VerticalCropValues = semiordersettingsinfo.VerticalCropValues;
                    semiordersettingsinfo.HorizontalCropValues = semiordersettingsinfo.HorizontalCropValues;
                    semiordersettingsinfo.LocationId = semiordersettingsinfo.LocationId;
                    semiordersettingsinfo.ChromaColor = semiordersettingsinfo.ChromaColor;
                    semiordersettingsinfo.ColorCode = semiordersettingsinfo.ColorCode;
                    semiordersettingsinfo.ClrTolerance = semiordersettingsinfo.ClrTolerance;
                    semiordersettingsinfo.Environment = semiordersettingsinfo.Environment;
                    semiordersettingsinfo.IsActive = semiordersettingsinfo.IsActive;

                    db.SemiOrderSettingsInfos.Add(semiordersettingsinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baSemiOrderSettingsInfo baSemiOrderSettingsInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SemiOrderSettingsInfos.Where(p => p.Id == baSemiOrderSettingsInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        semiordersettingsinfo semiordersettingsinfo = new semiordersettingsinfo();
                        semiordersettingsinfo.Id = semiordersettingsinfo.Id;
                        semiordersettingsinfo.IsBrightActive = semiordersettingsinfo.IsBrightActive;
                        semiordersettingsinfo.BrightValue = semiordersettingsinfo.BrightValue;
                        semiordersettingsinfo.IsContrastActive = semiordersettingsinfo.IsContrastActive;
                        semiordersettingsinfo.ContrastValue = semiordersettingsinfo.ContrastValue;
                        semiordersettingsinfo.BorderName = semiordersettingsinfo.BorderName;
                        semiordersettingsinfo.IsBorderActive = semiordersettingsinfo.IsBorderActive;
                        semiordersettingsinfo.ProductTypeId = semiordersettingsinfo.ProductTypeId;
                        semiordersettingsinfo.VerticalBorderName = semiordersettingsinfo.VerticalBorderName;
                        semiordersettingsinfo.IsGreenScreenActive = semiordersettingsinfo.IsGreenScreenActive;
                        semiordersettingsinfo.BackgroundName = semiordersettingsinfo.BackgroundName;
                        semiordersettingsinfo.IsChromaActive = semiordersettingsinfo.IsChromaActive;
                        semiordersettingsinfo.GraphicsLayer = semiordersettingsinfo.GraphicsLayer;
                        semiordersettingsinfo.ZoomInfo = semiordersettingsinfo.ZoomInfo;
                        semiordersettingsinfo.SubstoreId = semiordersettingsinfo.SubstoreId;
                        semiordersettingsinfo.IsPrintActive = semiordersettingsinfo.IsPrintActive;
                        semiordersettingsinfo.IsCropActive = semiordersettingsinfo.IsCropActive;
                        semiordersettingsinfo.VerticalCropValues = semiordersettingsinfo.VerticalCropValues;
                        semiordersettingsinfo.HorizontalCropValues = semiordersettingsinfo.HorizontalCropValues;
                        semiordersettingsinfo.LocationId = semiordersettingsinfo.LocationId;
                        semiordersettingsinfo.ChromaColor = semiordersettingsinfo.ChromaColor;
                        semiordersettingsinfo.ColorCode = semiordersettingsinfo.ColorCode;
                        semiordersettingsinfo.ClrTolerance = semiordersettingsinfo.ClrTolerance;
                        semiordersettingsinfo.Environment = semiordersettingsinfo.Environment;
                        semiordersettingsinfo.IsActive = semiordersettingsinfo.IsActive;

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
                    var obj = db.SemiOrderSettingsInfos.Where(p => p.Id == Id).FirstOrDefault();
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
