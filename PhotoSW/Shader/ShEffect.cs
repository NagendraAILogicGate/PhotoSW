using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
{
    public class ShEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty;

        public static readonly DependencyProperty StrengthProperty;

        public static readonly DependencyProperty PixelWidthProperty;

        public static readonly DependencyProperty PixelHeightProperty;

        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(ShEffect.InputProperty);
            }
            set
            {
                base.SetValue(ShEffect.InputProperty, value);
            }
        }

        public double Strength
        {
            get
            {
                return (double)base.GetValue(ShEffect.StrengthProperty);
            }
            set
            {
                base.SetValue(ShEffect.StrengthProperty, value);
            }
        }

        public double PixelWidth
        {
            get
            {
                return (double)base.GetValue(ShEffect.PixelWidthProperty);
            }
            set
            {
                base.SetValue(ShEffect.PixelWidthProperty, value);
            }
        }

        public double PixelHeight
        {
            get
            {
                return (double)base.GetValue(ShEffect.PixelHeightProperty);
            }
            set
            {
                base.SetValue(ShEffect.PixelHeightProperty, value);
            }
        }

        public ShEffect()
        {
            base.PixelShader = new PixelShader
            {
                UriSource = new Uri("/Shader/sh.ps", UriKind.Relative)
            };
            base.UpdateShaderValue(ShEffect.InputProperty);
            base.UpdateShaderValue(ShEffect.StrengthProperty);
            base.UpdateShaderValue(ShEffect.PixelWidthProperty);
            base.UpdateShaderValue(ShEffect.PixelHeightProperty);
        }

        static ShEffect()
        {
            // Note: this type is marked as 'beforefieldinit'.
            if (!false)
            {
                ShEffect.InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ShEffect), 0);
                ShEffect.StrengthProperty = DependencyProperty.Register("Strength", typeof(double), typeof(ShEffect), new PropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(0)));
            }
            if (5 != 0)
            {
                ShEffect.PixelWidthProperty = DependencyProperty.Register("PixelWidth", typeof(double), typeof(ShEffect), new PropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(1)));
                ShEffect.PixelHeightProperty = DependencyProperty.Register("PixelHeight", typeof(double), typeof(ShEffect), new PropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(2)));
            }
        }
    }
}
