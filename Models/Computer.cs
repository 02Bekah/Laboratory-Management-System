using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace Laboratory_Management_System.Models
{
    [Table("computer")]
    internal class Computer : Item
    {
        // Attributes
        public string OperatingSystem { get; set; }
        public Login[] Accounts { get; set; }
        public Software[] Softwares { get; set; }
    }
}
