namespace DigiPhoto
{
    using System;
    using System.Collections.Generic;

    public class BGMaster
    {
        private string bgDisplayName;
        private int bgID;
        private string bgName;
        private string filepath;
        private List<AllProductType> lstProductType;

        public string BgDisplayName
        {
            get
            {
                return this.bgDisplayName;
            }
            set
            {
                this.bgDisplayName = value;
            }
        }

        public int BgID
        {
            get
            {
                return this.bgID;
            }
            set
            {
                this.bgID = value;
            }
        }

        public string BgName
        {
            get
            {
                return this.bgName;
            }
            set
            {
                this.bgName = value;
            }
        }

        public string Filepath
        {
            get
            {
                return this.filepath;
            }
            set
            {
                this.filepath = value;
            }
        }

        public List<AllProductType> LstProductType
        {
            get
            {
                return this.lstProductType;
            }
            set
            {
                this.lstProductType = value;
            }
        }
    }
}

