using System.Collections.Generic;
using Dormitories.Models;
using Dormitories.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dormitories.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class BlockController : Controller
    {
        private readonly BlockService _blockService = new BlockService();

        // GET: api/blocks/{groupId}
        [HttpGet]
        [Route("api/blocks/{blockId}")]
        public Block GetBlockById(int blockId)
        {
            return _blockService.GetBlockWithRooms(blockId);
        }

        // GET: api/blocks/name/{blockName}
        [HttpGet]
        [Route("api/blocks/name/{blockName}")]
        public Block GetBlockByName(string blockName)
        {
            return _blockService.GetBlockWithRoomsByBlockName(blockName);
        }

        // GET: api/blocks/floor/{floorId}
        [HttpGet]
        [Route("api/blocks/floor/{floorId}")]
        public List<Block> GetBlockssByFloorId(int floorId)
        {
            return _blockService.GetBlocksByFloorId(floorId);
        }

        // DELETE: api/blocks/{blockId}
        [HttpDelete]
        [Route("api/blocks/{blockId}")]
        public bool DeleteBlock(int blockId)
        {
            return _blockService.DeleteBlockById(blockId);
        }

        // UPDATE: api/blocks
        [HttpPut]
        [Route("api/blocks")]
        public bool UpdateBlock([FromBody]Block block)
        {
            return _blockService.UpdateBlock(block);
        }

        //INSERT: api/blocks
        [HttpPost]
        [Route("api/blocks")]
        public bool InsertBlock([FromBody]Block block)
        {
            return _blockService.InsertBlock(block);
        }
    }
}