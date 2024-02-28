using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baGroupDetails
        {
        public long Id { get; set; }
        public int PS_Group_pkey { get; set; }
        public string PS_Group_Name { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public int OperationType { get; set; }
        public string PS_ProductCode { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<groupdetails> lst_groupdetails = new List<groupdetails>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    groupdetails groupdetails = new groupdetails();

                    groupdetails.Id = 1;
                    groupdetails.PS_Group_pkey = 2;
                    groupdetails.PS_Group_Name = "Test";
                    groupdetails.SyncCode = "";
                    groupdetails.IsSynced = false;                   
                    groupdetails.OperationType = 1;
                    groupdetails.PS_ProductCode = "";
                    groupdetails.IsActive = true;

                    lst_groupdetails.Add(groupdetails);

                    var Id = lst_groupdetails.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.GroupDetailses.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.GroupDetailses.AddRange(lst_groupdetails);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.GroupDetailses.AddRange(lst_groupdetails);
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

        public static baGroupDetails GetGroupDetailsDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.GroupDetailses.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baGroupDetails
                        {
                        Id = p.Id,
                        PS_Group_pkey = p.PS_Group_pkey,
                        PS_Group_Name = p.PS_Group_Name,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        OperationType = p.OperationType,
                        PS_ProductCode = p.PS_ProductCode,                       
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

        public static List<baGroupDetails> GetGroupDetailsData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GroupDetailses.Where(p => p.IsActive == true).Select(p => new baGroupDetails
                        {
                        Id = p.Id,
                        PS_Group_pkey = p.PS_Group_pkey,
                        PS_Group_Name = p.PS_Group_Name,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        OperationType = p.OperationType,
                        PS_ProductCode = p.PS_ProductCode,
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

        public static bool Insert ( baGroupDetails baGroupDetails )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    groupdetails groupdetails = new groupdetails();

                    groupdetails.Id = baGroupDetails.Id;
                    groupdetails.PS_Group_pkey = baGroupDetails.PS_Group_pkey;
                    groupdetails.PS_Group_Name = baGroupDetails.PS_Group_Name;
                    groupdetails.SyncCode = baGroupDetails.SyncCode;
                    groupdetails.IsSynced = baGroupDetails.IsSynced;
                    groupdetails.OperationType = baGroupDetails.OperationType;
                    groupdetails.PS_ProductCode = baGroupDetails.PS_ProductCode;
                    groupdetails.IsActive = baGroupDetails.IsActive;

                    db.GroupDetailses.Add(groupdetails);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baGroupDetails baGroupDetails )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GroupDetailses.Where(p => p.Id == baGroupDetails.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        groupdetails groupdetails = new groupdetails();

                        groupdetails.Id = baGroupDetails.Id;
                        groupdetails.PS_Group_pkey = baGroupDetails.PS_Group_pkey;
                        groupdetails.PS_Group_Name = baGroupDetails.PS_Group_Name;
                        groupdetails.SyncCode = baGroupDetails.SyncCode;
                        groupdetails.IsSynced = baGroupDetails.IsSynced;
                        groupdetails.OperationType = baGroupDetails.OperationType;
                        groupdetails.PS_ProductCode = baGroupDetails.PS_ProductCode;
                        groupdetails.IsActive = baGroupDetails.IsActive;

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
                    var obj = db.GroupDetailses.Where(p => p.Id == Id).FirstOrDefault();
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
