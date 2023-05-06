using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratory_Management_System.Helpers;
using Laboratory_Management_System.Models;
using Laboratory_Management_System.Services;

namespace Laboratory_Management_System.ViewModels
{
    public class BuildingViewModel : INotifyPropertyChanged
    {

        public LocalDatabaseService DatabaseService;
        public string Query;
        public IEnumerable<Building> Buildings;

        public event PropertyChangedEventHandler PropertyChanged;

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
            Query = $"DELETE FROM {Constants.BuildingTable} WHERE id = {id};";
            await DatabaseService.ExecuteQuery(Query);
        }


    }
}
