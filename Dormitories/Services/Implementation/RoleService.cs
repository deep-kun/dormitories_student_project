using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dormitories.Authentication;
using Dormitories.Models;
using Dormitories.Loggers;

namespace Dormitories.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger _logger;

        public RoleService()
        {
            _dbConnection = DBAccess.GetDbConnection();
            _logger = new FileLogger();
        }

        public List<Role> GetRoles()
        {
            _logger.LogInfo("Getting Roles");

            return _dbConnection
                .Query<Role>("SELECT * FROM [Roles]")
                .ToList();
        }

        public Role GetRoleById(int roleId)
        {
            _logger.LogInfo($"Getting role by Id {roleId}");

            return _dbConnection
                .Query<Role>("SELECT * FROM [Roles] WHERE [Id] = " + roleId)
                .SingleOrDefault();
        }

        public Role GetRoleByName(string roleName)
        {
            _logger.LogInfo($"Getting role by name {roleName}");

            return _dbConnection
                .Query<Role>("SELECT * FROM [Roles] WHERE [Name] = @RoleNameParameter",new
                {
                    RoleNameParameter = roleName
                })
                .SingleOrDefault();
        }
    }
}
