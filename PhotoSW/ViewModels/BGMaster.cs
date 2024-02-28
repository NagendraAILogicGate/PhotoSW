using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.ViewModels
{
    public class BGMaster
    {
        private string bgName;

        private string bgDisplayName;

        private string filepath;

        private int bgID;

        private System.Collections.Generic.List<AllProductType> lstProductType;

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

        public System.Collections.Generic.List<AllProductType> LstProductType
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
