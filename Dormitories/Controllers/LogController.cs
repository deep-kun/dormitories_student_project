using System.Collections.Generic;
using Dormitories.Models;
using Dormitories.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dormitories.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class LogController : Controller
    {
        private readonly LoggerService _loggerService = new LoggerService();

        // GET: api/logs
        [HttpGet]
        [Route("api/logs")]
        public List<Log> GetLogs()
        {
            return _loggerService.GetLogs();
        }

        // INSERT: api/logs/object
        [HttpPost]
        [Route("api/logs/object")]
        public bool InsertLogWithObject([FromBody]Log log)
        {
            return _loggerService.InsertLogWithObject(log);
        }

        // INSERT: api/logs/notobject
        [HttpPost]
        [Route("api/logs/notobject")]
        public bool InsertLogWithoutObject([FromBody]Log log)
        {
            return _loggerService.InsertLogWithObject(log);
        }
    }
}