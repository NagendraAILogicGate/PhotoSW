using PhotoSW.IMIX.Model;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PhotoSW.Interop
{
	public class VideoFrames : INotifyPropertyChanged
	{
		public ProcessedVideoDetailsInfo objPVDetails = new ProcessedVideoDetailsInfo();

		private BitmapImage _bitFrame;

		private string _frameInstance;

		private int _frameIndex;

		private BitmapSource _bitSource;

		private string _StrokeColor;

		private Visibility _visibilityCanvas;
        private PropertyChangedEventHandler propertyChanged;
		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				do
				{
					IL_00:
                    PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChanged;
					while (true)
					{
						IL_09:
						PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
						while (true)
						{
							PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
							if (-1 == 0)
							{
								goto IL_00;
							}
                            propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChanged, value2, propertyChangedEventHandler2);
							while (!false)
							{
								bool arg_39_0;
								bool expr_31 = arg_39_0 = (propertyChangedEventHandler == propertyChangedEventHandler2);
								if (!false)
								{
									arg_39_0 = !expr_31;
								}
								if (arg_39_0)
								{
									goto IL_09;
								}
								if (!false)
								{
									goto Block_4;
								}
							}
						}
					}
					Block_4:;
				}
				while (!true);
			}
			remove
			{
				do
				{
					IL_00:
                    PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChanged;
					while (true)
					{
						IL_09:
						PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
						while (true)
						{
							PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
							if (-1 == 0)
							{
								goto IL_00;
							}
                            propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChanged, value2, propertyChangedEventHandler2);
							while (!false)
							{
								bool arg_39_0;
								bool expr_31 = arg_39_0 = (propertyChangedEventHandler == propertyChangedEventHandler2);
								if (!false)
								{
									arg_39_0 = !expr_31;
								}
								if (arg_39_0)
								{
									goto IL_09;
								}
								if (!false)
								{
									goto Block_4;
								}
							}
						}
					}
					Block_4:;
				}
				while (!true);
			}
		}

		public BitmapImage bitFrame
		{
			get
			{
				return this._bitFrame;
			}
			set
			{
				this._bitFrame = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("bitFrame"));
			}
		}

		public string frameInstance
		{
			get
			{
				return this._frameInstance;
			}
			set
			{
				this._frameInstance = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("frameInstance"));
			}
		}

		public int frameIndex
		{
			get
			{
				return this._frameIndex;
			}
			set
			{
				this._frameIndex = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("frameIndex"));
			}
		}

		public BitmapSource bitSource
		{
			get
			{
				return this._bitSource;
			}
			set
			{
				this._bitSource = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("bitSource"));
			}
		}

		public string StrokeColor
		{
			get
			{
				return this._StrokeColor;
			}
			set
			{
				this._StrokeColor = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("StrokeColor"));
			}
		}

		public Visibility visibilityCanvas
		{
			get
			{
				return this._visibilityCanvas;
			}
			set
			{
				this._visibilityCanvas = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("visibilityCanvas"));
			}
		}

		public void OnPropertyChanged(PropertyChangedEventArgs e)
		{
            if (this.propertyChanged != null)
			{
                this.propertyChanged(this, e);
			}
		}
	}
}
