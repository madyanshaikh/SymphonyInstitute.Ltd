using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SymphonyInstitute.Ltd.Models
{
    public partial class Courses
    {
        public Courses()
        {
            CoursesEnrolled = new HashSet<CoursesEnrolled>();
            MonthlyTest = new HashSet<MonthlyTest>();
        }

        public int Id { get; set; }
        public string CoursesName { get; set; }
        public string CourseCode { get; set; }

        public virtual ICollection<CoursesEnrolled> CoursesEnrolled { get; set; }
        public virtual ICollection<MonthlyTest> MonthlyTest { get; set; }
    }
}
