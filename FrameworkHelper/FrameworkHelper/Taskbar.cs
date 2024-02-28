using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace FrameworkHelper
{
	public class Taskbar
	{
		private delegate bool EnumThreadProc(System.IntPtr hwnd, System.IntPtr lParam);

		private const int SW_HIDE = 0;

		private const int SW_SHOW = 5;

		private const string VistaStartMenuCaption = "Start";

		private static System.IntPtr vistaStartMenuWnd = System.IntPtr.Zero;

		public static bool Visible
		{
			set
			{
				Taskbar.SetVisibility(value);
			}
		}

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern int GetWindowText(System.IntPtr hWnd, System.Text.StringBuilder text, int count);

		[System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool EnumThreadWindows(int threadId, Taskbar.EnumThreadProc pfnEnum, System.IntPtr lParam);

		[System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
		private static extern System.IntPtr FindWindow(string lpClassName, string lpWindowName);

		[System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
		private static extern System.IntPtr FindWindowEx(System.IntPtr parentHandle, System.IntPtr childAfter, string className, string windowTitle);

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern System.IntPtr FindWindowEx(System.IntPtr parentHwnd, System.IntPtr childAfterHwnd, System.IntPtr className, string windowText);

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern int ShowWindow(System.IntPtr hwnd, int nCmdShow);

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern uint GetWindowThreadProcessId(System.IntPtr hwnd, out int lpdwProcessId);

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
			System.IntPtr intPtr = Taskbar.FindWindow("Shell_TrayWnd", null);
			System.IntPtr intPtr2 = Taskbar.FindWindowEx(intPtr, System.IntPtr.Zero, "Button", "Start");
			if (intPtr2 == System.IntPtr.Zero)
			{
				intPtr2 = Taskbar.FindWindowEx(System.IntPtr.Zero, System.IntPtr.Zero, (System.IntPtr)49175, "Start");
			}
			if (intPtr2 == System.IntPtr.Zero)
			{
				intPtr2 = Taskbar.FindWindow("Button", null);
				if (intPtr2 == System.IntPtr.Zero)
				{
					intPtr2 = Taskbar.GetVistaStartMenuWnd(intPtr);
				}
			}
			Taskbar.ShowWindow(intPtr, show ? 5 : 0);
			Taskbar.ShowWindow(intPtr2, show ? 5 : 0);
		}

		private static System.IntPtr GetVistaStartMenuWnd(System.IntPtr taskBarWnd)
		{
			int processId;
			Taskbar.GetWindowThreadProcessId(taskBarWnd, out processId);
			Process processById = Process.GetProcessById(processId);
			if (processById != null)
			{
				foreach (ProcessThread processThread in processById.Threads)
				{
					Taskbar.EnumThreadWindows(processThread.Id, new Taskbar.EnumThreadProc(Taskbar.MyEnumThreadWindowsProc), System.IntPtr.Zero);
				}
			}
			return Taskbar.vistaStartMenuWnd;
		}

		private static bool MyEnumThreadWindowsProc(System.IntPtr hWnd, System.IntPtr lParam)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(256);
			bool result;
			if (Taskbar.GetWindowText(hWnd, stringBuilder, stringBuilder.Capacity) > 0)
			{
				if (stringBuilder.ToString() == "Start")
				{
					Taskbar.vistaStartMenuWnd = hWnd;
					result = false;
					return result;
				}
			}
			result = true;
			return result;
		}
	}
}
