using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using PhotoSW.Manage;
//using DigiPhoto.Orders;
//using DigiPhoto.Shader;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using FrameworkHelper;
using FrameworkHelper.Common;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using DigiPhoto;
using PhotoSW.PSControls;

namespace PhotoSW.Views
{
	public partial class SearchResult : Window, IComponentConnector, IStyleConnector
	{
		public delegate void NextPrimeDelegate();

		public enum SearchTypeConfig
		{
			Image = 1,
			Video,
			ImageVideo
		}

		public static List<LstMyItems> itemsNotPrinted = new List<LstMyItems>();

		public bool flgViewScrl = false;

		private int num = 0;

		public string pagename;

		private bool continueCalculating = false;

		private bool IsEnableGrouping = false;

		private int count;

		private string MktImgPath = string.Empty;

		private int mktImgTime = 0;

		private double dbContr = 0.0;

		private double dbBrit = 0.0;

		private Process currentProcess = Process.GetCurrentProcess();

		public string Photoname = "";

		public long unlockImageId;

		public bool ismod;

		public BitmapImage unlockImage;

		private BitmapImage _objBitmap;

		private string _currentImage;

		private int _currentImageId;

		private int _currentMediaType;

		private bool flgLoadNext = false;

		private bool isBarcodeActive = false;

		//private ShEffect _sharpeff = new ShEffect();

		private bool flgGridWithoutPreview = true;

		private int scrollIndexWithoutPreview;

		private int scrollIndexWithPreview;

		public string Savebackpid = "";

		//public AssociateImage uctlAssociateImage = null;

		public ModalDialog ModalDialog = null;

		///public SaveGroup savegroupusercontrol = null;

		public bool isSingleScreenPreview = false;

		private ClientView clientWin = null;

		public bool returntoHome = true;

		private SearchDetailInfo searchDetails = new SearchDetailInfo();

		public int serachType = 0;

		private FileStream memoryFileStream;

		private static string vsMediaFileName = "";

		public long MaxPhotoIdCriteria = 0L;

		public long MinPhotoIdCriteria = 0L;

		public int NewReord = 0;

		public int AngleValue = 0;

		//public MLMediaPlayer mplayer;

		private int searchType = 3;

		private SearchResult.SearchTypeConfig searchConfig = (SearchResult.SearchTypeConfig)0;

		private List<string> imageList = new List<string>
		{
			"EPS",
			"TIFF",
			"JPEG",
			"GIF",
			"PNG",
			"BMP",
			"JPG"
		};

		private List<string> videoList = new List<string>
		{
			"3G2",
			"3GP",
			"ASF",
			"ASX",
			"AVI",
			"FLV",
			"MOV",
			"MP4",
			"MPG",
			"RM",
			"SWF",
			"VOB",
			"WMV"
		};

		//private MLFrameExtractor mExtractor;

		

		//private bool _contentLoaded;

		public BitmapImage CurrentBitmapImage
		{
			get;
			set;
		}

		public SearchResult()
		{
			try
			{
				this.InitializeComponent();
				if (RobotImageLoader.NotPrintedImages == null)
				{
					RobotImageLoader.NotPrintedImages = new List<LstMyItems>();
				}
				RobotImageLoader._objnewincrement = new List<LstMyItems>();
				this.grdSelectAll.Visibility = Visibility.Visible;
				this.GetConfigPageSize();
				RobotImageLoader.ViewGroupedImagesCount = new List<string>();
				this.LoadPendingBurnOrders();
                this.MsgBox.SetParent(this.ModalDialogParent);
                this.imageInfo.SetParent(this.imageInfoParent);
                this.imageInfo.ExecuteParentMethod += new EventHandler(this.ShowMediaPlayer);
			}
			catch (Exception serviceException)
			{
				ErrorHandler.ErrorHandler.LogError(serviceException);
			}
		}

		private void savegroupusercontrol_ExecuteParentMethod(object sender, EventArgs e)
		{
			if (4 != 0)
			{
				if (2 != 0)
				{
					do
					{
						this.gdMediaPlayer.Visibility = Visibility.Visible;
					}
					while (7 == 0);
					if (!false)
					{
						//this.savegroupusercontrol.ExecuteParentMethod -= new EventHandler(this.savegroupusercontrol_ExecuteParentMethod);
					}
				}
			}
		}

		private void AddUserControlAssociateImage()
		{
			//this.uctlAssociateImage = new AssociateImage();
			this.gdMediaPlayer.Visibility = Visibility.Collapsed;
			//this.uctlAssociateImage.ExecuteParentMethod += new EventHandler(this.ShowMediaPlayer);
			do
			{
				//this.grdCotrol.Children.Add(this.uctlAssociateImage);
				//this.uctlAssociateImage.SetParent(this.ModalDialogParent);
			}
			while (3 == 0);
		}

		private void AddUserControlModalDialog()
		{
			if (2 == 0)
			{
				goto IL_34;
			}
			if (!false)
			{
				//this.ModalDialog = new ModalDialog();
			}
			IL_10:
		//	this.grdCotrol.Children.Add(this.ModalDialog);
			//this.ModalDialog.SetParent(this.ModalDialogParent);
			IL_34:
			if (!false)
			{
				return;
			}
			goto IL_10;
		}

		private void AddUserControlSaveGroup()
		{
            //while (true)
            //{
            //    this.savegroupusercontrol = new SaveGroup();
            //    this.savegroupusercontrol.ExecuteParentMethod += new EventHandler(this.savegroupusercontrol_ExecuteParentMethod);
            //    if (!false)
            //    {
            //        goto IL_33;
            //    }
            //    IL_69:
            //    if (-1 == 0)
            //    {
            //        goto IL_33;
            //    }
            //    this.savegroupusercontrol.ExecuteGroupMethod += new EventHandler(this.savegroupusercontrol_ExecuteGroupMethod);
            //    if (5 == 0)
            //    {
            //        goto IL_33;
            //    }
            //    if (8 != 0)
            //    {
            //        if (!false)
            //        {
            //            break;
            //        }
            //        continue;
            //    }
            //    IL_52:
            //    this.savegroupusercontrol.ExecuteMethod += new EventHandler(this.ClearGroup);
            //    goto IL_69;
            //    IL_33:
            //    this.grdCotrol.Children.Add(this.savegroupusercontrol);
            //    goto IL_52;
            //}
		}

		public SearchResult(bool isShowClientView)
		{
		}

		private void GetConfigPageSize()
		{
            PhotoSW.Business.ConfigBusiness configBusiness = new PhotoSW.Business.ConfigBusiness();
			List<long> objConfigMasterIds = new List<long>
			{
				21L,
				22L,
				67L
			};
			List<iMIXConfigurationInfo> list = (from o in configBusiness.GetNewConfigValues(LoginUser.SubStoreId)
			where objConfigMasterIds.Contains(o.IMIXConfigurationMasterId)
			select o).ToList<iMIXConfigurationInfo>();
			bool flag = list == null;
			ConfigurationInfo configurationData;
			if (8 != 0)
			{
				if (!flag)
				{
					if (false)
					{
						return;
					}
					List<iMIXConfigurationInfo>.Enumerator enumerator = list.GetEnumerator();
					try
					{
						IL_190:
						while (enumerator.MoveNext())
						{
							iMIXConfigurationInfo current = enumerator.Current;
							long iMIXConfigurationMasterId = current.IMIXConfigurationMasterId;
							long arg_AF_0 = iMIXConfigurationMasterId;
							long arg_AF_1 = 1L;
							IL_AF:
							while (arg_AF_0 != arg_AF_1)
							{
								long arg_BC_0 = arg_AF_0 = iMIXConfigurationMasterId;
								int arg_B8_0 = 22;
								while (true)
								{
									long expr_B8 = arg_AF_1 = (long)arg_B8_0;
									if (!true)
									{
										goto IL_AF;
									}
									if (arg_BC_0 > expr_B8)
									{
										goto IL_DF;
									}
									IL_BE:
									if (iMIXConfigurationMasterId < 21L)
									{
										break;
									}
									long expr_C8 = arg_AF_0 = (arg_BC_0 = iMIXConfigurationMasterId);
									int expr_CC = arg_B8_0 = 21;
									if (expr_CC == 0)
									{
										continue;
									}
									switch ((int)(expr_C8 - (long)expr_CC))
									{
									case 0:
										goto IL_F1;
									case 1:
										goto IL_11E;
									}
									IL_DF:
									if (4 != 0)
									{
										goto Block_12;
									}
									goto IL_BE;
								}
								IL_18F:
								goto IL_190;
								Block_12:
								if (iMIXConfigurationMasterId != 67L)
								{
									goto IL_18F;
								}
								LoginUser.IsPhotographerSerailSearchActive = (current.ConfigurationValue != null && current.ConfigurationValue.ToBoolean(false));
								goto IL_18F;
								IL_F1:
								this.dbContr = (string.IsNullOrEmpty(current.ConfigurationValue) ? 0.0 : current.ConfigurationValue.ToDouble(false));
								goto IL_18F;
								IL_11E:
								this.dbBrit = (string.IsNullOrEmpty(current.ConfigurationValue) ? 0.0 : current.ConfigurationValue.ToDouble(false));
								goto IL_18F;
							}
							this.isBarcodeActive = (!string.IsNullOrEmpty(current.ConfigurationValue) && current.ConfigurationValue.ToBoolean(false));
						}
					}
					finally
					{
						do
						{
							((IDisposable)enumerator).Dispose();
						}
						while (2 == 0);
					}
				}
				configurationData = configBusiness.GetConfigurationData(LoginUser.SubStoreId);
				if (configurationData == null)
				{
					goto IL_1E9;
				}
			}
			this.searchDetails.PageSize = 9;
			this.searchDetails.PageNumber = 1;
			IL_1E9:
			if (!RobotImageLoader.Is9ImgViewActive)
			{
				if (configurationData != null)
				{
					this.scrollIndexWithoutPreview = configurationData.DG_PageCountGrid.ToInt32(false);
					this.scrollIndexWithPreview = configurationData.DG_PageCountGrid.ToInt32(false);
				}
			}
			else
			{
				this.scrollIndexWithoutPreview = 9;
				this.scrollIndexWithPreview = this.scrollIndexWithoutPreview;
			}
		}

		private void savegroupusercontrol_ExecuteGroupMethod(object sender, EventArgs e)
		{
			while (true)
			{
				while (4 != 0)
				{
					this.vwGroup.Text = "View Group";
					this.grdSelectAll.Visibility = Visibility.Visible;
					do
					{
						if (5 != 0)
						{
							this.ViewGroup();
						}
					}
					while (3 == 0);
					if (!false)
					{
						return;
					}
				}
			}
		}

		private void LoadNext()
		{
			while (true)
			{
				while (!false)
				{
					this.continueCalculating = false;
					this.flgLoadNext = true;
					while (true)
					{
						RobotImageLoader.LoadImages();
						if (-1 == 0)
						{
							return;
						}
						if (4 != 0)
						{
							this.LoadImages();
						}
						if (false)
						{
							break;
						}
						if (2 != 0)
						{
							return;
						}
					}
				}
			}
		}

		private void LoadImages()
		{
			try
			{
				this.txtimageofphotographer.Visibility = Visibility.Collapsed;
				this.txtcountspace.Visibility = Visibility.Collapsed;
				if (RobotImageLoader.robotImages.Count != 0)
				{
					int arg_77_0;
					if (RobotImageLoader.UserId > 0)
					{
						if (!(RobotImageLoader.SearchCriteria == "Time"))
						{
							bool expr_1C3 = (arg_77_0 = ((RobotImageLoader.SearchCriteria == "TimeWithQrcode") ? 1 : 0)) != 0;
							if (!false)
							{
								arg_77_0 = ((!expr_1C3) ? 1 : 0);
							}
						}
						else
						{
							arg_77_0 = 0;
						}
					}
					else
					{
						arg_77_0 = 1;
					}
					if (arg_77_0 == 0)
					{
						this.txtimageofphotographer.Visibility = Visibility.Visible;
						this.txtcountspace.Visibility = Visibility.Visible;
						this.txtimageofphotographer.Text = "PhotoGrapherImage: " + RobotImageLoader.ImgCount;
					}
					else
					{
						this.txtimageofphotographer.Visibility = Visibility.Collapsed;
						this.txtcountspace.Visibility = Visibility.Collapsed;
					}
					while (true)
					{
						RobotImageLoader.IsLastPage = false;
						this.lstImages.Items.Clear();
						this.num = 0;
						if (!this.continueCalculating)
						{
							goto IL_112;
						}
						if (8 == 0)
						{
							goto IL_180;
						}
						this.continueCalculating = false;
						IL_14C:
						if (4 == 0)
						{
							continue;
						}
						if (!false)
						{
							break;
						}
						IL_112:
						this.continueCalculating = true;
						if (RobotImageLoader.robotImages == null)
						{
							RobotImageLoader.LoadImages();
						}
						this.LoadImagestoList();
						this.CheckSelectAllGroup();
						this.SPSelectAll.Visibility = Visibility.Visible;
						goto IL_14C;
					}
				}
				else
				{
					this.lstImages.Items.Clear();
					RobotImageLoader.IsLastPage = true;
				}
				IL_156:
				if (2 == 0)
				{
					goto IL_156;
				}
				this.SetMessageText("Grouped");
				IL_180:;
			}
			catch (Exception serviceException)
			{
				if (8 != 0)
				{
					string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
					ErrorHandler.ErrorHandler.LogFileWrite(message);
				}
			}
			finally
			{
			}
			if (!false)
			{
			}
		}

		private void CheckSelectAllGroup()
		{
			int arg_35_0;
			int expr_01 = arg_35_0 = (RobotImageLoader.IsLastPage ? 1 : 0);
			int arg_35_1;
			int expr_07 = arg_35_1 = 0;
			if (expr_07 != 0)
			{
				goto IL_35;
			}
			bool flag = expr_01 == expr_07;
			bool arg_13_0 = flag;
			IL_13:
			if (!arg_13_0)
			{
				return;
			}
			if (RobotImageLoader.ViewGroupedImagesCount == null)
			{
				goto IL_3F;
			}
			arg_35_0 = RobotImageLoader.robotImages.Count<LstMyItems>();
			IL_2B:
			arg_35_1 = RobotImageLoader.ViewGroupedImagesCount.Count;
			IL_35:
			bool expr_35 = arg_13_0 = (arg_35_0 == arg_35_1);
			bool arg_A1_0;
			if (3 != 0)
			{
				arg_A1_0 = !expr_35;
				goto IL_40;
			}
			goto IL_13;
			IL_3F:
			arg_A1_0 = true;
			IL_40:
			flag = arg_A1_0;
			bool expr_A4 = (arg_35_0 = (flag ? 1 : 0)) != 0;
			if (false)
			{
				goto IL_2B;
			}
			if (!expr_A4)
			{
				this.chkSelectAll.IsChecked = new bool?(true);
				if (8 != 0)
				{
					goto IL_70;
				}
			}
			this.chkSelectAll.IsChecked = new bool?(false);
			IL_70:
			if (4 == 0)
			{
				goto IL_3F;
			}
			this.chkSelectAll.Visibility = Visibility.Visible;
		}

