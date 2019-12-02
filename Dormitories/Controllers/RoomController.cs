using Dormitories.Models;
using Dormitories.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dormitories.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class RoomController : Controller
    {
        private readonly RoomService _roomService = new RoomService();

        // GET: api/rooms/{roomId}
        [HttpGet]
        [Route("api/rooms/{roomId}")]
        public Room GetRoomById(int roomId)
        {
            return _roomService.GetRoomWithStudents(roomId);
        }

        // DELETE: api/rooms/{roomId}
        [HttpDelete]
        [Route("api/rooms/{roomId}")]
        public bool DeleteRoom(int roomId)
        {
            return _roomService.DeleteRoomById(roomId);
        }

        // UPDATE: api/rooms
        [HttpPut]
        [Route("api/rooms")]
        public bool UpdateRoom([FromBody]Room room)
        {
            return _roomService.UpdateRoom(room);
        }

        //INSERT: api/rooms
        [HttpPost]
        [Route("api/rooms")]
        public bool InsertRoom([FromBody]Room room)
        {
            return _roomService.InsertRoom(room);
        }
    }
}