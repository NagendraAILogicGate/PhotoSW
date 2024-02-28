using PhotoSW.DataLayer;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using PhotoSW.Views;
using DigiPhoto;

namespace PhotoSW.PSControls
{
    public partial class SelectedAlbumlist : UserControl, IComponentConnector, IStyleConnector
    {
        public int ActivePageNo = 1;

        public int DropPhotoId = 0;

        public int SelectedPhotoId1 = 0;

        public int SelectedPhotoId2 = 0;

        private int rotateAngleLeft = 0;

        private int rotateAngleRight = 0;

        public static readonly DependencyProperty PrintOrderPageProperty;

        private bool _hideRequest = false;

        private List<LstMyItems> _result;

        private UIElement _parent;

        public static readonly DependencyProperty MessageAlbum2Property;

       

        public ObservableCollection<PrintOrderPage> PrintOrderPageList
        {
            get
            {
                return (ObservableCollection<PrintOrderPage>)base.GetValue(SelectedAlbumlist.PrintOrderPageProperty);
            }
            set
            {
                base.SetValue(SelectedAlbumlist.PrintOrderPageProperty, value);
            }
        }

        public List<LstMyItems> _SelectedImage
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

        public string MessageAlbum2
        {
            get
            {
                return (string)base.GetValue(SelectedAlbumlist.MessageAlbum2Property);
            }
            set
            {
                base.SetValue(SelectedAlbumlist.MessageAlbum2Property, value);
            }
        }

        public SelectedAlbumlist()
        {
            try
            {
                this.InitializeComponent();
                this.lstSelectedImage.Items.Clear();
                this.lstSelectedPages.Items.Clear();
                foreach (LstMyItems current in RobotImageLoader.PrintImages)
                {
                    this.lstSelectedImage.Items.Add(current);
                }
                this.lstSelectedPages.ItemsSource = this.PrintOrderPageList;
            }
            catch
            {
            }
        }

        public void SetParentAlbum(UIElement parent)
        {
            this._parent = parent;
        }

