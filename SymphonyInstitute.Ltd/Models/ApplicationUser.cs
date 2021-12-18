using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SymphonyInstitute.Ltd.Models
{
    public class ApplicationUser : IdentityUser
    {

        [NotMapped]
        public string Password { get; set; }


    }
}
