using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
{
    public class redeyeMultiple : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(redeyeMultiple), 0);

        public static readonly DependencyProperty CenterProperty = DependencyProperty.Register("Center", typeof(Point), typeof(redeyeMultiple), new UIPropertyMetadata(new Point(0.5, 0.5), ShaderEffect.PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty Center1Property = DependencyProperty.Register("Center1", typeof(Point), typeof(redeyeMultiple), new UIPropertyMetadata(new Point(0.0, 0.0), ShaderEffect.PixelShaderConstantCallback(5)));

        public static readonly DependencyProperty Center2Property = DependencyProperty.Register("Center2", typeof(Point), typeof(redeyeMultiple), new UIPropertyMetadata(new Point(0.0, 0.0), ShaderEffect.PixelShaderConstantCallback(6)));

        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(redeyeMultiple), new UIPropertyMetadata(0.0105, ShaderEffect.PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty Radius1Property = DependencyProperty.Register("Radius1", typeof(double), typeof(redeyeMultiple), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(7)));

        public static readonly DependencyProperty Radius2Property = DependencyProperty.Register("Radius2", typeof(double), typeof(redeyeMultiple), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(8)));

        public static readonly DependencyProperty RedeyeTrueProperty = DependencyProperty.Register("RedeyeTrue", typeof(double), typeof(redeyeMultiple), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(2)));

        public static readonly DependencyProperty RedeyeTrue1Property = DependencyProperty.Register("RedeyeTrue1", typeof(double), typeof(redeyeMultiple), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(9)));

        public static readonly DependencyProperty RedeyeTrue2Property = DependencyProperty.Register("RedeyeTrue2", typeof(double), typeof(redeyeMultiple), new UIPropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(10)));

        public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(redeyeMultiple), new UIPropertyMetadata(1.0, ShaderEffect.PixelShaderConstantCallback(4)));

        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(redeyeMultiple.InputProperty);
            }
            set
            {
                base.SetValue(redeyeMultiple.InputProperty, value);
            }
        }

        public Point Center
        {
            get
            {
                return (Point)base.GetValue(redeyeMultiple.CenterProperty);
            }
            set
            {
                base.SetValue(redeyeMultiple.CenterProperty, value);
            }
        }

        public Point Center1
        {
            get
            {
                return (Point)base.GetValue(redeyeMultiple.Center1Property);
            }
            set
            {
                base.SetValue(redeyeMultiple.Center1Property, value);
            }
        }

        public Point Center2
        {
            get
            {
                return (Point)base.GetValue(redeyeMultiple.Center2Property);
            }
            set
            {
                base.SetValue(redeyeMultiple.Center2Property, value);
            }
        }

        public double Radius
        {
            get
            {
                return (double)base.GetValue(redeyeMultiple.RadiusProperty);
            }
            set
            {
                base.SetValue(redeyeMultiple.RadiusProperty, value);
            }
        }

        public double Radius1
        {
            get
            {
                return (double)base.GetValue(redeyeMultiple.Radius1Property);
            }
            set
            {
                base.SetValue(redeyeMultiple.Radius1Property, value);
            }
        }

        public double Radius2
        {
            get
            {
                return (double)base.GetValue(redeyeMultiple.Radius2Property);
            }
            set
            {
                base.SetValue(redeyeMultiple.Radius2Property, value);
            }
        }

        public double RedeyeTrue
        {
            get
            {
                return (double)base.GetValue(redeyeMultiple.RedeyeTrueProperty);
            }
            set
            {
                base.SetValue(redeyeMultiple.RedeyeTrueProperty, value);
            }
        }

        public double RedeyeTrue1
        {
            get
            {
                return (double)base.GetValue(redeyeMultiple.RedeyeTrue1Property);
            }
            set
            {
                base.SetValue(redeyeMultiple.RedeyeTrue1Property, value);
            }
        }

        public double RedeyeTrue2
        {
            get
            {
                return (double)base.GetValue(redeyeMultiple.RedeyeTrue2Property);
            }
            set
            {
                base.SetValue(redeyeMultiple.RedeyeTrue2Property, value);
            }
        }

        public double AspectRatio
        {
            get
            {
                return (double)base.GetValue(redeyeMultiple.AspectRatioProperty);
            }
            set
            {
                base.SetValue(redeyeMultiple.AspectRatioProperty, value);
            }
        }

        public redeyeMultiple()
        {
            base.PixelShader = new PixelShader
            {
                UriSource = new Uri("/PhotoSW;component/Shader/redeyemultiple.ps", UriKind.Relative)
            };
            base.UpdateShaderValue(redeyeMultiple.InputProperty);
            base.UpdateShaderValue(redeyeMultiple.CenterProperty);
            base.UpdateShaderValue(redeyeMultiple.Center1Property);
            base.UpdateShaderValue(redeyeMultiple.Center2Property);
            base.UpdateShaderValue(redeyeMultiple.RadiusProperty);
            base.UpdateShaderValue(redeyeMultiple.Radius1Property);
            base.UpdateShaderValue(redeyeMultiple.Radius2Property);
            base.UpdateShaderValue(redeyeMultiple.RedeyeTrueProperty);
            base.UpdateShaderValue(redeyeMultiple.RedeyeTrue1Property);
            base.UpdateShaderValue(redeyeMultiple.RedeyeTrue2Property);
            base.UpdateShaderValue(redeyeMultiple.AspectRatioProperty);
        }
    }
}
