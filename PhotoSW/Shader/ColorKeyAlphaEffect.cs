using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
{
    public class ColorKeyAlphaEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ColorKeyAlphaEffect), 0);

        public static readonly DependencyProperty ColorKeyProperty = DependencyProperty.Register("ColorKey", typeof(Color), typeof(ColorKeyAlphaEffect), new UIPropertyMetadata(Color.FromArgb(255, 0, 128, 0), ShaderEffect.PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty ToleranceProperty = DependencyProperty.Register("Tolerance", typeof(double), typeof(ColorKeyAlphaEffect), new UIPropertyMetadata(0.3, ShaderEffect.PixelShaderConstantCallback(1)));

        private static string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private static string xslLocation = Path.Combine(ColorKeyAlphaEffect.executableLocation, "Shader\\ColorKeyAlphaEffect.ps");

        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(ColorKeyAlphaEffect.InputProperty);
            }
            set
            {
                base.SetValue(ColorKeyAlphaEffect.InputProperty, value);
            }
        }

        public Color ColorKey
        {
            get
            {
                return (Color)base.GetValue(ColorKeyAlphaEffect.ColorKeyProperty);
            }
            set
            {
                base.SetValue(ColorKeyAlphaEffect.ColorKeyProperty, value);
            }
        }

        public double Tolerance
        {
            get
            {
                return (double)base.GetValue(ColorKeyAlphaEffect.ToleranceProperty);
            }
            set
            {
                base.SetValue(ColorKeyAlphaEffect.ToleranceProperty, value);
            }
        }

        public ColorKeyAlphaEffect()
        {
            base.PixelShader = new PixelShader
            {
                //UriSource = new Uri(ColorKeyAlphaEffect.xslLocation)
                UriSource = new Uri("/PhotoSW;component/Shader/ColorKeyAlphaEffect.ps", UriKind.Relative)
            };
            base.UpdateShaderValue(ColorKeyAlphaEffect.InputProperty);
            base.UpdateShaderValue(ColorKeyAlphaEffect.ColorKeyProperty);
            base.UpdateShaderValue(ColorKeyAlphaEffect.ToleranceProperty);
        }
    }
}
