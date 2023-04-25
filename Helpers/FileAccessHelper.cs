using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_Management_System.Helpers
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename) =>
            Path.Combine(FileSystem.AppDataDirectory, filename);
    }
}
