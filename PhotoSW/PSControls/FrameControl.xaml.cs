//using DigiPhoto.Interop;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using PhotoSW.Views;

namespace DigiPhoto
{
    public class FrameControl : UserControl, IComponentConnector
    {
        private UIElement _parent;

        private bool _result = false;

        private List<VideoFrames> lstVideoFrames = new List<VideoFrames>();

        private BusyWindow bs = new BusyWindow();

        public string LicenseKey = string.Empty;

        public string UserName = string.Empty;

        public string EmailID = string.Empty;

        private string videoPath = "";

        private long extractVideoEndTime = 0L;

        private string a;

        //internal TextBlock errorTxt;

        //internal ListBox lstFrames;

        //internal RangeSlider RangeSldGuestVideo;

        //internal Grid setTimeGrid;

        //internal TextBox txtvideoStart;

        //internal TextBox txtVideoEnd;

        //internal Button btnClose;

        //private bool _contentLoaded;
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

        public FrameControl()
        {
            this.InitializeComponent();
            base.Visibility = Visibility.Hidden;
        }

        public void frameControlListAutoFill(List<PanProperty> ppLstMain)
        {
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            bool arg_16_0 = this.RangeSldGuestVideo.LowerValue == this.RangeSldGuestVideo.UpperValue;
            bool expr_16;
            do
            {
                expr_16 = (arg_16_0 = !arg_16_0);
            }
            while (3 == 0);
            bool flag;
            if (!false)
            {
                flag = expr_16;
            }
            if (8 != 0)
            {
                if (false)
                {
                    goto IL_4F;
                }
                if (!flag)
                {
                    if (true)
                    {
                        MessageBox.Show("Video start time should be less than video end time!");
                        goto IL_50;
                    }
                    goto IL_50;
                }
                else
                {
                    this.HideHandlerDialog();
                }
            }
            this.setTimeGrid.Visibility = Visibility.Hidden;
        IL_48:
            this.OnExecuteMethod();
        IL_4F:
        IL_50:
            if (!false)
            {
                return;
            }
            goto IL_48;
        }

        private void HideHandlerDialog()
        {
            while (true)
            {
                if (8 != 0)
                {
                    base.Visibility = Visibility.Collapsed;
                    while (!false && !false)
                    {
                        this._parent.IsEnabled = true;
                        if (8 != 0)
                        {
                            return;
                        }
                    }
                }
            }
        }

        public bool ShowPanHandlerDialog(string _videoPath, long _extractVideoEndTime)
        {
            base.Visibility = Visibility.Visible;
            this.extractVideoEndTime = _extractVideoEndTime;
            this._parent.IsEnabled = false;
            this.videoPath = _videoPath;
         
            this.errorTxt.Visibility = Visibility.Collapsed;
            while (true)
            {
                this.lstFrames.Visibility = Visibility.Hidden;
                if (5 != 0)
                {
                    this.RangeSldGuestVideo.Visibility = Visibility.Hidden;
                    this.lstVideoFrames.Clear();
                }
            IL_76:
                if (8 != 0)
                {
                    this.RangeSldGuestVideo.Maximum = (double)this.extractVideoEndTime;
                    if (5 != 0)
                    {
                        break;
                    }
                    continue;
                }
                goto IL_76;
            }
            this.RangeSldGuestVideo.UpperValue = (double)this.extractVideoEndTime;
            this.RangeSldGuestVideo.LowerValue = 1.0;
            this.RangeSldGuestVideo.Minimum = 1.0;
            bool result;
            do
            {
                do
                {
                    this.bs.Show();
                    this.ExtractFrames(this.videoPath, this.extractVideoEndTime);
                }
                while (false);
                this.bs.Hide();
                result = this._result;
                while (false)
                {
                }
            }
            while (false);
            return result;
        }

        protected virtual void OnExecuteMethod()
        {
            while (true)
            {
                bool arg_17_0;
                bool arg_34_0 = arg_17_0 = (this.ExecuteMethod == null);
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
                this.ExecuteMethod(this, EventArgs.Empty);
            IL_2D:
                if (8 != 0)
                {
                    break;
                }
                goto IL_19;
            }
        }

        private void ExtractFrames(string fileName, long len)
        {
        }

