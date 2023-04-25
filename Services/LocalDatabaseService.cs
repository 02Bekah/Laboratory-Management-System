using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Laboratory_Management_System.Helpers;
using Laboratory_Management_System.Models;
using SQLite;

namespace Laboratory_Management_System.Services
{
    public class LocalDatabaseService : ILocalDatabaseService
    {
        private SQLiteAsyncConnection _databaseConn;
        private string _dbpath = FileAccessHelper.GetLocalFilePath(Constants.DatabaseFilename);

        public LocalDatabaseService(string _dbpath)
        {
            this._dbpath = _dbpath;
        }
        private async Task Init()
        {
            // Database connection
            if (_databaseConn != null)
                return;

            try
            {
                _databaseConn = new SQLiteAsyncConnection(_dbpath, Constants.Flags);

                _databaseConn.Tracer = new Action<string>(q => Debug.WriteLine(q));
                _databaseConn.Trace = true;

                await CreateTables();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }

        private async Task CreateTables()
        {
            var createTableStatements = new List<string>()
            {
                Constants.CreateRoomTable,
                Constants.CreateManufacturerTable,
                Constants.CreatePersonTable,
                Constants.CreateDepartmentTable,
                Constants.CreateItemTable,
                Constants.CreateComputerTable,
                Constants.CreateConsumableTable,
                Constants.CreateMachineTable,
                Constants.CreateSoftwareTable
            };

            foreach (var statement in createTableStatements)
                await ExecuteQuery(statement);
        }

        public async Task<bool> ExecuteQuery(string query)
        {
            await Init();

            var op = await _databaseConn.ExecuteAsync(query);
            return op > 0;
        }

        public async Task<IEnumerable<T>> GetItems<T>() where T : BaseModel, new()
        {
            await Init();

            return await _databaseConn.Table<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetItemsWithQuery<T>(string query) where T : BaseModel, new()
        {
            await Init();

            return await _databaseConn.QueryAsync<T>(query);
        }
    }
}
