using Laboratory_Management_System.Views;

namespace Laboratory_Management_System;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
