using Laboratory_Management_System.Views;

namespace Laboratory_Management_System;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

		// Register routes
		Routing.RegisterRoute("buildingroom", typeof(BuildingRoomView));
	}
}
