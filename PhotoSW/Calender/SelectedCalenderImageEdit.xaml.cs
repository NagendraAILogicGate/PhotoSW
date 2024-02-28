using PhotoSW.Common;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using PhotoSW.Calender;
using PhotoSW.Views;

namespace PhotoSW.Calender
{
    /// <summary>
    /// Interaction logic for SelectedCalenderImageEdit.xaml
    /// </summary>
  

    public partial class SelectedCalenderImageEdit : UserControl, IComponentConnector
    {
        public static readonly DependencyProperty ItemTemplateCalenderViewProperty;

        public static readonly DependencyProperty ItemTemplateCalenderDetailProperty;

        private bool _result = false;

        private bool _hideRequest = false;

        private UIElement _parent;

        //internal Grid grdCalenderPreview;

        //internal Grid grdImageEditOuter;

        //internal Image upperImage;

        //internal Image lowerImage;

        //internal StackPanel SPSubmitCancel;

        //internal Button btnSubmit;

        //internal Button btnSubmitCancel;

        //internal Button btnClose;

        //private bool _contentLoaded;

        public ItemTemplateCalenderView ItemTemplateCalenderView
        {
            get
            {
                return (ItemTemplateCalenderView)base.GetValue(SelectedCalenderImageEdit.ItemTemplateCalenderViewProperty);
            }
            set
            {
                base.SetValue(SelectedCalenderImageEdit.ItemTemplateCalenderViewProperty, value);
            }
        }

        public ItemTemplateDetail ItemTemplateCalenderDetail
        {
            get
            {
                return (ItemTemplateDetail)base.GetValue(SelectedCalenderImageEdit.ItemTemplateCalenderDetailProperty);
            }
            set
            {
                base.SetValue(SelectedCalenderImageEdit.ItemTemplateCalenderDetailProperty, value);
            }
        }

        public SelectedCalenderImageEdit()
        {
            this.InitializeComponent();
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(this.SelectedCalenderImageEdit_IsVisibleChanged);
            }
        }

