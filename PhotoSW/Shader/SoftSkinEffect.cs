using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
    {
    public class SoftSkinEffect : ShaderEffect
        {
            public static readonly DependencyProperty InputProperty;

            public static readonly DependencyProperty SoftSkinProperty;

            public Brush Input
                {
                get
                    {
                    return (Brush)base.GetValue(SoftSkinEffect.InputProperty);
                    }
                set
                    {
                    base.SetValue(SoftSkinEffect.InputProperty, value);
                    }
                }
        public double SoftSkin
            {
            get
                {
                return (double)base.GetValue(SoftSkinEffect.SoftSkinProperty);
                }
            set
                {
                base.SetValue(SoftSkinEffect.SoftSkinProperty, value);
                }
            }

        public SoftSkinEffect ()
            {
            base.PixelShader = new PixelShader
                {
                UriSource = new Uri("/PhotoSW;component/Shader/SoftSkin.ps", UriKind.Relative)
                };
            base.UpdateShaderValue(SoftSkinEffect.InputProperty);
            base.UpdateShaderValue(SoftSkinEffect.SoftSkinProperty);
            }

        static SoftSkinEffect ()
            {
            // Note: this type is marked as 'beforefieldinit'.
            do
                {
                if(true)
                    {
                    SoftSkinEffect.InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(SoftSkinEffect), 0);
                    if(7 == 0)
                        {
                        continue;
                        }
                    if(!false)
                        {
                        SoftSkinEffect.SoftSkinProperty = DependencyProperty.Register("SoftSkin", typeof(double), typeof(SoftSkinEffect), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(0)));
                        }
                    }
                }
            while(false);
            }

        }
    }
