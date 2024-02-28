using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PhotoSW.Common
{
	public class FileInformation : INotifyPropertyChanged, IInstantiateProperty
	{
		private const int THUMBNAIL_DATA = 20507;

		private System.WeakReference _weakBitmap = new System.WeakReference(null);

		public event PropertyChangedEventHandler PropertyChanged;

		public System.IO.FileInfo FileInfo
		{
			get;
			private set;
		}

		public BitmapImage SlowBitmap
		{
			get
			{
				object arg_2F_0;
				if ((arg_2F_0 = this._weakBitmap.Target) == null)
				{
					arg_2F_0 = (this._weakBitmap.Target = FileInformation.GetBitmap(this.FileInfo.FullName));
				}
				return (BitmapImage)arg_2F_0;
			}
		}

		public object FastBitmap
		{
			get
			{
				return this._weakBitmap.Target ?? DependencyProperty.UnsetValue;
			}
		}

		public FileInformation(System.IO.FileInfo fileInfo)
		{
			this.FileInfo = fileInfo;
		}

		private static BitmapImage GetBitmap(string path)
		{
			BitmapImage result;
			try
			{
				result = FileInformation.GetThumbnail(path);
			}
			catch (System.Exception)
			{
				result = null;
			}
			return result;
		}

		private static BitmapImage GetThumbnail(string path)
		{
			System.IO.FileStream fileStream = System.IO.File.OpenRead(path);
			Image image = Image.FromStream(fileStream, false, false);
			bool flag = false;
			for (int i = 0; i < image.PropertyIdList.Length; i++)
			{
				if (image.PropertyIdList[i] == 20507)
				{
					flag = true;
				}
			}
			BitmapImage bitmapImage = null;
			if (flag)
			{
				try
				{
					PropertyItem propertyItem = image.GetPropertyItem(20507);
					byte[] value = propertyItem.Value;
					System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(value.Length);
					memoryStream.Write(value, 0, value.Length);
					Bitmap bitmap = (Bitmap)Image.FromStream(memoryStream);
					bitmapImage = new BitmapImage();
					using (System.IO.MemoryStream memoryStream2 = new System.IO.MemoryStream())
					{
						bitmap.Save(memoryStream2, ImageFormat.Jpeg);
						memoryStream2.Seek(0L, System.IO.SeekOrigin.Begin);
						bitmapImage.BeginInit();
						bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
						bitmapImage.UriSource = null;
						bitmapImage.StreamSource = memoryStream2;
						bitmapImage.EndInit();
						bitmapImage.Freeze();
					}
				}
				catch (System.Exception var_10_112)
				{
					bitmapImage = FileInformation.GetThumbnailFromFile(path, bitmapImage);
				}
			}
			else
			{
				bitmapImage = FileInformation.GetThumbnailFromFile(path, bitmapImage);
			}
			fileStream.Close();
			image.Dispose();
			return bitmapImage;
		}

		private static BitmapImage GetThumbnailFromFile(string path, BitmapImage bmp)
		{
			BitmapImage result;
			try
			{
				bmp = new BitmapImage();
				bmp.BeginInit();
				bmp.CacheOption = BitmapCacheOption.OnLoad;
				bmp.UriSource = new Uri(path);
				bmp.DecodePixelHeight = 100;
				bmp.EndInit();
				bmp.Freeze();
				result = bmp;
			}
			catch (System.Exception)
			{
				result = null;
			}
			return result;
		}

		protected void OnPropertyChanged(string propName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
			}
		}

		public void InstantiateProperty(string propertyName, System.Globalization.CultureInfo culture, System.Threading.SynchronizationContext callbackExecutionContext)
		{
			string propertyName2 = propertyName;
			if (propertyName2 != null)
			{
				if (propertyName2 == "FastBitmap")
				{
					System.Threading.SendOrPostCallback arg_72_1 = delegate(object o)
					{
						this.OnPropertyChanged(propertyName);
					};
					object arg_72_2;
					if ((arg_72_2 = this._weakBitmap.Target) == null)
					{
						arg_72_2 = (this._weakBitmap.Target = FileInformation.GetBitmap(this.FileInfo.FullName));
					}
					callbackExecutionContext.Post(arg_72_1, arg_72_2);
				}
			}
		}
	}
}
