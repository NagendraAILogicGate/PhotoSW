using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using PhotoSW.Shader;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using DigiPhoto;

namespace PhotoSW.Views
{
	public partial class Burningimage : Window, IComponentConnector
	{
		private int _photoId;

		private double _hueshift = 0.0;

		private double _sharpen = 0.0;

		private double _currenthueshift = 0.0;

		private double _currentsharpen = 0.0;

		private double _cont = 1.0;

		private double _bright = 0.0;

		private double _attributeWidth = 10.0;

		private string _centerX = "";

		private string _centerY = "";

		private int _flipMode;

		private int _flipModeY;

		private bool _isGreenImage;

		private ContrastAdjustEffect _brighteff = new ContrastAdjustEffect();

		private ContrastAdjustEffect _conteff = new ContrastAdjustEffect();

		private MonochromeEffect _colorfiltereff = new MonochromeEffect();

		private ShiftHueEffect _shifthueeff = new ShiftHueEffect();

		private ShEffect _sharpeff = new ShEffect();

		//private BloomEffect _bloomeff = new BloomEffect();

		private ToneMappingEffect _defog = new ToneMappingEffect();

		private ChromaKeyHSVEffect _greenscreen = new ChromaKeyHSVEffect();

		private MultiChannelContrastEffect _under = new MultiChannelContrastEffect();

		private RedEyeEffect redEyeEffect = new RedEyeEffect();

		private RedEyeEffect redEyeEffectSecond = new RedEyeEffect();

		private redeyeMultiple redEyeEffectMultiple = new redeyeMultiple();

		private redeyeMultiple redEyeEffectMultiple1 = new redeyeMultiple();

		private int rotateangle = 0;

		private int graphicsTextBoxCount = 0;

		private int graphicsCount = 0;

		private int photoId = 0;

		private bool graphicsBorderApplied = false;

		private bool graphicsframeApplied = false;

		private TransformGroup _transformGroup;

		private TranslateTransform _translateTransform;

		private ScaleTransform _zoomTransform;

		private RotateTransform _rotateTransform;

		private double _zoomFactor = 1.0;

		private double _maxZoomFactor = 4.0;

		private double _graphicsZoomFactor = 1.0;

		private WriteableBitmap _bmp;

		

		public Collection<string> ImageArray
		{
			get;
			set;
		}

		public string ImageEffect
		{
			get;
			set;
		}

		public bool PrintJob
		{
			get;
			set;
		}

		public string PhotoName
		{
			get;
			set;
		}

		public int PhotoId
		{
			get
			{
				return this._photoId;
			}
			set
			{
				this._photoId = value;
			}
		}

		public Burningimage()
		{
			this.InitializeComponent();
		}

		private void Clear()
		{
			this.RemoveAllShaderEffects();
			this.RemoveAllGraphicsEffect();
		}

		private void RemoveAllGraphicsEffect()
		{
			try
			{
				this.canbackground.Background = null;
				List<UIElement> list = new List<UIElement>();
				IEnumerator expr_2C9 = this.dragCanvas.Children.GetEnumerator();
				IEnumerator enumerator;
				if (5 != 0)
				{
					enumerator = expr_2C9;
				}
				try
				{
					while (enumerator.MoveNext())
					{
						UIElement uIElement = (UIElement)enumerator.Current;
						bool arg_5C_0;
						bool expr_53 = arg_5C_0 = !(uIElement is Grid);
						if (!false)
						{
							bool flag = expr_53;
							arg_5C_0 = flag;
						}
						if (arg_5C_0)
						{
							list.Add(uIElement);
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				if (-1 != 0)
				{
					if (!false)
					{
						List<UIElement>.Enumerator enumerator2 = list.GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								UIElement uIElement = enumerator2.Current;
								this.dragCanvas.Children.Remove(uIElement);
							}
						}
						finally
						{
							if (true)
							{
								((IDisposable)enumerator2).Dispose();
							}
						}
					}
					list = new List<UIElement>();
					enumerator = this.frm.Children.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							UIElement uIElement = (UIElement)enumerator.Current;
							while (uIElement is OpaqueClickableImage)
							{
								if (2 != 0)
								{
									list.Add(uIElement);
									break;
								}
							}
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						bool arg_156_0 = disposable == null;
						bool expr_158;
						do
						{
							bool flag = arg_156_0;
							expr_158 = (arg_156_0 = flag);
						}
						while (3 == 0);
						if (!expr_158)
						{
							disposable.Dispose();
						}
					}
					if (6 != 0)
					{
						foreach (UIElement uIElement in list)
						{
							this.frm.Children.Remove(uIElement);
						}
						this._zoomFactor = 1.0;
						if (this._zoomTransform != null)
						{
							this._zoomTransform.CenterX = this.mainImage.ActualWidth / 2.0;
							this._zoomTransform.CenterY = this.mainImage.ActualHeight / 2.0;
							this._zoomTransform.ScaleX = this._zoomFactor;
							this._zoomTransform.ScaleY = this._zoomFactor;
							this._zoomTransform = new ScaleTransform();
							this._transformGroup = new TransformGroup();
							this._rotateTransform = new RotateTransform();
							this.GrdBrightness.RenderTransform = null;
							Canvas.SetLeft(this.GrdBrightness, 0.0);
							Canvas.SetTop(this.GrdBrightness, 0.0);
						}
					}
				}
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				do
				{
					ErrorHandler.ErrorHandler.LogFileWrite(message);
				}
				while (6 == 0);
			}
		}

