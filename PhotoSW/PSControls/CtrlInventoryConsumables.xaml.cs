using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using ErrorHandler;
using FrameworkHelper;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class CtrlInventoryConsumables : UserControl, IComponentConnector, IStyleConnector
    {
        public bool _issemiorder;

        private ObservableCollection<InventoryConsumables> _objInventory;

        private UIElement _parent;

        private bool _hideRequest = false;

        private string _result;

        private TextBox controlon;

        public static readonly DependencyProperty MessageInventoryConsFormProperty = DependencyProperty.Register("MessageInventoryConsForm", typeof(string), typeof(ModalDialog), new UIPropertyMetadata(string.Empty));

       

      //  private bool _contentLoaded;

        public string MessagInventoryConsForm
        {
            get
            {
                return (string)base.GetValue(CtrlInventoryConsumables.MessageInventoryConsFormProperty);
            }
            set
            {
                base.SetValue(CtrlInventoryConsumables.MessageInventoryConsFormProperty, value);
            }
        }

        public DateTime FromDate
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

        public DateTime BusinessDate
        {
            get;
            set;
        }

        public long SixEightStartingNumber
        {
            get;
            set;
        }

        public long EightTenStartingNumber
        {
            get;
            set;
        }

        public long PosterStartingNumber
        {
            get;
            set;
        }

        public long SixEightPrintCount
        {
            get;
            set;
        }

        public long EightTenPrintCount
        {
            get;
            set;
        }

        public long PosterPrintCount
        {
            get;
            set;
        }

        public List<InventoryConsumables> lstinventoryItem
        {
            get;
            set;
        }

        public long SixEightAutoStartingNumber
        {
            get;
            set;
        }

        public long EightTenAutoStartingNumber
        {
            get;
            set;
        }

        public long SixEightAutoClosingNumber
        {
            get;
            set;
        }

        public long EightTenAutoClosingNumber
        {
            get;
            set;
        }

        public CtrlInventoryConsumables()
        {
            this._objInventory = new ObservableCollection<InventoryConsumables>();
            this.InitializeComponent();
            //this.FillInventory();
            //this.dgInventory.ItemsSource = this._objInventory;
            base.Visibility = Visibility.Hidden;
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        public string ShowHandlerDialog(string message)
        {
            while (true)
            {
            IL_00:
                this.MessagInventoryConsForm = message;
                base.Visibility = Visibility.Visible;
                while (true)
                {
                    this.txtHeader.Text = "Closing Form for " + ((this.BusinessDate != DateTime.MinValue) ? string.Format("{0:dd-MMM-yyyy}", this.BusinessDate) : string.Format("{0:dd-MMM-yyyy}", DateTime.Now));
                    this.txtSubHeader.Text = "Inventory Consumables";
                    this.txtAuto6X8AutoClos.Text = Convert.ToString(this.SixEightAutoClosingNumber);
                    this.txtAuto8X10AutoClos.Text = Convert.ToString(this.EightTenAutoClosingNumber);
                    this.SetSixEightAutoWestage(this.FromDate, this.ToDate, this.SubStoreID, this.SixEightAutoStartingNumber, this.SixEightAutoClosingNumber);
                    this.SetEightTenAutoWestage(this.FromDate, this.ToDate, this.SubStoreID, this.EightTenAutoStartingNumber, this.EightTenAutoClosingNumber);
                    this._hideRequest = false;
                    while (true)
                    {
                    IL_182:
                        bool arg_189_0 = this._hideRequest;
                        while (!arg_189_0)
                        {
                            if (base.Dispatcher.HasShutdownStarted)
                            {
                                goto IL_12C;
                            }
                            bool arg_128_0;
                            arg_189_0 = (arg_128_0 = base.Dispatcher.HasShutdownFinished);
                        IL_124:
                            if (false)
                            {
                                continue;
                            }
                            bool arg_134_0 = !arg_128_0;
                        IL_133:
                            bool flag = arg_134_0;
                            if (6 != 0)
                            {
                                bool expr_138 = arg_128_0 = (arg_189_0 = flag);
                                if (false || 5 == 0)
                                {
                                    goto IL_124;
                                }
                                if (expr_138)
                                {
                                    base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                                    {
                                    }));
                                    Thread.Sleep(20);
                                    goto IL_182;
                                }
                            }
                            if (7 != 0)
                            {
                                goto Block_7;
                            }
                        IL_12C:
                            if (!false)
                            {
                                arg_134_0 = false;
                                goto IL_133;
                            }
                            goto IL_00;
                        }
                        goto IL_192;
                    }
                Block_7:
                    if (!false)
                    {
                        goto Block_8;
                    }
                }
            }
        Block_8:
        IL_192:
            this.lstinventoryItem = this._objInventory.ToList<InventoryConsumables>();
            return this._result;
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

        private void FillInventory()
        {
            SubStoresInfo substoreData = new StoreSubStoreDataBusniess().GetSubstoreData(LoginUser.SubStoreId);
            int SubStoreID = 0;
            if (substoreData != null)
            {
                SubStoreID = ((substoreData.LogicalSubStoreID == 0) ? LoginUser.SubStoreId : Convert.ToInt32(substoreData.LogicalSubStoreID));
            }
            ProductBusiness productBusiness = new ProductBusiness();
            List<ProductTypeInfo> oList = productBusiness.GetProductType().Where(delegate(ProductTypeInfo t)
            {
                bool? flag;
                if (!false)
                {
                    if (-1 == 0)
                    {
                        goto IL_1B;
                    }
                    flag = t.DG_IsAccessory;
                }
                bool arg_29_0;
                if (!flag.GetValueOrDefault())
                {
                    arg_29_0 = false;
                    goto IL_25;
                }
            IL_1B:
                arg_29_0 = flag.HasValue;
            IL_25:
                if (!false)
                {
                }
                bool arg_61_0;
                if (arg_29_0 && t.DG_SubStore_pkey == SubStoreID)
                {
                    do
                    {
                        flag = t.DG_IsActive;
                        if (!flag.GetValueOrDefault())
                        {
                            goto IL_58;
                        }
                    }
                    while (5 == 0);
                    arg_61_0 = flag.HasValue;
                    goto IL_56;
                IL_58:
                    arg_61_0 = false;
                }
                else
                {
                    arg_61_0 = false;
                }
            IL_56:
                if (!false)
                {
                    return arg_61_0;
                }
                goto IL_56;
            }).ToList<ProductTypeInfo>();
            CommonUtility.BindCombo<ProductTypeInfo>(this.cmbInventory, oList, "DG_Orders_ProductType_Name", "DG_Orders_ProductType_pkey");
            this.cmbInventory.SelectedValue = "0";
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
                    bool expr_4D = arg_27_0 = CtrlInventoryConsumables.IsTextAllowed(text);
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
                //goto IL_56;
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
            if (!true)
            {
                goto IL_19;
            }
            if (!false)
            {
            }
        IL_07:
            if (3 == 0)
            {
                return;
            }
            e.Handled = !CtrlInventoryConsumables.IsTextAllowed(e.Text.Trim());
        IL_19:
            if (8 == 0)
            {
                goto IL_07;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            this._result = string.Empty;
            bool arg_9F_0;
            bool expr_2F = arg_9F_0 = !(this.txt6X8CloseNumber.Text.Trim() == string.Empty);
            if (false)
            {
                goto IL_9F;
            }
            bool arg_148_0;
            if (!expr_2F)
            {
                if (!false)
                {
                    MessageBox.Show("Please enter 6X8 printer closing number", "Spectra Photo");
                    this.txt6X8CloseNumber.Focus();
                    this.txt6X8CloseNumber.BorderBrush = Brushes.Red;
                    goto IL_75;
                }
                goto IL_75;
            }
            else
            {
                bool expr_8F = arg_148_0 = (this.txt8X10CloseNumber.Text.Trim() == string.Empty);
                if (!false)
                {
                    bool flag = !expr_8F;
                    arg_9F_0 = flag;
                    goto IL_9F;
                }
            }
        IL_148:
            while (arg_148_0)
            {
                if (!true)
                {
                    goto IL_75;
                }
                bool flag = !(this.txt8X10Westage.Text.Trim() == string.Empty);
                bool expr_1A3 = arg_148_0 = flag;
                if (6 != 0)
                {
                    if (!expr_1A3)
                    {
                        MessageBox.Show("Please enter value", "Spectra Photo");
                        this.txt8X10Westage.Focus();
                        this.txt8X10Westage.BorderBrush = Brushes.Red;
                        goto IL_1D7;
                    }
                    this._result = string.Concat(new string[]
					{
						this.txt6X8CloseNumber.Text.ToString(),
						"%##%",
						this.txt8X10CloseNumber.Text.ToString(),
						"%##%",
						this.txtPosterCloseNumber.Text.ToString(),
						"%##%",
						this.txt6X8Westage.Text,
						"%##%",
						this.txt8X10Westage.Text,
						"%##%",
						this.txtPosterWestage.Text
					});
                    this.HideHandlerDialog();
                    goto IL_286;
                }
            }
            MessageBox.Show("Please enter value", "Spectra Photo");
            this.txt6X8Westage.Focus();
            this.txt6X8Westage.BorderBrush = Brushes.Red;
        IL_75:
            goto IL_286;
        IL_9F:
            if (!arg_9F_0)
            {
                MessageBox.Show("Please enter 8X10 printer closing number", "Spectra Photo");
                this.txt8X10CloseNumber.Focus();
                this.txt8X10CloseNumber.BorderBrush = Brushes.Red;
            }
            else
            {
                if (!(this.txtPosterCloseNumber.Text.Trim() == string.Empty))
                {
                    arg_148_0 = !(this.txt6X8Westage.Text.Trim() == string.Empty);
                    goto IL_148;
                }
                if (2 != 0)
                {
                }
                MessageBox.Show("Please enter poster printer closing number", "Spectra Photo");
                this.txtPosterCloseNumber.Focus();
                this.txtPosterCloseNumber.BorderBrush = Brushes.Red;
            }
        IL_1D7:
        IL_286:
            if (!false)
            {
                return;
            }
            goto IL_1D7;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this._result = string.Empty;
            this.HideHandlerDialog();
        }

        public void SetSixEightAutoWestage(DateTime FromDate, DateTime ToDate, int SubStoreID, long StartingNumber, long EndNumber)
        {
            List<SageInfoWestage> source = new SageBusiness().ProductTypeWestage(FromDate, ToDate, SubStoreID);
            if (source.Count<SageInfoWestage>() > 0)
            {
                SageInfoWestage sageInfoWestage = (from o in source
                                                   where o.ProductType == 1
                                                   select o).FirstOrDefault<SageInfoWestage>();
                SageInfoWestage sageInfoWestage2 = (from o in source
                                                    where o.ProductType == 3
                                                    select o).FirstOrDefault<SageInfoWestage>();
                SageInfoWestage sageInfoWestage3 = (from o in source
                                                    where o.ProductType == 4
                                                    select o).FirstOrDefault<SageInfoWestage>();
                SageInfoWestage sageInfoWestage4 = (from o in source
                                                    where o.ProductType == 5
                                                    select o).FirstOrDefault<SageInfoWestage>();
                while (true)
                {
                    SageInfoWestage sageInfoWestage5 = (from o in source
                                                        where o.ProductType == 30
                                                        select o).FirstOrDefault<SageInfoWestage>();
                    SageInfoWestage sageInfoWestage6 = (from o in source
                                                        where o.ProductType == 98
                                                        select o).FirstOrDefault<SageInfoWestage>();
                    SageInfoWestage sageInfoWestage7 = (from o in source
                                                        where o.ProductType == 104
                                                        select o).FirstOrDefault<SageInfoWestage>();
                    this.SixEightPrintCount = ((sageInfoWestage != null) ? sageInfoWestage.Printed : 0L) + ((sageInfoWestage2 != null) ? sageInfoWestage2.Printed : 0L) + ((sageInfoWestage3 != null) ? sageInfoWestage3.Printed : 0L) + ((sageInfoWestage4 != null) ? sageInfoWestage4.Printed : 0L) + ((sageInfoWestage5 != null) ? sageInfoWestage5.Printed : 0L) + ((sageInfoWestage6 != null) ? sageInfoWestage6.Printed : 0L) + ((sageInfoWestage7 != null) ? sageInfoWestage7.Printed : 0L);
                    long arg_24B_0;
                    long expr_1E5 = arg_24B_0 = 2L;
                    long arg_205_0;
                    if (sageInfoWestage == null)
                    {
                        arg_205_0 = 0L;
                        goto IL_1F6;
                    }
                    if (!false)
                    {
                        arg_205_0 = sageInfoWestage.Printed;
                        goto IL_1F6;
                    }
                    goto IL_23B;
                IL_24A:
                    long arg_24B_1;
                    long num = arg_24B_0 + arg_24B_1 + ((sageInfoWestage6 != null) ? sageInfoWestage6.Printed : 0L);
                    this.txtAuto6X8Westage.Text = ((EndNumber - StartingNumber - num > 0L) ? (EndNumber - StartingNumber - num).ToString() : "0");
                    if (!false)
                    {
                        break;
                    }
                    continue;
                IL_1F6:
                    long expr_205 = arg_24B_1 = arg_205_0 + ((sageInfoWestage2 != null) ? sageInfoWestage2.Printed : 0L);
                    long arg_217_1;
                    if (sageInfoWestage3 == null)
                    {
                        arg_217_1 = 0L;
                    }
                    else
                    {
                        if (false)
                        {
                            goto IL_24A;
                        }
                        arg_217_1 = sageInfoWestage3.Printed;
                    }
                    arg_24B_0 = expr_1E5 * (expr_205 + arg_217_1 + ((sageInfoWestage4 != null) ? sageInfoWestage4.Printed : 0L) + ((sageInfoWestage7 != null) ? sageInfoWestage7.Printed : 0L));
                IL_23B:
                    arg_24B_1 = ((sageInfoWestage5 != null) ? sageInfoWestage5.Printed : 0L);
                    goto IL_24A;
                }
            }
            else
            {
                this.txtAuto6X8Westage.Text = ((EndNumber - StartingNumber > 0L) ? (EndNumber - StartingNumber).ToString() : "0");
            }
        }

        public void SetEightTenAutoWestage(DateTime FromDate, DateTime ToDate, int SubStoreID, long StartingNumber, long EndNumber)
        {
            List<SageInfoWestage> source = new SageBusiness().ProductTypeWestage(FromDate, ToDate, SubStoreID);
            int arg_38_0;
            int expr_126 = arg_38_0 = source.Count<SageInfoWestage>();
            if (!false)
            {
                bool flag = expr_126 <= 0;
                arg_38_0 = (flag ? 1 : 0);
            }
            if (arg_38_0 == 0)
            {
                SageInfoWestage sageInfoWestage = (from o in source
                                                   where o.ProductType == 2
                                                   select o).FirstOrDefault<SageInfoWestage>();
                bool flag = sageInfoWestage == null;
                if (!false)
                {
                    if (!flag)
                    {
                        this.EightTenPrintCount = sageInfoWestage.Printed;
                    }
                    else
                    {
                        this.EightTenPrintCount = 0L;
                    }
                    this.txtAuto8X10Westage.Text = ((EndNumber - StartingNumber - this.EightTenPrintCount > 0L) ? (EndNumber - StartingNumber - this.EightTenPrintCount).ToString() : "0");
                }
            }
            else
            {
                this.txtAuto8X10Westage.Text = ((EndNumber - StartingNumber > 0L) ? (EndNumber - StartingNumber).ToString() : "0");
            }
        }

        public void SetSixEightWestage(DateTime FromDate, DateTime ToDate, int SubStoreID, long StartingNumber, long EndNumber)
        {
            List<SageInfoWestage> source = new SageBusiness().ProductTypeWestage(FromDate, ToDate, SubStoreID);
            if (source.Count<SageInfoWestage>() > 0)
            {
                SageInfoWestage sageInfoWestage = (from o in source
                                                   where o.ProductType == 1
                                                   select o).FirstOrDefault<SageInfoWestage>();
                SageInfoWestage sageInfoWestage2 = (from o in source
                                                    where o.ProductType == 3
                                                    select o).FirstOrDefault<SageInfoWestage>();
                SageInfoWestage sageInfoWestage3 = (from o in source
                                                    where o.ProductType == 4
                                                    select o).FirstOrDefault<SageInfoWestage>();
                SageInfoWestage sageInfoWestage4 = (from o in source
                                                    where o.ProductType == 5
                                                    select o).FirstOrDefault<SageInfoWestage>();
                while (true)
                {
                    SageInfoWestage sageInfoWestage5 = (from o in source
                                                        where o.ProductType == 30
                                                        select o).FirstOrDefault<SageInfoWestage>();
                    SageInfoWestage sageInfoWestage6 = (from o in source
                                                        where o.ProductType == 98
                                                        select o).FirstOrDefault<SageInfoWestage>();
                    SageInfoWestage sageInfoWestage7 = (from o in source
                                                        where o.ProductType == 104
                                                        select o).FirstOrDefault<SageInfoWestage>();
                    this.SixEightPrintCount = ((sageInfoWestage != null) ? sageInfoWestage.Printed : 0L) + ((sageInfoWestage2 != null) ? sageInfoWestage2.Printed : 0L) + ((sageInfoWestage3 != null) ? sageInfoWestage3.Printed : 0L) + ((sageInfoWestage4 != null) ? sageInfoWestage4.Printed : 0L) + ((sageInfoWestage5 != null) ? sageInfoWestage5.Printed : 0L) + ((sageInfoWestage6 != null) ? sageInfoWestage6.Printed : 0L) + ((sageInfoWestage7 != null) ? sageInfoWestage7.Printed : 0L);
                    long arg_24B_0;
                    long expr_1E5 = arg_24B_0 = 2L;
                    long arg_205_0;
                    if (sageInfoWestage == null)
                    {
                        arg_205_0 = 0L;
                        goto IL_1F6;
                    }
                    if (!false)
                    {
                        arg_205_0 = sageInfoWestage.Printed;
                        goto IL_1F6;
                    }
                    goto IL_23B;
                IL_24A:
                    long arg_24B_1;
                    long num = arg_24B_0 + arg_24B_1 + ((sageInfoWestage6 != null) ? sageInfoWestage6.Printed : 0L);
                    this.txt6X8Westage.Text = ((EndNumber - StartingNumber - num > 0L) ? (EndNumber - StartingNumber - num).ToString() : "0");
                    if (!false)
                    {
                        break;
                    }
                    continue;
                IL_1F6:
                    long expr_205 = arg_24B_1 = arg_205_0 + ((sageInfoWestage2 != null) ? sageInfoWestage2.Printed : 0L);
                    long arg_217_1;
                    if (sageInfoWestage3 == null)
                    {
                        arg_217_1 = 0L;
                    }
                    else
                    {
                        if (false)
                        {
                            goto IL_24A;
                        }
                        arg_217_1 = sageInfoWestage3.Printed;
                    }
                    arg_24B_0 = expr_1E5 * (expr_205 + arg_217_1 + ((sageInfoWestage4 != null) ? sageInfoWestage4.Printed : 0L) + ((sageInfoWestage7 != null) ? sageInfoWestage7.Printed : 0L));
                IL_23B:
                    arg_24B_1 = ((sageInfoWestage5 != null) ? sageInfoWestage5.Printed : 0L);
                    goto IL_24A;
                }
            }
            else
            {
                this.txt6X8Westage.Text = ((EndNumber - StartingNumber > 0L) ? (EndNumber - StartingNumber).ToString() : "0");
            }
        }

        public void SetEightTenWestage(DateTime FromDate, DateTime ToDate, int SubStoreID, long StartingNumber, long EndNumber)
        {
            List<SageInfoWestage> source = new SageBusiness().ProductTypeWestage(FromDate, ToDate, SubStoreID);
            int arg_38_0;
            int expr_126 = arg_38_0 = source.Count<SageInfoWestage>();
            if (!false)
            {
                bool flag = expr_126 <= 0;
                arg_38_0 = (flag ? 1 : 0);
            }
            if (arg_38_0 == 0)
            {
                SageInfoWestage sageInfoWestage = (from o in source
                                                   where o.ProductType == 2
                                                   select o).FirstOrDefault<SageInfoWestage>();
                bool flag = sageInfoWestage == null;
                if (!false)
                {
                    if (!flag)
                    {
                        this.EightTenPrintCount = sageInfoWestage.Printed;
                    }
                    else
                    {
                        this.EightTenPrintCount = 0L;
                    }
                    this.txt8X10Westage.Text = ((EndNumber - StartingNumber - this.EightTenPrintCount > 0L) ? (EndNumber - StartingNumber - this.EightTenPrintCount).ToString() : "0");
                }
            }
            else
            {
                this.txt8X10Westage.Text = ((EndNumber - StartingNumber > 0L) ? (EndNumber - StartingNumber).ToString() : "0");
            }
        }

        public void SetPosterWestage(DateTime FromDate, DateTime ToDate, int SubStoreID, long StartingNumber, long EndNumber)
        {
            List<SageInfoWestage> source = new SageBusiness().ProductTypeWestage(FromDate, ToDate, SubStoreID);
            bool arg_38_0;
            bool expr_2A = arg_38_0 = (source.Count<SageInfoWestage>() > 0);
            bool arg_17D_0;
            if (!false)
            {
                arg_17D_0 = !expr_2A;
                goto IL_32;
            }
        IL_38:
            bool flag;
            while (!arg_38_0)
            {
                SageInfoWestage sageInfoWestage;
                while (true)
                {
                    while (true)
                    {
                        if (7 != 0)
                        {
                            sageInfoWestage = (from o in source
                                               where o.ProductType == 6
                                               select o).FirstOrDefault<SageInfoWestage>();
                            if (sageInfoWestage == null)
                            {
                                goto IL_8B;
                            }
                        }
                        if (5 != 0)
                        {
                            goto Block_4;
                        }
                    }
                IL_96:
                    if (!false)
                    {
                        break;
                    }
                    continue;
                Block_4:
                    this.PosterPrintCount = sageInfoWestage.Printed;
                    if (true)
                    {
                    }
                    goto IL_96;
                IL_8B:
                    this.PosterPrintCount = 0L;
                    goto IL_96;
                }
                bool expr_9B = arg_38_0 = (sageInfoWestage == null);
                if (!false)
                {
                    flag = expr_9B;
                    bool expr_A4 = arg_17D_0 = flag;
                    if (!false)
                    {
                        if (!expr_A4)
                        {
                            this.txtPosterWestage.Text = ((EndNumber - StartingNumber - sageInfoWestage.Printed > 0L) ? (EndNumber - StartingNumber - sageInfoWestage.Printed).ToString() : "0");
                        }
                        else
                        {
                            this.txtPosterWestage.Text = ((EndNumber - StartingNumber > 0L) ? (EndNumber - StartingNumber).ToString() : "0");
                        }
                        return;
                    }
                    goto IL_32;
                }
            }
            this.txtPosterWestage.Text = ((EndNumber - StartingNumber > 0L) ? (EndNumber - StartingNumber).ToString() : "0");
            return;
        IL_32:
            flag = arg_17D_0;
            arg_38_0 = flag;
            goto IL_38;
        }

        private void txtPosterCloseNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            this.controlon = (TextBox)sender;
            this.Calculation();
        }

        private void txt6X8Folder_GotFocus(object sender, RoutedEventArgs e)
        {
            this.controlon = (TextBox)sender;
            this.Calculation();
        }

        private void txt8X10Folder_GotFocus(object sender, RoutedEventArgs e)
        {
            this.controlon = (TextBox)sender;
            this.Calculation();
        }

        private void txt6X8FolderCash_GotFocus(object sender, RoutedEventArgs e)
        {
            this.controlon = (TextBox)sender;
            this.Calculation();
        }

        private void txt8X10FolderCash_GotFocus(object sender, RoutedEventArgs e)
        {
            this.controlon = (TextBox)sender;
            this.Calculation();
        }

        private void txtRovingTicket_GotFocus(object sender, RoutedEventArgs e)
        {
            this.controlon = (TextBox)sender;
            this.Calculation();
        }

        private void txtRovingBand_GotFocus(object sender, RoutedEventArgs e)
        {
            this.controlon = (TextBox)sender;
            this.Calculation();
        }

        private void txtPlasticBag_GotFocus(object sender, RoutedEventArgs e)
        {
            this.controlon = (TextBox)sender;
            this.Calculation();
        }

        private void txt6X8CloseNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            this.controlon = (TextBox)sender;
            this.Calculation();
        }

        private void txt8X10CloseNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            this.controlon = (TextBox)sender;
            this.Calculation();
        }

        private void txt6X8CloseNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            while (this.txt6X8CloseNumber.Text != "")
            {
                this.SetSixEightWestage(this.FromDate, this.ToDate, this.SubStoreID, this.SixEightStartingNumber, (this.txt6X8CloseNumber.Text.Trim() == "") ? 0L : Convert.ToInt64(this.txt6X8CloseNumber.Text));
                if (3 != 0)
                {
                    break;
                }
            }
        }

        private void txt8X10CloseNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            while (this.txt8X10CloseNumber.Text != "")
            {
                this.SetEightTenWestage(this.FromDate, this.ToDate, this.SubStoreID, this.EightTenStartingNumber, (this.txt8X10CloseNumber.Text.Trim() == "") ? 0L : Convert.ToInt64(this.txt8X10CloseNumber.Text));
                if (3 != 0)
                {
                    break;
                }
            }
        }

        private void txtPosterCloseNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.txtPosterCloseNumber.Text != "")
            {
                this.SetPosterWestage(this.FromDate, this.ToDate, this.SubStoreID, this.PosterStartingNumber, (this.txtPosterCloseNumber.Text == "") ? 0L : Convert.ToInt64(this.txtPosterCloseNumber.Text));
            }
        }

        private void txt6X8CloseNumber_PreviewKeyDown(object sender, KeyEventArgs e)
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

        private void Calculation()
        {
            this.SetPosterWestage(this.FromDate, this.ToDate, this.SubStoreID, this.PosterStartingNumber, (this.txtPosterCloseNumber.Text == "") ? 0L : Convert.ToInt64(this.txtPosterCloseNumber.Text));
            this.SetEightTenWestage(this.FromDate, this.ToDate, this.SubStoreID, this.EightTenStartingNumber, (this.txt8X10CloseNumber.Text.Trim() == "") ? 0L : Convert.ToInt64(this.txt8X10CloseNumber.Text));
            this.SetSixEightWestage(this.FromDate, this.ToDate, this.SubStoreID, this.SixEightStartingNumber, (this.txt6X8CloseNumber.Text.Trim() == "") ? 0L : Convert.ToInt64(this.txt6X8CloseNumber.Text));
            while (3 == 0)
            {
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool expr_17 = this.cmbInventory.SelectedIndex < 0;
            bool flag;
            if (!false)
            {
                flag = expr_17;
            }
            if (!flag)
            {
                flag = (!(this.txtConsume.Text != "") || !(this.txtConsume.Text != "0"));
                if (!flag)
                {
                    List<InventoryConsumables> list = this._objInventory.Where(delegate(InventoryConsumables t)
                    {
                        bool result;
                        do
                        {
                            if (true && !false)
                            {
                                result = (t.AccessoryID == Convert.ToInt64(this.cmbInventory.SelectedValue));
                            }
                            while (false)
                            {
                            }
                        }
                        while (8 == 0);
                        return result;
                    }).ToList<InventoryConsumables>();
                    flag = (list.Count != 0);
                    if (!flag)
                    {
                        InventoryConsumables inventoryConsumables = new InventoryConsumables();
                        inventoryConsumables.AccessoryID = Convert.ToInt64(this.cmbInventory.SelectedValue);
                        inventoryConsumables.AccessoryName = this.cmbInventory.Text;
                        inventoryConsumables.ConsumeValue = Convert.ToInt64(this.txtConsume.Text);
                        this._objInventory.Add(inventoryConsumables);
                        this.dgInventory.ItemsSource = this._objInventory;
                        this.dgInventory.UpdateLayout();
                        this.txtConsume.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Selected inventory is already added", "Spectra Photo");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid inventory Consumable", "Spectra Photo");
                    this.txtConsume.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please select inventory", "Spectra Photo");
                this.cmbInventory.Focus();
            }
        }

        private void btndeleteInventory_Click(object sender, RoutedEventArgs e)
		{
			if (!false)
			{
				try
				{
                    //CtrlInventoryConsumables c__DisplayClass2a=null;
                    //if (-1 != 0)
                    //{
                    //    CtrlInventoryConsumables expr_5C = new CtrlInventoryConsumables();
                    //    if (!false)
                    //    {
                    //        c__DisplayClass2a = expr_5C;
                    //    }
                    //}
					var   ToBeDeleteditem = (InventoryConsumables)this.dgInventory.CurrentItem;
					InventoryConsumables inventoryConsumables = (from lineitem in this._objInventory
					where lineitem.AccessoryID == ToBeDeleteditem.AccessoryID
					select lineitem).FirstOrDefault<InventoryConsumables>();
					if (5 != 0 && inventoryConsumables != null)
					{
						this._objInventory.Remove(inventoryConsumables);
					}
				}
				catch (Exception serviceException)
				{
					string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
					ErrorHandler.ErrorHandler.LogFileWrite(message);
					if (7 != 0)
					{
					}
				}
			}
			if (!false)
			{
			}
		}

        private FrameworkElement FindByName(string name, FrameworkElement root)
        {
            Stack<FrameworkElement> stack;
            if (!false)
            {
                stack = new Stack<FrameworkElement>();
                stack.Push(root);
                goto IL_A3;
            }
        IL_24:
            FrameworkElement frameworkElement = stack.Pop();
            FrameworkElement result;
            if (-1 != 0 && frameworkElement.Name == name)
            {
                result = frameworkElement;
                return result;
            }
            int arg_5A_0 = VisualTreeHelper.GetChildrenCount(frameworkElement);
        IL_5A:
            int num = arg_5A_0;
            int num2 = 0;
            while (true)
            {
                bool flag = num2 < num;
                bool arg_79_0;
                bool expr_9B = arg_79_0 = flag;
                if (false)
                {
                    goto IL_79;
                }
                if (!expr_9B)
                {
                    break;
                }
                goto IL_5F;
            IL_93:
                int arg_93_0;
                int arg_93_1;
                num2 = arg_93_0 + arg_93_1;
                continue;
            IL_5F:
                DependencyObject child = VisualTreeHelper.GetChild(frameworkElement, num2);
                int expr_71 = arg_93_0 = ((child is FrameworkElement) ? 1 : 0);
                int expr_74 = arg_93_1 = 0;
                if (expr_74 != 0)
                {
                    goto IL_93;
                }
                arg_79_0 = (expr_71 == expr_74);
            IL_79:
                flag = arg_79_0;
                if (2 != 0)
                {
                    if (!flag)
                    {
                        stack.Push((FrameworkElement)child);
                    }
                    arg_93_0 = num2;
                    arg_93_1 = 1;
                    goto IL_93;
                }
                goto IL_5F;
            }
        IL_A3:
            int expr_A4 = arg_5A_0 = stack.Count;
            if (!true)
            {
                goto IL_5A;
            }
            if (expr_A4 > 0)
            {
                goto IL_24;
            }
            result = null;
            return result;
        }

        private void txtConsume_GotFocus(object sender, RoutedEventArgs e)
        {
            this.controlon = (TextBox)sender;
        }

        private void txtConsume_PreviewKeyDown(object sender, KeyEventArgs e)
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

        private void txtConsume_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!true)
            {
                goto IL_19;
            }
            if (!false)
            {
            }
        IL_07:
            if (3 == 0)
            {
                return;
            }
            e.Handled = !CtrlInventoryConsumables.IsTextAllowed(e.Text.Trim());
        IL_19:
            if (8 == 0)
            {
                goto IL_07;
            }
        }

 
        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        void IStyleConnector.Connect(int connectionId, object target)
        {
            while (true)
            {
                if (8 == 0)
                {
                    goto IL_16;
                }
                int arg_0F_0 = connectionId;
                if (8 != 0)
                {
                    arg_0F_0 = connectionId;
                }
                if (arg_0F_0 == 31 || false)
                {
                    goto IL_16;
                }
            IL_2F:
                if (!false)
                {
                    break;
                }
                continue;
            IL_16:
                ((Button)target).Click += new RoutedEventHandler(this.btndeleteInventory_Click);
                goto IL_2F;
            }
        }
    }
}
