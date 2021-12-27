using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SymphonyInstitute.Ltd.Models
{

    public class Voucher
    {
        
        //public int MyProperty { get; set; }

        //public string Search { get; set; }

        public string Fname { get; set; }
        public string Lname { get; set; }
        public string CoursesName { get; set; }
        //public string Duration { get; set; }
        public string Rollno { get; set; }
        //public string ExamResult { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
       
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amountdue { get; set; }

        public bool LabSession { get; set; }
        public string ObtMarks { get; set; }
        public string TotalMarks { get; set; }
    }
}
