using System.Collections.Generic;
using Dormitories.Models;

namespace Dormitories.Services
{
    public interface IAdministratorService
    {
        List<Administrator> GetAdministrators();
        Administrator GetAdministratorByUserName(string username);
        Administrator GetAdministratorById(int id);
        void AddAdministrator(AdminCreateDto administrator);
    }
}