using System.Collections.Generic;
using Dormitories.Models;
using Dormitories.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dormitories.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class AdministratorController : Controller
    {
        private readonly AdministratorService _administratorService = new AdministratorService();

        // GET: api/administrators
        [HttpGet]
        [Route("api/administrators")]
        public List<Administrator> GetAdministrators()
        {
            return _administratorService.GetAdministrators();
        }

        // GET: api/administrators/{administratorUsername}
        [HttpGet]
        [Route("api/administrators/{administratorUsername}")]
        public Administrator GetAdministratorById(string administratorUsername)
        {
            return _administratorService.GetAdministratorByUserName(administratorUsername);
        }
    }
}