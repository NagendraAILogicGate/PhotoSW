using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baOrderDetails
        {
        public long Id { get; set; }
        public string PS_Orders_ProductType_Name { get; set; }
        public decimal? PS_Orders_Details_Items_TotalCost { get; set; }
        public decimal? PS_Orders_LineItems_DiscountAmount { get; set; }
        public long? PS_Orders_LineItems_Quantity { get; set; }
        public int PS_Refund_Quantity { get; set; }
        public decimal? PS_Refund_Amount { get; set; }
        public int PS_LineItemId { get; set; }
        public decimal? PS_LineItem_RefundPrice { get; set; }
        public decimal? PS_LineItemUnitPrice { get; set; }
        public string PhotoIds { get; set; }
        public int? PS_ProductTypeId { get; set; }
        public bool IsBundled { get; set; }
        public bool IsPackage { get; set; }
        public int loopquantity { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<orderdetails> lst_orderdetails = new List<orderdetails>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    orderdetails orderdetails = new orderdetails();

                      orderdetails.Id = 1;
                      orderdetails.PS_Orders_ProductType_Name = "";
                      orderdetails.PS_Orders_Details_Items_TotalCost = 1;
                      orderdetails.PS_Orders_LineItems_DiscountAmount = 1;
                      orderdetails.PS_Orders_LineItems_Quantity = 1;
                      orderdetails.PS_Refund_Quantity = 1;
                      orderdetails.PS_Refund_Amount = 1;
                      orderdetails.PS_LineItemId = 1;
                      orderdetails.PS_LineItem_RefundPrice = 1;
                      orderdetails.PS_LineItemUnitPrice = 1;
                      orderdetails.PhotoIds = "";
                      orderdetails.PS_ProductTypeId = 1;
                      orderdetails.IsBundled = false;
                      orderdetails.IsPackage = false;
                      orderdetails.loopquantity = 1;
                      orderdetails.IsActive = true;

                    lst_orderdetails.Add(orderdetails);

                    var Id = lst_orderdetails.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.OrderDetailses.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.OrderDetailses.AddRange(lst_orderdetails);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.OrderDetailses.AddRange(lst_orderdetails);
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

        public static baOrderDetails GetOrderDetailsById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderDetailses.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baOrderDetails
                        {

                        Id = p.Id,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        PS_Orders_Details_Items_TotalCost = p.PS_Orders_Details_Items_TotalCost,
                        PS_Orders_LineItems_DiscountAmount = p.PS_Orders_LineItems_DiscountAmount,
                        PS_Orders_LineItems_Quantity = p.PS_Orders_LineItems_Quantity,
                        PS_Refund_Quantity = p.PS_Refund_Quantity,
                        PS_Refund_Amount = p.PS_Refund_Amount,
                        PS_LineItemId = p.PS_LineItemId,
                        PS_LineItem_RefundPrice = p.PS_LineItem_RefundPrice,
                        PS_LineItemUnitPrice = p.PS_LineItemUnitPrice,
                        PhotoIds = p.PhotoIds,
                        PS_ProductTypeId = p.PS_ProductTypeId,
                        IsBundled = p.IsBundled,
                        IsPackage = p.IsPackage,
                        loopquantity = p.loopquantity,
                        IsActive = true


                    }).FirstOrDefault();
                    return obj;
                    }
                }
            catch
                {
                return null; ;
                }
            }

        public static List<baOrderDetails> GetOrderDetailsData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderDetailses.Where(p => p.IsActive == true).Select(p => new baOrderDetails
                        {
                        Id = p.Id,
                        PS_Orders_ProductType_Name = p.PS_Orders_ProductType_Name,
                        PS_Orders_Details_Items_TotalCost = p.PS_Orders_Details_Items_TotalCost,
                        PS_Orders_LineItems_DiscountAmount = p.PS_Orders_LineItems_DiscountAmount,
                        PS_Orders_LineItems_Quantity = p.PS_Orders_LineItems_Quantity,
                        PS_Refund_Quantity = p.PS_Refund_Quantity,
                        PS_Refund_Amount = p.PS_Refund_Amount,
                        PS_LineItemId = p.PS_LineItemId,
                        PS_LineItem_RefundPrice = p.PS_LineItem_RefundPrice,
                        PS_LineItemUnitPrice = p.PS_LineItemUnitPrice,
                        PhotoIds = p.PhotoIds,
                        PS_ProductTypeId = p.PS_ProductTypeId,
                        IsBundled = p.IsBundled,
                        IsPackage = p.IsPackage,
                        loopquantity = p.loopquantity,
                        IsActive = true

                        }).ToList();
                    return obj;
                    }
                }
            catch
                {
                return null; ;
                }
            }

        public static bool Insert ( baOrderDetails baOrderDetails )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    orderdetails orderdetails = new orderdetails();

                    orderdetails.Id = baOrderDetails.Id;
                    orderdetails.PS_Orders_ProductType_Name = baOrderDetails.PS_Orders_ProductType_Name;
                    orderdetails.PS_Orders_Details_Items_TotalCost = baOrderDetails.PS_Orders_Details_Items_TotalCost;
                    orderdetails.PS_Orders_LineItems_DiscountAmount = baOrderDetails.PS_Orders_LineItems_DiscountAmount;
                    orderdetails.PS_Orders_LineItems_Quantity = baOrderDetails.PS_Orders_LineItems_Quantity;
                    orderdetails.PS_Refund_Quantity = baOrderDetails.PS_Refund_Quantity;
                    orderdetails.PS_Refund_Amount = baOrderDetails.PS_Refund_Amount;
                    orderdetails.PS_LineItemId = baOrderDetails.PS_LineItemId;
                    orderdetails.PS_LineItem_RefundPrice = baOrderDetails.PS_LineItem_RefundPrice;
                    orderdetails.PS_LineItemUnitPrice = baOrderDetails.PS_LineItemUnitPrice;
                    orderdetails.PhotoIds = baOrderDetails.PhotoIds;
                    orderdetails.PS_ProductTypeId = baOrderDetails.PS_ProductTypeId;
                    orderdetails.IsBundled = baOrderDetails.IsBundled;
                    orderdetails.IsPackage = baOrderDetails.IsPackage;
                    orderdetails.loopquantity = baOrderDetails.loopquantity;
                    orderdetails.IsActive = baOrderDetails.IsActive;

                    db.OrderDetailses.Add(orderdetails);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baOrderDetails baOrderDetails )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.OrderDetailses.Where(p => p.Id == baOrderDetails.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        orderdetails orderdetails = new orderdetails();

                        orderdetails.Id = baOrderDetails.Id;
                        orderdetails.PS_Orders_ProductType_Name = baOrderDetails.PS_Orders_ProductType_Name;
                        orderdetails.PS_Orders_Details_Items_TotalCost = baOrderDetails.PS_Orders_Details_Items_TotalCost;
                        orderdetails.PS_Orders_LineItems_DiscountAmount = baOrderDetails.PS_Orders_LineItems_DiscountAmount;
                        orderdetails.PS_Orders_LineItems_Quantity = baOrderDetails.PS_Orders_LineItems_Quantity;
                        orderdetails.PS_Refund_Quantity = baOrderDetails.PS_Refund_Quantity;
                        orderdetails.PS_Refund_Amount = baOrderDetails.PS_Refund_Amount;
                        orderdetails.PS_LineItemId = baOrderDetails.PS_LineItemId;
                        orderdetails.PS_LineItem_RefundPrice = baOrderDetails.PS_LineItem_RefundPrice;
                        orderdetails.PS_LineItemUnitPrice = baOrderDetails.PS_LineItemUnitPrice;
                        orderdetails.PhotoIds = baOrderDetails.PhotoIds;
                        orderdetails.PS_ProductTypeId = baOrderDetails.PS_ProductTypeId;
                        orderdetails.IsBundled = baOrderDetails.IsBundled;
                        orderdetails.IsPackage = baOrderDetails.IsPackage;
                        orderdetails.loopquantity = baOrderDetails.loopquantity;
                        orderdetails.IsActive = baOrderDetails.IsActive;

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
                    var obj = db.OrderDetailses.Where(p => p.Id == Id).FirstOrDefault();
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
