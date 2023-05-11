using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_Management_System.Helpers
{
    public static class Constants
    {
        public const string DatabaseFilename = "LMS.db";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        // Table names
        public const string ComputerTable = "computers";
        public const string ConsumableTable = "consumables";
        public const string DepartmentTable = "departments";
        public const string ItemTable = "items";
        public const string MachineTable = "machines";
        public const string ManufacturerTable = "manufacturers";
        public const string PersonTable = "people";
        public const string RoomTable = "rooms";
        public const string SoftwareTable = "software";
        public const string BuildingTable = "buildings";

        // Create table statements
        public const string CreateRoomTable = $"CREATE TABLE IF NOT EXISTS {RoomTable} (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Number TEXT, Type TEXT, FOREIGN KEY(BuildingID) REFERENCES building(Id));";
        public const string CreateManufacturerTable = $"CREATE TABLE IF NOT EXISTS {ManufacturerTable} (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Phone TEXT, Email TEXT, Website TEXT);";
        public const string CreatePersonTable = $"CREATE TABLE IF NOT EXISTS {PersonTable} (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Phone TEXT, Email TEXT, OfficeID INTEGER, FOREIGN KEY(OfficeID) REFERENCES rooms(Id));";
        public const string CreateDepartmentTable = $"CREATE TABLE IF NOT EXISTS {DepartmentTable} (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, DepartmentHeadID INTEGER, FOREIGN KEY(DepartmentHeadID) REFERENCES people(Id));";
        public const string CreateItemTable = $"CREATE TABLE IF NOT EXISTS {ItemTable} (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Model TEXT, Version TEXT, SerialNumber TEXT, ManufactureDate TEXT, PurchaseDate TEXT, ManufacturerID INTEGER, DepartmentID INTEGER, LocationID INTEGER, FOREIGN KEY(ManufacturerID) REFERENCES manufacturers(Id), FOREIGN KEY (DepartmentID) REFERENCES departments(Id), FOREIGN KEY(LocationID) REFERENCES rooms(Id));";
        public const string CreateComputerTable = $"CREATE TABLE IF NOT EXISTS {ComputerTable} (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Model TEXT, SerialNumber TEXT, ManufactureDate TEXT, PurchaseDate TEXT, OS TEXT, Accounts TEXT, Softwares TEXT, ManufacturerID INTEGER, DepartmentID INTEGER, LocationID INTEGER, FOREIGN KEY(ManufacturerID) REFERENCES manufacturers(Id), FOREIGN KEY (DepartmentID) REFERENCES departments(Id), FOREIGN KEY(LocationID) REFERENCES rooms(Id));";
        public const string CreateConsumableTable = $"CREATE TABLE IF NOT EXISTS {ConsumableTable} (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Model TEXT, Version TEXT, PresentCount INTEGER, RequiredCount INTEGER, Description TEXT);";
        public const string CreateMachineTable = $"CREATE TABLE IF NOT EXISTS {MachineTable} (Id INTEGER PRIMARY KEY AUTOINCREMENT);";
        public const string CreateSoftwareTable = $"CREATE TABLE IF NOT EXISTS {SoftwareTable} (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Model TEXT, Version TEXT, PurchaseDate TEXT, OS_Support TEXT, CPU_Requirements TEXT, Graphics_Requirements TEXT, Memory_Requirements TEXT, LicenseKey TEXT, Size REAL, ManufacturerID INTEGER, FOREIGN KEY(ManufacturerID) REFERENCES manufacturers(Id));";
        public const string CreateBuildingTable = $"CREATE TABLE IF NOT EXISTS {BuildingTable} (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT);";

        // Delete table statements (used for development)
        public const string DeleteRoomTable = $"DROP TABLE IF EXISTS{RoomTable};";
        public const string DeleteManufacturerTable = $"DROP TABLE IF EXISTS{ManufacturerTable};";
        public const string DeletePersonTable = $"DROP TABLE IF EXISTS{PersonTable};";
        public const string DeleteDepartmentTable = $"DROP TABLE IF EXISTS{DepartmentTable};";
        public const string DeleteItemTable = $"DROP TABLE IF EXISTS{ItemTable};";
        public const string DeleteComputerTable = $"DROP TABLE IF EXISTS{ComputerTable};";
        public const string DeleteConsumableTable = $"DROP TABLE IF EXISTS{ConsumableTable};";
        public const string DeleteMachineTable = $"DROP TABLE IF EXISTS{MachineTable};";
        public const string DeleteSoftwareTable = $"DROP TABLE IF EXISTS{SoftwareTable};";
        public const string DeleteBuildingTable = $"DROP TABLE IF EXISTS{BuildingTable};";

    }
}
