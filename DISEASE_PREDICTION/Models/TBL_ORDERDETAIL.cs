namespace DISEASE_PREDICTION.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_ORDERDETAIL
    {
        [Key]
        public int ORDERDETAIL_ID { get; set; }

        public int ORDER_FID { get; set; }

        public int MEDICINE_FID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal MED_PURCHASE_PRICE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal MED_SALE_PRICE { get; set; }

        [Required]
        //[StringLength(50)]
        public int MED_QUANTITY { get; set; }

        public virtual TBL_MEDICINE TBL_MEDICINE { get; set; }

        public virtual TBL_ORDER TBL_ORDER { get; set; }
    }
}
