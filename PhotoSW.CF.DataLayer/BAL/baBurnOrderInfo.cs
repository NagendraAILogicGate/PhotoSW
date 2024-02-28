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
    public class baBurnOrderInfo
        {
        public long Id { get; set; }
        public string OrderNumber { get; set; }
        public int OrderDetailId { get; set; }
        public int ProductType { get; set; }
        public string PhotosId { get; set; }
        public int Status { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<burnorderinfo> lst_burnorderinfo = new List<burnorderinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    burnorderinfo burnorderinfo = new burnorderinfo();

                    burnorderinfo.Id = 1;
                    burnorderinfo.OrderNumber = "";
                    burnorderinfo.OrderDetailId = 2;
                    burnorderinfo.ProductType = 1;
                    burnorderinfo.PhotosId = "";
                    burnorderinfo.Status = 1;
                    burnorderinfo.IsActive = true;


                    lst_burnorderinfo.Add(burnorderinfo);

                    var Id = lst_burnorderinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.BurnOrderInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.BurnOrderInfos.AddRange(lst_burnorderinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.BurnOrderInfos.AddRange(lst_burnorderinfo);
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

        public static baBurnOrderInfo GetBurnOrderInfoDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.BurnOrderInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baBurnOrderInfo
                        {
                        Id = p.Id,
                        OrderNumber = p.OrderNumber,
                        OrderDetailId = p.OrderDetailId,
                        ProductType = p.ProductType,
                        PhotosId = p.PhotosId,
                        Status = p.Status,                                     
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

        public static List<baBurnOrderInfo> GetBurnOrderInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.BurnOrderInfos.Where(p => p.IsActive == true).Select(p => new baBurnOrderInfo
                        {
                        Id = p.Id,
                        OrderNumber = p.OrderNumber,
                        OrderDetailId = p.OrderDetailId,
                        ProductType = p.ProductType,
                        PhotosId = p.PhotosId,
                        Status = p.Status,
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

        public static bool Insert ( baBurnOrderInfo baBurnOrderInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    burnorderinfo burnorderinfo = new burnorderinfo();

                    burnorderinfo.Id = baBurnOrderInfo.Id;
                    burnorderinfo.OrderNumber = baBurnOrderInfo.OrderNumber;
                    burnorderinfo.OrderDetailId = baBurnOrderInfo.OrderDetailId;
                    burnorderinfo.ProductType = baBurnOrderInfo.ProductType;
                    burnorderinfo.PhotosId = baBurnOrderInfo.PhotosId;
                    burnorderinfo.Status = baBurnOrderInfo.Status;
                    burnorderinfo.IsActive = baBurnOrderInfo.IsActive;

                    db.BurnOrderInfos.Add(burnorderinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baBurnOrderInfo baBurnOrderInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.BurnOrderInfos.Where(p => p.Id == baBurnOrderInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        burnorderinfo burnorderinfo = new burnorderinfo();
                        burnorderinfo.Id = baBurnOrderInfo.Id;
                        burnorderinfo.OrderNumber = baBurnOrderInfo.OrderNumber;
                        burnorderinfo.OrderDetailId = baBurnOrderInfo.OrderDetailId;
                        burnorderinfo.ProductType = baBurnOrderInfo.ProductType;
                        burnorderinfo.PhotosId = baBurnOrderInfo.PhotosId;
                        burnorderinfo.Status = baBurnOrderInfo.Status;
                        burnorderinfo.IsActive = baBurnOrderInfo.IsActive;

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
                    var obj = db.BurnOrderInfos.Where(p => p.Id == Id).FirstOrDefault();
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
