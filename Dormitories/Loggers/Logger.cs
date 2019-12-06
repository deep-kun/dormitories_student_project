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
            directory = "../logs/";//System.Reflection.Assembly.GetExecutingAssembly().Location;
        }

        public void LogInfo(string info)
        {
            CheckIfLogExists();

            string path = String.Format($@"bin\logs\log[{DateTime.Today.Year}.{DateTime.Today.Month}.{DateTime.Today.Day}].txt", AppDomain.CurrentDomain.BaseDirectory);

            try
            {
                using (StreamWriter outputFile = File.AppendText(path))
                {
                    outputFile.WriteLine($"INFO {DateTime.Now} - {info}.");
                }
            }
            catch { }
        }

        public void LogError(string error)
        {
            CheckIfLogExists();

            string path = String.Format($@"bin\logs\log[{DateTime.Today.Year}.{DateTime.Today.Month}.{DateTime.Today.Day}].txt", AppDomain.CurrentDomain.BaseDirectory);
            try
            {
                using (StreamWriter outputFile = File.AppendText(path))
                {
                    outputFile.WriteLine($"ERROR {DateTime.Now} - {error}.");
                }
            }
            catch { }
        }

        private void CheckIfLogExists()
        {
            string path = String.Format(@"bin\logs", AppDomain.CurrentDomain.BaseDirectory);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
    }
}
