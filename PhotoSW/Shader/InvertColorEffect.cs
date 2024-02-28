using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
{
    public class InvertColorEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(InvertColorEffect), 0);

        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(InvertColorEffect.InputProperty);
            }
            set
            {
                base.SetValue(InvertColorEffect.InputProperty, value);
            }
        }

        public InvertColorEffect()
        {
            base.PixelShader = new PixelShader
            {
                UriSource = new Uri("/PhotoSW;component/Shader/InvertColor.ps", UriKind.Relative)
            };
            base.UpdateShaderValue(InvertColorEffect.InputProperty);
        }
    }
}