		private void ReloadAllGraphicsEffect()
		{
			try
			{
				this.canbackground.Background = null;
				List<UIElement> expr_36F = new List<UIElement>();
				List<UIElement> list;
				if (!false)
				{
					list = expr_36F;
				}
				IEnumerator expr_38F = this.dragCanvas.Children.GetEnumerator();
				IEnumerator enumerator;
				if (!false)
				{
					enumerator = expr_38F;
				}
				try
				{
					while (enumerator.MoveNext())
					{
						UIElement uIElement = (UIElement)enumerator.Current;
						if (!(uIElement is Grid))
						{
							list.Add(uIElement);
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				foreach (UIElement uIElement in list)
				{
					
					this.dragCanvas.Children.Remove(uIElement);
				}
				list = new List<UIElement>();
				//using (IEnumerator enumerator = this.frm.Children.GetEnumerator())
                IEnumerator enumerator1 = this.frm.Children.GetEnumerator();
                try
                {
                    while (enumerator1.MoveNext())
                    {
                        UIElement uIElement = (UIElement)enumerator1.Current;
                        bool flag = !(uIElement is OpaqueClickableImage);
                        if (false || !flag)
                        {
                            list.Add(uIElement);
                        }
                    }
                }
                catch
                {
                }
				foreach (UIElement uIElement in list)
				{
					
					this.frm.Children.Remove(uIElement);
				}
				if (this._flipMode != 0 || this._flipModeY != 0)
				{
					this._zoomFactor = 1.0;
					this._zoomTransform.CenterX = Convert.ToDouble(this._centerX);
					this._zoomTransform.CenterY = Convert.ToDouble(this._centerY);
					this._zoomTransform.ScaleX = 1.0;
					this._zoomTransform.ScaleY = 1.0;
					this._translateTransform = new TranslateTransform();
					this._rotateTransform = new RotateTransform();
					do
					{
						this._transformGroup = new TransformGroup();
						this.GrdBrightness.RenderTransform = null;
						Canvas.SetLeft(this.GrdBrightness, 0.0);
						Canvas.SetTop(this.GrdBrightness, 0.0);
						this.FlipLoad();
					}
					while (5 == 0);
				}
				else
				{
					this._zoomFactor = 1.0;
					this._zoomTransform.CenterX = this.mainImage.ActualWidth / 2.0;
					this._zoomTransform.CenterY = this.mainImage.ActualHeight / 2.0;
					this._zoomTransform.ScaleX = this._zoomFactor;
					this._zoomTransform.ScaleY = this._zoomFactor;
					this._transformGroup = new TransformGroup();
					this._rotateTransform = new RotateTransform();
					this._zoomTransform = new ScaleTransform();
					this.GrdBrightness.RenderTransform = null;
					Canvas.SetLeft(this.GrdBrightness, 0.0);
					Canvas.SetTop(this.GrdBrightness, 0.0);
				}
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
		}

		private void RemoveAllShaderEffects()
		{
			try
			{
				if (false)
				{
					goto IL_5F;
				}
				IL_05:
				if (false)
				{
					goto IL_AD;
				}
				this.GrdInvert.Effect = null;
				this.GrdSharpen.Effect = null;
				this.GrdSketchGranite.Effect = null;
				this.GrdEmboss.Effect = null;
				this.Grdcartoonize.Effect = null;
				IL_5F:
				this.GrdGreyScale.Effect = null;
				this.GrdHueShift.Effect = null;
				this.Grdcolorfilter.Effect = null;
				this.GrdBrightness.Effect = null;
				this.GrdSepia.Effect = null;
				this.GrdRedEyeFirst.Effect = null;
				IL_AD:
				if (8 == 0)
				{
					goto IL_05;
				}
				this.GrdRedEyeSecond.Effect = null;
				this.GrdRedEyeMultiple.Effect = null;
				do
				{
					this.GrdRedEyeMultiple1.Effect = null;
				}
				while (2 == 0);
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				do
				{
					ErrorHandler.ErrorHandler.LogFileWrite(message);
				}
				while (false);
			}
			if (6 != 0)
			{
			}
		}

		private void ImageLoader(PhotoInfo objphoto)
		{
			this.grdZoomCanvas.UpdateLayout();
			this.GrdSize.UpdateLayout();
			this.Clear();
			this._attributeWidth = 10.0;
			this._centerX = "";
			this._centerY = "";
			this._flipMode = 0;
			this._flipModeY = 0;
			this.mainImage.SnapsToDevicePixels = true;
			RenderOptions.SetEdgeMode(this.mainImage, EdgeMode.Aliased);
			this.forWdht.RenderTransform = new RotateTransform();
			try
			{
				PhotoInfo photoDetailsbyPhotoId = new PhotoBusiness().GetPhotoDetailsbyPhotoId(this.PhotoId);
				bool hasValue = photoDetailsbyPhotoId.DG_Photos_IsRedEye.HasValue;
				bool hasValue2 = photoDetailsbyPhotoId.DG_Photos_IsCroped.HasValue;
				this._isGreenImage = photoDetailsbyPhotoId.DG_Photos_IsGreen.HasValue;
				if (hasValue2 && !this._isGreenImage)
				{
					using (FileStream fileStream = File.OpenRead(Path.Combine(objphoto.HotFolderPath, "Croped", objphoto.DG_Photos_FileName)))
					{
						BitmapImage bitmapImage = new BitmapImage();
						using (MemoryStream memoryStream = new MemoryStream())
						{
							if (!false)
							{
								do
								{
									fileStream.CopyTo(memoryStream);
									memoryStream.Seek(0L, SeekOrigin.Begin);
									fileStream.Close();
								}
								while (false);
								bitmapImage.BeginInit();
								bitmapImage.StreamSource = memoryStream;
								bitmapImage.EndInit();
								this.mainImage.Source = bitmapImage;
								this.widthimg.Source = bitmapImage;
							}
						}
					}
					if (8 == 0)
					{
						goto IL_2E8;
					}
				}
				else
				{
					using (FileStream fileStream = File.OpenRead(Path.Combine(objphoto.HotFolderPath, objphoto.DG_Photos_CreatedOn.ToString("yyyyMMdd"), objphoto.DG_Photos_FileName)))
					{
						BitmapImage bitmapImage = new BitmapImage();
						using (MemoryStream memoryStream = new MemoryStream())
						{
							fileStream.CopyTo(memoryStream);
							if (6 != 0)
							{
								memoryStream.Seek(0L, SeekOrigin.Begin);
								fileStream.Close();
								bitmapImage.BeginInit();
								bitmapImage.StreamSource = memoryStream;
							}
							bitmapImage.EndInit();
							if (false)
							{
								goto IL_245;
							}
							this.mainImage.Source = bitmapImage;
							IL_238:
							this.widthimg.Source = bitmapImage;
							IL_245:
							if (2 == 0)
							{
								goto IL_238;
							}
						}
					}
				}
				this.forWdht.Height = this.widthimg.Source.Height;
				this.forWdht.Width = this.widthimg.Source.Width;
				int arg_2C7_0 = (string.IsNullOrEmpty(this.ImageEffect) || this._isGreenImage) ? 1 : 0;
				IL_2C7:
				if (arg_2C7_0 == 0)
				{
					this.LoadXml(this.ImageEffect);
				}
				this.dragCanvas.AllowDragOutOfView = true;
				IL_2E8:
				this.GrdBrightness.Margin = new Thickness(0.0, 0.0, 0.0, 0.0);
				this.forWdht.HorizontalAlignment = HorizontalAlignment.Center;
				this.forWdht.VerticalAlignment = VerticalAlignment.Center;
				if (!this._isGreenImage)
				{
					this.LoadFromDB();
					this.Zomout(true);
				}
				else
				{
					this.forWdht.Width = this.widthimg.Source.Width;
					if (!false)
					{
						this.forWdht.Height = this.widthimg.Source.Height;
						this.GrdGreenScreenDefault3.RenderTransform = null;
					}
					Canvas.SetLeft(this.GrdBrightness, 0.0);
					Canvas.SetTop(this.GrdBrightness, 0.0);
					this.GrdBrightness.RenderTransform = null;
					this.grdZoomCanvas.RenderTransform = null;
				}
				int expr_3E9 = arg_2C7_0 = 3;
				if (expr_3E9 == 0)
				{
					goto IL_2C7;
				}
				int num = expr_3E9;
				if (ConfigurationSettings.AppSettings["SharpenFactor"] != null)
				{
					num = Convert.ToInt32(ConfigurationSettings.AppSettings["SharpenFactor"]);
				}
				if (num > 0)
				{
					this._currentsharpen += 0.025 * (double)num;
					this._sharpeff.Strength = this._currentsharpen;
					this._sharpeff.PixelWidth = 0.0015;
					this._sharpeff.PixelHeight = 0.0015;
					this.GrdSharpen.Effect = this._sharpeff;
				}
				this._currentsharpen = 0.0;
				this.dragCanvas.AllowDragging = false;
				this.dragCanvas.IsEnabled = false;
			}
			finally
			{
			}
		}

		public void ResetForm(PhotoInfo objphoto)
		{
			do
			{
				if (!false)
				{
					this._translateTransform = new TranslateTransform();
					this._rotateTransform = new RotateTransform();
					this._transformGroup = new TransformGroup();
					ErrorHandler.ErrorHandler.LogFileWrite("Load Photo " + this.PhotoId);
				}
				bool arg_5F_0;
				bool expr_57 = arg_5F_0 = (this.PhotoId > 0);
				if (!false)
				{
					arg_5F_0 = !expr_57;
				}
				if (arg_5F_0)
				{
					return;
				}
				ErrorHandler.ErrorHandler.LogFileWrite("Photo Details Completed");
				this.TbNumber.Text = objphoto.DG_Photos_RFID;
			}
			while (7 == 0);
			this.photoId = objphoto.DG_Photos_pkey;
			this.ImageEffect = objphoto.DG_Photos_Effects;
			this.ImageLoader(objphoto);
		}

		private void LoadXaml(string inputXml)
		{
			XmlDocument expr_D29 = new XmlDocument();
            Dictionary<string, int> obj=null;
			XmlDocument xmlDocument;
			if (3 != 0)
			{
				xmlDocument = expr_D29;
			}
			xmlDocument.LoadXml(inputXml);
			double num = 0.0;
			double value = 0.0;
			this._transformGroup = new TransformGroup();
			this._rotateTransform = new RotateTransform();
			try
			{
				if (6 == 0)
				{
					goto IL_972;
				}
				BitmapImage bitmapImage;
				if (xmlDocument.ChildNodes[0] != null)
				{
					foreach (object current in xmlDocument.ChildNodes[0].Attributes)
					{
						string text = ((XmlAttribute)current).Name.ToLower();
						if (text != null)
						{
							if (obj == null)
							{
								obj = new Dictionary<string, int>(8)
								{
									{
										"border",
										0
									},
									{
										"bg",
										1
									},
									{
										"canvasleft",
										2
									},
									{
										"canvastop",
										3
									},
									{
										"rotatetransform",
										4
									},
									{
										"scalecentrex",
										5
									},
									{
										"scalecentrey",
										6
									},
									{
										"zoomfactor",
										7
									}
								};
							}
							int num2;
                            if (obj.TryGetValue(text, out num2))
							{
								OpaqueClickableImage opaqueClickableImage;
								switch (num2)
								{
								case 0:
									if (((XmlAttribute)current).Value != string.Empty)
									{
										bitmapImage = new BitmapImage(new Uri(LoginUser.DigiFolderFramePath + "\\" + ((XmlAttribute)current).Value.ToString()));
										string[] array = bitmapImage.ToString().Split(new char[]
										{
											'/'
										});
										opaqueClickableImage = new OpaqueClickableImage();
										opaqueClickableImage.Uid = "frame";
										opaqueClickableImage.Source = bitmapImage;
										opaqueClickableImage.IsHitTestVisible = false;
										opaqueClickableImage.Stretch = Stretch.Fill;
										opaqueClickableImage.Loaded += new RoutedEventHandler(this.objCurrent_Loaded);
										double num3;
										if (bitmapImage.Height > bitmapImage.Width)
										{
											if (false)
											{
												break;
											}
											num3 = bitmapImage.Width / bitmapImage.Height;
										}
										else
										{
											num3 = bitmapImage.Height / bitmapImage.Width;
										}
										if (this.forWdht.Height > this.forWdht.Width)
										{
											this.forWdht.Width = this.forWdht.Height * num3;
										}
										else
										{
											this.forWdht.Height = this.forWdht.Width * num3;
										}
										this.frm.Width = this.forWdht.Width;
										this.frm.Height = this.forWdht.Height;
										this.forWdht.InvalidateArrange();
										goto IL_302;
									}
									break;
								case 1:
									if (((XmlAttribute)current).Value != string.Empty)
									{
										BitmapImage imageSource = new BitmapImage(new Uri(LoginUser.DigiFolderBackGroundPath + "\\" + ((XmlAttribute)current).Value));
										this.canbackground.Background = new ImageBrush
										{
											ImageSource = imageSource
										};
									}
									break;
								case 2:
									Canvas.SetLeft(this.GrdBrightness, Convert.ToDouble(((XmlAttribute)current).Value));
									break;
								case 3:
									Canvas.SetTop(this.GrdBrightness, Convert.ToDouble(((XmlAttribute)current).Value));
									break;
								case 4:
								{
									RotateTransform rotateTransform = new RotateTransform();
									rotateTransform.CenterX = 0.0;
									rotateTransform.CenterY = 0.0;
									rotateTransform.Angle = Convert.ToDouble(((XmlAttribute)current).Value);
									this.GrdBrightness.RenderTransformOrigin = new Point(0.5, 0.5);
									if (rotateTransform.Angle != -1.0 && rotateTransform.Angle != 0.0)
									{
										this.GrdBrightness.RenderTransform = rotateTransform;
									}
									break;
								}
								case 5:
									this._centerX = ((XmlAttribute)current).Value;
									if (3 == 0)
									{
										goto IL_302;
									}
									break;
								case 6:
									this._centerY = ((XmlAttribute)current).Value;
									break;
								case 7:
									this._zoomFactor = Convert.ToDouble(((XmlAttribute)current).Value);
									break;
								}
								continue;
								IL_302:
								this.forWdht.InvalidateMeasure();
								this.forWdht.InvalidateVisual();
								this.frm.Children.Add(opaqueClickableImage);
							}
						}
					}
				}
				bool flag = !(this._centerX != "-1");
				IL_50E:
				if (!flag)
				{
					ScaleTransform scaleTransform = new ScaleTransform();
					scaleTransform.CenterX = Convert.ToDouble(this._centerX);
					scaleTransform.CenterY = Convert.ToDouble(this._centerY);
					if (this._zoomFactor != -1.0)
					{
						scaleTransform.ScaleX = this._zoomFactor;
						scaleTransform.ScaleY = this._zoomFactor;
					}
					bool arg_593_0;
					if (this._flipMode == 0)
					{
						if (false)
						{
							goto IL_6B4;
						}
						arg_593_0 = (this._flipModeY == 0);
					}
					else
					{
						arg_593_0 = false;
					}
					if (!arg_593_0)
					{
						scaleTransform.ScaleX = scaleTransform.ScaleX;
					}
					this._zoomTransform = scaleTransform;
					this._transformGroup.Children.Add(scaleTransform);
				}
				if (num != 0.0)
				{
					TranslateTransform translateTransform = new TranslateTransform();
					translateTransform.X = Convert.ToDouble(num);
					translateTransform.Y = Convert.ToDouble(value);
					this._translateTransform = translateTransform;
					this._transformGroup.Children.Add(translateTransform);
				}
				if (this.GrdGreenScreenDefault3.RenderTransform == null)
				{
					this.GrdGreenScreenDefault3.RenderTransform = this._transformGroup;
				}
				XmlReader xmlReader = XmlReader.Create(new StringReader(xmlDocument.InnerXml));
				if (true)
				{
					goto IL_CFD;
				}
				goto IL_953;
				IL_6B4:
				Button button = new Button();
				button.HorizontalAlignment = HorizontalAlignment.Center;
				button.VerticalAlignment = VerticalAlignment.Center;
				Style style = (Style)base.FindResource("ButtonStyleGraphic");
				button.Style = style;
				Image image = new Image();
				bitmapImage = new BitmapImage(new Uri(LoginUser.DigiFolderGraphicsPath + "\\" + xmlReader.GetAttribute("source")));
				image.Name = "A" + Guid.NewGuid().ToString().Split(new char[]
				{
					'-'
				})[0];
				if (8 == 0)
				{
					goto IL_C63;
				}
				button.Name = "btn" + Guid.NewGuid().ToString().Split(new char[]
				{
					'-'
				})[0];
				button.Uid = "uid" + Guid.NewGuid().ToString().Split(new char[]
				{
					'-'
				})[0];
				bitmapImage.BeginInit();
				image.Source = bitmapImage;
				bitmapImage.EndInit();
				button.Width = 90.0;
				button.Height = 90.0;
				button.Content = image;
				this.dragCanvas.Children.Add(button);
				string value2 = string.Format("{0:0.00}", Convert.ToDouble(xmlReader.GetAttribute("left")));
				string value3 = string.Format("{0:0.00}", Convert.ToDouble(xmlReader.GetAttribute("top")));
				Canvas.SetLeft(button, Convert.ToDouble(value2));
				Canvas.SetTop(button, Convert.ToDouble(value3));
				double num4 = Convert.ToDouble(xmlReader.GetAttribute("zoomfactor"));
				FrameworkElement arg_8C7_0 = button;
				Convert.ToDouble(xmlReader.GetAttribute("wthsource"));
				arg_8C7_0.Width = Convert.ToDouble(xmlReader.GetAttribute("wthsource"));
				FrameworkElement arg_8F2_0 = button;
				Convert.ToDouble(xmlReader.GetAttribute("wthsource"));
				arg_8F2_0.Height = Convert.ToDouble(xmlReader.GetAttribute("wthsource"));
				button.Tag = num4.ToString();
				TransformGroup transformGroup = new TransformGroup();
				RotateTransform rotateTransform2 = new RotateTransform();
				ScaleTransform scaleTransform2 = new ScaleTransform();
				scaleTransform2.CenterX = 0.0;
				scaleTransform2.CenterY = 0.0;
				if (xmlReader.GetAttribute("scalex") == null)
				{
					goto IL_973;
				}
				IL_953:
				scaleTransform2.ScaleX = Convert.ToDouble(xmlReader.GetAttribute("scalex").ToString());
				IL_972:
				IL_973:
				if (xmlReader.GetAttribute("scaley") != null)
				{
					scaleTransform2.ScaleY = Convert.ToDouble(xmlReader.GetAttribute("scaley").ToString());
				}
				if (true)
				{
					button.RenderTransformOrigin = new Point(0.5, 0.5);
					transformGroup.Children.Add(scaleTransform2);
					rotateTransform2.CenterX = 0.0;
					rotateTransform2.CenterY = 0.0;
					rotateTransform2.Angle = Convert.ToDouble(xmlReader.GetAttribute("angle").ToString());
					button.RenderTransformOrigin = new Point(0.5, 0.5);
					do
					{
						transformGroup.Children.Add(rotateTransform2);
					}
					while (false);
					button.RenderTransform = transformGroup;
					this.graphicsCount++;
					goto IL_CFB;
				}
				IL_A95:
				flag = !(xmlReader.GetAttribute("foreground").ToString() != string.Empty);
				TextBox textBox;
				if (!flag)
				{
					BrushConverter brushConverter = new BrushConverter();
					if (2 == 0)
					{
						goto IL_50E;
					}
					Brush foreground = (Brush)brushConverter.ConvertFromString(xmlReader.GetAttribute("foreground").ToString());
					textBox.Foreground = foreground;
				}
				else
				{
					textBox.Foreground = new SolidColorBrush(Colors.DarkRed);
				}
				if (!(xmlReader.GetAttribute("fontsize").ToString() != string.Empty))
				{
					textBox.FontSize = 20.0;
					goto IL_B61;
				}
				IL_B2D:
				textBox.FontSize = Convert.ToDouble(xmlReader.GetAttribute("fontsize").ToString());
				IL_B61:
				if (xmlReader.GetAttribute("_fontfamily").ToString() != string.Empty)
				{
					FontFamily fontFamily = (FontFamily)new FontFamilyConverter().ConvertFromString(xmlReader.GetAttribute("_fontfamily").ToString());
					textBox.FontFamily = fontFamily;
				}
				textBox.RenderTransformOrigin = new Point(0.5, 0.5);
				textBox.Uid = "txtblock";
				textBox.FontWeight = FontWeights.Bold;
				textBox.BorderBrush = null;
				textBox.Style = (Style)base.FindResource("SearchIDTB");
				this.dragCanvas.Children.Add(textBox);
				Canvas.SetLeft(textBox, Convert.ToDouble(xmlReader.GetAttribute("left").ToString()));
				Canvas.SetTop(textBox, Convert.ToDouble(xmlReader.GetAttribute("top").ToString()));
				rotateTransform2 = new RotateTransform();
				IL_C63:
				rotateTransform2.CenterX = 0.0;
				if (-1 == 0)
				{
					goto IL_B2D;
				}
				rotateTransform2.CenterY = 0.0;
				rotateTransform2.Angle = Convert.ToDouble(xmlReader.GetAttribute("angle").ToString());
				textBox.RenderTransformOrigin = new Point(0.5, 0.5);
				textBox.RenderTransform = rotateTransform2;
				textBox.Text = xmlReader.GetAttribute("text").ToString();
				this.graphicsTextBoxCount++;
				IL_CFB:
				IL_CFC:
				IL_CFD:
				if (xmlReader.Read())
				{
					if (xmlReader.NodeType != XmlNodeType.Element)
					{
						goto IL_CFC;
					}
					string text = xmlReader.Name.ToString().ToLower();
					if (text == null)
					{
						goto IL_CFB;
					}
					if (text == "graphics")
					{
						goto IL_6B4;
					}
					if (!(text == "textbox"))
					{
						goto IL_CFB;
					}
					textBox = new TextBox();
					textBox.ContextMenu = this.dragCanvas.ContextMenu;
					textBox.Background = new SolidColorBrush(Colors.Transparent);
					goto IL_A95;
				}
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
		}

		private void LoadXml(string imageXml)
		{
			try
			{
				bool flag = false;
				XmlDocument xmlDocument = new XmlDocument();
				bool flag2 = false;
				xmlDocument.LoadXml(imageXml);
				foreach (object current in xmlDocument.ChildNodes[0].Attributes)
				{
					string text = ((XmlAttribute)current).Name.ToLower();
					switch (text)
					{
					case "brightness":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this._bright = Convert.ToDouble(((XmlAttribute)current).Value.ToString());
							this._brighteff.Brightness = this._bright;
							this._brighteff.Contrast = 1.0;
							this.GrdBrightness.Effect = this._brighteff;
							flag = true;
						}
						else
						{
							this.GrdBrightness.Effect = null;
						}
						break;
					case "firstredeye":
						if (((XmlAttribute)current).Value.ToString() == "true")
						{
							this.redEyeEffect.Radius = 0.0105;
							this.redEyeEffect.RedeyeTrue = 1.0;
							this.GrdRedEyeFirst.Effect = this.redEyeEffect;
							this.redEyeEffect.Center = new Point(0.5, 0.5);
						}
						else
						{
							this.GrdRedEyeFirst.Effect = null;
						}
						break;
					case "secondredeye":
						if (((XmlAttribute)current).Value.ToString() == "true")
						{
							this.redEyeEffectSecond.Radius = 0.0105;
							this.redEyeEffectSecond.RedeyeTrue = 1.0;
							this.GrdRedEyeSecond.Effect = this.redEyeEffectSecond;
							this.redEyeEffectSecond.Center = new Point(0.5, 0.5);
						}
						else
						{
							this.GrdRedEyeSecond.Effect = null;
						}
						break;
					case "firstradius":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffect.Radius = Convert.ToDouble(((XmlAttribute)current).Value);
						}
						break;
					case "aspectratiofirstredeye":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffect.AspectRatio = Convert.ToDouble(((XmlAttribute)current).Value);
						}
						break;
					case "aspectratiosecondredeye":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectSecond.AspectRatio = Convert.ToDouble(((XmlAttribute)current).Value);
						}
						break;
					case "secondradius":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectSecond.Radius = Convert.ToDouble(((XmlAttribute)current).Value);
						}
						break;
					case "firstcenterx":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffect.Center = new Point(Convert.ToDouble(((XmlAttribute)current).Value), 0.5);
						}
						break;
					case "firstcentery":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffect.Center = new Point(this.redEyeEffect.Center.X, Convert.ToDouble(((XmlAttribute)current).Value));
						}
						break;
					case "secondcenterx":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectSecond.Center = new Point(Convert.ToDouble(((XmlAttribute)current).Value), 0.5);
						}
						break;
					case "secondcentery":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectSecond.Center = new Point(this.redEyeEffectSecond.Center.X, Convert.ToDouble(((XmlAttribute)current).Value));
						}
						break;
					case "multipleredeye1":
						if (((XmlAttribute)current).Value.ToString() == "true")
						{
							this.redEyeEffectMultiple.Radius = 0.0105;
							this.redEyeEffectMultiple.RedeyeTrue = 1.0;
							this.GrdRedEyeMultiple.Effect = this.redEyeEffectMultiple;
							this.redEyeEffectMultiple.Center = new Point(0.5, 0.5);
						}
						else
						{
							this.GrdRedEyeMultiple.Effect = null;
						}
						break;
					case "multipleradius1":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectMultiple.Radius = Convert.ToDouble(((XmlAttribute)current).Value);
						}
						break;
					case "multiplecenterx1":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectMultiple.Center = new Point(Convert.ToDouble(((XmlAttribute)current).Value), 0.5);
						}
						break;
					case "multiplecentery1":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectMultiple.Center = new Point(this.redEyeEffectMultiple.Center.X, Convert.ToDouble(((XmlAttribute)current).Value));
						}
						break;
					case "multipleredeye2":
						if (((XmlAttribute)current).Value.ToString() == "true")
						{
							this.redEyeEffectMultiple.Radius1 = 0.0105;
							this.redEyeEffectMultiple.RedeyeTrue1 = 1.0;
							this.GrdRedEyeMultiple.Effect = this.redEyeEffectMultiple;
							this.redEyeEffectMultiple.Center1 = new Point(0.5, 0.5);
						}
						break;
					case "multipleradius2":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectMultiple.Radius1 = Convert.ToDouble(((XmlAttribute)current).Value);
						}
						break;
					case "multiplecenterx2":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectMultiple.Center1 = new Point(Convert.ToDouble(((XmlAttribute)current).Value), 0.5);
						}
						break;
					case "multiplecentery2":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectMultiple.Center1 = new Point(this.redEyeEffectMultiple.Center1.X, Convert.ToDouble(((XmlAttribute)current).Value));
						}
						break;
					case "multipleredeye3":
						if (((XmlAttribute)current).Value.ToString() == "true")
						{
							this.redEyeEffectMultiple.Radius2 = 0.0105;
							this.redEyeEffectMultiple.RedeyeTrue2 = 1.0;
							this.GrdRedEyeMultiple.Effect = this.redEyeEffectMultiple;
							this.redEyeEffectMultiple.Center2 = new Point(0.5, 0.5);
						}
						break;
					case "multipleradius3":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectMultiple.Radius2 = Convert.ToDouble(((XmlAttribute)current).Value);
						}
						break;
					case "multiplecenterx3":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectMultiple.Center2 = new Point(Convert.ToDouble(((XmlAttribute)current).Value), 0.5);
						}
						break;
					case "multiplecentery3":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectMultiple.Center2 = new Point(this.redEyeEffectMultiple.Center2.X, Convert.ToDouble(((XmlAttribute)current).Value));
						}
						break;
					case "multipleredeye4":
						if (((XmlAttribute)current).Value.ToString() == "true")
						{
							this.redEyeEffectMultiple1.Radius = 0.0105;
							this.redEyeEffectMultiple1.RedeyeTrue = 1.0;
							this.GrdRedEyeMultiple1.Effect = this.redEyeEffectMultiple1;
							this.redEyeEffectMultiple1.Center = new Point(0.5, 0.5);
						}
						else
						{
							this.GrdRedEyeMultiple1.Effect = null;
						}
						break;
					case "multipleradius4":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectMultiple1.Radius = Convert.ToDouble(((XmlAttribute)current).Value);
						}
						break;
					case "multiplecenterx4":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectMultiple1.Center = new Point(Convert.ToDouble(((XmlAttribute)current).Value), 0.5);
						}
						break;
					case "multiplecentery4":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectMultiple1.Center = new Point(this.redEyeEffectMultiple1.Center.X, Convert.ToDouble(((XmlAttribute)current).Value));
						}
						break;
					case "multipleredeye5":
						if (((XmlAttribute)current).Value.ToString() == "true")
						{
							this.redEyeEffectMultiple1.Radius1 = 0.0105;
							this.redEyeEffectMultiple1.RedeyeTrue1 = 1.0;
							this.GrdRedEyeMultiple1.Effect = this.redEyeEffectMultiple1;
							this.redEyeEffectMultiple1.Center1 = new Point(0.5, 0.5);
						}
						break;
					case "multipleradius5":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectMultiple1.Radius1 = Convert.ToDouble(((XmlAttribute)current).Value);
						}
						break;
					case "multiplecenterx5":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectMultiple1.Center1 = new Point(Convert.ToDouble(((XmlAttribute)current).Value), 0.5);
						}
						break;
					case "multiplecentery5":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectMultiple1.Center1 = new Point(this.redEyeEffectMultiple1.Center1.X, Convert.ToDouble(((XmlAttribute)current).Value));
						}
						break;
					case "multipleredeye6":
						if (((XmlAttribute)current).Value.ToString() == "true")
						{
							this.redEyeEffectMultiple1.Radius2 = 0.0105;
							this.redEyeEffectMultiple1.RedeyeTrue2 = 1.0;
							this.GrdRedEyeMultiple1.Effect = this.redEyeEffectMultiple1;
							this.redEyeEffectMultiple1.Center2 = new Point(0.5, 0.5);
						}
						break;
					case "multipleradius6":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectMultiple1.Radius2 = Convert.ToDouble(((XmlAttribute)current).Value);
						}
						break;
					case "multiplecenterx6":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectMultiple1.Center2 = new Point(Convert.ToDouble(((XmlAttribute)current).Value), 0.5);
						}
						break;
					case "multiplecentery6":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this.redEyeEffectMultiple1.Center2 = new Point(this.redEyeEffectMultiple1.Center2.X, Convert.ToDouble(((XmlAttribute)current).Value));
						}
						break;
					case "contrast":
						if (((XmlAttribute)current).Value.ToString() != "1")
						{
							if (((XmlAttribute)current).Value.ToString() == "##")
							{
								this._cont = 1.0;
							}
							else
							{
								this._cont = Convert.ToDouble(((XmlAttribute)current).Value.ToString());
							}
							this._conteff.Brightness = this._bright;
							this._conteff.Contrast = this._cont;
							this.GrdBrightness.Effect = this._conteff;
							flag = true;
						}
						break;
					case "rotate":
						if (((XmlAttribute)current).Value.ToString() != "##")
						{
							this.rotateangle = Convert.ToInt32(((XmlAttribute)current).Value.ToString());
							this.Rotate(this.rotateangle);
						}
						break;
					case "flipmode":
						if (((XmlAttribute)current).Value.ToString() != "##")
						{
							this._flipMode = Convert.ToInt32(((XmlAttribute)current).Value.ToString());
						}
						else
						{
							this._flipMode = 0;
						}
						break;
					case "flipmodey":
						if (((XmlAttribute)current).Value.ToString() != "##")
						{
							this._flipModeY = Convert.ToInt32(((XmlAttribute)current).Value.ToString());
						}
						else
						{
							this._flipModeY = 0;
						}
						break;
					case "_centerx":
						if (((XmlAttribute)current).Value.ToString() != "##")
						{
							this._centerX = ((XmlAttribute)current).Value.ToString();
						}
						else
						{
							this._centerX = "";
						}
						break;
					case "_centery":
						if (((XmlAttribute)current).Value.ToString() != "##")
						{
							this._centerY = ((XmlAttribute)current).Value.ToString();
						}
						else
						{
							this._centerY = "";
						}
						break;
					case "colourvalue":
						if (((XmlAttribute)current).Value.ToString() != "##")
						{
							text = ((XmlAttribute)current).Value.ToString();
							switch (text)
							{
							case "red":
								this._colorfiltereff.FilterColor = Colors.Red;
								this.Grdcolorfilter.Effect = this._colorfiltereff;
								break;
							case "blue":
								this._colorfiltereff.FilterColor = Colors.Blue;
								this.Grdcolorfilter.Effect = this._colorfiltereff;
								break;
							case "green":
								this._colorfiltereff.FilterColor = Colors.Green;
								this.Grdcolorfilter.Effect = this._colorfiltereff;
								break;
							case "magenta":
								this._colorfiltereff.FilterColor = Colors.Magenta;
								this.Grdcolorfilter.Effect = this._colorfiltereff;
								break;
							case "lime":
							{
								Color filterColor = (Color)ColorConverter.ConvertFromString("#FFFFFF00");
								this._colorfiltereff.FilterColor = filterColor;
								this.Grdcolorfilter.Effect = this._colorfiltereff;
								break;
							}
							case "orange":
							{
								Color filterColor = (Color)ColorConverter.ConvertFromString("#FFFFA81D");
								this._colorfiltereff.FilterColor = filterColor;
								this.Grdcolorfilter.Effect = this._colorfiltereff;
								break;
							}
							case "yellow":
							{
								Color filterColor = (Color)ColorConverter.ConvertFromString("#FFFFFF96");
								this._colorfiltereff.FilterColor = filterColor;
								this.Grdcolorfilter.Effect = this._colorfiltereff;
								break;
							}
							case "skyblue":
							{
								Color filterColor = (Color)ColorConverter.ConvertFromString("#FF7CF5F5");
								this._colorfiltereff.FilterColor = filterColor;
								this.Grdcolorfilter.Effect = this._colorfiltereff;
								break;
							}
							case "lightred":
							{
								Color filterColor = (Color)ColorConverter.ConvertFromString("#FFFFCACB");
								this._colorfiltereff.FilterColor = filterColor;
								this.Grdcolorfilter.Effect = this._colorfiltereff;
								break;
							}
							}
						}
						else
						{
							this.Grdcolorfilter.Effect = null;
						}
						break;
					}
				}
				foreach (object current in xmlDocument.ChildNodes[0].FirstChild.Attributes)
				{
					string text = ((XmlAttribute)current).Name.ToLower();
					switch (text)
					{
					case "sharpen":
						if (((XmlAttribute)current).Value.ToString() != "##")
						{
							this._sharpen = Convert.ToDouble(((XmlAttribute)current).Value.ToString());
							this._sharpeff.Strength = this._sharpen;
							this._sharpeff.PixelWidth = 0.0015;
							this._sharpeff.PixelHeight = 0.0015;
							this._currentsharpen = this._sharpen;
							this.GrdSharpen.Effect = this._sharpeff;
						}
						else
						{
							this.GrdSharpen.Effect = null;
						}
						break;
					case "greyscale":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							GreyScaleEffect greyScaleEffect = new GreyScaleEffect();
							greyScaleEffect.Desaturation = Convert.ToDouble(((XmlAttribute)current).Value.ToString());
							greyScaleEffect.Toned = 0.0;
							this.GrdGreyScale.Effect = greyScaleEffect;
						}
						else
						{
							this.GrdGreyScale.Effect = null;
						}
						break;
					case "digimagic":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this._brighteff.Brightness = -0.05;
							this._brighteff.Contrast = 1.3;
							this.GrdBrightness.Effect = this._brighteff;
							this._bright = -0.05;
							this._cont = 1.3;
							this._sharpen = 0.05;
							this._sharpeff.Strength = this._sharpen;
							this._sharpeff.PixelWidth = 0.0015;
							this._sharpeff.PixelHeight = 0.0015;
							this.GrdSharpen.Effect = this._sharpeff;
							flag2 = true;
						}
						else if (!flag)
						{
							this.GrdBrightness.Effect = null;
						}
						break;
					case "sepia":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this._colorfiltereff.FilterColor = (Color)ColorConverter.ConvertFromString("#FFE6B34D");
							this.GrdSepia.Effect = this._colorfiltereff;
						}
						else
						{
							this.GrdSepia.Effect = null;
						}
						break;
					case "defog":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this._brighteff.Brightness = -0.1;
							this._brighteff.Contrast = 1.09;
							this.GrdBrightness.Effect = this._brighteff;
							this._bright = -0.1;
							this._cont = 1.09;
						}
						else if (!flag && !flag2)
						{
							this.GrdBrightness.Effect = null;
						}
						break;
					case "underwater":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							this._under.FogColor = (Color)ColorConverter.ConvertFromString("#FF4F9CEF");
							this._under.Defog = 0.4;
							this._under.Contrastr = 0.67;
							this._under.Contrastg = 1.0;
							this._under.Contrastb = 1.0;
							this._under.Exposure = 0.77;
							this._under.Gamma = 0.91;
							this.GrdUnderWater.Effect = this._under;
						}
						else
						{
							this.GrdUnderWater.Effect = null;
						}
						break;
					case "emboss":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							EmbossedEffect embossedEffect = new EmbossedEffect();
							embossedEffect.Amount = 0.7;
							embossedEffect.Width = 0.002;
							this.GrdEmboss.Effect = embossedEffect;
						}
						else
						{
							this.GrdEmboss.Effect = null;
						}
						break;
					case "invert":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							InvertColorEffect effect = new InvertColorEffect();
							this.GrdInvert.Effect = effect;
						}
						else
						{
							this.GrdInvert.Effect = null;
						}
						break;
					case "granite":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							SketchGraniteEffect sketchGraniteEffect = new SketchGraniteEffect();
							sketchGraniteEffect.BrushSize = 0.005;
							this.GrdSketchGranite.Effect = sketchGraniteEffect;
						}
						else
						{
							this.GrdSketchGranite.Effect = null;
						}
						break;
					case "hue":
						if (((XmlAttribute)current).Value.ToString() != "##")
						{
							this._hueshift = Convert.ToDouble(((XmlAttribute)current).Value.ToString());
							this._shifthueeff.HueShift = this._hueshift;
							this.GrdHueShift.Effect = this._shifthueeff;
							this._currenthueshift = this._hueshift;
						}
						else
						{
							this.GrdHueShift.Effect = null;
						}
						break;
					case "cartoon":
						if (((XmlAttribute)current).Value.ToString() != "0")
						{
							Cartoonize cartoonize = new Cartoonize();
							cartoonize.Width = 150.0;
							cartoonize.Height = 150.0;
							this.Grdcartoonize.Effect = cartoonize;
						}
						else
						{
							this.Grdcartoonize.Effect = null;
						}
						break;
					}
				}
				this._zoomTransform = new ScaleTransform();
				if (this._flipMode != 0 || this._flipModeY != 0)
				{
					this.FlipLoad();
				}
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
		}

		private void objCurrent_Loaded(object sender, RoutedEventArgs e)
		{
			if (7 != 0)
			{
				if (!false)
				{
					UIElement expr_09 = this.frm;
					double expr_2A = (this.dragCanvas.ActualWidth - this.frm.ActualWidth) / 2.0;
					if (!false)
					{
						Canvas.SetLeft(expr_09, expr_2A);
					}
				}
			}
			Canvas.SetTop(this.frm, (this.dragCanvas.ActualHeight - this.frm.ActualHeight) / 2.0);
		}

		private void LoadFromDB()
		{
			PhotoInfo photoInfo = null;
			try
			{
				if (!false)
				{
					this.graphicsTextBoxCount = 0;
					while (true)
					{
						if (4 != 0)
						{
							this.graphicsBorderApplied = false;
							this.graphicsCount = 0;
							this.graphicsframeApplied = false;
							photoInfo = new PhotoBusiness().GetPhotoDetailsbyPhotoId(this.photoId);
							if (photoInfo.DG_Photos_Layering != null)
							{
								break;
							}
						}
						if (3 != 0)
						{
							goto Block_6;
						}
					}
					this.GrdGreenScreenDefault3.RenderTransform = null;
					Canvas.SetLeft(this.GrdBrightness, 0.0);
					IL_89:
					Canvas.SetTop(this.GrdBrightness, 0.0);
					this.GrdBrightness.RenderTransform = null;
					this.grdZoomCanvas.RenderTransform = null;
					this.LoadXaml(photoInfo.DG_Photos_Layering);
					goto IL_C4;
					Block_6:
					this.forWdht.Width = this.widthimg.Source.Width;
					this.forWdht.Height = this.widthimg.Source.Height;
					this.GrdGreenScreenDefault3.RenderTransform = null;
					Canvas.SetLeft(this.GrdBrightness, 0.0);
					if (3 != 0)
					{
						Canvas.SetTop(this.GrdBrightness, 0.0);
						if (false)
						{
							goto IL_89;
						}
						this.GrdBrightness.RenderTransform = null;
						this.grdZoomCanvas.RenderTransform = null;
					}
				}
				IL_C4:;
			}
			catch (Exception serviceException)
			{
				do
				{
					string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
					ErrorHandler.ErrorHandler.LogFileWrite(message);
				}
				while (false);
			}
			finally
			{
			}
		}

		private void Zomout(bool orignal)
		{
			try
			{
				double num;
				double height;
				double num2;
				ScaleTransform scaleTransform=null;
				TransformGroup transformGroup=null;
				while (true)
				{
					UIElement expr_07 = this.grdZoomCanvas;
					if (7 != 0)
					{
						expr_07.UpdateLayout();
					}
					num = this.widthimg.Source.Width;
					height = this.widthimg.Source.Height;
					double arg_B4_0;
					double expr_4C = arg_B4_0 = num / 600.0;
					if (!true)
					{
						goto IL_B4;
					}
					num2 = expr_4C;
					double num3 = height / 600.0;
					num2 = 100.0 / num2 / 100.0;
					num3 = 100.0 / num3 / 100.0;
					bool arg_11C_0;
					int expr_9A = (arg_11C_0 = (this.frm.Children.Count == 1)) ? 1 : 0;
					int arg_11C_1;
					int expr_9D = arg_11C_1 = 0;
					if (expr_9D != 0)
					{
						goto IL_11C;
					}
					if (expr_9A != expr_9D)
					{
						arg_B4_0 = this.forWdht.Width;
						goto IL_B4;
					}
					goto IL_106;
					IL_14D:
					if (7 != 0)
					{
						break;
					}
					continue;
					IL_106:
					scaleTransform = new ScaleTransform();
					if (3 != 0)
					{
						transformGroup = new TransformGroup();
						arg_11C_0 = (height > num);
						goto IL_11B;
					}
					goto IL_14D;
					IL_11C:
					bool flag = (arg_11C_0 ? 1 : 0) == arg_11C_1;
					bool expr_120 = arg_11C_0 = flag;
					if (7 != 0)
					{
						if (!expr_120)
						{
							scaleTransform.ScaleX = num3 - 0.01;
							scaleTransform.ScaleY = num3 - 0.01;
							goto IL_14D;
						}
						goto IL_15B;
					}
					IL_11B:
					arg_11C_1 = 0;
					goto IL_11C;
					IL_B4:
					num = arg_B4_0;
					height = this.forWdht.Height;
					num2 = num / 600.0;
					num3 = height / 600.0;
					num2 = 100.0 / num2 / 100.0;
					num3 = 100.0 / num3 / 100.0;
					goto IL_106;
				}
				if (false)
				{
					goto IL_267;
				}
				IL_15B:
				if (height < num)
				{
					scaleTransform.ScaleX = num2 - 0.01;
					scaleTransform.ScaleY = num2 - 0.01;
				}
				scaleTransform.CenterX = this.forWdht.ActualWidth / 2.0;
				scaleTransform.CenterY = this.forWdht.ActualHeight / 2.0;
				transformGroup.Children.Add(scaleTransform);
				if (orignal)
				{
					this.MyInkCanvas.RenderTransform = null;
					this.grdZoomCanvas.LayoutTransform = transformGroup;
				}
				else
				{
					this.GrdGreenScreenDefault3.RenderTransform = null;
					this.MyInkCanvas.RenderTransform = transformGroup;
					this.MyInkCanvas.DefaultDrawingAttributes.StylusTipTransform = new Matrix(scaleTransform.ScaleX, 0.0, 0.0, scaleTransform.ScaleY, 0.0, 0.0);
				}
				IL_267:;
			}
			catch (Exception serviceException)
			{
				if (7 != 0)
				{
					string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
					ErrorHandler.ErrorHandler.LogFileWrite(message);
				}
			}
			finally
			{
				MemoryManagement.FlushMemory();
			}
		}

		private void FlipLoad()
		{
			do
			{
				try
				{
					while (true)
					{
						int arg_0D_0 = this._flipModeY;
						int arg_0D_1 = 0;
						while (arg_0D_0 == arg_0D_1)
						{
							int expr_24 = arg_0D_0 = this._flipMode;
							int expr_2A = arg_0D_1 = 1;
							if (expr_2A != 0)
							{
								bool flag = expr_24 != expr_2A;
								if (4 != 0)
								{
									if (!flag)
									{
										IL_45:
										this._zoomTransform.ScaleX = 1.0;
									}
									else
									{
										this._zoomTransform.ScaleX = 1.0;
										if (-1 != 0)
										{
										}
									}
									break;
									break;
								}
								goto IL_10A;
							}
						}
						this._zoomTransform.CenterX = Convert.ToDouble(this._centerX);
						this._zoomTransform.CenterY = Convert.ToDouble(this._centerY);
						this._transformGroup = new TransformGroup();
						this._transformGroup.Children.Add(this._zoomTransform);
						if (!false)
						{
							this._transformGroup.Children.Add(this._translateTransform);
							if (2 != 0)
							{
								break;
							}
							//goto IL_45;
						}
					}
					this._transformGroup.Children.Add(this._rotateTransform);
					IL_10A:;
				}
				catch (Exception serviceException)
				{
					string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
					ErrorHandler.ErrorHandler.LogFileWrite(message);
				}
			}
			while (8 == 0);
		}

		private void Rotate(int angle)
		{
			this.GrdBrightness.RenderTransformOrigin = new Point(0.5, 0.5);
			RotateTransform rotateTransform = new RotateTransform();
			int arg_3CA_0 = this.rotateangle;
			if (angle != -1)
			{
				rotateTransform.Angle = (double)angle;
				this.GrdBrightness.RenderTransform = rotateTransform;
				this.rotateangle = 360 - angle;
				if (this.rotateangle == 360)
				{
					this.rotateangle = 0;
				}
			}
			else
			{
				try
				{
					try
					{
						int num = this.rotateangle;
						if (num <= 90)
						{
							if (num != 0)
							{
								if (num == 90)
								{
									if (false)
									{
										goto IL_28A;
									}
									rotateTransform.Angle = 180.0;
									this.rotateangle = 180;
									if (6 == 0)
									{
										goto IL_237;
									}
								}
							}
							else
							{
								rotateTransform.Angle = 90.0;
								this.rotateangle = 90;
							}
						}
						else
						{
							while (num == 180)
							{
								rotateTransform.Angle = 270.0;
								if (!false)
								{
									this.rotateangle = 270;
									goto IL_156;
								}
							}
							if (num == 270)
							{
								rotateTransform.Angle = 360.0;
								if (8 == 0)
								{
									goto IL_2A2;
								}
								this.rotateangle = 0;
							}
						}
						IL_156:
						this.GrdBrightness.RenderTransform = rotateTransform;
						int arg_1A3_0;
						if (rotateTransform.Angle / 90.0 != 1.0)
						{
							bool expr_197 = (arg_1A3_0 = ((rotateTransform.Angle / 90.0 == 3.0) ? 1 : 0)) != 0;
							if (4 != 0)
							{
								arg_1A3_0 = ((!expr_197) ? 1 : 0);
							}
						}
						else
						{
							arg_1A3_0 = 0;
						}
						double actualWidth;
						double actualHeight;
						if (arg_1A3_0 != 0)
						{
							this.GrdBrightness.Margin = new Thickness(0.0, 0.0, 0.0, 0.0);
							if (8 != 0)
							{
								actualWidth = this.forWdht.ActualWidth;
								actualHeight = this.forWdht.ActualHeight;
								this.forWdht.Width = actualHeight;
								this.forWdht.Height = actualWidth;
								this.forWdht.RenderSize = new Size(actualHeight, actualWidth);
								this.dragCanvas.RenderSize = new Size(actualHeight, actualWidth);
							}
							this.canbackground.RenderSize = new Size(actualHeight, actualWidth);
							this.forWdht.InvalidateArrange();
							this.forWdht.InvalidateMeasure();
							this.forWdht.InvalidateVisual();
							goto IL_371;
						}
						this.GrdBrightness.Margin = new Thickness(-(this.forWdht.Width - this.forWdht.Height) / 2.0, (this.forWdht.Width - this.forWdht.Height) / 2.0, 0.0, 0.0);
						actualWidth = this.forWdht.ActualWidth;
						actualHeight = this.forWdht.ActualHeight;
						this.forWdht.Width = actualHeight;
						IL_237:
						this.forWdht.Height = actualWidth;
						this.forWdht.RenderSize = new Size(actualHeight, actualWidth);
						this.dragCanvas.RenderSize = new Size(actualHeight, actualWidth);
						this.canbackground.RenderSize = new Size(actualHeight, actualWidth);
						this.forWdht.InvalidateArrange();
						IL_28A:
						this.forWdht.InvalidateMeasure();
						this.forWdht.InvalidateVisual();
						IL_2A2:
						IL_371:;
					}
					catch (Exception serviceException)
					{
						if (8 != 0)
						{
							string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
							ErrorHandler.ErrorHandler.LogFileWrite(message);
						}
					}
					while (4 == 0)
					{
					}
				}
				finally
				{
				}
			}
		}

		public RenderTargetBitmap jCaptureScreen()
		{
			double num;
			double num2;
			RenderTargetBitmap renderTargetBitmap;
			if (4 != 0)
			{
				base.InvalidateVisual();
				BitmapImage expr_21 = this.mainImage.Source as BitmapImage;
				BitmapImage bitmapImage;
				if (!false)
				{
					bitmapImage = expr_21;
				}
				do
				{
					double expr_2D = 0.0;
					if (!false)
					{
						num = expr_2D;
					}
					num2 = 0.0;
					bool flag = new ConfigBusiness().GetConfigCompression(LoginUser.SubStoreId).ToBoolean(false);
					if (!flag)
					{
						goto IL_8E;
					}
					double arg_7A_0 = 96.0;
					double expr_7B;
					do
					{
						num = arg_7A_0;
						expr_7B = (arg_7A_0 = 96.0);
					}
					while (-1 == 0);
					num2 = expr_7B;
				}
				while (7 == 0);
				goto IL_9E;
				IL_8E:
				num = bitmapImage.DpiX;
				num2 = bitmapImage.DpiY;
				IL_9E:
				renderTargetBitmap = null;
				RenderOptions.SetBitmapScalingMode(this.forWdht, BitmapScalingMode.HighQuality);
				RenderOptions.SetEdgeMode(this.forWdht, EdgeMode.Aliased);
			}
			RenderTargetBitmap result;
			try
			{
				if (8 != 0)
				{
					Size size;
					if (this._zoomFactor > 1.0)
					{
						size = new Size(this.forWdht.Width, this.forWdht.Height);
						if (3 == 0)
						{
							goto IL_287;
						}
						renderTargetBitmap = new RenderTargetBitmap((int)(size.Width * num / 96.0 * (1.0 / this._zoomFactor)), (int)(size.Height * num2 / 96.0 * (1.0 / this._zoomFactor)), num, num2, PixelFormats.Default);
						RenderOptions.SetEdgeMode(this.forWdht, EdgeMode.Aliased);
						this.forWdht.SnapsToDevicePixels = true;
						this.forWdht.RenderTransform = new ScaleTransform(1.0 / this._zoomFactor, 1.0 / this._zoomFactor, 0.5, 0.5);
						this.forWdht.Measure(size);
						this.forWdht.Arrange(new Rect(size));
						renderTargetBitmap.Render(this.forWdht);
						if (renderTargetBitmap.CanFreeze)
						{
							goto IL_1F8;
						}
						goto IL_202;
					}
					else
					{
						size = new Size(this.forWdht.Width, this.forWdht.Height);
						int arg_266_0 = (int)(size.Width * num2 / 96.0);
						double arg_25E_0;
						double expr_24A = arg_25E_0 = size.Height;
						if (3 != 0)
						{
							arg_25E_0 = expr_24A * num2 / 96.0;
						}
						renderTargetBitmap = new RenderTargetBitmap(arg_266_0, (int)arg_25E_0, num, num2, PixelFormats.Default);
						RenderOptions.SetEdgeMode(this.forWdht, EdgeMode.Aliased);
					}
					IL_279:
					this.forWdht.SnapsToDevicePixels = true;
					IL_287:
					this.forWdht.RenderTransform = new ScaleTransform(1.0, 1.0, 0.5, 0.5);
					this.forWdht.Measure(size);
					this.forWdht.Arrange(new Rect(size));
					renderTargetBitmap.Render(this.forWdht);
					if (renderTargetBitmap.CanFreeze)
					{
						renderTargetBitmap.Freeze();
					}
					this.forWdht.RenderTransform = null;
					if (!false)
					{
						goto IL_319;
					}
					goto IL_279;
				}
				IL_1F8:
				renderTargetBitmap.Freeze();
				IL_202:
				this.forWdht.RenderTransform = null;
				IL_319:
				result = renderTargetBitmap;
			}
			catch (Exception var_6_322)
			{
				Rect descendantBounds = VisualTreeHelper.GetDescendantBounds(this.GrdBrightness);
				DrawingVisual drawingVisual = new DrawingVisual();
				renderTargetBitmap = new RenderTargetBitmap((int)(descendantBounds.Width * num / 96.0), (int)(descendantBounds.Height * num2 / 96.0), num, num2, PixelFormats.Default);
				do
				{
					using (DrawingContext drawingContext = drawingVisual.RenderOpen())
					{
						VisualBrush brush = new VisualBrush(this.forWdht);
						drawingContext.DrawRectangle(brush, null, new Rect(default(Point), descendantBounds.Size));
					}
					renderTargetBitmap.Render(drawingVisual);
				}
				while (6 == 0);
				result = renderTargetBitmap;
			}
			return result;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Rect expr_31 = SystemParameters.WorkArea;
			Rect rect;
			if (!false)
			{
				rect = expr_31;
			}
			base.Left = rect.Right - base.Width;
			base.Top = rect.Bottom - base.Height;
			base.Topmost = false;
		}

	}
}
