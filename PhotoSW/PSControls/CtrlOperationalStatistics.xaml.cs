using PhotoSW.IMIX.Business;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;

namespace PhotoSW.PSControls
{
    public partial class CtrlOperationalStatistics : UserControl, IComponentConnector
    {
        private UIElement _parent;

        private bool _hideRequest = false;

        private string _result;

        private TextBox controlon;

        public static readonly DependencyProperty MessageOperationalStatFormProperty = DependencyProperty.Register("MessageOperationalStatForm", typeof(string), typeof(ModalDialog), new UIPropertyMetadata(string.Empty));

       
       // private bool _contentLoaded;

        public DateTime FromDate
        {
            get;
            set;
        }

        public DateTime BusinessDate
        {
            get;
            set;
        }

        public DateTime ToDate
        {
            get;
            set;
        }

        public int SubStoreID
        {
            get;
            set;
        }

        public int Back
        {
            get;
            set;
        }

        public string MessagOperationalStatForm
        {
            get
            {
                return (string)base.GetValue(CtrlOperationalStatistics.MessageOperationalStatFormProperty);
            }
            set
            {
                base.SetValue(CtrlOperationalStatistics.MessageOperationalStatFormProperty, value);
            }
        }

        public CtrlOperationalStatistics()
        {
            this.InitializeComponent();
            base.Visibility = Visibility.Hidden;
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        public string ShowHandlerDialog(string message)
        {
            this.Back = 0;
            this.MessagOperationalStatForm = message;
            Visibility expr_22 = Visibility.Visible;
            if (!false)
            {
                base.Visibility = expr_22;
            }
            this.SetNoOfCapture(this.FromDate, this.ToDate, this.SubStoreID);
            this.SetNoOfPreview(this.FromDate, this.ToDate, this.SubStoreID);
            this.SetNoOfImageSold(this.FromDate, this.ToDate, this.SubStoreID);
            this.txtAttendance.Focus();
            string result;
            while (true)
            {
                this.txtHeader.Text = "Closing Form for " + ((this.FromDate != DateTime.MinValue) ? string.Format("{0:dd-MMM-yyyy}", this.FromDate) : string.Format("{0:dd-MMM-yyyy}", DateTime.Now));
                this.txtSubHeader.Text = "Operational Statistics";
                this._hideRequest = false;
                while (true)
                {
                    if (!this._hideRequest)
                    {
                        bool flag = !base.Dispatcher.HasShutdownStarted && !base.Dispatcher.HasShutdownFinished;
                        bool expr_11A = flag;
                        if (false)
                        {
                            break;
                        }
                        if (expr_11A)
                        {
                            base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                            {
                            }));
                            Thread.Sleep(20);
                            continue;
                        }
                    }
                    result = this._result;
                    if (7 != 0)
                    {
                        return result;
                    }
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

        private void PastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            bool arg_5A_0;
            bool expr_8B = arg_5A_0 = e.DataObject.GetDataPresent(typeof(string));
            if (5 != 0)
            {
                bool flag = !expr_8B;
                bool arg_27_0 = flag;
                while (!arg_27_0)
                {
                    string text;
                    do
                    {
                        text = (string)e.DataObject.GetData(typeof(string));
                    }
                    while (false);
                    bool expr_4D = arg_27_0 = CtrlOperationalStatistics.IsTextAllowed(text);
                    if (!false)
                    {
                        flag = expr_4D;
                    IL_56:
                        if (!false)
                        {
                            arg_5A_0 = flag;
                            goto IL_5A;
                        }
                        return;
                    }
                }
                e.CancelCommand();
                if (5 != 0)
                {
                    return;
                }
               // goto IL_56;
            }
        IL_5A:
            if (!arg_5A_0)
            {
                e.CancelCommand();
            }
        }

        private static bool IsTextAllowed(string text)
        {
            bool arg_29_0;
            bool flag;
            while (true)
            {
                while (!false)
                {
                    Regex expr_2A = new Regex("[^0-9]+");
                    Regex regex;
                    if (4 != 0)
                    {
                        regex = expr_2A;
                    }
                    while (true)
                    {
                        bool expr_16 = arg_29_0 = !regex.IsMatch(text);
                        if (-1 == 0)
                        {
                            return arg_29_0;
                        }
                        if (5 != 0)
                        {
                            flag = expr_16;
                        }
                        if (false)
                        {
                            break;
                        }
                        if (2 != 0)
                        {
                            goto Block_3;
                        }
                    }
                }
            }
        Block_3:
            arg_29_0 = flag;
            return arg_29_0;
        }

        private void txtAmountEntered_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CtrlOperationalStatistics.IsTextAllowed(e.Text);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            this._result = string.Empty;
            if (this.txtAttendance.Text == string.Empty)
            {
                MessageBox.Show("Please enter attendance", "Spectra Photo");
                this.txtAttendance.Focus();
                this.txtAttendance.BorderBrush = Brushes.Red;
            }
            else if (this.txtLabourHour.Text == string.Empty)
            {
                MessageBox.Show("Please enter labour hour", "Spectra Photo");
                this.txtLabourHour.Focus();
                this.txtLabourHour.BorderBrush = Brushes.Red;
            }
            else if (this.txtNoOfCapture.Text == string.Empty)
            {
                this.txtNoOfCapture.Focus();
            }
            else if (this.txtNoOfPreviews.Text == string.Empty)
            {
                this.txtNoOfPreviews.Focus();
            }
            else if (this.txtNoOfImageSold.Text == string.Empty)
            {
                this.txtNoOfImageSold.Focus();
            }
            else if (this.txtComment.Text == string.Empty)
            {
                MessageBox.Show("Please enter comment", "Spectra Photo");
                this.txtComment.Focus();
                this.txtComment.BorderBrush = Brushes.Red;
            }
            else if (8 != 0)
            {
                this._result = string.Concat(new string[]
				{
					this.txtAttendance.Text.ToString(),
					"%##%",
					this.txtLabourHour.Text,
					"%##%",
					this.txtNoOfCapture.Text,
					"%##%",
					this.txtNoOfPreviews.Text,
					"%##%",
					this.txtNoOfImageSold.Text,
					"%##%",
					this.txtComment.Text
				});
                this.HideHandlerDialog();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this._result = string.Empty;
            this.HideHandlerDialog();
        }

        public void SetNoOfCapture(DateTime FromDate, DateTime ToDate, int SubStoreID)
        {
            if (4 != 0)
            {
                int captureBySubStoreAndDateRange = new PhotoSW.IMIX.Business.SageBusiness().GetCaptureBySubStoreAndDateRange(FromDate, ToDate, SubStoreID);
                if (!false)
                {
                    this.txtNoOfCapture.Text = captureBySubStoreAndDateRange.ToString();
                }
            }
        }

        public void SetNoOfPreview(DateTime FromDate, DateTime ToDate, int SubStoreID)
        {
            if (4 != 0)
            {
                int previewBySubStoreAndDateRange = new SageBusiness().GetPreviewBySubStoreAndDateRange(FromDate, ToDate, SubStoreID);
                if (!false)
                {
                    this.txtNoOfPreviews.Text = previewBySubStoreAndDateRange.ToString();
                }
            }
        }

        public void SetNoOfImageSold(DateTime FromDate, DateTime ToDate, int SubStoreID)
        {
            if (4 != 0)
            {
                long totalSoldBySubStoreAndDateRange = new SageBusiness().GetTotalSoldBySubStoreAndDateRange(FromDate, ToDate, SubStoreID);
                if (!false)
                {
                    this.txtNoOfImageSold.Text = totalSoldBySubStoreAndDateRange.ToString();
                }
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string text = button.Content.ToString();
            if (text == null)
            {
                goto IL_11B;
            }
            if (text == "ENTER")
            {
                this.KeyBorder.Visibility = Visibility.Hidden;
                return;
            }
            if (text == "SPACE")
            {
                this.controlon.Text = this.controlon.Text + " ";
                return;
            }
            if (text == "CLOSE")
            {
                this.KeyBorder.Visibility = Visibility.Hidden;
                return;
            }
            int arg_DA_0;
            int arg_DA_1;
            if (!(text == "Back"))
            {
                if (7 != 0)
                {
                    goto IL_11B;
                }
                goto IL_263;
            }
            else
            {
                TextBox textBox = this.controlon;
                arg_DA_0 = this.controlon.Text.Length;
                arg_DA_1 = 0;
            }
        IL_DA:
            if (arg_DA_0 > arg_DA_1)
            {
                this.controlon.Text = this.controlon.Text.Remove(this.controlon.Text.Length - 1, 1);
            }
            return;
        IL_11B:
            string[] array = new string[]
			{
				"0",
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9",
				"."
			};
            bool flag;
            bool arg_2C4_0;
            if (!(this.controlon.Name != "txtComment"))
            {
                int expr_2B1 = arg_DA_0 = this.controlon.Text.Count<char>();
                int expr_2B8 = arg_DA_1 = 59;
                if (expr_2B8 != 0)
                {
                    flag = (expr_2B1 > expr_2B8);
                    arg_2C4_0 = flag;
                    goto IL_2C4;
                }
                goto IL_DA;
            }
        IL_1AF:
            flag = (this.controlon.Text.Count<char>() >= 15);
            int arg_1CA_0 = flag ? 1 : 0;
            while (arg_1CA_0 == 0)
            {
                int num = Array.IndexOf<object>(array, button.Content);
                if (num <= -1)
                {
                    break;
                }
                string[] array2 = (this.controlon.Text + button.Content).Split(new char[]
				{
					'.'
				});
                bool arg_235_0;
                if (array2.Length == 2)
                {
                    int expr_226 = arg_1CA_0 = array2[1].Length;
                    if (false)
                    {
                        continue;
                    }
                    arg_235_0 = (expr_226 > 2);
                }
                else
                {
                    arg_235_0 = true;
                }
                flag = arg_235_0;
                bool expr_237 = arg_2C4_0 = flag;
                if (!true)
                {
                    goto IL_2C4;
                }
                if (!expr_237)
                {
                    this.controlon.Text = this.controlon.Text + button.Content;
                    goto IL_263;
                }
                if (array2.Length < 2)
                {
                    this.controlon.Text = this.controlon.Text + button.Content;
                    goto IL_29B;
                }
                goto IL_29B;
            }
            goto IL_2A3;
        IL_263:
        IL_29B:
            if (false)
            {
                goto IL_1AF;
            }
        IL_2A3:
            return;
        IL_2C4:
            if (!arg_2C4_0)
            {
                this.controlon.Text = this.controlon.Text + button.Content;
            }
        }

        private void txtAttendance_GotFocus(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                }
                while (8 != 0)
                {
                    this.controlon = (TextBox)sender;
                    if (false)
                    {
                        break;
                    }
                    this.KeyBorder.Visibility = Visibility.Visible;
                    if (8 != 0)
                    {
                        return;
                    }
                }
            }
        }

