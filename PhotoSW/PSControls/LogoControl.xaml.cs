using PhotoSW.Interop;
using PhotoSW.Manage;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Markup;

namespace PhotoSW.PSControls
{
    public partial class LogoControl : System.Windows.Controls.UserControl, IComponentConnector, IStyleConnector
    {
        private UIElement _parent;

        private bool _result = false;

        public int videoExpLen = 0;

        public List<SlotProperty> LogoSlotList = new List<SlotProperty>();

        public int uniqueID = 51;

        private List<TemplateListItems> lstGraphics = new List<TemplateListItems>();

        public FontDialog fontDialog = new FontDialog();

        private long EditedItemId = 0L;

        private bool IsEdited = false;


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

        public int Left
        {
            get;
            set;
        }

        public int Top
        {
            get;
            set;
        }

        public LogoControl()
        {
            this.InitializeComponent();
            base.Visibility = Visibility.Hidden;
            this.fontDialog.Color = Color.White;
            this.fontDialog.Font = new Font("Arial", 32f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 204);
            this.fontDialog.ShowColor = true;
            this.cmbCheckedGraphic.SelectedIndex = 0;
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

        public void ControlListAutoFill()
        {
        IL_00:
            while (8 != 0)
            {
                do
                {
                    this.DGManageLogo.ItemsSource = this.LogoSlotList;
                    if (2 == 0)
                    {
                        goto IL_2B;
                    }
                    if (5 == 0)
                    {
                        goto IL_00;
                    }
                }
                while (false);
                CollectionView expr_3D = this.DGManageLogo.Items;
                if (3 != 0)
                {
                    expr_3D.Refresh();
                }
            IL_2B:
                break;
            }
        }

        public bool ShowPanHandlerDialog()
        {
            bool result;
            try
            {
                base.Visibility = Visibility.Visible;
                this._parent.IsEnabled = false;
                while (true)
                {
                IL_1E:
                    int arg_7D_0;
                    if (4 != 0)
                    {
                        this.lstGraphics = ((VideoEditor)Window.GetWindow(this._parent)).objTemplateList.Where(delegate(TemplateListItems o)
                        {
                            bool result2;
                            while (8 != 0)
                            {
                                bool arg_3A_0;
                                if (o.MediaType == 606)
                                {
                                    arg_3A_0 = o.IsChecked;
                                    if (2 != 0)
                                    {
                                    }
                                }
                                else
                                {
                                    if (5 == 0 || false)
                                    {
                                        continue;
                                    }
                                    arg_3A_0 = false;
                                }
                                result2 = arg_3A_0;
                                break;
                            }
                            return result2;
                        }).ToList<TemplateListItems>();
                        arg_7D_0 = this.lstGraphics.Count;
                        goto IL_7C;
                    }
                IL_E6:
                    this.txtGraphicLogoLeft.Text = this.lstGraphics.FirstOrDefault<TemplateListItems>().LeftPositon.ToString();
                    do
                    {
                        bool flag = this.videoExpLen <= 0;
                        bool expr_118 = (arg_7D_0 = (flag ? 1 : 0)) != 0;
                        if (false)
                        {
                            goto IL_7C;
                        }
                        if (!expr_118)
                        {
                            this.sldRange.Maximum = (double)this.videoExpLen;
                        }
                        this.DGManageLogo.ItemsSource = null;
                        if (-1 == 0)
                        {
                            goto IL_1E;
                        }
                        this.DGManageLogo.ItemsSource = this.LogoSlotList;
                    }
                    while (4 == 0);
                    result = this._result;
                    if (!false)
                    {
                        break;
                    }
                IL_98:
                    this.cmbCheckedGraphic.ItemsSource = this.lstGraphics;
                    this.txtStopTime.Text = this.videoExpLen.ToString();
                    this.txtGraphicLogoTop.Text = this.lstGraphics.FirstOrDefault<TemplateListItems>().TopPositon.ToString();
                    goto IL_E6;
                IL_97:
                    goto IL_98;
                IL_7C:
                    if (arg_7D_0 == 0)
                    {
                        this.chkGraphicLogo.IsChecked = new bool?(false);
                        goto IL_97;
                    }
                    goto IL_98;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
                result = this._result;
            }
            return result;
        }

        protected virtual void OnExecuteMethod()
        {
            while (true)
            {
                bool arg_17_0;
                bool arg_34_0 = arg_17_0 = (this.ExecuteMethod == null);
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
                this.ExecuteMethod(this, EventArgs.Empty);
            IL_2D:
                if (8 != 0)
                {
                    break;
                }
                goto IL_19;
            }
        }

        private void btFont_Click(object sender, RoutedEventArgs e)
        {
            bool arg_34_0;
            if (6 != 0)
            {
                arg_34_0 = (this.fontDialog.ShowDialog() != DialogResult.OK);
                goto IL_13;
            }
            while (true)
            {
            IL_1D:
                this.OnExecuteMethod();
                if (8 == 0)
                {
                    goto IL_15;
                }
                if (!false)
                {
                    return;
                }
            }
        IL_13:
            bool flag = arg_34_0;
        IL_15:
            bool expr_37 = arg_34_0 = flag;
            if (!true)
            {
                goto IL_13;
            }
            if (!expr_37)
            {
                goto IL_1D;
            }
        }

        private void txtnumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text;
            do
            {
                text = "";
            }
            while (false);
            if (!string.IsNullOrEmpty(((System.Windows.Controls.TextBox)sender).Text))
            {
                int num = 0;
                if (true)
                {
                    bool flag = int.TryParse(((System.Windows.Controls.TextBox)sender).Text, out num);
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
                ((System.Windows.Controls.TextBox)sender).Text.Trim();
                text = ((System.Windows.Controls.TextBox)sender).Text;
                goto IL_C6;
            IL_99:
                ((System.Windows.Controls.TextBox)sender).Text = text;
                if (3 == 0)
                {
                    return;
                }
                ((System.Windows.Controls.TextBox)sender).SelectionStart = ((System.Windows.Controls.TextBox)sender).Text.Length;
            IL_C6:
                if (false)
                {
                    goto IL_99;
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.cmbCheckedGraphic.Items.Count <= 0)
                {
                    System.Windows.MessageBox.Show("Please upload graphics.", "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    SlotProperty expr_40E = new SlotProperty();
                    SlotProperty slotProperty;
                    if (!false)
                    {
                        slotProperty = expr_40E;
                    }
                    VideoElements videoElements = new VideoElements();
                    int stopTime = 0;
                    int startTime = 0;
                    if (!string.IsNullOrEmpty(this.txtStartTime.Text))
                    {
                        startTime = Convert.ToInt32(this.txtStartTime.Text);
                    }
                    if (!string.IsNullOrEmpty(this.txtStopTime.Text))
                    {
                        stopTime = Convert.ToInt32(this.txtStopTime.Text);
                    }
                    long item_ID = ((TemplateListItems)this.cmbCheckedGraphic.SelectionBoxItem).Item_ID;
                    if (this.CheckSlotValidations())
                    {
                        if (this.IsEdited)
                        {
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to save changes?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            this.IsEdited = false;
                            if (messageBoxResult != MessageBoxResult.Yes)
                            {
                                this.cmbCheckedGraphic.SelectedIndex = 0;
                                this.txtStartTime.Text = "0";
                                this.txtStopTime.Text = "0";
                                this.txtGraphicLogoLeft.Text = "0";
                                this.txtGraphicLogoTop.Text = "0";
                                return;
                            }
                            slotProperty = (from o in this.LogoSlotList
                                            where (long)o.ID == this.EditedItemId
                                            select o).FirstOrDefault<SlotProperty>();
                            this.LogoSlotList.Remove(slotProperty);
                            if (videoElements.IsValidSlot(this.LogoSlotList, startTime, stopTime, item_ID))
                            {
                                slotProperty.ItemID = item_ID;
                                slotProperty.ID = Convert.ToInt32(this.EditedItemId);
                                slotProperty.FilePath = ((TemplateListItems)this.cmbCheckedGraphic.SelectionBoxItem).FilePath;
                                slotProperty.StartTime = Convert.ToInt32(this.txtStartTime.Text);
                                slotProperty.StopTime = Convert.ToInt32(this.txtStopTime.Text);
                                slotProperty.Left = Convert.ToInt32(this.txtGraphicLogoLeft.Text);
                                slotProperty.Top = Convert.ToInt32(this.txtGraphicLogoTop.Text);
                                this.LogoSlotList.Add(slotProperty);
                                this.EditedItemId = 0L;
                            }
                            else
                            {
                                this.LogoSlotList.Add(slotProperty);
                            }
                        }
                        else if (this.chkGraphicLogo.IsChecked == true)
                        {
                            if (videoElements.IsValidSlot(this.LogoSlotList, startTime, stopTime, item_ID))
                            {
                                slotProperty.ID = this.uniqueID;
                                slotProperty.ItemID = item_ID;
                                slotProperty.FilePath = ((TemplateListItems)this.cmbCheckedGraphic.SelectionBoxItem).FilePath;
                                if (!false)
                                {
                                    slotProperty.StartTime = Convert.ToInt32(this.txtStartTime.Text);
                                    slotProperty.StopTime = Convert.ToInt32(this.txtStopTime.Text);
                                    slotProperty.Left = Convert.ToInt32(this.txtGraphicLogoLeft.Text);
                                    slotProperty.Top = Convert.ToInt32(this.txtGraphicLogoTop.Text);
                                    this.LogoSlotList.Add(slotProperty);
                                }
                                this.uniqueID++;
                            }
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Please check Apply graphic logo.", "DigiPhoto", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        }
                        this.DGManageLogo.ItemsSource = from o in this.LogoSlotList
                                                        orderby o.StartTime
                                                        select o;
                        this.DGManageLogo.Items.Refresh();
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private bool CheckSlotValidations()
        {
            bool flag = !string.IsNullOrEmpty(this.txtStartTime.Text.Trim()) && !string.IsNullOrEmpty(this.txtStopTime.Text.Trim());
            bool result;
            if (3 != 0)
            {
                if (!flag)
                {
                    System.Windows.MessageBox.Show("Start/End time can not be zero or null.", "DigiPhoto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    result = false;
                    if (4 != 0)
                    {
                        return result;
                    }
                    goto IL_14D;
                }
                else
                {
                    flag = (Convert.ToInt32(this.txtStartTime.Text.Trim()) < Convert.ToInt32(this.txtStopTime.Text.Trim()));
                    if (flag)
                    {
                        flag = (!string.IsNullOrEmpty(this.txtGraphicLogoLeft.Text.Trim()) && !string.IsNullOrEmpty(this.txtGraphicLogoTop.Text.Trim()));
                        goto IL_EA;
                    }
                    System.Windows.MessageBox.Show("Start time should be less then End time.", "DigiPhoto", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            result = false;
            if (!false)
            {
                return result;
            }
        IL_EA:
            if (!flag)
            {
                System.Windows.MessageBox.Show("Top/Left value can not be zero or null.", "DigiPhoto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                result = false;
                return result;
            }
            if (Convert.ToInt32(this.txtGraphicLogoLeft.Text.Trim()) <= this.Top && Convert.ToInt32(this.txtGraphicLogoTop.Text.Trim()) <= this.Left)
            {
                result = true;
                return result;
            }
        IL_14D:
            object[] array = new object[5];
            array[0] = "Top/Left value should be as per aspect ratio [";
            if (8 != 0)
            {
                array[1] = this.Left;
                array[2] = " X ";
            }
            array[3] = this.Top;
            array[4] = "].";
            System.Windows.MessageBox.Show(string.Concat(array), "DigiPhoto", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            result = false;
            return result;
        }

        private void btnClearList_Click(object sender, RoutedEventArgs e)
        {
            bool arg_12_0;
            bool expr_09 = arg_12_0 = (this.LogoSlotList == null);
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
                        this.LogoSlotList.Clear();
                    }
                    if (false)
                    {
                        break;
                    }
                    this.DGManageLogo.ItemsSource = this.LogoSlotList;
                    this.DGManageLogo.Items.Refresh();
                }
                while (4 == 0);
            }
        }

        private void btnDeleteSlots_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Func<SlotProperty, bool> expr_01 = null;
                if (!false)
                {
                    Func<SlotProperty, bool> predicate = expr_01;
                }
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                long SlotId = long.Parse(button.Tag.ToString());
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to delete record?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Question);
                int arg_65_0 = (messageBoxResult == MessageBoxResult.Yes) ? 1 : 0;
                int arg_65_1 = 0;
                bool expr_124;
                while (true)
                {
                IL_65:
                    bool arg_67_0 = arg_65_0 == arg_65_1;
                    bool expr_6C;
                    while (true)
                    {
                        bool flag = arg_67_0;
                        if (false)
                        {
                            break;
                        }
                        expr_6C = (arg_67_0 = flag);
                        if (!false)
                        {
                            goto Block_3;
                        }
                    }
                IL_9F:
                    long itemID = (from o in this.LogoSlotList
                                   where (long)o.ID == SlotId
                                   select o).FirstOrDefault<SlotProperty>().ItemID;
                    this.LogoSlotList.RemoveAll((SlotProperty o) => (long)o.ID == SlotId);
                    this.DGManageLogo.ItemsSource = this.LogoSlotList;
                    this.DGManageLogo.Items.Refresh();
                    int arg_124_0 = arg_65_0 = this.LogoSlotList.Count;
                    while (true)
                    {
                        int expr_11E = arg_65_1 = 0;
                        if (expr_11E != 0)
                        {
                            goto IL_65;
                        }
                        expr_124 = ((arg_65_0 = (arg_124_0 = ((arg_124_0 == expr_11E) ? 1 : 0))) != 0);
                        if (4 != 0)
                        {
                            goto Block_9;
                        }
                    }
                Block_3:
                    if (!expr_6C)
                    {
                        IEnumerable<SlotProperty> arg_94_0 = this.LogoSlotList;
                        Func<SlotProperty, bool> predicate = (SlotProperty o) => (long)o.ID == SlotId;
                        SlotProperty slotProperty = arg_94_0.Where(predicate).FirstOrDefault<SlotProperty>();
                        goto IL_9F;
                    }
                    goto IL_140;
                }
            Block_9:
                if (!expr_124)
                {
                    goto IL_13C;
                }
            IL_133:
                this.uniqueID = 51;
            IL_13C:
                if (2 == 0)
                {
                    goto IL_133;
                }
            IL_140: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
                if (!false)
                {
                }
            }
            if (!false)
            {
            }
        }

        private void cmbCheckedGraphic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            do
            {
                bool arg_C8_0;
                if (this.cmbCheckedGraphic.SelectedIndex >= 0)
                {
                    arg_C8_0 = (this.cmbCheckedGraphic.SelectionBoxItem == "");
                }
                else
                {
                    if (false)
                    {
                        break;
                    }
                    arg_C8_0 = true;
                }
                bool flag = arg_C8_0;
                while (3 != 0)
                {
                    if (flag)
                    {
                        return;
                    }
                    while (7 == 0)
                    {
                    }
                    if (!false)
                    {
                        this.txtGraphicLogoLeft.Text = ((TemplateListItems)this.cmbCheckedGraphic.SelectionBoxItem).LeftPositon.ToString();
                        this.txtGraphicLogoTop.Text = ((TemplateListItems)this.cmbCheckedGraphic.SelectionBoxItem).TopPositon.ToString();
                        break;
                    }
                }
            }
            while (false);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
		{
			SlotProperty slotProperty;
			while (true)
			{
				IL_00:
				if (!true)
				{
					goto IL_119;
				}
				//LogoControl <>4__this = this;
				long id;
				while (true)
				{
					IL_20:
					System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
					this.EditedItemId = long.Parse(button.Tag.ToString());
					this.IsEdited = true;
					slotProperty = (from o in this.LogoSlotList
					where (long)o.ID == this.EditedItemId
					select o).FirstOrDefault<SlotProperty>();
					while (!false)
					{
						id = (from o in this.LogoSlotList
						where (long)o.ID == this.EditedItemId
						select o).FirstOrDefault<SlotProperty>().ItemID;
						this.cmbCheckedGraphic.SelectedItem = null;
						TemplateListItems selectedItem = (from o in this.lstGraphics
						where o.Item_ID == id
						select o).FirstOrDefault<TemplateListItems>();
						if (false)
						{
							goto IL_00;
						}
						if (6 == 0)
						{
							goto IL_20;
						}
						this.cmbCheckedGraphic.SelectedItem = selectedItem;
						if (!false)
						{
							goto Block_4;
						}
					}
					return;
				}
			}
			Block_4:
			this.txtGraphicLogoLeft.Text = slotProperty.Left.ToString();
			this.txtGraphicLogoTop.Text = slotProperty.Top.ToString();
			IL_119:
			if (!false)
			{
				this.txtStartTime.Text = slotProperty.StartTime.ToString();
			}
			this.txtStopTime.Text = slotProperty.StopTime.ToString();
		}



       
    }
}
