using System.Collections.Generic;
using Dormitories.Models;

namespace Dormitories.Services
{
    public interface IBlockService
    {
        Block GetSimpleBlockById(int id);
        Block GetBlockWithRoomsByBlockName(string blockName);
        List<Block> GetBlocksByFloorId(int floorId);
        bool InsertBlock(Block block);
        bool DeleteBlockById(int blockId);
        bool UpdateBlock(Block block);
    }
}