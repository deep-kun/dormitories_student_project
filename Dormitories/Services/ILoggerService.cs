using System.Collections.Generic;
using Dormitories.Models;

namespace Dormitories.Services
{
    public interface ILoggerService
    {
        bool InsertLogWithoutObject(Log log);
        bool InsertLogWithObject(Log log);
        List<Log> GetLogs();
    }
}