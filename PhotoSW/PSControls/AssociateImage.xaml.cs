
using PhotoSW.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PhotoSW.IMIX.Business;
namespace PhotoSW.PSControls
    {
    /// <summary>
    /// Interaction logic for AssociateImage.xaml
    /// </summary>
    public partial class AssociateImage : UserControl, IComponentConnector, IDisposable
        {
        private UIElement _parent;

        private string _CardCode = string.Empty;

        private EventHandler executeParentMethod;

        public event EventHandler ExecuteParentMethod
            {
            add
                {
                do
                    {
                    IL_00:
                    EventHandler eventHandler = this.executeParentMethod;
                    while(true)
                        {
                        IL_09:
                        EventHandler eventHandler2 = eventHandler;
                        while(true)
                            {
                            EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
                            if(-1 == 0)
                                {
                                goto IL_00;
                                }
                            eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.executeParentMethod, value2, eventHandler2);
                            while(!false)
                                {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (eventHandler == eventHandler2);
                                if(!false)
                                    {
                                    arg_39_0 = !expr_31;
                                    }
                                if(arg_39_0)
                                    {
                                    goto IL_09;
                                    }
                                if(!false)
                                    {
                                    goto Block_4;
                                    }
                                }
                            }
                        }
                    Block_4: ;
                    }
                while(!true);
                }
            remove
                {
                do
                    {
                    IL_00:
                    EventHandler eventHandler = this.executeParentMethod;
                    while(true)
                        {
                        IL_09:
                        EventHandler eventHandler2 = eventHandler;
                        while(true)
                            {
                            EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
                            if(-1 == 0)
                                {
                                goto IL_00;
                                }
                            eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.executeParentMethod, value2, eventHandler2);
                            while(!false)
                                {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (eventHandler == eventHandler2);
                                if(!false)
                                    {
                                    arg_39_0 = !expr_31;
                                    }
                                if(arg_39_0)
                                    {
                                    goto IL_09;
                                    }
                                if(!false)
                                    {
                                    goto Block_4;
                                    }
                                }
                            }
                        }
                    Block_4: ;
                    }
                while(!true);
                }
            }

        public AssociateImage ()
            {
            try
                {
                this.InitializeComponent();
                this.BindCodeType();
                this.MsgBox.SetParent(this.OuterBorder);
                this.CtrlCodePopup.SetParent(this.OuterBorder);
                if(string.IsNullOrEmpty(App.QRCodeWebUrl.Trim()))
                    {
                    string qRCodeWebUrl = new LocationBusniess().GetQRCodeWebUrl();
                    App.QRCodeWebUrl = (string.IsNullOrEmpty(qRCodeWebUrl) ? " " : qRCodeWebUrl);
                    }
                this.cmbQRCodeType.SelectedValue = App.SelectedCodeType;
                this.CodeTypeSelectionChange();
                }
            catch(Exception serviceException)
                {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }

        protected virtual void OnExecuteMethod ()
            {
            while(true)
                {
                bool arg_17_0;
                bool arg_34_0 = arg_17_0 = (this.executeParentMethod == null);
                do
                    {
                    if(2 != 0)
                        {
                        bool flag;
                        if(7 != 0)
                            {
                            flag = arg_34_0;
                            }
                        arg_34_0 = (arg_17_0 = flag);
                        }
                    }
                while(false);
                if(arg_17_0)
                    {
                    goto IL_2D;
                    }
                IL_19:
                if(false)
                    {
                    continue;
                    }
                this.executeParentMethod(this, EventArgs.Empty);
                IL_2D:
                if(8 != 0)
                    {
                    break;
                    }
                goto IL_19;
                }
            }

        private void btnClose_Click ( object sender, RoutedEventArgs e )
            {
            try
                {
                Visibility expr_07 = Visibility.Collapsed;
                if(!false)
                    {
                    base.Visibility = expr_07;
                    }
                this._parent.IsEnabled = true;
               // this.KeyBorder1.Visibility = Visibility.Collapsed;
                while(true)
                    {
                    if(this.cmbQRCodeType.SelectedValue != null && string.Compare(this.cmbQRCodeType.SelectedValue.ToString(), "404", true) == 0)
                        {
                        if(8 != 0)
                            {
                            goto IL_75;
                            }
                        goto IL_75;
                        }
                    else
                        {
                        this.txtQRCode.Text = string.Empty;
                        this.txtQRCode.IsEnabled = true;
                        if(!false)
                            {
                            this.txtQRCode.Focus();
                            goto IL_C9;
                            }
                        goto IL_75;
                        }
                    IL_E6:
                    if(6 != 0)
                        {
                        break;
                        }
                    continue;
                    IL_75:
                    this.txtQRCode.Text = this._CardCode;
                    if(6 == 0)
                        {
                        goto IL_E6;
                        }
                    this.txtQRCode.IsEnabled = false;
                    IL_C9:
                    this.OnExecuteMethod();
                    ((Grid)base.Parent).Children.Remove(this);
                    goto IL_E6;
                    }
                this.Dispose();
                }
            catch(Exception serviceException)
                {
                do
                    {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                while(false);
                }
            finally
                {
                while(4 == 0)
                    {
                    }
                }
            }

        private void HideHandlerDialog ()
            {
            try
                {
                this.txtQRCode.Text = string.Empty;
                this.txtQRCode.IsEnabled = true;
                base.Visibility = Visibility.Collapsed;
                UIElement expr_24 = this._parent;
                bool expr_29 = true;
                if(true)
                    {
                    expr_24.IsEnabled = expr_29;
                    }
                this.OnExecuteMethod();
              //  this.KeyBorder1.Visibility = Visibility.Collapsed;
                }
            catch(Exception serviceException)
                {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }

        private void txtCode_GotFocus ( object sender, RoutedEventArgs e )
            {
            try
                {
                int num;
                if(!false)
                    {
                    num = 0;
                    }
                if(this.cmbQRCodeType.SelectedValue != null)
                    {
                    num = (int)this.cmbQRCodeType.SelectedValue;
                    }
                bool arg_4C_0;
                if(num != 0)
                    {
                    if(!true)
                        {
                        goto IL_6B;
                        }
                    arg_4C_0 = (num == 404);
                    }
                else
                    {
                    arg_4C_0 = true;
                    }
                if(!arg_4C_0)
                    {
                   // this.KeyBorder1.Visibility = Visibility.Visible;
                    }
                else
                    {
                   // this.KeyBorder1.Visibility = Visibility.Collapsed;
                    }
                IL_6B: ;
                }
            catch(Exception serviceException)
                {
                string message;
                if(-1 != 0)
                    {
                    message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    }
                if(!false)
                    {
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                }
            }

        private void BindCodeType ()
            {
            try
                {
                Dictionary<string, int> cardCodeTypes = new CardBusiness().GetCardCodeTypes();
                Dictionary<string, int> dictionary = new Dictionary<string, int>();
                dictionary.Add("--Select--", 0);
                foreach(KeyValuePair<string, int> current in cardCodeTypes)
                    {
                    dictionary.Add(current.Key, current.Value);
                    }
                this.cmbQRCodeType.ItemsSource = dictionary;
                do
                    {
                    this.cmbQRCodeType.SelectedValue = 405;
                    this._CardCode = new CardBusiness().GetCardCode(404);
                    }
                while(false);
                }
            catch(Exception serviceException)
                {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }

        private void btnAssociate_Click ( object sender, RoutedEventArgs e )
            {
            try
                {
                if(this.cmbQRCodeType.SelectedIndex <= 0)
                    {
                    MessageBox.Show("Please select card type.");
                    }
                else
                    {
                    int num = (int)this.cmbQRCodeType.SelectedValue;
                    RobotImageLoader.IsAnonymousQrCodeEnabled = (App.IsAnonymousQrCodeEnabled && num == 405);
                    string text = this.txtQRCode.Text.Trim();
                    int overWriteStatus = 0;
                    if(num > 0)
                        {
                        if(string.IsNullOrEmpty(this.txtQRCode.Text.Trim()))
                            {
                            MessageBox.Show("Enter " + this.cmbQRCodeType.Text + ((num != 405) ? " Code." : "."));
                            }
                        else
                            {
                            int arg_13D_0;
                            int expr_F8 = arg_13D_0 = this.txtQRCode.Text.Trim().Length;
                            if(4 == 0)
                                {
                                goto IL_13C;
                                }
                            bool arg_115_0;
                            if(expr_F8 < 5)
                                {
                                arg_115_0 = (num == 404);
                                }
                            else
                                {
                                if(-1 == 0)
                                    {
                                    goto IL_2CB;
                                    }
                                arg_115_0 = true;
                                }
                            bool flag = arg_115_0;
                            bool arg_119_0 = flag;
                            IL_119:
                            if(arg_119_0)
                                {
                                if(!false)
                                    {
                                    arg_13D_0 = RobotImageLoader.GroupImages.Count;
                                    goto IL_13C;
                                    }
                                goto IL_337;
                                }
                            IL_11C:
                            MessageBox.Show("Code length must be more than 4 digit.");
                            return;
                            IL_13C:
                            if(arg_13D_0 < 1)
                                {
                                MessageBox.Show("No Image is selected to associate.");
                                return;
                                }
                            string PhotoIds = string.Empty;
                            RobotImageLoader.GroupImages.ForEach(delegate( LstMyItems o )
                            {
                                PhotoIds = PhotoIds + "," + o.PhotoId;
                            });
                            if(PhotoIds.Length > 0)
                                {
                                PhotoIds = PhotoIds.Substring(1, PhotoIds.Length - 1);
                                }
                            if(false)
                                {
                                goto IL_328;
                                }
                           // this.KeyBorder1.Visibility = Visibility.Collapsed;
                            if(num == 403)
                                {
                                text = "0000" + text;
                                }
                            if(num == 406)
                                {
                                text = "2222" + text;
                                }
                            string message;
                            bool flag3;
                            if(!App.IsAnonymousQrCodeEnabled && !new CardBusiness().IsValidCodeType(text, num))
                                {
                                if(!false)
                                    {
                                    MessageBox.Show("Invalid code.");
                                    flag = (RobotImageLoader.CodeType == 404);
                                    if(!flag)
                                        {
                                        if(false)
                                            {
                                            goto IL_2D5;
                                            }
                                        this.txtQRCode.Text = string.Empty;
                                        }
                                    return;
                                    }
                                }
                            else if(num != 404 && new AssociateImageBusiness().IsUniqueCodeExists(text, RobotImageLoader.IsAnonymousQrCodeEnabled))
                                {
                                message = "This code already exists. Do you want to associate with the same code?";
                                bool flag2 = this.CtrlCodePopup.ShowHandlerDialog(message);
                                if(flag2)
                                    {
                                    if(this.CtrlCodePopup.IsToOverwrite)
                                        {
                                        overWriteStatus = 1;
                                        }
                                    flag3 = true;
                                    }
                                else
                                    {
                                    flag3 = false;
                                    }
                                goto IL_2CF;
                                }
                            IL_2CB:
                            flag3 = true;
                            IL_2CF:
                            flag = !flag3;
                            IL_2D5:
                            if(flag)
                                {
                                goto IL_34C;
                                }
                            string text2 = new AssociateImageBusiness().AssociateImage(num, text, PhotoIds, overWriteStatus, RobotImageLoader.IsAnonymousQrCodeEnabled);
                            flag = !(text2 == "1");
                            bool expr_306 = arg_119_0 = flag;
                            if(false)
                                {
                                goto IL_119;
                                }
                            if(expr_306)
                                {
                                MessageBox.Show(text2);
                                goto IL_34B;
                                }
                            message = "Selected images associated with the " + this.cmbQRCodeType.Text;
                            IL_328:
                            this.MsgBox.ShowHandlerDialog(message, DigiMessageBox.DialogType.OK);
                            IL_337:
                            this.ViewInGroup(text, num);
                            IL_34B:
                            IL_34C: ;
                           // this.KeyBorder1.Visibility = Visibility.Visible;
                            if(false)
                                {
                                goto IL_11C;
                                }
                            }
                        }
                    else
                        {
                        MessageBox.Show("Select card type.");
                        }
                    }
                }
            catch(Exception serviceException)
                {
                string message2 = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message2);
                }
            }

        private void ViewInGroup ( string Code, int CodeType )
            {
            try
                {
                Window window;
                while(true)
                    {
                    RobotImageLoader.SearchCriteria = "QRCODEGROUP";
                    if(5 == 0)
                        {
                        goto IL_4E;
                        }
                    RobotImageLoader.Code = Code;
                    if(-1 != 0)
                        {
                        RobotImageLoader.CodeType = CodeType;
                        SearchResult searchResult = new SearchResult();
                        if(false)
                            {
                            goto IL_58;
                            }
                        if(5 != 0)
                            {
                            searchResult.pagename = "MainGroup";
                            searchResult.Show();
                            searchResult.LoadWindow();
                            goto IL_4E;
                            }
                        goto IL_83;
                        }
                    IL_76:
                    if(!false)
                        {
                        break;
                        }
                    continue;
                    IL_58:
                    window = Window.GetWindow(this);
                    ((SearchResult)window).grdCotrol.Children.Remove(this);
                    goto IL_76;
                    IL_4E:
                    if(2 != 0)
                        {
                        this.HideHandlerDialog();
                        goto IL_58;
                        }
                    goto IL_58;
                    }
                window.Close();
                IL_83:
                this.Dispose();
                }
            catch(Exception serviceException)
                {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }

        public void SetParent ( UIElement parent )
            {
            this._parent = parent;
            }

        private void btn_Click_keyboard ( object sender, RoutedEventArgs e )
            {
            try
                {
                new Button();
                Button button = (Button)sender;
                string text;
                do
                    {
                    text = button.Content.ToString();
                    if(text == null)
                        {
                        goto IL_116;
                        }
                    if(text == "ENTER")
                        {
                        goto IL_75;
                        }
                    if(text == "SPACE")
                        {
                        goto IL_8B;
                        }
                    }
                while(-1 == 0);
                if(text == "CLOSE")
                    {
                    goto IL_B5;
                    }
                if(!(text == "Back"))
                    {
                    goto IL_116;
                    }
                goto IL_C6;
                IL_75:
                if(8 != 0)
                    {
                    //this.KeyBorder1.Visibility = Visibility.Collapsed;
                    goto IL_142;
                    }
                goto IL_B5;
                IL_8B:
                this.txtQRCode.Text = this.txtQRCode.Text + " ";
                if(-1 != 0)
                    {
                    goto IL_142;
                    }
                IL_B5: ;
               // this.KeyBorder1.Visibility = Visibility.Collapsed;
                goto IL_142;
                IL_C6:
                bool arg_DA_0 = this.txtQRCode.Text.Length > 0;
                bool expr_DA;
                do
                    {
                    expr_DA = (arg_DA_0 = !arg_DA_0);
                    }
                while(false);
                if(!expr_DA)
                    {
                    this.txtQRCode.Text = this.txtQRCode.Text.Remove(this.txtQRCode.Text.Length - 1, 1);
                    }
                goto IL_142;
                IL_116:
                this.txtQRCode.Text = this.txtQRCode.Text + button.Content;
                if(false)
                    {
                    goto IL_C6;
                    }
                IL_142: ;
                }
            catch(Exception serviceException)
                {
                if(5 != 0)
                    {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                while(false)
                    {
                    }
                }
            }

        private void btnSearch_Click ( object sender, RoutedEventArgs e )
            {
            try
                {
                if(this.cmbQRCodeType.SelectedIndex <= 0)
                    {
                    MessageBox.Show("Please select card type.");
                    }
                else
                    {
                    RobotImageLoader.CodeType = (int)this.cmbQRCodeType.SelectedValue;
                    RobotImageLoader.IsAnonymousQrCodeEnabled = (App.IsAnonymousQrCodeEnabled && RobotImageLoader.CodeType == 405);
                    if(!string.IsNullOrEmpty(this.txtQRCode.Text.Trim()))
                        {
                        RobotImageLoader.SearchCriteria = "QRCODEGROUP";
                        RobotImageLoader.Code = this.txtQRCode.Text;
                        if(RobotImageLoader.CodeType == 403)
                            {
                            RobotImageLoader.Code = "0000" + RobotImageLoader.Code;
                            }
                        bool flag = RobotImageLoader.CodeType != 406;
                        if(!false)
                            {
                            if(flag)
                                {
                                goto IL_FC;
                                }
                            IL_E8:
                            RobotImageLoader.Code = "2222" + RobotImageLoader.Code;
                            IL_FC:
                            bool arg_121_0;
                            if(App.IsAnonymousQrCodeEnabled)
                                {
                                arg_121_0 = true;
                                goto IL_120;
                                }
                            IL_103:
                            if(8 == 0)
                                {
                                goto IL_26A;
                                }
                            arg_121_0 = new CardBusiness().IsValidCodeType(RobotImageLoader.Code, RobotImageLoader.CodeType);
                            IL_120:
                            if(!arg_121_0)
                                {
                                MessageBox.Show("Invalid code.");
                                if(RobotImageLoader.CodeType == 404)
                                    {
                                    goto IL_167;
                                    }
                                this.txtQRCode.Text = string.Empty;
                                if(8 == 0)
                                    {
                                    goto IL_103;
                                    }
                                }
                            else if(this.IsImageExists(RobotImageLoader.Code))
                                {
                                SearchResult searchResult = null;
                                if(5 != 0)
                                    {
                                    if(searchResult == null)
                                        {
                                        searchResult = new SearchResult();
                                        }
                                    searchResult.pagename = "MainGroup";
                                    searchResult.Show();
                                    searchResult.LoadWindow();
                                    this.HideHandlerDialog();
                                    if(5 != 0)
                                        {
                                        Window window = Window.GetWindow(this);
                                        ((SearchResult)window).grdCotrol.Children.Remove(this);
                                        window.Close();
                                        this.Dispose();
                                        goto IL_232;
                                        }
                                    goto IL_E8;
                                    }
                                }
                            else
                                {
                                MessageBox.Show("No image is associated with this code.");
                                if(RobotImageLoader.CodeType == 404)
                                    {
                                    goto IL_231;
                                    }
                                if(true)
                                    {
                                    goto IL_213;
                                    }
                                goto IL_2C;
                                }
                            this.txtQRCode.Focus();
                            IL_167:
                            return;
                            }
                        IL_213:
                        this.txtQRCode.Text = string.Empty;
                        this.txtQRCode.Focus();
                        IL_231:
                        IL_232: ;
                        }
                    else
                        {
                        MessageBox.Show("Enter " + this.cmbQRCodeType.Text + ((RobotImageLoader.CodeType != 405) ? " Code." : "."));
                        }
                    IL_26A: ;
                    }
                IL_2C: ;
                }
            catch(Exception serviceException)
                {
                if(5 != 0)
                    {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                }
            }

        private bool IsImageExists ( string Code )
            {
            bool result;
            if(!false)
                {
                try
                    {
                    int expr_2F;
                    while(true)
                        {
                        int arg_19_0;
                        int expr_47 = arg_19_0 = new PhotoBusiness().GetImagesBYQRCode(Code, RobotImageLoader.IsAnonymousQrCodeEnabled).Count;
                        int arg_19_1;
                        int expr_13 = arg_19_1 = 0;
                        if(expr_13 == 0)
                            {
                            arg_19_0 = ((expr_47 > expr_13) ? 1 : 0);
                            goto IL_18;
                            }
                        IL_19:
                        bool expr_19 = arg_19_0 == arg_19_1;
                        bool flag;
                        if(!false)
                            {
                            flag = expr_19;
                            }
                        if(!flag)
                            {
                            result = true;
                            if(7 != 0)
                                {
                                if(3 != 0)
                                    {
                                    break;
                                    }
                                continue;
                                }
                            }
                        expr_2F = (arg_19_0 = 0);
                        if(expr_2F == 0)
                            {
                            goto Block_6;
                            }
                        IL_18:
                        arg_19_1 = 0;
                        goto IL_19;
                        }
                    return result;
                    Block_6:
                    result = (expr_2F != 0);
                    }
                catch(Exception serviceException)
                    {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                    result = false;
                    }
                }
            return result;
            }

        private void UserControl_Loaded ( object sender, RoutedEventArgs e )
            {
            }

        private void txtQRCode_KeyDown ( object sender, KeyEventArgs e )
            {
            if(e.Key == Key.Return)
                {
                this.txtQRCode.Text = this.txtQRCode.Text.Replace(App.QRCodeWebUrl, string.Empty);
                if(this.txtQRCode.Text.Trim().Length > 20)
                    {
                    this.txtQRCode.Text = this.txtQRCode.Text.Trim().Remove(0, 20);
                    this.txtQRCode.SelectionStart = this.txtQRCode.Text.Length;
                    }
                this.btnSearch_Click(sender, e);
                }
            }

        private void UserControl_GotFocus ( object sender, RoutedEventArgs e )
            {
            }

        private void UserControl_IsVisibleChanged ( object sender, DependencyPropertyChangedEventArgs e )
            {
            }

        private void cmbQRCodeType_SelectionChanged ( object sender, SelectionChangedEventArgs e )
            {
            try
                {
                do
                    {
                    this.CodeTypeSelectionChange();
                    }
                while(false || 7 == 0);
                }
            catch(Exception serviceException)
                {
                do
                    {
                    string message;
                    do
                        {
                        message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        }
                    while(false);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                while(false);
                }
            }

        private void ClearResources ()
            {
            this.cmbQRCodeType.SelectionChanged -= new SelectionChangedEventHandler(this.cmbQRCodeType_SelectionChanged);
            base.IsVisibleChanged -= new DependencyPropertyChangedEventHandler(this.UserControl_IsVisibleChanged);
            base.GotFocus -= new RoutedEventHandler(this.UserControl_GotFocus);
            base.KeyDown -= new KeyEventHandler(this.txtQRCode_KeyDown);
            base.Loaded -= new RoutedEventHandler(this.UserControl_Loaded);
            this.btnSearch.Click -= new RoutedEventHandler(this.btnSearch_Click);
            this.btnClose.Click -= new RoutedEventHandler(this.btnClose_Click);
            this.btnAssociate.Click -= new RoutedEventHandler(this.btnAssociate_Click);
            //while(true)
            //    {
            //    this.txtQRCode.GotFocus -= new RoutedEventHandler(this.txtCode_GotFocus);
            //    this.btnW.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //    this.btnE.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //    this.btnT.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //    while(true)
            //        {
            //        this.btnR.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //        this.btnY.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //        while(true)
            //            {
            //            if(2 != 0)
            //                {
            //                this.btnU.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //                this.btnI.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //                }
            //            this.btnO.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnP.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            if(8 == 0)
            //                {
            //                break;
            //                }
            //            this.Delete.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnA.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnS.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            if(!false)
            //                {
            //                goto Block_3;
            //                }
            //            }
            //        IL_4E4:
            //        if(3 != 0)
            //            {
            //            goto Block_6;
            //            }
            //        continue;
            //        Block_3:
            //        if(!false)
            //            {
            //            this.btnD.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnF.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnG.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnH.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnJ.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnK.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnL.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnEnter.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnDoller.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnZ.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnX.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnC.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnV.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnB.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnN.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnM.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnHash.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnAtRate.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnAstrick.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btnUnderscore.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            if(!false)
            //                {
            //                this.btnSpace.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //                this.btnCloseKey.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //                this.btnSlash.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //                this.btn4.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //                this.btn5.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //                }
            //            this.btn6.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btn7.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btn8.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btn9.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            this.btn1.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //            goto IL_4E4;
            //            }
            //        break;
            //        }
            //    }
            //Block_6:
            //this.btn2.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //this.btn3.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //this.btnDash.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //this.btnDot.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //this.btnPlus.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //this.btnW.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            //this.btnW.Click -= new RoutedEventHandler(this.btn_Click_keyboard);
            this.OuterBorder = null;
            }

        private void CodeTypeSelectionChange ()
            {
            if(false)
                {
                goto IL_4A;
                }
            bool flag = this.cmbQRCodeType.SelectedValue == null || string.Compare(this.cmbQRCodeType.SelectedValue.ToString(), "404", true) != 0;
            bool arg_48_0 = flag;
            IL_48:
            if(arg_48_0)
                {
                this.txtQRCode.Text = string.Empty;
                this.txtQRCode.IsEnabled = true;
                arg_48_0 = this.txtQRCode.Focus();
                goto IL_AB;
                }
            IL_4A:
            this.txtQRCode.Text = this._CardCode;
            if(!false)
                {
                }
            this.txtQRCode.IsEnabled = false;
           // this.KeyBorder1.Visibility = Visibility.Collapsed;
            goto IL_BD;
            IL_AB:
            if(4 == 0)
                {
                goto IL_48;
                }
            //this.KeyBorder1.Visibility = Visibility.Visible;
            IL_BD:
            bool expr_C9 = arg_48_0 = (this.cmbQRCodeType.SelectedValue == null);
            if(8 != 0)
                {
                if(!expr_C9)
                    {
                    App.SelectedCodeType = (int)this.cmbQRCodeType.SelectedValue;
                    }
                return;
                }
            goto IL_AB;
            }

        public void Dispose ()
            {
            GC.SuppressFinalize(this);
            }

         //void IComponentConnector.Connect ( int connectionId, object target )
         //   {
         //   switch(connectionId)
         //       {
         //       case 1:
         //               {
         //               FrameworkElement expr_111 = (AssociateImage)target;
         //               RoutedEventHandler expr_121 = new RoutedEventHandler(this.UserControl_Loaded);
         //               if(!false)
         //                   {
         //                   expr_111.Loaded += expr_121;
         //                   }
         //               ((AssociateImage)target).GotFocus += new RoutedEventHandler(this.UserControl_GotFocus);
         //               ((AssociateImage)target).IsVisibleChanged += new DependencyPropertyChangedEventHandler(this.UserControl_IsVisibleChanged);
         //               return;
         //               }
         //       case 2:
         //           this.OuterBorder = (Border)target;
         //           return;
         //       case 3:
         //           this.cmbQRCodeType = (ComboBox)target;
         //           this.cmbQRCodeType.SelectionChanged += new SelectionChangedEventHandler(this.cmbQRCodeType_SelectionChanged);
         //           if(!false)
         //               {
         //               return;
         //               }
         //           goto IL_4F1;
         //       case 4:
         //           this.txtQRCode = (TextBox)target;
         //           this.txtQRCode.GotFocus += new RoutedEventHandler(this.txtCode_GotFocus);
         //           this.txtQRCode.KeyDown += new KeyEventHandler(this.txtQRCode_KeyDown);
         //           return;
         //       case 5:
         //           this.btnSearch = (Button)target;
         //           this.btnSearch.Click += new RoutedEventHandler(this.btnSearch_Click);
         //           return;
         //       case 6:
         //           this.btnAssociate = (Button)target;
         //           this.btnAssociate.Click += new RoutedEventHandler(this.btnAssociate_Click);
         //           return;
         //       case 7:
         //           this.btnClose = (Button)target;
         //           this.btnClose.Click += new RoutedEventHandler(this.btnClose_Click);
         //           goto IL_263;
         //       case 8:
         //           this.MsgBox = (DigiMessageBox)target;
         //           return;
         //       case 9:
         //           this.CtrlCodePopup = (CtrlExistCodePopup)target;
         //           return;
         //       case 10:
         //           this.KeyBorder1 = (Border)target;
         //           return;
         //       case 11:
         //           this.btnQ = (Button)target;
         //           this.btnQ.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           if(!false)
         //               {
         //               return;
         //               }
         //           goto IL_263;
         //       case 12:
         //           this.btnW = (Button)target;
         //           this.btnW.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           if(6 != 0)
         //               {
         //               return;
         //               }
         //           goto IL_5E1;
         //       case 13:
         //           this.btnE = (Button)target;
         //           this.btnE.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 14:
         //           this.btnR = (Button)target;
         //           this.btnR.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 15:
         //           this.btnT = (Button)target;
         //           this.btnT.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 16:
         //           this.btnY = (Button)target;
         //           this.btnY.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 17:
         //           this.btnU = (Button)target;
         //           this.btnU.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 18:
         //           this.btnI = (Button)target;
         //           if(2 != 0)
         //               {
         //               this.btnI.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //               return;
         //               }
         //           goto IL_6AE;
         //       case 19:
         //           this.btnO = (Button)target;
         //           this.btnO.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 20:
         //           this.btnP = (Button)target;
         //           this.btnP.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 21:
         //           this.Delete = (Button)target;
         //           this.Delete.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           if(!false)
         //               {
         //               return;
         //               }
         //           break;
         //       case 22:
         //           this.btnA = (Button)target;
         //           this.btnA.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           goto IL_497;
         //       case 23:
         //           this.btnS = (Button)target;
         //           goto IL_4A8;
         //       case 24:
         //           this.btnD = (Button)target;
         //           this.btnD.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           if(4 != 0)
         //               {
         //               return;
         //               }
         //           goto IL_4A8;
         //       case 25:
         //           goto IL_4F1;
         //       case 26:
         //           this.btnG = (Button)target;
         //           this.btnG.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 27:
         //           this.btnH = (Button)target;
         //           this.btnH.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 28:
         //           this.btnJ = (Button)target;
         //           this.btnJ.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 29:
         //           this.btnK = (Button)target;
         //           this.btnK.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 30:
         //           this.btnL = (Button)target;
         //           this.btnL.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           goto IL_5E1;
         //       case 31:
         //           this.btnEnter = (Button)target;
         //           this.btnEnter.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 32:
         //           this.btnDoller = (Button)target;
         //           this.btnDoller.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 33:
         //           this.btnZ = (Button)target;
         //           this.btnZ.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 34:
         //           this.btnX = (Button)target;
         //           this.btnX.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 35:
         //           this.btnC = (Button)target;
         //           this.btnC.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           goto IL_6AE;
         //       case 36:
         //           this.btnV = (Button)target;
         //           this.btnV.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 37:
         //           this.btnB = (Button)target;
         //           this.btnB.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 38:
         //           this.btnN = (Button)target;
         //           this.btnN.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 39:
         //           this.btnM = (Button)target;
         //           goto IL_73B;
         //       case 40:
         //           this.btnHash = (Button)target;
         //           this.btnHash.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 41:
         //           this.btnAtRate = (Button)target;
         //           this.btnAtRate.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 42:
         //           this.btnAstrick = (Button)target;
         //           this.btnAstrick.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 43:
         //           this.btnUnderscore = (Button)target;
         //           this.btnUnderscore.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 44:
         //           this.btnSpace = (Button)target;
         //           this.btnSpace.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           if(true)
         //               {
         //               return;
         //               }
         //           goto IL_73B;
         //       case 45:
         //           this.btnCloseKey = (Button)target;
         //           this.btnCloseKey.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 46:
         //           if(!false)
         //               {
         //               this.btn7 = (Button)target;
         //               this.btn7.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //               return;
         //               }
         //           goto IL_497;
         //       case 47:
         //           this.btn8 = (Button)target;
         //           this.btn8.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 48:
         //           this.btn9 = (Button)target;
         //           this.btn9.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 49:
         //           this.btnSlash = (Button)target;
         //           this.btnSlash.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 50:
         //           this.btn4 = (Button)target;
         //           this.btn4.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 51:
         //           this.btn5 = (Button)target;
         //           this.btn5.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           if(!false)
         //               {
         //               return;
         //               }
         //           goto IL_9FA;
         //       case 52:
         //           this.btn6 = (Button)target;
         //           this.btn6.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 53:
         //           this.btnAll = (Button)target;
         //           this.btnAll.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 54:
         //           this.btn1 = (Button)target;
         //           this.btn1.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 55:
         //           this.btn2 = (Button)target;
         //           this.btn2.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 56:
         //           goto IL_9FA;
         //       case 57:
         //           this.btnDash = (Button)target;
         //           this.btnDash.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 58:
         //           this.btn0 = (Button)target;
         //           this.btn0.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 59:
         //           this.btnDot = (Button)target;
         //           this.btnDot.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       case 60:
         //           this.btnPlus = (Button)target;
         //           this.btnPlus.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //           return;
         //       }
         //   this._contentLoaded = true;
         //   IL_263:
         //   IL_497:
         //   return;
         //   IL_4A8:
         //   this.btnS.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //   return;
         //   IL_4F1:
         //   this.btnF = (Button)target;
         //   this.btnF.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //   IL_5E1:
         //   IL_6AE:
         //   return;
         //   IL_73B:
         //   this.btnM.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //   return;
         //   IL_9FA:
         //   this.btn3 = (Button)target;
         //   this.btn3.Click += new RoutedEventHandler(this.btn_Click_keyboard);
         //   }
        }
    }
