using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
     public class baMappedPos
        {
        public long Id { get; set; }
        public long ImixPOSDetailID { get; set; }
        public string SystemName { get; set; }
        public long SubStoreID { get; set; }
        public string SubStoreName { get; set; }
        public string UniqueCode { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<mappedpos> lst_mappedpos = new List<mappedpos>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    mappedpos mappedpos = new mappedpos();

                    mappedpos.Id = 1;
                    mappedpos.ImixPOSDetailID = 2;
                    mappedpos.SystemName = "";
                    mappedpos.SubStoreID = 4;
                    mappedpos.SubStoreName = "";
                    mappedpos.UniqueCode = "";
                    mappedpos.IsActive = true;

                    lst_mappedpos.Add(mappedpos);

                    var Id = lst_mappedpos.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.MappedPoses.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.MappedPoses.AddRange(lst_mappedpos);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.MappedPoses.AddRange(lst_mappedpos);
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

        public static baMappedPos GetMappedPosInfoById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.MappedPoses.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baMappedPos
                        {

                        Id = p.Id,
                        ImixPOSDetailID = p.ImixPOSDetailID,
                        SystemName = p.SystemName,
                        SubStoreID = p.SubStoreID,
                        SubStoreName = p.SubStoreName,
                        UniqueCode = p.UniqueCode,                      
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

        public static List<baMappedPos> GetMappedPosData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.MappedPoses.Where(p => p.IsActive == true).Select(p => new baMappedPos
                        {
                        Id = p.Id,
                        ImixPOSDetailID = p.ImixPOSDetailID,
                        SystemName = p.SystemName,
                        SubStoreID = p.SubStoreID,
                        SubStoreName = p.SubStoreName,
                        UniqueCode = p.UniqueCode,
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

        public static bool Insert ( baMappedPos baMappedPos )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    mappedpos mappedpos = new mappedpos();

                    mappedpos.Id = baMappedPos.Id;
                    mappedpos.ImixPOSDetailID = baMappedPos.ImixPOSDetailID;
                    mappedpos.SystemName = baMappedPos.SystemName;
                    mappedpos.SubStoreID = baMappedPos.SubStoreID;
                    mappedpos.SubStoreName = baMappedPos.SubStoreName;
                    mappedpos.UniqueCode = baMappedPos.UniqueCode;
                    mappedpos.IsActive = baMappedPos.IsActive;

                    db.MappedPoses.Add(mappedpos);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baMappedPos baMappedPos )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.MappedPoses.Where(p => p.Id == baMappedPos.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        mappedpos mappedpos = new mappedpos();

                        mappedpos.Id = baMappedPos.Id;
                        mappedpos.ImixPOSDetailID = baMappedPos.ImixPOSDetailID;
                        mappedpos.SystemName = baMappedPos.SystemName;
                        mappedpos.SubStoreID = baMappedPos.SubStoreID;
                        mappedpos.SubStoreName = baMappedPos.SubStoreName;
                        mappedpos.UniqueCode = baMappedPos.UniqueCode;
                        mappedpos.IsActive = baMappedPos.IsActive;

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
                    var obj = db.MappedPoses.Where(p => p.Id == Id).FirstOrDefault();
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
