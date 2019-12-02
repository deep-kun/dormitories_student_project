using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dormitories.Authentication;
using Dormitories.Models;

namespace Dormitories.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRoleService _roleService;
        private readonly IDbConnection _dbConnection;

        public UserService()
        {
            _roleService = new RoleService();
            _dbConnection = DBAccess.GetDbConnection();
        }

        public List<User> GetUsers()
        {
            return _dbConnection
                .Query<User>("SELECT * FROM [Users]")
                .ToList();
        }

        public User GetUserByUserName(string username)
        {
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
