using System;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Threading;

namespace PhotoSW.Calender
{
    public class ItemTemplatePrintOrder : EntityObject, INotifyPropertyChanged, INotifyPropertyChanging
    {
        private PropertyChangedEventHandler propertyChanged;
        public new event PropertyChangedEventHandler PropertyChanged
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
        public PropertyChangingEventHandler propertyChanging;
        public new event PropertyChangingEventHandler PropertyChanging
        {
            add
            {
                do
                {
                IL_00:
                    PropertyChangingEventHandler propertyChangingEventHandler = this.propertyChanging;
                    while (true)
                    {
                    IL_09:
                        PropertyChangingEventHandler propertyChangingEventHandler2 = propertyChangingEventHandler;
                        while (true)
                        {
                            PropertyChangingEventHandler value2 = (PropertyChangingEventHandler)Delegate.Combine(propertyChangingEventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            propertyChangingEventHandler = Interlocked.CompareExchange<PropertyChangingEventHandler>(ref this.propertyChanging, value2, propertyChangingEventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (propertyChangingEventHandler == propertyChangingEventHandler2);
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
                    PropertyChangingEventHandler propertyChangingEventHandler = this.propertyChanging;
                    while (true)
                    {
                    IL_09:
                        PropertyChangingEventHandler propertyChangingEventHandler2 = propertyChangingEventHandler;
                        while (true)
                        {
                            PropertyChangingEventHandler value2 = (PropertyChangingEventHandler)Delegate.Remove(propertyChangingEventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            propertyChangingEventHandler = Interlocked.CompareExchange<PropertyChangingEventHandler>(ref this.propertyChanging, value2, propertyChangingEventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (propertyChangingEventHandler == propertyChangingEventHandler2);
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

        public static long AddPrintOrder(ItemTemplatePrintOrder order)
        {
            return 0L;
        }

        public static void GetCalenderPages(long printerQueueId, string digiFolderThumbnailPath, string templatePath)
        {
        }

        protected void NotifyPropertyChanged(string info)
        {
            do
            {
                info = info.Replace("get_", "").Replace("set_", "");
                if (!false)
                {
                    bool arg_34_0;
                    bool expr_28 = arg_34_0 = (this.propertyChanged == null);
                    if (!false)
                    {
                        bool flag = expr_28;
                        if (false)
                        {
                            goto IL_36;
                        }
                        arg_34_0 = flag;
                    }
                    if (arg_34_0)
                    {
                        break;
                    }
                }
            IL_36:
                this.propertyChanged(this, new PropertyChangedEventArgs(info));
            }
            while (2 == 0);
        }

        protected void NotifyPropertyChanging(string info)
        {
            do
            {
                info = info.Replace("get_", "").Replace("set_", "");
                if (!false)
                {
                    bool arg_34_0;
                    bool expr_28 = arg_34_0 = (this.propertyChanging == null);
                    if (!false)
                    {
                        bool flag = expr_28;
                        if (false)
                        {
                            goto IL_36;
                        }
                        arg_34_0 = flag;
                    }
                    if (arg_34_0)
                    {
                        break;
                    }
                }
            IL_36:
                this.propertyChanging(this, new PropertyChangingEventArgs(info));
            }
            while (2 == 0);
        }
    }
}
