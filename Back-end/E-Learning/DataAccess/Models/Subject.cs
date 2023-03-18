using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Courses = new HashSet<Course>();
            SubjectItems = new HashSet<SubjectItem>();
        }

        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string MajorId { get; set; }
        public string TeacherId { get; set; }
        public string StudentSemesterId { get; set; }
        public string SemesterId { get; set; }

        public virtual Major Major { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual StudentSemester StudentSemester { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<SubjectItem> SubjectItems { get; set; }
    }
}
