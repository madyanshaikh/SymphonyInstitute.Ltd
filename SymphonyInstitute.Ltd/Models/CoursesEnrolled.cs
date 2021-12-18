using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SymphonyInstitute.Ltd.Models
{
    public partial class CoursesEnrolled
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? CoursesId { get; set; }
        public int? StudentId { get; set; }
        public int? PaymentId { get; set; }
        public bool Labsession { get; set; }
        public string RollNo { get; set; }

        public virtual Courses Courses { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Student Student { get; set; }
    }
}
