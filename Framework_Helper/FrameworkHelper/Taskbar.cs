namespace FrameworkHelper
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    public class Taskbar
    {
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;
        private const string VistaStartMenuCaption = "Start";
        private static IntPtr vistaStartMenuWnd = IntPtr.Zero;

        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        private static extern bool EnumThreadWindows(int threadId, EnumThreadProc pfnEnum, IntPtr lParam);
        [DllImport("user32.dll", SetLastError=true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindowEx(IntPtr parentHwnd, IntPtr childAfterHwnd, IntPtr className, string windowText);
        [DllImport("user32.dll", SetLastError=true)]
        private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);
        private static IntPtr GetVistaStartMenuWnd(IntPtr taskBarWnd)
        {
            int num;
            GetWindowThreadProcessId(taskBarWnd, out num);
            Process processById = Process.GetProcessById(num);
            if (processById != null)
            {
                foreach (ProcessThread thread in processById.Threads)
                {
                    EnumThreadWindows(thread.Id, new EnumThreadProc(Taskbar.MyEnumThreadWindowsProc), IntPtr.Zero);
                }
            }
            return vistaStartMenuWnd;
        }

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hwnd, out int lpdwProcessId);
        public static void Hide()
        {
            SetVisibility(false);
        }

        private static bool MyEnumThreadWindowsProc(IntPtr hWnd, IntPtr lParam)
        {
            StringBuilder text = new StringBuilder(0x100);
            if ((GetWindowText(hWnd, text, text.Capacity) > 0) && (text.ToString() == "Start"))
            {
                vistaStartMenuWnd = hWnd;
                return false;
            }
            return true;
        }

        private static void SetVisibility(bool show)
        {
            IntPtr parentHandle = FindWindow("Shell_TrayWnd", null);
            IntPtr hwnd = FindWindowEx(parentHandle, IntPtr.Zero, "Button", "Start");
            if (hwnd == IntPtr.Zero)
            {
                hwnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, (IntPtr) 0xc017, "Start");
            }
            if (hwnd == IntPtr.Zero)
            {
                hwnd = FindWindow("Button", null);
                if (hwnd == IntPtr.Zero)
                {
                    hwnd = GetVistaStartMenuWnd(parentHandle);
                }
            }
            ShowWindow(parentHandle, show ? 5 : 0);
            ShowWindow(hwnd, show ? 5 : 0);
        }

        public static void Show()
        {
            SetVisibility(true);
        }

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        public static bool Visible
        {
            set
            {
                SetVisibility(value);
            }
        }

        private delegate bool EnumThreadProc(IntPtr hwnd, IntPtr lParam);
    }
}

