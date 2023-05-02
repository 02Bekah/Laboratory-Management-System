using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratory_Management_System.Helpers;
using Laboratory_Management_System.Models;
using Laboratory_Management_System.Services;

namespace Laboratory_Management_System.ViewModels
{
    public class RoomViewModel
    {
        LocalDatabaseService _databaseService;
        Models.Room[] roomList;

        public RoomViewModel()
        {
            _databaseService = new LocalDatabaseService();
            //var roomList = new List<Models.Room>();
        }

        public async Task AddNewRoom(string name, string number, string building)
        {
            string query = $"INSERT INTO rooms (Name, Number, Building) VALUES ({name}, {number}, {building});";
            await _databaseService.ExecuteQuery(query);
        }

        public async Task GetAllRooms()
        {
            await roomList = _databaseService.GetItems<Room>();
        }
    }
}
