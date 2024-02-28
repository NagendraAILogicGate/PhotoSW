using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace PhotoSW.PSControls
{
    public partial class AngleRotate : UserControl, IComponentConnector
    {
        public delegate void AngleChangedDelegate();
        private AngleRotate.AngleChangedDelegate angleChanged;
        public static readonly DependencyProperty AngleProperty;

        public Point arrowCenterPoint;

        private bool isMouseRotating;

        private double mouseDownAngle;

        private Vector mouseDownVector;

       // internal AngleRotate This;

       // private bool _contentLoaded;
        public AngleRotate()
        {
            
            //this.InitializeComponent();
        }
        public event AngleRotate.AngleChangedDelegate AngleChanged
        {

            add
            {
                do
                {
                IL_00:
                    AngleRotate.AngleChangedDelegate angleChangedDelegate = this.angleChanged;
                    while (true)
                    {
                    IL_09:
                        AngleRotate.AngleChangedDelegate angleChangedDelegate2 = angleChangedDelegate;
                        while (true)
                        {
                            AngleRotate.AngleChangedDelegate value2 = (AngleRotate.AngleChangedDelegate)Delegate.Combine(angleChangedDelegate2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            angleChangedDelegate = Interlocked.CompareExchange<AngleRotate.AngleChangedDelegate>(ref this.angleChanged, value2, angleChangedDelegate2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (angleChangedDelegate == angleChangedDelegate2);
                                if (!false)
                                {
                                    arg_39_0 = !expr_31;
                                }
                                if (arg_39_0)
                                {
                                    goto IL_09;
                                }
                                if (!false)
                                {
                                    goto Block_4;
                                }
                            }
                        }
                    }
                Block_4: ;
                }
                while (!true);
            }
            remove
            {
                do
                {
                IL_00:
                    AngleRotate.AngleChangedDelegate angleChangedDelegate = this.angleChanged;
                    while (true)
                    {
                    IL_09:
                        AngleRotate.AngleChangedDelegate angleChangedDelegate2 = angleChangedDelegate;
                        while (true)
                        {
                            AngleRotate.AngleChangedDelegate value2 = (AngleRotate.AngleChangedDelegate)Delegate.Remove(angleChangedDelegate2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            angleChangedDelegate = Interlocked.CompareExchange<AngleRotate.AngleChangedDelegate>(ref this.angleChanged, value2, angleChangedDelegate2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (angleChangedDelegate == angleChangedDelegate2);
                                if (!false)
                                {
                                    arg_39_0 = !expr_31;
                                }
                                if (arg_39_0)
                                {
                                    goto IL_09;
                                }
                                if (!false)
                                {
                                    goto Block_4;
                                }
                            }
                        }
                    }
                Block_4: ;
                }
                while (!true);
            }
        }

        public double Angle
        {
            get
            {
                return (double)base.GetValue(AngleRotate.AngleProperty);
            }
            set
            {
                while (true)
                {
                    while (true)
                    {
                        if (6 != 0)
                        {
                            base.SetValue(AngleRotate.AngleProperty, value);
                            if (!false)
                            {
                                if (false)
                                {
                                    break;
                                }

                               // this.AngleChanged();
                            }
                        }
                        if (!false)
                        {
                            return;
                        }
                    }
                }
            }
        }

       

        protected override void OnLostMouseCapture(MouseEventArgs e)
        {
            this.isMouseRotating = false;
            base.OnLostMouseCapture(e);
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            if (7 != 0)
            {
                if (false)
                {
                    goto IL_30;
                }
                Point expr_53 = e.GetPosition(this);
                Point point;
                if (!false)
                {
                    point = expr_53;
                }
                this.mouseDownVector = point - this.arrowCenterPoint;
            }
            this.mouseDownAngle = this.Angle;
        IL_30:
            e.MouseDevice.Capture(this);
            this.isMouseRotating = true;
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            bool flag;
            if (2 != 0)
            {
                bool arg_0C_0 = this.isMouseRotating;
                bool expr_0C;
                do
                {
                    expr_0C = (arg_0C_0 = !arg_0C_0);
                }
                while (4 == 0);
                flag = expr_0C;
            }
            if (!false && -1 != 0 && !flag)
            {
                Point position = e.GetPosition(this);
                Vector vector = position - this.arrowCenterPoint;
                if (2 != 0)
                {
                    this.Angle = Vector.AngleBetween(this.mouseDownVector, vector) + this.mouseDownAngle;
                }
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            while (true)
            {
                if (2 == 0)
                {
                    goto IL_18;
                }
                bool arg_40_0 = !this.isMouseRotating;
            IL_0E:
                bool flag = arg_40_0;
                if (4 == 0)
                {
                    continue;
                }
                if (flag)
                {
                    goto IL_2F;
                }
            IL_18:
                arg_40_0 = e.MouseDevice.Capture(null);
                if (!false)
                {
                    break;
                }
                goto IL_0E;
            }
        IL_23:
            this.isMouseRotating = false;
        IL_2B:
            if (4 == 0)
            {
                goto IL_23;
            }
        IL_2F:
            if (!false)
            {
                base.OnMouseUp(e);
                return;
            }
            goto IL_2B;
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            this.arrowCenterPoint = new Point(base.ActualWidth / 2.0, base.ActualHeight / 2.0);
        }

        private static object coerceValueCallback(DependencyObject d, object baseValue)
        {
            double num = (double)baseValue % 360.0;
            object result;
            while (true)
            {
                if (!false)
                {
                    double arg_41_0;
                    double expr_64 = arg_41_0 = num;
                    double arg_41_1;
                    double expr_19 = arg_41_1 = 0.0;
                    if (-1 != 0)
                    {
                        bool arg_67_0;
                        bool arg_34_0;
                        bool expr_25 = arg_34_0 = (arg_67_0 = (expr_64 < expr_19));
                        if (!false)
                        {
                            arg_67_0 = (arg_34_0 = !expr_25);
                        }
                        if (8 != 0)
                        {
                            bool flag = arg_67_0;
                            arg_34_0 = flag;
                        }
                        if (arg_34_0)
                        {
                            result = num;
                            goto IL_54;
                        }
                        arg_41_0 = num;
                        arg_41_1 = 360.0;
                    }
                    result = arg_41_0 + arg_41_1;
                }
            IL_56:
                if (4 != 0)
                {
                    break;
                }
                continue;
            IL_54:
                goto IL_56;
            }
            return result;
        }

        
        //public void InitializeComponentCoustom()
        //{
        //    bool arg_09_0 = this._contentLoaded;
        //    bool expr_09;
        //    do
        //    {
        //        expr_09 = (arg_09_0 = !arg_09_0);
        //    }
        //    while (false);
        //    bool flag = expr_09;
        //    while (true)
        //    {
        //        if (!flag)
        //        {
        //            goto IL_14;
        //        }
        //    IL_1A:
        //        this._contentLoaded = true;
        //        while (6 != 0)
        //        {
        //            Uri resourceLocator = new Uri("/DigiPhoto;component/usercontrol/anglerotate.xaml", UriKind.Relative);
        //            if (!false)
        //            {
        //                Application.LoadComponent(this, resourceLocator);
        //                if (-1 != 0)
        //                {
        //                    return;
        //                }
        //                goto IL_14;
        //            }
        //        }
        //        continue;
        //    IL_14:
        //        if (6 != 0)
        //        {
        //            break;
        //        }
        //        goto IL_1A;
        //    }
        //}

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        //void IComponentConnector.Connect(int connectionId, object target)
        //{
        //    do
        //    {
        //        if (8 != 0 && connectionId != 1 && !false)
        //        {
        //            if (false)
        //            {
        //                continue;
        //            }
        //            this._contentLoaded = true;
        //        }
        //        else
        //        {
        //            this.This = (AngleRotate)target;
        //        }
        //    }
        //    while (false);
        //}

        //static AngleRotate()
        //{
        //    // Note: this type is marked as 'beforefieldinit'.
        //    do
        //    {
        //        if (-1 != 0)
        //        {
        //            AngleRotate.AngleProperty = DependencyProperty.Register("Angle", typeof(double), typeof(AngleRotate), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null, new CoerceValueCallback(AngleRotate.coerceValueCallback)));
        //        }
        //    }
        //    while (false || false || 5 == 0);
        //}
    }
}
