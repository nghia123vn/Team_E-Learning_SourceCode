using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Student
    {

        public Student()
        {
            SubjectItems = new HashSet<SubjectItem>();
        }

        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string StudentSemesterId { get; set; }

        public virtual StudentSemester StudentSemester { get; set; }
        public virtual ICollection<SubjectItem> SubjectItems { get; set; }
    }
}
