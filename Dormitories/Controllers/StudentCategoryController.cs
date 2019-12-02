using System.Collections.Generic;
using Dormitories.Models;
using Dormitories.Services;
using Dormitories.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dormitories.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class StudentCategoryController : Controller
    {
        private readonly IStudentCategoryService _studentCategoryService = new StudentCategoryService();

        // GET: api/studentCategories
        [HttpGet]
        [Route("api/studentCategories")]
        public List<StudentCategory> GetStudentCategories()
        {
            return _studentCategoryService.GetStudentCategories();
        }

        // GET: api/studentCategories/{studentCategoryId}
        [HttpGet]
        [Route("api/studentCategories/{studentCategoryId}")]
        public StudentCategory GetStudentCategoryById(int studentCategoryId)
        {
            return _studentCategoryService.GetStudentCategoryById(studentCategoryId);
        }

        // DELETE: api/studentCategories/{studentCategoryId}
        [HttpDelete]
        [Route("api/studentCategories/{studentCategoryId}")]
        public bool DeleteStudentCategory(int studentCategoryId)
        {
            return _studentCategoryService.DeleteStudentCategoryById(studentCategoryId);
        }

        // UPDATE: api/studentCategories
        [HttpPut]
        [Route("api/studentCategories")]
        public bool UpdateStudentCategory([FromBody]StudentCategory studentCategory)
        {
            return _studentCategoryService.UpdateStudentCategory(studentCategory);
        }

        // INSERT: api/studentCategories
        [HttpPost]
        [Route("api/studentCategories")]
        public bool InsertStudentCategory([FromBody]StudentCategory studentCategory)
        {
            return _studentCategoryService.InsertStudentCategory(studentCategory);
        }
    }
}