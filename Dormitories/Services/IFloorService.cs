using System.Collections.Generic;
using Dormitories.Models;

namespace Dormitories.Services
{
    public interface IFloorService
    {
        List<Floor> GetFloorsByDormitoryId(int dormitoryId);
        bool InsertFloor(Floor floor);
        bool DeleteFloorById(int floorId);
        bool UpdateFloor(Floor floor);
        Floor GetFloorWithBlocksAndRooms(int floorId);
    }
}