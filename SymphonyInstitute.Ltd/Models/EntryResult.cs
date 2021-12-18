using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SymphonyInstitute.Ltd.Models
{
    public partial class EntryResult
    {
        public EntryResult()
        {
            InverseStudent = new HashSet<EntryResult>();
        }

        public int Id { get; set; }
        public int? EntryExamId { get; set; }
        public int? StudentId { get; set; }
        public int ObtMarks { get; set; }

        public virtual EntryExam EntryExam { get; set; }
        public virtual EntryResult Student { get; set; }
        public virtual ICollection<EntryResult> InverseStudent { get; set; }
    }
}
