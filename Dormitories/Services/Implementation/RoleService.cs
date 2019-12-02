using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dormitories.Authentication;
using Dormitories.Models;

namespace Dormitories.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IDbConnection _dbConnection;

        public RoleService()
        {
            _dbConnection = DBAccess.GetDbConnection();
        }

        public List<Role> GetRoles()
        {
            return _dbConnection
                .Query<Role>("SELECT * FROM [Roles]")
                .ToList();
        }

        public Role GetRoleById(int roleId)
        {
            return _dbConnection
                .Query<Role>("SELECT * FROM [Roles] WHERE [Id] = " + roleId)
                .SingleOrDefault();
        }

        public Role GetRoleByName(string roleName)
        {
            return _dbConnection
                .Query<Role>("SELECT * FROM [Roles] WHERE [Name] = @RoleNameParameter",new
                {
                    RoleNameParameter = roleName
                })
                .SingleOrDefault();
        }
    }
}
