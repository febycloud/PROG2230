﻿using System;
using System.Collections.Generic;

namespace A1Patients.Models
{
    public partial class DiagnosisCategory
    {
        public DiagnosisCategory()
        {
            Diagnosis = new HashSet<Diagnosis>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Diagnosis> Diagnosis { get; set; }
    }
}
