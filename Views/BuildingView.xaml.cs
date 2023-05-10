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

            if (_name is not null)
            {
                bool _confirm = await DisplayAlert("Confirm", "Add building " + _name + "?", "Yes", "No");

                if (_confirm)
                {
                    await BuildingsVM.AddNewBuilding(_name);
                }
            }

            await GetBuildings();
        }

        public async void OnBuildingCollectionSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool _confirm;
            Building building = e.CurrentSelection.LastOrDefault() as Building;
            string _action = await DisplayActionSheet($"{building.Name}", "Cancel", null, "See Rooms", "Change Name", "Delete");

            switch (_action) {
                case "Delete":
                    _confirm = await DisplayAlert("Confirm", "Delete building " + building.Name + "?", "Yes", "No");

                    if (_confirm)
                    {
                        await BuildingsVM.DeleteBuilding(building.Id);
                        await GetBuildings();
                    }
                    
                    break;
                case "Change Name":
                    //await Navigation.PushModalAsync(new UpdateBuildingView(building));
                    string _name = await DisplayPromptAsync($"{building.Name}", "Enter the New Name", "Save", "Cancel");
                    if (_name is not null) {
                        _confirm = await DisplayAlert("Confirm", "Change " + building.Name + " to " + _name + "?", "Yes", "No");
                        if (_confirm)
                        {
                            await BuildingsVM.UpdateBuilding(building.Id, _name);
                            await GetBuildings();
                        }
                    }
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
