namespace DigiPhoto
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows;

    public class AllProductType
    {
        private Visibility Isvisible;
        private int ProductId;
        private string ProductName;

        public int BGId { get; set; }

        public Visibility Isvisible1
        {
            get
            {
                return this.Isvisible;
            }
            set
            {
                this.Isvisible = value;
            }
        }

        public int ProductId1
        {
            get
            {
                return this.ProductId;
            }
            set
            {
                this.ProductId = value;
            }
        }

        public string ProductName1
        {
            get
            {
                return this.ProductName;
            }
            set
            {
                this.ProductName = value;
            }
        }
    }
}

