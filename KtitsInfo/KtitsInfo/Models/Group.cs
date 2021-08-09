using System;
using System.Collections.Generic;

#nullable disable

namespace KtitsInfo.Models
{
    public partial class Group
    {
        public Group()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public string Specialization { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
