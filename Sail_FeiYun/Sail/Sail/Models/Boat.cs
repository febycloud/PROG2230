using System;
using System.Collections.Generic;

namespace Sail.Models
{
    public partial class Boat
    {
        public int BoatId { get; set; }
        public int? MemberId { get; set; }
        public string BoatClass { get; set; }
        public string HullColour { get; set; }
        public string SailNumber { get; set; }
        public double? HullLength { get; set; }
        public int? BoatTypeId { get; set; }
        public string ParkingCode { get; set; }

        public virtual BoatType BoatType { get; set; }
        public virtual Member Member { get; set; }
        public virtual Parking ParkingCodeNavigation { get; set; }
    }
}
