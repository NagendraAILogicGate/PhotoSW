using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
{
    public class ShaderBaseClass : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ShaderBaseClass), 0);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(ShaderBaseClass.InputProperty);
            }
            set
            {
                base.SetValue(ShaderBaseClass.InputProperty, value);
            }
        }

        public ShaderBaseClass(PixelShader shader)
        {
            base.PixelShader = shader;
            base.UpdateShaderValue(ShaderBaseClass.InputProperty);
        }
    }
}
