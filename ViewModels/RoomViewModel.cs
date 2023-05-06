using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratory_Management_System.Helpers;
using Laboratory_Management_System.Models;

namespace Laboratory_Management_System.ViewModels
{
    public class RoomViewModel : BaseViewModel
    {
        public IEnumerable<Room> AllRooms;
        public IEnumerable<Room> Offices;
        public IEnumerable<Room> Labs;
        public IEnumerable<Room> Classrooms;
        public IEnumerable<String> ValidRoomTypes;
        
        public RoomViewModel() : base()
        {
            ValidRoomTypes = new List<String>() { "Office", "Lab", "Classroom" };
        }

        public async Task GetAllRooms()
        {
            AllRooms = await DatabaseService.GetItems<Room>();
        }

        public async Task GetOffices()
        {
            Query = $"SELECT * FROM {Constants.RoomTable} WHERE type = 'Office';";
            Offices = await DatabaseService.GetItemsWithQuery<Room>(Query);
        }

        public async Task GetLabs()
        {
            Query = $"SELECT * FROM {Constants.RoomTable} WHERE type = 'Lab';";
            Offices = await DatabaseService.GetItemsWithQuery<Room>(Query);
        }

        public async Task GetClassrooms()
        {
            Query = $"SELECT * FROM {Constants.RoomTable} WHERE type = 'Classroom';";
            Offices = await DatabaseService.GetItemsWithQuery<Room>(Query);
        }

        public async Task AddNewRoom(string name, string number, string building, string type)
        {
            Query = $"INSERT INTO {Constants.RoomTable} (name, number, building, type) VALUES ('{name}', '{number}', '{building}', '{type}');";
            await DatabaseService.ExecuteQuery(Query);
        }

        public async Task UpdateRoom(int id, string name, string number, string type, int buildingID)
        {
            Query = $"UPDATE {Constants.RoomTable} SET name = '{name}', number = '{number}', type = '{type}', buildingID = {buildingID} WHERE id = {id};";
            await DatabaseService.ExecuteQuery(Query);

        }

        public async Task DeleteRoom(int id)
        {
            Query = $"DELETE FROM {Constants.RoomTable} WHERE id = {id};";
            await DatabaseService.ExecuteQuery(Query);
        }
    }
}
