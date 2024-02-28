using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baiMixImageAssociationInfo
        {
        public long Id { get; set; }
        public long IMIXImageAssociationId { get; set; }
        public int IMIXCardTypeId { get; set; }
        public int PhotoId { get; set; }
        public string CardUniqueIdentifier { get; set; }
        public string MappedIdentifier { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<imiximageassociationinfo> lst_imiximageassociationinfo = new List<imiximageassociationinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    //foreach (var item in lst_str)
                    //{
                    imiximageassociationinfo imiximageassociationinfo = new imiximageassociationinfo();

                    imiximageassociationinfo.Id = 1;
                    imiximageassociationinfo.IMIXImageAssociationId = 2;
                    imiximageassociationinfo.IMIXCardTypeId = 1;
                    imiximageassociationinfo.PhotoId = 2;
                    imiximageassociationinfo.CardUniqueIdentifier = "";
                    imiximageassociationinfo.MappedIdentifier = "";
                    imiximageassociationinfo.IsActive = true;

                    lst_imiximageassociationinfo.Add(imiximageassociationinfo);

                    var Id = lst_imiximageassociationinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.iMixImageAssociationInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.iMixImageAssociationInfos.AddRange(lst_imiximageassociationinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.iMixImageAssociationInfos.AddRange(lst_imiximageassociationinfo);
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

        public static baiMixImageAssociationInfo GetiMixImageAssociationInfoById ( int Id )
            {
            try
                {

              //  imixconfigurationlocationinfolist imixconfigurationlocationinfolist = new imixconfigurationlocationinfolist();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.iMixImageAssociationInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baiMixImageAssociationInfo
                        {
                        Id = p.Id,
                        IMIXImageAssociationId = p.IMIXImageAssociationId,
                        IMIXCardTypeId = p.IMIXCardTypeId,
                        PhotoId = p.PhotoId,
                        CardUniqueIdentifier = p.CardUniqueIdentifier,
                        MappedIdentifier = p.MappedIdentifier,
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

        public static List<baiMixImageAssociationInfo> GetiMixImageAssociationInfoData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.iMixImageAssociationInfos.Where(p => p.IsActive == true).Select(p => new baiMixImageAssociationInfo
                        {
                        Id = p.Id,
                        IMIXImageAssociationId = p.IMIXImageAssociationId,
                        IMIXCardTypeId = p.IMIXCardTypeId,
                        PhotoId = p.PhotoId,
                        CardUniqueIdentifier = p.CardUniqueIdentifier,
                        MappedIdentifier = p.MappedIdentifier,
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

        public static bool Insert ( baiMixImageAssociationInfo baiMixImageAssociationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    imiximageassociationinfo imiximageassociationinfo = new imiximageassociationinfo();

                    imiximageassociationinfo.Id = baiMixImageAssociationInfo.Id;
                    imiximageassociationinfo.IMIXImageAssociationId = baiMixImageAssociationInfo.IMIXImageAssociationId;
                    imiximageassociationinfo.IMIXCardTypeId = baiMixImageAssociationInfo.IMIXCardTypeId;
                    imiximageassociationinfo.PhotoId = baiMixImageAssociationInfo.PhotoId;
                    imiximageassociationinfo.CardUniqueIdentifier = baiMixImageAssociationInfo.CardUniqueIdentifier;
                    imiximageassociationinfo.MappedIdentifier = baiMixImageAssociationInfo.MappedIdentifier;
                    imiximageassociationinfo.IsActive = baiMixImageAssociationInfo.IsActive;

                    db.iMixImageAssociationInfos.Add(imiximageassociationinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baiMixImageAssociationInfo baiMixImageAssociationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.iMixImageAssociationInfos.Where(p => p.Id == baiMixImageAssociationInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        imiximageassociationinfo imiximageassociationinfo = new imiximageassociationinfo();

                        imiximageassociationinfo.Id = baiMixImageAssociationInfo.Id;
                        imiximageassociationinfo.IMIXImageAssociationId = baiMixImageAssociationInfo.IMIXImageAssociationId;
                        imiximageassociationinfo.IMIXCardTypeId = baiMixImageAssociationInfo.IMIXCardTypeId;
                        imiximageassociationinfo.PhotoId = baiMixImageAssociationInfo.PhotoId;
                        imiximageassociationinfo.CardUniqueIdentifier = baiMixImageAssociationInfo.CardUniqueIdentifier;
                        imiximageassociationinfo.MappedIdentifier = baiMixImageAssociationInfo.MappedIdentifier;
                        imiximageassociationinfo.IsActive = baiMixImageAssociationInfo.IsActive;

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
                    var obj = db.iMixImageAssociationInfos.Where(p => p.Id == Id).FirstOrDefault();
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
