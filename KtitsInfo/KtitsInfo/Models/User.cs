using System;
using System.Collections.Generic;

#nullable disable

namespace KtitsInfo.Models
{
    public partial class User
    {
        public User()
        {
            Lessons = new HashSet<Lesson>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
