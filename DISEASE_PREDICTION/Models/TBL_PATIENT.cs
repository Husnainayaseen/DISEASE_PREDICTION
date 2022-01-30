namespace DISEASE_PREDICTION.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_PATIENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_PATIENT()
        {
            TBL_FEEDBACK = new HashSet<TBL_FEEDBACK>();
            TBL_ORDER = new HashSet<TBL_ORDER>();
        }

        [Key]
        public int PATIENT_ID { get; set; }

        public int PATIENT_AGE { get; set; }

        [Required]
        [StringLength(10)]
        public string PATIENT_GENDER { get; set; }

        [Required]
        [StringLength(50)]
        public string PATIENT_LOCATION { get; set; }

        [Required]
        [StringLength(50)]
        public string PATIENT_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string PATIENT_PhoneNo { get; set; }
            [Required]
        [StringLength(50)]
        public string PATIENT_Email { get; set; }
            [Required]
        [StringLength(50)]
        public string Patient_EmailPassword { get; set; }

        [Required]
        [StringLength(100)]
        public string PATIENT_DISEASE { get; set; }

        [Column(TypeName = "date")]
        public DateTime PATIENT_APPOINTMENTDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_FEEDBACK> TBL_FEEDBACK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ORDER> TBL_ORDER { get; set; }
    }
}
