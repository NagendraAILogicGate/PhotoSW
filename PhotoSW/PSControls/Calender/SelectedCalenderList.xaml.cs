using PhotoSW.Common;
using PhotoSW.DataLayer;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DigiPhoto;
using PhotoSW.Views;
using PhotoSW.Calender;

namespace PhotoSW.PSControls.Calender
{
    /// <summary>
    /// Interaction logic for SelectedCalenderList.xaml
    /// </summary>
   

    public partial class SelectedCalenderList : UserControl, IComponentConnector//, IStyleConnector
    {
        private delegate void SetCalenderImageHandler(Grid sender, string fileName);

        private int DropPhotoId = 0;

        private bool _hideRequest = false;

        private bool _intiLoad = false;

        private UIElement _parent;

        public static readonly DependencyProperty PrintOrderPageProperty;

        public static readonly DependencyProperty ItemTemplateCalenderViewProperty;

        public static readonly DependencyProperty MessageProperty;



        public List<LstMyItems> SelectedImage
        {
            get;
            set;
        }

        public long? SelectedMasterTemplateId
        {
            get;
            set;
        }

        public int? SelectedIndexId
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

        public ObservableCollection<PrintOrderPage> PrintOrderPageList
        {
            get
            {
                return (ObservableCollection<PrintOrderPage>)base.GetValue(SelectedCalenderList.PrintOrderPageProperty);
            }
            set
            {
                base.SetValue(SelectedCalenderList.PrintOrderPageProperty, value);
            }
        }

        public ItemTemplateCalenderView ItemTemplateCalenderView
        {
            get
            {
                return (ItemTemplateCalenderView)base.GetValue(SelectedCalenderList.ItemTemplateCalenderViewProperty);
            }
            set
            {
                base.SetValue(SelectedCalenderList.ItemTemplateCalenderViewProperty, value);
            }
        }

        public string Message
        {
            get
            {
                return (string)base.GetValue(SelectedCalenderList.MessageProperty);
            }
            set
            {
                base.SetValue(SelectedCalenderList.MessageProperty, value);
            }
        }

        public SelectedCalenderList()
        {
            this.InitializeComponent();
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                //this.ctrlSelectedCalenderImageEdit.SetParentAlbum(this.maingrd);
                this.lstSelectedImage.Items.Clear();
                foreach (LstMyItems current in RobotImageLoader.PrintImages)
                {
                    this.lstSelectedImage.Items.Add(current);
                }
                //this.lstCalenderList.SelectionChanged += new SelectionChangedEventHandler(this.lstCalenderList_SelectionChanged);
                //this.lstCalenderGrid.DataContextChanged += new DependencyPropertyChangedEventHandler(this.lstCalenderGrid_DataContextChanged);
                //this.lstCalenderGrid.SelectionChanged += new SelectionChangedEventHandler(this.lstCalenderGrid_SelectionChanged);
            }
        }

