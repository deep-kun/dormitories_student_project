using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Dormitories.Authentication
{
    public class AuthOptions
    {
        public const string ISSUER = "Dormitories";
        public const string AUDIENCE = "ManagmentFundDormitories";
        const string KEY = "mysupersecret_secretkey!123"; // ключ для шифру
        public const int LIFETIME = 7200; // час життя ключа - 7200 хвилин = 5 днів

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}