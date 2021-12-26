namespace DISEASE_PREDICTION.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_MEDICINECOMPANY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MEDICINECOMPANY()
        {
            TBL_MEDICINE = new HashSet<TBL_MEDICINE>();
        }

        [Key]
        public int COMPANY_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string COMPANY_NAME { get; set; }

        //[Column(TypeName = "image")]
        //public byte[] COMPANY_LOGO { get; set; }

        [StringLength(50)]
        public string COMPANY_LOCATION { get; set; }

        [StringLength(50)]
        public string COMPANY_LICENSE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MEDICINE> TBL_MEDICINE { get; set; }
    }
}