        public static BitmapSource loadBitmap(Bitmap source)
        {
            BitmapSource result;
            do
            {
                if (5 != 0)
                {
                    if (-1 != 0)
                    {
                        if (false)
                        {
                            continue;
                        }
                        result = Imaging.CreateBitmapSourceFromHBitmap(source.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromWidthAndHeight(120, 130));
                    }
                }
            }
            while (false);
            return result;
        }

        private void txtnumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool expr_16 = !string.IsNullOrEmpty(((TextBox)sender).Text);
            bool flag;
            if (!false)
            {
                flag = expr_16;
            }
            if (!flag)
            {
                this.a = "";
            }
            else
            {
                int num = 0;
                bool flag2 = int.TryParse(((TextBox)sender).Text, out num);
                bool arg_65_0;
                bool expr_58 = arg_65_0 = flag2;
                if (!false)
                {
                    arg_65_0 = (expr_58 & num >= 0);
                }
                flag = !arg_65_0;
                if (!flag)
                {
                    ((TextBox)sender).Text.Trim();
                    this.a = ((TextBox)sender).Text;
                }
                else
                {
                    ((TextBox)sender).Text = this.a;
                    ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                }
            }
            string text = ((TextBox)sender).Text;
        }

        private bool IsNumeric(string text)
        {
            bool result;
            try
            {
                while (!false)
                {
                    if (!false)
                    {
                        int num;
                        result = int.TryParse(text, out num);
                        break;
                    }
                }
            }
            catch
            {
                if (!false)
                {
                }
                if (7 != 0)
                {
                    result = false;
                }
            }
            return result;
        }

