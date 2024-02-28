using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
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
    public partial class PanControl : UserControl, IComponentConnector, IStyleConnector
    {
        private UIElement _parent;

        private bool _result = false;

        public List<PanProperty> ppLst = new List<PanProperty>();

        private int ppID = 101;

        private int pandestfocuswidth = 300;

        private int panDestFocusHeight = 250;

        public List<VideoTemplateInfo.VideoSlot> slotList;

        public int videoExpLen = 0;

        private int EditedPanID = 0;

        private bool IsPanEdit = false;


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

        public PanControl()
        {
            this.InitializeComponent();
            base.Visibility = Visibility.Hidden;
            int num = ConfigManager.IMIXConfigurations.ContainsKey(43L) ? Convert.ToInt32(ConfigManager.IMIXConfigurations[43L]) : 720;
            int num2 = ConfigManager.IMIXConfigurations.ContainsKey(42L) ? Convert.ToInt32(ConfigManager.IMIXConfigurations[42L]) : 576;
            this.edPanSourceLeft.Text = "0";
            this.edPanSourceTop.Text = "0";
            this.edPanSourceWidth.Text = num.ToString();
            this.edPanSourceHeight.Text = num2.ToString();
            this.edPanDestLeft.Text = this.pandestfocuswidth.ToString();
            this.edPanDestTop.Text = "0";
            this.edPanDestWidth.Text = (num - this.pandestfocuswidth).ToString();
            this.edPanDestHeight.Text = (num2 - this.panDestFocusHeight).ToString();
        }

        public void PanControlListAutoFill(List<PanProperty> ppLstMain)
        {
            if (-1 != 0 && 8 != 0)
            {
                if (true)
                {
                    if (7 == 0)
                    {
                        return;
                    }
                    this.ppLst = ppLstMain;
                    this.DGManagePan.ItemsSource = this.ppLst;
                }
            }
            this.DGManagePan.Items.Refresh();
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
            base.Visibility = Visibility.Visible;
            this._parent.IsEnabled = false;
            this.txtPanStopTime.Text = this.videoExpLen.ToString();
            bool flag = this.videoExpLen <= 0;
            bool result=false;
            if (!false)
            {
                if (!flag)
                {
                    goto IL_54;
                }
                do
                {
                IL_69:
                    bool arg_89_0;
                    if (this.slotList != null)
                    {
                        arg_89_0 = (this.slotList.Count <= 0);
                        if (!false)
                        {
                        }
                    }
                    else
                    {
                        arg_89_0 = true;
                    }
                    if (arg_89_0)
                    {
                        goto IL_A1;
                    }
                }
                while (false);
                this.btnDefaultPan.Visibility = Visibility.Visible;
                goto IL_B3;
            IL_A1:
                if (!true)
                {
                    goto IL_54;
                }
                this.btnDefaultPan.Visibility = Visibility.Collapsed;
            IL_B3:
                if (true)
                {
                    result = this._result;
                    return result;
                }
            IL_54:
                this.RangeSliderPan.Maximum = (double)this.videoExpLen;
                //goto IL_69;
            }
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            PanProperty panProperty;
            int stopTime;
            int startTime;
            bool flag;
            if (7 != 0)
            {
                panProperty = new PanProperty();
                int expr_14 = 0;
                if (!false)
                {
                    stopTime = expr_14;
                }
                startTime = 0;
                flag = string.IsNullOrEmpty(this.txtPanStartTime.Text);
            }
            if (!flag)
            {
                startTime = Convert.ToInt32(this.txtPanStartTime.Text);
            }
            bool arg_135_0;
            do
            {
                flag = string.IsNullOrEmpty(this.txtPanStopTime.Text);
                if (!flag)
                {
                    stopTime = Convert.ToInt32(this.txtPanStopTime.Text);
                }
                flag = !(this.cbPan.IsChecked == true);
                if (flag)
                {
                    goto IL_3CE;
                }
                flag = !this.IsPanEdit;
                if (flag)
                {
                    goto IL_252;
                }
                this.IsPanEdit = false;
                MessageBoxResult messageBoxResult = MessageBox.Show("Would you like to save changes?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Question);
                bool expr_DB = arg_135_0 = (messageBoxResult != MessageBoxResult.Yes);
                if (false)
                {
                    goto IL_135;
                }
                flag = expr_DB;
                if (flag)
                {
                    goto IL_24C;
                }
                panProperty = (from o in this.ppLst
                               where o.PanID == this.EditedPanID
                               select o).FirstOrDefault<PanProperty>();
                this.ppLst.Remove(panProperty);
            }
            while (false);
            arg_135_0 = !this.CheckSlotValidations(this.ppLst, startTime, stopTime);
        IL_135:
            flag = arg_135_0;
            if (!flag)
            {
                panProperty.PanStartTime = Convert.ToInt32(this.txtPanStartTime.Text);
                panProperty.PanStopTime = Convert.ToInt32(this.txtPanStopTime.Text);
                if (!false)
                {
                    panProperty.PanSourceLeft = Convert.ToInt32(this.edPanSourceLeft.Text);
                    panProperty.PanSourceTop = Convert.ToInt32(this.edPanSourceTop.Text);
                    if (7 == 0)
                    {
                        goto IL_367;
                    }
                    panProperty.PanSourceWidth = Convert.ToInt32(this.edPanSourceWidth.Text);
                }
                panProperty.PanSourceHeight = Convert.ToInt32(this.edPanSourceHeight.Text);
                panProperty.PanDestLeft = Convert.ToInt32(this.edPanDestLeft.Text);
                panProperty.PanDestTop = Convert.ToInt32(this.edPanDestTop.Text);
                panProperty.PanDestWidth = Convert.ToInt32(this.edPanDestWidth.Text);
                panProperty.PanDestHeight = Convert.ToInt32(this.edPanDestHeight.Text);
                this.ppLst.Add(panProperty);
            }
            else
            {
                this.ppLst.Add(panProperty);
            }
        IL_24C:
            goto IL_384;
        IL_252:
            flag = !this.CheckSlotValidations(this.ppLst, startTime, stopTime);
            if (flag)
            {
                goto IL_383;
            }
            panProperty.PanID = this.ppID;
            panProperty.PanStartTime = Convert.ToInt32(this.txtPanStartTime.Text);
            if (false)
            {
                goto IL_382;
            }
            panProperty.PanStopTime = Convert.ToInt32(this.txtPanStopTime.Text);
            panProperty.PanSourceLeft = Convert.ToInt32(this.edPanSourceLeft.Text);
            panProperty.PanSourceTop = Convert.ToInt32(this.edPanSourceTop.Text);
            panProperty.PanSourceWidth = Convert.ToInt32(this.edPanSourceWidth.Text);
            panProperty.PanSourceHeight = Convert.ToInt32(this.edPanSourceHeight.Text);
            panProperty.PanDestLeft = Convert.ToInt32(this.edPanDestLeft.Text);
            panProperty.PanDestTop = Convert.ToInt32(this.edPanDestTop.Text);
            panProperty.PanDestWidth = Convert.ToInt32(this.edPanDestWidth.Text);
            panProperty.PanDestHeight = Convert.ToInt32(this.edPanDestHeight.Text);
        IL_367:
            this.ppLst.Add(panProperty);
            this.ppID++;
        IL_382:
        IL_383:
        IL_384:
            this.DGManagePan.ItemsSource = from o in this.ppLst
                                           orderby o.PanStartTime
                                           select o;
            this.DGManagePan.Items.Refresh();
            goto IL_3E3;
        IL_3CE:
            MessageBox.Show("Please enable the pan effect.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        IL_3E3:
            this.ResetToDefault();
        }

        private void btnDeletePanSlots_Click(object sender, RoutedEventArgs e)
		{
			if (-1 != 0)
			{
                //PanControl.<>c__DisplayClass6 expr_B2 = new PanControl.<>c__DisplayClass6();
                //PanControl.<>c__DisplayClass6 <>c__DisplayClass;
                //if (3 != 0)
                //{
                //    <>c__DisplayClass = expr_B2;
                //}
				Button button = (Button)sender;
				
                long SlotId = long.Parse(button.Tag.ToString());
				MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to delete record?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Question);
				bool arg_60_0 = messageBoxResult != MessageBoxResult.Yes;
				if (!false)
				{
					if (arg_60_0)
					{
						return;
					}
					this.ppLst.RemoveAll((PanProperty o) => (long)o.PanID == SlotId);
				}
			}
			this.DGManagePan.ItemsSource = this.ppLst;
			this.DGManagePan.Items.Refresh();
		}

        private void txtnumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text;
            do
            {
                text = string.Empty;
            }
            while (false);
            if (!string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                int num = 0;
                if (true)
                {
                    bool flag = int.TryParse(((TextBox)sender).Text, out num);
                    bool arg_6F_0 = flag;
                    int arg_64_0 = num;
                    bool arg_6F_1;
                    bool expr_64;
                    do
                    {
                        expr_64 = ((arg_64_0 = ((arg_6F_1 = (arg_64_0 < 0)) ? 1 : 0)) != 0);
                        if (false)
                        {
                            goto IL_6F;
                        }
                    }
                    while (false);
                    arg_6F_1 = !expr_64;
                IL_6F:
                    if (!(arg_6F_0 & arg_6F_1))
                    {
                        goto IL_99;
                    }
                }
                ((TextBox)sender).Text.Trim();
                text = ((TextBox)sender).Text;
                goto IL_C6;
            IL_99:
                ((TextBox)sender).Text = text;
                if (3 == 0)
                {
                    return;
                }
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
            IL_C6:
                if (false)
                {
                    goto IL_99;
                }
            }
        }

        private bool CheckSlotValidations(List<PanProperty> slotList, int startTime, int stopTime)
        {
            int arg_75_0;
            bool expr_27C = (arg_75_0 = (string.IsNullOrEmpty(this.txtPanStartTime.Text.Trim()) ? 1 : 0)) != 0;
            bool result;
            if (!false)
            {
                bool arg_5A_0;
                if (expr_27C)
                {
                    arg_5A_0 = false;
                    goto IL_59;
                }
                int arg_54_0 = string.IsNullOrEmpty(this.txtPanStopTime.Text.Trim()) ? 1 : 0;
            IL_53:
                arg_5A_0 = (arg_54_0 == 0);
            IL_59:
                if (!arg_5A_0)
                {
                    MessageBox.Show("Enter value for start time or end time.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    arg_75_0 = 0;
                }
                else
                {
                    if (Convert.ToInt32(this.txtPanStartTime.Text.Trim()) == Convert.ToInt32(this.txtPanStopTime.Text.Trim()))
                    {
                        if (!false)
                        {
                            MessageBox.Show("Start time and stop time can not be same.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        }
                        result = false;
                        return result;
                    }
                    PanProperty panProperty = (from o in slotList
                                               orderby o.PanStartTime
                                               select o).FirstOrDefault<PanProperty>();
                    PanProperty panProperty2 = (from o in slotList
                                                orderby o.PanStartTime
                                                select o).LastOrDefault<PanProperty>();
                    bool flag = panProperty == null;
                    if (8 != 0)
                    {
                        if (!flag)
                        {
                            if (stopTime <= panProperty.PanStartTime)
                            {
                                result = true;
                                return result;
                            }
                            if (startTime < panProperty2.PanStopTime)
                            {
                                List<PanProperty> list = (from o in slotList
                                                          orderby o.PanStartTime
                                                          select o).ToList<PanProperty>();
                                PanProperty item = list.Where(delegate(PanProperty o)
                                {
                                    int arg_0E_0;
                                    int arg_14_0 = arg_0E_0 = o.PanStopTime;
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
                                }).LastOrDefault<PanProperty>();
                                PanProperty panProperty3 = list[list.IndexOf(item) + 1];
                                if (panProperty3 == null)
                                {
                                    MessageBox.Show("Effect is already applied in the given time frame.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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
                                if (panProperty3.PanStartTime >= stopTime)
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
                    MessageBox.Show("Effect is already applied in the given time frame.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    result = false;
                    return result;
                }
            }
            result = (arg_75_0 != 0);
            return result;
        }

        private void UnsubscribeEvents()
        {
            this.txtPanStopTime.TextChanged -= new TextChangedEventHandler(this.txtnumber_TextChanged);
            this.txtPanStartTime.TextChanged -= new TextChangedEventHandler(this.txtnumber_TextChanged);
            this.edPanSourceLeft.TextChanged -= new TextChangedEventHandler(this.txtnumber_TextChanged);
            this.edPanSourceTop.TextChanged -= new TextChangedEventHandler(this.txtnumber_TextChanged);
            this.edPanSourceHeight.TextChanged -= new TextChangedEventHandler(this.txtnumber_TextChanged);
            this.edPanSourceWidth.TextChanged -= new TextChangedEventHandler(this.txtnumber_TextChanged);
            this.edPanDestLeft.TextChanged -= new TextChangedEventHandler(this.txtnumber_TextChanged);
            this.edPanDestTop.TextChanged -= new TextChangedEventHandler(this.txtnumber_TextChanged);
            this.edPanDestHeight.TextChanged -= new TextChangedEventHandler(this.txtnumber_TextChanged);
            this.edPanDestWidth.TextChanged -= new TextChangedEventHandler(this.txtnumber_TextChanged);
            this.btnAdd.Click -= new RoutedEventHandler(this.btnAdd_Click);
            this.btnClose.Click -= new RoutedEventHandler(this.btnClose_Click);
            this.btnDefaultPan.Click -= new RoutedEventHandler(this.btnDefaultPan_Click);
            this.btnClearList.Click -= new RoutedEventHandler(this.btnClearList_Click);
            if (this.ppLst.Count > 0)
            {
                this.ppLst.Clear();
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            this.UnsubscribeEvents();
        }

        private void btnClearList_Click(object sender, RoutedEventArgs e)
        {
            bool arg_12_0;
            bool expr_09 = arg_12_0 = (this.ppLst == null);
            if (!false)
            {
                bool flag = expr_09;
                arg_12_0 = flag;
            }
            if (!arg_12_0)
            {
                do
                {
                    if (-1 != 0 && !false)
                    {
                        this.ppLst.Clear();
                    }
                    if (false)
                    {
                        break;
                    }
                    this.DGManagePan.ItemsSource = this.ppLst;
                    this.DGManagePan.Items.Refresh();
                }
                while (4 == 0);
            }
        }

        private void btnDefaultPan_Click(object sender, RoutedEventArgs e)
        {
            bool? isChecked = this.cbPan.IsChecked;
            int arg_2D_0;
            bool arg_39_0 = ((!isChecked.GetValueOrDefault()) ? (arg_2D_0 = 0) : (arg_2D_0 = (isChecked.HasValue ? 1 : 0))) != 0;
            if (!false)
            {
                bool flag = arg_2D_0 == 0;
                arg_39_0 = flag;
            }
            if (!arg_39_0)
            {
                if (6 == 0 || (this.slotList != null && this.slotList.Count > 0))
                {
                    this.ppLst.Clear();
                    this.ppID = 101;
                    for (int i = 0; i < this.slotList.Count; i++)
                    {
                        PanProperty panProperty = new PanProperty();
                        int panStartTime = Convert.ToInt32(this.slotList[i].FrameTimeIn);
                        int panStopTime = Convert.ToInt32(this.slotList[i].PhotoDisplayTime) + Convert.ToInt32(this.slotList[i].FrameTimeIn);
                        panProperty.PanID = this.ppID;
                        panProperty.PanStartTime = panStartTime;
                        panProperty.PanStopTime = panStopTime;
                        panProperty.PanSourceLeft = Convert.ToInt32(this.edPanSourceLeft.Text);
                        panProperty.PanSourceTop = Convert.ToInt32(this.edPanSourceTop.Text);
                        panProperty.PanSourceWidth = Convert.ToInt32(this.edPanSourceWidth.Text);
                        panProperty.PanSourceHeight = Convert.ToInt32(this.edPanSourceHeight.Text);
                        panProperty.PanDestLeft = Convert.ToInt32(this.edPanDestLeft.Text);
                        panProperty.PanDestTop = Convert.ToInt32(this.edPanDestTop.Text);
                        panProperty.PanDestWidth = Convert.ToInt32(this.edPanDestWidth.Text);
                        panProperty.PanDestHeight = Convert.ToInt32(this.edPanDestHeight.Text);
                        this.ppID++;
                        this.ppLst.Add(panProperty);
                    }
                    this.DGManagePan.ItemsSource = this.ppLst;
                    this.DGManagePan.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("No template selected.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Please enable the pan effect.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        private void btnEditPanSlots_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            this.EditedPanID = Convert.ToInt32(button.Tag.ToString());
            PanProperty panProperty = (from o in this.ppLst
                                       where o.PanID == this.EditedPanID
                                       select o).FirstOrDefault<PanProperty>();
            this.txtPanStartTime.Text = panProperty.PanStartTime.ToString();
            if (!false)
            {
                this.txtPanStopTime.Text = panProperty.PanStopTime.ToString();
                this.edPanSourceLeft.Text = panProperty.PanSourceLeft.ToString();
                this.edPanSourceTop.Text = panProperty.PanSourceTop.ToString();
                this.edPanSourceHeight.Text = panProperty.PanSourceHeight.ToString();
                this.edPanSourceWidth.Text = panProperty.PanSourceWidth.ToString();
                this.edPanDestHeight.Text = panProperty.PanDestHeight.ToString();
            }
            this.edPanDestLeft.Text = panProperty.PanDestLeft.ToString();
            this.edPanDestWidth.Text = panProperty.PanDestWidth.ToString();
            this.edPanDestTop.Text = panProperty.PanDestTop.ToString();
            this.IsPanEdit = true;
        }

        private void ResetToDefault()
        {
            this.edPanSourceLeft.Text = "0";
            while (true)
            {
            IL_15:
                if (true)
                {
                }
                while (true)
                {
                    this.edPanSourceTop.Text = "0";
                    while (true)
                    {
                        TextBox expr_36 = this.edPanSourceHeight;
                        string expr_3B = "480";
                        if (!false)
                        {
                            expr_36.Text = expr_3B;
                        }
                        if (-1 != 0)
                        {
                            if (!false)
                            {
                                this.edPanSourceWidth.Text = "640";
                                this.edPanDestHeight.Text = "240";
                                this.edPanDestLeft.Text = "0";
                                break;
                            }
                            goto IL_15;
                        }
                    }
                    if (!false)
                    {
                        goto Block_4;
                    }
                }
            }
        Block_4:
            this.edPanDestWidth.Text = "320";
            this.edPanDestTop.Text = "0";
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
                    arg_16_0 = connectionId - 18;
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
                        ((Button)target).Click += new RoutedEventHandler(this.btnEditPanSlots_Click);
                        break;
                    case 1:
                        if (!false)
                        {
                            ((Button)target).Click += new RoutedEventHandler(this.btnDeletePanSlots_Click);
                        }
                        break;
                }
                goto IL_23;
            }
        }
    }
}
