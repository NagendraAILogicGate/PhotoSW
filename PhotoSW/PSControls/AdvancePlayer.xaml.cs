using PhotoSW.Manage;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace PhotoSW.PSControls
{
    public partial class AdvancePlayer : UserControl, IComponentConnector
    {
        private UIElement _parent;

        private MLMediaPlayer mplayer;

      

        public string vsMediaFileName
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
            bool arg_1A_0;
            bool expr_41 = arg_1A_0 = string.IsNullOrEmpty(this.vsMediaFileName);
            if (7 == 0 || false)
            {
                goto IL_1A;
            }
            bool flag = expr_41;
        IL_18:
            arg_1A_0 = flag;
        IL_1A:
            if (!arg_1A_0)
            {
                this.MediaStop();
                if (false)
                {
                    goto IL_18;
                }
                do
                {
                    this.MediaPlay();
                }
                while (false);
            }
        }

        public AdvancePlayer()
        {
            this.InitializeComponent();
           // this.mplayer = new MLMediaPlayer(this.vsMediaFileName, "AdvancePreview");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.MediaStop();
                while (!false)
                {
                    this.vsMediaFileName = string.Empty;
                    if (-1 != 0)
                    {
                        break;
                    }
                }
            }
            catch (Exception serviceException)
            {
                do
                {
                    if (!false)
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                }
                while (false);
            }
            do
            {
                this.HideHandlerDialog();
            }
            while (4 == 0);
        }

        private void HideHandlerDialog()
        {
            do
            {
                if (!false)
                {
                    Visibility expr_06 = Visibility.Collapsed;
                    if (7 != 0)
                    {
                        base.Visibility = expr_06;
                    }
                    while (5 == 0)
                    {
                    }
                    this._parent.IsEnabled = true;
                }
                if (true)
                {
                    ((MLLiveCapture)this._parent).SetVisibility(true);
                }
            }
            while (7 == 0);
        }

        private void MediaStop()
        {
            if (this.mplayer != null)
            {
                this.mplayer.MediaStop();
                this.mplayer = null;
            }
            this.gdMediaPlayer.Children.Clear();
            if (6 != 0)
            {
                this.gdMediaPlayer.Children.Remove(this.mplayer);
            }
        }

        private void MediaPlay()
        {
            while (!false)
            {
                if (5 != 0)
                {
                    this.MediaStop();
                    bool flag = this.mplayer == null;
                    if (false)
                    {
                        continue;
                    }
                    if (false || !flag)
                    {
                        break;
                    }
                }
                else
                {
                IL_23:
                    this.mplayer.Dispose();
                    if (false)
                    {
                        return;
                    }
                }
                this.gdMediaPlayer.Dispatcher.BeginInvoke(new Action(delegate
                {
                    if (7 != 0)
                    {
                        if (false)
                        {
                            goto IL_31;
                        }
                        if (5 == 0)
                        {
                            goto IL_35;
                        }
                        this.mplayer = new MLMediaPlayer(this.vsMediaFileName, "AdvancePreview");
                        this.gdMediaPlayer.BeginInit();
                    }
                    this.gdMediaPlayer.Children.Clear();
                IL_31:
                    if (7 == 0)
                    {
                        goto IL_4F;
                    }
                IL_35:
                    if (false)
                    {
                        return;
                    }
                    this.gdMediaPlayer.Children.Add(this.mplayer);
                IL_4F:
                    this.gdMediaPlayer.EndInit();
                }), new object[0]);
                return;
            }
            goto IL_23;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            if (!false)
            {
                goto IL_04;
            }
        IL_0D:
            while (3 == 0)
            {
            }
            this.btnClose.Click -= new RoutedEventHandler(this.btnClose_Click);
            goto IL_28;
        IL_04:
            if (6 != 0)
            {
                if (false)
                {
                    goto IL_0D;
                }
                this.MediaStop();
                goto IL_0D;
            }
        IL_28:
            if (!false)
            {
                return;
            }
            goto IL_04;
        }

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), DebuggerNonUserCode]
        //public void InitializeComponent()
        //{
        //    bool arg_09_0 = this._contentLoaded;
        //    bool expr_09;
        //    do
        //    {
        //        expr_09 = (arg_09_0 = !arg_09_0);
        //    }
        //    while (false);
        //    bool flag = expr_09;
        //    while (true)
        //    {
        //        if (!flag)
        //        {
        //            goto IL_14;
        //        }
        //    IL_1A:
        //        this._contentLoaded = true;
        //        while (6 != 0)
        //        {
        //            Uri resourceLocator = new Uri("/DigiPhoto;component/usercontrol/advanceplayer.xaml", UriKind.Relative);
        //            if (!false)
        //            {
        //                Application.LoadComponent(this, resourceLocator);
        //                if (-1 != 0)
        //                {
        //                    return;
        //                }
        //                goto IL_14;
        //            }
        //        }
        //        continue;
        //    IL_14:
        //        if (6 != 0)
        //        {
        //            break;
        //        }
        //        goto IL_1A;
        //    }
        //}

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        //void IComponentConnector.Connect(int connectionId, object target)
        //{
        //    while (true)
        //    {
        //        while (true)
        //        {
        //            switch (connectionId)
        //            {
        //                case 1:
        //                    goto IL_2C;
        //                case 2:
        //                    if (!false)
        //                    {
        //                        goto Block_1;
        //                    }
        //                    continue;
        //                case 3:
        //                    if (!false && 2 != 0)
        //                    {
        //                        goto Block_3;
        //                    }
        //                    continue;
        //                case 4:
        //                    goto IL_85;
        //            }
        //            goto Block_0;
        //        }
        //    Block_3:
        //        if (false)
        //        {
        //            goto IL_4B;
        //        }
        //        if (5 != 0)
        //        {
        //            goto Block_5;
        //        }
        //    }
        //Block_0:
        //    this._contentLoaded = true;
        //    return;
        //IL_2C:
        //    ((AdvancePlayer)target).Unloaded += new RoutedEventHandler(this.UserControl_Unloaded);
        //IL_4B:
        //    return;
        //Block_1:
        //    this.IMGFrame = (Grid)target;
        //    return;
        //Block_5:
        //    this.gdMediaPlayer = (Grid)target;
        //    return;
        //IL_85:
        //    this.btnClose = (Button)target;
        //    this.btnClose.Click += new RoutedEventHandler(this.btnClose_Click);
        //}
    }
}
