using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baTableBaseInfo
        {
        public int Id { get; set; }
        public string name { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<tablebaseinfo> lst_tablebaseinfo = new List<tablebaseinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    tablebaseinfo tablebaseinfo = new tablebaseinfo();

                    tablebaseinfo.Id = 1;
                    tablebaseinfo.name = "";                   
                    tablebaseinfo.IsActive = true;

                    lst_tablebaseinfo.Add(tablebaseinfo);

                    var Id = lst_tablebaseinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.TableBaseInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.TableBaseInfos.AddRange(lst_tablebaseinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.TableBaseInfos.AddRange(lst_tablebaseinfo);
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

        public static baTableBaseInfo GetTableBaseInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.TableBaseInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baTableBaseInfo
                        {
                        Id = p.Id,
                        name = p.name,                      
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

        public static List<baTableBaseInfo> GetTableBaseInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.TableBaseInfos.Where(p => p.IsActive == true).Select(p => new baTableBaseInfo
                        {
                        Id = p.Id,
                        name = p.name,
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


        public static bool Insert ( baTableBaseInfo baTableBaseInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    tablebaseinfo tablebaseinfo = new tablebaseinfo();

                    tablebaseinfo.Id = baTableBaseInfo.Id;
                    tablebaseinfo.name = baTableBaseInfo.name;
                    tablebaseinfo.IsActive = baTableBaseInfo.IsActive;

                    db.TableBaseInfos.Add(tablebaseinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baTableBaseInfo baTableBaseInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.TableBaseInfos.Where(p => p.Id == baTableBaseInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        tablebaseinfo tablebaseinfo = new tablebaseinfo();

                        tablebaseinfo.Id = baTableBaseInfo.Id;
                        tablebaseinfo.name = baTableBaseInfo.name;
                        tablebaseinfo.IsActive = baTableBaseInfo.IsActive;

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
                    var obj = db.TableBaseInfos.Where(p => p.Id == Id).FirstOrDefault();
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
