using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace Laboratory_Management_System.Models
{
    [Table("manufacturer")]
    public class Manufacturer : Contact
    {
        // Set primary key
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // Attributes
        public string SupportWebsite { get; set; }
    }
}
