using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using PhotoSW.Manage;
using DigiPhoto.Utility.Repository.Data;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using FrameworkHelper;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using DigiPhoto;

namespace PhotoSW.Views
{
	public partial class SearchByPhoto : Window, IComponentConnector
	{
		private TextBox _txtKeyboard = new TextBox();

		private string _mktImgPath = string.Empty;

		private int _mktImgTime = 0;

		private string _cardCode = string.Empty;

		private Visibility _isPanelVisible;


		//private bool _contentLoaded;

		public Visibility IsPanelVisible
		{
			get
			{
				return this._isPanelVisible;
			}
			set
			{
				this._isPanelVisible = value;
			}
		}

		public SearchByPhoto()
		{
			try
			{
				this.InitializeComponent();
				this.txbUserName.Text = LoginUser.UserName;
				this.txbStoreName.Text = LoginUser.StoreName;
				this.txtRFID.Focus();
				this.rdbtnPhotoId.IsChecked = new bool?(true);
				this.searchbyPhotoId.Visibility = Visibility.Visible;
				DateTime value = new CustomBusineses().ServerDateTime();
				this.dtselect.SelectedDate = new DateTime?(value);
				this.dtselectToDate.SelectedDate = new DateTime?(value);
				this.GetAllDropdown();
				this.txtRFID.Text = "";
				this.BindCodeType();
				this.rdbtnPhotoId.IsChecked = new bool?(App.ViewOrderSearchIndex == 0);
				this.rdbtnTime.IsChecked = new bool?(App.ViewOrderSearchIndex == 1);
				this.rdbtnGroup.IsChecked = new bool?(App.ViewOrderSearchIndex == 2);
				this.SetQrCodeSearchState();
				if ( string.IsNullOrEmpty(App.QRCodeWebUrl))
				{
					string qRCodeWebUrl = new LocationBusniess().GetQRCodeWebUrl();
					App.QRCodeWebUrl = (string.IsNullOrEmpty(qRCodeWebUrl) ? " " : qRCodeWebUrl);
				}
			}
			catch (Exception serviceException)
			{
				ErrorHandler.ErrorHandler.LogError(serviceException);
			}
		}

		private void btn_Click_keyboard(object sender, RoutedEventArgs e)
		{
			do
			{
				try
				{
					Button button;
					bool expr_DF;
					while (true)
					{
						IL_01:
						button = (Button)sender;
						string expr_15E = button.Content.ToString();
						string text;
						if (!false)
						{
							text = expr_15E;
						}
						if (text == null)
						{
							break;
						}
						if (2 == 0)
						{
							goto IL_AC;
						}
						if (text == "ENTER")
						{
							goto IL_71;
						}
						if (!(text == "SPACE"))
						{
							bool arg_5D_0 = text == "CLOSE";
							while (!arg_5D_0)
							{
								if (!(text == "Back"))
								{
									goto Block_7;
								}
								int arg_D0_0 = this._txtKeyboard.Text.Length;
								bool expr_D0;
								do
								{
									expr_D0 = ((arg_D0_0 = ((arg_D0_0 > 0) ? 1 : 0)) != 0);
								}
								while (false);
								bool flag = !expr_D0;
								if (false)
								{
									goto IL_01;
								}
								expr_DF = (arg_5D_0 = flag);
								if (true)
								{
									goto Block_10;
								}
							}
							goto IL_AB;
						}
						goto IL_84;
					}
					Block_7:
					goto IL_119;
					IL_71:
					this.KeyBorder1.Visibility = Visibility.Collapsed;
					goto IL_13F;
					IL_84:
					this._txtKeyboard.Text = this._txtKeyboard.Text + " ";
					goto IL_13F;
					IL_AB:
					IL_AC:
					this.KeyBorder1.Visibility = Visibility.Collapsed;
					goto IL_13F;
					Block_10:
					if (!expr_DF)
					{
						this._txtKeyboard.Text = this._txtKeyboard.Text.Remove(this._txtKeyboard.Text.Length - 1, 1);
					}
					goto IL_13F;
					IL_119:
					this._txtKeyboard.Text = this._txtKeyboard.Text + button.Content;
					IL_13F:;
				}
				catch (Exception serviceException)
				{
					ErrorHandler.ErrorHandler.LogError(serviceException);
					if (3 == 0 || 6 != 0)
					{
					}
				}
			}
			while (false);
		}

		private void btnHome_Click(object sender, RoutedEventArgs e)
		{
			if (!false)
			{
				//ClientView clientView = null;
				IEnumerator expr_1C4 = Application.Current.Windows.GetEnumerator();
				IEnumerator enumerator;
				if (!false)
				{
					enumerator = expr_1C4;
				}
				try
				{
					while (enumerator.MoveNext())
					{
						Window expr_2A = (Window)enumerator.Current;
						Window window;
						if (3 != 0)
						{
							window = expr_2A;
						}
						if (window.Title == "ClientView")
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
				}
                //if (clientView == null)
                //{
                //    //clientView = new ClientView();
                //    //clientView.WindowStartupLocation = WindowStartupLocation.Manual;
                //}
                //clientView.GroupView = false;
                //clientView.DefaultView = false;
				this.GetMktImgInfo();
                //if (!(this._mktImgPath == "") && this._mktImgTime != 0)
                //{
                //    clientView.instructionVideo.Visibility = Visibility.Visible;
                //    clientView.instructionVideo.Play();
                //}
                //else
                //{
                //    clientView.imgDefault.Visibility = Visibility.Visible;
                //}
                //clientView.testR.Fill = null;
                //do
                //{
                //    clientView.DefaultView = true;
                //    if (clientView.instructionVideo.Visibility == Visibility.Visible)
                //    {
                //        clientView.instructionVideo.Play();
                //    }
                //    else
                //    {
                //        clientView.instructionVideo.Pause();
                //    }
                //    Home home = new Home();
                //    home.Show();
                //}
                //while (3 == 0);
				if (this.cmbQRCodeType.SelectedValue.ToString() != "404")
				{
					this.txtQRCode.Text = string.Empty;
				}
			}
			base.Hide();
		}

		private void btnRefresh_Click(object sender, RoutedEventArgs e)
		{
			this.GetPrintersStatus();
		}

		private void DatePicker_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			bool arg_36_0;
			bool arg_18_0;
			bool expr_06 = arg_18_0 = (arg_36_0 = (e.Key == Key.Return));
			if (-1 == 0)
			{
				goto IL_15;
			}
			arg_36_0 = (arg_18_0 = !expr_06);
			IL_0E:
			if (-1 != 0)
			{
				bool flag = arg_36_0;
				arg_36_0 = (arg_18_0 = flag);
			}
			IL_15:
			if (2 != 0)
			{
				if (!arg_18_0 && true)
				{
					this.btnSearchDetailWithQrcode_Click(this.btnsearch, new RoutedEventArgs());
				}
				return;
			}
			goto IL_0E;
		}

		private void bttnLogin_Enter(object sender, KeyEventArgs e)
		{
		}

