using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratory_Management_System.Helpers;
using SQLite;

namespace Laboratory_Management_System.Models
{
    [Table(Constants.ConsumableTable)]
    public class Consumable : Item
    {
        // Attributes
        public int PresentCount { get; set; }
        public int RequiredCount { get; set; }
        public string Description { get; set; }
    }
}
