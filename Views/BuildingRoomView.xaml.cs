using Laboratory_Management_System.Models;
using Laboratory_Management_System.ViewModels;

namespace Laboratory_Management_System.Views
{
    [QueryProperty(nameof(Building), "building")]
    public partial class BuildingRoomView : ContentPage
    {
        // Working
        public int _buildingID;
        // Not working but should be
        Building _building;
        public Building Building
        {
            get
            {
                return _building;
            }
            set
            {
                // Working
                _buildingID = value.Id;
                // Not working but should be
                _building = value;
            }
        }
        
        public IEnumerable<Room> Rooms;
        public RoomViewModel RoomVM;
        public BuildingViewModel BuildingVM;

        public BuildingRoomView()
        {
            InitializeComponent();

            RoomVM = new RoomViewModel();
            BindingContext = this;

            GetRooms().GetAwaiter();

        }

        public async Task GetRooms()
        {
            // _buildingID is not initialized during first call
            await RoomVM.GetRoomsByBuilding(_buildingID);
            await RoomVM.GetRoomsByBuilding(_buildingID);

            RoomCollection.ItemsSource = RoomVM.RoomsInBuilding;
        }


        public async void OnRoomCollectionSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool _confirm;
            Room room = e.CurrentSelection.LastOrDefault() as Room;
            string _action = await DisplayActionSheet($"{room.Name}", "Cancel", null, "Delete");

            switch (_action)
            {
                case "Delete":
                    _confirm = await DisplayAlert("Confirm", "Delete room " + room.Name + "?", "Yes", "No");
                    if (_confirm)
                    {
                        await RoomVM.DeleteRoom(room.Id);
                        await GetRooms();
                    }
                    break;
            }
        }

        public async void OnAddRoomButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddNewRoomView(_building.Id));
            return;
        }
    }
}
