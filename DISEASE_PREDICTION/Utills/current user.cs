﻿using DISEASE_PREDICTION.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DISEASE_PREDICTION.Utills
{
    public static class current_user
    {
        public static TBL_PATIENT currentpatient { get; set;    }
        public static TBL_ADMIN currentadmin { get; set;    }
        public static TBL_DOCTOR currentdoctor { get;set; }
    }
}