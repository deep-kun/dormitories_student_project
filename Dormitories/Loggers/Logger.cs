using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dormitories.Loggers
{
    public class FileLogger: ILogger
    {
        private string directory;     
        
        public FileLogger()
        {
            directory = System.Reflection.Assembly.GetExecutingAssembly().Location;
        }

        public void LogInfo(string info)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(directory, DateTime.Today.ToString() + ".txt")))
            {
                outputFile.WriteLine($"INFO {DateTime.Now} - {info}.");
            }
        }

        public void LogError(string error)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(directory, DateTime.Today.ToString() + ".txt")))
            {
                outputFile.WriteLine($"ERROR {DateTime.Now} - {error}.");
            }
        }
    }
}
