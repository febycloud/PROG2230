using System;
using System.Collections.Generic;

namespace Sail.Models
{
    public partial class Tasks
    {
        public Tasks()
        {
            MemberTask = new HashSet<MemberTask>();
        }

        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MemberTask> MemberTask { get; set; }
    }
}
