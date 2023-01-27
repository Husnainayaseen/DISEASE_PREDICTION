namespace DISEASE_PREDICTION.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_MEDICINE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MEDICINE()
        {
            TBL_ORDERDETAIL = new HashSet<TBL_ORDERDETAIL>();
            //TBL_SYMPTOMS = new HashSet<TBL_SYMPTOMS>();
        }

        [Key]
        public int MED_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MED_NAME { get; set; }

        [Column(TypeName = "date")]
        public DateTime MED_MANUFACTURE_DATE { get; set; }

        [Column(TypeName = "date")]
        public DateTime MED_EXPIRY_DATE { get; set; }

        public int MED_SALE_PRICE { get; set; }
        [NotMapped]
        public int Quantity{ get; set; }

        [Required]
        [StringLength(100)]
        public string MED_USAGE { get; set; }

        public int MED_PURCHASE_PRICE { get; set; }

        public int DISEASECATEGORY_FID { get; set; }

        [Required]
        [StringLength(200)]
        public string MEDICINE_REACTION { get; set; }

        public int MED_COMPANY_FID { get; set; }

        [Required]
        public string MED_IMAGE { get; set; }

        public virtual TBL_DISEASECATEGORY TBL_DISEASECATEGORY { get; set; }

        public virtual TBL_MEDICINECOMPANY TBL_MEDICINECOMPANY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ORDERDETAIL> TBL_ORDERDETAIL { get; set; }

       
    }
}
