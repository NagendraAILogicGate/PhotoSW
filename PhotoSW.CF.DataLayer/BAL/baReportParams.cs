using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baReportParams
        {
        public int Id { get; set; }
        public string ReportType { get; set; }
        public Dictionary<string, string> ReportFormats { get; set; }
        public bool? IsActive { get; set; }


        public static bool Marge ()
            {
            List<reportparams> lst_reportparams = new List<reportparams>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    reportparams reportparams = new reportparams();

                    reportparams.Id = 1;
                    reportparams.ReportType = "Report";
                   // reportparams.ReportFormats = "";
                    reportparams.IsActive = true;

                    lst_reportparams.Add(reportparams);

                    var Id = lst_reportparams.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ReportParamses.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.ReportParamses.AddRange(lst_reportparams);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ReportParamses.AddRange(lst_reportparams);
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

        public static baReportParams GetReportParamsDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ReportParamses.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baReportParams
                        {
                        Id = p.Id,
                        ReportType = p.ReportType,
                       // ReportFormats = p.ReportFormats,                      
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

        public static List<baReportParams> GetReportParamsData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ReportParamses.Where(p => p.IsActive == true).Select(p => new baReportParams
                        {
                        Id = p.Id,
                        ReportType = p.ReportType,
                        //ReportFormats = p.ReportFormats,
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

        public static bool Insert ( baReportParams baReportParams )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    reportparams reportparams = new reportparams();

                    reportparams.Id = baReportParams.Id;
                    reportparams.ReportType = baReportParams.ReportType;
                    reportparams.IsActive = baReportParams.IsActive;

                    db.ReportParamses.Add(reportparams);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baReportParams baReportParams )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ReportParamses.Where(p => p.Id == baReportParams.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        reportparams reportparams = new reportparams();

                        reportparams.Id = baReportParams.Id;
                        reportparams.ReportType = baReportParams.ReportType;
                        reportparams.IsActive = baReportParams.IsActive;

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
                    var obj = db.ReportParamses.Where(p => p.Id == Id).FirstOrDefault();
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
