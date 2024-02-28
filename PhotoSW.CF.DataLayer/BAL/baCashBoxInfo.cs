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
    public class baCashBoxInfo
        {
        public int Id { get; set; }
        public string Reason { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }      
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<cashboxinfo> lst_cashboxinfo = new List<cashboxinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    cashboxinfo burnorderinfo = new cashboxinfo();

                    burnorderinfo.Id = 1;
                    burnorderinfo.Reason = "Comment";
                    burnorderinfo.UserId = 2;
                    burnorderinfo.CreatedDate = DateTime.Now;                  
                    burnorderinfo.IsActive = true;
                    
                    lst_cashboxinfo.Add(burnorderinfo);

                    var Id = lst_cashboxinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.CashBoxInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.CashBoxInfos.AddRange(lst_cashboxinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.CashBoxInfos.AddRange(lst_cashboxinfo);
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

        public static baCashBoxInfo GetCashBoxInfoDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.CashBoxInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baCashBoxInfo
                        {
                        Id = p.Id,
                        Reason = p.Reason,
                        UserId = p.UserId,
                        CreatedDate = p.CreatedDate,                      
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

        public static List<baCashBoxInfo> GetBurnOrderInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.CashBoxInfos.Where(p => p.IsActive == true).Select(p => new baCashBoxInfo
                        {
                        Id = p.Id,
                        Reason = p.Reason,
                        UserId = p.UserId,
                        CreatedDate = p.CreatedDate,                        
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

        public static bool Insert(baCashBoxInfo baCashBoxInfo)
        {
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    cashboxinfo cashboxinfo = new cashboxinfo();
                    
                    cashboxinfo.Reason = baCashBoxInfo.Reason;
                    cashboxinfo.UserId = baCashBoxInfo.UserId;
                    cashboxinfo.CreatedDate = baCashBoxInfo.CreatedDate;
                    cashboxinfo.IsActive = baCashBoxInfo.IsActive;
                    db.CashBoxInfos.Add(cashboxinfo);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool Update(baCashBoxInfo baCashBoxInfo)
        {
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.CashBoxInfos.Where(p => p.Id == baCashBoxInfo.Id).FirstOrDefault();
                    if (obj != null)
                    {
                        cashboxinfo cashboxinfo = new cashboxinfo();
                        cashboxinfo.Id = baCashBoxInfo.Id;
                        cashboxinfo.Reason = baCashBoxInfo.Reason;
                        cashboxinfo.UserId = baCashBoxInfo.UserId;
                        cashboxinfo.CreatedDate = baCashBoxInfo.CreatedDate;
                        cashboxinfo.IsActive = baCashBoxInfo.IsActive;
                        
                        db.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
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
                    var obj = db.CashBoxInfos.Where(p => p.Id == Id).FirstOrDefault();
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
