using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhotoSW.ViewModels
{
    public class BurnOrderElements
    {
        public static bool isExecuting = false;

        private string BurnOrderNumber;

        private string Status;

        private long BurnKey;

        private string MediaType;

        private bool IsBurnEnable;

        private Visibility IsBurnVisible;

        private Visibility IsDisableBurnVisible;

        public string BurnOrderNumber1
        {
            get
            {
                return this.BurnOrderNumber;
            }
            set
            {
                this.BurnOrderNumber = value;
            }
        }

        public string Status1
        {
            get
            {
                return this.Status;
            }
            set
            {
                this.Status = value;
            }
        }

        public long BurnKey1
        {
            get
            {
                return this.BurnKey;
            }
            set
            {
                this.BurnKey = value;
            }
        }

        public string MediaType1
        {
            get
            {
                return this.MediaType;
            }
            set
            {
                this.MediaType = value;
            }
        }

        public bool IsBurnEnable1
        {
            get
            {
                return this.IsBurnEnable;
            }
            set
            {
                this.IsBurnEnable = value;
            }
        }

        public Visibility IsBurnVisible1
        {
            get
            {
                return this.IsBurnVisible;
            }
            set
            {
                this.IsBurnVisible = value;
            }
        }

        public Visibility IsDisableBurnVisible1
        {
            get
            {
                return this.IsDisableBurnVisible;
            }
            set
            {
                this.IsDisableBurnVisible = value;
            }
        }
    }
}
