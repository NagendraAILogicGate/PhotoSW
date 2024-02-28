namespace PhotoSW.Shader
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Effects;

    internal class RemoveDarkGreenEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty;

        static RemoveDarkGreenEffect()
        {
            // This item is obfuscated and can not be translated.
        }

        public RemoveDarkGreenEffect()
        {
            PixelShader shader = new PixelShader {
                UriSource = new Uri("/Shader/RemoveDarkGreen.ps", UriKind.Relative)
            };
            base.PixelShader = shader;
            base.UpdateShaderValue(InputProperty);
        }

        public Brush Input
        {
            get
            {
                // This item is obfuscated and can not be translated.
            }
            set
            {
                InputProperty.SetValue((DependencyProperty) this, value);
            }
        }
    }
}

