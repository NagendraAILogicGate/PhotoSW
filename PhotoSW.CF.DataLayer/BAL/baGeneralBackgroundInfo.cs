using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baGeneralBackgroundInfo
        {
        public long Id { get; set; }
        public long GeneralBackgroundId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int MediaType { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string IsActiveDisplay { get; set; }
        public int GeneralLength { get; set; }
        public bool IsActive { get; set; }

        public static bool Marge ()
            {
            List<generalbackgroundinfo> lst_generalbackgroundinfo = new List<generalbackgroundinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    generalbackgroundinfo generalbackgroundinfo = new generalbackgroundinfo();

                    generalbackgroundinfo.Id = 1;
                    generalbackgroundinfo.GeneralBackgroundId = 5;
                    generalbackgroundinfo.Name = "test";
                    generalbackgroundinfo.DisplayName = "display";
                    generalbackgroundinfo.Description = "description";
                    generalbackgroundinfo.MediaType = 2;
                    generalbackgroundinfo.CreatedBy = 2;
                    generalbackgroundinfo.CreatedOn = DateTime.Now;
                    generalbackgroundinfo.ModifiedBy = 3;
                    generalbackgroundinfo.ModifiedOn = DateTime.Now;
                    generalbackgroundinfo.IsActiveDisplay = "";                  
                    generalbackgroundinfo.GeneralLength = 5;
                    generalbackgroundinfo.IsActive = true;

                    lst_generalbackgroundinfo.Add(generalbackgroundinfo);

                    var Id = lst_generalbackgroundinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.TripCamSettingInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.GeneralBackgroundInfos.AddRange(lst_generalbackgroundinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.GeneralBackgroundInfos.AddRange(lst_generalbackgroundinfo);
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

        public static baGeneralBackgroundInfo GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GeneralBackgroundInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baGeneralBackgroundInfo
                        {
                        Id = p.Id,
                        GeneralBackgroundId = p.GeneralBackgroundId,
                        Name = p.Name,
                        DisplayName = p.DisplayName,
                        Description = p.Description,
                        MediaType = p.MediaType,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedOn = p.ModifiedOn,
                        IsActiveDisplay = p.IsActiveDisplay,
                        GeneralLength = p.GeneralLength,
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

        public static List<baGeneralBackgroundInfo> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GeneralBackgroundInfos.Where(p => p.IsActive == true).Select(p => new baGeneralBackgroundInfo
                        {
                        Id = p.Id,
                        GeneralBackgroundId = p.GeneralBackgroundId,
                        Name = p.Name,
                        DisplayName = p.DisplayName,
                        Description = p.Description,
                        MediaType = p.MediaType,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedOn = p.ModifiedOn,
                        IsActiveDisplay = p.IsActiveDisplay,
                        GeneralLength = p.GeneralLength,
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

        public static bool Insert ( baGeneralBackgroundInfo baGeneralBackgroundInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    generalbackgroundinfo generalbackgroundinfo = new generalbackgroundinfo();

                    generalbackgroundinfo.Id = baGeneralBackgroundInfo.Id;
                    generalbackgroundinfo.GeneralBackgroundId = baGeneralBackgroundInfo.GeneralBackgroundId;
                    generalbackgroundinfo.Name = baGeneralBackgroundInfo.Name;
                    generalbackgroundinfo.DisplayName = baGeneralBackgroundInfo.DisplayName;
                    generalbackgroundinfo.Description = baGeneralBackgroundInfo.Description;
                    generalbackgroundinfo.MediaType = baGeneralBackgroundInfo.MediaType;
                    generalbackgroundinfo.CreatedBy = baGeneralBackgroundInfo.CreatedBy;
                    generalbackgroundinfo.CreatedOn = baGeneralBackgroundInfo.CreatedOn;
                    generalbackgroundinfo.ModifiedBy = baGeneralBackgroundInfo.ModifiedBy;
                    generalbackgroundinfo.ModifiedOn = baGeneralBackgroundInfo.ModifiedOn;
                    generalbackgroundinfo.IsActiveDisplay = baGeneralBackgroundInfo.IsActiveDisplay;
                    generalbackgroundinfo.GeneralLength = baGeneralBackgroundInfo.GeneralLength;
                    generalbackgroundinfo.IsActive = baGeneralBackgroundInfo.IsActive;

                    db.GeneralBackgroundInfos.Add(generalbackgroundinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception ex)
                {

                throw;
                }
            }

        public static bool Update ( baGeneralBackgroundInfo baGeneralBackgroundInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GeneralBackgroundInfos.Where(p => p.Id == baGeneralBackgroundInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        generalbackgroundinfo generalbackgroundinfo = new generalbackgroundinfo();

                        generalbackgroundinfo.Id = baGeneralBackgroundInfo.Id;
                        generalbackgroundinfo.GeneralBackgroundId = baGeneralBackgroundInfo.GeneralBackgroundId;
                        generalbackgroundinfo.Name = baGeneralBackgroundInfo.Name;
                        generalbackgroundinfo.DisplayName = baGeneralBackgroundInfo.DisplayName;
                        generalbackgroundinfo.Description = baGeneralBackgroundInfo.Description;
                        generalbackgroundinfo.MediaType = baGeneralBackgroundInfo.MediaType;
                        generalbackgroundinfo.CreatedBy = baGeneralBackgroundInfo.CreatedBy;
                        generalbackgroundinfo.CreatedOn = baGeneralBackgroundInfo.CreatedOn;
                        generalbackgroundinfo.ModifiedBy = baGeneralBackgroundInfo.ModifiedBy;
                        generalbackgroundinfo.ModifiedOn = baGeneralBackgroundInfo.ModifiedOn;
                        generalbackgroundinfo.IsActiveDisplay = baGeneralBackgroundInfo.IsActiveDisplay;
                        generalbackgroundinfo.GeneralLength = baGeneralBackgroundInfo.GeneralLength;
                        generalbackgroundinfo.IsActive = baGeneralBackgroundInfo.IsActive;

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
                    var obj = db.GeneralBackgroundInfos.Where(p => p.Id == Id).FirstOrDefault();
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
