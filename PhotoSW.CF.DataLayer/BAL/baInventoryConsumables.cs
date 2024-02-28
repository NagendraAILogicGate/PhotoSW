using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baInventoryConsumables
        {
        public long Id { get; set; }
        public long InventoryConsumablesID { get; set; }
        public long AccessoryID { get; set; }
        public long ConsumeValue { get; set; }
        public string AccessoryName { get; set; }
        public string AccessorySyncCode { get; set; }
        public string AccessoryCode { get; set; }
        public bool? IsActive { get; set; }


        public static bool Marge ()
            {
            List<inventoryconsumables> lst_inventoryconsumables = new List<inventoryconsumables>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    inventoryconsumables inventoryconsumables = new inventoryconsumables();

                    inventoryconsumables.Id = 1;
                    inventoryconsumables.InventoryConsumablesID = 2;
                    inventoryconsumables.AccessoryID = 3;
                    inventoryconsumables.ConsumeValue = 4;
                    inventoryconsumables.AccessoryName = "";
                    inventoryconsumables.AccessorySyncCode = "";
                    inventoryconsumables.AccessoryCode = "";
                    inventoryconsumables.IsActive = true;

                    lst_inventoryconsumables.Add(inventoryconsumables);

                    var Id = lst_inventoryconsumables.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.InventoryConsumableses.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.InventoryConsumableses.AddRange(lst_inventoryconsumables);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.InventoryConsumableses.AddRange(lst_inventoryconsumables);
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

        public static baInventoryConsumables GetInventoryConsumablesById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.InventoryConsumableses.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baInventoryConsumables
                        {
                        Id = p.Id,
                        InventoryConsumablesID = p.InventoryConsumablesID,
                        AccessoryID = p.AccessoryID,
                        ConsumeValue = p.ConsumeValue,
                        AccessoryName = p.AccessoryName,
                        AccessorySyncCode = p.AccessorySyncCode,
                        AccessoryCode = p.AccessoryCode,
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

        public static List<baInventoryConsumables> GetInventoryConsumablesData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.InventoryConsumableses.Where(p => p.IsActive == true).Select(p => new baInventoryConsumables
                        {
                        Id = p.Id,
                        InventoryConsumablesID = p.InventoryConsumablesID,
                        AccessoryID = p.AccessoryID,
                        ConsumeValue = p.ConsumeValue,
                        AccessoryName = p.AccessoryName,
                        AccessorySyncCode = p.AccessorySyncCode,
                        AccessoryCode = p.AccessoryCode,
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

        public static bool Insert ( baInventoryConsumables baInventoryConsumables )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    inventoryconsumables inventoryconsumables = new inventoryconsumables();

                    inventoryconsumables.Id = baInventoryConsumables.Id;
                    inventoryconsumables.InventoryConsumablesID = baInventoryConsumables.InventoryConsumablesID;
                    inventoryconsumables.AccessoryID = baInventoryConsumables.AccessoryID;
                    inventoryconsumables.ConsumeValue = baInventoryConsumables.ConsumeValue;
                    inventoryconsumables.AccessoryName = baInventoryConsumables.AccessoryName;
                    inventoryconsumables.AccessorySyncCode = baInventoryConsumables.AccessorySyncCode;
                    inventoryconsumables.AccessoryCode = baInventoryConsumables.AccessoryCode;
                    inventoryconsumables.IsActive = baInventoryConsumables.IsActive;

                    db.InventoryConsumableses.Add(inventoryconsumables);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baInventoryConsumables baInventoryConsumables )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.InventoryConsumableses.Where(p => p.Id == baInventoryConsumables.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        inventoryconsumables inventoryconsumables = new inventoryconsumables();

                        inventoryconsumables.Id = baInventoryConsumables.Id;
                        inventoryconsumables.InventoryConsumablesID = baInventoryConsumables.InventoryConsumablesID;
                        inventoryconsumables.AccessoryID = baInventoryConsumables.AccessoryID;
                        inventoryconsumables.ConsumeValue = baInventoryConsumables.ConsumeValue;
                        inventoryconsumables.AccessoryName = baInventoryConsumables.AccessoryName;
                        inventoryconsumables.AccessorySyncCode = baInventoryConsumables.AccessorySyncCode;
                        inventoryconsumables.AccessoryCode = baInventoryConsumables.AccessoryCode;
                        inventoryconsumables.IsActive = baInventoryConsumables.IsActive;


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
                    var obj = db.InventoryConsumableses.Where(p => p.Id == Id).FirstOrDefault();
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
