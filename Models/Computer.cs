using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratory_Management_System.Helpers;
using SQLite;

namespace Laboratory_Management_System.Models
{
    [Table(Constants.ComputerTable)]
    public class Computer : Item
    {
        // Attributes
        public string OperatingSystem { get; set; }
        public Login Account { get; set; }
        public string Software { get; set; }
    }
}
