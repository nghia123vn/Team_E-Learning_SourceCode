using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class QuizOption
    {
        public QuizOption()
        {
            ResultDetails = new HashSet<ResultDetail>();
        }

        public string OptionId { get; set; }
        public string QuestionId { get; set; }
        public string OptionText { get; set; }

        public virtual QuizQuestion Question { get; set; }
        public virtual ICollection<ResultDetail> ResultDetails { get; set; }
    }
}
