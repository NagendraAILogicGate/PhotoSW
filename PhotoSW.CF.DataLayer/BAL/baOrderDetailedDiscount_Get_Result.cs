using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baOrderDetailedDiscount_Get_Result
        {
        public long Id { get; set; }
        public int PS_Orders_pkey { get; set; }
        public string PS_Orders_Number { get; set; }
        public DateTime PS_Orders_Date { get; set; }
        public int? OrderDetailId { get; set; }
        public decimal? PS_Orders_LineItems_DiscountAmount { get; set; }
        public decimal? PS_Orders_Details_Items_UniPrice { get; set; }
        public decimal? PS_Orders_Details_Items_TotalCost { get; set; }
        public decimal? PS_Orders_Details_Items_NetPrice { get; set; }
        public decimal? PS_Orders_Cost { get; set; }
        public decimal? PS_Orders_NetCost { get; set; }
        public double? PS_Orders_Total_Discount { get; set; }
        public string PS_Orders_ProductType_Name { get; set; }
        public string PS_Orders_ProductCode { get; set; }
        public string Discount { get; set; }
        public string Value { get; set; }
        public bool InPercentmode { get; set; }
        public string StoreName { get; set; }
        public string USerName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public double ActualValue { get; set; }
        public string TotalOrderDiscountDetails { get; set; }
        public decimal TotalLineItemDiscount { get; set; }
        public int Quantity { get; set; }
        public string PhotNumber { get; set; }
        public bool? IsActive { get; set; }


        public static bool Marge ()
            {
            List<orderdetaileddiscount_get_result> lst_orderdetaileddiscount = new List<orderdetaileddiscount_get_result>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    orderdetaileddiscount_get_result orderdetaileddiscount_get_result = new orderdetaileddiscount_get_result();

                    orderdetaileddiscount_get_result.Id = 1;
                    orderdetaileddiscount_get_result.PS_Orders_pkey = 2;
                    orderdetaileddiscount_get_result.PS_Orders_Number = "";
                    orderdetaileddiscount_get_result.PS_Orders_Date = DateTime.Now;
                    orderdetaileddiscount_get_result.OrderDetailId = 5;
                    orderdetaileddiscount_get_result.PS_Orders_LineItems_DiscountAmount = 4;
                    orderdetaileddiscount_get_result.PS_Orders_Details_Items_UniPrice = 5;
                    orderdetaileddiscount_get_result.PS_Orders_Details_Items_TotalCost = 5;
                    orderdetaileddiscount_get_result.PS_Orders_Details_Items_NetPrice = 4;
                    orderdetaileddiscount_get_result.PS_Orders_Cost = 6;
                    orderdetaileddiscount_get_result.PS_Orders_NetCost = 4;
                    orderdetaileddiscount_get_result.PS_Orders_Total_Discount = 7;
                    orderdetaileddiscount_get_result.PS_Orders_ProductType_Name = "";
                    orderdetaileddiscount_get_result.PS_Orders_ProductCode = "";
                    orderdetaileddiscount_get_result.Discount = "";
                    orderdetaileddiscount_get_result.Value = "";
                    orderdetaileddiscount_get_result.InPercentmode = false;
                    orderdetaileddiscount_get_result.StoreName = "";
                    orderdetaileddiscount_get_result.USerName = "";
                    orderdetaileddiscount_get_result.FromDate = DateTime.Now;
                    orderdetaileddiscount_get_result.ToDate = DateTime.Now;
                    orderdetaileddiscount_get_result.ActualValue = 4;
                    orderdetaileddiscount_get_result.TotalOrderDiscountDetails = "";
                    orderdetaileddiscount_get_result.TotalLineItemDiscount = 5;
                    orderdetaileddiscount_get_result.Quantity = 2;
                    orderdetaileddiscount_get_result.PhotNumber = "";
                    orderdetaileddiscount_get_result.IsActive = true;

                    lst_orderdetaileddiscount.Add(orderdetaileddiscount_get_result);

                    var Id = lst_orderdetaileddiscount.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.OrderDetailedDiscount_Get_Results.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.OrderDetailedDiscount_Get_Results.AddRange(lst_orderdetaileddiscount);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.OrderDetailedDiscount_Get_Results.AddRange(lst_orderdetaileddiscount);
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

        public static baOrderDetailedDiscount_Get_Result GetOrderDetailedDiscount_Get_ResultById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderDetailedDiscount_Get_Results.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baOrderDetailedDiscount_Get_Result
                        {

                        Id = p.Id,
                        PS_Orders_pkey = p.PS_Orders_pkey,
                        PS_Orders_Number = p.PS_Orders_Number,
                        PS_Orders_Date = p.PS_Orders_Date,
                        OrderDetailId = p.OrderDetailId,
                        PS_Orders_LineItems_DiscountAmount = p.PS_Orders_LineItems_DiscountAmount,
                        PS_Orders_Details_Items_UniPrice = p.PS_Orders_Details_Items_UniPrice,
                        PS_Orders_Details_Items_TotalCost = p.PS_Orders_Details_Items_TotalCost,
                        PS_Orders_Details_Items_NetPrice = p.PS_Orders_Details_Items_NetPrice,
                        PS_Orders_Cost = p.PS_Orders_Cost,
                        PS_Orders_NetCost = p.PS_Orders_NetCost,
                        PS_Orders_Total_Discount = p.PS_Orders_Total_Discount,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        PS_Orders_ProductCode = p.PS_Orders_ProductCode,
                        Discount = p.Discount,
                        Value = p.Value,
                        InPercentmode = p.InPercentmode,
                        StoreName = p.StoreName,
                        USerName = p.USerName,
                        FromDate = p.FromDate,
                        ToDate = p.ToDate,
                        ActualValue = p.ActualValue,
                        TotalOrderDiscountDetails = p.TotalOrderDiscountDetails,
                        TotalLineItemDiscount = p.TotalLineItemDiscount,
                        Quantity = p.Quantity,
                        PhotNumber = p.PhotNumber,
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

        public static List<baOrderDetailedDiscount_Get_Result> GetOrderDetailedDiscount_Get_ResultData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderDetailedDiscount_Get_Results.Where(p => p.IsActive == true).Select(p => new baOrderDetailedDiscount_Get_Result
                        {
                        Id = p.Id,
                        PS_Orders_pkey = p.PS_Orders_pkey,
                        PS_Orders_Number = p.PS_Orders_Number,
                        PS_Orders_Date = p.PS_Orders_Date,
                        OrderDetailId = p.OrderDetailId,
                        PS_Orders_LineItems_DiscountAmount = p.PS_Orders_LineItems_DiscountAmount,
                        PS_Orders_Details_Items_UniPrice = p.PS_Orders_Details_Items_UniPrice,
                        PS_Orders_Details_Items_TotalCost = p.PS_Orders_Details_Items_TotalCost,
                        PS_Orders_Details_Items_NetPrice = p.PS_Orders_Details_Items_NetPrice,
                        PS_Orders_Cost = p.PS_Orders_Cost,
                        PS_Orders_NetCost = p.PS_Orders_NetCost,
                        PS_Orders_Total_Discount = p.PS_Orders_Total_Discount,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        PS_Orders_ProductCode = p.PS_Orders_ProductCode,
                        Discount = p.Discount,
                        Value = p.Value,
                        InPercentmode = p.InPercentmode,
                        StoreName = p.StoreName,
                        USerName = p.USerName,
                        FromDate = p.FromDate,
                        ToDate = p.ToDate,
                        ActualValue = p.ActualValue,
                        TotalOrderDiscountDetails = p.TotalOrderDiscountDetails,
                        TotalLineItemDiscount = p.TotalLineItemDiscount,
                        Quantity = p.Quantity,
                        PhotNumber = p.PhotNumber,
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

        public static bool Insert ( baOrderDetailedDiscount_Get_Result baOrderDetailedDiscount_Get_Result )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    orderdetaileddiscount_get_result orderdetaileddiscount_get_result = new orderdetaileddiscount_get_result();

                    orderdetaileddiscount_get_result.Id = baOrderDetailedDiscount_Get_Result.Id;
                    orderdetaileddiscount_get_result.PS_Orders_pkey = baOrderDetailedDiscount_Get_Result.PS_Orders_pkey;
                    orderdetaileddiscount_get_result.PS_Orders_Number = baOrderDetailedDiscount_Get_Result.PS_Orders_Number;
                    orderdetaileddiscount_get_result.PS_Orders_Date = baOrderDetailedDiscount_Get_Result.PS_Orders_Date;
                    orderdetaileddiscount_get_result.OrderDetailId = baOrderDetailedDiscount_Get_Result.OrderDetailId;
                    orderdetaileddiscount_get_result.PS_Orders_LineItems_DiscountAmount = baOrderDetailedDiscount_Get_Result.PS_Orders_LineItems_DiscountAmount;
                    orderdetaileddiscount_get_result.PS_Orders_Details_Items_UniPrice = baOrderDetailedDiscount_Get_Result.PS_Orders_Details_Items_UniPrice;
                    orderdetaileddiscount_get_result.PS_Orders_Details_Items_TotalCost = baOrderDetailedDiscount_Get_Result.PS_Orders_Details_Items_TotalCost;
                    orderdetaileddiscount_get_result.PS_Orders_Details_Items_NetPrice = baOrderDetailedDiscount_Get_Result.PS_Orders_Details_Items_NetPrice;
                    orderdetaileddiscount_get_result.PS_Orders_Cost = baOrderDetailedDiscount_Get_Result.PS_Orders_Cost;
                    orderdetaileddiscount_get_result.PS_Orders_NetCost = baOrderDetailedDiscount_Get_Result.PS_Orders_NetCost;
                    orderdetaileddiscount_get_result.PS_Orders_Total_Discount = baOrderDetailedDiscount_Get_Result.PS_Orders_Total_Discount;
                    orderdetaileddiscount_get_result.PS_Orders_ProductType_Name = baOrderDetailedDiscount_Get_Result.PS_Orders_ProductType_Name;
                    orderdetaileddiscount_get_result.PS_Orders_ProductCode = baOrderDetailedDiscount_Get_Result.PS_Orders_ProductCode;
                    orderdetaileddiscount_get_result.Discount = baOrderDetailedDiscount_Get_Result.Discount;
                    orderdetaileddiscount_get_result.Value = baOrderDetailedDiscount_Get_Result.Value;
                    orderdetaileddiscount_get_result.InPercentmode = baOrderDetailedDiscount_Get_Result.InPercentmode;
                    orderdetaileddiscount_get_result.StoreName = baOrderDetailedDiscount_Get_Result.StoreName;
                    orderdetaileddiscount_get_result.USerName = baOrderDetailedDiscount_Get_Result.USerName;
                    orderdetaileddiscount_get_result.FromDate = baOrderDetailedDiscount_Get_Result.FromDate;
                    orderdetaileddiscount_get_result.ToDate = baOrderDetailedDiscount_Get_Result.ToDate;
                    orderdetaileddiscount_get_result.ActualValue = baOrderDetailedDiscount_Get_Result.ActualValue;
                    orderdetaileddiscount_get_result.TotalOrderDiscountDetails = baOrderDetailedDiscount_Get_Result.TotalOrderDiscountDetails;
                    orderdetaileddiscount_get_result.TotalLineItemDiscount = baOrderDetailedDiscount_Get_Result.TotalLineItemDiscount;
                    orderdetaileddiscount_get_result.Quantity = baOrderDetailedDiscount_Get_Result.Quantity;
                    orderdetaileddiscount_get_result.PhotNumber = baOrderDetailedDiscount_Get_Result.PhotNumber;
                    orderdetaileddiscount_get_result.IsActive = baOrderDetailedDiscount_Get_Result.IsActive;

                    db.OrderDetailedDiscount_Get_Results.Add(orderdetaileddiscount_get_result);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baOrderDetailedDiscount_Get_Result baOrderDetailedDiscount_Get_Result )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderDetailedDiscount_Get_Results.Where(p => p.Id == baOrderDetailedDiscount_Get_Result.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        orderdetaileddiscount_get_result orderdetaileddiscount_get_result = new orderdetaileddiscount_get_result();

                        orderdetaileddiscount_get_result.Id = baOrderDetailedDiscount_Get_Result.Id;
                        orderdetaileddiscount_get_result.PS_Orders_pkey = baOrderDetailedDiscount_Get_Result.PS_Orders_pkey;
                        orderdetaileddiscount_get_result.PS_Orders_Number = baOrderDetailedDiscount_Get_Result.PS_Orders_Number;
                        orderdetaileddiscount_get_result.PS_Orders_Date = baOrderDetailedDiscount_Get_Result.PS_Orders_Date;
                        orderdetaileddiscount_get_result.OrderDetailId = baOrderDetailedDiscount_Get_Result.OrderDetailId;
                        orderdetaileddiscount_get_result.PS_Orders_LineItems_DiscountAmount = baOrderDetailedDiscount_Get_Result.PS_Orders_LineItems_DiscountAmount;
                        orderdetaileddiscount_get_result.PS_Orders_Details_Items_UniPrice = baOrderDetailedDiscount_Get_Result.PS_Orders_Details_Items_UniPrice;
                        orderdetaileddiscount_get_result.PS_Orders_Details_Items_TotalCost = baOrderDetailedDiscount_Get_Result.PS_Orders_Details_Items_TotalCost;
                        orderdetaileddiscount_get_result.PS_Orders_Details_Items_NetPrice = baOrderDetailedDiscount_Get_Result.PS_Orders_Details_Items_NetPrice;
                        orderdetaileddiscount_get_result.PS_Orders_Cost = baOrderDetailedDiscount_Get_Result.PS_Orders_Cost;
                        orderdetaileddiscount_get_result.PS_Orders_NetCost = baOrderDetailedDiscount_Get_Result.PS_Orders_NetCost;
                        orderdetaileddiscount_get_result.PS_Orders_Total_Discount = baOrderDetailedDiscount_Get_Result.PS_Orders_Total_Discount;
                        orderdetaileddiscount_get_result.PS_Orders_ProductType_Name = baOrderDetailedDiscount_Get_Result.PS_Orders_ProductType_Name;
                        orderdetaileddiscount_get_result.PS_Orders_ProductCode = baOrderDetailedDiscount_Get_Result.PS_Orders_ProductCode;
                        orderdetaileddiscount_get_result.Discount = baOrderDetailedDiscount_Get_Result.Discount;
                        orderdetaileddiscount_get_result.Value = baOrderDetailedDiscount_Get_Result.Value;
                        orderdetaileddiscount_get_result.InPercentmode = baOrderDetailedDiscount_Get_Result.InPercentmode;
                        orderdetaileddiscount_get_result.StoreName = baOrderDetailedDiscount_Get_Result.StoreName;
                        orderdetaileddiscount_get_result.USerName = baOrderDetailedDiscount_Get_Result.USerName;
                        orderdetaileddiscount_get_result.FromDate = baOrderDetailedDiscount_Get_Result.FromDate;
                        orderdetaileddiscount_get_result.ToDate = baOrderDetailedDiscount_Get_Result.ToDate;
                        orderdetaileddiscount_get_result.ActualValue = baOrderDetailedDiscount_Get_Result.ActualValue;
                        orderdetaileddiscount_get_result.TotalOrderDiscountDetails = baOrderDetailedDiscount_Get_Result.TotalOrderDiscountDetails;
                        orderdetaileddiscount_get_result.TotalLineItemDiscount = baOrderDetailedDiscount_Get_Result.TotalLineItemDiscount;
                        orderdetaileddiscount_get_result.Quantity = baOrderDetailedDiscount_Get_Result.Quantity;
                        orderdetaileddiscount_get_result.PhotNumber = baOrderDetailedDiscount_Get_Result.PhotNumber;
                        orderdetaileddiscount_get_result.IsActive = baOrderDetailedDiscount_Get_Result.IsActive;

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
                    var obj = db.OrderDetailedDiscount_Get_Results.Where(p => p.Id == Id).FirstOrDefault();
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
