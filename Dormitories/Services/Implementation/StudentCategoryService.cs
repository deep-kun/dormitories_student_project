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
    public class StudentCategoryService : IStudentCategoryService
    {
        private readonly IDbConnection _dbConnection;

        public StudentCategoryService()
        {
            _dbConnection = DBAccess.GetDbConnection();
        }

        public List<StudentCategory> GetStudentCategories()
        {
            return _dbConnection
                .Query<StudentCategory>("SELECT * FROM [StudentCategories] ORDER BY [Priority]")
                .ToList();
        }

        public StudentCategory GetStudentCategoryById(int id)
        {
            return _dbConnection
                .Query<StudentCategory>("SELECT * FROM [StudentCategories] WHERE [Id] = " + id)
                .SingleOrDefault();
        }

        public bool DeleteDormitoryById(int dormitoryId)
        {
            var rowsAffected = _dbConnection
                .Execute(@"DELETE FROM [Dormitories] 
                           WHERE Id = @DormitoryId", new { DormitoryId = dormitoryId });

            return rowsAffected > 0;
        }

        public bool InsertStudentCategory(StudentCategory studentCategory)
        {

            var rowsAffected = _dbConnection.Execute(@"INSERT INTO [StudentCategories]([Description], [Priority]) 
                                        VALUES(@StudentCategoryDescription, @StudentCategoryPriority)", new { StudentCategoryDescription = studentCategory.Description, StudentCategoryPriority = studentCategory.Priority });

            return rowsAffected > 0;
        }

        public bool DeleteStudentCategoryById(int studentCategoryId)
        {
            var rowsAffected = _dbConnection
                .Execute(@"DELETE FROM [StudentCategories] 
                           WHERE Id = @StudentCategoryId", new { StudentCategoryId = studentCategoryId });

            return rowsAffected > 0;
        }

        public bool UpdateStudentCategory(StudentCategory studentCategory)
        {
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
