using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Admin
    {
        public string AdminId { get; set; }
        public string AdminName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
