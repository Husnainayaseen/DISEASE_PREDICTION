namespace DISEASE_PREDICTION.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_SPECIALIZATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_SPECIALIZATION()
        {
            TBL_DOCTOR = new HashSet<TBL_DOCTOR>();
        }

        [Key]
        public int SP_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string SPECIALIZATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_DOCTOR> TBL_DOCTOR { get; set; }
    }
}
