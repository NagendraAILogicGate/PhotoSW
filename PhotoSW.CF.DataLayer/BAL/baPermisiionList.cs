using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baPermisiionList
        {
        public long Id { get; set; }
        public bool? IsAvailable { get; set; }
        public string PermissionName { get; set; }
        public int PermissionId { get; set; }
        public bool IsActive { get; set; }

        public static bool Marge ()
            {
            List<permisiionlist> lst_permisiionlist = new List<permisiionlist>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    permisiionlist permisiionlist = new permisiionlist();

                    permisiionlist.Id = 1;
                    permisiionlist.IsAvailable = false;
                    permisiionlist.PermissionName = "";
                    permisiionlist.PermissionId = 2;
                    permisiionlist.IsActive = true;

                    lst_permisiionlist.Add(permisiionlist);

                    var Id = lst_permisiionlist.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PermisiionLists.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.PermisiionLists.AddRange(lst_permisiionlist);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.PermisiionLists.AddRange(lst_permisiionlist);
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

        public static baPermisiionList GetPermisiionListById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PermisiionLists.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPermisiionList
                        {
                        Id = p.Id,
                        IsAvailable = p.IsAvailable,
                        PermissionName = p.PermissionName,
                        PermissionId = p.PermissionId,
                       // IsActive = p.IsActive

                        }).FirstOrDefault();
                    return obj;
                    }
                }
            catch
                {
                return null; ;
                }
            }

        public static List<baPermisiionList> GetPermisiionListData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PermisiionLists.Where(p => p.IsActive == true).Select(p => new baPermisiionList
                        {
                        Id = p.Id,
                        IsAvailable = p.IsAvailable,
                        PermissionName = p.PermissionName,
                        PermissionId = p.PermissionId,
                        // IsActive = p.IsActive

                        }).ToList();
                    return obj;
                    }
                }
            catch
                {
                return null; ;
                }
            }

        public static bool Insert ( baPermisiionList baPermisiionList )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    permisiionlist permisiionlist = new permisiionlist();

                    permisiionlist.Id = baPermisiionList.Id;
                    permisiionlist.IsAvailable = baPermisiionList.IsAvailable;
                    permisiionlist.PermissionName = baPermisiionList.PermissionName;
                    permisiionlist.PermissionId = baPermisiionList.PermissionId;
                    permisiionlist.IsActive = baPermisiionList.IsActive;

                    db.PermisiionLists.Add(permisiionlist);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPermisiionList baPermisiionList )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PermisiionLists.Where(p => p.Id == baPermisiionList.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        permisiionlist permisiionlist = new permisiionlist();

                        permisiionlist.Id = baPermisiionList.Id;
                        permisiionlist.IsAvailable = baPermisiionList.IsAvailable;
                        permisiionlist.PermissionName = baPermisiionList.PermissionName;
                        permisiionlist.PermissionId = baPermisiionList.PermissionId;
                        permisiionlist.IsActive = baPermisiionList.IsActive;

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
                    var obj = db.PermisiionLists.Where(p => p.Id == Id).FirstOrDefault();
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
