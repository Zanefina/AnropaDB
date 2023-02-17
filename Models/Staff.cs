using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AnropaDB.Models
{
    public partial class Staff
    {
        public Staff()
        {
            Course = new HashSet<Course>();
            Grade = new HashSet<Grade>();
        }

        public int StaffId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime StartDate { get; set; }
        public int? Salary { get; set; }

        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<Grade> Grade { get; set; }
    }
}
