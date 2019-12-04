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
    public class StudentCategoryService : IStudentCategoryService
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger _logger;

        public StudentCategoryService()
        {
            _dbConnection = DBAccess.GetDbConnection();
            _logger = new FileLogger();
        }

        public List<StudentCategory> GetStudentCategories()
        {
            _logger.LogInfo($"Getting student categories");

            return _dbConnection
                .Query<StudentCategory>("SELECT * FROM [StudentCategories] ORDER BY [Priority]")
                .ToList();
        }

        public StudentCategory GetStudentCategoryById(int id)
        {
            _logger.LogInfo($"Getting student category by Id {id}");

            return _dbConnection
                .Query<StudentCategory>("SELECT * FROM [StudentCategories] WHERE [Id] = " + id)
                .SingleOrDefault();
        }

        public bool DeleteDormitoryById(int dormitoryId)
        {
            _logger.LogInfo($"Deleting dormitory by Id {dormitoryId}");

            var rowsAffected = _dbConnection
                .Execute(@"DELETE FROM [Dormitories] 
                           WHERE Id = @DormitoryId", new { DormitoryId = dormitoryId });

            return rowsAffected > 0;
        }

        public bool InsertStudentCategory(StudentCategory studentCategory)
        {
            _logger.LogInfo($"Inserting student category {studentCategory.Description}");

            var rowsAffected = _dbConnection.Execute(@"INSERT INTO [StudentCategories]([Description], [Priority]) 
                                        VALUES(@StudentCategoryDescription, @StudentCategoryPriority)", new { StudentCategoryDescription = studentCategory.Description, StudentCategoryPriority = studentCategory.Priority });

            return rowsAffected > 0;
        }

        public bool DeleteStudentCategoryById(int studentCategoryId)
        {
            _logger.LogInfo($"Delete student category by Id {studentCategoryId}");

            var rowsAffected = _dbConnection
                .Execute(@"DELETE FROM [StudentCategories] 
                           WHERE Id = @StudentCategoryId", new { StudentCategoryId = studentCategoryId });

            return rowsAffected > 0;
        }

        public bool UpdateStudentCategory(StudentCategory studentCategory)
        {
            _logger.LogInfo($"Updating student category {studentCategory.Id}");

            int rowsAffected = _dbConnection.Execute(@"UPDATE [StudentCategories] 
                                                       SET [Description] = @StudentCategoryDescription, [Priority] = @StudentCategoryPriority 
                                                       WHERE Id = @StudentCategoryId", new
            {
                StudentCategoryId = studentCategory.Id,
                StudentCategoryDescription = studentCategory.Description,
                StudentCategoryPriority = studentCategory.Priority
            });

            return rowsAffected > 0;
        }

    }
}
