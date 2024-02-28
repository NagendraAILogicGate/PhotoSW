using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media.Imaging;


namespace PhotoSW.Views
{
    public partial class SplashScreen : Window, IComponentConnector
    {
        
        public SplashScreen()
        {
            InitializeComponent();
            
              
            
        }
        private void local()
        {
            ClientView clientView = null;
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                if (window.Title == "ClientView")
                {
                    clientView = (ClientView)window;
                }
            }
            if (clientView != null)
            {
                clientView.WindowStartupLocation = WindowStartupLocation.Manual;
                clientView.DefaultView = true;
                clientView.ChildImage = new BitmapImage(new Uri("/images/all_frames_new.png", UriKind.Relative));
            }
            else
            {
                clientView = new ClientView();
                clientView.WindowStartupLocation = WindowStartupLocation.Manual;
                clientView.DefaultView = true;
                clientView.ChildImage = new BitmapImage(new Uri("/images/all_frames_new.png", UriKind.Relative));
            }
            Screen[] allScreens = Screen.AllScreens;
            if (allScreens.Length > 1)
            {
                if (allScreens[0].Primary)
                {
                    Screen screen = Screen.AllScreens[1];
                    Rectangle workingArea = screen.WorkingArea;
                    clientView.Top = (double)workingArea.Top;
                    clientView.Left = (double)workingArea.Left;
                    clientView.Show();
                }
                else
                {
                    Rectangle workingArea = allScreens[0].WorkingArea;
                    clientView.Top = (double)workingArea.Top;
                    clientView.Left = (double)workingArea.Left;
                    clientView.Show();
                }
            }
            else
            {
                clientView.Show();
            }
        }

    }
}
