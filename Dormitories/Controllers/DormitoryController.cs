using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dormitories.Models;
using Dormitories.Services;
using Dormitories.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dormitories.Loggers;

namespace Dormitories.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class DormitoryController : Controller
    {
        private readonly IDormitoryService _dormitoryService = new DormitoryService();
        private readonly ILogger _logger = new FileLogger();

        // GET: api/dormitories
        [HttpGet]
        [Route("api/dormitories")]
        public List<Dormitory> GetDormitories()
        {
            _logger.LogInfo("API HttpGet api/dormitories");
            try
            {
                return _dormitoryService.GetDormitories();
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/dormitories  " + e.Message);
                throw e;
            }
}

        // GET: api/dormitories/{dormitoryId}
        [HttpGet]
        [Route("api/dormitories/{dormitoryId}")]
        public Dormitory GetDormitoryById(int dormitoryId)
        {
            _logger.LogInfo("API HttpGet api/dormitories/{dormitoryId}");
            try
            {
                return _dormitoryService.GetDormitoryById(dormitoryId);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/dormitories/{dormitoryId}  " + e.Message);
                throw e;
            }
        }

        // GET: api/dormitories/dormitoryAdmin/{dormitoryAdminUsername}
        [HttpGet]
        [Route("api/dormitories/dormitoryAdmin/{dormitoryAdminUsername}")]
        public Dormitory GetDormitoryByDormitoryAdminId(string dormitoryAdminUsername)
        {
            _logger.LogInfo("API HttpGet api/dormitories/dormitoryAdmin/{dormitoryAdminUsername}");
            try
            {
                return _dormitoryService.GetDormitoryByDormitoryAdminId(dormitoryAdminUsername);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/dormitories/dormitoryAdmin/{dormitoryAdminUsername}  " + e.Message);
                throw e;
            }
        }

        // INSERT: api/dormitories
        [HttpPost]
        [Route("api/dormitories")]
        public bool InsertDormitory([FromBody]Dormitory dormitory)
        {
            _logger.LogInfo("API HttpPost api/dormitories");
            try
            {
                return _dormitoryService.InsertDormitory(dormitory);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPost api/dormitories  " + e.Message);
                throw e;
            }
        }
    }
}