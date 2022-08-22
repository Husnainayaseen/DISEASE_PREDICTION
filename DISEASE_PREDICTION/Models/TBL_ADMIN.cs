namespace DISEASE_PREDICTION.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_ADMIN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_ADMIN()
        {
            TBL_ORDER = new HashSet<TBL_ORDER>();
        }

        [Key]
        public int ADMIN_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_PASSWORD { get; set; }

        [StringLength(50)]
        public string ADMIN_CONTACT { get; set; }

        [StringLength(100)]
        public string ADMIN_ADDRESS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ORDER> TBL_ORDER { get; set; }
    }
}
