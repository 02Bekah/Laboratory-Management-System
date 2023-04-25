using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratory_Management_System.Helpers;
using SQLite;

namespace Laboratory_Management_System.Models
{
    [Table(Constants.SoftwareTable)]
    public class Software : Item
    {
        // Attributes
        public string OS_Support { get; set; }
        public string CPU_Requirements { get; set; }
        public string Graphics_Requirements { get; set; }
        public string Memory_Requirements { get;set; }
        public string LicenseKey { get; set; }
        public double Size { get; set; }

    }
}
