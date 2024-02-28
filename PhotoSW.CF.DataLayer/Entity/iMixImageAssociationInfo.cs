using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("iMixImageAssociationInfo")]
    public class imiximageassociationinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long IMIXImageAssociationId { get; set; }

        public int IMIXCardTypeId { get; set; }

        public int PhotoId { get; set; }

        public string CardUniqueIdentifier { get; set; }

        public string MappedIdentifier { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
