using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Dormitories.Authentication;
using Dormitories.Models;

namespace Dormitories.Services.Implementation
{
    public class FacultyService : IFacultyService
    {
        private readonly IDbConnection _dbConnection;

        public FacultyService()
        {
            _dbConnection = DBAccess.GetDbConnection();
        }

        public List<Faculty> GetFaculties()
        {
            return _dbConnection
                .Query<Faculty>("SELECT * FROM [Faculties]")
                .ToList();
        }

        public Faculty GetFacultyById(int id)
        {
            return _dbConnection
                .Query<Faculty>("SELECT * FROM [Faculties] WHERE [Id] = " + id)
                .SingleOrDefault();
        }

        public bool InsertFaculty(Faculty faculty)
        {
            var rowsAffected = _dbConnection.Execute(@"INSERT INTO [Faculties]([Name]) 
                                        VALUES(@FacultyName)", new { FacultyName = faculty.Name });

            return rowsAffected > 0;
        }

        public bool DeleteFacultyById(int facultyId)
        {
            var rowsAffected = _dbConnection
                .Execute(@"DELETE FROM [Faculties]
                           WHERE Id = @FacultyId", new { FacultyId = facultyId });

            return rowsAffected > 0;
        }

        public bool UpdateFaculty(Faculty faculty)
        {
            int rowsAffected = _dbConnection.Execute(@"UPDATE [Faculties] 
                                                       SET [Name] = @FacultyName
                                                       WHERE Id = " + faculty.Id, new { FacultyName = faculty.Name });

            return rowsAffected > 0;
        }
    }
}