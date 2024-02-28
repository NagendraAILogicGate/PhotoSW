namespace DigiPhoto
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Media.Imaging;

    public class MemoryManagement
    {
        public static Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(stream);
                return new Bitmap(new Bitmap(stream));
            }
        }

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        public static void DestroyBitmap(BitmapImage bitmapImage)
        {
            try
            {
                DeleteObject(BitmapImage2Bitmap(bitmapImage).GetHbitmap());
            }
            catch
            {
            }
        }

        public static void DisposeImage(BitmapImage image)
        {
            if (image != null)
            {
                try
                {
                    image.UriSource = null;
                }
                catch (Exception)
                {
                }
            }
        }

        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            GC.Collect();
        }

        [DllImport("kernel32.dll", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);
    }
}

