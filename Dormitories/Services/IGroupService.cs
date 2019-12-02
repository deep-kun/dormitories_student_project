using System.Collections.Generic;
using Dormitories.Models;

namespace Dormitories.Services
{
    public interface IGroupService
    {
        List<Group> GetGroups();
        Group GetGroupById(int id);
        bool InsertGroup(Group group);
        bool DeleteGroupById(int groupId);
        bool UpdateGroup(Group group);
    }
}