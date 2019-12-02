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
    public class FacultyController : Controller
    {
        private readonly IFacultyService _facultyService = new FacultyService();

        // GET: api/faculties
        [HttpGet]
        [Route("api/faculties")]
        public List<Faculty> GetFaculties()
        {
            return _facultyService.GetFaculties();
        }

        // GET: api/faculties/{facultyId}
        [HttpGet]
        [Route("api/faculties/{facultyId}")]
        public Faculty GetFacultyById(int facultyId)
        {
            return _facultyService.GetFacultyById(facultyId);
        }

        // DELETE: api/faculties/{facultyId}
        [HttpDelete]
        [Route("api/faculties/{facultyId}")]
        public bool DeleteFaculty(int facultyId)
        {
            return _facultyService.DeleteFacultyById(facultyId);
        }

        // UPDATE: api/faculties
        [HttpPut]
        [Route("api/faculties")]
        public bool UpdateFaculty([FromBody]Faculty faculty)
        {
            return _facultyService.UpdateFaculty(faculty);
        }

        // INSERT: api/faculties
        [HttpPost]
        [Route("api/faculties")]
        public bool InsertFaculty([FromBody]Faculty faculty)
        {
            return _facultyService.InsertFaculty(faculty);
        }
    }
}