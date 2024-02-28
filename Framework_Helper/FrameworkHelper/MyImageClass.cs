namespace FrameworkHelper
{
    using DigiPhoto.DataLayer;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Media;

    public class MyImageClass : ICloneable
    {
        public MyImageClass()
        {
        }

        public MyImageClass(string title, ImageSource image, bool ischeckd, DateTime createdDate, string imagePath, string fileExtension = "", string newLayeringXML = null, string newEffectsXML = null, DigiPhoto.DataLayer.SettingStatus settingStatus = 0, long photoNumber = 0L)
        {
            this.PhotoNumber = photoNumber;
            this.Title = title;
            this.Image = image;
            this.IsChecked = ischeckd;
            this.FileExtension = fileExtension;
            if (!fileExtension.ToLower().Equals(".jpg"))
            {
                this.IsVideo = Visibility.Visible;
            }
            else
            {
                this.IsVideo = Visibility.Collapsed;
            }
            this.CreatedDate = createdDate;
            this.ImagePath = imagePath;
            this.NewEffectsXML = newEffectsXML;
            this.NewLayeringXML = newLayeringXML;
            this.SettingStatus = settingStatus;
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

        public DateTime CreatedDate { get; set; }

        public DateTime? Datetaken { get; set; }

        public string FileExtension { get; set; }

        public ImageSource Image { get; set; }

        public string ImagePath { get; set; }

        public bool IsChecked { get; set; }

        public bool IsCodeType { get; set; }

        public bool IsCorrupt { get; set; }

        public bool IsCropped { get; set; }

        public bool IsGreen { get; set; }

        public Visibility IsVideo { get; set; }

        public string NewEffectsXML { get; set; }

        public string NewLayeringXML { get; set; }

        public int PhotoGrapherID { get; set; }

        public long PhotoNumber { get; set; }

        public DigiPhoto.DataLayer.SettingStatus SettingStatus { get; set; }

        public string srcPath { get; set; }

        public string Title { get; set; }

        public int UserIdSequence { get; set; }
    }
}

