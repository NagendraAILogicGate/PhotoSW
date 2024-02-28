using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using ErrorHandler;
using FrameworkHelper;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit;
using DigiPhoto;

namespace PhotoSW.PSControls
{
    public partial class SelectedProcessedVideoslist : UserControl, IComponentConnector, IStyleConnector
    {
        private bool islistLoaded = false;

        private bool _hideRequest = false;

        private List<LstMyItems> _result;

        private UIElement _parent;

        public static readonly DependencyProperty MessageProcessedVideo2Property = DependencyProperty.Register("MessageProcessedVideo2", typeof(string), typeof(ModalDialog), new UIPropertyMetadata(string.Empty));

       

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

        public int PackageId
        {
            get;
            set;
        }

        public string MessageProcessedVideo2
        {
            get
            {
                return (string)base.GetValue(SelectedProcessedVideoslist.MessageProcessedVideo2Property);
            }
            set
            {
                base.SetValue(SelectedProcessedVideoslist.MessageProcessedVideo2Property, value);
            }
        }

        public SelectedProcessedVideoslist()
        {
            try
            {
                this.InitializeComponent();
                this.lstSelectedImage.Items.Clear();
            }
            catch (Exception var_0_32)
            {
            }
        }

        public void SetParent(UIElement parent)
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

