using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baServicesInfo
        {
        public int Id { get; set; }
        public int PS_Service_Id { get; set; }
        public string PS_Sevice_Name { get; set; }
        public string PS_Service_Display_Name { get; set; }
        public string PS_Service_Path { get; set; }
        public bool? IsInterface { get; set; }
        public long RunLevel { get; set; }
        public bool IsService { get; set; }
        public bool? IsActive { get; set; }



        public static bool Marge ()
            {
            List<servicesinfo> lst_servicesinfo = new List<servicesinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    servicesinfo servicesinfo = new servicesinfo();

                    servicesinfo.Id = 1;
                    servicesinfo.PS_Service_Id = 1;
                    servicesinfo.PS_Sevice_Name = "";
                    servicesinfo.PS_Service_Display_Name = "";
                    servicesinfo.PS_Service_Path = "";
                    servicesinfo.IsInterface = false;
                    servicesinfo.RunLevel = 5;
                    servicesinfo.IsService = false;
                    servicesinfo.IsActive = true;

                    lst_servicesinfo.Add(servicesinfo);

                    var Id = lst_servicesinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ServicesInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.ServicesInfos.AddRange(lst_servicesinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ServicesInfos.AddRange(lst_servicesinfo);
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

        public static baServicesInfo GetServicesInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ServicesInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baServicesInfo
                        {
                        Id = p.Id,
                        PS_Service_Id = p.PS_Service_Id,
                        PS_Sevice_Name = p.PS_Sevice_Name,
                        PS_Service_Display_Name = p.PS_Service_Display_Name,
                        PS_Service_Path = p.PS_Service_Path,
                        IsInterface = p.IsInterface,
                        RunLevel = p.RunLevel,
                        IsService = p.IsService,                      
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

        public static List<baServicesInfo> GetServicesInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ServicesInfos.Where(p => p.IsActive == true).Select(p => new baServicesInfo
                        {
                        Id = p.Id,
                        PS_Service_Id = p.PS_Service_Id,
                        PS_Sevice_Name = p.PS_Sevice_Name,
                        PS_Service_Display_Name = p.PS_Service_Display_Name,
                        PS_Service_Path = p.PS_Service_Path,
                        IsInterface = p.IsInterface,
                        RunLevel = p.RunLevel,
                        IsService = p.IsService,
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

        public static bool Insert ( baServicesInfo baServicesInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    servicesinfo servicesinfo = new servicesinfo();

                    servicesinfo.Id = baServicesInfo.Id;
                    servicesinfo.PS_Service_Id = baServicesInfo.PS_Service_Id;
                    servicesinfo.PS_Sevice_Name = baServicesInfo.PS_Sevice_Name;
                    servicesinfo.PS_Service_Display_Name = baServicesInfo.PS_Service_Display_Name;
                    servicesinfo.PS_Service_Path = baServicesInfo.PS_Service_Path;
                    servicesinfo.IsInterface = baServicesInfo.IsInterface;
                    servicesinfo.RunLevel = baServicesInfo.RunLevel;
                    servicesinfo.IsService = baServicesInfo.IsService;
                    servicesinfo.IsActive = baServicesInfo.IsActive;

                    db.ServicesInfos.Add(servicesinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baServicesInfo baServicesInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ServicesInfos.Where(p => p.Id == baServicesInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        servicesinfo servicesinfo = new servicesinfo();

                        servicesinfo.Id = baServicesInfo.Id;
                        servicesinfo.PS_Service_Id = baServicesInfo.PS_Service_Id;
                        servicesinfo.PS_Sevice_Name = baServicesInfo.PS_Sevice_Name;
                        servicesinfo.PS_Service_Display_Name = baServicesInfo.PS_Service_Display_Name;
                        servicesinfo.PS_Service_Path = baServicesInfo.PS_Service_Path;
                        servicesinfo.IsInterface = baServicesInfo.IsInterface;
                        servicesinfo.RunLevel = baServicesInfo.RunLevel;
                        servicesinfo.IsService = baServicesInfo.IsService;
                        servicesinfo.IsActive = baServicesInfo.IsActive;

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
                    var obj = db.ServicesInfos.Where(p => p.Id == Id).FirstOrDefault();
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
