using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AnropaDB.Models
{
    public partial class VwStudentsbyClass
    {
        public int StudentId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string ClassName { get; set; }
    }
}
