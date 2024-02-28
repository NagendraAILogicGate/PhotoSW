using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhotoSW.ViewModels
{
    public class AllProductType
    {
        private string ProductName;

        private int ProductId;

        private Visibility Isvisible;

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

        public int BGId
        {
            get;
            set;
        }
    }
}
