using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AnropaDB.Models
{
    public partial class Grade
    {
        public int GradeId { get; set; }
        public int Grades { get; set; }
        public DateTime Date { get; set; }
        public int StaffId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Student Student { get; set; }
    }
}
