using Dapper;
using Dormitories.Authentication;
using Dormitories.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dormitories.Loggers;

namespace Dormitories.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IUserService _userService;
        private readonly IFacultyService _facultyService;
        private readonly IGroupService _groupService;
        private readonly IRoleService _roleService;
        private readonly IRoomService _roomService;
        private readonly IStudentCategoryService _studentCategoryService;
        private readonly IDbConnection _dbConnection;
        private readonly ILogger _logger;

        public StudentService()
        {
            _userService = new UserService();
            _facultyService = new FacultyService();
            _groupService = new GroupService();
            _roomService = new RoomService();
            _roleService = new RoleService();
            _studentCategoryService = new StudentCategoryService();
            _dbConnection = DBAccess.GetDbConnection();
            _logger = new FileLogger();
        }
        public List<Student> GetStudents()
        {
            _logger.LogInfo($"Getting students");

            var query = "SELECT * FROM [Students]";
            var students = new List<Student>();

            using (var reader = _dbConnection.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    Faculty faculty = null;
                    Group group = null;
                    Room room = null;

                    if (reader["FacultyId"] != DBNull.Value)
                    {
                        faculty = _facultyService.GetFacultyById(Convert.ToInt32(reader["FacultyId"]));
                    }

                    if (reader["GroupId"] != DBNull.Value)
                    {
                        group = _groupService.GetGroupById(Convert.ToInt32(reader["GroupId"]));
                    }

                    if (reader["RoomId"] != DBNull.Value)
                    {
                        room = _roomService.GetSimpleRoomById(Convert.ToInt32(reader["RoomId"]));
                    }

                    students.Add(new Student()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Faculty = faculty,
                        FullName = reader["FullName"].ToString(),
                        StudentCategory = _studentCategoryService.GetStudentCategoryById(Convert.ToInt32(reader["CategoryId"])),
                        User = _userService.GetUserById(Convert.ToInt32(reader["UserId"])),
                        Group = group,
                        Room = room,
                        StudentCardId = reader["StudentCardId"].ToString(),
                        StudyYear = Convert.ToInt32(reader["StudyYear"])
                    });
                }
            }

            return students;
        }

        public List<Student> GetStudentsWhichDoNotHaveRoom()
        {
            _logger.LogInfo($"Getting students who have no room");

            var students = new List<Student>();
            var query = @"SELECT * FROM Students WHERE [RoomId] is NULL";

            try
            {
                using (var reader = _dbConnection.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        Faculty faculty = null;
                        Group group = null;
                        Room room = null;

                        if (reader["FacultyId"] != DBNull.Value)
                            faculty = _facultyService.GetFacultyById(Convert.ToInt32(reader["FacultyId"]));

                        if (reader["GroupId"] != DBNull.Value)
                            group = _groupService.GetGroupById(Convert.ToInt32(reader["GroupId"]));

                        if (reader["RoomId"] != DBNull.Value)
                            room = _roomService.GetSimpleRoomById(Convert.ToInt32(reader["RoomId"]));

                        students.Add(new Student()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Email = reader["Email"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Faculty = faculty,
                            FullName = reader["FullName"].ToString(),
                            StudentCategory = _studentCategoryService.GetStudentCategoryById(Convert.ToInt32(reader["CategoryId"])),
                            User = _userService.GetUserById(Convert.ToInt32(reader["UserId"])),
                            Group = group,
                            Room = room,
                            StudentCardId = reader["StudentCardId"].ToString(),
                            StudyYear = Convert.ToInt32(reader["StudyYear"])
                        });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return students;
        }

        public List<Student> GetStudentByFullNameContains(string studentFullName)
        {
            _logger.LogInfo($"Getting student where full name contains '{studentFullName}'");

            var students = GetStudentsWhichDoNotHaveRoom();

            return students.Where(x => x.FullName.Contains(studentFullName)).ToList();
        }

        public Student GetStudentByUserName(string username)
        {
            _logger.LogInfo($"Geting student by user name {username}");

            var user = _userService.GetUserByUserName(username);
            var query = "SELECT * FROM [Students] WHERE [UserId] = @UserIdParameter";
            Student student = null;
            Faculty faculty = null;
            Group group = null;
            Room room = null;

            using (var reader = _dbConnection.ExecuteReader(query, new { UserIdParameter = user.Id }))
            {
                while (reader.Read())
                {
                    if (reader["FacultyId"] != DBNull.Value)
                    {
                        faculty = _facultyService.GetFacultyById(Convert.ToInt32(reader["FacultyId"]));
                    }

                    if (reader["GroupId"] != DBNull.Value)
                    {
                        group = _groupService.GetGroupById(Convert.ToInt32(reader["GroupId"]));
                    }
                     
                    if (reader["FacultyId"] != DBNull.Value)
                    {
                        room = _roomService.GetSimpleRoomById(Convert.ToInt32(reader["FacultyId"]));
                    }

                    student = new Student()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Faculty = faculty,
                        FullName = reader["FullName"].ToString(),
                        StudentCategory = _studentCategoryService.GetStudentCategoryById(Convert.ToInt32(reader["CategoryId"])),
                        User = user,
                        Group = group,
                        Room = room,
                        StudentCardId = reader["StudentCardId"].ToString(),
                        StudyYear = Convert.ToInt32(reader["StudyYear"])
                    };
                }
            }

            return student;
        }

        public bool DeleteStudentById(int studentId)
        {
            _logger.LogInfo($"Deleting student by Id {studentId}");

            var rowsAffected = _dbConnection
                .Execute(@"DELETE FROM [Students] 
                           WHERE Id = @StudentId", new { StudentId = studentId });

            return rowsAffected > 0;
        }

        public bool InsertStudent(Student student)
        {
            _logger.LogInfo($"Inserting student {student.StudentCardId}");

            var user = new User()
            {
                Role = _roleService.GetRoleByName("Student"),
                Username = student.StudentCardId,
                PasswordHash = "QWExMjM0NTY=" //Aa123456
            };
            _userService.InsertUser(user);
            var userId = _userService.GetUserByUserName(user.Username).Id;

            var rowAffected = _dbConnection.Execute(@"INSERT INTO Students([FullName],[FacultyId],[Email],[PhoneNumber],[StudentCardId],[GroupId],[RoomId],[StudyYear],[CategoryId],[UserId])
                                        VALUES(@FullNameParameter,@FacultyIdParameter,@EmailParameter,@PhoneNumberParameter,@StudentCardIdParameter,@GroupIdParameter,@RoomIdParameter,@StudyYearParameter,@CategoryIdParameter,@UserIdParameter)", new
            {
                FullNameParameter = student.FullName,
                FacultyIdParameter = student.Faculty?.Id,
                EmailParameter = student.Email,
                PhoneNumberParameter = student.PhoneNumber,
                StudentCardIdParameter = student.StudentCardId,
                GroupIdParameter = student.Group?.Id,
                RoomIdParameter = student.Room?.Id,
                StudyYearParameter = student.StudyYear,
                CategoryIdParameter = student.StudentCategory?.Id,
                UserIdParameter = userId
            });

            return rowAffected > 0;
        }

        public bool UpdateStudent(Student student)
        {
            _logger.LogInfo($"Updating student {student.Id}");

            throw new NotImplementedException();
        }

        public List<Student> GetStudentsByRoomId(int roomId)
        {
            _logger.LogInfo($"Getting students by room Id {roomId}");

            var query = "SELECT * FROM [Students] WHERE [RoomId] = " + roomId;
            var students = new List<Student>();

            using (var reader = _dbConnection.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    students.Add(new Student()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Faculty = null,
                        FullName = reader["FullName"].ToString(),
                        StudentCategory = _studentCategoryService.GetStudentCategoryById(Convert.ToInt32(reader["CategoryId"])),
                        User = _userService.GetUserById(Convert.ToInt32(reader["UserId"])),
                        Group = null,
                        Room = null,
                        StudentCardId = reader["StudentCardId"].ToString(),
                        StudyYear = Convert.ToInt32(reader["StudyYear"])
                    });
                }
            }

            return students;
        }

        public bool SettleStudent(int studentId, int roomId)
        {
            _logger.LogInfo($"Settling student {studentId} in room {roomId}");

            int rowsAffected = _dbConnection.Execute(@"UPDATE [Students]
                                                       SET 
                                                         [RoomId] = @RoomIdParameter 
                                                       WHERE [Id] = " + studentId,
                new
                {
                    RoomIdParameter = roomId
                });

            return rowsAffected > 0;
        }

        public bool EvictionStudent(int studentId)
        {
            _logger.LogInfo($"Evicting student {studentId}");

            int rowsAffected = _dbConnection.Execute(@"UPDATE [Students]
                                                       SET 
                                                         [RoomId] = NULL 
                                                       WHERE [Id] = " + studentId);

            return rowsAffected > 0;
        }
    }
}
