namespace FrameworkHelper
{
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

    public class CursorHelper
    {
        private static UIElement globalelement;

        public static Cursor CreateCursor(UIElement element)
        {
            Cursor cursor;
            try
            {
                GC.AddMemoryPressure(0x4e20L);
                element.Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
                element.Arrange(new Rect(new System.Windows.Point(), element.DesiredSize));
                double num = Math.Round(element.DesiredSize.Width);
                double num2 = Math.Round(element.DesiredSize.Height);
                RenderTargetBitmap source = new RenderTargetBitmap((int) num, (int) num2, 96.0, 96.0, PixelFormats.Pbgra32);
                source.Render(element);
                globalelement = element;
                PngBitmapEncoder encoder = new PngBitmapEncoder {
                    Frames = { BitmapFrame.Create(source) }
                };
                using (MemoryStream stream = new MemoryStream())
                {
                    encoder.Save(stream);
                    using (Bitmap bitmap2 = new Bitmap(stream))
                    {
                        cursor = InternalCreateCursor(bitmap2);
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception));
                cursor = null;
            }
            finally
            {
                GC.RemoveMemoryPressure(0x4e20L);
            }
            return cursor;
        }

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        private static Cursor InternalCreateCursor(Bitmap bmp)
        {
            Exception exception;
            Cursor cursor;
            try
            {
                NativeMethods.IconInfo pIconInfo = new NativeMethods.IconInfo();
                try
                {
                    NativeMethods.GetIconInfo(bmp.GetHicon(), ref pIconInfo);
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    return CursorInteropHelper.Create(NativeMethods.CreateIconIndirect(ref pIconInfo));
                }
                pIconInfo.xHotspot = (int) (globalelement.DesiredSize.Width * 0.5);
                pIconInfo.yHotspot = (int) (globalelement.DesiredSize.Height * 0.5);
                pIconInfo.fIcon = false;
                globalelement = null;
                cursor = CursorInteropHelper.Create(NativeMethods.CreateIconIndirect(ref pIconInfo));
            }
            catch (Exception exception2)
            {
                exception = exception2;
                ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception));
                cursor = null;
            }
            finally
            {
                DeleteObject(bmp.GetHbitmap());
            }
            return cursor;
        }

        private static class NativeMethods
        {
            [DllImport("user32.dll")]
            public static extern CursorHelper.SafeIconHandle CreateIconIndirect(ref IconInfo icon);
            [DllImport("user32.dll")]
            public static extern bool DestroyIcon(IntPtr hIcon);
            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("user32.dll")]
            public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

            [StructLayout(LayoutKind.Sequential)]
            public struct IconInfo
            {
                public bool fIcon;
                public int xHotspot;
                public int yHotspot;
                public IntPtr hbmMask;
                public IntPtr hbmColor;
            }
        }

        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
        private class SafeIconHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            public SafeIconHandle() : base(true)
            {
            }

            protected override bool ReleaseHandle()
            {
                return CursorHelper.NativeMethods.DestroyIcon(base.handle);
            }
        }
    }
}

