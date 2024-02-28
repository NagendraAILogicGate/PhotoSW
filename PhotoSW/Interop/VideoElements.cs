using ErrorHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PhotoSW.Interop
{
	public class VideoElements
	{
		private string _GuestImagePath;

		private string _VideoFilePath;

		public int PhotoId;

		private string _Name;

		private int _mediaType;

		private Visibility _playVisible;

		private Visibility _ProcessedVisible;

		public string GuestImagePath
		{
			get
			{
				return this._GuestImagePath;
			}
			set
			{
				this._GuestImagePath = value;
			}
		}

		public string VideoFilePath
		{
			get
			{
				return this._VideoFilePath;
			}
			set
			{
				this._VideoFilePath = value;
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
				this._Name = value;
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

		public Visibility PlayVisible
		{
			get
			{
				Visibility result;
				if (!false)
				{
					int arg_0C_0;
					int arg_1C_0 = arg_0C_0 = this.MediaType;
					int arg_09_0 = 2;
					int expr_19;
					do
					{
						int arg_19_0;
						int expr_09 = arg_19_0 = arg_09_0;
						if (expr_09 != 0)
						{
							if (arg_0C_0 == expr_09)
							{
								goto IL_20;
							}
							if (8 == 0)
							{
								goto IL_29;
							}
							arg_1C_0 = (arg_0C_0 = ((this.MediaType == 3) ? 1 : 0));
							arg_19_0 = 0;
						}
						expr_19 = (arg_09_0 = arg_19_0);
					}
					while (expr_19 != 0);
					bool arg_4E_0 = arg_1C_0 == expr_19;
					goto IL_21;
					IL_20:
					arg_4E_0 = false;
					IL_21:
					if (arg_4E_0)
					{
						while (2 == 0)
						{
						}
						result = Visibility.Collapsed;
						return result;
					}
					IL_29:
					result = Visibility.Visible;
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
				if (!false)
				{
				}
				int arg_3C_0;
				int arg_12_0;
				int expr_2F = arg_12_0 = (arg_3C_0 = this.MediaType);
				Visibility result;
				if (7 != 0)
				{
					int arg_12_1;
					int expr_0C = arg_12_1 = 3;
					if (expr_0C != 0)
					{
						arg_12_0 = ((expr_2F == expr_0C) ? 1 : 0);
						arg_12_1 = 0;
					}
					if (arg_12_0 == arg_12_1)
					{
						result = Visibility.Hidden;
						if (!false)
						{
							return result;
						}
					}
					arg_3C_0 = 0;
				}
				result = (Visibility)arg_3C_0;
				return result;
			}
			set
			{
				this._ProcessedVisible = value;
			}
		}

		public long videoLength
		{
			get;
			set;
		}

		public int PageNo
		{
			get;
			set;
		}

		public Visibility isVideoTemplate
		{
			get;
			set;
		}

		public DateTime CreatedDate
		{
			get;
			set;
		}

		public VideoElements()
		{
			this.isVideoTemplate = Visibility.Collapsed;
		}

		public bool IsValidSlot(List<SlotProperty> slotList, int startTime, int stopTime, long currentItemID)
		{
			int arg_DE_0;
			bool result;
			while (true)
			{
				while (true)
				{
					if (false)
					{
						goto IL_E5;
					}
					SlotProperty slotProperty = (from o in slotList
					orderby o.StartTime
					where o.ItemID == currentItemID
					select o).FirstOrDefault<SlotProperty>();
					SlotProperty slotProperty2 = (from o in slotList
					orderby o.StartTime
					where o.ItemID == currentItemID
					select o).LastOrDefault<SlotProperty>();
					bool flag = slotProperty == null;
					bool expr_BF = (arg_DE_0 = (flag ? 1 : 0)) != 0;
					if (5 == 0)
					{
						goto IL_DE;
					}
					if (!expr_BF)
					{
						goto IL_CA;
					}
					goto IL_1E8;
					IL_F2:
					int arg_F2_0;
					int arg_F2_1;
					if (arg_F2_0 >= arg_F2_1)
					{
						goto Block_7;
					}
					List<SlotProperty> list = (from o in slotList
					orderby o.StartTime
					where o.ItemID == currentItemID
					select o).ToList<SlotProperty>();
					SlotProperty item = list.Where(delegate(SlotProperty o)
					{
						int arg_1E_0;
						int arg_4E_0;
						if (o.ItemID != currentItemID || false)
						{
							arg_4E_0 = (arg_1E_0 = 0);
							goto IL_29;
						}
						bool result2;
						if (6 == 0)
						{
							return result2;
						}
						arg_1E_0 = o.StopTime;
						IL_17:
						int arg_21_0 = (arg_1E_0 > startTime) ? 1 : 0;
						do
						{
							arg_21_0 = (arg_1E_0 = (arg_4E_0 = ((arg_21_0 == 0) ? 1 : 0)));
						}
						while (false);
						IL_29:
						if (false)
						{
							goto IL_17;
						}
						result2 = (arg_4E_0 != 0);
						return result2;
					}).LastOrDefault<SlotProperty>();
					SlotProperty slotProperty3 = list[list.IndexOf(item) + 1];
					if (slotProperty3 == null)
					{
						goto IL_1CF;
					}
					while (slotProperty3.StartTime < stopTime)
					{
						MessageBox.Show("Selected item is already applied in the given time frame.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
						result = false;
						if (false)
						{
							goto IL_CA;
						}
						if (true)
						{
							goto Block_15;
						}
					}
					if (!true)
					{
						break;
					}
					result = true;
					if (!false)
					{
						goto Block_13;
					}
					continue;
					IL_CA:
					arg_F2_0 = stopTime;
					int expr_CC = arg_F2_1 = slotProperty.StartTime;
					if (false)
					{
						goto IL_F2;
					}
					if (stopTime <= expr_CC)
					{
						goto Block_6;
					}
					IL_E5:
					arg_F2_0 = startTime;
					arg_F2_1 = slotProperty2.StopTime;
					goto IL_F2;
				}
			}
			Block_6:
			arg_DE_0 = 1;
			IL_DE:
			result = (arg_DE_0 != 0);
			return result;
			Block_7:
			result = true;
			Block_13:
			Block_15:
			return result;
			IL_1CF:
			MessageBox.Show("Selected item is already applied in the given time frame.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
			result = false;
			return result;
			IL_1E8:
			result = true;
			return result;
		}

		public bool IsValidSlot(List<SlotProperty> slotList, int startTime, int stopTime)
		{
			bool result;
			while (true)
			{
				SlotProperty slotProperty = (from o in slotList
				orderby o.StartTime
				select o).FirstOrDefault<SlotProperty>();
				SlotProperty slotProperty2 = (from o in slotList
				orderby o.StartTime
				select o).LastOrDefault<SlotProperty>();
				bool flag = slotProperty == null;
				while (true)
				{
					if (!flag)
					{
						if (false)
						{
							goto IL_198;
						}
						bool arg_A8_0 = stopTime != 0;
						if (!false)
						{
							flag = (stopTime > slotProperty.StartTime);
							if (false)
							{
								goto IL_198;
							}
							arg_A8_0 = flag;
						}
						SlotProperty slotProperty3;
						if (!arg_A8_0)
						{
							if (2 != 0)
							{
								result = true;
								goto IL_19D;
							}
						}
						else
						{
							flag = (startTime < slotProperty2.StopTime);
							if (!flag)
							{
								result = true;
								goto IL_19D;
							}
							List<SlotProperty> list = (from o in slotList
							orderby o.StartTime
							select o).ToList<SlotProperty>();
							SlotProperty item = list.Where(delegate(SlotProperty o)
							{
								int arg_0E_0;
								int arg_14_0 = arg_0E_0 = o.StopTime;
								int arg_14_1;
								do
								{
									int expr_06 = arg_14_1 = startTime;
									if (false)
									{
										goto IL_14;
									}
									arg_14_0 = (arg_0E_0 = ((arg_0E_0 > expr_06) ? 1 : 0));
								}
								while (false);
								arg_14_1 = 0;
								IL_14:
								bool arg_22_0;
								bool expr_14 = arg_22_0 = (arg_14_0 == arg_14_1);
								if (!false)
								{
									bool flag2 = expr_14;
									while (false)
									{
									}
									arg_22_0 = flag2;
								}
								return arg_22_0;
							}).LastOrDefault<SlotProperty>();
							slotProperty3 = list[list.IndexOf(item) + 1];
							flag = (slotProperty3 == null);
							if (flag)
							{
								MessageBox.Show("Selected item is already applied in the given time frame.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
								if (-1 != 0)
								{
									result = false;
									goto IL_19D;
								}
								break;
							}
						}
						flag = (slotProperty3.StartTime < stopTime);
						if (!flag)
						{
							result = true;
						}
						else
						{
							MessageBox.Show("Selected item is already applied in the given time frame.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
							result = false;
						}
					}
					else
					{
						if (!false)
						{
							goto IL_198;
						}
						break;
					}
					IL_19D:
					if (2 != 0)
					{
						return result;
					}
					continue;
					IL_198:
					result = true;
					goto IL_19D;
				}
			}
			return result;
		}

		public void ResizeWPFImage(string sourceImage, int maxHeight, string saveToPath)
		{
			try
			{
				BitmapImage bitmapImage = new BitmapImage();
				BitmapImage bitmapImage2 = new BitmapImage();
				using (FileStream fileStream = File.OpenRead(sourceImage.ToString()))
				{
					MemoryStream memoryStream = new MemoryStream();
					if (5 != 0)
					{
						fileStream.CopyTo(memoryStream);
						int decodePixelWidth;
						if (5 != 0)
						{
							memoryStream.Seek(0L, SeekOrigin.Begin);
							fileStream.Close();
							bitmapImage.BeginInit();
							bitmapImage.StreamSource = memoryStream;
							bitmapImage.EndInit();
							bitmapImage.Freeze();
							decimal d = Convert.ToDecimal(bitmapImage.Width) / Convert.ToDecimal(bitmapImage.Height);
							decodePixelWidth = Convert.ToInt32(maxHeight * d);
							memoryStream.Seek(0L, SeekOrigin.Begin);
							bitmapImage2.BeginInit();
							bitmapImage2.StreamSource = memoryStream;
						}
						bitmapImage2.DecodePixelWidth = decodePixelWidth;
						bitmapImage2.DecodePixelHeight = maxHeight;
					}
					bitmapImage2.EndInit();
					bitmapImage2.Freeze();
				}
				FileStream fileStream2 = new FileStream(saveToPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
				try
				{
					new JpegBitmapEncoder
					{
						QualityLevel = 94,
						Frames = 
						{
							BitmapFrame.Create(bitmapImage2)
						}
					}.Save(fileStream2);
				}
				finally
				{
					if (4 != 0)
					{
						if (fileStream2 != null)
						{
							((IDisposable)fileStream2).Dispose();
						}
					}
				}
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
			finally
			{
				if (8 != 0)
				{
				}
			}
		}
	}
}
