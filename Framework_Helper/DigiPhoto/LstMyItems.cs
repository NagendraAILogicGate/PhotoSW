namespace DigiPhoto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows;
    using System.Windows.Media.Imaging;

    public class LstMyItems : INotifyPropertyChanged
    {
        private BitmapImage _bmpImage;
        private BitmapImage _bmpImageGroup;
        private int _counter;
        private DateTime _createdOn;
        private string _fileName;
        private string _filePath;
        private string _frameBrdr = null;
        private int _GridMainHeight;
        private int _GridMainRowHeight1;
        private int _GridMainRowHeight2;
        private int _GridMainWidth;
        private string _hotFolderPath = string.Empty;
        private Visibility _isLocked;
        private Visibility _isPassKeyVisible;
        private int _ItemTemplateDetailId;
        private int _ItemTemplateHeaderId;
        private int _listPosition;
        private int _maxCount;
        private int _mediaType;
        private string _name;
        private string _nameRowNo;
        private int _PageNo;
        private int _photoId;
        private int _PhotoId;
        private Visibility _playVisible;
        private Visibility _processedVisible;
        private string _vidFilePath;
        private string Photoname;
        public List<PhotoPrintPosition> PhotoPrintPositionList = new List<PhotoPrintPosition>();
        private BitmapImage printGroup;
        private bool toShownoCopy;

        public event PropertyChangedEventHandler PropertyChanged;

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        public void DestroyBitmap()
        {
            try
            {
                if (this.printGroup != null)
                {
                    DeleteObject(MemoryManagement.BitmapImage2Bitmap(this.printGroup).GetHbitmap());
                }
                if (this._bmpImage != null)
                {
                    DeleteObject(MemoryManagement.BitmapImage2Bitmap(this._bmpImage).GetHbitmap());
                }
                if (this._bmpImageGroup != null)
                {
                    DeleteObject(MemoryManagement.BitmapImage2Bitmap(this._bmpImageGroup).GetHbitmap());
                }
            }
            catch
            {
            }
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, e);
            }
        }

        public string BigDBThumnailPath
        {
            get
            {
                return Path.Combine(this.HotFolderPath, "Thumbnails_Big");
            }
        }

        public string BigThumbnailPath { get; set; }

        public BitmapImage BmpImage
        {
            get
            {
                return this._bmpImage;
            }
            set
            {
                this._bmpImage = value;
            }
        }

        public BitmapImage BmpImageGroup
        {
            get
            {
                return this._bmpImageGroup;
            }
            set
            {
                this._bmpImageGroup = value;
            }
        }

        public int Counter
        {
            get
            {
                return this._counter;
            }
            set
            {
                this._counter = value;
            }
        }

        public DateTime CreatedOn
        {
            get
            {
                return this._createdOn;
            }
            set
            {
                this._createdOn = value;
            }
        }

        public string FileName
        {
            get
            {
                return this._fileName;
            }
            set
            {
                this._fileName = value;
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
            }
        }

        public string FrameBrdr
        {
            get
            {
                return this._frameBrdr;
            }
            set
            {
                this._frameBrdr = value;
            }
        }

        public int GridMainHeight
        {
            get
            {
                return this._GridMainHeight;
            }
            set
            {
                if (this._GridMainHeight != value)
                {
                    this._GridMainHeight = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("GridMainHeight"));
                }
            }
        }

        public int GridMainRowHeight1
        {
            get
            {
                return this._GridMainRowHeight1;
            }
            set
            {
                if (this._GridMainRowHeight1 != value)
                {
                    this._GridMainRowHeight1 = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("GridMainRowHeight1"));
                }
            }
        }

        public int GridMainRowHeight2
        {
            get
            {
                return this._GridMainRowHeight2;
            }
            set
            {
                if (this._GridMainRowHeight2 != value)
                {
                    this._GridMainRowHeight2 = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("GridMainRowHeight2"));
                }
            }
        }

        public int GridMainWidth
        {
            get
            {
                return this._GridMainWidth;
            }
            set
            {
                if (this._GridMainWidth != value)
                {
                    this._GridMainWidth = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("GridMainWidth"));
                }
            }
        }

        public string HotFolderPath
        {
            get
            {
                return this._hotFolderPath;
            }
            set
            {
                this._hotFolderPath = value;
            }
        }

        public bool IsChecked { get; set; }

        public bool IsItemSelected { get; set; }

        public Visibility IsLocked
        {
            get
            {
                return this._isLocked;
            }
            set
            {
                this._isLocked = value;
            }
        }

        public Visibility IsPassKeyVisible
        {
            get
            {
                return this._isPassKeyVisible;
            }
            set
            {
                this._isPassKeyVisible = value;
            }
        }

        public int ItemTemplateDetailId
        {
            get
            {
                return this._ItemTemplateDetailId;
            }
            set
            {
                this._ItemTemplateDetailId = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("ItemTemplateDetailId"));
            }
        }

        public int ItemTemplateHeaderId
        {
            get
            {
                return this._ItemTemplateHeaderId;
            }
            set
            {
                this._ItemTemplateHeaderId = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("ItemTemplateHeaderId"));
            }
        }

        public int ListPosition
        {
            get
            {
                return this._listPosition;
            }
            set
            {
                this._listPosition = value;
            }
        }

        public int MaxCount
        {
            get
            {
                return this._maxCount;
            }
            set
            {
                this._maxCount = value;
            }
        }

        public int MediaType
        {
            get
            {
                return this._mediaType;
            }
            set
            {
                this._mediaType = value;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public string NameRowNo
        {
            get
            {
                return this._nameRowNo;
            }
            set
            {
                this._nameRowNo = value;
            }
        }

        public string OnlineQRCode { get; set; }

        public int PageNo
        {
            get
            {
                return this._PageNo;
            }
            set
            {
                this._PageNo = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("PageNo"));
            }
        }

        public int PhotoId
        {
            get
            {
                return this._photoId;
            }
            set
            {
                this._photoId = value;
            }
        }

        public string Photoname1
        {
            get
            {
                return this.Photoname;
            }
            set
            {
                this.Photoname = value;
            }
        }

        public Visibility PlayVisible
        {
            get
            {
                if ((this.MediaType == 2) || (this.MediaType == 3))
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
            set
            {
                this._playVisible = value;
            }
        }

        public BitmapImage PrintGroup
        {
            get
            {
                return this.printGroup;
            }
            set
            {
                this.printGroup = value;
            }
        }

        public Visibility ProcessedVisible
        {
            get
            {
                if (this.MediaType == 3)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
            set
            {
                this._processedVisible = value;
            }
        }

        public string ThumnailPath
        {
            get
            {
                return Path.Combine(this.HotFolderPath, "Thumbnails");
            }
        }

        public bool ToShownoCopy
        {
            get
            {
                return this.toShownoCopy;
            }
            set
            {
                this.toShownoCopy = value;
            }
        }

        public int updownCount { get; set; }

        public long? VideoLength { get; set; }

        public string VidFilePath
        {
            get
            {
                return this._vidFilePath;
            }
            set
            {
                this._vidFilePath = value;
            }
        }
    }
}

