using System.Collections.Generic;
using Dormitories.Models;

namespace Dormitories.Services
{
    public interface IStudentCategoryService
    {
        List<StudentCategory> GetStudentCategories();
        StudentCategory GetStudentCategoryById(int id);
        bool UpdateStudentCategory(StudentCategory studentCategory);
        bool DeleteStudentCategoryById(int studentCategoryId);
        bool InsertStudentCategory(StudentCategory studentCategory);
    }
}