        public List<LstMyItems> ShowHandlerDialog(string message)
        {
            bool flag;
            if (6 != 0)
            {
                do
                {
                    this.MessageProcessedVideo2 = message;
                    Visibility expr_1C = Visibility.Visible;
                    if (!false)
                    {
                        base.Visibility = expr_1C;
                    }
                    int expr_1B7 = this.PackageId;
                    if (!false)
                    {
                        this.LoadProcessedVideos(expr_1B7);
                    }
                    if (false)
                    {
                        break;
                    }
                    this._parent.IsEnabled = true;
                    while (-1 == 0)
                    {
                    }
                    if (-1 == 0)
                    {
                        break;
                    }
                    using (List<LstMyItems>.Enumerator enumerator = RobotImageLoader.PrintImages.GetEnumerator())
                    {
                        while (true)
                        {
                            flag = enumerator.MoveNext();
                            if (!flag)
                            {
                                break;
                            }
                            LstMyItems current = enumerator.Current;
                            current.MaxCount = this.maxSelectedPhotos;
                            int arg_9A_0;
                            bool arg_BD_0;
                            if (this.IsPackage)
                            {
                                if (this.ProductTypeID != 35)
                                {
                                    arg_9A_0 = this.ProductTypeID;
                                    goto IL_98;
                                }
                                goto IL_B4;
                            }
                            else
                            {
                                arg_BD_0 = ((arg_9A_0 = 0) != 0);
                            }
                        IL_B9:
                            if (!false)
                            {
                                flag = arg_BD_0;
                                if (!flag)
                                {
                                    current.ToShownoCopy = false;
                                }
                                else
                                {
                                    current.ToShownoCopy = true;
                                }
                                continue;
                            }
                            goto IL_98;
                        IL_B5:
                            goto IL_B9;
                        IL_98:
                            if (arg_9A_0 != 36 && this.ProductTypeID != 4)
                            {
                                arg_BD_0 = ((arg_9A_0 = ((this.ProductTypeID != 78) ? 1 : 0)) != 0);
                                goto IL_B5;
                            }
                        IL_B4:
                            arg_BD_0 = ((arg_9A_0 = 0) != 0);
                            goto IL_B5;
                        }
                    }
                    if (false)
                    {
                        break;
                    }
                    this.CheckSelectedImg();
                    this._hideRequest = false;
                }
                while (false);
                goto IL_16D;
            }
        IL_132:
            if (!flag)
            {
                goto IL_17A;
            }
            base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
            {
            }));
            Thread.Sleep(20);
        IL_16D:
            flag = !this._hideRequest;
            if (flag)
            {
                flag = (!base.Dispatcher.HasShutdownStarted && !base.Dispatcher.HasShutdownFinished);
                goto IL_132;
            }
        IL_17A:
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
                            childItem childItem1 = SelectedProcessedVideoslist.FindVisualChild<childItem>(dependencyObject);
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
                            childItem childItem1 = SelectedProcessedVideoslist.FindVisualChild<childItem>(dependencyObject); 
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
                    CheckBox checkBox = SelectedProcessedVideoslist.FindVisualChild<CheckBox>(dependencyObject);
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
            CheckBox chk = SelectedProcessedVideoslist.FindVisualChild<CheckBox>(dependencyObject);
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
            int num = 0;
            this._result = new List<LstMyItems>();
            int num2 = 0;
            while (true)
            {
                DependencyObject dependencyObject;
                bool arg_76_0;
                if (num2 >= this.lstSelectedImage.Items.Count)
                {
                    if (this.ProductTypeID != 4)
                    {
                        goto IL_1B7;
                    }
                    if (num == 4)
                    {
                        goto IL_1A5;
                    }
                    if (num <= 4 || num % 4 != 0)
                    {
                        goto IL_195;
                    }
                    if (System.Windows.MessageBox.Show("You have selected more than 4 videos, do you want to continue ?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.Yes)
                    {
                        goto IL_192;
                    }
                    if (!false)
                    {
                        break;
                    }
                    goto IL_7F;
                }
                else
                {
                    dependencyObject = this.lstSelectedImage.ItemContainerGenerator.ContainerFromIndex(num2);
                    if (dependencyObject == null)
                    {
                        goto IL_10B;
                    }
                    CheckBox checkBox = SelectedProcessedVideoslist.FindVisualChild<CheckBox>(dependencyObject);
                    if (checkBox != null)
                    {
                        arg_76_0 = !Convert.ToBoolean(checkBox.IsChecked);
                        goto IL_76;
                    }
                    goto IL_10A;
                }
            IL_10F:
                int arg_10F_0;
                num2 = arg_10F_0;
                continue;
            IL_7F:
                IntegerUpDown integerUpDown = SelectedProcessedVideoslist.FindVisualChild<IntegerUpDown>(dependencyObject);
                int num3 = 1;
                bool expr_96 = (arg_10F_0 = (integerUpDown.Value.HasValue ? 1 : 0)) != 0;
                if (!false)
                {
                    if (expr_96)
                    {
                        num3 = integerUpDown.Value.Value;
                    }
                    int arg_ED_0;
                    int expr_BC = arg_ED_0 = num + num3;
                    if (8 == 0)
                    {
                        goto IL_ED;
                    }
                    num = expr_BC;
                    int num4 = 0;
                IL_F0:
                    if (8 == 0)
                    {
                        goto IL_1AE;
                    }
                    bool expr_FA = arg_76_0 = (num4 < num3);
                    if (false)
                    {
                        goto IL_76;
                    }
                    if (!expr_FA)
                    {
                        goto IL_109;
                    }
                    this._result.Add((LstMyItems)this.lstSelectedImage.Items[num2]);
                    arg_ED_0 = num4 + 1;
                IL_ED:
                    num4 = arg_ED_0;
                    goto IL_F0;
                }
                goto IL_10F;
            IL_76:
                if (!arg_76_0)
                {
                    goto IL_7F;
                }
            IL_10B:
                arg_10F_0 = num2 + 1;
                goto IL_10F;
            IL_10A:
                goto IL_10B;
            IL_109:
                goto IL_10A;
            }
            this.HideHandlerDialog();
        IL_18D:
            if (-1 != 0)
            {
            }
        IL_192:
            goto IL_1A2;
        IL_195:
            System.Windows.MessageBox.Show("Please select combination of 4 videos.");
        IL_1A2:
            goto IL_1AE;
        IL_1A5:
            this.HideHandlerDialog();
        IL_1AE:
            if (!false)
            {
                return;
            }
            goto IL_18D;
        IL_1B7:
            bool flag = this.ProductTypeID != 3 && this.ProductTypeID != 5;
            if (6 != 0)
            {
                if (flag)
                {
                    if (this.IsPackage)
                    {
                        if (this._result.Count > this.maxSelectedPhotos)
                        {
                            if (System.Windows.MessageBox.Show("You have selected more than " + this.maxSelectedPhotos + " videos, do you want to continue ?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                            {
                                this.HideHandlerDialog();
                            }
                        }
                        else
                        {
                            this.HideHandlerDialog();
                        }
                    }
                    else
                    {
                        this.HideHandlerDialog();
                    }
                    return;
                }
                flag = (num <= 1);
            }
            if (!flag)
            {
                if (System.Windows.MessageBox.Show("You have selected more than 1 videos, do you want to continue ?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    this.HideHandlerDialog();
                }
            }
            else
            {
                this.HideHandlerDialog();
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
                        CheckBox checkBox = SelectedProcessedVideoslist.FindVisualChild<CheckBox>(dependencyObject);
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
                               where o.IsChecked
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
            int num = this.SelectedItemCount();
            bool flag = this.lstSelectedImage.Items.Count <= 0;
            if (!flag)
            {
                if (true)
                {
                    this.SPSelectAll.Visibility = Visibility.Visible;
                    flag = (this.lstSelectedImage.Items.Count != num);
                }
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
				num,
				"/",
				this.lstSelectedImage.Items.Count.ToString()
			});
        }

        private void LoadProcessedVideos(int PackageId)
        {
            ItemCollection expr_2DC = this.lstSelectedImage.Items;
            if (8 != 0)
            {
                expr_2DC.Clear();
            }
            ProcessedVideoBusiness processedVideoBusiness = new ProcessedVideoBusiness();
            List<ProcessedVideoInfo> processedVideosByPackageId = processedVideoBusiness.GetProcessedVideosByPackageId(PackageId);
            using (IEnumerator<LstMyItems> enumerator = RobotImageLoader.GroupImages.Where(delegate(LstMyItems p)
            {
                int arg_39_0;
                if (p.MediaType == 2)
                {
                    arg_39_0 = 1;
                    //goto IL_14;
                }
                int arg_0C_0 = p.MediaType;
                do
                {
                IL_0B:
                    arg_39_0 = (arg_0C_0 = ((arg_0C_0 == 3) ? 1 : 0));
                }
                while (false);
                bool expr_3C;
                do
                {
                IL_14:
                    bool flag = arg_39_0 != 0;
                    if (!false)
                    {
                    }
                    expr_3C = ((arg_0C_0 = (arg_39_0 = (flag ? 1 : 0))) != 0);
                }
                while (8 == 0);
                if (!false)
                {
                    return expr_3C;
                }
               // goto IL_0B;
            }).GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    LstMyItems item = enumerator.Current;
                    if ((from o in processedVideosByPackageId
                         where o.VideoId == item.PhotoId
                         select o).ToList<ProcessedVideoInfo>().Count > 0)
                    {
                        item.IsChecked = false;
                        VideoProcessingClass videoProcessingClass = new VideoProcessingClass();
                        item.FilePath = item.FilePath.Replace(videoProcessingClass.SupportedVideoFormats["avi"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mp4"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["wmv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mov"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3gp"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3g2"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m2v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m4v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["flv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mpeg"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["ffmpeg"].ToString(), ".jpg");
                        if (this.PreviousImage != null)
                        {
                            string text = this.PreviousImage.Where(delegate(string objSelected)
                            {
                                if (false)
                                {
                                    goto IL_20;
                                }
                                bool arg_27_0;
                                bool arg_46_0 = arg_27_0 = (objSelected == item.PhotoId.ToString());
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
                            }).FirstOrDefault<string>();
                            if (text != null)
                            {
                                item.IsChecked = true;
                            }
                        }
                        this.lstSelectedImage.Items.Add(item);
                    }
                }
            }
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
                if (arg_0E_0 == 2 || false)
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
