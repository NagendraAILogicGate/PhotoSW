using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
{
    public class Cartoonize : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(Cartoonize), 0);

        public static readonly DependencyProperty WidthProperty = DependencyProperty.Register("Width", typeof(double), typeof(Cartoonize), new UIPropertyMetadata(500.0, ShaderEffect.PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty HeightProperty = DependencyProperty.Register("Height", typeof(double), typeof(Cartoonize), new UIPropertyMetadata(300.0, ShaderEffect.PixelShaderConstantCallback(1)));

        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(Cartoonize.InputProperty);
            }
            set
            {
                base.SetValue(Cartoonize.InputProperty, value);
            }
        }

        public double Width
        {
            get
            {
                return (double)base.GetValue(Cartoonize.WidthProperty);
            }
            set
            {
                base.SetValue(Cartoonize.WidthProperty, value);
            }
        }

        public double Height
        {
            get
            {
                return (double)base.GetValue(Cartoonize.HeightProperty);
            }
            set
            {
                base.SetValue(Cartoonize.HeightProperty, value);
            }
        }

        public Cartoonize()
        {
            base.PixelShader = new PixelShader
            {
                UriSource = new Uri("/Shader/Cartoonize.ps", UriKind.Relative)
            };
            base.UpdateShaderValue(Cartoonize.InputProperty);
            base.UpdateShaderValue(Cartoonize.WidthProperty);
            base.UpdateShaderValue(Cartoonize.HeightProperty);
        }
    }
}
