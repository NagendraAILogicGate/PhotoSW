using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using PhotoSW.ViewModels;

namespace PhotoSW.PSControls
{
    public partial class ViewFrameControl : UserControl, IComponentConnector
    {
        private UIElement _parent;

        private bool _result = false;

        public List<fileClass> captureFrameList = new List<fileClass>();

        private EventHandler executeMethod;
        public event EventHandler ExecuteMethod
        {
            add
            {
                do
                {
                IL_00:
                    EventHandler eventHandler = this.executeMethod;
                    while (true)
                    {
                    IL_09:
                        EventHandler eventHandler2 = eventHandler;
                        while (true)
                        {
                            EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.executeMethod, value2, eventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (eventHandler == eventHandler2);
                                if (!false)
                                {
                                    arg_39_0 = !expr_31;
                                }
                                if (arg_39_0)
                                {
                                    goto IL_09;
                                }
                                if (!false)
                                {
                                    goto Block_4;
                                }
                            }
                        }
                    }
                Block_4: ;
                }
                while (!true);
            }
            remove
            {
                do
                {
                IL_00:
                    EventHandler eventHandler = this.executeMethod;
                    while (true)
                    {
                    IL_09:
                        EventHandler eventHandler2 = eventHandler;
                        while (true)
                        {
                            EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.executeMethod, value2, eventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (eventHandler == eventHandler2);
                                if (!false)
                                {
                                    arg_39_0 = !expr_31;
                                }
                                if (arg_39_0)
                                {
                                    goto IL_09;
                                }
                                if (!false)
                                {
                                    goto Block_4;
                                }
                            }
                        }
                    }
                Block_4: ;
                }
                while (!true);
            }
        }

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        public ViewFrameControl()
        {
            this.InitializeComponent();
            base.Visibility = Visibility.Hidden;
            this.captureFrameList.Clear();
            this.lstFrames.ItemsSource = null;
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.HideHandlerDialog();
            this.OnExecuteMethod();
        }

        private void HideHandlerDialog()
        {
            if (7 == 0)
            {
                goto IL_2F;
            }
            this.captureFrameList.Clear();
            this.lstFrames.ItemsSource = "";
            this.lstFrames.Items.Refresh();
            if (!false)
            {
                if (true)
                {
                    goto IL_2F;
                }
                goto IL_52;
            }
            while (true)
            {
            IL_3A:
                base.Visibility = Visibility.Collapsed;
                this._parent.IsEnabled = true;
                if (3 != 0)
                {
                    goto IL_52;
                }
            }
        IL_2F:
            this.imgFrame.Source = null;
            //goto IL_3A;
        IL_52:
            if (!false)
            {
                return;
            }
           // goto IL_3A;
        }

        public void ControlListAutoFill()
        {
            string expr_169 = Environment.CurrentDirectory;
            string str;
            if (!false)
            {
                str = expr_169;
            }
            string text = str + "\\";
            text = Path.Combine(text, "CapturedFrames\\");
            this.captureFrameList.Clear();
            int num = 1;
            bool flag = !Directory.Exists(text);
            bool arg_124_0;
            bool expr_52 = arg_124_0 = flag;
            if (false)
            {
                goto IL_124;
            }
            if (expr_52)
            {
                goto IL_12A;
            }
        IL_60:
            DirectoryInfo directoryInfo = new DirectoryInfo(text);
            FileInfo[] files = directoryInfo.GetFiles();
            FileInfo[] array = files;
            int num2;
            while (7 != 0)
            {
                num2 = 0;
                if (3 != 0)
                {
                    goto IL_118;
                }
            }
        IL_D8:
            BitmapImage bitmapImage;
            FileInfo fileInfo;
            bitmapImage.UriSource = new Uri(fileInfo.FullName);
            bitmapImage.EndInit();
        IL_F4:
            fileClass fileClass;
            fileClass.imgThumbnail = bitmapImage;
            this.captureFrameList.Add(fileClass);
            num++;
            num2++;
        IL_118:
            flag = (num2 < array.Length);
            arg_124_0 = flag;
        IL_124:
            if (arg_124_0)
            {
                fileInfo = array[num2];
                fileClass = new fileClass();
                fileClass.ID = num;
                fileClass.filePath = fileInfo.FullName;
                fileClass.fileName = fileInfo.Name;
                if (-1 == 0)
                {
                    goto IL_165;
                }
                bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                if (!false)
                {
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    goto IL_D8;
                }
                goto IL_60;
            }
        IL_12A:
            this.lstFrames.ItemsSource = null;
            this.lstFrames.ItemsSource = this.captureFrameList;
            this.lstFrames.UpdateLayout();
            if (!false)
            {
                this.lstFrames.SelectedIndex = 0;
            }
        IL_165:
            if (!false)
            {
                return;
            }
            goto IL_F4;
        }

        public bool ShowHandlerDialog()
        {
            base.Visibility = Visibility.Visible;
            while (!false)
            {
                this._parent.IsEnabled = false;
                this.ControlListAutoFill();
                if (!false)
                {
                    break;
                }
            }
            bool expr_55;
            while (true)
            {
                bool arg_52_0 = this._result;
                while (true)
                {
                    bool flag = arg_52_0;
                    if (!true)
                    {
                        break;
                    }
                    expr_55 = (arg_52_0 = flag);
                    if (!false)
                    {
                        return expr_55;
                    }
                }
            }
            return expr_55;
        }

        protected virtual void OnExecuteMethod()
        {
            while (true)
            {
                bool arg_17_0;
                bool arg_34_0 = arg_17_0 = (this.executeMethod == null);
                do
                {
                    if (2 != 0)
                    {
                        bool flag;
                        if (7 != 0)
                        {
                            flag = arg_34_0;
                        }
                        arg_34_0 = (arg_17_0 = flag);
                    }
                }
                while (false);
                if (arg_17_0)
                {
                    goto IL_2D;
                }
            IL_19:
                if (false)
                {
                    continue;
                }
                this.executeMethod(this, EventArgs.Empty);
            IL_2D:
                if (8 != 0)
                {
                    break;
                }
                goto IL_19;
            }
        }

        private void txtnumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text;
            do
            {
                text = string.Empty;
            }
            while (false);
            if (!string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                int num = 0;
                if (true)
                {
                    bool flag = int.TryParse(((TextBox)sender).Text, out num);
                    bool arg_6F_0 = flag;
                    int arg_64_0 = num;
                    bool arg_6F_1;
                    bool expr_64;
                    do
                    {
                        expr_64 = ((arg_64_0 = ((arg_6F_1 = (arg_64_0 < 0)) ? 1 : 0)) != 0);
                        if (false)
                        {
                            goto IL_6F;
                        }
                    }
                    while (false);
                    arg_6F_1 = !expr_64;
                IL_6F:
                    if (!(arg_6F_0 & arg_6F_1))
                    {
                        goto IL_99;
                    }
                }
                ((TextBox)sender).Text.Trim();
                text = ((TextBox)sender).Text;
                goto IL_C6;
            IL_99:
                ((TextBox)sender).Text = text;
                if (3 == 0)
                {
                    return;
                }
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
            IL_C6:
                if (false)
                {
                    goto IL_99;
                }
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        private void lstFrames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (!false)
                {
                    fileClass fileClass = (fileClass)e.AddedItems[0];
                    while (8 != 0)
                    {
                        this.imgFrame.Source = new BitmapImage(new Uri(fileClass.filePath));
                        if (-1 == 0 || !false)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception var_1_63)
            {
                do
                {
                    this.imgFrame.Source = null;
                }
                while (false);
            }
        }

    }
}
