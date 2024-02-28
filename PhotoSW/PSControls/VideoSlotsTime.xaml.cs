using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using PhotoSW.Manage;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace PhotoSW.PSControls
{
    public partial class VideoSlotsTime : UserControl, IComponentConnector, IStyleConnector
    {
        private string a;

        public long VideoTemplateId = 0L;

        public long VideoLength = 0L;

        public string VideoName = "";

        private UIElement _parent;

        private List<VideoTemplateInfo.VideoSlot> slotList;

        public bool isGuestVideoTemplate = false;

        

        public void SetParent(UIElement parent)
        {
            if (!false && -1 != 0)
            {
                this._parent = parent;
            }
            bool flag;
            do
            {
                this.slotList = new List<VideoTemplateInfo.VideoSlot>();
                flag = this.isGuestVideoTemplate;
            }
            while (false);
            if (!flag)
            {
                this.GetVideoSlotsTimeFrames(this.VideoTemplateId);
            }
            this.txtSlotFrameTime.MaxLength = this.VideoLength.ToString().Length;
            this.tbVLength.Text = this.VideoLength.ToString();
        }

        public VideoSlotsTime()
        {
            this.InitializeComponent();
        }

        private void GetVideoSlotsTimeFrames(long VideoTemplateId)
        {
            if (!false)
            {
                try
                {
                    bool flag = this.slotList != null && this.slotList.Count != 0;
                    bool arg_3A_0;
                    bool arg_72_0 = arg_3A_0 = flag;
                    while (true)
                    {
                        if (true)
                        {
                            if (!arg_3A_0)
                            {
                                this.slotList = new List<VideoTemplateInfo.VideoSlot>();
                                ConfigBusiness configBusiness = new ConfigBusiness();
                                this.slotList = configBusiness.GetVideoTemplate(VideoTemplateId).videoSlots;
                                goto IL_68;
                            }
                            goto IL_87;
                        }
                    IL_71:
                        flag = !arg_72_0;
                        bool expr_75 = arg_3A_0 = (arg_72_0 = flag);
                        if (!false)
                        {
                            if (!expr_75)
                            {
                                this.slotList = new List<VideoTemplateInfo.VideoSlot>();
                            }
                            goto IL_87;
                        }
                        continue;
                    IL_68:
                        arg_72_0 = (this.slotList == null);
                        goto IL_71;
                    IL_87:
                        if (true)
                        {
                            break;
                        }
                        goto IL_68;
                    }
                    this.DGManageVideo.ItemsSource = from o in this.slotList
                                                     orderby o.FrameTimeIn
                                                     select o;
                    this.DGManageVideo.Items.Refresh();
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    while (true)
                    {
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                        while (8 != 0)
                        {
                            if (!false)
                            {
                                goto Block_12;
                            }
                        }
                    }
                Block_12: ;
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.CheckSlotValidations())
				{
					long num;
					long num2;
					int num3;
                    long FrameTimeIn;
                    do
					{
						num = 0L;
						 FrameTimeIn = 0L;
						num2 = 0L;
						num3 = int.Parse(this.txtPhotoDisplayTime.Text.Trim());
						if (!string.IsNullOrEmpty(this.txtSlotFrameTime.Text))
						{
							FrameTimeIn = Convert.ToInt64(this.txtSlotFrameTime.Text.Trim());
						}
						if (!string.IsNullOrEmpty(this.txtSlotInterval.Text.Trim()))
						{
							num2 = Convert.ToInt64(this.txtSlotInterval.Text.Trim());
							num = num2;
						}
					}
					while (false);
					if (string.IsNullOrEmpty(this.txtSlotInterval.Text) && (from o in this.slotList
					where o.FrameTimeIn == FrameTimeIn
					select o).Count<VideoTemplateInfo.VideoSlot>() > 0)
					{
						MessageBox.Show("Same frame time already exists.", "Spectra Photo", MessageBoxButton.OK);
					}
					else if (FrameTimeIn > this.VideoLength)
					{
						MessageBox.Show("Slot time frame should be less than the total video length " + this.VideoLength.ToString() + "s .", "Spectra Photo", MessageBoxButton.OK);
					}
					else
					{
						if (num2 <= this.VideoLength)
						{
							long arg_1B1_0;
							long arg_41E_0 = arg_1B1_0 = FrameTimeIn;
							int arg_1B0_0;
							int arg_41D_0 = arg_1B0_0 = num3;
							VideoTemplateInfo.VideoSlot videoSlot2;
							while (3 != 0)
							{
								if (arg_1B1_0 + (long)arg_1B0_0 > this.VideoLength)
								{
									MessageBox.Show("The output video time exceeds the template video length " + this.VideoLength.ToString() + "s .", "Spectra Photo", MessageBoxButton.OK);
									return;
								}
								long expr_1EF = arg_1B1_0 = (arg_41E_0 = num2);
								long expr_1F0 = (long)(arg_1B0_0 = (arg_41D_0 = num3));
								if (4 != 0)
								{
									bool flag = expr_1EF + expr_1F0 <= this.VideoLength;
									bool arg_2E4_0;
									bool expr_203 = arg_2E4_0 = flag;
									if (true)
									{
										if (!expr_203)
										{
											MessageBox.Show("The output video time exceeds the template video length " + this.VideoLength.ToString() + "s .", "Spectra Photo", MessageBoxButton.OK);
											return;
										}
										if (!string.IsNullOrEmpty(this.txtSlotInterval.Text))
										{
											this.slotList.Clear();
											if (-1 == 0)
											{
												goto IL_177;
											}
											flag = ((long)num3 <= num2);
											if (!false && !flag)
											{
												MessageBox.Show("Photo display time should be less than slot interval", "Spectra Photo", MessageBoxButton.OK);
												return;
											}
											while (this.VideoLength > num2 + (long)num3)
											{
												this.slotList.Add(new VideoTemplateInfo.VideoSlot((long)(this.slotList.Count<VideoTemplateInfo.VideoSlot>() + 1), num2, num3));
												num2 += num;
											}
											goto IL_49A;
										}
										else
										{
											flag = (this.slotList.Count != 0);
											arg_2E4_0 = flag;
										}
									}
									if (!arg_2E4_0)
									{
										this.slotList.Add(new VideoTemplateInfo.VideoSlot((long)(this.slotList.Count<VideoTemplateInfo.VideoSlot>() + 1), FrameTimeIn, num3));
									}
									else
									{
										if (false)
										{
											goto IL_4A6;
										}
										VideoTemplateInfo.VideoSlot videoSlot = (from o in this.slotList
										orderby o.FrameTimeIn
										where o.FrameTimeIn < FrameTimeIn
										select o).LastOrDefault<VideoTemplateInfo.VideoSlot>();
										videoSlot2 = (from o in this.slotList
										orderby o.FrameTimeIn
										select o).ToList<VideoTemplateInfo.VideoSlot>().FirstOrDefault<VideoTemplateInfo.VideoSlot>();
										if (videoSlot != null)
										{
											if (FrameTimeIn >= videoSlot.FrameTimeIn + (long)videoSlot.PhotoDisplayTime)
											{
												this.slotList.Add(new VideoTemplateInfo.VideoSlot((long)(this.slotList.Count<VideoTemplateInfo.VideoSlot>() + 1), FrameTimeIn, num3));
											}
											else
											{
												MessageBox.Show("There is already a slot in given time frame.", "Spectra Photo", MessageBoxButton.OK);
											}
										}
										else
										{
											if (videoSlot2 != null)
											{
												arg_41E_0 = FrameTimeIn;
												arg_41D_0 = num3;
												break;
											}
											this.slotList.Add(new VideoTemplateInfo.VideoSlot((long)(this.slotList.Count<VideoTemplateInfo.VideoSlot>() + 1), FrameTimeIn, num3));
										}
										IL_498:;
									}
									IL_49A:
									this.GetVideoSlotsTimeFrames(this.VideoTemplateId);
									IL_4A6:
									this.ResetControls();
									goto IL_4B0;
								}
							}
							if (arg_41E_0 + (long)arg_41D_0 <= videoSlot2.FrameTimeIn)
							{
								this.slotList.Add(new VideoTemplateInfo.VideoSlot((long)(this.slotList.Count<VideoTemplateInfo.VideoSlot>() + 1), FrameTimeIn, num3));
							}
							else
							{
								MessageBox.Show("There is already a slot in given time frame.", "Spectra Photo", MessageBoxButton.OK);
							}
							//goto IL_498;
						}
						IL_177:
						MessageBox.Show("Slot interval should be less than the total video length " + this.VideoLength.ToString() + "s .", "Spectra Photo", MessageBoxButton.OK);
					}
				}
				IL_4B0:;
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				if (8 != 0)
				{
					ErrorHandler.ErrorHandler.LogFileWrite(message);
				}
			}
		}

        private void btnDeleteSlot_Click(object sender, RoutedEventArgs e)
        {
            if (!true)
            {
                goto IL_5E;
            }
            if (false)
            {
                goto IL_5E;
            }
            Button button = (Button)sender;
        IL_26:
            long videoSlotId = long.Parse(button.Tag.ToString());
            MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to delete record?", "Digiphoto", MessageBoxButton.YesNo);
            bool flag = messageBoxResult != MessageBoxResult.Yes;
        IL_5E:
            if (!flag)
            {
                if (4 != 0)
                {
                }
                this.slotList.RemoveAll((VideoTemplateInfo.VideoSlot o) => o.VideoSlotId == videoSlotId);
                this.GetVideoSlotsTimeFrames(this.VideoTemplateId);
                MessageBox.Show("Item deleted Successfully", "Spectra Photo", MessageBoxButton.OK);
                if (!true)
                {
                    goto IL_AE;
                }
            }
            this.ResetControls();
        IL_AE:
            if (4 != 0 && 4 != 0)
            {
                return;
            }
            goto IL_26;
        }

        private bool CheckSlotValidations()
        {
            bool arg_1AC_0 = !string.IsNullOrEmpty(this.txtSlotFrameTime.Text.Trim()) || !string.IsNullOrEmpty(this.txtSlotInterval.Text.Trim());
            bool result;
            while (arg_1AC_0)
            {
                int arg_145_0;
                int arg_97_0;
                if (!string.IsNullOrEmpty(this.txtPhotoDisplayTime.Text.Trim()))
                {
                    int expr_85 = arg_145_0 = Convert.ToInt32(this.txtPhotoDisplayTime.Text);
                    if (false)
                    {
                        goto IL_145;
                    }
                    arg_97_0 = ((expr_85 > 0) ? 1 : 0);
                }
                else
                {
                    arg_97_0 = 0;
                }
            IL_96:
                int arg_143_0;
                bool arg_EC_0;
                if (arg_97_0 == 0)
                {
                    if (-1 != 0)
                    {
                        MessageBox.Show("Photo display time can not be zero or null.", "Spectra Photo", MessageBoxButton.OK);
                        result = false;
                        return result;
                    }
                    goto IL_D2;
                }
                else
                {
                    bool expr_C8 = (arg_143_0 = ((arg_1AC_0 = this.IsNumeric(this.txtSlotFrameTime.Text.Trim())) ? 1 : 0)) != 0;
                    if (3 != 0)
                    {
                        if (!expr_C8)
                        {
                            goto IL_D2;
                        }
                        arg_EC_0 = true;
                        goto IL_EB;
                    }
                }
            IL_13D:
                if (4 != 0)
                {
                    bool flag = arg_143_0 != 0;
                    arg_145_0 = (flag ? 1 : 0);
                    goto IL_145;
                }
                continue;
            IL_EB:
                if (!arg_EC_0)
                {
                    MessageBox.Show("Only numeric values are allowed for slot time frame and slot interval.", "Spectra Photo", MessageBoxButton.OK);
                    result = false;
                    return result;
                }
                int arg_15A_0;
                bool expr_116 = (arg_15A_0 = (string.IsNullOrEmpty(this.txtSlotFrameTime.Text.Trim()) ? 1 : 0)) != 0;
                if (!false)
                {
                    if (expr_116)
                    {
                        int expr_12B = arg_97_0 = Convert.ToInt32(this.txtSlotInterval.Text);
                        if (false)
                        {
                            goto IL_93;
                        }
                        arg_1AC_0 = ((arg_143_0 = ((expr_12B > 0) ? 1 : 0)) != 0);
                    }
                    else
                    {
                        arg_1AC_0 = ((arg_143_0 = 1) != 0);
                    }
                    goto IL_13D;
                }
                goto IL_15A;
            IL_D2:
                arg_EC_0 = this.IsNumeric(this.txtSlotInterval.Text.Trim());
                goto IL_EB;
            IL_93:
                goto IL_96;
            IL_145:
                if (arg_145_0 != 0)
                {
                    result = true;
                    return result;
                }
                MessageBox.Show("Slot interval can not be zero.", "Spectra Photo", MessageBoxButton.OK);
                arg_15A_0 = 0;
            IL_15A:
                result = (arg_15A_0 != 0);
                return result;
            }
            if (!false)
            {
                MessageBox.Show("Enter value for slot time frame or slot interval.", "Spectra Photo", MessageBoxButton.OK);
                result = false;
                return result;
            }
            return result;
        }

        private bool SaveSlotTimeFrameDetails(long videoTemplateId, List<VideoTemplateInfo.VideoSlot> videoSlots)
        {
            bool result;
            do
            {
                try
                {
                    ConfigBusiness configBusiness;
                    VideoTemplateInfo videoTemplateInfo;
                    do
                    {
                        while (true)
                        {
                            configBusiness = new ConfigBusiness();
                            while (true)
                            {
                                videoTemplateInfo = new VideoTemplateInfo();
                                videoTemplateInfo.VideoTemplateId = videoTemplateId;
                                if (!false)
                                {
                                    goto Block_3;
                                }
                            }
                        }
                    Block_3: ;
                    }
                    while (false);
                    videoTemplateInfo.videoSlots = videoSlots;
                    result = configBusiness.SaveVideoSlot(videoTemplateInfo);
                }
                catch
                {
                    do
                    {
                        result = false;
                    }
                    while (4 == 0);
                }
            }
            while (2 == 0);
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                try
                {
                    bool arg_19_0;
                    bool expr_07 = arg_19_0 = this.isGuestVideoTemplate;
                    if (!false)
                    {
                        bool flag = expr_07;
                        arg_19_0 = flag;
                    }
                    while (!arg_19_0)
                    {
                        if (!false)
                        {
                            arg_19_0 = this.SaveSlotTimeFrameDetails(this.VideoTemplateId, this.slotList);
                            if (false)
                            {
                                continue;
                            }
                            this.slotList.Clear();
                        }
                        else
                        {
                        //IL_72:
                        //    ((VideoEditor)this._parent).LoadGuestVideoSlots();
                        IL_83:
                            this.DGManageVideo.ItemsSource = null;
                        }
                        goto IL_E1;
                    }
                    if (!false)
                    {
                       // ((VideoEditor)this._parent).slotList = this.slotList;
                        //goto IL_72;
                    }
                    //goto IL_83;
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            IL_E1:
                while (true)
                {
                    this.HideHandlerDialog();
                    if (4 == 0)
                    {
                        break;
                    }
                    if (8 != 0)
                    {
                        return;
                    }
                }
            }
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

        private void txtSlotFrameTime_KeyUp(object sender, KeyEventArgs e)
        {
            bool arg_10_0;
            bool arg_1C_0 = arg_10_0 = string.IsNullOrEmpty(this.txtSlotFrameTime.Text);
            while (true)
            {
                bool flag;
                if (!false)
                {
                    flag = !arg_10_0;
                    goto IL_14;
                }
            IL_19:
                if (!false)
                {
                    if (arg_1C_0)
                    {
                        this.txtSlotInterval.IsEnabled = false;
                        if (4 != 0)
                        {
                            goto IL_3D;
                        }
                    }
                    this.txtSlotInterval.IsEnabled = true;
                    goto IL_2A;
                }
                continue;
            IL_14:
                if (-1 != 0)
                {
                    arg_1C_0 = (arg_10_0 = flag);
                    goto IL_19;
                }
            IL_3D:
                if (!false)
                {
                    break;
                }
                goto IL_14;
            IL_2A:
                goto IL_3D;
            }
        }

        private void txtSlotInterval_KeyUp(object sender, KeyEventArgs e)
        {
            bool arg_10_0;
            bool arg_1C_0 = arg_10_0 = string.IsNullOrEmpty(this.txtSlotInterval.Text);
            while (true)
            {
                bool flag;
                if (!false)
                {
                    flag = !arg_10_0;
                    goto IL_14;
                }
            IL_19:
                if (!false)
                {
                    if (arg_1C_0)
                    {
                        this.txtSlotFrameTime.IsEnabled = false;
                        if (4 != 0)
                        {
                            goto IL_3D;
                        }
                    }
                    this.txtSlotFrameTime.IsEnabled = true;
                    goto IL_2A;
                }
                continue;
            IL_14:
                if (-1 != 0)
                {
                    arg_1C_0 = (arg_10_0 = flag);
                    goto IL_19;
                }
            IL_3D:
                if (!false)
                {
                    break;
                }
                goto IL_14;
            IL_2A:
                goto IL_3D;
            }
        }

        private void txtSlotFrameTime_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!false)
            {
                bool arg_19_0;
                bool expr_39 = arg_19_0 = string.IsNullOrEmpty(this.txtSlotFrameTime.Text);
                if (!false)
                {
                    bool flag = !expr_39;
                    arg_19_0 = flag;
                }
                if (arg_19_0)
                {
                    return;
                }
            }
            do
            {
                do
                {
                    this.txtSlotInterval.IsEnabled = true;
                }
                while (false);
            }
            while (-1 == 0);
        }

        private void txtSlotInterval_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!false)
            {
                bool arg_19_0;
                bool expr_39 = arg_19_0 = string.IsNullOrEmpty(this.txtSlotInterval.Text);
                if (!false)
                {
                    bool flag = !expr_39;
                    arg_19_0 = flag;
                }
                if (arg_19_0)
                {
                    return;
                }
            }
            do
            {
                do
                {
                    this.txtSlotFrameTime.IsEnabled = true;
                }
                while (false);
            }
            while (-1 == 0);
        }

        private void txtSlotFrameTime_KeyDown(object sender, KeyEventArgs e)
        {
            int arg_29_0;
            bool arg_6D_0;
            if (e.Key == Key.Tab)
            {
                arg_6D_0 = ((arg_29_0 = ((!string.IsNullOrEmpty(this.txtSlotFrameTime.Text)) ? 1 : 0)) != 0);
                if (8 != 0)
                {
                    if (false)
                    {
                        goto IL_29;
                    }
                }
            }
            else
            {
                arg_6D_0 = ((arg_29_0 = 1) != 0);
            }
            if (true)
            {
                bool flag;
                if (!false)
                {
                    flag = arg_6D_0;
                }
                arg_29_0 = (flag ? 1 : 0);
            }
        IL_29:
            if (arg_29_0 != 0)
            {
                goto IL_48;
            }
            this.txtSlotInterval.IsEnabled = true;
            if (false)
            {
                goto IL_46;
            }
        IL_3A:
            this.txtSlotFrameTime.IsEnabled = false;
        IL_46:
        IL_48:
            if (!false)
            {
                return;
            }
            goto IL_3A;
        }

        private void ResetControls()
        {
            this.txtPhotoDisplayTime.Text = string.Empty;
            this.txtSlotFrameTime.Text = string.Empty;
            TextBox expr_21 = this.txtSlotInterval;
            string expr_26 = string.Empty;
            if (!false)
            {
                expr_21.Text = expr_26;
            }
            this.txtSlotFrameTime.IsEnabled = true;
            this.txtSlotInterval.IsEnabled = true;
        }

        private void txtnumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool arg_89_0;
            bool arg_85_0;
            if (!false)
            {
                if (false)
                {
                    goto IL_C4;
                }
                bool arg_1F_0 = string.IsNullOrEmpty(((TextBox)sender).Text);
                bool expr_103;
                do
                {
                    bool flag = !arg_1F_0;
                    expr_103 = (arg_1F_0 = (arg_85_0 = (arg_89_0 = flag)));
                    if (8 == 0)
                    {
                        goto IL_81;
                    }
                }
                while (false);
                if (!expr_103)
                {
                    this.a = "";
                    if (5 != 0)
                    {
                        return;
                    }
                }
            }
            double num = 0.0;
            bool flag2 = double.TryParse(((TextBox)sender).Text, out num);
            arg_89_0 = (arg_85_0 = (flag2 & num >= 0.0));
        IL_81:
            if (-1 != 0)
            {
                bool flag = !arg_85_0;
                arg_89_0 = flag;
            }
            if (!arg_89_0)
            {
                ((TextBox)sender).Text.Trim();
                this.a = ((TextBox)sender).Text;
                return;
            }
            ((TextBox)sender).Text = this.a;
        IL_C4:
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                if (!false)
                {
                    List<VideoTemplateInfo.VideoSlot> expr_06 = this.slotList;
                    if (7 != 0)
                    {
                        expr_06.Clear();
                    }
                    while (5 == 0)
                    {
                    }
                    this.DGManageVideo.ItemsSource = this.slotList;
                }
                if (true)
                {
                    this.DGManageVideo.Items.Refresh();
                }
            }
            while (7 == 0);
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            this.UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            this.txtSlotFrameTime.KeyUp -= new KeyEventHandler(this.txtSlotFrameTime_KeyUp);
            this.txtSlotFrameTime.MouseLeave -= new MouseEventHandler(this.txtSlotFrameTime_MouseLeave);
            if (3 == 0)
            {
                goto IL_169;
            }
            if (3 == 0)
            {
                goto IL_11D;
            }
            this.txtSlotFrameTime.KeyDown -= new KeyEventHandler(this.txtSlotFrameTime_KeyDown);
            this.txtSlotFrameTime.TextChanged -= new TextChangedEventHandler(this.txtnumber_TextChanged);
            this.txtSlotInterval.KeyUp -= new KeyEventHandler(this.txtSlotInterval_KeyUp);
        IL_9D:
            this.txtSlotInterval.MouseLeave -= new MouseEventHandler(this.txtSlotInterval_MouseLeave);
            this.txtSlotInterval.TextChanged -= new TextChangedEventHandler(this.txtnumber_TextChanged);
            if (false)
            {
                goto IL_16A;
            }
            if (5 == 0)
            {
                goto IL_143;
            }
            this.txtPhotoDisplayTime.TextChanged -= new TextChangedEventHandler(this.txtnumber_TextChanged);
            this.btnAdd.Click -= new RoutedEventHandler(this.btnAdd_Click);
            this.btnClear.Click -= new RoutedEventHandler(this.Button_Click);
        IL_11D:
            this.btnClose.Click -= new RoutedEventHandler(this.btnClose_Click);
            if (this.slotList == null)
            {
                goto IL_16A;
            }
        IL_143:
            int arg_155_0;
            int expr_149 = arg_155_0 = this.slotList.Count;
            int arg_155_1;
            int expr_14F = arg_155_1 = 0;
            if (expr_14F != 0)
            {
                goto IL_155;
            }
            arg_155_0 = ((expr_149 > expr_14F) ? 1 : 0);
        IL_154:
            arg_155_1 = 0;
        IL_155:
            bool flag = arg_155_0 == arg_155_1;
            bool expr_158 = (arg_155_0 = (flag ? 1 : 0)) != 0;
            if (3 == 0)
            {
                goto IL_154;
            }
            if (!expr_158)
            {
                this.slotList.Clear();
            }
        IL_169:
        IL_16A:
            if (!false)
            {
                return;
            }
            goto IL_9D;
        }

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
                if (arg_0F_0 == 10 || false)
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
                ((Button)target).Click += new RoutedEventHandler(this.btnDeleteSlot_Click);
                goto IL_2F;
            }
        }
    }
}
