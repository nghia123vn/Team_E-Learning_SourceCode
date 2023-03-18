using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseDocuments = new HashSet<CourseDocument>();
            Quizzes = new HashSet<Quiz>();
        }

        public string CourseId { get; set; }
        public string TeacherId { get; set; }
        public DateTime Time { get; set; }
        public string SubjectId { get; set; }
        public string LinkCourse { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<CourseDocument> CourseDocuments { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
