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

    public class baSageInfoClosing
    {
        public long Id { get; set; }
        public long ClosingFormDetailID { get; set; }
        public long SubStoresInfoId { get; set; }
        //public SubStoresInfo objSubStore
        //{
        //    get;
        //    set;
        //}

        public long sixEightClosingNumber { get; set; }
        public long eightTenClosingNumber { get; set; }
        public long PosterClosingNumber { get; set; }
        public long sixEightAutoClosingNumber { get; set; }
        public long eightTenAutoClosingNumber { get; set; }
        public long SixEightWestage { get; set; }
        public long EightTenWestage { get; set; }
        public long SixEightAutoWestage { get; set; }
        public long EightTenAutoWestage { get; set; }
        public long PosterWestage { get; set; }
        public int Attendance { get; set; }
        public decimal LaborHour { get; set; }
        public long NoOfCapture { get; set; }
        public long NoOfPreview { get; set; }
        public long NoOfImageSold { get; set; }
        public string Comments { get; set; }
        public DateTime? ClosingDate { get; set; }
        public int FilledBy { get; set; }
        public string FilledBySyncCode { get; set; }
        public long OpenCloseProcDetailID { get; set; }
        public int FormTypeID { get; set; }
        public DateTime? TransDate { get; set; }
        public decimal Cash { get; set; }
        public decimal CreditCard { get; set; }
        public decimal Amex { get; set; }
        public decimal FCV { get; set; }
        public decimal RoomCharges { get; set; }
        public decimal KVL { get; set; }
        public decimal Vouchers { get; set; }
        public long SixEightPrintCount { get; set; }
        public long EightTenPrintCount { get; set; }
        public long PosterPrintCount { get; set; }
        public string SyncCode { get; set; }
        public DateTime? OpeningDate { get; set; }
        //public List<TransDetail> TransDetails
        //{
        //    get;
        //    set;
        //}

        //public List<InventoryConsumables> InventoryConsumable
        //{
        //    get;
        //    set;
        //}
        //[System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<sageinfoclosing> lst_sageinfoclosing = new List<sageinfoclosing>();

            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    //foreach (var item in lst_str)
                    //{
                    sageinfoclosing sageinfoclosing = new sageinfoclosing();

                    sageinfoclosing.Id = 1;

                    sageinfoclosing.ClosingFormDetailID = 1;
                    sageinfoclosing.SubStoresInfoId = 1;
                    sageinfoclosing.sixEightClosingNumber = 1;
                    sageinfoclosing.eightTenClosingNumber = 1;
                    sageinfoclosing.PosterClosingNumber = 1;
                    sageinfoclosing.sixEightAutoClosingNumber = 1;
                    sageinfoclosing.eightTenAutoClosingNumber = 1;
                    sageinfoclosing.SixEightWestage = 1;
                    sageinfoclosing.EightTenWestage = 1;
                    sageinfoclosing.SixEightAutoWestage = 1;
                    sageinfoclosing.EightTenAutoWestage = 1;
                    sageinfoclosing.PosterWestage = 1;
                    sageinfoclosing.Attendance = 1;
                    sageinfoclosing.LaborHour = 1;
                    sageinfoclosing.NoOfCapture = 1;
                    sageinfoclosing.NoOfPreview = 1;
                    sageinfoclosing.NoOfImageSold = 1;
                    sageinfoclosing.Comments = "vvdghas asdsa";
                    sageinfoclosing.ClosingDate = null;
                    sageinfoclosing.FilledBy = 1;
                    sageinfoclosing.FilledBySyncCode = "001";
                    sageinfoclosing.OpenCloseProcDetailID = 1;
                    sageinfoclosing.FormTypeID = 1;
                    sageinfoclosing.TransDate = null;
                    sageinfoclosing.Cash = 0;
                    sageinfoclosing.CreditCard = 0;
                    sageinfoclosing.Amex = 0;
                    sageinfoclosing.FCV = 0;
                    sageinfoclosing.RoomCharges = 0;
                    sageinfoclosing.KVL = 0;
                    sageinfoclosing.Vouchers = 0;
                    sageinfoclosing.SixEightPrintCount = 0;
                    sageinfoclosing.EightTenPrintCount = 0;
                    sageinfoclosing.PosterPrintCount = 0;
                    sageinfoclosing.SyncCode = "";
                    sageinfoclosing.OpeningDate = null;

                    sageinfoclosing.IsActive = true;


                    lst_sageinfoclosing.Add(sageinfoclosing);
                    // }
                    var Id = lst_sageinfoclosing.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.SageInfoClosings.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.SageInfoClosings.AddRange(lst_sageinfoclosing);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.SageInfoClosings.AddRange(lst_sageinfoclosing);
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

        public static baSageInfoClosing GetSageInfoClosingDataById(int Id)
        {
            try
            {

                sageinfoclosing sageinfoclosing = new sageinfoclosing();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SageInfoClosings.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baSageInfoClosing
                    {
                        Id = p.Id,
                        ClosingFormDetailID = p.ClosingFormDetailID,
                        SubStoresInfoId = p.SubStoresInfoId,
                        sixEightClosingNumber = p.sixEightClosingNumber,
                        eightTenClosingNumber = p.eightTenClosingNumber,
                        PosterClosingNumber = p.PosterClosingNumber,
                        sixEightAutoClosingNumber = p.sixEightAutoClosingNumber,
                        eightTenAutoClosingNumber = p.eightTenAutoClosingNumber,
                        SixEightWestage = p.SixEightWestage,
                        EightTenWestage = p.EightTenWestage,
                        SixEightAutoWestage = p.SixEightAutoWestage,
                        EightTenAutoWestage = p.EightTenAutoWestage,
                        PosterWestage = p.PosterWestage,
                        Attendance = p.Attendance,
                        LaborHour = p.LaborHour,
                        NoOfCapture = p.NoOfCapture,
                        NoOfPreview = p.NoOfPreview,
                        NoOfImageSold = p.NoOfImageSold,
                        Comments = p.Comments,
                        ClosingDate = p.ClosingDate,
                        FilledBy = p.FilledBy,
                        FilledBySyncCode = p.FilledBySyncCode,
                        OpenCloseProcDetailID = p.OpenCloseProcDetailID,
                        FormTypeID = p.FormTypeID,
                        TransDate = p.TransDate,
                        Cash = p.Cash,
                        CreditCard = p.CreditCard,
                        Amex = p.Amex,
                        FCV = p.FCV,
                        RoomCharges = p.RoomCharges,
                        KVL = p.KVL,
                        Vouchers = p.Vouchers,
                        SixEightPrintCount = p.SixEightPrintCount,
                        EightTenPrintCount = p.EightTenPrintCount,
                        PosterPrintCount = p.PosterPrintCount,
                        SyncCode = p.SyncCode,
                        OpeningDate = p.OpeningDate,
                        
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
        public static List<baSageInfoClosing> GetSageInfoClosingData()
        {
            try
            {
                sageinfoclosing sageinfo = new sageinfoclosing();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SageInfoClosings.Where(p => p.IsActive == true).Select(p => new baSageInfoClosing
                    {
                        Id = p.Id,
                        ClosingFormDetailID = p.ClosingFormDetailID,
                        SubStoresInfoId = p.SubStoresInfoId,
                        sixEightClosingNumber = p.sixEightClosingNumber,
                        eightTenClosingNumber = p.eightTenClosingNumber,
                        PosterClosingNumber = p.PosterClosingNumber,
                        sixEightAutoClosingNumber = p.sixEightAutoClosingNumber,
                        eightTenAutoClosingNumber = p.eightTenAutoClosingNumber,
                        SixEightWestage = p.SixEightWestage,
                        EightTenWestage = p.EightTenWestage,
                        SixEightAutoWestage = p.SixEightAutoWestage,
                        EightTenAutoWestage = p.EightTenAutoWestage,
                        PosterWestage = p.PosterWestage,
                        Attendance = p.Attendance,
                        LaborHour = p.LaborHour,
                        NoOfCapture = p.NoOfCapture,
                        NoOfPreview = p.NoOfPreview,
                        NoOfImageSold = p.NoOfImageSold,
                        Comments = p.Comments,
                        ClosingDate = p.ClosingDate,
                        FilledBy = p.FilledBy,
                        FilledBySyncCode = p.FilledBySyncCode,
                        OpenCloseProcDetailID = p.OpenCloseProcDetailID,
                        FormTypeID = p.FormTypeID,
                        TransDate = p.TransDate,
                        Cash = p.Cash,
                        CreditCard = p.CreditCard,
                        Amex = p.Amex,
                        FCV = p.FCV,
                        RoomCharges = p.RoomCharges,
                        KVL = p.KVL,
                        Vouchers = p.Vouchers,
                        SixEightPrintCount = p.SixEightPrintCount,
                        EightTenPrintCount = p.EightTenPrintCount,
                        PosterPrintCount = p.PosterPrintCount,
                        SyncCode = p.SyncCode,
                        OpeningDate = p.OpeningDate,

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

        public static bool Insert ( baSageInfoClosing baSageInfoClosing )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    sageinfoclosing sageinfoclosing = new sageinfoclosing();

                    sageinfoclosing.Id = baSageInfoClosing.Id;
                    sageinfoclosing.ClosingFormDetailID = baSageInfoClosing.ClosingFormDetailID;
                    sageinfoclosing.SubStoresInfoId = baSageInfoClosing.SubStoresInfoId;
                    sageinfoclosing.sixEightClosingNumber = baSageInfoClosing.sixEightClosingNumber;
                    sageinfoclosing.eightTenClosingNumber = baSageInfoClosing.eightTenClosingNumber;
                    sageinfoclosing.PosterClosingNumber = baSageInfoClosing.PosterClosingNumber;
                    sageinfoclosing.sixEightAutoClosingNumber = baSageInfoClosing.sixEightAutoClosingNumber;
                    sageinfoclosing.eightTenAutoClosingNumber = baSageInfoClosing.eightTenAutoClosingNumber;
                    sageinfoclosing.SixEightWestage = baSageInfoClosing.SixEightWestage;
                    sageinfoclosing.EightTenWestage = baSageInfoClosing.EightTenWestage;
                    sageinfoclosing.SixEightAutoWestage = baSageInfoClosing.SixEightAutoWestage;
                    sageinfoclosing.EightTenAutoWestage = baSageInfoClosing.EightTenAutoWestage;
                    sageinfoclosing.PosterWestage = baSageInfoClosing.PosterWestage;
                    sageinfoclosing.Attendance = baSageInfoClosing.Attendance;
                    sageinfoclosing.LaborHour = baSageInfoClosing.LaborHour;
                    sageinfoclosing.NoOfCapture = baSageInfoClosing.NoOfCapture;
                    sageinfoclosing.NoOfPreview = baSageInfoClosing.NoOfPreview;
                    sageinfoclosing.NoOfImageSold = baSageInfoClosing.NoOfImageSold;
                    sageinfoclosing.Comments = baSageInfoClosing.Comments;
                    sageinfoclosing.ClosingDate = baSageInfoClosing.ClosingDate;
                    sageinfoclosing.FilledBy = baSageInfoClosing.FilledBy;
                    sageinfoclosing.FilledBySyncCode = baSageInfoClosing.FilledBySyncCode;
                    sageinfoclosing.OpenCloseProcDetailID = baSageInfoClosing.OpenCloseProcDetailID;
                    sageinfoclosing.FormTypeID = baSageInfoClosing.FormTypeID;
                    sageinfoclosing.TransDate = baSageInfoClosing.TransDate;
                    sageinfoclosing.Cash = baSageInfoClosing.Cash;
                    sageinfoclosing.CreditCard = baSageInfoClosing.CreditCard;
                    sageinfoclosing.Amex = baSageInfoClosing.Amex;
                    sageinfoclosing.FCV = baSageInfoClosing.FCV;
                    sageinfoclosing.RoomCharges = baSageInfoClosing.RoomCharges;
                    sageinfoclosing.KVL = baSageInfoClosing.KVL;
                    sageinfoclosing.Vouchers = baSageInfoClosing.Vouchers;
                    sageinfoclosing.SixEightPrintCount = baSageInfoClosing.SixEightPrintCount;
                    sageinfoclosing.EightTenPrintCount = baSageInfoClosing.EightTenPrintCount;
                    sageinfoclosing.PosterPrintCount = baSageInfoClosing.PosterPrintCount;
                    sageinfoclosing.SyncCode = baSageInfoClosing.SyncCode;
                    sageinfoclosing.OpeningDate = baSageInfoClosing.OpeningDate;
                    sageinfoclosing.IsActive = baSageInfoClosing.IsActive;

                    db.SageInfoClosings.Add(sageinfoclosing);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baSageInfoClosing baSageInfoClosing )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SageInfoClosings.Where(p => p.Id == baSageInfoClosing.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        sageinfoclosing sageinfoclosing = new sageinfoclosing();

                        sageinfoclosing.Id = baSageInfoClosing.Id;
                        sageinfoclosing.ClosingFormDetailID = baSageInfoClosing.ClosingFormDetailID;
                        sageinfoclosing.SubStoresInfoId = baSageInfoClosing.SubStoresInfoId;
                        sageinfoclosing.sixEightClosingNumber = baSageInfoClosing.sixEightClosingNumber;
                        sageinfoclosing.eightTenClosingNumber = baSageInfoClosing.eightTenClosingNumber;
                        sageinfoclosing.PosterClosingNumber = baSageInfoClosing.PosterClosingNumber;
                        sageinfoclosing.sixEightAutoClosingNumber = baSageInfoClosing.sixEightAutoClosingNumber;
                        sageinfoclosing.eightTenAutoClosingNumber = baSageInfoClosing.eightTenAutoClosingNumber;
                        sageinfoclosing.SixEightWestage = baSageInfoClosing.SixEightWestage;
                        sageinfoclosing.EightTenWestage = baSageInfoClosing.EightTenWestage;
                        sageinfoclosing.SixEightAutoWestage = baSageInfoClosing.SixEightAutoWestage;
                        sageinfoclosing.EightTenAutoWestage = baSageInfoClosing.EightTenAutoWestage;
                        sageinfoclosing.PosterWestage = baSageInfoClosing.PosterWestage;
                        sageinfoclosing.Attendance = baSageInfoClosing.Attendance;
                        sageinfoclosing.LaborHour = baSageInfoClosing.LaborHour;
                        sageinfoclosing.NoOfCapture = baSageInfoClosing.NoOfCapture;
                        sageinfoclosing.NoOfPreview = baSageInfoClosing.NoOfPreview;
                        sageinfoclosing.NoOfImageSold = baSageInfoClosing.NoOfImageSold;
                        sageinfoclosing.Comments = baSageInfoClosing.Comments;
                        sageinfoclosing.ClosingDate = baSageInfoClosing.ClosingDate;
                        sageinfoclosing.FilledBy = baSageInfoClosing.FilledBy;
                        sageinfoclosing.FilledBySyncCode = baSageInfoClosing.FilledBySyncCode;
                        sageinfoclosing.OpenCloseProcDetailID = baSageInfoClosing.OpenCloseProcDetailID;
                        sageinfoclosing.FormTypeID = baSageInfoClosing.FormTypeID;
                        sageinfoclosing.TransDate = baSageInfoClosing.TransDate;
                        sageinfoclosing.Cash = baSageInfoClosing.Cash;
                        sageinfoclosing.CreditCard = baSageInfoClosing.CreditCard;
                        sageinfoclosing.Amex = baSageInfoClosing.Amex;
                        sageinfoclosing.FCV = baSageInfoClosing.FCV;
                        sageinfoclosing.RoomCharges = baSageInfoClosing.RoomCharges;
                        sageinfoclosing.KVL = baSageInfoClosing.KVL;
                        sageinfoclosing.Vouchers = baSageInfoClosing.Vouchers;
                        sageinfoclosing.SixEightPrintCount = baSageInfoClosing.SixEightPrintCount;
                        sageinfoclosing.EightTenPrintCount = baSageInfoClosing.EightTenPrintCount;
                        sageinfoclosing.PosterPrintCount = baSageInfoClosing.PosterPrintCount;
                        sageinfoclosing.SyncCode = baSageInfoClosing.SyncCode;
                        sageinfoclosing.OpeningDate = baSageInfoClosing.OpeningDate;
                        sageinfoclosing.IsActive = baSageInfoClosing.IsActive;

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
                    var obj = db.SageInfoClosings.Where(p => p.Id == Id).FirstOrDefault();
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
