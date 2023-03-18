using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class CourseDocument
    {
        public string DocumentId { get; set; }
        public string CourseId { get; set; }
        public string Title { get; set; }
        public string Defination { get; set; }
        public string Video { get; set; }

        public virtual Course Course { get; set; }
    }
}
