using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SymphonyInstitute.Ltd.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Payment = new HashSet<Payment>();
        }

        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PayMethod { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }
    }
}
