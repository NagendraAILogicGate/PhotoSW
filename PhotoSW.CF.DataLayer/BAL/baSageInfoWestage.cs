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
	public class baSageInfoWestage
    {
        public long Id { get; set; }
        public int ProductType { get; set; }
        public long Printed { get; set; }
        public int Reprint { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<sageinfowestage> lst_sageinfowestage = new List<sageinfowestage>();

            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    //foreach (var item in lst_str)
                    //{
                    sageinfowestage sageinfowestage = new sageinfowestage();

                    sageinfowestage.Id = 1;
                    sageinfowestage.ProductType = 1;
                    sageinfowestage.Printed = 1;
                    sageinfowestage.Reprint = 1;

                    sageinfowestage.IsActive = true;


                    lst_sageinfowestage.Add(sageinfowestage);
                    // }
                    var Id = lst_sageinfowestage.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.SageInfoWestages.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.SageInfoWestages.AddRange(lst_sageinfowestage);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.SageInfoWestages.AddRange(lst_sageinfowestage);
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

        public static baSageInfoWestage GetSageInfoWestageDataById(int Id)
        {
            try
            {

                sageinfoclosing sageinfoclosing = new sageinfoclosing();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SageInfoWestages.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baSageInfoWestage
                    {
                        Id = p.Id,
                        ProductType =p.ProductType,
                        Printed =p.Printed,
                        Reprint =p.Reprint,

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
        public static List<baSageInfoWestage> GetSageInfoWestageData()
        {
            try
            {
                sageinfoclosing sageinfo = new sageinfoclosing();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SageInfoWestages.Where(p => p.IsActive == true).Select(p => new baSageInfoWestage
                    {
                        Id = p.Id,
                        ProductType = p.ProductType,
                        Printed = p.Printed,
                        Reprint = p.Reprint,
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

        public static bool Insert ( baSageInfoWestage baSageInfoWestage )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    sageinfowestage sageinfowestage = new sageinfowestage();

                    sageinfowestage.Id = sageinfowestage.Id;
                    sageinfowestage.ProductType = sageinfowestage.ProductType;
                    sageinfowestage.Printed = sageinfowestage.Printed;
                    sageinfowestage.Reprint = sageinfowestage.Reprint;
                    sageinfowestage.IsActive = sageinfowestage.IsActive;

                    db.SageInfoWestages.Add(sageinfowestage);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baSageInfoWestage baSageInfoWestage )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SageInfoWestages.Where(p => p.Id == baSageInfoWestage.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        sageinfowestage sageinfowestage = new sageinfowestage();

                        sageinfowestage.Id = sageinfowestage.Id;
                        sageinfowestage.ProductType = sageinfowestage.ProductType;
                        sageinfowestage.Printed = sageinfowestage.Printed;
                        sageinfowestage.Reprint = sageinfowestage.Reprint;
                        sageinfowestage.IsActive = sageinfowestage.IsActive;

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
                    var obj = db.SageInfoWestages.Where(p => p.Id == Id).FirstOrDefault();
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
