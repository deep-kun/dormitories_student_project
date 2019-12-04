using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dormitories.Loggers
{
    public interface ILogger
    {
        //ILogger getInstance();
        void LogInfo(string info);
        void LogError(string error);
    }
}
