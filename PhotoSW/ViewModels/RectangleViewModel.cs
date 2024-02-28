using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace PhotoSW.ViewModels
{
    public class RectangleViewModel : INotifyPropertyChanged
    {
        private double x = 0.0;

        private double y = 0.0;

        private double width = 0.0;

        private double height = 0.0;

        private Color color;

        private Point connectorHotspot;
        private PropertyChangedEventHandler propertyChanged;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                do
                {
                IL_00:
                    PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChanged;
                    while (true)
                    {
                    IL_09:
                        PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
                        while (true)
                        {
                            PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChanged, value2, propertyChangedEventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (propertyChangedEventHandler == propertyChangedEventHandler2);
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
                    PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChanged;
                    while (true)
                    {
                    IL_09:
                        PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
                        while (true)
                        {
                            PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChanged, value2, propertyChangedEventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (propertyChangedEventHandler == propertyChangedEventHandler2);
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

        public double X
        {
            get
            {
                return this.x;
            }
            set
            {
                if (this.x != value)
                {
                    this.x = value;
                    string expr_23 = "X";
                    if (!false)
                    {
                        this.OnPropertyChanged(expr_23);
                    }
                }
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }
            set
            {
                if (this.y != value)
                {
                    this.y = value;
                    string expr_23 = "Y";
                    if (!false)
                    {
                        this.OnPropertyChanged(expr_23);
                    }
                }
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (this.width != value)
                {
                    this.width = value;
                    string expr_23 = "Width";
                    if (!false)
                    {
                        this.OnPropertyChanged(expr_23);
                    }
                }
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (this.height != value)
                {
                    this.height = value;
                    string expr_23 = "Height";
                    if (!false)
                    {
                        this.OnPropertyChanged(expr_23);
                    }
                }
            }
        }

        public Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                if (!(this.color == value))
                {
                    this.color = value;
                    string expr_23 = "Color";
                    if (!false)
                    {
                        this.OnPropertyChanged(expr_23);
                    }
                }
            }
        }

        public Point ConnectorHotspot
        {
            get
            {
                return this.connectorHotspot;
            }
            set
            {
                if (!(this.connectorHotspot == value))
                {
                    this.connectorHotspot = value;
                    string expr_23 = "ConnectorHotspot";
                    if (!false)
                    {
                        this.OnPropertyChanged(expr_23);
                    }
                }
            }
        }

        public RectangleViewModel()
        {
        }

        public RectangleViewModel(double x, double y, double width, double height, Color color)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.color = color;
        }

        protected void OnPropertyChanged(string name)
        {
            if (!false)
            {
                bool arg_15_0;
                bool expr_0C = arg_15_0 = (this.propertyChanged == null);
                if (!false)
                {
                    bool flag = expr_0C;
                    arg_15_0 = flag;
                }
                if (arg_15_0)
                {
                    return;
                }
            }
            do
            {
                do
                {
                    this.propertyChanged(this, new PropertyChangedEventArgs(name));
                }
                while (false);
            }
            while (-1 == 0);
        }
    }
}
