using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baPrintSummaryDetail
        {
        public int Id { get; set; }
        public string SaleType { get; set; }
        public string PhotoNumbers { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<printsummarydetail> lst_printsummarydetail = new List<printsummarydetail>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    printsummarydetail printsummarydetail = new printsummarydetail();

                    printsummarydetail.Id = 1;
                    printsummarydetail.SaleType = "";
                    printsummarydetail.PhotoNumbers = "";
                    printsummarydetail.IsActive = true;

                    lst_printsummarydetail.Add(printsummarydetail);

                    var Id = lst_printsummarydetail.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PrintSummaryDetails.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.PrintSummaryDetails.AddRange(lst_printsummarydetail);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.PrintSummaryDetails.AddRange(lst_printsummarydetail);
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

        public static baPrintSummaryDetail GetPrintSummaryDetailDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrintSummaryDetails.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPrintSummaryDetail
                        {
                        Id = p.Id,
                        SaleType = p.SaleType,
                        PhotoNumbers = p.PhotoNumbers,
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

        public static List<baPrintSummaryDetail> GetPrintSummaryDetailData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrintSummaryDetails.Where(p => p.IsActive == true).Select(p => new baPrintSummaryDetail
                        {
                        Id = p.Id,
                        SaleType = p.SaleType,
                        PhotoNumbers = p.PhotoNumbers,
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

        public static bool Insert ( baPrintSummaryDetail baPrintSummaryDetail )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    printsummarydetail printsummarydetail = new printsummarydetail();

                    printsummarydetail.Id = baPrintSummaryDetail.Id;
                    printsummarydetail.SaleType = baPrintSummaryDetail.SaleType;
                    printsummarydetail.PhotoNumbers = baPrintSummaryDetail.PhotoNumbers;
                    printsummarydetail.IsActive = baPrintSummaryDetail.IsActive;

                    db.PrintSummaryDetails.Add(printsummarydetail);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPrintSummaryDetail baPrintSummaryDetail )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PrintSummaryDetails.Where(p => p.Id == baPrintSummaryDetail.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        printsummarydetail printsummarydetail = new printsummarydetail();

                        printsummarydetail.Id = baPrintSummaryDetail.Id;
                        printsummarydetail.SaleType = baPrintSummaryDetail.SaleType;
                        printsummarydetail.PhotoNumbers = baPrintSummaryDetail.PhotoNumbers;
                        printsummarydetail.IsActive = baPrintSummaryDetail.IsActive;

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
                    var obj = db.PrintSummaryDetails.Where(p => p.Id == Id).FirstOrDefault();
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
