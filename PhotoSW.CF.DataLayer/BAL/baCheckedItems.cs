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
    public class baCheckedItems
        {
        public long Id { get; set; }
        public string SelectetdItems { get; set; }
        public int LineItemId { get; set; }
        public decimal? RefundPrice { get; set; }
        public string Reason { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<checkeditems> lst_checkeditems = new List<checkeditems>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    checkeditems checkeditems = new checkeditems();

                    checkeditems.Id = 1;
                    checkeditems.SelectetdItems = "";
                    checkeditems.LineItemId = 2;
                    checkeditems.RefundPrice = 1;
                    checkeditems.Reason = "";
                    checkeditems.IsActive = true;

                    lst_checkeditems.Add(checkeditems);

                    var Id = lst_checkeditems.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.CheckedItemses.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.CheckedItemses.AddRange(lst_checkeditems);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.CheckedItemses.AddRange(lst_checkeditems);
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

        public static baCheckedItems GetCheckedItemsDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.CheckedItemses.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baCheckedItems
                        {
                        Id = p.Id,
                        SelectetdItems = p.SelectetdItems,
                        LineItemId = p.LineItemId,
                        RefundPrice = p.RefundPrice,
                        Reason = p.Reason,
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

        public static List<baCheckedItems> GetCheckedItemsData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.CheckedItemses.Where(p => p.IsActive == true).Select(p => new baCheckedItems
                        {
                        Id = p.Id,
                        SelectetdItems = p.SelectetdItems,
                        LineItemId = p.LineItemId,
                        RefundPrice = p.RefundPrice,
                        Reason = p.Reason,
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

        public static bool Delete ( int Id )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.CheckedItemses.Where(p => p.Id == Id).FirstOrDefault();
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
