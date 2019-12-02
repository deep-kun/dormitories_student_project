using System.Collections.Generic;
using Dormitories.Models;

namespace Dormitories.Services
{
    public interface IRoleService
    {
        Role GetRoleById(int roleId);
        List<Role> GetRoles();
        Role GetRoleByName(string roleName);
    }
}
