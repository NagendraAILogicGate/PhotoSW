using System;
using System.ComponentModel;

namespace PhotoSW.IMIX.Model
{
	public class TripCamFeaturesInfo : INotifyPropertyChanged
	{
		private int _Height;

		private int _HeightMax;

		private int _ImageSize;

		private int _OffsetX;

		private int _OffsetY;

		private int _Width;

		private int _WidthMax;

		private float _Hue;

		private float _Saturation;

		private float _WhiteBalanceRed;

		private float _WhiteBalanceBlue;

		private long _ImagesCaptured;

		private long _ImagesDropped;

		private string _CameraName;

		private int _NoOfImages;

		private float _TriggerDelay;

		private float _ExposureTime;

		private int _CameraRotation;

		private string _DeviceTemperatureSelector;

		private double _DeviceTemperature;

		private long _CCDTemperatureOK;

		private int _StrobeDelay;

		private int _StrobeDuration;

		private string _StrobeDurationMode;

		private string _StrobeSource;

		private int _PacketSize;

		private string _MACAddress;

		private string _IPConfigurationMode;

		private string _IPAddress;

		private string _Subnet;

		private string _Gateway;

		private string _PixelFormat;

		private string _TriggerSource;

		private double _AquisitionFrameRate;

		private int _LensFocus;

		private int _LensFocusMax;

		private double _Aperture;

		private double _ApertureMin;

		private double _ApertureMax;

		private int _StreamBytesPerSec;

		private float _Gamma;

		private float _BlackLevel;

		private float _Gain;

		private float _Gain00;

		private float _Gain01;

		private float _Gain02;

		private float _Gain10;

		private float _Gain11;

		private float _Gain12;

		private float _Gain20;

		private float _Gain21;

		private float _Gain22;

		private string _ColorTransformationMode;

		private string _ExposureMode;

		private string _SyncOutPolarity;

		private string _SyncOutSelector;

		private string _SyncOutSource;

		private double _MaxStreamByteValue;

		public string AcquisitionMode = "Continuous";

		public event PropertyChangedEventHandler PropertyChanged;

		public int Height
		{
			get
			{
				return this._Height;
			}
			set
			{
				this._Height = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("Height"));
			}
		}

