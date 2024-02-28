namespace DigiPhoto
{
    using System;
    using System.Windows;

    public class BurnOrderElements
    {
        private long BurnKey;
        private string BurnOrderNumber;
        private bool IsBurnEnable;
        private Visibility IsBurnVisible;
        private Visibility IsDisableBurnVisible;
        public static bool isExecuting = false;
        private string MediaType;
        private string Status;

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
    }
}

