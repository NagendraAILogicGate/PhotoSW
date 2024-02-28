using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
{
    public class MultiChannelContrastEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(MultiChannelContrastEffect), 0);

        public static readonly DependencyProperty BrightnessProperty;

        public static readonly DependencyProperty ContrastrProperty;

        public static readonly DependencyProperty ContrastgProperty;

        public static readonly DependencyProperty ContrastbProperty;

        public static readonly DependencyProperty DefogProperty;

        public static readonly DependencyProperty FogColorProperty;

        public static readonly DependencyProperty ExposureProperty;

        public static readonly DependencyProperty GammaProperty;

        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(MultiChannelContrastEffect.InputProperty);
            }
            set
            {
                base.SetValue(MultiChannelContrastEffect.InputProperty, value);
            }
        }

        public double Brightness
        {
            get
            {
                return (double)base.GetValue(MultiChannelContrastEffect.BrightnessProperty);
            }
            set
            {
                base.SetValue(MultiChannelContrastEffect.BrightnessProperty, value);
            }
        }

        public double Contrastr
        {
            get
            {
                return (double)base.GetValue(MultiChannelContrastEffect.ContrastrProperty);
            }
            set
            {
                base.SetValue(MultiChannelContrastEffect.ContrastrProperty, value);
            }
        }

        public double Contrastg
        {
            get
            {
                return (double)base.GetValue(MultiChannelContrastEffect.ContrastgProperty);
            }
            set
            {
                base.SetValue(MultiChannelContrastEffect.ContrastgProperty, value);
            }
        }

        public double Contrastb
        {
            get
            {
                return (double)base.GetValue(MultiChannelContrastEffect.ContrastbProperty);
            }
            set
            {
                base.SetValue(MultiChannelContrastEffect.ContrastbProperty, value);
            }
        }

        public double Defog
        {
            get
            {
                return (double)base.GetValue(MultiChannelContrastEffect.DefogProperty);
            }
            set
            {
                base.SetValue(MultiChannelContrastEffect.DefogProperty, value);
            }
        }

        public Color FogColor
        {
            get
            {
                return (Color)base.GetValue(MultiChannelContrastEffect.FogColorProperty);
            }
            set
            {
                base.SetValue(MultiChannelContrastEffect.FogColorProperty, value);
            }
        }

        public double Exposure
        {
            get
            {
                return (double)base.GetValue(MultiChannelContrastEffect.ExposureProperty);
            }
            set
            {
                base.SetValue(MultiChannelContrastEffect.ExposureProperty, value);
            }
        }

        public double Gamma
        {
            get
            {
                return (double)base.GetValue(MultiChannelContrastEffect.GammaProperty);
            }
            set
            {
                base.SetValue(MultiChannelContrastEffect.GammaProperty, value);
            }
        }

        public MultiChannelContrastEffect()
        {
            base.PixelShader = new PixelShader
            {
                UriSource = new Uri("/Shader/multi.ps", UriKind.Relative)
            };
            base.UpdateShaderValue(MultiChannelContrastEffect.InputProperty);
            base.UpdateShaderValue(MultiChannelContrastEffect.BrightnessProperty);
            base.UpdateShaderValue(MultiChannelContrastEffect.ContrastrProperty);
            base.UpdateShaderValue(MultiChannelContrastEffect.ContrastgProperty);
            base.UpdateShaderValue(MultiChannelContrastEffect.ContrastbProperty);
            base.UpdateShaderValue(MultiChannelContrastEffect.DefogProperty);
            base.UpdateShaderValue(MultiChannelContrastEffect.FogColorProperty);
            base.UpdateShaderValue(MultiChannelContrastEffect.ExposureProperty);
            base.UpdateShaderValue(MultiChannelContrastEffect.GammaProperty);
        }

        static MultiChannelContrastEffect()
        {
            // Note: this type is marked as 'beforefieldinit'.
            do
            {
                MultiChannelContrastEffect.BrightnessProperty = DependencyProperty.Register("Brightness", typeof(double), typeof(MultiChannelContrastEffect), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(0)));
                MultiChannelContrastEffect.ContrastrProperty = DependencyProperty.Register("Contrastr", typeof(double), typeof(MultiChannelContrastEffect), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(1)));
                MultiChannelContrastEffect.ContrastgProperty = DependencyProperty.Register("Contrastg", typeof(double), typeof(MultiChannelContrastEffect), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(2)));
                MultiChannelContrastEffect.ContrastbProperty = DependencyProperty.Register("Contrastb", typeof(double), typeof(MultiChannelContrastEffect), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(3)));
                MultiChannelContrastEffect.DefogProperty = DependencyProperty.Register("Defog", typeof(double), typeof(MultiChannelContrastEffect), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(4)));
            }
            while (3 == 0);
            MultiChannelContrastEffect.FogColorProperty = DependencyProperty.Register("FogColor", typeof(Color), typeof(MultiChannelContrastEffect), new UIPropertyMetadata(Color.FromArgb(255, 255, 255, 255), ShaderEffect.PixelShaderConstantCallback(5)));
            MultiChannelContrastEffect.ExposureProperty = DependencyProperty.Register("Exposure", typeof(double), typeof(MultiChannelContrastEffect), new UIPropertyMetadata(0.2, ShaderEffect.PixelShaderConstantCallback(6)));
            MultiChannelContrastEffect.GammaProperty = DependencyProperty.Register("Gamma", typeof(double), typeof(MultiChannelContrastEffect), new UIPropertyMetadata(0.8, ShaderEffect.PixelShaderConstantCallback(7)));
        }
    }
}
