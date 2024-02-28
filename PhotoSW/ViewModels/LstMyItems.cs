using DigiPhoto.DataLayer;
using PhotoSW.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media.Imaging;


namespace PhotoSW.ViewModels
{
    public class LstMyItems : INotifyPropertyChanged
    {
        private int _listPosition;

        private int _photoId;

        private int _PhotoId;

        private BitmapImage printGroup;

        private string _name;

        private string _nameRowNo;

        private string _frameBrdr = null;

        private string _filePath;

        private BitmapImage _bmpImage;

        private BitmapImage _bmpImageGroup;

        private Visibility _isLocked;

        private Visibility _isPassKeyVisible;

        private string Photoname;

        private int _counter;

        private int _maxCount;

        private string _fileName;

        private bool toShownoCopy;

        private int _mediaType;

        private Visibility _playVisible;

        private Visibility _processedVisible;

        private string _vidFilePath;

        private System.DateTime _createdOn;

        private string _hotFolderPath = string.Empty;

        private int _GridMainWidth;

        private int _GridMainHeight;

        private int _GridMainRowHeight1;

        private int _GridMainRowHeight2;

        private int _ItemTemplateHeaderId;

        private int _ItemTemplateDetailId;

        private int _PageNo;

        public System.Collections.Generic.List<PhotoPrintPosition> PhotoPrintPositionList = new System.Collections.Generic.List<PhotoPrintPosition>();

        public event PropertyChangedEventHandler PropertyChanged;

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

        public System.DateTime CreatedOn
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

        public Visibility PlayVisible
        {
            get
            {
                Visibility result;
                if (this.MediaType == 2 || this.MediaType == 3)
                {
                    result = Visibility.Visible;
                }
                else
                {
                    result = Visibility.Collapsed;
                }
                return result;
            }
            set
            {
                this._playVisible = value;
            }
        }

        public Visibility ProcessedVisible
        {
            get
            {
                Visibility result;
                if (this.MediaType == 3)
                {
                    result = Visibility.Visible;
                }
                else
                {
                    result = Visibility.Collapsed;
                }
                return result;
            }
            set
            {
                this._processedVisible = value;
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

        public string BigDBThumnailPath
        {
            get
            {
                return System.IO.Path.Combine(this.HotFolderPath, "Thumbnails_Big");
            }
        }

        public string ThumnailPath
        {
            get
            {
                return System.IO.Path.Combine(this.HotFolderPath, "Thumbnails");
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

        public bool IsChecked
        {
            get;
            set;
        }

        public long? VideoLength
        {
            get;
            set;
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

        public bool IsItemSelected
        {
            get;
            set;
        }

        public int updownCount
        {
            get;
            set;
        }

        public string BigThumbnailPath
        {
            get;
            set;
        }

        public string OnlineQRCode
        {
            get;
            set;
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(System.IntPtr hObject);

        public void DestroyBitmap()
        {
            try
            {
                if (this.printGroup != null)
                {
                    System.IntPtr hbitmap = MemoryManagement.BitmapImage2Bitmap(this.printGroup).GetHbitmap();
                    LstMyItems.DeleteObject(hbitmap);
                }
                if (this._bmpImage != null)
                {
                    System.IntPtr hbitmap2 = MemoryManagement.BitmapImage2Bitmap(this._bmpImage).GetHbitmap();
                    LstMyItems.DeleteObject(hbitmap2);
                }
                if (this._bmpImageGroup != null)
                {
                    System.IntPtr hbitmap3 = MemoryManagement.BitmapImage2Bitmap(this._bmpImageGroup).GetHbitmap();
                    LstMyItems.DeleteObject(hbitmap3);
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
    }
}
