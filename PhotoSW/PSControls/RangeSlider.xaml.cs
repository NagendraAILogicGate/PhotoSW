using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace PhotoSW.PSControls
{
    public partial class RangeSlider : UserControl, IComponentConnector
    {
        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(double), typeof(RangeSlider), new UIPropertyMetadata(0.0));

        public static readonly DependencyProperty LowerValueProperty = DependencyProperty.Register("LowerValue", typeof(double), typeof(RangeSlider), new UIPropertyMetadata(0.0));

        public static readonly DependencyProperty UpperValueProperty = DependencyProperty.Register("UpperValue", typeof(double), typeof(RangeSlider), new UIPropertyMetadata(0.0));

        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(double), typeof(RangeSlider), new UIPropertyMetadata(1.0));

       

        public double Minimum
        {
            get
            {
                return (double)base.GetValue(RangeSlider.MinimumProperty);
            }
            set
            {
                base.SetValue(RangeSlider.MinimumProperty, value);
            }
        }

        public double LowerValue
        {
            get
            {
                return (double)base.GetValue(RangeSlider.LowerValueProperty);
            }
            set
            {
                base.SetValue(RangeSlider.LowerValueProperty, value);
            }
        }

        public double UpperValue
        {
            get
            {
                return (double)base.GetValue(RangeSlider.UpperValueProperty);
            }
            set
            {
                base.SetValue(RangeSlider.UpperValueProperty, value);
            }
        }

        public double Maximum
        {
            get
            {
                return (double)base.GetValue(RangeSlider.MaximumProperty);
            }
            set
            {
                base.SetValue(RangeSlider.MaximumProperty, value);
            }
        }

        public RangeSlider()
        {
            this.InitializeComponent();
            base.Loaded += new RoutedEventHandler(this.Slider_Loaded);
        }

        private void Slider_Loaded(object sender, RoutedEventArgs e)
        {
            do
            {
                if (-1 != 0 && 8 != 0)
                {
                    if (7 == 0)
                    {
                        return;
                    }
                    this.LowerSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(this.LowerSlider_ValueChanged);
                }
            }
            while (false);
            this.UpperSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(this.UpperSlider_ValueChanged);
        }

        private void LowerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            while (true)
            {
                if (-1 == 0)
                {
                    goto IL_24;
                }
            IL_04:
                if (false)
                {
                    continue;
                }
                this.UpperSlider.Value = Math.Max(this.UpperSlider.Value, this.LowerSlider.Value);
            IL_24:
                if (!false)
                {
                    if (!false)
                    {
                        break;
                    }
                    goto IL_04;
                }
            }
        }

        private void UpperSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            while (true)
            {
                if (-1 == 0)
                {
                    goto IL_24;
                }
            IL_04:
                if (false)
                {
                    continue;
                }
                this.LowerSlider.Value = Math.Min(this.UpperSlider.Value, this.LowerSlider.Value);
            IL_24:
                if (!false)
                {
                    if (!false)
                    {
                        break;
                    }
                    goto IL_04;
                }
            }
        }

   
    }
}
