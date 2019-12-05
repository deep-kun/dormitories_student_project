using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dormitories.Models;
using Dormitories.Services;
using Dormitories.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dormitories.Loggers;

namespace Dormitories.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService = new StudentService();
        private readonly RoomService _roomService = new RoomService();
        private readonly ILogger _logger = new FileLogger();

        // GET: api/students
        [HttpGet]
        [Route("api/students")]
        public List<Student> GetStudents()
        {
            _logger.LogInfo("API HttpGet api/students");
            try
            {
                return _studentService.GetStudents();
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPost api/studentCategories  " + e.Message);
                throw e;
            }
        }

        // GET: api/students/{studentUsername}
        [HttpGet]
        [Route("api/students/{studentUsername}")]
        public Student GetStudentById(string studentUsername)
        {
            _logger.LogInfo("API HttpGet api/students/{studentUsername}");
            try
            {
                return _studentService.GetStudentByUserName(studentUsername);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPost api/studentCategories  " + e.Message);
                throw e;
            }
        }

        // GET: api/students/search/{studentFullName}
        [HttpGet]
        [Route("api/students/search/{studentFullName}")]
        public List<Student> GetStudentByFullNameContains(string studentFullName)
        {
            _logger.LogInfo("API HttpGet api/students/search/{studentFullName}");
            try
            {
                return _studentService.GetStudentByFullNameContains(studentFullName);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPost api/studentCategories  " + e.Message);
                throw e;
            }
        }

        // GET: api/students/notSettle
        [HttpGet]
        [Route("api/students/notSettle")]
        public List<Student> GetStudentsWhichDoNotHaveRoom()
        {
            _logger.LogInfo("API HttpGet api/students/notSettle");
            try
            {
                return _studentService.GetStudentsWhichDoNotHaveRoom();
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/students/notSettle  " + e.Message);
                throw e;
            }
        }

        // Settle: api/students/settle/{studentId}/{roomId}
        [HttpGet]
        [Route("api/students/settle/{studentId}/{roomId}")]
        public bool SettleStudent(int studentId, int roomId)
        {
            _logger.LogInfo("API HttpGet api/students/settle/{studentId}/{roomId}");
            try
            {
                var returnValue = _studentService.SettleStudent(studentId, roomId);

                if (returnValue)
                {
                    _roomService.RoomFreePlacesToLower(roomId);
                }

                return returnValue;
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/students/settle/{studentId}/{roomId}  " + e.Message);
                throw e;
            }
        }

        // Eviction: api/students/eviction/{studentId}/{roomId}
        [HttpGet]
        [Route("api/students/eviction/{studentId}/{roomId}")]
        public bool EvictionStudent(int studentId, int roomId)
        {
            _logger.LogInfo("API HttpGet api/students/eviction/{studentId}/{roomId}");
            try
            {
                var returnValue = _studentService.EvictionStudent(studentId);

                if (returnValue)
                {
                    _roomService.RoomFreePlacesToUpper(roomId);
                }

                return returnValue;
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpGet api/students/eviction/{studentId}/{roomId}  " + e.Message);
                throw e;
            }
        }

        // INSERT: api/students
        [HttpPost]
        [Route("api/students")]
        public bool InsertStudent([FromBody]Student student)
        {
            _logger.LogInfo("API HttpPost api/students");
            try
            {
                return _studentService.InsertStudent(student);
            }
            catch (System.Exception e)
            {
                _logger.LogError("API HttpPost api/students  " + e.Message);
                throw e;
            }
        }
    }
}