namespace DISEASE_PREDICTION.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_SCH_DAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_SCH_DAY()
        {
            TBL_SCHEDULE = new HashSet<TBL_SCHEDULE>();
        }

        [Key]
        public int SCH_DAY_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string SCH_DAY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_SCHEDULE> TBL_SCHEDULE { get; set; }
    }
}
