using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baPaymentSummaryInfo
        {
        public long Id { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int SubStoreId { get; set; }
        public string SubStoreName { get; set; }
        public string Productcode { get; set; }
        public int Quantity { get; set; }
        public decimal ProductUnitPrice { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Tax { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetPrice { get; set; }
        public decimal SubStoreCardSale { get; set; }
        public decimal SubStoreCashSale { get; set; }
        public decimal SubStoreDiscountSale { get; set; }
        public decimal SubStoreRoomChargeSale { get; set; }
        public decimal SubStoreFC { get; set; }
        public decimal StoreCashSale { get; set; }
        public decimal StoreCardSale { get; set; }
        public decimal StoreDiscountSale { get; set; }
        public decimal StoreRoomChargeSale { get; set; }
        public decimal FC { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string ConSubStoreName { get; set; }
        public int SubStoreCashTransactionCount { get; set; }
        public int SubStoreCCTransactionCount { get; set; }
        public int SubstoreRoomChargeTransactionCount { get; set; }
        public int TotalSubStoreFCTransactionCount { get; set; }
        public int SubStoreDiscountedVoucherTransactionCount { get; set; }
        public decimal TotalStoreSale { get; set; }
        public int TotalStoreSaleTransactionCount { get; set; }
        public decimal StoreVoidSale { get; set; }
        public int StoreVoidSaleTransactionCount { get; set; }
        public int StoreCashSaleTransactionsCount { get; set; }
        public int StoreCardSaleTransactionsCount { get; set; }
        public int StoreDiscountSaleTransactionsCount { get; set; }
        public int StoreRoomChargeSaleTransactionsCount { get; set; }
        public int FCStoreTransactionCount { get; set; }
        public int KVLStoreTransactionCount { get; set; }
        public decimal KVLStoreTransactionAmount { get; set; }
        public int SubStoreVoidSaleTransactionCount { get; set; }
        public decimal SubStoreVoidSale { get; set; }
        public int SubStoreKVLTransactionCount { get; set; }
        public decimal SubStoreKVLTransactionAmount { get; set; }
        public int TotalSubStoreSaleTransactionCount { get; set; }
        public decimal StoreCardSaleVoid { get; set; }
        public decimal StoreCashSaleVoid { get; set; }
        public decimal StoreDiscountSaleVoid { get; set; }
        public decimal StoreRoomChargeSaleVoid { get; set; }
        public decimal FCVoid { get; set; }
        public decimal KVLStoreTransactionAmountVoid { get; set; }
        public decimal SubStoreCardSaleVoid { get; set; }
        public decimal SubStoreCashSaleVoid { get; set; }
        public decimal SubStoreDiscountSaleVoid { get; set; }
        public decimal SubStoreRoomChargeSaleVoid { get; set; }
        public decimal SubStoreFCVoid { get; set; }
        public decimal SubStoreKVLTransactionAmountVoid { get; set; }
        public int StoreCashSaleTransactionsCountVoid { get; set; }
        public int StoreCardSaleTransactionsCountVoid { get; set; }
        public int StoreDiscountSaleTransactionsCountVoid { get; set; }
        public int StoreRoomChargeSaleTransactionsCountVoid { get; set; }
        public int FCStoreTransactionCountVoid { get; set; }
        public int KVLStoreTransactionCountVoid { get; set; }
        public int SubStoreCashTransactionCountVoid { get; set; }
        public int SubStoreCCTransactionCountVoid { get; set; }
        public int TotalSubStoreFCTransactionCountVoid { get; set; }
        public int SubStoreDiscountedVoucherTransactionCountVoid { get; set; }
        public int SubstoreRoomChargeTransactionCountVoid { get; set; }
        public int SubStoreKVLTransactionCountVoid { get; set; }
        public bool? IsActive { get; set; }


        public static bool Marge ()
            {
            List<paymentsummaryinfo> lst_paymentsummaryinfo = new List<paymentsummaryinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    paymentsummaryinfo paymentsummaryinfo = new paymentsummaryinfo();


                    paymentsummaryinfo.Id = 1;
                    paymentsummaryinfo.StoreId = 1;
                    paymentsummaryinfo.StoreName = "";
                    paymentsummaryinfo.SubStoreId = 4;
                    paymentsummaryinfo.SubStoreName = "";
                    paymentsummaryinfo.Productcode = "";
                    paymentsummaryinfo.Quantity = 2;
                    paymentsummaryinfo.ProductUnitPrice = 5;
                    paymentsummaryinfo.TotalCost = 4;
                    paymentsummaryinfo.Tax = 5;
                    paymentsummaryinfo.DiscountAmount = 5;
                    paymentsummaryinfo.NetPrice = 5;
                    paymentsummaryinfo.SubStoreCardSale = 4;
                    paymentsummaryinfo.SubStoreCashSale = 5;
                    paymentsummaryinfo.SubStoreDiscountSale = 4;
                    paymentsummaryinfo.SubStoreRoomChargeSale = 5;
                    paymentsummaryinfo.SubStoreFC = 6;
                    paymentsummaryinfo.StoreCashSale = 4;
                    paymentsummaryinfo.StoreCardSale = 3;
                    paymentsummaryinfo.StoreDiscountSale = 2;
                    paymentsummaryinfo.StoreRoomChargeSale = 6;
                    paymentsummaryinfo.FC = 3;
                    paymentsummaryinfo.FromDate = DateTime.Now;
                    paymentsummaryinfo.ToDate = DateTime.Now;
                    paymentsummaryinfo.ConSubStoreName = "";
                    paymentsummaryinfo.SubStoreCashTransactionCount = 1;
                    paymentsummaryinfo.SubStoreCCTransactionCount = 2;
                    paymentsummaryinfo.SubstoreRoomChargeTransactionCount = 3;
                    paymentsummaryinfo.TotalSubStoreFCTransactionCount = 2;
                    paymentsummaryinfo.SubStoreDiscountedVoucherTransactionCount = 4;
                    paymentsummaryinfo.TotalStoreSale = 3;
                    paymentsummaryinfo.TotalStoreSaleTransactionCount = 5;
                    paymentsummaryinfo.StoreVoidSale = 8;
                    paymentsummaryinfo.StoreVoidSaleTransactionCount = 4;
                    paymentsummaryinfo.StoreCashSaleTransactionsCount = 4;
                    paymentsummaryinfo.StoreCardSaleTransactionsCount = 2;
                    paymentsummaryinfo.StoreDiscountSaleTransactionsCount = 8;
                    paymentsummaryinfo.StoreRoomChargeSaleTransactionsCount = 3;
                    paymentsummaryinfo.FCStoreTransactionCount = 7;
                    paymentsummaryinfo.KVLStoreTransactionCount = 5;
                    paymentsummaryinfo.KVLStoreTransactionAmount = 4;
                    paymentsummaryinfo.SubStoreVoidSaleTransactionCount = 7;
                    paymentsummaryinfo.SubStoreVoidSale = 2;
                    paymentsummaryinfo.SubStoreKVLTransactionCount = 4;
                    paymentsummaryinfo.SubStoreKVLTransactionAmount = 7;
                    paymentsummaryinfo.TotalSubStoreSaleTransactionCount = 2;
                    paymentsummaryinfo.StoreCardSaleVoid = 4;
                    paymentsummaryinfo.StoreCashSaleVoid = 5;
                    paymentsummaryinfo.StoreDiscountSaleVoid = 4;
                    paymentsummaryinfo.StoreRoomChargeSaleVoid = 4;
                    paymentsummaryinfo.FCVoid = 7;
                    paymentsummaryinfo.KVLStoreTransactionAmountVoid = 7;
                    paymentsummaryinfo.SubStoreCardSaleVoid = 2;
                    paymentsummaryinfo.SubStoreCashSaleVoid = 4;
                    paymentsummaryinfo.SubStoreDiscountSaleVoid = 5;
                    paymentsummaryinfo.SubStoreRoomChargeSaleVoid = 2;
                    paymentsummaryinfo.SubStoreFCVoid = 4;
                    paymentsummaryinfo.SubStoreKVLTransactionAmountVoid = 5;
                    paymentsummaryinfo.StoreCashSaleTransactionsCountVoid = 2;
                    paymentsummaryinfo.StoreCardSaleTransactionsCountVoid = 4;
                    paymentsummaryinfo.StoreDiscountSaleTransactionsCountVoid = 3;
                    paymentsummaryinfo.StoreRoomChargeSaleTransactionsCountVoid = 7;
                    paymentsummaryinfo.FCStoreTransactionCountVoid = 3;
                    paymentsummaryinfo.KVLStoreTransactionCountVoid = 4;
                    paymentsummaryinfo.SubStoreCashTransactionCountVoid = 5;
                    paymentsummaryinfo.SubStoreCCTransactionCountVoid = 6;
                    paymentsummaryinfo.TotalSubStoreFCTransactionCountVoid = 2;
                    paymentsummaryinfo.SubStoreDiscountedVoucherTransactionCountVoid = 4;
                    paymentsummaryinfo.SubstoreRoomChargeTransactionCountVoid = 4;
                    paymentsummaryinfo.SubStoreKVLTransactionCountVoid = 7;
                    paymentsummaryinfo.IsActive = true;

                    lst_paymentsummaryinfo.Add(paymentsummaryinfo);

                    var Id = lst_paymentsummaryinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PaymentSummaryInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.PaymentSummaryInfos.AddRange(lst_paymentsummaryinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.PaymentSummaryInfos.AddRange(lst_paymentsummaryinfo);
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

        public static baPaymentSummaryInfo GetPaymentSummaryInfoById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PaymentSummaryInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPaymentSummaryInfo
                        {

                        Id = p.Id,
                        StoreId = p.StoreId,
                        StoreName = p.StoreName,
                        SubStoreName = p.SubStoreName,
                        Productcode = p.Productcode,
                        Quantity = p.Quantity,
                        ProductUnitPrice = p.ProductUnitPrice,
                        TotalCost = p.TotalCost,
                        Tax = p.Tax,
                        DiscountAmount = p.DiscountAmount,
                        NetPrice = p.NetPrice,
                        SubStoreCardSale = p.SubStoreCardSale,
                        SubStoreCashSale = p.SubStoreCashSale,
                        SubStoreDiscountSale = p.SubStoreDiscountSale,
                        SubStoreRoomChargeSale = p.SubStoreRoomChargeSale,
                        SubStoreFC = p.SubStoreFC,
                        StoreCashSale = p.StoreCashSale,
                        StoreCardSale = p.StoreCardSale,
                        StoreDiscountSale = p.StoreDiscountSale,
                        StoreRoomChargeSale = p.StoreRoomChargeSale,
                        FC = p.FC,
                        FromDate = p.FromDate,
                        ToDate = p.ToDate,
                        ConSubStoreName = p.ConSubStoreName,
                        SubStoreCashTransactionCount = p.SubStoreCashTransactionCount,
                        SubStoreCCTransactionCount = p.SubStoreCCTransactionCount,
                        SubstoreRoomChargeTransactionCount = p.SubstoreRoomChargeTransactionCount,
                        TotalSubStoreFCTransactionCount = p.TotalSubStoreFCTransactionCount,
                        SubStoreDiscountedVoucherTransactionCount = p.SubStoreDiscountedVoucherTransactionCount,
                        TotalStoreSale = p.TotalStoreSale,
                        TotalStoreSaleTransactionCount = p.TotalStoreSaleTransactionCount,
                        StoreVoidSale = p.StoreVoidSale,
                        StoreVoidSaleTransactionCount = p.StoreVoidSaleTransactionCount,
                        StoreCashSaleTransactionsCount = p.StoreCashSaleTransactionsCount,
                        StoreCardSaleTransactionsCount = p.StoreCardSaleTransactionsCount,
                        StoreDiscountSaleTransactionsCount = p.StoreDiscountSaleTransactionsCount,
                        StoreRoomChargeSaleTransactionsCount = p.StoreRoomChargeSaleTransactionsCount,
                        FCStoreTransactionCount = p.FCStoreTransactionCount,
                        KVLStoreTransactionCount = p.KVLStoreTransactionCount,
                        KVLStoreTransactionAmount = p.KVLStoreTransactionAmount,
                        SubStoreVoidSaleTransactionCount = p.SubStoreVoidSaleTransactionCount,
                        SubStoreVoidSale = p.SubStoreVoidSale,
                        SubStoreKVLTransactionCount = p.SubStoreKVLTransactionCount,
                        SubStoreKVLTransactionAmount = p.SubStoreKVLTransactionAmount,
                        TotalSubStoreSaleTransactionCount = p.TotalSubStoreSaleTransactionCount,
                        StoreCardSaleVoid = p.StoreCardSaleVoid,
                        StoreCashSaleVoid = p.StoreCashSaleVoid,
                        StoreDiscountSaleVoid = p.StoreDiscountSaleVoid,
                        StoreRoomChargeSaleVoid = p.StoreRoomChargeSaleVoid,
                        FCVoid = p.FCVoid,
                        KVLStoreTransactionAmountVoid = p.KVLStoreTransactionAmountVoid,
                        SubStoreCardSaleVoid = p.SubStoreCardSaleVoid,
                        SubStoreCashSaleVoid = p.SubStoreCashSaleVoid,
                        SubStoreDiscountSaleVoid = p.SubStoreDiscountSaleVoid,
                        SubStoreRoomChargeSaleVoid = p.SubStoreRoomChargeSaleVoid,
                        SubStoreFCVoid = p.SubStoreFCVoid,
                        SubStoreKVLTransactionAmountVoid = p.SubStoreKVLTransactionAmountVoid,
                        StoreCashSaleTransactionsCountVoid = p.StoreCashSaleTransactionsCountVoid,
                        StoreCardSaleTransactionsCountVoid = p.StoreCardSaleTransactionsCountVoid,
                        StoreDiscountSaleTransactionsCountVoid = p.StoreDiscountSaleTransactionsCountVoid,
                        StoreRoomChargeSaleTransactionsCountVoid = p.StoreRoomChargeSaleTransactionsCountVoid,
                        FCStoreTransactionCountVoid = p.FCStoreTransactionCountVoid,
                        KVLStoreTransactionCountVoid = p.KVLStoreTransactionCountVoid,
                        SubStoreCashTransactionCountVoid = p.SubStoreCashTransactionCountVoid,
                        SubStoreCCTransactionCountVoid = p.SubStoreCCTransactionCountVoid,
                        TotalSubStoreFCTransactionCountVoid = p.TotalSubStoreFCTransactionCountVoid,
                        SubStoreDiscountedVoucherTransactionCountVoid = p.SubStoreDiscountedVoucherTransactionCountVoid,
                        SubstoreRoomChargeTransactionCountVoid = p.SubstoreRoomChargeTransactionCountVoid,
                        SubStoreKVLTransactionCountVoid = p.SubStoreKVLTransactionCountVoid,
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

        public static List<baPaymentSummaryInfo> GetPaymentSummaryInfoData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PaymentSummaryInfos.Where(p => p.IsActive == true).Select(p => new baPaymentSummaryInfo
                        {
                        Id = p.Id,
                        StoreId = p.StoreId,
                        StoreName = p.StoreName,
                        SubStoreName = p.SubStoreName,
                        Productcode = p.Productcode,
                        Quantity = p.Quantity,
                        ProductUnitPrice = p.ProductUnitPrice,
                        TotalCost = p.TotalCost,
                        Tax = p.Tax,
                        DiscountAmount = p.DiscountAmount,
                        NetPrice = p.NetPrice,
                        SubStoreCardSale = p.SubStoreCardSale,
                        SubStoreCashSale = p.SubStoreCashSale,
                        SubStoreDiscountSale = p.SubStoreDiscountSale,
                        SubStoreRoomChargeSale = p.SubStoreRoomChargeSale,
                        SubStoreFC = p.SubStoreFC,
                        StoreCashSale = p.StoreCashSale,
                        StoreCardSale = p.StoreCardSale,
                        StoreDiscountSale = p.StoreDiscountSale,
                        StoreRoomChargeSale = p.StoreRoomChargeSale,
                        FC = p.FC,
                        FromDate = p.FromDate,
                        ToDate = p.ToDate,
                        ConSubStoreName = p.ConSubStoreName,
                        SubStoreCashTransactionCount = p.SubStoreCashTransactionCount,
                        SubStoreCCTransactionCount = p.SubStoreCCTransactionCount,
                        SubstoreRoomChargeTransactionCount = p.SubstoreRoomChargeTransactionCount,
                        TotalSubStoreFCTransactionCount = p.TotalSubStoreFCTransactionCount,
                        SubStoreDiscountedVoucherTransactionCount = p.SubStoreDiscountedVoucherTransactionCount,
                        TotalStoreSale = p.TotalStoreSale,
                        TotalStoreSaleTransactionCount = p.TotalStoreSaleTransactionCount,
                        StoreVoidSale = p.StoreVoidSale,
                        StoreVoidSaleTransactionCount = p.StoreVoidSaleTransactionCount,
                        StoreCashSaleTransactionsCount = p.StoreCashSaleTransactionsCount,
                        StoreCardSaleTransactionsCount = p.StoreCardSaleTransactionsCount,
                        StoreDiscountSaleTransactionsCount = p.StoreDiscountSaleTransactionsCount,
                        StoreRoomChargeSaleTransactionsCount = p.StoreRoomChargeSaleTransactionsCount,
                        FCStoreTransactionCount = p.FCStoreTransactionCount,
                        KVLStoreTransactionCount = p.KVLStoreTransactionCount,
                        KVLStoreTransactionAmount = p.KVLStoreTransactionAmount,
                        SubStoreVoidSaleTransactionCount = p.SubStoreVoidSaleTransactionCount,
                        SubStoreVoidSale = p.SubStoreVoidSale,
                        SubStoreKVLTransactionCount = p.SubStoreKVLTransactionCount,
                        SubStoreKVLTransactionAmount = p.SubStoreKVLTransactionAmount,
                        TotalSubStoreSaleTransactionCount = p.TotalSubStoreSaleTransactionCount,
                        StoreCardSaleVoid = p.StoreCardSaleVoid,
                        StoreCashSaleVoid = p.StoreCashSaleVoid,
                        StoreDiscountSaleVoid = p.StoreDiscountSaleVoid,
                        StoreRoomChargeSaleVoid = p.StoreRoomChargeSaleVoid,
                        FCVoid = p.FCVoid,
                        KVLStoreTransactionAmountVoid = p.KVLStoreTransactionAmountVoid,
                        SubStoreCardSaleVoid = p.SubStoreCardSaleVoid,
                        SubStoreCashSaleVoid = p.SubStoreCashSaleVoid,
                        SubStoreDiscountSaleVoid = p.SubStoreDiscountSaleVoid,
                        SubStoreRoomChargeSaleVoid = p.SubStoreRoomChargeSaleVoid,
                        SubStoreFCVoid = p.SubStoreFCVoid,
                        SubStoreKVLTransactionAmountVoid = p.SubStoreKVLTransactionAmountVoid,
                        StoreCashSaleTransactionsCountVoid = p.StoreCashSaleTransactionsCountVoid,
                        StoreCardSaleTransactionsCountVoid = p.StoreCardSaleTransactionsCountVoid,
                        StoreDiscountSaleTransactionsCountVoid = p.StoreDiscountSaleTransactionsCountVoid,
                        StoreRoomChargeSaleTransactionsCountVoid = p.StoreRoomChargeSaleTransactionsCountVoid,
                        FCStoreTransactionCountVoid = p.FCStoreTransactionCountVoid,
                        KVLStoreTransactionCountVoid = p.KVLStoreTransactionCountVoid,
                        SubStoreCashTransactionCountVoid = p.SubStoreCashTransactionCountVoid,
                        SubStoreCCTransactionCountVoid = p.SubStoreCCTransactionCountVoid,
                        TotalSubStoreFCTransactionCountVoid = p.TotalSubStoreFCTransactionCountVoid,
                        SubStoreDiscountedVoucherTransactionCountVoid = p.SubStoreDiscountedVoucherTransactionCountVoid,
                        SubstoreRoomChargeTransactionCountVoid = p.SubstoreRoomChargeTransactionCountVoid,
                        SubStoreKVLTransactionCountVoid = p.SubStoreKVLTransactionCountVoid,
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

        public static bool Insert ( baPaymentSummaryInfo baPaymentSummaryInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    paymentsummaryinfo paymentsummaryinfo = new paymentsummaryinfo();

                    paymentsummaryinfo.Id = baPaymentSummaryInfo.Id;
                    paymentsummaryinfo.StoreId = baPaymentSummaryInfo.StoreId;
                    paymentsummaryinfo.StoreName = baPaymentSummaryInfo.StoreName;
                    paymentsummaryinfo.SubStoreId = baPaymentSummaryInfo.SubStoreId;
                    paymentsummaryinfo.SubStoreName = baPaymentSummaryInfo.SubStoreName;
                    paymentsummaryinfo.Productcode = baPaymentSummaryInfo.Productcode;
                    paymentsummaryinfo.Quantity = baPaymentSummaryInfo.Quantity;
                    paymentsummaryinfo.ProductUnitPrice = baPaymentSummaryInfo.ProductUnitPrice;
                    paymentsummaryinfo.TotalCost = baPaymentSummaryInfo.TotalCost;
                    paymentsummaryinfo.Tax = baPaymentSummaryInfo.Tax;
                    paymentsummaryinfo.DiscountAmount = baPaymentSummaryInfo.DiscountAmount;
                    paymentsummaryinfo.NetPrice = baPaymentSummaryInfo.NetPrice;
                    paymentsummaryinfo.SubStoreCardSale = baPaymentSummaryInfo.SubStoreCardSale;
                    paymentsummaryinfo.SubStoreCashSale = baPaymentSummaryInfo.SubStoreCashSale;
                    paymentsummaryinfo.SubStoreDiscountSale = baPaymentSummaryInfo.SubStoreDiscountSale;
                    paymentsummaryinfo.SubStoreRoomChargeSale = baPaymentSummaryInfo.SubStoreRoomChargeSale;
                    paymentsummaryinfo.SubStoreFC = baPaymentSummaryInfo.SubStoreFC;
                    paymentsummaryinfo.StoreCashSale = baPaymentSummaryInfo.StoreCashSale;
                    paymentsummaryinfo.StoreCardSale = baPaymentSummaryInfo.StoreCardSale;
                    paymentsummaryinfo.StoreDiscountSale = baPaymentSummaryInfo.StoreDiscountSale;
                    paymentsummaryinfo.StoreRoomChargeSale = baPaymentSummaryInfo.StoreRoomChargeSale;
                    paymentsummaryinfo.FC = baPaymentSummaryInfo.FC;
                    paymentsummaryinfo.FromDate = baPaymentSummaryInfo.FromDate;
                    paymentsummaryinfo.ToDate = baPaymentSummaryInfo.ToDate;
                    paymentsummaryinfo.ConSubStoreName = baPaymentSummaryInfo.ConSubStoreName;
                    paymentsummaryinfo.SubStoreCashTransactionCount = baPaymentSummaryInfo.SubStoreCashTransactionCount;
                    paymentsummaryinfo.SubStoreCCTransactionCount = baPaymentSummaryInfo.SubStoreCCTransactionCount;
                    paymentsummaryinfo.SubstoreRoomChargeTransactionCount = baPaymentSummaryInfo.SubstoreRoomChargeTransactionCount;
                    paymentsummaryinfo.TotalSubStoreFCTransactionCount = baPaymentSummaryInfo.TotalSubStoreFCTransactionCount;
                    paymentsummaryinfo.SubStoreDiscountedVoucherTransactionCount = baPaymentSummaryInfo.SubStoreDiscountedVoucherTransactionCount;
                    paymentsummaryinfo.TotalStoreSale = baPaymentSummaryInfo.TotalStoreSale;
                    paymentsummaryinfo.TotalStoreSaleTransactionCount = baPaymentSummaryInfo.TotalStoreSaleTransactionCount;
                    paymentsummaryinfo.StoreVoidSale = baPaymentSummaryInfo.StoreVoidSale;
                    paymentsummaryinfo.StoreVoidSaleTransactionCount = baPaymentSummaryInfo.StoreVoidSaleTransactionCount;
                    paymentsummaryinfo.StoreCashSaleTransactionsCount = baPaymentSummaryInfo.StoreCashSaleTransactionsCount;
                    paymentsummaryinfo.StoreCardSaleTransactionsCount = baPaymentSummaryInfo.StoreCardSaleTransactionsCount;
                    paymentsummaryinfo.StoreDiscountSaleTransactionsCount = baPaymentSummaryInfo.StoreDiscountSaleTransactionsCount;
                    paymentsummaryinfo.StoreRoomChargeSaleTransactionsCount = baPaymentSummaryInfo.StoreRoomChargeSaleTransactionsCount;
                    paymentsummaryinfo.FCStoreTransactionCount = baPaymentSummaryInfo.FCStoreTransactionCount;
                    paymentsummaryinfo.KVLStoreTransactionCount = baPaymentSummaryInfo.KVLStoreTransactionCount;
                    paymentsummaryinfo.KVLStoreTransactionAmount = baPaymentSummaryInfo.KVLStoreTransactionAmount;
                    paymentsummaryinfo.SubStoreVoidSaleTransactionCount = baPaymentSummaryInfo.SubStoreVoidSaleTransactionCount;
                    paymentsummaryinfo.SubStoreVoidSale = baPaymentSummaryInfo.SubStoreVoidSale;
                    paymentsummaryinfo.SubStoreKVLTransactionCount = baPaymentSummaryInfo.SubStoreKVLTransactionCount;
                    paymentsummaryinfo.SubStoreKVLTransactionAmount = baPaymentSummaryInfo.SubStoreKVLTransactionAmount;
                    paymentsummaryinfo.TotalSubStoreSaleTransactionCount = baPaymentSummaryInfo.TotalSubStoreSaleTransactionCount;
                    paymentsummaryinfo.StoreCardSaleVoid = baPaymentSummaryInfo.StoreCardSaleVoid;
                    paymentsummaryinfo.StoreCashSaleVoid = baPaymentSummaryInfo.StoreCashSaleVoid;
                    paymentsummaryinfo.StoreDiscountSaleVoid = baPaymentSummaryInfo.StoreDiscountSaleVoid;
                    paymentsummaryinfo.StoreRoomChargeSaleVoid = baPaymentSummaryInfo.StoreRoomChargeSaleVoid;
                    paymentsummaryinfo.FCVoid = baPaymentSummaryInfo.FCVoid;
                    paymentsummaryinfo.KVLStoreTransactionAmountVoid = baPaymentSummaryInfo.KVLStoreTransactionAmountVoid;
                    paymentsummaryinfo.SubStoreCardSaleVoid = baPaymentSummaryInfo.SubStoreCardSaleVoid;
                    paymentsummaryinfo.SubStoreCashSaleVoid = baPaymentSummaryInfo.SubStoreCashSaleVoid;
                    paymentsummaryinfo.SubStoreDiscountSaleVoid = baPaymentSummaryInfo.SubStoreDiscountSaleVoid;
                    paymentsummaryinfo.SubStoreRoomChargeSaleVoid = baPaymentSummaryInfo.SubStoreRoomChargeSaleVoid;
                    paymentsummaryinfo.SubStoreFCVoid = baPaymentSummaryInfo.SubStoreFCVoid;
                    paymentsummaryinfo.SubStoreKVLTransactionAmountVoid = baPaymentSummaryInfo.SubStoreKVLTransactionAmountVoid;
                    paymentsummaryinfo.StoreCashSaleTransactionsCountVoid = baPaymentSummaryInfo.StoreCashSaleTransactionsCountVoid;
                    paymentsummaryinfo.StoreCardSaleTransactionsCountVoid = baPaymentSummaryInfo.StoreCardSaleTransactionsCountVoid;
                    paymentsummaryinfo.StoreDiscountSaleTransactionsCountVoid = baPaymentSummaryInfo.StoreDiscountSaleTransactionsCountVoid;
                    paymentsummaryinfo.StoreRoomChargeSaleTransactionsCountVoid = baPaymentSummaryInfo.StoreRoomChargeSaleTransactionsCountVoid;
                    paymentsummaryinfo.FCStoreTransactionCountVoid = baPaymentSummaryInfo.FCStoreTransactionCountVoid;
                    paymentsummaryinfo.KVLStoreTransactionCountVoid = baPaymentSummaryInfo.KVLStoreTransactionCountVoid;
                    paymentsummaryinfo.SubStoreCashTransactionCountVoid = baPaymentSummaryInfo.SubStoreCashTransactionCountVoid;
                    paymentsummaryinfo.SubStoreCCTransactionCountVoid = baPaymentSummaryInfo.SubStoreCCTransactionCountVoid;
                    paymentsummaryinfo.TotalSubStoreFCTransactionCountVoid = baPaymentSummaryInfo.TotalSubStoreFCTransactionCountVoid;
                    paymentsummaryinfo.SubStoreDiscountedVoucherTransactionCountVoid = baPaymentSummaryInfo.SubStoreDiscountedVoucherTransactionCountVoid;
                    paymentsummaryinfo.SubstoreRoomChargeTransactionCountVoid = baPaymentSummaryInfo.SubstoreRoomChargeTransactionCountVoid;
                    paymentsummaryinfo.SubStoreKVLTransactionCountVoid = baPaymentSummaryInfo.SubStoreKVLTransactionCountVoid;
                    paymentsummaryinfo.IsActive = baPaymentSummaryInfo.IsActive;

                    db.PaymentSummaryInfos.Add(paymentsummaryinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPaymentSummaryInfo baPaymentSummaryInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PaymentSummaryInfos.Where(p => p.Id == baPaymentSummaryInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        paymentsummaryinfo paymentsummaryinfo = new paymentsummaryinfo();

                        paymentsummaryinfo.Id = baPaymentSummaryInfo.Id;
                        paymentsummaryinfo.StoreId = baPaymentSummaryInfo.StoreId;
                        paymentsummaryinfo.StoreName = baPaymentSummaryInfo.StoreName;
                        paymentsummaryinfo.SubStoreId = baPaymentSummaryInfo.SubStoreId;
                        paymentsummaryinfo.SubStoreName = baPaymentSummaryInfo.SubStoreName;
                        paymentsummaryinfo.Productcode = baPaymentSummaryInfo.Productcode;
                        paymentsummaryinfo.Quantity = baPaymentSummaryInfo.Quantity;
                        paymentsummaryinfo.ProductUnitPrice = baPaymentSummaryInfo.ProductUnitPrice;
                        paymentsummaryinfo.TotalCost = baPaymentSummaryInfo.TotalCost;
                        paymentsummaryinfo.Tax = baPaymentSummaryInfo.Tax;
                        paymentsummaryinfo.DiscountAmount = baPaymentSummaryInfo.DiscountAmount;
                        paymentsummaryinfo.NetPrice = baPaymentSummaryInfo.NetPrice;
                        paymentsummaryinfo.SubStoreCardSale = baPaymentSummaryInfo.SubStoreCardSale;
                        paymentsummaryinfo.SubStoreCashSale = baPaymentSummaryInfo.SubStoreCashSale;
                        paymentsummaryinfo.SubStoreDiscountSale = baPaymentSummaryInfo.SubStoreDiscountSale;
                        paymentsummaryinfo.SubStoreRoomChargeSale = baPaymentSummaryInfo.SubStoreRoomChargeSale;
                        paymentsummaryinfo.SubStoreFC = baPaymentSummaryInfo.SubStoreFC;
                        paymentsummaryinfo.StoreCashSale = baPaymentSummaryInfo.StoreCashSale;
                        paymentsummaryinfo.StoreCardSale = baPaymentSummaryInfo.StoreCardSale;
                        paymentsummaryinfo.StoreDiscountSale = baPaymentSummaryInfo.StoreDiscountSale;
                        paymentsummaryinfo.StoreRoomChargeSale = baPaymentSummaryInfo.StoreRoomChargeSale;
                        paymentsummaryinfo.FC = baPaymentSummaryInfo.FC;
                        paymentsummaryinfo.FromDate = baPaymentSummaryInfo.FromDate;
                        paymentsummaryinfo.ToDate = baPaymentSummaryInfo.ToDate;
                        paymentsummaryinfo.ConSubStoreName = baPaymentSummaryInfo.ConSubStoreName;
                        paymentsummaryinfo.SubStoreCashTransactionCount = baPaymentSummaryInfo.SubStoreCashTransactionCount;
                        paymentsummaryinfo.SubStoreCCTransactionCount = baPaymentSummaryInfo.SubStoreCCTransactionCount;
                        paymentsummaryinfo.SubstoreRoomChargeTransactionCount = baPaymentSummaryInfo.SubstoreRoomChargeTransactionCount;
                        paymentsummaryinfo.TotalSubStoreFCTransactionCount = baPaymentSummaryInfo.TotalSubStoreFCTransactionCount;
                        paymentsummaryinfo.SubStoreDiscountedVoucherTransactionCount = baPaymentSummaryInfo.SubStoreDiscountedVoucherTransactionCount;
                        paymentsummaryinfo.TotalStoreSale = baPaymentSummaryInfo.TotalStoreSale;
                        paymentsummaryinfo.TotalStoreSaleTransactionCount = baPaymentSummaryInfo.TotalStoreSaleTransactionCount;
                        paymentsummaryinfo.StoreVoidSale = baPaymentSummaryInfo.StoreVoidSale;
                        paymentsummaryinfo.StoreVoidSaleTransactionCount = baPaymentSummaryInfo.StoreVoidSaleTransactionCount;
                        paymentsummaryinfo.StoreCashSaleTransactionsCount = baPaymentSummaryInfo.StoreCashSaleTransactionsCount;
                        paymentsummaryinfo.StoreCardSaleTransactionsCount = baPaymentSummaryInfo.StoreCardSaleTransactionsCount;
                        paymentsummaryinfo.StoreDiscountSaleTransactionsCount = baPaymentSummaryInfo.StoreDiscountSaleTransactionsCount;
                        paymentsummaryinfo.StoreRoomChargeSaleTransactionsCount = baPaymentSummaryInfo.StoreRoomChargeSaleTransactionsCount;
                        paymentsummaryinfo.FCStoreTransactionCount = baPaymentSummaryInfo.FCStoreTransactionCount;
                        paymentsummaryinfo.KVLStoreTransactionCount = baPaymentSummaryInfo.KVLStoreTransactionCount;
                        paymentsummaryinfo.KVLStoreTransactionAmount = baPaymentSummaryInfo.KVLStoreTransactionAmount;
                        paymentsummaryinfo.SubStoreVoidSaleTransactionCount = baPaymentSummaryInfo.SubStoreVoidSaleTransactionCount;
                        paymentsummaryinfo.SubStoreVoidSale = baPaymentSummaryInfo.SubStoreVoidSale;
                        paymentsummaryinfo.SubStoreKVLTransactionCount = baPaymentSummaryInfo.SubStoreKVLTransactionCount;
                        paymentsummaryinfo.SubStoreKVLTransactionAmount = baPaymentSummaryInfo.SubStoreKVLTransactionAmount;
                        paymentsummaryinfo.TotalSubStoreSaleTransactionCount = baPaymentSummaryInfo.TotalSubStoreSaleTransactionCount;
                        paymentsummaryinfo.StoreCardSaleVoid = baPaymentSummaryInfo.StoreCardSaleVoid;
                        paymentsummaryinfo.StoreCashSaleVoid = baPaymentSummaryInfo.StoreCashSaleVoid;
                        paymentsummaryinfo.StoreDiscountSaleVoid = baPaymentSummaryInfo.StoreDiscountSaleVoid;
                        paymentsummaryinfo.StoreRoomChargeSaleVoid = baPaymentSummaryInfo.StoreRoomChargeSaleVoid;
                        paymentsummaryinfo.FCVoid = baPaymentSummaryInfo.FCVoid;
                        paymentsummaryinfo.KVLStoreTransactionAmountVoid = baPaymentSummaryInfo.KVLStoreTransactionAmountVoid;
                        paymentsummaryinfo.SubStoreCardSaleVoid = baPaymentSummaryInfo.SubStoreCardSaleVoid;
                        paymentsummaryinfo.SubStoreCashSaleVoid = baPaymentSummaryInfo.SubStoreCashSaleVoid;
                        paymentsummaryinfo.SubStoreDiscountSaleVoid = baPaymentSummaryInfo.SubStoreDiscountSaleVoid;
                        paymentsummaryinfo.SubStoreRoomChargeSaleVoid = baPaymentSummaryInfo.SubStoreRoomChargeSaleVoid;
                        paymentsummaryinfo.SubStoreFCVoid = baPaymentSummaryInfo.SubStoreFCVoid;
                        paymentsummaryinfo.SubStoreKVLTransactionAmountVoid = baPaymentSummaryInfo.SubStoreKVLTransactionAmountVoid;
                        paymentsummaryinfo.StoreCashSaleTransactionsCountVoid = baPaymentSummaryInfo.StoreCashSaleTransactionsCountVoid;
                        paymentsummaryinfo.StoreCardSaleTransactionsCountVoid = baPaymentSummaryInfo.StoreCardSaleTransactionsCountVoid;
                        paymentsummaryinfo.StoreDiscountSaleTransactionsCountVoid = baPaymentSummaryInfo.StoreDiscountSaleTransactionsCountVoid;
                        paymentsummaryinfo.StoreRoomChargeSaleTransactionsCountVoid = baPaymentSummaryInfo.StoreRoomChargeSaleTransactionsCountVoid;
                        paymentsummaryinfo.FCStoreTransactionCountVoid = baPaymentSummaryInfo.FCStoreTransactionCountVoid;
                        paymentsummaryinfo.KVLStoreTransactionCountVoid = baPaymentSummaryInfo.KVLStoreTransactionCountVoid;
                        paymentsummaryinfo.SubStoreCashTransactionCountVoid = baPaymentSummaryInfo.SubStoreCashTransactionCountVoid;
                        paymentsummaryinfo.SubStoreCCTransactionCountVoid = baPaymentSummaryInfo.SubStoreCCTransactionCountVoid;
                        paymentsummaryinfo.TotalSubStoreFCTransactionCountVoid = baPaymentSummaryInfo.TotalSubStoreFCTransactionCountVoid;
                        paymentsummaryinfo.SubStoreDiscountedVoucherTransactionCountVoid = baPaymentSummaryInfo.SubStoreDiscountedVoucherTransactionCountVoid;
                        paymentsummaryinfo.SubstoreRoomChargeTransactionCountVoid = baPaymentSummaryInfo.SubstoreRoomChargeTransactionCountVoid;
                        paymentsummaryinfo.SubStoreKVLTransactionCountVoid = baPaymentSummaryInfo.SubStoreKVLTransactionCountVoid;
                        paymentsummaryinfo.IsActive = baPaymentSummaryInfo.IsActive;

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
                    var obj = db.PaymentSummaryInfos.Where(p => p.Id == Id).FirstOrDefault();
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
