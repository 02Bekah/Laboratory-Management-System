using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratory_Management_System.Helpers;
using SQLite;

namespace Laboratory_Management_System.Models
{
    [Table(Constants.RoomTable)]
    public class Room : BaseModel
    {
        // Attributes
        public string Building { get; set; }
        public string Number { get; set; }
    }
}
