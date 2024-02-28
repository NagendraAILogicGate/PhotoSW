namespace PhotoSW.Shader
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Effects;

    internal class BloomEffect : ShaderEffect
    {
        //public static readonly DependencyProperty BaseIntensityProperty;
        //public static readonly DependencyProperty BaseSaturationProperty;
        //public static readonly DependencyProperty BloomIntensityProperty;
        //public static readonly DependencyProperty BloomSaturationProperty;
        //public static readonly DependencyProperty InputProperty;

        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(BloomEffect), 0);

        public static readonly DependencyProperty BaseIntensityProperty = DependencyProperty.Register("BaseIntensity", typeof(double), typeof(BloomEffect), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty BaseSaturationProperty = DependencyProperty.Register("BaseSaturation", typeof(double), typeof(BloomEffect), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty BloomIntensityProperty = DependencyProperty.Register("BloomIntensity", typeof(double), typeof(BloomEffect), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(2)));

        public static readonly DependencyProperty BloomSaturationProperty = DependencyProperty.Register("BloomSaturation", typeof(double), typeof(BloomEffect), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(3)));
        static BloomEffect()
        {
            // This item is obfuscated and can not be translated.
        }

        public BloomEffect()
        {
            PixelShader shader = new PixelShader {
                // UriSource = new Uri("/Shader/Bloom.ps", UriKind.Relative)
                UriSource = new Uri("/PhotoSW;component/Shader/Bloom.ps", UriKind.Relative)
                };
            base.PixelShader = shader;
            base.UpdateShaderValue(InputProperty);
            base.UpdateShaderValue(BloomIntensityProperty);
            base.UpdateShaderValue(BaseIntensityProperty);
            base.UpdateShaderValue(BloomSaturationProperty);
            base.UpdateShaderValue(BaseSaturationProperty);

            }

        public double BaseIntensity
            {

            get
                {
                return (double)base.GetValue(BloomEffect.BaseIntensityProperty);
                }
            set
                {
                base.SetValue(BloomEffect.BaseIntensityProperty, value);
                }
            }

        public double BaseSaturation
            {
            get
                {
                return (double)base.GetValue(BloomEffect.BloomSaturationProperty);
                }
            set
                {
                base.SetValue(BloomEffect.BloomSaturationProperty, value);
                }
            }

        public double BloomIntensity
            {
            get
                {
                return (double)base.GetValue(BloomEffect.BloomIntensityProperty);
                }
            set
                {
                base.SetValue(BloomEffect.BloomIntensityProperty, value);
                }
            }

        public double BloomSaturation
            {

            get
                {
                return (double)base.GetValue(BloomEffect.BloomSaturationProperty);
                }
            set
                {
                base.SetValue(BloomEffect.BloomSaturationProperty, value);
                }
            }

        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(BloomEffect.InputProperty);
            }
            set
            {
                base.SetValue(BloomEffect.InputProperty, value);
            }
        }  
    }
}

