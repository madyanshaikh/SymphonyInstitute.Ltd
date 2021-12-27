﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SymphonyInstitute.Ltd.Models
{

    public class CreateRoleViewModel
    {
       
        [Required]
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
