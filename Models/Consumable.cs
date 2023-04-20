using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace Laboratory_Management_System.Models
{
    [Table("consumable")]
    public class Consumable : Item
    {
        // Attributes
        public int PresentCount { get; set; }
        public int RequiredCount { get; set; }
        public string Description { get; set; }
    }
}
