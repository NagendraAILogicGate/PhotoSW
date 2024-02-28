using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FrameworkHelper
{
	public class VideoProcessingClass
	{
		public System.Collections.Hashtable SupportedVideoFormats = new System.Collections.Hashtable();

		public VideoProcessingClass()
		{
			this.SupportedVideoFormats.Add("mp4", ".mp4");
			this.SupportedVideoFormats.Add("avi", ".avi");
			this.SupportedVideoFormats.Add("mov", ".mov");
			this.SupportedVideoFormats.Add("wmv", ".wmv");
			this.SupportedVideoFormats.Add("3gp", ".3gp");
			this.SupportedVideoFormats.Add("3g2", ".3gp");
			this.SupportedVideoFormats.Add("m2v", ".m2v");
			this.SupportedVideoFormats.Add("m4v", ".m4v");
			this.SupportedVideoFormats.Add("flv", ".flv");
			this.SupportedVideoFormats.Add("mpeg", ".mpg");
			this.SupportedVideoFormats.Add("ffmpeg", ".ffmpeg");
			this.SupportedVideoFormats.Add("mts", ".mts");
			this.SupportedVideoFormats.Add("mkv", ".mkv");
		}

		public string GetVideoEffectsXML(string lightness, string saturation, string contrast, string darkness, bool greyScale, bool invert, string textLogo, string textLogoPosition, string graphicLogo, string graphicLogoPosition, string zoom, string fadeInOut, bool chroma, string chromaKeyColor, string chromaKeyBG, string audio, string audioEffects, string textfontName, string textfontColor, string textfontSize, string textfontStyle, string amplify, string equal1, string equal2, string equal3, string equal4, string equal5, string equal6)
		{
			string text = string.Empty;
			text += "<effects>";
			text += "<lightness>";
			text += lightness;
			text += "</lightness>";
			text += "<saturation>";
			text += saturation;
			text += "</saturation>";
			text += "<contrast>";
			text += contrast;
			text += "</contrast>";
			text += "<darkness>";
			text += darkness;
			text += "</darkness>";
			text += "<greyScale>";
			text += greyScale.ToString();
			text += "</greyScale>";
			text += "<invert>";
			text += invert.ToString();
			text += "</invert>";
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"<textLogo textLogoPosition=\"",
				textLogoPosition,
				"\" textfontName=\"",
				textfontName,
				"\" textfontColor=\"",
				textfontColor,
				"\" textfontSize=\"",
				textfontSize,
				"\" textfontStyle=\"",
				textfontStyle,
				"\">"
			});
			text += textLogo;
			text += "</textLogo>";
			text = text + "<graphicLogo graphicLogoPosition=\"" + graphicLogoPosition + "\">";
			text += graphicLogo;
			text += "</graphicLogo>";
			text += "<zoom>";
			text += zoom;
			text += "</zoom>";
			text += "<fadeInOut>";
			text += fadeInOut;
			text += "</fadeInOut>";
			text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"<chroma chromaKeyColor=\"",
				chromaKeyColor,
				"\" chromaKeyBG=\"",
				chromaKeyBG,
				"\" >"
			});
			text += chroma.ToString();
			text += "</chroma>";
			text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"<audio amplify=\"",
				amplify,
				"\" equal1=\"",
				equal1,
				"\" equal2=\"",
				equal2,
				"\" equal3=\"",
				equal3,
				"\" equal4=\"",
				equal4,
				"\" equal5=\"",
				equal5,
				"\" equal6=\"",
				equal6,
				"\">"
			});
			text += audio;
			text += "</audio>";
			return text + "</effects>";
		}

		public void ExtractThumbnailFromVideo(string mediaFile, int waitTime, int position, string acquiredPath)
		{
			MediaPlayer mediaPlayer = new MediaPlayer
			{
				Volume = 0.0,
				ScrubbingEnabled = true
			};
			mediaPlayer.Open(new Uri(mediaFile));
			mediaPlayer.Pause();
			mediaPlayer.Position = System.TimeSpan.FromSeconds((double)position);
			System.Threading.Thread.Sleep(waitTime * 1000);
			RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(120, 90, 96.0, 96.0, PixelFormats.Pbgra32);
			DrawingVisual drawingVisual = new DrawingVisual();
			using (DrawingContext drawingContext = drawingVisual.RenderOpen())
			{
				drawingContext.DrawVideo(mediaPlayer, new Rect(0.0, 0.0, 120.0, 90.0));
			}
			renderTargetBitmap.Render(drawingVisual);
			Duration naturalDuration = mediaPlayer.NaturalDuration;
			if (naturalDuration.HasTimeSpan)
			{
				int num = (int)naturalDuration.TimeSpan.TotalSeconds;
			}
			BitmapFrame item = BitmapFrame.Create(renderTargetBitmap).GetCurrentValueAsFrozen() as BitmapFrame;
			BitmapEncoder bitmapEncoder = new JpegBitmapEncoder();
			bitmapEncoder.Frames.Add(item);
			System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
			bitmapEncoder.Save(memoryStream);
			System.IO.FileStream fileStream = new System.IO.FileStream(acquiredPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
			memoryStream.WriteTo(fileStream);
			fileStream.Close();
			memoryStream.Close();
			mediaPlayer.Close();
		}

		public string CropeImageAsperAspectRatio(string sourceImage, string SavePath, int width, int height)
		{
			string result = string.Empty;
			BitmapImage bitmapImage = new BitmapImage();
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
			Image img = bitmap;
			int num = width;
			int num2 = height;
			if (width == 1072)
			{
				num = 1080;
			}
			else if (height == 1072)
			{
				num2 = 1080;
			}
			result = string.Format("{0}:{1}", num / this.GCD(num, num2), num2 / this.GCD(num, num2));
			int num3 = num / this.GCD(num, num2);
			int num4 = num2 / this.GCD(num, num2);
			Image image = this.resizeImg(img, width, (double)num3, (double)num4);
			image.Save(SavePath);
			return result;
		}

		private Image resizeImg(Image img, int width, double aspectRatio_X, double aspectRatio_Y)
		{
			double num = System.Convert.ToDouble(width) / (aspectRatio_X / aspectRatio_Y);
			img = this.cropImg(img, aspectRatio_X, aspectRatio_Y);
			Bitmap bitmap = new Bitmap(width, (int)num);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawImage(img, new Rectangle(0, 0, bitmap.Width, bitmap.Height), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
			return bitmap;
		}

		private Image cropImg(Image img, double aspectRatio_X, double aspectRatio_Y)
		{
			double num = System.Convert.ToDouble(img.Width);
			double num2 = System.Convert.ToDouble(img.Height);
			double num3 = num - num2 * (aspectRatio_X / aspectRatio_Y);
			double num4 = num3 / 2.0;
			Bitmap bitmap = new Bitmap((int)((double)img.Width - num3), img.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawImage(img, new Rectangle(0, 0, (int)((double)img.Width - num3), img.Height), new Rectangle((int)num4, 0, (int)(num - num3), img.Height), GraphicsUnit.Pixel);
			return bitmap;
		}

		public int GCD(int a, int b)
		{
			while (b != 0)
			{
				int num = a % b;
				a = b;
				b = num;
			}
			return a;
		}
	}
}
