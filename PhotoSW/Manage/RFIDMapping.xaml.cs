using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.Data;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using FrameworkHelper;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Xceed.Wpf.Toolkit;
using PhotoSW.Views;
using DigiPhoto;
//using PhotoSW.Manage;

namespace PhotoSW.Manage
{
    public partial class RFIDMapping : Window, IComponentConnector, IStyleConnector
    {
        private List<PhotoDetail> _lstPhotoDetails = null;

       

        public RFIDMapping()
        {
            this.InitializeComponent();
            this.GetDummyRFIDTagDetails();
            this.txbUserName.Text = LoginUser.UserName;
            this.txbStoreName.Text = LoginUser.StoreName;
            DateTime date = new CustomBusineses().ServerDateTime().Date;
            this.dtFrom.DefaultValue = date;
            this.dtFrom.Value = new DateTime?(date);
            this.FromDate.Value = new DateTime?(date);
            this.FromDate.DefaultValue = date;
            this.dtTo.Value = new DateTime?(new CustomBusineses().ServerDateTime());
            this.ToDate.Value = this.dtTo.Value;
            this.FillPhotoGraphersList();
            this.FillLocationDropdown();
            this.GetSeperatorRFIDTagDetails();
            this.dtFromRpt.Value = new DateTime?(date);
            this.dtToRpt.Value = new DateTime?(new CustomBusineses().ServerDateTime().Date.AddHours(23.0));
            this.FillPhotoGraphersListForreport();
        }

        private void FillPhotoGraphersList()
        {
            while (true)
            {
                List<UserInfo> photoGraphersList = new UserBusiness().GetPhotoGraphersList();
                if (5 == 0)
                {
                    goto IL_5A;
                }
                CommonUtility.BindComboWithSelect<UserInfo>(this.cmbPhotographer, photoGraphersList, "Photographer", "UserId", 0, ClientConstant.SelectString);
                if (false)
                {
                    goto IL_6A;
                }
            IL_35:
                if (!false)
                {
                    this.cmbPhotographer.SelectedIndex = 0;
                    CommonUtility.BindCombo<UserInfo>(this.cmbPhotographerNon, photoGraphersList, "Photographer", "UserId");
                    goto IL_5A;
                }
                continue;
            IL_6A:
                if (!false)
                {
                    break;
                }
                goto IL_35;
            IL_5A:
                if (6 != 0)
                {
                    this.cmbPhotographerNon.SelectedIndex = 0;
                    goto IL_6A;
                }
                break;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (-1 != 0)
            {
                try
                {
                    ManageHome manageHome = new ManageHome();
                    manageHome.Show();
                    base.Close();
                }
                catch (Exception serviceException)
                {
                    while (!false && !false)
                    {
                        if (-1 != 0)
                        {
                            ErrorHandler.ErrorHandler.LogError(serviceException);
                            break;
                        }
                    }
                }
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (2 != 0)
                {
                    int expr_28 = LoginUser.UserId;
                    if (8 != 0)
                    {
                        AuditLog.AddUserLog(expr_28, 39, "Logged out at ");
                    }
                    Login login = new Login();
                    login.Show();
                }
                do
                {
                    base.Close();
                }
                while (false);
            }
            catch (Exception serviceException)
            {
                do
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
                while (6 == 0);
            }
            finally
            {
                MemoryManagement.FlushMemory();
            }
            if (5 != 0)
            {
            }
        }

        private void cmbPhotographer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!false && -1 != 0)
            {
                try
                {
                    List<DeviceInfo> photoGrapherDeviceList;
                    do
                    {
                        photoGrapherDeviceList = new DeviceManager().GetPhotoGrapherDeviceList(this.cmbPhotographer.SelectedValue.ToInt32(false));
                    }
                    while (false);
                    CommonUtility.BindComboWithSelect<DeviceInfo>(this.cmbDevice, photoGrapherDeviceList, "Name", "DeviceId", 0, ClientConstant.SelectString);
                    do
                    {
                        this.cmbDevice.SelectedIndex = 0;
                    }
                    while (false || 4 == 0);
                }
                catch (Exception serviceException)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int photoGrapherId = this.cmbPhotographer.SelectedValue.ToInt32(false);
                int deviceId;
                DateTime dateTime;
                do
                {
                    deviceId = this.cmbDevice.SelectedValue.ToInt32(false);
                    dateTime = (this.dtFrom.Value.HasValue ? this.dtFrom.Value.ToDateTime(false) : DateTime.Now.Date);
                }
                while (7 == 0);
                DateTime dateTime2 = this.dtTo.Value.HasValue ? this.dtTo.Value.ToDateTime(false) : DateTime.Now;
                this.Dg_MappingStatus.ItemsSource = new RfidBusiness().GetRFIDAssociationSearch(photoGrapherId, deviceId, dateTime, dateTime2);
            }
            catch (Exception serviceException)
            {
                do
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
                while (6 == 0);
            }
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (-1 == 0)
                {
                    goto IL_68;
                }
                Button button = (Button)sender;
                string expr_B1 = Convert.ToString(button.CommandParameter);
                string photoRFID;
                if (5 != 0)
                {
                    photoRFID = expr_B1;
                }
                PhotoDetail photoDetail = new PhotoDetail();
                photoDetail.PhotoRFID = photoRFID;
                photoDetail.FileName = LoginUser.DigiFolderThumbnailPath;
                photoDetail.IsEnabled = false;
            IL_56:
                PhotoDetail photoDetailObj = photoDetail;
                if (false)
                {
                    goto IL_93;
                }
                List<PhotoDetail> photoDetailsByPhotoIds = new PhotoBusiness().GetPhotoDetailsByPhotoIds(photoDetailObj);
            IL_68:
                this.lstImages.ItemsSource = photoDetailsByPhotoIds;
                this.stkAssociation.Visibility = Visibility.Collapsed;
                this.GrdImageDetail.Visibility = Visibility.Visible;
                if (3 == 0)
                {
                    goto IL_56;
                }
            IL_93: ;
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void btnImageClose_Click(object sender, RoutedEventArgs e)
        {
            if (7 != 0 && !false)
            {
                try
                {
                    if (5 == 0)
                    {
                        goto IL_29;
                    }
                IL_0B:
                    this.txtRFIDAssociate.Text = string.Empty;
                    this.lstImages.ItemsSource = string.Empty;
                IL_29:
                    if (6 == 0)
                    {
                        goto IL_0B;
                    }
                    this.GrdImageDetail.Visibility = Visibility.Collapsed;
                    if (!false)
                    {
                    }
                }
                catch (Exception serviceException)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
            }
        }

