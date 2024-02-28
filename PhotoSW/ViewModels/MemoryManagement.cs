using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;


namespace PhotoSW.ViewModels
{
    public class MemoryManagement
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern int SetProcessWorkingSetSize(System.IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);

        public static void FlushMemory()
        {
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            if (System.Environment.OSVersion.Platform == System.PlatformID.Win32NT)
            {
                MemoryManagement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            System.GC.Collect();
        }

        public static void DisposeImage(BitmapImage image)
        {
            if (image != null)
            {
                try
                {
                    image.UriSource = null;
                }
                catch (System.Exception)
                {
                }
            }
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(System.IntPtr hObject);

        public static void DestroyBitmap(BitmapImage bitmapImage)
        {
            try
            {
                System.IntPtr hbitmap = MemoryManagement.BitmapImage2Bitmap(bitmapImage).GetHbitmap();
                MemoryManagement.DeleteObject(hbitmap);
            }
            catch
            {
            }
        }

        public static Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            Bitmap result;
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                new BmpBitmapEncoder
                {
                    Frames = 
					{
						BitmapFrame.Create(bitmapImage)
					}
                }.Save(memoryStream);
                Bitmap original = new Bitmap(memoryStream);
                result = new Bitmap(original);
            }
            return result;
        }
    }
}
