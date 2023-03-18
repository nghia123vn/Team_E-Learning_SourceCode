using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Subjects = new HashSet<Subject>();
        }

        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
