using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.ViewModels
{
    public class Taskbar
    {
        private delegate bool EnumThreadProc(IntPtr hwnd, IntPtr lParam);

        private const int SW_HIDE = 0;

        private const int SW_SHOW = 5;

        private const string VistaStartMenuCaption = "Start";

        private static IntPtr vistaStartMenuWnd = IntPtr.Zero;

        public static bool Visible
        {
            set
            {
                Taskbar.SetVisibility(value);
            }
        }

       // [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        //[DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool EnumThreadWindows(int threadId, Taskbar.EnumThreadProc pfnEnum, IntPtr lParam);

       // [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

       // [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        //[DllImport("user32.dll")]
        private static extern IntPtr FindWindowEx(IntPtr parentHwnd, IntPtr childAfterHwnd, IntPtr className, string windowText);

       // [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

       // [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hwnd, out int lpdwProcessId);

        public static void Show()
        {
            Taskbar.SetVisibility(true);
        }

        public static void Hide()
        {
            Taskbar.SetVisibility(false);
        }

        private static void SetVisibility(bool show)
        {
            IntPtr arg_B7_0;
            IntPtr expr_DF = arg_B7_0 = Taskbar.FindWindow("Shell_TrayWnd", null);
            IntPtr intPtr;
            IntPtr intPtr2;
            if (!false)
            {
                intPtr = expr_DF;
                IntPtr expr_F5 = Taskbar.FindWindowEx(intPtr, IntPtr.Zero, "Button", "Start");
                if (7 != 0)
                {
                    intPtr2 = expr_F5;
                }
                bool arg_47_0 = intPtr2 == IntPtr.Zero;
                int arg_47_1 = 0;
                int expr_A1;
                int expr_A7;
                do
                {
                    if ((arg_47_0 ? 1 : 0) != arg_47_1)
                    {
                        intPtr2 = Taskbar.FindWindowEx(IntPtr.Zero, IntPtr.Zero, (IntPtr)49175, "Start");
                    }
                    if (!false && !(intPtr2 == IntPtr.Zero))
                    {
                        goto IL_BA;
                    }
                    if (2 == 0)
                    {
                        return;
                    }
                    intPtr2 = Taskbar.FindWindow("Button", null);
                    expr_A1 = ((arg_47_0 = (intPtr2 == IntPtr.Zero)) ? 1 : 0);
                    expr_A7 = (arg_47_1 = 0);
                }
                while (expr_A7 != 0);
                if (expr_A1 == expr_A7)
                {
                    goto IL_B9;
                }
                arg_B7_0 = Taskbar.GetVistaStartMenuWnd(intPtr);
            }
            intPtr2 = arg_B7_0;
        IL_B9:
        IL_BA:
            IntPtr arg_C6_0 = intPtr;
            int arg_C6_1;
            if (!show)
            {
                if ((arg_C6_1 = 0) == 0)
                {
                }
            }
            else
            {
                arg_C6_1 = 5;
            }
            Taskbar.ShowWindow(arg_C6_0, arg_C6_1);
            IntPtr arg_D8_0 = intPtr2;
            int arg_D8_1 = show ? 5 : 0;
            while (8 == 0)
            {
            }
            Taskbar.ShowWindow(arg_D8_0, arg_D8_1);
        }

        private static IntPtr GetVistaStartMenuWnd(IntPtr taskBarWnd)
        {
            IntPtr arg_BB_0 = taskBarWnd;
            if (2 != 0)
            {
                int processId;
                Taskbar.GetWindowThreadProcessId(taskBarWnd, out processId);
                Process processById;
                bool flag;
                if (!false)
                {
                    processById = Process.GetProcessById(processId);
                    flag = (processById == null);
                    if (flag)
                    {
                        goto IL_B2;
                    }
                }
                IEnumerator enumerator = processById.Threads.GetEnumerator();
                try
                {
                    while (true)
                    {
                        if (2 != 0)
                        {
                            flag = enumerator.MoveNext();
                        }
                        if (!flag)
                        {
                            break;
                        }
                        ProcessThread processThread = (ProcessThread)enumerator.Current;
                        Taskbar.EnumThreadWindows(processThread.Id, new Taskbar.EnumThreadProc(Taskbar.MyEnumThreadWindowsProc), IntPtr.Zero);
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    bool arg_9B_0 = disposable == null;
                    bool expr_9D;
                    do
                    {
                        flag = arg_9B_0;
                        expr_9D = (arg_9B_0 = flag);
                    }
                    while (8 == 0 || false);
                    if (!expr_9D)
                    {
                        disposable.Dispose();
                    }
                }
            IL_B2:
                IntPtr intPtr = Taskbar.vistaStartMenuWnd;
                arg_BB_0 = intPtr;
            }
            return arg_BB_0;
        }

        private static bool MyEnumThreadWindowsProc(IntPtr hWnd, IntPtr lParam)
        {
            int arg_3C_0;
            int expr_06 = arg_3C_0 = 256;
            StringBuilder stringBuilder = null; ;
            IntPtr arg_68_0;
            bool flag;
            if (expr_06 != 0)
            {
                stringBuilder = new StringBuilder(expr_06);
                arg_68_0 = hWnd;
                if (false)
                {
                    goto IL_68;
                }
                flag = (Taskbar.GetWindowText(hWnd, stringBuilder, stringBuilder.Capacity) <= 0);
                arg_3C_0 = (flag ? 1 : 0);
            }
            if (arg_3C_0 == 0)
            {
                Console.WriteLine(stringBuilder);
                do
                {
                    if (7 != 0)
                    {
                        flag = !(stringBuilder.ToString() == "Start");
                    }
                    if (false)
                    {
                        goto IL_6D;
                    }
                    if (flag)
                    {
                        goto IL_71;
                    }
                }
                while (false);
                arg_68_0 = hWnd;
                goto IL_68;
            IL_71: ;
            }
            bool result = true;
            return result;
        IL_68:
            Taskbar.vistaStartMenuWnd = arg_68_0;
        IL_6D:
            result = false;
            return result;
        }
    }
}
