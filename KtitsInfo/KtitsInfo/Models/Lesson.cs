using System;
using System.Collections.Generic;

#nullable disable

namespace KtitsInfo.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            LessonsShedules = new HashSet<LessonsShedule>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<LessonsShedule> LessonsShedules { get; set; }
    }
}
