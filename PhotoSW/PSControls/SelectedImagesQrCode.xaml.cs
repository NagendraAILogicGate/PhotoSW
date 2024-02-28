using PhotoSW.Common;
using PhotoSW.DataSync.Controller;
using DigiPhoto.DigiSync.Model;
using DigiPhoto.DigiSync.ServiceLibrary.Interface;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit;
using DigiPhoto;

namespace PhotoSW.PSControls
{
    public partial class SelectedImagesQrCode : UserControl, IComponentConnector, IStyleConnector
    {
        public static int PackageCode;

        public bool IsQrCodeUsed = false;

        public PackageInfo packageInfo = new PackageInfo();

        private bool _hideRequest = false;

        private List<LstMyItems> _result;

        private UIElement _parent;

        public List<string> lstQrCode = new List<string>();

        public static readonly DependencyProperty MessageQrCode2Property = DependencyProperty.Register("MessageQrCode2", typeof(string), typeof(ModalDialog), new UIPropertyMetadata(string.Empty));

       

        public List<LstMyItems> _SelectedImage
        {
            get;
            set;
        }

        public List<LstMyItems> _lstSelectedImage
        {
            get;
            set;
        }

        public List<string> PreviousImage
        {
            get;
            set;
        }

        public int maxSelectedPhotos
        {
            get;
            set;
        }

        public bool IsBundled
        {
            get;
            set;
        }

        public bool IsPackage
        {
            get;
            set;
        }

        public int ProductTypeID
        {
            get;
            set;
        }

        public string QRCode
        {
            get;
            set;
        }

        public bool ValidateQRCodeChk
        {
            get;
            set;
        }

        public string MessageQrCode2
        {
            get
            {
                return (string)base.GetValue(SelectedImagesQrCode.MessageQrCode2Property);
            }
            set
            {
                base.SetValue(SelectedImagesQrCode.MessageQrCode2Property, value);
            }
        }

        public SelectedImagesQrCode()
        {
            string text = string.Empty;
            try
            {
                this.InitializeComponent();
                this.lstSelectedImage.Items.Clear();
                foreach (LstMyItems current in RobotImageLoader.PrintImages)
                {
                    text = text + current.PhotoId + ",";
                    this.lstSelectedImage.Items.Add(current);
                }
                List<string> list = new PhotoBusiness().GetQRCodeBYImages(text).ToList<string>();
                if (list.Count == 1)
                {
                    this.txtQRCode.Text = list[0].ToString();
                }
                if (string.IsNullOrEmpty(App.QRCodeWebUrl))
                {
                    string qRCodeWebUrl = new StoreSubStoreDataBusniess().GetQRCodeWebUrl();
                    App.QRCodeWebUrl = (string.IsNullOrEmpty(qRCodeWebUrl) ? " " : qRCodeWebUrl);
                }
            }
            catch (Exception var_4_122)
            {
            }
        }

        public void SetParentQrCode(UIElement parent)
        {
            do
            {
                this._parent = parent;
            }
            while (2 == 0);
            if (false)
            {
                goto IL_34;
            }
            bool arg_1F_0 = this.lstSelectedImage.Items.Count > 0;
            bool expr_1F;
            do
            {
                expr_1F = (arg_1F_0 = !arg_1F_0);
            }
            while (false);
            bool flag = expr_1F;
        IL_26:
            if (flag)
            {
                this.SPSelectAll.Visibility = Visibility.Hidden;
                return;
            }
            this.SPSelectAll.Visibility = Visibility.Visible;
        IL_34:
            if (!false && 3 == 0)
            {
                goto IL_26;
            }
        }

