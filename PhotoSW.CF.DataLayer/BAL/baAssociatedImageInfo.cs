using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baAssociatedImageInfo
        {
        public long Id { get; set; }

        public string KeyGenerate { get; set; }

        public string KeyNumber { get; set; }

        public string QRCode { get; set; }

        public string PS_Photos_FileName { get; set; }

        public bool IsActive { get; set; }

        public static bool Marge ()
            {
            List<associatedimageinfo> lst_associatedimageinfo = new List<associatedimageinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    associatedimageinfo associatedimageinfo = new associatedimageinfo();
                    associatedimageinfo.Id = 1;
                    associatedimageinfo.KeyGenerate = "Barcode";
                    associatedimageinfo.KeyNumber = "123456";
                    associatedimageinfo.QRCode = "*123456S*";
                    associatedimageinfo.PS_Photos_FileName = "";
                    associatedimageinfo.IsActive = true;

                    lst_associatedimageinfo.Add(associatedimageinfo);

                    var Id = lst_associatedimageinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.AssociatedImageInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.AssociatedImageInfos.AddRange(lst_associatedimageinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.AssociatedImageInfos.AddRange(lst_associatedimageinfo);
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

        public static List<baAssociatedImageInfo> GetAssociatedImageInfo ()
            {
            try
                {

                associatedimageinfo associatedimageinfo = new associatedimageinfo();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.AssociatedImageInfos.Where(p => p.IsActive == true).Select(p => new baAssociatedImageInfo
                        {
                        Id = p.Id,
                        KeyGenerate = p.KeyGenerate,
                        KeyNumber = p.KeyNumber,
                        QRCode = p.QRCode,
                        PS_Photos_FileName = p.PS_Photos_FileName,                       
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
        public static bool Insert ( baAssociatedImageInfo baAssociatedImageInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    associatedimageinfo associatedimageinfo = new associatedimageinfo();

                    associatedimageinfo.Id = baAssociatedImageInfo.Id;
                    associatedimageinfo.KeyGenerate = baAssociatedImageInfo.KeyGenerate;
                    associatedimageinfo.KeyNumber = baAssociatedImageInfo.KeyNumber;
                    associatedimageinfo.QRCode = baAssociatedImageInfo.QRCode;
                    associatedimageinfo.PS_Photos_FileName = baAssociatedImageInfo.PS_Photos_FileName;                   
                    associatedimageinfo.IsActive = true;

                    db.AssociatedImageInfos.Add(associatedimageinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baAssociatedImageInfo baAssociatedImageInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.AssociatedImageInfos.Where(p => p.Id == baAssociatedImageInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        associatedimageinfo associatedimageinfo = new associatedimageinfo();

                        associatedimageinfo.Id = baAssociatedImageInfo.Id;
                        associatedimageinfo.KeyGenerate = baAssociatedImageInfo.KeyGenerate;
                        associatedimageinfo.KeyNumber = baAssociatedImageInfo.KeyNumber;
                        associatedimageinfo.QRCode = baAssociatedImageInfo.QRCode;
                        associatedimageinfo.PS_Photos_FileName = baAssociatedImageInfo.PS_Photos_FileName;
                        associatedimageinfo.IsActive = true;                        

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
                    var obj = db.AssociatedImageInfos.Where(p => p.Id == Id).FirstOrDefault();
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
