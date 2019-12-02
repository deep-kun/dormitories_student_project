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

namespace Dormitories.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class DormitoryController : Controller
    {
        private readonly IDormitoryService _dormitoryService = new DormitoryService();

        // GET: api/dormitories
        [HttpGet]
        [Route("api/dormitories")]
        public List<Dormitory> GetDormitories()
        {
            return _dormitoryService.GetDormitories();
        }

        // GET: api/dormitories/{dormitoryId}
        [HttpGet]
        [Route("api/dormitories/{dormitoryId}")]
        public Dormitory GetDormitoryById(int dormitoryId)
        {
            return _dormitoryService.GetDormitoryById(dormitoryId);
        }

        // GET: api/dormitories/dormitoryAdmin/{dormitoryAdminUsername}
        [HttpGet]
        [Route("api/dormitories/dormitoryAdmin/{dormitoryAdminUsername}")]
        public Dormitory GetDormitoryByDormitoryAdminId(string dormitoryAdminUsername)
        {
            return _dormitoryService.GetDormitoryByDormitoryAdminId(dormitoryAdminUsername);
        }

        // INSERT: api/dormitories
        [HttpPost]
        [Route("api/dormitories")]
        public bool InsertDormitory([FromBody]Dormitory dormitory)
        {
            return _dormitoryService.InsertDormitory(dormitory);
        }
    }
}