        public List<LstMyItems> ShowQrCodeHandlerDialog(string message)
        {
            this.MessageQrCode2 = message;
            base.Visibility = Visibility.Visible;
            if (7 == 0)
            {
                goto IL_F0;
            }
            this.IsQrCodeUsed = false;
            this.txtQRCode.Text = this.QRCode;
            base.Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(delegate
            {
                this.txtQRCode.Focus();
                Keyboard.Focus(this.txtQRCode);
            }));
            this.LoadCheckBox();
            if (false)
            {
                goto IL_EE;
            }
            this._parent.IsEnabled = true;
            this.CheckSelectedImg();
            if (!false)
            {
                this._hideRequest = false;
                goto IL_F0;
            }
        IL_E7:
            Thread.Sleep(20);
        IL_EE:
        IL_F0:
            bool arg_F9_0 = !this._hideRequest;
            bool expr_FA;
            do
            {
                bool flag = arg_F9_0;
                expr_FA = (arg_F9_0 = flag);
            }
            while (3 == 0);
            if (expr_FA)
            {
                bool arg_B1_0;
                if (!base.Dispatcher.HasShutdownStarted)
                {
                    arg_B1_0 = !base.Dispatcher.HasShutdownFinished;
                }
                else
                {
                    arg_B1_0 = false;
                }
            IL_AA:
                if (!false)
                {
                    bool flag = arg_B1_0;
                    while (!flag)
                    {
                        if (!false)
                        {
                            goto IL_103;
                        }
                    }
                    base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                    {
                    }));
                    goto IL_E7;
                }
                goto IL_AA;
            }
        IL_103:
            return this._result;
        }

        private void LoadCheckBox()
        {
            this.lstSelectedImage.Items.Clear();
            List<LstMyItems>.Enumerator expr_16E = this._lstSelectedImage.GetEnumerator();
            List<LstMyItems>.Enumerator enumerator;
            if (!false)
            {
                enumerator = expr_16E;
            }
            try
            {
                if (5 != 0)
                {
                    goto IL_111;
                }
                goto IL_E1;
                LstMyItems current;
                while (true)
                {
                IL_E6:
                    current.IsItemSelected = false;
                    current.updownCount = 1;
                    if (3 == 0)
                    {
                        goto IL_11A;
                    }
                    if (!false)
                    {
                        goto IL_FE;
                    }
                }
            IL_E1:
                if (false)
                {
                   // goto IL_E6;
                }
            IL_FE:
                this.lstSelectedImage.Items.Add(current);
            IL_111:
                bool flag = enumerator.MoveNext();
            IL_11A:
                if (flag)
                {
                    current = enumerator.Current;
                    flag = (this.PreviousImage == null);
                    if (!flag)
                    {
                        string phtoId = current.PhotoId.ToString();
                        flag = !this.PreviousImage.Contains(phtoId);
                        if (!flag)
                        {
                            current.IsItemSelected = true;
                            while (5 != 0)
                            {
                                current.updownCount = (from o in this.PreviousImage
                                                       where o == phtoId
                                                       select o).Count<string>();
                                if (!false)
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            current.IsItemSelected = false;
                            if (false)
                            {
                                goto IL_FE;
                            }
                            current.updownCount = 1;
                        }
                        goto IL_E1;
                    }
                    //goto IL_E6;
                }
            }
            finally
            {
                ((IDisposable)enumerator).Dispose();
            }
        }

        private void HideHandlerDialog()
        {
            while (true)
            {
                if (8 != 0)
                {
                    this._hideRequest = true;
                    base.Visibility = Visibility.Collapsed;
                    goto IL_12;
                }
            IL_1F:
                if (!false)
                {
                    if (!false)
                    {
                        this.txtQRCode.Text = this.QRCode;
                    }
                    if (!false)
                    {
                        break;
                    }
                    continue;
                }
            IL_12:
                if (!false)
                {
                    this._parent.IsEnabled = true;
                    goto IL_1F;
                }
                return;
            }
            this.KeyBorder1.Visibility = Visibility.Collapsed;
        }

        public void GetPrintedImage()
        {
            this.lstSelectedImage.ItemsSource = this._SelectedImage;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }

        public static childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            int num = 0;
            childItem result;
            while (true)
            {
                int arg_83_0 = num;
                int arg_83_1 = VisualTreeHelper.GetChildrenCount(obj);
                int expr_75;
                int expr_77;
                while (true)
                {
                IL_83:
                    bool flag = arg_83_0 < arg_83_1;
                    bool arg_89_0 = flag;
                    while (true)
                    {
                    IL_89:
                        if (!arg_89_0)
                        {
                            result = default(childItem);
                            goto IL_9B;
                        }
                        goto IL_0D;
                    IL_23:
                        DependencyObject dependencyObject;
                        int arg_34_0;
                        arg_83_0 = (arg_34_0 = ((dependencyObject is childItem) ? 1 : 0));
                        int arg_31_0 = 0;
                        while (true)
                        {
                            int expr_31 = arg_83_1 = arg_31_0;
                            if (expr_31 != 0)
                            {
                                goto IL_83;
                            }
                            if (arg_34_0 != expr_31)
                            {
                                break;
                            }
                            childItem childItem1 = SelectedImagesQrCode.FindVisualChild<childItem>(dependencyObject);
                            bool expr_5E = arg_89_0 = (childItem1 == null);
                            if (4 == 0)
                            {
                                goto IL_89;
                            }
                            if (!expr_5E)
                            {
                                goto Block_4;
                            }
                            expr_75 = (arg_34_0 = (arg_83_0 = num));
                            expr_77 = (arg_31_0 = 1);
                            if (expr_77 != 0)
                            {
                                goto Block_7;
                            }
                        }
                        result = (childItem)((object)dependencyObject);
                        goto IL_9B;
                    Block_4:
                        if (!false && -1 != 0)
                        {
                            childItem childItem1 = SelectedImagesQrCode.FindVisualChild<childItem>(dependencyObject); ;
                            result = childItem1;
                            goto IL_9B;
                        }
                    IL_0D:
                        DependencyObject expr_B5 = VisualTreeHelper.GetChild(obj, num);
                        if (7 == 0)
                        {
                            goto IL_23;
                        }
                        dependencyObject = expr_B5;
                        goto IL_23;
                    IL_9B:
                        if (4 != 0)
                        {
                            return result;
                        }
                        goto IL_23;
                    }
                }
            Block_7:
                num = expr_75 + expr_77;
            }
            return result;
        }

        public void SetInitial()
        {
            int expr_01 = 0;
            int num;
            if (!false)
            {
                num = expr_01;
            }
            int arg_165_0;
            int arg_152_0;
            int arg_165_1;
            int arg_152_1;
            DependencyObject dependencyObject;
            bool flag;
            bool arg_167_0;
            while (true)
            {
                int expr_74 = arg_152_0 = (arg_165_0 = num);
                int expr_80 = arg_152_1 = (arg_165_1 = this.lstSelectedImage.Items.Count);
                if (2 == 0)
                {
                    goto IL_152;
                }
                if (-1 == 0)
                {
                    goto IL_165;
                }
                if (expr_74 >= expr_80)
                {
                    break;
                }
                dependencyObject = this.lstSelectedImage.ItemContainerGenerator.ContainerFromIndex(num);
                if (dependencyObject != null)
                {
                    CheckBox checkBox = SelectedImagesQrCode.FindVisualChild<CheckBox>(dependencyObject);
                    if (false)
                    {
                        goto IL_C6;
                    }
                    flag = (checkBox == null);
                    bool expr_52 = arg_167_0 = flag;
                    if (false)
                    {
                        goto IL_167;
                    }
                    if (!expr_52)
                    {
                        checkBox.IsChecked = new bool?(false);
                    }
                    if (false)
                    {
                        goto IL_A3;
                    }
                }
                num++;
            }
            num = 0;
        IL_9E:
            goto IL_154;
        IL_A3:
            dependencyObject = this.lstSelectedImage.ItemContainerGenerator.ContainerFromIndex(num);
            if (dependencyObject == null)
            {
                goto IL_14F;
            }
        IL_C6:
            CheckBox chk = SelectedImagesQrCode.FindVisualChild<CheckBox>(dependencyObject);
            flag = (chk == null);
            if (7 != 0)
            {
                if (flag)
                {
                    goto IL_14E;
                }
                if (this.PreviousImage == null)
                {
                    goto IL_14D;
                }
                string text = (from objSelected in this.PreviousImage
                               where objSelected == chk.Uid.ToString()
                               select objSelected).FirstOrDefault<string>();
                flag = (text == null);
            }
            if (!flag)
            {
                chk.IsChecked = new bool?(true);
                if (4 == 0)
                {
                    goto IL_9E;
                }
            }
        IL_14D:
        IL_14E:
        IL_14F:
            arg_152_0 = num;
            arg_152_1 = 1;
        IL_152:
            num = arg_152_0 + arg_152_1;
        IL_154:
            arg_165_0 = num;
            arg_165_1 = this.lstSelectedImage.Items.Count;
        IL_165:
            arg_167_0 = (arg_165_0 < arg_165_1);
        IL_167:
            if (!arg_167_0)
            {
                return;
            }
            goto IL_A3;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				
			
			    string	 Code = string.Empty;
			   CardLimitInfo   objCardLimit = new CardLimitInfo();
				bool flag = false;
				int num = 0;
				int num2 = 0;
				this._result = new List<LstMyItems>();
				for (int i = 0; i < this.lstSelectedImage.Items.Count; i++)
				{
					DependencyObject dependencyObject = this.lstSelectedImage.ItemContainerGenerator.ContainerFromIndex(i);
					if (dependencyObject != null)
					{
						CheckBox checkBox = SelectedImagesQrCode.FindVisualChild<CheckBox>(dependencyObject);
						if (checkBox != null)
						{
							if (Convert.ToBoolean(checkBox.IsChecked))
							{
								IntegerUpDown integerUpDown = SelectedImagesQrCode.FindVisualChild<IntegerUpDown>(dependencyObject);
								int value = integerUpDown.Value.Value;
								num += value;
								for (int j = 0; j < value; j++)
								{
									this._result.Add((LstMyItems)this.lstSelectedImage.Items[i]);
								}
							}
						}
					}
				}
				if (this._result.Count > 0)
				{
					if (!this.CheckQRCodeLength())
					{
						return;
					}
					if (string.IsNullOrEmpty(this.txtQRCode.Text.Trim()) || this.txtQRCode.Text.Trim().Length < 5)
					{
						System.Windows.MessageBox.Show("Invalid QR/Bar code.", "PhotoSW");
						return;
					}
					if (this.lstQrCode.Where(delegate(string o)
					{
						int arg_31_0;
						while (true)
						{
							bool expr_4D = (arg_31_0 = string.Compare(o, this.txtQRCode.Text.Trim(), true)) != 0;
							if (false)
							{
								goto IL_2D;
							}
							if (!expr_4D)
							{
								break;
							}
							if (7 != 0)
							{
								goto Block_3;
							}
						}
						int arg_1F_0 = string.Compare(o, this.QRCode, true);
						IL_1E:
						bool expr_1F = (arg_31_0 = ((arg_1F_0 == 0) ? 1 : 0)) != 0;
						if (true)
						{
							arg_31_0 = ((!expr_1F) ? 1 : 0);
						}
						IL_27:
						goto IL_2D;
						Block_3:
						arg_31_0 = 0;
						IL_2D:
						if (-1 == 0)
						{
							goto IL_27;
						}
						bool flag2 = arg_31_0 != 0;
						bool expr_34 = (arg_1F_0 = (flag2 ? 1 : 0)) != 0;
						if (!false)
						{
							return expr_34;
						}
						goto IL_1E;
					}).Count<string>() > 0)
					{
						System.Windows.MessageBox.Show("You have already used this code.", "Digiphoto");
						return;
					}
					Code = this.txtQRCode.Text.Trim();
					int num3;
					if (!App.IsAnonymousQrCodeEnabled)
					{
						if (!new CardBusiness().IsValidCodeType(Code, 405))
						{
							System.Windows.MessageBox.Show("Invalid code.");
							return;
						}
						if (this.ReadSystemOnlineStatus())
						{
							try
							{
								ServiceProxy<IDataSyncService>.Use(delegate(IDataSyncService client)
								{
									objCardLimit = client.CheckCardLimit(Code);
								});
								flag = true;
							}
							catch (Exception serviceException)
							{
								string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
								ErrorHandler.ErrorHandler.LogFileWrite(message);
								flag = false;
							}
						}
						if (flag)
						{
							if (!objCardLimit.ValidCard)
							{
								System.Windows.MessageBox.Show("Invalid card code.", "Digiphoto");
								return;
							}
							num3 = new CardBusiness().GetCardImageLimit(Code);
							if (!this.ValidateQRCodeChk)
							{
								num2 = new CardBusiness().GetCardImageSold(Code);
							}
						}
						else
						{
							num3 = new CardBusiness().GetCardImageLimit(Code);
							if (!this.ValidateQRCodeChk)
							{
								num2 = new CardBusiness().GetCardImageSold(Code);
							}
						}
					}
					else
					{
						if (this.ReadSystemOnlineStatus())
						{
							this.packageInfo.MaxImgQuantity = this.maxSelectedPhotos;
							try
							{
								ServiceProxy<IDataSyncService>.Use(delegate(IDataSyncService client)
								{
									if (!true || !false)
									{
									}
									do
									{
										if (3 != 0)
										{
											objCardLimit = client.CheckAnonymousCardLimit(Code, packageInfo);
										}
									}
									while (false);
								});
								flag = (objCardLimit.Allowed > 0 && objCardLimit.Associated > 0);
							}
							catch (Exception serviceException)
							{
								string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
								ErrorHandler.ErrorHandler.LogFileWrite(message);
								flag = false;
							}
						}
						if (flag)
						{
							if (!objCardLimit.ValidCard)
							{
								System.Windows.MessageBox.Show("Invalid card code.", "Digiphoto");
								return;
							}
							num3 = objCardLimit.Allowed;
							if (!this.ValidateQRCodeChk)
							{
								num2 = objCardLimit.Associated;
							}
						}
						else
						{
							num3 = this.maxSelectedPhotos;
							if (!this.ValidateQRCodeChk)
							{
								num2 = new CardBusiness().GetCardImageSold(Code);
							}
						}
					}
					if (num2 > 0)
					{
						this.IsQrCodeUsed = true;
					}
					else
					{
						this.IsQrCodeUsed = false;
					}
					if (num2 + this._result.Count > num3)
					{
						int num4 = num3 - num2;
						num4 = ((num4 < 0) ? 0 : num4);
						System.Windows.MessageBox.Show(string.Concat(new string[]
						{
							"This card ",
							Code,
							" exceed limit of ",
							num3.ToString(),
							" images. Please select less than ",
							num4.ToString(),
							" images."
						}), "Digiphoto");
						return;
					}
				}
				else if (!new OrderBusiness().chKIsWaterMarkedOrNot(SelectedImagesQrCode.PackageCode))
				{
					this.txtQRCode.Text = string.Empty;
					this.IsQrCodeUsed = false;
				}
				if (this.IsPackage)
				{
					if (this._result.Count > this.maxSelectedPhotos)
					{
						System.Windows.MessageBox.Show(string.Concat(new object[]
						{
							"You have selected more than ",
							this.maxSelectedPhotos,
							" images. Please select less than ",
							this.maxSelectedPhotos,
							" images."
						}), "Digiphoto");
					}
					else
					{
						this.QRCode = this.txtQRCode.Text.Trim();
						this.HideHandlerDialog();
					}
				}
				else
				{
					this.QRCode = this.txtQRCode.Text.Trim();
					this.HideHandlerDialog();
				}
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
		}

        private void btnSubmitCancel_Click(object sender, RoutedEventArgs e)
        {
            this.SelectDeselectAll(new bool?(false));
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this._result = null;
            this.HideHandlerDialog();
        }

        private void ChkSelected_Click(object sender, RoutedEventArgs e)
        {
            this.CheckSelectedImg();
        }

        private void chkSelectAll_Click(object sender, RoutedEventArgs e)
        {
            this.SelectDeselectAll(this.chkSelectAll.IsChecked);
        }

        private void SelectDeselectAll(bool? SelectDeselect)
        {
            int num = 0;
            bool flag;
            while (true)
            {
            IL_63:
                flag = (num < this.lstSelectedImage.Items.Count);
                while (flag)
                {
                    DependencyObject expr_14E = this.lstSelectedImage.ItemContainerGenerator.ContainerFromIndex(num);
                    DependencyObject dependencyObject;
                    if (!false)
                    {
                        dependencyObject = expr_14E;
                    }
                    bool expr_30 = dependencyObject == null;
                    if (!false)
                    {
                        flag = expr_30;
                    }
                    if (!flag)
                    {
                        CheckBox checkBox = SelectedImagesQrCode.FindVisualChild<CheckBox>(dependencyObject);
                        flag = (checkBox == null);
                        if (!flag)
                        {
                            checkBox.IsChecked = SelectDeselect;
                        }
                    }
                    if (!false)
                    {
                        num++;
                        goto IL_63;
                    }
                }
                break;
            }
            bool? flag2 = SelectDeselect;
            int arg_92_0;
            if (!flag2.GetValueOrDefault())
            {
                arg_92_0 = (flag2.HasValue ? 1 : 0);
                goto IL_90;
            }
        IL_8F:
            arg_92_0 = 0;
        IL_90:
            flag = (arg_92_0 == 0);
            if (!false)
            {
                if (flag)
                {
                    this.txbImages.Text = string.Concat(new object[]
					{
						"Selected : ",
						this.lstSelectedImage.Items.Count,
						"/",
						this.lstSelectedImage.Items.Count
					});
                    if (2 != 0)
                    {
                        return;
                    }
                }
                this.txbImages.Text = "Selected : 0/" + this.lstSelectedImage.Items.Count;
                return;
            }
            goto IL_8F;
        }

        private int SelectedItemCount()
        {
            int arg_93_0;
            int num;
            do
            {
                if (4 != 0)
                {
                    int expr_08 = arg_93_0 = 0;
                    if (expr_08 != 0)
                    {
                        return arg_93_0;
                    }
                    arg_93_0 = expr_08;
                    if (expr_08 != 0)
                    {
                        return arg_93_0;
                    }
                    num = expr_08;
                    try
                    {
                        num = (from LstMyItems o in this.lstSelectedImage.Items
                               where o.IsItemSelected
                               select o).Count<LstMyItems>();
                    }
                    catch (Exception serviceException)
                    {
                        if (8 != 0)
                        {
                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                        }
                    }
                }
            }
            while (false);
            int num2 = num;
            arg_93_0 = num2;
            return arg_93_0;
        }

        public void CheckSelectedImg()
        {
            bool expr_19 = this.lstSelectedImage.Items.Count <= 0;
            bool flag;
            if (!false)
            {
                flag = expr_19;
            }
            if (!flag)
            {
                this.SPSelectAll.Visibility = Visibility.Visible;
                flag = (this.lstSelectedImage.Items.Count != this.SelectedItemCount());
                if (!flag)
                {
                    this.chkSelectAll.IsChecked = new bool?(true);
                }
                else
                {
                    this.chkSelectAll.IsChecked = new bool?(false);
                }
            }
            else
            {
                this.SPSelectAll.Visibility = Visibility.Hidden;
            }
            this.txbImages.Text = string.Concat(new object[]
			{
				"Selected : ",
				this.SelectedItemCount(),
				"/",
				this.lstSelectedImage.Items.Count.ToString()
			});
        }

        private void txtCode_GotFocus(object sender, RoutedEventArgs e)
        {
            this.KeyBorder1.Visibility = Visibility.Visible;
        }

        private void btn_Click_keyboard(object sender, RoutedEventArgs e)
        {
            try
            {
                new Button();
                Button button = (Button)sender;
                string text;
                do
                {
                    text = button.Content.ToString();
                    if (text == null)
                    {
                        goto IL_116;
                    }
                    if (text == "ENTER")
                    {
                        goto IL_75;
                    }
                    if (text == "SPACE")
                    {
                        goto IL_8B;
                    }
                }
                while (-1 == 0);
                if (text == "CLOSE")
                {
                    goto IL_B5;
                }
                if (!(text == "Back"))
                {
                    goto IL_116;
                }
                goto IL_C6;
            IL_75:
                if (8 != 0)
                {
                    this.KeyBorder1.Visibility = Visibility.Collapsed;
                    goto IL_142;
                }
                goto IL_B5;
            IL_8B:
                this.txtQRCode.Text = this.txtQRCode.Text + " ";
                if (-1 != 0)
                {
                    goto IL_142;
                }
            IL_B5:
                this.KeyBorder1.Visibility = Visibility.Collapsed;
                goto IL_142;
            IL_C6:
                bool arg_DA_0 = this.txtQRCode.Text.Length > 0;
                bool expr_DA;
                do
                {
                    expr_DA = (arg_DA_0 = !arg_DA_0);
                }
                while (false);
                if (!expr_DA)
                {
                    this.txtQRCode.Text = this.txtQRCode.Text.Remove(this.txtQRCode.Text.Length - 1, 1);
                }
                goto IL_142;
            IL_116:
                this.txtQRCode.Text = this.txtQRCode.Text + button.Content;
                if (false)
                {
                    goto IL_C6;
                }
            IL_142: ;
            }
            catch (Exception serviceException)
            {
                if (5 != 0)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                while (false)
                {
                }
            }
        }

        private void txtQRCode_KeyDown(object sender, KeyEventArgs e)
        {
            while (-1 != 0 && 8 != 0)
            {
                if (7 != 0)
                {
                    bool flag = e.Key != Key.Return;
                    if (false)
                    {
                        continue;
                    }
                    if (!flag)
                    {
                        break;
                    }
                }
                return;
            }
            this.CheckQRCodeLength();
        }

        private void lstSelectedImage_GotFocus(object sender, RoutedEventArgs e)
        {
            this.KeyBorder1.Visibility = Visibility.Collapsed;
        }

        private bool ReadSystemOnlineStatus()
        {
            bool flag = false;
            try
            {
                while (false)
                {
                }
                string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                do
                {
                    bool flag2 = !File.Exists(directoryName + "\\Config.dat");
                    if (!flag2 && !false)
                    {
                        if (4 != 0)
                        {
                            using (StreamReader streamReader = new StreamReader(directoryName + "\\Config.dat"))
                            {
                                string text = streamReader.ReadLine();
                                flag = Convert.ToBoolean(text.Split(new char[]
								{
									','
								})[1]);
                            }
                        }
                    }
                }
                while (7 == 0);
            }
            catch (Exception serviceException)
            {
                if (!false)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
            bool result;
            if (true)
            {
                result = flag;
            }
            return result;
        }

        private bool CheckQRCodeLength()
        {
            List<long> filterValues = new List<long>();
            int num;
            while (true)
            {
                num = 0;
                this.txtQRCode.Text = this.txtQRCode.Text.Replace(App.QRCodeWebUrl, string.Empty);
                while (true)
                {
                IL_4E:
                    if (!false)
                    {
                        filterValues.Add(107L);
                        if (!false)
                        {
                            goto IL_64;
                        }
                        break;
                    }
                IL_83:
                    ConfigBusiness configBusiness;
                    List<iMIXConfigurationInfo> list = (from o in configBusiness.GetNewConfigValues(LoginUser.SubStoreId)
                                                        where filterValues.Contains(o.IMIXConfigurationMasterId)
                                                        select o).ToList<iMIXConfigurationInfo>();
                    if (list != null || list.Count > 0)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            long iMIXConfigurationMasterId = list[i].IMIXConfigurationMasterId;
                            if (iMIXConfigurationMasterId != 107L)
                            {
                                if (iMIXConfigurationMasterId == 152L)
                                {
                                    this.ValidateQRCodeChk = (list[i].ConfigurationValue != null && Convert.ToBoolean(list[i].ConfigurationValue));
                                    if (5 == 0)
                                    {
                                        goto IL_4E;
                                    }
                                }
                            }
                            else
                            {
                                int arg_115_0;
                                if (list[i].ConfigurationValue == null)
                                {
                                    arg_115_0 = 0;
                                }
                                else
                                {
                                    if (false)
                                    {
                                        goto IL_64;
                                    }
                                    arg_115_0 = Convert.ToInt32(list[i].ConfigurationValue);
                                }
                                num = arg_115_0;
                            }
                        }
                        goto IL_162;
                    }
                    goto IL_162;
                IL_64:
                    filterValues.Add(152L);
                    if (2 != 0)
                    {
                        configBusiness = new ConfigBusiness();
                        goto IL_83;
                    }
                    goto IL_16F;
                }
            }
        IL_162:
            bool result;
            if (num != 0)
            {
                if (num > 0 && this.txtQRCode.Text.Trim().Length != num)
                {
                    System.Windows.MessageBox.Show("QR/Bar code length should be " + num + " characters.", "Digiphoto");
                    result = false;
                    return result;
                }
                result = true;
                return result;
            }
        IL_16F:
            System.Windows.MessageBox.Show("Please Configure QRCode Length in Manage Configuration", "Digiphoto");
            result = false;
            return result;
        }

         void IStyleConnector.Connect(int connectionId, object target)
        {
            while (true)
            {
                if (8 == 0)
                {
                    goto IL_15;
                }
                int arg_0E_0 = connectionId;
                if (8 != 0)
                {
                    arg_0E_0 = connectionId;
                }
                if (arg_0E_0 == 3 || false)
                {
                    goto IL_15;
                }
            IL_2E:
                if (!false)
                {
                    break;
                }
                continue;
            IL_15:
                ((CheckBox)target).Click += new RoutedEventHandler(this.ChkSelected_Click);
                goto IL_2E;
            }
        }
    }
}
