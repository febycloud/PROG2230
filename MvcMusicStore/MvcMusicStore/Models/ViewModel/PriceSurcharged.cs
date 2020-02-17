using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMusicStore.Models
{
    public class PriceSurcharged
    {
        public string Title { get; set; }

        public string Artist { get; set; }

        public double Price { get; set; }

        public double SurchargedPrice { get; set; }
    }
}