		private void FillImageList()
		{
			RobotImageLoader.ViewGroupedImagesCount = new List<string>();
			List<LstMyItems>.Enumerator enumerator = RobotImageLoader.robotImages.GetEnumerator();
			//goto IL_1B;
			try
			{
				while (true)
				{
					IL_1B:
					if (4 != 0)
					{
						if (!false)
						{
							goto IL_5E;
						}
						goto IL_5E;
					}
					LstMyItems current;
					bool flag;
					do
					{
						IL_2A:
						flag = !(current.BmpImageGroup.UriSource.ToString() == "/images/view-accept.png");
					}
					while (false);
					if (5 == 0)
					{
						continue;
					}
					if (!flag)
					{
						RobotImageLoader.ViewGroupedImagesCount.Add(current.Name);
					}
					if (!false)
					{
						goto IL_5E;
					}
					IL_23:
					current = enumerator.Current;
					//goto IL_2A;
					IL_5E:
					if (!enumerator.MoveNext())
					{
						break;
					}
					goto IL_23;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		private void LoadImagestoList()
		{
			int num = RobotImageLoader.robotImages.Count;
			LstMyItems expr_2A9 = new LstMyItems();
			LstMyItems lstMyItems;
			if (true)
			{
				lstMyItems = expr_2A9;
			}
			this.txtSelectedImages.Foreground = new SolidColorBrush(Colors.Black);
			bool flag = this.num >= num;
			if (!flag)
			{
				if (false)
				{
					goto IL_FC;
				}
				lstMyItems = RobotImageLoader.robotImages[this.num];
				if (!this.continueCalculating)
				{
					goto IL_271;
				}
				this.lstImages.Items.Add(lstMyItems);
				int arg_B7_0;
				bool arg_15E_0 = ((this.pagename == "Saveback") ? (arg_B7_0 = 0) : (arg_B7_0 = ((!(this.pagename == "Placeback")) ? 1 : 0))) != 0;
				IL_B0:
				if (8 == 0)
				{
					goto IL_15D;
				}
				if (arg_B7_0 != 0)
				{
					goto IL_14D;
				}
				if (lstMyItems.PhotoId != this.Savebackpid.ToInt32(false))
				{
					goto IL_14C;
				}
				if (false)
				{
					goto IL_14B;
				}
				this.lstImages.SelectedIndex = this.lstImages.Items.Count - 1;
				IL_FC:
				this.lstImages.ScrollIntoView(this.lstImages.SelectedIndex);
				ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
				listBoxItem.Focus();
				this.pagename = "";
				IL_14B:
				IL_14C:
				IL_14D:
				arg_15E_0 = (lstMyItems.Name == RobotImageLoader.RFID);
				IL_15D:
				if (!arg_15E_0)
				{
					goto IL_1DA;
				}
				bool expr_171 = (arg_B7_0 = ((arg_15E_0 = (this.lstImages.SelectedItem == null)) ? 1 : 0)) != 0;
				if (false)
				{
					goto IL_B0;
				}
				flag = !expr_171;
			}
			else
			{
				this.continueCalculating = false;
				if (6 != 0)
				{
					this.num = 0;
					return;
				}
			}
			if (!flag)
			{
				if (2 == 0)
				{
					goto IL_270;
				}
				this.lstImages.SelectedItem = lstMyItems;
				this.lstImages.ScrollIntoView(this.lstImages.SelectedIndex);
				ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
				listBoxItem.Focus();
			}
			IL_1DA:
			int arg_1E6_0;
			int arg_200_0 = arg_1E6_0 = this.num;
			while (2 != 0)
			{
				if (arg_1E6_0 == num - 1)
				{
					bool expr_1F4 = (arg_1E6_0 = (arg_200_0 = ((this.lstImages.SelectedIndex == -1) ? 1 : 0))) != 0;
					if (false)
					{
						continue;
					}
					arg_200_0 = ((!expr_1F4) ? 1 : 0);
				}
				else
				{
					arg_200_0 = 1;
				}
				break;
			}
			if (arg_200_0 == 0)
			{
				this.lstImages.SelectedIndex = 0;
				this.lstImages.ScrollIntoView(this.lstImages.SelectedIndex);
				ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
				listBoxItem.Focus();
			}
			base.Dispatcher.BeginInvoke(DispatcherPriority.Background, new SearchResult.NextPrimeDelegate(this.LoadImagestoList));
			IL_270:
			IL_271:
			this.num++;
		}

		private childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
		{
			int num;
			if (true)
			{
				num = 0;
				goto IL_81;
			}
			IL_0C:
			DependencyObject child = VisualTreeHelper.GetChild(obj, num);
			bool arg_D3_0 = child == null || !(child is childItem);
			bool flag;
			bool expr_DA;
			do
			{
				if (7 != 0)
				{
					flag = arg_D3_0;
				}
				expr_DA = (arg_D3_0 = flag);
			}
			while (false);
			childItem result;
			if (!expr_DA)
			{
				if (3 != 0)
				{
					result = (childItem)((object)child);
					goto IL_A0;
				}
			}
			else
			{
            //    childItem childItem = this.FindVisualChild<childItem>(child);
            //    flag = (childItem == null);
            //    if (!flag)
            //    {
            //        result = childItem;
            //        goto IL_A0;
            //    }
            //    if (false)
            //    {
            //        goto IL_81;
            //    }
            }
			int arg_80_0;
			int expr_7A = arg_80_0 = num;
			if (5 != 0)
			{
				arg_80_0 = expr_7A + 1;
			}
			num = arg_80_0;
			IL_81:
			flag = (num < VisualTreeHelper.GetChildrenCount(obj));
			IL_8C:
			if (flag)
			{
				goto IL_0C;
			}
			result = default(childItem);
			IL_A0:
			if (!false)
			{
				return result;
			}
			goto IL_8C;
		}

		private BitmapImage GetImageFromPath(string path)
		{
			BitmapImage result;
			try
			{
				BitmapImage bitmapImage = new BitmapImage();
				FileStream fileStream = File.OpenRead(path);
				try
				{
					if (8 != 0)
					{
						MemoryStream expr_70 = new MemoryStream();
						MemoryStream memoryStream;
						if (!false)
						{
							memoryStream = expr_70;
						}
						do
						{
							Stream expr_80 = fileStream;
							Stream expr_86 = memoryStream;
							if (!false)
							{
								expr_80.CopyTo(expr_86);
							}
							memoryStream.Seek(0L, SeekOrigin.Begin);
							if (4 != 0)
							{
								fileStream.Close();
								bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
							}
							bitmapImage.BeginInit();
						}
						while (false);
						do
						{
							bitmapImage.StreamSource = memoryStream;
						}
						while (!true);
						bitmapImage.EndInit();
						bitmapImage.Freeze();
					}
					fileStream.Close();
					result = bitmapImage;
				}
				finally
				{
					bool arg_BA_0 = fileStream == null;
					while (true)
					{
						bool flag = arg_BA_0;
						while (true)
						{
							bool expr_BC = arg_BA_0 = flag;
							if (5 == 0)
							{
								break;
							}
							if (expr_BC)
							{
								goto IL_CD;
							}
							if (!false)
							{
								goto Block_10;
							}
						}
					}
					Block_10:
					((IDisposable)fileStream).Dispose();
					IL_CD:;
				}
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
				result = null;
			}
			return result;
		}

		private void CheckForAllImgSelectToPrint()
		{
			int num = (from p in RobotImageLoader.PrintImages
			join g in RobotImageLoader.GroupImages on p.PhotoId equals g.PhotoId
			select p.PhotoId).Count<int>();
			if (RobotImageLoader.PrintImages.Count <= 0)
			{
				goto IL_AD;
			}
			int arg_8F_0;
			int arg_A3_0 = arg_8F_0 = RobotImageLoader.GroupImages.Count;
			int arg_8C_0 = 0;
			int expr_A3;
			int expr_A6;
			do
			{
				int arg_A3_1;
				int expr_8C = arg_A3_1 = arg_8C_0;
				if (expr_8C == 0)
				{
					if (arg_8F_0 <= expr_8C)
					{
						goto IL_AD;
					}
					if (false)
					{
						goto IL_B8;
					}
					arg_A3_0 = num;
					arg_A3_1 = RobotImageLoader.GroupImages.Count;
				}
				expr_A3 = (arg_8F_0 = (arg_A3_0 = ((arg_A3_0 == arg_A3_1) ? 1 : 0)));
				expr_A6 = (arg_8C_0 = 0);
			}
			while (expr_A6 != 0);
			int arg_120_0 = (expr_A3 == expr_A6) ? 1 : 0;
			bool expr_126;
			do
			{
				IL_AE:
				bool flag = arg_120_0 != 0;
				expr_126 = ((arg_120_0 = (flag ? 1 : 0)) != 0);
			}
			while (6 == 0);
			if (!expr_126)
			{
				goto IL_B8;
			}
			if (!false)
			{
				this.chkSelectAll.IsChecked = new bool?(false);
			}
			return;
			IL_AD:
			arg_120_0 = 1;
			//goto IL_AE;
			IL_B8:
			this.chkSelectAll.IsChecked = new bool?(true);
		}

		public void GetNewMaxId(out long maxPhotoId, int mediaType)
		{
			while (!false)
			{
				long num = 0L;
				if (6 == 0)
				{
					break;
				}
				PhotoBusiness photoBusiness = new PhotoBusiness();
				while (4 != 0)
				{
					string arg_55_0;
					if (!RobotImageLoader.GetShowAllSubstorePhotos())
					{
						arg_55_0 = LoginUser.DefaultSubstores;
					}
					else
					{
						if (false)
						{
							continue;
						}
						arg_55_0 = string.Empty;
					}
					string substoreId = arg_55_0;
					if (!false)
					{
						photoBusiness.GetMaxId(substoreId, out num, mediaType);
					}
					maxPhotoId = num;
					return;
				}
			}
		}

		private void LoadImageGroupPrev()
		{
			bool flag;
			if (!false)
			{
				if (-1 == 0)
				{
					goto IL_21;
				}
				flag = (this.lstImages.Items.Count != 0);
			}
			if (false)
			{
				goto IL_21;
			}
			int arg_1F_0 = flag ? 1 : 0;
			IL_1F:
			if (arg_1F_0 != 0)
			{
				return;
			}
			IL_21:
			RobotImageLoader.IsNextPage = true;
			RobotImageLoader.ViewGroupedImagesCount.Clear();
			int expr_32 = arg_1F_0 = this.scrollIndexWithoutPreview;
			if (7 == 0)
			{
				goto IL_1F;
			}
			RobotImageLoader.thumbSet = expr_32;
			this.flgLoadNext = true;
			if (!false)
			{
				this.LoadNext();
			}
			this.FillImageList();
			this.CheckSelectAllGroup();
		}

		private void LoadImageGroupNext()
		{
			while (true)
			{
				IL_00:
				int arg_8C_0 = (this.lstImages.Items.Count != 0) ? 1 : 0;
				while (true)
				{
					bool flag = arg_8C_0 != 0;
					if (7 == 0)
					{
						break;
					}
					if (!false)
					{
						if (flag)
						{
							return;
						}
						RobotImageLoader.ViewGroupedImagesCount.Clear();
					}
					while (true)
					{
						int num = this.scrollIndexWithoutPreview;
						RobotImageLoader.IsNextPage = false;
						int expr_45 = arg_8C_0 = num;
						if (false)
						{
							break;
						}
						RobotImageLoader.thumbSet = expr_45;
						if (3 == 0)
						{
							goto IL_00;
						}
						this.flgLoadNext = true;
						if (3 != 0)
						{
							goto Block_5;
						}
					}
				}
			}
			Block_5:
			this.LoadNext();
			this.FillImageList();
			this.CheckSelectAllGroup();
		}

		private void ClearResources()
		{
			//System.Windows.DataObject.RemovePastingHandler(this.txtImageId, new DataObjectPastingEventHandler(this.PastingHandler));
			this.btnEdit.Click -= new RoutedEventHandler(this.btnEdit_Click);
			System.Windows.Controls.Primitives.ButtonBase expr_46 = this.btnHome;
			RoutedEventHandler expr_56 = new RoutedEventHandler(this.btnHome_Click);
			if (4 != 0)
			{
				expr_46.Click -= expr_56;
			}
			this.btnLogout.Click -= new RoutedEventHandler(this.btnLogout_Click);
			this.btnPlaceOrder.Click -= new RoutedEventHandler(this.btnPlaceOrder_Click);
			this.btnPrintGroup.Click -= new RoutedEventHandler(this.btnPrintGroup_Click);
			this.btnSearchPhoto.Click -= new RoutedEventHandler(this.btnSearchPhoto_Click);
			this.btnWithoutPreview.Click -= new RoutedEventHandler(this.btnWithoutPreview_Click);
			this.btnWithPreviewActive.Click -= new RoutedEventHandler(this.btnWithPreviewActive_Click);
			this.btnWithoutPreview9.Click -= new RoutedEventHandler(this.btnWithoutPreview9_Click);
			this.btnViewGroup.Click -= new RoutedEventHandler(this.btnWithPreviewActive_Click);
			this.btnViewGroup.Click -= new RoutedEventHandler(this.btnViewGroup_Click);
			this.chkSelectAll.Click -= new RoutedEventHandler(this.chkSelectAll_Click);
			this.btnSearchPhoto.Click -= new RoutedEventHandler(this.chkSelectAll_Click);
			//this.savegroupusercontrol.ExecuteMethod -= new EventHandler(this.ClearGroup);
			if (!false)
			{
				//this.savegroupusercontrol.ExecuteGroupMethod -= new EventHandler(this.savegroupusercontrol_ExecuteGroupMethod);
				base.KeyUp -= new System.Windows.Input.KeyEventHandler(this.Window_KeyUp);
				RobotImageLoader.ViewGroupedImagesCount = null;
                //this.savegroupusercontrol = null;
                //this.uctlAssociateImage = null;
                //this.ModalDialog = null;
				RobotImageLoader._objnewincrement = null;
				MemoryManagement.DisposeImage(this.CurrentBitmapImage);
				this.CurrentBitmapImage = null;
				//this.ModalDialog = null;
				this.lstImages.Items.Clear();
				this._objBitmap = null;
				this.unlockImage = null;
				base.ClearValue(System.Windows.Controls.TextBox.TextProperty);
				base.ClearValue(FrameworkElement.TagProperty);
				base.ClearValue(FrameworkElement.WidthProperty);
				base.ClearValue(FrameworkElement.HeightProperty);
				base.ClearValue(TextBlock.TextProperty);
				base.ClearValue(TextBlock.TextProperty);
				this.lstImages.Items.Clear();
				RobotImageLoader.currentCount = 0;
				if (false)
				{
					goto IL_3FD;
				}
				base.Closed -= new EventHandler(this.Window_Closed);
				base.Loaded -= new RoutedEventHandler(this.Window_Loaded);
				base.Unloaded -= new RoutedEventHandler(this.Window_Unloaded);
				this.btnPlaceOrder.Click -= new RoutedEventHandler(this.btnPlaceOrder_Click);
				this.btnImageAddToGroup.Click -= new RoutedEventHandler(this.btnImageAddToGroup_Click);
				this.btnRemoveGroup.Click -= new RoutedEventHandler(this.btnRemoveGroup_Click);
				this.btnUnloack.Click -= new RoutedEventHandler(this.btnUnlock_Click);
				this.btnViewGroup.Click -= new RoutedEventHandler(this.btnViewGroup_Click);
				this.lstImages.SelectionChanged -= new SelectionChangedEventHandler(this.lstImages_SelectionChanged);
				this.chkSelectAll.Click -= new RoutedEventHandler(this.chkSelectAll_Click);
				//this.txtImageId.KeyDown -= new System.Windows.Input.KeyEventHandler(this.bttnLogin_Enter);
			}
			this.Ok.Click -= new RoutedEventHandler(this.btnSearchImage_Click);
			this.btnQRSearch.Click -= new RoutedEventHandler(this.btnQRSearch_Click);
			this.btnPendingOrders.Click -= new RoutedEventHandler(this.btnPendingOrders_Click);
			this.btnchkpreview.Click -= new RoutedEventHandler(this.btnpreview_Click);
			this.btnNextButton.Click -= new RoutedEventHandler(this.btnScrollDown_Click);
			this.btnPrevButton.Click -= new RoutedEventHandler(this.btnScrollUp_Click);
			IL_3FD:
			//this.txtImageId.PreviewTextInput -= new TextCompositionEventHandler(this.txtAmountEntered_PreviewTextInput);
			BindingOperations.ClearBinding(this.lstImages, ItemsControl.ItemsSourceProperty);
			this.ModalDialogParent = null;
		}

		private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
		{
		}

		private void btnPrintGroup_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				System.Windows.Controls.Image image = (System.Windows.Controls.Image)this.btnPrintGroup.Content;
				LstMyItems lstMyItems;
				if (this.vwGroup.Text == "View Group" && this.pagename != "Saveback")
				{
					lstMyItems = (from t in RobotImageLoader.robotImages
					where t.PhotoId == this._currentImageId
					select t).First<LstMyItems>();
				}
				else
				{
					lstMyItems = (from t in RobotImageLoader.GroupImages
					where t.PhotoId == this._currentImageId
					select t).First<LstMyItems>();
				}
				this.lstImages.SelectedItem = lstMyItems;
				ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
				listBoxItem.Focus();
				LstMyItems lstMyItems2 = (from t in RobotImageLoader.PrintImages
				where t.PhotoId == this._currentImageId
				select t).FirstOrDefault<LstMyItems>();
				ListBoxItem listBoxItem2;
				if (lstMyItems2 == null)
				{
					LstMyItems lstMyItems3 = new LstMyItems();
					lstMyItems3 = lstMyItems;
					lstMyItems3.Name = this._currentImage;
					lstMyItems3.PhotoId = lstMyItems.PhotoId;
					lstMyItems3.MediaType = lstMyItems.MediaType;
					lstMyItems3.VideoLength = lstMyItems.VideoLength;
					lstMyItems3.FileName = lstMyItems.FileName;
					lstMyItems3.FilePath = lstMyItems.FilePath;
					RobotImageLoader.PrintImages.Add(lstMyItems3);
					image.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
					lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
					ContentPresenter contentPresenter = this.FindVisualChild<ContentPresenter>(listBoxItem);
					DataTemplate contentTemplate = contentPresenter.ContentTemplate;
					Grid grid = (Grid)contentTemplate.FindName("grdMain", contentPresenter);
					((System.Windows.Controls.Image)((System.Windows.Controls.Button)((Grid)grid.FindName("Printbtns")).Children[0]).Content).Source = null;
					((System.Windows.Controls.Image)((System.Windows.Controls.Button)((Grid)grid.FindName("Printbtns")).Children[0]).Content).Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
				}
				else
				{
					RobotImageLoader.PrintImages.Remove(lstMyItems2);
					image.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
					lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
					if (this.pagename == "Saveback")
					{
						if (this.vwGroup.Text == "View Group" && this.pagename == "Saveback")
						{
							using (List<LstMyItems>.Enumerator enumerator = RobotImageLoader.GroupImages.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									LstMyItems itx = enumerator.Current;
									LstMyItems lstMyItems4 = (from xs in RobotImageLoader.PrintImages
									where xs.PhotoId == itx.PhotoId
									select xs).FirstOrDefault<LstMyItems>();
									if (lstMyItems4 == null)
									{
										RobotImageLoader.NotPrintedImages.Add(itx);
									}
								}
							}
							if (RobotImageLoader.NotPrintedImages.Count != 0)
							{
								using (List<LstMyItems>.Enumerator enumerator = RobotImageLoader.NotPrintedImages.GetEnumerator())
								{
									while (enumerator.MoveNext())
									{
										LstMyItems ity = enumerator.Current;
										this.lstImages.Items.Remove(ity);
										LstMyItems lstMyItems5 = (from tg in RobotImageLoader.GroupImages
										where tg.PhotoId == ity.PhotoId
										select tg).FirstOrDefault<LstMyItems>();
										lstMyItems5.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
									}
								}
							}
							this.SPSelectAll.Visibility = Visibility.Hidden;
							this.SetMessageText("EditPrintGrouped");
							this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
						}
						else
						{
							this.SPSelectAll.Visibility = Visibility.Visible;
						}
						bool arg_49C_0 = this.lstImages.Items.Count != 0;
						if (false)
						{
							goto IL_8C6;
						}
						if (!arg_49C_0)
						{
							this.IMGFrame.Visibility = Visibility.Collapsed;
							Grid.SetColumnSpan(this.thumbPreview, 2);
							Grid.SetColumn(this.thumbPreview, 0);
							this.thumbPreview.Margin = new Thickness(0.0);
							this.pagename = "";
							this.SPSelectAll.Visibility = Visibility.Visible;
							this.vwGroup.Text = "View Group";
							this.flgGridWithoutPreview = true;
							this.ViewGroup();
							return;
						}
						this.lstImages.SelectedIndex = 0;
						listBoxItem2 = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.Items[0]);
						listBoxItem2.Focus();
						this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
						if (((LstMyItems)this.lstImages.SelectedItem).MediaType == 1)
						{
							this.imgmain.Source = this.GetImageFromPath(LoginUser.DigiFolderBigThumbnailPath + Convert.ToString(((LstMyItems)this.lstImages.SelectedItem).FileName));
						}
					}
					ContentPresenter contentPresenter = this.FindVisualChild<ContentPresenter>(listBoxItem);
					if (7 == 0)
					{
						goto IL_909;
					}
					DataTemplate contentTemplate = contentPresenter.ContentTemplate;
					Grid grid = (Grid)contentTemplate.FindName("grdMain", contentPresenter);
					((System.Windows.Controls.Image)((System.Windows.Controls.Button)((Grid)grid.FindName("Printbtns")).Children[0]).Content).Source = null;
					((System.Windows.Controls.Image)((System.Windows.Controls.Button)((Grid)grid.FindName("Printbtns")).Children[0]).Content).Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
				}
				if (this.vwGroup.Text == "View Group")
				{
					this.SetMessageText("Grouped");
				}
				else
				{
					this.SetMessageText("PrintGrouped");
				}
				if (this.vwGroup.Text == "View Group" && this.pagename == "Saveback")
				{
					using (List<LstMyItems>.Enumerator enumerator = RobotImageLoader.GroupImages.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							LstMyItems itx = enumerator.Current;
							LstMyItems lstMyItems4 = (from xs in RobotImageLoader.PrintImages
							where xs.PhotoId == itx.PhotoId
							select xs).FirstOrDefault<LstMyItems>();
							if (lstMyItems4 == null)
							{
								RobotImageLoader.NotPrintedImages.Add(itx);
							}
						}
					}
					if (RobotImageLoader.NotPrintedImages.Count != 0)
					{
						using (List<LstMyItems>.Enumerator enumerator = RobotImageLoader.NotPrintedImages.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								LstMyItems ity = enumerator.Current;
								this.lstImages.Items.Remove(ity);
								LstMyItems lstMyItems5 = (from tg in RobotImageLoader.GroupImages
								where tg.PhotoId == ity.PhotoId
								select tg).FirstOrDefault<LstMyItems>();
								lstMyItems5.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
							}
						}
					}
					this.SetMessageText("EditPrintGrouped");
					this.SPSelectAll.Visibility = Visibility.Hidden;
				}
				else
				{
					this.SPSelectAll.Visibility = Visibility.Visible;
				}
				if (this.lstImages.Items.Count <= 0 || this.lstImages.SelectedIndex != -1)
				{
					goto IL_8DF;
				}
				this.lstImages.SelectedIndex = 0;
				listBoxItem2 = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.Items[0]);
				listBoxItem2.Focus();
				IL_8C6:
				this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
				IL_8DF:
				if (this.vwGroup.Text == "View All")
				{
					this.CheckForAllImgSelectToPrint();
					goto IL_918;
				}
				IL_909:
				this.FillImageList();
				this.CheckSelectAllGroup();
				IL_918:;
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
		}

		private void btnHome_Click(object sender, RoutedEventArgs e)
		{
			Home home;
			while (true)
			{
				bool arg_125_0;
				bool expr_06 = arg_125_0 = this.returntoHome;
				if (-1 != 0)
				{
					if (expr_06)
					{
						goto IL_24;
					}
					goto IL_1CF;
				}
				IL_124:
				//ClientView clientView;
				if (!arg_125_0)
				{
					//clientView.instructionVideo.Visibility = Visibility.Visible;
					goto IL_137;
				}
				//clientView.imgDefault.Visibility = Visibility.Visible;
				IL_15B:
				if (false)
				{
					continue;
				}
                //clientView.testR.Fill = null;
                //clientView.DefaultView = true;
                bool flag = false; //clientView.instructionVideo.Visibility != Visibility.Visible;
				if (!flag)
				{
					if (-1 == 0)
					{
						goto IL_137;
					}
					//clientView.instructionVideo.Play();
				}
				else
				{
					//clientView.instructionVideo.Pause();
				}
				this.CompileEffectChanged(null, -2);
				home = new Home();
				if (!false)
				{
					break;
				}
				goto IL_E3;
				IL_137:
				//clientView.instructionVideo.Play();
				if (true)
				{
					goto IL_15B;
				}
				goto IL_24;
				IL_E3:
				if (!flag)
				{
					//clientView = new ClientView();
					//clientView.WindowStartupLocation = WindowStartupLocation.Manual;
				}
				//clientView.GroupView = false;
				//clientView.DefaultView = false;
				arg_125_0 = (this.MktImgPath == "" || this.mktImgTime == 0);
				goto IL_124;
				IL_24:
				if (!false)
				{
					this.MediaStop();
				}
				SearchResult.vsMediaFileName = string.Empty;
				RobotImageLoader.IsZeroSearchNeeded = true;
				RobotImageLoader.StartIndex = 0;
				this.vwGroup.Text = "View Group";
				this.GetMktImgInfo();
				//clientView = null;
				IEnumerator enumerator = System.Windows.Application.Current.Windows.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Window window = (Window)enumerator.Current;
						bool arg_9E_0 = !(window.Title == "ClientView");
						bool expr_9F;
						do
						{
							flag = arg_9E_0;
							expr_9F = (arg_9E_0 = flag);
						}
						while (4 == 0);
						if (!expr_9F)
						{
							//clientView = (ClientView)window;
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
					IL_D5:
					if (false)
					{
						goto IL_D5;
					}
				}
                flag = false; //(clientView != null);
				goto IL_E3;
			}
			home.Show();
			base.Hide();
			return;
			IL_1CF:
			this.returntoHome = true;
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			try
			{
				do
				{
					if (8 != 0)
					{
						if (5 == 0)
						{
							continue;
						}
						this.MediaStop();
						this.ClearResources();
					}
				}
				while (false);
			}
			catch
			{
				while (false)
				{
				}
			}
		}

		private void btnPrint_Click(object sender, RoutedEventArgs e)
		{
            //SearchResult.c__DisplayClass2d expr_7C1 = new SearchResult.c__DisplayClass2d();
            //SearchResult.c__DisplayClass2d  c__DisplayClass2d;
            //if (4 != 0)
            //{
            //     c__DisplayClass2d = expr_7C1;
            //}
            // c__DisplayClass2d.sender = sender;
            //try
            //{
            //    System.Windows.Controls.Button button = (System.Windows.Controls.Button) c__DisplayClass2d.sender;
            //    System.Windows.Controls.Image image = (System.Windows.Controls.Image)button.Content;
            //    if (this.vwGroup.Text == "View Group" && this.pagename != "Saveback")
            //    {
            //        RobotImageLoader.curItem = RobotImageLoader.robotImages.Where(delegate(LstMyItems t)
            //        {
            //            if (false)
            //            {
            //                goto IL_24;
            //            }
            //            int arg_1A_0 = t.PhotoId;
            //            bool expr_1A;
            //            do
            //            {
            //                IL_07:
            //                //expr_1A = ((arg_1A_0 = ((arg_1A_0 == (int)((System.Windows.Controls.Button)c__DisplayClass2d.sender).CommandParameter) ? 1 : 0)) != 0);
            //            }
            //            while (7 == 0 || 8 == 0);
            //            bool flag = expr_1A;
            //            IL_24:
            //            bool expr_43 = (arg_1A_0 = (flag ? 1 : 0)) != 0;
            //            if (!false)
            //            {
            //                return expr_43;
            //            }
            //            goto IL_07;
            //        }).First<LstMyItems>();
            //    }
            //    else
            //    {
            //        RobotImageLoader.curItem = RobotImageLoader.GroupImages.Where(delegate(LstMyItems t)
            //        {
            //            if (false)
            //            {
            //                goto IL_24;
            //            }
            //            int arg_1A_0 = t.PhotoId;
            //            bool expr_1A;
            //            do
            //            {
            //                IL_07:
            //                //expr_1A = ((arg_1A_0 = ((arg_1A_0 == (int)((System.Windows.Controls.Button)c__DisplayClass2d.sender).CommandParameter) ? 1 : 0)) != 0);
            //            }
            //            while (7 == 0 || 8 == 0);
            //            bool flag = expr_1A;
            //            IL_24:
            //            bool expr_43 = (arg_1A_0 = (flag ? 1 : 0)) != 0;
            //            if (!false)
            //            {
            //                return expr_43;
            //            }
            //            goto IL_07;
            //        }).First<LstMyItems>();
            //    }
            //    LstMyItems lstMyItems = RobotImageLoader.PrintImages.Where(delegate(LstMyItems t)
            //    {
            //        if (false)
            //        {
            //            goto IL_24;
            //        }
            //        int arg_1A_0 = t.PhotoId;
            //        bool expr_1A=false;
            //        do
            //        {
            //            IL_07:
            //            //expr_1A = ((arg_1A_0 = ((arg_1A_0 == (int)((System.Windows.Controls.Button)c__DisplayClass2d.sender).CommandParameter) ? 1 : 0)) != 0);
            //        }
            //        while (7 == 0 || 8 == 0);
            //        bool flag = expr_1A;
            //        IL_24:
            //        bool expr_43 = (arg_1A_0 = (flag ? 1 : 0)) != 0;
            //        if (!false)
            //        {
            //            return expr_43;
            //        }
            //        goto IL_07;
            //    }).FirstOrDefault<LstMyItems>();
            //    int num = 0;
            //    if (lstMyItems == null)
            //    {
            //        LstMyItems lstMyItems2 = new LstMyItems();
            //        lstMyItems2 = RobotImageLoader.curItem;
            //        lstMyItems2.Name = (string)((System.Windows.Controls.Button)sender).Tag;
            //        lstMyItems2.PhotoId = RobotImageLoader.curItem.PhotoId;
            //        lstMyItems2.MediaType = RobotImageLoader.curItem.MediaType;
            //        lstMyItems2.VideoLength = RobotImageLoader.curItem.VideoLength;
            //        lstMyItems2.FileName = RobotImageLoader.curItem.FileName;
            //        lstMyItems2.CreatedOn = RobotImageLoader.curItem.CreatedOn;
            //        lstMyItems2.OnlineQRCode = RobotImageLoader.curItem.OnlineQRCode;
            //        lstMyItems2.FilePath = RobotImageLoader.curItem.FilePath;
            //        RobotImageLoader.PrintImages.Add(lstMyItems2);
            //        image.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
            //        RobotImageLoader.curItem.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
            //        this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
            //    }
            //    else
            //    {
            //        num = this.NextGroupSelectedIndex(this.lstImages.Items.IndexOf(lstMyItems));
            //        RobotImageLoader.PrintImages.Remove(lstMyItems);
            //        image.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
            //        RobotImageLoader.curItem.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
            //        this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
            //        if (this.lstImages.Items.Count == 0)
            //        {
            //            this.pagename = "";
            //        }
            //        if (this.lstImages.Items.Count > 0)
            //        {
            //            if (num < 0)
            //            {
            //                num = 0;
            //            }
            //            this.lstImages.SelectedItem = this.lstImages.Items[num];
            //            ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.Items[num]);
            //            listBoxItem.Focus();
            //        }
            //        else
            //        {
            //            this.continueCalculating = false;
            //            this.num = 0;
            //            RobotImageLoader.currentCount = 0;
            //            RobotImageLoader.IsZeroSearchNeeded = true;
            //            RobotImageLoader.RFID = "0";
            //            RobotImageLoader.LoadImages();
            //            this.LoadImages();
            //            this.IMGFrame.Visibility = Visibility.Collapsed;
            //            Grid.SetColumnSpan(this.thumbPreview, 2);
            //            Grid.SetColumn(this.thumbPreview, 0);
            //            this.thumbPreview.Margin = new Thickness(0.0);
            //            this.vwGroup.Text = "View Group";
            //            this.flgGridWithoutPreview = true;
            //            this.btnprev.Visibility = Visibility.Visible;
            //            this.btnnext.Visibility = Visibility.Visible;
            //            ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
            //        }
            //    }
            //    this.lstImages.SelectedItem = RobotImageLoader.curItem;
            //    if (this.vwGroup.Text == "View All")
            //    {
            //        this.CheckForAllImgSelectToPrint();
            //    }
            //    if (this.vwGroup.Text == "View Group")
            //    {
            //        this.SetMessageText("Grouped");
            //    }
            //    else
            //    {
            //        this.SetMessageText("PrintGrouped");
            //    }
            //    if (this.vwGroup.Text == "View Group" && this.pagename == "Saveback")
            //    {
            //        using (List<LstMyItems>.Enumerator enumerator = RobotImageLoader.GroupImages.GetEnumerator())
            //        {
            //            while (enumerator.MoveNext())
            //            {
            //                LstMyItems itx = enumerator.Current;
            //                LstMyItems lstMyItems3 = (from xs in RobotImageLoader.PrintImages
            //                where xs.PhotoId == itx.PhotoId
            //                select xs).FirstOrDefault<LstMyItems>();
            //                if (lstMyItems3 == null)
            //                {
            //                    RobotImageLoader.NotPrintedImages.Add(itx);
            //                }
            //            }
            //        }
            //        if (RobotImageLoader.NotPrintedImages.Count != 0)
            //        {
            //            using (List<LstMyItems>.Enumerator enumerator = RobotImageLoader.NotPrintedImages.GetEnumerator())
            //            {
            //                while (enumerator.MoveNext())
            //                {
            //                    LstMyItems ity = enumerator.Current;
            //                    this.lstImages.Items.Remove(ity);
            //                    LstMyItems lstMyItems4 = (from tg in RobotImageLoader.GroupImages
            //                    where tg.PhotoId == ity.PhotoId
            //                    select tg).FirstOrDefault<LstMyItems>();
            //                    lstMyItems4.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
            //                }
            //            }
            //        }
            //        this.SetMessageText("EditPrintGrouped");
            //        this.SPSelectAll.Visibility = Visibility.Hidden;
            //    }
            //    else
            //    {
            //        this.SPSelectAll.Visibility = Visibility.Visible;
            //    }
            //    if (this.lstImages.Items.Count == 0)
            //    {
            //        this.IMGFrame.Visibility = Visibility.Collapsed;
            //        Grid.SetColumnSpan(this.thumbPreview, 2);
            //        Grid.SetColumn(this.thumbPreview, 0);
            //        this.thumbPreview.Margin = new Thickness(0.0);
            //        this.pagename = "";
            //        this.SPSelectAll.Visibility = Visibility.Visible;
            //        this.vwGroup.Text = "View Group";
            //        this.ViewGroup();
            //    }
            //    else
            //    {
            //        ListBoxItem listBoxItem2 = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
            //        if (listBoxItem2 != null)
            //        {
            //            listBoxItem2.Focus();
            //        }
            //        else if (this.lstImages.Items.Count > 0 && this.lstImages.SelectedIndex == -1)
            //        {
            //            this.lstImages.SelectedIndex = num;
            //            ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.Items[num]);
            //            listBoxItem.Focus();
            //            this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
            //        }
            //    }
            //}
            //catch (Exception serviceException)
            //{
            //    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
            //    ErrorHandler.ErrorHandler.LogFileWrite(message);
            //}
            //finally
            //{
            //}
		}

		private int NextGroupSelectedIndex(int currentIndex)
		{
			int arg_40_0;
			int num;
			int arg_47_0;
			int expr_33;
			while (true)
			{
				IL_00:
				int arg_02_0 = -1;
				int num2=0;
				bool expr_1A;
				do
				{
					int expr_02 = arg_40_0 = arg_02_0;
					if (expr_02 == 0)
					{
						goto IL_3F;
					}
					num = expr_02;
					num2 = this.lstImages.Items.Count;
					expr_1A = ((arg_02_0 = ((num2 <= 0) ? 1 : 0)) != 0);
				}
				while (7 == 0);
				bool flag = expr_1A;
				bool arg_26_0;
				arg_47_0 = ((arg_26_0 = flag) ? 1 : 0);
				while (5 != 0)
				{
					if (arg_26_0)
					{
						goto IL_42;
					}
					if (8 == 0)
					{
						goto IL_00;
					}
					if (num2 > currentIndex + 1)
					{
						goto IL_3E;
					}
					expr_33 = ((arg_26_0 = ((arg_47_0 = currentIndex) != 0)) ? 1 : 0);
					if (8 != 0)
					{
						goto Block_6;
					}
				}
				return arg_47_0;
			}
			Block_6:
			arg_40_0 = (currentIndex = expr_33 - 1);
			goto IL_3F;
			IL_3E:
			arg_40_0 = currentIndex;
			IL_3F:
			num = arg_40_0;
			IL_42:
			int num3 = num;
			arg_47_0 = num3;
			return arg_47_0;
		}

		private void MainImage_Click(object sender, RoutedEventArgs e)
		{
            //SearchResult.c__DisplayClass41 expr_B13 = new SearchResult.c__DisplayClass41();
            //SearchResult.c__DisplayClass41 c__DisplayClass;
            //if (5 != 0)
            //{
            //    c__DisplayClass = expr_B13;
            //}
            //c__DisplayClass.sender = sender;
			//c__DisplayClass.4__this = this;
			this.MediaStop();
			Grid.SetColumnSpan(this.thumbPreview, 1);
			Grid.SetColumn(this.thumbPreview, 1);
			this.thumbPreview.Margin = new Thickness(0.0, 0.0, -77.5, 8.0);
			ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Visible);
			this.imgwithPreview.Source = new BitmapImage(new Uri("/images/thumbnailview1_active.png", UriKind.Relative));
			this.imgwithoutPreview.Source = new BitmapImage(new Uri("images/16blocks_black.png", UriKind.Relative));
			this.imgwithoutPreview9.Source = new BitmapImage(new Uri("/images/9Blocks_black.png", UriKind.Relative));
			try
			{
				this.IMGFrame.Visibility = Visibility.Visible;
				LstMyItems lstMyItems;
				LstMyItems lstMyItems2;
				int photoId;
				LstMyItems curItem;
				if (!(this.vwGroup.Text == "View Group") || !(this.pagename != "Saveback"))
				{
                    //LstMyItems curItem = RobotImageLoader.GroupImages.Where(delegate(LstMyItems t)
                    //{
                    //    bool result;
                    //    do
                    //    {
                    //        if (true && !false)
                    //        {
                    //            result = (t.FilePath == ((System.Windows.Controls.Button)c__DisplayClass.sender).Tag);
                    //        }
                    //        while (false)
                    //        {
                    //        }
                    //    }
                    //    while (8 == 0);
                    //    return result;
                    //}).FirstOrDefault<LstMyItems>();
                    //if (curItem.MediaType != 1)
                    //{
                    //    if (curItem.MediaType == 2)
                    //    {
                    //        if (!false)
                    //        {
                    //            using (FileStream fileStream = File.OpenRead(Path.Combine(curItem.HotFolderPath, "Videos", curItem.CreatedOn.ToString("yyyyMMdd"), curItem.FileName)))
                    //            {
                    //                SearchResult.vsMediaFileName = fileStream.Name;
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        using (FileStream fileStream = File.OpenRead(Path.Combine(curItem.HotFolderPath, "ProcessedVideos", curItem.CreatedOn.ToString("yyyyMMdd"), curItem.FileName)))
                    //        {
                    //            SearchResult.vsMediaFileName = fileStream.Name;
                    //        }
                    //    }
                    //    this.MediaPlay();
                    //}
                    //if (this.lstImages.SelectedItem != curItem)
                    //{
                    //    this.lstImages.SelectedItem = curItem;
                    //    ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
                    //    listBoxItem.Focus();
                    //    RobotImageLoader.UniquePhotoId = curItem.PhotoId;
                    //    RobotImageLoader.PhotoId = curItem.Name.ToString();
                    //}
                    //else
                    //{
                    //    this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
                    //    this.txtMainImage.Text = ((LstMyItems)this.lstImages.SelectedItem).Name;
                    //    this._currentImage = ((LstMyItems)this.lstImages.SelectedItem).Name;
                    //    this._currentImageId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
                    //    lstMyItems = (from t in RobotImageLoader.GroupImages
                    //    where t.PhotoId == this._currentImageId
                    //    select t).FirstOrDefault<LstMyItems>();
                    //    if (lstMyItems != null)
                    //    {
                    //        this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                    //        this.btnImageAddToGroup.ToolTip = "Remove from group";
                    //    }
                    //    else
                    //    {
                    //        this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-GROUP.png", UriKind.Relative));
                    //        this.btnImageAddToGroup.ToolTip = "Add to group";
                    //    }
                    //    lstMyItems2 = (from t in RobotImageLoader.PrintImages
                    //    where t.PhotoId == curItem.PhotoId
                    //    select t).FirstOrDefault<LstMyItems>();
                    //    if (lstMyItems2 != null)
                    //    {
                    //        if (false)
                    //        {
                    //            goto IL_6A8;
                    //        }
                    //        this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                    //    }
                    //    else
                    //    {
                    //        this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                    //    }
                    //    photoId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
                    //    this.unlockImageId = (long)photoId;
                    //}
                    //goto IL_A3E;
				}
				//SearchResult.c__DisplayClass41 CS$<>8__locals42;
				while (true)
				{
					//CS$<>8__locals42 = <>c__DisplayClass;
					curItem = RobotImageLoader.robotImages.Where(delegate(LstMyItems t)
					{
						int arg_5A_0;
						int arg_2D_0;
						int num;
						do
						{
							int expr_31 = arg_2D_0 = (arg_5A_0 = t.PhotoId);
							if (false)
							{
								goto IL_2A;
							}
							if (false)
							{
								goto IL_25;
							}
							num = expr_31;
						}
						while (8 == 0);
						arg_5A_0 = 0;//((num.ToString() == ((System.Windows.Controls.Button)<>c__DisplayClass.sender).CommandParameter.ToString()) ? 1 : 0);
						IL_25:
						bool flag = arg_5A_0 != 0;
						arg_5A_0 = (arg_2D_0 = (flag ? 1 : 0));
						IL_2A:
						if (3 != 0)
						{
							return arg_2D_0 != 0;
						}
						goto IL_25;
					}).FirstOrDefault<LstMyItems>();
					if (curItem != null)
					{
						if (curItem.MediaType != 2 && curItem.MediaType != 3)
						{
							goto IL_303;
						}
						if (-1 == 0)
						{
							goto IL_303;
						}
						this.btnEdit.IsEnabled = false;
						this.img.Visibility = Visibility.Hidden;
						this.vidoriginal.Visibility = Visibility.Visible;
						string fileName = curItem.FileName;
						if (!string.IsNullOrEmpty(fileName))
						{
							if (curItem.MediaType == 2)
							{
								using (FileStream fileStream = File.OpenRead(Path.Combine(curItem.HotFolderPath, "Videos", curItem.CreatedOn.ToString("yyyyMMdd"), fileName)))
								{
									SearchResult.vsMediaFileName = fileStream.Name;
								}
							}
							else
							{
								using (FileStream fileStream = File.OpenRead(Path.Combine(curItem.HotFolderPath, "ProcessedVideos", curItem.CreatedOn.ToString("yyyyMMdd"), fileName)))
								{
									SearchResult.vsMediaFileName = fileStream.Name;
								}
							}
						}
						this.MediaPlay();
						this.txtMainVideo.Text = curItem.Name;
						IL_332:
						if (this.lstImages.SelectedItem != curItem)
						{
							if (curItem != null)
							{
								this.lstImages.SelectedItem = curItem;
								RobotImageLoader.PhotoId = curItem.Name;
								ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
								listBoxItem.Focus();
								this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
							}
						}
						if (this.lstImages.SelectedItem != null)
						{
							if (false)
							{
								goto IL_669;
							}
							this._currentImageId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
							this.txtMainImage.Text = ((LstMyItems)this.lstImages.SelectedItem).Name;
						}
						lstMyItems = (from t in RobotImageLoader.GroupImages
						where t.PhotoId == curItem.PhotoId
						select t).FirstOrDefault<LstMyItems>();
						if (lstMyItems != null)
						{
							this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
							this.btnImageAddToGroup.ToolTip = "Remove from group";
						}
						else
						{
							this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-GROUP.png", UriKind.Relative));
							this.btnImageAddToGroup.ToolTip = "Add to group";
						}
						lstMyItems2 = (from t in RobotImageLoader.PrintImages
						where t.PhotoId == curItem.PhotoId
						select t).FirstOrDefault<LstMyItems>();
						if (lstMyItems2 == null)
						{
							goto IL_510;
						}
						if (false)
						{
							break;
						}
						this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
						if (2 != 0)
						{
							break;
						}
						continue;
						IL_303:
						this.btnEdit.IsEnabled = true;
						this.img.Visibility = Visibility.Visible;
						this.vidoriginal.Visibility = Visibility.Hidden;
						this.MediaStop();
						goto IL_332;
					}
					goto IL_534;
				}
				goto IL_52E;
				IL_510:
				this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
				IL_52E:
				goto IL_6CA;
				IL_534:
				this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
				this.txtMainImage.Text = ((LstMyItems)this.lstImages.SelectedItem).Name;
				this._currentImage = ((LstMyItems)this.lstImages.SelectedItem).Name;
				this._currentImageId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
				lstMyItems = (from t in RobotImageLoader.GroupImages
				where t.PhotoId == this._currentImageId
				select t).FirstOrDefault<LstMyItems>();
				if (lstMyItems != null)
				{
					this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
					this.btnImageAddToGroup.ToolTip = "Remove from group";
				}
				else
				{
					this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-GROUP.png", UriKind.Relative));
					this.btnImageAddToGroup.ToolTip = "Add to group";
				}
				lstMyItems2 = (from t in RobotImageLoader.PrintImages
				where t.PhotoId == curItem.PhotoId
				select t).FirstOrDefault<LstMyItems>();
				if (lstMyItems2 == null)
				{
					this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
					goto IL_6A8;
				}
				IL_669:
				this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
				IL_6A8:
				photoId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
				this.unlockImageId = (long)photoId;
				IL_6CA:
				IL_A3E:
				if (this.lstImages.Items.Count > 0 && this.lstImages.SelectedIndex == -1)
				{
					this.lstImages.SelectedIndex = 0;
					ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.Items[0]);
					this.lstImages.SelectedItem = listBoxItem;
					this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
					listBoxItem.Focus();
				}
				this.flgGridWithoutPreview = false;
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
			finally
			{
			}
		}

		private void setPreview(BitmapImage objBitmap, bool GroupView, bool defaultview)
		{
			try
			{
				//ClientView clientView = null;
				IEnumerator enumerator = System.Windows.Application.Current.Windows.GetEnumerator();
				bool flag;
				try
				{
					while (enumerator.MoveNext())
					{
						Window window = (Window)enumerator.Current;
						if (window.Title == "ClientView")
						{
							//clientView = (ClientView)window;
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					flag = (disposable == null);
					if (!false)
					{
						if (!flag)
						{
							disposable.Dispose();
						}
					}
				}
                //if (clientView == null)
                //{
                //    //clientView = new ClientView();
                //    //clientView.WindowStartupLocation = WindowStartupLocation.Manual;
                //    goto IL_B6;
                //}
				//IL_9B:
				//clientView.WindowStartupLocation = WindowStartupLocation.Manual;
				IL_A2:
				IL_B6:
				flag = (RobotImageLoader.GroupImages.Count >= 0);
				if (7 == 0)
				{
					//goto IL_9B;
				}
				int arg_156_0;
				if (!flag)
				{
					if (false)
					{
						goto IL_A2;
					}
                    //clientView.DefaultView = true;
                    //clientView.GroupView = false;
				}
				else
				{
					int expr_EB = arg_156_0 = RobotImageLoader.GroupImages.Count;
					if (false)
					{
						goto IL_155;
					}
					if (expr_EB > 0)
					{
						//clientView.DefaultView = false;
						if (3 == 0)
						{
							//goto IL_129;
						}
						//clientView.GroupView = true;
					}
					else
					{
						//clientView.GroupView = false;
						if (!false)
						{
							//clientView.DefaultView = false;
							//goto IL_129;
						}
					}
					goto IL_145;
					//IL_129:
                    //clientView.ChildImage = objBitmap;
                    //clientView.Photoname = this.txtMainImage.Text;
				}
				IL_E2:
				IL_145:
				//clientView.SetEffect();
				Screen[] allScreens = Screen.AllScreens;
				arg_156_0 = allScreens.Length;
				IL_155:
				if (arg_156_0 > 1)
				{
					if (allScreens[0].Primary)
					{
						if (!true)
						{
							goto IL_E2;
						}
						Screen screen = Screen.AllScreens[1];
						Rectangle workingArea = screen.WorkingArea;
                        //clientView.Top = (double)workingArea.Top;
                        //clientView.Left = (double)workingArea.Left;
                        //clientView.Show();
					}
					else
					{
						Rectangle workingArea = allScreens[0].WorkingArea;
                        //clientView.Top = (double)workingArea.Top;
                        //clientView.Left = (double)workingArea.Left;
                        //clientView.Show();
					}
				}
				else
				{
					//clientView.Show();
				}
			}
			catch (Exception serviceException)
			{
				if (4 != 0)
				{
					string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
					ErrorHandler.ErrorHandler.LogFileWrite(message);
				}
			}
			finally
			{
				MemoryManagement.FlushMemory();
			}
		}

		private void btnEdit_Click(object sender, RoutedEventArgs e)
		{
            this.MediaStop();
            do
            {
                if (this.lstImages.SelectedItem != null)
                {
                    try
                    {
                        int arg_67_0;
                        int arg_3BF_0 = (this.vwGroup.Text == "View All") ? (arg_67_0 = 0) : (arg_67_0 = ((!(this.pagename == "Saveback")) ? 1 : 0));
                        if (false)
                        {
                            goto IL_3BE;
                        }
                        if (arg_67_0 == 0)
                        {
                            RobotImageLoader.NotPrintedImages.Clear();
                            using (List<LstMyItems>.Enumerator enumerator = RobotImageLoader.GroupImages.GetEnumerator())
                            {
                                while (enumerator.MoveNext())
                                {
                                    LstMyItems itx = enumerator.Current;
                                    LstMyItems lstMyItems = (from xs in RobotImageLoader.PrintImages
                                                             where xs.PhotoId == itx.PhotoId
                                                             select xs).FirstOrDefault<LstMyItems>();
                                    if (lstMyItems == null)
                                    {
                                        RobotImageLoader.NotPrintedImages.Add(itx);
                                    }
                                }
                            }
                        }
                        this.continueCalculating = false;
                        this.num = 0;
                        MainWindow instance;
                        if (MainWindow.Instance != null)
                        {
                            instance = MainWindow.Instance;
                        }
                        else
                        {
                            instance = new MainWindow();// MainWindow.Instance;
                        }
                        if (this.pagename == "Saveback")
                        {
                            instance.IsGoupped = "View All";
                            goto IL_166;
                        }
                    IL_155:
                        instance.IsGoupped = this.vwGroup.Text;
                    IL_166:
                        ContantValueForMainWindow.RedEyeSize = 0.0105;
                        instance.WindowState = WindowState.Maximized;
                        instance.WindowStyle = WindowStyle.None;
                        int photoId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
                        instance.PhotoName = ((LstMyItems)this.lstImages.SelectedItem).Name;
                        PhotoInfo photoDetailsbyPhotoId;
                        bool flag;
                        bool isGreenImageParam;
                        bool crop;
                        while (true)
                        {
                        IL_1B6:
                            instance.PhotoId = photoId;
                            if (5 != 0)
                            {
                                instance.dbBrit = (instance._brighteff.Brightness = this.dbBrit);
                            }
                            instance.dbContr = (instance._brighteff.Contrast = this.dbContr);
                            instance.SetEffect();
                            PhotoBusiness photoBusiness = new PhotoBusiness();
                            photoDetailsbyPhotoId = photoBusiness.GetPhotoDetailsbyPhotoId(photoId);
                            instance.HotFolderPath = photoDetailsbyPhotoId.HotFolderPath;
                            instance.BigThumnailFolderPath = Path.Combine(photoDetailsbyPhotoId.HotFolderPath, "Thumbnails_Big");
                            if (-1 == 0)
                            {
                                goto IL_436;
                            }
                            instance.ThumnailFolderPath = Path.Combine(photoDetailsbyPhotoId.HotFolderPath, "Thumbnails");
                            instance.CropFolderPath = Path.Combine(photoDetailsbyPhotoId.HotFolderPath, "Croped");
                            instance.tempfilename = photoDetailsbyPhotoId.DG_Photos_FileName;
                            instance.semiOrderProfileId = photoDetailsbyPhotoId.SemiOrderProfileId;
                            if (photoDetailsbyPhotoId != null)
                            {
                                flag = string.IsNullOrEmpty(photoDetailsbyPhotoId.DG_Photos_Effects);
                                while (!flag)
                                {
                                    if (4 != 0)
                                    {
                                        instance.ImageEffect = photoDetailsbyPhotoId.DG_Photos_Effects;
                                        if (5 == 0)
                                        {
                                        IL_2C8:
                                            instance.ImageEffect = string.Concat(new string[]
                                            {
                                                "<image brightness = '",
                                                this.dbBrit.ToString(),
                                                "' contrast = '",
                                                this.dbContr.ToString(),
                                                "' Crop='##' colourvalue = '##' rotatewidth='##' rotateheight='##' rotate='##' flipMode='0' flipModeY='0' _centerx ='0' _centery='0'><effects sharpen='##' greyscale='0' digimagic='0' sepia='0' defog='0' underwater='0' emboss='0' invert = '0' granite='0' hue ='##' cartoon = '0' firstredeye= 'false' firstradius='.0105' firstcenterx='.5' firstcentery='.5' secondredeye= 'false' secondradius='.0105' secondcenterx='.5' secondcentery='.5'></effects></image>"
                                            });
                                        }
                                        isGreenImageParam = false;
                                        isGreenImageParam = (photoDetailsbyPhotoId.DG_Photos_IsGreen.HasValue && photoDetailsbyPhotoId.DG_Photos_IsGreen.Value);
                                        crop = (photoDetailsbyPhotoId.DG_Photos_IsCroped.HasValue && photoDetailsbyPhotoId.DG_Photos_IsCroped.Value);
                                        flag = !photoDetailsbyPhotoId.DG_Photos_IsRedEye.HasValue;
                                        if (!false)
                                        {
                                            goto Block_19;
                                        }
                                        goto IL_1B6;
                                    }
                                }
                                //goto IL_2C8;
                            }
                            goto IL_437;
                        }
                    Block_19:
                        bool redeye = !flag && photoDetailsbyPhotoId.DG_Photos_IsRedEye.Value;
                        DateTime arg_3BC_0 = photoDetailsbyPhotoId.DG_Photos_CreatedOn;
                        arg_3BF_0 = 1;
                    IL_3BE:
                        flag = (arg_3BF_0 == 0);
                        instance.DateFolder = photoDetailsbyPhotoId.DG_Photos_CreatedOn.ToString("yyyyMMdd");
                        if (!true)
                        {
                            goto IL_155;
                        }
                        try
                        {
                            instance.Onload(redeye, crop, isGreenImageParam, photoDetailsbyPhotoId.DG_Photos_Layering, photoDetailsbyPhotoId.IsGumRideShow);
                            instance.ShowStripImages();
                            instance.searchDetails = this.searchDetails;
                            instance.Show();
                        }
                        catch (Exception serviceException)
                        {
                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                        }
                    IL_436:
                    IL_437:
                        base.Hide();
                    }
                    catch (Exception serviceException)
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                    finally
                    {
                    }
                }
            }
            while (6 == 0);
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    try
                    {
                        int expr_15;
                        while (true)
                        {
                            int arg_15_0;
                            int arg_40_0 = arg_15_0 = LoginUser.UserId;
                            while (true)
                            {
                                if (5 != 0)
                                {
                                   // AuditLog.AddUserLog(arg_40_0, 39, "Logged out at ");
                                    if (false)
                                    {
                                        break;
                                    }
                                    arg_15_0 = 1;
                                }
                                expr_15 = (arg_15_0 = (arg_40_0 = arg_15_0));
                                if (expr_15 != 0)
                                {
                                    goto Block_6;
                                }
                            }
                        }
                    Block_6:
                        RobotImageLoader.IsZeroSearchNeeded = (expr_15 != 0);
                        Login login = new Login();
                        login.Show();
                        this.CompileEffectChanged(null, -2);
                        base.Close();
                    }
                    catch (Exception serviceException)
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                    while (!true)
                    {
                    }
                }
                finally
                {
                    MemoryManagement.FlushMemory();
                }
            }
            while (false);
		}

		private void btnSearchPhoto_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				bool arg_0D_0 = this.returntoHome;
				while (arg_0D_0)
				{
					this.MediaStop();
					RobotImageLoader.IsZeroSearchNeeded = true;
					this.vwGroup.Text = "View Group";
					if (!false)
					{
						this.GetMktImgInfo();
					}
					//ClientView clientView = null;
					IEnumerator enumerator = System.Windows.Application.Current.Windows.GetEnumerator();
					try
					{
						while (true)
						{
							IL_9C:
							bool flag = enumerator.MoveNext();
							bool arg_A7_0 = flag;
							while (arg_A7_0)
							{
								Window window = (Window)enumerator.Current;
								flag = !(window.Title == "ClientView");
								bool expr_8B = arg_A7_0 = flag;
								if (!false)
								{
									if (!expr_8B)
									{
										//clientView = (ClientView)window;
									}
									goto IL_9C;
								}
							}
							break;
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						bool arg_B9_0 = disposable == null;
						bool expr_BB;
						do
						{
							bool flag = arg_B9_0;
							expr_BB = (arg_B9_0 = flag);
						}
						while (7 == 0);
						if (!expr_BB)
						{
							disposable.Dispose();
						}
					}
					if (5 == 0)
					{
						goto IL_194;
					}
                    //if (clientView == null)
                    //{
                    //    //clientView = new ClientView();
                    //    //clientView.WindowStartupLocation = WindowStartupLocation.Manual;
                    //}
                    //clientView.GroupView = false;
                    //clientView.DefaultView = false;
					IL_FF:
					bool arg_124_0;
					if (!(this.MktImgPath == ""))
					{
						arg_124_0 = (arg_0D_0 = (this.mktImgTime == 0));
						if (-1 == 0)
						{
							continue;
						}
					}
					else
					{
						arg_124_0 = true;
					}
					if (!arg_124_0)
					{
                        //clientView.instructionVideo.Visibility = Visibility.Visible;
                        //clientView.instructionVideo.Play();
						if (!true)
						{
							goto IL_26A;
						}
					}
					else
					{
						//clientView.imgDefault.Visibility = Visibility.Visible;
					}
                    //clientView.testR.Fill = null;
                    //clientView.DefaultView = true;
                    //if (clientView.instructionVideo.Visibility == Visibility.Visible)
                    //{
                    //    clientView.instructionVideo.Play();
                    //}
                    //else
                    //{
                    //    clientView.instructionVideo.Pause();
                    //}
					IL_1A2:
					Window window2 = null;
					enumerator = System.Windows.Application.Current.Windows.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							Window window = (Window)enumerator.Current;
							if (window.Title == "Search")
							{
								window2 = (window as SearchByPhoto);
								break;
							}
						}
					}
					finally
					{
						do
						{
							IDisposable disposable = enumerator as IDisposable;
							if (disposable == null)
							{
								break;
							}
							disposable.Dispose();
						}
						while (false);
					}
					SearchByPhoto searchByPhoto;
					if (window2 != null)
					{
						if (false)
						{
							goto IL_1A1;
						}
						searchByPhoto = (SearchByPhoto)window2;
					}
					else
					{
						searchByPhoto = new SearchByPhoto();
					}
					RobotImageLoader.PageName = "SearchResult";
					searchByPhoto.Show();
					this.continueCalculating = false;
					if (5 != 0)
					{
						searchByPhoto.LoadData();
						base.Hide();
						goto IL_26A;
					}
					goto IL_FF;
					IL_194:
					IL_1A1:
					goto IL_1A2;
					IL_26A:
					return;
				}
				this.returntoHome = true;
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
		}

		private void btnWithoutPreview_Click(object sender, RoutedEventArgs e)
		{
			this.MediaStop();
			this.continueCalculating = false;
			if (this.scrollIndexWithoutPreview == 9)
			{
				ConfigBusiness configBusiness = new ConfigBusiness();
				ConfigurationInfo configurationData = configBusiness.GetConfigurationData(LoginUser.SubStoreId);
				if (configurationData != null)
				{
					this.scrollIndexWithoutPreview = Convert.ToInt32(configurationData.DG_PageCountGrid);
					this.scrollIndexWithPreview = this.scrollIndexWithoutPreview;
					RobotImageLoader.thumbSet = this.scrollIndexWithPreview;
				}
			}
			this.imgwithPreview.Source = new BitmapImage(new Uri("/images/thumbnailview1.png", UriKind.Relative));
			this.imgwithoutPreview.Source = new BitmapImage(new Uri("images/16blocks_red.png", UriKind.Relative));
			this.imgwithoutPreview9.Source = new BitmapImage(new Uri("/images/9Blocks_black.png", UriKind.Relative));
			RobotImageLoader.Is9ImgViewActive = false;
			RobotImageLoader.Is16ImgViewActive = true;
			RobotImageLoader.IsPreview9or16active = true;
			RobotImageLoader.IsPreviewModeActive = false;
			if (RobotImageLoader.robotImages != null && RobotImageLoader.robotImages.Count > 0)
			{
				RobotImageLoader.StartIndex = RobotImageLoader.robotImages[0].PhotoId;
				if (RobotImageLoader.GroupImages != null && RobotImageLoader.GroupImages.Count > 0)
				{
					RobotImageLoader.GroupImages.ForEach(delegate(LstMyItems t)
					{
						if (!false)
						{
							t.GridMainHeight = 140;
							if (!false)
							{
								if (false)
								{
									return;
								}
								t.GridMainWidth = 170;
							}
						}
						do
						{
							t.GridMainRowHeight1 = 90;
							int expr_27 = 60;
							if (4 != 0)
							{
								t.GridMainRowHeight2 = expr_27;
							}
						}
						while (-1 == 0);
					});
				}
				bool arg_193_0;
				if (RobotImageLoader.PrintImages != null)
				{
					arg_193_0 = (RobotImageLoader.PrintImages.Count <= 0);
					goto IL_192;
				}
				IL_191:
				arg_193_0 = true;
				IL_192:
				if (!arg_193_0)
				{
					RobotImageLoader.PrintImages.ForEach(delegate(LstMyItems t)
					{
						if (!false)
						{
							t.GridMainHeight = 140;
							if (!false)
							{
								if (false)
								{
									return;
								}
								t.GridMainWidth = 170;
							}
						}
						do
						{
							t.GridMainRowHeight1 = 90;
							int expr_27 = 60;
							if (4 != 0)
							{
								t.GridMainRowHeight2 = expr_27;
							}
						}
						while (-1 == 0);
					});
				}
				if (RobotImageLoader.SearchCriteria == "TimeWithQrcode")
				{
					ConfigBusiness configBusiness = new ConfigBusiness();
					ConfigurationInfo configurationData = configBusiness.GetConfigurationData(LoginUser.SubStoreId);
					if (configurationData != null)
					{
						this.searchDetails.PageSize = configurationData.DG_PageCountGrid.ToInt32(false);
					}
					else
					{
						this.searchDetails.PageSize = 16;
					}
					RobotImageLoader.LoadImages(this.searchDetails);
				}
				else
				{
					RobotImageLoader.LoadImages();
				}
				IL_236:
				if (this.vwGroup.Text == "View Group")
				{
					try
					{
						bool arg_295_0;
						if (this.txtSelectImages.Text.Contains("Print Grouped"))
						{
							arg_295_0 = (this.txtSelectImages.Visibility != Visibility.Visible);
						}
						else
						{
							if (7 == 0)
							{
								goto IL_4FE;
							}
							arg_295_0 = true;
						}
						if (!arg_295_0)
						{
							ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Visible);
							this.SetMessageText("EditPrintGroupedView");
							this.SPSelectAll.Visibility = Visibility.Hidden;
							this.lstImages.Items.Clear();
							this.btnprev.Visibility = Visibility.Collapsed;
							this.btnnext.Visibility = Visibility.Collapsed;
							ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Visible);
							IEnumerable<LstMyItems> enumerable = from p in RobotImageLoader.PrintImages
							join g in RobotImageLoader.GroupImages on p.PhotoId equals g.PhotoId into ALLCOLUMNS
							from entry in ALLCOLUMNS
							select entry;
							foreach (LstMyItems current in enumerable)
							{
								this.lstImages.Items.Add(current);
								if (current.PhotoId == RobotImageLoader.UniquePhotoId)
								{
									try
									{
										if (-1 == 0)
										{
											goto IL_420;
										}
										this.lstImages.SelectedItem = current;
										IL_3FD:
										ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
										IL_420:
										listBoxItem.Focus();
										this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
										if (false)
										{
											goto IL_3FD;
										}
									}
									catch (Exception serviceException)
									{
										string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
										ErrorHandler.ErrorHandler.LogFileWrite(message);
									}
								}
							}
							goto IL_55C;
						}
						this.LoadImages();
						if (string.Compare(RobotImageLoader.SearchCriteria, "Time", true) == 0 || string.Compare(RobotImageLoader.SearchCriteria, "QRCODE", true) == 0 || string.Compare(RobotImageLoader.SearchCriteria, "TimeWithQrcode", true) == 0)
						{
							ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
							goto IL_541;
						}
						if (Convert.ToInt64(RobotImageLoader.RFID) <= 0L)
						{
							if (RobotImageLoader.RFID != "0")
							{
								ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Visible);
								goto IL_541;
							}
							ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
							goto IL_541;
						}
						IL_4FE:
						ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
						IL_541:
						this.SetMessageText("Grouped");
						this.FillImageList();
						this.CheckSelectAllGroup();
						IL_55C:
						this.IMGFrame.Visibility = Visibility.Collapsed;
						Grid.SetColumnSpan(this.thumbPreview, 2);
						Grid.SetColumn(this.thumbPreview, 0);
						this.thumbPreview.Margin = new Thickness(0.0);
					}
					catch (Exception serviceException)
					{
						string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
						ErrorHandler.ErrorHandler.LogFileWrite(message);
						while (false)
						{
						}
					}
					finally
					{
						MemoryManagement.FlushMemory();
					}
				}
				else
				{
					this.LoadImages();
					this.SetMessageText("PrintGrouped");
					this.flgGridWithoutPreview = true;
					do
					{
						this.continueCalculating = false;
						if (RobotImageLoader.GroupImages.Count <= 0)
						{
							goto IL_B90;
						}
						this.lstImages.Items.Clear();
					}
					while (3 == 0);
					this.btnprev.Visibility = Visibility.Collapsed;
					this.btnnext.Visibility = Visibility.Collapsed;
					ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Visible);
					using (List<LstMyItems>.Enumerator enumerator2 = RobotImageLoader.GroupImages.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							LstMyItems photoItem = enumerator2.Current;
							LstMyItems lstMyItems = (from t in RobotImageLoader.PrintImages
							where t.PhotoId == photoItem.PhotoId
							select t).FirstOrDefault<LstMyItems>();
							if (lstMyItems != null)
							{
								photoItem.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
							}
							else
							{
								photoItem.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
							}
							PhotoBusiness photoBusiness = new PhotoBusiness();
							if (photoBusiness.GetModeratePhotos((long)photoItem.PhotoId))
							{
								this.splockedImages.Visibility = Visibility.Collapsed;
								this.spaddtoalbumnunlockedImages.Visibility = Visibility.Visible;
								this.spunlockedImages.Visibility = Visibility.Visible;
								goto IL_734;
							}
							IL_7DC:
							photoItem.GridMainHeight = 140;
							photoItem.GridMainWidth = 170;
							photoItem.GridMainRowHeight1 = 90;
							if (6 != 0)
							{
								photoItem.GridMainRowHeight2 = 60;
								this.lstImages.Items.Add(photoItem);
								if (photoItem.PhotoId == RobotImageLoader.UniquePhotoId)
								{
									try
									{
										this.lstImages.SelectedItem = photoItem;
										ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
										listBoxItem.Focus();
										this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
									}
									catch (Exception serviceException)
									{
										string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
										ErrorHandler.ErrorHandler.LogFileWrite(message);
									}
								}
								continue;
							}
							IL_77D:
							if (!false)
							{
								photoItem.IsPassKeyVisible = Visibility.Visible;
								photoItem.BmpImageGroup = null;
								photoItem.FilePath = photoItem.HotFolderPath + "/Locked.png";
								photoItem.IsLocked = Visibility.Collapsed;
								photoItem.IsPassKeyVisible = Visibility.Visible;
								goto IL_7DC;
							}
							IL_734:
							if (RobotImageLoader.GroupImages.First<LstMyItems>().MediaType == 1)
							{
								this.unlockImage = new BitmapImage(new Uri(RobotImageLoader.GroupImages.First<LstMyItems>().BigThumbnailPath, UriKind.Absolute));
							}
							this.btnEdit.IsEnabled = false;
							goto IL_77D;
						}
					}
					if (this.vwGroup.Text == "View All")
					{
						if (this.lstImages != null && this.lstImages.SelectedItem == null)
						{
							if (false)
							{
								goto IL_191;
							}
							this.lstImages.SelectedItem = this.lstImages.Items[0];
							ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
							listBoxItem.Focus();
							this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
						}
					}
					this.txtMainImage.Text = Convert.ToString(RobotImageLoader.GroupImages.First<LstMyItems>().Name);
					do
					{
						this.CurrentBitmapImage = new BitmapImage(new Uri(RobotImageLoader.GroupImages.First<LstMyItems>().FilePath));
						this.CurrentBitmapImage.Freeze();
						this._currentImage = RobotImageLoader.GroupImages.First<LstMyItems>().Name;
						this._objBitmap = new BitmapImage();
						this._objBitmap = new BitmapImage(new Uri(RobotImageLoader.GroupImages.First<LstMyItems>().FilePath));
					}
					while (2 == 0);
					this.vwGroup.Text = "View All";
					this.grdSelectAll.Visibility = Visibility.Visible;
					this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
					this.ImgAddToGroup.ToolTip = "Remove from group";
					PhotoBusiness photoBusiness2 = new PhotoBusiness();
					long photoId = (long)RobotImageLoader.GroupImages.First<LstMyItems>().PhotoId;
					this.unlockImageId = photoId;
					if (photoBusiness2.GetModeratePhotos(photoId))
					{
						this.splockedImages.Visibility = Visibility.Collapsed;
						this.spaddtoalbumnunlockedImages.Visibility = Visibility.Visible;
						if (!true)
						{
							goto IL_236;
						}
						this.spunlockedImages.Visibility = Visibility.Visible;
						if (RobotImageLoader.GroupImages.First<LstMyItems>().MediaType == 1)
						{
							this.unlockImage = new BitmapImage(new Uri(RobotImageLoader.GroupImages.First<LstMyItems>().BigThumbnailPath, UriKind.Absolute));
						}
						this.btnEdit.IsEnabled = false;
					}
					else
					{
						this.splockedImages.Visibility = Visibility.Visible;
						this.spaddtoalbumnunlockedImages.Visibility = Visibility.Collapsed;
						this.spunlockedImages.Visibility = Visibility.Collapsed;
						if (RobotImageLoader.GroupImages.First<LstMyItems>().MediaType == 1)
						{
							this.unlockImage = new BitmapImage(new Uri(RobotImageLoader.GroupImages.First<LstMyItems>().BigThumbnailPath, UriKind.Absolute));
						}
						this.btnEdit.IsEnabled = true;
					}
					IL_B90:
					this.CheckForAllImgSelectToPrint();
					this.IMGFrame.Visibility = Visibility.Collapsed;
					Grid.SetColumnSpan(this.thumbPreview, 2);
					Grid.SetColumn(this.thumbPreview, 0);
					this.thumbPreview.Margin = new Thickness(0.0);
					this.FillImageList();
				}
			}
		}

		private void btnWithoutPreview9_Click(object sender, RoutedEventArgs e)
		{
			this.MediaStop();
			this.continueCalculating = false;
			this.scrollIndexWithoutPreview = 9;
			this.scrollIndexWithPreview = 9;
			RobotImageLoader.thumbSet = 9;
			RobotImageLoader.StartIndex = ((RobotImageLoader.robotImages.Count<LstMyItems>() > 0) ? RobotImageLoader.robotImages[0].PhotoId : 0);
			RobotImageLoader.Is9ImgViewActive = true;
			RobotImageLoader.IsPreview9or16active = true;
			RobotImageLoader.Is16ImgViewActive = false;
			RobotImageLoader.IsPreviewModeActive = false;
			this.imgwithPreview.Source = new BitmapImage(new Uri("/images/thumbnailview1.png", UriKind.Relative));
			this.imgwithoutPreview.Source = new BitmapImage(new Uri("images/16blocks_black.png", UriKind.Relative));
			this.imgwithoutPreview9.Source = new BitmapImage(new Uri("/images/9Blocks_red.png", UriKind.Relative));
			if (RobotImageLoader.robotImages != null && RobotImageLoader.robotImages.Count > 0)
			{
				RobotImageLoader.StartIndex = ((RobotImageLoader.robotImages.Count<LstMyItems>() > 0) ? RobotImageLoader.robotImages[0].PhotoId : 0);
				if (RobotImageLoader.GroupImages != null && RobotImageLoader.GroupImages.Count > 0)
				{
					RobotImageLoader.GroupImages.ForEach(delegate(LstMyItems t)
					{
						if (!false)
						{
							t.GridMainHeight = 190;
							if (!false)
							{
								if (false)
								{
									return;
								}
								t.GridMainWidth = 226;
							}
						}
						do
						{
							t.GridMainRowHeight1 = 140;
							int expr_2A = 50;
							if (4 != 0)
							{
								t.GridMainRowHeight2 = expr_2A;
							}
						}
						while (-1 == 0);
					});
				}
				if (RobotImageLoader.PrintImages != null && RobotImageLoader.PrintImages.Count > 0)
				{
					RobotImageLoader.PrintImages.ForEach(delegate(LstMyItems t)
					{
						if (!false)
						{
							t.GridMainHeight = 190;
							if (!false)
							{
								if (false)
								{
									return;
								}
								t.GridMainWidth = 226;
							}
						}
						do
						{
							t.GridMainRowHeight1 = 140;
							int expr_2A = 50;
							if (4 != 0)
							{
								t.GridMainRowHeight2 = expr_2A;
							}
						}
						while (-1 == 0);
					});
				}
				if (RobotImageLoader.SearchCriteria == "TimeWithQrcode")
				{
					this.searchDetails.PageSize = 9;
					RobotImageLoader.LoadImages(this.searchDetails);
				}
				else
				{
					RobotImageLoader.LoadImages();
				}
				if (this.vwGroup.Text == "View Group")
				{
					try
					{
						this.FillImageList();
						if (this.txtSelectImages.Text.Contains("Print Grouped") && this.txtSelectImages.Visibility == Visibility.Visible)
						{
							ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Visible);
							this.SetMessageText("EditPrintGroupedView");
							this.SPSelectAll.Visibility = Visibility.Hidden;
							this.lstImages.Items.Clear();
							if (!false)
							{
								this.btnprev.Visibility = Visibility.Collapsed;
							}
							this.btnnext.Visibility = Visibility.Collapsed;
							ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Visible);
							IEnumerable<LstMyItems> enumerable = from p in RobotImageLoader.PrintImages
							join g in RobotImageLoader.GroupImages on p.PhotoId equals g.PhotoId into ALLCOLUMNS
							from entry in ALLCOLUMNS
							select entry;
							IEnumerator<LstMyItems> enumerator = enumerable.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									LstMyItems current;
									do
									{
										current = enumerator.Current;
									}
									while (4 == 0);
									this.lstImages.Items.Add(current);
									if (current.PhotoId == RobotImageLoader.UniquePhotoId)
									{
										try
										{
											this.lstImages.SelectedItem = current;
											ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
											listBoxItem.Focus();
											this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
										}
										catch (Exception serviceException)
										{
											string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
											ErrorHandler.ErrorHandler.LogFileWrite(message);
										}
									}
								}
							}
							finally
							{
								if (enumerator != null)
								{
									do
									{
										enumerator.Dispose();
									}
									while (7 == 0);
								}
							}
						}
						else
						{
							this.LoadImages();
							if (string.Compare(RobotImageLoader.SearchCriteria, "Time", true) == 0 || string.Compare(RobotImageLoader.SearchCriteria, "QRCODE", true) == 0 || string.Compare(RobotImageLoader.SearchCriteria, "TimeWithQrcode", true) == 0)
							{
								ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
							}
							else if (Convert.ToInt64(RobotImageLoader.RFID) > 0L)
							{
								ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
							}
							else if (RobotImageLoader.RFID != "0")
							{
								ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Visible);
							}
							else
							{
								ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
							}
							this.SetMessageText("Grouped");
							this.CheckSelectAllGroup();
						}
						this.IMGFrame.Visibility = Visibility.Collapsed;
						Grid.SetColumnSpan(this.thumbPreview, 2);
						Grid.SetColumn(this.thumbPreview, 0);
						this.thumbPreview.Margin = new Thickness(0.0);
					}
					catch (Exception serviceException)
					{
						string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
						ErrorHandler.ErrorHandler.LogFileWrite(message);
					}
					finally
					{
						MemoryManagement.FlushMemory();
						while (8 == 0)
						{
						}
					}
				}
				else
				{
					this.LoadImages();
					this.IMGFrame.Visibility = Visibility.Collapsed;
					this.SetMessageText("PrintGrouped");
					this.flgGridWithoutPreview = true;
					long arg_A1A_0 = 0L;
					if (6 == 0)
					{
						goto IL_A1A;
					}
					this.continueCalculating = false;
					if (RobotImageLoader.GroupImages.Count <= 0)
					{
						goto IL_B24;
					}
					this.lstImages.Items.Clear();
					this.btnprev.Visibility = Visibility.Collapsed;
					this.btnnext.Visibility = Visibility.Collapsed;
					ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Visible);
					List<ModratePhotoInfo> source = new List<ModratePhotoInfo>();
					PhotoBusiness photoBusiness = new PhotoBusiness();
					source = photoBusiness.GetModeratePhotos();
					using (List<LstMyItems>.Enumerator enumerator2 = RobotImageLoader.GroupImages.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							LstMyItems photoItem = enumerator2.Current;
							LstMyItems lstMyItems = (from t in RobotImageLoader.PrintImages
							where t.PhotoId == photoItem.PhotoId
							select t).FirstOrDefault<LstMyItems>();
							bool flag = lstMyItems == null;
							IEnumerable<ModratePhotoInfo> enumerable2;
							while (true)
							{
								if (!flag)
								{
									photoItem.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
								}
								else
								{
									photoItem.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
								}
								enumerable2 = from x in source.AsEnumerable<ModratePhotoInfo>()
								where x.DG_Mod_Photo_ID == photoItem.PhotoId
								select x;
								if (enumerable2 == null)
								{
									goto IL_6EE;
								}
								if (!false)
								{
									goto Block_55;
								}
							}
							IL_6EF:
							int arg_6F0_0;
							if (arg_6F0_0 == 0)
							{
								this.splockedImages.Visibility = Visibility.Collapsed;
								this.spaddtoalbumnunlockedImages.Visibility = Visibility.Visible;
								this.spunlockedImages.Visibility = Visibility.Visible;
								if (RobotImageLoader.GroupImages.First<LstMyItems>().MediaType == 1)
								{
									this.unlockImage = new BitmapImage(new Uri(RobotImageLoader.GroupImages.First<LstMyItems>().BigThumbnailPath, UriKind.Absolute));
								}
								this.btnEdit.IsEnabled = false;
								photoItem.IsPassKeyVisible = Visibility.Visible;
								photoItem.BmpImageGroup = null;
								photoItem.FilePath = photoItem.HotFolderPath + "/Locked.png";
								photoItem.IsLocked = Visibility.Collapsed;
								photoItem.IsPassKeyVisible = Visibility.Visible;
							}
							this.lstImages.Items.Add(photoItem);
							int expr_7E4 = arg_6F0_0 = photoItem.PhotoId;
							if (true)
							{
								if (expr_7E4 == RobotImageLoader.UniquePhotoId)
								{
									try
									{
										this.lstImages.SelectedItem = photoItem;
										ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
										listBoxItem.Focus();
										this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
									}
									catch (Exception serviceException)
									{
										string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
										ErrorHandler.ErrorHandler.LogFileWrite(message);
									}
								}
								continue;
							}
							IL_6EC:
							goto IL_6EF;
							Block_55:
							arg_6F0_0 = ((enumerable2.Count<ModratePhotoInfo>() <= 0) ? 1 : 0);
							goto IL_6EC;
							IL_6EE:
							arg_6F0_0 = 1;
							goto IL_6EF;
						}
					}
					if (!(this.vwGroup.Text == "View All"))
					{
						goto IL_934;
					}
					bool arg_8CF_0;
					if (this.lstImages == null)
					{
						arg_8CF_0 = true;
						goto IL_8CE;
					}
					bool arg_8C9_0 = this.lstImages.SelectedItem == null;
					int arg_8C9_1 = 0;
					IL_8C9:
					arg_8CF_0 = ((arg_8C9_0 ? 1 : 0) == arg_8C9_1);
					IL_8CE:
					if (!arg_8CF_0)
					{
						this.lstImages.SelectedItem = this.lstImages.Items[0];
						ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
						listBoxItem.Focus();
						this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
					}
					IL_934:
					this.txtMainImage.Text = Convert.ToString(RobotImageLoader.GroupImages.First<LstMyItems>().Name);
					this.CurrentBitmapImage = new BitmapImage(new Uri(RobotImageLoader.GroupImages.First<LstMyItems>().FilePath));
					this.CurrentBitmapImage.Freeze();
					this._currentImage = RobotImageLoader.GroupImages.First<LstMyItems>().Name;
					this._objBitmap = new BitmapImage();
					this._objBitmap = new BitmapImage(new Uri(RobotImageLoader.GroupImages.First<LstMyItems>().FilePath));
					this.vwGroup.Text = "View All";
					this.grdSelectAll.Visibility = Visibility.Visible;
					this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
					this.ImgAddToGroup.ToolTip = "Remove from group";
					IL_A09:
					arg_A1A_0 = (long)RobotImageLoader.GroupImages.First<LstMyItems>().PhotoId;
					IL_A1A:
					long photoId = arg_A1A_0;
					this.unlockImageId = photoId;
					int expr_A28 = (arg_8C9_0 = photoBusiness.GetModeratePhotos(photoId)) ? 1 : 0;
					int expr_A2E = arg_8C9_1 = 0;
					if (expr_A2E != 0)
					{
						goto IL_8C9;
					}
					if (expr_A28 != expr_A2E)
					{
						this.splockedImages.Visibility = Visibility.Collapsed;
						this.spaddtoalbumnunlockedImages.Visibility = Visibility.Visible;
						this.spunlockedImages.Visibility = Visibility.Visible;
						if (3 == 0)
						{
							goto IL_A09;
						}
						if (RobotImageLoader.GroupImages.First<LstMyItems>().MediaType == 1)
						{
							this.unlockImage = new BitmapImage(new Uri(RobotImageLoader.GroupImages.First<LstMyItems>().BigThumbnailPath, UriKind.Absolute));
						}
						this.btnEdit.IsEnabled = false;
					}
					else
					{
						this.splockedImages.Visibility = Visibility.Visible;
						this.spaddtoalbumnunlockedImages.Visibility = Visibility.Collapsed;
						this.spunlockedImages.Visibility = Visibility.Collapsed;
						if (RobotImageLoader.GroupImages.First<LstMyItems>().MediaType == 1)
						{
							this.unlockImage = new BitmapImage(new Uri(RobotImageLoader.GroupImages.First<LstMyItems>().BigThumbnailPath, UriKind.Absolute));
						}
						this.btnEdit.IsEnabled = true;
					}
					IL_B24:
					this.CheckForAllImgSelectToPrint();
					Grid.SetColumnSpan(this.thumbPreview, 2);
					Grid.SetColumn(this.thumbPreview, 0);
					this.thumbPreview.Margin = new Thickness(0.0);
					this.FillImageList();
				}
			}
		}

		private void btnWithPreviewActive_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (RobotImageLoader.robotImages.Count > 0)
				{
					RobotImageLoader.IsPreview9or16active = false;
					if (this.scrollIndexWithoutPreview == 9)
					{
						ConfigBusiness configBusiness = new ConfigBusiness();
						ConfigurationInfo configurationData = configBusiness.GetConfigurationData(LoginUser.SubStoreId);
						if (configurationData != null)
						{
							this.scrollIndexWithoutPreview = Convert.ToInt32(configurationData.DG_PageCountGrid);
							this.scrollIndexWithPreview = this.scrollIndexWithoutPreview;
							RobotImageLoader.thumbSet = this.scrollIndexWithPreview;
						}
					}
					IEnumerator enumerator = ((IEnumerable)this.lstImages.Items).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							LstMyItems lstMyItems = (LstMyItems)enumerator.Current;
							lstMyItems.GridMainHeight = 140;
							lstMyItems.GridMainWidth = 170;
							lstMyItems.GridMainRowHeight1 = 90;
							lstMyItems.GridMainRowHeight2 = 60;
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (5 == 0 || disposable != null)
						{
							disposable.Dispose();
						}
					}
					if (RobotImageLoader.GroupImages != null && RobotImageLoader.GroupImages.Count > 0)
					{
						RobotImageLoader.GroupImages.ForEach(delegate(LstMyItems t)
						{
							if (!false)
							{
								t.GridMainHeight = 140;
								if (!false)
								{
									if (false)
									{
										return;
									}
									t.GridMainWidth = 170;
								}
							}
							do
							{
								t.GridMainRowHeight1 = 90;
								int expr_27 = 60;
								if (4 != 0)
								{
									t.GridMainRowHeight2 = expr_27;
								}
							}
							while (-1 == 0);
						});
					}
					if (RobotImageLoader.PrintImages != null && RobotImageLoader.PrintImages.Count > 0)
					{
						RobotImageLoader.PrintImages.ForEach(delegate(LstMyItems t)
						{
							if (!false)
							{
								t.GridMainHeight = 140;
								if (!false)
								{
									if (false)
									{
										return;
									}
									t.GridMainWidth = 170;
								}
							}
							do
							{
								t.GridMainRowHeight1 = 90;
								int expr_27 = 60;
								if (4 != 0)
								{
									t.GridMainRowHeight2 = expr_27;
								}
							}
							while (-1 == 0);
						});
					}
					if (RobotImageLoader.robotImages != null && RobotImageLoader.robotImages.Count > 0)
					{
						RobotImageLoader.robotImages.ForEach(delegate(LstMyItems t)
						{
							if (!false)
							{
								t.GridMainHeight = 140;
								if (!false)
								{
									if (false)
									{
										return;
									}
									t.GridMainWidth = 170;
								}
							}
							do
							{
								t.GridMainRowHeight1 = 90;
								int expr_27 = 60;
								if (4 != 0)
								{
									t.GridMainRowHeight2 = expr_27;
								}
							}
							while (-1 == 0);
						});
					}
					ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Visible);
					this.flgGridWithoutPreview = false;
					RobotImageLoader.IsPreviewModeActive = true;
					if (RobotImageLoader.robotImages.Count > 0)
					{
						this.IMGFrame.Visibility = Visibility.Visible;
					}
					else
					{
						this.IMGFrame.Visibility = Visibility.Collapsed;
					}
					Grid.SetColumnSpan(this.thumbPreview, 1);
					Grid.SetColumn(this.thumbPreview, 1);
					this.thumbPreview.Margin = new Thickness(0.0, 0.0, -77.5, 8.0);
					this.imgwithPreview.Source = new BitmapImage(new Uri("/images/thumbnailview1_active.png", UriKind.Relative));
					this.imgwithoutPreview.Source = new BitmapImage(new Uri("images/16blocks_black.png", UriKind.Relative));
					this.imgwithoutPreview9.Source = new BitmapImage(new Uri("/images/9Blocks_black.png", UriKind.Relative));
					if (this.lstImages.SelectedItem != null)
					{
						ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
						listBoxItem.Focus();
						this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
						LstMyItems lstMyItems2 = (LstMyItems)this.lstImages.SelectedItem;
						if (lstMyItems2.MediaType == 2 || lstMyItems2.MediaType == 3)
						{
							this.img.Visibility = Visibility.Hidden;
							this.vidoriginal.Visibility = Visibility.Visible;
							string fileName = lstMyItems2.FileName;
							if (!string.IsNullOrEmpty(fileName))
							{
								if (lstMyItems2.MediaType == 2)
								{
									using (FileStream fileStream = File.OpenRead(Path.Combine(lstMyItems2.HotFolderPath, "Videos", lstMyItems2.CreatedOn.ToString("yyyyMMdd"), lstMyItems2.FileName)))
									{
										SearchResult.vsMediaFileName = fileStream.Name;
									}
								}
								else
								{
									using (FileStream fileStream = File.OpenRead(Path.Combine(lstMyItems2.HotFolderPath, "ProcessedVideos", lstMyItems2.CreatedOn.ToString("yyyyMMdd"), lstMyItems2.FileName)))
									{
										SearchResult.vsMediaFileName = fileStream.Name;
									}
								}
							}
							base.Dispatcher.Invoke(new Action(delegate
							{
								this.MediaPlay();
							}), new object[0]);
							this.txtMainVideo.Text = lstMyItems2.Name;
						}
						else
						{
							this.img.Visibility = Visibility.Visible;
							this.vidoriginal.Visibility = Visibility.Hidden;
							this.MediaStop();
						}
						this.txtMainImage.Text = ((LstMyItems)this.lstImages.SelectedItem).Name;
						RobotImageLoader.PhotoId = ((LstMyItems)this.lstImages.SelectedItem).Name;
						RobotImageLoader.UniquePhotoId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
						this._currentImage = ((LstMyItems)this.lstImages.SelectedItem).Name;
						this._currentImageId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
						LstMyItems lstMyItems3 = (from t in RobotImageLoader.GroupImages
						where t.PhotoId == this._currentImageId
						select t).FirstOrDefault<LstMyItems>();
						if (lstMyItems3 != null)
						{
							this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
							this.btnImageAddToGroup.ToolTip = "Remove from group";
							this.btnImageAddToGroup.CommandParameter = "Remove from group";
						}
						else
						{
							this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-GROUP.png", UriKind.Relative));
							this.btnImageAddToGroup.ToolTip = "Add to group";
							this.btnImageAddToGroup.CommandParameter = "Add to group";
						}
						LstMyItems lstMyItems4 = (from t in RobotImageLoader.PrintImages
						where t.PhotoId == this._currentImageId
						select t).FirstOrDefault<LstMyItems>();
						if (lstMyItems4 != null)
						{
							this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
						}
						else
						{
							this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
						}
						int Photo_PKey = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
						this.unlockImageId = (long)Photo_PKey;
						IEnumerable<string> source = from x in RobotImageLoader.LstUnlocknames
						where x.Equals(Photo_PKey.ToString())
						select x;
						PhotoBusiness photoBusiness = new PhotoBusiness();
						if (photoBusiness.GetModeratePhotos((long)Photo_PKey) && source.Count<string>() == 0)
						{
							this.btnEdit.IsEnabled = false;
							this.splockedImages.Visibility = Visibility.Visible;
							this.spaddtoalbumnunlockedImages.Visibility = Visibility.Collapsed;
							this.spunlockedImages.Visibility = Visibility.Collapsed;
							this.mainFrame.Source = null;
							this.imgmain.Source = new BitmapImage(new Uri(LoginUser.DigiFolderPath + "/Locked.png"));
							this.CurrentBitmapImage = new BitmapImage(new Uri(LoginUser.DigiFolderPath + "/Locked.png"));
						}
						else
						{
							this.splockedImages.Visibility = Visibility.Collapsed;
							this.spaddtoalbumnunlockedImages.Visibility = Visibility.Visible;
							this.spunlockedImages.Visibility = Visibility.Visible;
							this.unlockImage = CommonUtility.GetImageFromPath(Convert.ToString(((LstMyItems)this.lstImages.SelectedItem).BigThumbnailPath));
							this.btnEdit.IsEnabled = true;
							this.imgmain.Source = CommonUtility.GetImageFromPath(Convert.ToString(((LstMyItems)this.lstImages.SelectedItem).BigThumbnailPath));
							if (((LstMyItems)this.lstImages.SelectedItem).FrameBrdr != null)
							{
								this.mainFrame.Source = new BitmapImage(new Uri(((LstMyItems)this.lstImages.SelectedItem).FrameBrdr));
							}
							else
							{
								this.mainFrame.Source = null;
							}
							this.CurrentBitmapImage = CommonUtility.GetImageFromPath(Convert.ToString(((LstMyItems)this.lstImages.SelectedItem).BigThumbnailPath));
						}
					}
					else if (this.vwGroup.Text == "View Group")
					{
						this.lstImages.SelectedItem = this.lstImages.Items[0];
						this.lstImages.Focus();
						ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
						listBoxItem.Focus();
					}
					else
					{
						this.lstImages.SelectedItem = RobotImageLoader.GroupImages.First<LstMyItems>();
						ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
						listBoxItem.Focus();
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
			}
		}

		private void btnAddToGroup_Click(object sender, RoutedEventArgs e)
		{
			Func<LstMyItems, bool> expr_06 = null;
			if (2 != 0)
			{
				Func<LstMyItems, bool> predicate = expr_06;
			}
			try
			{
				RobotImageLoader.curItem = null;
				System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
				System.Windows.Controls.Image image = (System.Windows.Controls.Image)button.Content;
				List<LstMyItems> list = RobotImageLoader.GroupImages.Where(delegate(LstMyItems t)
				{
					if (false)
					{
						goto IL_24;
					}
					int arg_1A_0 = t.PhotoId;
					bool expr_1A;
					do
					{
						IL_07:
						expr_1A = ((arg_1A_0 = ((arg_1A_0 == (int)((System.Windows.Controls.Button)sender).CommandParameter) ? 1 : 0)) != 0);
					}
					while (7 == 0 || 8 == 0);
					bool flag2 = expr_1A;
					IL_24:
					bool expr_43 = (arg_1A_0 = (flag2 ? 1 : 0)) != 0;
					if (!false)
					{
						return expr_43;
					}
					//goto IL_07;
				}).ToList<LstMyItems>();
				int arg_706_0;
				int arg_706_1;
				bool arg_778_0;
				if (list.Count == 0)
				{
					IEnumerable<LstMyItems> arg_BB_0 = RobotImageLoader.robotImages;
					Func<LstMyItems, bool> predicate = delegate(LstMyItems t)
					{
						if (false)
						{
							goto IL_24;
						}
						int arg_1A_0 = t.PhotoId;
						bool expr_1A;
						do
						{
							IL_07:
							expr_1A = ((arg_1A_0 = ((arg_1A_0 == (int)((System.Windows.Controls.Button)sender).CommandParameter) ? 1 : 0)) != 0);
						}
						while (7 == 0 || 8 == 0);
						bool flag2 = expr_1A;
						IL_24:
						bool expr_43 = (arg_1A_0 = (flag2 ? 1 : 0)) != 0;
						if (!false)
						{
							return expr_43;
						}
						//goto IL_07;
					};
					LstMyItems lstMyItems = arg_BB_0.Where(predicate).First<LstMyItems>();
					this.lstImages.SelectedItem = lstMyItems;
					ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
					listBoxItem.Focus();
					if (3 != 0)
					{
						LstMyItems lstMyItems2 = new LstMyItems();
						lstMyItems2 = lstMyItems;
						lstMyItems2.MediaType = lstMyItems.MediaType;
						lstMyItems2.VideoLength = lstMyItems.VideoLength;
						lstMyItems2.Name = lstMyItems.Name;
						lstMyItems2.IsPassKeyVisible = Visibility.Collapsed;
						lstMyItems2.PhotoId = lstMyItems.PhotoId;
						lstMyItems2.FileName = lstMyItems.FileName;
						lstMyItems2.CreatedOn = lstMyItems.CreatedOn;
						lstMyItems2.OnlineQRCode = lstMyItems.OnlineQRCode;
						lstMyItems2.IsLocked = Visibility.Visible;
						lstMyItems2.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
						lstMyItems2.FrameBrdr = ((LstMyItems)this.lstImages.SelectedItem).FrameBrdr;
						lstMyItems2.FilePath = lstMyItems.FilePath;
						RobotImageLoader.GroupImages.Add(lstMyItems2);
						if (RobotImageLoader.ViewGroupedImagesCount == null)
						{
							RobotImageLoader.ViewGroupedImagesCount = new List<string>();
						}
						RobotImageLoader.ViewGroupedImagesCount.Add(lstMyItems2.Name);
						int expr_21A = arg_706_0 = ((this._currentImage == (string)((System.Windows.Controls.Button)sender).Tag) ? 1 : 0);
						int expr_220 = arg_706_1 = 0;
						if (expr_220 == 0)
						{
							if (expr_21A != expr_220)
							{
								if (8 == 0)
								{
									goto IL_A2E;
								}
								this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
								this.btnImageAddToGroup.ToolTip = "Remove from group";
								if (-1 == 0)
								{
									//goto IL_83F;
								}
							}
							LstMyItems lstMyItems3 = RobotImageLoader.robotImages.Where(delegate(LstMyItems t)
							{
								if (false)
								{
									goto IL_24;
								}
								int arg_1A_0 = t.PhotoId;
								bool expr_1A;
								do
								{
									IL_07:
									expr_1A = ((arg_1A_0 = ((arg_1A_0 == (int)((System.Windows.Controls.Button)sender).CommandParameter) ? 1 : 0)) != 0);
								}
								while (7 == 0 || 8 == 0);
								bool flag2 = expr_1A;
								IL_24:
								bool expr_43 = (arg_1A_0 = (flag2 ? 1 : 0)) != 0;
								if (!false)
								{
									return expr_43;
								}
								//goto IL_07;
							}).First<LstMyItems>();
							if (lstMyItems3 != null)
							{
								lstMyItems3.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
							}
							image.Source = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
							//goto IL_909;
						}
						//goto IL_706;
					}
				}
				else
				{
					int sname = (int)button.CommandParameter;
					List<LstMyItems> list2 = (from t in RobotImageLoader.GroupImages
					where t.PhotoId == sname
					select t).ToList<LstMyItems>();
					if (list2.Count == 0)
					{
						goto IL_67B;
					}
					RobotImageLoader.GroupImages.Remove(list2.First<LstMyItems>());
					if (RobotImageLoader.ViewGroupedImagesCount != null && RobotImageLoader.ViewGroupedImagesCount.Count > 0)
					{
						RobotImageLoader.ViewGroupedImagesCount.Remove(list2.First<LstMyItems>().Name);
					}
					int arg_3A9_0;
					if (!(this.vwGroup.Text == "View All"))
					{
						arg_778_0 = ((arg_3A9_0 = ((!(this.pagename == "Saveback")) ? 1 : 0)) != 0);
						if (false)
						{
							//goto IL_778;
						}
					}
					else
					{
						arg_3A9_0 = 0;
					}
					if (arg_3A9_0 != 0)
					{
						LstMyItems lstMyItems = RobotImageLoader.robotImages.Where(delegate(LstMyItems t)
						{
							if (false)
							{
								goto IL_24;
							}
							int arg_1A_0 = t.PhotoId;
							bool expr_1A;
							do
							{
								IL_07:
								expr_1A = ((arg_1A_0 = ((arg_1A_0 == (int)((System.Windows.Controls.Button)sender).CommandParameter) ? 1 : 0)) != 0);
							}
							while (7 == 0 || 8 == 0);
							bool flag2 = expr_1A;
							IL_24:
							bool expr_43 = (arg_1A_0 = (flag2 ? 1 : 0)) != 0;
							if (!false)
							{
								return expr_43;
							}
							//goto IL_07;
						}).First<LstMyItems>();
						this.lstImages.SelectedItem = lstMyItems;
						ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
						listBoxItem.Focus();
						goto IL_67A;
					}
					int index = this.NextGroupSelectedIndex(this.lstImages.Items.IndexOf(list2.First<LstMyItems>()));
					this.lstImages.Items.Remove(list2.First<LstMyItems>());
					if (this.lstImages.Items.Count == 0)
					{
						this.pagename = "";
					}
					if (false)
					{
						//goto IL_7A4;
					}
					if (this.lstImages.Items.Count > 0)
					{
						this.lstImages.Focus();
						this.lstImages.SelectedItem = this.lstImages.Items[index];
						ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.Items[index]);
						listBoxItem.Focus();
						if (8 != 0)
						{
							goto IL_617;
						}
						//goto IL_83D;
					}
					else
					{
						this.continueCalculating = false;
						this.num = 0;
						RobotImageLoader.IsZeroSearchNeeded = true;
						RobotImageLoader.currentCount = 0;
						RobotImageLoader.RFID = "0";
						RobotImageLoader.SearchCriteria = "";
						RobotImageLoader.LoadImages();
						this.LoadImages();
						this.IMGFrame.Visibility = Visibility.Collapsed;
						Grid.SetColumnSpan(this.thumbPreview, 2);
						Grid.SetColumn(this.thumbPreview, 0);
						this.thumbPreview.Margin = new Thickness(0.0);
						this.vwGroup.Text = "View Group";
						this.flgGridWithoutPreview = true;
						if ((string.Compare(RobotImageLoader.SearchCriteria, "PhotoId", true) == 0 || string.IsNullOrEmpty(RobotImageLoader.SearchCriteria)) && RobotImageLoader.RFID == "0")
						{
							this.btnprev.Visibility = Visibility.Visible;
							this.btnnext.Visibility = Visibility.Visible;
							ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
							goto IL_616;
						}
					}
				}
				if (RobotImageLoader.RFID == "")
				{
					this.btnprev.Visibility = Visibility.Hidden;
					this.btnnext.Visibility = Visibility.Hidden;
					ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Visible);
				}
				else
				{
					this.btnprev.Visibility = Visibility.Visible;
					this.btnnext.Visibility = Visibility.Visible;
					ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
					this.vwGroup.Text = "View Group";
				}
				IL_616:
				IL_617:
				IL_67A:
				IL_67B:
				if (RobotImageLoader.robotImages == null || RobotImageLoader.robotImages.Count <= 0)
				{
					//goto IL_908;
				}
                //List<LstMyItems> list3 = (from t in RobotImageLoader.robotImages
                //where t.PhotoId == c__DisplayClass2.sname
                //select t).ToList<LstMyItems>();
                //if (list3.Count == 0)
                //{
                //    goto IL_907;
                //}
                //list3.First<LstMyItems>().BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                //arg_706_0 = this._currentImageId;
                ////arg_706_1 = c__DisplayClass2.sname;
                //IL_706:
                //if (arg_706_0 != arg_706_1)
                //{
                //    goto IL_8EF;
                //}
                //this.ImgAddToGroup.Source = null;
                //this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                //this.btnImageAddToGroup.ToolTip = "Add to group";
                //bool flag = list3.First<LstMyItems>().MediaType != 2 && list3.First<LstMyItems>().MediaType != 3;
                //arg_778_0 = flag;
                //IL_778:
                //if (arg_778_0)
                //{
                //    this.MediaStop();
                //    goto IL_8EE;
                //}
                //this.btnEdit.IsEnabled = false;
                //this.img.Visibility = Visibility.Hidden;
                //this.vidoriginal.Visibility = Visibility.Visible;
                //IL_7A4:
                //string fileName = list3.First<LstMyItems>().FileName;
                //if (string.IsNullOrEmpty(fileName))
                //{
                //    goto IL_8E2;
                //}
                //if (list3.First<LstMyItems>().MediaType == 2)
                //{
                //    FileStream fileStream = File.OpenRead(Path.Combine(list3.First<LstMyItems>().HotFolderPath, "Videos", list3.First<LstMyItems>().CreatedOn.ToString("yyyyMMdd"), fileName));
                //    try
                //    {
                //        SearchResult.vsMediaFileName = fileStream.Name;
                //    }
                //    finally
                //    {
                //        if (fileStream != null)
                //        {
                //            do
                //            {
                //                ((IDisposable)fileStream).Dispose();
                //            }
                //            while (2 == 0);
                //        }
                //    }
                //}
                //else
                //{
                //    using (FileStream fileStream = File.OpenRead(Path.Combine(list3.First<LstMyItems>().HotFolderPath, "ProcessedVideos", list3.First<LstMyItems>().CreatedOn.ToString("yyyyMMdd"), fileName)))
                //    {
                //        SearchResult.vsMediaFileName = fileStream.Name;
                //    }
                //}
                //IL_83D:
                //IL_83F:
                //base.Dispatcher.Invoke(new Action(delegate
                //{
                //    this.MediaPlay();
                //}), new object[0]);
                //this.txtMainVideo.Text = list3.First<LstMyItems>().Name;
                //IL_8E2:
                //IL_8EE:
                //IL_8EF:
                //image.Source = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                //IL_907:
                //IL_908:
                //IL_909:
				if (this.vwGroup.Text == "View Group")
				{
					this.SetMessageText("Grouped");
				}
				else
				{
					this.SetMessageText("PrintGrouped");
				}
				if (this.pagename == "Saveback" && RobotImageLoader.PrintImages.Count > 0 && this.SPSelectAll.Visibility == Visibility.Hidden)
				{
					this.SetMessageText("EditPrintGrouped");
					this.SPSelectAll.Visibility = Visibility.Hidden;
				}
				else
				{
					this.SPSelectAll.Visibility = Visibility.Visible;
				}
				if (this.lstImages.Items.Count > 0 && this.lstImages.SelectedIndex == -1)
				{
					this.lstImages.SelectedIndex = 0;
					ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.Items[0]);
					listBoxItem.Focus();
					this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
				}
				IL_A2E:
				if (this.vwGroup.Text == "View All")
				{
					this.CheckForAllImgSelectToPrint();
				}
				else
				{
					this.FillImageList();
					this.CheckSelectAllGroup();
				}
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
			finally
			{
				while (7 == 0)
				{
				}
			}
		}

		public void ViewGroup()
		{
			try
			{
				this.MediaStop();
				this.btnEdit.IsEnabled = false;
				long Photo_PKey = 0L;
				bool flag = false;
				if (false)
				{
					goto IL_75E;
				}
				int num = RobotImageLoader.GroupImages.Count;
				int num2 = RobotImageLoader.PrintImages.Count;
				this.SetMessageText("Grouped");
				int arg_7D_0 = (this.vwGroup.Text == "View Group") ? 1 : 0;
				IL_7D:
				bool flag2 = arg_7D_0 == 0 && !(this.pagename == "Saveback");
				IL_98:
				if (!flag2)
				{
					this.rdbtnAll.IsChecked = new bool?(true);
					this.continueCalculating = false;
					if (num > 0)
					{
						this.SetMessageText("Grouped");
						this.lstImages.Items.Clear();
						this.btnprev.Visibility = Visibility.Collapsed;
						this.btnnext.Visibility = Visibility.Collapsed;
						ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Visible);
						List<ModratePhotoInfo> source = new List<ModratePhotoInfo>();
						PhotoBusiness photoBusiness = new PhotoBusiness();
						source = photoBusiness.GetModeratePhotos();
						using (List<LstMyItems>.Enumerator enumerator = RobotImageLoader.GroupImages.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								LstMyItems photoItem = enumerator.Current;
								LstMyItems lstMyItems = (from t in RobotImageLoader.PrintImages
								where t.PhotoId == photoItem.PhotoId
								select t).FirstOrDefault<LstMyItems>();
								if (lstMyItems != null)
								{
									photoItem.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
								}
								else
								{
									photoItem.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
								}
								LstMyItems lstMyItems2;
								do
								{
									lstMyItems2 = (from xs in RobotImageLoader.NotPrintedImages
									where xs.FileName == photoItem.FileName
									select xs).FirstOrDefault<LstMyItems>();
								}
								while (3 == 0);
								if (lstMyItems2 == null && !flag)
								{
									flag = true;
								}
								IEnumerable<ModratePhotoInfo> enumerable = from x in source.AsEnumerable<ModratePhotoInfo>()
								where x.DG_Mod_Photo_ID == photoItem.PhotoId
								select x;
								bool arg_247_0;
								if (enumerable == null)
								{
									arg_247_0 = true;
									goto IL_246;
								}
								bool arg_32D_0;
								int expr_238 = (arg_32D_0 = (enumerable.Count<ModratePhotoInfo>() > 0)) ? 1 : 0;
								int arg_32D_1;
								int expr_23B = arg_32D_1 = 0;
								if (expr_23B == 0)
								{
									arg_247_0 = (expr_238 == expr_23B);
									goto IL_246;
								}
								IL_32D:
								if ((arg_32D_0 ? 1 : 0) != arg_32D_1)
								{
									try
									{
										this.lstImages.SelectedItem = photoItem;
										ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
										listBoxItem.Focus();
										this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
									}
									catch (Exception serviceException)
									{
										string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
										ErrorHandler.ErrorHandler.LogFileWrite(message);
									}
								}
								continue;
								IL_246:
								if (!arg_247_0)
								{
									this.splockedImages.Visibility = Visibility.Collapsed;
									this.spaddtoalbumnunlockedImages.Visibility = Visibility.Visible;
									this.spunlockedImages.Visibility = Visibility.Visible;
									this.unlockImage = new BitmapImage(new Uri(RobotImageLoader.GroupImages.First<LstMyItems>().BigThumbnailPath, UriKind.Absolute));
									this.btnEdit.IsEnabled = false;
									photoItem.IsPassKeyVisible = Visibility.Visible;
									photoItem.BmpImageGroup = null;
									photoItem.FilePath = photoItem.HotFolderPath + "/Locked.png";
									photoItem.IsLocked = Visibility.Collapsed;
									photoItem.IsPassKeyVisible = Visibility.Visible;
								}
								this.lstImages.Items.Add(photoItem);
								arg_32D_0 = (photoItem.PhotoId == RobotImageLoader.UniquePhotoId);
								arg_32D_1 = 0;
								goto IL_32D;
							}
						}
						this.SetMessageText("PrintGrouped");
						LstMyItems lstMyItems3 = RobotImageLoader.GroupImages.First<LstMyItems>();
						this.txtMainImage.Text = lstMyItems3.Name.ToString();
						this._currentImage = lstMyItems3.Name;
						this._objBitmap = new BitmapImage();
						this._objBitmap = this.CurrentBitmapImage;
						this.vwGroup.Text = "View All";
						this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
						this.ImgAddToGroup.ToolTip = "Remove from group";
						Photo_PKey = (long)lstMyItems3.PhotoId;
						this.unlockImageId = Photo_PKey;
						IEnumerable<ModratePhotoInfo> enumerable2 = from x in source.AsEnumerable<ModratePhotoInfo>()
						where (long)x.DG_Mod_Photo_ID == Photo_PKey
						select x;
						if (enumerable2 != null && enumerable2.Count<ModratePhotoInfo>() > 0)
						{
							this.splockedImages.Visibility = Visibility.Collapsed;
							this.spaddtoalbumnunlockedImages.Visibility = Visibility.Visible;
							this.spunlockedImages.Visibility = Visibility.Visible;
							this.unlockImage = new BitmapImage(new Uri(lstMyItems3.FilePath, UriKind.Absolute));
							this.btnEdit.IsEnabled = false;
						}
						if (flag)
						{
							MainWindow instance = MainWindow.Instance;
							if (instance.IsGoupped == "View All" && this.pagename == "Saveback")
							{
								this.vwGroup.Text = "View Group";
								using (List<LstMyItems>.Enumerator enumerator = RobotImageLoader.GroupImages.GetEnumerator())
								{
									while (enumerator.MoveNext())
									{
										LstMyItems itx = enumerator.Current;
										LstMyItems lstMyItems4 = (from xs in RobotImageLoader.PrintImages
										where xs.PhotoId == itx.PhotoId
										select xs).FirstOrDefault<LstMyItems>();
										if (lstMyItems4 == null)
										{
											RobotImageLoader.NotPrintedImages.Add(itx);
										}
									}
								}
								if (RobotImageLoader.NotPrintedImages.Count != 0)
								{
									using (List<LstMyItems>.Enumerator enumerator = RobotImageLoader.NotPrintedImages.GetEnumerator())
									{
										while (enumerator.MoveNext())
										{
											LstMyItems ity = enumerator.Current;
											this.lstImages.Items.Remove(ity);
											LstMyItems lstMyItems5 = (from tg in RobotImageLoader.GroupImages
											where tg.PhotoId == ity.PhotoId
											select tg).FirstOrDefault<LstMyItems>();
											lstMyItems5.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
										}
									}
								}
								this.SetMessageText("EditPrintGrouped");
								this.SPSelectAll.Visibility = Visibility.Hidden;
							}
							else
							{
								this.SPSelectAll.Visibility = Visibility.Visible;
							}
						}
					}
					else
					{
						if (this.lstImages.SelectedIndex > -1)
						{
							ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
							listBoxItem.Focus();
							this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
						}
						System.Windows.MessageBox.Show("No images are grouped!", "DigiPhoto i-Mix", MessageBoxButton.OK, MessageBoxImage.Asterisk);
					}
				}
				else
				{
					this.lstImages.Items.Clear();
					this.btnprev.Visibility = Visibility.Visible;
					this.btnnext.Visibility = Visibility.Visible;
					ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
					RobotImageLoader.GroupId = "";
					RobotImageLoader.SearchCriteria = "";
					RobotImageLoader.RFID = "0";
					this.continueCalculating = false;
					this.num = 0;
					bool expr_7DB = (arg_7D_0 = ((RobotImageLoader.RFID == "0") ? 1 : 0)) != 0;
					if (!false)
					{
						if (expr_7DB)
						{
							if (this.flgGridWithoutPreview)
							{
								RobotImageLoader.thumbSet = this.scrollIndexWithoutPreview;
							}
							else
							{
								RobotImageLoader.thumbSet = this.scrollIndexWithPreview;
							}
							RobotImageLoader.currentCount = 0;
							RobotImageLoader.IsZeroSearchNeeded = true;
							this.flgLoadNext = false;
							this.LoadNext();
							this.lstImages.SelectedIndex = 0;
						}
						LstMyItems lstMyItems6 = RobotImageLoader.robotImages.First<LstMyItems>();
						if (lstMyItems6.MediaType == 1)
						{
							this.CurrentBitmapImage = new BitmapImage(new Uri(lstMyItems6.BigThumbnailPath, UriKind.Absolute));
						}
						this.imgmain.Source = this.CurrentBitmapImage;
						this.txtMainImage.Text = lstMyItems6.Name.ToString();
						this._currentImage = lstMyItems6.Name;
						this._objBitmap = new BitmapImage();
						this._objBitmap = new BitmapImage(new Uri(lstMyItems6.FilePath));
						this.vwGroup.Text = "View Group";
						Photo_PKey = (long)lstMyItems6.PhotoId;
						this.unlockImageId = Photo_PKey;
						PhotoBusiness photoBusiness2 = new PhotoBusiness();
						if (!photoBusiness2.GetModeratePhotos(Photo_PKey))
						{
							this.splockedImages.Visibility = Visibility.Collapsed;
							this.spaddtoalbumnunlockedImages.Visibility = Visibility.Visible;
							this.spunlockedImages.Visibility = Visibility.Visible;
							this.btnEdit.IsEnabled = false;
						}
						else
						{
							if (2 != 0)
							{
								this.splockedImages.Visibility = Visibility.Visible;
							}
							this.spaddtoalbumnunlockedImages.Visibility = Visibility.Collapsed;
							this.spunlockedImages.Visibility = Visibility.Collapsed;
							this.unlockImage = new BitmapImage(new Uri(lstMyItems6.BigThumbnailPath, UriKind.Absolute));
							this.btnEdit.IsEnabled = true;
						}
						if (this.lstImages.Items.Count > 0)
						{
							ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.Items[0]);
							listBoxItem.Focus();
							this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
						}
						RobotImageLoader.ViewGroupedImagesCount = new List<string>();
						this.FillImageList();
						this.CheckSelectAllGroup();
						goto IL_A23;
					}
					goto IL_7D;
				}
				IL_75E:
				this.CheckForAllImgSelectToPrint();
				IL_A23:
				flag2 = (RobotImageLoader.curItem == null || this.lstImages.Items.Count <= 0);
				if (!flag2)
				{
					this.lstImages.SelectedItem = RobotImageLoader.curItem;
					this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
					((ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem)).Focus();
				}
				else
				{
					bool arg_ACD_0 = ((this.lstImages.Items.Count <= 0) ? (arg_7D_0 = 1) : (arg_7D_0 = ((this.lstImages.SelectedIndex != -1) ? 1 : 0))) != 0;
					if (6 == 0)
					{
						goto IL_7D;
					}
					flag2 = arg_ACD_0;
					if (!flag2)
					{
						this.lstImages.SelectedIndex = 0;
						ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.Items[0]);
						this.lstImages.SelectedItem = listBoxItem;
						this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
						listBoxItem.Focus();
					}
				}
				if (3 == 0)
				{
					goto IL_98;
				}
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
			finally
			{
				MemoryManagement.FlushMemory();
			}
		}

		public void btnViewGroup_Click(object sender, RoutedEventArgs e)
		{
			if (-1 != 0 && 8 != 0)
			{
				if (true)
				{
					if (7 == 0)
					{
						return;
					}
					this.MediaStop();
					this.pagename = "";
				}
				this.SPSelectAll.Visibility = Visibility.Visible;
			}
			this.ViewGroup();
		}

		private void btnImageAddToGroup_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Func<LstMyItems, bool> expr_13 = null;
				if (!false)
				{
					Func<LstMyItems, bool> predicate = expr_13;
				}
				//SearchResult.c__DisplayClassb6 c__DisplayClassb = new SearchResult.c__DisplayClassb6();
				UIElement expr_2B = this.btnEdit;
				bool expr_30 = false;
				if (true)
				{
					expr_2B.IsEnabled = expr_30;
				}
				System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
				//c__DisplayClassb.mainitem = new LstMyItems();
				if (this._currentImageId == 0)
				{
					this._currentImageId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
				}
				bool arg_AC_0 = !(this.vwGroup.Text == "View Group") || !(this.pagename != "Saveback");
				bool expr_7B3;
				while (true)
				{
					bool flag = arg_AC_0;
					if (!false)
					{
						if (!flag)
						{
							//c__DisplayClassb.mainitem = (from t in RobotImageLoader.robotImages
                            //where t.PhotoId == this._currentImageId
                            //select t).FirstOrDefault<LstMyItems>();
						}
						else
						{
							//c__DisplayClassb.mainitem = (from t in RobotImageLoader.GroupImages
                            //where t.PhotoId == this._currentImageId
                            //select t).FirstOrDefault<LstMyItems>();
						}
						Grid grid;
						if (button.CommandParameter.ToString() == "Remove from group")
						{
							this.btnImageAddToGroup.ToolTip = "Add to group";
							this.btnImageAddToGroup.CommandParameter = "Add to group";
							this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                            flag = false;// (c__DisplayClassb.mainitem == null);
							if (!flag)
							{
								if (6 == 0)
								{
									goto IL_5F8;
								}
                                //c__DisplayClassb.mainitem.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                                //this.lstImages.SelectedItem = c__DisplayClassb.mainitem;
								ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
								ContentPresenter contentPresenter = this.FindVisualChild<ContentPresenter>(listBoxItem);
								DataTemplate contentTemplate = contentPresenter.ContentTemplate;
								grid = (Grid)contentTemplate.FindName("grdMain", contentPresenter);
								((System.Windows.Controls.Image)((System.Windows.Controls.Button)((Grid)grid.FindName("Printbtns")).Children[2]).Content).Source = null;
								((System.Windows.Controls.Image)((System.Windows.Controls.Button)((Grid)grid.FindName("Printbtns")).Children[2]).Content).Source = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
								LstMyItems lstMyItems = (from t in RobotImageLoader.GroupImages
								where t.PhotoId == this._currentImageId
								select t).FirstOrDefault<LstMyItems>();
								if (false)
								{
									goto IL_748;
								}
								RobotImageLoader.GroupImages.Remove(lstMyItems);
								if (this.vwGroup.Text == "View All" || this.pagename == "Saveback")
								{
									this.lstImages.Items.Remove(lstMyItems);
								}
							}
							goto IL_493;
						}
						this.btnImageAddToGroup.ToolTip = "Remove from group";
						this.btnImageAddToGroup.CommandParameter = "Remove from group";
						if (false)
						{
							goto IL_41E;
						}
						this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                        //if (c__DisplayClassb.mainitem != null)
                        //{
                        //    IEnumerable<LstMyItems> arg_371_0 = RobotImageLoader.GroupImages;
                        //    Func<LstMyItems, bool> predicate = (LstMyItems gi) => gi.FileName == c__DisplayClassb.mainitem.FileName;
                        //    IEnumerable<LstMyItems> source = arg_371_0.Where(predicate);
                        //    if (source.Count<LstMyItems>() == 0)
                        //    {
                        //        RobotImageLoader.GroupImages.Add(c__DisplayClassb.mainitem);
                        //    }
                        //    if (false)
                        //    {
                        //        goto IL_6D7;
                        //    }
                        //    c__DisplayClassb.mainitem.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                        //    if (3 != 0)
                        //    {
                        //        this.lstImages.SelectedItem = c__DisplayClassb.mainitem;
                        //        ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
                        //        ContentPresenter contentPresenter = this.FindVisualChild<ContentPresenter>(listBoxItem);
                        //        DataTemplate contentTemplate = contentPresenter.ContentTemplate;
                        //        grid = (Grid)contentTemplate.FindName("grdMain", contentPresenter);
                        //        goto IL_41E;
                        //    }
                        //    goto IL_91D;
                        //}
						IL_492:
						goto IL_493;
						IL_41E:
						((System.Windows.Controls.Image)((System.Windows.Controls.Button)((Grid)grid.FindName("Printbtns")).Children[2]).Content).Source = null;
						((System.Windows.Controls.Image)((System.Windows.Controls.Button)((Grid)grid.FindName("Printbtns")).Children[2]).Content).Source = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
						goto IL_492;
						IL_7A3:
						expr_7B3 = (arg_AC_0 = (this.vwGroup.Text == "View Group"));
						if (4 != 0)
						{
							break;
						}
						continue;
						IL_493:
						if (this.vwGroup.Text == "View All")
						{
							this.CheckForAllImgSelectToPrint();
						}
						else
						{
							this.FillImageList();
							this.CheckSelectAllGroup();
						}
						if (this.vwGroup.Text == "View All" || this.pagename == "Saveback")
						{
							if (this.lstImages.Items.Count == 0)
							{
								if (this.pagename == "Saveback")
								{
									this.pagename = "";
								}
								this.continueCalculating = false;
								this.num = 0;
								RobotImageLoader.currentCount = 0;
								RobotImageLoader.IsZeroSearchNeeded = true;
								RobotImageLoader.RFID = "0";
								RobotImageLoader.LoadImages();
								this.LoadImages();
								this.IMGFrame.Visibility = Visibility.Collapsed;
								Grid.SetColumnSpan(this.thumbPreview, 2);
								Grid.SetColumn(this.thumbPreview, 0);
								this.thumbPreview.Margin = new Thickness(0.0);
								this.vwGroup.Text = "View Group";
								this.flgGridWithoutPreview = true;
								this.btnprev.Visibility = Visibility.Visible;
								this.btnnext.Visibility = Visibility.Visible;
								ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
								goto IL_5F8;
							}
							if (this.pagename == "Saveback")
							{
								this.lstImages.SelectedIndex = 0;
							}
							else
							{
								this.lstImages.SelectedItem = RobotImageLoader.GroupImages.First<LstMyItems>();
							}
							LstMyItems lstMyItems2 = (LstMyItems)this.lstImages.SelectedItem;
							if (lstMyItems2.IsLocked == Visibility.Collapsed && lstMyItems2.IsPassKeyVisible == Visibility.Visible)
							{
								this.imgmain.Source = CommonUtility.GetImageFromPath(lstMyItems2.FilePath);
								goto IL_6D8;
							}
							if (lstMyItems2.MediaType == 1)
							{
								this.imgmain.Source = CommonUtility.GetImageFromPath(Convert.ToString(lstMyItems2.BigThumbnailPath));
								goto IL_6D7;
							}
							goto IL_6D7;
						}
						IL_7A2:
						goto IL_7A3;
						IL_7A1:
						goto IL_7A2;
						IL_6D8:
						ListBoxItem listBoxItem2 = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
						if (this.lstImages.SelectedItem != null)
						{
							listBoxItem2.Focus();
							goto IL_7A1;
						}
						flag = (this.lstImages.Items.Count <= 0 || this.lstImages.SelectedIndex != -1);
						goto IL_748;
						IL_5F8:
						this.SPSelectAll.Visibility = Visibility.Visible;
						this.FillImageList();
						this.CheckSelectAllGroup();
						goto IL_7A2;
						IL_748:
						if (!flag)
						{
							this.lstImages.SelectedIndex = 0;
							ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.Items[0]);
							listBoxItem.Focus();
							this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
						}
						goto IL_7A1;
						IL_6D7:
						goto IL_6D8;
					}
					goto IL_93B;
				}
				if (expr_7B3)
				{
					this.SetMessageText("Grouped");
				}
				else
				{
					this.SetMessageText("PrintGrouped");
				}
				if (!(this.vwGroup.Text == "View Group") || !(this.pagename == "Saveback"))
				{
					goto IL_93B;
				}
				using (List<LstMyItems>.Enumerator enumerator = RobotImageLoader.GroupImages.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						LstMyItems lstMyItems3;
						LstMyItems itx;
						if (4 != 0)
						{
							//SearchResult.<>c__DisplayClassb6 CS$<>8__localsb7 = <>c__DisplayClassb;
							itx = enumerator.Current;
							lstMyItems3 = (from xs in RobotImageLoader.PrintImages
							where xs.PhotoId == itx.PhotoId
							select xs).FirstOrDefault<LstMyItems>();
						}
						if (lstMyItems3 == null)
						{
							RobotImageLoader.NotPrintedImages.Add(itx);
							if (false)
							{
								break;
							}
						}
					}
				}
				if (RobotImageLoader.NotPrintedImages.Count != 0)
				{
					foreach (LstMyItems current in RobotImageLoader.NotPrintedImages)
					{
						this.lstImages.Items.Remove(current);
					}
				}
				IL_91D:
				this.SetMessageText("EditPrintGrouped");
				this.SPSelectAll.Visibility = Visibility.Hidden;
				goto IL_949;
				IL_93B:
				this.SPSelectAll.Visibility = Visibility.Visible;
				IL_949:;
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
		}

		public void LoadWindow()
		{
			try
			{
				this.txbUserName.Text = LoginUser.UserName;
				this.txbStoreName.Text = LoginUser.StoreName;
				this.returntoHome = true;
				RobotImageLoader.GetConfigData();
				RobotImageLoader.LstUnlocknames = new List<string>();
				RobotImageLoader.IsPreviewModeActive = false;
				bool flag = !RobotImageLoader.Is9ImgViewActive;
				bool arg_5F_0 = flag;
				int arg_6F2_0;
				bool expr_21F;
				do
				{
					if (!arg_5F_0)
					{
						this.scrollIndexWithoutPreview = 9;
						this.scrollIndexWithPreview = 9;
					}
					RobotImageLoader.thumbSet = this.scrollIndexWithoutPreview;
					if (this.pagename != "Saveback")
					{
						if (this.serachType == 1)
						{
							this.searchDetails.NewRecord = 0;
							this.searchDetails.StartIndex = 0L;
							RobotImageLoader.Is16ImgViewActive = false;
							RobotImageLoader.Is9ImgViewActive = true;
							this.searchDetails.PageSize = 9;
						}
						this.serachType = 0;
						this.searchDetails.PageNumber = 1;
						this.SetMediaType();
						RobotImageLoader.LoadImages(this.searchDetails);
						flag = !(RobotImageLoader.SearchCriteria != "TimeWithQrcode");
						bool expr_11F = (arg_6F2_0 = (flag ? 1 : 0)) != 0;
						if (false)
						{
							goto IL_6F1;
						}
						if (!expr_11F)
						{
							this.btnprev.IsEnabled = true;
							this.btnnext.IsEnabled = true;
						}
						if (5 == 0)
						{
							goto IL_408;
						}
					}
					if (RobotImageLoader.robotImages != null)
					{
						this.count = RobotImageLoader.robotImages.Count;
					}
					if (RobotImageLoader.GroupImages == null)
					{
						RobotImageLoader.GroupImages = new List<LstMyItems>();
					}
					if (RobotImageLoader.PrintImages == null)
					{
						RobotImageLoader.PrintImages = new List<LstMyItems>();
					}
					if (this.scrollIndexWithoutPreview != 9)
					{
						goto IL_2A5;
					}
					if (RobotImageLoader.GroupImages != null && RobotImageLoader.GroupImages.Count > 0)
					{
						RobotImageLoader.GroupImages.ForEach(delegate(LstMyItems t)
						{
							if (!false)
							{
								t.GridMainHeight = 190;
								if (!false)
								{
									if (false)
									{
										return;
									}
									t.GridMainWidth = 226;
								}
							}
							do
							{
								t.GridMainRowHeight1 = 140;
								int expr_2A = 50;
								if (4 != 0)
								{
									t.GridMainRowHeight2 = expr_2A;
								}
							}
							while (-1 == 0);
						});
					}
					flag = (RobotImageLoader.PrintImages == null || RobotImageLoader.PrintImages.Count <= 0);
					expr_21F = (arg_5F_0 = flag);
				}
				while (-1 == 0);
				if (!expr_21F)
				{
					RobotImageLoader.PrintImages.ForEach(delegate(LstMyItems t)
					{
						if (!false)
						{
							t.GridMainHeight = 190;
							if (!false)
							{
								if (false)
								{
									return;
								}
								t.GridMainWidth = 226;
							}
						}
						do
						{
							t.GridMainRowHeight1 = 140;
							int expr_2A = 50;
							if (4 != 0)
							{
								t.GridMainRowHeight2 = expr_2A;
							}
						}
						while (-1 == 0);
					});
				}
				if (RobotImageLoader.robotImages == null || RobotImageLoader.robotImages.Count <= 0)
				{
					goto IL_29E;
				}
				IL_274:
				RobotImageLoader.robotImages.ForEach(delegate(LstMyItems t)
				{
					if (!false)
					{
						t.GridMainHeight = 190;
						if (!false)
						{
							if (false)
							{
								return;
							}
							t.GridMainWidth = 226;
						}
					}
					do
					{
						t.GridMainRowHeight1 = 140;
						int expr_2A = 50;
						if (4 != 0)
						{
							t.GridMainRowHeight2 = expr_2A;
						}
					}
					while (-1 == 0);
				});
				IL_29E:
				if (false)
				{
					goto IL_6F0;
				}
				IL_2A5:
                //this._sharpeff.Strength = 0.075000000000000011;
                //this._sharpeff.PixelWidth = 0.0015;
                //this._sharpeff.PixelHeight = 0.0015;
                //this.GrdSharpen.Effect = this._sharpeff;
				this.PreviewPhoto();
				flag = (!(RobotImageLoader.SearchCriteria == "Time") && !(RobotImageLoader.SearchCriteria == "QRCODE") && !(RobotImageLoader.SearchCriteria == "TimeWithQrcode"));
				IL_337:
				if (!flag)
				{
					this.btnprev.Visibility = Visibility.Visible;
					this.btnnext.Visibility = Visibility.Visible;
					ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
				}
				else if (RobotImageLoader.RFID == "")
				{
					this.btnprev.Visibility = Visibility.Hidden;
					this.btnnext.Visibility = Visibility.Hidden;
					ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Visible);
					if (false)
					{
						goto IL_274;
					}
				}
				else
				{
					this.btnprev.Visibility = Visibility.Visible;
					this.btnnext.Visibility = Visibility.Visible;
					ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
					this.vwGroup.Text = "View Group";
				}
				MainWindow instance;
				if (!(this.pagename == "MainGroup"))
				{
					if (this.pagename == "Saveback")
					{
						try
						{
							if (MainWindow.Instance != null)
							{
								instance = MainWindow.Instance;
							}
							else
							{
								instance = MainWindow.Instance;
								if (2 == 0)
								{
									goto IL_4BB;
								}
							}
							if (!(instance.IsGoupped == "View All"))
							{
								instance.IsGoupped = "View Group";
								this.vwGroup.Text = "View Group";
								this.lstImages.Items.Clear();
								this.continueCalculating = true;
								this.SetMessageText("Grouped");
								if (RobotImageLoader._objnewincrement != null && RobotImageLoader._objnewincrement.Count == 0)
								{
									RobotImageLoader._objnewincrement = RobotImageLoader.robotImages;
								}
								this.LoadImagestoList();
								goto IL_53E;
							}
							IL_4BB:
							this.ViewGroup();
							if (true)
							{
								goto IL_54E;
							}
							IL_53E:
							this.FillImageList();
							this.CheckSelectAllGroup();
							IL_54E:;
						}
						catch (Exception serviceException)
						{
							string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
							ErrorHandler.ErrorHandler.LogFileWrite(message);
						}
						goto IL_6A5;
					}
					if (this.pagename == "Placeback")
					{
						try
						{
							if (RobotImageLoader.robotImages.Count == 0)
							{
								RobotImageLoader.LoadImages();
							}
							if (RobotImageLoader.robotImages.Count != 0)
							{
								bool flag2 = false;
								while (true)
								{
									IL_668:
									flag = !flag2;
									while (flag)
									{
										if (6 != 0)
										{
											LstMyItems lstMyItems = new LstMyItems();
											lstMyItems = RobotImageLoader.robotImages.Where(delegate(LstMyItems xb)
											{
												bool result;
												do
												{
													if (true && !false)
													{
														result = (xb.PhotoId == this.Savebackpid.ToInt32(false));
													}
													while (false)
													{
													}
												}
												while (8 == 0);
												return result;
											}).FirstOrDefault<LstMyItems>();
											if (lstMyItems != null)
											{
												goto Block_50;
											}
											if (RobotImageLoader.robotImages.Count != 0)
											{
												RobotImageLoader.LoadImages();
												goto IL_668;
											}
											break;
										}
									}
									goto IL_675;
								}
								Block_50:
								this.continueCalculating = true;
								if (this.lstImages.Items.Count > 0)
								{
									this.lstImages.Items.Clear();
								}
								this.LoadImagestoList();
								IL_675:
								this.SetMessageText("Grouped");
							}
						}
						catch (Exception serviceException)
						{
							string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
							ErrorHandler.ErrorHandler.LogFileWrite(message);
						}
						goto IL_6A5;
					}
					this.LoadImages();
					goto IL_6A5;
				}
				IL_408:
				if (MainWindow.Instance != null)
				{
					instance = MainWindow.Instance;
				}
				else
				{
					instance = MainWindow.Instance;
				}
				flag = !(instance.IsGoupped == "View Group");
				if (!flag)
				{
					this.vwGroup.Text = "View Group";
					if (8 == 0)
					{
						goto IL_337;
					}
				}
				this.ViewGroup();
				IL_6A5:
				if (this.pagename == "Placeback")
				{
					this.CheckForAllImgSelectToPrint();
					goto IL_708;
				}
				if (this.pagename != "MainGroup")
				{
					arg_6F2_0 = ((!(this.pagename != "Saveback")) ? 1 : 0);
					goto IL_6F1;
				}
				IL_6F0:
				arg_6F2_0 = 1;
				IL_6F1:
				if (arg_6F2_0 == 0)
				{
					this.FillImageList();
					this.CheckSelectAllGroup();
				}
				IL_708:;
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
			finally
			{
				MemoryManagement.FlushMemory();
			}
			this.IMGFrame.Visibility = Visibility.Collapsed;
			Grid.SetColumnSpan(this.thumbPreview, 2);
			Grid.SetColumn(this.thumbPreview, 0);
			this.thumbPreview.Margin = new Thickness(0.0);
			if (RobotImageLoader.robotImages != null)
			{
				if (RobotImageLoader.Is16ImgViewActive && !RobotImageLoader.Is9ImgViewActive)
				{
					this.imgwithPreview.Source = new BitmapImage(new Uri("/images/thumbnailview1.png", UriKind.Relative));
					this.imgwithoutPreview.Source = new BitmapImage(new Uri("images/16blocks_red.png", UriKind.Relative));
					this.imgwithoutPreview9.Source = new BitmapImage(new Uri("/images/9Blocks_black.png", UriKind.Relative));
					this.ImageSize(16);
				}
				else if (!RobotImageLoader.Is16ImgViewActive && RobotImageLoader.Is9ImgViewActive)
				{
					this.imgwithPreview.Source = new BitmapImage(new Uri("/images/thumbnailview1.png", UriKind.Relative));
					this.imgwithoutPreview.Source = new BitmapImage(new Uri("images/16blocks_black.png", UriKind.Relative));
					this.imgwithoutPreview9.Source = new BitmapImage(new Uri("/images/9Blocks_red.png", UriKind.Relative));
					this.ImageSize(9);
				}
				else
				{
					this.imgwithPreview.Source = new BitmapImage(new Uri("/images/thumbnailview1.png", UriKind.Relative));
					this.imgwithoutPreview.Source = new BitmapImage(new Uri("images/16blocks_black.png", UriKind.Relative));
					this.imgwithoutPreview9.Source = new BitmapImage(new Uri("/images/9Blocks_black.png", UriKind.Relative));
				}
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			if (-1 != 0)
			{
				try
				{
					if (5 != 0)
					{
						ConfigBusiness configBusiness = new ConfigBusiness();
						this.IsEnableGrouping = Convert.ToBoolean(configBusiness.GetConfigEnableGroup(LoginUser.SubStoreId));
						bool arg_2B_0 = this.IsEnableGrouping;
						bool expr_2B;
						do
						{
							expr_2B = (arg_2B_0 = !arg_2B_0);
						}
						while (false);
						bool flag = expr_2B;
						if (!false)
						{
							if (!flag)
							{
								this.tbcleargroup.Text = "Group";
							}
						}
					}
				}
				catch (Exception serviceException)
				{
					string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
					do
					{
						ErrorHandler.ErrorHandler.LogFileWrite(message);
					}
					while (2 == 0);
				}
			}
		}

		public void CompileEffectChanged(VisualBrush compiledBitmapImage, int ProductType)
		{
			try
			{
				try
				{
					this.GetMktImgInfo();
					//ClientView clientView = null;
                    //using (IEnumerator enumerator = System.Windows.Application.Current.Windows.GetEnumerator())
                    //{
                    //    if (true)
                    //    {
                    //        goto IL_5E;
                    //    }
                    //    IL_52:
                    //    if (!true)
                    //    {
                    //        goto IL_6E;
                    //    }
                    //    Window window;
                    //    //clientView = (ClientView)window;
                    //    IL_5D:
                    //    IL_5E:
                    //    bool flag = enumerator.MoveNext();
                    //    bool arg_4F_0;
                    //    bool expr_67 = arg_4F_0 = flag;
                    //    if (true)
                    //    {
                    //        if (!expr_67)
                    //        {
                    //            goto IL_6E;
                    //        }
                    //        window = (Window)enumerator.Current;
                    //        flag = !(window.Title == "ClientView");
                    //        arg_4F_0 = flag;
                    //    }
                    //    if (!arg_4F_0)
                    //    {
                    //        goto IL_52;
                    //    }
                    //    goto IL_5D;
                    //    IL_6E:;
                    //}
                    //if (clientView == null)
                    //{
                    //    //clientView = new ClientView();
                    //    clientView.WindowStartupLocation = WindowStartupLocation.Manual;
                    //}
                    //clientView.imgNext.Visibility = Visibility.Collapsed;
                    //clientView.imgNext.Source = null;
					int expr_1CA;
                    //do
                    //{
                    //    clientView.txtMainImage.Visibility = Visibility.Collapsed;
                    //    clientView.stkPrint.Visibility = Visibility.Collapsed;
                    //    clientView.btnMinimize.Visibility = Visibility.Collapsed;
                    //    clientView.stkPrevNext.Visibility = Visibility.Collapsed;
                    //    clientView.testR.Visibility = Visibility.Visible;
                    //    clientView.GroupView = false;
                    //    clientView.DefaultView = false;
                    //    bool arg_125_0 = compiledBitmapImage == null;
                    //    while (arg_125_0)
                    //    {
                    //        clientView.DefaultView = true;
                    //        if (this.MktImgPath == "")
                    //        {
                    //            goto IL_1DA;
                    //        }
                    //        expr_1CA = ((arg_125_0 = (this.mktImgTime != 0)) ? 1 : 0);
                    //        if (!false)
                    //        {
                    //            goto Block_10;
                    //        }
                    //    }
                    //    clientView.testR.Fill = null;
                    //    compiledBitmapImage.Stretch = Stretch.Uniform;
                    //    if (8 == 0)
                    //    {
                    //        goto IL_1AB;
                    //    }
                    //}
                    //while (false);
                    //clientView.imgDefault.Visibility = Visibility.Collapsed;
                    //clientView.instructionVideo.Visibility = Visibility.Collapsed;
                    //clientView.instructionVideo.Pause();
                    //clientView.testR.Fill = compiledBitmapImage;
                    //if (clientView.mPreviewControl.m_pPreview != null)
                    //{
                    //    clientView.mPreviewControl.m_pPreview.PreviewEnable("", 1, 1);
                    //}
					IL_1AB:
					goto IL_21C;
					Block_10:
					bool arg_1DC_0 = expr_1CA == 0;
					goto IL_1DB;
					IL_1DA:
					arg_1DC_0 = true;
                IL_1DB:
                //if (!arg_1DC_0)
                //{
                //    clientView.instructionVideo.Visibility = Visibility.Visible;
                //    clientView.instructionVideo.Play();
                //}
                //else
                //{
                //    clientView.imgDefault.Visibility = Visibility.Visible;
                //}
                //clientView.testR.Fill = null;
                IL_21C:
                    bool arg_22B_0 = false;//clientView.instructionVideo.Visibility == Visibility.Visible;
					bool expr_22F;
					do
					{
						bool flag = !arg_22B_0;
						expr_22F = (arg_22B_0 = flag);
					}
					while (4 == 0);
                    //if (!expr_22F)
                    //{
                    //    clientView.instructionVideo.Play();
                    //}
                    //else
                    //{
                    //    clientView.instructionVideo.Pause();
                    //}
					Screen[] allScreens = Screen.AllScreens;
					if (allScreens.Length > 1)
					{
						if (allScreens[0].Primary)
						{
							Screen screen = Screen.AllScreens[1];
							Rectangle workingArea = screen.WorkingArea;
                            //clientView.Top = (double)workingArea.Top;
                            //clientView.Left = (double)workingArea.Left;
                            //clientView.Show();
						}
						else
						{
							Rectangle workingArea = allScreens[0].WorkingArea;
                            //clientView.Top = (double)workingArea.Top;
                            //clientView.Left = (double)workingArea.Left;
                            //clientView.Show();
						}
					}
					else
					{
						//clientView.Show();
					}
				}
				catch (Exception serviceException)
				{
					string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
					ErrorHandler.ErrorHandler.LogFileWrite(message);
				}
				if (!false)
				{
				}
			}
			finally
			{
			}
		}

		private void ImageSize(int size)
		{
			bool flag;
			if (size != 16)
			{
				bool arg_132_0 = RobotImageLoader.GroupImages == null || RobotImageLoader.GroupImages.Count <= 0;
				bool expr_1BE;
				while (true)
				{
					flag = arg_132_0;
					if (!flag)
					{
						RobotImageLoader.GroupImages.ForEach(delegate(LstMyItems t)
						{
							if (!false)
							{
								t.GridMainHeight = 190;
								if (!false)
								{
									if (false)
									{
										return;
									}
									t.GridMainWidth = 226;
								}
							}
							do
							{
								t.GridMainRowHeight1 = 140;
								int expr_2A = 50;
								if (4 != 0)
								{
									t.GridMainRowHeight2 = expr_2A;
								}
							}
							while (-1 == 0);
						});
					}
					bool arg_17E_0;
					if (RobotImageLoader.PrintImages == null)
					{
						arg_17E_0 = true;
						goto IL_17D;
					}
					if (true)
					{
						arg_17E_0 = (RobotImageLoader.PrintImages.Count <= 0);
						goto IL_17D;
					}
					IL_17F:
					if (!flag)
					{
						RobotImageLoader.PrintImages.ForEach(delegate(LstMyItems t)
						{
							if (!false)
							{
								t.GridMainHeight = 190;
								if (!false)
								{
									if (false)
									{
										return;
									}
									t.GridMainWidth = 226;
								}
							}
							do
							{
								t.GridMainRowHeight1 = 140;
								int expr_2A = 50;
								if (4 != 0)
								{
									t.GridMainRowHeight2 = expr_2A;
								}
							}
							while (-1 == 0);
						});
					}
					if (RobotImageLoader.robotImages == null)
					{
						goto IL_1CB;
					}
					expr_1BE = (arg_132_0 = (RobotImageLoader.robotImages.Count > 0));
					if (5 != 0)
					{
						break;
					}
					continue;
					IL_17D:
					flag = arg_17E_0;
					goto IL_17F;
				}
				bool arg_1CD_0 = !expr_1BE;
				goto IL_1CC;
				IL_1CB:
				arg_1CD_0 = true;
				IL_1CC:
				if (!arg_1CD_0)
				{
					if (false)
					{
						goto IL_71;
					}
					if (-1 == 0)
					{
						goto IL_27;
					}
					RobotImageLoader.robotImages.ForEach(delegate(LstMyItems t)
					{
						if (!false)
						{
							t.GridMainHeight = 190;
							if (!false)
							{
								if (false)
								{
									return;
								}
								t.GridMainWidth = 226;
							}
						}
						do
						{
							t.GridMainRowHeight1 = 140;
							int expr_2A = 50;
							if (4 != 0)
							{
								t.GridMainRowHeight2 = expr_2A;
							}
						}
						while (-1 == 0);
					});
				}
				return;
			}
			if (false)
			{
				goto IL_97;
			}
			bool arg_225_0;
			if (RobotImageLoader.GroupImages == null)
			{
				arg_225_0 = true;
				goto IL_3A;
			}
			IL_27:
			int arg_32_0 = RobotImageLoader.GroupImages.Count;
			IL_31:
			bool arg_35_0 = arg_32_0 > 0;
			IL_34:
			arg_225_0 = !arg_35_0;
			IL_3A:
			if (!arg_225_0)
			{
				RobotImageLoader.GroupImages.ForEach(delegate(LstMyItems t)
				{
					if (!false)
					{
						t.GridMainHeight = 140;
						if (!false)
						{
							if (false)
							{
								return;
							}
							t.GridMainWidth = 170;
						}
					}
					do
					{
						t.GridMainRowHeight1 = 90;
						int expr_27 = 60;
						if (4 != 0)
						{
							t.GridMainRowHeight2 = expr_27;
						}
					}
					while (-1 == 0);
				});
			}
			IL_71:
			flag = (RobotImageLoader.PrintImages == null || RobotImageLoader.PrintImages.Count <= 0);
			bool expr_91 = arg_35_0 = flag;
			if (false)
			{
				goto IL_34;
			}
			if (expr_91)
			{
				goto IL_C1;
			}
			IL_97:
			RobotImageLoader.PrintImages.ForEach(delegate(LstMyItems t)
			{
				if (!false)
				{
					t.GridMainHeight = 140;
					if (!false)
					{
						if (false)
						{
							return;
						}
						t.GridMainWidth = 170;
					}
				}
				do
				{
					t.GridMainRowHeight1 = 90;
					int expr_27 = 60;
					if (4 != 0)
					{
						t.GridMainRowHeight2 = expr_27;
					}
				}
				while (-1 == 0);
			});
			IL_C1:
			bool arg_E2_0;
			if (RobotImageLoader.robotImages != null)
			{
				int expr_CD = arg_32_0 = RobotImageLoader.robotImages.Count;
				if (2 == 0)
				{
					goto IL_31;
				}
				arg_E2_0 = (expr_CD <= 0);
			}
			else
			{
				arg_E2_0 = true;
			}
			if (!arg_E2_0)
			{
				RobotImageLoader.robotImages.ForEach(delegate(LstMyItems t)
				{
					if (!false)
					{
						t.GridMainHeight = 140;
						if (!false)
						{
							if (false)
							{
								return;
							}
							t.GridMainWidth = 170;
						}
					}
					do
					{
						t.GridMainRowHeight1 = 90;
						int expr_27 = 60;
						if (4 != 0)
						{
							t.GridMainRowHeight2 = expr_27;
						}
					}
					while (-1 == 0);
				});
			}
		}

		public void PreviewPhoto()
		{
			try
			{
				while (true)
				{
					bool? expr_162 = this.btnchkpreview.IsChecked;
					bool? flag;
					if (3 != 0)
					{
						flag = expr_162;
					}
					if (flag.Value)
					{
						goto IL_B6;
					}
					if (RobotImageLoader.GroupImages.Count != 0)
					{
						break;
					}
					if (!false)
					{
						goto Block_4;
					}
				}
				VisualBrush compiledBitmapImage;
				if (this.IMGFrame.Visibility == Visibility.Visible)
				{
					compiledBitmapImage = new VisualBrush(this.ContentContainer);
					this.CompileEffectChanged(compiledBitmapImage, -1);
				}
				else
				{
					compiledBitmapImage = new VisualBrush(this.ContentContainer);
					this.CompileEffectChanged(compiledBitmapImage, -1);
				}
				goto IL_B0;
				Block_4:
				compiledBitmapImage = new VisualBrush(this.ContentContainer);
				this.CompileEffectChanged(compiledBitmapImage, -1);
				IL_B0:
				goto IL_159;
				IL_B6:
				Visual visual;
				if (this.vidoriginal.Visibility == Visibility.Visible)
				{
					if (false)
					{
						goto IL_127;
					}
					visual = this.vidoriginal;
				}
				else
				{
					visual = this.img;
				}
				if (RobotImageLoader.GroupImages.Count != 0)
				{
					if (this.IMGFrame.Visibility == Visibility.Visible)
					{
						if (6 != 0)
						{
							compiledBitmapImage = new VisualBrush(visual);
							this.CompileEffectChanged(compiledBitmapImage, -1);
							this.continueCalculating = false;
						}
					}
					else
					{
						compiledBitmapImage = new VisualBrush(visual);
						this.CompileEffectChanged(compiledBitmapImage, -1);
						this.continueCalculating = false;
					}
				}
				else
				{
					compiledBitmapImage = new VisualBrush(visual);
					this.CompileEffectChanged(compiledBitmapImage, -1);
				}
				IL_127:
				IL_159:;
			}
			catch (Exception ex)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(ex);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
				System.Windows.MessageBox.Show(ex.Message);
			}
		}

		private void RotateThumbPreview()
		{
			bool expr_0C = !this.isSingleScreenPreview;
			bool flag;
			if (true)
			{
				flag = expr_0C;
			}
			if (!flag)
			{
				//this.clientWin.FilpFrom = 1;
				bool? isChecked = this.btnchkthumbpreview.IsChecked;
				TransformGroup transformGroup;
				if (!false)
				{
					flag = !(isChecked == true);
					if (!flag)
					{
						LstMyItems selectedItem = (LstMyItems)this.lstImages.SelectedItem;
						if (!false)
						{
							LstMyItems lstMyItems = (from o in RobotImageLoader.GroupImages
							orderby o.PhotoId descending
							where o.PhotoId == selectedItem.PhotoId
							select o).FirstOrDefault<LstMyItems>();
							flag = (lstMyItems != null);
							if (8 != 0)
							{
								if (flag)
								{
									goto IL_EB;
								}
								IL_DA:
								selectedItem = RobotImageLoader.GroupImages.FirstOrDefault<LstMyItems>();
								IL_EB:
								if (false)
								{
									goto IL_DA;
								}
								if (8 != 0)
								{
									flag = (selectedItem == null);
									if (!flag)
									{
										if (6 != 0)
										{
											this.txtMainImage.Text = selectedItem.Name;
											this.lstImages.SelectedItem = selectedItem;
											goto IL_12A;
										}
										goto IL_133;
									}
								}
								if (2 != 0)
								{
								}
							}
							IL_12A:
							IL_133:
							this.AngleValue += 720;
							this.AngleValue %= 360;
							transformGroup = new TransformGroup();
							goto IL_15D;
						}
					}
					else
					{
						transformGroup = new TransformGroup();
					}
					transformGroup.Children.Add(new RotateTransform(0.0));
					this.ContentContainer.LayoutTransform = transformGroup;
					goto IL_1C9;
				}
				IL_15D:
				transformGroup.Children.Add(new RotateTransform((double)this.AngleValue));
				this.row0.MinHeight = 31.0;
				this.ContentContainer.LayoutTransform = transformGroup;
				IL_1C9:;
			}
		}

		private void FlipPreview()
		{
			bool? isChecked = this.btnchkpreview.IsChecked;
			if (isChecked == true)
			{
				if (this.IMGFrame.Visibility == Visibility.Visible)
				{
					if (false)
					{
						goto IL_392;
					}
					AuditLog.AddUserLog(LoginUser.UserId, 1, "Show Preview of " + ((LstMyItems)this.lstImages.SelectedItem).Name.ToString() + " image.", ((LstMyItems)this.lstImages.SelectedItem).PhotoId);
				}
			}
			this.PreviewPhoto();
            //if (this.clientWin == null)
            //{
            //    foreach (Window window in System.Windows.Application.Current.Windows)
            //    {
            //        if (window.Title == "ClientView")
            //        {
            //            this.clientWin = (ClientView)window;
            //            break;
            //        }
            //    }
            //}
			if (!this.isSingleScreenPreview)
			{
				return;
			}
			//this.clientWin.FilpFrom = 1;
			isChecked = this.btnchkpreview.IsChecked;
			TransformGroup transformGroup;
			if (!(isChecked == true))
			{
                //this.clientWin.btnPrev.Visibility = Visibility.Collapsed;
                //this.clientWin.btnNext.Visibility = Visibility.Collapsed;
                //this.clientWin.btnMinimize.Visibility = Visibility.Collapsed;
                //this.clientWin.stkPrint.Visibility = Visibility.Collapsed;
				transformGroup = new TransformGroup();
				transformGroup.Children.Add(new RotateTransform(0.0));
				this.ContentContainer.RenderTransform = transformGroup;
                //if (this.clientWin != null)
                //{
                //    this.clientWin.img12.RenderTransform = transformGroup;
                //}
				return;
			}
			IL_191:
            //this.clientWin.imgNext.Visibility = Visibility.Visible;
            //this.clientWin.testR.Fill = null;
            //this.clientWin.testR.Visibility = Visibility.Collapsed;
            //this.clientWin.stkPrevNext.Visibility = Visibility.Visible;
            //this.clientWin.stkPrint.Visibility = Visibility.Visible;
            //this.clientWin.btnMinimize.Visibility = Visibility.Visible;
            //this.clientWin.mPreviewControl.SetControlledObject(this.gdMediaPlayer);
			LstMyItems selectedItem = (LstMyItems)this.lstImages.SelectedItem;
			LstMyItems lstMyItems = (from o in RobotImageLoader.GroupImages
			orderby o.PhotoId descending
			where o.PhotoId == selectedItem.PhotoId
			select o).FirstOrDefault<LstMyItems>();
			if (lstMyItems == null)
			{
				selectedItem = RobotImageLoader.GroupImages.FirstOrDefault<LstMyItems>();
			}
			if (selectedItem != null)
			{
				//this.clientWin.LoadImage(selectedItem);
				if ((from o in RobotImageLoader.PrintImages
				where o.PhotoId == selectedItem.PhotoId
				select o).FirstOrDefault<LstMyItems>() != null)
				{
					//this.clientWin.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
				}
				else
				{
					//this.clientWin.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
				}
				this.txtMainImage.Text = selectedItem.Name;
				this.lstImages.SelectedItem = selectedItem;
				//this.clientWin._currentImageId = selectedItem.PhotoId;
			}
			else
			{
				//this.clientWin.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
			}
			IL_392:
			this.AngleValue += 720;
			this.AngleValue %= 360;
			transformGroup = new TransformGroup();
			transformGroup.Children.Add(new RotateTransform((double)this.AngleValue));
			transformGroup.Children.Add(new TranslateTransform(this.ContentContainer.ActualWidth, this.ContentContainer.ActualHeight));
			this.ContentContainer.LayoutTransform = transformGroup;
			if (!true)
			{
				goto IL_191;
			}
			TransformGroup transformGroup2 = new TransformGroup();
			transformGroup2.Children.Add(new RotateTransform((double)this.AngleValue));
			//transformGroup2.Children.Add(new TranslateTransform(this.clientWin.img12.ActualWidth, this.clientWin.img12.ActualHeight));
            //this.clientWin.img12.LayoutTransform = transformGroup2;
            //if (this.clientWin != null)
            //{
            //    this.clientWin.WindowState = WindowState.Maximized;
            //}
		}

		private void btnpreview_Click(object sender, RoutedEventArgs e)
		{
			this.FlipPreview();
		}

		private void btnthumbpreview_Click(object sender, RoutedEventArgs e)
		{
			this.RotateThumbPreview();
		}

		private void btnUnlock_Click(object sender, RoutedEventArgs e)
		{
			if (2 != 0)
			{
				try
				{
					this.AddUserControlModalDialog();
					//this.ModalDialog.OkButton.IsDefault = true;
                    bool flag = false;//this.ModalDialog.ShowHandlerDialog("Digi");
					int arg_54F_0;
					int arg_54F_1;
					LstMyItems lstMyItems;
					bool arg_4DB_0;
					LstMyItems lstMyItems3;
					while (true)
					{
						//this.ModalDialog.OkButton.IsDefault = false;
						int expr_68 = arg_54F_0 = (flag ? 1 : 0);
						int expr_6A = arg_54F_1 = 0;
						if (expr_6A != 0)
						{
							goto IL_53A;
						}
						if (expr_68 == expr_6A)
						{
							//goto IL_556;
						}
						PhotoBusiness photoBusiness = new PhotoBusiness();
						PhotoInfo photoDetailsbyPhotoId = photoBusiness.GetPhotoDetailsbyPhotoId(Convert.ToInt32(this.unlockImageId));
						RobotImageLoader.LstUnlocknames.Add(this.unlockImageId.ToString());
						if (photoDetailsbyPhotoId.DG_MediaType == 1)
						{
							this.imgmain.Source = CommonUtility.GetImageFromPath(Path.Combine(photoDetailsbyPhotoId.HotFolderPath, photoDetailsbyPhotoId.DG_Photos_CreatedOn.ToString("yyyyMMdd"), photoDetailsbyPhotoId.DG_Photos_FileName));
						}
						this.txtMainImage.Text = Convert.ToString(this.Photoname);
						this.splockedImages.Visibility = Visibility.Collapsed;
						if (false)
						{
							goto IL_42E;
						}
						this.spaddtoalbumnunlockedImages.Visibility = Visibility.Visible;
						this.spunlockedImages.Visibility = Visibility.Visible;
                        //if (Convert.ToBoolean(this.ModalDialog.rdbPermanantly.IsChecked))
                        //{
                        //    photoBusiness.immoderate(this.unlockImageId);
                        //}
                        //else
                        //{
                        //    RobotImageLoader.LstUnlocknames.Add(this.unlockImageId.ToString());
                        //}
						lstMyItems = (from t in RobotImageLoader.robotImages
						where (long)t.PhotoId == this.unlockImageId
						select t).FirstOrDefault<LstMyItems>();
						lstMyItems.FilePath = Path.Combine(photoDetailsbyPhotoId.HotFolderPath, "Thumbnails_Big", photoDetailsbyPhotoId.DG_Photos_CreatedOn.ToString("yyyyMMdd"), photoDetailsbyPhotoId.DG_Photos_FileName);
						lstMyItems.BigThumbnailPath = Path.Combine(photoDetailsbyPhotoId.HotFolderPath, "Thumbnails_Big", photoDetailsbyPhotoId.DG_Photos_CreatedOn.ToString("yyyyMMdd"), photoDetailsbyPhotoId.DG_Photos_FileName);
						LstMyItems lstMyItems2 = (from t in RobotImageLoader.robotImages
						where (long)t.PhotoId == this.unlockImageId
						select t).FirstOrDefault<LstMyItems>();
						bool expr_230 = arg_4DB_0 = (lstMyItems2 == null);
						if (!false)
						{
							if (!expr_230)
							{
								lstMyItems2.BigThumbnailPath = lstMyItems.BigThumbnailPath;
							}
							lstMyItems.IsLocked = Visibility.Visible;
							lstMyItems.IsPassKeyVisible = Visibility.Collapsed;
							lstMyItems3 = (from t in RobotImageLoader.GroupImages
							where (long)t.PhotoId == this.unlockImageId
							select t).FirstOrDefault<LstMyItems>();
							if (lstMyItems3 != null)
							{
								lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
								goto IL_2A7;
							}
							lstMyItems.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
							IL_320:
							LstMyItems lstMyItems4 = (from t in RobotImageLoader.PrintImages
							where (long)t.PhotoId == this.unlockImageId
							select t).FirstOrDefault<LstMyItems>();
							if (lstMyItems4 != null)
							{
								lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
								goto IL_36A;
							}
							lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
							IL_3E2:
							this.splockedImages.Visibility = Visibility.Collapsed;
							if (7 != 0)
							{
								this.spaddtoalbumnunlockedImages.Visibility = Visibility.Visible;
								if (false)
								{
									goto IL_31F;
								}
								this.spunlockedImages.Visibility = Visibility.Visible;
								if (false)
								{
									goto IL_2A7;
								}
								if (5 != 0)
								{
									break;
								}
								continue;
							}
							IL_36A:
							lstMyItems4.FilePath = Path.Combine(photoDetailsbyPhotoId.HotFolderPath, "Thumbnails_Big", photoDetailsbyPhotoId.DG_Photos_CreatedOn.ToString("yyyyMMdd"), photoDetailsbyPhotoId.DG_Photos_FileName);
							lstMyItems4.IsLocked = Visibility.Visible;
							lstMyItems4.IsPassKeyVisible = Visibility.Collapsed;
							lstMyItems4.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
							goto IL_3E2;
							IL_2A7:
							lstMyItems3.FilePath = Path.Combine(photoDetailsbyPhotoId.HotFolderPath, "Thumbnails_Big", photoDetailsbyPhotoId.DG_Photos_CreatedOn.ToString("yyyyMMdd"), photoDetailsbyPhotoId.DG_Photos_FileName);
							lstMyItems3.IsLocked = Visibility.Visible;
							lstMyItems3.IsPassKeyVisible = Visibility.Collapsed;
							lstMyItems3.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
							IL_31F:
							goto IL_320;
						}
						goto IL_4DB;
					}
					this.lstImages.SelectedItem = lstMyItems;
					IL_42E:
					int selectedIndex = this.lstImages.SelectedIndex;
					this.lstImages.Items.RemoveAt(selectedIndex);
					if (this.pagename == "Saveback" && this.vwGroup.Text == "View Group")
					{
						this.lstImages.Items.Insert(selectedIndex, lstMyItems3);
						this.lstImages.SelectedItem = lstMyItems3;
						goto IL_527;
					}
					bool flag2 = !(this.pagename == "Saveback") || !(this.vwGroup.Text == "View All");
					arg_4DB_0 = flag2;
					IL_4DB:
					if (!arg_4DB_0)
					{
						this.lstImages.Items.Insert(selectedIndex, lstMyItems3);
						this.lstImages.SelectedItem = lstMyItems3;
					}
					else
					{
						this.lstImages.Items.Insert(selectedIndex, lstMyItems);
						this.lstImages.SelectedItem = lstMyItems;
					}
					IL_527:
					this.btnEdit.IsEnabled = true;
					arg_54F_0 = LoginUser.UserId;
					arg_54F_1 = 5;
					IL_53A:
					AuditLog.AddUserLog(arg_54F_0, arg_54F_1, "Unlock " + this.Photoname + " image.");
                    //IL_556:
                    //this.ModalDialog.Dispose();
				}
				catch (Exception serviceException)
				{
					string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
					ErrorHandler.ErrorHandler.LogFileWrite(message);
				}
				finally
				{
					do
					{
						MemoryManagement.FlushMemory();
					}
					while (6 == 0);
				}
			}
		}

		private void lstImages_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Func<LstMyItems, bool> expr_06 = null;
			if (3 != 0)
			{
				Func<LstMyItems, bool> predicate = expr_06;
			}
			try
			{
				this.MediaStop();
                if (this.clientWin == null)
                {
                    foreach (Window window in System.Windows.Application.Current.Windows)
                    {
                        if (window.Title == "ClientView")
                        {
                            this.clientWin = (ClientView)window;
                            break;
                        }
                    }
                }
				if (this.lstImages.Items.Count > 0 && this.lstImages.SelectedItem != null)
				{
					LstMyItems lstMyItems=null;
					IEnumerable<string> source;
					PhotoBusiness photoBusiness;
					int arg_9C0_0;
					int arg_9C0_1;
					if (this.IMGFrame.Visibility != Visibility.Visible)
					{
						lstMyItems = (LstMyItems)this.lstImages.SelectedItem;
						int Photo_PKey = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
						source = from x in RobotImageLoader.LstUnlocknames
						where x.Equals(Photo_PKey.ToString())
						select x;
						photoBusiness = new PhotoBusiness();
						bool flag = !photoBusiness.GetModeratePhotos((long)Photo_PKey) || source.Count<string>() != 0;
						if (2 != 0)
						{
							if (!flag)
							{
								this.btnEdit.IsEnabled = false;
								this.splockedImages.Visibility = Visibility.Visible;
								this.spaddtoalbumnunlockedImages.Visibility = Visibility.Collapsed;
								this.spunlockedImages.Visibility = Visibility.Collapsed;
								this.mainFrame.Source = null;
								this.imgmain.Source = new BitmapImage(new Uri(LoginUser.DigiFolderPath + "/Locked.png"));
								goto IL_8AB;
							}
							this.splockedImages.Visibility = Visibility.Collapsed;
							this.spaddtoalbumnunlockedImages.Visibility = Visibility.Visible;
							this.spunlockedImages.Visibility = Visibility.Visible;
							this.btnEdit.IsEnabled = true;
							if (lstMyItems.MediaType != 1)
							{
								goto IL_931;
							}
						}
						this.unlockImage = CommonUtility.GetImageFromPath(lstMyItems.BigThumbnailPath);
						IL_931:
						this.imgmain.Source = this.unlockImage;
						if (((LstMyItems)this.lstImages.SelectedItem).FrameBrdr != null)
						{
							try
							{
								this.mainFrame.Source = new BitmapImage(new Uri(((LstMyItems)this.lstImages.SelectedItem).FrameBrdr));
							}
							catch
							{
							}
						}
						else
						{
							this.mainFrame.Source = null;
						}
						arg_9C0_0 = ((((LstMyItems)this.lstImages.SelectedItem).MediaType == 1) ? 1 : 0);
						arg_9C0_1 = 0;
						goto IL_9C0;
					}
					if (!RobotImageLoader.Is9ImgViewActive)
					{
						foreach (LstMyItems lstMyItems2 in ((IEnumerable)this.lstImages.Items))
						{
							lstMyItems2.GridMainHeight = 140;
							lstMyItems2.GridMainWidth = 170;
							lstMyItems2.GridMainRowHeight1 = 90;
							lstMyItems2.GridMainRowHeight2 = 60;
						}
					}
					this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
					this.txtMainImage.Text = ((LstMyItems)this.lstImages.SelectedItem).Name;
					RobotImageLoader.PhotoId = ((LstMyItems)this.lstImages.SelectedItem).Name;
					RobotImageLoader.UniquePhotoId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
					LstMyItems lstMyItems3 = (LstMyItems)this.lstImages.SelectedItem;
					this._currentImage = ((LstMyItems)this.lstImages.SelectedItem).Name;
					this._currentImageId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
					LstMyItems lstMyItems4 = (from t in RobotImageLoader.GroupImages
					where t.PhotoId == this._currentImageId
					select t).FirstOrDefault<LstMyItems>();
					if (lstMyItems4 != null)
					{
						this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
						this.btnImageAddToGroup.ToolTip = "Remove from group";
						this.btnImageAddToGroup.CommandParameter = "Remove from group";
					}
					else
					{
						this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
						this.btnImageAddToGroup.ToolTip = "Add to group";
						this.btnImageAddToGroup.CommandParameter = "Add to group";
					}
					IEnumerable<LstMyItems> arg_312_0 = RobotImageLoader.PrintImages;
					Func<LstMyItems, bool> predicate = (LstMyItems t) => t.PhotoId == this._currentImageId;
					LstMyItems lstMyItems5 = arg_312_0.Where(predicate).FirstOrDefault<LstMyItems>();
					if (lstMyItems5 != null)
					{
						this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
						if (this.isSingleScreenPreview)
						{
							this.clientWin.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
						}
					}
					else
					{
						this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
						if (this.isSingleScreenPreview)
						{
							this.clientWin.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
						}
					}
					int currentImageId = this._currentImageId;
					this.unlockImageId = (long)currentImageId;
					LstMyItems myItems = (LstMyItems)this.lstImages.SelectedItem;
					IL_3EF:
					source = RobotImageLoader.LstUnlocknames.Where(delegate(string x)
					{
						if (false)
						{
							goto IL_20;
						}
						bool arg_27_0;
						bool arg_46_0 = arg_27_0 = x.Equals(myItems.PhotoId.ToString());
						IL_16:
						if (7 == 0 || 8 == 0)
						{
							goto IL_24;
						}
						bool flag2;
						if (!false)
						{
							flag2 = arg_46_0;
						}
						IL_20:
						arg_46_0 = (arg_27_0 = flag2);
						IL_24:
						if (!false)
						{
							return arg_27_0;
						}
						goto IL_16;
					});
					IL_408:
					photoBusiness = new PhotoBusiness();
					int arg_613_0;
					int arg_613_1;
					if (photoBusiness.GetModeratePhotos((long)currentImageId) && source.Count<string>() == 0)
					{
						this.btnEdit.IsEnabled = false;
						this.splockedImages.Visibility = Visibility.Visible;
						this.spaddtoalbumnunlockedImages.Visibility = Visibility.Collapsed;
						this.spunlockedImages.Visibility = Visibility.Collapsed;
						this.mainFrame.Source = null;
						this.imgmain.Source = new BitmapImage(new Uri(LoginUser.DigiFolderPath + "/Locked.png"));
						this.CurrentBitmapImage = new BitmapImage(new Uri(LoginUser.DigiFolderPath + "/Locked.png"));
					}
					else
					{
						bool flag;
						do
						{
							this.splockedImages.Visibility = Visibility.Collapsed;
							this.spaddtoalbumnunlockedImages.Visibility = Visibility.Visible;
							this.spunlockedImages.Visibility = Visibility.Visible;
							this.btnEdit.IsEnabled = true;
							int expr_4FE = arg_613_0 = myItems.MediaType;
							int expr_504 = arg_613_1 = 1;
							if (expr_504 == 0)
							{
								//goto IL_613;
							}
							flag = (expr_4FE != expr_504);
						}
						while (false);
						if (!flag)
						{
							this.CurrentBitmapImage = CommonUtility.GetImageFromPath(myItems.BigThumbnailPath);
							this.imgmain.Source = this.CurrentBitmapImage;
						}
						if (((LstMyItems)this.lstImages.SelectedItem).FrameBrdr != null)
						{
							this.mainFrame.Source = new BitmapImage(new Uri(((LstMyItems)this.lstImages.SelectedItem).FrameBrdr));
						}
						else
						{
							this.mainFrame.Source = null;
						}
					}
					IL_58C:
					bool arg_5BC_0;
                    if (lstMyItems3.MediaType != 2)
                    {
                        int expr_5A7 = arg_9C0_0 = lstMyItems3.MediaType;
                        int expr_5AD = arg_9C0_1 = 3;
                        if (expr_5AD == 0)
                        {
                            goto IL_9C0;
                        }
                        arg_5BC_0 = (expr_5A7 != expr_5AD);
                    }
                    else
                    {
                        arg_5BC_0 = false;
                    }
                    if (arg_5BC_0)
                    {
                        this.btnEdit.IsEnabled = true;
                        this.img.Visibility = Visibility.Visible;
                        this.vidoriginal.Visibility = Visibility.Hidden;
                        goto IL_735;
                    }
					this.btnEdit.IsEnabled = false;
					this.img.Visibility = Visibility.Hidden;
					this.vidoriginal.Visibility = Visibility.Visible;
					if (false)
					{
						goto IL_3EF;
					}
                    string fileName = lstMyItems3.FileName;
                    if (string.IsNullOrEmpty(fileName))
                    {
                        goto IL_709;
                    }
                    arg_613_0 = lstMyItems3.MediaType;
                    arg_613_1 = 2;
                IL_613:
                    if (arg_613_0 == arg_613_1)
                    {
                        using (FileStream fileStream = File.OpenRead(Path.Combine(lstMyItems3.HotFolderPath, "Videos", lstMyItems3.CreatedOn.ToString("yyyyMMdd"), fileName)))
                        {
                            SearchResult.vsMediaFileName = fileStream.Name;
                        }
                    }
                    else
                    {
                        using (FileStream fileStream = File.OpenRead(Path.Combine(lstMyItems3.HotFolderPath, "ProcessedVideos", lstMyItems3.CreatedOn.ToString("yyyyMMdd"), fileName)))
                        {
                            SearchResult.vsMediaFileName = fileStream.Name;
                        }
                        if (3 == 0)
                        {
                            goto IL_8AB;
                        }
                    }
					base.Dispatcher.Invoke(new Action(delegate
					{
						this.MediaPlay();
					}), new object[0]);
					this.txtMainVideo.Text = lstMyItems3.Name;
					IL_709:
					IL_735:
					bool? isChecked = this.btnchkpreview.IsChecked;
					int arg_75D_0;
					if (isChecked.GetValueOrDefault())
					{
						arg_75D_0 = (isChecked.HasValue ? 1 : 0);
					}
					else
					{
						if (4 == 0)
						{
							goto IL_408;
						}
						arg_75D_0 = 0;
					}
					if (arg_75D_0 != 0)
					{
						if (!false)
						{
							AuditLog.AddUserLog(LoginUser.UserId, 1, "Show Preview of " + ((LstMyItems)this.lstImages.SelectedItem).Name.ToString() + " image.", ((LstMyItems)this.lstImages.SelectedItem).PhotoId);
						}
					}
					goto IL_A1A;
					IL_8AB:
					this.CurrentBitmapImage = new BitmapImage(new Uri(LoginUser.DigiFolderPath + "/Locked.png"));
					if (2 != 0)
					{
						goto IL_9DC;
					}
					goto IL_58C;
					IL_9C0:
					if (arg_9C0_0 != arg_9C0_1)
					{
						this.CurrentBitmapImage = CommonUtility.GetImageFromPath(lstMyItems.BigThumbnailPath);
					}
                IL_9DC:
                    if (lstMyItems.MediaType == 2 || lstMyItems.MediaType == 3)
                    {
                        this.btnEdit.IsEnabled = false;
                    }
                    else
                    {
                        this.btnEdit.IsEnabled = true;
                    }
					IL_A1A:;
				}
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
			finally
			{
			}
		}

		private void Window_Unloaded(object sender, RoutedEventArgs e)
		{
		}

		protected override void OnClosed(EventArgs e)
		{
			while (-1 != 0 && 8 != 0)
			{
				if (7 == 0)
				{
					return;
				}
				base.OnClosed(e);
				this.continueCalculating = false;
				if (!false)
				{
					this.lstImages.Items.Clear();
					break;
				}
			}
			MemoryManagement.FlushMemory();
		}

		private void btnRemoveGroup_Click(object sender, RoutedEventArgs e)
		{
            //if (!false)
            //{
            //    int arg_12_0 = this.IsEnableGrouping ? 1 : 0;
            //    int arg_12_1 = 0;
            //    while (true)
            //    {
            //        IL_12:
            //        bool flag = arg_12_0 == arg_12_1;
            //        while (!flag)
            //        {
            //            if (2 == 0)
            //            {
            //                goto IL_147;
            //            }
            //            flag = (RobotImageLoader.GroupImages.Count <= 0);
            //            if (!flag)
            //            {
            //                this.AddUserControlSaveGroup();
            //                this.savegroupusercontrol.txtGroupName.Focus();
            //                FocusManager.SetFocusedElement(this, this.savegroupusercontrol.txtGroupName);
            //                Keyboard.Focus(this.savegroupusercontrol.txtGroupName);
            //                this.savegroupusercontrol.SaveButton.IsDefault = true;
            //                LstMyItems lstMyItems = (LstMyItems)this.lstImages.SelectedItem;
            //                flag = (lstMyItems == null);
            //                if (!flag)
            //                {
            //                    flag = (lstMyItems.MediaType == 1);
            //                    if (!flag)
            //                    {
            //                        this.imageInfo.IsVideo = true;
            //                        this.gdMediaPlayer.Visibility = Visibility.Collapsed;
            //                        goto IL_E1;
            //                    }
            //                    this.imageInfo.IsVideo = false;
            //                    goto IL_EF;
            //                }
            //            }
            //            else if (8 != 0)
            //            {
            //                int expr_11B = arg_12_0 = RobotImageLoader.PrintImages.Count;
            //                int expr_121 = arg_12_1 = 0;
            //                if (expr_121 != 0)
            //                {
            //                    goto IL_12;
            //                }
            //                flag = (expr_11B <= expr_121);
            //                if (!flag)
            //                {
            //                    goto Block_10;
            //                }
            //                System.Windows.MessageBox.Show("Please add images to group!");
            //                goto IL_147;
            //            }
            //            IL_109:
            //            if (!false)
            //            {
            //                goto Block_7;
            //            }
            //            continue;
            //            IL_EF:
            //            this.savegroupusercontrol.Visibility = Visibility.Visible;
            //            this.savegroupusercontrol.ClearControls();
            //            goto IL_109;
            //            IL_E1:
            //            goto IL_EF;
            //            IL_147:
            //            if (!false)
            //            {
            //                goto IL_14B;
            //            }
            //            goto IL_E1;
            //        }
            //        goto IL_14F;
            //    }
            //    Block_7:
            //    goto IL_14C;
            //    Block_10:
            //    this.ClearGroupforPrint();
            //    IL_14B:
            //    IL_14C:
            //    goto IL_14D;
            //    IL_14F:
            //    goto IL_150;
            //}
            //goto IL_150;
            //IL_14D:
            //return;
            //IL_150:
            //this.ClearGroup(this, e);
            //if (7 != 0)
            //{
            //}
		}

		private void ClearGroup(object sender, EventArgs e)
		{
			try
			{
				this.MediaStop();
				RobotImageLoader.currentCount = 0;
				RobotImageLoader.IsZeroSearchNeeded = true;
				this.flgGridWithoutPreview = true;
				bool expr_2A = RobotImageLoader.ViewGroupedImagesCount == null;
				bool flag;
				if (!false)
				{
					flag = expr_2A;
				}
				if (flag)
				{
					goto IL_45;
				}
				IL_3A:
				RobotImageLoader.ViewGroupedImagesCount.Clear();
				IL_45:
				RobotImageLoader.thumbSet = this.scrollIndexWithoutPreview;
				this.btnprev.Visibility = Visibility.Visible;
				this.btnnext.Visibility = Visibility.Visible;
				ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
				flag = (RobotImageLoader.GroupImages == null);
				if (false)
				{
					goto IL_29E;
				}
				if (!flag)
				{
					if (4 != 0)
					{
						this.IMGFrame.Visibility = Visibility.Collapsed;
						Grid.SetColumnSpan(this.thumbPreview, 2);
						Grid.SetColumn(this.thumbPreview, 0);
						this.thumbPreview.Margin = new Thickness(0.0);
						if (7 != 0)
						{
							this.btnEdit.IsEnabled = false;
							int arg_FD_0;
							int expr_F1 = arg_FD_0 = RobotImageLoader.GroupImages.Count;
							int arg_FD_1;
							int expr_F7 = arg_FD_1 = 0;
							if (expr_F7 == 0)
							{
								arg_FD_0 = ((expr_F1 > expr_F7) ? 1 : 0);
								arg_FD_1 = 0;
							}
							flag = (arg_FD_0 == arg_FD_1);
							if (flag)
							{
								flag = (RobotImageLoader.PrintImages == null);
								if (flag)
								{
									goto IL_258;
								}
								RobotImageLoader.PrintImages.Clear();
								this.lstImages.Items.Clear();
								if (!false)
								{
									flag = (RobotImageLoader.GroupImages != null);
									if (!flag)
									{
										RobotImageLoader.GroupImages = new List<LstMyItems>();
									}
									RobotImageLoader.GroupImages.Clear();
									RobotImageLoader.RFID = "0";
									RobotImageLoader.SearchCriteria = "";
									RobotImageLoader.LoadImages();
									this.continueCalculating = false;
									this.num = 0;
									this.vwGroup.Text = "View Group";
									this.LoadImages();
									this.SetMessageText("Grouped");
									goto IL_249;
								}
								goto IL_3A;
							}
						}
						this.lstImages.Items.Clear();
						RobotImageLoader.GroupImages.Clear();
						flag = (RobotImageLoader.PrintImages != null);
						if (!flag)
						{
							RobotImageLoader.PrintImages = new List<LstMyItems>();
						}
						RobotImageLoader.PrintImages.Clear();
						RobotImageLoader.RFID = "0";
						RobotImageLoader.SearchCriteria = "";
						RobotImageLoader.LoadImages();
						this.continueCalculating = false;
						this.num = 0;
						this.vwGroup.Text = "View Group";
					}
					this.grdSelectAll.Visibility = Visibility.Visible;
					this.LoadImages();
					this.SPSelectAll.Visibility = Visibility.Visible;
					goto IL_259;
				}
				flag = (RobotImageLoader.PrintImages == null);
				if (flag)
				{
					goto IL_31C;
				}
				RobotImageLoader.PrintImages.Clear();
				if (false)
				{
					goto IL_2FB;
				}
				this.lstImages.Items.Clear();
				flag = (RobotImageLoader.GroupImages != null);
				if (!flag)
				{
					goto IL_29E;
				}
				goto IL_2A8;
				IL_249:
				this.grdSelectAll.Visibility = Visibility.Visible;
				IL_258:
				IL_259:
				goto IL_31D;
				IL_29E:
				RobotImageLoader.GroupImages = new List<LstMyItems>();
				IL_2A8:
				RobotImageLoader.GroupImages.Clear();
				if (4 == 0)
				{
					goto IL_249;
				}
				RobotImageLoader.currentCount = 0;
				RobotImageLoader.IsZeroSearchNeeded = true;
				RobotImageLoader.RFID = "0";
				RobotImageLoader.SearchCriteria = "";
				RobotImageLoader.LoadImages();
				this.continueCalculating = false;
				this.num = 0;
				this.vwGroup.Text = "View Group";
				IL_2FB:
				this.SetMessageText("Grouped");
				this.grdSelectAll.Visibility = Visibility.Visible;
				this.LoadImages();
				IL_31C:
				IL_31D:
				this.FillImageList();
				this.CheckSelectAllGroup();
			}
			catch (Exception serviceException)
			{
				do
				{
					string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
					ErrorHandler.ErrorHandler.LogFileWrite(message);
				}
				while (false);
			}
		}

		private void ClearGroupforPrint()
		{
			try
			{
				if (!true)
				{
					goto IL_98;
				}
				this.lstImages.Items.Clear();
				IL_1C:
				RobotImageLoader.GroupImages = new List<LstMyItems>();
				if (5 != 0)
				{
					if (false)
					{
						goto IL_88;
					}
					RobotImageLoader.PrintImages = new List<LstMyItems>();
					RobotImageLoader.RFID = "0";
				}
				RobotImageLoader.SearchCriteria = "";
				RobotImageLoader.LoadImages();
				this.continueCalculating = false;
				RobotImageLoader.currentCount = 0;
				IL_62:
				RobotImageLoader.IsZeroSearchNeeded = true;
				this.num = 0;
				this.vwGroup.Text = "View Group";
				IL_88:
				if (false)
				{
					goto IL_1C;
				}
				this.grdSelectAll.Visibility = Visibility.Visible;
				IL_98:
				if (false)
				{
					goto IL_62;
				}
				this.LoadImages();
				this.txtSelectedImages.Visibility = Visibility.Visible;
			}
			catch (Exception serviceException)
			{
				while (false)
				{
				}
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
		}

		private void btnPlaceOrder_Click(object sender, RoutedEventArgs e)
		{
			do
			{
				try
				{
					do
					{
						SearchResult.vsMediaFileName = string.Empty;
						if (!false)
						{
							this.MediaStop();
						}
					}
					while (false);
                    //PlaceOrder placeOrder = new PlaceOrder();
                    //placeOrder.CtrlSelectedAlbumlist.PrintOrderPageList.Clear();
					RobotImageLoader.PrintImages.ForEach(delegate(LstMyItems o)
					{
						o.PhotoPrintPositionList.Clear();
					});
					//placeOrder.Show();
					do
					{
						//placeOrder.LoadProductType(sender);
						base.Close();
					}
					while (!true);
				}
				catch
				{
					if (7 != 0)
					{
					}
				}
			}
			while (false);
			if (!false)
			{
			}
		}

		private void chkSelectAll_Click(object sender, RoutedEventArgs e)
		{
			LstMyItems selectedItem = (LstMyItems)this.lstImages.SelectedItem;
			if (this.vwGroup.Text != "View Group")
			{
				string uriString = (this.chkSelectAll.IsChecked == true) ? "/images/print-accept.png" : "/images/print-group.png";
                //using (IEnumerator enumerator = ((IEnumerable)this.lstImages.Items).GetEnumerator())
                //{
                //    while (enumerator.MoveNext())
                //    {
                //        LstMyItems curItem = (LstMyItems)enumerator.Current;
                //        try
                //        {
                //            try
                //            {
                //                LstMyItems lstMyItems = (from t in RobotImageLoader.PrintImages
                //                where t.PhotoId == curItem.PhotoId
                //                select t).FirstOrDefault<LstMyItems>();
                //                ListBoxItem obj = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(curItem);
                //                while (!(this.chkSelectAll.IsChecked == true) || lstMyItems != null)
                //                {
                //                    if (this.chkSelectAll.IsChecked == false && lstMyItems != null)
                //                    {
                //                        RobotImageLoader.PrintImages.Remove(lstMyItems);
                //                        LstMyItems lstMyItems2 = (from r in RobotImageLoader.robotImages
                //                        where r.PhotoId == curItem.PhotoId
                //                        select r).FirstOrDefault<LstMyItems>();
                //                        if (false)
                //                        {
                //                            continue;
                //                        }
                //                        if (lstMyItems2 != null)
                //                        {
                //                            lstMyItems2.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                //                        }
                //                    }
                //                    IL_27F:
                //                    this.imgprintgroup.Source = new BitmapImage(new Uri(uriString, UriKind.Relative));
                //                    ContentPresenter contentPresenter = this.FindVisualChild<ContentPresenter>(obj);
                //                    DataTemplate contentTemplate = contentPresenter.ContentTemplate;
                //                    Grid grid = (Grid)contentTemplate.FindName("grdMain", contentPresenter);
                //                    ((System.Windows.Controls.Image)((System.Windows.Controls.Button)((Grid)grid.FindName("Printbtns")).Children[0]).Content).Source = new BitmapImage(new Uri(uriString, UriKind.Relative));
                //                    goto IL_315;
                //                }
                //                LstMyItems lstMyItems3 = new LstMyItems();
                //                lstMyItems3 = curItem;
                //                lstMyItems3.FilePath = curItem.FilePath;
                //                lstMyItems3.Name = curItem.Name;
                //                lstMyItems3.PhotoId = curItem.PhotoId;
                //                lstMyItems3.MediaType = curItem.MediaType;
                //                lstMyItems3.VideoLength = curItem.VideoLength;
                //                lstMyItems3.FileName = curItem.FileName;
                //                lstMyItems3.CreatedOn = curItem.CreatedOn;
                //                RobotImageLoader.PrintImages.Add(lstMyItems3);
                //                if (!false)
                //                {
                //                }
                //                goto IL_27F;
                //            }
                //            catch (Exception serviceException)
                //            {
                //                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                //                ErrorHandler.ErrorHandler.LogFileWrite(message);
                //            }
                //            IL_315:;
                //        }
                //        finally
                //        {
                //            while (2 == 0)
                //            {
                //            }
                //        }
                //    }
                //}
				this.SetMessageText("PrintGrouped");
			}
			else
			{
				string uriString2 = (this.chkSelectAll.IsChecked == true) ? "/images/view-accept.png" : "/images/view-group.png";
                //using (IEnumerator enumerator = ((IEnumerable)this.lstImages.Items).GetEnumerator())
                //{
                //    while (true)
                //    {
                //        bool arg_669_0;
                //        bool expr_65D = arg_669_0 = enumerator.MoveNext();
                //        if (4 != 0)
                //        {
                //            bool flag = expr_65D;
                //            arg_669_0 = flag;
                //        }
                //        if (!arg_669_0)
                //        {
                //            break;
                //        }
                //        LstMyItems curItem = (LstMyItems)enumerator.Current;
                //        try
                //        {
                //            LstMyItems grpitem = (from t in RobotImageLoader.GroupImages
                //            where t.PhotoId == curItem.PhotoId
                //            select t).FirstOrDefault<LstMyItems>();
                //            ListBoxItem obj = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(curItem);
                //            if (!(this.chkSelectAll.IsChecked == true) || grpitem != null)
                //            {
                //                bool flag = !(this.chkSelectAll.IsChecked == false) || grpitem == null;
                //                if (false)
                //                {
                //                    goto IL_4A7;
                //                }
                //                if (!flag)
                //                {
                //                    RobotImageLoader.GroupImages.Remove(grpitem);
                //                    int arg_551_0;
                //                    bool arg_54D_0;
                //                    if (RobotImageLoader.ViewGroupedImagesCount != null)
                //                    {
                //                        int expr_535 = arg_551_0 = RobotImageLoader.ViewGroupedImagesCount.Count;
                //                        if (7 == 0)
                //                        {
                //                            goto IL_551;
                //                        }
                //                        arg_54D_0 = (expr_535 <= 0);
                //                    }
                //                    else
                //                    {
                //                        if (!true)
                //                        {
                //                            goto IL_475;
                //                        }
                //                        arg_54D_0 = true;
                //                    }
                //                    flag = arg_54D_0;
                //                    arg_551_0 = (flag ? 1 : 0);
                //                    IL_551:
                //                    if (arg_551_0 == 0)
                //                    {
                //                        RobotImageLoader.ViewGroupedImagesCount.Remove(grpitem.Name);
                //                    }
                //                    LstMyItems lstMyItems2 = (from r in RobotImageLoader.robotImages
                //                    where r.PhotoId == grpitem.PhotoId
                //                    select r).FirstOrDefault<LstMyItems>();
                //                    if (lstMyItems2 != null)
                //                    {
                //                        lstMyItems2.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                //                    }
                //                    goto IL_5B8;
                //                }
                //                goto IL_5B8;
                //            }
                //            IL_475:
                //            LstMyItems lstMyItems3 = new LstMyItems();
                //            lstMyItems3 = curItem;
                //            lstMyItems3.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                //            RobotImageLoader.GroupImages.Add(lstMyItems3);
                //            IL_4A7:
                //            if (RobotImageLoader.ViewGroupedImagesCount == null)
                //            {
                //                RobotImageLoader.ViewGroupedImagesCount = new List<string>();
                //            }
                //            RobotImageLoader.ViewGroupedImagesCount.Add(lstMyItems3.Name);
                //            IL_5B8:
                //            ContentPresenter contentPresenter = this.FindVisualChild<ContentPresenter>(obj);
                //            DataTemplate contentTemplate = contentPresenter.ContentTemplate;
                //            Grid grid = (Grid)contentTemplate.FindName("grdMain", contentPresenter);
                //            if (!false)
                //            {
                //                ((System.Windows.Controls.Image)((System.Windows.Controls.Button)((Grid)grid.FindName("Printbtns")).Children[2]).Content).Source = new BitmapImage(new Uri(uriString2, UriKind.Relative));
                //                this.ImgAddToGroup.Source = new BitmapImage(new Uri(uriString2, UriKind.Relative));
                //            }
                //        }
                //        catch (Exception serviceException)
                //        {
                //            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                //            ErrorHandler.ErrorHandler.LogFileWrite(message);
                //        }
                //        finally
                //        {
                //        }
                //    }
                //}
				this.SetMessageText("Grouped");
			}
			if (selectedItem != null)
			{
				if (3 != 0)
				{
					this.lstImages.SelectedItem = selectedItem;
					this.lstImages.Focus();
					LstMyItems lstMyItems4 = (from t in RobotImageLoader.PrintImages
					where t.PhotoId == selectedItem.PhotoId
					select t).FirstOrDefault<LstMyItems>();
					if (lstMyItems4 != null)
					{
						this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
					}
					else
					{
						this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
					}
				}
			}
		}

		private void btnScrollUp_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				bool flag = !(RobotImageLoader.SearchCriteria == "TimeWithQrcode");
				int arg_130_0;
				if (!flag)
				{
					bool arg_182_0;
					if (RobotImageLoader.robotImages != null)
					{
						bool expr_36 = (arg_130_0 = ((RobotImageLoader.robotImages.Count > 0) ? 1 : 0)) != 0;
						if (3 == 0)
						{
							goto IL_130;
						}
						arg_182_0 = !expr_36;
					}
					else
					{
						if (3 == 0)
						{
							goto IL_14E;
						}
						arg_182_0 = true;
					}
					if (!false)
					{
						flag = arg_182_0;
					}
					if (flag)
					{
						goto IL_AF;
					}
					this.searchDetails.StartIndex = (long)RobotImageLoader.robotImages.Min((LstMyItems o) => o.PhotoId);
					this.searchDetails.NewRecord = 1;
				}
				else
				{
					flag = (!(RobotImageLoader.SearchCriteria == "PhotoId") || !(RobotImageLoader.RFID != "0"));
					if (5 == 0)
					{
						goto IL_AD;
					}
					if (flag)
					{
						goto IL_14E;
					}
					bool arg_102_0;
					if (RobotImageLoader.robotImages != null)
					{
						if (false)
						{
							goto IL_13C;
						}
						arg_102_0 = (RobotImageLoader.robotImages.Count <= 0);
					}
					else
					{
						arg_102_0 = true;
					}
					if (!arg_102_0)
					{
						arg_130_0 = RobotImageLoader.robotImages.Min((LstMyItems o) => o.PhotoId);
						goto IL_130;
					}
					goto IL_14A;
				}
				IL_A0:
				this.MovePage(this.searchDetails);
				IL_AD:
				IL_AF:
				goto IL_156;
				IL_130:
				RobotImageLoader.StartIndexRFID = (long)arg_130_0;
				RobotImageLoader.NewRecord = 1;
				IL_13C:
				this.MovePagePhotoId(this.searchDetails);
				IL_149:
				IL_14A:
				goto IL_156;
				IL_14E:
				this.NextRec();
				IL_156:
				if (false)
				{
					goto IL_149;
				}
				if (false)
				{
					goto IL_A0;
				}
			}
			finally
			{
				MemoryManagement.FlushMemory();
				while (2 == 0)
				{
				}
			}
		}

		private void MovePagePhotoId(SearchDetailInfo searchDetails)
		{
			if (RobotImageLoader.robotImages != null && RobotImageLoader.Is16ImgViewActive && !RobotImageLoader.Is9ImgViewActive)
			{
				this.ImageSize(16);
			}
			else
			{
				this.ImageSize(9);
			}
			IL_43:
			if (RobotImageLoader.robotImages == null || RobotImageLoader.robotImages.Count <= 0)
			{
				goto IL_161;
			}
			int arg_78_0;
			int arg_7B_0 = arg_78_0 = RobotImageLoader.NewRecord;
			IL_74:
			int arg_7B_1;
			int expr_75 = arg_7B_1 = 0;
			if (expr_75 == 0)
			{
				arg_7B_0 = ((arg_78_0 == expr_75) ? 1 : 0);
				arg_7B_1 = 0;
			}
			bool arg_85_0;
			bool expr_7B = arg_85_0 = (arg_7B_0 == arg_7B_1);
			if (6 != 0)
			{
				bool flag = expr_7B;
				if (false)
				{
					goto IL_43;
				}
				arg_85_0 = flag;
			}
			LstMyItems lstMyItems;
			if (arg_85_0)
			{
				lstMyItems = RobotImageLoader.robotImages.FirstOrDefault((LstMyItems o) => (long)o.PhotoId == RobotImageLoader.MinPhotoIdCriteria);
				goto IL_11B;
			}
			LstMyItems lstMyItems2 = RobotImageLoader.robotImages.FirstOrDefault((LstMyItems o) => (long)o.PhotoId == RobotImageLoader.MaxPhotoIdCriteria);
			if (lstMyItems2 == null)
			{
				goto IL_160;
			}
			RobotImageLoader.NewRecord = 1;
			IL_C1:
			long arg_C8_0 = RobotImageLoader.MaxPhotoIdCriteria;
			int arg_C7_0 = 1;
			IL_C7:
			RobotImageLoader.StartIndexRFID = arg_C8_0 + (long)arg_C7_0;
			System.Windows.MessageBox.Show("No more records found!", "DigiPhoto i-Mix", MessageBoxButton.OK, MessageBoxImage.Asterisk);
			this.LoadImagePhotoId();
			return;
			IL_11B:
			bool expr_11D = (arg_78_0 = (arg_7B_0 = ((lstMyItems == null) ? 1 : 0))) != 0;
			if (false)
			{
				goto IL_74;
			}
			if (!expr_11D)
			{
				RobotImageLoader.NewRecord = 0;
				long expr_130 = arg_C8_0 = RobotImageLoader.MinPhotoIdCriteria;
				int expr_136 = arg_C7_0 = 1;
				if (expr_136 != 0)
				{
					RobotImageLoader.StartIndexRFID = expr_130 - (long)expr_136;
					System.Windows.MessageBox.Show("No more records found!", "DigiPhoto i-Mix", MessageBoxButton.OK, MessageBoxImage.Asterisk);
					this.LoadImagePhotoId();
					return;
				}
				goto IL_C7;
			}
			IL_160:
			IL_161:
			RobotImageLoader._rfidSearch = 1;
			RobotImageLoader.LoadImages(searchDetails);
			if (false)
			{
				goto IL_C1;
			}
			this.LoadImages();
			this.FillImageList();
			this.CheckSelectAllGroup();
			RobotImageLoader.ViewGroupedImagesCount.Clear();
			if (7 == 0)
			{
				goto IL_11B;
			}
		}

		private void PrevRec()
		{
			long expr_02 = 0L;
			long num;
			if (!false)
			{
				num = expr_02;
			}
			int expr_11 = RobotImageLoader.MediaTypes;
			if (!false)
			{
				this.GetNewMaxId(out num, expr_11);
			}
			while (true)
			{
				IL_1F:
				bool arg_120_0;
				if (RobotImageLoader._objnewincrement != null)
				{
					int arg_32_0 = RobotImageLoader._objnewincrement.Count;
					while (arg_32_0 > 0)
					{
						if (RobotImageLoader._objnewincrement.Count != 0)
						{
							if (-1 == 0)
							{
								goto IL_95;
							}
							arg_120_0 = ((arg_32_0 = ((num != (long)RobotImageLoader._objnewincrement[0].PhotoId) ? 1 : 0)) != 0);
						}
						else
						{
							arg_120_0 = ((arg_32_0 = 0) != 0);
						}
						if (!false)
						{
							goto IL_68;
						}
					}
					goto IL_67;
				}
				goto IL_67;
				IL_68:
				bool flag = arg_120_0;
				if (!true)
				{
					goto IL_95;
				}
				if (!flag)
				{
					break;
				}
				RobotImageLoader.IsNextPage = true;
				RobotImageLoader.ViewGroupedImagesCount.Clear();
				while (true)
				{
					RobotImageLoader.thumbSet = this.scrollIndexWithoutPreview;
					this.flgLoadNext = true;
					if (7 == 0)
					{
						goto IL_1F;
					}
					this.LoadNext();
					this.FillImageList();
					this.CheckSelectAllGroup();
					if (!false)
					{
						return;
					}
				}
				IL_67:
				arg_120_0 = true;
				goto IL_68;
			}
			RobotImageLoader.currentCount = 0;
			IL_7B:
			System.Windows.MessageBox.Show("No more records found!", "DigiPhoto i-Mix", MessageBoxButton.OK, MessageBoxImage.Asterisk);
			this.LoadImageGroupPrev();
			IL_95:
			if (6 == 0)
			{
				goto IL_7B;
			}
		}

		private void NextRec()
		{
			if (RobotImageLoader._objnewincrement == null)
			{
				goto IL_40;
			}
			int arg_13_0 = RobotImageLoader._objnewincrement.Count;
			IL_12:
			int arg_EB_0;
			int arg_8C_0;
			if (arg_13_0 > 0)
			{
				arg_8C_0 = (arg_13_0 = (arg_EB_0 = ((RobotImageLoader.MinPhotoId != (long)RobotImageLoader._objnewincrement[RobotImageLoader._objnewincrement.Count - 1].PhotoId) ? 1 : 0)));
				if (!false)
				{
					goto IL_41;
				}
				goto IL_8C;
			}
			IL_40:
			arg_EB_0 = (arg_13_0 = 1);
			IL_41:
			if (false)
			{
				goto IL_12;
			}
			bool flag;
			if (6 != 0)
			{
				flag = (arg_EB_0 != 0);
			}
			if (flag)
			{
				goto IL_7A;
			}
			IL_53:
			IL_54:
			RobotImageLoader.currentCount = 0;
			System.Windows.MessageBox.Show("No more records found!", "DigiPhoto i-Mix", MessageBoxButton.OK, MessageBoxImage.Asterisk);
			this.LoadImageGroupNext();
			return;
			IL_7A:
			RobotImageLoader.ViewGroupedImagesCount.Clear();
			if (-1 == 0)
			{
				goto IL_54;
			}
			if (false)
			{
				goto IL_94;
			}
			arg_8C_0 = 0;
			IL_8C:
			int thumbSet = arg_8C_0;
			thumbSet = this.scrollIndexWithoutPreview;
			IL_94:
			RobotImageLoader.IsNextPage = false;
			if (5 == 0)
			{
				goto IL_7A;
			}
			RobotImageLoader.thumbSet = thumbSet;
			this.flgLoadNext = true;
			this.LoadNext();
			this.FillImageList();
			if (false)
			{
				goto IL_53;
			}
			this.CheckSelectAllGroup();
		}

		private void btnScrollDown_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				bool flag = !(RobotImageLoader.SearchCriteria == "TimeWithQrcode");
				int arg_130_0;
				if (!flag)
				{
					bool arg_182_0;
					if (RobotImageLoader.robotImages != null)
					{
						bool expr_36 = (arg_130_0 = ((RobotImageLoader.robotImages.Count > 0) ? 1 : 0)) != 0;
						if (3 == 0)
						{
							goto IL_130;
						}
						arg_182_0 = !expr_36;
					}
					else
					{
						if (3 == 0)
						{
							goto IL_14E;
						}
						arg_182_0 = true;
					}
					if (!false)
					{
						flag = arg_182_0;
					}
					if (flag)
					{
						goto IL_AF;
					}
					this.searchDetails.StartIndex = (long)RobotImageLoader.robotImages.Max((LstMyItems o) => o.PhotoId);
					this.searchDetails.NewRecord = 0;
				}
				else
				{
					flag = (!(RobotImageLoader.SearchCriteria == "PhotoId") || !(RobotImageLoader.RFID != "0"));
					if (5 == 0)
					{
						goto IL_AD;
					}
					if (flag)
					{
						goto IL_14E;
					}
					bool arg_102_0;
					if (RobotImageLoader.robotImages != null)
					{
						if (false)
						{
							goto IL_13C;
						}
						arg_102_0 = (RobotImageLoader.robotImages.Count <= 0);
					}
					else
					{
						arg_102_0 = true;
					}
					if (!arg_102_0)
					{
						arg_130_0 = RobotImageLoader.robotImages.Max((LstMyItems o) => o.PhotoId);
						goto IL_130;
					}
					goto IL_14A;
				}
				IL_A0:
				this.MovePage(this.searchDetails);
				IL_AD:
				IL_AF:
				goto IL_156;
				IL_130:
				RobotImageLoader.StartIndexRFID = (long)arg_130_0;
				RobotImageLoader.NewRecord = 0;
				IL_13C:
				this.MovePagePhotoId(this.searchDetails);
				IL_149:
				IL_14A:
				goto IL_156;
				IL_14E:
				this.PrevRec();
				IL_156:
				if (false)
				{
					goto IL_149;
				}
				if (false)
				{
					goto IL_A0;
				}
			}
			finally
			{
				MemoryManagement.FlushMemory();
				while (2 == 0)
				{
				}
			}
		}

		private void GetMktImgInfo()
		{
			try
			{
				ConfigBusiness configBusiness = new ConfigBusiness();
				List<long> objList = new List<long>();
				objList.Add(24L);
				objList.Add(25L);
				List<iMIXConfigurationInfo> list;
				do
				{
					objList.Add(48L);
					objList.Add(75L);
					objList.Add(126L);
					list = (from o in configBusiness.GetNewConfigValues(LoginUser.SubStoreId)
					where objList.Contains(o.IMIXConfigurationMasterId)
					select o).ToList<iMIXConfigurationInfo>();
					if (list == null)
					{
						goto IL_B2;
					}
				}
				while (7 == 0);
				bool arg_B4_0 = list.Count <= 0;
				goto IL_B3;
				IL_B2:
				arg_B4_0 = true;
				IL_B3:
				if (!arg_B4_0)
				{
					int i = 0;
					IL_25C:
					while (i < list.Count)
					{
						if (5 == 0)
						{
							goto IL_29E;
						}
						long iMIXConfigurationMasterId = list[i].IMIXConfigurationMasterId;
						long arg_DF_0 = iMIXConfigurationMasterId;
						while (arg_DF_0 > 48L)
						{
							long arg_120_0;
							long arg_ED_0 = arg_DF_0 = (arg_120_0 = iMIXConfigurationMasterId);
							if (!false)
							{
								int arg_EC_0;
								int expr_11C = arg_EC_0 = 75;
								if (expr_11C != 0)
								{
									long arg_120_1 = (long)expr_11C;
									while (arg_120_0 != arg_120_1)
									{
										long expr_122 = arg_120_0 = iMIXConfigurationMasterId;
										long expr_126 = arg_120_1 = 126L;
										if (!false)
										{
											if (expr_122 != expr_126)
											{
												goto IL_257;
											}
											this.AngleValue = ((list[i].ConfigurationValue != null) ? Convert.ToInt32(list[i].ConfigurationValue) : 0);
											goto IL_257;
										}
									}
									this.isSingleScreenPreview = (list[i].ConfigurationValue != null && list[i].ConfigurationValue.ToBoolean(false));
								}
								else
								{
									IL_EC:
									if (arg_ED_0 >= (long)arg_EC_0)
									{
										switch ((int)(iMIXConfigurationMasterId - 24L))
										{
										case 0:
											this.MktImgPath = list[i].ConfigurationValue;
											break;
										case 1:
											this.mktImgTime = ((list[i].ConfigurationValue != null) ? list[i].ConfigurationValue.ToInt32(false) : 10) * 1000;
											break;
										default:
											IL_106:
											if (iMIXConfigurationMasterId == 48L)
											{
												bool arg_1D9_0;
												if (list[i].ConfigurationValue == null)
												{
													arg_1D9_0 = false;
												}
												else
												{
													if (8 == 0)
													{
														goto IL_27F;
													}
													arg_1D9_0 = Convert.ToBoolean(list[i].ConfigurationValue);
												}
												bool flag = arg_1D9_0;
												this.stkEditVideo.Visibility = (flag ? Visibility.Visible : Visibility.Collapsed);
												this.stkAdvVideoEdit.Visibility = (flag ? Visibility.Visible : Visibility.Collapsed);
												this.stackVideoSearchTypes.Visibility = (flag ? Visibility.Visible : Visibility.Collapsed);
												this.stkVideoOverlay.Visibility = (flag ? Visibility.Visible : Visibility.Collapsed);
											}
											break;
										}
									}
								}
								IL_257:
								i++;
								goto IL_25C;
							}
						}
						if (iMIXConfigurationMasterId <= 25L)
						{
							long arg_ED_0 = iMIXConfigurationMasterId;
							int arg_EC_0 = 24;
							//goto IL_EC;
						}
						//goto IL_106;
					}
				}
				if (!this.isSingleScreenPreview)
				{
					this.txtpreview.Text = "Preview Photo";
					goto IL_2B1;
				}
				IL_27F:
				this.txtpreview.Text = "Preview & Flip";
				this.grdThumbPreview.Visibility = Visibility.Visible;
				IL_29E:
				IL_2B1:;
			}
			catch (Exception serviceException)
			{
				do
				{
					string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
					ErrorHandler.ErrorHandler.LogFileWrite(message);
				}
				while (7 == 0);
				if (-1 != 0)
				{
				}
			}
		}

		private void PastingHandler(object sender, DataObjectPastingEventArgs e)
		{
			bool arg_5A_0;
			bool expr_8B = arg_5A_0 = e.DataObject.GetDataPresent(typeof(string));
			if (5 != 0)
			{
				bool flag = !expr_8B;
				bool arg_27_0 = flag;
				while (!arg_27_0)
				{
					string text;
					do
					{
						text = (string)e.DataObject.GetData(typeof(string));
					}
					while (false);
					bool expr_4D = arg_27_0 = SearchResult.IsTextAllowed(text);
					if (!false)
					{
						flag = expr_4D;
						IL_56:
						if (!false)
						{
							arg_5A_0 = flag;
							goto IL_5A;
						}
						return;
					}
				}
				e.CancelCommand();
				if (5 != 0)
				{
					return;
				}
				//goto IL_56;
			}
			IL_5A:
			if (!arg_5A_0)
			{
				e.CancelCommand();
			}
		}

		private static bool IsTextAllowed(string text)
		{
			bool arg_29_0;
			bool flag;
			while (true)
			{
				while (!false)
				{
					Regex expr_2A = new Regex("[^0-9.-]+");
					Regex regex;
					if (4 != 0)
					{
						regex = expr_2A;
					}
					while (true)
					{
						bool expr_16 = arg_29_0 = !regex.IsMatch(text);
						if (-1 == 0)
						{
							return arg_29_0;
						}
						if (5 != 0)
						{
							flag = expr_16;
						}
						if (false)
						{
							break;
						}
						if (2 != 0)
						{
							goto Block_3;
						}
					}
				}
			}
			Block_3:
			arg_29_0 = flag;
			return arg_29_0;
		}

		private void bttnLogin_Enter(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (4 != 0)
			{
				bool arg_0C_0 = e.Key == Key.Return;
				bool arg_18_0;
				do
				{
					bool expr_0C = arg_0C_0 = (arg_18_0 = !arg_0C_0);
					if (!false)
					{
						bool flag = expr_0C;
						arg_18_0 = (arg_0C_0 = flag);
					}
				}
				while (3 == 0);
				if (!arg_18_0)
				{
					if (6 != 0 && !false)
					{
						this.SearchImages();
					}
				}
			}
		}

		private void SearchImages()
		{
            //int rfidSearch = RobotImageLoader._rfidSearch;
            //RobotImageLoader._rfidSearch = 0;
            //long startIndexRFID = RobotImageLoader.StartIndexRFID;
            //RobotImageLoader.StartIndexRFID = 0L;
            //bool flag;
            //while (true)
            //{
            //    if (this.txtImageId.Text.Trim() == "")
            //    {
            //        this.txtImageId.Text = "0";
            //    }
            //    if (this.txtImageId.Text.Trim() == "")
            //    {
            //        this.txtImageId.Text = "0";
            //    }
            //    this.SetMediaType();
            //    if (string.IsNullOrEmpty(this.txtImageId.Text.Trim()))
            //    {
            //        return;
            //    }
            //    string rFID = RobotImageLoader.RFID;
            //    RobotImageLoader.RFID = this.txtImageId.Text;
            //    while (true)
            //    {
            //        string searchCriteria = RobotImageLoader.SearchCriteria;
            //        RobotImageLoader.SearchCriteria = "PhotoId";
            //        this.pagename = "";
            //        flag = !(this.txtImageId.Text != "0");
            //        bool arg_268_0;
            //        bool expr_10B = arg_268_0 = flag;
            //        if (4 == 0)
            //        {
            //            goto IL_268;
            //        }
            //        if (expr_10B)
            //        {
            //            RobotImageLoader.IsZeroSearchNeeded = true;
            //            RobotImageLoader.currentCount = 0;
            //            goto IL_305;
            //        }
            //        string photoId;
            //        List<PhotoInfo> source;
            //        if (5 != 0)
            //        {
            //            photoId = RobotImageLoader.PhotoId;
            //            RobotImageLoader.PhotoId = this.txtImageId.Text;
            //            PhotoBusiness photoBusiness = new PhotoBusiness();
            //            source = (from t in photoBusiness.GetAllPhotosforSearch(LoginUser.DefaultSubstores, this.txtImageId.Text.Trim().ToInt64(false), LoginUser.PageCountGrid, LoginUser.IsPhotographerSerailSearchActive, RobotImageLoader.StartIndexRFID, RobotImageLoader._rfidSearch, this.NewReord, out this.MaxPhotoIdCriteria, out this.MinPhotoIdCriteria, RobotImageLoader.MediaTypes)
            //            orderby t.DG_Photos_pkey descending
            //            select t).ToList<PhotoInfo>();
            //            goto IL_1B5;
            //        }
            //        break;
            //        IL_283:
            //        RobotImageLoader.PhotoId = photoId;
            //        if (6 == 0)
            //        {
            //            continue;
            //        }
            //        if (!false)
            //        {
            //            goto Block_16;
            //        }
            //        IL_216:
            //        List<PhotoInfo> list;
            //        flag = (list.Count != 0);
            //        if (flag)
            //        {
            //            goto IL_2DA;
            //        }
            //        if (false)
            //        {
            //            goto IL_283;
            //        }
            //        //string message = "Unable to find the Item with ID '" + this.txtImageId.Text + "'.\nDo you wish to see the images that were found?";
            //        //bool flag2 = this.MsgBox.ShowHandlerDialog(message, DigiMessageBox.DialogType.Confirm);
            //        //if (!false)
            //        //{
            //        //    flag = flag2;
            //        //    arg_268_0 = flag;
            //        //    goto IL_268;
            //        //}
            //        goto IL_305;
            //        IL_208:
            //        goto IL_216;
            //        IL_1FD:
            //        goto IL_208;
            //        IL_1B5:
            //        list = new List<PhotoInfo>();
            //        if (LoginUser.IsPhotographerSerailSearchActive)
            //        {
            //            list = source.ToList<PhotoInfo>();
            //            goto IL_216;
            //        }
            //        if (RobotImageLoader._rfidSearch == 0)
            //        {
            //            list = (from T in source
            //            where T.DG_Photos_RFID == this.txtImageId.Text
            //            select T).ToList<PhotoInfo>();
            //            goto IL_1FD;
            //        }
            //        list = source.ToList<PhotoInfo>();
            //        goto IL_208;
            //        IL_268:
            //        if (!arg_268_0)
            //        {
            //            RobotImageLoader._rfidSearch = rfidSearch;
            //            RobotImageLoader.StartIndexRFID = startIndexRFID;
            //            RobotImageLoader.RFID = rFID;
            //            RobotImageLoader.SearchCriteria = searchCriteria;
            //            goto IL_283;
            //        }
            //        goto IL_2AC;
            //        IL_305:
            //        if (8 == 0)
            //        {
            //            goto IL_2E4;
            //        }
            //        this.grdSelectAll.Visibility = Visibility.Visible;
            //        this.SPSelectAll.Visibility = Visibility.Visible;
            //        if (!false)
            //        {
            //            goto IL_329;
            //        }
            //        goto IL_1B5;
            //    }
            //}
            //Block_16:
            //this.txtImageId.Text = "";
            //return;
            //IL_2AC:
            //this.txtImageId.Text = "0";
            //RobotImageLoader.RFID = this.txtImageId.Text;
            //RobotImageLoader.IsZeroSearchNeeded = true;
            //RobotImageLoader.currentCount = 0;
            //IL_2DA:
            //flag = (RobotImageLoader._objnewincrement == null);
            //IL_2E4:
            //if (!flag)
            //{
            //    RobotImageLoader._objnewincrement.Clear();
            //}
            //IL_329:
            //this.LoadWindow();
            //this.txtImageId.Clear();
		}

		private void SetMediaType()
		{
			bool? isChecked;
			int arg_72_0;
			bool arg_6F_0;
			bool flag;
			int arg_6B_0;
			if (3 != 0)
			{
				isChecked = this.rdbtnPhoto.IsChecked;
				int arg_2D_0;
				arg_72_0 = ((!isChecked.GetValueOrDefault()) ? (arg_2D_0 = 0) : (arg_2D_0 = (isChecked.HasValue ? 1 : 0)));
				if (false)
				{
					goto IL_72;
				}
				bool expr_2D = arg_6F_0 = (arg_2D_0 == 0);
				if (3 == 0)
				{
					goto IL_6F;
				}
				flag = expr_2D;
				if (!flag)
				{
					RobotImageLoader.MediaTypes = 1;
					return;
				}
				if (7 == 0)
				{
					goto IL_6E;
				}
				isChecked = this.rdbtnVideo.IsChecked;
				if (!isChecked.GetValueOrDefault())
				{
					if (8 != 0)
					{
						arg_6B_0 = 0;
						goto IL_69;
					}
					goto IL_6E;
				}
			}
			arg_6B_0 = (isChecked.HasValue ? 1 : 0);
			IL_69:
			flag = (arg_6B_0 == 0);
			IL_6E:
			arg_6F_0 = flag;
			IL_6F:
			if (arg_6F_0)
			{
				RobotImageLoader.MediaTypes = 0;
				return;
			}
			arg_72_0 = 2;
			IL_72:
			RobotImageLoader.MediaTypes = arg_72_0;
		}

		private void SetMessageText(string caseValue)
		{
			if (!false)
			{
				if (caseValue != null)
				{
					if (!(caseValue == "Grouped"))
					{
						bool arg_4F_0;
						bool expr_2AE = arg_4F_0 = (caseValue == "PrintGrouped");
						if (!false)
						{
							if (!expr_2AE)
							{
								arg_4F_0 = (caseValue == "EditPrintGrouped");
							}
							else
							{
								if (false)
								{
									goto IL_1D5;
								}
								this.txtSelectImages.Visibility = Visibility.Visible;
								if (6 != 0)
								{
									this.txtSelectedImages.Visibility = Visibility.Collapsed;
									goto IL_D9;
								}
								return;
							}
						}
						if (!arg_4F_0)
						{
							if (!(caseValue == "EditPrintGroupedView"))
							{
								return;
							}
							this.txtSelectImages.Visibility = Visibility.Visible;
						}
						else
						{
							this.txtSelectImages.Visibility = Visibility.Visible;
							if (!false)
							{
								this.txtSelectedImages.Visibility = Visibility.Collapsed;
								if (!false)
								{
									this.txtSelectImages.Text = "Print Grouped : " + this.lstImages.Items.Count.ToString();
									goto IL_1D5;
								}
								goto IL_D9;
							}
						}
						this.txtSelectedImages.Visibility = Visibility.Collapsed;
						int num = (from p in RobotImageLoader.PrintImages
						join g in RobotImageLoader.GroupImages on p.PhotoId equals g.PhotoId
						select p.PhotoId).Count<int>();
						this.txtSelectImages.Text = "Print Grouped : " + num.ToString();
						return;
						IL_D9:
						int num2 = (from groupImages in RobotImageLoader.GroupImages
						join printImages in RobotImageLoader.PrintImages on groupImages.PhotoId equals printImages.PhotoId
						select groupImages).Count<LstMyItems>();
						this.txtSelectImages.Text = "Selected : " + num2.ToString() + "/" + RobotImageLoader.GroupImages.Count.ToString();
						IL_1D5:;
					}
					else
					{
						this.txtSelectImages.Visibility = Visibility.Collapsed;
						this.txtSelectedImages.Visibility = Visibility.Visible;
						if (2 != 0)
						{
							this.txtSelectedImages.Text = "Grouped : " + RobotImageLoader.GroupImages.Count;
						}
					}
				}
			}
		}

		private void btnSearchImage_Click(object sender, RoutedEventArgs e)
		{
			if (!false)
			{
				this.Ok.IsEnabled = false;
				if (false)
				{
					return;
				}
				this.MediaStop();
			}
			do
			{
				this.SearchImages();
				this.Ok.IsEnabled = true;
			}
			while (-1 == 0);
		}

		private void OpenAssociateWindow()
		{
            //do
            //{
            //    this.AddUserControlAssociateImage();
            //    if (5 == 0)
            //    {
            //        goto IL_31;
            //    }
            //    this.ModalDialogParent.IsEnabled = false;
            //    this.uctlAssociateImage.Visibility = Visibility.Visible;
            //}
            //while (false);
            //this.uctlAssociateImage.txtQRCode.Focus();
            //IL_31:
            //FocusManager.SetFocusedElement(this, this.uctlAssociateImage.txtQRCode);
            //if (6 != 0)
            //{
            //    Keyboard.Focus(this.uctlAssociateImage.txtQRCode);
            //}
		}

		private void btnQRSearch_Click(object sender, RoutedEventArgs e)
		{
			this.vwGroup.Text = "View Group";
			this.OpenAssociateWindow();
		}

		private void LoadPendingBurnOrders()
		{
			this.lblPendingOrders.Text = this.GetPendingBurnOrders();
		}

		private void btnPendingOrders_Click(object sender, RoutedEventArgs e)
		{
			this.InitiateBurnOrders();
		}

		private void InitiateBurnOrders()
		{
			while (!BurnOrderElements.isExecuting)
			{
				this.closeExistingBurnOrderWindows();
				//BurnMediaOrderList burnMediaOrderList = new BurnMediaOrderList();
                string text = ""; //burnMediaOrderList.FetchNextOrderDetails();
				if (!false)
				{
					bool flag = !(text == "\r\nNo active orders found!");
					bool arg_4D_0 = flag;
					while (arg_4D_0)
					{
						if (!true)
						{
							goto IL_D7;
						}
						MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show(text, "iMIX", MessageBoxButton.YesNo, MessageBoxImage.Question);
						flag = (messageBoxResult != MessageBoxResult.Yes);
						bool expr_7D = arg_4D_0 = flag;
						if (!false)
						{
							if (!expr_7D)
							{
								while (true)
								{
									while (true)
									{
										//burnMediaOrderList.Width = 0.0;
										if (!false)
										{
                                            //burnMediaOrderList.Height = 0.0;
                                            //burnMediaOrderList.WindowState = WindowState.Minimized;
                                            //burnMediaOrderList.Show();
                                            //burnMediaOrderList.Hide();
											if (!false)
											{
												goto Block_6;
											}
										}
									}
								}
								Block_6:
								//burnMediaOrderList._isAutoStart = true;
								//burnMediaOrderList.AutoExecuteOrders();
								if (!false)
								{
								}
							}
							IL_D3:
							return;
						}
					}
					System.Windows.MessageBox.Show(text, "iMIX", MessageBoxButton.OK, MessageBoxImage.Asterisk);
					//goto IL_D3;
					IL_D7:
					System.Windows.MessageBox.Show("Orders are already being processed!", "iMIX", MessageBoxButton.OK, MessageBoxImage.Hand);
					return;
				}
			}
			//goto IL_D7;
		}

		private string GetPendingBurnOrders()
		{
			int num = 0;
			int arg_39_0;
			int expr_08 = arg_39_0 = 0;
			int num2=0;
            List<BurnOrderInfo> pendingBurnOrders = new List<BurnOrderInfo>(); ;
			if (expr_08 == 0)
			{
				num2 = expr_08;
				OrderBusiness orderBusiness = new OrderBusiness();
				pendingBurnOrders = orderBusiness.GetPendingBurnOrders(true);
				bool flag = pendingBurnOrders == null;
				arg_39_0 = (flag ? 1 : 0);
			}
			if (arg_39_0 == 0)
			{
				List<BurnOrderInfo>.Enumerator enumerator = pendingBurnOrders.GetEnumerator();
				try
				{
					while (true)
					{
						while (enumerator.MoveNext())
						{
							BurnOrderInfo current = enumerator.Current;
							if (current.Status != 1)
							{
								if (4 != 0)
								{
								}
								if (this.isLocalOrder(current.OrderNumber, current.ProductType))
								{
									int productType;
									if (5 != 0)
									{
										productType = current.ProductType;
									}
									if (true)
									{
										bool flag = productType != 36 && productType != 97;
										if (!false && !flag)
										{
											num++;
										}
										else
										{
											num2++;
										}
									}
								}
							}
						}
						break;
					}
				}
				finally
				{
					do
					{
						((IDisposable)enumerator).Dispose();
					}
					while (false);
				}
			}
			string result = string.Concat(new string[]
			{
				"USB(",
				num.ToString(),
				") CD(",
				num2.ToString(),
				")"
			});
			if (!false)
			{
			}
			return result;
		}

		private bool isLocalOrder(string OrderNumber, int ProdType)
		{
			string path = "";
			if (false)
			{
				goto IL_A0;
			}
			bool arg_E3_0;
			bool expr_18 = arg_E3_0 = (ProdType == 35);
			if (false)
			{
				return arg_E3_0;
			}
			if (expr_18)
			{
				path = Environment.CurrentDirectory + "\\DigiOrderdImages\\CDOrders\\" + OrderNumber + "\\CD\\";
				goto IL_CD;
			}
			bool arg_5B_0 = ProdType != 36;
			IL_5B:
			if (!arg_5B_0)
			{
				path = Environment.CurrentDirectory + "\\DigiOrderdImages\\USBOrders\\" + OrderNumber + "\\USB\\";
				goto IL_CD;
			}
			int arg_7A_0 = ProdType;
			int arg_7A_1 = 96;
			IL_7A:
			if (arg_7A_0 == arg_7A_1)
			{
				path = Environment.CurrentDirectory + "\\DigiOrderdImages\\CDOrders\\" + OrderNumber + "\\VideoCD\\";
				if (!false)
				{
					goto IL_CD;
				}
				goto IL_DE;
			}
			IL_A0:
			int expr_A3 = arg_7A_0 = ((ProdType == 97) ? 1 : 0);
			int expr_A6 = arg_7A_1 = 0;
			if (expr_A6 != 0)
			{
				goto IL_7A;
			}
			bool flag = expr_A3 == expr_A6;
			bool expr_AC = arg_5B_0 = flag;
			if (6 == 0)
			{
				goto IL_5B;
			}
			if (!expr_AC)
			{
				if (!false)
				{
				}
				path = Environment.CurrentDirectory + "\\DigiOrderdImages\\USBOrders\\" + OrderNumber + "\\VideoUSB\\";
			}
			IL_CD:
			bool flag2;
			if (Directory.Exists(path))
			{
				flag2 = true;
				goto IL_E2;
			}
			IL_DE:
			flag2 = false;
			IL_E2:
			arg_E3_0 = flag2;
			return arg_E3_0;
		}

		private void closeExistingBurnOrderWindows()
		{
			foreach (Window window in System.Windows.Application.Current.Windows)
			{
				if (window.Title == "BurnMedia")
				{
					window.Close();
				}
			}
		}

		private void txtImageId_TextChanged(object sender, TextChangedEventArgs e)
		{
            //if (this.txtImageId.Text.Contains('.'))
            //{
            //    this.txtImageId.Text = this.txtImageId.Text.Replace(".", "");
            //}
            //if (this.txtImageId.Text.Contains('-'))
            //{
            //    this.txtImageId.Text = this.txtImageId.Text.Replace("-", "");
            //}
            //this.txtImageId.CaretIndex = this.txtImageId.Text.Length;
		}

		private void MediaStop()
		{
			bool arg_4D_0;
			bool flag;
			while (true)
			{
                bool expr_09 = arg_4D_0 = false;//(this.mplayer == null);
				if (false)
				{
					goto IL_4D;
				}
				if (expr_09)
				{
					goto IL_33;
				}
				IL_15:
				while (!false)
				{
					//MLMediaPlayer expr_1A = this.mplayer;
					if (true)
					{
						//expr_1A.MediaStop();
					}
					//this.mplayer = null;
					if (7 == 0)
					{
						//goto IL_4F;
					}
					if (!false)
					{
						goto IL_33;
					}
				}
				continue;
				IL_33:
				this.gdMediaPlayer.Children.Clear();
                flag = false; //(this.clientWin == null);
				if (!false)
				{
					break;
				}
				goto IL_15;
			}
			arg_4D_0 = flag;
			IL_4D:
			if (arg_4D_0)
			{
				return;
			}
			//IL_4F:
			//this.clientWin.StopMediaPlay();
		}

		private void MediaPlay()
		{
			if (false || -1 == 0)
			{
				goto IL_13;
			}
        IL_07:
            bool flag = false; //this.mplayer == null;
			IL_13:
			if (6 == 0)
			{
				goto IL_07;
			}
			if (!flag)
			{
				this.MediaStop();
			}
			IL_20:
			//this.mplayer = new MLMediaPlayer(SearchResult.vsMediaFileName, "Search", true);
			FrameworkElement expr_37 = this.gdMediaPlayer;
			if (3 != 0)
			{
				expr_37.BeginInit();
			}
			if (5 == 0)
			{
				goto IL_20;
			}
			//this.gdMediaPlayer.Children.Add(this.mplayer);
			if (!false)
			{
				this.gdMediaPlayer.EndInit();
				return;
			}
			goto IL_20;
		}

		private void btnEditVideo_Click(object sender, RoutedEventArgs e)
		{
			if (this.vwGroup.Text == "View All")
			{
				RobotImageLoader.isGroup = true;
			}
			else
			{
				RobotImageLoader.isGroup = false;
			}
			SearchResult.vsMediaFileName = string.Empty;
			try
			{
				bool flag = false;
				Window window = null;
                //using (IEnumerator enumerator = System.Windows.Application.Current.Windows.GetEnumerator())
                //{
                //    while (true)
                //    {
                //        IL_A2:
                //        bool flag2 = enumerator.MoveNext();
                //        bool arg_AD_0 = flag2;
                //        IL_AD:
                //        while (arg_AD_0)
                //        {
                //            while (true)
                //            {
                //                Window window2 = (Window)enumerator.Current;
                //                if (!(window2.Title == "VideoEditor"))
                //                {
                //                    break;
                //                }
                //                while (true)
                //                {
                //                    //window = (window2 as VideoEditor);
                //                    bool expr_96 = arg_AD_0 = true;
                //                    if (!expr_96)
                //                    {
                //                        goto IL_AD;
                //                    }
                //                    flag = expr_96;
                //                    if (8 == 0)
                //                    {
                //                        break;
                //                    }
                //                    if (!false)
                //                    {
                //                        goto IL_A1;
                //                    }
                //                }
                //            }
                //            IL_A1:
                //            goto IL_A2;
                //        }
                //        break;
                //    }
                //}
				bool arg_F1_0;
				if (this.lstImages.SelectedItem != null && RobotImageLoader.PrintImages.Count > 0)
				{
					arg_F1_0 = false;
					goto IL_F0;
				}
				int arg_EB_0 = flag ? 1 : 0;
				IL_EA:
				arg_F1_0 = (arg_EB_0 == 0);
				IL_F0:
				if (!arg_F1_0)
				{
					if (false)
					{
						goto IL_11A;
					}
					this.MediaStop();
					if (window == null)
					{
						goto IL_11A;
					}
					//VideoEditor videoEditor = (VideoEditor)window;
					IL_118:
					goto IL_122;
					IL_11A:
					//videoEditor = new VideoEditor();
					IL_122:
					bool arg_153_0 = ((this.vwGroup.Text == "View All") ? (arg_EB_0 = 0) : (arg_EB_0 = ((!(this.pagename == "Saveback")) ? 1 : 0))) != 0;
					if (false)
					{
						goto IL_EA;
					}
					if (!arg_153_0)
					{
						SearchResult.itemsNotPrinted = new List<LstMyItems>();
						using (List<LstMyItems>.Enumerator enumerator2 = RobotImageLoader.GroupImages.GetEnumerator())
						{
							while (true)
							{
								if (!enumerator2.MoveNext())
								{
									if (6 != 0)
									{
										break;
									}
								}
								else
								{
									if (!false)
									{
										LstMyItems itx = enumerator2.Current;
									}
								}
                                //LstMyItems lstMyItems = (from xs in RobotImageLoader.PrintImages
                                //where xs.PhotoId == c__DisplayClass.itx.PhotoId
                                //select xs).FirstOrDefault<LstMyItems>();
                                //if (lstMyItems == null)
                                //{
                                //    SearchResult.itemsNotPrinted.Add(c__DisplayClass.itx);
                                //}
							}
						}
					}
					if (this.pagename == "Saveback")
					{
						if (4 == 0)
						{
							goto IL_118;
						}
						//videoEditor.IsGoupped = "View All";
					}
					else
					{
						//videoEditor.IsGoupped = this.vwGroup.Text;
					}
					ContantValueForMainWindow.RedEyeSize = 0.0105;
                    //videoEditor.WindowState = WindowState.Maximized;
                    //videoEditor.WindowStyle = WindowStyle.None;
                    //videoEditor.Show();
					base.Hide();
				}
				else
				{
					System.Windows.MessageBox.Show("No images or videos selected!", "DigiPhoto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				}
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
			finally
			{
			}
		}

		private void btnWithPreviewActive_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			e.Handled = true;
		}

		private void MovePage(SearchDetailInfo searchDetails)
		{
			int arg_13B_0;
			bool flag;
			if (!false)
			{
				if (false)
				{
					goto IL_145;
				}
				bool arg_19E_0 = ((RobotImageLoader.robotImages == null || !RobotImageLoader.Is16ImgViewActive) ? (arg_13B_0 = 1) : (arg_13B_0 = (RobotImageLoader.Is9ImgViewActive ? 1 : 0))) != 0;
				if (false)
				{
					goto IL_13B;
				}
				flag = arg_19E_0;
				if (!flag)
				{
					if (false)
					{
						goto IL_86;
					}
					this.ImageSize(16);
				}
				else
				{
					this.ImageSize(9);
				}
				bool arg_1D4_0;
				if (RobotImageLoader.robotImages != null)
				{
					int arg_6B_0 = RobotImageLoader.robotImages.Count;
					int arg_6B_1 = 0;
					int expr_6B;
					int expr_6E;
					do
					{
						expr_6B = (arg_6B_0 = ((arg_6B_0 > arg_6B_1) ? 1 : 0));
						expr_6E = (arg_6B_1 = 0);
					}
					while (expr_6E != 0);
					arg_1D4_0 = (expr_6B == expr_6E);
				}
				else
				{
					arg_1D4_0 = true;
				}
				flag = arg_1D4_0;
				if (flag)
				{
					goto IL_176;
				}
				IL_86:
				flag = (searchDetails.NewRecord != 0);
				if (!flag)
				{
					LstMyItems lstMyItems = RobotImageLoader.robotImages.FirstOrDefault((LstMyItems o) => (long)o.PhotoId == RobotImageLoader.MaxPhotoIdCriteria);
					flag = (lstMyItems == null);
					if (flag)
					{
						goto IL_175;
					}
					searchDetails.NewRecord = 1;
					searchDetails.StartIndex = RobotImageLoader.MaxPhotoIdCriteria + 1L;
					if (!false)
					{
						System.Windows.MessageBox.Show("No more records found!", "DigiPhoto i-Mix", MessageBoxButton.OK, MessageBoxImage.Asterisk);
						this.LoadImageCriteria();
						return;
					}
					goto IL_18A;
				}
			}
			LstMyItems lstMyItems2 = RobotImageLoader.robotImages.FirstOrDefault((LstMyItems o) => (long)o.PhotoId == RobotImageLoader.MinPhotoIdCriteria);
			flag = (lstMyItems2 == null);
			IL_13A:
			arg_13B_0 = (flag ? 1 : 0);
			IL_13B:
			if (arg_13B_0 != 0)
			{
				goto IL_175;
			}
			searchDetails.NewRecord = 0;
			IL_145:
			if (!false)
			{
				searchDetails.StartIndex = RobotImageLoader.MinPhotoIdCriteria - 1L;
				System.Windows.MessageBox.Show("No more records found!", "DigiPhoto i-Mix", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				this.LoadImageCriteria();
				return;
			}
			goto IL_13A;
			IL_175:
			IL_176:
			RobotImageLoader.LoadImages(searchDetails);
			this.LoadImages();
			this.FillImageList();
			IL_18A:
			this.CheckSelectAllGroup();
			RobotImageLoader.ViewGroupedImagesCount.Clear();
		}

		private void LoadImageCriteria()
		{
			int arg_16_0;
			int expr_5C = arg_16_0 = this.lstImages.Items.Count;
			int arg_16_1;
			int expr_0D = arg_16_1 = 0;
			if (expr_0D == 0)
			{
				arg_16_1 = expr_0D;
				if (expr_0D == 0)
				{
					arg_16_0 = ((expr_5C == expr_0D) ? 1 : 0);
					arg_16_1 = 0;
				}
			}
			if (arg_16_0 == arg_16_1)
			{
				goto IL_4E;
			}
			this.FillImageList();
			this.CheckSelectAllGroup();
			IL_29:
			RobotImageLoader.ViewGroupedImagesCount.Clear();
			RobotImageLoader.LoadImages(this.searchDetails);
			IL_40:
			this.LoadImages();
			if (!false)
			{
			}
			if (3 == 0)
			{
				goto IL_29;
			}
			IL_4E:
			if (true)
			{
				return;
			}
			goto IL_40;
		}

		private void LoadImagePhotoId()
		{
			int arg_16_0;
			int expr_5C = arg_16_0 = this.lstImages.Items.Count;
			int arg_16_1;
			int expr_0D = arg_16_1 = 0;
			if (expr_0D == 0)
			{
				arg_16_1 = expr_0D;
				if (expr_0D == 0)
				{
					arg_16_0 = ((expr_5C == expr_0D) ? 1 : 0);
					arg_16_1 = 0;
				}
			}
			if (arg_16_0 == arg_16_1)
			{
				goto IL_4E;
			}
			this.FillImageList();
			this.CheckSelectAllGroup();
			IL_29:
			RobotImageLoader.ViewGroupedImagesCount.Clear();
			RobotImageLoader.LoadImages(this.searchDetails);
			IL_40:
			this.LoadImages();
			if (!false)
			{
			}
			if (3 == 0)
			{
				goto IL_29;
			}
			IL_4E:
			if (true)
			{
				return;
			}
			goto IL_40;
		}

		private void txtAmountEntered_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = !SearchResult.IsTextAllowed(e.Text);
		}

		private void btnCaptureInfo_Click(object sender, RoutedEventArgs e)
		{
			LstMyItems lstMyItems;
			while (4 != 0)
			{
				int arg_E0_0;
				bool arg_16D_0;
				if (this.lstImages.Items == null)
				{
					arg_16D_0 = ((arg_E0_0 = 1) != 0);
					goto IL_38;
				}
				int arg_71_0;
				int expr_2D = arg_71_0 = ((this.lstImages.Items.Count > 0) ? 1 : 0);
				int arg_71_1;
				int expr_30 = arg_71_1 = 0;
				if (expr_30 == 0)
				{
					arg_16D_0 = ((arg_E0_0 = ((expr_2D == expr_30) ? 1 : 0)) != 0);
					goto IL_38;
				}
				goto IL_71;
            IL_A6:
                int arg_B2_0 = 0; //lstMyItems.PhotoId;
				if (false)
				{
					IL_140:
					return;
				}
				int pkey = arg_B2_0;
				List<PhotoCaptureInfo> list = new List<PhotoCaptureInfo>();
				bool flag;
				if (4 != 0)
				{
					list = new PhotoBusiness().GetphotoCapturedetails(pkey);
					flag = (list == null || list.Count <= 0);
					arg_E0_0 = (flag ? 1 : 0);
					goto IL_E0;
				}
				continue;
				IL_71:
				if (arg_71_0 != arg_71_1)
				{
					//this.imageInfo.IsVideo = true;
					this.gdMediaPlayer.Visibility = Visibility.Collapsed;
				}
				else
				{
					//this.imageInfo.IsVideo = false;
				}
				//RobotImageLoader.curItem = lstMyItems;
				goto IL_A6;
				IL_E0:
				if (arg_E0_0 != 0)
				{
					break;
				}
				if (!false)
				{
					//this.imageInfo.ShowHandlerDialog(list.FirstOrDefault<PhotoCaptureInfo>());
					break;
				}
				goto IL_A6;
				IL_38:
				if (false)
				{
					goto IL_E0;
				}
				flag = arg_16D_0;
				bool expr_173 = (arg_E0_0 = (flag ? 1 : 0)) != 0;
				if (false)
				{
					goto IL_E0;
				}
				if (!expr_173)
				{
					lstMyItems = (LstMyItems)this.lstImages.SelectedItem;
					arg_71_0 = lstMyItems.MediaType;
					arg_71_1 = 1;
					goto IL_71;
				}
				return;
			}
			//this.lstImages.SelectedItem = lstMyItems;
			this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
			((ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem)).Focus();
			//goto IL_140;
		}

		private void rdbtPVBoth_Checked(object sender, RoutedEventArgs e)
		{
			while (!false)
			{
				bool expr_149;
				do
				{
					this.searchConfig = SearchResult.SearchTypeConfig.ImageVideo;
					RobotImageLoader.MediaTypes = 3;
					bool flag = !(this.vwGroup.Text == "View All");
					bool arg_3E_0 = flag;
					while (arg_3E_0)
					{
						expr_149 = (arg_3E_0 = (-1 != 0));
						if (expr_149)
						{
							goto Block_4;
						}
					}
					RobotImageLoader.robotImages.Clear();
					List<LstMyItems>.Enumerator enumerator = RobotImageLoader.GroupImages.GetEnumerator();
					try
					{
						while (true)
						{
							bool arg_FD_0;
							bool expr_F3 = arg_FD_0 = enumerator.MoveNext();
							if (!false)
							{
								flag = expr_F3;
								arg_FD_0 = flag;
							}
							if (!arg_FD_0)
							{
								break;
							}
							LstMyItems item = enumerator.Current;
							LstMyItems lstMyItems = (from t in RobotImageLoader.PrintImages
							where t.PhotoId == item.PhotoId
							select t).FirstOrDefault<LstMyItems>();
							if (lstMyItems != null)
							{
								item.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
							}
							else
							{
								item.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
							}
							RobotImageLoader.robotImages.Add(item);
						}
					}
					finally
					{
						((IDisposable)enumerator).Dispose();
						if (true)
						{
						}
					}
					this.LoadImages();
				}
				while (false);
				this.FillImageList();
				this.CheckForAllImgSelectToPrint();
				if (5 != 0)
				{
					this.SetMessageText("PrintGrouped");
					return;
				}
				continue;
				Block_4:
				RobotImageLoader.MinPhotoIdCriteria = (expr_149 ? 1L : 0L);
				RobotImageLoader.IsZeroSearchNeeded = true;
				RobotImageLoader.currentCount = 0;
				RobotImageLoader.LoadImages();
				this.LoadImages();
				this.FillImageList();
				IL_174:
				this.CheckSelectAllGroup();
				break;
			}
			if (7 != 0)
			{
				return;
			}
			//goto IL_174;
		}

		private void rdbtnVideo_Checked(object sender, RoutedEventArgs e)
		{
			this.searchConfig = SearchResult.SearchTypeConfig.Video;
			RobotImageLoader.MediaTypes = 2;
			if (!(this.vwGroup.Text == "View All"))
			{
				RobotImageLoader.MinPhotoIdCriteria = -1L;
				RobotImageLoader.IsZeroSearchNeeded = true;
				RobotImageLoader.currentCount = 0;
				RobotImageLoader.LoadImages();
				this.LoadImages();
				this.FillImageList();
				this.CheckSelectAllGroup();
				goto IL_198;
			}
			RobotImageLoader.robotImages.Clear();
			using (List<LstMyItems>.Enumerator enumerator = RobotImageLoader.GroupImages.GetEnumerator())
			{
				while (true)
				{
					IL_124:
					bool flag = enumerator.MoveNext();
					while (flag)
					{
						if (!false)
						{
							LstMyItems item = enumerator.Current;
							LstMyItems lstMyItems = (from t in RobotImageLoader.PrintImages
							where t.PhotoId == item.PhotoId
							select t).FirstOrDefault<LstMyItems>();
							flag = (lstMyItems == null);
							if (!flag)
							{
								item.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
							}
							else
							{
								item.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
							}
						}
						IL_DC:
						if (3 != 0)
						{
							if (false)
							{
								goto IL_109;
							}
							int arg_102_0;
                            int expr_E8 = arg_102_0 = 0; //c__DisplayClass.item.MediaType;
							int arg_102_1;
							int expr_EE = arg_102_1 = 2;
							bool arg_10B_0;
							if (expr_EE != 0)
							{
								if (expr_E8 == expr_EE)
								{
									goto IL_109;
								}
                                arg_10B_0 = false;// ((arg_102_0 = c__DisplayClass.item.MediaType) != 0);
								if (6 == 0)
								{
									goto IL_10A;
								}
								arg_102_1 = 3;
							}
							arg_10B_0 = (arg_102_0 != arg_102_1);
							IL_10A:
							if (!arg_10B_0)
							{
								//RobotImageLoader.robotImages.Add(c__DisplayClass.item);
							}
							if (-1 != 0)
							{
								goto IL_124;
							}
							goto IL_124;
							IL_109:
							arg_10B_0 = false;
							goto IL_10A;
						}
						continue;
						goto IL_DC;
					}
					break;
				}
			}
			this.LoadImages();
			this.FillImageList();
			this.CheckForAllImgSelectToPrint();
			IL_159:
			this.SetMessageText("PrintGrouped");
			IL_198:
			if (7 != 0)
			{
				return;
			}
			goto IL_159;
		}

		private void rdbtnPhoto_checked(object sender, RoutedEventArgs e)
		{
			this.searchConfig = SearchResult.SearchTypeConfig.Image;
			RobotImageLoader.MediaTypes = 1;
			bool expr_2C = !(this.vwGroup.Text == "View All");
			bool flag;
			if (!false)
			{
				flag = expr_2C;
			}
			if (!flag)
			{
				List<LstMyItems> expr_40 = RobotImageLoader.robotImages;
				if (!false)
				{
					expr_40.Clear();
				}
				using (List<LstMyItems>.Enumerator enumerator = RobotImageLoader.GroupImages.GetEnumerator())
				{
					while (true)
					{
						flag = enumerator.MoveNext();
						if (!flag)
						{
							break;
						}
						if (8 != 0)
						{
							LstMyItems item = enumerator.Current;
							if (!false)
							{
								LstMyItems lstMyItems = (from t in RobotImageLoader.PrintImages
								where t.PhotoId == item.PhotoId
								select t).FirstOrDefault<LstMyItems>();
								flag = (lstMyItems == null);
								if (!flag)
								{
									item.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
								}
								else
								{
									item.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
								}
								flag = (item.MediaType != RobotImageLoader.MediaTypes);
								if (!flag)
								{
									RobotImageLoader.robotImages.Add(item);
								}
							}
						}
					}
				}
				this.LoadImages();
				this.FillImageList();
				this.CheckForAllImgSelectToPrint();
				this.SetMessageText("PrintGrouped");
			}
			else
			{
				RobotImageLoader.MinPhotoIdCriteria = -1L;
				RobotImageLoader.IsZeroSearchNeeded = true;
				RobotImageLoader.currentCount = 0;
				RobotImageLoader.LoadImages();
				this.LoadImages();
				this.FillImageList();
				this.CheckSelectAllGroup();
			}
		}

		private void btnAdvanceVideoEditing_Click(object sender, RoutedEventArgs e)
		{
			bool expr_1B = !(this.vwGroup.Text == "View All");
			bool flag;
			if (!false)
			{
				flag = expr_1B;
			}
			if (!flag)
			{
				RobotImageLoader.isGroup = true;
			}
			else
			{
				while (4 == 0)
				{
				}
				RobotImageLoader.isGroup = false;
			}
			this.MediaStop();
			SearchResult.vsMediaFileName = string.Empty;
			try
			{
				bool flag2 = false;
				Window window = null;
				IEnumerator enumerator = System.Windows.Application.Current.Windows.GetEnumerator();
				try
				{
					while (true)
					{
						bool arg_95_0;
						bool expr_AE = arg_95_0 = enumerator.MoveNext();
						bool arg_BA_0;
						if (6 != 0)
						{
							flag = expr_AE;
							arg_BA_0 = flag;
							goto IL_BA;
						}
						IL_94:
						bool expr_95 = arg_BA_0 = !arg_95_0;
						Window window2;
						if (7 != 0)
						{
							flag = expr_95;
							if (!flag)
							{
								//window = (window2 as MLLiveCapture);
								flag2 = true;
							}
							continue;
						}
						IL_BA:
						if (!arg_BA_0)
						{
							break;
						}
						window2 = (Window)enumerator.Current;
						arg_95_0 = (window2.Title == "MLLiveCapture");
						goto IL_94;
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					bool arg_D3_0;
					bool expr_CA = arg_D3_0 = (disposable == null);
					if (true)
					{
						flag = expr_CA;
						arg_D3_0 = flag;
					}
					if (!arg_D3_0)
					{
						disposable.Dispose();
					}
				}
				bool arg_104_0;
				if (this.lstImages.SelectedItem == null || RobotImageLoader.PrintImages.Count <= 0)
				{
					if (3 == 0)
					{
						goto IL_12A;
					}
					arg_104_0 = !flag2;
				}
				else
				{
					arg_104_0 = false;
				}
				flag = arg_104_0;
				if (flag)
				{
					System.Windows.MessageBox.Show("No images or videos selected!", "DigiPhoto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
					goto IL_24A;
				}
				flag = (window == null);
                //MLLiveCapture mLLiveCapture;
                //if (!flag)
                //{
                //    mLLiveCapture = (MLLiveCapture)window;
                //}
                //else
                //{
                //    mLLiveCapture = new MLLiveCapture();
                //}
				IL_12A:
				flag = (!(this.vwGroup.Text == "View All") && !(this.pagename == "Saveback"));
				if (!flag)
				{
					SearchResult.itemsNotPrinted = new List<LstMyItems>();
					using (List<LstMyItems>.Enumerator enumerator2 = RobotImageLoader.GroupImages.GetEnumerator())
					{
						while (true)
						{
							flag = enumerator2.MoveNext();
							if (!flag)
							{
								break;
							}
							LstMyItems itx = enumerator2.Current;
							while (false)
							{
							}
							LstMyItems lstMyItems = (from xs in RobotImageLoader.PrintImages
							where xs.PhotoId == itx.PhotoId
							select xs).FirstOrDefault<LstMyItems>();
							flag = (lstMyItems != null);
							if (!flag)
							{
								SearchResult.itemsNotPrinted.Add(itx);
							}
						}
					}
				}
				ContantValueForMainWindow.RedEyeSize = 0.0105;
                //mLLiveCapture.WindowState = WindowState.Maximized;
                //mLLiveCapture.WindowStyle = WindowStyle.None;
                //mLLiveCapture.Show();
				base.Hide();
				IL_24A:;
			}
			catch (Exception serviceException)
			{
				string message;
				do
				{
					message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				}
				while (6 == 0);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
			finally
			{
				if (-1 != 0)
				{
				}
			}
		}

		protected void ShowMediaPlayer(object sender, EventArgs e)
		{
			if (6 == 0)
			{
				goto IL_25;
			}
			UIElement expr_06 = this.gdMediaPlayer;
			Visibility expr_0B = Visibility.Visible;
			if (!false)
			{
				expr_06.Visibility = expr_0B;
			}
			if (5 != 0)
			{
			}
			IL_15:
			bool arg_43_0 = string.IsNullOrEmpty(SearchResult.vsMediaFileName);
			bool expr_46;
			do
			{
				bool flag = arg_43_0;
				expr_46 = (arg_43_0 = flag);
			}
			while (!true);
			if (expr_46)
			{
				return;
			}
			IL_25:
			if (7 != 0)
			{
				this.MediaPlay();
			}
			if (8 == 0)
			{
				goto IL_15;
			}
		}

		private void btnLockmage_Click(object sender, RoutedEventArgs e)
		{
			string text = string.Empty;
			try
			{
				List<string> list = new List<string>();
				bool flag = false;
				string message;
				if (-1 != 0)
				{
					bool flag2;
					using (List<LstMyItems>.Enumerator enumerator = RobotImageLoader.PrintImages.GetEnumerator())
					{
						while (true)
						{
							flag2 = enumerator.MoveNext();
							if (!flag2)
							{
								break;
							}
							LstMyItems current = enumerator.Current;
							string item = current.Name + "@" + current.PhotoId;
							list.Add(item);
						}
					}
					bool arg_1F3_0;
					int arg_1F3_1;
					bool arg_A8_0;
					if (list != null)
					{
						int expr_99 = (arg_1F3_0 = (list.Count > 0)) ? 1 : 0;
						int expr_9C = arg_1F3_1 = 0;
						if (expr_9C != 0)
						{
							goto IL_1F3;
						}
						arg_A8_0 = (expr_99 == expr_9C);
					}
					else
					{
						arg_A8_0 = true;
					}
					flag2 = arg_A8_0;
					if (flag2)
					{
						message = "Please select image for preview lock.";
						//this.MsgBox.ShowHandlerDialog(message, DigiMessageBox.DialogType.OK);
						goto IL_269;
					}
					string text2 = string.Empty;
					List<string> source = Directory.GetFiles(Path.Combine(LoginUser.DigiFolderPath, "PreviewWall"), "*.jpg", SearchOption.AllDirectories).ToList<string>();
					using (List<string>.Enumerator enumerator2 = list.GetEnumerator())
					{
						while (true)
						{
							bool arg_1DA_0;
							bool expr_1CE = arg_1DA_0 = enumerator2.MoveNext();
							if (8 != 0)
							{
								flag2 = expr_1CE;
								goto IL_1D8;
							}
							IL_1DA:
							if (!arg_1DA_0 || false)
							{
								break;
							}
							string str = enumerator2.Current;
							try
							{
								bool arg_12F_0;
								bool expr_124 = arg_12F_0 = source.Any((string s) => s.Contains(str));
								if (!false)
								{
									arg_12F_0 = !expr_124;
								}
								flag2 = arg_12F_0;
								if (!flag2)
								{
									do
									{
										string[] array = str.Split(new char[]
										{
											'@'
										});
										text2 = array[0];
										File.Delete(source.FirstOrDefault((string x) => x.Contains(str)));
									}
									while (false);
									text = text2 + ',' + text;
									flag = true;
								}
							}
							catch (Exception serviceException)
							{
								ErrorHandler.ErrorHandler.LogError(serviceException);
								message = "Image number " + text2 + " is not locked for preview.";
								//this.MsgBox.ShowHandlerDialog(message, DigiMessageBox.DialogType.OK);
							}
							if (!false)
							{
								continue;
							}
							IL_1D8:
							arg_1DA_0 = flag2;
							goto IL_1DA;
						}
					}
					arg_1F3_0 = flag;
					arg_1F3_1 = 0;
					IL_1F3:
					flag2 = ((arg_1F3_0 ? 1 : 0) == arg_1F3_1);
					if (flag2)
					{
						message = "Images are already locked for preview.";
						//this.MsgBox.ShowHandlerDialog(message, DigiMessageBox.DialogType.OK);
						goto IL_245;
					}
				}
				message = "Images with number " + text.Remove(text.Length - 1) + " has been locked successfully.";
				//this.MsgBox.ShowHandlerDialog(message, DigiMessageBox.DialogType.OK);
				IL_245:
				this.btnRemoveGroup_Click(null, null);
				IL_269:;
			}
			catch (Exception serviceException)
			{
				if (-1 != 0)
				{
					string message2 = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
					ErrorHandler.ErrorHandler.LogFileWrite(message2);
				}
			}
		}

		private void btnExtractVideoFrame_Click(object sender, RoutedEventArgs e)
		{
			do
			{
				try
				{
					if (4 != 0)
					{
						this.AddVideoFrameExtractionPopup();
					}
					while (6 == 0)
					{
					}
				}
				catch (Exception serviceException)
				{
					string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
					ErrorHandler.ErrorHandler.LogFileWrite(message);
				}
				finally
				{
					while (-1 == 0)
					{
					}
				}
			}
			while (!true);
			if (!false)
			{
			}
		}

		private void AddVideoFrameExtractionPopup()
		{
			try
			{
				string fileName;
				string subStoreName;
				int photographerId;
				LstMyItems lstMyItems;
				string text;
				if (6 != 0)
				{
					bool flag;
					while (true)
					{
						fileName = string.Empty;
						string expr_12 = string.Empty;
						if (2 != 0)
						{
							subStoreName = expr_12;
						}
						if (4 == 0)
						{
							goto IL_59;
						}
						photographerId = 0;
						IL_2D:
						lstMyItems = RobotImageLoader.PrintImages.LastOrDefault<LstMyItems>();
						if (7 == 0)
						{
							continue;
						}
						bool expr_45 = lstMyItems == null;
						if (!false)
						{
							flag = expr_45;
						}
						if (flag)
						{
							goto IL_212;
						}
						IL_59:
						PhotoCaptureInfo photoCaptureInfo = new PhotoBusiness().GetphotoCapturedetails(lstMyItems.PhotoId).FirstOrDefault<PhotoCaptureInfo>();
						flag = (photoCaptureInfo == null);
						if (flag)
						{
							goto IL_209;
						}
						photographerId = photoCaptureInfo.PhotoGrapherId;
						subStoreName = photoCaptureInfo.SubstoreName;
						int locationId = photoCaptureInfo.LocationId;
						text = new PhotoBusiness().GetVideoFrameCropRatio(locationId);
						text = (string.IsNullOrEmpty(text) ? "None" : text);
						flag = (lstMyItems.MediaType != 1);
						if (!flag)
						{
							break;
						}
						if (-1 == 0)
						{
							goto IL_213;
						}
						this.MediaStop();
						flag = (lstMyItems.MediaType != 2);
						if (flag)
						{
							goto IL_13D;
						}
						if (-1 != 0)
						{
							goto Block_9;
						}
						goto IL_2D;
					}
					System.Windows.MessageBox.Show("Please select a video to extract frames.!", "DigiPhoto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
					return;
					Block_9:
					fileName = Path.Combine(lstMyItems.HotFolderPath, "Videos", lstMyItems.CreatedOn.ToString("yyyyMMdd"), lstMyItems.FileName);
					goto IL_17E;
					IL_13D:
					flag = (lstMyItems.MediaType != 3);
					if (!flag)
					{
						goto IL_150;
					}
					goto IL_17E;
					IL_212:
					IL_213:
					System.Windows.MessageBox.Show("No videos selected!", "DigiPhoto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
					goto IL_227;
				}
				goto IL_17E;
				IL_150:
				fileName = Path.Combine(lstMyItems.HotFolderPath, "ProcessedVideos", lstMyItems.CreatedOn.ToString("yyyyMMdd"), lstMyItems.FileName);
				IL_17E:
                //this.mExtractor = new MLFrameExtractor(fileName, "FrameExtractionPreview", true, lstMyItems.MediaType, lstMyItems.HotFolderPath, lstMyItems.Name, subStoreName, photographerId, text);
                this.gdMediaPlayer.Visibility = Visibility.Collapsed;
                //do
                //{
                //    this.mExtractor.ExecuteParentMethod += new EventHandler(this.ShowMediaPlayer);
                //}
                //while (false);
                //this.mExtractor.SetParent(this.ModalDialogParent);
                //this.grdCotrol.Children.Add(this.mExtractor);
                //this.mExtractor.Visibility = Visibility.Visible;
				IL_209:
				if (false)
				{
					goto IL_150;
				}
				IL_227:;
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
		}


        void IStyleConnector.Connect(int connectionId, object target)
        {
            if (2 != 0)
            {
                int arg_1B_0 = connectionId;
                if (4 != 0)
                {
                    if (8 == 0)
                    {
                        return;
                    }
                    
                    arg_1B_0 = connectionId - 2;
                }
                switch (arg_1B_0)
                {
                    case 0:
                        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.MainImage_Click);
                        break;
                    case 1:
                        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnPrint_Click);
                        break;
                    case 2:
                        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnAddToGroup_Click);
                        if (5 != 0)
                        {
                        }
                        break;
                    default:
                    IL_2C:
                        break;
                }
            }
        }
		
	}
}
