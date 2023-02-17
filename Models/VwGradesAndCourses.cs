using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AnropaDB.Models
{
    public partial class VwGradesAndCourses
    {
        public string CourseName { get; set; }
        public int? AvarageGrade { get; set; }
        public int? HighestGrade { get; set; }
        public int? LowesttGrade { get; set; }
    }
}
