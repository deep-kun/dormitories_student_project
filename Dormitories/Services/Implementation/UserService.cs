using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dormitories.Authentication;
using Dormitories.Models;
using Dormitories.Loggers;

namespace Dormitories.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRoleService _roleService;
        private readonly IDbConnection _dbConnection;
        private readonly ILogger _logger;

        public UserService()
        {
            _roleService = new RoleService();
            _dbConnection = DBAccess.GetDbConnection();
            _logger = new FileLogger();
        }

        public List<User> GetUsers()
        {
            _logger.LogInfo("Getting users");

            return _dbConnection
                .Query<User>("SELECT * FROM [Users]")
                .ToList();
        }

        public User GetUserByUserName(string username)
        {
            _logger.LogInfo($"Getting user by user name '{username}'");

            var query = "SELECT * FROM [Users] WHERE [Username] = @UsernameParameter";
            var user = new User();
            
            using (var reader = _dbConnection.ExecuteReader(query, new { UsernameParameter = username }))
            {
                while (reader.Read())
                {
                    user = new User()
                    {
                        Id = Convert.ToInt64(reader["Id"]),
                        Username = reader["Username"].ToString(),
                        PasswordHash = reader["PasswordHash"].ToString(),
                        Role = _roleService.GetRoleById(Convert.ToInt32(reader["RoleId"]))
                    };
                }
            }

            return user;
        }

        public User GetUserById(int id)
        {
            _logger.LogInfo($"Getting user by Id {id}");

            var query = "SELECT * FROM [Users] WHERE [Id] = @IdParameter";
            var user = new User();

            using (var reader = _dbConnection.ExecuteReader(query, new { IdParameter = id }))
            {
                while (reader.Read())
                {
                    user = new User()
                    {
                        Id = Convert.ToInt64(reader["Id"]),
                        Username = reader["Username"].ToString(),
                        PasswordHash = reader["PasswordHash"].ToString(),
                        Role = _roleService.GetRoleById(Convert.ToInt32(reader["RoleId"]))
                    };
                }
            }

            return user;
        }

        public bool InsertUser(User user)
        {
            _logger.LogInfo($"Inserting user '{user.Username}'");

            var rowsAffected = _dbConnection.Execute(@"INSERT INTO [Users]([Username],[PasswordHash],[RoleId]) 
                                        VALUES(@UsernameParameter,@PasswordHashParameter,@RoleIdParameter)", new
            {
                UsernameParameter = user.Username,
                PasswordHashParameter = user.PasswordHash,
                RoleIdParameter = user.Role.Id
            });

            return rowsAffected > 0;
        }

        public bool ChangePassword(string username, string newPassword)
        {
            _logger.LogInfo($"Changing password for user '{username}'");

            var rowsAffected = _dbConnection.Execute(@"UPDATE [Users]
                                                       SET [PasswordHash] = @PasswordHashParameter
                                                       WHERE [Username] = @UsernameParameter", new
            {
                UsernameParameter = username,
                PasswordHashParameter = newPassword
            });

            return rowsAffected > 0;
        }
    }
}
