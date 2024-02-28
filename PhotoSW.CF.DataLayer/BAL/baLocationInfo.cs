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
	public class baLocationInfo
	{
        public long Id { get; set; }
        public int Location_pkey { get; set; }
        public string Location_Name { get; set; }
        public int Store_ID { get; set; }
        public int SubStore_Location_Pkey { get; set; }
		public string Location_PhoneNumber{ get; set; }
        public bool Location_IsActive { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public int SubStore_ID { get; set; }
        public int Location_ID { get; set; }
        public bool? IsActive { get; set; }
        public static bool Marge()
        {
            List<locationinfo> lst_locationinfo = new List<locationinfo>();
            List<long> lst_str = new List<long>();
            //lst_str.Add(1);
            //lst_str.Add(2);
            //lst_str.Add(3);
            //lst_str.Add(4);
            //lst_str.Add(5);
            //lst_str.Add(6);

            //lst_str.Add(7);
            //lst_str.Add(8);
            //lst_str.Add(9);
            //lst_str.Add(10);
            //lst_str.Add(11);
            //lst_str.Add(12);

            //lst_str.Add(13);
            //lst_str.Add(14);
            //lst_str.Add(15);
            //lst_str.Add(16);
            //try
            //{
            //    using (PhotoSWEntities db = new PhotoSWEntities())
            //    {
            //        foreach (var item in lst_str)
            //        {
            //            locationinfo locationinfo = new locationinfo();

            //            locationinfo.Id = item;
            //            locationinfo.Location_pkey = (int)item;

            //            if (item == 1)
            //            {
            //                locationinfo.Location_Name = "Bhopal";
            //                locationinfo.Store_ID = 1;
            //                locationinfo.SubStore_Location_Pkey = 1;
            //            }
            //            if (item == 2)
            //            {
            //                locationinfo.Location_Name = "Indoe";
            //                locationinfo.Store_ID = 1;
            //                locationinfo.SubStore_Location_Pkey = 2;
            //            }
            //            if (item == 3)
            //            {
            //                locationinfo.Location_Name = "Jabalpur";
            //                locationinfo.Store_ID = 1;
            //                locationinfo.SubStore_Location_Pkey = 3;
            //            }
            //            if (item == 4)
            //            {
            //                locationinfo.Location_Name = "Sagar";
            //                locationinfo.Store_ID = 1;
            //                locationinfo.SubStore_Location_Pkey = 4;
            //            }

            //            if (item == 5)
            //            {
            //                locationinfo.Location_Name = "Bhopal";
            //                locationinfo.Store_ID = 2;
            //                locationinfo.SubStore_Location_Pkey = 1;
            //            }
            //            if (item == 6)
            //            {
            //                locationinfo.Location_Name = "Indoe";
            //                locationinfo.Store_ID = 2;
            //                locationinfo.SubStore_Location_Pkey = 2;
            //            }
            //            if (item == 7)
            //            {
            //                locationinfo.Location_Name = "Jabalpur";
            //                locationinfo.Store_ID = 2;
            //                locationinfo.SubStore_Location_Pkey = 3;
            //            }
            //            if (item == 8)
            //            {
            //                locationinfo.Location_Name = "Sagar";
            //                locationinfo.Store_ID = 2;
            //                locationinfo.SubStore_Location_Pkey = 4;
            //            }
            //            if (item == 9)
            //            {
            //                locationinfo.Location_Name = "Bhopal";
            //                locationinfo.Store_ID = 3;
            //                locationinfo.SubStore_Location_Pkey = 1;
            //            }
            //            if (item == 10)
            //            {
            //                locationinfo.Location_Name = "Indoe";
            //                locationinfo.Store_ID = 3;
            //                locationinfo.SubStore_Location_Pkey = 2;
            //            }
            //            if (item == 11)
            //            {
            //                locationinfo.Location_Name = "Jabalpur";
            //                locationinfo.Store_ID = 3;
            //                locationinfo.SubStore_Location_Pkey = 3;
            //            }
            //            if (item == 12)
            //            {
            //                locationinfo.Location_Name = "Sagar";
            //                locationinfo.Store_ID = 3;
            //                locationinfo.SubStore_Location_Pkey = 4;
            //            }

            //            if (item == 13)
            //            {
            //                locationinfo.Location_Name = "Bhopal";
            //                locationinfo.Store_ID = 0;
            //                locationinfo.SubStore_Location_Pkey = 1;
            //            }
            //            if (item == 14)
            //            {
            //                locationinfo.Location_Name = "Indore";
            //                locationinfo.Store_ID = 0;
            //                locationinfo.SubStore_Location_Pkey = 2;
            //            }
            //            if (item == 15)
            //            {
            //                locationinfo.Location_Name = "Jabalpur";
            //                locationinfo.Store_ID = 0;
            //                locationinfo.SubStore_Location_Pkey = 3;
            //            }
            //            if (item == 16)
            //            {
            //                locationinfo.Location_Name = "Sagar";
            //                locationinfo.Store_ID = 0;
            //                locationinfo.SubStore_Location_Pkey = 4;
            //            }

            //            locationinfo.Location_PhoneNumber = "752421411";
            //            locationinfo.Location_IsActive = true;
            //            locationinfo.SyncCode = "211";
            //            locationinfo.IsSynced = true;
            //            locationinfo.SubStore_ID = 3;
            //            locationinfo.Location_ID = 1;
            //            locationinfo.IsActive = true;


            //            lst_locationinfo.Add(locationinfo);
            //        }
            //        var Id = lst_locationinfo.Where(t => t.Id == 1).First().Id;
            //        var IsExist = db.LocationInfos.Where(p => lst_str.Contains(p.Id)).ToList();
            //        if (IsExist == null)
            //        {
            //            db.LocationInfos.AddRange(lst_locationinfo);
            //            db.SaveChanges();
            //        }
            //        else if (IsExist.Count == 0)
            //        {
            //            db.LocationInfos.AddRange(lst_locationinfo);
            //            db.SaveChanges();
            //        }
            //        return true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return false;
                
            //}
            return false;
        }

        public static baLocationInfo GetLocationInfoDataById(int Id)
        {
            try
            {

                locationinfo locationinfo = new locationinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.LocationInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baLocationInfo
                    {
                        Id = p.Id,
                        Location_pkey = p.Location_pkey,
                        Location_Name = p.Location_Name,
                        Store_ID = p.Store_ID,
                        SubStore_Location_Pkey = p.SubStore_Location_Pkey,
                        Location_PhoneNumber = p.Location_PhoneNumber,
                        Location_IsActive = p.Location_IsActive,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        SubStore_ID = p.SubStore_ID,
                        Location_ID = p.Location_ID,
                        IsActive = true,

                    }).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }
        public static List<baLocationInfo> GetLocationInfoData()
        {
            try
            {

                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.LocationInfos.Where(p => p.IsActive == true).Select(p => new baLocationInfo
                    {
                        Id = p.Id,
                        Location_pkey = p.Location_pkey,
                        Location_Name = p.Location_Name,
                        Store_ID = p.Store_ID,
                        SubStore_Location_Pkey = p.SubStore_Location_Pkey,
                        Location_PhoneNumber = p.Location_PhoneNumber,
                        Location_IsActive = p.Location_IsActive,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        SubStore_ID = p.SubStore_ID,
                        Location_ID = p.Location_ID,
                        IsActive = true,

                    }).ToList();
                    return obj;
                }
            }
            catch
            {
                return null; 
            }
        }

        public static bool Insert ( baLocationInfo baLocationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    locationinfo locationinfo = new locationinfo();

                    locationinfo.Id = baLocationInfo.Id;
                    locationinfo.Location_Name = baLocationInfo.Location_Name;
                    locationinfo.Store_ID = baLocationInfo.Store_ID;
                    locationinfo.SubStore_Location_Pkey = baLocationInfo.SubStore_Location_Pkey;
                    locationinfo.Location_PhoneNumber = baLocationInfo.Location_PhoneNumber;
                    locationinfo.Location_IsActive = baLocationInfo.Location_IsActive;
                    locationinfo.SyncCode = baLocationInfo.SyncCode;
                    locationinfo.IsSynced = baLocationInfo.IsSynced;
                    locationinfo.SubStore_ID = baLocationInfo.SubStore_ID;
                    locationinfo.Location_ID = baLocationInfo.Location_ID;
                    locationinfo.IsActive = baLocationInfo.IsActive;

                    db.LocationInfos.Add(locationinfo);
                    db.SaveChanges();

                    locationinfo.Location_pkey = Convert.ToInt32(baLocationInfo.GetLocationInfoData().OrderByDescending(m => m.Id).FirstOrDefault().Id);
                    db.SaveChanges();
                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baLocationInfo baLocationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.LocationInfos.Where(p => p.Location_pkey == baLocationInfo.Location_pkey).FirstOrDefault();
                    if(obj != null)
                        {
                        //locationinfo locationinfo = new locationinfo();

                        //locationinfo.Id = baLocationInfo.Id;
                        //locationinfo.Location_pkey = baLocationInfo.Location_pkey;
                        //locationinfo.Location_Name = baLocationInfo.Location_Name;
                        //locationinfo.Store_ID = baLocationInfo.Store_ID;
                        //locationinfo.SubStore_Location_Pkey = baLocationInfo.SubStore_Location_Pkey;
                        //locationinfo.Location_PhoneNumber = baLocationInfo.Location_PhoneNumber;
                        //locationinfo.Location_IsActive = baLocationInfo.Location_IsActive;
                        //locationinfo.SyncCode = baLocationInfo.SyncCode;
                        //locationinfo.IsSynced = baLocationInfo.IsSynced;
                        //locationinfo.SubStore_ID = baLocationInfo.SubStore_ID;
                        //locationinfo.Location_ID = baLocationInfo.Location_ID;
                        //locationinfo.IsActive = baLocationInfo.IsActive;

                        obj.Location_Name = baLocationInfo.Location_Name;
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
                    var obj = db.LocationInfos.Where(p => p.Location_pkey == Id).FirstOrDefault();
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
