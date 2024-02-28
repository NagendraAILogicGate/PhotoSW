using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baGumRide
        {
        public long Id { get; set; }
        public int Locationid { get; set; }
        public string LocationName { get; set; }
        public decimal FontSize { get; set; }
        public string FontColor { get; set; }
        public string FontWeight { get; set; }
        public string BackgroundColor { get; set; }
        public string Margin { get; set; }
        public string FilePath { get; set; }
        public string PhotoPath { get; set; }
        public string IsGumbleRideActive { get; set; }
        public string Position { get; set; }
        public string IsSpecGumbRide { get; set; }
        public string FontStyle { get; set; }
        public string FontFamily { get; set; }
        public string TimeOut { get; set; }
        public string IsPrefixActiveFlow { get; set; }
        public string PrefixPhotoName { get; set; }
        public string PrefixScoreFileName { get; set; }
        public string GumballScoreSeperater { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<gumride> lst_gumride = new List<gumride>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    gumride gumride = new gumride();

                    gumride.Id = 1;
                    gumride.Locationid = 2;
                    gumride.LocationName = "";
                    gumride.FontSize = 2;
                    gumride.FontColor = "";
                    gumride.FontWeight = "";
                    gumride.BackgroundColor = "";
                    gumride.Margin = "";
                    gumride.FilePath = "";
                    gumride.PhotoPath = "";
                    gumride.IsGumbleRideActive = "";
                    gumride.Position = "";
                    gumride.IsSpecGumbRide = "";
                    gumride.FontStyle = "";
                    gumride.FontFamily = "";
                    gumride.TimeOut = "";
                    gumride.IsPrefixActiveFlow = "";
                    gumride.PrefixPhotoName = "";
                    gumride.PrefixScoreFileName = "";
                    gumride.GumballScoreSeperater = "";
                    gumride.IsActive = true;

                    lst_gumride.Add(gumride);

                    var Id = lst_gumride.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.GumRides.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.GumRides.AddRange(lst_gumride);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.GumRides.AddRange(lst_gumride);
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

        public static baGumRide GetGumRideDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GumRides.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baGumRide
                        {
                            Id = p.Id,
                            Locationid = p.Locationid,
                            LocationName = p.LocationName,
                            FontSize = p.FontSize,
                            FontColor = p.FontColor,
                            FontWeight = p.FontWeight,
                            BackgroundColor = p.BackgroundColor,
                            Margin = p.Margin,
                            FilePath = p.FilePath,
                            PhotoPath = p.PhotoPath,
                            IsGumbleRideActive = p.IsGumbleRideActive,
                            Position = p.Position,
                            IsSpecGumbRide = p.IsSpecGumbRide,
                            FontStyle = p.FontStyle,
                            FontFamily = p.FontFamily,
                            TimeOut = p.TimeOut,
                            IsPrefixActiveFlow = p.IsPrefixActiveFlow,
                            PrefixPhotoName = p.PrefixPhotoName,
                            PrefixScoreFileName = p.PrefixScoreFileName,
                            GumballScoreSeperater = p.PrefixScoreFileName,
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

        public static List<baGumRide> GetGumRideInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GumRides.Where(p => p.IsActive == true).Select(p => new baGumRide
                        {
                        Id = p.Id,
                        Locationid = p.Locationid,
                        LocationName = p.LocationName,
                        FontSize = p.FontSize,
                        FontColor = p.FontColor,
                        FontWeight = p.FontWeight,
                        BackgroundColor = p.BackgroundColor,
                        Margin = p.Margin,
                        FilePath = p.FilePath,
                        PhotoPath = p.PhotoPath,
                        IsGumbleRideActive = p.IsGumbleRideActive,
                        Position = p.Position,
                        IsSpecGumbRide = p.IsSpecGumbRide,
                        FontStyle = p.FontStyle,
                        FontFamily = p.FontFamily,
                        TimeOut = p.TimeOut,
                        IsPrefixActiveFlow = p.IsPrefixActiveFlow,
                        PrefixPhotoName = p.PrefixPhotoName,
                        PrefixScoreFileName = p.PrefixScoreFileName,
                        GumballScoreSeperater = p.PrefixScoreFileName,
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

        public static bool Insert ( baGumRide baGumRide )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    gumride gumride = new gumride();

                    gumride.Id = baGumRide.Id;
                    gumride.Locationid = baGumRide.Locationid;
                    gumride.LocationName = baGumRide.LocationName;
                    gumride.FontSize = baGumRide.FontSize;
                    gumride.FontColor = baGumRide.FontColor;
                    gumride.FontWeight = baGumRide.FontWeight;
                    gumride.BackgroundColor = baGumRide.BackgroundColor;
                    gumride.Margin = baGumRide.Margin;
                    gumride.FilePath = baGumRide.FilePath;
                    gumride.PhotoPath = baGumRide.PhotoPath;
                    gumride.IsGumbleRideActive = baGumRide.IsGumbleRideActive;
                    gumride.Position = baGumRide.Position;
                    gumride.IsSpecGumbRide = baGumRide.IsSpecGumbRide;
                    gumride.FontStyle = baGumRide.FontStyle;
                    gumride.FontFamily = baGumRide.FontFamily;
                    gumride.TimeOut = baGumRide.TimeOut;
                    gumride.IsPrefixActiveFlow = baGumRide.IsPrefixActiveFlow;
                    gumride.PrefixPhotoName = baGumRide.PrefixPhotoName;
                    gumride.PrefixScoreFileName = baGumRide.PrefixScoreFileName;
                    gumride.GumballScoreSeperater = baGumRide.GumballScoreSeperater;
                    gumride.IsActive = baGumRide.IsActive;

                    db.GumRides.Add(gumride);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baGumRide baGumRide )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.GumRides.Where(p => p.Id == baGumRide.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        gumride gumride = new gumride();

                        gumride.Id = baGumRide.Id;
                        gumride.Locationid = baGumRide.Locationid;
                        gumride.LocationName = baGumRide.LocationName;
                        gumride.FontSize = baGumRide.FontSize;
                        gumride.FontColor = baGumRide.FontColor;
                        gumride.FontWeight = baGumRide.FontWeight;
                        gumride.BackgroundColor = baGumRide.BackgroundColor;
                        gumride.Margin = baGumRide.Margin;
                        gumride.FilePath = baGumRide.FilePath;
                        gumride.PhotoPath = baGumRide.PhotoPath;
                        gumride.IsGumbleRideActive = baGumRide.IsGumbleRideActive;
                        gumride.Position = baGumRide.Position;
                        gumride.IsSpecGumbRide = baGumRide.IsSpecGumbRide;
                        gumride.FontStyle = baGumRide.FontStyle;
                        gumride.FontFamily = baGumRide.FontFamily;
                        gumride.TimeOut = baGumRide.TimeOut;
                        gumride.IsPrefixActiveFlow = baGumRide.IsPrefixActiveFlow;
                        gumride.PrefixPhotoName = baGumRide.PrefixPhotoName;
                        gumride.PrefixScoreFileName = baGumRide.PrefixScoreFileName;
                        gumride.GumballScoreSeperater = baGumRide.GumballScoreSeperater;
                        gumride.IsActive = baGumRide.IsActive;

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
                    var obj = db.GumRides.Where(p => p.Id == Id).FirstOrDefault();
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
