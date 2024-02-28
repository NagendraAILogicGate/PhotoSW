using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
{
    public class ChromaKeyHSVEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ChromaKeyHSVEffect), 0);

        public static readonly DependencyProperty HueMinProperty = DependencyProperty.Register("HueMin", typeof(double), typeof(ChromaKeyHSVEffect), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty HueMaxProperty = DependencyProperty.Register("HueMax", typeof(double), typeof(ChromaKeyHSVEffect), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty SaturationShiftProperty = DependencyProperty.Register("SaturationShift", typeof(double), typeof(ChromaKeyHSVEffect), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(2)));

        public static readonly DependencyProperty LightnessShiftProperty = DependencyProperty.Register("LightnessShift", typeof(double), typeof(ChromaKeyHSVEffect), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(3)));

     
        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(ChromaKeyHSVEffect.InputProperty);
            }
            set
            {
                base.SetValue(ChromaKeyHSVEffect.InputProperty, value);
            }
        }

        public double HueMin
        {
            get
            {
                if (!true)
                {
                    goto IL_24;
                }
                if (!false)
                {
                }
            IL_07:
                double result;
                if (3 != 0)
                {
                    result = (double)base.GetValue(ChromaKeyHSVEffect.HueMinProperty) + 0.9;
                  //  result = (double)base.GetValue(ChromaKeyHSVEffect.HueMinProperty) + 0.1;
                    }
            IL_24:
                if (8 != 0)
                {
                    return result;
                }
                goto IL_07;
            }
            set
            {
                base.SetValue(ChromaKeyHSVEffect.HueMinProperty, value);
            }
        }

        public double HueMax
        {
            get
            {
                if (!true)
                {
                    goto IL_24;
                }
                if (!false)
                {
                }
            IL_07:
                double result;
                if (3 != 0)
                {
                    result = (double)base.GetValue(ChromaKeyHSVEffect.HueMaxProperty) + 0.54;
                }
            IL_24:
                if (8 != 0)
                {
                    return result;
                }
                goto IL_07;
            }
            set
            {
                base.SetValue(ChromaKeyHSVEffect.HueMaxProperty, value);
            }
        }

        public double SaturationShift
        {
            get
            {
                if (!true)
                {
                    goto IL_24;
                }
                if (!false)
                {
                }
            IL_07:
                double result;
                if (3 != 0)
                {
                    result = (double)base.GetValue(ChromaKeyHSVEffect.SaturationShiftProperty) + 0.3;
                }
            IL_24:
                if (8 != 0)
                {
                    return result;
                }
                goto IL_07;
            }
            set
            {
                base.SetValue(ChromaKeyHSVEffect.SaturationShiftProperty, value);
            }
        }

        public double LightnessShift
        {
            get
            {
                if (!true)
                {
                    goto IL_24;
                }
                if (!false)
                {
                }
            IL_07:
                double result;
                if (3 != 0)
                {
                    result = (double)base.GetValue(ChromaKeyHSVEffect.LightnessShiftProperty) + 0.5423;
                }
            IL_24:
                if (8 != 0)
                {
                    return result;
                }
                goto IL_07;
            }
            set
            {
                base.SetValue(ChromaKeyHSVEffect.LightnessShiftProperty, value);
            }
        }

        

        public ChromaKeyHSVEffect()
        {
            base.PixelShader = new PixelShader
            {
                // UriSource = new Uri("/Shader/ChromaKeyHSV.ps", UriKind.Relative)
                UriSource = PhotoSW.ViewModels.Global.MakePackUri("Shader/ChromaKeyHSV.ps")
            };
            base.UpdateShaderValue(ChromaKeyHSVEffect.InputProperty);
            base.UpdateShaderValue(ChromaKeyHSVEffect.HueMinProperty);
            base.UpdateShaderValue(ChromaKeyHSVEffect.HueMaxProperty);
            base.UpdateShaderValue(ChromaKeyHSVEffect.SaturationShiftProperty);
            base.UpdateShaderValue(ChromaKeyHSVEffect.LightnessShiftProperty);
         
            }
    }
}
