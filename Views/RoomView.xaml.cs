using Laboratory_Management_System.ViewModels;
using Laboratory_Management_System.Models;

namespace Laboratory_Management_System.Views
{
    public partial class RoomView : ContentPage
    {
        public int RoomTypeIndex;
        readonly int _buildingID;
        readonly Room room;
        public RoomViewModel RoomVM;
        public RoomView(int buildingID)
        {
            InitializeComponent();

            RoomVM = new RoomViewModel();
            _buildingID = buildingID;

            BindingContext = this;
            PickRoomType.ItemsSource = RoomVM.ValidRoomTypes.ToList();

        }

        public RoomView(int buildingID, Room room) : this(buildingID)
        {
            this.room = room;

            string _type = room.Type;
            int _roomType = Array.IndexOf(RoomVM.ValidRoomTypes.ToArray(),_type);

            roomNameEntry.Text = room.Name;
            roomNumberEntry.Text = room.Number;
            PickRoomType.SelectedIndex = _roomType;

            SaveRoomBtn.Text = "Update";
        }

        public async void OnSaveRoomBtnClicked(object sender, EventArgs e)
        {
            bool _confirm;
            string _name = roomNameEntry.Text;
            string _number = roomNumberEntry.Text;

            if (RoomTypeIndex != -1)
            {
                string _type = RoomVM.ValidRoomTypes.ToArray()[RoomTypeIndex];

                if (room is null)
                {
                    string addRoomMsg = "Add " + _name + ", " + _number + " as a " + _type + "?";

                    _confirm = await DisplayAlert("Confirm", addRoomMsg, "Yes", "No");

                    if (_confirm)
                    {
                        await RoomVM.AddNewRoom(_name, _number, _buildingID, _type);
                        await Navigation.PopModalAsync();
                    }
                } 
                else 
                { 
                    string updateRoomMsg = "Change " + room.Name + ", " + room.Number + " (" + room.Type + ") to " + _name + ", " + _number + " (" + _type + ")?";
                    
                    _confirm = await DisplayAlert("Confirm", updateRoomMsg, "Yes", "No");

                    if (_confirm)
                    {
                        await RoomVM.UpdateRoom(room.Id, _name, _number, _type, _buildingID);
                        await Navigation.PopModalAsync();
                    }
                }
            }
        }

        public String[] GetRoomInfo()
        {
            string _name = roomNameEntry.Text;
            string _number = roomNumberEntry.Text;
            string _type = "";

            if (RoomTypeIndex != -1)
            {
                _type = RoomVM.ValidRoomTypes.ToArray()[RoomTypeIndex];

            }

            String[] _info = { _name, _number, _type };

            return _info;
        }

        public void OnPickRoomTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            RoomTypeIndex = picker.SelectedIndex;
        }

        public async void OnExitButtonClicked(object sender, EventArgs e)
        {
            bool _confirm = await DisplayAlert("Exit", "Are you sure you want to exit?", "Yes", "No");

            if (_confirm)
            {
                await Navigation.PopModalAsync();
            }
        }
    }
}
