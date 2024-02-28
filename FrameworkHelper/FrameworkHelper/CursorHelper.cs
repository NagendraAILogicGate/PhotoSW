using ErrorHandler;
using Microsoft.Win32.SafeHandles;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FrameworkHelper
{
	public class CursorHelper
	{
		private static class NativeMethods
		{
			public struct IconInfo
			{
				public bool fIcon;

				public int xHotspot;

				public int yHotspot;

				public System.IntPtr hbmMask;

				public System.IntPtr hbmColor;
			}

			[System.Runtime.InteropServices.DllImport("user32.dll")]
			public static extern CursorHelper.SafeIconHandle CreateIconIndirect(ref CursorHelper.NativeMethods.IconInfo icon);

			[System.Runtime.InteropServices.DllImport("user32.dll")]
			public static extern bool DestroyIcon(System.IntPtr hIcon);

			[System.Runtime.InteropServices.DllImport("user32.dll")]
			[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
			public static extern bool GetIconInfo(System.IntPtr hIcon, ref CursorHelper.NativeMethods.IconInfo pIconInfo);
		}

		[System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, UnmanagedCode = true)]
		private class SafeIconHandle : Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid
		{
			public SafeIconHandle() : base(true)
			{
			}

			protected override bool ReleaseHandle()
			{
				return CursorHelper.NativeMethods.DestroyIcon(this.handle);
			}
		}

		private static UIElement globalelement;

		[System.Runtime.InteropServices.DllImport("gdi32.dll")]
		public static extern bool DeleteObject(System.IntPtr hObject);

		private static Cursor InternalCreateCursor(Bitmap bmp)
		{
			Cursor result;
			try
			{
				CursorHelper.NativeMethods.IconInfo iconInfo = default(CursorHelper.NativeMethods.IconInfo);
				try
				{
					CursorHelper.NativeMethods.GetIconInfo(bmp.GetHicon(), ref iconInfo);
				}
				catch (System.Exception serviceException)
				{
					CursorHelper.SafeIconHandle cursorHandle = CursorHelper.NativeMethods.CreateIconIndirect(ref iconInfo);
					result = CursorInteropHelper.Create(cursorHandle);
					return result;
				}
				iconInfo.xHotspot = (int)(CursorHelper.globalelement.DesiredSize.Width * 0.5);
				iconInfo.yHotspot = (int)(CursorHelper.globalelement.DesiredSize.Height * 0.5);
				iconInfo.fIcon = false;
				CursorHelper.globalelement = null;
				CursorHelper.SafeIconHandle cursorHandle2 = CursorHelper.NativeMethods.CreateIconIndirect(ref iconInfo);
				result = CursorInteropHelper.Create(cursorHandle2);
			}
			catch (System.Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
				result = null;
			}
			finally
			{
				System.IntPtr hbitmap = bmp.GetHbitmap();
				CursorHelper.DeleteObject(hbitmap);
			}
			return result;
		}

		public static Cursor CreateCursor(UIElement element)
		{
			Cursor result;
			try
			{
				System.GC.AddMemoryPressure(20000L);
				element.Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
				element.Arrange(new Rect(default(System.Windows.Point), element.DesiredSize));
				double num = System.Math.Round(element.DesiredSize.Width);
				double num2 = System.Math.Round(element.DesiredSize.Height);
				RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)num, (int)num2, 96.0, 96.0, PixelFormats.Pbgra32);
				renderTargetBitmap.Render(element);
				CursorHelper.globalelement = element;
				PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
				pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
				using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
				{
					pngBitmapEncoder.Save(memoryStream);
					using (Bitmap bitmap = new Bitmap(memoryStream))
					{
						result = CursorHelper.InternalCreateCursor(bitmap);
					}
				}
			}
			catch (System.Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
				result = null;
			}
			finally
			{
				System.GC.RemoveMemoryPressure(20000L);
			}
			return result;
		}
	}
}
