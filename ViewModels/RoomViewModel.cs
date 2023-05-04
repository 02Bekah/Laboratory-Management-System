using System;
using System.Collections;
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
        public IEnumerable<Room> roomList;
        
        public RoomViewModel()
        {
            _databaseService = new LocalDatabaseService();
        }

        public async Task AddNewRoom(string name, string number, string building)
        {
            string query = $"INSERT INTO {Constants.RoomTable} (name, number, building) VALUES ('{name}', '{number}', '{building}');";
            await _databaseService.ExecuteQuery(query);
        }

        public async Task GetAllRooms()
        {
             roomList = await _databaseService.GetItems<Room>();
        }
    }
}
