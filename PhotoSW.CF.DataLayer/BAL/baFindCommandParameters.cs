using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baFindCommandParameters
        {
        public long Id { get; set; }
        public string Text { get; set; }
        public string IgnoreCase { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<findcommandparameters> lst_findcommandparameters = new List<findcommandparameters>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    findcommandparameters findcommandparameters = new findcommandparameters();

                    findcommandparameters.Id = 1;
                    findcommandparameters.Text = "";
                    findcommandparameters.IgnoreCase = "";
                    findcommandparameters.IsActive = true;

                    lst_findcommandparameters.Add(findcommandparameters);

                    var Id = lst_findcommandparameters.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.FindCommandParameterses.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.FindCommandParameterses.AddRange(lst_findcommandparameters);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.FindCommandParameterses.AddRange(lst_findcommandparameters);
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

        public static baFindCommandParameters GetFindCommandParametersDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.FindCommandParameterses.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baFindCommandParameters
                        {
                        Id = p.Id,
                        Text = p.Text,
                        IgnoreCase = p.IgnoreCase,                      
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

        public static List<baFindCommandParameters> GetFindCommandParametersData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.FindCommandParameterses.Where(p => p.IsActive == true).Select(p => new baFindCommandParameters
                        {
                        Id = p.Id,
                        Text = p.Text,
                        IgnoreCase = p.IgnoreCase,
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

        public static bool Insert ( baFindCommandParameters baFindCommandParameters )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    findcommandparameters findcommandparameters = new findcommandparameters();

                    findcommandparameters.Id = baFindCommandParameters.Id;
                    findcommandparameters.Text = baFindCommandParameters.Text;
                    findcommandparameters.IgnoreCase = baFindCommandParameters.IgnoreCase;
                    findcommandparameters.IsActive = baFindCommandParameters.IsActive;

                    db.FindCommandParameterses.Add(findcommandparameters);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baFindCommandParameters baFindCommandParameters )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.FindCommandParameterses.Where(p => p.Id == baFindCommandParameters.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        findcommandparameters findcommandparameters = new findcommandparameters();

                        findcommandparameters.Id = baFindCommandParameters.Id;
                        findcommandparameters.Text = baFindCommandParameters.Text;
                        findcommandparameters.IgnoreCase = baFindCommandParameters.IgnoreCase;
                        findcommandparameters.IsActive = baFindCommandParameters.IsActive;
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
                    var obj = db.FindCommandParameterses.Where(p => p.Id == Id).FirstOrDefault();
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
