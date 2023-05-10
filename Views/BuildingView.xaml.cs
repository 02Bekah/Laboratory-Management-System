using Laboratory_Management_System.Models;
using Laboratory_Management_System.ViewModels;
using Microsoft.Maui.Controls.Platform;

namespace Laboratory_Management_System.Views
{
    public partial class BuildingView : ContentPage
    {
        public BuildingViewModel BuildingsVM;
        public BuildingView()
        {
            InitializeComponent();

            BuildingsVM = new BuildingViewModel();

            GetBuildings().GetAwaiter();
        }

        public async Task GetBuildings()
        {
            await BuildingsVM.GetAllBuildings();

            BuildingCollection.ItemsSource = BuildingsVM.Buildings;
        }
        public async void OnAddBuildingButtonClicked(object sender, EventArgs e)
        {
            string _name = await DisplayPromptAsync("New Building", "Name");

            await BuildingsVM.AddNewBuilding(_name);

            await GetBuildings();
        }

        public async void OnBuildingCollectionSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Building building = e.CurrentSelection.LastOrDefault() as Building;
            string _action = await DisplayActionSheet($"{building.Name}", "Cancel", null, "See Rooms", "Change Name", "Delete");

            switch(_action) {
                case "Delete":
                    await BuildingsVM.DeleteBuilding(building.Id);
                    await GetBuildings();
                    break;
                case "Update":
                    string _name = await DisplayPromptAsync("Change Name", "Enter the new name:");
                    await BuildingsVM.UpdateBuilding(building.Id, _name);
                    await GetBuildings();
                    break;
                case "See Rooms":
                    var navigationParameter = new Dictionary<string, object>
                    {
                        {"building", building }
                    };

                    await Shell.Current.GoToAsync($"buildingroom", navigationParameter);
                    break;
            }
        }

    }
}
