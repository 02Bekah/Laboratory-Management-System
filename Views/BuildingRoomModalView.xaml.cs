using Laboratory_Management_System.Models;
using Laboratory_Management_System.ViewModels;

namespace Laboratory_Management_System.Views
{
    public partial class BuildingRoomModalView : ContentPage
    {
        public Building building;
        public IEnumerable<Room> Rooms;
        public RoomViewModel RoomVM;
        public BuildingViewModel BuildingVM;

        public BuildingRoomModalView(Building building)
        {
            InitializeComponent();

            this.building = building;
            RoomVM = new RoomViewModel();
            BuildingVM = new BuildingViewModel();

            GetRooms().GetAwaiter();

        }

        public async Task GetRooms()
        {
            await RoomVM.GetRoomsByBuilding(building.Id);

            RoomCollection.ItemsSource = RoomVM.RoomsInBuilding;
        }

        public async void OnRoomCollectionSelectionChanged(object sender, SelectedItemChangedEventArgs e)
        {

        }

        public async void OnAddRoomButtonClicked(object sender, EventArgs e)
        {

        }
    }
}
