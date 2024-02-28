using Baracoda;
using Baracoda.Cameleon.PC.Common;
using Baracoda.Cameleon.PC.Modularity.Connectivity;
using Baracoda.Cameleon.PC.Readers;
using Baracoda.Cameleon.PC.Readers.DataParsers;
using FrameworkHelper.RfidLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace PhotoSW.Views
{
    public class MainModel : SdkModelBase
    {
        private bool isUsbAvailable = true;
        private EventHandler listRefreshNeeded;
        private EventHandler<DataEventArgs> dataReceived;
        public event EventHandler ListRefreshNeeded
        {
            add
            {
                do
                {
                IL_00:
                    EventHandler eventHandler = this.listRefreshNeeded;
                    while (true)
                    {
                    IL_09:
                        EventHandler eventHandler2 = eventHandler;
                        while (true)
                        {
                            EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.listRefreshNeeded, value2, eventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (eventHandler == eventHandler2);
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
                    EventHandler eventHandler = this.listRefreshNeeded;
                    while (true)
                    {
                    IL_09:
                        EventHandler eventHandler2 = eventHandler;
                        while (true)
                        {
                            EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.listRefreshNeeded, value2, eventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (eventHandler == eventHandler2);
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

        public event EventHandler<DataEventArgs> DataReceived
        {
            add
            {
                do
                {
                IL_00:
                    EventHandler<DataEventArgs> eventHandler = this.dataReceived;
                    while (true)
                    {
                    IL_09:
                        EventHandler<DataEventArgs> eventHandler2 = eventHandler;
                        while (true)
                        {
                            EventHandler<DataEventArgs> value2 = (EventHandler<DataEventArgs>)Delegate.Combine(eventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            eventHandler = Interlocked.CompareExchange<EventHandler<DataEventArgs>>(ref this.dataReceived, value2, eventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (eventHandler == eventHandler2);
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
                    EventHandler<DataEventArgs> eventHandler = this.dataReceived;
                    while (true)
                    {
                    IL_09:
                        EventHandler<DataEventArgs> eventHandler2 = eventHandler;
                        while (true)
                        {
                            EventHandler<DataEventArgs> value2 = (EventHandler<DataEventArgs>)Delegate.Remove(eventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            eventHandler = Interlocked.CompareExchange<EventHandler<DataEventArgs>>(ref this.dataReceived, value2, eventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (eventHandler == eventHandler2);
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

        public bool IsUsbAvailable
        {
            get
            {
                return this.isUsbAvailable;
            }
            set
            {
                bool expr_10 = this.isUsbAvailable != value;
                bool flag;
                if (!false)
                {
                    flag = expr_10;
                }
                if (!flag && 3 != 0)
                {
                    goto IL_71;
                }
                if (8 != 0)
                {
                    if (false)
                    {
                        goto IL_71;
                    }
                    this.isUsbAvailable = value;
                }
            IL_34:
                if (true)
                {
                    base.SendPropertyChanged<bool>(() => this.IsUsbAvailable);
                }
            IL_71:
                if (!false)
                {
                    return;
                }
                goto IL_34;
            }
        }

        public MainModel()
        {
            this.InitUsb();
        }

        private void InitUsb()
        {
            while (true)
            {
                if (8 != 0)
                {
                    base.IsBusy = true;
                    if (!false && !false)
                    {
                        break;
                    }
                }
            }
            if (5 != 0)
            {
                UsbManager.CreateAndInitialize(new Action(this.OnUsbInit));
            }
        }

        private void OnUsbInit()
        {
            Action<UsbDevice> expr_00 = null;
            if (!false)
            {
                Action<UsbDevice> action = expr_00;
            }
            UsbManager instance;
            do
            {
                instance = UsbManager.Instance;
            }
            while (-1 == 0);
            this.IsUsbAvailable = instance.IsUsbAvailable;
            bool arg_36_0 = instance.IsUsbAvailable;
            bool expr_36;
            do
            {
                expr_36 = (arg_36_0 = !arg_36_0);
            }
            while (false);
            if (!expr_36)
            {
                try
                {
                    if (-1 == 0)
                    {
                        goto IL_A3;
                    }
                    ReadOnlyCollection<UsbDevice> devices = instance.UsbRepository.Devices;
                IL_52:
                    instance.UsbRepository.UsbDevicesStateChanged += new EventHandler<UsbDevicesStateChangedEventArgs>(this.OnUsbDevicesChanged);
                    if (3 != 0 && devices != null && devices.Count > 0)
                    {
                        IEnumerable<UsbDevice> arg_9B_0 = devices;
                        Action<UsbDevice> action = delegate(UsbDevice x)
                        {
                            BaracodaUsbReader baracodaUsbReader = new BaracodaUsbReader(x);
                            if (!false)
                            {
                                base.Readers.Add(baracodaUsbReader);
                            }
                            baracodaUsbReader.DataReceived += new EventHandler<DataReceivedEventArgs>(this.OnDataReceived);
                            baracodaUsbReader.ConnectionStateChanged += new EventHandler<ConnectionStateEventArgs>(this.OnConnectionStateChanged);
                        };
                        arg_9B_0.ApplyAction(action);
                    }
                IL_A3:
                    if (2 == 0)
                    {
                        goto IL_52;
                    }
                }
                catch (Exception x)
                {
                    
                    base.OnException(x);
                }
                if (false)
                {
                    return;
                }
            }
            base.IsBusy = false;
        }

        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            bool expr_BD;
            while (true)
            {
                while (true)
                {
                    BaracodaReaderBase baracodaReaderBase = (BaracodaReaderBase)sender;
                    bool arg_19_0 = baracodaReaderBase == null;
                    while (true)
                    {
                        bool arg_2B_0;
                        bool expr_19 = arg_19_0 = (arg_2B_0 = !arg_19_0);
                        bool flag;
                        if (6 != 0)
                        {
                            if (-1 == 0)
                            {
                                continue;
                            }
                            flag = expr_19;
                            arg_2B_0 = flag;
                        }
                        if (!arg_2B_0)
                        {
                            goto Block_2;
                        }
                        flag = !e.NeedsAck;
                        if (false)
                        {
                            break;
                        }
                        if (!flag)
                        {
                            baracodaReaderBase.AckData(true, e.Id);
                        }
                        DataContainer dataContainer = new DataContainer();
                        dataContainer.AckId = e.Id.ToString();
                        dataContainer.Id = baracodaReaderBase.Retrieved.SerialNumber;
                        dataContainer.Time = e.ReceivedTime;
                        dataContainer.Content = e.Text;
                        if (5 == 0)
                        {
                            break;
                        }
                        DataContainer rfidData = dataContainer;
                        EventHandler<DataEventArgs> dataReceived = this.dataReceived;
                        expr_BD = (arg_19_0 = (dataReceived == null));
                        if (6 != 0)
                        {
                            goto Block_6;
                        }
                    }
                }
            }
        Block_2:
            goto IL_E5;
        Block_6:
            if (!expr_BD)
            {
                BaracodaReaderBase baracodaReaderBase= (BaracodaReaderBase)sender;;
                DataContainer dataContainer = new DataContainer();
                dataContainer.AckId = e.Id.ToString();
                dataContainer.Id = baracodaReaderBase.Retrieved.SerialNumber;
                dataContainer.Time = e.ReceivedTime;
                dataContainer.Content = e.Text;
               
                DataContainer rfidData = dataContainer;
               // EventHandler<DataEventArgs> dataReceived;
                dataReceived(baracodaReaderBase, new DataEventArgs
                {
                    RfidData = rfidData
                });
            }
        IL_E4:
        IL_E5:
            if (3 != 0)
            {
                return;
            }
            goto IL_E4;
        }

        private void RaiseRefreshNeeded()
        {
            EventHandler listRefreshNeeded;
            while (-1 != 0 && 8 != 0)
            {
                if (7 != 0)
                {
                    listRefreshNeeded = this.listRefreshNeeded;
                    bool flag = listRefreshNeeded == null;
                    if (false)
                    {
                        continue;
                    }
                    if (!flag)
                    {
                        break;
                    }
                }
                return;
            }
            listRefreshNeeded(this, EventArgs.Empty);
        }

        private void OnConnectionStateChanged(object sender, ConnectionStateEventArgs e)
        {
            this.RaiseRefreshNeeded();
        }

        private void OnUsbDevicesChanged(object sender, UsbDevicesStateChangedEventArgs e)
        {
            if (e.RemovedDevices != null)
            {
                List<BaracodaReaderBase> list = base.Readers.Where(delegate(BaracodaReaderBase x)
                {
                    bool arg_37_0;
                    if (true)
                    {
                        if (!false)
                        {
                           // BaracodaReaderBase x = x;
                            arg_37_0 = e.RemovedDevices.Any((UsbDevice d) => d.Id == x.Id);
                            goto IL_37;
                        }
                    }
                IL_38:
                    while (!true)
                    {
                    }
                    bool flag;
                    bool expr_3D = arg_37_0 = flag;
                    if (!false)
                    {
                        return expr_3D;
                    }
                IL_37:
                    flag = arg_37_0;
                    goto IL_38;
                }).ToList<BaracodaReaderBase>();
                base.Readers.RemoveRange(list);
                foreach (BaracodaReaderBase current in list)
                {
                    current.ConnectionStateChanged -= new EventHandler<ConnectionStateEventArgs>(this.OnConnectionStateChanged);
                    current.DataReceived -= new EventHandler<DataReceivedEventArgs>(this.OnDataReceived);
                    base.Readers.Remove(current);
                }
            }
            if (e.AddedDevices != null)
            {
                IEnumerable<BaracodaUsbReader> enumerable = from d in e.AddedDevices
                                                            select new BaracodaUsbReader(d);
                IEnumerator<BaracodaUsbReader> enumerator2 = enumerable.GetEnumerator();
                try
                {
                    while (enumerator2.MoveNext())
                    {
                        BaracodaUsbReader current2 = enumerator2.Current;
                        base.Readers.Add(current2);
                        current2.ConnectionStateChanged += new EventHandler<ConnectionStateEventArgs>(this.OnConnectionStateChanged);
                        current2.DataReceived += new EventHandler<DataReceivedEventArgs>(this.OnDataReceived);
                    }
                }
                finally
                {
                    if (enumerator2 == null)
                    {
                        goto IL_193;
                    }
                IL_18B:
                    enumerator2.Dispose();
                IL_193:
                    if (5 == 0)
                    {
                        goto IL_18B;
                    }
                }
            }
            this.RaiseRefreshNeeded();
        }

        public new void CloseForced()
        {
            UsbManager.Instance.Dispose();
        }
    }
}
