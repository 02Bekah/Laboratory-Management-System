using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Laboratory_Management_System.Models;

namespace Laboratory_Management_System.Services
{
    public interface ILocalDatabaseService
    {
        Task<IEnumerable<T>> GetItemsWithQuery<T>(string query) where T : BaseModel, new();
        Task<IEnumerable<T>> GetItems<T>() where T : BaseModel, new();
        Task<bool> ExecuteQuery(string query);
    }
}
