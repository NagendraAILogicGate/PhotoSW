using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
{
    public class ShiftHueEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty;

        public static readonly DependencyProperty HueShiftProperty;

        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(ShiftHueEffect.InputProperty);
            }
            set
            {
                base.SetValue(ShiftHueEffect.InputProperty, value);
            }
        }

        public double HueShift
        {
            get
            {
                return (double)base.GetValue(ShiftHueEffect.HueShiftProperty);
            }
            set
            {
                base.SetValue(ShiftHueEffect.HueShiftProperty, value);
            }
        } 

        public ShiftHueEffect()
        {
            base.PixelShader = new PixelShader
            {
                UriSource = new Uri("/PhotoSW;component/Shader/ShiftHue.ps", UriKind.Relative)
            };
            base.UpdateShaderValue(ShiftHueEffect.InputProperty);
            base.UpdateShaderValue(ShiftHueEffect.HueShiftProperty);
        }

        static ShiftHueEffect()
        {
            // Note: this type is marked as 'beforefieldinit'.
            do
            {
                if (true)
                {
                    ShiftHueEffect.InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ShiftHueEffect), 0);
                    if (7 == 0)
                    {
                        continue;
                    }
                    if (!false)
                    {
                        ShiftHueEffect.HueShiftProperty = DependencyProperty.Register("HueShift", typeof(double), typeof(ShiftHueEffect), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(0)));
                    }
                }
            }
            while (false);
        }
    }
}
