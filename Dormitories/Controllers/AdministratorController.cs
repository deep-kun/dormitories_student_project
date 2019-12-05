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
    public class AdministratorController : Controller
    {
        private readonly AdministratorService _administratorService = new AdministratorService();
        private readonly ILogger _logger = new FileLogger();

        // GET: api/administrators
        [HttpGet]
        [Route("api/administrators")]
        public List<Administrator> GetAdministrators()
        {
            _logger.LogInfo("API HttpGet api/administrators");
            try
            {
                return _administratorService.GetAdministrators();
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/administrators  " + e.Message);
                throw e;
            }
        }

        // GET: api/administrators/{administratorUsername}
        [HttpGet]
        [Route("api/administrators/{administratorUsername}")]
        public Administrator GetAdministratorById(string administratorUsername)
        {
            _logger.LogInfo("API HttpGet api/administrators/{administratorUsername}");
            try
            {
                return _administratorService.GetAdministratorByUserName(administratorUsername);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/administrators/{administratorUsername}  " + e.Message);
                throw e;
            }
}
    }
}