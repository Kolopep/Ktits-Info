using System;
using System.Collections.Generic;

#nullable disable

namespace KtitsInfo.Models
{
    public partial class Couple
    {
        public Couple()
        {
            LessonsShedules = new HashSet<LessonsShedule>();
        }

        public int Id { get; set; }
        public int? Number { get; set; }
        public int? DayId { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual Day Day { get; set; }
        public virtual ICollection<LessonsShedule> LessonsShedules { get; set; }
    }
}
