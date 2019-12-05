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
    public class FacultyController : Controller
    {
        private readonly IFacultyService _facultyService = new FacultyService();
        private readonly ILogger _logger = new FileLogger();

        // GET: api/faculties
        [HttpGet]
        [Route("api/faculties")]
        public List<Faculty> GetFaculties()
        {
            _logger.LogInfo("API HttpGet api/faculties");
            try
            {
                return _facultyService.GetFaculties();
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/faculties  " + e.Message);
                throw e;
            }
        }

        // GET: api/faculties/{facultyId}
        [HttpGet]
        [Route("api/faculties/{facultyId}")]
        public Faculty GetFacultyById(int facultyId)
        {
            _logger.LogInfo("API HttpGet api/faculties/{facultyId}");
            try
            {
                return _facultyService.GetFacultyById(facultyId);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/faculties/{facultyId}  " + e.Message);
                throw e;
            }
        }

        // DELETE: api/faculties/{facultyId}
        [HttpDelete]
        [Route("api/faculties/{facultyId}")]
        public bool DeleteFaculty(int facultyId)
        {
            _logger.LogInfo("API HttpDelete api/faculties/{facultyId}");
            try
            {
                return _facultyService.DeleteFacultyById(facultyId);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpDelete api/faculties/{facultyId}  " + e.Message);
                throw e;
            }
        }

        // UPDATE: api/faculties
        [HttpPut]
        [Route("api/faculties")]
        public bool UpdateFaculty([FromBody]Faculty faculty)
        {
            _logger.LogInfo("API HttpPut api/faculties");
            try
            {
                return _facultyService.UpdateFaculty(faculty);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPut api/faculties  " + e.Message);
                throw e;
            }
        }

        // INSERT: api/faculties
        [HttpPost]
        [Route("api/faculties")]
        public bool InsertFaculty([FromBody]Faculty faculty)
        {
            _logger.LogInfo("API HttpPost api/faculties");
            try
            {
                return _facultyService.InsertFaculty(faculty);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPost api/faculties  " + e.Message);
                throw e;
            }
        }
    }
}