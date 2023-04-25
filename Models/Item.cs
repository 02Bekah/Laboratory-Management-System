using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratory_Management_System.Helpers;
using SQLite;

namespace Laboratory_Management_System.Models
{
    [Table(Constants.ItemTable)]
    public class Item : BaseModel
    {
        // Set attributes
        public string Model { get; set; }
        public string Version { get; set; }
        public string SerialNumber { get; set; }
        public string ManufactureDate { get; set; }
        public string PurchaseDate { get; set; }
        public int ManufacturerID { get; set; }
        public int DepartmentID { get; set; }
        public int LocationID { get; set; }
    }
}
