using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
{
    public class MonochromeEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(MonochromeEffect), 0);

        public static readonly DependencyProperty FilterColorProperty = DependencyProperty.Register("FilterColor", typeof(Color), typeof(MonochromeEffect), new UIPropertyMetadata(Color.FromArgb(255, 255, 255, 0), ShaderEffect.PixelShaderConstantCallback(0)));

        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(MonochromeEffect.InputProperty);
            }
            set
            {
                base.SetValue(MonochromeEffect.InputProperty, value);
            }
        }

        public Color FilterColor
        {
            get
            {
                return (Color)base.GetValue(MonochromeEffect.FilterColorProperty);
            }
            set
            {
                base.SetValue(MonochromeEffect.FilterColorProperty, value);
            }
        }

        public MonochromeEffect()
        {
            string str = "pack://application:,,,/PhotoSW;component/Shader/monochrome.ps";
            base.PixelShader = new PixelShader
            {
                //UriSource = new Uri(str, UriKind.Relative)
                //UriSource = new Uri("/PhotoSW;component/Shader/Monochrome.ps", UriKind.Relative)
                UriSource = PhotoSW.ViewModels.Global.MakePackUri("Shader/Monochrome.ps")
            };
            base.UpdateShaderValue(MonochromeEffect.InputProperty);
            base.UpdateShaderValue(MonochromeEffect.FilterColorProperty);
        }
    }
}
