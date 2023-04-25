using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratory_Management_System.Helpers;
using SQLite;

namespace Laboratory_Management_System.Models
{
    [Table(Constants.PersonTable)]
    public class Person : Contact
    {
        // Attributes
        public int OfficeID { get; set; }
    }
}
