using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Laboratory_Management_System.Helpers;
using Laboratory_Management_System.Models;
using Laboratory_Management_System.Services;

namespace Laboratory_Management_System.ViewModels
{
    public class BuildingViewModel : BaseViewModel
    {
        
        public IEnumerable<Building> Buildings;

        public BuildingViewModel() : base()
        {
            DatabaseService = new LocalDatabaseService();
        }
        public async Task GetAllBuildings()
        {
            Buildings = await DatabaseService.GetItems<Building>();
        }

        public async Task AddNewBuilding(string name)
        {
            Query = $"INSERT INTO {Constants.BuildingTable} (name) VALUES ('{name}');";
            await DatabaseService.ExecuteQuery(Query);
        }

        public async Task UpdateBuilding(int id, string name)
        {
            Query = $"UPDATE {Constants.BuildingTable} SET name = '{name}' WHERE id = {id};";
            await DatabaseService.ExecuteQuery(Query);
        }

        public async Task DeleteBuilding(int id)
        {
            await DeleteRoomsInBuilding(id);

            Query = $"DELETE FROM {Constants.BuildingTable} WHERE id = {id};";
            await DatabaseService.ExecuteQuery(Query);
        }

        public async Task DeleteRoomsInBuilding(int id)
        {
            Query = $"DELETE FROM {Constants.RoomTable} WHERE buildingid = {id};";
            await DatabaseService.ExecuteQuery(Query);
        }

    }
}
