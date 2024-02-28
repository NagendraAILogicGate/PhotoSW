using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
{
    public class UndoBrushEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(UndoBrushEffect), 0);

        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(UndoBrushEffect.InputProperty);
            }
            set
            {
                base.SetValue(UndoBrushEffect.InputProperty, value);
            }
        }

        public UndoBrushEffect()
        {
            base.PixelShader = new PixelShader
            {
                UriSource = PhotoSW.ViewModels.Global.MakePackUri("Shader/UndoBrush.ps")
                //UriSource = new Uri("/Shader/UndoBrush.ps", UriKind.Relative)
            };
            base.UpdateShaderValue(UndoBrushEffect.InputProperty);
        }
    }
}
