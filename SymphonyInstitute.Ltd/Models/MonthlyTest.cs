using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SymphonyInstitute.Ltd.Models
{
    public partial class MonthlyTest
    {
        public int Id { get; set; }
        public int? Courseid { get; set; }
        public int? EntryExamId { get; set; }
        public int ObtainedMarks { get; set; }

        public virtual Courses Course { get; set; }
        public virtual EntryExam EntryExam { get; set; }
    }
}
