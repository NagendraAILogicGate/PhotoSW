using ErrorHandler;
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

namespace FrameworkHelper.Common
{
	public class MLHelpers
	{
		private static double startTime;

		private static double stopTime;

		public static double VideoLength;

		public MLHelpers()
		{
            //ChromaKeypluginLic.IntializeProtection();
            //DecoderlibLic.IntializeProtection();
            //EncoderlibLic.IntializeProtection();
            //MComposerlibLic.IntializeProtection();
            //MPlatformSDKLic.IntializeProtection();
		}

		public static string ExtractThumbnail(string fileName)
		{
			string result;
			try
			{
				MFileClass mFileClass = new MFileClass();
				mFileClass.FileNameSet(fileName, "");
				mFileClass.FilePlayStart();
				System.Threading.Thread.Sleep(1000);
				string text = string.Empty;
				string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
				MFrame mFrame;
				mFileClass.FileFrameGet(4.0, 0.0, out mFrame);
				text = baseDirectory + "\\Output.jpg";
				if (System.IO.File.Exists(text))
				{
					System.IO.File.Delete(text);
				}
				mFrame.FrameVideoSaveToFile(text);
				mFileClass.FileInOutGet(out MLHelpers.startTime, out MLHelpers.stopTime, out MLHelpers.VideoLength);
				mFileClass.FilePlayStop(0.0);
				mFileClass.ObjectClose();
				System.Runtime.InteropServices.Marshal.ReleaseComObject(mFrame);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(mFileClass);
				result = text;
			}
			catch (System.Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
				result = null;
			}
			return result;
		}

