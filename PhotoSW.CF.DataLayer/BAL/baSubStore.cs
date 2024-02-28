using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
{
    public class baSubStore
    {
        public int Id { get; set; }
        public int PS_SubStore_pkey { get; set; }
        public string PS_SubStore_Name { get; set; }
        public string PS_SubStore_Description { get; set; }
       
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public static bool Marge()
        {
            List<substore> lst_companydetail = new List<substore>();
            List<int> lst_str = new List<int>();
            lst_str.Add(1);
            lst_str.Add(2);
            lst_str.Add(3);

            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    foreach (var item in lst_str)
                    {
                    substore substore = new substore();

                    substore.Id = item;
                    substore.PS_SubStore_pkey = item;
                    substore.PS_SubStore_Name = "Test";
                    substore.PS_SubStore_Description = "Desc";
                    substore.SyncCode = "001";
                    substore.IsSynced = true;
                    substore.ModifiedDate = DateTime.Now;
                    substore.IsActive = true;
                    lst_companydetail.Add(substore);

                    }
                    var Id = lst_companydetail.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.SubStores.Where(p => lst_str.Contains(p.Id)).ToList();
                    if (IsExist == null)
                    {
                        db.SubStores.AddRange(lst_companydetail);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.SubStores.AddRange(lst_companydetail);
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
       // GetSubstoreNameById
        public static string GetSubstoreNameById(int SubStoreId)
        {
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SubStores.Where(p => p.Id == SubStoreId && p.IsActive == true).First().PS_SubStore_Name;
                    return obj;
                }
            }
            catch
            {
                return "";
            }
        }
        public static int GetSubstoreIdById(int SubStoreId)
        {
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SubStores.Where(p => p.Id == SubStoreId && p.IsActive == true).First().Id;
                    return obj;
                }
            }
            catch
            {
                return 0;
            }
        }


        public static baSubStore GetSubstoreData(int Substore_Id)
        {
            try
            {

                substore substore = new substore();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SubStores.Where(p => p.Id == Substore_Id && p.IsActive == true).Select(p => new baSubStore
                        {
                          Id = p.Id,
                          PS_SubStore_pkey = p.Id,
                          PS_SubStore_Name = p.PS_SubStore_Name,
                          PS_SubStore_Description = p.PS_SubStore_Description,
                          SyncCode = p.SyncCode,
                          IsSynced =p.IsSynced,
                          ModifiedDate = p.ModifiedDate,
                          IsActive = p.IsActive,

                    }).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }
        public static baSubStore GetSubstoreDataById(int Id)
        {
            try
            {

                configurationinfo configurationinfo = new configurationinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SubStores.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baSubStore
                    {
                        Id = p.Id,
                        PS_SubStore_pkey = p.Id,
                        PS_SubStore_Name = p.PS_SubStore_Name,
                        PS_SubStore_Description = p.PS_SubStore_Description,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        ModifiedDate = p.ModifiedDate,
                        IsActive = p.IsActive,

                        }).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }

        public static List<baSubStore> GetSubstoreData()
        {
            try
            {

                configurationinfo configurationinfo = new configurationinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SubStores.Where(p => p.IsActive == true).Select(p => new baSubStore
                    {
                         Id = p.Id,
                          PS_SubStore_pkey = p.Id,
                          PS_SubStore_Name = p.PS_SubStore_Name,
                          PS_SubStore_Description = p.PS_SubStore_Description,
                          SyncCode = p.SyncCode,
                          IsSynced =p.IsSynced,
                          ModifiedDate = p.ModifiedDate,
                          IsActive = p.IsActive,

                    }).ToList();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }


        public static int Insert(baSubStore baSubStore)
        {
            try
            {

                substore substore = new substore();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    
                    substore.Id = baSubStore.Id;
                    substore.PS_SubStore_pkey = baSubStore.PS_SubStore_pkey;
                    substore.PS_SubStore_Name = baSubStore.PS_SubStore_Name;
                    substore.PS_SubStore_Description = baSubStore.PS_SubStore_Description;
                    substore.SyncCode = baSubStore.SyncCode;
                    substore.IsSynced = baSubStore.IsSynced;
                    substore.ModifiedDate = baSubStore.ModifiedDate;
                    substore.IsActive = baSubStore.IsActive;
                    db.SubStores.Add(substore);
                    db.SaveChanges();
                    return (int)substore.Id;
                }
            }
            catch
            {
                return 0;
            }
        }

        public static bool Marge(baSubStore baSubStore)
        {
            try
            {


                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SubStores.Where(p => p.Id == 1).FirstOrDefault();
                    if (obj == null)
                    {
                        substore substore = new substore();
                        substore.Id = baSubStore.Id;
                        substore.PS_SubStore_pkey = baSubStore.PS_SubStore_pkey;
                        substore.PS_SubStore_Name = baSubStore.PS_SubStore_Name;
                        substore.PS_SubStore_Description = baSubStore.PS_SubStore_Description;
                        substore.SyncCode = baSubStore.SyncCode;
                        substore.IsSynced = baSubStore.IsSynced;
                        substore.ModifiedDate = baSubStore.ModifiedDate;
                        substore.IsActive = baSubStore.IsActive;
                        db.SubStores.Add(substore);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        //obj.Id = baSubStore.Id;
                        substore substore = new substore();

                        obj.Id = baSubStore.Id;
                        obj.PS_SubStore_pkey = baSubStore.PS_SubStore_pkey;
                        obj.PS_SubStore_Name = baSubStore.PS_SubStore_Name;
                        obj.PS_SubStore_Description = baSubStore.PS_SubStore_Description;
                        obj.SyncCode = baSubStore.SyncCode;
                        obj.IsSynced = baSubStore.IsSynced;
                        obj.ModifiedDate = baSubStore.ModifiedDate;
                        obj.IsActive = baSubStore.IsActive;
                        
                        db.SaveChanges();
                        return true;
                    }

                }
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete ( int Id )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SubStores.Where(p => p.Id == Id).FirstOrDefault();
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
