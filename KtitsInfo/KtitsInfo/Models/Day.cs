using System;
using System.Collections.Generic;

#nullable disable

namespace KtitsInfo.Models
{
    public partial class Day
    {
        public Day()
        {
            Couples = new HashSet<Couple>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Couple> Couples { get; set; }
    }
}