        private void SelectedCalenderImageEdit_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            while (-1 != 0)
            {
                if (8 != 0)
                {
                    if (7 != 0)
                    {
                        bool flag = base.Visibility != Visibility.Visible;
                        if (false)
                        {
                            continue;
                        }
                        if (!flag)
                        {
                            goto IL_1E;
                        }
                    }
                    return;
                }
            IL_1E:
                this.BuildImages();
                break;
            }
        }

        private void ShowToClientView()
        {
            try
            {
                if (4 != 0)
                {
                    VisualBrush compiledBitmapImage = new VisualBrush(this.grdCalenderPreview);
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

        private void CalcImageSize()
        {
        }

        public Rectangle GetLargestRectangle(Rectangle rect, int xratio, int yratio)
        {
            Rectangle rectangle;
            while (!false)
            {
                rectangle = new Rectangle();
                double arg_2B_0;
                double arg_43_0 = arg_2B_0 = rect.Width / (double)xratio;
                double num;
                double arg_4F_0;
                double width;
                while (true)
                {
                    if (false)
                    {
                        goto IL_41;
                    }
                    num = arg_2B_0 * (double)yratio;
                    double expr_CE = arg_2B_0 = (arg_43_0 = (arg_4F_0 = rect.Height));
                    if (!false)
                    {
                        arg_43_0 = expr_CE / (double)yratio;
                        goto IL_41;
                    }
                IL_46:
                    if (4 != 0)
                    {
                        break;
                    }
                    continue;
                IL_41:
                    width = arg_43_0 * (double)xratio;
                    arg_43_0 = (arg_2B_0 = (arg_4F_0 = num));
                    goto IL_46;
                }
                bool arg_54_0 = arg_4F_0 <= rect.Height;
                bool expr_56;
                do
                {
                    bool flag = arg_54_0;
                    expr_56 = (arg_54_0 = flag);
                }
                while (2 == 0);
                if (expr_56)
                {
                    rectangle.Width = rect.Width;
                    rectangle.Height = num;
                    break;
                }
                if (2 != 0)
                {
                    rectangle.Width = width;
                    rectangle.Height = rect.Height;
                    return rectangle;
                }
            }
            return rectangle;
        }

        private void BuildImages()
        {
            if (-1 != 0 && 5 != 0)
            {
                if (this.ItemTemplateCalenderDetail != null)
                {
                    this.lowerImage.Source = this.GetBitmapImage(System.IO.Path.Combine(new string[]
					{
						LoginUser.ItemCalenderPath + this.ItemTemplateCalenderDetail.FilePath
					}));
                    this.upperImage.Source = this.GetBitmapImage(this.ItemTemplateCalenderDetail.AssociationPhotoFilePath);
                }
            }
        }

        private ImageSource GetBitmapImage(string imagePath)
        {
            ImageSource result;
            if (!string.IsNullOrWhiteSpace(imagePath))
            {
                if (8 == 0)
                {
                    goto IL_3D;
                }
                if (!false)
                {
                    if (!File.Exists(imagePath))
                    {
                        ErrorHandler.ErrorHandler.LogFileWrite(string.Format("Calender Template : File not found \"{0}\"", imagePath));
                    }
                    else
                    {
                        result = new BitmapImage(new Uri(imagePath));
                        if (!false)
                        {
                            goto IL_57;
                        }
                        goto IL_3D;
                    }
                }
            }
            else
            {
                while (true)
                {
                    result = null;
                    if (!false)
                    {
                        goto IL_57;
                    }
                }
            }
        IL_3A:
            result = null;
        IL_3D:
        IL_57:
            if (3 != 0)
            {
                return result;
            }
            goto IL_3A;
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<ItemTemplateDetail> itemTemplateDetailList = this.ItemTemplateCalenderView.ItemTemplateCalenderSelected.ItemTemplateDetailList;
            long arg_D7_0 = (long)this.ItemTemplateCalenderDetail.Id;
            while (true)
            {
                long num = arg_D7_0;
                int arg_80_0;
                int expr_30 = arg_80_0 = 0;
                int num2;
                if (expr_30 == 0)
                {
                    num2 = expr_30;
                    goto IL_85;
                }
                goto IL_7F;
            IL_36:
                long expr_43 = arg_D7_0 = (long)itemTemplateDetailList[num2].Id;
                if (7 == 0)
                {
                    continue;
                }
                int arg_4B_0 = (expr_43 == num) ? 1 : 0;
            IL_4A:
                int arg_8C_0;
                int arg_8C_1;
                if (arg_4B_0 != 0)
                {
                    do
                    {
                        int expr_52 = arg_8C_0 = num2;
                        int expr_54 = arg_8C_1 = 1;
                        if (expr_54 == 0)
                        {
                            goto IL_8C;
                        }
                        if (expr_52 < expr_54)
                        {
                            goto IL_7C;
                        }
                        this.ItemTemplateCalenderDetail = itemTemplateDetailList[num2 - 1];
                    }
                    while (6 == 0);
                    this.BuildImages();
                    if (false)
                    {
                        goto IL_36;
                    }
                IL_7C: ;
                }
                arg_80_0 = num2;
                goto IL_7F;
            IL_8C:
                if (arg_8C_0 >= arg_8C_1)
                {
                    break;
                }
                goto IL_36;
            IL_85:
                arg_8C_0 = num2;
                arg_8C_1 = itemTemplateDetailList.Count;
                goto IL_8C;
            IL_7F:
                int expr_80 = arg_4B_0 = arg_80_0 + 1;
                if (!false)
                {
                    num2 = expr_80;
                    goto IL_85;
                }
                goto IL_4A;
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (false)
            {
                goto IL_43;
            }
            if (false)
            {
                goto IL_8D;
            }
            ObservableCollection<ItemTemplateDetail> itemTemplateDetailList = this.ItemTemplateCalenderView.ItemTemplateCalenderSelected.ItemTemplateDetailList;
            int arg_35_0;
            bool arg_6E_0 = (arg_35_0 = this.ItemTemplateCalenderDetail.Id) != 0;
        IL_32:
            if (8 == 0)
            {
                goto IL_6B;
            }
            long num = (long)arg_35_0;
            int num2 = 0;
            if (5 != 0)
            {
                goto IL_92;
            }
        IL_42:
        IL_43:
            bool flag = (long)itemTemplateDetailList[num2].Id != num;
            if (flag)
            {
                goto IL_8D;
            }
            flag = (num2 + 1 >= itemTemplateDetailList.Count);
            arg_6E_0 = ((arg_35_0 = (flag ? 1 : 0)) != 0);
        IL_6B:
            if (false)
            {
                goto IL_32;
            }
            if (!arg_6E_0)
            {
                if (false)
                {
                    goto IL_9C;
                }
                this.ItemTemplateCalenderDetail = itemTemplateDetailList[num2 + 1];
                this.BuildImages();
            }
        IL_8D:
            num2++;
        IL_92:
            flag = (num2 < itemTemplateDetailList.Count);
        IL_9C:
            if (!flag)
            {
                return;
            }
            goto IL_42;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            base.Visibility = Visibility.Hidden;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                    base.Visibility = Visibility.Hidden;
                }
                while (true)
                {
                    this._result = true;
                    if (7 == 0)
                    {
                        break;
                    }
                    if (8 != 0)
                    {
                        if (!false)
                        {
                            this.HideHandlerDialog();
                        }
                        if (!false)
                        {
                            return;
                        }
                    }
                }
            }
        }

        public bool ShowRequest()
        {
            if (true)
            {
                base.Visibility = Visibility.Visible;
            }
            this._parent.IsEnabled = false;
            this._hideRequest = false;
            bool result;
            while (true)
            {
                bool arg_A5_0 = this._hideRequest;
                int arg_A5_1 = 0;
                while (true)
                {
                IL_A5:
                    bool arg_A7_0 = (arg_A5_0 ? 1 : 0) == arg_A5_1;
                    while (true)
                    {
                        bool flag = arg_A7_0;
                        while (true)
                        {
                            if (flag)
                            {
                                bool arg_5C_0;
                                if (!base.Dispatcher.HasShutdownStarted)
                                {
                                    int expr_4A = (arg_A5_0 = base.Dispatcher.HasShutdownFinished) ? 1 : 0;
                                    int expr_50 = arg_A5_1 = 0;
                                    if (expr_50 != 0)
                                    {
                                        goto IL_A5;
                                    }
                                    arg_5C_0 = (expr_4A == expr_50);
                                }
                                else
                                {
                                    arg_5C_0 = false;
                                }
                                if (!false)
                                {
                                }
                                flag = arg_5C_0;
                                bool expr_5D = arg_A7_0 = flag;
                                if (3 == 0)
                                {
                                    break;
                                }
                                if (expr_5D)
                                {
                                    goto IL_66;
                                }
                            }
                            result = this._result;
                            if (!false)
                            {
                                return result;
                            }
                        }
                    }
                }
            IL_66:
                base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                }));
                if (5 != 0)
                {
                    Thread.Sleep(20);
                }
            }
            return result;
        }

        private void HideHandlerDialog()
        {
            if (4 != 0)
            {
                this._hideRequest = true;
                do
                {
                    Visibility expr_0E = Visibility.Hidden;
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

        public void SetParentAlbum(UIElement parent)
        {
            this._parent = parent;
        }

        private void btnSubmitCancel_Click(object sender, RoutedEventArgs e)
        {
            base.Visibility = Visibility.Hidden;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
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



        //static SelectedCalenderImageEdit()
        //{
        //    // Note: this type is marked as 'beforefieldinit'.
        //    do
        //    {
        //        if (true)
        //        {
        //            SelectedCalenderImageEdit.ItemTemplateCalenderViewProperty = DependencyProperty.Register("ItemTemplateCalenderView", typeof(ItemTemplateCalenderView), typeof(SelectedCalenderImageEdit), new PropertyMetadata(new ItemTemplateCalenderView()));
        //            SelectedCalenderImageEdit.ItemTemplateCalenderDetailProperty = DependencyProperty.Register("ItemTemplateCalenderDetail", typeof(ItemTemplateDetail), typeof(SelectedCalenderImageEdit), new PropertyMetadata(new ItemTemplateDetail()));
        //        }
        //    }
        //    while (false);
        //}
    }
}
