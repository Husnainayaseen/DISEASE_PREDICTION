namespace DISEASE_PREDICTION.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_DISEASECATEGORY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_DISEASECATEGORY()
        {
            TBL_DISEASE_SYMPTOM = new HashSet<TBL_DISEASE_SYMPTOM>();
            TBL_MEDICINE = new HashSet<TBL_MEDICINE>();
        }

        [Key]
        public int DISEASE_ID { get; set; }

        [StringLength(50)]
        public string DISEASE_DESCRIPTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_DISEASE_SYMPTOM> TBL_DISEASE_SYMPTOM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MEDICINE> TBL_MEDICINE { get; set; }
    }
}
