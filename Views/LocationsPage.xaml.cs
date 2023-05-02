namespace Laboratory_Management_System.Views;
using Laboratory_Management_System.Services;
using Laboratory_Management_System.ViewModels;

public partial class LocationsPage : ContentPage
{
    RoomViewModel rooms;
    public LocationsPage()
	{
        InitializeComponent();
        rooms = new RoomViewModel();
    }

    public async void AddRoomButtonClicked(object sender, EventArgs e)
    {
        string _name = NameEntry.Text;
        string _number = NumberEntry.Text;
        string _building = BuildingEntry.Text;

        await rooms.AddNewRoom(_name, _number, _building);
    }
}