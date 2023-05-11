using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Laboratory_Management_System.Models;
using Laboratory_Management_System.Helpers;

namespace Laboratory_Management_System.ViewModels
{
    public class DepartmentViewModel : BaseViewModel
    {
        public IEnumerable<Department> Departments;
        public DepartmentViewModel()
        {

        }

        public async Task GetDepartments()
        {
            Departments = await DatabaseService.GetItems<Department>();
        }

        public async Task AddNewDepartment(string name)
        {
            Query = $"INSERT INTO {Constants.DepartmentTable} (name) VALUES ('{name}');";
            await DatabaseService.ExecuteQuery(Query);
        }

        public async Task UpdateDepartment(int id, string name, int deptHead)
        {
            Query = $"UPDATE {Constants.DepartmentTable} SET name = '{name}', departmentheadid = {deptHead} WHERE id = {id};";
            await DatabaseService.ExecuteQuery(Query);
        }

        public async Task DeleteDepartment(int id)
        {
            Query = $"DELETE FROM {Constants.DepartmentTable} WHERE id = {id};";
            await DatabaseService.ExecuteQuery(Query);
        }
    }

}
