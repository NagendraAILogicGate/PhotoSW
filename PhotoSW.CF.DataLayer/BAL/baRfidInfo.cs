using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
{
    public class baRfidInfo
    {
        public long Id { get; set; }
        public long ImixConfigValueID { get; set; }
        public long ImixConfigMasterID { get; set; }
        public string ImixConfigMasterName { get; set; }
        public string ConfigurationValue { get; set; }
        public int SubStoreId { get; set; }
        public string SubStoreName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<rfidinfo> lst_rfidinfo = new List<rfidinfo>();

            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                   
                    rfidinfo rfidinfo = new rfidinfo();

                    rfidinfo.Id = 1;
                    rfidinfo.ImixConfigValueID = 1;
                    rfidinfo.ImixConfigMasterID = 1;
                    rfidinfo.ImixConfigMasterName = "1";
                    rfidinfo.ConfigurationValue = "1";
                    rfidinfo.SubStoreId = 1;
                    rfidinfo.SubStoreName = "1";
                    rfidinfo.LocationId = 1;
                    rfidinfo.LocationName = "Bhopal";
                    rfidinfo.IsActive = true;


                    lst_rfidinfo.Add(rfidinfo);
                    
                    var Id = lst_rfidinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.RfidInfos.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.RfidInfos.AddRange(lst_rfidinfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.RfidInfos.AddRange(lst_rfidinfo);
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
        public static baRfidInfo GetRfidInfoDataById(int Id)
        {
            try
            {

                rfidinfo rfidinfo = new rfidinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.RfidInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baRfidInfo
                    {
                          Id = p.Id,
                          ImixConfigValueID =p.ImixConfigValueID,
                          ImixConfigMasterID =p.ImixConfigMasterID,
                          ImixConfigMasterName =p.ImixConfigMasterName,
                          ConfigurationValue =p.ConfigurationValue,
                          SubStoreId =p.SubStoreId,
                          SubStoreName =p.SubStoreName,
                          LocationId =p.LocationId,
                          LocationName =p.LocationName,
                          IsActive =p.IsActive


                    }).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }
        public static List<baRfidInfo> GetRfidInfoData()
        {
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.RfidInfos.Where(p =>  p.IsActive == true).Select(p => new baRfidInfo
                    {
                        Id = p.Id,
                        ImixConfigValueID = p.ImixConfigValueID,
                        ImixConfigMasterID = p.ImixConfigMasterID,
                        ImixConfigMasterName = p.ImixConfigMasterName,
                        ConfigurationValue = p.ConfigurationValue,
                        SubStoreId = p.SubStoreId,
                        SubStoreName = p.SubStoreName,
                        LocationId = p.LocationId,
                        LocationName = p.LocationName,
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

        public static bool Insert ( baCashBoxInfo baCashBoxInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
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
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baCashBoxInfo baCashBoxInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RfidInfos.Where(p => p.Id == baCashBoxInfo.Id).FirstOrDefault();
                    if(obj != null)
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
                    var obj = db.RfidInfos.Where(p => p.Id == Id).FirstOrDefault();
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
