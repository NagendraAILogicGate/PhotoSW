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

    public class baPhotoGroupInfo
    {
   
        public long Id { get; set; }
        public long Group_pkey { get; set; }
        public string Group_Name { get; set; }
        public int Photo_ID { get; set; }
        public string Photo_RFID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int SubstoreId { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<photogroupinfo> lst_photogroupinfo = new List<photogroupinfo>();

            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    //foreach (var item in lst_str)
                    //{
                    photogroupinfo photogroupinfo = new photogroupinfo();

                    photogroupinfo.Id = 1;

                    photogroupinfo.Group_pkey = 1;
                    photogroupinfo.Group_Name = "Pgroup";
                    photogroupinfo.Photo_ID = 1;
                    photogroupinfo.Photo_RFID = "1";
                    photogroupinfo.CreatedDate = DateTime.Now;
                    photogroupinfo.SubstoreId = 1;

                    
                    photogroupinfo.IsActive = true;


                    lst_photogroupinfo.Add(photogroupinfo);
                    // }
                    var Id = lst_photogroupinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PhotoGroupInfos.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.PhotoGroupInfos.AddRange(lst_photogroupinfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.PhotoGroupInfos.AddRange(lst_photogroupinfo);
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

        public static baPhotoGroupInfo GetPhotoGroupInfoDataById(int Id)
        {
            try
            {

                locationinfo locationinfo = new locationinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.PhotoGroupInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPhotoGroupInfo
                    {
                        Id = p.Id,
                        Group_pkey = p.Group_pkey,
                        Group_Name = p.Group_Name,
                        Photo_ID = p.Photo_ID,
                        Photo_RFID = p.Photo_RFID,
                        CreatedDate = p.CreatedDate,
                        SubstoreId = p.SubstoreId,
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
        public static List<baPhotoGroupInfo> GetPhotoGroupInfoData()
        {
            try
            {

                photogroupinfo photogroupinfo = new photogroupinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.PhotoGroupInfos.Where(p => p.IsActive == true).Select(p => new baPhotoGroupInfo
                    {
                        Id = p.Id,
                        Group_pkey = p.Group_pkey,
                        Group_Name = p.Group_Name,
                        Photo_ID = p.Photo_ID,
                        Photo_RFID = p.Photo_RFID,
                        CreatedDate = p.CreatedDate,
                        SubstoreId = p.SubstoreId,
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

        public static bool Insert ( baPhotoGroupInfo baPhotoGroupInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    photogroupinfo photogroupinfo = new photogroupinfo();

                    photogroupinfo.Id = baPhotoGroupInfo.Id;
                    photogroupinfo.Group_pkey = baPhotoGroupInfo.Group_pkey;
                    photogroupinfo.Group_Name = baPhotoGroupInfo.Group_Name;
                    photogroupinfo.Photo_ID = baPhotoGroupInfo.Photo_ID;
                    photogroupinfo.Photo_RFID = baPhotoGroupInfo.Photo_RFID;
                    photogroupinfo.CreatedDate = baPhotoGroupInfo.CreatedDate;
                    photogroupinfo.SubstoreId = baPhotoGroupInfo.SubstoreId;
                    db.PhotoGroupInfos.Add(photogroupinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPhotoGroupInfo baPhotoGroupInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PhotoGroupInfos.Where(p => p.Id == baPhotoGroupInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        photogroupinfo photogroupinfo = new photogroupinfo();

                        photogroupinfo.Id = baPhotoGroupInfo.Id;
                        photogroupinfo.Group_pkey = baPhotoGroupInfo.Group_pkey;
                        photogroupinfo.Group_Name = baPhotoGroupInfo.Group_Name;
                        photogroupinfo.Photo_ID = baPhotoGroupInfo.Photo_ID;
                        photogroupinfo.Photo_RFID = baPhotoGroupInfo.Photo_RFID;
                        photogroupinfo.CreatedDate = baPhotoGroupInfo.CreatedDate;
                        photogroupinfo.SubstoreId = baPhotoGroupInfo.SubstoreId;

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
                    var obj = db.PhotoGroupInfos.Where(p => p.Id == Id).FirstOrDefault();
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
