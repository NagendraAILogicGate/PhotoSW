using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
{
   public class baPhotoDetail
   {
       public long Id { get; set; }
       public int PhotoId { get; set; }
       public string FileName { get; set; }
       public DateTime PS_Photos_CreatedOn { get; set; }
       public string PhotoRFID { get; set; }
       public string Layering { get; set; }
       public string Effects { get; set; }
       public bool IsCropped { get; set; }
       public bool IsGreen { get; set; }
       public int LocationId { get; set; }
       public int SubstoreId { get; set; }
       public bool IsEnabled { get; set; }
       public bool IsChecked { get; set; }
       public string HotFolderPath { get; set; }
       public int MediaType { get; set; }
       public int PhotoGrapherId { get; set; }
       public long VideoLength { get; set; }
       public int PhotoIdSequence { get; set; }
       public int SemiOrderProfileId { get; set; }
       public bool? IsGumRideShow { get; set; }

       public bool? IsActive { get; set; }

       public static bool Marge()
       {
           List<photodetail> lst_photodetail = new List<photodetail>();

           try
           {
               using (PhotoSWEntities db = new PhotoSWEntities())
               {
                   //foreach (var item in lst_str)
                   //{
                   photodetail photodetail = new photodetail();

                   photodetail.Id = 1;
                   photodetail.PhotoId = 1;
                   photodetail.FileName = "";
                   photodetail.PS_Photos_CreatedOn = DateTime.Now;
                   photodetail.PhotoRFID = "1";
                   photodetail.Layering = "";
                   photodetail.Effects = "";
                   photodetail.IsCropped = true;
                   photodetail.IsGreen = true;
                   photodetail.LocationId = 1;
                   photodetail.SubstoreId = 1;
                   photodetail.IsEnabled = true;
                   photodetail.IsChecked = true;
                   photodetail.HotFolderPath = "";
                   photodetail.MediaType = 1;
                   photodetail.PhotoGrapherId = 1;
                   photodetail.VideoLength = 5;
                   photodetail.PhotoIdSequence = 1;
                   photodetail.SemiOrderProfileId = 1;
                   photodetail.IsGumRideShow = true;
                   photodetail.IsActive = true;


                   lst_photodetail.Add(photodetail);
                   // }
                   var Id = lst_photodetail.Where(t => t.Id == 1).First().Id;
                   var IsExist = db.PhotoDetails.Where(p => p.Id == Id).ToList();
                   if (IsExist == null)
                   {
                       db.PhotoDetails.AddRange(lst_photodetail);
                       db.SaveChanges();
                   }
                   else if (IsExist.Count == 0)
                   {
                       db.PhotoDetails.AddRange(lst_photodetail);
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
       public static baPhotoDetail GetPhotoDetailDataById(int Id)
       {
           try
           {

               photodetail photodetail = new photodetail();
               using (PhotoSWEntities db = new PhotoSWEntities())
               {
                   var obj = db.PhotoDetails.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPhotoDetail
                   {
                       Id = p.Id,
                       PhotoId = p.PhotoId,
                       FileName = p.FileName,
                       PS_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                       PhotoRFID = p.PhotoRFID,
                       Layering = p.Layering,
                       Effects = p.Effects,
                       IsCropped = p.IsCropped,
                       IsGreen = p.IsGreen,
                       LocationId = p.LocationId,
                       SubstoreId = p.SubstoreId,
                       IsEnabled = p.IsEnabled,
                       IsChecked = p.IsChecked,
                       HotFolderPath = p.HotFolderPath,
                       MediaType = p.MediaType,
                       PhotoGrapherId = p.PhotoGrapherId,
                       VideoLength =p.VideoLength,
                       PhotoIdSequence = p.PhotoIdSequence,
                       SemiOrderProfileId = p.SemiOrderProfileId,
                       IsGumRideShow = p.IsGumRideShow,
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
       public static List<baPhotoDetail> GetPhotoDetailData()
       {
           try
           {

               photodetail photodetail = new photodetail();
               using (PhotoSWEntities db = new PhotoSWEntities())
               {
                   var obj = db.PhotoDetails.Where(p => p.IsActive == true).Select(p => new baPhotoDetail
                   {
                       Id = p.Id,
                       PhotoId = p.PhotoId,
                       FileName = p.FileName,
                       PS_Photos_CreatedOn = p.PS_Photos_CreatedOn,
                       PhotoRFID = p.PhotoRFID,
                       Layering = p.Layering,
                       Effects = p.Effects,
                       IsCropped = p.IsCropped,
                       IsGreen = p.IsGreen,
                       LocationId = p.LocationId,
                       SubstoreId = p.SubstoreId,
                       IsEnabled = p.IsEnabled,
                       IsChecked = p.IsChecked,
                       HotFolderPath = p.HotFolderPath,
                       MediaType = p.MediaType,
                       PhotoGrapherId = p.PhotoGrapherId,
                       VideoLength = p.VideoLength,
                       PhotoIdSequence = p.PhotoIdSequence,
                       SemiOrderProfileId = p.SemiOrderProfileId,
                       IsGumRideShow = p.IsGumRideShow,
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

        public static bool Insert ( baPhotoDetail baPhotoDetail )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    photodetail photodetail = new photodetail();

                    photodetail.Id = baPhotoDetail.Id;
                    photodetail.PhotoId = baPhotoDetail.PhotoId;
                    photodetail.FileName = baPhotoDetail.FileName;
                    photodetail.PS_Photos_CreatedOn = baPhotoDetail.PS_Photos_CreatedOn;
                    photodetail.PhotoRFID = baPhotoDetail.PhotoRFID;
                    photodetail.Layering = baPhotoDetail.Layering;
                    photodetail.Effects = baPhotoDetail.Effects;
                    photodetail.IsCropped = baPhotoDetail.IsCropped;
                    photodetail.IsGreen = baPhotoDetail.IsGreen;
                    photodetail.LocationId = baPhotoDetail.LocationId;
                    photodetail.SubstoreId = baPhotoDetail.SubstoreId;
                    photodetail.IsEnabled = baPhotoDetail.IsEnabled;
                    photodetail.IsChecked = baPhotoDetail.IsChecked;
                    photodetail.HotFolderPath = baPhotoDetail.HotFolderPath;
                    photodetail.MediaType = baPhotoDetail.MediaType;
                    photodetail.PhotoGrapherId = baPhotoDetail.PhotoGrapherId;
                    photodetail.VideoLength = baPhotoDetail.VideoLength;
                    photodetail.PhotoIdSequence = baPhotoDetail.PhotoIdSequence;
                    photodetail.SemiOrderProfileId = baPhotoDetail.SemiOrderProfileId;
                    photodetail.IsGumRideShow = baPhotoDetail.IsGumRideShow;
                    photodetail.IsActive = baPhotoDetail.IsActive;

                    db.PhotoDetails.Add(photodetail);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPhotoDetail baPhotoDetail )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PhotoDetails.Where(p => p.Id == baPhotoDetail.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        photodetail photodetail = new photodetail();

                        photodetail.Id = baPhotoDetail.Id;
                        photodetail.PhotoId = baPhotoDetail.PhotoId;
                        photodetail.FileName = baPhotoDetail.FileName;
                        photodetail.PS_Photos_CreatedOn = baPhotoDetail.PS_Photos_CreatedOn;
                        photodetail.PhotoRFID = baPhotoDetail.PhotoRFID;
                        photodetail.Layering = baPhotoDetail.Layering;
                        photodetail.Effects = baPhotoDetail.Effects;
                        photodetail.IsCropped = baPhotoDetail.IsCropped;
                        photodetail.IsGreen = baPhotoDetail.IsGreen;
                        photodetail.LocationId = baPhotoDetail.LocationId;
                        photodetail.SubstoreId = baPhotoDetail.SubstoreId;
                        photodetail.IsEnabled = baPhotoDetail.IsEnabled;
                        photodetail.IsChecked = baPhotoDetail.IsChecked;
                        photodetail.HotFolderPath = baPhotoDetail.HotFolderPath;
                        photodetail.MediaType = baPhotoDetail.MediaType;
                        photodetail.PhotoGrapherId = baPhotoDetail.PhotoGrapherId;
                        photodetail.VideoLength = baPhotoDetail.VideoLength;
                        photodetail.PhotoIdSequence = baPhotoDetail.PhotoIdSequence;
                        photodetail.SemiOrderProfileId = baPhotoDetail.SemiOrderProfileId;
                        photodetail.IsGumRideShow = baPhotoDetail.IsGumRideShow;
                        photodetail.IsActive = baPhotoDetail.IsActive;

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
                    var obj = db.PhotoDetails.Where(p => p.Id == Id).FirstOrDefault();
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
