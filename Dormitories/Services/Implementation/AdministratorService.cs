﻿using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Dormitories.Authentication;
using Dormitories.Models;

namespace Dormitories.Services.Implementation
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IUserService _userService;
        private readonly IFacultyService _facultyService;
        private readonly IDbConnection _dbConnection;

        public AdministratorService()
        {
            _userService = new UserService();
            _facultyService = new FacultyService();
            _dbConnection = DBAccess.GetDbConnection();
        }

        public List<Administrator> GetAdministrators()
        {
            var query = "SELECT * FROM [Administrators]";
            var administrators = new List<Administrator>();

            using (var reader = _dbConnection.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    Faculty faculty = null;

                    if (reader["FacultyId"] != DBNull.Value)
                    {
                        faculty = _facultyService.GetFacultyById(Convert.ToInt32(reader["FacultyId"]));
                    }

                    administrators.Add(new Administrator()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Faculty = faculty,
                        FullName = reader["FullName"].ToString(),
                        User = _userService.GetUserById(Convert.ToInt32(reader["UserId"]))
                    });
                }
            }

            return administrators;
        }

        public Administrator GetAdministratorByUserName(string username)
        {
            var user = _userService.GetUserByUserName(username);
            var query = "SELECT * FROM [Administrators] WHERE [UserId] = @UserIdParameter";
            Administrator administrator = null;
            Faculty faculty = null;

            using (var reader = _dbConnection.ExecuteReader(query, new { UserIdParameter = user.Id }))
            {
                while (reader.Read())
                {
                    if (reader["FacultyId"] != DBNull.Value)
                    {
                        faculty = _facultyService.GetFacultyById(Convert.ToInt32(reader["FacultyId"]));
                    }

                    administrator = new Administrator()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Faculty = faculty,
                        FullName = reader["FullName"].ToString(),
                        User = user
                    };
                }
            }

            return administrator;
        }

        public Administrator GetAdministratorById(int id)
        {
            var query = "SELECT * FROM [Administrators] WHERE [Id] = @IdParameter";
            Administrator administrator = null;
            Faculty faculty = null;

            using (var reader = _dbConnection.ExecuteReader(query, new { IdParameter = id }))
            {
                while (reader.Read())
                {
                    if (reader["FacultyId"] != DBNull.Value)
                    {
                        faculty = _facultyService.GetFacultyById(Convert.ToInt32(reader["FacultyId"]));
                    }

                    administrator = new Administrator()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Faculty = faculty,
                        FullName = reader["FullName"].ToString(),
                        User = _userService.GetUserById(Convert.ToInt32(reader["UserId"]))
                    };
                }
            }

            return administrator;
        }
    }
}