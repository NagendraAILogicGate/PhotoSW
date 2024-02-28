namespace FrameworkHelper.Common
{
    using ErrorHandler;
    using FrameworkHelper;
    using MCHROMAKEYLib;
    using MControls;
    using MPLATFORMLib;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Media.Imaging;
    using System.Xml;

    public class MLHelpers
    {
        private static double startTime;
        private static double stopTime;
        public static double VideoLength;

        public MLHelpers()
        {
            ChromaKeypluginLic.IntializeProtection();
            DecoderlibLic.IntializeProtection();
            EncoderlibLic.IntializeProtection();
            MComposerlibLic.IntializeProtection();
            MPlatformSDKLic.IntializeProtection();
        }

        public static string ExtractFrame(string frameCropRatio, string fileName, string tempFolderPath, string extractedImagePath)
        {
            try
            {
                string path = tempFolderPath + @"ResizeFrames\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string savePath = path + fileName;
                VideoProcessingClass class2 = new VideoProcessingClass();
                int height = 0;
                int width = 0;
                bool flag = false;
                flag = getFrameRatio(frameCropRatio, out width, out height);
                MFileClass class3 = new MFileClass();
                if (flag)
                {
                    if (!GetCropRatio(extractedImagePath, frameCropRatio))
                    {
                        class2.CropeImageAsperAspectRatio(extractedImagePath, savePath, width, height);
                    }
                    else
                    {
                        File.Copy(extractedImagePath, savePath, true);
                    }
                }
                else
                {
                    File.Copy(extractedImagePath, savePath, true);
                }
                try
                {
                    File.Delete(extractedImagePath);
                }
                catch (Exception)
                {
                }
                return savePath;
            }
            catch (Exception exception2)
            {
                ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception2));
            }
            return null;
        }

        public static List<string> ExtractFrame(string FileName, List<double> FrameSec, string Userid, string FileFullName, string frameCropRatio)
        {
            try
            {
                int num = 0;
                VideoProcessingClass class2 = new VideoProcessingClass();
                string path = string.Empty;
                string savePath = string.Empty;
                int height = 0;
                int width = 0;
                bool flag = false;
                flag = getFrameRatio(frameCropRatio, out width, out height);
                List<string> list = new List<string>();
                List<string> list2 = new List<string>();
                MFileClass o = new MFileClass();
                o.FileNameSet(FileName, "");
                o.FilePlayStart();
                Thread.Sleep(0x3e8);
                string str3 = string.Empty;
                string str4 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Frames");
                path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Frames", "ResizeImagePath");
                if (!Directory.Exists(str4))
                {
                    Directory.CreateDirectory(str4);
                }
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                MFrame frame = null;
                foreach (double num4 in FrameSec)
                {
                    if (num4 <= VideoLength)
                    {
                        num++;
                        o.FileFrameGet(num4, 0.0, out frame);
                        str3 = string.Concat(new object[] { str4, @"\", FileFullName, "_", num, "@", Userid, ".jpg" });
                        savePath = string.Concat(new object[] { path, @"\", FileFullName, "_", num, "@", Userid, ".jpg" });
                        frame.FrameVideoSaveToFile(str3);
                        if (flag)
                        {
                            if (!GetCropRatio(str3, frameCropRatio))
                            {
                                class2.CropeImageAsperAspectRatio(str3, savePath, width, height);
                                list.Add(savePath);
                                list2.Add(str3);
                            }
                            else
                            {
                                File.Copy(str3, savePath);
                                list.Add(savePath);
                                list2.Add(str3);
                            }
                        }
                        else
                        {
                            File.Copy(str3, savePath);
                            list.Add(savePath);
                            list2.Add(str3);
                        }
                    }
                }
                o.FilePlayStop(0.0);
                o.ObjectClose();
                Marshal.ReleaseComObject(frame);
                Marshal.ReleaseComObject(o);
                foreach (string str5 in list2)
                {
                    try
                    {
                        File.Delete(str5);
                    }
                    catch (Exception)
                    {
                    }
                }
                return list;
            }
            catch (Exception exception2)
            {
                ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception2));
                return null;
            }
        }

        public static List<string> ExtractFramesManualDownload(List<double> FrameSec, string title, string videopath, string extension, string frameCropRatio)
        {
            try
            {
                string str = Path.Combine(videopath, title + extension);
                int num = 0;
                List<string> list = new List<string>();
                List<string> list2 = new List<string>();
                string path = string.Empty;
                VideoProcessingClass class2 = new VideoProcessingClass();
                string savePath = string.Empty;
                int height = 0;
                int width = 0;
                bool flag = false;
                flag = getFrameRatio(frameCropRatio, out width, out height);
                MFileClass o = new MFileClass();
                o.FileNameSet(str, "");
                o.FilePlayStart();
                Thread.Sleep(0x3e8);
                string str4 = string.Empty;
                string str5 = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "ManualDownloadFrames");
                path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "ManualDownloadFrames", "ResizeImagePath");
                if (!Directory.Exists(str5))
                {
                    Directory.CreateDirectory(str5);
                }
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                MFrame frame = null;
                foreach (double num4 in FrameSec)
                {
                    if (num4 <= VideoLength)
                    {
                        num++;
                        o.FileFrameGet(num4, 0.0, out frame);
                        str4 = string.Concat(new object[] { str5, @"\", title, "_#", num, ".jpg" });
                        savePath = string.Concat(new object[] { path, @"\", title, "_#", num, ".jpg" });
                        frame.FrameVideoSaveToFile(str4);
                        if (flag)
                        {
                            if (!GetCropRatio(str4, frameCropRatio))
                            {
                                class2.CropeImageAsperAspectRatio(str4, savePath, width, height);
                                list.Add(savePath);
                                list2.Add(str4);
                            }
                            else
                            {
                                File.Copy(str4, savePath);
                                list.Add(savePath);
                                list2.Add(str4);
                            }
                        }
                        else
                        {
                            File.Copy(str4, savePath);
                            list.Add(savePath);
                            list2.Add(str4);
                        }
                    }
                }
                o.FilePlayStop(0.0);
                o.ObjectClose();
                Marshal.ReleaseComObject(frame);
                Marshal.ReleaseComObject(o);
                foreach (string str6 in list2)
                {
                    try
                    {
                        File.Delete(str6);
                    }
                    catch (Exception)
                    {
                    }
                }
                return list;
            }
            catch (Exception exception2)
            {
                ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception2));
                return null;
            }
        }

        public static string ExtractThumbnail(string fileName)
        {
            try
            {
                MFrame frame;
                MFileClass o = new MFileClass();
                o.FileNameSet(fileName, "");
                o.FilePlayStart();
                Thread.Sleep(0x3e8);
                string path = string.Empty;
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                o.FileFrameGet(4.0, 0.0, out frame);
                path = baseDirectory + @"\Output.jpg";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                frame.FrameVideoSaveToFile(path);
                o.FileInOutGet(out startTime, out stopTime, out VideoLength);
                o.FilePlayStop(0.0);
                o.ObjectClose();
                Marshal.ReleaseComObject(frame);
                Marshal.ReleaseComObject(o);
                return path;
            }
            catch (Exception exception)
            {
                ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception));
                return null;
            }
        }

        private MCHROMAKEYLib.MChromaKey GetChromakeyFilter(object source)
        {
            try
            {
                int num = 0;
                IMPlugins plugins = (IMPlugins) source;
                plugins.PluginsGetCount(out num);
                for (int i = 0; i < num; i++)
                {
                    object obj2;
                    long num3;
                    plugins.PluginsGetByIndex(i, out obj2, out num3);
                    try
                    {
                        return (MCHROMAKEYLib.MChromaKey) obj2;
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            return null;
        }

        private static bool GetCropRatio(string imagePath, string frameCropRatio)
        {
            string[] strArray = frameCropRatio.Split(new char[] { 'x' });
            string str = string.Format("{0}:{1}", strArray[0], strArray[1]);
            BitmapImage source = new BitmapImage();
            using (FileStream stream = File.OpenRead(imagePath.ToString()))
            {
                MemoryStream destination = new MemoryStream();
                stream.CopyTo(destination);
                destination.Seek(0L, SeekOrigin.Begin);
                stream.Close();
                source.BeginInit();
                source.StreamSource = destination;
                source.EndInit();
                source.Freeze();
            }
            Bitmap bitmap = null;
            using (MemoryStream stream3 = new MemoryStream())
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(source));
                encoder.Save(stream3);
                bitmap = new Bitmap(stream3);
            }
            Image image2 = bitmap;
            int width = image2.Width;
            int height = image2.Height;
            int a = width;
            int b = height;
            VideoProcessingClass class2 = new VideoProcessingClass();
            return (string.Format("{0}:{1}", a / class2.GCD(a, b), b / class2.GCD(a, b)) == str);
        }

        private static bool getFrameRatio(string frameCropRatio, out int width, out int height)
        {
            if ((frameCropRatio == "None") || string.IsNullOrEmpty(frameCropRatio))
            {
                width = 0;
                height = 0;
                return false;
            }
            if (frameCropRatio == "4x6")
            {
                width = 0x708;
                height = 0x4b0;
            }
            else if (frameCropRatio == "6x8")
            {
                width = 0x960;
                height = 0x708;
            }
            else
            {
                width = 0xbb8;
                height = 0x960;
            }
            return true;
        }

        private void LoadChromaPlugin(bool onloadChroma, object source)
        {
            try
            {
                if (source != null)
                {
                    int num;
                    IMPlugins plugins = source as IMPlugins;
                    object obj2 = null;
                    bool flag = false;
                    plugins.PluginsGetCount(out num);
                    for (int i = 0; i < num; i++)
                    {
                        long num2;
                        plugins.PluginsGetByIndex(i, out obj2, out num2);
                        if ((obj2.GetType().Name == "CoMChromaKeyClass") || (obj2.GetType().Name == "MChromaKeyClass"))
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!(flag && (!onloadChroma || flag)))
                    {
                        plugins.PluginsAdd(new MChromaKeyClass(), 0L);
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception));
            }
        }

        private MCHROMAKEYLib.MChromaKey LoadChromaPlugin(bool onloadChroma, object source, int a)
        {
            MCHROMAKEYLib.MChromaKey key = null;
            try
            {
                int num;
                IMPlugins plugins = (IMPlugins) source;
                object obj2 = null;
                bool flag = false;
                plugins.PluginsGetCount(out num);
                for (int i = 0; i < num; i++)
                {
                    long num2;
                    plugins.PluginsGetByIndex(i, out obj2, out num2);
                    if ((obj2.GetType().Name == "CoMChromaKeyClass") || (obj2.GetType().Name == "MChromaKeyClass"))
                    {
                        flag = true;
                        break;
                    }
                }
                if (!(flag && (!onloadChroma || flag)))
                {
                    key = new MChromaKeyClass();
                    plugins.PluginsAdd(key, 0L);
                    return key;
                }
                if (flag)
                {
                    plugins.PluginsRemove(obj2);
                }
            }
            catch (Exception exception)
            {
                ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception));
            }
            return key;
        }

        public MCHROMAKEYLib.MChromaKey LoadChromaScreen(MItem pFile, string streamId)
        {
            MCHROMAKEYLib.MChromaKey pChromaKey = null;
            try
            {
                if (pFile != null)
                {
                    this.LoadChromaPlugin(true, pFile);
                    Thread.Sleep(500);
                    pChromaKey = this.GetChromakeyFilter(pFile);
                    try
                    {
                        ((MPLATFORMLib.IMProps) pChromaKey).PropsSet("gpu_mode", "true");
                    }
                    catch
                    {
                    }
                    Thread.Sleep(500);
                    if (pChromaKey != null)
                    {
                        new FormChromaKey(pChromaKey).ShowDialog();
                    }
                }
                return pChromaKey;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static VideoColorEffects ReadColorXml(string path)
        {
            VideoColorEffects effects = new VideoColorEffects();
            try
            {
                if (File.Exists(path))
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(path);
                    effects.ULevel = Convert.ToDouble(document.GetElementsByTagName("ULevel")[0].InnerText);
                    effects.UVGain = Convert.ToDouble(document.GetElementsByTagName("UVGain")[0].InnerText);
                    effects.VLevel = Convert.ToDouble(document.GetElementsByTagName("VLevel")[0].InnerText);
                    effects.YGain = Convert.ToDouble(document.GetElementsByTagName("YGain")[0].InnerText);
                    effects.YLevel = Convert.ToDouble(document.GetElementsByTagName("YLevel")[0].InnerText);
                    effects.BlackLevel = Convert.ToDouble(document.GetElementsByTagName("BlackLevel")[0].InnerText);
                    effects.Brightness = Convert.ToDouble(document.GetElementsByTagName("Brightness")[0].InnerText);
                    effects.ColorGain = Convert.ToDouble(document.GetElementsByTagName("ColorGain")[0].InnerText);
                    effects.Contrast = Convert.ToDouble(document.GetElementsByTagName("Contrast")[0].InnerText);
                    effects.WhiteLevel = Convert.ToDouble(document.GetElementsByTagName("WhiteLevel")[0].InnerText);
                    effects.PresetEffects = document.GetElementsByTagName("PresetEffects")[0].InnerText;
                    return effects;
                }
                effects = VideoPresetColorEffects(3);
            }
            catch (Exception exception)
            {
                ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception));
            }
            return effects;
        }

        public static void ResizeImage(string sourceImage, int maxHeight, string saveToPath)
        {
            try
            {
                try
                {
                    BitmapImage image = new BitmapImage();
                    BitmapImage source = new BitmapImage();
                    using (FileStream stream = File.OpenRead(sourceImage.ToString()))
                    {
                        MemoryStream destination = new MemoryStream();
                        stream.CopyTo(destination);
                        destination.Seek(0L, SeekOrigin.Begin);
                        stream.Close();
                        image.BeginInit();
                        image.StreamSource = destination;
                        image.EndInit();
                        image.Freeze();
                        decimal num = Convert.ToDecimal(image.Width) / Convert.ToDecimal(image.Height);
                        int num2 = Convert.ToInt32((decimal) (maxHeight * num));
                        int num3 = maxHeight;
                        destination.Seek(0L, SeekOrigin.Begin);
                        source.BeginInit();
                        source.StreamSource = destination;
                        source.DecodePixelWidth = num2;
                        source.DecodePixelHeight = num3;
                        source.EndInit();
                        source.Freeze();
                    }
                    using (FileStream stream3 = new FileStream(saveToPath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        JpegBitmapEncoder encoder = new JpegBitmapEncoder {
                            QualityLevel = 0x5e
                        };
                        encoder.Frames.Add(BitmapFrame.Create(source));
                        encoder.Save(stream3);
                    }
                }
                catch (Exception exception)
                {
                    ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception));
                }
            }
            finally
            {
            }
        }

        public static VideoColorEffects VideoPresetColorEffects(int PresetEffectId)
        {
            VideoColorEffects effects = new VideoColorEffects();
            try
            {
                if (PresetEffectId == 1)
                {
                    effects.ULevel = 0.0;
                    effects.UVGain = 0.0;
                    effects.VLevel = 0.0;
                    effects.YGain = 100.0;
                    effects.YLevel = 0.0;
                    effects.BlackLevel = 0.0;
                    effects.Brightness = 0.0;
                    effects.ColorGain = 100.0;
                    effects.Contrast = 0.0;
                    effects.WhiteLevel = 100.0;
                }
                if (PresetEffectId == 2)
                {
                    effects.ULevel = -50.0;
                    effects.UVGain = 15.0;
                    effects.VLevel = 45.0;
                    effects.YGain = 100.0;
                    effects.YLevel = 0.0;
                    effects.BlackLevel = 0.0;
                    effects.Brightness = 0.0;
                    effects.ColorGain = 100.0;
                    effects.Contrast = 0.0;
                    effects.WhiteLevel = 100.0;
                }
                if (PresetEffectId == 3)
                {
                    effects.ULevel = 0.0;
                    effects.UVGain = 100.0;
                    effects.VLevel = 0.0;
                    effects.YGain = 100.0;
                    effects.YLevel = 0.0;
                    effects.BlackLevel = 0.0;
                    effects.Brightness = 0.0;
                    effects.ColorGain = 100.0;
                    effects.Contrast = 0.0;
                    effects.WhiteLevel = 100.0;
                }
                if (PresetEffectId == 4)
                {
                    effects.ULevel = -50.0;
                    effects.UVGain = 15.0;
                    effects.VLevel = 45.0;
                    effects.YGain = 100.0;
                    effects.YLevel = 0.0;
                    effects.BlackLevel = 0.0;
                    effects.Brightness = 0.0;
                    effects.ColorGain = 100.0;
                    effects.Contrast = 0.0;
                    effects.WhiteLevel = 100.0;
                }
            }
            catch (Exception exception)
            {
                ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception));
            }
            return effects;
        }
    }
}