        private void txtvideoStart_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool expr_16 = !string.IsNullOrEmpty(((TextBox)sender).Text);
            bool flag;
            if (!false)
            {
                flag = expr_16;
            }
            if (flag)
            {
                while (!false)
                {
                    int num = 0;
                    bool arg_5D_0 = int.TryParse(((TextBox)sender).Text, out num);
                    bool expr_69;
                    do
                    {
                        bool flag2 = arg_5D_0;
                        bool arg_69_0 = flag2;
                        int arg_67_0;
                        int expr_5F = arg_67_0 = num;
                        int arg_67_1;
                        int expr_61 = arg_67_1 = 0;
                        if (expr_61 == 0)
                        {
                            arg_67_0 = ((expr_5F < expr_61) ? 1 : 0);
                            arg_67_1 = 0;
                        }
                        expr_69 = (arg_5D_0 = (arg_69_0 & arg_67_0 == arg_67_1));
                    }
                    while (false);
                    flag = !expr_69;
                    if (flag)
                    {
                        if (6 == 0)
                        {
                            continue;
                        }
                        ((TextBox)sender).Text = this.a;
                        if (!false)
                        {
                            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                            goto IL_D2;
                        }
                    }
                    ((TextBox)sender).Text.Trim();
                    this.a = ((TextBox)sender).Text;
                IL_D2:
                    goto IL_D3;
                }
                return;
            }
            this.a = "";
        IL_D3:
            flag = !string.IsNullOrEmpty(((TextBox)sender).Text);
            if (!false && flag)
            {
                string text = ((TextBox)sender).Text;
                int start = Convert.ToInt32(text);
                this.updateList(start, Convert.ToInt32(this.RangeSldGuestVideo.UpperValue), true);
            }
        }

        private void txtVideoEnd_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool expr_16 = !string.IsNullOrEmpty(((TextBox)sender).Text);
            bool flag;
            if (!false)
            {
                flag = expr_16;
            }
            if (flag)
            {
                while (!false)
                {
                    int num = 0;
                    bool arg_5D_0 = int.TryParse(((TextBox)sender).Text, out num);
                    bool expr_69;
                    do
                    {
                        bool flag2 = arg_5D_0;
                        bool arg_69_0 = flag2;
                        int arg_67_0;
                        int expr_5F = arg_67_0 = num;
                        int arg_67_1;
                        int expr_61 = arg_67_1 = 0;
                        if (expr_61 == 0)
                        {
                            arg_67_0 = ((expr_5F < expr_61) ? 1 : 0);
                            arg_67_1 = 0;
                        }
                        expr_69 = (arg_5D_0 = (arg_69_0 & arg_67_0 == arg_67_1));
                    }
                    while (false);
                    flag = !expr_69;
                    if (flag)
                    {
                        if (6 == 0)
                        {
                            continue;
                        }
                        ((TextBox)sender).Text = this.a;
                        if (!false)
                        {
                            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                            goto IL_D2;
                        }
                    }
                    ((TextBox)sender).Text.Trim();
                    this.a = ((TextBox)sender).Text;
                IL_D2:
                    goto IL_D3;
                }
                return;
            }
            this.a = "";
        IL_D3:
            flag = !string.IsNullOrEmpty(((TextBox)sender).Text);
            if (!false && flag)
            {
                string text = ((TextBox)sender).Text;
                int end = Convert.ToInt32(text);
                this.updateList(Convert.ToInt32(this.RangeSldGuestVideo.LowerValue), end, false);
            }
        }

        private void updateList(int start, int end, bool isStart)
        {
            try
            {
                int num = 0;
                int num2 = 0;
                VideoFrames item;
                while (true)
                {
                    int arg_16D_0;
                    if (num2 >= this.lstVideoFrames.Count)
                    {
                        item = new VideoFrames();
                        arg_16D_0 = this.lstVideoFrames.Count;
                        goto IL_16C;
                    }
                    bool arg_1F3_0;
                    if (num2 == start - 1)
                    {
                        arg_1F3_0 = ((arg_16D_0 = ((!isStart) ? 1 : 0)) != 0);
                        if (false)
                        {
                            goto IL_16C;
                        }
                    }
                    else
                    {
                        arg_1F3_0 = true;
                    }
                    bool flag = arg_1F3_0;
                    if (6 == 0)
                    {
                        goto IL_186;
                    }
                    if (!flag)
                    {
                        if (true)
                        {
                            this.lstVideoFrames[end - 1].StrokeColor = "Green";
                            this.lstVideoFrames[end - 1].visibilityCanvas = Visibility.Visible;
                            goto IL_83;
                        }
                    }
                    else if (num2 == end - 1 && !isStart)
                    {
                        this.lstVideoFrames[start - 1].StrokeColor = "Red";
                    }
                    else if (4 != 0)
                    {
                        this.lstVideoFrames[num2].visibilityCanvas = Visibility.Hidden;
                        goto IL_13F;
                    }
                    this.lstVideoFrames[start - 1].visibilityCanvas = Visibility.Visible;
                    if (8 != 0)
                    {
                        this.lstVideoFrames[num2].StrokeColor = "Green";
                    }
                    this.lstVideoFrames[num2].visibilityCanvas = Visibility.Visible;
                    num = num2;
                IL_13F:
                    num2++;
                    continue;
                IL_83:
                    this.lstVideoFrames[num2].StrokeColor = "Red";
                    this.lstVideoFrames[num2].visibilityCanvas = Visibility.Visible;
                    num = num2;
                    goto IL_13F;
                IL_187:
                    if (2 != 0)
                    {
                        break;
                    }
                    goto IL_83;
                IL_186:
                    goto IL_187;
                IL_16C:
                    if (arg_16D_0 > 0)
                    {
                        item = this.lstVideoFrames[num];
                        goto IL_186;
                    }
                    goto IL_187;
                }
                this.lstFrames.ItemsSource = null;
                this.lstFrames.ItemsSource = this.lstVideoFrames;
                this.lstFrames.SelectedIndex = num;
                this.lstFrames.ScrollIntoView(item);
                this.lstFrames.UpdateLayout();
            }
            catch (Exception serviceException)
            {
                if (!false)
                {
                    string message = ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            do
            {
                bool arg_15_0;
                bool arg_29_0 = arg_15_0 = (this.lstVideoFrames == null);
                do
                {
                    if (!false)
                    {
                        bool flag = arg_29_0;
                        arg_29_0 = (arg_15_0 = flag);
                    }
                }
                while (false);
                if (!arg_15_0)
                {
                    if (8 == 0)
                    {
                        continue;
                    }
                    this.lstVideoFrames = null;
                }
            }
            while (false);
        }

     
    }
}
