using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baRFIDField
        {
        public int Id { get; set; }
        public int RFId { get; set; }
        public int DeviceID { get; set; }
        public string SerialNo { get; set; }
        public string HotFolderpath { get; set; }
        public int SubStoreID { get; set; }
        public bool? IsActive { get; set; }


        public static bool Marge ()
            {
            List<rfidfield> lst_rfidfield = new List<rfidfield>();
            List<int> lst_str = new List<int>();
            lst_str.Add(1);
            lst_str.Add(2);
            lst_str.Add(3);
            lst_str.Add(4);
            lst_str.Add(5);
            lst_str.Add(6);
            lst_str.Add(7);
            lst_str.Add(8);
            lst_str.Add(9);
            lst_str.Add(10);
            lst_str.Add(11);
            lst_str.Add(12);
            lst_str.Add(11);
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    int id = 3021;
                    foreach(var item in lst_str)
                        {
                        rfidfield rfidfield = new rfidfield();

                        rfidfield.Id = 1;
                        rfidfield.DeviceID = 1;
                        rfidfield.RFId = 3021;
                        rfidfield.SerialNo =Convert.ToString( id++);
                        rfidfield.HotFolderpath = "HotFolderpath\\";
                        rfidfield.SubStoreID = 3;
                        rfidfield.IsActive = true;

                        lst_rfidfield.Add(rfidfield);
                        }
                        var Id = lst_rfidfield.Where(t => t.Id == 1).First().Id;
                        var IsExist = db.RFIDFields.Where(p => lst_str.Contains(p.Id)).ToList();
                        if(IsExist == null)
                            {
                            db.RFIDFields.AddRange(lst_rfidfield);
                            db.SaveChanges();
                            }
                        else if(IsExist.Count == 0)
                            {
                            db.RFIDFields.AddRange(lst_rfidfield);
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

        public static baRFIDField GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RFIDFields.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baRFIDField
                        {
                        Id = p.Id,
                        RFId=p.RFId,
                        DeviceID = p.DeviceID,
                        SerialNo = p.SerialNo,
                        HotFolderpath = p.HotFolderpath,
                        SubStoreID = p.SubStoreID,                     
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

        public static List<baRFIDField> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RFIDFields.Where(p => p.IsActive == true).Select(p => new baRFIDField
                        {
                        Id = p.Id,
                        RFId = p.RFId,
                        DeviceID = p.DeviceID,
                        SerialNo = p.SerialNo,
                        HotFolderpath = p.HotFolderpath,
                        SubStoreID = p.SubStoreID,
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

        public static bool Insert ( baRFIDField baRFIDField )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    rfidfield rfidfield = new rfidfield();

                    rfidfield.Id = baRFIDField.Id;
                    rfidfield.RFId = baRFIDField.RFId;
                    rfidfield.DeviceID = baRFIDField.DeviceID;
                    rfidfield.SerialNo = baRFIDField.SerialNo;
                    rfidfield.HotFolderpath = baRFIDField.HotFolderpath;
                    rfidfield.SubStoreID = baRFIDField.SubStoreID;
                    rfidfield.IsActive = baRFIDField.IsActive;

                    db.RFIDFields.Add(rfidfield);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baRFIDField baRFIDField )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RFIDFields.Where(p => p.Id == baRFIDField.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        rfidfield rfidfield = new rfidfield();

                        rfidfield.Id = baRFIDField.Id;
                        rfidfield.RFId = baRFIDField.RFId;
                        rfidfield.DeviceID = baRFIDField.DeviceID;
                        rfidfield.SerialNo = baRFIDField.SerialNo;
                        rfidfield.HotFolderpath = baRFIDField.HotFolderpath;
                        rfidfield.SubStoreID = baRFIDField.SubStoreID;
                        rfidfield.IsActive = baRFIDField.IsActive;

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
                    var obj = db.RFIDFields.Where(p => p.Id == Id).FirstOrDefault();
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
