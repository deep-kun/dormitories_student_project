using System.Collections.Generic;
using Dormitories.Models;

namespace Dormitories.Services
{
    public interface IDormitoryService
    {
        List<Dormitory> GetDormitories();
        Dormitory GetDormitoryById(int id);
        Dormitory GetDormitoryByDormitoryAdminId(string dormitoryAdminUsername);
        bool InsertDormitory(Dormitory dormitory);
        Dormitory GetDormitoryByNumber(int number);
    }
}