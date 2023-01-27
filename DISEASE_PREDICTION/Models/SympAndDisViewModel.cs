using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DISEASE_PREDICTION.Models
{
    public class SympAndDisViewModel
    {
        public IEnumerable<TBL_SYMPTOMS> symp { get; set; }
        public IEnumerable<TBL_DISEASECATEGORY> dis { get; set; }
    }
}