using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PhotoSW.PSControls
{
    public partial class JRotate : UserControl, IComponentConnector
    {
        public delegate void JAngleChangedDelegate();
        private JAngleChangedDelegate angleChanged;
        public static readonly DependencyProperty AngleProperty;

        public Point arrowCenterPoint;

        private bool isMouseRotating;

        private double mouseDownAngle;

        private Vector mouseDownVector;
        public JRotate()
        {
            this.InitializeComponent();
        }
       

       // private bool _contentLoaded;

        public event JRotate.JAngleChangedDelegate AngleChanged
        {
           
            add
            {
                do
                {
                IL_00:
                    JRotate.JAngleChangedDelegate jAngleChangedDelegate = this.angleChanged;
                    while (true)
                    {
                    IL_09:
                        JRotate.JAngleChangedDelegate jAngleChangedDelegate2 = jAngleChangedDelegate;
                        while (true)
                        {
                            JRotate.JAngleChangedDelegate value2 = (JRotate.JAngleChangedDelegate)Delegate.Combine(jAngleChangedDelegate2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            jAngleChangedDelegate = Interlocked.CompareExchange<JRotate.JAngleChangedDelegate>(ref this.angleChanged, value2, jAngleChangedDelegate2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (jAngleChangedDelegate == jAngleChangedDelegate2);
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
                    JRotate.JAngleChangedDelegate jAngleChangedDelegate = this.angleChanged;
                    while (true)
                    {
                    IL_09:
                        JRotate.JAngleChangedDelegate jAngleChangedDelegate2 = jAngleChangedDelegate;
                        while (true)
                        {
                            JRotate.JAngleChangedDelegate value2 = (JRotate.JAngleChangedDelegate)Delegate.Remove(jAngleChangedDelegate2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            jAngleChangedDelegate = Interlocked.CompareExchange<JRotate.JAngleChangedDelegate>(ref this.angleChanged, value2, jAngleChangedDelegate2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (jAngleChangedDelegate == jAngleChangedDelegate2);
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
                return (double)base.GetValue(JRotate.AngleProperty);
            }
            set
            {
                do
                {
                    //if (2 != 0)
                    //{
                        base.SetValue(JRotate.AngleProperty, value);
                        this.angleChanged();
                        RotateTransform rotateTransform = new RotateTransform();
                        rotateTransform.CenterX = 0.0;
                        rotateTransform.CenterY = 0.0;
                        while (false)
                        {
                        }
                        rotateTransform.Angle = this.Angle;
                        this.RedRect.RenderTransformOrigin = new Point(0.5, 1.0);
                        this.RedRect.RenderTransform = rotateTransform;
                   // }
                }
                while (false);
                this.RedRect.InvalidateArrange();
                this.RedRect.InvalidateMeasure();
                this.RedRect.InvalidateVisual();
            }
        }

       

        protected override void OnLostMouseCapture(MouseEventArgs e)
        {
            this.isMouseRotating = false;
            base.OnLostMouseCapture(e);
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            while (true)
            {
            IL_00:
                bool flag = !(e.OriginalSource is Rectangle);
                bool arg_23_0;
                if (!false)
                {
                    arg_23_0 = flag;
                    goto IL_23;
                }
                goto IL_88;
            IL_28:
                Rectangle rectangle = e.OriginalSource as Rectangle;
                flag = !(rectangle.Name == "RedRect");
                while (!flag)
                {
                    if (false)
                    {
                        return;
                    }
                    if (-1 != 0)
                    {
                        Point position = e.GetPosition(this);
                        if (4 != 0)
                        {
                            this.mouseDownVector = position - this.arrowCenterPoint;
                            this.mouseDownAngle = this.Angle;
                            goto IL_88;
                        }
                        goto IL_00;
                    }
                }
                goto IL_A3;
            IL_23:
                if (!arg_23_0)
                {
                    goto IL_28;
                }
                break;
            IL_A3:
                if (6 != 0)
                {
                    break;
                }
                goto IL_28;
            IL_88:
                arg_23_0 = e.MouseDevice.Capture(this);
                if (!false)
                {
                    this.isMouseRotating = true;
                    goto IL_A3;
                }
                goto IL_23;
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            bool arg_135_0;
            if (this.isMouseRotating)
            {
                if (7 == 0)
                {
                    goto IL_F1;
                }
                arg_135_0 = (e.MouseDevice.Captured == null);
                if (!false)
                {
                }
            }
            else
            {
                arg_135_0 = true;
            }
            if (arg_135_0)
            {
                goto IL_10B;
            }
            if (true)
            {
                Point position = e.GetPosition(this);
                RotateTransform rotateTransform;
                if (!false)
                {
                    Vector vector = position - this.arrowCenterPoint;
                    this.Angle = Vector.AngleBetween(this.mouseDownVector, vector) + this.mouseDownAngle;
                    rotateTransform = new RotateTransform();
                    rotateTransform.CenterX = 0.0;
                    if (false)
                    {
                        goto IL_F1;
                    }
                }
                rotateTransform.CenterY = 0.0;
                if (false)
                {
                    goto IL_10B;
                }
                rotateTransform.Angle = this.Angle;
                this.RedRect.RenderTransformOrigin = new Point(0.5, 1.0);
                this.RedRect.RenderTransform = rotateTransform;
            }
            this.RedRect.InvalidateArrange();
        IL_F1:
            this.RedRect.InvalidateMeasure();
            this.RedRect.InvalidateVisual();
        IL_10B:
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            if (!this.isMouseRotating)
            {
                goto IL_167;
            }
        IL_1E:
            Point position = e.GetPosition(this);
        IL_33:
            if (false)
            {
                goto IL_1E;
            }
            Vector vector = position - this.arrowCenterPoint;
            this.Angle = Vector.AngleBetween(this.mouseDownVector, vector) + this.mouseDownAngle;
            double arg_78_0;
            double expr_66 = arg_78_0 = this.Angle;
            if (!false)
            {
                arg_78_0 = expr_66 / 4.0;
            }
            double num = arg_78_0;
            double num2 = num - (double)((int)num);
            bool flag = num2 < 0.5;
            while (true)
            {
                int arg_A0_0;
                bool expr_8D = (arg_A0_0 = (flag ? 1 : 0)) != 0;
                if (6 == 0)
                {
                    goto IL_A0;
                }
                if (!expr_8D)
                {
                    goto IL_94;
                }
                num = Math.Floor(num);
                num = (double)((int)num * 4);
            IL_B4:
                if (4 == 0)
                {
                    goto IL_145;
                }
                RotateTransform rotateTransform = new RotateTransform();
                if (3 == 0)
                {
                    continue;
                }
                rotateTransform.CenterX = 0.0;
                rotateTransform.CenterY = 0.0;
                rotateTransform.Angle = num;
                this.RedRect.RenderTransformOrigin = new Point(0.5, 1.0);
                this.RedRect.RenderTransform = rotateTransform;
                if (!false)
                {
                    break;
                }
                goto IL_94;
            IL_A0:
                num = (double)arg_A0_0;
                goto IL_B4;
            IL_94:
                num = Math.Ceiling(num);
                arg_A0_0 = (int)num * 4;
                goto IL_A0;
            }
            this.Angle = num;
            this.RedRect.InvalidateArrange();
            this.RedRect.InvalidateMeasure();
        IL_145:
            this.RedRect.InvalidateVisual();
            e.MouseDevice.Capture(null);
            this.isMouseRotating = false;
        IL_167:
            if (2 != 0)
            {
                base.OnMouseUp(e);
                return;
            }
            goto IL_33;
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

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), DebuggerNonUserCode]
        //public void InitializeComponent()
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
        //            Uri resourceLocator = new Uri("/DigiPhoto;component/usercontrol/jrotate.xaml", UriKind.Relative);
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
        //    if (false)
        //    {
        //    }
        //    switch (connectionId)
        //    {
        //        case 1:
        //            this.This = (JRotate)target;
        //            break;
        //        case 2:
        //            this.BlackRect0 = (Rectangle)target;
        //            break;
        //        case 3:
        //            this.transformGroupLayout37 = (TransformGroup)target;
        //            break;
        //        case 4:
        //            this.BlackRect1 = (Rectangle)target;
        //            break;
        //        case 5:
        //            this.transformGroupLayout1 = (TransformGroup)target;
        //            break;
        //        case 6:
        //            this.transformGroupRender1 = (TransformGroup)target;
        //            break;
        //        case 7:
        //            this.BlackRect2 = (Rectangle)target;
        //            break;
        //        case 8:
        //            this.transformGroupLayout3 = (TransformGroup)target;
        //            break;
        //        case 9:
        //            this.BlackRect3 = (Rectangle)target;
        //            break;
        //        case 10:
        //            this.transformGroupLayout2 = (TransformGroup)target;
        //            break;
        //        case 11:
        //            this.transformGroupRender2 = (TransformGroup)target;
        //            break;
        //        case 12:
        //            this.BlackRec4 = (Rectangle)target;
        //            break;
        //        case 13:
        //            this.transformGroupLayout4 = (TransformGroup)target;
        //            break;
        //        case 14:
        //            this.transformGroupRender4 = (TransformGroup)target;
        //            break;
        //        case 15:
        //            this.BlackRec5 = (Rectangle)target;
        //            break;
        //        case 16:
        //            this.transformGroupLayout5 = (TransformGroup)target;
        //            break;
        //        case 17:
        //            this.transformGroupRender5 = (TransformGroup)target;
        //            break;
        //        case 18:
        //            this.BlackRec6 = (Rectangle)target;
        //            break;
        //        case 19:
        //            this.transformGroupLayout6 = (TransformGroup)target;
        //            break;
        //        case 20:
        //            this.transformGroupRender6 = (TransformGroup)target;
        //            break;
        //        case 21:
        //            this.BlackRec7 = (Rectangle)target;
        //            break;
        //        case 22:
        //            this.transformGroupLayout7 = (TransformGroup)target;
        //            break;
        //        case 23:
        //            this.transformGroupRender7 = (TransformGroup)target;
        //            break;
        //        case 24:
        //            this.BlackRec8 = (Rectangle)target;
        //            break;
        //        case 25:
        //            this.transformGroupLayout8 = (TransformGroup)target;
        //            break;
        //        case 26:
        //            this.transformGroupRender8 = (TransformGroup)target;
        //            break;
        //        case 27:
        //            this.BlackRec9 = (Rectangle)target;
        //            break;
        //        case 28:
        //            this.transformGroupLayout9 = (TransformGroup)target;
        //            break;
        //        case 29:
        //            this.transformGroupRender9 = (TransformGroup)target;
        //            break;
        //        case 30:
        //            this.BlackRec10 = (Rectangle)target;
        //            break;
        //        case 31:
        //            this.transformGroupLayout10 = (TransformGroup)target;
        //            break;
        //        case 32:
        //            this.transformGroupRender10 = (TransformGroup)target;
        //            break;
        //        case 33:
        //            this.BlackRec11 = (Rectangle)target;
        //            break;
        //        case 34:
        //            this.transformGroupLayout11 = (TransformGroup)target;
        //            break;
        //        case 35:
        //            goto IL_5E0;
        //        case 36:
        //            this.BlackRec12 = (Rectangle)target;
        //            break;
        //        case 37:
        //            this.transformGroupLayout12 = (TransformGroup)target;
        //            break;
        //        case 38:
        //            this.transformGroupRender12 = (TransformGroup)target;
        //            break;
        //        case 39:
        //            this.BlackRec13 = (Rectangle)target;
        //            break;
        //        case 40:
        //            this.transformGroupLayout13 = (TransformGroup)target;
        //            break;
        //        case 41:
        //            this.transformGroupRender3 = (TransformGroup)target;
        //            break;
        //        case 42:
        //            this.BlackRec14 = (Rectangle)target;
        //            break;
        //        case 43:
        //            this.transformGroupLayout14 = (TransformGroup)target;
        //            break;
        //        case 44:
        //            this.transformGroupRender13 = (TransformGroup)target;
        //            break;
        //        case 45:
        //            this.BlackRec15 = (Rectangle)target;
        //            break;
        //        case 46:
        //            this.transformGroupLayout15 = (TransformGroup)target;
        //            break;
        //        case 47:
        //            this.transformGroupRender14 = (TransformGroup)target;
        //            break;
        //        case 48:
        //            this.BlackRec16 = (Rectangle)target;
        //            break;
        //        case 49:
        //            this.transformGroupLayout16 = (TransformGroup)target;
        //            break;
        //        case 50:
        //            this.transformGroupRender15 = (TransformGroup)target;
        //            break;
        //        case 51:
        //            this.BlackRec17 = (Rectangle)target;
        //            break;
        //        case 52:
        //            this.transformGroupLayout17 = (TransformGroup)target;
        //            break;
        //        case 53:
        //            this.transformGroupRender16 = (TransformGroup)target;
        //            break;
        //        case 54:
        //            this.BlackRec18 = (Rectangle)target;
        //            break;
        //        case 55:
        //            if (!false)
        //            {
        //                this.transformGroupLayout18 = (TransformGroup)target;
        //            }
        //            break;
        //        case 56:
        //            this.transformGroupRender17 = (TransformGroup)target;
        //            break;
        //        case 57:
        //            this.BlackRec19 = (Rectangle)target;
        //            break;
        //        case 58:
        //            this.transformGroupLayout19 = (TransformGroup)target;
        //            break;
        //        case 59:
        //            this.transformGroupRender18 = (TransformGroup)target;
        //            break;
        //        case 60:
        //            this.BlackRec20 = (Rectangle)target;
        //            break;
        //        case 61:
        //            this.transformGroupLayout20 = (TransformGroup)target;
        //            break;
        //        case 62:
        //            this.transformGroupRender19 = (TransformGroup)target;
        //            break;
        //        case 63:
        //            this.BlackRec21 = (Rectangle)target;
        //            break;
        //        case 64:
        //            this.transformGroupLayout21 = (TransformGroup)target;
        //            break;
        //        case 65:
        //            this.transformGroupRender20 = (TransformGroup)target;
        //            break;
        //        case 66:
        //            this.BlackRec22 = (Rectangle)target;
        //            break;
        //        case 67:
        //            this.transformGroupLayout22 = (TransformGroup)target;
        //            break;
        //        case 68:
        //            this.transformGroupRender21 = (TransformGroup)target;
        //            break;
        //        case 69:
        //            this.BlackRec23 = (Rectangle)target;
        //            break;
        //        case 70:
        //            this.transformGroupLayout23 = (TransformGroup)target;
        //            break;
        //        case 71:
        //            this.transformGroupRender22 = (TransformGroup)target;
        //            break;
        //        case 72:
        //            this.BlackRec24 = (Rectangle)target;
        //            break;
        //        case 73:
        //            this.transformGroupLayout24 = (TransformGroup)target;
        //            break;
        //        case 74:
        //            this.transformGroupRender23 = (TransformGroup)target;
        //            break;
        //        case 75:
        //            this.BlackRec25 = (Rectangle)target;
        //            break;
        //        case 76:
        //            this.transformGroupLayout25 = (TransformGroup)target;
        //            break;
        //        case 77:
        //            this.transformGroupRender24 = (TransformGroup)target;
        //            break;
        //        case 78:
        //            this.BlackRec26 = (Rectangle)target;
        //            break;
        //        case 79:
        //            this.transformGroupLayout26 = (TransformGroup)target;
        //            break;
        //        case 80:
        //            this.transformGroupRender25 = (TransformGroup)target;
        //            break;
        //        case 81:
        //            this.BlackRec27 = (Rectangle)target;
        //            break;
        //        case 82:
        //            this.transformGroupLayout27 = (TransformGroup)target;
        //            break;
        //        case 83:
        //            this.transformGroupRender26 = (TransformGroup)target;
        //            break;
        //        case 84:
        //            this.BlackRec28 = (Rectangle)target;
        //            break;
        //        case 85:
        //            this.transformGroupLayout28 = (TransformGroup)target;
        //            break;
        //        case 86:
        //            this.transformGroupRender27 = (TransformGroup)target;
        //            break;
        //        case 87:
        //            this.BlackRec29 = (Rectangle)target;
        //            break;
        //        case 88:
        //            this.transformGroupLayout29 = (TransformGroup)target;
        //            break;
        //        case 89:
        //            this.transformGroupRender28 = (TransformGroup)target;
        //            break;
        //        case 90:
        //            this.BlackRec30 = (Rectangle)target;
        //            break;
        //        case 91:
        //            this.transformGroupLayout30 = (TransformGroup)target;
        //            break;
        //        case 92:
        //            this.transformGroupRender29 = (TransformGroup)target;
        //            break;
        //        case 93:
        //            this.BlackRec31 = (Rectangle)target;
        //            break;
        //        case 94:
        //            this.transformGroupLayout31 = (TransformGroup)target;
        //            break;
        //        case 95:
        //            this.transformGroupRender30 = (TransformGroup)target;
        //            break;
        //        case 96:
        //            if (false)
        //            {
        //                goto IL_5E0;
        //            }
        //            this.BlackRec32 = (Rectangle)target;
        //            break;
        //        case 97:
        //            this.transformGroupLayout32 = (TransformGroup)target;
        //            break;
        //        case 98:
        //            this.transformGroupRender31 = (TransformGroup)target;
        //            break;
        //        case 99:
        //            this.BlackRec33 = (Rectangle)target;
        //            break;
        //        case 100:
        //            this.transformGroupLayout33 = (TransformGroup)target;
        //            break;
        //        case 101:
        //            this.transformGroupRender32 = (TransformGroup)target;
        //            break;
        //        case 102:
        //            this.BlackRec34 = (Rectangle)target;
        //            break;
        //        case 103:
        //            this.transformGroupLayout34 = (TransformGroup)target;
        //            break;
        //        case 104:
        //            this.transformGroupRender33 = (TransformGroup)target;
        //            break;
        //        case 105:
        //            this.BlackRec35 = (Rectangle)target;
        //            break;
        //        case 106:
        //            this.transformGroupLayout35 = (TransformGroup)target;
        //            break;
        //        case 107:
        //            this.transformGroupRender34 = (TransformGroup)target;
        //            break;
        //        case 108:
        //            this.BlackRec36 = (Rectangle)target;
        //            break;
        //        case 109:
        //            this.transformGroupLayout36 = (TransformGroup)target;
        //            break;
        //        case 110:
        //            this.transformGroupRender35 = (TransformGroup)target;
        //            break;
        //        case 111:
        //            this.BlackRec37 = (Rectangle)target;
        //            break;
        //        case 112:
        //            this.transformGroupLayout38 = (TransformGroup)target;
        //            break;
        //        case 113:
        //            this.transformGroupRender36 = (TransformGroup)target;
        //            break;
        //        case 114:
        //            this.BlackRec38 = (Rectangle)target;
        //            break;
        //        case 115:
        //            this.transformGroupLayout39 = (TransformGroup)target;
        //            break;
        //        case 116:
        //            this.transformGroupRender37 = (TransformGroup)target;
        //            break;
        //        case 117:
        //            this.BlackRec39 = (Rectangle)target;
        //            break;
        //        case 118:
        //            this.transformGroupLayout40 = (TransformGroup)target;
        //            break;
        //        case 119:
        //            this.transformGroupRender38 = (TransformGroup)target;
        //            break;
        //        case 120:
        //            this.BlackRec40 = (Rectangle)target;
        //            break;
        //        case 121:
        //            this.transformGroupLayout41 = (TransformGroup)target;
        //            break;
        //        case 122:
        //            this.transformGroupRender39 = (TransformGroup)target;
        //            break;
        //        case 123:
        //            this.BlackRec41 = (Rectangle)target;
        //            break;
        //        case 124:
        //            this.transformGroupLayout42 = (TransformGroup)target;
        //            break;
        //        case 125:
        //            this.transformGroupRender40 = (TransformGroup)target;
        //            break;
        //        case 126:
        //            this.BlackRec42 = (Rectangle)target;
        //            break;
        //        case 127:
        //            this.transformGroupLayout43 = (TransformGroup)target;
        //            break;
        //        case 128:
        //            this.transformGroupRender41 = (TransformGroup)target;
        //            break;
        //        case 129:
        //            this.BlackRec43 = (Rectangle)target;
        //            break;
        //        case 130:
        //            this.transformGroupLayout44 = (TransformGroup)target;
        //            break;
        //        case 131:
        //            this.transformGroupRender42 = (TransformGroup)target;
        //            break;
        //        case 132:
        //            this.BlackRec44 = (Rectangle)target;
        //            break;
        //        case 133:
        //            this.transformGroupLayout45 = (TransformGroup)target;
        //            break;
        //        case 134:
        //            this.transformGroupRender43 = (TransformGroup)target;
        //            break;
        //        case 135:
        //            this.BlackRec45 = (Rectangle)target;
        //            break;
        //        case 136:
        //            this.transformGroupLayout46 = (TransformGroup)target;
        //            break;
        //        case 137:
        //            this.transformGroupRender44 = (TransformGroup)target;
        //            break;
        //        case 138:
        //            this.BlackRec46 = (Rectangle)target;
        //            break;
        //        case 139:
        //            this.transformGroupLayout47 = (TransformGroup)target;
        //            break;
        //        case 140:
        //            this.transformGroupRender45 = (TransformGroup)target;
        //            break;
        //        case 141:
        //            this.BlackRec47 = (Rectangle)target;
        //            break;
        //        case 142:
        //            this.transformGroupLayout48 = (TransformGroup)target;
        //            break;
        //        case 143:
        //            this.transformGroupRender46 = (TransformGroup)target;
        //            break;
        //        case 144:
        //            this.BlackRec48 = (Rectangle)target;
        //            break;
        //        case 145:
        //            this.transformGroupLayout49 = (TransformGroup)target;
        //            if (!false)
        //            {
        //            }
        //            break;
        //        case 146:
        //            this.transformGroupRender47 = (TransformGroup)target;
        //            break;
        //        case 147:
        //            this.BlackRec49 = (Rectangle)target;
        //            break;
        //        case 148:
        //            this.transformGroupLayout50 = (TransformGroup)target;
        //            break;
        //        case 149:
        //            this.transformGroupRender48 = (TransformGroup)target;
        //            break;
        //        case 150:
        //            this.BlackRec50 = (Rectangle)target;
        //            break;
        //        case 151:
        //            this.transformGroupLayout51 = (TransformGroup)target;
        //            break;
        //        case 152:
        //            this.transformGroupRender49 = (TransformGroup)target;
        //            break;
        //        case 153:
        //            this.BlackRec55 = (Rectangle)target;
        //            break;
        //        case 154:
        //            this.transformGroupLayout52 = (TransformGroup)target;
        //            break;
        //        case 155:
        //            this.transformGroupRender50 = (TransformGroup)target;
        //            break;
        //        case 156:
        //            this.BlackRec60 = (Rectangle)target;
        //            break;
        //        case 157:
        //            this.transformGroupLayout53 = (TransformGroup)target;
        //            break;
        //        case 158:
        //            this.transformGroupRender51 = (TransformGroup)target;
        //            break;
        //        case 159:
        //            this.BlackRec61 = (Rectangle)target;
        //            break;
        //        case 160:
        //            this.transformGroupLayout54 = (TransformGroup)target;
        //            break;
        //        case 161:
        //            this.transformGroupRender52 = (TransformGroup)target;
        //            break;
        //        case 162:
        //            this.BlackRec62 = (Rectangle)target;
        //            break;
        //        case 163:
        //            this.transformGroupLayout55 = (TransformGroup)target;
        //            break;
        //        case 164:
        //            this.transformGroupRender53 = (TransformGroup)target;
        //            break;
        //        case 165:
        //            this.BlackRec63 = (Rectangle)target;
        //            break;
        //        case 166:
        //            this.transformGroupLayout56 = (TransformGroup)target;
        //            break;
        //        case 167:
        //            this.transformGroupRender54 = (TransformGroup)target;
        //            break;
        //        case 168:
        //            this.BlackRec64 = (Rectangle)target;
        //            break;
        //        case 169:
        //            this.transformGroupLayout57 = (TransformGroup)target;
        //            break;
        //        case 170:
        //            this.transformGroupRender55 = (TransformGroup)target;
        //            break;
        //        case 171:
        //            this.BlackRec65 = (Rectangle)target;
        //            break;
        //        case 172:
        //            this.transformGroupLayout58 = (TransformGroup)target;
        //            break;
        //        case 173:
        //            this.transformGroupRender56 = (TransformGroup)target;
        //            break;
        //        case 174:
        //            this.BlackRec66 = (Rectangle)target;
        //            break;
        //        case 175:
        //            this.transformGroupLayout59 = (TransformGroup)target;
        //            break;
        //        case 176:
        //            this.transformGroupRender57 = (TransformGroup)target;
        //            break;
        //        case 177:
        //            this.BlackRec67 = (Rectangle)target;
        //            break;
        //        case 178:
        //            this.transformGroupLayout60 = (TransformGroup)target;
        //            if (3 != 0)
        //            {
        //            }
        //            break;
        //        case 179:
        //            this.transformGroupRender58 = (TransformGroup)target;
        //            break;
        //        case 180:
        //            this.BlackRec68 = (Rectangle)target;
        //            break;
        //        case 181:
        //            this.transformGroupLayout61 = (TransformGroup)target;
        //            break;
        //        case 182:
        //            this.transformGroupRender59 = (TransformGroup)target;
        //            break;
        //        case 183:
        //            this.BlackRec69 = (Rectangle)target;
        //            break;
        //        case 184:
        //            this.transformGroupLayout62 = (TransformGroup)target;
        //            break;
        //        case 185:
        //            this.transformGroupRender60 = (TransformGroup)target;
        //            break;
        //        case 186:
        //            this.BlackRec70 = (Rectangle)target;
        //            break;
        //        case 187:
        //            this.transformGroupLayout63 = (TransformGroup)target;
        //            break;
        //        case 188:
        //            this.transformGroupRender61 = (TransformGroup)target;
        //            break;
        //        case 189:
        //            this.BlackRec71 = (Rectangle)target;
        //            break;
        //        case 190:
        //            this.transformGroupLayout64 = (TransformGroup)target;
        //            break;
        //        case 191:
        //            this.transformGroupRender62 = (TransformGroup)target;
        //            break;
        //        case 192:
        //            this.BlackRec72 = (Rectangle)target;
        //            break;
        //        case 193:
        //            this.transformGroupLayout65 = (TransformGroup)target;
        //            break;
        //        case 194:
        //            this.transformGroupRender63 = (TransformGroup)target;
        //            break;
        //        case 195:
        //            this.BlackRec73 = (Rectangle)target;
        //            break;
        //        case 196:
        //            this.transformGroupLayout66 = (TransformGroup)target;
        //            break;
        //        case 197:
        //            this.transformGroupRender64 = (TransformGroup)target;
        //            break;
        //        case 198:
        //            this.BlackRec74 = (Rectangle)target;
        //            break;
        //        case 199:
        //            this.transformGroupLayout67 = (TransformGroup)target;
        //            break;
        //        case 200:
        //            this.transformGroupRender65 = (TransformGroup)target;
        //            break;
        //        case 201:
        //            this.BlackRec75 = (Rectangle)target;
        //            break;
        //        case 202:
        //            this.transformGroupLayout68 = (TransformGroup)target;
        //            break;
        //        case 203:
        //            this.transformGroupRender66 = (TransformGroup)target;
        //            break;
        //        case 204:
        //            this.BlackRec76 = (Rectangle)target;
        //            break;
        //        case 205:
        //            this.transformGroupLayout69 = (TransformGroup)target;
        //            break;
        //        case 206:
        //            this.transformGroupRender67 = (TransformGroup)target;
        //            break;
        //        case 207:
        //            this.BlackRec77 = (Rectangle)target;
        //            break;
        //        case 208:
        //            this.transformGroupLayout70 = (TransformGroup)target;
        //            break;
        //        case 209:
        //            this.transformGroupRender68 = (TransformGroup)target;
        //            break;
        //        case 210:
        //            this.BlackRec78 = (Rectangle)target;
        //            break;
        //        case 211:
        //            this.transformGroupLayout71 = (TransformGroup)target;
        //            break;
        //        case 212:
        //            this.transformGroupRender69 = (TransformGroup)target;
        //            break;
        //        case 213:
        //            this.BlackRec79 = (Rectangle)target;
        //            break;
        //        case 214:
        //            this.transformGroupLayout72 = (TransformGroup)target;
        //            break;
        //        case 215:
        //            this.transformGroupRender70 = (TransformGroup)target;
        //            break;
        //        case 216:
        //            this.RedRect = (Rectangle)target;
        //            break;
        //        case 217:
        //            this.transformGroupLayout = (TransformGroup)target;
        //            break;
        //        case 218:
        //            this.transformGroupRender = (TransformGroup)target;
        //            break;
        //        default:
        //            this._contentLoaded = true;
        //            break;
        //    }
        //    return;
        //IL_5E0:
        //    this.transformGroupRender11 = (TransformGroup)target;
        //}

        static JRotate()
        {
            // Note: this type is marked as 'beforefieldinit'.
            do
            {
                if (-1 != 0)
                {
                    JRotate.AngleProperty = DependencyProperty.Register("Angle", typeof(double), typeof(JRotate), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null, new CoerceValueCallback(JRotate.coerceValueCallback)));
                }
            }
            while (false || false || 5 == 0);
        }
    }
}
