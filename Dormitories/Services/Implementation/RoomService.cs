using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Dormitories.Authentication;
using Dormitories.Models;

namespace Dormitories.Services.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly IDbConnection _dbConnection;
        private readonly IFacultyService _facultyService;
        private readonly IGroupService _groupService;
        private readonly IStudentCategoryService _studentCategoryService;
        private readonly IUserService _userService;

        public RoomService()
        {
            _dbConnection = DBAccess.GetDbConnection();
            _facultyService = new FacultyService();
            _groupService = new GroupService();
            _studentCategoryService = new StudentCategoryService();
            _userService = new UserService();
        }

        public Room GetSimpleRoomById(int id)
        {
            return _dbConnection
                .Query<Room>("SELECT * FROM [Rooms] WHERE [Id] = " + id)
                .SingleOrDefault();
        }

        public Room GetRoomWithStudents(int id)
        {
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
            List<Room> rooms = new List<Room>();
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
            var rowsAffected = _dbConnection
                .Execute(@"DELETE FROM [Rooms] 
                           WHERE Id = @RoomId", new { RoomId = roomId });

            return rowsAffected > 0;
        }

        public bool UpdateRoom(Room room)
        {
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