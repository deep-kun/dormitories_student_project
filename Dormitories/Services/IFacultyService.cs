using System.Collections.Generic;
using Dormitories.Models;

namespace Dormitories.Services
{
    public interface IFacultyService
    {
        List<Faculty> GetFaculties();
        Faculty GetFacultyById(int id);
        bool InsertFaculty(Faculty faculty);
        bool DeleteFacultyById(int facultyId);
        bool UpdateFaculty(Faculty faculty);
    }
}