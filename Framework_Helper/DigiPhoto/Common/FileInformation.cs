namespace DigiPhoto.Common
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows;
    using System.Windows.Media.Imaging;

    public class FileInformation : INotifyPropertyChanged, IInstantiateProperty
    {
        private WeakReference _weakBitmap = new WeakReference(null);
        private const int THUMBNAIL_DATA = 0x501b;

        public event PropertyChangedEventHandler PropertyChanged;

        public FileInformation(System.IO.FileInfo fileInfo)
        {
            this.FileInfo = fileInfo;
        }

        private static BitmapImage GetBitmap(string path)
        {
            try
            {
                return GetThumbnail(path);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static BitmapImage GetThumbnail(string path)
        {
            FileStream stream = File.OpenRead(path);
            Image image = Image.FromStream(stream, false, false);
            bool flag = false;
            for (int i = 0; i < image.PropertyIdList.Length; i++)
            {
                if (image.PropertyIdList[i] == 0x501b)
                {
                    flag = true;
                }
            }
            BitmapImage bmp = null;
            if (flag)
            {
                try
                {
                    byte[] buffer = image.GetPropertyItem(0x501b).Value;
                    MemoryStream stream2 = new MemoryStream(buffer.Length);
                    stream2.Write(buffer, 0, buffer.Length);
                    Bitmap bitmap = (Bitmap) Image.FromStream(stream2);
                    bmp = new BitmapImage();
                    using (MemoryStream stream3 = new MemoryStream())
                    {
                        bitmap.Save(stream3, ImageFormat.Jpeg);
                        stream3.Seek(0L, SeekOrigin.Begin);
                        bmp.BeginInit();
                        bmp.CacheOption = BitmapCacheOption.OnLoad;
                        bmp.UriSource = null;
                        bmp.StreamSource = stream3;
                        bmp.EndInit();
                        bmp.Freeze();
                    }
                }
                catch (Exception)
                {
                    bmp = GetThumbnailFromFile(path, bmp);
                }
            }
            else
            {
                bmp = GetThumbnailFromFile(path, bmp);
            }
            stream.Close();
            image.Dispose();
            return bmp;
        }

        private static BitmapImage GetThumbnailFromFile(string path, BitmapImage bmp)
        {
            try
            {
                bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.CacheOption = BitmapCacheOption.OnLoad;
                bmp.UriSource = new Uri(path);
                bmp.DecodePixelHeight = 100;
                bmp.EndInit();
                bmp.Freeze();
                return bmp;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void InstantiateProperty(string propertyName, CultureInfo culture, SynchronizationContext callbackExecutionContext)
        {
            SendOrPostCallback d = null;
            string str = propertyName;
            if ((str != null) && (str == "FastBitmap"))
            {
                if (d == null)
                {
                    d = o => this.OnPropertyChanged(propertyName);
                }
                callbackExecutionContext.Post(d, this._weakBitmap.Target ?? (this._weakBitmap.Target = GetBitmap(this.FileInfo.FullName)));
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public object FastBitmap
        {
            get
            {
                return (this._weakBitmap.Target ?? DependencyProperty.UnsetValue);
            }
        }

        public System.IO.FileInfo FileInfo { get; private set; }

        public BitmapImage SlowBitmap
        {
            get
            {
                return (this._weakBitmap.Target ?? (this._weakBitmap.Target = GetBitmap(this.FileInfo.FullName)));
            }
        }
    }
}

