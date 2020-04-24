using System;
using System.Collections.Generic;

namespace Sail.Models
{
    public partial class Parking
    {
        public Parking()
        {
            Boat = new HashSet<Boat>();
        }

        public string ParkingCode { get; set; }
        public int? BoatTypeId { get; set; }
        public string ActualBoatId { get; set; }

        public virtual BoatType BoatType { get; set; }
        public virtual ICollection<Boat> Boat { get; set; }
    }
}
