using PhotoSW.IMIX.Model;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace PhotoSW.Interop
{
	public class VideoPage : INotifyPropertyChanged
	{
		public ProcessedVideoDetailsInfo objPVDetails = new ProcessedVideoDetailsInfo();

		private int _PageNo;

		private string _Name;

		private string _FilePath;

		private int _PhotoId;

		private int _ImageDisplayTime;

		private int _ProcessedVideoId;

		private int _MediaType;

		private bool _IsGuestImage;

		private Visibility _playVisible;

		private string _DropVideoPath;

		private Visibility _ProcessedVisible;

		public Visibility _processPlayVisible;
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

		public int PageNo
		{
			get
			{
				return this._PageNo;
			}
			set
			{
				int arg_0D_0;
				bool arg_3C_0 = (arg_0D_0 = this._PageNo) != 0;
				do
				{
					if (2 != 0)
					{
						arg_3C_0 = ((arg_0D_0 = ((arg_0D_0 == value) ? 1 : 0)) != 0);
					}
				}
				while (false);
				bool flag = arg_3C_0;
				if (7 == 0 || !flag)
				{
					do
					{
						this._PageNo = value;
					}
					while (false);
					this.OnPropertyChanged(new PropertyChangedEventArgs("PageNo"));
				}
			}
		}

		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if (-1 != 0)
				{
					bool expr_10 = !(this._Name != value);
					bool flag;
					if (4 != 0)
					{
						flag = expr_10;
					}
					if (!false)
					{
						if (!flag)
						{
							this._Name = value;
							if (!false && !false)
							{
								this.OnPropertyChanged(new PropertyChangedEventArgs("Name"));
							}
						}
					}
				}
			}
		}

		public string FilePath
		{
			get
			{
				return this._FilePath;
			}
			set
			{
				if (-1 != 0)
				{
					bool expr_10 = !(this._FilePath != value);
					bool flag;
					if (4 != 0)
					{
						flag = expr_10;
					}
					if (!false)
					{
						if (!flag)
						{
							this._FilePath = value;
							if (!false && !false)
							{
								this.OnPropertyChanged(new PropertyChangedEventArgs("FilePath"));
							}
						}
					}
				}
			}
		}

		public int PhotoId
		{
			get
			{
				return this._PhotoId;
			}
			set
			{
				while (true)
				{
					bool arg_13_0;
					bool expr_0A = arg_13_0 = (this._PhotoId == value);
					bool flag;
					if (!false)
					{
						flag = expr_0A;
						goto IL_11;
					}
					IL_13:
					if (!arg_13_0)
					{
						while (-1 != 0)
						{
							if (!false)
							{
								this._PhotoId = value;
								break;
							}
						}
						this.objPVDetails.MediaId = (long)this._PhotoId;
						this.OnPropertyChanged(new PropertyChangedEventArgs("PhotoId"));
						if (4 == 0)
						{
							goto IL_11;
						}
					}
					if (!false)
					{
						break;
					}
					continue;
					IL_11:
					arg_13_0 = flag;
					goto IL_13;
				}
			}
		}

		public int ImageDisplayTime
		{
			get
			{
				return this._ImageDisplayTime;
			}
			set
			{
				while (true)
				{
					int arg_55_0;
					int arg_16_0;
					int expr_03 = arg_16_0 = (arg_55_0 = this._ImageDisplayTime);
					if (4 == 0)
					{
						goto IL_12;
					}
					if (!false)
					{
						arg_55_0 = ((expr_03 == value) ? 1 : 0);
						goto IL_12;
					}
					IL_16:
					if (arg_16_0 == 0)
					{
						if (!false)
						{
							this._ImageDisplayTime = value;
						}
						this.objPVDetails.DisplayTime = this._ImageDisplayTime;
						this.OnPropertyChanged(new PropertyChangedEventArgs("ImageDisplayTime"));
					}
					IL_48:
					if (false)
					{
						continue;
					}
					if (!false)
					{
						break;
					}
					goto IL_48;
					IL_12:
					bool flag = arg_55_0 != 0;
					arg_16_0 = (flag ? 1 : 0);
					goto IL_16;
				}
			}
		}

		public int ProcessedVideoId
		{
			get
			{
				return this._ProcessedVideoId;
			}
			set
			{
				while (true)
				{
					int arg_55_0;
					int arg_16_0;
					int expr_03 = arg_16_0 = (arg_55_0 = this._ProcessedVideoId);
					if (4 == 0)
					{
						goto IL_12;
					}
					if (!false)
					{
						arg_55_0 = ((expr_03 == value) ? 1 : 0);
						goto IL_12;
					}
					IL_16:
					if (arg_16_0 == 0)
					{
						if (!false)
						{
							this._ProcessedVideoId = value;
						}
						this.objPVDetails.ProcessedVideoId = this._ProcessedVideoId;
						this.OnPropertyChanged(new PropertyChangedEventArgs("ProcessedVideoId"));
					}
					IL_48:
					if (false)
					{
						continue;
					}
					if (!false)
					{
						break;
					}
					goto IL_48;
					IL_12:
					bool flag = arg_55_0 != 0;
					arg_16_0 = (flag ? 1 : 0);
					goto IL_16;
				}
			}
		}

		public int MediaType
		{
			get
			{
				return this._MediaType;
			}
			set
			{
				while (true)
				{
					int arg_55_0;
					int arg_16_0;
					int expr_03 = arg_16_0 = (arg_55_0 = this._MediaType);
					if (4 == 0)
					{
						goto IL_12;
					}
					if (!false)
					{
						arg_55_0 = ((expr_03 == value) ? 1 : 0);
						goto IL_12;
					}
					IL_16:
					if (arg_16_0 == 0)
					{
						if (!false)
						{
							this._MediaType = value;
						}
						this.objPVDetails.MediaType = this._MediaType;
						this.OnPropertyChanged(new PropertyChangedEventArgs("MediaType"));
					}
					IL_48:
					if (false)
					{
						continue;
					}
					if (!false)
					{
						break;
					}
					goto IL_48;
					IL_12:
					bool flag = arg_55_0 != 0;
					arg_16_0 = (flag ? 1 : 0);
					goto IL_16;
				}
			}
		}

		public bool IsGuestImage
		{
			get
			{
				return this._IsGuestImage;
			}
			set
			{
				bool arg_0D_0;
				bool arg_3C_0 = arg_0D_0 = this._IsGuestImage;
				do
				{
					if (2 != 0)
					{
						arg_3C_0 = (arg_0D_0 = (arg_0D_0 == value));
					}
				}
				while (false);
				bool flag = arg_3C_0;
				if (7 == 0 || !flag)
				{
					do
					{
						this._IsGuestImage = value;
					}
					while (false);
					this.OnPropertyChanged(new PropertyChangedEventArgs("IsGuestImage"));
				}
			}
		}

		public Visibility PlayVisible
		{
			get
			{
				Visibility result;
				if (!false)
				{
					int arg_10_0;
					int arg_24_0 = arg_10_0 = this.MediaType;
					int arg_0D_0 = 602;
					int expr_21;
					do
					{
						int arg_21_0;
						int expr_0D = arg_21_0 = arg_0D_0;
						if (expr_0D != 0)
						{
							if (arg_10_0 == expr_0D)
							{
								goto IL_28;
							}
							if (8 == 0)
							{
								goto IL_31;
							}
							arg_24_0 = (arg_10_0 = ((this.MediaType == 607) ? 1 : 0));
							arg_21_0 = 0;
						}
						expr_21 = (arg_0D_0 = arg_21_0);
					}
					while (expr_21 != 0);
					bool arg_56_0 = arg_24_0 == expr_21;
					goto IL_29;
					IL_28:
					arg_56_0 = false;
					IL_29:
					if (arg_56_0)
					{
						while (2 == 0)
						{
						}
						result = Visibility.Collapsed;
						return result;
					}
					IL_31:
					result = Visibility.Visible;
				}
				return result;
			}
			set
			{
				this._playVisible = value;
			}
		}

		public string DropVideoPath
		{
			get
			{
				return this._DropVideoPath;
			}
			set
			{
				this._DropVideoPath = value;
			}
		}

		public string slotTime
		{
			get;
			set;
		}

		public long videoLength
		{
			get;
			set;
		}

		public int videoStartTime
		{
			get;
			set;
		}

		public int videoEndTime
		{
			get;
			set;
		}

		public double InsertTime
		{
			get;
			set;
		}

		public Visibility ProcessedVisible
		{
			get
			{
				if (!false)
				{
				}
				int arg_40_0;
				int arg_16_0;
				int expr_33 = arg_16_0 = (arg_40_0 = this.MediaType);
				Visibility result;
				if (7 != 0)
				{
					int arg_16_1;
					int expr_10 = arg_16_1 = 607;
					if (expr_10 != 0)
					{
						arg_16_0 = ((expr_33 == expr_10) ? 1 : 0);
						arg_16_1 = 0;
					}
					if (arg_16_0 == arg_16_1)
					{
						result = Visibility.Hidden;
						if (!false)
						{
							return result;
						}
					}
					arg_40_0 = 0;
				}
				result = (Visibility)arg_40_0;
				return result;
			}
			set
			{
				this._ProcessedVisible = value;
			}
		}

		public Visibility ProcessPlayVisible
		{
			get
			{
				Visibility result;
				if (!false)
				{
					int arg_3C_0;
					bool expr_09 = (arg_3C_0 = ((this.MediaType == 0) ? 1 : 0)) != 0;
					if (!false)
					{
						if (!expr_09)
						{
							goto IL_15;
						}
						arg_3C_0 = 1;
					}
					result = (Visibility)arg_3C_0;
					if (!false)
					{
						goto IL_23;
					}
					goto IL_18;
				}
				IL_15:
				result = Visibility.Visible;
				IL_18:
				IL_23:
				if (-1 != 0)
				{
					return result;
				}
				goto IL_15;
			}
			set
			{
				this._processPlayVisible = value;
			}
		}

		public string tooltip
		{
			get;
			set;
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
