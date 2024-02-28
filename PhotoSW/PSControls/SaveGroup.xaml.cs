using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.Data;
using ErrorHandler;
using FrameworkHelper;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using DigiPhoto;
using PhotoSW.Views;

namespace PhotoSW.PSControls
{
    public partial class SaveGroup : UserControl, IComponentConnector, IDisposable
    {
        public bool overwrite = false;

        private Dictionary<string, string> lstSubStore;

        private EventHandler executeParentMethod;

        public event EventHandler ExecuteParentMethod
        {
            add
            {
                do
                {
                IL_00:
                    EventHandler eventHandler = this.executeParentMethod;
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
                            eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.executeParentMethod, value2, eventHandler2);
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
                    EventHandler eventHandler = this.executeParentMethod;
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
                            eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.executeParentMethod, value2, eventHandler2);
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
        private EventHandler executeGroupMethod;
        public event EventHandler ExecuteGroupMethod
        {
            add
            {
                do
                {
                IL_00:
                    EventHandler eventHandler = this.executeGroupMethod;
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
                            eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.executeGroupMethod, value2, eventHandler2);
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
                    EventHandler eventHandler = this.executeGroupMethod;
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
                            eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.executeGroupMethod, value2, eventHandler2);
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

        public SaveGroup()
        {
            this.InitializeComponent();
            this.ClearControls();
            this.FillSubstore();
        }

        public void Dispose()
        {
            Window window;
            do
            {
                window = Window.GetWindow(this);
                bool flag;
                do
                {
                    flag = (window == null);
                }
                while (false);
                if (flag)
                {
                    goto IL_42;
                }
            }
            while (false);
            if (!false)
            {
                ((SearchResult)window).grdCotrol.Children.Remove(this);
                ((SearchResult)window).ModalDialog = null;
                if (2 != 0)
                {
                }
            }
        IL_42:
            if (!false)
            {
                GC.SuppressFinalize(this);
            }
        }

        private void FillSubstore()
        {
            do
            {
                try
                {
                    if (8 != 0)
                    {
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
            }
            while (false);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
        }

        protected virtual void OnExecuteMethodML()
        {
            while (true)
            {
                bool arg_17_0;
                bool arg_34_0 = arg_17_0 = (this.executeParentMethod == null);
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
                this.executeParentMethod(this, EventArgs.Empty);
            IL_2D:
                if (8 != 0)
                {
                    break;
                }
                goto IL_19;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            base.Visibility = Visibility.Collapsed;
            this.OnExecuteMethodML();
        }

        protected virtual void OnExecuteGroupMethod()
        {
            while (true)
            {
                bool arg_17_0;
                bool arg_34_0 = arg_17_0 = (this.executeGroupMethod == null);
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
                this.executeGroupMethod(this, EventArgs.Empty);
            IL_2D:
                if (8 != 0)
                {
                    break;
                }
                goto IL_19;
            }
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

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                this.OnExecuteMethod();
                while (true)
                {
                    if (8 != 0)
                    {
                    }
                    if (false)
                    {
                        break;
                    }
                    this.OnExecuteMethodML();
                    do
                    {
                        base.Visibility = Visibility.Collapsed;
                    }
                    while (7 == 0);
                    this.Dispose();
                    if (!false)
                    {
                        return;
                    }
                }
            }
        }

        private void AddGroup()
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (LstMyItems current in RobotImageLoader.GroupImages)
                {
                    dictionary.Add(current.PhotoId.ToString(), current.Name);
                }
                new PhotoBusiness().SaveGroupData(dictionary, this.txtGroupName.Text, Convert.ToInt32(this.cmbSubStoreName.SelectedValue));
                MessageBox.Show("Group Saved Successfully!");
                RobotImageLoader.SearchCriteria = "Group";
                RobotImageLoader.GroupId = this.txtGroupName.Text;
                RobotImageLoader.LoadImages();
                this.OnExecuteGroupMethod();
                base.Visibility = Visibility.Collapsed;
                this.SaveButton.IsDefault = false;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            bool flag = !this.CheckValidationsGroup();
            if (!flag)
            {
                if (5 != 0)
                {
                    flag = (this.RadioStack.Visibility != Visibility.Visible);
                }
                bool arg_6A_0;
                if (flag)
                {
                    if (!false)
                    {
                        bool expr_C7 = arg_6A_0 = !string.IsNullOrEmpty(this.txtGroupName.Text);
                        if (!true)
                        {
                            goto IL_6A;
                        }
                        if (!expr_C7)
                        {
                            MessageBox.Show("Please enter group name");
                            goto IL_150;
                        }
                        while (!false)
                        {
                            DG_PhotoGroupInfo groupName = new PhotoBusiness().GetGroupName(this.txtGroupName.Text);
                            if (groupName == null)
                            {
                                goto IL_105;
                            }
                            this.cmbSubStoreName.SelectedValue = groupName.DG_SubstoreId.ToString();
                            if (4 != 0)
                            {
                                this.tbErrorMsg.Visibility = Visibility.Visible;
                                this.RadioStack.Visibility = Visibility.Visible;
                                goto IL_148;
                            }
                        }
                        goto IL_9C;
                    }
                IL_105:
                    this.AddGroup();
                IL_148:
                    this.OnExecuteMethodML();
                IL_150:
                    goto IL_151;
                }
                bool? isChecked = this.rdbAddimg.IsChecked;
            IL_53:
                arg_6A_0 = !(isChecked == true);
            IL_6A:
                if (!arg_6A_0)
                {
                    this.AddGroup();
                }
                else if (true)
                {
                    new PhotoBusiness().DeletePhotoGroupByName(this.txtGroupName.Text);
                    if (false)
                    {
                        goto IL_53;
                    }
                    this.AddGroup();
                }
            IL_9C:
                this.Dispose();
                this.OnExecuteMethodML();
            IL_151: ;
            }
        }

        public void ClearControls()
        {
            UIElement expr_06 = this.GrdDetails;
            int expr_0B = 0;
            if (4 != 0)
            {
                Grid.SetRow(expr_06, expr_0B);
            }
            this.btnAdd.Visibility = Visibility.Collapsed;
            this.btnClear.Visibility = Visibility.Visible;
            this.StackSave.Visibility = Visibility.Visible;
            this.GrdDetails.Visibility = Visibility.Visible;
            this.tbErrorMsg.Visibility = Visibility.Collapsed;
            this.RadioStack.Visibility = Visibility.Collapsed;
           
            this.txtGroupName.Focus();
            this.txtGroupName.Text = string.Empty;
            List<SubStoresInfo> allSubstoreName = new StoreSubStoreDataBusniess().GetAllSubstoreName();
            CommonUtility.BindComboWithSelect<SubStoresInfo>(this.cmbSubStoreName, allSubstoreName, "DG_SubStore_Name", "DG_SubStore_pkey", 0, ClientConstant.SelectString);
            this.cmbSubStoreName.SelectedValue = LoginUser.SubStoreId.ToString();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtGroupName.Focus();
        }

        private bool CheckValidationsGroup()
        {
            bool flag;
            bool arg_42_0;
            bool arg_3E_0;
            do
            {
                flag = true;
                bool flag2;
                if (!false)
                {
                    bool expr_1A = arg_3E_0 = (arg_42_0 = !(this.cmbSubStoreName.SelectedValue.ToString() == "0"));
                    if (false)
                    {
                        return arg_42_0;
                    }
                    if (8 == 0)
                    {
                        goto IL_3E;
                    }
                    flag2 = expr_1A;
                }
                if (flag2)
                {
                    break;
                }
                if (!false)
                {
                }
                MessageBox.Show("Please enter SubStore name.");
                bool expr_34 = false;
                if (!false)
                {
                    flag = expr_34;
                }
            }
            while (false);
            arg_3E_0 = flag;
        IL_3E:
            bool flag3 = arg_3E_0;
            arg_42_0 = flag3;
            return arg_42_0;
        }


    }
}
