using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class ResultDetail
    {
        public string ResultId { get; set; }
        public string OptionId { get; set; }
        public string QuestionId { get; set; }
        public string Question { get; set; }
        public string OptionText { get; set; }
        public bool IsCorrect { get; set; }

        public virtual QuizOption Option { get; set; }
        public virtual Result Result { get; set; }
    }
}
