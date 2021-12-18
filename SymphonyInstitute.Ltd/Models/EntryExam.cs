using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SymphonyInstitute.Ltd.Models
{
    public partial class EntryExam
    {
        public EntryExam()
        {
            EntryResult = new HashSet<EntryResult>();
            MonthlyTest = new HashSet<MonthlyTest>();
        }

        public int Id { get; set; }
        public bool Examonducted { get; set; }
        public int TotalMarks { get; set; }

        public virtual ICollection<EntryResult> EntryResult { get; set; }
        public virtual ICollection<MonthlyTest> MonthlyTest { get; set; }
    }
}
