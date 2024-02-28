using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
{
    public class SketchGraniteEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty;

        public static readonly DependencyProperty BrushSizeProperty;

        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(SketchGraniteEffect.InputProperty);
            }
            set
            {
                base.SetValue(SketchGraniteEffect.InputProperty, value);
            }
        }

        public double BrushSize
        {
            get
            {
                return (double)base.GetValue(SketchGraniteEffect.BrushSizeProperty);
            }
            set
            {
                base.SetValue(SketchGraniteEffect.BrushSizeProperty, value);
            }
        }

        public SketchGraniteEffect()
        {
            base.PixelShader = new PixelShader
            {
                UriSource = new Uri("/PhotoSW;component/Shader/SketchGranite.ps", UriKind.Relative)
            };
            base.UpdateShaderValue(SketchGraniteEffect.InputProperty);
            base.UpdateShaderValue(SketchGraniteEffect.BrushSizeProperty);
        }

        static SketchGraniteEffect()
        {
            // Note: this type is marked as 'beforefieldinit'.
            do
            {
                if (true)
                {
                    SketchGraniteEffect.InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(SketchGraniteEffect), 0);
                    if (7 == 0)
                    {
                        continue;
                    }
                    if (!false)
                    {
                        SketchGraniteEffect.BrushSizeProperty = DependencyProperty.Register("BrushSize", typeof(double), typeof(SketchGraniteEffect), new UIPropertyMetadata(0.003, ShaderEffect.PixelShaderConstantCallback(0)));
                    }
                }
            }
            while (false);
        }
    }
}
