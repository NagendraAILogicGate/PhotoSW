using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;
namespace PhotoSW.CF.DataLayer.BAL
{
    public class baChromaKeyTemplateInfo
    {
        public long Id { get; set; }
        public long ChromaKeyTemplateId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsActive { get; set; }
        public string IsActiveDisplay { get; set; }
        public long ChromaKeyLength { get; set; }

        public static bool Marge()
        {
            List<chromakeytemplateinfo> lst_chromakeytemplateinfo = new List<chromakeytemplateinfo>();

            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    chromakeytemplateinfo chromakeytemplateinfo = new chromakeytemplateinfo();

                    chromakeytemplateinfo.Id = 1;
                    chromakeytemplateinfo.ChromaKeyTemplateId = 1;
                    chromakeytemplateinfo.Name = "";
                    chromakeytemplateinfo.DisplayName = "";
                    chromakeytemplateinfo.Description = "";
                    chromakeytemplateinfo.CreatedBy = 1;
                    chromakeytemplateinfo.CreatedOn = DateTime.Now;
                    chromakeytemplateinfo.ModifiedBy = 1;
                    chromakeytemplateinfo.ModifiedOn = DateTime.Now;
                    chromakeytemplateinfo.IsActiveDisplay = "";
                    chromakeytemplateinfo.ChromaKeyLength = 2;
                    chromakeytemplateinfo.IsActive = true;

                    lst_chromakeytemplateinfo.Add(chromakeytemplateinfo);

                    var Id = lst_chromakeytemplateinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.AudioTemplateInfos.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.ChromaKeyTemplateInfos.AddRange(lst_chromakeytemplateinfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.ChromaKeyTemplateInfos.AddRange(lst_chromakeytemplateinfo);
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


        public static baChromaKeyTemplateInfo GetChromaKeyInfosDataById(long Id)
        {
            try
            {


                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.ChromaKeyTemplateInfos.Where(v => v.ChromaKeyTemplateId == Id && v.IsActive == true).Select(v => new baChromaKeyTemplateInfo
                    {
                        Id = v.Id,
                        ChromaKeyTemplateId = v.ChromaKeyTemplateId,
                        Name = v.Name,
                        DisplayName = v.DisplayName,
                        Description = v.Description,
                        CreatedBy = v.CreatedBy,
                        CreatedOn = v.CreatedOn,
                        ModifiedBy = v.ModifiedBy,
                        ModifiedOn = v.ModifiedOn,
                        IsActive = v.IsActive,
                        IsActiveDisplay = v.IsActiveDisplay,
                        ChromaKeyLength = v.ChromaKeyLength
                    }).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }
        public static List<baChromaKeyTemplateInfo> GetChromaKeyInfosData()
        {
            try
            {

                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.ChromaKeyTemplateInfos.Where(v => v.IsActive == true).Select(v => new baChromaKeyTemplateInfo
                    {
                        Id = v.Id,
                        ChromaKeyTemplateId = v.ChromaKeyTemplateId,
                        Name = v.Name,
                        DisplayName = v.DisplayName,
                        Description = v.Description,
                        CreatedBy = v.CreatedBy,
                        CreatedOn = v.CreatedOn,
                        ModifiedBy = v.ModifiedBy,
                        ModifiedOn = v.ModifiedOn,
                        IsActive = v.IsActive,
                        IsActiveDisplay = v.IsActiveDisplay,
                        ChromaKeyLength = v.ChromaKeyLength
                    }).ToList();
                    return obj;
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool Insert(baChromaKeyTemplateInfo baChromaKeyTemplateInfo)
        {
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    chromakeytemplateinfo Chromakeytemplateinfo = new chromakeytemplateinfo();
                    Chromakeytemplateinfo.Id = baChromaKeyTemplateInfo.Id;
                    Chromakeytemplateinfo.Name = baChromaKeyTemplateInfo.Name;
                    Chromakeytemplateinfo.DisplayName = baChromaKeyTemplateInfo.DisplayName;
                    Chromakeytemplateinfo.Description = baChromaKeyTemplateInfo.Description;
                    Chromakeytemplateinfo.CreatedBy = baChromaKeyTemplateInfo.CreatedBy;
                    Chromakeytemplateinfo.CreatedOn = baChromaKeyTemplateInfo.CreatedOn;
                    Chromakeytemplateinfo.ModifiedBy = baChromaKeyTemplateInfo.ModifiedBy;
                    Chromakeytemplateinfo.ModifiedOn = baChromaKeyTemplateInfo.ModifiedOn;
                    Chromakeytemplateinfo.IsActive = baChromaKeyTemplateInfo.IsActive;
                    Chromakeytemplateinfo.IsActiveDisplay = baChromaKeyTemplateInfo.IsActiveDisplay;
                    Chromakeytemplateinfo.ChromaKeyLength = baChromaKeyTemplateInfo.ChromaKeyLength;
                    db.ChromaKeyTemplateInfos.Add(Chromakeytemplateinfo);
                    db.SaveChanges();

                    Chromakeytemplateinfo.ChromaKeyTemplateId = db.ChromaKeyTemplateInfos.OrderByDescending(m => m.Id).FirstOrDefault().Id;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool Update(baChromaKeyTemplateInfo baChromaKeyTemplateInfo)
        {
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.ChromaKeyTemplateInfos.Where(p => p.ChromaKeyTemplateId == baChromaKeyTemplateInfo.ChromaKeyTemplateId).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.Name = baChromaKeyTemplateInfo.Name;
                        obj.Description = baChromaKeyTemplateInfo.Description;
                        obj.DisplayName = baChromaKeyTemplateInfo.DisplayName;
                        obj.IsActive = baChromaKeyTemplateInfo.IsActive;
                        obj.ChromaKeyLength = baChromaKeyTemplateInfo.ChromaKeyLength;

                        db.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool Delete(int Id)
        {
            bool retval = false;
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.ChromaKeyTemplateInfos.Where(p => p.ChromaKeyTemplateId == Id).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.IsActive = false;
                        db.SaveChanges();
                        retval = true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return retval;

        }



    }
}
