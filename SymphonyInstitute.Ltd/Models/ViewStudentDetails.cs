using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SymphonyInstitute.Ltd.Models
{
    public partial class ViewStudentDetails
    {
        
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string CoursesName { get; set; }
        public string Rollno { get; set; }
        public bool? Labsession { get; set; }
        public string Faculty { get; set; }
        public decimal Amount { get; set; }
        public decimal Amountdue { get; set; }
        public int? ObtMarks { get; set; }
        public int? TotalMarks { get; set; }
    }
}
