using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baTaxDetailInfo
        {
        public int Id { get; set; }
        public int TaxId { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TaxPercentage { get; set; }
        public string TaxName { get; set; }
        public string CurrencyName { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<taxdetailinfo> lst_taxdetailinfo = new List<taxdetailinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    taxdetailinfo taxdetailinfo = new taxdetailinfo();

                    taxdetailinfo.Id = 1;
                    taxdetailinfo.TaxId = 5;
                    taxdetailinfo.TaxAmount = 5;
                    taxdetailinfo.TaxPercentage = 5;
                    taxdetailinfo.TaxName = "";
                    taxdetailinfo.CurrencyName = "";
                    taxdetailinfo.IsActive = true;

                    lst_taxdetailinfo.Add(taxdetailinfo);

                    var Id = lst_taxdetailinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.TaxDetailInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.TaxDetailInfos.AddRange(lst_taxdetailinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.TaxDetailInfos.AddRange(lst_taxdetailinfo);
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

        public static baTaxDetailInfo GetTaxDetailInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.TaxDetailInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baTaxDetailInfo
                        {
                        Id = p.Id,
                        TaxId = p.TaxId,
                        TaxAmount = p.TaxAmount,
                        TaxPercentage = p.TaxPercentage,
                        TaxName = p.TaxName,
                        CurrencyName = p.CurrencyName,
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

        public static List<baTaxDetailInfo> GetTaxDetailInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.TaxDetailInfos.Where(p => p.IsActive == true).Select(p => new baTaxDetailInfo
                        {
                        Id = p.Id,
                        TaxId = p.TaxId,
                        TaxAmount = p.TaxAmount,
                        TaxPercentage = p.TaxPercentage,
                        TaxName = p.TaxName,
                        CurrencyName = p.CurrencyName,
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


        public static bool Insert ( baTaxDetailInfo baTaxDetailInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    taxdetailinfo taxdetailinfo = new taxdetailinfo();

                    taxdetailinfo.Id = baTaxDetailInfo.Id;
                    taxdetailinfo.TaxId = baTaxDetailInfo.TaxId;
                    taxdetailinfo.TaxAmount = baTaxDetailInfo.TaxAmount;
                    taxdetailinfo.TaxPercentage = baTaxDetailInfo.TaxPercentage;
                    taxdetailinfo.TaxName = baTaxDetailInfo.TaxName;
                    taxdetailinfo.CurrencyName = baTaxDetailInfo.CurrencyName;
                    taxdetailinfo.IsActive = baTaxDetailInfo.IsActive;

                    db.TaxDetailInfos.Add(taxdetailinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baTaxDetailInfo baTaxDetailInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.TaxDetailInfos.Where(p => p.Id == baTaxDetailInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        taxdetailinfo taxdetailinfo = new taxdetailinfo();

                        taxdetailinfo.Id = baTaxDetailInfo.Id;
                        taxdetailinfo.TaxId = baTaxDetailInfo.TaxId;
                        taxdetailinfo.TaxAmount = baTaxDetailInfo.TaxAmount;
                        taxdetailinfo.TaxPercentage = baTaxDetailInfo.TaxPercentage;
                        taxdetailinfo.TaxName = baTaxDetailInfo.TaxName;
                        taxdetailinfo.CurrencyName = baTaxDetailInfo.CurrencyName;
                        taxdetailinfo.IsActive = baTaxDetailInfo.IsActive;

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
                    var obj = db.TaxDetailInfos.Where(p => p.Id == Id).FirstOrDefault();
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
