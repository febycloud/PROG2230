using System;
using System.Collections.Generic;

namespace MvcMusicStore.Models
{
    public partial class Country
    {
        public Country()
        {
            Order = new HashSet<Order>();
            Province = new HashSet<Province>();
        }

        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string PostalPattern { get; set; }
        public string PhonePattern { get; set; }
        public string ProvinceStateLabel { get; set; }
        public double RetailTaxRate { get; set; }

        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Province> Province { get; set; }
    }
}
