using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using PhotoSW.Views;

namespace PhotoSW.PSControls
{
    public partial class VideoPlayer : UserControl, IComponentConnector
    {
        private UIElement _parent;

        private DispatcherTimer timer = new DispatcherTimer();

        private FileStream memoryFileStream;

        private bool isMuted = false;

        private MLMediaPlayer mplayer;

        private ClientView clientWin = null;

        private EventHandler executeParentMethod;
        public event EventHandler ExecuteParentMethod
        {
            add
            {
                do
                {
                IL_00:
                    EventHandler eventHandler = executeParentMethod;
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
                            eventHandler = Interlocked.CompareExchange<EventHandler>(ref executeParentMethod, value2, eventHandler2);
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
                    EventHandler eventHandler = executeParentMethod;
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
                            eventHandler = Interlocked.CompareExchange<EventHandler>(ref executeParentMethod, value2, eventHandler2);
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

        public static string vsMediaFileName
        {
            get;
            set;
        }

        public BitmapImage imagesource
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
            if (!true)
            {
                goto IL_5F;
            }
            this.imgname.Text = this.Title;
            do
            {
                this._parent = parent;
            }
            while (!true);
            bool expr_E8 = string.IsNullOrEmpty(VideoPlayer.vsMediaFileName);
            bool flag;
            if (7 != 0)
            {
                flag = expr_E8;
            }
        IL_41:
            if (flag)
            {
                this.imgmain.Visibility = Visibility.Visible;
                this.vidoriginal.Visibility = Visibility.Collapsed;
                this.imgmain.Source = this.imagesource;
                this.ShowToClientView();
                if (4 != 0)
                {
                    goto IL_AB;
                }
            }
        IL_44:
            this.imgmain.Visibility = Visibility.Collapsed;
            this.vidoriginal.Visibility = Visibility.Visible;
        IL_5F:
            this.MediaStop();
            this.MediaPlay();
        IL_6C:
            if (-1 == 0)
            {
                goto IL_41;
            }
        IL_AB:
            if (8 == 0)
            {
                goto IL_6C;
            }
            if (4 != 0)
            {
                return;
            }
            goto IL_44;
        }

        private void _mediaPlay()
        {
            this.mplayer = new MLMediaPlayer(VideoPlayer.vsMediaFileName, "Search", true);
        }

        public void ShowToClientView()
        {
            if (!false)
            {
                try
                {
                    do
                    {
                        VisualBrush compiledBitmapImage = new VisualBrush(this.IMGFrame);
                        SearchResult searchResult = new SearchResult();
                        searchResult.CompileEffectChanged(compiledBitmapImage, -1);
                    }
                    while (7 == 0);
                }
                catch (Exception serviceException)
                {
                    do
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        if (!false)
                        {
                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                        }
                        if (2 != 0)
                        {
                        }
                    }
                    while (3 == 0);
                }
            }
        }

        public VideoPlayer()
        {
            this.InitializeComponent();
            this.mplayer = new MLMediaPlayer(VideoPlayer.vsMediaFileName, "VideoPlayer");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!false)
                {
                    this.MediaStop();
                    this.imagesource = null;
                    if (8 != 0)
                    {
                        VideoPlayer.vsMediaFileName = string.Empty;
                    }
                }
            }
            catch (Exception serviceException)
            {
                if (-1 != 0)
                {
                    if (!false)
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                }
            }
            while (false)
            {
            }
            this.HideHandlerDialog();
        }

        private void HideHandlerDialog()
        {
            if (4 != 0)
            {
                base.Visibility = Visibility.Collapsed;
                this._parent.IsEnabled = true;
                this.OnExecuteMethod();
            }
        }

        public virtual void OnExecuteMethod()
        {
            while (true)
            {
                bool arg_17_0;
                bool arg_2F_0 = arg_17_0 = (executeParentMethod == null);
                do
                {
                    if (2 != 0)
                    {
                        bool flag;
                        if (7 != 0)
                        {
                            flag = arg_2F_0;
                        }
                        arg_2F_0 = (arg_17_0 = flag);
                    }
                }
                while (false);
                if (arg_17_0)
                {
                    goto IL_28;
                }
            IL_19:
                if (false)
                {
                    continue;
                }
                executeParentMethod(null, null);
            IL_28:
                if (8 != 0)
                {
                    break;
                }
                goto IL_19;
            }
        }

        private void MediaStop()
        {
            bool flag = this.mplayer == null;
            bool arg_76_0;
            bool expr_11B = arg_76_0 = flag;
            if (false)
            {
                goto IL_75;
            }
            if (expr_11B)
            {
                goto IL_3A;
            }
        IL_1E:
            this.mplayer.MediaStop();
            this.mplayer = null;
        IL_3A:
            this.gdMediaPlayer.Children.Clear();
            if (8 == 0)
            {
                goto IL_F4;
            }
            this.gdMediaPlayer.Children.Remove(this.mplayer);
            arg_76_0 = (this.clientWin == null);
        IL_75:
            flag = !arg_76_0;
            if (!flag)
            {
                if (false)
                {
                    goto IL_1E;
                }
                IEnumerator enumerator = Application.Current.Windows.GetEnumerator();
                try
                {
                    if (6 == 0)
                    {
                        goto IL_D4;
                    }
                IL_CD:
                    flag = enumerator.MoveNext();
                IL_D4:
                    if (flag)
                    {
                        Window window = (Window)enumerator.Current;
                        if (!(window.Title == "ClientView"))
                        {
                            goto IL_CD;
                        }
                        this.clientWin = (ClientView)window;
                        if (!false)
                        {
                        }
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    flag = (disposable == null);
                    do
                    {
                        if (!flag)
                        {
                            disposable.Dispose();
                        }
                    }
                    while (false);
                }
            }
        IL_F4:
            if (this.clientWin != null)
            {
               // this.clientWin.StopMediaPlay();
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
                            goto IL_30;
                        }
                        if (5 == 0)
                        {
                            goto IL_34;
                        }
                        this.mplayer = new MLMediaPlayer(VideoPlayer.vsMediaFileName, "Search", true);
                        this.gdMediaPlayer.BeginInit();
                    }
                    this.gdMediaPlayer.Children.Clear();
                IL_30:
                    if (7 == 0)
                    {
                        goto IL_4F;
                    }
                IL_34:
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
            //goto IL_23;
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


    }
}
