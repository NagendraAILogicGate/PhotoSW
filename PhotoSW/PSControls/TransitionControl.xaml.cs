using PhotoSW.Interop;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace PhotoSW.PSControls
{
    public partial class TransitionControl : UserControl, IComponentConnector, IStyleConnector
    {
        private UIElement _parent;

        private bool _result = false;

        public List<TransitionProperty> tpLst = new List<TransitionProperty>();

        private long EditTransitionID = 0L;

        private bool IsTransitionEdit = false;

        private string a;

        private int i = 1;


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

        public TransitionControl()
        {
            this.InitializeComponent();
            base.Visibility = Visibility.Hidden;
            this.cbTransitionName.SelectedIndex = 0;
        }

        public void TransitionControlListAutoFill(List<TransitionProperty> tpLstMain)
        {
            if (-1 != 0 && 8 != 0)
            {
                if (true)
                {
                    if (7 == 0)
                    {
                        return;
                    }
                    this.tpLst = tpLstMain;
                    this.DGManageTransition.ItemsSource = this.tpLst;
                }
            }
            this.DGManageTransition.Items.Refresh();
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

        public bool ShowPanHandlerDialog()
        {
            bool result;
            if (-1 != 0)
            {
                if (8 != 0 && true)
                {
                    if (7 == 0)
                    {
                        return result;
                    }
                    base.Visibility = Visibility.Visible;
                    this._parent.IsEnabled = false;
                }
            }
            result = this._result;
            return result;
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

        private void btnDeleteTransitionSlots_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            long SlotId = long.Parse(button.Tag.ToString());
            MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to delete record?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                this.tpLst.RemoveAll((TransitionProperty o) => (long)o.ID == SlotId);
                MessageBox.Show("Item deleted Successfully", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                this.DGManageTransition.ItemsSource = this.tpLst;
                this.DGManageTransition.Items.Refresh();
            }
        }

        private void txtnumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool arg_70_0;
            if (!false)
            {
                if (false)
                {
                    goto IL_B4;
                }
                bool arg_1F_0 = string.IsNullOrEmpty(((TextBox)sender).Text);
                bool expr_F3;
                do
                {
                    bool flag = !arg_1F_0;
                    expr_F3 = (arg_1F_0 = (arg_70_0 = flag));
                    if (8 == 0)
                    {
                        goto IL_69;
                    }
                }
                while (false);
                if (!expr_F3)
                {
                    this.a = "";
                    if (5 != 0)
                    {
                        return;
                    }
                }
            }
            int num = 0;
            bool flag2 = int.TryParse(((TextBox)sender).Text, out num);
            arg_70_0 = flag2;
        IL_69:
            bool arg_77_0;
            bool expr_70 = arg_77_0 = (arg_70_0 & num >= 0);
            if (-1 != 0)
            {
                arg_77_0 = !expr_70;
            }
            if (!arg_77_0)
            {
                ((TextBox)sender).Text.Trim();
                this.a = ((TextBox)sender).Text;
                return;
            }
            ((TextBox)sender).Text = this.a;
        IL_B4:
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
        }

        private bool CheckSlotValidations()
        {
            bool result=false;
            while (!string.IsNullOrEmpty(this.edTransStartTime.Text.Trim()))
            {
                if (!false)
                {
                    int arg_3C_0;
                    bool arg_9C_0 = (arg_3C_0 = (string.IsNullOrEmpty(this.edTransStopTime.Text.Trim()) ? 1 : 0)) != 0;
                    if (4 == 0)
                    {
                        goto IL_9C;
                    }
                    int arg_3C_1 = 0;
                IL_3C:
                    bool arg_108_0 = arg_3C_0 == arg_3C_1;
                IL_44:
                    if (!arg_108_0)
                    {
                        MessageBox.Show("Start time and end time can not be zero or null.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else
                    {
                        int expr_78 = arg_3C_0 = Convert.ToInt32(this.edTransStartTime.Text.Trim());
                        int expr_8D = arg_3C_1 = Convert.ToInt32(this.edTransStopTime.Text.Trim());
                        if (7 != 0)
                        {
                            bool flag = expr_78 != expr_8D;
                            arg_9C_0 = flag;
                            goto IL_9C;
                        }
                        goto IL_3C;
                    }
                IL_61:
                    result = false;
                    if (3 != 0)
                    {
                        return result;
                    }
                    goto IL_B2;
                IL_9C:
                    if (!arg_9C_0)
                    {
                        MessageBox.Show("Start time should be less than end time.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                    else
                    {
                        if (!false)
                        {
                            result = true;
                            return result;
                        }
                        goto IL_61;
                    }
                IL_B2:
                    result = false;
                    return result;
                }
            }
            if (!false)
            {
                bool arg_108_0 = false;
                //goto IL_44;
            }
            return result;
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

        private void cbTransition_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void btAddTransition_Click(object sender, RoutedEventArgs e)
        {
            if (!false)
            {
                TransitionProperty transitionProperty = new TransitionProperty();
                int stopTime = 0;
                int startTime;
                bool arg_F4_0;
                bool flag;
                MessageBoxResult messageBoxResult;
                do
                {
                    startTime = 0;
                    bool expr_310 = arg_F4_0 = string.IsNullOrEmpty(this.edTransStartTime.Text);
                    if (false)
                    {
                        goto IL_F4;
                    }
                    if (!expr_310)
                    {
                        startTime = Convert.ToInt32(this.edTransStartTime.Text);
                    }
                    flag = string.IsNullOrEmpty(this.edTransStopTime.Text);
                    bool expr_6B = arg_F4_0 = flag;
                    if (!true)
                    {
                        goto IL_F4;
                    }
                    if (!expr_6B)
                    {
                        stopTime = Convert.ToInt32(this.edTransStopTime.Text);
                    }
                    if (!(this.cbTransition.IsChecked == true))
                    {
                        goto IL_2C6;
                    }
                    if (!this.IsTransitionEdit)
                    {
                        goto IL_1F9;
                    }
                    this.IsTransitionEdit = false;
                    messageBoxResult = MessageBox.Show("Would you like to save changes?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Question);
                }
                while (false);
                flag = (messageBoxResult != MessageBoxResult.Yes);
                arg_F4_0 = flag;
            IL_F4:
                if (!arg_F4_0)
                {
                    transitionProperty = (from o in this.tpLst
                                          where (long)o.ID == this.EditTransitionID
                                          select o).FirstOrDefault<TransitionProperty>();
                    if (!false)
                    {
                        this.tpLst.Remove(transitionProperty);
                        if (this.IsValidTransitionSlot(this.tpLst, startTime, stopTime))
                        {
                            transitionProperty.TransitionName = this.cbTransitionName.Text;
                            transitionProperty.TransitionStartTime = Convert.ToInt32(this.edTransStartTime.Text);
                            transitionProperty.TransitionStopTime = Convert.ToInt32(this.edTransStopTime.Text);
                            this.tpLst.Add(transitionProperty);
                            this.EditTransitionID = 0L;
                            if (false)
                            {
                                goto IL_2C4;
                            }
                        }
                        else
                        {
                            this.tpLst.Add(transitionProperty);
                        }
                    }
                }
                else
                {
                    this.edTransStartTime.Text = "0";
                    this.edTransStopTime.Text = "0";
                    this.cbTransitionName.SelectedIndex = 0;
                    this.EditTransitionID = 0L;
                }
                goto IL_27C;
            IL_1F9:
                if (this.IsValidTransitionSlot(this.tpLst, startTime, stopTime))
                {
                    transitionProperty.ID = this.i;
                    transitionProperty.TransitionName = this.cbTransitionName.Text;
                    transitionProperty.TransitionStartTime = Convert.ToInt32(this.edTransStartTime.Text);
                    transitionProperty.TransitionStopTime = Convert.ToInt32(this.edTransStopTime.Text);
                    this.tpLst.Add(transitionProperty);
                    this.i++;
                }
            IL_27C:
                this.DGManageTransition.ItemsSource = from o in this.tpLst
                                                      orderby o.TransitionStartTime
                                                      select o;
                this.DGManageTransition.Items.Refresh();
            IL_2C4:
                return;
            IL_2C6:
                MessageBox.Show("Please enable the transition effect.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        private void UnsubscribeEvents()
        {
            if (false)
            {
                goto IL_47;
            }
            this.cbTransition.Checked -= new RoutedEventHandler(this.cbTransition_Checked);
            this.edTransStopTime.TextChanged -= new TextChangedEventHandler(this.txtnumber_TextChanged);
        IL_43:
            if (false)
            {
                goto IL_97;
            }
        IL_47:
            this.edTransStartTime.TextChanged -= new TextChangedEventHandler(this.txtnumber_TextChanged);
            this.btAddTransition.Click -= new RoutedEventHandler(this.btAddTransition_Click);
            this.btnClose.Click -= new RoutedEventHandler(this.btnClose_Click);
        IL_97:
            int arg_AB_0;
            int expr_9D = arg_AB_0 = this.tpLst.Count;
            if (!false)
            {
                arg_AB_0 = ((expr_9D <= 0) ? 1 : 0);
            }
            bool flag = arg_AB_0 != 0;
            if (-1 != 0)
            {
                if (!flag)
                {
                    this.tpLst.Clear();
                }
                return;
            }
            goto IL_43;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            this.UnsubscribeEvents();
        }

        private void btnEditTransitionSlots_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                Button button = (Button)sender;
                this.EditTransitionID = long.Parse(button.Tag.ToString());
                if (!false)
                {
                    TransitionProperty transitionProperty = (from o in this.tpLst
                                                             where (long)o.ID == this.EditTransitionID
                                                             select o).FirstOrDefault<TransitionProperty>();
                    while (true)
                    {
                        this.edTransStartTime.Text = transitionProperty.TransitionStartTime.ToString();
                        this.edTransStopTime.Text = transitionProperty.TransitionStopTime.ToString();
                        if (false)
                        {
                            break;
                        }
                        this.cbTransitionName.Text = transitionProperty.TransitionName;
                        if (6 != 0)
                        {
                            if (true)
                            {
                                goto Block_4;
                            }
                            break;
                        }
                    }
                }
            }
        Block_4:
            this.IsTransitionEdit = true;
        }

        public bool IsValidTransitionSlot(List<TransitionProperty> slotList, int startTime, int stopTime)
        {
            int arg_75_0;
            bool expr_27C = (arg_75_0 = (string.IsNullOrEmpty(this.edTransStartTime.Text.Trim()) ? 1 : 0)) != 0;
            bool result;
            if (!false)
            {
                bool arg_5A_0;
                if (expr_27C)
                {
                    arg_5A_0 = false;
                    goto IL_59;
                }
                int arg_54_0 = string.IsNullOrEmpty(this.edTransStopTime.Text.Trim()) ? 1 : 0;
            IL_53:
                arg_5A_0 = (arg_54_0 == 0);
            IL_59:
                if (!arg_5A_0)
                {
                    MessageBox.Show("Start time and end time can not be zero or null.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    arg_75_0 = 0;
                }
                else
                {
                    if (Convert.ToInt32(this.edTransStartTime.Text.Trim()) == Convert.ToInt32(this.edTransStopTime.Text.Trim()))
                    {
                        if (!false)
                        {
                            MessageBox.Show("Start time should be less than end time.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        }
                        result = false;
                        return result;
                    }
                    TransitionProperty transitionProperty = (from o in slotList
                                                             orderby o.TransitionStartTime
                                                             select o).FirstOrDefault<TransitionProperty>();
                    TransitionProperty transitionProperty2 = (from o in slotList
                                                              orderby o.TransitionStartTime
                                                              select o).LastOrDefault<TransitionProperty>();
                    bool flag = transitionProperty == null;
                    if (8 != 0)
                    {
                        if (!flag)
                        {
                            if (stopTime <= transitionProperty.TransitionStartTime)
                            {
                                result = true;
                                return result;
                            }
                            if (startTime < transitionProperty2.TransitionStopTime)
                            {
                                List<TransitionProperty> list = (from o in slotList
                                                                 orderby o.TransitionStartTime
                                                                 select o).ToList<TransitionProperty>();
                                TransitionProperty item = list.Where(delegate(TransitionProperty o)
                                {
                                    int arg_0E_0;
                                    int arg_14_0 = arg_0E_0 = o.TransitionStopTime;
                                    int arg_14_1;
                                    do
                                    {
                                        int expr_06 = arg_14_1 = startTime;
                                        if (false)
                                        {
                                            goto IL_14;
                                        }
                                        arg_14_0 = (arg_0E_0 = ((arg_0E_0 > expr_06) ? 1 : 0));
                                    }
                                    while (false);
                                    arg_14_1 = 0;
                                IL_14:
                                    bool arg_22_0;
                                    bool expr_14 = arg_22_0 = (arg_14_0 == arg_14_1);
                                    if (!false)
                                    {
                                        bool flag2 = expr_14;
                                        while (false)
                                        {
                                        }
                                        arg_22_0 = flag2;
                                    }
                                    return arg_22_0;
                                }).LastOrDefault<TransitionProperty>();
                                TransitionProperty transitionProperty3 = list[list.IndexOf(item) + 1];
                                if (transitionProperty3 == null)
                                {
                                    MessageBox.Show("Selected effect is already applied in the given time frame.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                    if (8 != 0)
                                    {
                                        if (6 != 0)
                                        {
                                            result = false;
                                            return result;
                                        }
                                        goto IL_1FC;
                                    }
                                }
                                if (4 == 0)
                                {
                                    goto IL_234;
                                }
                                if (transitionProperty3.TransitionStartTime >= stopTime)
                                {
                                    result = true;
                                    return result;
                                }
                            IL_1FC:
                                goto IL_1FD;
                            }
                            int expr_16A = arg_54_0 = 1;
                            if (expr_16A != 0)
                            {
                                result = (expr_16A != 0);
                                return result;
                            }
                            goto IL_53;
                        }
                    IL_234:
                        result = true;
                        return result;
                    }
                IL_1FD:
                    MessageBox.Show("Selected effect is already applied in the given time frame.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    result = false;
                    return result;
                }
            }
            result = (arg_75_0 != 0);
            return result;
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
                    arg_16_0 = connectionId - 10;
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
                        ((Button)target).Click += new RoutedEventHandler(this.btnEditTransitionSlots_Click);
                        break;
                    case 1:
                        if (!false)
                        {
                            ((Button)target).Click += new RoutedEventHandler(this.btnDeleteTransitionSlots_Click);
                        }
                        break;
                }
                goto IL_23;
            }
        }
    }
}
