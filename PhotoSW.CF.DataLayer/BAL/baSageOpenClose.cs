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
 
	public class baSageOpenClose
	{
       
        public long Id { get; set; }
        public long SageInfoClosingId { get; set; }
        public long SageInfoId { get; set; }
        //public SageInfoClosing objClose { get; set; }
        //public SageInfo objOpen { get; set; }
      
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<sageopenclose> lst_sageopenclose = new List<sageopenclose>();

            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    //foreach (var item in lst_str)
                    //{
                    sageopenclose sageopenclose = new sageopenclose();

                    sageopenclose.Id = 1;
                    sageopenclose.SageInfoClosingId = sageopenclose.SageInfoClosingId;
                    sageopenclose.SageInfoId = sageopenclose.SageInfoId;

                    sageopenclose.IsActive = true;


                    lst_sageopenclose.Add(sageopenclose);
                    // }
                    var Id = lst_sageopenclose.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.SageOpenCloses.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.SageOpenCloses.AddRange(lst_sageopenclose);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.SageOpenCloses.AddRange(lst_sageopenclose);
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

        public static baSageOpenClose GetSageOpenCloseDataById(int Id)
        {
            try
            {

                sageopenclose sageopenclose = new sageopenclose();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SageOpenCloses.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baSageOpenClose
                    {
                        Id = p.Id,
                        SageInfoClosingId =p.SageInfoClosingId,
                        SageInfoId =p.SageInfoId,
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
        public static List<baSageOpenClose> GetSageOpenCloseData()
        {
            try
            {
                sageinfoclosing sageinfo = new sageinfoclosing();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SageOpenCloses.Where(p => p.IsActive == true).Select(p => new baSageOpenClose
                    {
                        Id = p.Id,
                        SageInfoClosingId = p.SageInfoClosingId,
                        SageInfoId = p.SageInfoId,
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


        public static bool Insert ( baSageOpenClose baSageOpenClose )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    sageopenclose sageopenclose = new sageopenclose();

                    sageopenclose.Id = baSageOpenClose.Id;
                    sageopenclose.SageInfoClosingId = baSageOpenClose.SageInfoClosingId;
                    sageopenclose.SageInfoId = baSageOpenClose.SageInfoId;

                    db.SageOpenCloses.Add(sageopenclose);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baSageOpenClose baSageOpenClose )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SageOpenCloses.Where(p => p.Id == baSageOpenClose.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        sageopenclose sageopenclose = new sageopenclose();

                        sageopenclose.Id = baSageOpenClose.Id;
                        sageopenclose.SageInfoClosingId = baSageOpenClose.SageInfoClosingId;
                        sageopenclose.SageInfoId = baSageOpenClose.SageInfoId;

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
                    var obj = db.SageOpenCloses.Where(p => p.Id == Id).FirstOrDefault();
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
