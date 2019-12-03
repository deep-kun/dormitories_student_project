using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Dormitories.Authentication;
using Dormitories.Models;
using Dormitories.Loggers;

namespace Dormitories.Services.Implementation
{
    public class DormitoryService : IDormitoryService
    {
        private readonly IFloorService _floorService;
        private readonly IAdministratorService _administratorService;
        private readonly IDbConnection _dbConnection;
        private readonly ILogger _logger;

        public DormitoryService()
        {
            _floorService = new FloorService();
            _administratorService = new AdministratorService();
            _dbConnection = DBAccess.GetDbConnection();
            _logger = new FileLogger();
        }

        public List<Dormitory> GetDormitories()
        {
            _logger.LogInfo("Getting Dormitories");

            var query = "SELECT * FROM [Dormitories] ORDER BY [Number]";
            var dormitories = new List<Dormitory>();

            using (var reader = _dbConnection.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    dormitories.Add(new Dormitory()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Description = reader["Description"].ToString(),
                        Address = reader["Address"].ToString(),
                        Number = Convert.ToInt32(reader["Number"]),
                        Comendant = _administratorService.GetAdministratorById(Convert.ToInt32(reader["ComendantId"])),
                        Floors = _floorService.GetFloorsByDormitoryId(Convert.ToInt32(reader["Id"]))
                    });
                }
            }

            return dormitories;
        }

        public Dormitory GetDormitoryById(int id)
        {
            _logger.LogInfo($"Getting dormitory by Id {id}");

            var query = "SELECT * FROM [Dormitories] WHERE [Id] = " + id;
            var dormitory = new Dormitory();

            using (var reader = _dbConnection.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    dormitory = new Dormitory()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Description = reader["Description"].ToString(),
                        Address = reader["Address"].ToString(),
                        Number = Convert.ToInt32(reader["Number"]),
                        Comendant = _administratorService.GetAdministratorById(Convert.ToInt32(reader["ComendantId"])),
                        Floors = _floorService.GetFloorsByDormitoryId(Convert.ToInt32(reader["Id"]))
                    };
                }
            }

            return dormitory;
        }

        public Dormitory GetDormitoryByNumber(int number)
        {
            _logger.LogInfo($"Getting dormitory by number {number}");

            var query = "SELECT * FROM [Dormitories] WHERE [Number] = " + number;
            var dormitory = new Dormitory();

            using (var reader = _dbConnection.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    dormitory = new Dormitory()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Description = reader["Description"].ToString(),
                        Address = reader["Address"].ToString(),
                        Number = Convert.ToInt32(reader["Number"]),
                        Comendant = _administratorService.GetAdministratorById(Convert.ToInt32(reader["ComendantId"])),
                        Floors = _floorService.GetFloorsByDormitoryId(Convert.ToInt32(reader["Id"]))
                    };
                }
            }

            return dormitory;
        }

        public Dormitory GetDormitoryByDormitoryAdminId(string dormitoryAdminUsername)
        {
            _logger.LogInfo($"Getting dormitory by dormitory admin Id {dormitoryAdminUsername}");

            var administrator = _administratorService.GetAdministratorByUserName(dormitoryAdminUsername);

            var query = "SELECT * FROM [Dormitories] WHERE [ComendantId] = " + administrator.Id;
            var dormitory = new Dormitory();

            using (var reader = _dbConnection.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    dormitory = new Dormitory()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Description = reader["Description"].ToString(),
                        Address = reader["Address"].ToString(),
                        Number = Convert.ToInt32(reader["Number"]),
                        Comendant = _administratorService.GetAdministratorById(Convert.ToInt32(reader["ComendantId"])),
                        Floors = _floorService.GetFloorsByDormitoryId(Convert.ToInt32(reader["Id"]))
                    };
                }
            }

            return dormitory;
        }

        public bool InsertDormitory(Dormitory dormitory)
        {
            _logger.LogInfo($"Inserting dormitory '{dormitory.Number}'");

            var rowAffected = _dbConnection.Execute(@"INSERT INTO Dormitories([Description],[Address],[Number],[ComendantId])
                                        VALUES(@DormitoryDescription,@DormitoryAddress,@DormitoryNumber,@DormitoryComendantId)", new
            {
                DormitoryDescription = dormitory.Description,
                DormitoryAddress = dormitory.Address,
                DormitoryNumber = dormitory.Number,
                DormitoryComendantId = dormitory.Comendant.Id
            });

            return rowAffected > 0;
        }
    }
}