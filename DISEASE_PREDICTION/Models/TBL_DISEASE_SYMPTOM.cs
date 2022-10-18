namespace DISEASE_PREDICTION.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_DISEASE_SYMPTOM
    {
        [Key]
        public int DIS_SYMP_ID { get; set; }

        public int SYMPTOM_FID { get; set; }

        public int DISEASE_FID { get; set; }

        public virtual TBL_DISEASECATEGORY TBL_DISEASECATEGORY { get; set; }

        public virtual TBL_SYMPTOMS TBL_SYMPTOMS { get; set; }
    }
}
