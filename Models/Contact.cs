﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_Management_System.Models
{
    public abstract class Contact : BaseModel
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
    
}
