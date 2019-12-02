using System.Collections.Generic;
using Dormitories.Models;

namespace Dormitories.Services
{
    public interface IRoomService
    {
        Room GetSimpleRoomById(int id);
        List<Room> GetRoomsByFloorId(int floorId);
        List<Room> GetRoomsByBlockId(int blockId);
        Room GetRoomWithStudents(int id);
        bool InsertRoom(Room room);
        bool DeleteRoomById(int roomId);
        bool UpdateRoom(Room room);
        void RoomFreePlacesToLower(int roomId);
        void RoomFreePlacesToUpper(int roomId);
    }
}