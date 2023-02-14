namespace DISEASE_PREDICTION.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_SYMPTOMS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_SYMPTOMS()
        {
            TBL_DISEASE_SYMPTOM = new HashSet<TBL_DISEASE_SYMPTOM>();
        }

        [Key]
        public int SYMPTOM_ID { get; set; }

        [Required]
        [StringLength(200)]
        public string DISEASE_SYMPTOMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_DISEASE_SYMPTOM> TBL_DISEASE_SYMPTOM { get; set; }
    }
}
