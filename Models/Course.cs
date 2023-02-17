using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AnropaDB.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseStudent = new HashSet<CourseStudent>();
            Grade = new HashSet<Grade>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int StaffId { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual ICollection<CourseStudent> CourseStudent { get; set; }
        public virtual ICollection<Grade> Grade { get; set; }
    }
}
