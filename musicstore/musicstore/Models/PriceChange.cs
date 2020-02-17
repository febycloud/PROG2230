using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicstore.Models
{
    public class PriceChange
    {
        public string Title { get; set; }
        public string Aritist { get; set; }
        public double Price { get; set; }
       public double taxPrice { get; set; }
    }
}
