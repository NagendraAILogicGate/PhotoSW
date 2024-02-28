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
    
	public class baDeviceInfo
    {
      
        public long Id { get; set; }
        public int DeviceId { get; set; }

        public string Name { get; set; }

        public string BDA { get; set; }

        public string SerialNo { get; set; }

        public int DeviceTypeId { get; set; }

        public string DeviceTypeName { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsChecked { get; set; }

        public int DeviceSessionId { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<deviceinfo> lst_deviceinfo = new List<deviceinfo>();

            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    //foreach (var item in lst_str)
                    //{
                    deviceinfo deviceinfo = new deviceinfo();

                   deviceinfo.Id = 1;
                   deviceinfo.DeviceId = 1;
                   deviceinfo.Name = "";
                   deviceinfo.BDA = "";
                   deviceinfo.SerialNo = "";
                   deviceinfo.DeviceTypeId = 1;
                   deviceinfo.DeviceTypeName = "";
                   deviceinfo.CreatedBy = 1;//DateTime.Now;
                   deviceinfo.CreatedDate = DateTime.Now;
                   deviceinfo.IsChecked = true;
                   deviceinfo.DeviceSessionId = 1;
                   deviceinfo.IsActive = true;


                   lst_deviceinfo.Add(deviceinfo);
                    // }
                   var Id = lst_deviceinfo.Where(t => t.Id == 1).First().Id;
                   var IsExist = db.DeviceInfos.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.DeviceInfos.AddRange(lst_deviceinfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.DeviceInfos.AddRange(lst_deviceinfo);
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
        public static baDeviceInfo GetDeviceInfoDataById(int Id)
        {
            try
            {

                deviceinfo deviceinfo = new deviceinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.DeviceInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baDeviceInfo
                    {
                        Id = p.Id,
                        DeviceId = p.DeviceId,
                        Name = p.Name,
                        BDA = p.BDA,
                        SerialNo = p.SerialNo,
                        DeviceTypeId = p.DeviceTypeId,
                        DeviceTypeName = p.DeviceTypeName,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        IsChecked = p.IsChecked,
                        DeviceSessionId = p.DeviceSessionId,
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
        public static List<baDeviceInfo> GetDeviceInfoData()
        {
            try
            {

                deviceinfo deviceinfo = new deviceinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.DeviceInfos.Where(p => p.IsActive == true).Select(p => new baDeviceInfo
                    {
                        Id = p.Id,
                        DeviceId = p.DeviceId,
                        Name = p.Name,
                        BDA = p.BDA,
                        SerialNo = p.SerialNo,
                        DeviceTypeId = p.DeviceTypeId,
                        DeviceTypeName = p.DeviceTypeName,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        IsChecked = p.IsChecked,
                        DeviceSessionId = p.DeviceSessionId,
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

        public static bool Insert ( baDeviceInfo baDeviceInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    deviceinfo deviceinfo = new deviceinfo();

                    deviceinfo.Id = baDeviceInfo.Id;
                    deviceinfo.DeviceId = baDeviceInfo.DeviceId;
                    deviceinfo.Name = baDeviceInfo.Name;
                    deviceinfo.BDA = baDeviceInfo.BDA;
                    deviceinfo.SerialNo = baDeviceInfo.SerialNo;
                    deviceinfo.DeviceTypeId = baDeviceInfo.DeviceTypeId;
                    deviceinfo.DeviceTypeName = baDeviceInfo.DeviceTypeName;
                    deviceinfo.CreatedBy = baDeviceInfo.CreatedBy;
                    deviceinfo.CreatedDate = baDeviceInfo.CreatedDate;
                    deviceinfo.IsChecked = baDeviceInfo.IsChecked;
                    deviceinfo.DeviceSessionId = baDeviceInfo.DeviceSessionId;
                    deviceinfo.IsActive = baDeviceInfo.IsActive;

                    db.DeviceInfos.Add(deviceinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baDeviceInfo baDeviceInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.DeviceInfos.Where(p => p.Id == baDeviceInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        deviceinfo deviceinfo = new deviceinfo();

                        deviceinfo.Id = baDeviceInfo.Id;
                        deviceinfo.DeviceId = baDeviceInfo.DeviceId;
                        deviceinfo.Name = baDeviceInfo.Name;
                        deviceinfo.BDA = baDeviceInfo.BDA;
                        deviceinfo.SerialNo = baDeviceInfo.SerialNo;
                        deviceinfo.DeviceTypeId = baDeviceInfo.DeviceTypeId;
                        deviceinfo.DeviceTypeName = baDeviceInfo.DeviceTypeName;
                        deviceinfo.CreatedBy = baDeviceInfo.CreatedBy;
                        deviceinfo.CreatedDate = baDeviceInfo.CreatedDate;
                        deviceinfo.IsChecked = baDeviceInfo.IsChecked;
                        deviceinfo.DeviceSessionId = baDeviceInfo.DeviceSessionId;
                        deviceinfo.IsActive = baDeviceInfo.IsActive;

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
                    var obj = db.DeviceInfos.Where(p => p.Id == Id).FirstOrDefault();
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
