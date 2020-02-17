﻿using System;
using System.Collections.Generic;

namespace A1Patients.Models
{
    public partial class MedicationType
    {
        public MedicationType()
        {
            Medication = new HashSet<Medication>();
        }

        public int MedicationTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Medication> Medication { get; set; }
    }
}
