using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_Management_System.Models
{
    public class BaseModel
    {
        // Set primary key
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // Set attibutes
        public string Name { get; set; }
    }
}
