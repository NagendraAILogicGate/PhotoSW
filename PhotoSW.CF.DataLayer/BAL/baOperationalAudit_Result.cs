using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baOperationalAudit_Result
        {
        public long Id { get; set; }
        public int PS_Orders_pkey { get; set; }
        public string PS_Orders_Number { get; set; }
        public string Location { get; set; }
        public string PhotoID { get; set; }
        public int Qty { get; set; }
        public string PhotoGrapher { get; set; }
        public string ProductType { get; set; }
        public string SubstoreName { get; set; }
        public string ProductCode { get; set; }
        public bool? IsActive { get; set; }


        public static bool Marge ()
            {
            List<operationalaudit_result> lst_operationalaudit = new List<operationalaudit_result>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    operationalaudit_result operationalaudit_result = new operationalaudit_result();

                    operationalaudit_result.Id = 1;
                    operationalaudit_result.PS_Orders_pkey = 2;
                    operationalaudit_result.PS_Orders_Number = "";
                    operationalaudit_result.Location = "";
                    operationalaudit_result.PhotoID = "";
                    operationalaudit_result.Qty = 3;
                    operationalaudit_result.PhotoGrapher = "";
                    operationalaudit_result.ProductType = "";
                    operationalaudit_result.SubstoreName = "";
                    operationalaudit_result.ProductCode = "";
                    operationalaudit_result.IsActive = true;

                    lst_operationalaudit.Add(operationalaudit_result);

                    var Id = lst_operationalaudit.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.OperationalAudit_Results.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.OperationalAudit_Results.AddRange(lst_operationalaudit);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.OperationalAudit_Results.AddRange(lst_operationalaudit);
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

        public static baOperationalAudit_Result GetOperationalAudit_ResultById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OperationalAudit_Results.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baOperationalAudit_Result
                        {

                        Id = p.Id,
                        PS_Orders_pkey = p.PS_Orders_pkey,
                        PS_Orders_Number = p.PS_Orders_Number,
                        Location = p.Location,
                        PhotoID = p.PhotoID,
                        Qty = p.Qty,
                        PhotoGrapher = p.PhotoGrapher,
                        ProductType = p.ProductType,
                        SubstoreName = p.SubstoreName,
                        ProductCode = p.ProductCode,
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

        public static List<baOperationalAudit_Result> GetOperationalAudit_ResultData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OperationalAudit_Results.Where(p => p.IsActive == true).Select(p => new baOperationalAudit_Result
                        {
                        Id = p.Id,
                        PS_Orders_pkey = p.PS_Orders_pkey,
                        PS_Orders_Number = p.PS_Orders_Number,
                        Location = p.Location,
                        PhotoID = p.PhotoID,
                        Qty = p.Qty,
                        PhotoGrapher = p.PhotoGrapher,
                        ProductType = p.ProductType,
                        SubstoreName = p.SubstoreName,
                        ProductCode = p.ProductCode,
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

        public static bool Insert ( baOperationalAudit_Result baOperationalAudit_Result )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    operationalaudit_result operationalaudit_result = new operationalaudit_result();

                    operationalaudit_result.Id = baOperationalAudit_Result.Id;
                    operationalaudit_result.PS_Orders_pkey = baOperationalAudit_Result.PS_Orders_pkey;
                    operationalaudit_result.PS_Orders_Number = baOperationalAudit_Result.PS_Orders_Number;
                    operationalaudit_result.Location = baOperationalAudit_Result.Location;
                    operationalaudit_result.PhotoID = baOperationalAudit_Result.PhotoID;
                    operationalaudit_result.Qty = baOperationalAudit_Result.Qty;
                    operationalaudit_result.PhotoGrapher = baOperationalAudit_Result.PhotoGrapher;
                    operationalaudit_result.ProductType = baOperationalAudit_Result.ProductType;
                    operationalaudit_result.SubstoreName = baOperationalAudit_Result.SubstoreName;
                    operationalaudit_result.ProductCode = baOperationalAudit_Result.ProductCode;
                    operationalaudit_result.IsActive = baOperationalAudit_Result.IsActive;

                    db.OperationalAudit_Results.Add(operationalaudit_result);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baOperationalAudit_Result baOperationalAudit_Result )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OperationalAudit_Results.Where(p => p.Id == baOperationalAudit_Result.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        operationalaudit_result operationalaudit_result = new operationalaudit_result();

                        operationalaudit_result.Id = baOperationalAudit_Result.Id;
                        operationalaudit_result.PS_Orders_pkey = baOperationalAudit_Result.PS_Orders_pkey;
                        operationalaudit_result.PS_Orders_Number = baOperationalAudit_Result.PS_Orders_Number;
                        operationalaudit_result.Location = baOperationalAudit_Result.Location;
                        operationalaudit_result.PhotoID = baOperationalAudit_Result.PhotoID;
                        operationalaudit_result.Qty = baOperationalAudit_Result.Qty;
                        operationalaudit_result.PhotoGrapher = baOperationalAudit_Result.PhotoGrapher;
                        operationalaudit_result.ProductType = baOperationalAudit_Result.ProductType;
                        operationalaudit_result.SubstoreName = baOperationalAudit_Result.SubstoreName;
                        operationalaudit_result.ProductCode = baOperationalAudit_Result.ProductCode;
                        operationalaudit_result.IsActive = baOperationalAudit_Result.IsActive;

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
                    var obj = db.OperationalAudit_Results.Where(p => p.Id == Id).FirstOrDefault();
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
