namespace DISEASE_PREDICTION.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_ORDER()
        {
            TBL_ORDERDETAIL = new HashSet<TBL_ORDERDETAIL>();
        }

        [Key]
        public int ORDER_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ORDER_NAME { get; set; }

        [Column(TypeName = "date")]
        public DateTime ORDER_DATE { get; set; }

        [Required]
        [StringLength(50)]
        public string ORDER_STATUS { get; set; }

        [Required]
        [StringLength(50)]
        public string ORDER_TYPE { get; set; }

        [Required]
        [StringLength(50)]
        public string ORDER_EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string ORDER_ADDRESS { get; set; }

        [Required]
        [StringLength(50)]
        public string ORDER_CONTACT { get; set; }

        public int PATIENT_FID { get; set; }

        [Required]
        [StringLength(50)]
        public string STATUS { get; set; }

        public virtual TBL_PATIENT TBL_PATIENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ORDERDETAIL> TBL_ORDERDETAIL { get; set; }
    }
}
