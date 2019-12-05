using System.Collections.Generic;
using Dormitories.Models;
using Dormitories.Services;
using Dormitories.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dormitories.Loggers;

namespace Dormitories.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService = new GroupService();
        private readonly ILogger _logger = new FileLogger();

        // GET: api/groups
        [HttpGet]
        [Route("api/groups")]
        public List<Group> GetGroups()
        {
            _logger.LogInfo("API HttpGet api/groups");
            try
            {
                return _groupService.GetGroups();
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/groups  " + e.Message);
                throw e;
            }
        }

        // GET: api/groups/{groupId}
        [HttpGet]
        [Route("api/groups/{groupId}")]
        public Group GetGroupById(int groupId)
        {
            _logger.LogInfo("API HttpGet api/groups/{groupId}");
            try
            {
                return _groupService.GetGroupById(groupId);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/groups/{groupId}  " + e.Message);
                throw e;
            }
        }

        // DELETE: api/groups/{groupId}
        [HttpDelete]
        [Route("api/groups/{groupId}")]
        public bool DeleteGroup(int groupId)
        {
            _logger.LogInfo("API HttpDelete api/groups/{groupId}");
            try
            {
                return _groupService.DeleteGroupById(groupId);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpDelete api/groups/{groupId}  " + e.Message);
                throw e;
            }
        }

        // UPDATE: api/groups
        [HttpPut]
        [Route("api/groups")]
        public bool UpdateGroup([FromBody]Group group)
        {
            _logger.LogInfo("API HttpPut api/groups");
            try
            {
                return _groupService.UpdateGroup(group);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPut api/groups  " + e.Message);
                throw e;
            }
        }

        // INSERT: api/groups
        [HttpPost]
        [Route("api/groups")]
        public bool InsertGroup([FromBody]Group group)
        {
            _logger.LogInfo("API HttpPost api/groups");
            try
            {
                return _groupService.InsertGroup(group);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPost api/groups  " + e.Message);
                throw e;
            }
        }

    }
}