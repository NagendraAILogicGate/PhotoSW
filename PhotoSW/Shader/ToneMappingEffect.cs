using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
{
    public class ToneMappingEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ToneMappingEffect), 0);

        public static readonly DependencyProperty DefogProperty = DependencyProperty.Register("Defog", typeof(double), typeof(ToneMappingEffect), new UIPropertyMetadata(0.01, ShaderEffect.PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty FogColorProperty = DependencyProperty.Register("FogColor", typeof(Color), typeof(ToneMappingEffect), new UIPropertyMetadata(Color.FromArgb(255, 255, 255, 255), ShaderEffect.PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty ExposureProperty = DependencyProperty.Register("Exposure", typeof(double), typeof(ToneMappingEffect), new UIPropertyMetadata(0.2, ShaderEffect.PixelShaderConstantCallback(2)));

        public static readonly DependencyProperty GammaProperty = DependencyProperty.Register("Gamma", typeof(double), typeof(ToneMappingEffect), new UIPropertyMetadata(0.8, ShaderEffect.PixelShaderConstantCallback(3)));

        public static readonly DependencyProperty VignetteCenterProperty = DependencyProperty.Register("VignetteCenter", typeof(Point), typeof(ToneMappingEffect), new UIPropertyMetadata(new Point(0.5, 0.5), ShaderEffect.PixelShaderConstantCallback(4)));

        public static readonly DependencyProperty VignetteRadiusProperty = DependencyProperty.Register("VignetteRadius", typeof(double), typeof(ToneMappingEffect), new UIPropertyMetadata(1.0, ShaderEffect.PixelShaderConstantCallback(5)));

        public static readonly DependencyProperty VignetteAmountProperty = DependencyProperty.Register("VignetteAmount", typeof(double), typeof(ToneMappingEffect), new UIPropertyMetadata(-1.0, ShaderEffect.PixelShaderConstantCallback(6)));

        public static readonly DependencyProperty BlueShiftProperty = DependencyProperty.Register("BlueShift", typeof(double), typeof(ToneMappingEffect), new UIPropertyMetadata(0.25, ShaderEffect.PixelShaderConstantCallback(7)));

        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(ToneMappingEffect.InputProperty);
            }
            set
            {
                base.SetValue(ToneMappingEffect.InputProperty, value);
            }
        }

        public double Defog
        {
            get
            {
                return (double)base.GetValue(ToneMappingEffect.DefogProperty);
            }
            set
            {
                base.SetValue(ToneMappingEffect.DefogProperty, value);
            }
        }

        public Color FogColor
        {
            get
            {
                return (Color)base.GetValue(ToneMappingEffect.FogColorProperty);
            }
            set
            {
                base.SetValue(ToneMappingEffect.FogColorProperty, value);
            }
        }

        public double Exposure
        {
            get
            {
                return (double)base.GetValue(ToneMappingEffect.ExposureProperty);
            }
            set
            {
                base.SetValue(ToneMappingEffect.ExposureProperty, value);
            }
        }

        public double Gamma
        {
            get
            {
                return (double)base.GetValue(ToneMappingEffect.GammaProperty);
            }
            set
            {
                base.SetValue(ToneMappingEffect.GammaProperty, value);
            }
        }

        public Point VignetteCenter
        {
            get
            {
                return (Point)base.GetValue(ToneMappingEffect.VignetteCenterProperty);
            }
            set
            {
                base.SetValue(ToneMappingEffect.VignetteCenterProperty, value);
            }
        }

        public double VignetteRadius
        {
            get
            {
                return (double)base.GetValue(ToneMappingEffect.VignetteRadiusProperty);
            }
            set
            {
                base.SetValue(ToneMappingEffect.VignetteRadiusProperty, value);
            }
        }

        public double VignetteAmount
        {
            get
            {
                return (double)base.GetValue(ToneMappingEffect.VignetteAmountProperty);
            }
            set
            {
                base.SetValue(ToneMappingEffect.VignetteAmountProperty, value);
            }
        }

        public double BlueShift
        {
            get
            {
                return (double)base.GetValue(ToneMappingEffect.BlueShiftProperty);
            }
            set
            {
                base.SetValue(ToneMappingEffect.BlueShiftProperty, value);
            }
        }

        public ToneMappingEffect()
        {
            base.PixelShader = new PixelShader
            {   
                UriSource = PhotoSW.ViewModels.Global.MakePackUri("Shader/ToneMapping.ps")
                //UriSource = new Uri("/Shader/ToneMapping.ps", UriKind.Relative)
            };
            base.UpdateShaderValue(ToneMappingEffect.InputProperty);
            base.UpdateShaderValue(ToneMappingEffect.DefogProperty);
            base.UpdateShaderValue(ToneMappingEffect.FogColorProperty);
            base.UpdateShaderValue(ToneMappingEffect.ExposureProperty);
            base.UpdateShaderValue(ToneMappingEffect.GammaProperty);
            base.UpdateShaderValue(ToneMappingEffect.VignetteCenterProperty);
            base.UpdateShaderValue(ToneMappingEffect.VignetteRadiusProperty);
            base.UpdateShaderValue(ToneMappingEffect.VignetteAmountProperty);
            base.UpdateShaderValue(ToneMappingEffect.BlueShiftProperty);
        }
    }
}
