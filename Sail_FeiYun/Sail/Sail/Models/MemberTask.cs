using System;
using System.Collections.Generic;

namespace Sail.Models
{
    public partial class MemberTask
    {
        public int MemberTaskId { get; set; }
        public DateTime? WednesdayDate { get; set; }
        public int? TaskId { get; set; }
        public int? MemberId { get; set; }
        public string Comment { get; set; }

        public virtual Member Member { get; set; }
        public virtual Tasks Task { get; set; }
    }
}
