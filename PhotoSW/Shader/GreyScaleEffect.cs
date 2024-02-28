using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
{
    public class GreyScaleEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty;

        public static readonly DependencyProperty DesaturationProperty;

        public static readonly DependencyProperty TonedProperty;

        public static readonly DependencyProperty LightColorProperty;

        public static readonly DependencyProperty DarkColorProperty;

        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(GreyScaleEffect.InputProperty);
            }
            set
            {
                base.SetValue(GreyScaleEffect.InputProperty, value);
            }
        }

        public double Desaturation
        {
            get
            {
                return (double)base.GetValue(GreyScaleEffect.DesaturationProperty);
            }
            set
            {
                base.SetValue(GreyScaleEffect.DesaturationProperty, value);
            }
        }

        public double Toned
        {
            get
            {
                return (double)base.GetValue(GreyScaleEffect.TonedProperty);
            }
            set
            {
                base.SetValue(GreyScaleEffect.TonedProperty, value);
            }
        }

        public Color LightColor
        {
            get
            {
                return (Color)base.GetValue(GreyScaleEffect.LightColorProperty);
            }
            set
            {
                base.SetValue(GreyScaleEffect.LightColorProperty, value);
            }
        }

        public Color DarkColor
        {
            get
            {
                return (Color)base.GetValue(GreyScaleEffect.DarkColorProperty);
            }
            set
            {
                base.SetValue(GreyScaleEffect.DarkColorProperty, value);
            }
        }

        public GreyScaleEffect()
        {
            base.PixelShader = new PixelShader
            {
                UriSource = new Uri("/PhotoSW;component/Shader/ColorTone.ps", UriKind.Relative)
            };
            base.UpdateShaderValue(GreyScaleEffect.InputProperty);
            base.UpdateShaderValue(GreyScaleEffect.DesaturationProperty);
            base.UpdateShaderValue(GreyScaleEffect.TonedProperty);
            base.UpdateShaderValue(GreyScaleEffect.LightColorProperty);
            base.UpdateShaderValue(GreyScaleEffect.DarkColorProperty);
        }

        static GreyScaleEffect()
        {
            // Note: this type is marked as 'beforefieldinit'.
            if (true)
            {
                GreyScaleEffect.InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(GreyScaleEffect), 0);
                GreyScaleEffect.DesaturationProperty = DependencyProperty.Register("Desaturation", typeof(double), typeof(GreyScaleEffect), new UIPropertyMetadata(0.5, ShaderEffect.PixelShaderConstantCallback(0)));
                GreyScaleEffect.TonedProperty = DependencyProperty.Register("Toned", typeof(double), typeof(GreyScaleEffect), new UIPropertyMetadata(0.5, ShaderEffect.PixelShaderConstantCallback(1)));
                GreyScaleEffect.LightColorProperty = DependencyProperty.Register("LightColor", typeof(Color), typeof(GreyScaleEffect), new UIPropertyMetadata(Color.FromArgb(255, 255, 255, 0), ShaderEffect.PixelShaderConstantCallback(2)));
            }
            GreyScaleEffect.DarkColorProperty = DependencyProperty.Register("DarkColor", typeof(Color), typeof(GreyScaleEffect), new UIPropertyMetadata(Color.FromArgb(255, 0, 0, 128), ShaderEffect.PixelShaderConstantCallback(3)));
        }
    }
}
