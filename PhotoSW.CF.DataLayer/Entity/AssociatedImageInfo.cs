using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("AssociatedImageInfo")]
    public class associatedimageinfo
        {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string KeyGenerate { get; set; }

        public string KeyNumber { get; set; }

        public string QRCode { get; set; }

        public string PS_Photos_FileName { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool IsActive { get; set; }


        }
    }
