using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
     public class baFinancialAuditTrail_Result
        {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string StoreName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ProductType { get; set; }
        public string SellPrice { get; set; }
        public int Quantity { get; set; }
        public string TotalPrice { get; set; }
        public string Discount { get; set; }
        public string revenue { get; set; }
        public string TotalOrderPrice { get; set; }
        public string PS_Order_SubStoreId { get; set; }
        public string ProductCode { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<financialaudittrail_result> lst_financialaudittrail = new List<financialaudittrail_result>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    financialaudittrail_result financialaudittrail_result = new financialaudittrail_result();

                    financialaudittrail_result.Id = 1;
                    financialaudittrail_result.UserName = "";
                    financialaudittrail_result.StoreName = "";
                    financialaudittrail_result.StartDate = DateTime.Now;
                    financialaudittrail_result.EndDate = DateTime.Now;
                    financialaudittrail_result.OrderNumber = "";
                    financialaudittrail_result.OrderDate = DateTime.Now;
                    financialaudittrail_result.ProductType = "";                    
                    financialaudittrail_result.SellPrice = "";
                    financialaudittrail_result.Quantity = 2;
                    financialaudittrail_result.TotalPrice = "";
                    financialaudittrail_result.Discount = "";
                    financialaudittrail_result.revenue = "";
                    financialaudittrail_result.TotalOrderPrice = "";
                    financialaudittrail_result.DG_Order_SubStoreId = "";
                    financialaudittrail_result.ProductCode = "";
                    financialaudittrail_result.IsActive = true;

                    lst_financialaudittrail.Add(financialaudittrail_result);

                    var Id = lst_financialaudittrail.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.FinancialAuditTrail_Results.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.FinancialAuditTrail_Results.AddRange(lst_financialaudittrail);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.FinancialAuditTrail_Results.AddRange(lst_financialaudittrail);
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

        public static baFinancialAuditTrail_Result GetFinancialAuditTrail_ResultDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.FinancialAuditTrail_Results.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baFinancialAuditTrail_Result
                        {
                        Id = p.Id,
                        UserName = p.UserName,
                        StoreName = p.StoreName,
                        StartDate = p.StartDate,
                        EndDate = p.EndDate,
                        OrderNumber = p.OrderNumber,
                        OrderDate = p.OrderDate,
                        ProductType = p.ProductType,                       
                        SellPrice = p.SellPrice,
                        Quantity = p.Quantity,
                        TotalPrice = p.TotalPrice,
                        Discount = p.Discount,
                        revenue = p.revenue,
                        TotalOrderPrice = p.TotalOrderPrice,
                        PS_Order_SubStoreId = p.DG_Order_SubStoreId,
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

        public static List<baFinancialAuditTrail_Result> GetFinancialAuditTrail_ResultData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.FinancialAuditTrail_Results.Where(p => p.IsActive == true).Select(p => new baFinancialAuditTrail_Result
                        {
                        Id = p.Id,
                        UserName = p.UserName,
                        StoreName = p.StoreName,
                        StartDate = p.StartDate,
                        EndDate = p.EndDate,
                        OrderNumber = p.OrderNumber,
                        OrderDate = p.OrderDate,
                        ProductType = p.ProductType,
                        SellPrice = p.SellPrice,
                        Quantity = p.Quantity,
                        TotalPrice = p.TotalPrice,
                        Discount = p.Discount,
                        revenue = p.revenue,
                        TotalOrderPrice = p.TotalOrderPrice,
                        PS_Order_SubStoreId = p.DG_Order_SubStoreId,
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

        public static bool Insert ( baFinancialAuditTrail_Result baFinancialAuditTrail_Result )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    financialaudittrail_result financialaudittrail_result = new financialaudittrail_result();

                    financialaudittrail_result.Id = baFinancialAuditTrail_Result.Id;
                    financialaudittrail_result.UserName = baFinancialAuditTrail_Result.UserName;
                    financialaudittrail_result.StoreName = baFinancialAuditTrail_Result.StoreName;
                    financialaudittrail_result.StartDate = baFinancialAuditTrail_Result.StartDate;
                    financialaudittrail_result.EndDate = baFinancialAuditTrail_Result.EndDate;
                    financialaudittrail_result.OrderNumber = baFinancialAuditTrail_Result.OrderNumber;
                    financialaudittrail_result.OrderDate = baFinancialAuditTrail_Result.OrderDate;
                    financialaudittrail_result.ProductType = baFinancialAuditTrail_Result.ProductType;
                    financialaudittrail_result.SellPrice = baFinancialAuditTrail_Result.SellPrice;
                    financialaudittrail_result.Quantity = baFinancialAuditTrail_Result.Quantity;
                    financialaudittrail_result.TotalPrice = baFinancialAuditTrail_Result.TotalPrice;
                    financialaudittrail_result.Discount = baFinancialAuditTrail_Result.Discount;
                    financialaudittrail_result.revenue = baFinancialAuditTrail_Result.revenue;
                    financialaudittrail_result.TotalOrderPrice = baFinancialAuditTrail_Result.TotalOrderPrice;
                    financialaudittrail_result.DG_Order_SubStoreId = baFinancialAuditTrail_Result.PS_Order_SubStoreId;
                    financialaudittrail_result.ProductCode = baFinancialAuditTrail_Result.ProductCode;
                    financialaudittrail_result.IsActive = baFinancialAuditTrail_Result.IsActive;

                    db.FinancialAuditTrail_Results.Add(financialaudittrail_result);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baFinancialAuditTrail_Result baFinancialAuditTrail_Result )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.FinancialAuditTrail_Results.Where(p => p.Id == baFinancialAuditTrail_Result.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        financialaudittrail_result financialaudittrail_result = new financialaudittrail_result();

                        financialaudittrail_result.Id = baFinancialAuditTrail_Result.Id;
                        financialaudittrail_result.UserName = baFinancialAuditTrail_Result.UserName;
                        financialaudittrail_result.StoreName = baFinancialAuditTrail_Result.StoreName;
                        financialaudittrail_result.StartDate = baFinancialAuditTrail_Result.StartDate;
                        financialaudittrail_result.EndDate = baFinancialAuditTrail_Result.EndDate;
                        financialaudittrail_result.OrderNumber = baFinancialAuditTrail_Result.OrderNumber;
                        financialaudittrail_result.OrderDate = baFinancialAuditTrail_Result.OrderDate;
                        financialaudittrail_result.ProductType = baFinancialAuditTrail_Result.ProductType;
                        financialaudittrail_result.SellPrice = baFinancialAuditTrail_Result.SellPrice;
                        financialaudittrail_result.Quantity = baFinancialAuditTrail_Result.Quantity;
                        financialaudittrail_result.TotalPrice = baFinancialAuditTrail_Result.TotalPrice;
                        financialaudittrail_result.Discount = baFinancialAuditTrail_Result.Discount;
                        financialaudittrail_result.revenue = baFinancialAuditTrail_Result.revenue;
                        financialaudittrail_result.TotalOrderPrice = baFinancialAuditTrail_Result.TotalOrderPrice;
                        financialaudittrail_result.DG_Order_SubStoreId = baFinancialAuditTrail_Result.PS_Order_SubStoreId;
                        financialaudittrail_result.ProductCode = baFinancialAuditTrail_Result.ProductCode;
                        financialaudittrail_result.IsActive = baFinancialAuditTrail_Result.IsActive;

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
                    var obj = db.FinancialAuditTrail_Results.Where(p => p.Id == Id).FirstOrDefault();
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
