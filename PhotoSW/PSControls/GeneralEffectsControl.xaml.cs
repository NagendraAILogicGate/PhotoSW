using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace PhotoSW.PSControls
{
    public partial class GeneralEffectsControl : UserControl, IComponentConnector
    {
        private UIElement _parent;

        private bool _result = false;

        public string LicenseKey = string.Empty;

        public string UserName = string.Empty;

        public string EmailID = string.Empty;

        private readonly OpenFileDialog openFileDialog = new OpenFileDialog();

        private string FileName = "";

        

        public GeneralEffectsControl()
        {
            this.InitializeComponent();
            base.Visibility = Visibility.Hidden;
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                if (!false)
                {
                }
                if (3 == 0)
                {
                    return;
                }
                this.chkPreview.IsChecked = new bool?(false);
            }
        IL_16:
            this.HideHandlerDialog();
            if (8 == 0)
            {
                goto IL_16;
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            this.UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            this.btnClose.Click -= new RoutedEventHandler(this.btnClose_Click);
        }

        private void chkPreview_Checked(object sender, RoutedEventArgs e)
        {
            bool? expr_16D = this.chkPreview.IsChecked;
            bool? flag;
            if (7 != 0)
            {
                flag = expr_16D;
            }
        IL_17:
            while (!(flag == false))
            {
                if (!false)
                {
                    flag = this.chkPreview.IsChecked;
                    bool flag2;
                    while (true)
                    {
                        bool arg_9A_0;
                        if (!(flag == true))
                        {
                            arg_9A_0 = true;
                            goto IL_99;
                        }
                        if (!false)
                        {
                            flag = this.radioStandardPreview.IsChecked;
                            int arg_94_0;
                            if (flag.GetValueOrDefault())
                            {
                                arg_94_0 = (flag.HasValue ? 1 : 0);
                            }
                            else
                            {
                                if (8 == 0)
                                {
                                    goto IL_DB;
                                }
                                arg_94_0 = 0;
                            }
                            arg_9A_0 = (arg_94_0 == 0);
                            goto IL_99;
                        }
                        goto IL_C3;
                    IL_129:
                        bool arg_12A_0;
                        flag2 = arg_12A_0;
                        if (3 != 0)
                        {
                            goto Block_17;
                        }
                        continue;
                    IL_124:
                        bool arg_124_0;
                        int arg_124_1;
                        arg_12A_0 = ((arg_124_0 ? 1 : 0) == arg_124_1);
                        goto IL_129;
                    IL_99:
                        flag2 = arg_9A_0;
                        while (!flag2)
                        {
                            int expr_A5 = (arg_124_0 = string.IsNullOrEmpty(this.FileName)) ? 1 : 0;
                            int expr_AB = arg_124_1 = 0;
                            if (expr_AB != 0)
                            {
                                goto IL_124;
                            }
                            flag2 = (expr_A5 == expr_AB);
                            if (flag2)
                            {
                                goto IL_C6;
                            }
                            if (6 != 0)
                            {
                                goto Block_12;
                            }
                        }
                    IL_DB:
                        flag = this.chkPreview.IsChecked;
                        if (!(flag == true))
                        {
                            arg_12A_0 = true;
                            goto IL_129;
                        }
                        if (7 != 0)
                        {
                            flag = this.radioTemplatePreview.IsChecked;
                            arg_124_0 = (flag == true);
                            arg_124_1 = 0;
                            goto IL_124;
                        }
                        goto IL_17;
                    }
                Block_12:
                    MessageBox.Show("Please Select the file.");
                IL_C3:
                    break;
                IL_C6:
                    this.PlayFile(this.FileName);
                    break;
                Block_17:
                    if (!flag2)
                    {
                        if (string.IsNullOrEmpty(this.FileName))
                        {
                            MessageBox.Show("Please Select the file.");
                        }
                        else
                        {
                            this.PlayFile(this.FileName);
                        }
                    }
                }
                return;
            }
        }

        private void radioStandardPreview_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void radioTemplatePreview_Checked(object sender, RoutedEventArgs e)
        {
            bool? expr_A5 = this.radioTemplatePreview.IsChecked;
            bool? flag;
            if (2 != 0)
            {
                flag = expr_A5;
            }
            bool flag2 = !(flag == true);
            bool arg_38_0 = flag2;
            while (!arg_38_0)
            {
                flag = this.openFileDialog.ShowDialog();
                int arg_63_0;
                if (flag.GetValueOrDefault())
                {
                    arg_63_0 = ((arg_38_0 = flag.HasValue) ? 1 : 0);
                    if (6 == 0)
                    {
                        continue;
                    }
                }
                else
                {
                    arg_63_0 = 0;
                }
                if (arg_63_0 != 0)
                {
                    this.FileName = this.openFileDialog.FileName;
                    this.chkPreview.IsChecked = new bool?(false);
                }
                return;
            }
            this.FileName = "";
        }

        private void PlayFile(string fileName)
        {
        }

        private void tbLightness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }

        private void tbSaturation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }

        private void tbContrast_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }

        private void tbDarkness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }

        private void chkGrayScale_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void chkInvert_Checked(object sender, RoutedEventArgs e)
        {
        }

    }
}
