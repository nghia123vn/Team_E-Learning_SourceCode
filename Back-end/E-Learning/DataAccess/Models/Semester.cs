using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Semester
    {
        public Semester()
        {
            Subjects = new HashSet<Subject>();
        }

        public string SemesterId { get; set; }
        public string SemesterName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
