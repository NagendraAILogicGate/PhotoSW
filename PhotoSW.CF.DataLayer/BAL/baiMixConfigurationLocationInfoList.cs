using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baiMixConfigurationLocationInfoList
        {
        public long Id { get; set; }
        public List<imixconfigurationlocationinfo> iMixConfigurationLocationList { get; set; }
        public int SubstoreId { get; set; }
        public int LocationId { get; set; }        
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<imixconfigurationlocationinfolist> lst_imixconfigurationlocationinfolist = new List<imixconfigurationlocationinfolist>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    //foreach (var item in lst_str)
                    //{
                    imixconfigurationlocationinfolist imixconfigurationlocationinfolist = new imixconfigurationlocationinfolist();

                    imixconfigurationlocationinfolist.Id = 1;
                 //   imixconfigurationlocationinfolist.iMixConfigurationLocationList = "";
                    imixconfigurationlocationinfolist.SubstoreId = 1;
                    imixconfigurationlocationinfolist.LocationId = 2;
                    imixconfigurationlocationinfolist.IsActive = true;

                    lst_imixconfigurationlocationinfolist.Add(imixconfigurationlocationinfolist);

                    var Id = lst_imixconfigurationlocationinfolist.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.iMixConfigurationLocationInfoLists.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.iMixConfigurationLocationInfoLists.AddRange(lst_imixconfigurationlocationinfolist);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.iMixConfigurationLocationInfoLists.AddRange(lst_imixconfigurationlocationinfolist);
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

        public static baiMixConfigurationLocationInfoList GetiMixConfigurationLocationInfoListById ( int Id )
            {
            try
                {

                imixconfigurationlocationinfolist imixconfigurationlocationinfolist = new imixconfigurationlocationinfolist();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.iMixConfigurationLocationInfoLists.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baiMixConfigurationLocationInfoList
                        {
                        Id = p.Id,
                        SubstoreId = p.SubstoreId,                       
                        LocationId = p.LocationId,
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

        public static List<baiMixConfigurationLocationInfoList> GetiMixConfigurationLocationInfoListData ()
            {
            try
                {

                //   iMIXconfigurationinfo iMIXconfigurationinfo = new iMIXconfigurationinfo();
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.iMixConfigurationLocationInfoLists.Where(p => p.IsActive == true).Select(p => new baiMixConfigurationLocationInfoList
                        {
                        Id = p.Id,
                        SubstoreId = p.SubstoreId,
                        LocationId = p.LocationId,
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

        public static bool Insert ( baiMixConfigurationLocationInfoList baiMixConfigurationLocationInfoList )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    imixconfigurationlocationinfolist imixconfigurationlocationinfolist = new imixconfigurationlocationinfolist();

                    imixconfigurationlocationinfolist.Id = baiMixConfigurationLocationInfoList.Id;
                    imixconfigurationlocationinfolist.SubstoreId = baiMixConfigurationLocationInfoList.SubstoreId;
                    imixconfigurationlocationinfolist.LocationId = baiMixConfigurationLocationInfoList.LocationId;
                    imixconfigurationlocationinfolist.IsActive = baiMixConfigurationLocationInfoList.IsActive;

                    db.iMixConfigurationLocationInfoLists.Add(imixconfigurationlocationinfolist);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baiMixConfigurationLocationInfoList baiMixConfigurationLocationInfoList )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.iMixConfigurationLocationInfoLists.Where(p => p.Id == baiMixConfigurationLocationInfoList.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        imixconfigurationlocationinfolist imixconfigurationlocationinfolist = new imixconfigurationlocationinfolist();

                        imixconfigurationlocationinfolist.Id = baiMixConfigurationLocationInfoList.Id;
                        imixconfigurationlocationinfolist.SubstoreId = baiMixConfigurationLocationInfoList.SubstoreId;
                        imixconfigurationlocationinfolist.LocationId = baiMixConfigurationLocationInfoList.LocationId;
                        imixconfigurationlocationinfolist.IsActive = baiMixConfigurationLocationInfoList.IsActive;

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
                    var obj = db.iMixConfigurationLocationInfoLists.Where(p => p.Id == Id).FirstOrDefault();
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
