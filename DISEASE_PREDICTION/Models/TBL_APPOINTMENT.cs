namespace DISEASE_PREDICTION.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_APPOINTMENT
    {
        [Key]
        public int APP_ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime? APP_DATE { get; set; }

        [StringLength(50)]
        public string APP_STATUS { get; set; }

        [StringLength(50)]
        public string APP_FEE_STATUS { get; set; }

        public int PATIENT_FID { get; set; }

        public int SCH_FID { get; set; }

        public virtual TBL_SCHEDULE TBL_SCHEDULE { get; set; }

        public virtual TBL_PATIENT TBL_PATIENT { get; set; }
    }
}
