using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Media;

namespace PhotoSW.ImageGallery
{
	public class ImageFile : INotifyPropertyChanged
	{
		private string _filePath;

		private string _parentPath;

		private SolidColorBrush _colorCode;

		public event PropertyChangedEventHandler PropertyChanged;

		public string FilePath
		{
			get
			{
				return this._filePath;
			}
			set
			{
				this._filePath = value;
				this._parentPath = new System.IO.FileInfo(this._filePath).DirectoryName;
				this.NotifyPropertyChanged("FilePath");
				this.NotifyPropertyChanged("ParentPath");
				this.NotifyPropertyChanged("ColorCode");
			}
		}

		public string ParentPath
		{
			get
			{
				return this._parentPath;
			}
		}

		public SolidColorBrush ColorCode
		{
			get
			{
				return this._colorCode;
			}
			set
			{
				this._colorCode = value;
				this.NotifyPropertyChanged("ColorCode");
			}
		}

		private void NotifyPropertyChanged(string info)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}

		public ImageFile()
		{
		}

		public ImageFile(string filePath)
		{
			this.FilePath = filePath;
		}
	}
}
