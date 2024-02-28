using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
{
    public class ChromaEffectAllColor : ShaderBaseClass
    {
        private static string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private static string xslLocation = Path.Combine(ChromaEffectAllColor.executableLocation, "Shader\\ColorKeyShader.ps");

        private static readonly PixelShader shader;

        public static readonly DependencyProperty ChannelRProperty;

        public static readonly DependencyProperty ChannelGProperty;

        public static readonly DependencyProperty ChannelBProperty;

        public static readonly DependencyProperty ToleranceProperty;

        public float ChannelR
        {
            get
            {
                return (float)base.GetValue(ChromaEffectAllColor.ChannelRProperty);
            }
            set
            {
                base.SetValue(ChromaEffectAllColor.ChannelRProperty, value);
            }
        }

        public float ChannelG
        {
            get
            {
                return (float)base.GetValue(ChromaEffectAllColor.ChannelGProperty);
            }
            set
            {
                base.SetValue(ChromaEffectAllColor.ChannelGProperty, value);
            }
        }

        public float ChannelB
        {
            get
            {
                return (float)base.GetValue(ChromaEffectAllColor.ChannelBProperty);
            }
            set
            {
                base.SetValue(ChromaEffectAllColor.ChannelBProperty, value);
            }
        }

        public Color ColorKey
        {
            get
            {
                Color result;
                do
                {
                    if (5 != 0)
                    {
                        if (-1 != 0)
                        {
                            if (false)
                            {
                                continue;
                            }
                            result = Color.FromScRgb(1f, this.ChannelR, this.ChannelG, this.ChannelB);
                        }
                    }
                }
                while (false);
                return result;
            }
            set
            {
                do
                {
                    if (!false)
                    {
                        float expr_2F = value.ScR;
                        if (7 != 0)
                        {
                            this.ChannelR = expr_2F;
                        }
                        if (5 != 0)
                        {
                        }
                        this.ChannelG = value.ScG;
                    }
                    if (true)
                    {
                        this.ChannelB = value.ScB;
                    }
                }
                while (7 == 0);
            }
        }

        public float Tolerance
        {
            get
            {
                return (float)base.GetValue(ChromaEffectAllColor.ToleranceProperty);
            }
            set
            {
                base.SetValue(ChromaEffectAllColor.ToleranceProperty, value);
            }
        }

        public ChromaEffectAllColor()
            : base(ChromaEffectAllColor.shader)
        {
            this.ChannelR = 0f;
            this.ChannelG = 0f;
            this.ChannelB = 0f;
            this.Tolerance = 0.3f;
            base.UpdateShaderValue(ChromaEffectAllColor.ChannelRProperty);
            base.UpdateShaderValue(ChromaEffectAllColor.ChannelGProperty);
            base.UpdateShaderValue(ChromaEffectAllColor.ChannelBProperty);
            base.UpdateShaderValue(ChromaEffectAllColor.ToleranceProperty);
        }

        static ChromaEffectAllColor()
        {
            // Note: this type is marked as 'beforefieldinit'.
            PixelShader expr_158 = new PixelShader();
            PixelShader pixelShader;
            if (4 != 0)
            {
                pixelShader = expr_158;
            }

            //base.PixelShader = new PixelShader
            //{
            //    UriSource = new Uri("/Shader/Cartoonize.ps", UriKind.Relative)
            //};

            pixelShader.UriSource = new Uri("/Shader/ColorKeyShader.ps", UriKind.Relative); //Uri(ChromaEffectAllColor.xslLocation);
            ChromaEffectAllColor.shader = pixelShader;
            ChromaEffectAllColor.ChannelRProperty = DependencyProperty.Register("ChannelR", typeof(float), typeof(ChromaEffectAllColor), new UIPropertyMetadata(0f, ShaderEffect.PixelShaderConstantCallback(0)));
            ChromaEffectAllColor.ChannelGProperty = DependencyProperty.Register("ChannelG", typeof(float), typeof(ChromaEffectAllColor), new UIPropertyMetadata(0f, ShaderEffect.PixelShaderConstantCallback(1)));
            ChromaEffectAllColor.ChannelBProperty = DependencyProperty.Register("ChannelB", typeof(float), typeof(ChromaEffectAllColor), new UIPropertyMetadata(0f, ShaderEffect.PixelShaderConstantCallback(2)));
            ChromaEffectAllColor.ToleranceProperty = DependencyProperty.Register("Tolerance", typeof(float), typeof(ChromaEffectAllColor), new UIPropertyMetadata(0.3f, ShaderEffect.PixelShaderConstantCallback(3)));
        }
    }
}
