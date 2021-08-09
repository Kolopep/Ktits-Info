using System;
using System.Collections.Generic;

#nullable disable

namespace KtitsInfo.Models
{
    public partial class LessonsShedule
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int CoupleId { get; set; }
        public int GroupId { get; set; }

        public virtual Couple Couple { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
