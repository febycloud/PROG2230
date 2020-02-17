using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMusicStore.Models
{
    public class Generic2String
    {
        public Generic2String( string key, string value)
        {
            this.key = key;
            this.value = value;
        }

        public string key { get; set; }

        public string value { get; set; }
    }
}
