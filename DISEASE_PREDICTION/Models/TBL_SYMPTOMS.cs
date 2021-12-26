namespace DISEASE_PREDICTION.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_SYMPTOMS
    {
        [Key]
        public int SYMPTOM_ID { get; set; }

        [Required]
        [StringLength(200)]
        public string DISEASE_SYMPTOMS { get; set; }

        public int MED_FID { get; set; }

        public virtual TBL_MEDICINE TBL_MEDICINE { get; set; }
    }
}
