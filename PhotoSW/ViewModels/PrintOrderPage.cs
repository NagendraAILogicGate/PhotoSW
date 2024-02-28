﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PhotoSW.ViewModels
{
    public class PrintOrderPage : INotifyPropertyChanged
    {
        private int _PageNo;

        private string _Name1;

        private string _Name2;

        private string _FilePath1;

        private string _FilePath2;

        private int _PhotoPosition1;

        private int _PhotoPosition2;

        private int _PhotoId1;

        private int _PhotoId2;

        private ImageSource _ImageSource1;

        private ImageSource _ImageSource2;

        private int _RotationAngle1;

        private int _RotationAngle2;

        private int _ItemTemplateHeaderId;

        private int _ItemTemplateDetailId;

        public event PropertyChangedEventHandler PropertyChanged;

        public int PageNo
        {
            get
            {
                return this._PageNo;
            }
            set
            {
                if (this._PageNo != value)
                {
                    this._PageNo = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("PageNo"));
                }
            }
        }

        public string Name1
        {
            get
            {
                return this._Name1;
            }
            set
            {
                if (this._Name1 != value)
                {
                    this._Name1 = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("Name1"));
                }
            }
        }

        public string Name2
        {
            get
            {
                return this._Name2;
            }
            set
            {
                if (this._Name2 != value)
                {
                    this._Name2 = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("Name2"));
                }
            }
        }

        public string FilePath1
        {
            get
            {
                return this._FilePath1;
            }
            set
            {
                if (this._FilePath1 != value)
                {
                    this._FilePath1 = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("FilePath1"));
                }
            }
        }

        public string FilePath2
        {
            get
            {
                return this._FilePath2;
            }
            set
            {
                if (this._FilePath2 != value)
                {
                    this._FilePath2 = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("FilePath2"));
                }
            }
        }

        public int PhotoPosition1
        {
            get
            {
                return this._PhotoPosition1;
            }
            set
            {
                if (this._PhotoPosition1 != value)
                {
                    this._PhotoPosition1 = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("PhotoPosition1"));
                }
            }
        }

        public int PhotoPosition2
        {
            get
            {
                return this._PhotoPosition2;
            }
            set
            {
                if (this._PhotoPosition2 != value)
                {
                    this._PhotoPosition2 = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("PhotoPosition2"));
                }
            }
        }

        public int PhotoId1
        {
            get
            {
                return this._PhotoId1;
            }
            set
            {
                if (this._PhotoId1 != value)
                {
                    this._PhotoId1 = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("PhotoId1"));
                }
            }
        }

        public int PhotoId2
        {
            get
            {
                return this._PhotoId2;
            }
            set
            {
                if (this._PhotoId2 != value)
                {
                    this._PhotoId2 = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("PhotoId2"));
                }
            }
        }

        public ImageSource ImageSource1
        {
            get
            {
                return this._ImageSource1;
            }
            set
            {
                if (this._ImageSource1 != value)
                {
                    this._ImageSource1 = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ImageSource1"));
                }
            }
        }

        public ImageSource ImageSource2
        {
            get
            {
                return this._ImageSource2;
            }
            set
            {
                if (this._ImageSource2 != value)
                {
                    this._ImageSource2 = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ImageSource2"));
                }
            }
        }

        public int RotationAngle1
        {
            get
            {
                return this._RotationAngle1;
            }
            set
            {
                if (this._RotationAngle1 != value)
                {
                    this._RotationAngle1 = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("RotationAngle1"));
                }
            }
        }

        public int RotationAngle2
        {
            get
            {
                return this._RotationAngle2;
            }
            set
            {
                if (this._RotationAngle2 != value)
                {
                    this._RotationAngle2 = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("RotationAngle2"));
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

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, e);
            }
        }
    }
}