		public static string ExtractFrame(string frameCropRatio, string fileName, string tempFolderPath, string extractedImagePath)
		{
			string result;
			try
			{
				string text = tempFolderPath + "ResizeFrames\\";
				if (!System.IO.Directory.Exists(text))
				{
					System.IO.Directory.CreateDirectory(text);
				}
				string text2 = text + fileName;
				VideoProcessingClass videoProcessingClass = new VideoProcessingClass();
				int height = 0;
				int width = 0;
				bool frameRatio = MLHelpers.getFrameRatio(frameCropRatio, out width, out height);
				MFileClass mFileClass = new MFileClass();
				if (frameRatio)
				{
					if (!MLHelpers.GetCropRatio(extractedImagePath, frameCropRatio))
					{
						videoProcessingClass.CropeImageAsperAspectRatio(extractedImagePath, text2, width, height);
					}
					else
					{
						System.IO.File.Copy(extractedImagePath, text2, true);
					}
				}
				else
				{
					System.IO.File.Copy(extractedImagePath, text2, true);
				}
				try
				{
					System.IO.File.Delete(extractedImagePath);
				}
				catch (System.Exception var_8_96)
				{
				}
				result = text2;
				return result;
			}
			catch (System.Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
			result = null;
			return result;
		}

		public static System.Collections.Generic.List<string> ExtractFrame(string FileName, System.Collections.Generic.List<double> FrameSec, string Userid, string FileFullName, string frameCropRatio)
		{
			System.Collections.Generic.List<string> result;
			try
			{
				int num = 0;
				VideoProcessingClass videoProcessingClass = new VideoProcessingClass();
				string text = string.Empty;
				string text2 = string.Empty;
				int height = 0;
				int width = 0;
				bool frameRatio = MLHelpers.getFrameRatio(frameCropRatio, out width, out height);
				System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
				System.Collections.Generic.List<string> list2 = new System.Collections.Generic.List<string>();
				MFileClass mFileClass = new MFileClass();
				mFileClass.FileNameSet(FileName, "");
				mFileClass.FilePlayStart();
				System.Threading.Thread.Sleep(1000);
				string text3 = string.Empty;
				string text4 = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Frames");
				text = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Frames", "ResizeImagePath");
				if (!System.IO.Directory.Exists(text4))
				{
					System.IO.Directory.CreateDirectory(text4);
				}
				if (!System.IO.Directory.Exists(text))
				{
					System.IO.Directory.CreateDirectory(text);
				}
				MFrame mFrame = null;
				foreach (double num2 in FrameSec)
				{
					if (num2 <= MLHelpers.VideoLength)
					{
						num++;
						mFileClass.FileFrameGet(num2, 0.0, out mFrame);
						text3 = string.Concat(new object[]
						{
							text4,
							"\\",
							FileFullName,
							"_",
							num,
							"@",
							Userid,
							".jpg"
						});
						text2 = string.Concat(new object[]
						{
							text,
							"\\",
							FileFullName,
							"_",
							num,
							"@",
							Userid,
							".jpg"
						});
						mFrame.FrameVideoSaveToFile(text3);
						if (frameRatio)
						{
							if (!MLHelpers.GetCropRatio(text3, frameCropRatio))
							{
								videoProcessingClass.CropeImageAsperAspectRatio(text3, text2, width, height);
								list.Add(text2);
								list2.Add(text3);
							}
							else
							{
								System.IO.File.Copy(text3, text2);
								list.Add(text2);
								list2.Add(text3);
							}
						}
						else
						{
							System.IO.File.Copy(text3, text2);
							list.Add(text2);
							list2.Add(text3);
						}
					}
				}
				mFileClass.FilePlayStop(0.0);
				mFileClass.ObjectClose();
				System.Runtime.InteropServices.Marshal.ReleaseComObject(mFrame);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(mFileClass);
				foreach (string current in list2)
				{
					try
					{
						System.IO.File.Delete(current);
					}
					catch (System.Exception var_15_29D)
					{
					}
				}
				result = list;
			}
			catch (System.Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
				result = null;
			}
			return result;
		}

		private static bool GetCropRatio(string imagePath, string frameCropRatio)
		{
			string[] array = frameCropRatio.Split(new char[]
			{
				'x'
			});
			string b = string.Format("{0}:{1}", array[0], array[1]);
			string a = string.Empty;
			BitmapImage bitmapImage = new BitmapImage();
			using (System.IO.FileStream fileStream = System.IO.File.OpenRead(imagePath.ToString()))
			{
				System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
				fileStream.CopyTo(memoryStream);
				memoryStream.Seek(0L, System.IO.SeekOrigin.Begin);
				fileStream.Close();
				bitmapImage.BeginInit();
				bitmapImage.StreamSource = memoryStream;
				bitmapImage.EndInit();
				bitmapImage.Freeze();
			}
			Bitmap bitmap = null;
			using (System.IO.MemoryStream memoryStream2 = new System.IO.MemoryStream())
			{
				new PngBitmapEncoder
				{
					Frames = 
					{
						BitmapFrame.Create(bitmapImage)
					}
				}.Save(memoryStream2);
				bitmap = new Bitmap(memoryStream2);
			}
			Image image = bitmap;
			int width = image.Width;
			int height = image.Height;
			int num = width;
			int num2 = height;
			VideoProcessingClass videoProcessingClass = new VideoProcessingClass();
			a = string.Format("{0}:{1}", num / videoProcessingClass.GCD(num, num2), num2 / videoProcessingClass.GCD(num, num2));
			return a == b;
		}

		private static bool getFrameRatio(string frameCropRatio, out int width, out int height)
		{
			bool result;
			if (frameCropRatio == "None" || string.IsNullOrEmpty(frameCropRatio))
			{
				width = 0;
				height = 0;
				result = false;
			}
			else
			{
				if (frameCropRatio == "4x6")
				{
					width = 1800;
					height = 1200;
				}
				else if (frameCropRatio == "6x8")
				{
					width = 2400;
					height = 1800;
				}
				else
				{
					width = 3000;
					height = 2400;
				}
				result = true;
			}
			return result;
		}

		public static System.Collections.Generic.List<string> ExtractFramesManualDownload(System.Collections.Generic.List<double> FrameSec, string title, string videopath, string extension, string frameCropRatio)
		{
			System.Collections.Generic.List<string> result;
			try
			{
				string bsFile = System.IO.Path.Combine(videopath, title + extension);
				int num = 0;
				System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
				System.Collections.Generic.List<string> list2 = new System.Collections.Generic.List<string>();
				string text = string.Empty;
				VideoProcessingClass videoProcessingClass = new VideoProcessingClass();
				string text2 = string.Empty;
				int height = 0;
				int width = 0;
				bool frameRatio = MLHelpers.getFrameRatio(frameCropRatio, out width, out height);
				MFileClass mFileClass = new MFileClass();
				mFileClass.FileNameSet(bsFile, "");
				mFileClass.FilePlayStart();
				System.Threading.Thread.Sleep(1000);
				string text3 = string.Empty;
				string text4 = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory), "ManualDownloadFrames");
				text = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory), "ManualDownloadFrames", "ResizeImagePath");
				if (!System.IO.Directory.Exists(text4))
				{
					System.IO.Directory.CreateDirectory(text4);
				}
				if (!System.IO.Directory.Exists(text))
				{
					System.IO.Directory.CreateDirectory(text);
				}
				MFrame mFrame = null;
				foreach (double num2 in FrameSec)
				{
					if (num2 <= MLHelpers.VideoLength)
					{
						num++;
						mFileClass.FileFrameGet(num2, 0.0, out mFrame);
						text3 = string.Concat(new object[]
						{
							text4,
							"\\",
							title,
							"_#",
							num,
							".jpg"
						});
						text2 = string.Concat(new object[]
						{
							text,
							"\\",
							title,
							"_#",
							num,
							".jpg"
						});
						mFrame.FrameVideoSaveToFile(text3);
						if (frameRatio)
						{
							if (!MLHelpers.GetCropRatio(text3, frameCropRatio))
							{
								videoProcessingClass.CropeImageAsperAspectRatio(text3, text2, width, height);
								list.Add(text2);
								list2.Add(text3);
							}
							else
							{
								System.IO.File.Copy(text3, text2);
								list.Add(text2);
								list2.Add(text3);
							}
						}
						else
						{
							System.IO.File.Copy(text3, text2);
							list.Add(text2);
							list2.Add(text3);
						}
					}
				}
				mFileClass.FilePlayStop(0.0);
				mFileClass.ObjectClose();
				System.Runtime.InteropServices.Marshal.ReleaseComObject(mFrame);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(mFileClass);
				foreach (string current in list2)
				{
					try
					{
						System.IO.File.Delete(current);
					}
					catch (System.Exception var_16_29F)
					{
					}
				}
				result = list;
			}
			catch (System.Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
				result = null;
			}
			return result;
		}

		public static void ResizeImage(string sourceImage, int maxHeight, string saveToPath)
		{
			try
			{
				BitmapImage bitmapImage = new BitmapImage();
				BitmapImage bitmapImage2 = new BitmapImage();
				using (System.IO.FileStream fileStream = System.IO.File.OpenRead(sourceImage.ToString()))
				{
					System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
					fileStream.CopyTo(memoryStream);
					memoryStream.Seek(0L, System.IO.SeekOrigin.Begin);
					fileStream.Close();
					bitmapImage.BeginInit();
					bitmapImage.StreamSource = memoryStream;
					bitmapImage.EndInit();
					bitmapImage.Freeze();
					decimal d = System.Convert.ToDecimal(bitmapImage.Width) / System.Convert.ToDecimal(bitmapImage.Height);
					int decodePixelWidth = System.Convert.ToInt32(maxHeight * d);
					memoryStream.Seek(0L, System.IO.SeekOrigin.Begin);
					bitmapImage2.BeginInit();
					bitmapImage2.StreamSource = memoryStream;
					bitmapImage2.DecodePixelWidth = decodePixelWidth;
					bitmapImage2.DecodePixelHeight = maxHeight;
					bitmapImage2.EndInit();
					bitmapImage2.Freeze();
				}
				using (System.IO.FileStream fileStream2 = new System.IO.FileStream(saveToPath, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
				{
					new JpegBitmapEncoder
					{
						QualityLevel = 94,
						Frames = 
						{
							BitmapFrame.Create(bitmapImage2)
						}
					}.Save(fileStream2);
				}
			}
			catch (System.Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
			finally
			{
			}
		}

		public static VideoColorEffects ReadColorXml(string path)
		{
			VideoColorEffects videoColorEffects = new VideoColorEffects();
			try
			{
				if (System.IO.File.Exists(path))
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.Load(path);
					videoColorEffects.ULevel = System.Convert.ToDouble(xmlDocument.GetElementsByTagName("ULevel")[0].InnerText);
					videoColorEffects.UVGain = System.Convert.ToDouble(xmlDocument.GetElementsByTagName("UVGain")[0].InnerText);
					videoColorEffects.VLevel = System.Convert.ToDouble(xmlDocument.GetElementsByTagName("VLevel")[0].InnerText);
					videoColorEffects.YGain = System.Convert.ToDouble(xmlDocument.GetElementsByTagName("YGain")[0].InnerText);
					videoColorEffects.YLevel = System.Convert.ToDouble(xmlDocument.GetElementsByTagName("YLevel")[0].InnerText);
					videoColorEffects.BlackLevel = System.Convert.ToDouble(xmlDocument.GetElementsByTagName("BlackLevel")[0].InnerText);
					videoColorEffects.Brightness = System.Convert.ToDouble(xmlDocument.GetElementsByTagName("Brightness")[0].InnerText);
					videoColorEffects.ColorGain = System.Convert.ToDouble(xmlDocument.GetElementsByTagName("ColorGain")[0].InnerText);
					videoColorEffects.Contrast = System.Convert.ToDouble(xmlDocument.GetElementsByTagName("Contrast")[0].InnerText);
					videoColorEffects.WhiteLevel = System.Convert.ToDouble(xmlDocument.GetElementsByTagName("WhiteLevel")[0].InnerText);
					videoColorEffects.PresetEffects = xmlDocument.GetElementsByTagName("PresetEffects")[0].InnerText;
				}
				else
				{
					videoColorEffects = MLHelpers.VideoPresetColorEffects(3);
				}
			}
			catch (System.Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
			return videoColorEffects;
		}

		public static VideoColorEffects VideoPresetColorEffects(int PresetEffectId)
		{
			VideoColorEffects videoColorEffects = new VideoColorEffects();
			try
			{
				if (PresetEffectId == 1)
				{
					videoColorEffects.ULevel = 0.0;
					videoColorEffects.UVGain = 0.0;
					videoColorEffects.VLevel = 0.0;
					videoColorEffects.YGain = 100.0;
					videoColorEffects.YLevel = 0.0;
					videoColorEffects.BlackLevel = 0.0;
					videoColorEffects.Brightness = 0.0;
					videoColorEffects.ColorGain = 100.0;
					videoColorEffects.Contrast = 0.0;
					videoColorEffects.WhiteLevel = 100.0;
				}
				if (PresetEffectId == 2)
				{
					videoColorEffects.ULevel = -50.0;
					videoColorEffects.UVGain = 15.0;
					videoColorEffects.VLevel = 45.0;
					videoColorEffects.YGain = 100.0;
					videoColorEffects.YLevel = 0.0;
					videoColorEffects.BlackLevel = 0.0;
					videoColorEffects.Brightness = 0.0;
					videoColorEffects.ColorGain = 100.0;
					videoColorEffects.Contrast = 0.0;
					videoColorEffects.WhiteLevel = 100.0;
				}
				if (PresetEffectId == 3)
				{
					videoColorEffects.ULevel = 0.0;
					videoColorEffects.UVGain = 100.0;
					videoColorEffects.VLevel = 0.0;
					videoColorEffects.YGain = 100.0;
					videoColorEffects.YLevel = 0.0;
					videoColorEffects.BlackLevel = 0.0;
					videoColorEffects.Brightness = 0.0;
					videoColorEffects.ColorGain = 100.0;
					videoColorEffects.Contrast = 0.0;
					videoColorEffects.WhiteLevel = 100.0;
				}
				if (PresetEffectId == 4)
				{
					videoColorEffects.ULevel = -50.0;
					videoColorEffects.UVGain = 15.0;
					videoColorEffects.VLevel = 45.0;
					videoColorEffects.YGain = 100.0;
					videoColorEffects.YLevel = 0.0;
					videoColorEffects.BlackLevel = 0.0;
					videoColorEffects.Brightness = 0.0;
					videoColorEffects.ColorGain = 100.0;
					videoColorEffects.Contrast = 0.0;
					videoColorEffects.WhiteLevel = 100.0;
				}
			}
			catch (System.Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
			return videoColorEffects;
		}

		public MCHROMAKEYLib.MChromaKey LoadChromaScreen(MItem pFile, string streamId)
		{
			MCHROMAKEYLib.MChromaKey mChromaKey = null;
			MCHROMAKEYLib.MChromaKey result;
			try
			{
				if (pFile != null)
				{
					this.LoadChromaPlugin(true, pFile);
					System.Threading.Thread.Sleep(500);
					mChromaKey = this.GetChromakeyFilter(pFile);
					try
					{
						((MPLATFORMLib.IMProps)mChromaKey).PropsSet("gpu_mode", "true");
					}
					catch
					{
					}
					System.Threading.Thread.Sleep(500);
					if (mChromaKey != null)
					{
						FormChromaKey formChromaKey = new FormChromaKey(mChromaKey);
						formChromaKey.ShowDialog();
					}
				}
				result = mChromaKey;
			}
			catch (System.Exception var_2_75)
			{
				result = null;
			}
			return result;
		}

		private MCHROMAKEYLib.MChromaKey GetChromakeyFilter(object source)
		{
			MCHROMAKEYLib.MChromaKey result = null;
			try
			{
				int num = 0;
				IMPlugins iMPlugins = (IMPlugins)source;
				iMPlugins.PluginsGetCount(out num);
				for (int i = 0; i < num; i++)
				{
					object obj;
					long num2;
					iMPlugins.PluginsGetByIndex(i, out obj, out num2);
					try
					{
						result = (MCHROMAKEYLib.MChromaKey)obj;
						break;
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private MCHROMAKEYLib.MChromaKey LoadChromaPlugin(bool onloadChroma, object source, int a)
		{
			MCHROMAKEYLib.MChromaKey mChromaKey = null;
			try
			{
				IMPlugins iMPlugins = (IMPlugins)source;
				object obj = null;
				bool flag = false;
				int num;
				iMPlugins.PluginsGetCount(out num);
				for (int i = 0; i < num; i++)
				{
					long num2;
					iMPlugins.PluginsGetByIndex(i, out obj, out num2);
					if (obj.GetType().Name == "CoMChromaKeyClass" || obj.GetType().Name == "MChromaKeyClass")
					{
						flag = true;
						break;
					}
				}
				if (!flag || (onloadChroma && !flag))
				{
					mChromaKey = new MChromaKeyClass();
					iMPlugins.PluginsAdd(mChromaKey, 0L);
				}
				else if (flag)
				{
					iMPlugins.PluginsRemove(obj);
				}
			}
			catch (System.Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
			return mChromaKey;
		}

		private void LoadChromaPlugin(bool onloadChroma, object source)
		{
			try
			{
				if (source != null)
				{
					IMPlugins iMPlugins = source as IMPlugins;
					object obj = null;
					bool flag = false;
					int num;
					iMPlugins.PluginsGetCount(out num);
					for (int i = 0; i < num; i++)
					{
						long num2;
						iMPlugins.PluginsGetByIndex(i, out obj, out num2);
						if (obj.GetType().Name == "CoMChromaKeyClass" || obj.GetType().Name == "MChromaKeyClass")
						{
							flag = true;
							break;
						}
					}
					if (!flag || (onloadChroma && !flag))
					{
						iMPlugins.PluginsAdd(new MChromaKeyClass(), 0L);
					}
				}
			}
			catch (System.Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
		}
	}
}
