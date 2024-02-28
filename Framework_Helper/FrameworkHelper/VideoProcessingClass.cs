namespace FrameworkHelper
{
    using System;
    using System.Collections;
    using System.Drawing;
    using System.IO;
    using System.Threading;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public class VideoProcessingClass
    {
        public Hashtable SupportedVideoFormats = new Hashtable();

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

        public string CropeImageAsperAspectRatio(string sourceImage, string SavePath, int width, int height)
        {
            string str = string.Empty;
            BitmapImage source = new BitmapImage();
            using (FileStream stream = File.OpenRead(sourceImage.ToString()))
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
            Image img = bitmap;
            int a = width;
            int b = height;
            if (width == 0x430)
            {
                a = 0x438;
            }
            else if (height == 0x430)
            {
                b = 0x438;
            }
            str = string.Format("{0}:{1}", a / this.GCD(a, b), b / this.GCD(a, b));
            int num3 = a / this.GCD(a, b);
            int num4 = b / this.GCD(a, b);
            this.resizeImg(img, width, (double) num3, (double) num4).Save(SavePath);
            return str;
        }

        private Image cropImg(Image img, double aspectRatio_X, double aspectRatio_Y)
        {
            double num = Convert.ToDouble(img.Width);
            double num2 = Convert.ToDouble(img.Height);
            double num3 = num - (num2 * (aspectRatio_X / aspectRatio_Y));
            double num4 = num3 / 2.0;
            Bitmap image = new Bitmap(img.Width - ((int) num3), img.Height);
            Graphics.FromImage(image).DrawImage(img, new Rectangle(0, 0, img.Width - ((int) num3), img.Height), new Rectangle((int) num4, 0, (int) (num - num3), img.Height), GraphicsUnit.Pixel);
            return image;
        }

        public void ExtractThumbnailFromVideo(string mediaFile, int waitTime, int position, string acquiredPath)
        {
            MediaPlayer player = new MediaPlayer {
                Volume = 0.0,
                ScrubbingEnabled = true
            };
            player.Open(new Uri(mediaFile));
            player.Pause();
            player.Position = TimeSpan.FromSeconds((double) position);
            Thread.Sleep((int) (waitTime * 0x3e8));
            RenderTargetBitmap source = new RenderTargetBitmap(120, 90, 96.0, 96.0, PixelFormats.Pbgra32);
            DrawingVisual visual = new DrawingVisual();
            using (DrawingContext context = visual.RenderOpen())
            {
                context.DrawVideo(player, new Rect(0.0, 0.0, 120.0, 90.0));
            }
            source.Render(visual);
            Duration naturalDuration = player.NaturalDuration;
            int totalSeconds = 0;
            if (naturalDuration.HasTimeSpan)
            {
                totalSeconds = (int) naturalDuration.TimeSpan.TotalSeconds;
            }
            BitmapFrame currentValueAsFrozen = BitmapFrame.Create(source).GetCurrentValueAsFrozen() as BitmapFrame;
            BitmapEncoder encoder = new JpegBitmapEncoder {
                Frames = { currentValueAsFrozen }
            };
            MemoryStream stream = new MemoryStream();
            encoder.Save(stream);
            FileStream stream2 = new FileStream(acquiredPath, FileMode.Create, FileAccess.Write);
            stream.WriteTo(stream2);
            stream2.Close();
            stream.Close();
            player.Close();
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

        public string GetVideoEffectsXML(string lightness, string saturation, string contrast, string darkness, bool greyScale, bool invert, string textLogo, string textLogoPosition, string graphicLogo, string graphicLogoPosition, string zoom, string fadeInOut, bool chroma, string chromaKeyColor, string chromaKeyBG, string audio, string audioEffects, string textfontName, string textfontColor, string textfontSize, string textfontStyle, string amplify, string equal1, string equal2, string equal3, string equal4, string equal5, string equal6)
        {
            string str3 = (((((((((string.Empty + "<effects>") + "<lightness>" + lightness) + "</lightness>" + "<saturation>") + saturation + "</saturation>") + "<contrast>" + contrast) + "</contrast>" + "<darkness>") + darkness + "</darkness>") + "<greyScale>" + greyScale.ToString()) + "</greyScale>" + "<invert>") + invert.ToString() + "</invert>";
            str3 = ((((((str3 + "<textLogo textLogoPosition=\"" + textLogoPosition + "\" textfontName=\"" + textfontName + "\" textfontColor=\"" + textfontColor + "\" textfontSize=\"" + textfontSize + "\" textfontStyle=\"" + textfontStyle + "\">") + textLogo + "</textLogo>") + "<graphicLogo graphicLogoPosition=\"" + graphicLogoPosition + "\">") + graphicLogo + "</graphicLogo>") + "<zoom>" + zoom) + "</zoom>" + "<fadeInOut>") + fadeInOut + "</fadeInOut>";
            str3 = (str3 + "<chroma chromaKeyColor=\"" + chromaKeyColor + "\" chromaKeyBG=\"" + chromaKeyBG + "\" >") + chroma.ToString() + "</chroma>";
            return (((str3 + "<audio amplify=\"" + amplify + "\" equal1=\"" + equal1 + "\" equal2=\"" + equal2 + "\" equal3=\"" + equal3 + "\" equal4=\"" + equal4 + "\" equal5=\"" + equal5 + "\" equal6=\"" + equal6 + "\">") + audio) + "</audio>" + "</effects>");
        }

        private Image resizeImg(Image img, int width, double aspectRatio_X, double aspectRatio_Y)
        {
            double num = Convert.ToDouble(width) / (aspectRatio_X / aspectRatio_Y);
            img = this.cropImg(img, aspectRatio_X, aspectRatio_Y);
            Bitmap image = new Bitmap(width, (int) num);
            Graphics.FromImage(image).DrawImage(img, new Rectangle(0, 0, image.Width, image.Height), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            return image;
        }
    }
}

