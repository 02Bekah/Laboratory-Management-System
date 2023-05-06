using Laboratory_Management_System.Services;
using Laboratory_Management_System.Models;
using Laboratory_Management_System.ViewModels;
using System.Windows.Input;
using Microsoft.Maui.Controls.Xaml;

namespace Laboratory_Management_System.Views
{
    public partial class EditLocationView : ContentPage
    {
        public BuildingViewModel Buildings;
        public RoomViewModel Rooms;

        public EditLocationView()
        {
            InitializeComponent();

            Buildings = new BuildingViewModel();
            Rooms = new RoomViewModel();

            GetBuildings().GetAwaiter();
        }

        public async Task GetBuildings()
        {
            await Buildings.GetAllBuildings();

            BuildingCollection.ItemsSource = Buildings.Buildings;
        }
        public async void OnAddBuildingButtonClicked(object sender, EventArgs e)
        {
            string _name = await DisplayPromptAsync("New Building", "Name");

            await Buildings.AddNewBuilding(_name);

            await GetBuildings();
        }

        public async void OnUpdateBuildingButtonClicked(object sender, EventArgs e)
        {
            BuildingCollection.ItemsSource = Buildings.Buildings;
            int _id = 0; // id selected from .xaml
            string _name = "";

            await Buildings.UpdateBuilding(_id, _name);
        }

        public async void OnDeleteBuildingButtonClicked(object sender, EventArgs e)
        {
            int _id = 0;

            await Buildings.DeleteBuilding(_id);

        }

        public async Task GetAllRooms()
        {
            await Rooms.GetAllRooms();
            // Set item source
        }

        public async Task GetRooms(string type)
        {
            IEnumerable<Room> source;

            switch(type)
            {
                case "Office":
                    await Rooms.GetOffices();
                    source = Rooms.Offices;
                    break;
                case "Lab":
                    await Rooms.GetLabs();
                    source = Rooms.Labs;
                    break;
                case "Classroom":
                    await Rooms.GetClassrooms();
                    source = Rooms.Classrooms;
                    break;
            } // End switch(type)

            // Set item source
        } // End method GetRooms(string type)

        public async void OnUpdateRoomButtonClicked(object sender, EventArgs e)
        {
            int _id = 0; // id selected from .xaml
            string _name = ""; // entry text from .xaml
            string _number = ""; // entry text from .xaml
            string _type = ""; // entry text from .xaml
            int _buildingID = 0; // entry text from .xaml

            await Rooms.UpdateRoom(_id, _name, _number, _type, _buildingID);
        }

        public async void OnDeleteRoomButtonClicked(object sender, EventArgs e)
        {
            int _id = 0; // id selected from .xaml

            await Rooms.DeleteRoom(_id);
        }

        public void OnBuildingCollectionSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var previous = e.PreviousSelection;
            var current = e.CurrentSelection;
        }
    }
}
