namespace DigiPhoto
{
    using System;

    public class AllGraphics : ICloneable
    {
        private string Filepath;
        private string GraphicsDisplayName;
        private string GraphicsName;
        private bool IsActive;
        private int Pkey;

        public object Clone()
        {
            return base.MemberwiseClone();
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

        public string IsActiveLabel
        {
            get
            {
                if (this.IsActive1)
                {
                    return "Active";
                }
                return "InActive";
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
    }
}

