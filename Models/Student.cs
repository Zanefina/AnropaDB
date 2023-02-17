using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AnropaDB.Models
{
    public partial class Student
    {
        public Student()
        {
            CourseStudent = new HashSet<CourseStudent>();
            Grade = new HashSet<Grade>();
        }

        public int StudentId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string PersonalNumber { get; set; }
        public string Email { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual ICollection<CourseStudent> CourseStudent { get; set; }
        public virtual ICollection<Grade> Grade { get; set; }
    }
}
