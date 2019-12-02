using System.Collections.Generic;
using Dormitories.Models;
using Dormitories.Services;
using Dormitories.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dormitories.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService = new GroupService();

        // GET: api/groups
        [HttpGet]
        [Route("api/groups")]
        public List<Group> GetGroups()
        {
            return _groupService.GetGroups();
        }

        // GET: api/groups/{groupId}
        [HttpGet]
        [Route("api/groups/{groupId}")]
        public Group GetGroupById(int groupId)
        {
            return _groupService.GetGroupById(groupId);
        }

        // DELETE: api/groups/{groupId}
        [HttpDelete]
        [Route("api/groups/{groupId}")]
        public bool DeleteGroup(int groupId)
        {
            return _groupService.DeleteGroupById(groupId);
        }

        // UPDATE: api/groups
        [HttpPut]
        [Route("api/groups")]
        public bool UpdateGroup([FromBody]Group group)
        {
            return _groupService.UpdateGroup(group);
        }

        // INSERT: api/groups
        [HttpPost]
        [Route("api/groups")]
        public bool InsertGroup([FromBody]Group group)
        {
            return _groupService.InsertGroup(group);
        }

    }
}