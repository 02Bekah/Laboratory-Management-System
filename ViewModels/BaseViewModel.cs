using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratory_Management_System.Services;

namespace Laboratory_Management_System.ViewModels
{
    public abstract class BaseViewModel
    {
        // Database service
        public LocalDatabaseService DatabaseService;
        public string Query;

        public BaseViewModel()
        {
            DatabaseService = new LocalDatabaseService();
        }
    }
}
