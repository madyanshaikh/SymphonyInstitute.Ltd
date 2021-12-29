using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SymphonyInstitute.Ltd.Models
{
    public partial class Student 
    {
        public Student()
        {
            CoursesEnrolled = new HashSet<CoursesEnrolled>();
        }

        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Nic { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public string GuradianNumber { get; set; }
        public bool? RequestConfirm { get; set; }
        public string MobileNumber { get; set; }
        public int? Qualificationid { get; set; }
        public int? Religionid { get; set; }
        public string AspNetUsersId { get; set; }   
        [NotMapped]
        public string Email { get; set; }
        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [NotMapped]
        public int Qualifications { get; set; }
        [NotMapped]
        public int religion { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Qualification Qualification { get; set; }
        public virtual Religion Religion { get; set; }
        public virtual ICollection<CoursesEnrolled> CoursesEnrolled { get; set; }
    }
}
