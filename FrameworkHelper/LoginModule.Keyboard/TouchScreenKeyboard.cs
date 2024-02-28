using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LoginModule.Keyboard
{
	public class TouchScreenKeyboard : Window
	{
		private static double _WidthTouchKeyboard;

		private static bool _ShiftFlag;

		private static bool _CapsLockFlag;

		private static Window _InstanceObject;

		private static Brush _PreviousTextBoxBackgroundBrush;

		private static Brush _PreviousTextBoxBorderBrush;

		private static Thickness _PreviousTextBoxBorderThickness;

		private static Control _CurrentControl;

		public static RoutedUICommand CmdTlide;

		public static RoutedUICommand Cmd1;

		public static RoutedUICommand Cmd2;

		public static RoutedUICommand Cmd3;

		public static RoutedUICommand Cmd4;

		public static RoutedUICommand Cmd5;

		public static RoutedUICommand Cmd6;

		public static RoutedUICommand Cmd7;

		public static RoutedUICommand Cmd8;

		public static RoutedUICommand Cmd9;

		public static RoutedUICommand Cmd0;

		public static RoutedUICommand CmdMinus;

		public static RoutedUICommand CmdPlus;

		public static RoutedUICommand CmdBackspace;

		public static RoutedUICommand CmdTab;

		public static RoutedUICommand CmdQ;

		public static RoutedUICommand Cmdw;

		public static RoutedUICommand CmdE;

		public static RoutedUICommand CmdR;

		public static RoutedUICommand CmdT;

		public static RoutedUICommand CmdY;

		public static RoutedUICommand CmdU;

		public static RoutedUICommand CmdI;

		public static RoutedUICommand CmdO;

		public static RoutedUICommand CmdP;

		public static RoutedUICommand CmdOpenCrulyBrace;

		public static RoutedUICommand CmdEndCrultBrace;

		public static RoutedUICommand CmdOR;

		public static RoutedUICommand CmdCapsLock;

		public static RoutedUICommand CmdA;

		public static RoutedUICommand CmdS;

		public static RoutedUICommand CmdD;

		public static RoutedUICommand CmdF;

		public static RoutedUICommand CmdG;

		public static RoutedUICommand CmdH;

		public static RoutedUICommand CmdJ;

		public static RoutedUICommand CmdK;

		public static RoutedUICommand CmdL;

		public static RoutedUICommand CmdColon;

		public static RoutedUICommand CmdDoubleInvertedComma;

		public static RoutedUICommand CmdEnter;

		public static RoutedUICommand CmdShift;

		public static RoutedUICommand CmdZ;

		public static RoutedUICommand CmdX;

		public static RoutedUICommand CmdC;

		public static RoutedUICommand CmdV;

		public static RoutedUICommand CmdB;

		public static RoutedUICommand CmdN;

		public static RoutedUICommand CmdM;

		public static RoutedUICommand CmdGreaterThan;

		public static RoutedUICommand CmdLessThan;

		public static RoutedUICommand CmdQuestion;

		public static RoutedUICommand CmdSpaceBar;

		public static RoutedUICommand CmdClear;

		public static readonly DependencyProperty TouchScreenKeyboardProperty;

		public static double WidthTouchKeyboard
		{
			get
			{
				return TouchScreenKeyboard._WidthTouchKeyboard;
			}
			set
			{
				TouchScreenKeyboard._WidthTouchKeyboard = value;
			}
		}

		protected static bool ShiftFlag
		{
			get
			{
				return TouchScreenKeyboard._ShiftFlag;
			}
			set
			{
				TouchScreenKeyboard._ShiftFlag = value;
			}
		}

		protected static bool CapsLockFlag
		{
			get
			{
				return TouchScreenKeyboard._CapsLockFlag;
			}
			set
			{
				TouchScreenKeyboard._CapsLockFlag = value;
			}
		}

		public static string TouchScreenText
		{
			get
			{
				string result;
				if (TouchScreenKeyboard._CurrentControl is TextBox)
				{
					result = ((TextBox)TouchScreenKeyboard._CurrentControl).Text;
				}
				else if (TouchScreenKeyboard._CurrentControl is PasswordBox)
				{
					result = ((PasswordBox)TouchScreenKeyboard._CurrentControl).Password;
				}
				else
				{
					result = "";
				}
				return result;
			}
			set
			{
				if (TouchScreenKeyboard._CurrentControl is TextBox)
				{
					((TextBox)TouchScreenKeyboard._CurrentControl).Text = value;
				}
				else if (TouchScreenKeyboard._CurrentControl is PasswordBox)
				{
					((PasswordBox)TouchScreenKeyboard._CurrentControl).Password = value;
				}
			}
		}

		public TouchScreenKeyboard()
		{
			base.Width = TouchScreenKeyboard.WidthTouchKeyboard;
		}

		static TouchScreenKeyboard()
		{
			TouchScreenKeyboard._WidthTouchKeyboard = 830.0;
			TouchScreenKeyboard._PreviousTextBoxBackgroundBrush = null;
			TouchScreenKeyboard._PreviousTextBoxBorderBrush = null;
			TouchScreenKeyboard.CmdTlide = new RoutedUICommand();
			TouchScreenKeyboard.Cmd1 = new RoutedUICommand();
			TouchScreenKeyboard.Cmd2 = new RoutedUICommand();
			TouchScreenKeyboard.Cmd3 = new RoutedUICommand();
			TouchScreenKeyboard.Cmd4 = new RoutedUICommand();
			TouchScreenKeyboard.Cmd5 = new RoutedUICommand();
			TouchScreenKeyboard.Cmd6 = new RoutedUICommand();
			TouchScreenKeyboard.Cmd7 = new RoutedUICommand();
			TouchScreenKeyboard.Cmd8 = new RoutedUICommand();
			TouchScreenKeyboard.Cmd9 = new RoutedUICommand();
			TouchScreenKeyboard.Cmd0 = new RoutedUICommand();
			TouchScreenKeyboard.CmdMinus = new RoutedUICommand();
			TouchScreenKeyboard.CmdPlus = new RoutedUICommand();
			TouchScreenKeyboard.CmdBackspace = new RoutedUICommand();
			TouchScreenKeyboard.CmdTab = new RoutedUICommand();
			TouchScreenKeyboard.CmdQ = new RoutedUICommand();
			TouchScreenKeyboard.Cmdw = new RoutedUICommand();
			TouchScreenKeyboard.CmdE = new RoutedUICommand();
			TouchScreenKeyboard.CmdR = new RoutedUICommand();
			TouchScreenKeyboard.CmdT = new RoutedUICommand();
			TouchScreenKeyboard.CmdY = new RoutedUICommand();
			TouchScreenKeyboard.CmdU = new RoutedUICommand();
			TouchScreenKeyboard.CmdI = new RoutedUICommand();
			TouchScreenKeyboard.CmdO = new RoutedUICommand();
			TouchScreenKeyboard.CmdP = new RoutedUICommand();
			TouchScreenKeyboard.CmdOpenCrulyBrace = new RoutedUICommand();
			TouchScreenKeyboard.CmdEndCrultBrace = new RoutedUICommand();
			TouchScreenKeyboard.CmdOR = new RoutedUICommand();
			TouchScreenKeyboard.CmdCapsLock = new RoutedUICommand();
			TouchScreenKeyboard.CmdA = new RoutedUICommand();
			TouchScreenKeyboard.CmdS = new RoutedUICommand();
			TouchScreenKeyboard.CmdD = new RoutedUICommand();
			TouchScreenKeyboard.CmdF = new RoutedUICommand();
			TouchScreenKeyboard.CmdG = new RoutedUICommand();
			TouchScreenKeyboard.CmdH = new RoutedUICommand();
			TouchScreenKeyboard.CmdJ = new RoutedUICommand();
			TouchScreenKeyboard.CmdK = new RoutedUICommand();
			TouchScreenKeyboard.CmdL = new RoutedUICommand();
			TouchScreenKeyboard.CmdColon = new RoutedUICommand();
			TouchScreenKeyboard.CmdDoubleInvertedComma = new RoutedUICommand();
			TouchScreenKeyboard.CmdEnter = new RoutedUICommand();
			TouchScreenKeyboard.CmdShift = new RoutedUICommand();
			TouchScreenKeyboard.CmdZ = new RoutedUICommand();
			TouchScreenKeyboard.CmdX = new RoutedUICommand();
			TouchScreenKeyboard.CmdC = new RoutedUICommand();
			TouchScreenKeyboard.CmdV = new RoutedUICommand();
			TouchScreenKeyboard.CmdB = new RoutedUICommand();
			TouchScreenKeyboard.CmdN = new RoutedUICommand();
			TouchScreenKeyboard.CmdM = new RoutedUICommand();
			TouchScreenKeyboard.CmdGreaterThan = new RoutedUICommand();
			TouchScreenKeyboard.CmdLessThan = new RoutedUICommand();
			TouchScreenKeyboard.CmdQuestion = new RoutedUICommand();
			TouchScreenKeyboard.CmdSpaceBar = new RoutedUICommand();
			TouchScreenKeyboard.CmdClear = new RoutedUICommand();
			TouchScreenKeyboard.TouchScreenKeyboardProperty = DependencyProperty.RegisterAttached("TouchScreenKeyboard", typeof(bool), typeof(TouchScreenKeyboard), new UIPropertyMetadata(false, new PropertyChangedCallback(TouchScreenKeyboard.TouchScreenKeyboardPropertyChanged)));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TouchScreenKeyboard), new FrameworkPropertyMetadata(typeof(TouchScreenKeyboard)));
			TouchScreenKeyboard.SetCommandBinding();
		}

		private static void SetCommandBinding()
		{
			CommandBinding commandBinding = new CommandBinding(TouchScreenKeyboard.CmdTlide, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding2 = new CommandBinding(TouchScreenKeyboard.Cmd1, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding3 = new CommandBinding(TouchScreenKeyboard.Cmd2, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding4 = new CommandBinding(TouchScreenKeyboard.Cmd3, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding5 = new CommandBinding(TouchScreenKeyboard.Cmd4, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding6 = new CommandBinding(TouchScreenKeyboard.Cmd5, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding7 = new CommandBinding(TouchScreenKeyboard.Cmd6, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding8 = new CommandBinding(TouchScreenKeyboard.Cmd7, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding9 = new CommandBinding(TouchScreenKeyboard.Cmd8, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding10 = new CommandBinding(TouchScreenKeyboard.Cmd9, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding11 = new CommandBinding(TouchScreenKeyboard.Cmd0, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding12 = new CommandBinding(TouchScreenKeyboard.CmdMinus, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding13 = new CommandBinding(TouchScreenKeyboard.CmdPlus, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding14 = new CommandBinding(TouchScreenKeyboard.CmdBackspace, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding2);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding3);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding4);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding5);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding6);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding7);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding8);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding9);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding10);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding11);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding12);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding13);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding14);
			CommandBinding commandBinding15 = new CommandBinding(TouchScreenKeyboard.CmdTab, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding16 = new CommandBinding(TouchScreenKeyboard.CmdQ, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding17 = new CommandBinding(TouchScreenKeyboard.Cmdw, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding18 = new CommandBinding(TouchScreenKeyboard.CmdE, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding19 = new CommandBinding(TouchScreenKeyboard.CmdR, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding20 = new CommandBinding(TouchScreenKeyboard.CmdT, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding21 = new CommandBinding(TouchScreenKeyboard.CmdY, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding22 = new CommandBinding(TouchScreenKeyboard.CmdU, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding23 = new CommandBinding(TouchScreenKeyboard.CmdI, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding24 = new CommandBinding(TouchScreenKeyboard.CmdO, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding25 = new CommandBinding(TouchScreenKeyboard.CmdP, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding26 = new CommandBinding(TouchScreenKeyboard.CmdOpenCrulyBrace, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding27 = new CommandBinding(TouchScreenKeyboard.CmdEndCrultBrace, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding28 = new CommandBinding(TouchScreenKeyboard.CmdOR, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding29 = new CommandBinding(TouchScreenKeyboard.CmdCapsLock, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding30 = new CommandBinding(TouchScreenKeyboard.CmdA, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding31 = new CommandBinding(TouchScreenKeyboard.CmdS, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding32 = new CommandBinding(TouchScreenKeyboard.CmdD, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding33 = new CommandBinding(TouchScreenKeyboard.CmdF, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding34 = new CommandBinding(TouchScreenKeyboard.CmdG, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding35 = new CommandBinding(TouchScreenKeyboard.CmdH, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding36 = new CommandBinding(TouchScreenKeyboard.CmdJ, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding37 = new CommandBinding(TouchScreenKeyboard.CmdK, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding38 = new CommandBinding(TouchScreenKeyboard.CmdL, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding39 = new CommandBinding(TouchScreenKeyboard.CmdColon, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding40 = new CommandBinding(TouchScreenKeyboard.CmdDoubleInvertedComma, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding41 = new CommandBinding(TouchScreenKeyboard.CmdEnter, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding42 = new CommandBinding(TouchScreenKeyboard.CmdShift, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding43 = new CommandBinding(TouchScreenKeyboard.CmdZ, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding44 = new CommandBinding(TouchScreenKeyboard.CmdX, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding45 = new CommandBinding(TouchScreenKeyboard.CmdC, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding46 = new CommandBinding(TouchScreenKeyboard.CmdV, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding47 = new CommandBinding(TouchScreenKeyboard.CmdB, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding48 = new CommandBinding(TouchScreenKeyboard.CmdN, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding49 = new CommandBinding(TouchScreenKeyboard.CmdM, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding50 = new CommandBinding(TouchScreenKeyboard.CmdGreaterThan, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding51 = new CommandBinding(TouchScreenKeyboard.CmdLessThan, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding52 = new CommandBinding(TouchScreenKeyboard.CmdQuestion, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding53 = new CommandBinding(TouchScreenKeyboard.CmdSpaceBar, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandBinding commandBinding54 = new CommandBinding(TouchScreenKeyboard.CmdClear, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding15);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding16);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding17);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding18);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding19);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding20);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding21);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding22);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding23);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding24);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding25);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding26);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding27);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding28);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding29);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding30);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding31);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding32);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding33);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding34);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding35);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding36);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding37);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding38);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding39);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding40);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding41);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding42);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding43);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding44);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding45);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding46);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding47);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding48);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding49);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding50);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding51);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding52);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding53);
			CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding54);
		}

		private static void RunCommand(object sender, ExecutedRoutedEventArgs e)
		{
			if (e.Command == TouchScreenKeyboard.CmdTlide)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += "`";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += "~";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.Cmd1)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += "1";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += "!";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.Cmd2)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += "2";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += "@";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.Cmd3)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += "3";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += "#";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.Cmd4)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += "4";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += "$";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.Cmd5)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += "5";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += "%";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.Cmd6)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += "6";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += "^";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.Cmd7)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += "7";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += "&";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.Cmd8)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += "8";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += "*";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.Cmd9)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += "9";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += "(";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.Cmd0)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += "0";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += ")";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.CmdMinus)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += "-";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += "_";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.CmdPlus)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += "=";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += "+";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.CmdBackspace)
			{
				if (!string.IsNullOrEmpty(TouchScreenKeyboard.TouchScreenText))
				{
					TouchScreenKeyboard.TouchScreenText = TouchScreenKeyboard.TouchScreenText.Substring(0, TouchScreenKeyboard.TouchScreenText.Length - 1);
				}
			}
			else if (e.Command == TouchScreenKeyboard.CmdTab)
			{
				TouchScreenKeyboard.TouchScreenText += "     ";
			}
			else if (e.Command == TouchScreenKeyboard.CmdQ)
			{
				TouchScreenKeyboard.AddKeyBoardINput('Q');
			}
			else if (e.Command == TouchScreenKeyboard.Cmdw)
			{
				TouchScreenKeyboard.AddKeyBoardINput('w');
			}
			else if (e.Command == TouchScreenKeyboard.CmdE)
			{
				TouchScreenKeyboard.AddKeyBoardINput('E');
			}
			else if (e.Command == TouchScreenKeyboard.CmdR)
			{
				TouchScreenKeyboard.AddKeyBoardINput('R');
			}
			else if (e.Command == TouchScreenKeyboard.CmdT)
			{
				TouchScreenKeyboard.AddKeyBoardINput('T');
			}
			else if (e.Command == TouchScreenKeyboard.CmdY)
			{
				TouchScreenKeyboard.AddKeyBoardINput('Y');
			}
			else if (e.Command == TouchScreenKeyboard.CmdU)
			{
				TouchScreenKeyboard.AddKeyBoardINput('U');
			}
			else if (e.Command == TouchScreenKeyboard.CmdI)
			{
				TouchScreenKeyboard.AddKeyBoardINput('I');
			}
			else if (e.Command == TouchScreenKeyboard.CmdO)
			{
				TouchScreenKeyboard.AddKeyBoardINput('O');
			}
			else if (e.Command == TouchScreenKeyboard.CmdP)
			{
				TouchScreenKeyboard.AddKeyBoardINput('P');
			}
			else if (e.Command == TouchScreenKeyboard.CmdOpenCrulyBrace)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += "[";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += "{";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.CmdEndCrultBrace)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += "]";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += "}";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.CmdOR)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += "\\";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += "|";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.CmdCapsLock)
			{
				if (!TouchScreenKeyboard.CapsLockFlag)
				{
					TouchScreenKeyboard.CapsLockFlag = true;
				}
				else
				{
					TouchScreenKeyboard.CapsLockFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.CmdA)
			{
				TouchScreenKeyboard.AddKeyBoardINput('A');
			}
			else if (e.Command == TouchScreenKeyboard.CmdS)
			{
				TouchScreenKeyboard.AddKeyBoardINput('S');
			}
			else if (e.Command == TouchScreenKeyboard.CmdD)
			{
				TouchScreenKeyboard.AddKeyBoardINput('D');
			}
			else if (e.Command == TouchScreenKeyboard.CmdF)
			{
				TouchScreenKeyboard.AddKeyBoardINput('F');
			}
			else if (e.Command == TouchScreenKeyboard.CmdG)
			{
				TouchScreenKeyboard.AddKeyBoardINput('G');
			}
			else if (e.Command == TouchScreenKeyboard.CmdH)
			{
				TouchScreenKeyboard.AddKeyBoardINput('H');
			}
			else if (e.Command == TouchScreenKeyboard.CmdJ)
			{
				TouchScreenKeyboard.AddKeyBoardINput('J');
			}
			else if (e.Command == TouchScreenKeyboard.CmdK)
			{
				TouchScreenKeyboard.AddKeyBoardINput('K');
			}
			else if (e.Command == TouchScreenKeyboard.CmdL)
			{
				TouchScreenKeyboard.AddKeyBoardINput('L');
			}
			else if (e.Command == TouchScreenKeyboard.CmdColon)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += ";";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += ":";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.CmdDoubleInvertedComma)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += "'";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += char.ConvertFromUtf32(34);
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.CmdEnter)
			{
				if (TouchScreenKeyboard._InstanceObject != null)
				{
					TouchScreenKeyboard._InstanceObject.Close();
					TouchScreenKeyboard._InstanceObject = null;
				}
				TouchScreenKeyboard._CurrentControl.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
			}
			else if (e.Command == TouchScreenKeyboard.CmdShift)
			{
				TouchScreenKeyboard.ShiftFlag = true;
			}
			else if (e.Command == TouchScreenKeyboard.CmdZ)
			{
				TouchScreenKeyboard.AddKeyBoardINput('Z');
			}
			else if (e.Command == TouchScreenKeyboard.CmdX)
			{
				TouchScreenKeyboard.AddKeyBoardINput('X');
			}
			else if (e.Command == TouchScreenKeyboard.CmdC)
			{
				TouchScreenKeyboard.AddKeyBoardINput('C');
			}
			else if (e.Command == TouchScreenKeyboard.CmdV)
			{
				TouchScreenKeyboard.AddKeyBoardINput('V');
			}
			else if (e.Command == TouchScreenKeyboard.CmdB)
			{
				TouchScreenKeyboard.AddKeyBoardINput('B');
			}
			else if (e.Command == TouchScreenKeyboard.CmdN)
			{
				TouchScreenKeyboard.AddKeyBoardINput('N');
			}
			else if (e.Command == TouchScreenKeyboard.CmdM)
			{
				TouchScreenKeyboard.AddKeyBoardINput('M');
			}
			else if (e.Command == TouchScreenKeyboard.CmdLessThan)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += ",";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += "<";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.CmdGreaterThan)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += ".";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += ">";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.CmdQuestion)
			{
				if (!TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += "/";
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += "?";
					TouchScreenKeyboard.ShiftFlag = false;
				}
			}
			else if (e.Command == TouchScreenKeyboard.CmdSpaceBar)
			{
				TouchScreenKeyboard.TouchScreenText += " ";
			}
			else if (e.Command == TouchScreenKeyboard.CmdClear)
			{
				TouchScreenKeyboard.TouchScreenText = "";
			}
		}

		private static void AddKeyBoardINput(char input)
		{
			if (TouchScreenKeyboard.CapsLockFlag)
			{
				if (TouchScreenKeyboard.ShiftFlag)
				{
					TouchScreenKeyboard.TouchScreenText += char.ToLower(input).ToString();
					TouchScreenKeyboard.ShiftFlag = false;
				}
				else
				{
					TouchScreenKeyboard.TouchScreenText += char.ToUpper(input).ToString();
				}
			}
			else if (!TouchScreenKeyboard.ShiftFlag)
			{
				TouchScreenKeyboard.TouchScreenText += char.ToLower(input).ToString();
			}
			else
			{
				TouchScreenKeyboard.TouchScreenText += char.ToUpper(input).ToString();
				TouchScreenKeyboard.ShiftFlag = false;
			}
		}

		private static void syncchild()
		{
			if (TouchScreenKeyboard._CurrentControl != null && TouchScreenKeyboard._InstanceObject != null)
			{
				Point point = new Point(0.0, TouchScreenKeyboard._CurrentControl.ActualHeight + 3.0);
				Point point2 = TouchScreenKeyboard._CurrentControl.PointToScreen(point);
				if (TouchScreenKeyboard.WidthTouchKeyboard + point2.X > SystemParameters.VirtualScreenWidth)
				{
					double num = TouchScreenKeyboard.WidthTouchKeyboard + point2.X - SystemParameters.VirtualScreenWidth;
					TouchScreenKeyboard._InstanceObject.Left = point2.X - num;
				}
				else if (point2.X <= 1.0)
				{
					TouchScreenKeyboard._InstanceObject.Left = 1.0;
				}
				else
				{
					TouchScreenKeyboard._InstanceObject.Left = point2.X;
				}
				TouchScreenKeyboard._InstanceObject.Top = point2.Y;
				TouchScreenKeyboard._InstanceObject.Show();
			}
		}

		public static bool GetTouchScreenKeyboard(DependencyObject obj)
		{
			return (bool)obj.GetValue(TouchScreenKeyboard.TouchScreenKeyboardProperty);
		}

		public static void SetTouchScreenKeyboard(DependencyObject obj, bool value)
		{
			obj.SetValue(TouchScreenKeyboard.TouchScreenKeyboardProperty, value);
		}

		private static void TouchScreenKeyboardPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			FrameworkElement frameworkElement = sender as FrameworkElement;
			if (frameworkElement != null)
			{
				frameworkElement.GotFocus += new RoutedEventHandler(TouchScreenKeyboard.OnGotFocus);
				frameworkElement.LostFocus += new RoutedEventHandler(TouchScreenKeyboard.OnLostFocus);
			}
		}

		private static void OnGotFocus(object sender, RoutedEventArgs e)
		{
			Control control = sender as Control;
			TouchScreenKeyboard._PreviousTextBoxBackgroundBrush = control.Background;
			TouchScreenKeyboard._PreviousTextBoxBorderBrush = control.BorderBrush;
			TouchScreenKeyboard._PreviousTextBoxBorderThickness = control.BorderThickness;
			control.Background = Brushes.Yellow;
			control.BorderBrush = Brushes.Red;
			control.BorderThickness = new Thickness(4.0);
			TouchScreenKeyboard._CurrentControl = control;
			if (TouchScreenKeyboard._InstanceObject == null)
			{
				FrameworkElement frameworkElement = control;
				while (!(frameworkElement is Window))
				{
					frameworkElement = (FrameworkElement)frameworkElement.Parent;
				}
				((Window)frameworkElement).LocationChanged += new System.EventHandler(TouchScreenKeyboard.TouchScreenKeyboard_LocationChanged);
				((Window)frameworkElement).Activated += new System.EventHandler(TouchScreenKeyboard.TouchScreenKeyboard_Activated);
				((Window)frameworkElement).Deactivated += new System.EventHandler(TouchScreenKeyboard.TouchScreenKeyboard_Deactivated);
				TouchScreenKeyboard._InstanceObject = new TouchScreenKeyboard();
				TouchScreenKeyboard._InstanceObject.AllowsTransparency = true;
				TouchScreenKeyboard._InstanceObject.WindowStyle = WindowStyle.None;
				TouchScreenKeyboard._InstanceObject.ShowInTaskbar = false;
				TouchScreenKeyboard._InstanceObject.ShowInTaskbar = false;
				TouchScreenKeyboard._InstanceObject.Topmost = true;
				control.LayoutUpdated += new System.EventHandler(TouchScreenKeyboard.tb_LayoutUpdated);
			}
		}

		private static void TouchScreenKeyboard_Deactivated(object sender, System.EventArgs e)
		{
			if (TouchScreenKeyboard._InstanceObject != null)
			{
				TouchScreenKeyboard._InstanceObject.Topmost = false;
			}
		}

		private static void TouchScreenKeyboard_Activated(object sender, System.EventArgs e)
		{
			if (TouchScreenKeyboard._InstanceObject != null)
			{
				TouchScreenKeyboard._InstanceObject.Topmost = true;
			}
		}

		private static void TouchScreenKeyboard_LocationChanged(object sender, System.EventArgs e)
		{
			TouchScreenKeyboard.syncchild();
		}

		private static void tb_LayoutUpdated(object sender, System.EventArgs e)
		{
			TouchScreenKeyboard.syncchild();
		}

		private static void OnLostFocus(object sender, RoutedEventArgs e)
		{
			Control control = sender as Control;
			control.Background = TouchScreenKeyboard._PreviousTextBoxBackgroundBrush;
			control.BorderBrush = TouchScreenKeyboard._PreviousTextBoxBorderBrush;
			control.BorderThickness = TouchScreenKeyboard._PreviousTextBoxBorderThickness;
			if (TouchScreenKeyboard._InstanceObject != null)
			{
				TouchScreenKeyboard._InstanceObject.Close();
				TouchScreenKeyboard._InstanceObject = null;
			}
		}
	}
}
