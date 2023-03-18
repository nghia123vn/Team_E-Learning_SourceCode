using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Major
    {
        public Major()
        {
            Subjects = new HashSet<Subject>();
        }

        public string MajorId { get; set; }
        public string MajorName { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
