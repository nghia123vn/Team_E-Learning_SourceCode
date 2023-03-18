using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class QuizQuestion
    {
        public QuizQuestion()
        {
            QuizOptions = new HashSet<QuizOption>();
        }

        public string QuestionId { get; set; }
        public string QuizId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public virtual Quiz Quiz { get; set; }
        public virtual ICollection<QuizOption> QuizOptions { get; set; }
    }
}
