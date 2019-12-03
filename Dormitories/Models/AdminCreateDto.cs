
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dormitories.Models
{
    public class AdminCreateDto
    {
        public string FullName { get; set; }
        public string Faculty { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
