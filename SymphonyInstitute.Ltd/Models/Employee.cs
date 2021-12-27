using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SymphonyInstitute.Ltd.Models
{
    public partial class Employee
    {
        public Employee()
        {
            CoursesEnrolled = new HashSet<CoursesEnrolled>();
        }

        public int Id { get; set; }
        public string Faculty { get; set; }
        public string Lname { get; set; }
        public string Nic { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }
        public string Experience { get; set; }
        public string MobileNumber { get; set; }
        public int? Qualificationid { get; set; }
        public int? Religionid { get; set; }
        public string AspNetUsersId { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Qualification Qualification { get; set; }
        public virtual Religion Religion { get; set; }
        public virtual ICollection<CoursesEnrolled> CoursesEnrolled { get; set; }
    }
}