        private void btnSearchNonAssociated_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RFIDPhotoDetails rFIDPhotoDetails;
                while (true)
                {
                    this._lstPhotoDetails = new List<PhotoDetail>();
                    int photoGrapherId = this.cmbPhotographerNon.SelectedValue.ToInt32(false);
                    while (true)
                    {
                        DateTime startDate = this.FromDate.Value.HasValue ? this.FromDate.Value.ToDateTime(false) : DateTime.Now.Date;
                        DateTime? value = this.ToDate.Value;
                        if (5 == 0)
                        {
                            goto IL_126;
                        }
                        DateTime arg_B0_0;
                        if (!value.HasValue)
                        {
                            if (false)
                            {
                                break;
                            }
                            arg_B0_0 = DateTime.Now;
                        }
                        else
                        {
                            arg_B0_0 = this.ToDate.Value.ToDateTime(false);
                        }
                        DateTime endDate = arg_B0_0;
                        rFIDPhotoDetails = new RFIDPhotoDetails();
                        rFIDPhotoDetails.PhotoGrapherId = photoGrapherId;
                        rFIDPhotoDetails.StartDate = startDate;
                        rFIDPhotoDetails.EndDate = endDate;
                        if (4 != 0)
                        {
                            goto Block_5;
                        }
                    }
                }
            Block_5:
                rFIDPhotoDetails.FileName = LoginUser.DigiFolderThumbnailPath;
                RFIDPhotoDetails rFIDPhotoObj = rFIDPhotoDetails;
                this._lstPhotoDetails = new RfidBusiness().GetRFIDNotAssociatedPhotos(rFIDPhotoObj);
                this.lstImages.ItemsSource = this._lstPhotoDetails;
                this.stkAssociation.Visibility = Visibility.Visible;
                this.GrdImageDetail.Visibility = Visibility.Visible;
            IL_126:
                if (7 != 0)
                {
                }
            }
            catch (Exception serviceException)
            {
                while (true)
                {
                    while (true)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                        while (8 != 0)
                        {
                            if (!false)
                            {
                                if (8 != 0)
                                {
                                    goto Block_8;
                                }
                                break;
                            }
                        }
                    }
                }
            Block_8: ;
            }
        }

        private void cmbPhotographerNon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int arg_0C_0 = this.cmbPhotographerNon.SelectedIndex;
                bool expr_0F;
                do
                {
                    expr_0F = ((arg_0C_0 = ((arg_0C_0 <= 0) ? 1 : 0)) != 0);
                }
                while (false);
                bool flag = expr_0F;
                do
                {
                    if (!flag)
                    {
                        if (2 != 0)
                        {
                            this.btnSearchNonAssociated.IsEnabled = true;
                        }
                    }
                }
                while (false);
            }
            catch (Exception serviceException)
            {
                do
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
                while (false || 4 == 0);
            }
        }

        private void GetDummyRFIDTagDetails()
        {
            try
            {
                List<RFIDTagInfo> dummyRFIDTags = new RfidBusiness().GetDummyRFIDTags(0);
                this.DGDummyRFIDTags.ItemsSource = dummyRFIDTags;
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private bool CheckDummyTagValidations(string keyword)
        {
            return !string.IsNullOrEmpty(keyword);
        }

        private bool SaveDummyRFIDTagDetails(int DummyTagID, string TagId, bool isActive)
        {
            bool result;
            try
            {
                RFIDTagInfo rfidTag;
                while (true)
                {
                    RFIDTagInfo rFIDTagInfo = new RFIDTagInfo();
                    while (true)
                    {
                    IL_06:
                        RFIDTagInfo expr_46 = rFIDTagInfo;
                        if (true)
                        {
                            expr_46.DummyRFIDTagID = DummyTagID;
                        }
                        while (!false)
                        {
                            rFIDTagInfo.TagId = TagId;
                            rFIDTagInfo.IsActive = isActive;
                            while (7 == 0)
                            {
                            }
                            if (!false)
                            {
                                rfidTag = rFIDTagInfo;
                                if (!false)
                                {
                                    goto Block_4;
                                }
                                goto IL_06;
                            }
                        }
                        break;
                    }
                }
            Block_4:
                result = new RfidBusiness().SaveUpdateDummyRFIDTags(rfidTag);
            }
            catch (Exception serviceException)
            {
                do
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
                while (false);
                result = false;
            }
            return result;
        }

        private void btnDeleteTag_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                int dummyRFIDTagID = button.Tag.ToInt32(false);
                while (true)
                {
                IL_26:
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to delete the RFID tag?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (!false)
                    {
                        bool flag = messageBoxResult != MessageBoxResult.Yes;
                        bool arg_4F_0 = flag;
                        while (!arg_4F_0)
                        {
                            RFIDTagInfo rFIDTagInfo = new RfidBusiness().GetDummyRFIDTags(dummyRFIDTagID).FirstOrDefault<RFIDTagInfo>();
                            bool expr_68 = arg_4F_0 = (rFIDTagInfo == null);
                            if (!false)
                            {
                                if (expr_68)
                                {
                                    break;
                                }
                                if (false)
                                {
                                    break;
                                }
                                bool arg_82_0 = new RfidBusiness().DeleteDummyRFIDTags(dummyRFIDTagID);
                                bool expr_84;
                                do
                                {
                                    bool flag2 = arg_82_0;
                                    expr_84 = (arg_82_0 = flag2);
                                }
                                while (5 == 0);
                                if (!expr_84)
                                {
                                    goto IL_B6;
                                }
                                this.GetDummyRFIDTagDetails();
                                if (!false)
                                {
                                    goto IL_A0;
                                }
                                goto IL_26;
                            }
                        }
                        goto IL_CB;
                    }
                    break;
                }
            IL_A0:
                System.Windows.MessageBox.Show("RFID tag deleted successfully.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                goto IL_C9;
            IL_B6:
                System.Windows.MessageBox.Show("RFID tag could not be deleted!", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Hand);
            IL_C9:
            IL_CB: ;
            }
            catch (Exception serviceException)
            {
                do
                {
                    System.Windows.MessageBox.Show("RFID tag could not be deleted!", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
                while (3 == 0);
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnSaveTag_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    if (!false)
                    {
                        string text = this.txtTag.Text;
                        if (!this.CheckDummyTagValidations(text))
                        {
                            System.Windows.MessageBox.Show("RFID tag keyword cannot be empty!", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Hand);
                            goto IL_D4;
                        }
                        if (false)
                        {
                            goto IL_D5;
                        }
                        bool value = this.chkIsTagActive.IsChecked.Value;
                        bool flag = this.SaveDummyRFIDTagDetails(0, text, value);
                        this.GetDummyRFIDTagDetails();
                        bool arg_75_0;
                        bool expr_6E = arg_75_0 = flag;
                        if (5 != 0)
                        {
                            arg_75_0 = !expr_6E;
                        }
                        if (!arg_75_0 && !false)
                        {
                            this.txtTag.Text = string.Empty;
                            System.Windows.MessageBox.Show("RFID tag saved successfully.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("RFID tag could not be saved due to some error!", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Hand);
                        }
                    }
                IL_A3:
                    if (false)
                    {
                        goto IL_A3;
                    }
                IL_D4:
                IL_D5: ;
                }
                catch (Exception serviceException)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
            }
            while (false);
        }

        private void btnAssociate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool expr_17 = !string.IsNullOrEmpty(this.txtRFIDAssociate.Text);
                bool flag;
                if (!false)
                {
                    flag = expr_17;
                }
                if (!flag)
                {
                    System.Windows.MessageBox.Show("Please enter RFID for association", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    string text = string.Join(", ", (from i in
                                                         (from x in this._lstPhotoDetails
                                                          where x.IsChecked
                                                          select x).ToList<PhotoDetail>()
                                                     select i.PhotoId.ToString()).ToArray<string>());
                    flag = (text.Length <= 1);
                    if (!flag)
                    {
                        this.MapNonAssociatedImages(this.txtRFIDAssociate.Text, text.ToString());
                        System.Windows.MessageBox.Show("Images associated successfully", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        this.btnSearchNonAssociated_Click(null, new RoutedEventArgs());
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Please select Images to associate", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void chkSelectedimages_Click(object sender, RoutedEventArgs e)
        {
        }

        private bool MapNonAssociatedImages(string cardUniqueIdentifier, string photoIDS)
        {
            bool result;
            try
            {
                do
                {
                    result = new RfidBusiness().MapNonAssociatedImages(cardUniqueIdentifier, photoIDS);
                }
                while (false);
            }
            catch (Exception serviceException)
            {
                do
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
                while (false || false);
                result = false;
            }
            if (!false)
            {
            }
            return result;
        }

        private void btnSaveSeperatorTag_Click(object sender, RoutedEventArgs e)
        {
            bool arg_19_0;
            bool arg_78_0 = arg_19_0 = string.IsNullOrWhiteSpace(this.txtSeperatortxtTag.Text);
            bool expr_7E;
            while (true)
            {
                int arg_78_1;
                int expr_16 = arg_78_1 = 0;
                bool arg_CB_0;
                if (expr_16 == 0)
                {
                    arg_CB_0 = ((arg_19_0 ? 1 : 0) == expr_16);
                    goto IL_1B;
                }
                goto IL_78;
            IL_72:
                bool arg_75_0;
                if (!false)
                {
                    bool flag = arg_75_0;
                    arg_78_0 = flag;
                    arg_78_1 = 0;
                    goto IL_78;
                }
                continue;
            IL_1B:
                if (!arg_CB_0)
                {
                    break;
                }
                arg_75_0 = (arg_19_0 = (arg_78_0 = this.SaveSeperatorRFIDTagDetails(0, this.txtSeperatortxtTag.Text, Convert.ToInt32(this.cmbLocation.SelectedValue), this.chkIsSeperatorTagActive.IsChecked.Value)));
                goto IL_72;
            IL_78:
                bool expr_78 = arg_19_0 = (arg_78_0 = ((arg_78_0 ? 1 : 0) == arg_78_1));
                if (!false)
                {
                    bool flag2 = expr_78;
                    expr_7E = (arg_19_0 = (arg_75_0 = (arg_78_0 = (arg_CB_0 = flag2))));
                    if (false)
                    {
                        goto IL_1B;
                    }
                    if (true)
                    {
                        goto Block_6;
                    }
                    goto IL_72;
                }
            }
            System.Windows.MessageBox.Show("Separator RFID tag can not be empty");
            return;
        Block_6:
            if (!expr_7E)
            {
                System.Windows.MessageBox.Show("Separator RFID tag saved successfully");
                if (8 == 0)
                {
                    return;
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Some error occured");
            }
            this.clearControls();
            this.GetSeperatorRFIDTagDetails();
        }

        private void FillLocationDropdown()
        {
            if (true)
            {
                goto IL_04;
            }
            Dictionary<string, string> dictionary;
            do
            {
            IL_38:
                RfidBusiness rfidBusiness;
                using (List<LocationInfo>.Enumerator enumerator = rfidBusiness.GetAllLocations().GetEnumerator())
                {
                    while (-1 == 0 || enumerator.MoveNext())
                    {
                        LocationInfo current = enumerator.Current;
                        dictionary.Add(current.DG_Location_Name, current.DG_Location_ID.ToString());
                    }
                }
                this.cmbLocation.ItemsSource = dictionary;
                this.cmbLocation.SelectedValue = "0";
                if (4 == 0)
                {
                    goto IL_16;
                }
            }
            while (8 == 0);
            if (4 != 0)
            {
                return;
            }
            goto IL_16;
        IL_04:
            dictionary = null;
            Dictionary<string, string> expr_CA = new Dictionary<string, string>();
            if (7 != 0)
            {
                dictionary = expr_CA;
            }
        IL_16:
            dictionary.Add("--Select--", "0");
            if (true)
            {
                RfidBusiness rfidBusiness = new RfidBusiness();
               // goto IL_38;
            }
            goto IL_04;
        }

        private bool SaveSeperatorRFIDTagDetails(int SeperatorTagID, string TagId, int locationId, bool isActive)
        {
            bool result;
            do
            {
                try
                {
                    SeperatorTagInfo rfidTag = new SeperatorTagInfo
                    {
                        SeparatorRFIDTagID = SeperatorTagID,
                        TagID = TagId,
                        LocationId = locationId,
                        IsActive = isActive
                    };
                    result = new RfidBusiness().SaveSeperatorRFIDTagsInfo(rfidTag);
                }
                catch (Exception serviceException)
                {
                    do
                    {
                        if (6 != 0)
                        {
                        }
                        if (6 == 0)
                        {
                            goto IL_74;
                        }
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                        if (-1 != 0)
                        {
                        }
                    }
                    while (false);
                    result = false;
                IL_74: ;
                }
            }
            while (3 == 0);
            return result;
        }

        private void GetSeperatorRFIDTagDetails()
        {
            try
            {
                List<SeperatorTagInfo> seperatorRFIDTags = new RfidBusiness().GetSeperatorRFIDTags(0);
                this.DGSeperatorRFIDTags.ItemsSource = seperatorRFIDTags;
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void btnDeleteSeperatorTag_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int arg_69_0;
                bool flag;
                bool arg_6F_0;
                bool arg_6B_0;
                bool flag2;
                if (-1 != 0)
                {
                    Button button = (Button)sender;
                    int expr_9C = arg_69_0 = button.Tag.ToInt32(false);
                    if (false)
                    {
                        goto IL_68;
                    }
                    int seperatorTagID = expr_9C;
                    RfidBusiness rfidBusiness = new RfidBusiness();
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to delete the separator RFID tag?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    do
                    {
                        flag = (messageBoxResult != MessageBoxResult.Yes);
                        bool expr_4F = arg_6F_0 = flag;
                        if (false)
                        {
                            goto IL_6F;
                        }
                        if (expr_4F)
                        {
                            goto IL_7D;
                        }
                    }
                    while (-1 == 0);
                    bool expr_5C = arg_6B_0 = rfidBusiness.DeleteSeperatorTag(seperatorTagID);
                    if (false)
                    {
                        goto IL_6B;
                    }
                    flag2 = expr_5C;
                }
                arg_69_0 = (flag2 ? 1 : 0);
            IL_68:
                arg_6B_0 = (arg_69_0 == 0);
            IL_6B:
                flag = arg_6B_0;
                arg_6F_0 = flag;
            IL_6F:
                if (!arg_6F_0)
                {
                    System.Windows.MessageBox.Show("Separator RFID tag deleted successfully");
                }
            IL_7D: ;
            }
            catch (Exception serviceException)
            {
                do
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
                while (6 == 0);
            }
            this.GetSeperatorRFIDTagDetails();
        }

        private void clearControls()
        {
            if (false)
            {
                goto IL_15;
            }
        IL_04:
            if (6 == 0)
            {
                goto IL_24;
            }
            this.txtSeperatortxtTag.Text = string.Empty;
        IL_15:
            if (!false)
            {
                this.cmbLocation.SelectedIndex = 0;
            }
        IL_24:
            if (!false)
            {
                return;
            }
            goto IL_04;
        }

        private void btnReportearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime? value = this.dtFromRpt.Value;
                if (!value.HasValue)
                {
                    System.Windows.MessageBox.Show("Please enter from date", "Spectra Photo");
                }
                else
                {
                    value = this.dtToRpt.Value;
                    if (!value.HasValue)
                    {
                        System.Windows.MessageBox.Show("Please enter to date", "Spectra Photo");
                    }
                    else if (this.dtFromRpt.Value.ToDateTime(false) > this.dtToRpt.Value.ToDateTime(false))
                    {
                        System.Windows.MessageBox.Show("From date is not greater than to date", "Spectra Photo");
                    }
                    else
                    {
                        int? num = new int?(this.cmbPhotographerRpt.SelectedValue.ToInt32(false));
                        if (num == 0)
                        {
                            num = null;
                        }
                        DateTime dateTime = this.dtFromRpt.Value.ToDateTime(false);
                        DateTime dateTime2 = this.dtToRpt.Value.ToDateTime(false);
                        this.Dg_PhotographerReport.ItemsSource = new RfidBusiness().GetPhotographerRFIDAssociation(num, dateTime, dateTime2);
                    }
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void FillPhotoGraphersListForreport()
        {
            do
            {
                List<UserInfo> photoGraphersList = new UserBusiness().GetPhotoGraphersList();
                do
                {
                    CommonUtility.BindComboWithSelect<UserInfo>(this.cmbPhotographerRpt, photoGraphersList, "Photographer", "UserId", 0, "Select All");
                }
                while (false || !true || false);
                this.cmbPhotographerRpt.SelectedIndex = 0;
            }
            while (false);
        }

        void IStyleConnector.Connect(int connectionId, object target)
        {
            int num;
            int arg_44_0;
            int arg_44_1;
            do
            {
                int arg_CE_0 = connectionId;
                int expr_D4;
                do
                {
                    num = arg_CE_0;
                    expr_D4 = (arg_44_0 = (arg_CE_0 = num));
                }
                while (false);
                int expr_15 = arg_44_1 = 16;
                if (expr_15 == 0)
                {
                    goto IL_44;
                }
                if (expr_D4 > expr_15)
                {
                    goto IL_31;
                }
                if (num == 11)
                {
                    goto IL_4E;
                }
                if (num != 16)
                {
                    break;
                }
                ((Button)target).Click += new RoutedEventHandler(this.btnDeleteSeperatorTag_Click);
            }
            while (7 == 0);
            return;
        IL_31:
            int arg_38_0 = num;
            while (arg_38_0 != 27)
            {
                arg_44_0 = (arg_38_0 = num);
                if (!false)
                {
                    arg_44_1 = 44;
                    goto IL_44;
                }
            }
            ((Button)target).Click += new RoutedEventHandler(this.btnDetails_Click);
            return;
        IL_44:
            if (arg_44_0 != arg_44_1 && true)
            {
                return;
            }
            ((CheckBox)target).Click += new RoutedEventHandler(this.chkSelectedimages_Click);
            if (5 != 0)
            {
                return;
            }
            return;
        IL_4E:
            ((Button)target).Click += new RoutedEventHandler(this.btnDeleteTag_Click);
        }
    }
}
