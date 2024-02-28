using ErrorHandler;
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
    public partial class SelectedImageslist : UserControl, IComponentConnector, IStyleConnector
    {
        private bool _hideRequest = false;

        private List<LstMyItems> _result;

        private UIElement _parent;

        public static readonly DependencyProperty Message2Property = DependencyProperty.Register("Message2", typeof(string), typeof(ModalDialog), new UIPropertyMetadata(string.Empty));

      

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

        public string Message
        {
            get
            {
                return (string)base.GetValue(SelectedImageslist.Message2Property);
            }
            set
            {
                base.SetValue(SelectedImageslist.Message2Property, value);
            }
        }

        public SelectedImageslist()
        {
            try
            {
                this.InitializeComponent();
                this.lstSelectedImage.Items.Clear();
                if (this._lstSelectedImage == null) return;
                foreach (LstMyItems current in this._lstSelectedImage)
                {
                    this.lstSelectedImage.Items.Add(current);
                }
            }
            catch (Exception var_1_73)
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
            this.Message = message;
            base.Visibility = Visibility.Visible;
            while (true)
            {
                this._parent.IsEnabled = true;
                List<LstMyItems>.Enumerator enumerator = this._lstSelectedImage.GetEnumerator();
                try
                {
                    if (!false)
                    {
                        goto IL_C2;
                    }
                IL_B2:
                IL_BE:
                    if (8 == 0)
                    {
                        goto IL_CA;
                    }
                IL_C2:
                    bool flag = enumerator.MoveNext();
                IL_CA:
                    if (flag)
                    {
                        LstMyItems current = enumerator.Current;
                        current.MaxCount = this.maxSelectedPhotos;
                        while (true)
                        {
                            int arg_A1_0;
                            if (this.IsPackage)
                            {
                                if (this.ProductTypeID == 35 || this.ProductTypeID == 36 || this.ProductTypeID == 4)
                                {
                                    goto IL_9B;
                                }
                                int expr_80 = arg_A1_0 = this.ProductTypeID;
                                if (!false)
                                {
                                    if (expr_80 == 78)
                                    {
                                        goto IL_9B;
                                    }
                                    arg_A1_0 = ((this.ProductTypeID != 101) ? 1 : 0);
                                }
                                goto IL_A0;
                            IL_9B:
                                arg_A1_0 = 0;
                            }
                            else
                            {
                                arg_A1_0 = 0;
                            }
                        IL_A1:
                            flag = (arg_A1_0 != 0);
                            if (flag)
                            {
                                break;
                            }
                            current.ToShownoCopy = false;
                            if (!false)
                            {
                                goto IL_B2;
                            }
                            continue;
                        IL_A0:
                            goto IL_A1;
                        }
                        current.ToShownoCopy = true;
                        goto IL_BE;
                    }
                }
                finally
                {
                    do
                    {
                        ((IDisposable)enumerator).Dispose();
                    }
                    while (8 == 0);
                }
                this.LoadCheckBox();
                this.CheckSelectedImg();
                this._hideRequest = false;
                while (true)
                {
                    if (!false)
                    {
                        bool flag = !this._hideRequest;
                        if (!flag)
                        {
                            goto IL_171;
                        }
                        flag = (!base.Dispatcher.HasShutdownStarted && !base.Dispatcher.HasShutdownFinished);
                        if (false)
                        {
                            break;
                        }
                        if (!flag)
                        {
                            goto Block_4;
                        }
                        base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                        {
                        }));
                        Thread.Sleep(20);
                    }
                }
            }
        Block_4:
        IL_171:
            return this._result;
        }

        private void LoadCheckBox()
        {
            while (6 != 0)
            {
                this.lstSelectedImage.Items.Clear();
                if (!false)
                {
                    IEnumerator<LstMyItems> enumerator = (from o in this._lstSelectedImage
                                                          where o.MediaType == 1
                                                          select o).GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            LstMyItems current;
                            if (!enumerator.MoveNext())
                            {
                                if (!false)
                                {
                                    break;
                                }
                                goto IL_E9;
                            }
                            else
                            {
                                current = enumerator.Current;
                                if (this.PreviousImage == null)
                                {
                                    current.IsItemSelected = false;
                                    current.updownCount = 1;
                                    goto IL_113;
                                }
                                string phtoId = current.PhotoId.ToString();
                                if (this.PreviousImage.Contains(phtoId))
                                {
                                    current.IsItemSelected = true;
                                    current.updownCount = (from o in this.PreviousImage
                                                           where o == phtoId
                                                           select o).Count<string>();
                                    goto IL_FE;
                                }
                                goto IL_E9;
                            }
                        IL_125:
                            if (!false)
                            {
                                continue;
                            }
                            goto IL_F4;
                        IL_E9:
                            if (!false)
                            {
                                current.IsItemSelected = false;
                                goto IL_F4;
                            }
                            goto IL_125;
                        IL_113:
                            this.lstSelectedImage.Items.Add(current);
                            goto IL_125;
                        IL_FE:
                            goto IL_113;
                        IL_F4:
                            current.updownCount = 1;
                            goto IL_FE;
                        }
                    }
                    finally
                    {
                        bool flag;
                        do
                        {
                            flag = (enumerator == null);
                        }
                        while (false);
                        if (!flag)
                        {
                            enumerator.Dispose();
                        }
                    }
                    break;
                }
            }
            if (7 != 0)
            {
            }
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
                            childItem childItem1 = SelectedImageslist.FindVisualChild<childItem>(dependencyObject);
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
                            childItem childItem1 = SelectedImageslist.FindVisualChild<childItem>(dependencyObject); ;
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
			int num;
			if (8 != 0)
			{
				num = 0;
				goto IL_69;
			}
			goto IL_192;
			IL_4A:
			CheckBox checkBox;
			if (checkBox != null)
			{
				checkBox.IsChecked = new bool?(false);
			}
			IL_64:
			num++;
			IL_69:
			DependencyObject dependencyObject;
			if (num >= this.lstSelectedImage.Items.Count)
			{
				if (!false)
				{
					num = 0;
					goto IL_1C6;
				}
				return;
			}
			else
			{
				dependencyObject = this.lstSelectedImage.ItemContainerGenerator.ContainerFromIndex(num);
				if (dependencyObject != null)
				{
					checkBox = SelectedImageslist.FindVisualChild<CheckBox>(dependencyObject);
					goto IL_4A;
				}
				goto IL_64;
			}
			IL_120:
			int value;
			if (4 != 0)
			{
				 var item = (from objSelected in this.PreviousImage
				where objSelected == Uid.ToString()
				select objSelected).FirstOrDefault<string>();
				value = (from o in this.PreviousImage
				where o == item
				select o).Count<string>();
			}
		
			IL_192:
			IL_195:
			IL_196:
			IntegerUpDown integerUpDown = SelectedImageslist.FindVisualChild<IntegerUpDown>(dependencyObject);
			bool flag = integerUpDown == null;
			if (2 == 0)
			{
				goto IL_1DB;
			}
			if (!flag)
			{
				integerUpDown.Value = new int?(value);
			}
			IL_1BB:
			if (false)
			{
				goto IL_120;
			}
			num++;
			IL_1C6:
			flag = (num < this.lstSelectedImage.Items.Count);
			IL_1DB:
			if (flag)
			{
				value = 1;
				dependencyObject = this.lstSelectedImage.ItemContainerGenerator.ContainerFromIndex(num);
				bool arg_AF_0;
				bool expr_A6 = arg_AF_0 = (dependencyObject == null);
				if (!false)
				{
					flag = expr_A6;
					arg_AF_0 = flag;
				}
				if (arg_AF_0)
				{
					goto IL_1BB;
				}
				int photoId = ((LstMyItems)((ContentControl)dependencyObject).Content).PhotoId;
				CheckBox chk = SelectedImageslist.FindVisualChild<CheckBox>(dependencyObject);
				if (chk == null)
				{
					goto IL_196;
				}
				flag = (this.PreviousImage == null);
				if (2 == 0)
				{
					goto IL_4A;
				}
				if (!flag)
				{
					goto IL_120;
				}
				goto IL_195;
			}
		}

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            int expr_01 = 0;
            int num;
            if (-1 != 0)
            {
                num = expr_01;
            }
            this._result = new List<LstMyItems>();
            int num2 = 0;
            while (true)
            {
                DependencyObject dependencyObject;
                bool flag;
                if (num2 < this.lstSelectedImage.Items.Count)
                {
                    dependencyObject = this.lstSelectedImage.ItemContainerGenerator.ContainerFromIndex(num2);
                    flag = (dependencyObject == null);
                    goto IL_48;
                }
                int arg_107_0 = this.ProductTypeID;
                while (arg_107_0 == 4 || this.ProductTypeID == 101)
                {
                    flag = (num == 4);
                    if (!flag)
                    {
                        bool arg_140_0;
                        if (num > 4)
                        {
                            int expr_132 = arg_107_0 = num % 4;
                            if (3 == 0)
                            {
                                continue;
                            }
                            arg_140_0 = (expr_132 != 0);
                        }
                        else
                        {
                            arg_140_0 = true;
                        }
                        flag = arg_140_0;
                        if (!flag)
                        {
                            flag = (System.Windows.MessageBox.Show("You have selected more than 4 images, do you want to continue ?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.Yes);
                            if (!flag)
                            {
                                this.HideHandlerDialog();
                                if (false)
                                {
                                    //goto IL_CA;
                                }
                            }
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Please select combination of 4 images.");
                            if (8 == 0)
                            {
                            IL_26B:
                                this.HideHandlerDialog();
                            IL_271:
                            IL_273:
                            IL_27F:
                            IL_294: ;
                            }
                        }
                    }
                    else
                    {
                        this.HideHandlerDialog();
                    }
                    goto IL_295;
                }
                if (this.ProductTypeID != 3 && this.ProductTypeID != 5)
                {
                    flag = !this.IsPackage;
                    if (!flag)
                    {
                        flag = (this._result.Count <= this.maxSelectedPhotos);
                        if (flag)
                        {
                            this.HideHandlerDialog();
                           // goto IL_27F;
                        }
                        flag = (System.Windows.MessageBox.Show("You have selected more than " + this.maxSelectedPhotos + " images, do you want to continue ?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.Yes);
                        if (!flag)
                        {
                            //goto IL_26B;
                        }
                       // goto IL_273;
                    }
                    else
                    {
                        if (3 == 0)
                        {
                           // goto IL_271;
                        }
                        this.HideHandlerDialog();
                        if (3 != 0)
                        {
                           // goto IL_294;
                        }
                    }
                }
                flag = (num <= 1);
                if (!flag)
                {
                    goto IL_1CA;
                }
                this.HideHandlerDialog();
                goto IL_203;
                bool arg_1E8_0;
                while (true)
                {
                IL_CA:
                    int num3;
                    int value;
                    bool expr_CE = arg_1E8_0 = (num3 < value);
                    if (3 == 0)
                    {
                        goto IL_1E8;
                    }
                    if (!expr_CE)
                    {
                        break;
                    }
                    this._result.Add((LstMyItems)this.lstSelectedImage.Items[num2]);
                    num3++;
                }
            IL_DF:
                num2++;
                continue;
            IL_48:
                if (!flag)
                {
                    CheckBox checkBox = SelectedImageslist.FindVisualChild<CheckBox>(dependencyObject);
                    if (checkBox != null)
                    {
                        if (Convert.ToBoolean(checkBox.IsChecked))
                        {
                            IntegerUpDown integerUpDown = SelectedImageslist.FindVisualChild<IntegerUpDown>(dependencyObject);
                            int value = integerUpDown.Value.Value;
                            num += value;
                            int num3 = 0;
                            //goto IL_CA;
                        }
                    }
                }
            IL_DE:
                goto IL_DF;
                goto IL_DE;
            IL_1CA:
                if (7 != 0)
                {
                    arg_1E8_0 = (System.Windows.MessageBox.Show("You have selected more than 1 image, do you want to continue ?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.Yes);
                    goto IL_1E8;
                }
                goto IL_48;
            IL_295:
                if (-1 != 0)
                {
                    break;
                }
                goto IL_1CA;
            IL_203:
                goto IL_295;
            IL_1E8:
                flag = arg_1E8_0;
                if (!flag)
                {
                    this.HideHandlerDialog();
                }
                goto IL_203;
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
                        CheckBox checkBox = SelectedImageslist.FindVisualChild<CheckBox>(dependencyObject);
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

        private void LoadImages()
        {
            if (4 != 0)
            {
                this.lstSelectedImage.Items.Clear();
            }
            using (IEnumerator<LstMyItems> enumerator = (from p in RobotImageLoader.GroupImages
                                                         where p.MediaType == 1
                                                         select p).GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    LstMyItems item;
                    do
                    {
                        item = enumerator.Current;
                        if (8 != 0)
                        {
                            item.IsChecked = false;
                            if (false)
                            {
                                goto IL_D7;
                            }
                        }
                        if (2 == 0 || this.PreviousImage == null)
                        {
                            goto IL_D9;
                        }
                    }
                    while (false);
                    string text;
                    do
                    {
                        text = this.PreviousImage.Where(delegate(string objSelected)
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
                    }
                    while (false);
                    if (text != null)
                    {
                        item.IsChecked = true;
                    }
                IL_D9:
                    this.lstSelectedImage.Items.Add(item);
                    continue;
                IL_D8:
                    goto IL_D9;
                IL_D7:
                    goto IL_D8;
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
