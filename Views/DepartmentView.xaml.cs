using Laboratory_Management_System.Models;
using Laboratory_Management_System.ViewModels;

namespace Laboratory_Management_System.Views
{
    public partial class DepartmentView : ContentPage
    {
        DepartmentViewModel DeptVM;
        public DepartmentView()
        {
            InitializeComponent();

            DeptVM = new DepartmentViewModel();

            GetDepartments().GetAwaiter();
        }

        public async Task GetDepartments()
        {
            await DeptVM.GetDepartments();

            DeptCollection.ItemsSource = DeptVM.Departments;
        }

        public async void OnAddDeptButtonClicked(object sender, EventArgs e)
        {
            string _name = await DisplayPromptAsync("Add Department", "Enter Name");

            bool _confirm = await DisplayAlert("Confirm", $"Do you want to add department {_name}?", "Yes", "No");
            
            if (_confirm)
            {
                await DeptVM.AddNewDepartment(_name);
                await GetDepartments();
            }
        }

        public async Task OnDeleteDeptOptionSelected(Department dept)
        {
            bool _confirm = await DisplayAlert("Confirm", $"Do you want to delete department '{dept.Name}'?", "Yes", "No");

            if (_confirm)
            {
                await DeptVM.DeleteDepartment(dept.Id);
                await GetDepartments();
            }
        }


        public async void OnDeptSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Department _department = e.CurrentSelection.LastOrDefault() as Department;
            string _action = await DisplayActionSheet(_department.Name, "Cancel", null, "Delete");

            switch(_action)
            {
                case "Delete":
                    await OnDeleteDeptOptionSelected(_department);
                    break;
            }
        }

    }
}
