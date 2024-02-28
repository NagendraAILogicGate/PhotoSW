using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
{
    public class SharpenEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(SharpenEffect), 0);

        public static readonly DependencyProperty AmountProperty = DependencyProperty.Register("Amount", typeof(double), typeof(SharpenEffect), new UIPropertyMetadata(1.0, ShaderEffect.PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty InputSizeProperty = DependencyProperty.Register("InputSize", typeof(Size), typeof(SharpenEffect), new UIPropertyMetadata(new Size(800.0, 600.0), ShaderEffect.PixelShaderConstantCallback(1)));

        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(SharpenEffect.InputProperty);
            }
            set
            {
                base.SetValue(SharpenEffect.InputProperty, value);
            }
        }

        public double Amount
        {
            get
            {
                return (double)base.GetValue(SharpenEffect.AmountProperty);
            }
            set
            {
                base.SetValue(SharpenEffect.AmountProperty, value);
            }
        }

        public Size InputSize
        {
            get
            {
                return (Size)base.GetValue(SharpenEffect.InputSizeProperty);
            }
            set
            {
                base.SetValue(SharpenEffect.InputSizeProperty, value);
            }
        }

        public SharpenEffect()
        {
            base.PixelShader = new PixelShader
            {
                UriSource = new Uri("/PhotoSW;component/Shader/Sharpen.ps", UriKind.Relative)
            };
            base.UpdateShaderValue(SharpenEffect.InputProperty);
            base.UpdateShaderValue(SharpenEffect.AmountProperty);
            base.UpdateShaderValue(SharpenEffect.InputSizeProperty);
        }
    }
}