        private void txtLabourHour_GotFocus(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                }
                while (8 != 0)
                {
                    this.controlon = (TextBox)sender;
                    if (false)
                    {
                        break;
                    }
                    this.KeyBorder.Visibility = Visibility.Visible;
                    if (8 != 0)
                    {
                        return;
                    }
                }
            }
        }

        private void txtNoOfCapture_GotFocus(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                }
                while (8 != 0)
                {
                    this.controlon = (TextBox)sender;
                    if (false)
                    {
                        break;
                    }
                    this.KeyBorder.Visibility = Visibility.Visible;
                    if (8 != 0)
                    {
                        return;
                    }
                }
            }
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                    this.Back = 1;
                }
                while (true)
                {
                    this._result = string.Empty;
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

        private void txtAttendance_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (6 == 0)
            {
                goto IL_1E;
            }
            bool arg_33_0;
            bool expr_0A = arg_33_0 = (e.Key == Key.Space);
            if (5 != 0)
            {
                arg_33_0 = !expr_0A;
            }
            bool flag;
            if (!false)
            {
                flag = arg_33_0;
            }
        IL_16:
            if (flag)
            {
                return;
            }
            if (!true)
            {
                return;
            }
        IL_1E:
            e.Handled = true;
            if (8 == 0)
            {
                goto IL_16;
            }
        }

        private void txtComment_GotFocus(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                }
                while (8 != 0)
                {
                    this.controlon = (TextBox)sender;
                    if (false)
                    {
                        break;
                    }
                    this.KeyBorder.Visibility = Visibility.Visible;
                    if (8 != 0)
                    {
                        return;
                    }
                }
            }
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
        //            Uri resourceLocator = new Uri("/DigiPhoto;component/usercontrol/ctrloperationalstatistics.xaml", UriKind.Relative);
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
        //    switch (connectionId)
        //    {
        //        case 1:
        //            this.txtHeader = (TextBox)target;
        //            break;
        //        case 2:
        //            this.txtSubHeader = (TextBox)target;
        //            break;
        //        case 3:
        //            ((TextBlock)target).PreviewTextInput += new TextCompositionEventHandler(this.txtAmountEntered_PreviewTextInput);
        //            ((TextBlock)target).AddHandler(DataObject.PastingEvent, new DataObjectPastingEventHandler(this.PastingHandler));
        //            break;
        //        case 4:
        //            this.txtAttendance = (TextBox)target;
        //            this.txtAttendance.GotFocus += new RoutedEventHandler(this.txtAttendance_GotFocus);
        //            this.txtAttendance.PreviewTextInput += new TextCompositionEventHandler(this.txtAmountEntered_PreviewTextInput);
        //            break;
        //        case 5:
        //            this.txtLabourHour = (TextBox)target;
        //            this.txtLabourHour.GotFocus += new RoutedEventHandler(this.txtLabourHour_GotFocus);
        //            break;
        //        case 6:
        //            ((TextBlock)target).PreviewTextInput += new TextCompositionEventHandler(this.txtAmountEntered_PreviewTextInput);
        //            ((TextBlock)target).AddHandler(DataObject.PastingEvent, new DataObjectPastingEventHandler(this.PastingHandler));
        //            break;
        //        case 7:
        //            this.txtNoOfCapture = (TextBox)target;
        //            this.txtNoOfCapture.GotFocus += new RoutedEventHandler(this.txtNoOfCapture_GotFocus);
        //            this.txtNoOfCapture.PreviewTextInput += new TextCompositionEventHandler(this.txtAmountEntered_PreviewTextInput);
        //            break;
        //        case 8:
        //            ((TextBlock)target).PreviewTextInput += new TextCompositionEventHandler(this.txtAmountEntered_PreviewTextInput);
        //            ((TextBlock)target).AddHandler(DataObject.PastingEvent, new DataObjectPastingEventHandler(this.PastingHandler));
        //            break;
        //        case 9:
        //            this.txtNoOfPreviews = (TextBox)target;
        //            this.txtNoOfPreviews.PreviewTextInput += new TextCompositionEventHandler(this.txtAmountEntered_PreviewTextInput);
        //            break;
        //        case 10:
        //            ((TextBlock)target).PreviewTextInput += new TextCompositionEventHandler(this.txtAmountEntered_PreviewTextInput);
        //            ((TextBlock)target).AddHandler(DataObject.PastingEvent, new DataObjectPastingEventHandler(this.PastingHandler));
        //            break;
        //        case 11:
        //            this.txtNoOfImageSold = (TextBox)target;
        //            this.txtNoOfImageSold.PreviewTextInput += new TextCompositionEventHandler(this.txtAmountEntered_PreviewTextInput);
        //            break;
        //        case 12:
        //            ((TextBlock)target).PreviewTextInput += new TextCompositionEventHandler(this.txtAmountEntered_PreviewTextInput);
        //            ((TextBlock)target).AddHandler(DataObject.PastingEvent, new DataObjectPastingEventHandler(this.PastingHandler));
        //            break;
        //        case 13:
        //            this.txtComment = (TextBox)target;
        //            this.txtComment.GotFocus += new RoutedEventHandler(this.txtComment_GotFocus);
        //            break;
        //        case 14:
        //            this.SPSubmitCancel = (StackPanel)target;
        //            break;
        //        case 15:
        //            this.btnback = (Button)target;
        //            this.btnback.Click += new RoutedEventHandler(this.btnback_Click);
        //            break;
        //        case 16:
        //            this.btnSubmit = (Button)target;
        //            this.btnSubmit.Click += new RoutedEventHandler(this.btnSubmit_Click);
        //            break;
        //        case 17:
        //            this.KeyBorder = (Border)target;
        //            break;
        //        case 18:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 19:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 20:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 21:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 22:
        //            if (!false)
        //            {
        //                ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            }
        //            break;
        //        case 23:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 24:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 25:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 26:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 27:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 28:
        //            this.Delete = (Button)target;
        //            this.Delete.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 29:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 30:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 31:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 32:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 33:
        //            if (2 != 0)
        //            {
        //                ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            }
        //            break;
        //        case 34:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 35:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 36:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 37:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 38:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 39:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 40:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 41:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 42:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 43:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 44:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 45:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 46:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 47:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            if (!false)
        //            {
        //            }
        //            break;
        //        case 48:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 49:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 50:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 51:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 52:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 53:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 54:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 55:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 56:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 57:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 58:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 59:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 60:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 61:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 62:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 63:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 64:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 65:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            if (3 != 0)
        //            {
        //            }
        //            break;
        //        case 66:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 67:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 68:
        //            this.btnClose = (Button)target;
        //            this.btnClose.Click += new RoutedEventHandler(this.btnClose_Click);
        //            break;
        //        default:
        //            this._contentLoaded = true;
        //            break;
        //    }
        //}
    }
}