		public int HeightMax
		{
			get
			{
				return this._HeightMax;
			}
			set
			{
				this._HeightMax = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("HeightMax"));
			}
		}

		public int ImageSize
		{
			get
			{
				return this._ImageSize;
			}
			set
			{
				this._ImageSize = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("ImageSize"));
			}
		}

		public int OffsetX
		{
			get
			{
				return this._OffsetX;
			}
			set
			{
				this._OffsetX = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("OffsetX"));
			}
		}

		public int OffsetY
		{
			get
			{
				return this._OffsetY;
			}
			set
			{
				this._OffsetY = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("OffsetY"));
			}
		}

		public int Width
		{
			get
			{
				return this._Width;
			}
			set
			{
				this._Width = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("Width"));
			}
		}

		public int WidthMax
		{
			get
			{
				return this._WidthMax;
			}
			set
			{
				this._WidthMax = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("WidthMax"));
			}
		}

		public float Hue
		{
			get
			{
				return this._Hue;
			}
			set
			{
				this._Hue = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("Hue"));
			}
		}

		public float Saturation
		{
			get
			{
				return this._Saturation;
			}
			set
			{
				this._Saturation = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("Saturation"));
			}
		}

		public float WhiteBalanceRed
		{
			get
			{
				return this._WhiteBalanceRed;
			}
			set
			{
				this._WhiteBalanceRed = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("WhiteBalanceRed"));
			}
		}

		public float WhiteBalanceBlue
		{
			get
			{
				return this._WhiteBalanceBlue;
			}
			set
			{
				this._WhiteBalanceBlue = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("WhiteBalanceBlue"));
			}
		}

		public long ImagesCaptured
		{
			get
			{
				return this._ImagesCaptured;
			}
			set
			{
				this._ImagesCaptured = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("ImagesCaptured"));
			}
		}

		public long ImagesDropped
		{
			get
			{
				return this._ImagesDropped;
			}
			set
			{
				this._ImagesDropped = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("ImagesDropped"));
			}
		}

		public string CameraName
		{
			get
			{
				return this._CameraName;
			}
			set
			{
				this._CameraName = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("CameraName"));
			}
		}

		public int NoOfImages
		{
			get
			{
				return this._NoOfImages;
			}
			set
			{
				this._NoOfImages = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("NoOfImages"));
			}
		}

		public float TriggerDelay
		{
			get
			{
				return this._TriggerDelay;
			}
			set
			{
				this._TriggerDelay = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("TriggerDelay"));
			}
		}

		public float ExposureTime
		{
			get
			{
				return this._ExposureTime;
			}
			set
			{
				this._ExposureTime = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("ExposureTime"));
			}
		}

		public int CameraRotation
		{
			get
			{
				return this._CameraRotation;
			}
			set
			{
				this._CameraRotation = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("CameraRotation"));
			}
		}

		public string DeviceTemperatureSelector
		{
			get
			{
				return this._DeviceTemperatureSelector;
			}
			set
			{
				this._DeviceTemperatureSelector = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("DeviceTemperatureSelector"));
			}
		}

		public double DeviceTemperature
		{
			get
			{
				return this._DeviceTemperature;
			}
			set
			{
				this._DeviceTemperature = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("DeviceTemperature"));
			}
		}

		public long CCDTemperatureOK
		{
			get
			{
				return this._CCDTemperatureOK;
			}
			set
			{
				this._CCDTemperatureOK = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("CCDTemperatureOK"));
			}
		}

		public int StrobeDelay
		{
			get
			{
				return this._StrobeDelay;
			}
			set
			{
				this._StrobeDelay = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("StrobeDelay"));
			}
		}

		public int StrobeDuration
		{
			get
			{
				return this._StrobeDuration;
			}
			set
			{
				this._StrobeDuration = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("StrobeDuration"));
			}
		}

		public string StrobeDurationMode
		{
			get
			{
				return this._StrobeDurationMode;
			}
			set
			{
				this._StrobeDurationMode = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("StrobeDurationMode"));
			}
		}

		public string StrobeSource
		{
			get
			{
				return this._StrobeSource;
			}
			set
			{
				this._StrobeSource = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("StrobeSource"));
			}
		}

		public int PacketSize
		{
			get
			{
				return this._PacketSize;
			}
			set
			{
				this._PacketSize = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("PacketSize"));
			}
		}

		public string MACAddress
		{
			get
			{
				return this._MACAddress;
			}
			set
			{
				this._MACAddress = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("MACAddress"));
			}
		}

		public string IPConfigurationMode
		{
			get
			{
				return this._IPConfigurationMode;
			}
			set
			{
				this._IPConfigurationMode = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("IPConfigurationMode"));
			}
		}

		public string IPAddress
		{
			get
			{
				return this._IPAddress;
			}
			set
			{
				this._IPAddress = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("IPAddress"));
			}
		}

		public string Subnet
		{
			get
			{
				return this._Subnet;
			}
			set
			{
				this._Subnet = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("Subnet"));
			}
		}

		public string Gateway
		{
			get
			{
				return this._Gateway;
			}
			set
			{
				this._Gateway = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("Gateway"));
			}
		}

		public string PixelFormat
		{
			get
			{
				return this._PixelFormat;
			}
			set
			{
				this._PixelFormat = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("PixelFormat"));
			}
		}

		public string TriggerSource
		{
			get
			{
				return this._TriggerSource;
			}
			set
			{
				this._TriggerSource = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("TriggerSource"));
			}
		}

		public double AquisitionFrameRate
		{
			get
			{
				return this._AquisitionFrameRate;
			}
			set
			{
				this._AquisitionFrameRate = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("AquisitionFrameRate"));
			}
		}

		public int LensFocus
		{
			get
			{
				return this._LensFocus;
			}
			set
			{
				this._LensFocus = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("LensFocus"));
			}
		}

		public int LensFocusMax
		{
			get
			{
				return this._LensFocusMax;
			}
			set
			{
				this._LensFocusMax = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("LensFocusMax"));
			}
		}

		public double Aperture
		{
			get
			{
				return this._Aperture;
			}
			set
			{
				this._Aperture = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("Aperture"));
			}
		}

		public double ApertureMin
		{
			get
			{
				return this._ApertureMin;
			}
			set
			{
				this._ApertureMin = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("ApertureMin"));
			}
		}

		public double ApertureMax
		{
			get
			{
				return this._ApertureMax;
			}
			set
			{
				this._ApertureMax = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("ApertureMax"));
			}
		}

		public int StreamBytesPerSec
		{
			get
			{
				return this._StreamBytesPerSec;
			}
			set
			{
				this._StreamBytesPerSec = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("StreamBytesPerSec"));
			}
		}

		public float Gamma
		{
			get
			{
				return this._Gamma;
			}
			set
			{
				this._Gamma = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("Gamma"));
			}
		}

		public float BlackLevel
		{
			get
			{
				return this._BlackLevel;
			}
			set
			{
				this._BlackLevel = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("BlackLevel"));
			}
		}

		public float Gain
		{
			get
			{
				return this._Gain;
			}
			set
			{
				this._Gain = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("Gain"));
			}
		}

		public float Gain00
		{
			get
			{
				return this._Gain00;
			}
			set
			{
				this._Gain00 = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("Gain00"));
			}
		}

		public float Gain01
		{
			get
			{
				return this._Gain01;
			}
			set
			{
				this._Gain01 = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("Gain01"));
			}
		}

		public float Gain02
		{
			get
			{
				return this._Gain02;
			}
			set
			{
				this._Gain02 = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("Gain02"));
			}
		}

		public float Gain10
		{
			get
			{
				return this._Gain10;
			}
			set
			{
				this._Gain10 = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("Gain10"));
			}
		}

		public float Gain11
		{
			get
			{
				return this._Gain11;
			}
			set
			{
				this._Gain11 = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("Gain11"));
			}
		}

		public float Gain12
		{
			get
			{
				return this._Gain12;
			}
			set
			{
				this._Gain12 = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("Gain12"));
			}
		}

		public float Gain20
		{
			get
			{
				return this._Gain20;
			}
			set
			{
				this._Gain20 = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("Gain20"));
			}
		}

		public float Gain21
		{
			get
			{
				return this._Gain21;
			}
			set
			{
				this._Gain21 = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("Gain21"));
			}
		}

		public float Gain22
		{
			get
			{
				return this._Gain22;
			}
			set
			{
				this._Gain22 = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("Gain22"));
			}
		}

		public string ColorTransformationMode
		{
			get
			{
				return this._ColorTransformationMode;
			}
			set
			{
				this._ColorTransformationMode = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("ColorTransformationMode"));
			}
		}

		public string ExposureMode
		{
			get
			{
				return this._ExposureMode;
			}
			set
			{
				this._ExposureMode = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("ExposureMode"));
			}
		}

		public string SyncOutPolarity
		{
			get
			{
				return this._SyncOutPolarity;
			}
			set
			{
				this._SyncOutPolarity = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("SyncOutPolarity"));
			}
		}

		public string SyncOutSelector
		{
			get
			{
				return this._SyncOutSelector;
			}
			set
			{
				this._SyncOutSelector = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("SyncOutSelector"));
			}
		}

		public string SyncOutSource
		{
			get
			{
				return this._SyncOutSource;
			}
			set
			{
				this._SyncOutSource = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("SyncOutSource"));
			}
		}

		public double MaxStreamByteValue
		{
			get
			{
				return this._MaxStreamByteValue;
			}
			set
			{
				this._MaxStreamByteValue = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("MaxStreamByteValue"));
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
