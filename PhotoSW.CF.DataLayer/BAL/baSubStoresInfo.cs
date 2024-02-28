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
    public class baSubstoresInfo
	{
        public long Id { get; set; }
        public int PS_SubStore_pkey { get; set; }
        public string PS_SubStore_Name { get; set; }
        public string PS_SubStore_Description { get; set; }
        public bool PS_SubStore_IsActive { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public string PS_SubStore_Locations { get; set; }
        public bool IsLogicalSubStore { get; set; }
        public int? LogicalSubStoreID { get; set; }
        public string PS_SubStore_Code { get; set; }
        public int SiteID { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<substoresinfo> lst_substoresinfo = new List<substoresinfo>();
            List<long> lst_str = new List<long>();
            lst_str.Add(1);
            lst_str.Add(2);
            lst_str.Add(3);

            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    foreach (var item in lst_str)
                    {

                    substoresinfo substoresinfo = new substoresinfo();
                    substoresinfo.Id = 1;
                    substoresinfo.PS_SubStore_pkey =(int)item;
                    substoresinfo.PS_SubStore_Name = "Test" + item.ToString();
                    substoresinfo.PS_SubStore_Description = "Test" + item.ToString();
                    substoresinfo.PS_SubStore_IsActive = true;
                    substoresinfo.SyncCode = "00" + item.ToString();
                    substoresinfo.IsSynced = true;
                    substoresinfo.PS_SubStore_Locations = "Bhopal";
                    substoresinfo.IsLogicalSubStore = true;
                    substoresinfo.LogicalSubStoreID = 1;
                    substoresinfo.PS_SubStore_Code = "00"+ item.ToString();
                    substoresinfo.SiteID = 1;
                    substoresinfo.IsActive = true;
                    lst_substoresinfo.Add(substoresinfo);

                    }
                    var Id = lst_substoresinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.SubStoresInfos.Where(p => lst_str.Contains(p.Id)).ToList();
                    if (IsExist == null)
                    {
                        db.SubStoresInfos.AddRange(lst_substoresinfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.SubStoresInfos.AddRange(lst_substoresinfo);
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


        public static baSubstoresInfo GetStoreInfoDataById(int Id)
        {
            try
            {

                substorelocationinfo substorelocationinfo = new substorelocationinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SubStoresInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baSubstoresInfo
                    {
                        Id = p.Id,
                        PS_SubStore_pkey =p.PS_SubStore_pkey,
                        PS_SubStore_Name =p.PS_SubStore_Name,
                        PS_SubStore_Description =p.PS_SubStore_Description,
                        PS_SubStore_IsActive =p.PS_SubStore_IsActive,
                        SyncCode =p.SyncCode,
                        IsSynced =p.IsSynced,
                        PS_SubStore_Locations =p.PS_SubStore_Locations,
                        IsLogicalSubStore =p.IsLogicalSubStore,
                        LogicalSubStoreID =p.LogicalSubStoreID,
                        PS_SubStore_Code =p.PS_SubStore_Code,
                        SiteID =p.SiteID,
                        IsActive =p.IsActive

                    }).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }
        public static List<baSubstoresInfo> GetSubstoresInfoData()
        {
            try
            {

                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SubStoresInfos.Where(p => p.IsActive == true).Select(p => new baSubstoresInfo
                    {
                        Id = p.Id,
                        PS_SubStore_pkey = p.PS_SubStore_pkey,
                        PS_SubStore_Name = p.PS_SubStore_Name,
                        PS_SubStore_Description = p.PS_SubStore_Description,
                        PS_SubStore_IsActive = p.PS_SubStore_IsActive,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        PS_SubStore_Locations = p.PS_SubStore_Locations,
                        IsLogicalSubStore = p.IsLogicalSubStore,
                        LogicalSubStoreID = p.LogicalSubStoreID,
                        PS_SubStore_Code = p.PS_SubStore_Code,
                        SiteID = p.SiteID,
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


        public static bool Insert ( baSubstoresInfo baSubstoresInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    substoresinfo substoresinfo = new substoresinfo();
                    substoresinfo.Id = baSubstoresInfo.Id;
                    //substoresinfo.PS_SubStore_pkey = baSubstoresInfo.PS_SubStore_pkey;
                    substoresinfo.PS_SubStore_Name = baSubstoresInfo.PS_SubStore_Name;
                    substoresinfo.PS_SubStore_Description = baSubstoresInfo.PS_SubStore_Description;
                    substoresinfo.PS_SubStore_IsActive = baSubstoresInfo.PS_SubStore_IsActive;
                    substoresinfo.SyncCode = baSubstoresInfo.SyncCode;
                    substoresinfo.IsSynced = baSubstoresInfo.IsSynced;
                    substoresinfo.PS_SubStore_Locations = baSubstoresInfo.PS_SubStore_Locations;
                    substoresinfo.IsLogicalSubStore = baSubstoresInfo.IsLogicalSubStore;
                    substoresinfo.LogicalSubStoreID = baSubstoresInfo.LogicalSubStoreID;
                    substoresinfo.PS_SubStore_Code = baSubstoresInfo.PS_SubStore_Code;
                    substoresinfo.SiteID = baSubstoresInfo.SiteID;
                    substoresinfo.IsActive = baSubstoresInfo.IsActive;

                    db.SubStoresInfos.Add(substoresinfo);
                    db.SaveChanges();
                    
                    substoresinfo.PS_SubStore_pkey = Convert.ToInt32(baSubstoresInfo.GetSubstoresInfoData().OrderByDescending(m => m.Id).FirstOrDefault().Id);
                    db.SaveChanges();
                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baSubstoresInfo baSubstoresInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SubStoresInfos.Where(p => p.PS_SubStore_pkey == baSubstoresInfo.PS_SubStore_pkey).FirstOrDefault();
                    if(obj != null)
                        {
                        //obj.Id = baSubstoresInfo.Id;
                        //obj.PS_SubStore_pkey = baSubstoresInfo.PS_SubStore_pkey;
                        //obj.PS_SubStore_Name = baSubstoresInfo.PS_SubStore_Name;
                        //obj.PS_SubStore_Description = baSubstoresInfo.PS_SubStore_Description;
                        //obj.PS_SubStore_IsActive = baSubstoresInfo.PS_SubStore_IsActive;
                        //obj.SyncCode = baSubstoresInfo.SyncCode;
                        //obj.IsSynced = baSubstoresInfo.IsSynced;
                        //obj.PS_SubStore_Locations = baSubstoresInfo.PS_SubStore_Locations;
                        //obj.IsLogicalSubStore = baSubstoresInfo.IsLogicalSubStore;
                        //obj.LogicalSubStoreID = baSubstoresInfo.LogicalSubStoreID;
                        //obj.PS_SubStore_Code = baSubstoresInfo.PS_SubStore_Code;
                        //obj.SiteID = baSubstoresInfo.SiteID;
                        //obj.IsActive = baSubstoresInfo.IsActive;


                        obj.PS_SubStore_Name = baSubstoresInfo.PS_SubStore_Name;
                        obj.PS_SubStore_Description = baSubstoresInfo.PS_SubStore_Description;
                        obj.PS_SubStore_Code = baSubstoresInfo.PS_SubStore_Code;
                        obj.SiteID = baSubstoresInfo.SiteID;
                        obj.PS_SubStore_Locations = baSubstoresInfo.PS_SubStore_Locations;
                        obj.IsLogicalSubStore = baSubstoresInfo.IsLogicalSubStore;
                        obj.LogicalSubStoreID = baSubstoresInfo.LogicalSubStoreID;

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
                    var obj = db.SubStoresInfos.Where(p => p.Id == Id).FirstOrDefault();
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
