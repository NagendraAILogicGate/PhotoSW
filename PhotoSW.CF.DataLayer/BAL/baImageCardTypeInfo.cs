using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
{
   public class baImageCardTypeInfo
   {
       public long Id { get; set; }
       public int IMIXImageCardTypeId { get; set; }
       public string Name { get; set; }
       public string CardIdentificationDigit { get; set; }
       public int ImageIdentificationType { get; set; }
       public bool? IsWaterMark { get; set; }
       public int? MaxImages { get; set; }
       public string Description { get; set; }
       public DateTime? CreatedOn { get; set; }
       public bool? IsPrepaid { get; set; }
       public int? PackageId { get; set; }
       public string Status { get; set; }
       public string ImageIdentificationTypeName { get; set; }
       public bool? IsActive { get; set; }

       public static bool Marge()
       {
           List<imagecardtypeinfo> lst_imagecardtypeinfo = new List<imagecardtypeinfo>();

           try
           {
               using (PhotoSWEntities db = new PhotoSWEntities())
               {
                   //foreach (var item in lst_str)
                   //{
                   imagecardtypeinfo imagecardtypeinfo = new imagecardtypeinfo();

                   imagecardtypeinfo.Id = 1;
                   imagecardtypeinfo.IMIXImageCardTypeId = 1;
                   imagecardtypeinfo.Name = "";
                   imagecardtypeinfo.CardIdentificationDigit = "";
                   imagecardtypeinfo.ImageIdentificationType = 1;
                   imagecardtypeinfo.IsWaterMark = false;
                   imagecardtypeinfo.MaxImages = 20;
                   imagecardtypeinfo.Description = "Desc";
                   imagecardtypeinfo.CreatedOn = DateTime.Now;
                   imagecardtypeinfo.IsPrepaid = true;
                   imagecardtypeinfo.PackageId = 1;
                   imagecardtypeinfo.Status = "Active";
                   imagecardtypeinfo.ImageIdentificationTypeName = "Test";
                   imagecardtypeinfo.IsActive = true;


                   lst_imagecardtypeinfo.Add(imagecardtypeinfo);
                   // }
                   var Id = lst_imagecardtypeinfo.Where(t => t.Id == 1).First().Id;
                   var IsExist = db.ImageCardTypeInfos.Where(p => p.Id == Id).ToList();
                   if (IsExist == null)
                   {
                       db.ImageCardTypeInfos.AddRange(lst_imagecardtypeinfo);
                       db.SaveChanges();
                   }
                   else if (IsExist.Count == 0)
                   {
                       db.ImageCardTypeInfos.AddRange(lst_imagecardtypeinfo);
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
       public static baImageCardTypeInfo GetImageCardTypeInfoDataById(int Id)
       {
           try
           {

               imagecardtypeinfo imagecardtypeinfo = new imagecardtypeinfo();
               using (PhotoSWEntities db = new PhotoSWEntities())
               {
                   var obj = db.ImageCardTypeInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baImageCardTypeInfo
                   {
                       
                       Id = p.Id,
                       IMIXImageCardTypeId=p.IMIXImageCardTypeId,
                       Name = p.Name,
                       CardIdentificationDigit=p.CardIdentificationDigit ,
                       ImageIdentificationType=p.ImageIdentificationType,
                       IsWaterMark = p.IsWaterMark,
                       MaxImages = p.MaxImages,
                       Description = p.Description,
                       CreatedOn = p.CreatedOn,
                       IsPrepaid = p.IsPrepaid,
                       PackageId = p.PackageId,
                       Status = p.Status,
                       ImageIdentificationTypeName=p.ImageIdentificationTypeName,
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
       public static List<baImageCardTypeInfo> GetImageCardTypeInfoData()
       {
           try
           {

              
               using (PhotoSWEntities db = new PhotoSWEntities())
               {
                   var obj = db.ImageCardTypeInfos.Where(p => p.IsActive == true).Select(p => new baImageCardTypeInfo
                   {
                       Id = p.Id,
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

        public static bool Insert ( baImageCardTypeInfo baImageCardTypeInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    imagecardtypeinfo imagecardtypeinfo = new imagecardtypeinfo();

                    imagecardtypeinfo.Id = baImageCardTypeInfo.Id;
                    imagecardtypeinfo.IMIXImageCardTypeId = baImageCardTypeInfo.IMIXImageCardTypeId;
                    imagecardtypeinfo.Name = baImageCardTypeInfo.Name;
                    imagecardtypeinfo.CardIdentificationDigit = baImageCardTypeInfo.CardIdentificationDigit;
                    imagecardtypeinfo.ImageIdentificationType = baImageCardTypeInfo.ImageIdentificationType;
                    imagecardtypeinfo.IsWaterMark = baImageCardTypeInfo.IsWaterMark;
                    imagecardtypeinfo.MaxImages = baImageCardTypeInfo.MaxImages;
                    imagecardtypeinfo.Description = baImageCardTypeInfo.Description;
                    imagecardtypeinfo.CreatedOn = baImageCardTypeInfo.CreatedOn;
                    imagecardtypeinfo.IsPrepaid = baImageCardTypeInfo.IsPrepaid;
                    imagecardtypeinfo.PackageId = baImageCardTypeInfo.PackageId;
                    imagecardtypeinfo.Status = baImageCardTypeInfo.Status;
                    imagecardtypeinfo.ImageIdentificationTypeName = baImageCardTypeInfo.ImageIdentificationTypeName;
                    imagecardtypeinfo.IsActive = baImageCardTypeInfo.IsActive;

                    db.ImageCardTypeInfos.Add(imagecardtypeinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baImageCardTypeInfo baImageCardTypeInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ImageCardTypeInfos.Where(p => p.Id == baImageCardTypeInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        imagecardtypeinfo imagecardtypeinfo = new imagecardtypeinfo();

                        imagecardtypeinfo.Id = baImageCardTypeInfo.Id;
                        imagecardtypeinfo.IMIXImageCardTypeId = baImageCardTypeInfo.IMIXImageCardTypeId;
                        imagecardtypeinfo.Name = baImageCardTypeInfo.Name;
                        imagecardtypeinfo.CardIdentificationDigit = baImageCardTypeInfo.CardIdentificationDigit;
                        imagecardtypeinfo.ImageIdentificationType = baImageCardTypeInfo.ImageIdentificationType;
                        imagecardtypeinfo.IsWaterMark = baImageCardTypeInfo.IsWaterMark;
                        imagecardtypeinfo.MaxImages = baImageCardTypeInfo.MaxImages;
                        imagecardtypeinfo.Description = baImageCardTypeInfo.Description;
                        imagecardtypeinfo.CreatedOn = baImageCardTypeInfo.CreatedOn;
                        imagecardtypeinfo.IsPrepaid = baImageCardTypeInfo.IsPrepaid;
                        imagecardtypeinfo.PackageId = baImageCardTypeInfo.PackageId;
                        imagecardtypeinfo.Status = baImageCardTypeInfo.Status;
                        imagecardtypeinfo.ImageIdentificationTypeName = baImageCardTypeInfo.ImageIdentificationTypeName;
                        imagecardtypeinfo.IsActive = baImageCardTypeInfo.IsActive;

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
                    var obj = db.ImageCardTypeInfos.Where(p => p.Id == Id).FirstOrDefault();
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
