namespace DISEASE_PREDICTION.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_SCHEDULE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_SCHEDULE()
        {
            TBL_APPOINTMENT = new HashSet<TBL_APPOINTMENT>();
        }

        [Key]
        public int SCH_ID { get; set; }

        public int SCH_DAY_FID { get; set; }

        [StringLength(50)]
        public string FEE { get; set; }

        public TimeSpan? START_TIME { get; set; }

        public TimeSpan? END_TIME { get; set; }

        [StringLength(50)]
        public string MAX_APP { get; set; }

        public int DOC_FID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_APPOINTMENT> TBL_APPOINTMENT { get; set; }

        public virtual TBL_DOCTOR TBL_DOCTOR { get; set; }

        public virtual TBL_SCH_DAY TBL_SCH_DAY { get; set; }
    }
}
