using DigiAuditLogger;
using PhotoSW;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using PhotoSW.Manage;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using DigiPhoto;
using PhotoSW.PSControls;
using PhotoSW.Views;

namespace PhotoSW.Manage
{
    public partial class CardType : Window, IComponentConnector, IStyleConnector
    {
        public class CardTypeList
        {
            public int IMIXImageCardTypeId
            {
                get;
                set;
            }

            public string Name
            {
                get;
                set;
            }

            public string CardIdentificationDigit
            {
                get;
                set;
            }

            public string ImageIdentificationType
            {
                get;
                set;
            }

            public string Status
            {
                get;
                set;
            }

            public int MaxImages
            {
                get;
                set;
            }

            public string Description
            {
                get;
                set;
            }

            public DateTime CreatedOn
            {
                get;
                set;
            }
        }

        private int cardId = 0;

        private UIElement _parent;

        

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        public CardType()
        {
            try
            {
                this.InitializeComponent();
                this.LoadComboValues();
                this.GetCardTypeList();
                this.txbUserName.Text = LoginUser.UserName;
                this.txbStoreName.Text = LoginUser.StoreName;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                do
                {
                    do
                    {
                        AuditLog.AddUserLog(LoginUser.UserId, 39, "Logged out at ");
                    }
                    while (8 == 0);
                    Login login = new Login();
                    Window expr_45 = login;
                    if (!false)
                    {
                        expr_45.Show();
                    }
                    do
                    {
                        if (!false)
                        {
                            base.Close();
                        }
                    }
                    while (5 == 0);
                }
                while (false);
            }
            catch (Exception serviceException)
            {
                string message;
                if (2 != 0)
                {
                    message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                }
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            finally
            {
                MemoryManagement.FlushMemory();
            }
        }

        private iMixImageCardTypeInfo GetCardTypebyCardId()
        {
            if (!true)
            {
                goto IL_0B;
            }
        IL_04:
            if (3 == 0)
            {
                goto IL_1D;
            }
            CardBusiness cardBusiness = new CardBusiness();
        IL_0B:
            if (false)
            {
                goto IL_04;
            }
            iMixImageCardTypeInfo cardTypeList = cardBusiness.GetCardTypeList(this.cardId);
        IL_1D:
            if (8 != 0)
            {
                return cardTypeList;
            }
            goto IL_04;
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                if (!false)
                {
                    EditAddCard expr_06 = this.ctrlEditAddCard;
                    int expr_0B = 0;
                    if (7 != 0)
                    {
                        expr_06.cardId = expr_0B;
                    }
                    if (5 != 0)
                    {
                    }
                    this.ctrlEditAddCard.Visibility = Visibility.Visible;
                }
                if (true)
                {
                    this.ctrlEditAddCard.SetParent(this);
                }
            }
            while (7 == 0);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    if (4 != 0)
                    {
                        ManageHome manageHome = new ManageHome();
                        Window expr_25 = manageHome;
                        if (-1 != 0)
                        {
                            expr_25.Show();
                        }
                        if (6 == 0)
                        {
                            goto IL_19;
                        }
                    }
                    base.Close();
                IL_19: ;
                }
                catch (Exception serviceException)
                {
                    do
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                    while (-1 == 0);
                }
            }
            while (!true);
            if (!false)
            {
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                this.cardId = button.Tag.ToInt32(false);
                iMixImageCardTypeInfo cardTypebyCardId = this.GetCardTypebyCardId();
                if (cardTypebyCardId != null)
                {
                    if (2 != 0)
                    {
                        if (4 != 0)
                        {
                            this.ctrlEditAddCard.txtName.Text = cardTypebyCardId.Name;
                        }
                        this.ctrlEditAddCard.txtCardDesc.Text = cardTypebyCardId.Description;
                        if (!false)
                        {
                            this.ctrlEditAddCard.txtCardIdentificationDigit.Text = cardTypebyCardId.CardIdentificationDigit;
                            this.ctrlEditAddCard.chkIsActive.IsChecked = new bool?(cardTypebyCardId.IsActive.ToBoolean(false));
                            this.ctrlEditAddCard.cmbCardFormatType.SelectedValue = cardTypebyCardId.ImageIdentificationType;
                            this.ctrlEditAddCard.txtMaxImage.Text = cardTypebyCardId.MaxImages.ToString();
                            this.ctrlEditAddCard.chkIsPrePaid.IsChecked = new bool?(cardTypebyCardId.IsPrepaid);
                        }
                        this.ctrlEditAddCard.cmbPackage.SelectedValue = cardTypebyCardId.PackageId;
                        if (!false)
                        {
                            this.ctrlEditAddCard.chkIsWaterMark.IsChecked = new bool?(cardTypebyCardId.IsWaterMark.ToBoolean(false));
                            this.ctrlEditAddCard.cardId = this.cardId;
                            this.ctrlEditAddCard.Visibility = Visibility.Visible;
                            this.ctrlEditAddCard.SetParent(this);
                        }
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                this.cardId = button.Tag.ToInt32(false);
                MessageBoxResult messageBoxResult = MessageBox.Show("Alert: Are you sure you want to change the status of Card?", "Temper Alert", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (messageBoxResult != MessageBoxResult.Yes)
                {
                    goto IL_C7;
                }
            IL_53:
                string name;
                while (5 != 0)
                {
                    CardBusiness cardBusiness = new CardBusiness();
                    name = cardBusiness.GetCardTypeList(this.cardId).Name;
                    bool arg_81_0 = !cardBusiness.ChangeCardStatus(this.cardId);
                    if (8 != 0)
                    {
                        bool flag = arg_81_0;
                        if (5 == 0)
                        {
                            continue;
                        }
                        if (!flag)
                        {
                            break;
                        }
                        MessageBox.Show("Record is in use");
                    }
                    else
                    {
                    IL_A7:
                        this.GetCardTypeList();
                        this.cardId = 0;
                    }
                    goto IL_C7;
                }
                AuditLog.AddUserLog(LoginUser.UserId, 27, "Card (" + name + ") status has been changed on ");
            IL_C7:
                if (false)
                {
                    goto IL_53;
                }
            }
            catch (Exception serviceException)
            {
                if (!false)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
            if (!false)
            {
            }
        }

        private void LoadComboValues()
        {
            if (!false)
            {
                goto IL_04;
            }
            Dictionary<string, int> dictionary;
            while (true)
            {
            IL_39:
                dictionary.Add("QRCode+Barcode", 405);
                if (!true)
                {
                    break;
                }
                if (!false)
                {
                    return;
                }
            }
        IL_04:
            Dictionary<string, int> expr_52 = new Dictionary<string, int>();
            if (!false)
            {
                dictionary = expr_52;
            }
            if (-1 != 0)
            {
                dictionary.Add("--Select--", 0);
                dictionary.Add("QRCode", 401);
                if (!false)
                {
                    dictionary.Add("Barcode", 402);
                }
                //goto IL_39;
            }
        }

        public void GetCardTypeList()
        {
            if (!true)
            {
                goto IL_36;
            }
        IL_04:
            CardBusiness cardBusiness = new CardBusiness();
            this.grdCardType.ItemsSource = cardBusiness.GetCardTypeListview().SkipWhile((ImageCardTypeInfo x) => x.IMIXImageCardTypeId == 3);
        IL_36:
            if (!false)
            {
                return;
            }
            goto IL_04;
        }

        private void btnBackToHome_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    if (4 != 0)
                    {
                        ManageHome manageHome = new ManageHome();
                        Window expr_25 = manageHome;
                        if (-1 != 0)
                        {
                            expr_25.Show();
                        }
                        if (6 == 0)
                        {
                            goto IL_19;
                        }
                    }
                    base.Close();
                IL_19: ;
                }
                catch (Exception serviceException)
                {
                    do
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                    while (-1 == 0);
                }
            }
            while (!true);
            if (!false)
            {
            }
        }
        void IStyleConnector.Connect(int connectionId, object target)
        {
            while (true)
            {
                int arg_16_0 = connectionId;
                if (false)
                {
                    goto IL_16;
                }
                if (4 != 0)
                {
                    arg_16_0 = connectionId - 13;
                    goto IL_16;
                }
            IL_5A:
                if (!false)
                {
                    if (true)
                    {
                        break;
                    }
                    continue;
                }
            IL_23:
                goto IL_5A;
            IL_16:
                switch (arg_16_0)
                {
                    case 0:
                        ((Button)target).Click += new RoutedEventHandler(this.btnEdit_Click);
                        break;
                    case 1:
                        if (!false)
                        {
                            ((Button)target).Click += new RoutedEventHandler(this.btnDelete_Click);
                        }
                        break;
                }
                goto IL_23;
            }
        }

    }
}
