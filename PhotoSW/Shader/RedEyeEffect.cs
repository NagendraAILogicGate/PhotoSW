using FrameworkHelper.Common;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
{
    public class RedEyeEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(RedEyeEffect), 0);

        public static readonly DependencyProperty CenterProperty = DependencyProperty.Register("Center", typeof(Point), typeof(RedEyeEffect), new UIPropertyMetadata(new Point(0.5, 0.5), ShaderEffect.PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(RedEyeEffect), new UIPropertyMetadata(ContantValueForMainWindow.RedEyeSize, ShaderEffect.PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty RedeyeTrueProperty = DependencyProperty.Register("RedeyeTrue", typeof(double), typeof(RedEyeEffect), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(2)));

        public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(RedEyeEffect), new UIPropertyMetadata(1.0, ShaderEffect.PixelShaderConstantCallback(4)));

        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(RedEyeEffect.InputProperty);
            }
            set
            {
                base.SetValue(RedEyeEffect.InputProperty, value);
            }
        }

        public Point Center
        {
            get
            {
                return (Point)base.GetValue(RedEyeEffect.CenterProperty);
            }
            set
            {
                base.SetValue(RedEyeEffect.CenterProperty, value);
            }
        }

        public double Radius
        {
            get
            {
                return (double)base.GetValue(RedEyeEffect.RadiusProperty);
            }
            set
            {
                base.SetValue(RedEyeEffect.RadiusProperty, value);
            }
        }

        public double RedeyeTrue
        {
            get
            {
                return (double)base.GetValue(RedEyeEffect.RedeyeTrueProperty);
            }
            set
            {
                base.SetValue(RedEyeEffect.RedeyeTrueProperty, value);
            }
        }

        public double AspectRatio
        {
            get
            {
                return (double)base.GetValue(RedEyeEffect.AspectRatioProperty);
            }
            set
            {
                base.SetValue(RedEyeEffect.AspectRatioProperty, value);
            }
        }

        public RedEyeEffect()
        {
            base.PixelShader = new PixelShader
            {
                UriSource = new Uri("/PhotoSW;component/Shader/redeyeFurther.ps", UriKind.RelativeOrAbsolute)
            };
            base.UpdateShaderValue(RedEyeEffect.InputProperty);
            base.UpdateShaderValue(RedEyeEffect.CenterProperty);
            base.UpdateShaderValue(RedEyeEffect.RadiusProperty);
            base.UpdateShaderValue(RedEyeEffect.RedeyeTrueProperty);
            base.UpdateShaderValue(RedEyeEffect.AspectRatioProperty);
        }
    }
}