        public List<LstMyItems> ShowAlbumHandlerDialog(string message)
        {
            while (true)
            {
                this.BindPageStrips();
                if (true)
                {
                    if (!false)
                    {
                        this.MessageAlbum2 = message;
                        base.Visibility = Visibility.Visible;
                        this._parent.IsEnabled = true;
                        this._hideRequest = false;
                    }
                    goto IL_AD;
                }
                goto IL_66;
            IL_67:
                bool arg_68_0;
                int arg_54_0;
                if (!arg_68_0)
                {
                    if (6 != 0)
                    {
                        break;
                    }
                    continue;
                }
                else
                {
                    base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                    {
                    }));
                    int expr_A3 = arg_54_0 = 20;
                    if (expr_A3 != 0)
                    {
                        Thread.Sleep(expr_A3);
                        goto IL_AD;
                    }
                    goto IL_54;
                }
            IL_62:
                bool arg_62_0;
                int arg_62_1;
                arg_68_0 = ((arg_62_0 ? 1 : 0) == arg_62_1);
                goto IL_67;
            IL_54:
                if (arg_54_0 == 0)
                {
                    arg_62_0 = base.Dispatcher.HasShutdownFinished;
                    arg_62_1 = 0;
                    goto IL_62;
                }
            IL_66:
                arg_68_0 = false;
                goto IL_67;
            IL_AD:
                bool expr_AE = arg_62_0 = this._hideRequest;
                int expr_B4 = arg_62_1 = 0;
                if (expr_B4 != 0)
                {
                    goto IL_62;
                }
                arg_62_1 = expr_B4;
                if (expr_B4 != 0)
                {
                    goto IL_62;
                }
                if ((expr_AE ? 1 : 0) != expr_B4)
                {
                    break;
                }
                arg_54_0 = (base.Dispatcher.HasShutdownStarted ? 1 : 0);
                goto IL_54;
            }
            return this._result;
        }

        private void HideHandlerDialog()
        {
            if (4 != 0)
            {
                this._hideRequest = true;
                do
                {
                    Visibility expr_0E = Visibility.Collapsed;
                    if (!false)
                    {
                        base.Visibility = expr_0E;
                    }
                    if (false)
                    {
                        goto IL_25;
                    }
                }
                while (false);
                this._parent.IsEnabled = true;
            IL_25: ;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
		{
			this._result = new List<LstMyItems>();
			while (true)
			{
				IL_10:
				this.PreviousImage = new List<string>();
				IEnumerator<PrintOrderPage> expr_32B = this.PrintOrderPageList.GetEnumerator();
				IEnumerator<PrintOrderPage> enumerator;
				if (!false)
				{
					enumerator = expr_32B;
				}
				try
				{
					while (enumerator.MoveNext())
					{
						LstMyItems lstMyItems;
                        PrintOrderPage printPage ;
						while (true)
						{
							 printPage = enumerator.Current;
							if (printPage.FilePath1 == null || printPage.PhotoId1 <= 0)
							{
								goto IL_156;
							}
							lstMyItems = (from o in RobotImageLoader.PrintImages
							where o.PhotoId == printPage.PhotoId1
							select o).FirstOrDefault<LstMyItems>();
							if (lstMyItems == null)
							{
								goto IL_155;
							}
							if (lstMyItems.PhotoPrintPositionList.Where(delegate(PhotoPrintPosition o)
							{
								int arg_0D_0 = o.PageNo;
								int arg_5C_0;
								while (true)
								{
									if (arg_0D_0 == printPage.PageNo)
									{
										goto IL_0F;
									}
									goto IL_26;
									IL_2A:
									if (!false)
									{
										break;
									}
									continue;
									IL_0F:
									if (!false)
									{
										int arg_1F_0 = o.PhotoPosition;
										do
										{
											arg_1F_0 = (arg_0D_0 = (arg_5C_0 = ((arg_1F_0 == printPage.PhotoPosition1) ? 1 : 0)));
										}
										while (false);
										goto IL_2A;
									}
									IL_26:
									if (!false)
									{
										arg_5C_0 = (arg_0D_0 = 0);
										goto IL_2A;
									}
									goto IL_0F;
								}
								return arg_5C_0 != 0;
							}).FirstOrDefault<PhotoPrintPosition>() != null)
							{
								goto IL_12C;
							}
							lstMyItems.PhotoPrintPositionList.Add(new PhotoPrintPosition(printPage.PageNo, printPage.PhotoPosition1, printPage.RotationAngle1));
							if (3 == 0)
							{
								goto IL_1A8;
							}
							if (!false)
							{
								goto IL_12C;
							}
						}
						IL_254:
						if (true)
						{
							continue;
						}
						goto IL_1E5;
						IL_156:
                        //PrintOrderPage printPage = enumerator.Current;
						bool flag = printPage.FilePath2 == null || printPage.PhotoId2 <= 0;
						if (!flag)
						{
							goto IL_183;
						}
						IL_253:
						goto IL_254;
						IL_1E5:
						if (!flag)
						{
							if (false)
							{
								goto IL_156;
							}
							lstMyItems.PhotoPrintPositionList.Add(new PhotoPrintPosition(printPage.PageNo, printPage.PhotoPosition2, printPage.RotationAngle2));
						}
						this._result.Add(lstMyItems);
						if (-1 != 0)
						{
							this.PreviousImage.Add(lstMyItems.PhotoId.ToString());
							goto IL_253;
						}
						goto IL_183;
						IL_1A8:
						flag = (lstMyItems == null);
						if (!flag)
						{
							flag = (lstMyItems.PhotoPrintPositionList.Where(delegate(PhotoPrintPosition o)
							{
								int arg_0D_0 = o.PageNo;
								int arg_5C_0;
								while (true)
								{
									if (arg_0D_0 == printPage.PageNo)
									{
										goto IL_0F;
									}
									goto IL_26;
									IL_2A:
									if (!false)
									{
										break;
									}
									continue;
									IL_0F:
									if (!false)
									{
										int arg_1F_0 = o.PhotoPosition;
										do
										{
											arg_1F_0 = (arg_0D_0 = (arg_5C_0 = ((arg_1F_0 == printPage.PhotoPosition2) ? 1 : 0)));
										}
										while (false);
										goto IL_2A;
									}
									IL_26:
									if (!false)
									{
										arg_5C_0 = (arg_0D_0 = 0);
										goto IL_2A;
									}
									goto IL_0F;
								}
								return arg_5C_0 != 0;
							}).FirstOrDefault<PhotoPrintPosition>() != null);
							goto IL_1E5;
						}
						goto IL_253;
						IL_183:
						lstMyItems = (from o in RobotImageLoader.PrintImages
						where o.PhotoId == printPage.PhotoId2
						select o).FirstOrDefault<LstMyItems>();
						goto IL_1A8;
						IL_155:
						goto IL_156;
						IL_12C:
						this._result.Add(lstMyItems);
						this.PreviousImage.Add(lstMyItems.PhotoId.ToString());
						goto IL_155;
					}
				}
				finally
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
				int arg_286_0 = this.IsPackage ? 1 : 0;
				int arg_286_1 = 0;
				while (arg_286_0 != arg_286_1)
				{
					int expr_295 = arg_286_0 = this._result.Count;
					int expr_29B = arg_286_1 = this.maxSelectedPhotos;
					if (!false)
					{
						bool flag = expr_295 <= expr_29B;
						if (!false && flag)
						{
							goto IL_2DB;
						}
						if (4 != 0)
						{
							goto Block_5;
						}
						goto IL_10;
					}
				}
				goto IL_2E7;
			}
			Block_5:
			MessageBox.Show("You can't select more than " + this.maxSelectedPhotos + " images");
			goto IL_2E4;
			IL_2DB:
			this.HideHandlerDialog();
			IL_2E4:
			return;
			IL_2E7:
			this.HideHandlerDialog();
		}

        private void btnSubmitCancel_Click(object sender, RoutedEventArgs e)
        {
            this.ResetPageStrip();
        }

        private void ResetPageStrip()
        {
            IEnumerator<PrintOrderPage> enumerator = this.PrintOrderPageList.GetEnumerator();
            try
            {
                while (true)
                {
                    bool arg_69_0;
                    bool expr_5F = arg_69_0 = enumerator.MoveNext();
                    if (3 != 0)
                    {
                        bool flag = expr_5F;
                        arg_69_0 = flag;
                    }
                    if (!arg_69_0)
                    {
                        break;
                    }
                    PrintOrderPage current = enumerator.Current;
                    if (8 != 0)
                    {
                    }
                    current.ImageSource1 = null;
                    current.ImageSource2 = null;
                    if (3 != 0)
                    {
                        current.Name1 = string.Empty;
                    }
                    current.Name2 = string.Empty;
                    current.PhotoId1 = (current.PhotoId2 = 0);
                }
            }
            finally
            {
                do
                {
                    if (enumerator != null)
                    {
                        enumerator.Dispose();
                    }
                }
                while (false);
            }
            this.img1.Source = null;
            if (true)
            {
                this.img2.Source = null;
                while (false)
                {
                }
                this.tbkActivePageNo.Text = "1";
                this.ActivePageNo = 1;
                this.DropPhotoId = 0;
            }
            this.lstSelectedPages.SelectedIndex = 0;
            this.rotateAngleLeft = (this.rotateAngleRight = 0);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this._result = null;
            this.HideHandlerDialog();
        }

        private void Image_PreviewMouseDown(object sender, EventArgs e)
        {
            if (!true)
            {
                goto IL_25;
            }
            LstMyItems lstMyItems;
            do
            {
            IL_04:
                lstMyItems = (LstMyItems)(sender as Image).DataContext;
            }
            while (7 == 0);
            if (!false)
            {
                this.DropPhotoId = lstMyItems.PhotoId;
            }
        IL_25:
            DragDrop.DoDragDrop((DependencyObject)sender, ((Image)sender).Source, DragDropEffects.Copy);
            if (!false)
            {
                return;
            }
            //goto IL_04;
        }

        private void Image_Drop(object sender, DragEventArgs e)
        {
            LstMyItems lstMyItems;
            BitmapImage bitmapImage;
            Image image;
            PrintOrderPage printOrderPage;
            while (true)
            {
            IL_06:
                Func<PrintOrderPage, bool> expr_06 = null;
                if (!false)
                {
                    Func<PrintOrderPage, bool> predicate = expr_06;
                }
                lstMyItems = (from o in RobotImageLoader.PrintImages
                              where o.PhotoId == this.DropPhotoId
                              select o).FirstOrDefault<LstMyItems>();
                bitmapImage = new BitmapImage();
                if (3 != 0)
                {
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(lstMyItems.FilePath.Replace("Thumbnails", "Thumbnails_Big"), UriKind.Relative);
                    bitmapImage.DecodePixelWidth = 200;
                    bitmapImage.EndInit();
                    string name = ((Rectangle)sender).Name;
                    object obj = ((Rectangle)sender).FindName("ViewBox1");
                    bool arg_B2_0 = !(name == "btn1");
                    while (!arg_B2_0)
                    {
                        object obj2 = ((Viewbox)obj).FindName("img1");
                        bool flag = !(obj2 is Image);
                        bool expr_DD = arg_B2_0 = flag;
                        if (5 != 0)
                        {
                            if (expr_DD)
                            {
                                goto IL_212;
                            }
                            image = (Image)obj2;
                            printOrderPage = (from o in this.PrintOrderPageList
                                              where o.PageNo == this.ActivePageNo
                                              select o).FirstOrDefault<PrintOrderPage>();
                            printOrderPage.FilePath1 = lstMyItems.FilePath.Replace("Thumbnails", "Thumbnails_Big");
                            do
                            {
                                printOrderPage.Name1 = lstMyItems.Name;
                                printOrderPage.PhotoPosition1 = 1;
                                printOrderPage.PhotoId1 = lstMyItems.PhotoId;
                                this.SelectedPhotoId1 = this.DropPhotoId;
                            }
                            while (false);
                            if (bitmapImage.PixelWidth > bitmapImage.PixelHeight)
                            {
                                goto Block_7;
                            }
                            image.Source = bitmapImage;
                            printOrderPage.ImageSource1 = bitmapImage;
                            if (!false)
                            {
                                goto Block_8;
                            }
                            goto IL_06;
                        }
                    }
                    goto IL_218;
                }
                goto IL_1F8;
            }
            object obj3;
            Image image2;
            TransformedBitmap transformedBitmap;
            RotateTransform transform;
            while (true)
            {
            IL_241:
                image2 = (Image)obj3;
                IEnumerable<PrintOrderPage> arg_267_0 = this.PrintOrderPageList;
                Func<PrintOrderPage, bool> predicate = (PrintOrderPage o) => o.PageNo == this.ActivePageNo;
                printOrderPage = arg_267_0.Where(predicate).FirstOrDefault<PrintOrderPage>();
                printOrderPage.FilePath2 = lstMyItems.FilePath.Replace("Thumbnails", "Thumbnails_Big");
                while (true)
                {
                    printOrderPage.Name2 = lstMyItems.Name;
                    printOrderPage.PhotoPosition2 = 2;
                    printOrderPage.PhotoId2 = lstMyItems.PhotoId;
                    this.SelectedPhotoId2 = this.DropPhotoId;
                    bool flag = bitmapImage.PixelWidth <= bitmapImage.PixelHeight;
                    if (6 == 0)
                    {
                        break;
                    }
                    if (flag)
                    {
                        goto IL_33F;
                    }
                    transformedBitmap = new TransformedBitmap();
                    transformedBitmap.BeginInit();
                    transformedBitmap.Source = bitmapImage;
                    this.rotateAngleRight = 270;
                    transform = new RotateTransform((double)this.rotateAngleRight);
                    transformedBitmap.Transform = transform;
                    if (!false)
                    {
                        goto Block_12;
                    }
                }
            }
        Block_12:
            transformedBitmap.EndInit();
            image2.Source = transformedBitmap;
            printOrderPage.ImageSource2 = transformedBitmap;
            goto IL_35A;
        IL_33F:
            image2.Source = bitmapImage;
            printOrderPage.ImageSource2 = bitmapImage;
            this.rotateAngleRight = 0;
        IL_35A:
            printOrderPage.RotationAngle2 = this.rotateAngleRight;
            return;
        Block_7:
            transformedBitmap = new TransformedBitmap();
            transformedBitmap.BeginInit();
            transformedBitmap.Source = bitmapImage;
            this.rotateAngleLeft = 270;
            transform = new RotateTransform((double)this.rotateAngleLeft);
            transformedBitmap.Transform = transform;
        IL_1BC:
            transformedBitmap.EndInit();
            image.Source = transformedBitmap;
            printOrderPage.ImageSource1 = transformedBitmap;
            goto IL_203;
        Block_8:
            if (8 == 0)
            {
                //goto IL_241;
            }
        IL_1F8:
            this.rotateAngleLeft = 0;
            if (7 == 0)
            {
                goto IL_1BC;
            }
        IL_203:
            printOrderPage.RotationAngle1 = this.rotateAngleLeft;
        IL_212:
            return;
        IL_218:
            obj3 = ((Rectangle)sender).FindName("img2");
            if (obj3 is Image)
            {
                //goto IL_241;
            }
        }

        private void lstSelectedPages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                try
                {
                    ImageSource imageSource2;
                    while (true)
                    {
                        int arg_17_0 = this.lstSelectedPages.Items.Count;
                        bool expr_1A;
                        do
                        {
                            expr_1A = ((arg_17_0 = ((arg_17_0 <= 0) ? 1 : 0)) != 0);
                        }
                        while (false);
                        if (expr_1A)
                        {
                            goto IL_117;
                        }
                        if (!false)
                        {
                            this.lstSelectedPages.ScrollIntoView(this.lstSelectedPages.SelectedItem);
                            if (this.lstSelectedPages.SelectedItems.Count <= 0)
                            {
                                goto IL_116;
                            }
                            this.ActivePageNo = ((PrintOrderPage)this.lstSelectedPages.SelectedItem).PageNo;
                            PrintOrderPage printOrderPage;
                            ImageSource imageSource;
                            do
                            {
                                printOrderPage = (PrintOrderPage)this.lstSelectedPages.SelectedItem;
                                imageSource = printOrderPage.ImageSource1;
                                imageSource2 = printOrderPage.ImageSource2;
                                this.rotateAngleLeft = printOrderPage.RotationAngle1;
                                this.rotateAngleRight = printOrderPage.RotationAngle2;
                            }
                            while (-1 == 0);
                            this.SelectedPhotoId1 = printOrderPage.PhotoId1;
                            this.SelectedPhotoId2 = printOrderPage.PhotoId2;
                            this.img1.Source = imageSource;
                            if (!false)
                            {
                                break;
                            }
                        }
                    }
                    this.img2.Source = imageSource2;
                    this.tbkActivePageNo.Text = this.ActivePageNo.ToString();
                IL_116:
                IL_117: ;
                }
                catch (Exception serviceException)
                {
                    string message;
                    while (6 != 0)
                    {
                        if (!false)
                        {
                            message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                            break;
                        }
                    }
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                while (false)
                {
                }
            }
            finally
            {
                MemoryManagement.FlushMemory();
            }
        }

        private void BindPageStrips()
        {
            try
            {
                do
                {
                    if (this.PrintOrderPageList.Count<PrintOrderPage>() == 0)
                    {
                        this.img1.Source = null;
                        this.img2.Source = null;
                        int num = this.maxSelectedPhotos / 2 + this.maxSelectedPhotos % 2;
                        PrintOrderPage printOrderPage = null;
                        int num2 = 1;
                        while (true)
                        {
                            int arg_84_0;
                            int expr_9C = arg_84_0 = num2;
                            if (!false)
                            {
                                bool arg_A6_0 = expr_9C <= num;
                                bool expr_A8;
                                do
                                {
                                    bool flag = arg_A6_0;
                                    expr_A8 = (arg_A6_0 = flag);
                                }
                                while (8 == 0);
                                if (!expr_A8)
                                {
                                    break;
                                }
                                printOrderPage = new PrintOrderPage();
                                printOrderPage.PageNo = num2;
                                printOrderPage.PhotoPosition1 = 1;
                                printOrderPage.PhotoPosition2 = 2;
                                arg_84_0 = ((printOrderPage == null) ? 1 : 0);
                            }
                            if (arg_84_0 == 0)
                            {
                                this.PrintOrderPageList.Add(printOrderPage);
                            }
                            num2++;
                        }
                    }
                    this.lstSelectedPages.ItemsSource = this.PrintOrderPageList;
                }
                while (!true);
                this.ActivePageNo = 1;
                PrintOrderPage printOrderPage2 = (from o in this.PrintOrderPageList
                                                  where o.PageNo == 1
                                                  select o).FirstOrDefault<PrintOrderPage>();
                ImageSource imageSource = printOrderPage2.ImageSource1;
                ImageSource imageSource2 = printOrderPage2.ImageSource2;
                this.rotateAngleLeft = printOrderPage2.RotationAngle1;
                this.rotateAngleRight = printOrderPage2.RotationAngle2;
                this.SelectedPhotoId1 = printOrderPage2.PhotoId1;
                this.SelectedPhotoId2 = printOrderPage2.PhotoId2;
                this.img1.Source = imageSource;
                do
                {
                    this.img2.Source = imageSource2;
                    this.tbkActivePageNo.Text = this.ActivePageNo.ToString();
                }
                while (5 == 0);
            }
            catch
            {
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.ShowToClientView();
        }

        private void ShowToClientView()
        {
            try
            {
                VisualBrush compiledBitmapImage = new VisualBrush(this.ThumbPreview);
                while (true)
                {
                    SearchResult searchResult;
                    if (3 != 0)
                    {
                        searchResult = null;
                    }
                    //using (IEnumerator enumerator = Application.Current.Windows.GetEnumerator())
                    //{
                    IEnumerator enumerator = Application.Current.Windows.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            if (!false)
                            {
                                Window window = (Window)enumerator.Current;
                                if (window.Title == "View/Order Station")
                                {
                                    searchResult = (SearchResult)window;
                                }
                            }
                        }
                    //}
                    while (true)
                    {
                        bool arg_A9_0;
                        bool expr_9D = arg_A9_0 = (searchResult == null);
                        if (!false)
                        {
                            bool flag = !expr_9D;
                            arg_A9_0 = flag;
                        }
                        if (arg_A9_0)
                        {
                            break;
                        }
                        if (4 != 0)
                        {
                            goto Block_6;
                        }
                    }
                IL_B4:
                    searchResult.CompileEffectChanged(compiledBitmapImage, -1);
                    while (false)
                    {
                    }
                    if (!false)
                    {
                        break;
                    }
                    continue;
                Block_6:
                    searchResult = new SearchResult();
                    goto IL_B4;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnRotateLeft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.rotateAngleLeft += 90;
                this.rotateAngleLeft %= 360;
                LstMyItems lstMyItems = (from o in RobotImageLoader.PrintImages
                                         where o.PhotoId == this.SelectedPhotoId1
                                         select o).FirstOrDefault<LstMyItems>();
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(lstMyItems.FilePath.Replace("Thumbnails", "Thumbnails_Big"), UriKind.Relative);
                TransformedBitmap transformedBitmap;
                PrintOrderPage printOrderPage;
                if (true)
                {
                    bitmapImage.DecodePixelWidth = 200;
                    bitmapImage.EndInit();
                    transformedBitmap = new TransformedBitmap();
                    transformedBitmap.BeginInit();
                    transformedBitmap.Source = bitmapImage;
                    while (false)
                    {
                    }
                    RotateTransform transform = new RotateTransform((double)this.rotateAngleLeft);
                    transformedBitmap.Transform = transform;
                    transformedBitmap.EndInit();
                    if (7 != 0)
                    {
                        this.img1.Source = transformedBitmap;
                    }
                    printOrderPage = (from o in this.PrintOrderPageList
                                      where o.PageNo == this.ActivePageNo
                                      select o).FirstOrDefault<PrintOrderPage>();
                }
                printOrderPage.ImageSource1 = transformedBitmap;
                printOrderPage.RotationAngle1 = this.rotateAngleLeft;
            }
            catch
            {
            }
        }

        private void btnRotateRight_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.rotateAngleRight += 90;
                this.rotateAngleRight %= 360;
                LstMyItems lstMyItems = (from o in RobotImageLoader.PrintImages
                                         where o.PhotoId == this.SelectedPhotoId2
                                         select o).FirstOrDefault<LstMyItems>();
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(lstMyItems.FilePath.Replace("Thumbnails", "Thumbnails_Big"), UriKind.Relative);
                TransformedBitmap transformedBitmap;
                PrintOrderPage printOrderPage;
                if (true)
                {
                    bitmapImage.DecodePixelWidth = 200;
                    bitmapImage.EndInit();
                    transformedBitmap = new TransformedBitmap();
                    transformedBitmap.BeginInit();
                    transformedBitmap.Source = bitmapImage;
                    while (false)
                    {
                    }
                    RotateTransform transform = new RotateTransform((double)this.rotateAngleRight);
                    transformedBitmap.Transform = transform;
                    transformedBitmap.EndInit();
                    if (7 != 0)
                    {
                        this.img2.Source = transformedBitmap;
                    }
                    printOrderPage = (from o in this.PrintOrderPageList
                                      where o.PageNo == this.ActivePageNo
                                      select o).FirstOrDefault<PrintOrderPage>();
                }
                printOrderPage.ImageSource2 = transformedBitmap;
                printOrderPage.RotationAngle2 = this.rotateAngleRight;
            }
            catch
            {
            }
        }

      
         void IStyleConnector.Connect(int connectionId, object target)
        {
            int arg_48_0 = connectionId;
            int expr_4B;
            do
            {
                int num;
                if (4 != 0)
                {
                    num = arg_48_0;
                }
                expr_4B = (arg_48_0 = num);
            }
            while (6 == 0);
            if (expr_4B == 6)
            {
                ((Image)target).MouseDown += new MouseButtonEventHandler(this.Image_PreviewMouseDown);
                if (!false)
                {
                    ((Image)target).TouchDown += new EventHandler<TouchEventArgs>(this.Image_PreviewMouseDown);
                }
            }
        }

        static SelectedAlbumlist()
        {
            // Note: this type is marked as 'beforefieldinit'.
            do
            {
                if (true)
                {
                    SelectedAlbumlist.PrintOrderPageProperty = DependencyProperty.Register("PrintOrderPageList", typeof(ObservableCollection<PrintOrderPage>), typeof(SelectedAlbumlist), new PropertyMetadata(new ObservableCollection<PrintOrderPage>()));
                    SelectedAlbumlist.MessageAlbum2Property = DependencyProperty.Register("MessageAlbum2", typeof(string), typeof(ModalDialog), new UIPropertyMetadata(string.Empty));
                }
            }
            while (false);
        }
    }
}
