using Laboratory_Management_System.ViewModels;

namespace Laboratory_Management_System.Views
{
    public partial class AddNewRoomView : ContentPage
    {
        readonly int _buildingID;
        public RoomViewModel RoomVM;
        public AddNewRoomView(int buildingID)
        {
            InitializeComponent();

            BindingContext = this;

            RoomVM = new RoomViewModel();

            _buildingID = buildingID;
        }

        public async void OnSaveRoomBtnClicked(object sender, EventArgs e)
        {
            string _name = roomNameEntry.Text;
            string _number = roomNumberEntry.Text;
            string _type = roomTypeEntry.Text;

            await RoomVM.AddNewRoom(_name, _number, _buildingID, _type);
            await Navigation.PopModalAsync();
        }
    }
}
