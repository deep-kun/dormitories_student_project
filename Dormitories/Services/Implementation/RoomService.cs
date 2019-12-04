using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Dormitories.Authentication;
using Dormitories.Models;
using Dormitories.Loggers;

namespace Dormitories.Services.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly IDbConnection _dbConnection;
        private readonly IFacultyService _facultyService;
        private readonly IGroupService _groupService;
        private readonly IStudentCategoryService _studentCategoryService;
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public RoomService()
        {
            _dbConnection = DBAccess.GetDbConnection();
            _facultyService = new FacultyService();
            _groupService = new GroupService();
            _studentCategoryService = new StudentCategoryService();
            _userService = new UserService();
            _logger = new FileLogger();
        }

        public Room GetSimpleRoomById(int id)
        {
            _logger.LogInfo($"Getting simple room by Id {id}");

            return _dbConnection
                .Query<Room>("SELECT * FROM [Rooms] WHERE [Id] = " + id)
                .SingleOrDefault();
        }

        public Room GetRoomWithStudents(int id)
        {
            _logger.LogInfo($"Geting room with students by Id {id}");

            Room room = null;
            var query = @"SELECT * FROM [Rooms] WHERE [Id] = @IdParameter";
            var studentsForThisRoom = GetStudentsByRoomId(id);

            try
            {
                using (var reader = _dbConnection.ExecuteReader(query, new { IdParameter = id }))
                {
                    while (reader.Read())
                    {
                        room = new Room()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            FreePlaces = Convert.ToInt32(reader["FreePlaces"]),
                            TotalPlaces = Convert.ToInt32(reader["TotalPlaces"]),
                            Faculty = _facultyService.GetFacultyById(Convert.ToInt32(reader["FacultyId"])),
                            Students = studentsForThisRoom
                        };
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return room;

        }

        public List<Room> GetRoomsByFloorId(int floorId)
        {
            _logger.LogInfo($"Getting rooms by floor Id {floorId}");

            List <Room> rooms = new List<Room>();
            var query = @"SELECT * FROM [Rooms] WHERE [FloorId] = @FloorIdParameter ORDER BY [Name]";

            try
            {
                using (var reader = _dbConnection.ExecuteReader(query, new
                {
                    FloorIdParameter = floorId
                }))
                {
                    while (reader.Read())
                    {
                        rooms.Add(new Room()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            FreePlaces = Convert.ToInt32(reader["FreePlaces"]),
                            TotalPlaces = Convert.ToInt32(reader["TotalPlaces"]),
                            Faculty = _facultyService.GetFacultyById(Convert.ToInt32(reader["FacultyId"]))
                        });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return rooms;
        }

        public List<Room> GetRoomsByBlockId(int blockId)
        {
            _logger.LogInfo($"Getting rooms by block Id {blockId}");

            List<Room> rooms = new List<Room>();
            var query = @"SELECT * FROM [Rooms] WHERE [BlockId] = @BlockIdParameter ORDER BY [Name]";

            try
            {
                using (var reader = _dbConnection.ExecuteReader(query, new { BlockIdParameter = blockId }))
                {
                    while (reader.Read())
                    {
                        rooms.Add(new Room()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            FreePlaces = Convert.ToInt32(reader["FreePlaces"]),
                            TotalPlaces = Convert.ToInt32(reader["TotalPlaces"]),
                            Faculty = _facultyService.GetFacultyById(Convert.ToInt32(reader["FacultyId"]))
                        });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return rooms;
        }

        public bool InsertRoom(Room room)
        {
            _logger.LogInfo($"Inserting room '{room.Name}'");

            if (room.Block != null)
            {
                _dbConnection.Execute(@"INSERT INTO [Rooms]([TotalPlaces],[FreePlaces],[FacultyId],[BlockId],[Name])
                                        VALUES(@RoomTotalPlaces,@RoomFreePlaces,@RoomFacultyId,@RoomBlockId,@RoomName)", new
                {
                    RoomTotalPlaces = room.TotalPlaces,
                    RoomFreePlaces = room.FreePlaces,
                    RoomFacultyId = room.Faculty.Id,
                    RoomBlockId = room.Block?.Id,
                    RoomName = room.Name
                });

                return true;
            }

            if (room.Floor != null)
            {
                _dbConnection.Execute(@"INSERT INTO [Rooms]([TotalPlaces],[FreePlaces],[FacultyId],[FloorId],[Name])
                                        VALUES(@RoomTotalPlaces,@RoomFreePlaces,@RoomFacultyId,@RoomFloorId,@RoomName)", new
                {
                    RoomTotalPlaces = room.TotalPlaces,
                    RoomFreePlaces = room.FreePlaces,
                    RoomFacultyId = room.Faculty.Id,
                    RoomFloorId = room.Floor?.Id,
                    RoomName = room.Name
                });

                return true;
            }

            return false;
        }

        public bool DeleteRoomById(int roomId)
        {
            _logger.LogInfo($"Deleting room by Id {roomId}");

            var rowsAffected = _dbConnection
                .Execute(@"DELETE FROM [Rooms] 
                           WHERE Id = @RoomId", new { RoomId = roomId });

            return rowsAffected > 0;
        }

        public bool UpdateRoom(Room room)
        {
            _logger.LogInfo($"Updating room by id {room.Id}");

            int rowsAffected = 0;

            if (room.Block?.Id != 0)
            {
                rowsAffected = _dbConnection.Execute(@"UPDATE [Rooms]
                                                       SET [TotalPlaces] = @RoomTotalPlaces,[FreePlaces] = @RoomFreePlaces,
                                                           [FacultyId] = @RoomFacultyId,[BlockId] = @RoomBlockId,[Name] = @RoomName
                                                       WHERE [Id] = " + room.Id, new
                {
                    RoomTotalPlaces = room.TotalPlaces,
                    RoomFreePlaces = room.FreePlaces,
                    RoomFacultyId = room.Faculty.Id,
                    RoomBlockId = room.Block?.Id,
                    RoomName = room.Name
                });
            }
            else if (room.Floor?.Id != 0)
            {
                rowsAffected = _dbConnection.Execute(@"UPDATE [Rooms]
                                                       SET [TotalPlaces] = @RoomTotalPlaces,[FreePlaces] = @RoomFreePlaces,
                                                           [FacultyId] = @RoomFacultyId,[FloorId] = @RoomFloorId,[Name] = @RoomName
                                                       WHERE [Id] = " + room.Id, new
                {
                    RoomTotalPlaces = room.TotalPlaces,
                    RoomFreePlaces = room.FreePlaces,
                    RoomFacultyId = room.Faculty.Id,
                    RoomFloorId = room.Floor?.Id,
                    RoomName = room.Name
                });
            }

            return rowsAffected > 0;
        }

        public void RoomFreePlacesToLower(int roomId)
        {
            _logger.LogInfo("Getting room free places to lower by Id {roomId}");

            var room = GetSimpleRoomById(roomId);

            _dbConnection.Execute(@"UPDATE [Rooms]
                                    SET [FreePlaces] = @RoomFreePlaces
                                    WHERE [Id] = " + room.Id, new
            {
                RoomFreePlaces = room.FreePlaces - 1
            });
        }

        public void RoomFreePlacesToUpper(int roomId)
        {
            _logger.LogInfo($"Getting room free places to upper by Id {roomId}");

            var room = GetSimpleRoomById(roomId);

            _dbConnection.Execute(@"UPDATE [Rooms]
                                    SET [FreePlaces] = @RoomFreePlaces
                                    WHERE [Id] = " + room.Id, new
            {
                RoomFreePlaces = room.FreePlaces + 1
            });
        }

        private List<Student> GetStudentsByRoomId(int roomId)
        {
            _logger.LogInfo($"Getting students by room Id {roomId}");

            var query = "SELECT * FROM [Students] WHERE [RoomId] = " + roomId;
            var students = new List<Student>();

            using (var reader = _dbConnection.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    Faculty faculty = null;
                    Group group = null;

                    if (reader["FacultyId"] != DBNull.Value)
                    {
                        faculty = _facultyService.GetFacultyById(Convert.ToInt32(reader["FacultyId"]));
                    }

                    if (reader["GroupId"] != DBNull.Value)
                    {
                        group = _groupService.GetGroupById(Convert.ToInt32(reader["GroupId"]));
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
                        StudentCardId = reader["StudentCardId"].ToString(),
                        StudyYear = Convert.ToInt32(reader["StudyYear"])
                    });
                }
            }

            return students;
        }

    }
}