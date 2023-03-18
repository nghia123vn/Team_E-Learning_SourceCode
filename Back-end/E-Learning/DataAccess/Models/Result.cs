using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Result
    {
        public Result()
        {
            ResultDetails = new HashSet<ResultDetail>();
        }

        public string ResultId { get; set; }
        public string QuizId { get; set; }
        public string StudentName { get; set; }
        public int CorrectQuestion { get; set; }
        public double Point { get; set; }

        public virtual Quiz Quiz { get; set; }
        public virtual ICollection<ResultDetail> ResultDetails { get; set; }
    }
}
