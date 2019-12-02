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

namespace Dormitories.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService = new StudentService();
        private readonly RoomService _roomService = new RoomService();

        // GET: api/students
        [HttpGet]
        [Route("api/students")]
        public List<Student> GetStudents()
        {
            return _studentService.GetStudents();
        }

        // GET: api/students/{studentUsername}
        [HttpGet]
        [Route("api/students/{studentUsername}")]
        public Student GetStudentById(string studentUsername)
        {
            return _studentService.GetStudentByUserName(studentUsername);
        }

        // GET: api/students/search/{studentFullName}
        [HttpGet]
        [Route("api/students/search/{studentFullName}")]
        public List<Student> GetStudentByFullNameContains(string studentFullName)
        {
            return _studentService.GetStudentByFullNameContains(studentFullName);
        }

        // GET: api/students/notSettle
        [HttpGet]
        [Route("api/students/notSettle")]
        public List<Student> GetStudentsWhichDoNotHaveRoom()
        {
            return _studentService.GetStudentsWhichDoNotHaveRoom();
        }

        // Settle: api/students/settle/{studentId}/{roomId}
        [HttpGet]
        [Route("api/students/settle/{studentId}/{roomId}")]
        public bool SettleStudent(int studentId, int roomId)
        {
            var returnValue = _studentService.SettleStudent(studentId, roomId);

            if (returnValue)
            {
                _roomService.RoomFreePlacesToLower(roomId);
            }

            return returnValue;
        }

        // Eviction: api/students/eviction/{studentId}/{roomId}
        [HttpGet]
        [Route("api/students/eviction/{studentId}/{roomId}")]
        public bool EvictionStudent(int studentId, int roomId)
        {
            var returnValue = _studentService.EvictionStudent(studentId);

            if (returnValue)
            {
                _roomService.RoomFreePlacesToUpper(roomId);
            }

            return returnValue;
        }

        // INSERT: api/students
        [HttpPost]
        [Route("api/students")]
        public bool InsertStudent([FromBody]Student student)
        {
            return _studentService.InsertStudent(student);
        }
    }
}