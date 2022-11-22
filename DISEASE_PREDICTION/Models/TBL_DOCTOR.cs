namespace DISEASE_PREDICTION.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_DOCTOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_DOCTOR()
        {
            TBL_SCHEDULE = new HashSet<TBL_SCHEDULE>();
        }

        [Key]
        public int DOC_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string DOC_NAME { get; set; } 
        [StringLength(50)]
        public string QUALIFICATION { get; set; }
       
        [Required]
        [StringLength(50)]
        public string DOC_EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string DOC_PASSWORD { get; set; }

        public int SP_FID { get; set; }

        [Required]
        [StringLength(10)]
        public string DOC_GENDER { get; set; }

        [Required]
        [StringLength(50)]
        public string DOC_ADDRESS { get; set; }

      
        [StringLength(50)]
        public string DOC_PIC { get; set; }

        [StringLength(50)]
        public string AVAILABLE_STATUS { get; set; }

        public virtual TBL_SPECIALIZATION TBL_SPECIALIZATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_SCHEDULE> TBL_SCHEDULE { get; set; }
    }
}
