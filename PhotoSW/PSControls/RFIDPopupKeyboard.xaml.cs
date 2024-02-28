using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace PhotoSW.PSControls
{
	public partial  class RFIDPopupKeyboardUserControl : UserControl, IComponentConnector
	{
		private const double AnimationDelay = 150.0;

		private const uint KEYEVENTF_KEYUP = 2u;

		private const byte VK_BACK = 8;

		private const byte VK_LEFT = 37;

		private const byte VK_RIGHT = 39;

		private const byte VK_0 = 48;

		private const byte VK_1 = 49;

		private const byte VK_2 = 50;

		private const byte VK_3 = 51;

		private const byte VK_4 = 52;

		private const byte VK_5 = 53;

		private const byte VK_6 = 54;

		private const byte VK_7 = 55;

		private const byte VK_8 = 56;

		private const byte VK_9 = 57;

		private Popup _parentPopup;

		private Storyboard storyboard;

		public static readonly DependencyProperty PlacementProperty = Popup.PlacementProperty.AddOwner(typeof(RFIDPopupKeyboardUserControl));

		public static readonly DependencyProperty PlacementTargetProperty;

		public static readonly DependencyProperty PlacementRectangleProperty;

		public static readonly DependencyProperty HorizontalOffsetProperty;

		public static readonly DependencyProperty VerticalOffsetProperty;

		public static readonly DependencyProperty StaysOpenProperty;

		public static readonly DependencyProperty CustomPopupPlacementCallbackProperty;

		public static readonly DependencyProperty IsOpenProperty;

		public static readonly DependencyProperty StateProperty;

		public static readonly DependencyProperty NormalHeightProperty;

		public static readonly DependencyProperty NormalWidthProperty;

		

		//private bool _contentLoaded;

		public PlacementMode Placement
		{
			get
			{
				return (PlacementMode)base.GetValue(RFIDPopupKeyboardUserControl.PlacementProperty);
			}
			set
			{
				base.SetValue(RFIDPopupKeyboardUserControl.PlacementProperty, value);
			}
		}

		public UIElement PlacementTarget
		{
			get
			{
				return (UIElement)base.GetValue(RFIDPopupKeyboardUserControl.PlacementTargetProperty);
			}
			set
			{
				base.SetValue(RFIDPopupKeyboardUserControl.PlacementTargetProperty, value);
			}
		}

		public Rect PlacementRectangle
		{
			get
			{
				return (Rect)base.GetValue(RFIDPopupKeyboardUserControl.PlacementRectangleProperty);
			}
			set
			{
				base.SetValue(RFIDPopupKeyboardUserControl.PlacementRectangleProperty, value);
			}
		}

		public double HorizontalOffset
		{
			get
			{
				return (double)base.GetValue(RFIDPopupKeyboardUserControl.HorizontalOffsetProperty);
			}
			set
			{
				base.SetValue(RFIDPopupKeyboardUserControl.HorizontalOffsetProperty, value);
			}
		}

		public double VerticalOffset
		{
			get
			{
				return (double)base.GetValue(RFIDPopupKeyboardUserControl.VerticalOffsetProperty);
			}
			set
			{
				base.SetValue(RFIDPopupKeyboardUserControl.VerticalOffsetProperty, value);
			}
		}

		public bool StaysOpen
		{
			get
			{
				return (bool)base.GetValue(RFIDPopupKeyboardUserControl.StaysOpenProperty);
			}
			set
			{
				base.SetValue(RFIDPopupKeyboardUserControl.StaysOpenProperty, value);
			}
		}

		public CustomPopupPlacementCallback CustomPopupPlacementCallback
		{
			get
			{
				return (CustomPopupPlacementCallback)base.GetValue(RFIDPopupKeyboardUserControl.CustomPopupPlacementCallbackProperty);
			}
			set
			{
				base.SetValue(RFIDPopupKeyboardUserControl.CustomPopupPlacementCallbackProperty, value);
			}
		}

		public bool IsOpen
		{
			get
			{
				return (bool)base.GetValue(RFIDPopupKeyboardUserControl.IsOpenProperty);
			}
			set
			{
				base.SetValue(RFIDPopupKeyboardUserControl.IsOpenProperty, value);
			}
		}

		public KeyboardState State
		{
			get
			{
				return (KeyboardState)base.GetValue(RFIDPopupKeyboardUserControl.StateProperty);
			}
			set
			{
				base.SetValue(RFIDPopupKeyboardUserControl.StateProperty, value);
			}
		}

		public double NormalHeight
		{
			get
			{
				return (double)base.GetValue(RFIDPopupKeyboardUserControl.NormalHeightProperty);
			}
			set
			{
				base.SetValue(RFIDPopupKeyboardUserControl.NormalHeightProperty, value);
			}
		}

		public double NormalWidth
		{
			get
			{
				return (double)base.GetValue(RFIDPopupKeyboardUserControl.NormalWidthProperty);
			}
			set
			{
				base.SetValue(RFIDPopupKeyboardUserControl.NormalWidthProperty, value);
			}
		}

		public RFIDPopupKeyboardUserControl()
		{
			this.InitializeComponent();
		}

		private static void IsOpenChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
		{
			RFIDPopupKeyboardUserControl rFIDPopupKeyboardUserControl;
			do
			{
				rFIDPopupKeyboardUserControl = (RFIDPopupKeyboardUserControl)element;
			}
			while (4 == 0);
			bool flag = !(bool)e.NewValue;
			while (true)
			{
				if (flag)
				{
					goto IL_47;
				}
				bool arg_34_0;
				bool expr_2B = arg_34_0 = (rFIDPopupKeyboardUserControl._parentPopup != null);
				if (true)
				{
					flag = expr_2B;
					arg_34_0 = flag;
				}
				if (arg_34_0)
				{
					goto IL_46;
				}
				IL_36:
				rFIDPopupKeyboardUserControl.HookupParentPopup();
				if (false)
				{
					continue;
				}
				if (5 != 0)
				{
				}
				IL_47:
				if (!false)
				{
					break;
				}
				goto IL_36;
				IL_46:
				goto IL_47;
			}
		}

		private void HookupParentPopup()
		{
			this._parentPopup = new Popup();
			Popup expr_0C = this._parentPopup;
			bool expr_11 = true;
			if (!false)
			{
				expr_0C.AllowsTransparency = expr_11;
			}
			do
			{
				this._parentPopup.PopupAnimation = PopupAnimation.Scroll;
				base.Height = this.NormalHeight;
				if (6 != 0)
				{
					base.Width = this.NormalWidth;
				}
			}
			while (false);
			Popup.CreateRootPopup(this._parentPopup, this);
		}

		private static void StateChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
		{
			RFIDPopupKeyboardUserControl rFIDPopupKeyboardUserControl = (RFIDPopupKeyboardUserControl)element;
			bool flag = (KeyboardState)e.NewValue != KeyboardState.Normal;
			if (!flag)
			{
				rFIDPopupKeyboardUserControl.IsOpen = true;
			}
			else
			{
				bool expr_36 = (KeyboardState)e.NewValue != KeyboardState.Hidden;
				if (!false)
				{
					flag = expr_36;
				}
				if (!flag)
				{
					rFIDPopupKeyboardUserControl.HideKeyboard();
				}
			}
		}

		private void HideKeyboard()
		{
			DoubleAnimation doubleAnimation;
			DoubleAnimation doubleAnimation2;
			if (2 != 0)
			{
				base.RegisterName("HidePopupKeyboard", this);
				if (false)
				{
					goto IL_11D;
				}
				this.storyboard = new Storyboard();
				if (!false)
				{
					this.storyboard.Completed += new EventHandler(this.storyboard_Completed);
					doubleAnimation = new DoubleAnimation();
					doubleAnimation.From = new double?(this.NormalWidth);
					doubleAnimation.To = new double?(0.0);
					doubleAnimation.Duration = TimeSpan.FromMilliseconds(150.0);
					doubleAnimation.FillBehavior = FillBehavior.Stop;
					doubleAnimation2 = new DoubleAnimation();
				}
				doubleAnimation2.From = new double?(this.NormalHeight);
				if (!false)
				{
				}
			}
			doubleAnimation2.To = new double?(0.0);
			doubleAnimation2.Duration = TimeSpan.FromMilliseconds(150.0);
			doubleAnimation2.FillBehavior = FillBehavior.Stop;
			Storyboard.SetTargetName(doubleAnimation, "HidePopupKeyboard");
			Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(FrameworkElement.WidthProperty));
			Storyboard.SetTargetName(doubleAnimation2, "HidePopupKeyboard");
			IL_11D:
			Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath(FrameworkElement.HeightProperty));
			this.storyboard.Children.Add(doubleAnimation);
			this.storyboard.Children.Add(doubleAnimation2);
			this.storyboard.Begin(this);
		}

		private void storyboard_Completed(object sender, EventArgs e)
		{
			this.IsOpen = false;
		}

		public void LocationChange()
		{
			while (true)
			{
				while (this._parentPopup != null)
				{
					if (!false)
					{
						if (2 != 0)
						{
							goto Block_2;
						}
					}
				}
				goto IL_43;
			}
			Block_2:
			this.IsOpen = false;
			if (8 != 0)
			{
				this._parentPopup.PopupAnimation = PopupAnimation.None;
			}
			IL_2C:
			this.IsOpen = true;
			this._parentPopup.PopupAnimation = PopupAnimation.Scroll;
			if (5 != 0)
			{
			}
			IL_43:
			if (!false)
			{
				return;
			}
			goto IL_2C;
		}

		private void cmdNumericButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Button button = (Button)sender;
                  Dictionary<string, int> obj1 = new Dictionary<string, int>();
                obj1.Add(button.Name.ToString(),1);

				while (true)
				{
					string name = button.Name;
					if (name != null)
					{
                        
						if (button == null)
						{
							goto IL_36;
						}
						IL_FE:
						int num=0;


                        if (obj1.TryGetValue(name, out num))
						{
							switch (num)
							{
							case 0:
								goto IL_15D;
							case 1:
								goto IL_18A;
							case 2:
								goto IL_1C0;
							case 3:
								goto IL_1ED;
							case 4:
								goto IL_21A;
							case 5:
								goto IL_247;
							case 6:
								goto IL_27D;
							case 7:
								goto IL_2AA;
							case 8:
								goto IL_2D7;
							case 9:
								RFIDPopupKeyboardUserControl.keybd_event(48, 0, 0u, (UIntPtr)0u);
								RFIDPopupKeyboardUserControl.keybd_event(48, 0, 2u, (UIntPtr)0u);
								e.Handled = true;
								if (4 != 0)
								{
									goto Block_8;
								}
								continue;
							case 10:
								goto IL_33D;
							case 11:
								goto IL_373;
							case 12:
								if (!false)
								{
									goto Block_11;
								}
								goto IL_36;
							case 13:
								goto IL_3CE;
							case 14:
								goto IL_3F8;
							}
							break;
						}
						break;
						IL_36:
						Dictionary<string, int> obj = new Dictionary<string, int>(15)
						{
							{
								"btn010300",
								0
							},
							{
								"btn010301",
								1
							},
							{
								"btn010302",
								2
							},
							{
								"btn010200",
								3
							},
							{
								"btn010201",
								4
							},
							{
								"btn010202",
								5
							},
							{
								"btn010100",
								6
							},
							{
								"btn010101",
								7
							},
							{
								"btn010102",
								8
							},
							{
								"btn010400",
								9
							},
							{
								"btn010103",
								10
							},
							{
								"btn010402",
								11
							},
							{
								"btn010203",
								12
							},
							{
								"btn010303",
								13
							},
							{
								"btn010401",
								14
							}
						};
						goto IL_FE;
					}
					break;
				}
				goto IL_428;
				IL_15D:
				RFIDPopupKeyboardUserControl.keybd_event(49, 0, 0u, (UIntPtr)0u);
				RFIDPopupKeyboardUserControl.keybd_event(49, 0, 2u, (UIntPtr)0u);
				IL_17C:
				e.Handled = true;
				goto IL_428;
				IL_18A:
				int arg_38B_0;
				byte expr_18A = (byte)(arg_38B_0 = 50);
				int arg_38B_1;
				byte expr_18C = (byte)(arg_38B_1 = 0);
				int arg_38B_2;
				uint expr_18D = (uint)(arg_38B_2 = 0);
				UIntPtr arg_38B_3;
				UIntPtr expr_18F = arg_38B_3 = (UIntPtr)0u;
				if (2 == 0)
				{
					goto IL_38B;
				}
				RFIDPopupKeyboardUserControl.keybd_event(expr_18A, expr_18C, expr_18D, expr_18F);
				RFIDPopupKeyboardUserControl.keybd_event(50, 0, 2u, (UIntPtr)0u);
				if (false)
				{
					goto IL_17C;
				}
				IL_1B3:
				e.Handled = true;
				goto IL_428;
				IL_1C0:
				RFIDPopupKeyboardUserControl.keybd_event(51, 0, 0u, (UIntPtr)0u);
				RFIDPopupKeyboardUserControl.keybd_event(51, 0, 2u, (UIntPtr)0u);
				e.Handled = true;
				goto IL_428;
				IL_1ED:
				RFIDPopupKeyboardUserControl.keybd_event(52, 0, 0u, (UIntPtr)0u);
				RFIDPopupKeyboardUserControl.keybd_event(52, 0, 2u, (UIntPtr)0u);
				e.Handled = true;
				goto IL_428;
				IL_21A:
				RFIDPopupKeyboardUserControl.keybd_event(53, 0, 0u, (UIntPtr)0u);
				RFIDPopupKeyboardUserControl.keybd_event(53, 0, 2u, (UIntPtr)0u);
				IL_23A:
				e.Handled = true;
				goto IL_428;
				IL_247:
				int arg_418_0;
				byte expr_247 = (byte)(arg_418_0 = 54);
				int arg_418_1;
				byte expr_249 = (byte)(arg_418_1 = 0);
				int arg_418_2;
				uint expr_24A = (uint)(arg_418_2 = 0);
				int arg_413_0;
				int expr_24C = arg_413_0 = 0;
				if (expr_24C != 0)
				{
					goto IL_413;
				}
				RFIDPopupKeyboardUserControl.keybd_event(expr_247, expr_249, expr_24A, (UIntPtr)((uint)expr_24C));
				RFIDPopupKeyboardUserControl.keybd_event(54, 0, 2u, (UIntPtr)0u);
				if (!false)
				{
					e.Handled = true;
					goto IL_428;
				}
				goto IL_23A;
				IL_27D:
				RFIDPopupKeyboardUserControl.keybd_event(55, 0, 0u, (UIntPtr)0u);
				RFIDPopupKeyboardUserControl.keybd_event(55, 0, 2u, (UIntPtr)0u);
				e.Handled = true;
				goto IL_428;
				IL_2AA:
				RFIDPopupKeyboardUserControl.keybd_event(56, 0, 0u, (UIntPtr)0u);
				RFIDPopupKeyboardUserControl.keybd_event(56, 0, 2u, (UIntPtr)0u);
				e.Handled = true;
				goto IL_428;
				IL_2D7:
				RFIDPopupKeyboardUserControl.keybd_event(57, 0, 0u, (UIntPtr)0u);
				RFIDPopupKeyboardUserControl.keybd_event(57, 0, 2u, (UIntPtr)0u);
				e.Handled = true;
				goto IL_428;
				Block_8:
				if (8 != 0)
				{
					goto IL_428;
				}
				goto IL_1B3;
				IL_33D:
				RFIDPopupKeyboardUserControl.keybd_event(189, 0, 0u, (UIntPtr)0u);
				RFIDPopupKeyboardUserControl.keybd_event(189, 0, 2u, (UIntPtr)0u);
				while (7 == 0)
				{
				}
				e.Handled = true;
				goto IL_428;
				IL_373:
				RFIDPopupKeyboardUserControl.keybd_event(8, 0, 0u, (UIntPtr)0u);
				arg_38B_0 = 8;
				arg_38B_1 = 0;
				arg_38B_2 = 2;
				arg_38B_3 = (UIntPtr)0u;
				IL_38B:
				RFIDPopupKeyboardUserControl.keybd_event((byte)arg_38B_0, (byte)arg_38B_1, (uint)arg_38B_2, arg_38B_3);
				e.Handled = true;
				goto IL_428;
				Block_11:
				RFIDPopupKeyboardUserControl.keybd_event(37, 0, 0u, (UIntPtr)0u);
				RFIDPopupKeyboardUserControl.keybd_event(37, 0, 2u, (UIntPtr)0u);
				e.Handled = true;
				goto IL_428;
				IL_3CE:
				RFIDPopupKeyboardUserControl.keybd_event(39, 0, 0u, (UIntPtr)0u);
				RFIDPopupKeyboardUserControl.keybd_event(39, 0, 2u, (UIntPtr)0u);
				e.Handled = true;
				goto IL_428;
				IL_3F8:
				RFIDPopupKeyboardUserControl.keybd_event(190, 0, 0u, (UIntPtr)0u);
				arg_418_0 = 190;
				arg_418_1 = 0;
				arg_418_2 = 2;
				arg_413_0 = 0;
				IL_413:
				RFIDPopupKeyboardUserControl.keybd_event((byte)arg_418_0, (byte)arg_418_1, (uint)arg_418_2, (UIntPtr)((uint)arg_413_0));
				e.Handled = true;
				IL_428:;
			}
			catch
			{
			}
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			this.State = KeyboardState.Hidden;
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);


		static RFIDPopupKeyboardUserControl()
		{
			// Note: this type is marked as 'beforefieldinit'.
			do
			{
				RFIDPopupKeyboardUserControl.PlacementTargetProperty = Popup.PlacementTargetProperty.AddOwner(typeof(RFIDPopupKeyboardUserControl));
				RFIDPopupKeyboardUserControl.PlacementRectangleProperty = Popup.PlacementRectangleProperty.AddOwner(typeof(RFIDPopupKeyboardUserControl));
				RFIDPopupKeyboardUserControl.HorizontalOffsetProperty = Popup.HorizontalOffsetProperty.AddOwner(typeof(RFIDPopupKeyboardUserControl));
				while (true)
				{
					RFIDPopupKeyboardUserControl.VerticalOffsetProperty = Popup.VerticalOffsetProperty.AddOwner(typeof(RFIDPopupKeyboardUserControl));
					if (5 != 0)
					{
						RFIDPopupKeyboardUserControl.StaysOpenProperty = Popup.StaysOpenProperty.AddOwner(typeof(RFIDPopupKeyboardUserControl));
						RFIDPopupKeyboardUserControl.CustomPopupPlacementCallbackProperty = Popup.CustomPopupPlacementCallbackProperty.AddOwner(typeof(RFIDPopupKeyboardUserControl));
					}
					while (true)
					{
						RFIDPopupKeyboardUserControl.IsOpenProperty = Popup.IsOpenProperty.AddOwner(typeof(RFIDPopupKeyboardUserControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(RFIDPopupKeyboardUserControl.IsOpenChanged)));
						if (6 == 0)
						{
							break;
						}
						RFIDPopupKeyboardUserControl.StateProperty = DependencyProperty.Register("State", typeof(KeyboardState), typeof(RFIDPopupKeyboardUserControl), new FrameworkPropertyMetadata(KeyboardState.Normal, new PropertyChangedCallback(RFIDPopupKeyboardUserControl.StateChanged)));
						RFIDPopupKeyboardUserControl.NormalHeightProperty = DependencyProperty.Register("NormalHeight", typeof(double), typeof(RFIDPopupKeyboardUserControl), new FrameworkPropertyMetadata(0.0));
						if (6 != 0)
						{
							goto Block_3;
						}
					}
				}
				Block_3:
				RFIDPopupKeyboardUserControl.NormalWidthProperty = DependencyProperty.Register("NormalWidth", typeof(double), typeof(RFIDPopupKeyboardUserControl), new FrameworkPropertyMetadata(0.0));
			}
			while (6 == 0);
		}
	}
}
