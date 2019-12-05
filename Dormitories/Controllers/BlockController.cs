using System.Collections.Generic;
using Dormitories.Models;
using Dormitories.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dormitories.Loggers;

namespace Dormitories.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class BlockController : Controller
    {
        private readonly BlockService _blockService = new BlockService();
        private readonly ILogger _logger = new FileLogger();

        // GET: api/blocks/{groupId}
        [HttpGet]
        [Route("api/blocks/{blockId}")]
        public Block GetBlockById(int blockId)
        {
            _logger.LogInfo("API HttpGet api/blocks/{blockId}");
            try
            {
                return _blockService.GetBlockWithRooms(blockId);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/blocks/{blockId}  " + e.Message);
                throw e;
            }
        }

        // GET: api/blocks/name/{blockName}
        [HttpGet]
        [Route("api/blocks/name/{blockName}")]
        public Block GetBlockByName(string blockName)
        {
            _logger.LogInfo("API HttpGet api/blocks/name/{blockName}");
            try
            {
                return _blockService.GetBlockWithRoomsByBlockName(blockName);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/blocks/name/{blockName}  " + e.Message);
                throw e;
            }
        }

        // GET: api/blocks/floor/{floorId}
        [HttpGet]
        [Route("api/blocks/floor/{floorId}")]
        public List<Block> GetBlockssByFloorId(int floorId)
        {
            _logger.LogInfo("API HttpGet api/blocks/floor/{floorId}");
            try
            {
                return _blockService.GetBlocksByFloorId(floorId);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/blocks/floor/{floorId}  " + e.Message);
                throw e;
            }
        }

        // DELETE: api/blocks/{blockId}
        [HttpDelete]
        [Route("api/blocks/{blockId}")]
        public bool DeleteBlock(int blockId)
        {
            _logger.LogInfo("API HttpDelete api/blocks/{blockId}");
            try
            {
                return _blockService.DeleteBlockById(blockId);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpDelete api/blocks/{blockId}  " + e.Message);
                throw e;
            }
        }

        // UPDATE: api/blocks
        [HttpPut]
        [Route("api/blocks")]
        public bool UpdateBlock([FromBody]Block block)
        {
            _logger.LogInfo("API HttpPut api/blocks");
            try
            {
                return _blockService.UpdateBlock(block);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPut api/blocks  " + e.Message);
                throw e;
            }
        }

        //INSERT: api/blocks
        [HttpPost]
        [Route("api/blocks")]
        public bool InsertBlock([FromBody]Block block)
        {
            _logger.LogInfo("API HttpPost api/blocks");
            try
            {
                return _blockService.InsertBlock(block);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPost api/blocks  " + e.Message);
                throw e;
            }
        }
    }
}