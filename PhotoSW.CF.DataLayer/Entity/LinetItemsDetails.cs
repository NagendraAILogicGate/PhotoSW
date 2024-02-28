using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("LinetItemsDetails")]
    public class LinetItemsDetails
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        private string productname;

		private string productprice;

		private string productquantity;

        //public string Productname
        //{
        //    get
        //    {
        //        return this.productname;
        //    }
        //    set
        //    {
        //        this.productname = value;
        //    }
        //}

		public string Productprice
		{
			get
			{
				return this.productprice;
			}
			set
			{
				this.productprice = value;
			}
		}

		public string Productquantity
		{
			get
			{
				return this.productquantity;
			}
			set
			{
				this.productquantity = value;
			}
		}

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
