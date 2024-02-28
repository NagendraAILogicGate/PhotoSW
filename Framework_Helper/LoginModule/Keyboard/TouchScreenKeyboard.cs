namespace LoginModule.Keyboard
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    public class TouchScreenKeyboard : Window
    {
        private static bool _CapsLockFlag;
        private static Control _CurrentControl;
        private static Window _InstanceObject;
        private static Brush _PreviousTextBoxBackgroundBrush = null;
        private static Brush _PreviousTextBoxBorderBrush = null;
        private static Thickness _PreviousTextBoxBorderThickness;
        private static bool _ShiftFlag;
        private static double _WidthTouchKeyboard = 830.0;
        public static RoutedUICommand Cmd0 = new RoutedUICommand();
        public static RoutedUICommand Cmd1 = new RoutedUICommand();
        public static RoutedUICommand Cmd2 = new RoutedUICommand();
        public static RoutedUICommand Cmd3 = new RoutedUICommand();
        public static RoutedUICommand Cmd4 = new RoutedUICommand();
        public static RoutedUICommand Cmd5 = new RoutedUICommand();
        public static RoutedUICommand Cmd6 = new RoutedUICommand();
        public static RoutedUICommand Cmd7 = new RoutedUICommand();
        public static RoutedUICommand Cmd8 = new RoutedUICommand();
        public static RoutedUICommand Cmd9 = new RoutedUICommand();
        public static RoutedUICommand CmdA = new RoutedUICommand();
        public static RoutedUICommand CmdB = new RoutedUICommand();
        public static RoutedUICommand CmdBackspace = new RoutedUICommand();
        public static RoutedUICommand CmdC = new RoutedUICommand();
        public static RoutedUICommand CmdCapsLock = new RoutedUICommand();
        public static RoutedUICommand CmdClear = new RoutedUICommand();
        public static RoutedUICommand CmdColon = new RoutedUICommand();
        public static RoutedUICommand CmdD = new RoutedUICommand();
        public static RoutedUICommand CmdDoubleInvertedComma = new RoutedUICommand();
        public static RoutedUICommand CmdE = new RoutedUICommand();
        public static RoutedUICommand CmdEndCrultBrace = new RoutedUICommand();
        public static RoutedUICommand CmdEnter = new RoutedUICommand();
        public static RoutedUICommand CmdF = new RoutedUICommand();
        public static RoutedUICommand CmdG = new RoutedUICommand();
        public static RoutedUICommand CmdGreaterThan = new RoutedUICommand();
        public static RoutedUICommand CmdH = new RoutedUICommand();
        public static RoutedUICommand CmdI = new RoutedUICommand();
        public static RoutedUICommand CmdJ = new RoutedUICommand();
        public static RoutedUICommand CmdK = new RoutedUICommand();
        public static RoutedUICommand CmdL = new RoutedUICommand();
        public static RoutedUICommand CmdLessThan = new RoutedUICommand();
        public static RoutedUICommand CmdM = new RoutedUICommand();
        public static RoutedUICommand CmdMinus = new RoutedUICommand();
        public static RoutedUICommand CmdN = new RoutedUICommand();
        public static RoutedUICommand CmdO = new RoutedUICommand();
        public static RoutedUICommand CmdOpenCrulyBrace = new RoutedUICommand();
        public static RoutedUICommand CmdOR = new RoutedUICommand();
        public static RoutedUICommand CmdP = new RoutedUICommand();
        public static RoutedUICommand CmdPlus = new RoutedUICommand();
        public static RoutedUICommand CmdQ = new RoutedUICommand();
        public static RoutedUICommand CmdQuestion = new RoutedUICommand();
        public static RoutedUICommand CmdR = new RoutedUICommand();
        public static RoutedUICommand CmdS = new RoutedUICommand();
        public static RoutedUICommand CmdShift = new RoutedUICommand();
        public static RoutedUICommand CmdSpaceBar = new RoutedUICommand();
        public static RoutedUICommand CmdT = new RoutedUICommand();
        public static RoutedUICommand CmdTab = new RoutedUICommand();
        public static RoutedUICommand CmdTlide = new RoutedUICommand();
        public static RoutedUICommand CmdU = new RoutedUICommand();
        public static RoutedUICommand CmdV = new RoutedUICommand();
        public static RoutedUICommand Cmdw = new RoutedUICommand();
        public static RoutedUICommand CmdX = new RoutedUICommand();
        public static RoutedUICommand CmdY = new RoutedUICommand();
        public static RoutedUICommand CmdZ = new RoutedUICommand();
        public static readonly DependencyProperty TouchScreenKeyboardProperty = DependencyProperty.RegisterAttached("TouchScreenKeyboard", typeof(bool), typeof(TouchScreenKeyboard), new UIPropertyMetadata(false, new PropertyChangedCallback(TouchScreenKeyboard.TouchScreenKeyboardPropertyChanged)));

        static TouchScreenKeyboard()
        {
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TouchScreenKeyboard), new FrameworkPropertyMetadata(typeof(TouchScreenKeyboard)));
            SetCommandBinding();
        }

        public TouchScreenKeyboard()
        {
            base.Width = WidthTouchKeyboard;
        }

        private static void AddKeyBoardINput(char input)
        {
            if (CapsLockFlag)
            {
                if (ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + char.ToLower(input).ToString();
                    ShiftFlag = false;
                }
                else
                {
                    TouchScreenText = TouchScreenText + char.ToUpper(input).ToString();
                }
            }
            else if (!ShiftFlag)
            {
                TouchScreenText = TouchScreenText + char.ToLower(input).ToString();
            }
            else
            {
                TouchScreenText = TouchScreenText + char.ToUpper(input).ToString();
                ShiftFlag = false;
            }
        }

        public static bool GetTouchScreenKeyboard(DependencyObject obj)
        {
            return (bool) obj.GetValue(TouchScreenKeyboardProperty);
        }

        private static void OnGotFocus(object sender, RoutedEventArgs e)
        {
            Control control = sender as Control;
            _PreviousTextBoxBackgroundBrush = control.Background;
            _PreviousTextBoxBorderBrush = control.BorderBrush;
            _PreviousTextBoxBorderThickness = control.BorderThickness;
            control.Background = Brushes.Yellow;
            control.BorderBrush = Brushes.Red;
            control.BorderThickness = new Thickness(4.0);
            _CurrentControl = control;
            if (_InstanceObject == null)
            {
                FrameworkElement parent = control;
                while (true)
                {
                    if (parent is Window)
                    {
                        ((Window) parent).LocationChanged += new EventHandler(TouchScreenKeyboard.TouchScreenKeyboard_LocationChanged);
                        ((Window) parent).Activated += new EventHandler(TouchScreenKeyboard.TouchScreenKeyboard_Activated);
                        ((Window) parent).Deactivated += new EventHandler(TouchScreenKeyboard.TouchScreenKeyboard_Deactivated);
                        _InstanceObject = new TouchScreenKeyboard();
                        _InstanceObject.AllowsTransparency = true;
                        _InstanceObject.WindowStyle = WindowStyle.None;
                        _InstanceObject.ShowInTaskbar = false;
                        _InstanceObject.ShowInTaskbar = false;
                        _InstanceObject.Topmost = true;
                        control.LayoutUpdated += new EventHandler(TouchScreenKeyboard.tb_LayoutUpdated);
                        return;
                    }
                    parent = (FrameworkElement) parent.Parent;
                }
            }
        }

        private static void OnLostFocus(object sender, RoutedEventArgs e)
        {
            Control control = sender as Control;
            control.Background = _PreviousTextBoxBackgroundBrush;
            control.BorderBrush = _PreviousTextBoxBorderBrush;
            control.BorderThickness = _PreviousTextBoxBorderThickness;
            if (_InstanceObject != null)
            {
                _InstanceObject.Close();
                _InstanceObject = null;
            }
        }

        private static void RunCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.get_Command() == CmdTlide)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + "`";
                }
                else
                {
                    TouchScreenText = TouchScreenText + "~";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == Cmd1)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + "1";
                }
                else
                {
                    TouchScreenText = TouchScreenText + "!";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == Cmd2)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + "2";
                }
                else
                {
                    TouchScreenText = TouchScreenText + "@";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == Cmd3)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + "3";
                }
                else
                {
                    TouchScreenText = TouchScreenText + "#";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == Cmd4)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + "4";
                }
                else
                {
                    TouchScreenText = TouchScreenText + "$";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == Cmd5)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + "5";
                }
                else
                {
                    TouchScreenText = TouchScreenText + "%";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == Cmd6)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + "6";
                }
                else
                {
                    TouchScreenText = TouchScreenText + "^";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == Cmd7)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + "7";
                }
                else
                {
                    TouchScreenText = TouchScreenText + "&";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == Cmd8)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + "8";
                }
                else
                {
                    TouchScreenText = TouchScreenText + "*";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == Cmd9)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + "9";
                }
                else
                {
                    TouchScreenText = TouchScreenText + "(";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == Cmd0)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + "0";
                }
                else
                {
                    TouchScreenText = TouchScreenText + ")";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == CmdMinus)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + "-";
                }
                else
                {
                    TouchScreenText = TouchScreenText + "_";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == CmdPlus)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + "=";
                }
                else
                {
                    TouchScreenText = TouchScreenText + "+";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == CmdBackspace)
            {
                if (!string.IsNullOrEmpty(TouchScreenText))
                {
                    TouchScreenText = TouchScreenText.Substring(0, TouchScreenText.Length - 1);
                }
            }
            else if (e.get_Command() == CmdTab)
            {
                TouchScreenText = TouchScreenText + "     ";
            }
            else if (e.get_Command() == CmdQ)
            {
                AddKeyBoardINput('Q');
            }
            else if (e.get_Command() == Cmdw)
            {
                AddKeyBoardINput('w');
            }
            else if (e.get_Command() == CmdE)
            {
                AddKeyBoardINput('E');
            }
            else if (e.get_Command() == CmdR)
            {
                AddKeyBoardINput('R');
            }
            else if (e.get_Command() == CmdT)
            {
                AddKeyBoardINput('T');
            }
            else if (e.get_Command() == CmdY)
            {
                AddKeyBoardINput('Y');
            }
            else if (e.get_Command() == CmdU)
            {
                AddKeyBoardINput('U');
            }
            else if (e.get_Command() == CmdI)
            {
                AddKeyBoardINput('I');
            }
            else if (e.get_Command() == CmdO)
            {
                AddKeyBoardINput('O');
            }
            else if (e.get_Command() == CmdP)
            {
                AddKeyBoardINput('P');
            }
            else if (e.get_Command() == CmdOpenCrulyBrace)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + "[";
                }
                else
                {
                    TouchScreenText = TouchScreenText + "{";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == CmdEndCrultBrace)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + "]";
                }
                else
                {
                    TouchScreenText = TouchScreenText + "}";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == CmdOR)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + @"\";
                }
                else
                {
                    TouchScreenText = TouchScreenText + "|";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == CmdCapsLock)
            {
                if (!CapsLockFlag)
                {
                    CapsLockFlag = true;
                }
                else
                {
                    CapsLockFlag = false;
                }
            }
            else if (e.get_Command() == CmdA)
            {
                AddKeyBoardINput('A');
            }
            else if (e.get_Command() == CmdS)
            {
                AddKeyBoardINput('S');
            }
            else if (e.get_Command() == CmdD)
            {
                AddKeyBoardINput('D');
            }
            else if (e.get_Command() == CmdF)
            {
                AddKeyBoardINput('F');
            }
            else if (e.get_Command() == CmdG)
            {
                AddKeyBoardINput('G');
            }
            else if (e.get_Command() == CmdH)
            {
                AddKeyBoardINput('H');
            }
            else if (e.get_Command() == CmdJ)
            {
                AddKeyBoardINput('J');
            }
            else if (e.get_Command() == CmdK)
            {
                AddKeyBoardINput('K');
            }
            else if (e.get_Command() == CmdL)
            {
                AddKeyBoardINput('L');
            }
            else if (e.get_Command() == CmdColon)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + ";";
                }
                else
                {
                    TouchScreenText = TouchScreenText + ":";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == CmdDoubleInvertedComma)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + "'";
                }
                else
                {
                    TouchScreenText = TouchScreenText + char.ConvertFromUtf32(0x22);
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == CmdEnter)
            {
                if (_InstanceObject != null)
                {
                    _InstanceObject.Close();
                    _InstanceObject = null;
                }
                _CurrentControl.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
            else if (e.get_Command() == CmdShift)
            {
                ShiftFlag = true;
            }
            else if (e.get_Command() == CmdZ)
            {
                AddKeyBoardINput('Z');
            }
            else if (e.get_Command() == CmdX)
            {
                AddKeyBoardINput('X');
            }
            else if (e.get_Command() == CmdC)
            {
                AddKeyBoardINput('C');
            }
            else if (e.get_Command() == CmdV)
            {
                AddKeyBoardINput('V');
            }
            else if (e.get_Command() == CmdB)
            {
                AddKeyBoardINput('B');
            }
            else if (e.get_Command() == CmdN)
            {
                AddKeyBoardINput('N');
            }
            else if (e.get_Command() == CmdM)
            {
                AddKeyBoardINput('M');
            }
            else if (e.get_Command() == CmdLessThan)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + ",";
                }
                else
                {
                    TouchScreenText = TouchScreenText + "<";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == CmdGreaterThan)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + ".";
                }
                else
                {
                    TouchScreenText = TouchScreenText + ">";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == CmdQuestion)
            {
                if (!ShiftFlag)
                {
                    TouchScreenText = TouchScreenText + "/";
                }
                else
                {
                    TouchScreenText = TouchScreenText + "?";
                    ShiftFlag = false;
                }
            }
            else if (e.get_Command() == CmdSpaceBar)
            {
                TouchScreenText = TouchScreenText + " ";
            }
            else if (e.get_Command() == CmdClear)
            {
                TouchScreenText = "";
            }
        }

        private static void SetCommandBinding()
        {
            CommandBinding commandBinding = new CommandBinding((ICommand) CmdTlide, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding2 = new CommandBinding((ICommand) Cmd1, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding3 = new CommandBinding((ICommand) Cmd2, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding4 = new CommandBinding((ICommand) Cmd3, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding5 = new CommandBinding((ICommand) Cmd4, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding6 = new CommandBinding((ICommand) Cmd5, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding7 = new CommandBinding((ICommand) Cmd6, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding8 = new CommandBinding((ICommand) Cmd7, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding9 = new CommandBinding((ICommand) Cmd8, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding10 = new CommandBinding((ICommand) Cmd9, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding11 = new CommandBinding((ICommand) Cmd0, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding12 = new CommandBinding((ICommand) CmdMinus, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding13 = new CommandBinding((ICommand) CmdPlus, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding14 = new CommandBinding((ICommand) CmdBackspace, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), commandBinding);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding2);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding3);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding4);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding5);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding6);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding7);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding8);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding9);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding10);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding11);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding12);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding13);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding14);
            CommandBinding binding15 = new CommandBinding((ICommand) CmdTab, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding16 = new CommandBinding((ICommand) CmdQ, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding17 = new CommandBinding((ICommand) Cmdw, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding18 = new CommandBinding((ICommand) CmdE, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding19 = new CommandBinding((ICommand) CmdR, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding20 = new CommandBinding((ICommand) CmdT, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding21 = new CommandBinding((ICommand) CmdY, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding22 = new CommandBinding((ICommand) CmdU, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding23 = new CommandBinding((ICommand) CmdI, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding24 = new CommandBinding((ICommand) CmdO, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding25 = new CommandBinding((ICommand) CmdP, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding26 = new CommandBinding((ICommand) CmdOpenCrulyBrace, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding27 = new CommandBinding((ICommand) CmdEndCrultBrace, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding28 = new CommandBinding((ICommand) CmdOR, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding29 = new CommandBinding((ICommand) CmdCapsLock, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding30 = new CommandBinding((ICommand) CmdA, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding31 = new CommandBinding((ICommand) CmdS, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding32 = new CommandBinding((ICommand) CmdD, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding33 = new CommandBinding((ICommand) CmdF, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding34 = new CommandBinding((ICommand) CmdG, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding35 = new CommandBinding((ICommand) CmdH, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding36 = new CommandBinding((ICommand) CmdJ, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding37 = new CommandBinding((ICommand) CmdK, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding38 = new CommandBinding((ICommand) CmdL, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding39 = new CommandBinding((ICommand) CmdColon, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding40 = new CommandBinding((ICommand) CmdDoubleInvertedComma, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding41 = new CommandBinding((ICommand) CmdEnter, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding42 = new CommandBinding((ICommand) CmdShift, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding43 = new CommandBinding((ICommand) CmdZ, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding44 = new CommandBinding((ICommand) CmdX, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding45 = new CommandBinding((ICommand) CmdC, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding46 = new CommandBinding((ICommand) CmdV, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding47 = new CommandBinding((ICommand) CmdB, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding48 = new CommandBinding((ICommand) CmdN, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding49 = new CommandBinding((ICommand) CmdM, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding50 = new CommandBinding((ICommand) CmdGreaterThan, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding51 = new CommandBinding((ICommand) CmdLessThan, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding52 = new CommandBinding((ICommand) CmdQuestion, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding53 = new CommandBinding((ICommand) CmdSpaceBar, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandBinding binding54 = new CommandBinding((ICommand) CmdClear, new ExecutedRoutedEventHandler(TouchScreenKeyboard.RunCommand));
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding15);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding16);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding17);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding18);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding19);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding20);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding21);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding22);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding23);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding24);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding25);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding26);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding27);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding28);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding29);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding30);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding31);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding32);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding33);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding34);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding35);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding36);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding37);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding38);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding39);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding40);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding41);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding42);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding43);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding44);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding45);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding46);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding47);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding48);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding49);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding50);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding51);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding52);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding53);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), binding54);
        }

        public static void SetTouchScreenKeyboard(DependencyObject obj, bool value)
        {
            obj.SetValue(TouchScreenKeyboardProperty, value);
        }

        private static void syncchild()
        {
            if ((_CurrentControl != null) && (_InstanceObject != null))
            {
                Point point = new Point(0.0, _CurrentControl.ActualHeight + 3.0);
                Point point2 = _CurrentControl.PointToScreen(point);
                if ((WidthTouchKeyboard + point2.X) > SystemParameters.VirtualScreenWidth)
                {
                    double num = (WidthTouchKeyboard + point2.X) - SystemParameters.VirtualScreenWidth;
                    _InstanceObject.Left = point2.X - num;
                }
                else if (point2.X <= 1.0)
                {
                    _InstanceObject.Left = 1.0;
                }
                else
                {
                    _InstanceObject.Left = point2.X;
                }
                _InstanceObject.Top = point2.Y;
                _InstanceObject.Show();
            }
        }

        private static void tb_LayoutUpdated(object sender, EventArgs e)
        {
            syncchild();
        }

        private static void TouchScreenKeyboard_Activated(object sender, EventArgs e)
        {
            if (_InstanceObject != null)
            {
                _InstanceObject.Topmost = true;
            }
        }

        private static void TouchScreenKeyboard_Deactivated(object sender, EventArgs e)
        {
            if (_InstanceObject != null)
            {
                _InstanceObject.Topmost = false;
            }
        }

        private static void TouchScreenKeyboard_LocationChanged(object sender, EventArgs e)
        {
            syncchild();
        }

        private static void TouchScreenKeyboardPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (element != null)
            {
                element.GotFocus += new RoutedEventHandler(TouchScreenKeyboard.OnGotFocus);
                element.LostFocus += new RoutedEventHandler(TouchScreenKeyboard.OnLostFocus);
            }
        }

        protected static bool CapsLockFlag
        {
            get
            {
                return _CapsLockFlag;
            }
            set
            {
                _CapsLockFlag = value;
            }
        }

        protected static bool ShiftFlag
        {
            get
            {
                return _ShiftFlag;
            }
            set
            {
                _ShiftFlag = value;
            }
        }

        public static string TouchScreenText
        {
            get
            {
                if (_CurrentControl is TextBox)
                {
                    return ((TextBox) _CurrentControl).Text;
                }
                if (_CurrentControl is PasswordBox)
                {
                    return ((PasswordBox) _CurrentControl).Password;
                }
                return "";
            }
            set
            {
                if (_CurrentControl is TextBox)
                {
                    ((TextBox) _CurrentControl).Text = value;
                }
                else if (_CurrentControl is PasswordBox)
                {
                    ((PasswordBox) _CurrentControl).Password = value;
                }
            }
        }

        public static double WidthTouchKeyboard
        {
            get
            {
                return _WidthTouchKeyboard;
            }
            set
            {
                _WidthTouchKeyboard = value;
            }
        }
    }
}

