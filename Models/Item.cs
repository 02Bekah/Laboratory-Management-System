using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace Laboratory_Management_System.Models
{
    [Table("item")]
    public class Item
    {
        // Set primary key
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // Set attributes
        public string Name { get; set; }
        public string Model { get; set; }
        public string Version { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Department Department { get; set; }
        public Room Location { get; set; }
    }
}
