using Dormitories.Models;
using Dormitories.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dormitories.Loggers;

namespace Dormitories.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class RoomController : Controller
    {
        private readonly RoomService _roomService = new RoomService();
        private readonly ILogger _logger = new FileLogger();

        // GET: api/rooms/{roomId}
        [HttpGet]
        [Route("api/rooms/{roomId}")]
        public Room GetRoomById(int roomId)
        {
            _logger.LogInfo("API HttpGet api/rooms/{roomId}");
            try
            {
                return _roomService.GetRoomWithStudents(roomId);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/rooms/{roomId}  " + e.Message);
                throw e;
            }
        }

        // DELETE: api/rooms/{roomId}
        [HttpDelete]
        [Route("api/rooms/{roomId}")]
        public bool DeleteRoom(int roomId)
        {
            _logger.LogInfo("API HttpDelete api/rooms/{roomId}");
            try
            {
                return _roomService.DeleteRoomById(roomId);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpDelete api/rooms/{roomId}  " + e.Message);
                throw e;
            }
        }

        // UPDATE: api/rooms
        [HttpPut]
        [Route("api/rooms")]
        public bool UpdateRoom([FromBody]Room room)
        {
            _logger.LogInfo("API HttpPut api/rooms");
            try
            {
                return _roomService.UpdateRoom(room);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPut api/rooms  " + e.Message);
                throw e;
            }
        }

        //INSERT: api/rooms
        [HttpPost]
        [Route("api/rooms")]
        public bool InsertRoom([FromBody]Room room)
        {
            _logger.LogInfo("API HttpPost api/rooms");
            try
            {
                return _roomService.InsertRoom(room);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPost api/rooms  " + e.Message);
                throw e;
            }
        }
    }
}