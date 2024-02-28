using PhotoSW.DataLayer;
using System;
using System.Windows;
using System.Windows.Media;

namespace FrameworkHelper
{
	public class MyImageClass : System.ICloneable
	{
		public string Title
		{
			get;
			set;
		}

		public string FileExtension
		{
			get;
			set;
		}

		public string NewLayeringXML
		{
			get;
			set;
		}

		public string NewEffectsXML
		{
			get;
			set;
		}

		public bool IsCropped
		{
			get;
			set;
		}

		public bool IsGreen
		{
			get;
			set;
		}

		public SettingStatus SettingStatus
		{
			get;
			set;
		}

		public ImageSource Image
		{
			get;
			set;
		}

		public System.DateTime CreatedDate
		{
			get;
			set;
		}

		public bool IsChecked
		{
			get;
			set;
		}

		public Visibility IsVideo
		{
			get;
			set;
		}

		public bool IsCodeType
		{
			get;
			set;
		}

		public string ImagePath
		{
			get;
			set;
		}

		public bool IsCorrupt
		{
			get;
			set;
		}

		public long PhotoNumber
		{
			get;
			set;
		}

		public int PhotoGrapherID
		{
			get;
			set;
		}

		public System.DateTime? Datetaken
		{
			get;
			set;
		}

		public int UserIdSequence
		{
			get;
			set;
		}

		public string srcPath
		{
			get;
			set;
		}

		public MyImageClass()
		{
		}

		public MyImageClass(string title, ImageSource image, bool ischeckd, System.DateTime createdDate, string imagePath, string fileExtension = "", string newLayeringXML = null, string newEffectsXML = null, SettingStatus settingStatus = SettingStatus.None, long photoNumber = 0L)
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
	}
}
