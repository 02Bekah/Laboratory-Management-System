using Laboratory_Management_System.Models;
using Laboratory_Management_System.ViewModels;

namespace Laboratory_Management_System.Views
{
    [QueryProperty(nameof(building), "building")]
    public partial class BuildingRoomView : ContentPage
    {
        public int BuildingID;
        public Building building
        {
            set
            {
                BuildingID = value.Id;
            }
        }
        
        public IEnumerable<Room> Rooms;
        public RoomViewModel RoomVM;
        public BuildingViewModel BuildingVM;

        public BuildingRoomView()
        {
            InitializeComponent();

            RoomVM = new RoomViewModel();
            GetRooms().GetAwaiter();
            BindingContext = this;
        }

        public async Task GetRooms()
        {
            await RoomVM.GetRoomsByBuilding(BuildingID);

            RoomCollection.ItemsSource = RoomVM.RoomsInBuilding;
        }


        public async void OnRoomCollectionSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Room room = e.CurrentSelection.LastOrDefault() as Room;
            string _action = await DisplayActionSheet($"{room.Name}", "Cancel", null, "Change Name", "Delete");

            switch (_action)
            {
                case "Delete":
                    await RoomVM.DeleteRoom(room.Id);
                    await GetRooms();
                    break;
                case "Update":
                    break;
            }
        }

        public async void OnAddRoomButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddNewRoomView(BuildingID));

            RoomCollection.ItemsSource = Rooms;

        }
    }
}
