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
    public class FloorController : Controller
    {
        private readonly IFloorService _floorService = new FloorService();
        private readonly ILogger _logger = new FileLogger();

        // GET: api/floors/{floorId}
        [HttpGet]
        [Route("api/floors/{floorId}")]
        public Floor GetFloorById(int floorId)
        {
            _logger.LogInfo("API HttpGet api/floors/{floorId}");
            try
            {
                return _floorService.GetFloorWithBlocksAndRooms(floorId);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/floors/{floorId}  " + e.Message);
                throw e;
            }
        }

        // GET: api/floors/dormitory/{dormitoryId}
        [HttpGet]
        [Route("api/floors/dormitory/{dormitoryId}")]
        public List<Floor> GetFloorByDormitoryId(int dormitoryId)
        {
            _logger.LogInfo("API HttpGet api/floors/dormitory/{dormitoryId}");
            try
            {
                return _floorService.GetFloorsByDormitoryId(dormitoryId);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/floors/dormitory/{dormitoryId}  " + e.Message);
                throw e;
            }
        }

        // DELETE: api/floors/{floorId}
        [HttpDelete]
        [Route("api/floors/{floorId}")]
        public bool DeleteFloor(int floorId)
        {
            _logger.LogInfo("API HttpDelete api/floors/{floorId}");
            try
            {
                return _floorService.DeleteFloorById(floorId);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpDelete api/floors/{floorId}  " + e.Message);
                throw e;
            }
        }

        // UPDATE: api/floors
        [HttpPut]
        [Route("api/floors")]
        public bool UpdateFloor([FromBody]Floor floor)
        {
            _logger.LogInfo("API HttpPut api/floors");
            try
            {
                return _floorService.UpdateFloor(floor);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPut api/floors  " + e.Message);
                throw e;
            }
        }

        //INSERT: api/floors
        [HttpPost]
        [Route("api/floors")]
        public bool InsertFloor([FromBody]Floor floor)
        {
            _logger.LogInfo("API HttpPost api/floors");
            try
            {
                return _floorService.InsertFloor(floor);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPost api/floors  " + e.Message);
                throw e;
            }
        }
    }
}