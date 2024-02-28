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
    public class baBorderInfo
        {
        public long Id { get; set; }
        public int PS_Borders_pkey { get; set; }
        public string PS_Border { get; set; }
        public int PS_ProductTypeID { get; set; }
        public bool PS_IsActive { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public int PS_Orders_ProductType_pkey { get; set; }
        public string PS_Orders_ProductType_Name { get; set; }     
        public string FilePath { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }


        public static bool Marge ()
            {
            string path=AppDomain.CurrentDomain.BaseDirectory+"Frames\\"+"Thumbnails\\";
                var file_obj = System.IO.Directory.GetFiles(path, "*.png").Select(System.IO.Path.GetFileName);
            List<borderinfo> lst_borderinfo = new List<borderinfo>();
            List<long> lst_Ids = new List<long>();
            try
                {
                    
                    using (PhotoSWEntities db = new PhotoSWEntities())
                        {
                            int i = 0;
                            foreach (var item in file_obj)
                            {
                                borderinfo borderinfo = new borderinfo();

                                borderinfo.Id = ++i;
                                borderinfo.PS_Borders_pkey = i;
                                borderinfo.PS_Border = item;
                                borderinfo.PS_ProductTypeID = 1;
                                borderinfo.PS_IsActive = true;
                                borderinfo.SyncCode = "";
                                borderinfo.IsSynced = true;
                                borderinfo.PS_Orders_ProductType_pkey = 1;
                                borderinfo.PS_Orders_ProductType_Name = "Test";
                                borderinfo.FilePath = "Frames\\";
                                borderinfo.CreatedBy = 2;
                                borderinfo.ModifiedBy = 2;
                                borderinfo.CreatedDate = DateTime.Now;
                                borderinfo.ModifiedDate = DateTime.Now;
                                borderinfo.IsActive = true;
                                lst_Ids.Add(borderinfo.Id);
                                lst_borderinfo.Add(borderinfo);
                            }
                            //var Ids = lst_borderinfo.Where(t => lst_Ids.Contains(t.Id)).Select(t=>t.Id);
                            var IsExist = db.BorderInfos.Where(p => lst_Ids.Contains(p.Id)).ToList();
                            if (IsExist == null)
                            {
                                db.BorderInfos.AddRange(lst_borderinfo);
                                db.SaveChanges();
                            }
                            else if (IsExist.Count == 0)
                            {
                                db.BorderInfos.AddRange(lst_borderinfo);
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

        public static baBorderInfo GetBorderInfoDataById(long Id)
            {
            try
                {
                               
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.BorderInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baBorderInfo
                        {
                        Id = p.Id,
                        PS_Borders_pkey = p.PS_Borders_pkey,
                        PS_Border = p.PS_Border,
                        PS_ProductTypeID = p.PS_ProductTypeID,
                        PS_IsActive = p.PS_IsActive,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        PS_Orders_ProductType_pkey = p.PS_Orders_ProductType_pkey,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        FilePath = p.FilePath,
                        CreatedBy = p.CreatedBy,
                        ModifiedBy = p.ModifiedBy,                      
                        CreatedDate = p.CreatedDate,
                        ModifiedDate = p.ModifiedDate,                       
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

        public static List<baBorderInfo> GetBorderInfoInfoData()
            {
            try
                {
                
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.BorderInfos.Where(p => p.IsActive == true).Select(p => new baBorderInfo
                        {
                        Id = p.Id,
                        PS_Borders_pkey = p.PS_Borders_pkey,
                        PS_Border = p.PS_Border,
                        PS_ProductTypeID = p.PS_ProductTypeID,
                        PS_IsActive = p.PS_IsActive,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        PS_Orders_ProductType_pkey = p.PS_Orders_ProductType_pkey,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        FilePath = p.FilePath,
                        CreatedBy = p.CreatedBy,
                        ModifiedBy = p.ModifiedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedDate = p.ModifiedDate,
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

        public static bool Insert ( baBorderInfo baBorderInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    borderinfo borderinfo = new borderinfo();

                    borderinfo.Id = baBorderInfo.Id;
                    borderinfo.PS_Borders_pkey = baBorderInfo.PS_Borders_pkey;
                    borderinfo.PS_Border = baBorderInfo.PS_Border;
                    borderinfo.PS_ProductTypeID = baBorderInfo.PS_ProductTypeID;
                    borderinfo.PS_IsActive = baBorderInfo.PS_IsActive;
                    borderinfo.SyncCode = baBorderInfo.SyncCode;
                    borderinfo.IsSynced = baBorderInfo.IsSynced;
                    borderinfo.PS_Orders_ProductType_pkey = baBorderInfo.PS_Orders_ProductType_pkey;
                    borderinfo.PS_Orders_ProductType_Name = baBorderInfo.PS_Orders_ProductType_Name;
                    borderinfo.FilePath = baBorderInfo.FilePath;
                    borderinfo.CreatedBy = baBorderInfo.CreatedBy;
                    borderinfo.ModifiedBy = baBorderInfo.ModifiedBy;
                    borderinfo.CreatedDate = baBorderInfo.CreatedDate;
                    borderinfo.ModifiedDate = baBorderInfo.ModifiedDate;
                    borderinfo.IsActive = baBorderInfo.IsActive;
                    db.BorderInfos.Add(borderinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baBorderInfo baBorderInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.BorderInfos.Where(p => p.Id == baBorderInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        borderinfo borderinfo = new borderinfo();
                        borderinfo.Id = baBorderInfo.Id;
                        borderinfo.PS_Borders_pkey = baBorderInfo.PS_Borders_pkey;
                        borderinfo.PS_Border = baBorderInfo.PS_Border;
                        borderinfo.PS_ProductTypeID = baBorderInfo.PS_ProductTypeID;
                        borderinfo.PS_IsActive = baBorderInfo.PS_IsActive;
                        borderinfo.SyncCode = baBorderInfo.SyncCode;
                        borderinfo.IsSynced = baBorderInfo.IsSynced;
                        borderinfo.PS_Orders_ProductType_pkey = baBorderInfo.PS_Orders_ProductType_pkey;
                        borderinfo.PS_Orders_ProductType_Name = baBorderInfo.PS_Orders_ProductType_Name;
                        borderinfo.FilePath = baBorderInfo.FilePath;
                        borderinfo.CreatedBy = baBorderInfo.CreatedBy;
                        borderinfo.ModifiedBy = baBorderInfo.ModifiedBy;
                        borderinfo.CreatedDate = baBorderInfo.CreatedDate;
                        borderinfo.ModifiedDate = baBorderInfo.ModifiedDate;
                        borderinfo.IsActive = baBorderInfo.IsActive;

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
                    var obj = db.BorderInfos.Where(p => p.Id == Id).FirstOrDefault();
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

