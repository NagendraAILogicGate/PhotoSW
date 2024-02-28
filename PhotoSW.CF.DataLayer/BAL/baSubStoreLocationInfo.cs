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
	public class baSubstoreLocationInfo
    {
        public long Id { get; set; }
        public int SubStore_Location_Pkey { get; set; }
        public int SubStore_ID { get; set; }
        public int Location_ID { get; set; }
        public string Location_Name { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<substorelocationinfo> lst_substorelocationinfo = new List<substorelocationinfo>();
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    //foreach (var item in lst_str)
                    //{
                    substorelocationinfo substorelocationinfo = new substorelocationinfo();

                    substorelocationinfo.SubStore_Location_Pkey = 1;
                    substorelocationinfo.SubStore_ID = 1;
                    substorelocationinfo.Location_ID = 1;
                    substorelocationinfo.Location_Name = "";
                    substorelocationinfo.IsActive = true;
                    lst_substorelocationinfo.Add(substorelocationinfo);

                    // }
                    var Id = lst_substorelocationinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.SubStoreLocationInfos.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.SubStoreLocationInfos.AddRange(lst_substorelocationinfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.SubStoreLocationInfos.AddRange(lst_substorelocationinfo);
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

        public static baSubstoreLocationInfo GetStoreInfoDataById(int Id)
        {
            try
            {

                substorelocationinfo substorelocationinfo = new substorelocationinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SubStoreLocationInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baSubstoreLocationInfo
                    {
                        Id = p.Id,
                        SubStore_Location_Pkey =p.SubStore_Location_Pkey,
                        SubStore_ID =p.SubStore_ID,
                        Location_ID =p.Location_ID,
                        Location_Name =p.Location_Name,
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
        public static List<baSubstoreLocationInfo> GetSubstoreLocationCloseData()
        {
            try
            {

                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SubStoreLocationInfos.Where(p => p.IsActive == true).Select(p => new baSubstoreLocationInfo
                    {
                        Id = p.Id,
                        SubStore_Location_Pkey = p.SubStore_Location_Pkey,
                        SubStore_ID = p.SubStore_ID,
                        Location_ID = p.Location_ID,
                        Location_Name = p.Location_Name,
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

        public static bool Insert ( baSubstoreLocationInfo baSubstoreLocationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    substorelocationinfo substorelocationinfo = new substorelocationinfo();
                    substorelocationinfo.Id = baSubstoreLocationInfo.Id;
                    substorelocationinfo.SubStore_Location_Pkey = baSubstoreLocationInfo.SubStore_Location_Pkey;
                    substorelocationinfo.SubStore_ID = baSubstoreLocationInfo.SubStore_ID;
                    substorelocationinfo.Location_ID = baSubstoreLocationInfo.Location_ID;
                    substorelocationinfo.Location_Name = baSubstoreLocationInfo.Location_Name;
                    substorelocationinfo.IsActive = baSubstoreLocationInfo.IsActive;

                    db.SubStoreLocationInfos.Add(substorelocationinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baSubstoreLocationInfo baSubstoreLocationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SubStoreLocationInfos.Where(p => p.Id == baSubstoreLocationInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        substorelocationinfo substorelocationinfo = new substorelocationinfo();
                        substorelocationinfo.Id = baSubstoreLocationInfo.Id;
                        substorelocationinfo.SubStore_Location_Pkey = baSubstoreLocationInfo.SubStore_Location_Pkey;
                        substorelocationinfo.SubStore_ID = baSubstoreLocationInfo.SubStore_ID;
                        substorelocationinfo.Location_ID = baSubstoreLocationInfo.Location_ID;
                        substorelocationinfo.Location_Name = baSubstoreLocationInfo.Location_Name;
                        substorelocationinfo.IsActive = baSubstoreLocationInfo.IsActive;

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
                    var obj = db.SubStoreLocationInfos.Where(p => p.Id == Id).FirstOrDefault();
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
