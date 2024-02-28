using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
{
    public class EmbossedEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(EmbossedEffect), 0);

        public static readonly DependencyProperty AmountProperty = DependencyProperty.Register("Amount", typeof(double), typeof(EmbossedEffect), new UIPropertyMetadata(0.5, ShaderEffect.PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty WidthProperty = DependencyProperty.Register("Width", typeof(double), typeof(EmbossedEffect), new UIPropertyMetadata(0.003, ShaderEffect.PixelShaderConstantCallback(1)));

        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(EmbossedEffect.InputProperty);
            }
            set
            {
                base.SetValue(EmbossedEffect.InputProperty, value);
            }
        }

        public double Amount
        {
            get
            {
                return (double)base.GetValue(EmbossedEffect.AmountProperty);
            }
            set
            {
                base.SetValue(EmbossedEffect.AmountProperty, value);
            }
        }

        public double Width
        {
            get
            {
                return (double)base.GetValue(EmbossedEffect.WidthProperty);
            }
            set
            {
                base.SetValue(EmbossedEffect.WidthProperty, value);
            }
        }

        public EmbossedEffect()
        {
            base.PixelShader = new PixelShader
            {
                UriSource = new Uri("/PhotoSW;component/Shader/Embossed.ps", UriKind.Relative)
            };
            base.UpdateShaderValue(EmbossedEffect.InputProperty);
            base.UpdateShaderValue(EmbossedEffect.AmountProperty);
            base.UpdateShaderValue(EmbossedEffect.WidthProperty);
        }
    }
}
