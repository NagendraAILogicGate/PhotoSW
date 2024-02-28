using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace PhotoSW.Shader
{
    public class ContrastAdjustEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ContrastAdjustEffect), 0);

        public static readonly DependencyProperty BrightnessProperty = DependencyProperty.Register("Brightness", typeof(double), typeof(ContrastAdjustEffect), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty ContrastProperty = DependencyProperty.Register("Contrast", typeof(double), typeof(ContrastAdjustEffect), new UIPropertyMetadata(1.5, ShaderEffect.PixelShaderConstantCallback(1)));

        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(ContrastAdjustEffect.InputProperty);
            }
            set
            {
                base.SetValue(ContrastAdjustEffect.InputProperty, value);
            }
        }

        public double Brightness
        {
            get
            {
                return (double)base.GetValue(ContrastAdjustEffect.BrightnessProperty);
            }
            set
            {
                base.SetValue(ContrastAdjustEffect.BrightnessProperty, value);
            }
        }

        public double Contrast
        {
            get
            {
                return (double)base.GetValue(ContrastAdjustEffect.ContrastProperty);
            }
            set
            {
                base.SetValue(ContrastAdjustEffect.ContrastProperty, value);
            }
        }

        public BitmapImage CurrentImage
        {
            get;
            set;
        }

        public ContrastAdjustEffect()
        {//string str ="pack://application:,,,/PhotoSW;component/Shader/brght.ps";
            base.PixelShader = new PixelShader
            {
                //UriSource = new Uri(str)
                UriSource = PhotoSW.ViewModels.Global.MakePackUri("Shader/brght.ps")
               // UriSource = new Uri(@"pack://application:,,,/PhotoSW;component/Shader/brght.ps") 
               // UriSource = new Uri("/PhotoSW;component/Shader/brght.ps", UriKind.Relative)
            };
            base.UpdateShaderValue(ContrastAdjustEffect.InputProperty);
            base.UpdateShaderValue(ContrastAdjustEffect.BrightnessProperty);
            base.UpdateShaderValue(ContrastAdjustEffect.ContrastProperty);
        }

        //////

       


        ///////////


    }
}
