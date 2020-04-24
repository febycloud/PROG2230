using System;
using System.Collections.Generic;

namespace Sail.Models
{
    public partial class Province
    {
        public Province()
        {
            Member = new HashSet<Member>();
        }

        public string ProvinceCode { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string TaxCode { get; set; }
        public double TaxRate { get; set; }
        public string Capital { get; set; }
        public bool IncludesFerderalTax { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual ICollection<Member> Member { get; set; }
    }
}
