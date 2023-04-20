using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace Laboratory_Management_System.Models
{
    [Table("software")]
    public class Software : Item
    {
        // Primary key Id (autoincrement) inherited from Item (hopefully)

        // Attributes
        public string OS_Support { get; set; }
        public string CPU_Requirements { get; set; }
        public string Graphics_Requirements { get; set; }
        public string Memory_Requirements { get;set; }
        public double Size { get; set; }

    }
}
