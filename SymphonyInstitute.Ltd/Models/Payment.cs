using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SymphonyInstitute.Ltd.Models
{
    public partial class Payment
    {
        public Payment()
        {
            CoursesEnrolled = new HashSet<CoursesEnrolled>();
        }

        public int Id { get; set; }
        public decimal Amount { get; set; }
        public decimal Amountdue { get; set; }
        public int? PaymentMethodId { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual ICollection<CoursesEnrolled> CoursesEnrolled { get; set; }
    }
}
