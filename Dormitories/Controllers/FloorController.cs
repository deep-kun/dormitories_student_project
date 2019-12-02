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
    public class FloorController : Controller
    {
        private readonly IFloorService _floorService = new FloorService();

        // GET: api/floors/{floorId}
        [HttpGet]
        [Route("api/floors/{floorId}")]
        public Floor GetFloorById(int floorId)
        {
            return _floorService.GetFloorWithBlocksAndRooms(floorId);
        }

        // GET: api/floors/dormitory/{dormitoryId}
        [HttpGet]
        [Route("api/floors/dormitory/{dormitoryId}")]
        public List<Floor> GetFloorByDormitoryId(int dormitoryId)
        {
            return _floorService.GetFloorsByDormitoryId(dormitoryId);
        }

        // DELETE: api/floors/{floorId}
        [HttpDelete]
        [Route("api/floors/{floorId}")]
        public bool DeleteFloor(int floorId)
        {
            return _floorService.DeleteFloorById(floorId);
        }

        // UPDATE: api/floors
        [HttpPut]
        [Route("api/floors")]
        public bool UpdateFloor([FromBody]Floor floor)
        {
            return _floorService.UpdateFloor(floor);
        }

        //INSERT: api/floors
        [HttpPost]
        [Route("api/floors")]
        public bool InsertFloor([FromBody]Floor floor)
        {
            return _floorService.InsertFloor(floor);
        }
    }
}