		private void btnSearchDetailWithQrcode_Click(object sender, RoutedEventArgs e)
		{
			if (this.txtRFID.Text.Trim() == "")
			{
				this.txtRFID.Text = "0";
			}
			try
			{
				if (this.cmbFromTime.SelectedItem != null && this.cmbToTime.SelectedItem != null)
				{
					RobotImageLoader.RFID = this.txtRFID.Text;
					RobotImageLoader.PhotoId = this.txtRFID.Text;
                    //RobotImageLoader.SearchCriteria = "TimeWithQrcode";
                    RobotImageLoader.SearchCriteria = "Time";
                    bool flag = this.dtselect.SelectedDate.HasValue || this.dtselectToDate.SelectedDate.HasValue;
					bool arg_D0_0 = flag;
					DateTime fromTime;
					DateTime toTime;
					while (arg_D0_0)
					{
						if (this.dtselect.SelectedDate.HasValue && this.dtselectToDate.SelectedDate.HasValue)
						{
							fromTime = this.dtselect.SelectedDate.Value;
							toTime = this.dtselectToDate.SelectedDate.Value;
							goto IL_1FA;
						}
						flag = (!this.dtselectToDate.SelectedDate.HasValue || this.dtselect.SelectedDate.HasValue);
						bool expr_198 = arg_D0_0 = flag;
						if (5 == 0)
						{
							continue;
						}
						if (expr_198)
						{
							fromTime = new CustomBusineses().ServerDateTime().Date;
							toTime = new CustomBusineses().ServerDateTime().Date;
							goto IL_1FA;
						}
						IL_1A3:
						fromTime = this.dtselectToDate.SelectedDate.Value;
						toTime = this.dtselectToDate.SelectedDate.Value;
						IL_1FA:
						fromTime = fromTime.AddHours((double)Convert.ToInt32(this.cmbFromTime.SelectionBoxItem.ToString().Substring(0, 2))).AddMinutes((double)Convert.ToInt32(this.cmbFromTime.SelectionBoxItem.ToString().Substring(3, 2)));
						toTime = toTime.AddHours((double)Convert.ToInt32(this.cmbToTime.SelectionBoxItem.ToString().Substring(0, 2))).AddMinutes((double)Convert.ToInt32(this.cmbToTime.SelectionBoxItem.ToString().Substring(3, 2)));
						RobotImageLoader.FromTime = fromTime;
						RobotImageLoader.ToTime = toTime;
						RobotImageLoader.LocationId = Convert.ToInt32(((LocationInfo)this.cmbLocation.SelectedItem).DG_Location_pkey);
						RobotImageLoader.UserId = Convert.ToInt32(((PhotoGraphersInfo)this.cmbPhotographer.SelectedItem).DG_User_pkey);
						if (this.cmbSubstore.SelectedValue != "0")
						{
							RobotImageLoader.SearchedStoreId = this.cmbSubstore.SelectedValue.ToString();
						}
						else
						{
							if (2 == 0)
							{
								goto IL_6C9;
							}
							RobotImageLoader.SearchedStoreId = "";
						}
						if (this.cmbCharacter.SelectedValue != "0")
						{
							RobotImageLoader.CharacterId = new int?(this.cmbCharacter.SelectedValue.ToInt32(false));
						}
						else
						{
							RobotImageLoader.CharacterId = null;
						}
						ErrorHandler.ErrorHandler.LogFileWrite(RobotImageLoader.SearchedStoreId);
						this.txtQRCode.Text = String.IsNullOrEmpty(this.txtQRCode.Text)?"": this.txtQRCode.Text.Replace(App.QRCodeWebUrl, string.Empty);
						if (5 == 0)
						{
							goto IL_77C;
						}
						if (!string.IsNullOrEmpty(this.txtQRCode.Text))
						{
							if (false)
							{
								goto IL_1A3;
							}
							if (this.cmbQRCodeType.SelectedIndex <= 0)
							{
								MessageBox.Show("Please select Code Type.");
								return;
							}
						}
						if (this.cmbQRCodeType.SelectedIndex > 0)
						{
							if (string.IsNullOrEmpty(this.txtQRCode.Text))
							{
								int num = (int)this.cmbQRCodeType.SelectedValue;
								MessageBox.Show("Enter " + this.cmbQRCodeType.Text + ((num != 405) ? " Code." : "."));
								return;
							}
						}
						if (Convert.ToInt32(this.cmbQRCodeType.SelectedValue) > 0)
						{
							RobotImageLoader.CodeType = (int)this.cmbQRCodeType.SelectedValue;
						}
						RobotImageLoader.IsAnonymousQrCodeEnabled = (App.IsAnonymousQrCodeEnabled && RobotImageLoader.CodeType == 405);
						SearchResult searchResult;
						IEnumerator enumerator;
						if (string.IsNullOrEmpty(this.txtQRCode.Text.Trim()))
						{
							RobotImageLoader.Code = string.Empty;
							searchResult = null;
							enumerator = Application.Current.Windows.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									if (-1 != 0)
									{
										Window window = (Window)enumerator.Current;
										if (window.Title == "View/Order Station")
										{
											searchResult = (SearchResult)window;
										}
									}
								}
							}
							finally
							{
								IDisposable disposable;
								if (!false)
								{
									disposable = (enumerator as IDisposable);
									if (disposable == null)
									{
										goto IL_759;
									}
								}
								disposable.Dispose();
								IL_759:;
							}
							if (searchResult == null)
							{
								searchResult = new SearchResult();
							}
							searchResult.pagename = "";
							goto IL_77C;
						}
						SearchResult searchResult2 = null;
						enumerator = Application.Current.Windows.GetEnumerator();
						try
						{
							Window window2;
							do
							{
								flag = enumerator.MoveNext();
								if (!flag)
								{
									goto IL_520;
								}
								window2 = (Window)enumerator.Current;
								if (6 != 0)
								{
									flag = (string.Compare(window2.Title, "View/Order Station", true) != 0);
								}
							}
							while (flag);
							searchResult2 = (SearchResult)window2;
							IL_520:;
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							flag = (disposable == null);
							if (false || !flag)
							{
								disposable.Dispose();
							}
						}
						CardBusiness cardBusiness = new CardBusiness();
						searchResult = ((searchResult2 != null) ? searchResult2 : new SearchResult());
						RobotImageLoader.Code = this.txtQRCode.Text;
						if (RobotImageLoader.CodeType == 403)
						{
							RobotImageLoader.Code = "0000" + RobotImageLoader.Code;
						}
						if (RobotImageLoader.CodeType == 406)
						{
							RobotImageLoader.Code = "2222" + RobotImageLoader.Code;
						}
						if (!App.IsAnonymousQrCodeEnabled && !cardBusiness.IsValidCodeType(RobotImageLoader.Code, RobotImageLoader.CodeType))
						{
							MessageBox.Show("Invalid code.");
							if (RobotImageLoader.CodeType != 404)
							{
								this.txtQRCode.Text = string.Empty;
							}
							return;
						}
						if (this.txtQRCode == null)
						{
							goto IL_6CB;
						}
						if (!this.IsImageExists(RobotImageLoader.Code))
						{
							if (RobotImageLoader.CodeType != 404)
							{
								this.txtQRCode.Text = string.Empty;
							}
							MessageBox.Show("No image is associated with this code.");
							goto IL_6C9;
						}
						searchResult.pagename = "";
						searchResult.Show();
						searchResult.serachType = 1;
						searchResult.LoadWindow();
						bool arg_677_0 = this.cmbQRCodeType.SelectedValue.ToString() != "404";
						IL_676:
						if (arg_677_0)
						{
							this.txtQRCode.Text = string.Empty;
						}
						base.Hide();
						goto IL_6CA;
						IL_77C:
						if (RobotImageLoader.NotPrintedImages == null)
						{
							RobotImageLoader.NotPrintedImages = new List<LstMyItems>();
						}
						RobotImageLoader._objnewincrement = new List<LstMyItems>();
						searchResult.grdSelectAll.Visibility = Visibility.Visible;
						RobotImageLoader.ViewGroupedImagesCount = new List<string>();
						searchResult.Show();
						searchResult.serachType = 1;
						searchResult.LoadWindow();
						flag = !(this.cmbQRCodeType.SelectedValue.ToString() != "404");
						bool expr_7F0 = arg_677_0 = flag;
						if (8 == 0)
						{
							goto IL_676;
						}
						if (!expr_7F0)
						{
							this.txtQRCode.Text = string.Empty;
						}
						base.Hide();
						IL_6C9:
						IL_6CA:
						IL_6CB:
						goto IL_814;
					}
					fromTime = this.dtselect.SelectedDate.Value;
					toTime = this.dtselectToDate.SelectedDate.Value;
					//goto IL_1FA;
				}
				IL_814:;
			}
			catch (Exception serviceException)
			{
				ErrorHandler.ErrorHandler.LogError(serviceException);
			}
		}

		private void btn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				RobotImageLoader.MediaTypes = 0;
				Button expr_0D = (Button)sender;
				Button button;
				if (4 != 0)
				{
					button = expr_0D;
				}
				string name = button.Name;
                Dictionary<string, int> obj=null;
				if (name != null)
				{
                    if (obj == null)
                    {
                        obj = new Dictionary<string, int>(16)
                        {
                            {
                                "btn1",
                                0
                            },
                            {
                                "btn2",
                                1
                            },
                            {
                                "btn3",
                                2
                            },
                            {
                                "btn4",
                                3
                            },
                            {
                                "btn5",
                                4
                            },
                            {
                                "btn6",
                                5
                            },
                            {
                                "btn7",
                                6
                            },
                            {
                                "btn8",
                                7
                            },
                            {
                                "btn9",
                                8
                            },
                            {
                                "btn0",
                                9
                            },
                            {
                                "Ok",
                                10
                            },
                            {
                                "btnsearchgroup",
                                11
                            },
                            {
                                "btnSearchQRCode",
                                12
                            },
                            {
                                "Cancel",
                                13
                            },
                            {
                                "btnback",
                                14
                            },
                            {
                                "btnsearch",
                                15
                            }
                        };
                    }
					int num=0;
                    if (obj.TryGetValue(name, out num))
                    {
						bool arg_319_0;
						int arg_319_1;
						CardBusiness cardBusiness;
						bool arg_8C2_0;

						switch (num)
						{
						case 0:
							this.txtRFID.Text = this.txtRFID.Text + "1";
							goto IL_EA1;
						case 1:
							this.txtRFID.Text = this.txtRFID.Text + "2";
							goto IL_EA1;
						case 2:
							this.txtRFID.Text = this.txtRFID.Text + "3";
							goto IL_EA1;
						case 3:
							this.txtRFID.Text = this.txtRFID.Text + "4";
							goto IL_EA1;
						case 4:
							this.txtRFID.Text = this.txtRFID.Text + "5";
							goto IL_EA1;
						case 5:
							this.txtRFID.Text = this.txtRFID.Text + "6";
							goto IL_EA1;
						case 6:
							this.txtRFID.Text = this.txtRFID.Text + "7";
							goto IL_EA1;
						case 7:
							this.txtRFID.Text = this.txtRFID.Text + "8";
							goto IL_EA1;
						case 8:
							this.txtRFID.Text = this.txtRFID.Text + "9";
							goto IL_EA1;
						case 9:
							this.txtRFID.Text = this.txtRFID.Text + "0";
							goto IL_EA1;
						case 10:
							arg_319_0 = (this.txtRFID.Text.Trim() == "");
							arg_319_1 = 0;
							break;
						case 11:
							if (this.txtRFID.Text.Trim() == "")
							{
								this.txtRFID.Text = "0";
							}
							if (!string.IsNullOrEmpty(this.txtRFID.Text.Trim()))
							{
								if (string.IsNullOrEmpty(this.txtgroupname.Text.Trim()))
								{
									MessageBox.Show("Please enter group name.");
								}
								else
								{
									PhotoBusiness photoBusiness = new PhotoBusiness();
									if (photoBusiness.GetSavedGroupImages(this.txtgroupname.Text.Trim()).Count<PhotoInfo>() <= 0)
									{
										MessageBox.Show("No image is grouped with this name.");
									}
									else
									{
										RobotImageLoader.GroupId = this.txtgroupname.Text;
										RobotImageLoader.SearchCriteria = "Group";
										SearchResult searchResult = null;
										foreach (Window window in Application.Current.Windows)
										{
											if (window.Title == "View/Order Station")
											{
												searchResult = (SearchResult)window;
											}
										}
										if (searchResult == null)
										{
											searchResult = new SearchResult();
										}
										searchResult.pagename = "MainGroup";
										searchResult.txtgpnumber.Text = this.txtgroupname.Text;
										searchResult.Show();
										searchResult.LoadWindow();
										if (this.cmbQRCodeType.SelectedValue.ToString() != "404")
										{
											this.txtQRCode.Text = string.Empty;
										}

                                        ClientView clientView = null;
                                        foreach (Window window in System.Windows.Application.Current.Windows)
                                        {
                                            if (window.Title == "ClientView")
                                            {
                                                clientView = (ClientView)window;
                                            }
                                        }
                                        if (clientView != null)
                                        {

                                        }
                                        else
                                        {
                                            clientView = new ClientView();
                                        }
                                        clientView.LoadWindow();

                                        this.txtgroupname.Text = "";
										base.Hide();
									}
								}
							}
							goto IL_EA1;
						case 12:
						{
							this.txtQRCode.Text = this.txtQRCode.Text.Replace(App.QRCodeWebUrl, string.Empty);
							if (this.cmbQRCodeType.SelectedIndex <= 0)
							{
								MessageBox.Show("Please select card type.");
								return;
							}
							RobotImageLoader.CodeType = (int)this.cmbQRCodeType.SelectedValue;
							RobotImageLoader.IsAnonymousQrCodeEnabled = (App.IsAnonymousQrCodeEnabled && RobotImageLoader.CodeType == 405);
							if (string.IsNullOrEmpty(this.txtQRCode.Text.Trim()))
							{
								MessageBox.Show("Please enter " + this.cmbQRCodeType.Text + ((RobotImageLoader.CodeType != 405) ? " Code." : "."));
								goto IL_9D2;
							}
							SearchResult searchResult2 = null;
							foreach (Window window2 in Application.Current.Windows)
							{
								if (string.Compare(window2.Title, "View/Order Station", true) == 0)
								{
									searchResult2 = (SearchResult)window2;
									break;
								}
							}
							cardBusiness = new CardBusiness();
							RobotImageLoader.SearchCriteria = "QRCODE";
							SearchResult searchResult3 = (searchResult2 != null) ? searchResult2 : new SearchResult();
							RobotImageLoader.Code = this.txtQRCode.Text;
							if (RobotImageLoader.CodeType == 403)
							{
								RobotImageLoader.Code = "0000" + RobotImageLoader.Code;
							}
							if (RobotImageLoader.CodeType == 406)
							{
								RobotImageLoader.Code = "2222" + RobotImageLoader.Code;
							}
							if (!App.IsAnonymousQrCodeEnabled)
							{
								goto IL_8AD;
							}
							arg_8C2_0 = true;
							goto IL_8C1;
						}
						case 13:
						{
							if (string.IsNullOrEmpty(RobotImageLoader.RFID))
							{
								goto IL_9EB;
							}
							SearchResult searchResult = null;
                            //using (IEnumerator enumerator = Application.Current.Windows.GetEnumerator())
                            try
                            {
                                IEnumerator enumerator = Application.Current.Windows.GetEnumerator();
                                while (true)
                                {
                                    bool arg_A43_0;
                                    bool expr_A57 = arg_A43_0 = enumerator.MoveNext();
                                    Window window;
                                    if (8 != 0)
                                    {
                                        if (!expr_A57)
                                        {
                                            break;
                                        }
                                        window = (Window)enumerator.Current;
                                        arg_A43_0 = (window.Title == "View/Order Station");
                                    }
                                    if (arg_A43_0)
                                    {
                                        searchResult = (SearchResult)window;
                                    }
                                }
                            }
                            catch(Exception ex)
                            {
                                throw ex;
                            }
							if (searchResult == null)
							{
								searchResult = new SearchResult();
							}
							int expr_A9E = (arg_319_0 = (RobotImageLoader.NotPrintedImages == null)) ? 1 : 0;
							int expr_AA1 = arg_319_1 = 0;
							if (expr_AA1 == 0)
							{
								bool flag = expr_A9E == expr_AA1;
								bool arg_AAD_0 = flag;
								bool expr_B03;
								do
								{
									if (!arg_AAD_0)
									{
										RobotImageLoader.NotPrintedImages = new List<LstMyItems>();
									}
									RobotImageLoader._objnewincrement = new List<LstMyItems>();
									searchResult.grdSelectAll.Visibility = Visibility.Visible;
									RobotImageLoader.ViewGroupedImagesCount = new List<string>();
									searchResult.Show();
									searchResult.LoadWindow();
									expr_B03 = (arg_AAD_0 = !(this.cmbQRCodeType.SelectedValue.ToString() != "404"));
								}
								while (6 == 0);
								if (!expr_B03)
								{
									this.txtQRCode.Text = string.Empty;
								}
								this.txtgroupname.Text = "";
								base.Hide();
								goto IL_B38;
							}
							break;
						}
						case 14:
							if (this.txtRFID.Text.Length > 0)
							{
								if (false)
								{
									goto IL_8AD;
								}
								this.txtRFID.Text = this.txtRFID.Text.Remove(this.txtRFID.Text.Length - 1, 1);
							}
							goto IL_EA1;
						case 15:
						{
							bool flag = !(this.txtRFID.Text.Trim() == "");
							if (!false)
							{
								if (!flag)
								{
									this.txtRFID.Text = "0";
								}
								try
								{
									if (this.cmbFromTime.SelectedItem != null && this.cmbToTime.SelectedItem != null)
									{
										RobotImageLoader.RFID = this.txtRFID.Text;
										RobotImageLoader.PhotoId = this.txtRFID.Text;
										RobotImageLoader.SearchCriteria = "TimeWithQrcode";
										DateTime toTime;
										DateTime fromTime;
										if (this.dtselect.SelectedDate.HasValue)
										{
											do
											{
												toTime = this.dtselect.SelectedDate.Value;
												fromTime = this.dtselect.SelectedDate.Value;
												if (false)
												{
													goto IL_E03;
												}
											}
											while (7 == 0);
										}
										else
										{
											toTime = new CustomBusineses().ServerDateTime().Date;
											fromTime = new CustomBusineses().ServerDateTime().Date;
										}
										fromTime = fromTime.AddHours((double)Convert.ToInt32(this.cmbFromTime.SelectionBoxItem.ToString().Substring(0, 2)));
										toTime = toTime.AddHours((double)Convert.ToInt32(this.cmbToTime.SelectionBoxItem.ToString().Substring(0, 2)));
										RobotImageLoader.FromTime = fromTime;
										RobotImageLoader.ToTime = toTime;
										RobotImageLoader.LocationId = Convert.ToInt32(((LocationInfo)this.cmbLocation.SelectedItem).DG_Location_pkey);
										RobotImageLoader.UserId = Convert.ToInt32(((PhotoGraphersInfo)this.cmbPhotographer.SelectedItem).DG_User_pkey);
										if (this.cmbSubstore.SelectedValue != "0")
										{
											RobotImageLoader.SearchedStoreId = this.cmbSubstore.SelectedValue.ToString();
										}
										else
										{
											RobotImageLoader.SearchedStoreId = LoginUser.DefaultSubstores;
										}
										ErrorHandler.ErrorHandler.LogFileWrite(RobotImageLoader.SearchedStoreId);
										SearchResult searchResult3 = null;
                                        //using (IEnumerator enumerator = Application.Current.Windows.GetEnumerator())
                                        try
                                        {
                                            IEnumerator enumerator = Application.Current.Windows.GetEnumerator();
                                            while (true)
                                            {
                                            IL_DD6:
                                                flag = enumerator.MoveNext();
                                                bool arg_DE1_0 = flag;
                                            IL_DE1:
                                                while (arg_DE1_0)
                                                {
                                                    Window window = (Window)enumerator.Current;
                                                    bool arg_DBD_0 = window.Title == "View/Order Station";
                                                    bool expr_DC4;
                                                    do
                                                    {
                                                        bool expr_DBD = arg_DE1_0 = !arg_DBD_0;
                                                        if (2 == 0)
                                                        {
                                                            goto IL_DE1;
                                                        }
                                                        flag = expr_DBD;
                                                        expr_DC4 = (arg_DBD_0 = flag);
                                                    }
                                                    while (false);
                                                    if (!expr_DC4)
                                                    {
                                                        searchResult3 = (SearchResult)window;
                                                    }
                                                    goto IL_DD6;
                                                }
                                                break;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }
                                       
										IL_E03:
										if (searchResult3 == null)
										{
											searchResult3 = new SearchResult();
										}
										searchResult3.pagename = "";
										searchResult3.Show();
										searchResult3.LoadWindow();
										if (this.cmbQRCodeType.SelectedValue.ToString() != "404")
										{
											this.txtQRCode.Text = string.Empty;
										}
										this.txtgroupname.Text = "";
										base.Hide();
									}
								}
								catch (Exception serviceException)
								{
									string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
									if (!false)
									{
										ErrorHandler.ErrorHandler.LogFileWrite(message);
									}
								}
								goto IL_EA1;
							}
							goto IL_9EB;
						}
						default:
							goto IL_EA1;
						}
						if ((arg_319_0 ? 1 : 0) != arg_319_1)
						{
							this.txtRFID.Text = "0";
							RobotImageLoader.IsZeroSearchNeeded = true;
						}
						if (!string.IsNullOrEmpty(this.txtRFID.Text.Trim()))
						{
							RobotImageLoader.RFID = this.txtRFID.Text;
							RobotImageLoader.SearchCriteria = "PhotoId";
							if (RobotImageLoader.GroupImages == null)
							{
								RobotImageLoader.GroupImages = new List<LstMyItems>();
							}
							else if (RobotImageLoader.GroupImages.Count == 0)
							{
								RobotImageLoader.GroupImages = new List<LstMyItems>();
							}
                            bool arg_8C2_01 = ((RobotImageLoader.PhotoId = this.txtRFID.Text) == null);
                            if (this.txtRFID.Text != "0")
                            {
                                RobotImageLoader._rfidSearch = 0;
                                RobotImageLoader.StartIndexRFID = 0L;
                                RobotImageLoader.PhotoId = this.txtRFID.Text;
                                RobotImageLoader.LoadImages();
                                if (RobotImageLoader.robotImages.Count == 0)
                                {
                                    MessageBox.Show("No images found for given Id");
                                    return;
                                }
                            }
                            else if (!arg_8C2_01)
                            {
                                MessageBox.Show("No images found for given Id");
                                return;
                            }
                            else
                            {
                                RobotImageLoader.IsZeroSearchNeeded = true;
                                RobotImageLoader.currentCount = 0;
                            }
                                                        

                            SearchResult searchResult = null;
							foreach (Window window in Application.Current.Windows)
							{
								if (window.Title == "View/Order Station")
								{
									searchResult = (SearchResult)window;
								}
							}
							if (searchResult == null)
							{
								searchResult = new SearchResult();
							}
							if (RobotImageLoader.NotPrintedImages == null)
							{
								RobotImageLoader.NotPrintedImages = new List<LstMyItems>();
							}
							RobotImageLoader._objnewincrement = new List<LstMyItems>();
							searchResult.grdSelectAll.Visibility = Visibility.Visible;
							RobotImageLoader.ViewGroupedImagesCount = new List<string>();
							searchResult.pagename = "";
							searchResult.Show();
							searchResult.returntoHome = false;
							searchResult.LoadWindow();
							if (this.cmbQRCodeType.SelectedValue.ToString() != "404")
							{
								this.txtQRCode.Text = string.Empty;
							}

                            ClientView clientView = null;

                            foreach (Window window in System.Windows.Application.Current.Windows)
                            {
                                if (window.Title == "ClientView")
                                {
                                    clientView = (ClientView)window;
                                }
                            }
                            if (clientView != null)
                            {

                            }
                            else
                            {
                                clientView = new ClientView();

                            }
                            clientView.LoadWindow();
                            base.Hide();
						}
						goto IL_EA1;
						IL_8AD:
						arg_8C2_0 = cardBusiness.IsValidCodeType(RobotImageLoader.Code, RobotImageLoader.CodeType);
						IL_8C1:
						if (!arg_8C2_0)
						{
							MessageBox.Show("Invalid code.");
							if (RobotImageLoader.CodeType != 404)
							{
								this.txtQRCode.Text = string.Empty;
							}
						}
						else if (this.IsImageExists(RobotImageLoader.Code))
						{
							SearchResult searchResult3=new SearchResult();
							searchResult3.pagename = "";
							searchResult3.Show();
							searchResult3.LoadWindow();
							if (this.cmbQRCodeType.SelectedValue.ToString() != "404")
							{
								this.txtQRCode.Text = string.Empty;
							}
							base.Hide();
						}
						else
						{
							if (RobotImageLoader.CodeType != 404)
							{
								this.txtQRCode.Text = string.Empty;
							}
							MessageBox.Show("No image is associated with this code.");
						}
						IL_9D2:
						goto IL_EA1;
						IL_9EB:
						RobotImageLoader.RFID = "1";
						this.txtRFID.Text = "0";
						IL_B38:;
					}
				}
				IL_EA1:;
			}
			catch (Exception serviceException)
			{
				ErrorHandler.ErrorHandler.LogError(serviceException);
			}
		}

		private void btnLogout_Click(object sender, RoutedEventArgs e)
		{
			do
			{
				try
				{
					if (!false)
					{
						//AuditLog.AddUserLog(LoginUser.UserId, 39, "Logged out at ");
						if (false)
						{
							goto IL_20;
						}
						Login login = new Login();
						login.Show();
					}
					if (false)
					{
						goto IL_26;
					}
					IL_20:
					base.Close();
					IL_26:;
				}
				catch (Exception serviceException)
				{
					do
					{
						ErrorHandler.ErrorHandler.LogError(serviceException);
					}
					while (4 == 0);
				}
			}
			while (false);
		}

		private void txtRFID_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				bool expr_13E;
				while (true)
				{
					while (true)
					{
						IL_02:
						if (e.Key == Key.D0 || e.Key == Key.D1 || e.Key == Key.D2 || e.Key == Key.D3 || (!false && (e.Key == Key.D4 || e.Key == Key.D5 || e.Key == Key.D6 || (!false && (e.Key == Key.D7 || e.Key == Key.D8 || e.Key == Key.D9 || e.Key == Key.NumPad0 || e.Key == Key.NumPad1)) || e.Key == Key.NumPad2 || e.Key == Key.NumPad3 || e.Key == Key.NumPad4)))
						{
							goto IL_10A;
						}
						if (false)
						{
							break;
						}
						if (e.Key == Key.NumPad5 || e.Key == Key.NumPad6 || e.Key == Key.NumPad7 || e.Key == Key.NumPad8)
						{
							goto IL_10A;
						}
						bool arg_10C_0 = e.Key != Key.NumPad9;
						IL_10B:
						while (arg_10C_0)
						{
							if (e.Key == Key.Return)
							{
								bool flag = string.IsNullOrEmpty(this.txtRFID.Text.Trim());
								expr_13E = (arg_10C_0 = flag);
								if (!false)
								{
									goto Block_24;
								}
							}
							else
							{
								e.Handled = true;
								if (2 != 0)
								{
									goto IL_159;
								}
								goto IL_02;
							}
						}
						if (!false)
						{
							goto Block_22;
						}
						IL_10A:
						arg_10C_0 = false;
						goto IL_10B;
					}
				}
				Block_22:
				goto IL_159;
				Block_24:
				if (!expr_13E)
				{
				}
				IL_159:;
			}
			catch (Exception serviceException)
			{
				if (3 != 0)
				{
					ErrorHandler.ErrorHandler.LogError(serviceException);
				}
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			if (8 != 0 && 5 != 0)
			{
				try
				{
					while (false)
					{
					}
				}
				catch (Exception serviceException)
				{
					if (2 != 0)
					{
						ErrorHandler.ErrorHandler.LogError(serviceException);
					}
				}
			}
		}

		private void rdbtnPhotoId_Click(object sender, RoutedEventArgs e)
		{
			this.PhotoIdSearch();
		}

		private void PhotoIdSearch()
		{
			this.searchbyCode.Visibility = Visibility.Collapsed;
			while (true)
			{
				this.searchbyPhotoId.Visibility = Visibility.Visible;
				while (true)
				{
					this.searchbyTimeRange.Visibility = Visibility.Hidden;
                    //this.txtRFID.Text = "";
                    this.txtRFID.Text = GetLastPhotoID();
                    if (7 == 0)
					{
						goto IL_CD;
					}
					if (3 == 0)
					{
						goto IL_93;
					}
					this.txtRFID.Focus();
					this._txtKeyboard = this.txtRFID;
					this.dtselect.SelectedDate = null;
					if (!false)
					{
						this.searchbyGroup.Visibility = Visibility.Collapsed;
						goto IL_93;
					}
					IL_A9:
					if (false)
					{
						goto IL_CC;
					}
					if (!false)
					{
						goto Block_6;
					}
					continue;
					IL_93:
					if (7 != 0)
					{
						this.txtgroupname.Text = "";
						goto IL_A9;
					}
					break;
				}
			}
			Block_6:
			this.KeyBorder1.Visibility = Visibility.Collapsed;
			this.Ok.IsDefault = true;
			IL_CC:
			IL_CD:
			App.ViewOrderSearchIndex = this.rdbtnPhotoId.TabIndex;
		}

        private String GetLastPhotoID()
        {
            PhotoBusiness photoBusiness = new PhotoBusiness();
            return photoBusiness.GetSearchNoPhotoInfo();

        }
        private void rdbtnTime_Click(object sender, RoutedEventArgs e)
		{
			if (true)
			{
				if (!true)
				{
					goto IL_B3;
				}
				this.ChangeKey();
				this.searchbyCode.Visibility = Visibility.Collapsed;
			}
			while (true)
			{
				if (5 != 0)
				{
					UIElement expr_2E = this.searchbyPhotoId;
					Visibility expr_33 = Visibility.Hidden;
					if (2 != 0)
					{
						expr_2E.Visibility = expr_33;
					}
				}
				IL_3D:
				this.searchbyTimeRange.Visibility = Visibility.Visible;
				if (4 == 0)
				{
					return;
				}
				this.txtRFID.Text = "0";
				this.dtselect.SelectedDate = new DateTime?(new CustomBusineses().ServerDateTime().Date);
				if (!false)
				{
					this.searchbyGroup.Visibility = Visibility.Collapsed;
					if (5 != 0)
					{
						break;
					}
					continue;
				}
				goto IL_3D;
			}
			this.txtgroupname.Text = "";
			IL_B3:
			this.KeyBorder1.Visibility = Visibility.Collapsed;
			App.ViewOrderSearchIndex = this.rdbtnTime.TabIndex;
			this.btnsearch.IsDefault = true;
		}

		private void dtselectEnter_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//this.dtselect.Focus();
			//Keyboard.Focus(this.dtselect);
			//this.btnsearch.IsDefault = true;
		}

		private void rdbtnGroup_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (2 == 0)
				{
					goto IL_83;
				}
				this.ChangeKey();
				if (false)
				{
					goto IL_B0;
				}
				this.searchbyCode.Visibility = Visibility.Collapsed;
				this.searchbyPhotoId.Visibility = Visibility.Collapsed;
				this.searchbyTimeRange.Visibility = Visibility.Collapsed;
				this.searchbyGroup.Visibility = Visibility.Visible;
				IL_59:
				this.txtRFID.Text = "0";
				this.txtgroupname.Focus();
				FocusManager.SetFocusedElement(this, this.txtgroupname);
				IL_83:
				Keyboard.Focus(this.txtgroupname);
				this._txtKeyboard = this.txtgroupname;
				this.dtselect.SelectedDate = null;
				IL_B0:
				this.btnsearchgroup.IsDefault = true;
				if (false)
				{
					goto IL_83;
				}
				App.ViewOrderSearchIndex = this.rdbtnGroup.TabIndex;
				if (false)
				{
					goto IL_59;
				}
			}
			catch (Exception var_0_120)
			{
			}
			do
			{
				if (!false)
				{
				}
			}
			while (!true);
		}

		private void txtgroupname_GotFocus(object sender, RoutedEventArgs e)
		{
			this.KeyBorder1.Visibility = Visibility.Visible;
		}

		private void rdbtnQRCode_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.ChangeKey();
				this.searchbyPhotoId.Visibility = Visibility.Collapsed;
				if (true)
				{
					this.searchbyTimeRange.Visibility = Visibility.Collapsed;
					this.searchbyGroup.Visibility = Visibility.Collapsed;
					this.searchbyCode.Visibility = Visibility.Visible;
					this.txtRFID.Text = "0";
					this.txtQRCode.Focus();
				}
				this._txtKeyboard = this.txtQRCode;
				this.dtselect.SelectedDate = null;
				this.SetQrCodeSearchState();
				this.btnSearchQRCode.IsDefault = true;
			}
			catch (Exception serviceException)
			{
				ErrorHandler.ErrorHandler.LogError(serviceException);
			}
		}

		private void txtQRCode_GotFocus(object sender, RoutedEventArgs e)
		{
			while (true)
			{
				if (!false)
				{
				}
				while (8 != 0)
				{
					this._txtKeyboard = this.txtQRCode;
					if (false)
					{
						break;
					}
					this.KeyBorder1.Visibility = Visibility.Visible;
					if (8 != 0)
					{
						return;
					}
				}
			}
		}

		private void cmbQRCodeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.cmbQRCodeType.SelectedValue != null)
			{
				App.SelectedCodeType = (int)this.cmbQRCodeType.SelectedValue;
				if (string.Compare(this.cmbQRCodeType.SelectedValue.ToString(), "404", true) == 0)
				{
					this.txtQRCode.Text = this._cardCode;
					this.txtQRCode.IsEnabled = false;
					this.KeyBorder1.Visibility = Visibility.Collapsed;
				}
				else
				{
					do
					{
						this.KeyBorder1.Visibility = Visibility.Visible;
						this.txtQRCode.Text = string.Empty;
					}
					while (false);
					this.txtQRCode.IsEnabled = true;
					this.txtQRCode.Focus();
				}
			}
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			this.ClearLocalResouces();
		}

		private void ClearLocalResouces()
		{
			this.cmbQRCodeType.SelectionChanged -= new SelectionChangedEventHandler(this.cmbQRCodeType_SelectionChanged);
			UIElement expr_26 = this.txtQRCode;
			RoutedEventHandler expr_36 = new RoutedEventHandler(this.txtQRCode_GotFocus);
			if (5 != 0)
			{
				expr_26.GotFocus -= expr_36;
			}
			this.txtgroupname.GotFocus -= new RoutedEventHandler(this.txtgroupname_GotFocus);
			this.rdbtnGroup.Click -= new RoutedEventHandler(this.rdbtnGroup_Click);
			this.rdbtnPhotoId.Click -= new RoutedEventHandler(this.rdbtnPhotoId_Click);
			base.Loaded -= new RoutedEventHandler(this.Window_Loaded);
			this.txtRFID.KeyDown -= new KeyEventHandler(this.txtRFID_KeyDown);
			this.btnLogout.Click -= new RoutedEventHandler(this.btnLogout_Click);
			this.dtselect.PreviewKeyDown -= new KeyEventHandler(this.DatePicker_PreviewKeyDown);
			this.dtselect.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(this.dtselectEnter_SelectionChanged);
			this.btnLogout.Click -= new RoutedEventHandler(this.btnLogout_Click);
			this.btnback.Click -= new RoutedEventHandler(this.btn_Click);
			this.btnRefresh.Click -= new RoutedEventHandler(this.btnRefresh_Click);
			this.btnHome.Click -= new RoutedEventHandler(this.btnHome_Click);
			this.btnA.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnB.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnC.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnD.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnE.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnF.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnG.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnH.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnI.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnJ.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnK.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnL.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnM.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnN.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnO.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnP.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnQ.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnR.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnS.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnT.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnU.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnV.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnW.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnX.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnY.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btnZ.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btn1.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
			this.btn0.Click -= new RoutedEventHandler(this.btn_Click);
			this.btn2.Click -= new RoutedEventHandler(this.btn_Click);
			this.btn3.Click -= new RoutedEventHandler(this.btn_Click);
			this.btn4.Click -= new RoutedEventHandler(this.btn_Click);
			this.btn5.Click -= new RoutedEventHandler(this.btn_Click);
			this.btn6.Click -= new RoutedEventHandler(this.btn_Click);
			this.btn7.Click -= new RoutedEventHandler(this.btn_Click);
			this.btn8.Click -= new RoutedEventHandler(this.btn_Click);
			this.btn9.Click -= new RoutedEventHandler(this.btn_Click);
			base.Closed -= new EventHandler(this.Window_Closed);
			this.txtRFID.KeyDown -= new KeyEventHandler(this.bttnLogin_Enter);
			this._txtKeyboard = null;
			MemoryManagement.FlushMemory();
		}

		public void GetAllDropdown()
		{
			do
			{
				try
				{
					if (!false)
					{
						this.LoadPhotoGrapher();
						if (false)
						{
							goto IL_20;
						}
						this.LoadLocation(null);
					}
					if (-1 != 0)
					{
					}
					this.LoadSubStore();
					this.FillCharacter();
					IL_20:;
				}
				catch (Exception serviceException)
				{
					ErrorHandler.ErrorHandler.LogError(serviceException);
				}
			}
			while (4 == 0 || false);
		}

		public void LoadSubStore()
		{
            //SearchByPhoto.c__DisplayClass1 c__DisplayClass = new SearchByPhoto.c__DisplayClass1();
            //SearchByPhoto.c__DisplayClass1 arg_3A_0 = c__DisplayClass;
          //  SearchByPhoto c__DisplayClass = new SearchByPhoto();
           // SearchByPhoto arg_3A_0 = c__DisplayClass;
            List<string> str = new List<string>();
			string arg_C8_0 = LoginUser.DefaultSubstores;
			char[] expr_16 = new char[1];
			char[] array;
			if (!false)
			{
				array = expr_16;
			}
			array[0] = ',';
            str = arg_C8_0.Split(array).ToList<string>();
            List<SubStoresInfo> oList = new StoreSubStoreDataBusniess().GetSubstoreData().Where(delegate(SubStoresInfo l)
            {
                if (false)
                {
                    goto IL_20;
                }
                bool arg_27_0;
                bool arg_46_0 = arg_27_0 = str.Contains(l.DG_SubStore_pkey.ToString());
            IL_16:
                if (7 == 0 || 8 == 0)
                {
                    goto IL_24;
                }
                bool flag;
                if (!false)
                {
                    flag = arg_46_0;
                }
            IL_20:
                arg_46_0 = (arg_27_0 = flag);
            IL_24:
                if (!false)
                {
                    return arg_27_0;
                }
                goto IL_16;
            }).ToList<SubStoresInfo>();
            do
            {
                if (-1 != 0)
                {
                    CommonUtility.BindComboWithSelect<SubStoresInfo>(this.cmbSubstore, oList, "DG_SubStore_Name", "DG_SubStore_pkey", 0, ClientConstant.SelectString);
                }
            }
            while (-1 == 0);
            this.cmbSubstore.SelectedValue = "0";
		}

		public void LoadLocation(List<LocationInfo> objLocation = null)
		{
			List<LocationInfo> oList;
			if (2 != 0)
			{
				oList = null;
				if (8 != 0)
				{
					bool arg_69_0 = objLocation != null;
					bool expr_6C;
					do
					{
						bool flag = arg_69_0;
						expr_6C = (arg_69_0 = flag);
					}
					while (false);
					if (expr_6C)
					{
						oList = objLocation;
						goto IL_2B;
					}
					oList = new LocationBusniess().GetLocationName(LoginUser.StoreId);
				}
			}
			IL_23:
			if (!false)
			{
			}
			IL_2B:
			CommonUtility.BindComboWithSelect<LocationInfo>(this.cmbLocation, oList, "DG_Location_Name", "DG_Location_pkey", 0, ClientConstant.SelectString);
			this.cmbLocation.SelectedValue = "0";
			if (5 != 0)
			{
				return;
			}
			goto IL_23;
		}

		public void LoadPhotoGrapher()
		{
			if (false)
			{
				goto IL_44;
			}
			if (!false)
			{
			}
			List<PhotoGraphersInfo> photoGraphersList = new UserBusiness().GetPhotoGraphersList(LoginUser.StoreId);
			ComboBox expr_11 = this.cmbPhotographer;
			List<PhotoGraphersInfo> expr_63 = photoGraphersList;
			string expr_18 = "DG_User_Name";
			string expr_1D = "DG_User_pkey";
			int expr_22 = 0;
			string expr_23 = ClientConstant.SelectString;
			if (6 != 0)
			{
				CommonUtility.BindComboWithSelect<PhotoGraphersInfo>(expr_11, expr_63, expr_18, expr_1D, expr_22, expr_23);
			}
			IL_31:
			if (2 != 0)
			{
				this.cmbPhotographer.SelectedValue = "0";
			}
			IL_44:
			if (!false)
			{
				return;
			}
			goto IL_31;
		}

		private void FillCharacter()
		{
			do
			{
				new List<CharacterInfo>();
			}
			while (false);
			List<CharacterInfo> oList = new CharacterBusiness().GetCharacter().ToList<CharacterInfo>();
			do
			{
				CommonUtility.BindComboWithSelect<CharacterInfo>(this.cmbCharacter, oList, "DG_Character_Name", "DG_Character_Pkey", 0, ClientConstant.SelectString);
			}
			while (3 == 0);
			if (!false)
			{
				this.cmbCharacter.SelectedValue = "0";
			}
		}

		private void GetPrintersStatus()
		{
			//ObservableCollection<SystemPrinterQueuee.PrinterDetails> observableCollection = new ObservableCollection<SystemPrinterQueuee.PrinterDetails>();
			PrintServer printServer = new PrintServer();
			PrintQueueCollection printQueues = printServer.GetPrintQueues(new EnumeratedPrintQueueTypes[]
			{
				EnumeratedPrintQueueTypes.Local,
				EnumeratedPrintQueueTypes.Connections
			});
			IEnumerator enumerator;
			if (-1 != 0)
			{
				List<AssociatedPrintersInfo> associatedPrintersName = new PrinterBusniess().GetAssociatedPrintersName(LoginUser.SubStoreId);
				if (associatedPrintersName == null)
				{
					return;
				}
				IEnumerable<string> enumerable = (from t in associatedPrintersName
				select t.DG_AssociatedPrinters_Name).Distinct<string>();
				enumerator = enumerable.GetEnumerator();
				goto IL_116;
			}
			IL_A6:
			//c__DisplayClass.name = enumerator.Current;

            PrintQueue printQueue = printQueues.FirstOrDefault((PrintQueue t) => t.FullName == enumerator.Current.ToString());
			if (printQueue == null)
			{
				goto IL_116;
			}
			string printerStatus = this.getPrinterStatus(printQueue.FullName);
			bool flag = !printerStatus.Equals("Offline");
			bool arg_FB_0 = flag;
			IL_FB:
			if (!arg_FB_0)
			{
				//observableCollection.Add(new SystemPrinterQueuee.PrinterDetails(printQueue.FullName, null, printerStatus));
			}
			IL_116:
			bool expr_118 = arg_FB_0 = enumerator.MoveNext();
			if (false)
			{
				goto IL_FB;
			}
			if (expr_118)
			{
				goto IL_A6;
			}
			//this.lstprinters.ItemsSource = observableCollection;
		}

		private void SetQrCodeSearchState()
		{
			bool flag = !(this.rdbtnTime.IsChecked != true);
			if (3 == 0)
			{
				goto IL_73;
			}
			if (!flag)
			{
				goto IL_EA;
			}
			IL_43:
			flag = (this.cmbQRCodeType.SelectedValue == null || Convert.ToInt32(this.cmbQRCodeType.SelectedValue) != 404);
			IL_73:
			if (flag)
			{
				this.txtQRCode.Text = string.Empty;
				if (!false)
				{
					this.txtQRCode.IsEnabled = true;
					goto IL_BD;
				}
			}
			this.txtQRCode.Text = this._cardCode;
			if (false)
			{
				goto IL_43;
			}
			this.txtQRCode.IsEnabled = false;
			IL_99:
			goto IL_EA;
			IL_BD:
			this.txtQRCode.Focus();
			if (false)
			{
				goto IL_99;
			}
			FocusManager.SetFocusedElement(this, this.txtQRCode);
			Keyboard.Focus(this.txtQRCode);
			IL_E6:
			if (2 == 0)
			{
				goto IL_BD;
			}
			IL_EA:
			if (3 != 0)
			{
				return;
			}
			goto IL_E6;
		}

		private string getPrinterStatus(string printerName)
		{
			string text = "";
			ManagementScope managementScope = new ManagementScope("\\root\\cimv2");
			managementScope.Connect();
			string result;
			do
			{
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
				ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator();
				try
				{
					while (true)
					{
						bool flag = enumerator.MoveNext();
						ManagementObject managementObject;
						if (5 != 0)
						{
							if (!flag)
							{
								break;
							}
							managementObject = (ManagementObject)enumerator.Current;
						}
						if (2 == 0)
						{
							goto IL_CE;
						}
						string text2 = managementObject["Name"].ToString().ToLower();
						string arg_D4_0;
						if (text2.Equals(printerName.ToLower()))
						{
							if (7 != 0)
							{
								Console.WriteLine("Printer = " + managementObject["Name"]);
								if (!managementObject["WorkOffline"].ToString().ToLower().Equals("true"))
								{
									arg_D4_0 = "Online";
									goto IL_D3;
								}
								goto IL_CE;
							}
						}
						continue;
						IL_D3:
						text = arg_D4_0;
						continue;
						IL_CE:
						arg_D4_0 = "Offline";
						goto IL_D3;
					}
				}
				finally
				{
					bool arg_FA_0;
					bool expr_F1 = arg_FA_0 = (enumerator == null);
					if (!false)
					{
						bool flag = expr_F1;
						arg_FA_0 = flag;
					}
					if (!arg_FA_0)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				result = text;
				while (false)
				{
				}
			}
			while (6 == 0);
			return result;
		}

		private void GetMktImgInfo()
		{
			if (2 != 0)
			{
				try
				{
					if (!false)
					{
						List<long> objList = new List<long>
						{
							24L,
							25L
						};
						List<iMIXConfigurationInfo> list = (from o in new ConfigBusiness().GetNewConfigValues(LoginUser.SubStoreId)
						where objList.Contains(o.IMIXConfigurationMasterId)
						select o).ToList<iMIXConfigurationInfo>();
						int arg_85_0;
						if (list != null)
						{
							int expr_73 = arg_85_0 = list.Count;
							if (!false)
							{
								arg_85_0 = ((expr_73 <= 0) ? 1 : 0);
							}
						}
						else
						{
							arg_85_0 = 1;
						}
						if (arg_85_0 == 0)
						{
							List<iMIXConfigurationInfo>.Enumerator enumerator = list.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									iMIXConfigurationInfo current = enumerator.Current;
									long iMIXConfigurationMasterId = current.IMIXConfigurationMasterId;
									if (iMIXConfigurationMasterId <= 25L)
									{
										if (iMIXConfigurationMasterId >= 24L)
										{
											switch ((int)(iMIXConfigurationMasterId - 24L))
											{
											case 0:
												this._mktImgPath = current.ConfigurationValue;
												break;
											case 1:
												goto IL_DD;
											}
										}
									}
									IL_103:
									if (4 != 0)
									{
										continue;
									}
									goto IL_DD;
									goto IL_103;
									IL_DD:
									this._mktImgTime = ((current.ConfigurationValue != null) ? Convert.ToInt32(current.ConfigurationValue) : 10) * 1000;
									goto IL_103;
								}
							}
							finally
							{
								((IDisposable)enumerator).Dispose();
								if (2 != 0)
								{
								}
							}
						}
					}
				}
				catch (Exception serviceException)
				{
					ErrorHandler.ErrorHandler.LogError(serviceException);
					if (!false)
					{
					}
				}
				if (!false)
				{
				}
			}
		}

		private void BindCodeType()
		{
			try
			{
				while (true)
				{
                     CardBusiness cardBusiness = new  CardBusiness();
					Dictionary<string, int> cardCodeTypes = cardBusiness.GetCardCodeTypes();
					Dictionary<string, int> dictionary = new Dictionary<string, int>();
					dictionary.Add("--Select--", 0);
					using (Dictionary<string, int>.Enumerator enumerator = cardCodeTypes.GetEnumerator())
					{
						while (true)
						{
							while (!false && enumerator.MoveNext())
							{
								KeyValuePair<string, int> current = enumerator.Current;
								if (!false)
								{
									dictionary.Add(current.Key, current.Value);
								}
							}
							break;
						}
					}
					this.cmbQRCodeType.ItemsSource = dictionary;
					while (true)
					{
						IL_92:
						this.cmbQRCodeType.SelectedValue = "0";
						while (2 != 0)
						{
							this._cardCode = cardBusiness.GetCardCode(404);
							if (!false)
							{
								if (-1 != 0)
								{
									goto Block_4;
								}
                                goto IL_92;
							}
						}
						break;
					}
				}
				Block_4:;
			}
			catch (Exception serviceException)
			{
				ErrorHandler.ErrorHandler.LogError(serviceException);
			}
			if (true)
			{
			}
		}

		private bool IsImageExists(string code)
		{
			bool result;
			try
			{
				result = (new PhotoBusiness().GetImagesBYQRCode(code, RobotImageLoader.IsAnonymousQrCodeEnabled).Count > 0);
			}
			catch (Exception serviceException)
			{
				ErrorHandler.ErrorHandler.LogError(serviceException);
				result = false;
			}
			return result;
		}

		private void ChangeKey()
		{
			if (this.rdbtnTime.IsChecked == true)
			{
				this.btnA.Content = "A";
				goto IL_50;
			}
			if (!false)
			{
				this.btnA.Content = "a";
				if (2 != 0)
				{
					this.btnB.Content = "b";
					this.btnC.Content = "c";
					this.btnD.Content = "d";
					this.btnE.Content = "e";
					this.btnF.Content = "f";
					this.btnG.Content = "g";
					this.btnH.Content = "h";
					this.btnI.Content = "i";
					this.btnJ.Content = "j";
					this.btnK.Content = "k";
					this.btnL.Content = "l";
					this.btnM.Content = "m";
					this.btnN.Content = "n";
					this.btnO.Content = "o";
					goto IL_31E;
				}
				goto IL_210;
			}
			while (true)
			{
				IL_BD:
				this.btnH.Content = "H";
				this.btnI.Content = "I";
				this.btnJ.Content = "J";
				if (false)
				{
					break;
				}
				this.btnK.Content = "K";
				this.btnL.Content = "L";
				if (!false)
				{
					this.btnM.Content = "M";
					this.btnN.Content = "N";
					this.btnO.Content = "O";
					this.btnP.Content = "P";
					this.btnQ.Content = "Q";
					this.btnR.Content = "R";
					this.btnS.Content = "S";
					this.btnT.Content = "T";
					this.btnU.Content = "U";
					this.btnV.Content = "V";
					this.btnW.Content = "W";
					this.btnX.Content = "X";
					this.btnY.Content = "Y";
					this.btnZ.Content = "Z";
					if (true)
					{
						goto IL_210;
					}
				}
			}
			IL_50:
			this.btnB.Content = "B";
			this.btnC.Content = "C";
			this.btnD.Content = "D";
			this.btnE.Content = "E";
			if (false)
			{
				goto IL_395;
			}
			this.btnF.Content = "F";
			this.btnG.Content = "G";
			//goto IL_BD;
			IL_210:
			return;
			IL_31E:
			this.btnP.Content = "p";
			this.btnQ.Content = "q";
			this.btnR.Content = "r";
			this.btnS.Content = "s";
			this.btnT.Content = "t";
			this.btnU.Content = "u";
			this.btnV.Content = "v";
			IL_395:
			this.btnW.Content = "w";
			this.btnX.Content = "x";
			this.btnY.Content = "y";
			this.btnZ.Content = "z";
			if (false)
			{
				goto IL_31E;
			}
		}

		public void LoadData()
		{
			try
			{
				string searchCriteria = RobotImageLoader.SearchCriteria;
				if (searchCriteria == null)
				{
					goto IL_E0;
				}
				bool arg_36_0;
				if (!(searchCriteria == "PhotoId"))
				{
					arg_36_0 = (searchCriteria == "Time");
				}
				else
				{
					if (-1 != 0)
					{
						this.rdbtnPhotoId.IsChecked = new bool?(true);
						this.searchbyPhotoId.Visibility = Visibility.Visible;
						this.searchbyTimeRange.Visibility = Visibility.Hidden;
						this.txtRFID.Text = "";
						goto IL_84;
					}
					goto IL_11D;
				}
				IL_36:
				if (!arg_36_0)
				{
					goto IL_E0;
				}
				goto IL_92;
				IL_84:
				this.txtRFID.Focus();
				goto IL_105;
				IL_92:
				this.rdbtnTime.IsChecked = new bool?(true);
				this.searchbyPhotoId.Visibility = Visibility.Hidden;
				this.searchbyTimeRange.Visibility = Visibility.Visible;
				if (true)
				{
					this.txtRFID.Text = "";
					this.txtRFID.Focus();
					goto IL_105;
				}
				goto IL_84;
				IL_E0:
				this.txtRFID.Text = "";
				arg_36_0 = this.txtRFID.Focus();
				if (-1 == 0)
				{
					goto IL_36;
				}
				IL_105:
				this.GetPrintersStatus();
				this.txbUserName.Text = LoginUser.UserName;
				IL_11D:
				this.txbStoreName.Text = LoginUser.StoreName;
				if (Convert.ToBoolean(new ConfigBusiness().GetConfigEnableGroup(LoginUser.SubStoreId)))
				{
					this.rdbtnGroup.Visibility = Visibility.Visible;
				}
				else
				{
					if (false)
					{
						goto IL_92;
					}
					this.rdbtnGroup.Visibility = Visibility.Collapsed;
					this.PhotoIdSearch();
				}
			}
			catch (Exception serviceException)
			{
				do
				{
					ErrorHandler.ErrorHandler.LogError(serviceException);
				}
				while (false);
			}
		}


        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        //void IComponentConnector.Connect(int connectionId, object target)
        //{
        //    switch (connectionId)
        //    {
        //    case 1:
        //        ((SearchByPhoto)target).Loaded += new RoutedEventHandler(this.Window_Loaded);
        //        ((SearchByPhoto)target).Closed += new EventHandler(this.Window_Closed);
        //        return;
        //    case 2:
        //        this.pnlTop = (StackPanel)target;
        //        return;
        //    case 3:
        //        this.vb1 = (Viewbox)target;
        //        return;
        //    case 4:
        //        this.bg_withlogo = (StackPanel)target;
        //        return;
        //    case 5:
        //        this.bg = (Image)target;
        //        return;
        //    case 6:
        //        this.pnlFooter = (StackPanel)target;
        //        return;
        //    case 7:
        //        this.pnlUserDetails = (StackPanel)target;
        //        return;
        //    case 8:
        //        this.btnUserName = (Button)target;
        //        return;
        //    case 9:
        //        this.txbUserName = (TextBlock)target;
        //        return;
        //    case 10:
        //        this.txbStoreName = (TextBlock)target;
        //        return;
        //    case 11:
        //        this.btnLogout = (Button)target;
        //        this.btnLogout.Click += new RoutedEventHandler(this.btnLogout_Click);
        //        return;
        //    case 12:
        //        this.rdbtnPhotoId = (RadioButton)target;
        //        this.rdbtnPhotoId.Checked += new RoutedEventHandler(this.rdbtnPhotoId_Click);
        //        return;
        //    case 13:
        //        this.rdbtnTime = (RadioButton)target;
        //        this.rdbtnTime.Checked += new RoutedEventHandler(this.rdbtnTime_Click);
        //        return;
        //    case 14:
        //        this.rdbtnGroup = (RadioButton)target;
        //        this.rdbtnGroup.Checked += new RoutedEventHandler(this.rdbtnGroup_Click);
        //        return;
        //    case 15:
        //        this.searchbyPhotoId = (Grid)target;
        //        return;
        //    case 16:
        //        this.txtRFID = (TextBox)target;
        //        this.txtRFID.KeyDown += new KeyEventHandler(this.txtRFID_KeyDown);
        //        this.txtRFID.AddHandler(Keyboard.KeyDownEvent, new KeyEventHandler(this.bttnLogin_Enter));
        //        return;
        //    case 17:
        //        this.KeyBorder = (Grid)target;
        //        return;
        //    case 18:
        //        this.btn1 = (Button)target;
        //        this.btn1.Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 19:
        //        this.btn2 = (Button)target;
        //        this.btn2.Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 20:
        //        this.btn3 = (Button)target;
        //        this.btn3.Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 21:
        //        this.btn4 = (Button)target;
        //        this.btn4.Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 22:
        //        this.btn5 = (Button)target;
        //        this.btn5.Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 23:
        //        this.btn6 = (Button)target;
        //        this.btn6.Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 24:
        //        this.btn7 = (Button)target;
        //        this.btn7.Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 25:
        //        this.btn8 = (Button)target;
        //        this.btn8.Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 26:
        //        break;
        //    case 27:
        //        this.btn0 = (Button)target;
        //        this.btn0.Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 28:
        //        this.btnback = (Button)target;
        //        this.btnback.Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 29:
        //        this.Ok = (Button)target;
        //        this.Ok.Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 30:
        //        this.Cancel = (Button)target;
        //        this.Cancel.Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 31:
        //        this.searchbyTimeRange = (Border)target;
        //        return;
        //    case 32:
        //        this.dtselect = (DatePicker)target;
        //        this.dtselect.KeyUp += new KeyEventHandler(this.DatePicker_PreviewKeyDown);
        //        this.dtselect.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(this.dtselectEnter_SelectionChanged);
        //        return;
        //    case 33:
        //        this.dtselectToDate = (DatePicker)target;
        //        this.dtselectToDate.KeyUp += new KeyEventHandler(this.DatePicker_PreviewKeyDown);
        //        this.dtselectToDate.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(this.dtselectEnter_SelectionChanged);
        //        return;
        //    case 34:
        //        this.cmbLocation = (ComboBox)target;
        //        return;
        //    case 35:
        //        this.cmbPhotographer = (ComboBox)target;
        //        return;
        //    case 36:
        //        this.cmbFromTime = (ComboBox)target;
        //        return;
        //    case 37:
        //        this.cmbToTime = (ComboBox)target;
        //        return;
        //    case 38:
        //        this.cmbQRCodeType = (ComboBox)target;
        //        this.cmbQRCodeType.SelectionChanged += new SelectionChangedEventHandler(this.cmbQRCodeType_SelectionChanged);
        //        return;
        //    case 39:
        //        this.cmbCharacter = (ComboBox)target;
        //        return;
        //    case 40:
        //        this.txtQRCode = (TextBox)target;
        //        this.txtQRCode.GotFocus += new RoutedEventHandler(this.txtQRCode_GotFocus);
        //        return;
        //    case 41:
        //        this.btnsearchold = (Button)target;
        //        this.btnsearchold.Click += new RoutedEventHandler(this.btnSearchDetailWithQrcode_Click);
        //        return;
        //    case 42:
        //        this.btnsearch = (Button)target;
        //        this.btnsearch.Click += new RoutedEventHandler(this.btnSearchDetailWithQrcode_Click);
        //        return;
        //    case 43:
        //        this.cmbSubstore = (ComboBox)target;
        //        return;
        //    case 44:
        //        this.searchbyGroup = (Border)target;
        //        return;
        //    case 45:
        //        this.txtgroupname = (TextBox)target;
        //        this.txtgroupname.GotFocus += new RoutedEventHandler(this.txtgroupname_GotFocus);
        //        return;
        //    case 46:
        //        this.btnsearchgroup = (Button)target;
        //        this.btnsearchgroup.Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 47:
        //        this.searchbyCode = (Border)target;
        //        return;
        //    case 48:
        //        this.btnSearchQRCode = (Button)target;
        //        this.btnSearchQRCode.Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 49:
        //        this.btnRefresh = (Button)target;
        //        this.btnRefresh.Click += new RoutedEventHandler(this.btnRefresh_Click);
        //        return;
        //    case 50:
        //        this.lstprinters = (ListBox)target;
        //        return;
        //    case 51:
        //        this.KeyBorder1 = (Border)target;
        //        return;
        //    case 52:
        //        this.btnQ = (Button)target;
        //        this.btnQ.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 53:
        //        this.btnW = (Button)target;
        //        this.btnW.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 54:
        //        this.btnE = (Button)target;
        //        this.btnE.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 55:
        //        this.btnR = (Button)target;
        //        this.btnR.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 56:
        //        this.btnT = (Button)target;
        //        this.btnT.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 57:
        //        this.btnY = (Button)target;
        //        this.btnY.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 58:
        //        this.btnU = (Button)target;
        //        this.btnU.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        if (4 != 0)
        //        {
        //            return;
        //        }
        //        return;
        //    case 59:
        //        this.btnI = (Button)target;
        //        this.btnI.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 60:
        //        this.btnO = (Button)target;
        //        this.btnO.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 61:
        //        this.btnP = (Button)target;
        //        this.btnP.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 62:
        //        this.Delete = (Button)target;
        //        this.Delete.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 63:
        //        this.btnA = (Button)target;
        //        this.btnA.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 64:
        //        this.btnS = (Button)target;
        //        this.btnS.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        if (!false)
        //        {
        //            return;
        //        }
        //        break;
        //    case 65:
        //        this.btnD = (Button)target;
        //        this.btnD.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 66:
        //        this.btnF = (Button)target;
        //        this.btnF.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 67:
        //        this.btnG = (Button)target;
        //        this.btnG.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 68:
        //        this.btnH = (Button)target;
        //        this.btnH.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 69:
        //        this.btnJ = (Button)target;
        //        this.btnJ.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 70:
        //        this.btnK = (Button)target;
        //        this.btnK.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 71:
        //        this.btnL = (Button)target;
        //        this.btnL.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 72:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 73:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 74:
        //        this.btnZ = (Button)target;
        //        this.btnZ.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 75:
        //        this.btnX = (Button)target;
        //        this.btnX.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 76:
        //        this.btnC = (Button)target;
        //        this.btnC.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 77:
        //        this.btnV = (Button)target;
        //        this.btnV.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 78:
        //        this.btnB = (Button)target;
        //        this.btnB.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 79:
        //        this.btnN = (Button)target;
        //        this.btnN.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 80:
        //        this.btnM = (Button)target;
        //        this.btnM.Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 81:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 82:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 83:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 84:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 85:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 86:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 87:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 88:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 89:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 90:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 91:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 92:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 93:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 94:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 95:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 96:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 97:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 98:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 99:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 100:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 101:
        //        ((Button)target).Click += new RoutedEventHandler(this.btn_Click_keyboard);
        //        return;
        //    case 102:
        //        this.btnHome = (Button)target;
        //        this.btnHome.Click += new RoutedEventHandler(this.btnHome_Click);
        //        return;
        //    default:
        //        this._contentLoaded = true;
        //        return;
        //    }
        //    this.btn9 = (Button)target;
        //    this.btn9.Click += new RoutedEventHandler(this.btn_Click);
        //}
	}
}
