﻿using System;
using System.Collections.Generic;

namespace A1Patients.Models
{
    public partial class Medication
    {
        public Medication()
        {
            PatientMedication = new HashSet<PatientMedication>();
            TreatmentMedication = new HashSet<TreatmentMedication>();
        }

        public string Din { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int MedicationTypeId { get; set; }
        public string DispensingCode { get; set; }
        public double Concentration { get; set; }
        public string ConcentrationCode { get; set; }

        public virtual ConcentrationUnit ConcentrationCodeNavigation { get; set; }
        public virtual DispensingUnit DispensingCodeNavigation { get; set; }
        public virtual MedicationType MedicationType { get; set; }
        public virtual ICollection<PatientMedication> PatientMedication { get; set; }
        public virtual ICollection<TreatmentMedication> TreatmentMedication { get; set; }
    }
}
