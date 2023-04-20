using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace Laboratory_Management_System.Models
{
    [Table("department")]
    public class Department
    {
        // Set primary key
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // Set attributes
        public Person DepartmentHead { get; set; }
    }
}
