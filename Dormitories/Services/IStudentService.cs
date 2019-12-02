using System.Collections.Generic;
using Dormitories.Models;

namespace Dormitories.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student GetStudentByUserName(string username);
        List<Student> GetStudentsByRoomId(int roomId);
        bool DeleteStudentById(int studentId);
        bool InsertStudent(Student student);
        bool UpdateStudent(Student student);
        List<Student> GetStudentsWhichDoNotHaveRoom();
        List<Student> GetStudentByFullNameContains(string studentFullName);
        bool SettleStudent(int studentId, int roomId);
        bool EvictionStudent(int studentId);
    }
}