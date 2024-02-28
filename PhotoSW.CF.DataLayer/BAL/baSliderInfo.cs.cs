using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baSliderInfo
        {
        public int Id { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public string PropertyName { get; set; }
        public bool IsFloat { get; set; }
        public double tickFrequency { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<sliderinfo> lst_sliderinfo = new List<sliderinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    sliderinfo sliderinfo = new sliderinfo();

                    sliderinfo.Id = 1;
                    sliderinfo.MinValue = 1;
                    sliderinfo.MaxValue = 5;
                    sliderinfo.PropertyName = "";
                    sliderinfo.IsFloat = false;
                    sliderinfo.tickFrequency = 5;
                    sliderinfo.IsActive = true;

                    lst_sliderinfo.Add(sliderinfo);

                    var Id = lst_sliderinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.SliderInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.SliderInfos.AddRange(lst_sliderinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.SliderInfos.AddRange(lst_sliderinfo);
                        db.SaveChanges();
                        }
                    return true;
                    }
                }
            catch(Exception ex)
                {
                return false;
                }
            }

        public static baSliderInfo GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SliderInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baSliderInfo
                        {
                        Id = p.Id,
                        MinValue = p.MinValue,
                        MaxValue = p.MaxValue,
                        PropertyName = p.PropertyName,
                        IsFloat = p.IsFloat,
                        tickFrequency = p.tickFrequency,
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

        public static List<baSliderInfo> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SliderInfos.Where(p => p.IsActive == true).Select(p => new baSliderInfo
                        {
                        Id = p.Id,
                        MinValue = p.MinValue,
                        MaxValue = p.MaxValue,
                        PropertyName = p.PropertyName,
                        IsFloat = p.IsFloat,
                        tickFrequency = p.tickFrequency,
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


        public static bool Insert ( baSliderInfo baSliderInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    sliderinfo sliderinfo = new sliderinfo();

                    sliderinfo.Id = baSliderInfo.Id;
                    sliderinfo.MinValue = baSliderInfo.MinValue;
                    sliderinfo.MaxValue = baSliderInfo.MaxValue;
                    sliderinfo.PropertyName = baSliderInfo.PropertyName;
                    sliderinfo.IsFloat = baSliderInfo.IsFloat;
                    sliderinfo.tickFrequency = baSliderInfo.tickFrequency;
                    sliderinfo.IsActive = baSliderInfo.IsActive;

                    db.SliderInfos.Add(sliderinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baSliderInfo baSliderInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SliderInfos.Where(p => p.Id == baSliderInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        sliderinfo sliderinfo = new sliderinfo();

                        sliderinfo.Id = baSliderInfo.Id;
                        sliderinfo.MinValue = baSliderInfo.MinValue;
                        sliderinfo.MaxValue = baSliderInfo.MaxValue;
                        sliderinfo.PropertyName = baSliderInfo.PropertyName;
                        sliderinfo.IsFloat = baSliderInfo.IsFloat;
                        sliderinfo.tickFrequency = baSliderInfo.tickFrequency;
                        sliderinfo.IsActive = baSliderInfo.IsActive;

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
                    var obj = db.SliderInfos.Where(p => p.Id == Id).FirstOrDefault();
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
