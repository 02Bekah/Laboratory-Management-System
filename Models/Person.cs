using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace Laboratory_Management_System.Models
{
    [Table("person")]
    public class Person : Contact
    {
        // Set primary key
        [PrimaryKey,  AutoIncrement]
        public int Id { get; set; }

        // Attributes
        public Room Office { get; set; }
    }
}
