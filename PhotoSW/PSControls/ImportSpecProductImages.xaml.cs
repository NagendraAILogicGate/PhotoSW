using PhotoSW.Common;
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
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using DigiPhoto;

namespace PhotoSW.PSControls
{
    public partial class ImportSpecProductImages : UserControl, IComponentConnector
    {
        private bool _hideRequest = false;

        public int _photoId;

        private List<PhotoInfo> _result;

        private UIElement _parent;

        

        public List<string> PreviousImage
        {
            get;
            set;
        }

        public ImportSpecProductImages()
        {
            this.InitializeComponent();
            string arg = string.Empty;
            try
            {
                this.InitializeComponent();
                this.lstSelectedImage.Items.Clear();
                foreach (LstMyItems current in RobotImageLoader.PrintImages)
                {
                    arg = arg + current.PhotoId + ",";
                    this.lstSelectedImage.Items.Add(current);
                }
            }
            catch (Exception var_2_98)
            {
            }
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        public List<PhotoInfo> ShowSpecImagesDialog(string message)
        {
            if (!false)
            {
                base.Visibility = Visibility.Visible;
                goto IL_12;
            }
            List<PhotoInfo> result;
            while (true)
            {
            IL_C3:
                bool arg_CC_0 = !this._hideRequest;
                int arg_7E_0;
                while (true)
                {
                    bool flag = arg_CC_0;
                    if (2 == 0)
                    {
                        return result;
                    }
                    if (!flag)
                    {
                        goto IL_D6;
                    }
                    if (!base.Dispatcher.HasShutdownStarted)
                    {
                        if (false)
                        {
                            goto IL_89;
                        }
                        arg_CC_0 = ((arg_7E_0 = ((!base.Dispatcher.HasShutdownFinished) ? 1 : 0)) != 0);
                    }
                    else
                    {
                        arg_CC_0 = ((arg_7E_0 = 0) != 0);
                    }
                    if (2 != 0)
                    {
                        goto Block_4;
                    }
                }
            IL_8E:
                base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                }));
                Thread.Sleep(20);
                continue;
            Block_4:
                if (arg_7E_0 != 0)
                {
                    goto IL_8E;
                }
                if (false)
                {
                    goto IL_12;
                }
            IL_89:
                if (!false)
                {
                    break;
                }
                goto IL_8E;
            }
        IL_D6:
            result = this._result;
            return result;
        IL_12:
            base.Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(delegate
            {
                this.txtRFID.Focus();
                Keyboard.Focus(this.txtRFID);
            }));
            UIElement expr_39 = this._parent;
            bool expr_3E = true;
            if (!false)
            {
                expr_39.IsEnabled = expr_3E;
            }
            this._hideRequest = false;
           // goto IL_C3;
            return  this._result;
        }

        private void HideHandlerDialog()
        {
            this._hideRequest = true;
            while (true)
            {
            IL_09:
                base.Visibility = Visibility.Collapsed;
                while (!false)
                {
                    this._parent.IsEnabled = true;
                    if (!false)
                    {
                        if (true && !false)
                        {
                            goto Block_4;
                        }
                        goto IL_09;
                    }
                }
                return;
            }
        Block_4:
            this.KeyBorder1.Visibility = Visibility.Collapsed;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string arg_115_0 = string.Empty;
            this.lstSelectedImage.Items.Clear();
            List<PhotoInfo> photosBasedonRFID = new PhotoBusiness().GetPhotosBasedonRFID(LoginUser.SubStoreId, this.txtRFID.Text.ToString());
            int arg_51_0;
            int expr_45 = arg_51_0 = photosBasedonRFID.Count;
            int arg_51_1;
            int expr_4B = arg_51_1 = 1;
            if (expr_4B != 0)
            {
                arg_51_0 = ((expr_45 > expr_4B) ? 1 : 0);
                arg_51_1 = 0;
            }
            if (arg_51_0 != arg_51_1)
            {
                if (!false)
                {
                    using (List<PhotoInfo>.Enumerator enumerator = photosBasedonRFID.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            PhotoInfo current;
                            if (!false)
                            {
                                current = enumerator.Current;
                                current.DG_Photos_FileName = Path.Combine(LoginUser.DigiFolderThumbnailPath, current.DG_Photos_CreatedOn.ToString("yyyyMMdd"), current.DG_Photos_FileName);
                            }
                            this.lstSelectedImage.Items.Add(current);
                        }
                    }
                    this.SetInitial();
                }
            }
            else if (photosBasedonRFID.Count == 1)
            {
                this._result = new List<PhotoInfo>();
                if (true)
                {
                    this._result.Add(photosBasedonRFID[0]);
                    this.HideHandlerDialog();
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this._result = null;
            this.HideHandlerDialog();
        }

        private void txtRFID_GotFocus(object sender, RoutedEventArgs e)
        {
            this.KeyBorder1.Visibility = Visibility.Visible;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (8 == 0)
            {
                goto IL_66;
            }
        IL_04:
            this._result = new List<PhotoInfo>();
            int num = 0;
            goto IL_B6;
        IL_28:
            DependencyObject dependencyObject = this.lstSelectedImage.ItemContainerGenerator.ContainerFromIndex(num);
            if (!true)
            {
                goto IL_04;
            }
            if (dependencyObject == null)
            {
                goto IL_AB;
            }
            CheckBox checkBox = ImportSpecProductImages.FindVisualChild<CheckBox>(dependencyObject);
            if (checkBox == null)
            {
                goto IL_AA;
            }
        IL_66:
            bool arg_77_0 = Convert.ToBoolean(checkBox.IsChecked);
            bool expr_77;
            do
            {
                expr_77 = (arg_77_0 = !arg_77_0);
            }
            while (false);
            bool flag = expr_77;
            int arg_C7_0;
            bool expr_7E = (arg_C7_0 = (flag ? 1 : 0)) != 0;
            if (false)
            {
                goto IL_B7;
            }
            if (expr_7E)
            {
                goto IL_A9;
            }
        IL_85:
            this._result.Add((PhotoInfo)this.lstSelectedImage.Items[num]);
        IL_A9:
        IL_AA:
        IL_AB:
            if (7 == 0)
            {
                goto IL_28;
            }
            num++;
        IL_B6:
            arg_C7_0 = num;
        IL_B7:
            if (arg_C7_0 >= this.lstSelectedImage.Items.Count)
            {
                this.HideHandlerDialog();
                return;
            }
            if (8 != 0)
            {
                goto IL_28;
            }
            goto IL_85;
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
                            childItem childItem1 = ImportSpecProductImages.FindVisualChild<childItem>(dependencyObject);
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
                            childItem childItem1 = ImportSpecProductImages.FindVisualChild<childItem>(dependencyObject); ;
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
                    CheckBox checkBox = ImportSpecProductImages.FindVisualChild<CheckBox>(dependencyObject);
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
            CheckBox chk = ImportSpecProductImages.FindVisualChild<CheckBox>(dependencyObject);
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
                this.txtRFID.Text = this.txtRFID.Text + " ";
                if (-1 != 0)
                {
                    goto IL_142;
                }
            IL_B5:
                this.KeyBorder1.Visibility = Visibility.Collapsed;
                goto IL_142;
            IL_C6:
                bool arg_DA_0 = this.txtRFID.Text.Length > 0;
                bool expr_DA;
                do
                {
                    expr_DA = (arg_DA_0 = !arg_DA_0);
                }
                while (false);
                if (!expr_DA)
                {
                    this.txtRFID.Text = this.txtRFID.Text.Remove(this.txtRFID.Text.Length - 1, 1);
                }
                goto IL_142;
            IL_116:
                this.txtRFID.Text = this.txtRFID.Text + button.Content;
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

    }
}
