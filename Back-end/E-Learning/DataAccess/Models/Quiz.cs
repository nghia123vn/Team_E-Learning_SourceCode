using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            QuizQuestions = new HashSet<QuizQuestion>();
            Results = new HashSet<Result>();
        }

        public string QuizId { get; set; }
        public string StudentName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<QuizQuestion> QuizQuestions { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
