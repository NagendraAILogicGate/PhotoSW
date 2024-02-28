namespace DigiPhoto.ImageGallery
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Threading;
    using System.Windows.Media;

    public class ImageFile : INotifyPropertyChanged
    {
        private SolidColorBrush _colorCode;
        private string _filePath;
        private string _parentPath;

        public event PropertyChangedEventHandler PropertyChanged;

        public ImageFile()
        {
        }

        public ImageFile(string filePath)
        {
            this.FilePath = filePath;
        }

        private void NotifyPropertyChanged(string info)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
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

        public string FilePath
        {
            get
            {
                return this._filePath;
            }
            set
            {
                this._filePath = value;
                this._parentPath = new FileInfo(this._filePath).DirectoryName;
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
    }
}

