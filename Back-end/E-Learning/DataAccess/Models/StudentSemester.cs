using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class StudentSemester
    {
        public StudentSemester()
        {
            Students = new HashSet<Student>();
            Subjects = new HashSet<Subject>();
        }

        public string StudentSemesterId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
