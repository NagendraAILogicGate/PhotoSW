using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baAudioTemplateInfo
        {
        public long Id { get; set; }
        public long AudioTemplateId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsActive { get; set; }
        public string IsActiveDisplay { get; set; }
        public long AudioLength { get; set; }
        
        public static bool Marge ()
            {
            List<audiotemplateinfo> lst_audiotemplateinfo = new List<audiotemplateinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    audiotemplateinfo audiotemplateinfo = new audiotemplateinfo();

                    audiotemplateinfo.Id = 1;
                    audiotemplateinfo.AudioTemplateId = 3;
                    audiotemplateinfo.Name = "";
                    audiotemplateinfo.DisplayName = "";
                    audiotemplateinfo.Description = "";
                    audiotemplateinfo.CreatedBy = 1;
                    audiotemplateinfo.CreatedOn = DateTime.Now;
                    audiotemplateinfo.ModifiedBy = 1;
                    audiotemplateinfo.ModifiedOn = DateTime.Now;
                    audiotemplateinfo.IsActiveDisplay = "";
                    audiotemplateinfo.AudioLength = 2;                   
                    audiotemplateinfo.IsActive = true;

                    lst_audiotemplateinfo.Add(audiotemplateinfo);

                    var Id = lst_audiotemplateinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.AudioTemplateInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.AudioTemplateInfos.AddRange(lst_audiotemplateinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.AudioTemplateInfos.AddRange(lst_audiotemplateinfo);
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

        public static baAudioTemplateInfo GetAudioTemplateInfoDataById ( long Id )
            {
            try
                {

                audiotemplateinfo audiotemplateinfo = new audiotemplateinfo();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.AudioTemplateInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baAudioTemplateInfo
                        {
                        Id = p.Id,
                        AudioTemplateId = p.AudioTemplateId,
                        Name = p.Name,
                        DisplayName = p.DisplayName,
                        Description = p.Description,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedOn = p.ModifiedOn,
                        IsActiveDisplay = p.IsActiveDisplay,
                        AudioLength = p.AudioLength,
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

        public static List<baAudioTemplateInfo> GetAudioTemplateInfoData ()
            {
            try
                {

                audiotemplateinfo audiotemplateinfo = new audiotemplateinfo();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.AudioTemplateInfos.Where(p => p.IsActive == true).Select(p => new baAudioTemplateInfo
                        {
                        Id = p.Id,
                        AudioTemplateId = p.AudioTemplateId,
                        Name = p.Name,
                        DisplayName = p.DisplayName,
                        Description = p.Description,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedOn = p.ModifiedOn,
                        IsActiveDisplay = p.IsActiveDisplay,
                        AudioLength = p.AudioLength,
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

        public static bool Insert ( baAudioTemplateInfo baAudioTemplateInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    audiotemplateinfo audiotemplateinfo = new audiotemplateinfo();

                    audiotemplateinfo.Id = baAudioTemplateInfo.Id;
                    audiotemplateinfo.AudioTemplateId = baAudioTemplateInfo.AudioTemplateId;
                    audiotemplateinfo.Name = baAudioTemplateInfo.Name;
                    audiotemplateinfo.DisplayName = baAudioTemplateInfo.DisplayName;
                    audiotemplateinfo.Description = baAudioTemplateInfo.Description;
                    audiotemplateinfo.CreatedBy = baAudioTemplateInfo.CreatedBy;
                    audiotemplateinfo.CreatedOn = baAudioTemplateInfo.CreatedOn;
                    audiotemplateinfo.ModifiedBy = baAudioTemplateInfo.ModifiedBy;
                    audiotemplateinfo.ModifiedOn = baAudioTemplateInfo.ModifiedOn;
                    audiotemplateinfo.IsActiveDisplay = baAudioTemplateInfo.IsActiveDisplay;
                    audiotemplateinfo.AudioLength = baAudioTemplateInfo.AudioLength;
                    audiotemplateinfo.IsActive = baAudioTemplateInfo.IsActive;

                    db.AudioTemplateInfos.Add(audiotemplateinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baAudioTemplateInfo baAudioTemplateInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.AudioTemplateInfos.Where(p => p.Id == baAudioTemplateInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        audiotemplateinfo audiotemplateinfo = new audiotemplateinfo();

                        audiotemplateinfo.Id = baAudioTemplateInfo.Id;
                        audiotemplateinfo.AudioTemplateId = baAudioTemplateInfo.AudioTemplateId;
                        audiotemplateinfo.Name = baAudioTemplateInfo.Name;
                        audiotemplateinfo.DisplayName = baAudioTemplateInfo.DisplayName;
                        audiotemplateinfo.Description = baAudioTemplateInfo.Description;
                        audiotemplateinfo.CreatedBy = baAudioTemplateInfo.CreatedBy;
                        audiotemplateinfo.CreatedOn = baAudioTemplateInfo.CreatedOn;
                        audiotemplateinfo.ModifiedBy = baAudioTemplateInfo.ModifiedBy;
                        audiotemplateinfo.ModifiedOn = baAudioTemplateInfo.ModifiedOn;
                        audiotemplateinfo.IsActiveDisplay = baAudioTemplateInfo.IsActiveDisplay;
                        audiotemplateinfo.AudioLength = baAudioTemplateInfo.AudioLength;
                        audiotemplateinfo.IsActive = baAudioTemplateInfo.IsActive;

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
                    var obj = db.AudioTemplateInfos.Where(p => p.Id == Id).FirstOrDefault();
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
