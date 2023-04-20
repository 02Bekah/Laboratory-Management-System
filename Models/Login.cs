using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace Laboratory_Management_System.Models
{
    public abstract class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
