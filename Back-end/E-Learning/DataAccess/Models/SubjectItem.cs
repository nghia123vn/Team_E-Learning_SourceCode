using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class SubjectItem
    {
        public string SubjectId { get; set; }
        public string StudentId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
