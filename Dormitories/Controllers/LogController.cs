using System.Collections.Generic;
using Dormitories.Models;
using Dormitories.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dormitories.Loggers;

namespace Dormitories.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class LogController : Controller
    {
        private readonly LoggerService _loggerService = new LoggerService();
        private readonly ILogger _logger = new FileLogger();

        // GET: api/logs
        [HttpGet]
        [Route("api/logs")]
        public List<Log> GetLogs()
        {
            _logger.LogInfo("API HttpGet api/logs");
            try
            {
                return _loggerService.GetLogs();
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/logs  " + e.Message);
                throw e;
            }
        }

        // INSERT: api/logs/object
        [HttpPost]
        [Route("api/logs/object")]
        public bool InsertLogWithObject([FromBody]Log log)
        {
            _logger.LogInfo("API HttpPost api/logs/object");
            try
            {
                return _loggerService.InsertLogWithObject(log);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPost api/logs/object  " + e.Message);
                throw e;
            }
        }

        // INSERT: api/logs/notobject
        [HttpPost]
        [Route("api/logs/notobject")]
        public bool InsertLogWithoutObject([FromBody]Log log)
        {
            _logger.LogInfo("API HttpPost api/logs/notobject");
            try
            {
                return _loggerService.InsertLogWithObject(log);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPost api/logs/notobject  " + e.Message);
                throw e;
            }
        }
    }
}