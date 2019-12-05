using System.Collections.Generic;
using Dormitories.Models;
using Dormitories.Services;
using Dormitories.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dormitories.Loggers;

namespace Dormitories.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class StudentCategoryController : Controller
    {
        private readonly IStudentCategoryService _studentCategoryService = new StudentCategoryService();
        private readonly ILogger _logger = new FileLogger();

        // GET: api/studentCategories
        [HttpGet]
        [Route("api/studentCategories")]
        public List<StudentCategory> GetStudentCategories()
        {
            _logger.LogInfo("API HttpGet api/studentCategories");
            try
            {
                return _studentCategoryService.GetStudentCategories();
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/studentCategories  " + e.Message);
                throw e;
            }
        }

        // GET: api/studentCategories/{studentCategoryId}
        [HttpGet]
        [Route("api/studentCategories/{studentCategoryId}")]
        public StudentCategory GetStudentCategoryById(int studentCategoryId)
        {
            _logger.LogInfo("API HttpGet api/studentCategories/{studentCategoryId}");
            try
            {
                return _studentCategoryService.GetStudentCategoryById(studentCategoryId);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/studentCategories/{studentCategoryId}  " + e.Message);
                throw e;
            }
        }

        // DELETE: api/studentCategories/{studentCategoryId}
        [HttpDelete]
        [Route("api/studentCategories/{studentCategoryId}")]
        public bool DeleteStudentCategory(int studentCategoryId)
        {
            _logger.LogInfo("API HttpDelete api/studentCategories/{studentCategoryId}");
            try
            {
                return _studentCategoryService.DeleteStudentCategoryById(studentCategoryId);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpDelete api/studentCategories/{studentCategoryId}  " + e.Message);
                throw e;
            }
        }

        // UPDATE: api/studentCategories
        [HttpPut]
        [Route("api/studentCategories")]
        public bool UpdateStudentCategory([FromBody]StudentCategory studentCategory)
        {
            _logger.LogInfo("API HttpPut api/studentCategories");
            try
            {
                return _studentCategoryService.UpdateStudentCategory(studentCategory);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPut api/studentCategories  " + e.Message);
                throw e;
            }
        }

        // INSERT: api/studentCategories
        [HttpPost]
        [Route("api/studentCategories")]
        public bool InsertStudentCategory([FromBody]StudentCategory studentCategory)
        {
            _logger.LogInfo("API HttpPost api/studentCategories");
            try
            {
                return _studentCategoryService.InsertStudentCategory(studentCategory);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPost api/studentCategories  " + e.Message);
                throw e;
            }
        }
    }
}