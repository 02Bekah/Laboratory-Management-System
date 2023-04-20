using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace Laboratory_Management_System.Models
{
    [Table("room")]
    public class Room
    {
        // Set primary key
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // Attributes
        public string name { get; set; }
        public string building { get; set; }
        public string number { get; set; }
    }
}