        private void lstCalenderGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int arg_110_0;
            int arg_3E_0;
            bool arg_86_0;
            if (this.ItemTemplateCalenderView.ItemTemplateCalenderSelected != null)
            {
                int arg_2C_0 = this.ItemTemplateCalenderView.ItemTemplateCalenderSelected.SubtemplateCount;
                arg_86_0 = ((arg_3E_0 = (arg_110_0 = ((1 == 0) ? 1 : 0))) != 0);
            }
            else
            {
                arg_86_0 = ((arg_3E_0 = (arg_110_0 = 1)) != 0);
            }
            if (false)
            {
                goto IL_82;
            }
        IL_38:
            bool flag = arg_110_0 != 0;
            arg_3E_0 = (flag ? 1 : 0);
        IL_3E:
            if (arg_3E_0 != 0)
            {
                goto IL_C4;
            }
        IL_43:
            bool expr_44 = (arg_110_0 = (this._intiLoad ? 1 : 0)) != 0;
            if (3 == 0)
            {
                goto IL_38;
            }
            if (expr_44)
            {
                int arg_71_0;
                int arg_7D_0 = arg_71_0 = this.lstCalenderGrid.Items.Count;
                int arg_7D_1;
                do
                {
                    int expr_69 = arg_7D_1 = this.ItemTemplateCalenderView.ItemTemplateCalenderSelected.SubtemplateCount;
                    if (false)
                    {
                        goto IL_7D;
                    }
                    if (arg_71_0 != expr_69)
                    {
                        goto IL_81;
                    }
                    arg_7D_0 = (arg_71_0 = (this._intiLoad ? 1 : 0));
                }
                while (4 == 0);
                arg_7D_1 = 0;
            IL_7D:
                arg_86_0 = ((arg_3E_0 = ((arg_7D_0 == arg_7D_1) ? 1 : 0)) != 0);
                goto IL_82;
            }
        IL_81:
            arg_86_0 = ((arg_3E_0 = 1) != 0);
        IL_82:
            if (false)
            {
                goto IL_3E;
            }
            if (!arg_86_0)
            {
                this._intiLoad = false;
                this.lstCalenderGrid.Dispatcher.Invoke(new Action(delegate
                {
                    new object();
                    new RoutedEventArgs();
                    this.BindImageToCalenderControlAuto(false);
                }), new object[0]);
                this.ShowToClientView1();
            }
        IL_C4:
            if (3 != 0)
            {
                return;
            }
            goto IL_43;
        }

        private void lstCalenderGrid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.lstCalenderGrid.SelectedIndex = 0;
        }

        private void lstCalenderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemTemplateMaster itemTemplateMaster;
            do
            {
                itemTemplateMaster = (this.lstCalenderList.SelectedItem as ItemTemplateMaster);
                if (false)
                {
                    goto IL_41;
                }
                this.ItemTemplateCalenderView.ItemTemplateCalenderSelected = itemTemplateMaster;
            }
            while (false);
            if (false)
            {
                return;
            }
            if (8 != 0)
            {
                int arg_39_0;
                bool expr_29 = (arg_39_0 = ((itemTemplateMaster == null) ? 1 : 0)) != 0;
                if (!false)
                {
                    if (expr_29)
                    {
                        goto IL_41;
                    }
                    arg_39_0 = itemTemplateMaster.Id;
                }
                LoginUser.MasterTemplateId = arg_39_0;
                return;
            }
        IL_41:
            LoginUser.MasterTemplateId = 1;
        }

        public void SetParentAlbum(UIElement parent)
        {
            this._parent = parent;
        }

        public List<LstMyItems> ShowAlbumHandlerDialog(string message)
        {
            this.BindPageStrips();
            List<LstMyItems> selectedImage;
            while (true)
            {
                while (true)
                {
                    if (true)
                    {
                        this.Message = message;
                    }
                    if (!false)
                    {
                        if (-1 != 0)
                        {
                            base.Visibility = Visibility.Visible;
                        }
                        if (8 != 0)
                        {
                            this._parent.IsEnabled = true;
                            this._hideRequest = false;
                        }
                        selectedImage = this.SelectedImage;
                        if (4 != 0)
                        {
                            return selectedImage;
                        }
                    }
                }
            }
            return selectedImage;
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
            this.SelectedImage = new List<LstMyItems>();
            this.PreviousImage = new List<string>();
            this.PrintOrderPageList = new ObservableCollection<PrintOrderPage>();
            int num2;
            int num3;
            string[] values;
            while (true)
            {
                ItemCollection items = this.lstCalenderGrid.Items;
                bool flag = this.ItemTemplateCalenderView.ItemTemplateCalenderSelected == null;
                if (false)
                {
                    goto IL_DE;
                }
                ItemCollection items2;
                int num;
                if (!flag)
                {
                    this.SelectedMasterTemplateId = new long?((long)this.ItemTemplateCalenderView.ItemTemplateCalenderSelected.Id);
                    items2 = this.lstCalenderList.Items;
                    num = 0;
                    goto IL_CD;
                }
                goto IL_E3;
            IL_369:
                num2 = 0;
                bool arg_382_0;
                if (5 != 0)
                {
                    num3 = 0;
                    flag = (this.SelectedImage == null);
                    arg_382_0 = flag;
                    goto IL_382;
                }
                continue;
            IL_353:
                if (false)
                {
                    goto IL_361;
                }
                if (!flag)
                {
                    break;
                }
                goto IL_369;
            IL_DE:
                if (!flag)
                {
                    goto IL_E3;
                }
                if (!false)
                {
                    if ((long)(items2[num] as ItemTemplateMaster).Id == this.SelectedMasterTemplateId.Value)
                    {
                        this.SelectedIndexId = new int?(num);
                    }
                    num++;
                    goto IL_CD;
                }
                goto IL_353;
            IL_382:
                if (!arg_382_0)
                {
                    num2 = this.SelectedImage.Count;
                }
                if (this.ItemTemplateCalenderView != null && this.ItemTemplateCalenderView.ItemTemplateCalenderSelected != null && this.ItemTemplateCalenderView.ItemTemplateCalenderSelected.SubtemplateCount > 0)
                {
                    num3 = this.ItemTemplateCalenderView.ItemTemplateCalenderSelected.SubtemplateCount;
                }
                values = new string[]
				{
					"The calender template needs more images to print.",
					Environment.NewLine,
					" Selected no of images '{1}' / Expected no of images '{0}'.",
					Environment.NewLine,
					" Please select more images before submit."
				};
                if (!false)
                {
                    goto Block_15;
                }
                goto IL_369;
            IL_CD:
                bool expr_D4 = arg_382_0 = (num < items2.Count);
                if (!false)
                {
                    flag = expr_D4;
                    goto IL_DE;
                }
                goto IL_382;
            IL_E3:
                PrintOrderPage printOrderPage = new PrintOrderPage();
                foreach (object current in ((IEnumerable)items))
                {
                    if (4 == 0)
                    {
                        goto IL_166;
                    }
                    ItemTemplateDetail _itemDetail = current as ItemTemplateDetail;
                    LstMyItems lstMyItems;
                    LstMyItems lstMyItems2;
                    if (!string.IsNullOrWhiteSpace(_itemDetail.AssociationPhotoFilePath))
                    {
                        lstMyItems = (from o in RobotImageLoader.PrintImages
                                      where o.PhotoId == _itemDetail.AssociationPhotoId
                                      select o).FirstOrDefault<LstMyItems>();
                        lstMyItems2 = new LstMyItems();
                        goto IL_166;
                    }
                    continue;
                IL_166:
                    lstMyItems2.PhotoId = lstMyItems.PhotoId;
                    lstMyItems2.Name = lstMyItems.Name;
                    lstMyItems2.FileName = lstMyItems.FileName;
                    lstMyItems2.FilePath = lstMyItems.FilePath.Replace("Thumbnails", "Thumbnails_Big");
                    lstMyItems2.ItemTemplateHeaderId = _itemDetail.MasterTemplateId;
                    lstMyItems2.ItemTemplateDetailId = _itemDetail.Id;
                    int arg_298_0;
                    int expr_1E0 = arg_298_0 = _itemDetail.FileOrder;
                    if (false)
                    {
                        goto IL_298;
                    }
                    if (expr_1E0 > 0)
                    {
                        lstMyItems2.PageNo = _itemDetail.FileOrder;
                    }
                    if (string.IsNullOrWhiteSpace(printOrderPage.Name1))
                    {
                        printOrderPage.PhotoId1 = _itemDetail.AssociationPhotoId;
                        printOrderPage.FilePath1 = _itemDetail.AssociationPhotoFilePath;
                        printOrderPage.Name1 = _itemDetail.AssociationPhotoFileName;
                        printOrderPage.ItemTemplateHeaderId = _itemDetail.MasterTemplateId;
                        printOrderPage.ItemTemplateDetailId = _itemDetail.Id;
                        flag = (_itemDetail.FileOrder <= 0);
                        arg_298_0 = (flag ? 1 : 0);
                        goto IL_298;
                    }
                IL_2BB:
                    lstMyItems2.PhotoPrintPositionList.Add(new PhotoPrintPosition
                    {
                        PageNo = _itemDetail.FileOrder
                    });
                    this.SelectedImage.Add(lstMyItems2);
                    continue;
                IL_298:
                    if (arg_298_0 == 0)
                    {
                        printOrderPage.PageNo = _itemDetail.FileOrder;
                    }
                    this.PrintOrderPageList.Add(printOrderPage);
                    goto IL_2BB;
                }
                flag = (this.SelectedImage == null || this.SelectedImage.Count != this.ItemTemplateCalenderView.ItemTemplateCalenderSelected.SubtemplateCount);
                goto IL_353;
            }
            this.HideHandlerDialog();
        IL_361:
            return;
        Block_15:
            MessageBox.Show(string.Format(string.Concat(values), num3, num2), "Calender Template", MessageBoxButton.OK);
        }

        private void btnSubmitCancel_Click(object sender, RoutedEventArgs e)
        {
            int arg_10E_0;
            int arg_45_0;
            int arg_C9_0;
            if (this.lstCalenderGrid != null)
            {
                arg_C9_0 = (arg_45_0 = (arg_10E_0 = ((this.lstCalenderGrid.Items.Count <= 0) ? 1 : 0)));
            }
            else
            {
                arg_C9_0 = (arg_45_0 = (arg_10E_0 = 1));
            }
        IL_27:
            int num;
            if (!false)
            {
                if (4 != 0)
                {
                    if (arg_10E_0 != 0)
                    {
                        return;
                    }
                    arg_45_0 = 0;
                }
                int expr_45 = arg_45_0 = (arg_C9_0 = (arg_10E_0 = arg_45_0));
                if (expr_45 == 0)
                {
                    num = expr_45;
                    goto IL_CA;
                }
                goto IL_27;
            }
        IL_C9:
            num = arg_C9_0;
        IL_CA:
            bool expr_DB = (arg_C9_0 = ((num < this.lstCalenderGrid.Items.Count) ? 1 : 0)) != 0;
            if (4 == 0)
            {
                goto IL_C9;
            }
            bool flag = expr_DB;
            bool arg_7E_0;
            bool arg_77_0;
            bool expr_E2 = arg_77_0 = (arg_7E_0 = flag);
            if (3 == 0)
            {
                goto IL_7B;
            }
            if (!expr_E2)
            {
                return;
            }
            ListBoxItem obj = (ListBoxItem)this.lstCalenderGrid.ItemContainerGenerator.ContainerFromIndex(num);
            ContentPresenter contentPresenter = this.FindVisualChild<ContentPresenter>(obj);
            arg_77_0 = (contentPresenter == null);
        IL_77:
            flag = arg_77_0;
            arg_7E_0 = (arg_77_0 = flag);
        IL_7B:
            if (!false)
            {
                if (!arg_7E_0)
                {
                    DataTemplate contentTemplate = contentPresenter.ContentTemplate;
                    Grid grid = (Grid)contentTemplate.FindName("imgCalenderHolderGrid", contentPresenter);
                    object obj2 = grid.FindName("imgCalenderHolder");
                    if (obj2 != null)
                    {
                        (obj2 as Image).Source = null;
                    }
                }
                arg_C9_0 = num + 1;
                goto IL_C9;
            }
            goto IL_77;
        }

        private void ResetPageStrip()
        {
            int arg_5B_0;
            int arg_B4_0;
            if (this.SelectedImage != null && this.ItemTemplateCalenderView != null)
            {
                if (4 == 0)
                {
                    return;
                }
                if (this.ItemTemplateCalenderView.ItemTemplateCalenderSelected != null)
                {
                    arg_B4_0 = (arg_5B_0 = ((this.SelectedImage.Count != this.ItemTemplateCalenderView.ItemTemplateCalenderSelected.SubtemplateCount) ? 1 : 0));
                    goto IL_57;
                }
            }
            arg_B4_0 = (arg_5B_0 = 1);
        IL_57:
            if (2 == 0)
            {
                goto IL_B3;
            }
        IL_5B:
            if (arg_5B_0 == 0)
            {
                this.HideHandlerDialog();
                return;
            }
        IL_6D:
            int arg_BD_0;
            if ((arg_5B_0 = (arg_BD_0 = 0)) != 0)
            {
                goto IL_B6;
            }
            if (this.SelectedImage != null)
            {
                int count = this.SelectedImage.Count;
            }
            if (this.ItemTemplateCalenderView == null || this.ItemTemplateCalenderView.ItemTemplateCalenderSelected == null)
            {
                arg_BD_0 = (arg_5B_0 = 1);
                goto IL_B9;
            }
            arg_B4_0 = ((this.ItemTemplateCalenderView.ItemTemplateCalenderSelected.SubtemplateCount > 0) ? 1 : 0);
        IL_B3:
            arg_BD_0 = (arg_5B_0 = ((arg_B4_0 == 0) ? 1 : 0));
        IL_B6:
        IL_B9:
            if (false)
            {
                goto IL_5B;
            }
            bool flag = arg_BD_0 != 0;
            bool expr_BE = (arg_5B_0 = (arg_BD_0 = (flag ? 1 : 0))) != 0;
            if (false)
            {
                goto IL_B6;
            }
            if (!expr_BE)
            {
                int subtemplateCount = this.ItemTemplateCalenderView.ItemTemplateCalenderSelected.SubtemplateCount;
            }
            this.HideHandlerDialog();
            if (6 == 0)
            {
                goto IL_6D;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            int arg_5B_0;
            int arg_B4_0;
            if (this.SelectedImage != null && this.ItemTemplateCalenderView != null)
            {
                if (4 == 0)
                {
                    return;
                }
                if (this.ItemTemplateCalenderView.ItemTemplateCalenderSelected != null)
                {
                    arg_B4_0 = (arg_5B_0 = ((this.SelectedImage.Count != this.ItemTemplateCalenderView.ItemTemplateCalenderSelected.SubtemplateCount) ? 1 : 0));
                    goto IL_57;
                }
            }
            arg_B4_0 = (arg_5B_0 = 1);
        IL_57:
            if (2 == 0)
            {
                goto IL_B3;
            }
        IL_5B:
            if (arg_5B_0 == 0)
            {
                this.HideHandlerDialog();
                return;
            }
        IL_6D:
            int arg_BD_0;
            if ((arg_5B_0 = (arg_BD_0 = 0)) != 0)
            {
                goto IL_B6;
            }
            if (this.SelectedImage != null)
            {
                int count = this.SelectedImage.Count;
            }
            if (this.ItemTemplateCalenderView == null || this.ItemTemplateCalenderView.ItemTemplateCalenderSelected == null)
            {
                arg_BD_0 = (arg_5B_0 = 1);
                goto IL_B9;
            }
            arg_B4_0 = ((this.ItemTemplateCalenderView.ItemTemplateCalenderSelected.SubtemplateCount > 0) ? 1 : 0);
        IL_B3:
            arg_BD_0 = (arg_5B_0 = ((arg_B4_0 == 0) ? 1 : 0));
        IL_B6:
        IL_B9:
            if (false)
            {
                goto IL_5B;
            }
            bool flag = arg_BD_0 != 0;
            bool expr_BE = (arg_5B_0 = (arg_BD_0 = (flag ? 1 : 0))) != 0;
            if (false)
            {
                goto IL_B6;
            }
            if (!expr_BE)
            {
                int subtemplateCount = this.ItemTemplateCalenderView.ItemTemplateCalenderSelected.SubtemplateCount;
            }
            this.HideHandlerDialog();
            if (6 == 0)
            {
                goto IL_6D;
            }
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

        private void Selected_Image_Drop(object sender, DragEventArgs e)
        {
            LstMyItems lstMyItems = (from o in RobotImageLoader.PrintImages
                                     where o.PhotoId == this.DropPhotoId
                                     select o).FirstOrDefault<LstMyItems>();
            string text = lstMyItems.FilePath.Replace("Thumbnails", "Thumbnails_Big");
            if (!File.Exists(text))
            {
                ErrorHandler.ErrorHandler.LogFileWrite(string.Format("Calender Template : File not found \"{0}\"", text));
            }
            else
            {
                this.SetCalenderImage(sender as Grid, text);
                ItemTemplateDetail destination = ((Grid)sender).DataContext as ItemTemplateDetail;
                this.ItemTemplateCalenderView.CopyMyListItem(lstMyItems, destination, false);
            }
        }

        private void SetCalenderImage(Grid sender, string fileName)
        {
            bool expr_C3 = File.Exists(fileName);
            bool flag;
            if (!false)
            {
                flag = expr_C3;
            }
            if (flag)
            {
                if (2 == 0)
                {
                    goto IL_83;
                }
                BitmapImage expr_F3 = new BitmapImage();
                BitmapImage bitmapImage;
                if (!false)
                {
                    bitmapImage = expr_F3;
                }
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(fileName, UriKind.Relative);
                if (8 == 0)
                {
                    return;
                }
                if (false)
                {
                    goto IL_19;
                }
                bitmapImage.DecodePixelWidth = 200;
            IL_6C:
                bitmapImage.EndInit();
                TransformedBitmap transformedBitmap;
                do
                {
                    transformedBitmap = new TransformedBitmap();
                    transformedBitmap.BeginInit();
                }
                while (7 == 0);
            IL_83:
                if (!false)
                {
                    transformedBitmap.Source = bitmapImage;
                    transformedBitmap.EndInit();
                    object obj;
                    do
                    {
                        obj = sender.FindName("imgCalenderHolder");
                    }
                    while (6 == 0);
                    flag = (obj == null);
                    if (!flag)
                    {
                        (obj as Image).Source = transformedBitmap;
                    }
                    return;
                }
                goto IL_6C;
            }
        IL_19:
            ErrorHandler.ErrorHandler.LogFileWrite(string.Format("Calender Template : File not found \"{0}\"", fileName));
        }

        private void SetCalenderImageAsync(Grid sender, string fileName)
        {
            SelectedCalenderList.SetCalenderImageHandler setCalenderImageHandler = new SelectedCalenderList.SetCalenderImageHandler(this.SetCalenderImage);
            setCalenderImageHandler.BeginInvoke(sender, fileName, new AsyncCallback(this.SetCalenderImageCallback), null);
        }

        private void SetCalenderImageCallback(IAsyncResult result)
        {
            while (5 != 0)
            {
                if (!false)
                {
                    AsyncResult expr_09 = result as AsyncResult;
                    AsyncResult asyncResult;
                    if (4 != 0)
                    {
                        asyncResult = expr_09;
                    }
                    SelectedCalenderList.SetCalenderImageHandler expr_16 = asyncResult.AsyncDelegate as SelectedCalenderList.SetCalenderImageHandler;
                    SelectedCalenderList.SetCalenderImageHandler setCalenderImageHandler;
                    if (5 != 0)
                    {
                        setCalenderImageHandler = expr_16;
                    }
                    while (!false)
                    {
                        setCalenderImageHandler.EndInvoke(result);
                        if (5 != 0)
                        {
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void BindPageStrips()
        {
            while (true)
            {
                bool expr_0C = this.ItemTemplateCalenderView == null;
                bool flag;
                if (3 != 0)
                {
                    flag = expr_0C;
                }
                if (!flag)
                {
                }
                bool flag2 = false;
                flag = (this.SelectedImage != null && this.SelectedImage.Count != 0);
                if (!flag)
                {
                    flag2 = true;
                    this.ItemTemplateCalenderView.OperationDoneEvent += new ItemTemplateCalenderView.OperationDoneHandler(this.ItemTemplateCalenderView_OperationDoneEvent);
                    goto IL_67;
                }
                goto IL_8D;
            IL_96:
                if (!false)
                {
                    if (2 == 0)
                    {
                        continue;
                    }
                    flag2 = false;
                    this._intiLoad = true;
                    this.lstCalenderList.SelectedIndex = 0;
                }
                ItemTemplatePrintOrder.GetCalenderPages(111L, LoginUser.DigiFolderThumbnailPath, LoginUser.ItemCalenderPath);
                goto IL_C7;
            IL_67:
                if (false)
                {
                    goto IL_96;
                }
                this.ItemTemplateCalenderView.LoadCalenderTemplate(LoginUser.ItemCalenderPath);
                if (true)
                {
                    base.DataContext = this.ItemTemplateCalenderView;
                }
            IL_8D:
                flag = !flag2;
                if (!flag)
                {
                    goto IL_96;
                }
                if (!false)
                {
                    break;
                }
            IL_C7:
                if (8 != 0)
                {
                    break;
                }
                goto IL_67;
            }
        }

        private void ItemTemplateCalenderView_OperationDoneEvent(ItemTemplateCalenderView sender, CalenderViewOperationType operation)
        {
            while (true)
            {
            IL_00:
                while (true)
                {
                    bool arg_07_0 = operation == CalenderViewOperationType.LoadCalenderDetailData;
                    bool expr_24;
                    do
                    {
                        bool flag = !arg_07_0;
                        if (false)
                        {
                            goto IL_00;
                        }
                        expr_24 = (arg_07_0 = flag);
                    }
                    while (7 == 0 || 8 == 0);
                    if (!expr_24)
                    {
                    }
                    if (!false)
                    {
                        return;
                    }
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.ShowToClientView1();
        }

        public void ShowToClientView1()
        {
            try
            {
                if (4 != 0)
                {
                    VisualBrush compiledBitmapImage = new VisualBrush(this.grdMainView);
                    SearchResult searchResult = null;
                    if (searchResult == null)
                    {
                        searchResult = new SearchResult();
                    }
                    searchResult.CompileEffectChanged(compiledBitmapImage, -1);
                }
            }
            catch (Exception serviceException)
            {
                if (false)
                {
                    goto IL_70;
                }
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
            IL_62:
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            IL_68:
                if (!false && false)
                {
                    goto IL_62;
                }
            IL_70:
                if (6 == 0)
                {
                    goto IL_68;
                }
            }
        }

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            this.BindImageToCalenderControlRandom(true);
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            int arg_42_0;
            int arg_8B_0;
            if (this.ItemTemplateCalenderView != null && this.ItemTemplateCalenderView.ItemTemplateCalenderSelected != null)
            {
                int arg_39_0;
                int expr_FB = arg_39_0 = this.ItemTemplateCalenderView.ItemTemplateCalenderSelected.SubtemplateCount;
                int arg_39_1;
                int expr_33 = arg_39_1 = 0;
                if (expr_33 == 0)
                {
                    arg_39_0 = ((expr_FB > expr_33) ? 1 : 0);
                    arg_39_1 = 0;
                }
                arg_8B_0 = (arg_42_0 = ((arg_39_0 == arg_39_1) ? 1 : 0));
                if (4 == 0)
                {
                    goto IL_8A;
                }
            }
            else
            {
                arg_42_0 = 1;
            }
            if (arg_42_0 != 0)
            {
                return;
            }
            Random random = new Random(DateTime.Now.Millisecond);
            List<int> list = new List<int>();
            if (false)
            {
                goto IL_85;
            }
            int count = RobotImageLoader.PrintImages.Count;
            int count2 = this.lstCalenderGrid.Items.Count;
            int arg_83_0 = 0;
        IL_83:
            int num = arg_83_0;
        IL_85:
            goto IL_A4;
        IL_8A:
            int selectedIndex = arg_8B_0 % count;
            this.BindImageToCalenderControl(num, selectedIndex, true);
            int arg_9E_0 = num;
            int arg_9E_1 = 1;
        IL_9E:
            int expr_9E = arg_83_0 = arg_9E_0 + arg_9E_1;
            if (false)
            {
                goto IL_83;
            }
            num = expr_9E;
        IL_A4:
            int expr_A4 = arg_8B_0 = (arg_9E_0 = num);
            if (false)
            {
                goto IL_8A;
            }
            int expr_A9 = arg_9E_1 = count2;
            if (false)
            {
                goto IL_9E;
            }
            if (expr_A4 < expr_A9)
            {
                arg_8B_0 = num;
                goto IL_8A;
            }
        }

        private void BindImageToCalenderControlAuto(bool isneedtobindimage)
        {
            bool arg_3C_0;
            if (this.ItemTemplateCalenderView == null || this.ItemTemplateCalenderView.ItemTemplateCalenderSelected == null)
            {
                arg_3C_0 = true;
                goto IL_3B;
            }
            int arg_33_0 = this.ItemTemplateCalenderView.ItemTemplateCalenderSelected.SubtemplateCount;
            int arg_33_1 = 0;
        IL_33:
            arg_3C_0 = (arg_33_0 <= arg_33_1);
        IL_3B:
            if (!arg_3C_0)
            {
                Random random = new Random(DateTime.Now.Millisecond);
                List<int> list = new List<int>();
                int count = RobotImageLoader.PrintImages.Count;
                while (true)
                {
                    bool flag = count > 0;
                    if (false)
                    {
                        goto IL_9F;
                    }
                    int count2;
                    int num;
                    if (!flag)
                    {
                        if (!false)
                        {
                            break;
                        }
                    }
                    else
                    {
                        count2 = this.lstCalenderGrid.Items.Count;
                        num = 0;
                    }
                IL_C2:
                    flag = (num < count2);
                    if (8 == 0)
                    {
                        continue;
                    }
                    int arg_C0_0;
                    bool expr_CC = (arg_C0_0 = (flag ? 1 : 0)) != 0;
                    if (!false)
                    {
                        if (!expr_CC)
                        {
                            return;
                        }
                        goto IL_9F;
                    }
                IL_C0:
                    num = arg_C0_0;
                    goto IL_C2;
                IL_9F:
                    int arg_BF_0;
                    int expr_A0 = arg_33_0 = (arg_BF_0 = num);
                    int arg_BF_1;
                    int expr_A2 = arg_33_1 = (arg_BF_1 = count);
                    if (!false)
                    {
                        if (2 == 0)
                        {
                            goto IL_33;
                        }
                        int selectedIndex = expr_A0 % expr_A2;
                        this.BindImageToCalenderControl(num, selectedIndex, isneedtobindimage);
                        arg_BF_0 = num;
                        arg_BF_1 = 1;
                    }
                    arg_C0_0 = arg_BF_0 + arg_BF_1;
                    goto IL_C0;
                }
                MessageBox.Show("please Select Images");
            }
        }

        private void BindImageToCalenderControlRandom(bool isneedtobindimage)
        {
            bool arg_42_0;
            if (this.ItemTemplateCalenderView != null && this.ItemTemplateCalenderView.ItemTemplateCalenderSelected != null)
            {
                arg_42_0 = (this.ItemTemplateCalenderView.ItemTemplateCalenderSelected.SubtemplateCount <= 0);
                goto IL_41;
            }
            if (false)
            {
                goto IL_A2;
            }
            if (2 != 0)
            {
                arg_42_0 = true;
                goto IL_41;
            }
            goto IL_66;
            int num;
            int num2;
            do
            {
            IL_AC:
                int arg_B8_0;
                int expr_AC = arg_B8_0 = num;
                if (!false)
                {
                    bool flag = expr_AC < num2;
                    arg_B8_0 = (flag ? 1 : 0);
                }
                if (arg_B8_0 == 0)
                {
                    return;
                }
            }
            while (4 == 0);
            List<int> list;
            int count;
            Random rand;
            int availablepool = this.GetAvailablepool(list, count, rand);
            this.BindImageToCalenderControl(num, availablepool, true);
            goto IL_A2;
        IL_41:
            if (arg_42_0)
            {
                return;
            }
            if (3 != 0)
            {
                rand = new Random(DateTime.Now.Millisecond);
            }
            list = new List<int>();
        IL_66:
            count = RobotImageLoader.PrintImages.Count;
            int arg_81_0 = this.lstCalenderGrid.Items.Count;
        IL_81:
            num2 = arg_81_0;
            num = 0;
        // goto IL_AC;
        IL_A2:
            int expr_A3 = arg_81_0 = num;
            if (!false)
            {
                num = expr_A3 + 1;
                //goto IL_AC;
            }
            goto IL_81;
        }

        private void BindImageToCalenderControl(int i, int selectedIndex, bool isneedtobindimage)
        {
            LstMyItems expr_12C = RobotImageLoader.PrintImages[selectedIndex];
            LstMyItems lstMyItems;
            if (!false)
            {
                lstMyItems = expr_12C;
            }
            ListBoxItem listBoxItem = (ListBoxItem)this.lstCalenderGrid.ItemContainerGenerator.ContainerFromIndex(i);
            ContentPresenter contentPresenter = this.FindVisualChild<ContentPresenter>(listBoxItem);
            bool arg_48_0 = isneedtobindimage;
            while (arg_48_0)
            {
                if (8 != 0)
                {
                    bool expr_5C = arg_48_0 = (contentPresenter == null);
                    if (false)
                    {
                        continue;
                    }
                    bool flag = expr_5C;
                    if (false)
                    {
                        break;
                    }
                    if (!flag)
                    {
                        DataTemplate contentTemplate = contentPresenter.ContentTemplate;
                        Grid sender = (Grid)contentTemplate.FindName("imgCalenderHolderGrid", contentPresenter);
                        ItemTemplateDetail destination = listBoxItem.DataContext as ItemTemplateDetail;
                        string text = lstMyItems.FilePath.Replace("Thumbnails", "Thumbnails_Big");
                        while (!File.Exists(text))
                        {
                            ErrorHandler.ErrorHandler.LogFileWrite(string.Format("Calender Template : File not found \"{0}\"", text));
                            if (!false)
                            {
                                return;
                            }
                        }
                        bool arg_E1_0 = isneedtobindimage;
                        if (!false)
                        {
                            flag = !isneedtobindimage;
                            arg_E1_0 = flag;
                        }
                        if (!arg_E1_0)
                        {
                            this.SetCalenderImage(sender, text);
                        }
                        this.ItemTemplateCalenderView.CopyMyListItem(lstMyItems, destination, false);
                    }
                }
                return;
            }
            if (8 != 0)
            {
                ItemTemplateDetail destination = listBoxItem.DataContext as ItemTemplateDetail;
                this.ItemTemplateCalenderView.CopyMyListItem(lstMyItems, destination, false);
            }
        }

        private void imgCalenderHolderGrid_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                while (true)
                {
                    //this.ctrlSelectedCalenderImageEdit.ItemTemplateCalenderView = this.ItemTemplateCalenderView;
                    //this.ctrlSelectedCalenderImageEdit.ItemTemplateCalenderDetail = (((Grid)sender).DataContext as ItemTemplateDetail);
                    //this.ctrlSelectedCalenderImageEdit.Visibility = Visibility.Visible;
                    while (!false)
                    {
                       // this.ctrlSelectedCalenderImageEdit.ShowRequest();
                        if (false)
                        {
                            break;
                        }
                        if (!false)
                        {
                            return;
                        }
                    }
                }
            }
        }

        public int GetAvailablepool(List<int> list, int max, Random rand)
        {
            int arg_BE_0;
            int arg_BE_1;
            bool arg_114_0;
            if (list != null)
            {
                int expr_19 = arg_BE_0 = ((list.Count > 0) ? 1 : 0);
                int expr_1C = arg_BE_1 = 0;
                if (expr_1C != 0)
                {
                    goto IL_BE;
                }
                arg_114_0 = (expr_19 == expr_1C);
            }
            else
            {
                arg_114_0 = true;
            }
            bool flag;
            if (!false)
            {
                flag = arg_114_0;
            }
            int index;
            int num;
            if (!flag)
            {
                index = rand.Next(list.Count - 1);
                num = list[index];
                list.RemoveAt(index);
                goto IL_ED;
            }
            int num2;
            if (!false)
            {
                num2 = 0;
            }
            int arg_C2_0;
            int arg_C2_1;
            while (true)
            {
                int arg_84_0;
                int expr_7D = arg_84_0 = num2;
                if (!false)
                {
                    arg_84_0 = ((expr_7D < max) ? 1 : 0);
                }
                flag = (arg_84_0 != 0);
                if (!flag)
                {
                    break;
                }
                list.Add(num2);
                int expr_76 = arg_C2_0 = num2;
                int expr_78 = arg_C2_1 = 1;
                if (expr_78 == 0)
                {
                    goto IL_C2;
                }
                num2 = expr_76 + expr_78;
            }
            num2 = 0;
            goto IL_C0;
        IL_BA:
            arg_BE_0 = num2;
            arg_BE_1 = 1;
        IL_BE:
            num2 = arg_BE_0 + arg_BE_1;
        IL_C0:
            arg_C2_0 = num2;
            arg_C2_1 = max;
        IL_C2:
            flag = (arg_C2_0 < arg_C2_1);
            int expr_D3;
            int item;
            do
            {
                int arg_9D_0;
                if (!flag)
                {
                    expr_D3 = (arg_9D_0 = rand.Next(list.Count - 1));
                    if (!false)
                    {
                        goto Block_10;
                    }
                }
                else
                {
                    arg_9D_0 = rand.Next(list.Count - 1);
                }
                int index2 = arg_9D_0;
                item = list[index2];
                list.RemoveAt(index2);
            }
            while (false);
            list.Add(item);
            goto IL_BA;
        Block_10:
            index = expr_D3;
            num = list[index];
            list.RemoveAt(index);
        IL_ED:
            int result = num;
            if (!false)
            {
                return result;
            }
            goto IL_BA;
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
                childItem childItem1 = this.FindVisualChild<childItem>(child);
                flag = (childItem1 == null);
                if (!flag)
                {
                    result = childItem1;
                    goto IL_A0;
                }
                if (false)
                {
                    goto IL_81;
                }
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

        private void imgCalenderHolderGrid_Loaded(object sender, RoutedEventArgs e)
        {
            if (false)
            {
                goto IL_46;
            }
        IL_04:
            Grid grid = (Grid)sender;
            ItemTemplateDetail itemTemplateDetail = grid.DataContext as ItemTemplateDetail;
            string associationPhotoFilePath = itemTemplateDetail.AssociationPhotoFilePath;
            bool flag = string.IsNullOrWhiteSpace(itemTemplateDetail.AssociationPhotoFilePath);
        IL_46:
            if (!flag)
            {
                flag = File.Exists(associationPhotoFilePath);
                if (flag)
                {
                    this.SetCalenderImage(grid, associationPhotoFilePath);
                    if (6 != 0)
                    {
                        return;
                    }
                    return;
                }
            }
            else
            {
                if (false)
                {
                    goto IL_04;
                }
                if (5 != 0)
                {
                    if (!false)
                    {
                        this.BindImageToCalenderControlAuto(true);
                        return;
                    }
                }
            }
            ErrorHandler.ErrorHandler.LogFileWrite(string.Format("Calender Template : File not found \"{0}\"", associationPhotoFilePath));
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }



        static SelectedCalenderList()
        {
            // Note: this type is marked as 'beforefieldinit'.
            while (!false)
            {
                SelectedCalenderList.PrintOrderPageProperty = DependencyProperty.Register("PrintOrderPageList", typeof(ObservableCollection<PrintOrderPage>), typeof(SelectedCalenderList), new PropertyMetadata(new ObservableCollection<PrintOrderPage>()));
                if (!false)
                {
                    if (false)
                    {
                        return;
                    }
                    if (!false)
                    {
                        SelectedCalenderList.ItemTemplateCalenderViewProperty = DependencyProperty.Register("ItemTemplateCalenderView", typeof(ItemTemplateCalenderView), typeof(SelectedCalenderList), new PropertyMetadata(new ItemTemplateCalenderView()));
                        break;
                    }
                    break;
                }
            }
            SelectedCalenderList.MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(SelectedCalenderList), new UIPropertyMetadata(string.Empty));
        }
    }
}
