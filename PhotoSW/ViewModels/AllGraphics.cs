using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.ViewModels
{
    public class AllGraphics : System.ICloneable
    {
        private string GraphicsName;

        private string GraphicsDisplayName;

        private bool IsActive;

        private string Filepath;

        private int Pkey;

        public string GraphicsName1
        {
            get
            {
                return this.GraphicsName;
            }
            set
            {
                this.GraphicsName = value;
            }
        }

        public string GraphicsDisplayName1
        {
            get
            {
                return this.GraphicsDisplayName;
            }
            set
            {
                this.GraphicsDisplayName = value;
            }
        }

        public bool IsActive1
        {
            get
            {
                return this.IsActive;
            }
            set
            {
                this.IsActive = value;
            }
        }

        public string Filepath1
        {
            get
            {
                return this.Filepath;
            }
            set
            {
                this.Filepath = value;
            }
        }

        public int Pkey1
        {
            get
            {
                return this.Pkey;
            }
            set
            {
                this.Pkey = value;
            }
        }

        public string IsActiveLabel
        {
            get
            {
                string result;
                if (this.IsActive1)
                {
                    result = "Active";
                }
                else
                {
                    result = "InActive";
                }
                return result;
            }
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }
    }
}
