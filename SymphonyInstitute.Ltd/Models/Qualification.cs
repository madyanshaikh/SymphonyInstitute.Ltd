using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SymphonyInstitute.Ltd.Models
{
    public partial class Qualification
    {
        public Qualification()
        {
            Employee = new HashSet<Employee>();
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Qualification1 { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
