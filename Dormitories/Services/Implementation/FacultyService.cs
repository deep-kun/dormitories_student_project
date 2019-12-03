using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Dormitories.Authentication;
using Dormitories.Models;
using Dormitories.Loggers;

namespace Dormitories.Services.Implementation
{
    public class FacultyService : IFacultyService
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger _logger;

        public FacultyService()
        {
            _dbConnection = DBAccess.GetDbConnection();
            _logger = new FileLogger();
        }

        public List<Faculty> GetFaculties()
        {
            _logger.LogInfo("Getting faculties");

            return _dbConnection
                .Query<Faculty>("SELECT * FROM [Faculties]")
                .ToList();
        }

        public Faculty GetFacultyById(int id)
        {
            _logger.LogInfo($"Getting faculty by Id {id}");

            return _dbConnection
                .Query<Faculty>("SELECT * FROM [Faculties] WHERE [Id] = " + id)
                .SingleOrDefault();
        }

        public bool InsertFaculty(Faculty faculty)
        {
            _logger.LogInfo($"Inserting faculty {faculty.Name}");

            var rowsAffected = _dbConnection.Execute(@"INSERT INTO [Faculties]([Name]) 
                                        VALUES(@FacultyName)", new { FacultyName = faculty.Name });

            return rowsAffected > 0;
        }

        public bool DeleteFacultyById(int facultyId)
        {
            _logger.LogInfo($"Deleting faculty by Id {facultyId}");

            var rowsAffected = _dbConnection
                .Execute(@"DELETE FROM [Faculties]
                           WHERE Id = @FacultyId", new { FacultyId = facultyId });

            return rowsAffected > 0;
        }

        public bool UpdateFaculty(Faculty faculty)
        {
            _logger.LogInfo($"Updating faculty {faculty.Id}");

            int rowsAffected = _dbConnection.Execute(@"UPDATE [Faculties] 
                                                       SET [Name] = @FacultyName
                                                       WHERE Id = " + faculty.Id, new { FacultyName = faculty.Name });

            return rowsAffected > 0;
        }
    }
}