using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dormitories.Authentication;
using Dormitories.Models;
using Dormitories.Services.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Dormitories.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        [HttpPost("token")]
        public async Task Token([FromBody]User user)
        {
            var username = user.Username;
            var password = user.PasswordHash;
            var identity = GetIdentity(username, password);

            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Логін або пароль не вірний!");
                return;
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name,
                role = identity.Claims.ToList()[1].Value
            };

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        [HttpPost("changePassword")]
        public async Task Token([FromBody]ChangePasswordModel changePasswordModel)
        {
            var userService = new UserService();

            if (changePasswordModel.NewPassword == changePasswordModel.ConfirmationNewPassword)
            {
                var user = userService.GetUserByUserName(changePasswordModel.Username);
                
                if(user == null)
                {
                    await Response.WriteAsync("Старий пароль не вірний");
                }

                ChangePassword(changePasswordModel.Username, changePasswordModel.NewPassword);
            }
            else
            {
                await Response.WriteAsync("Паролі не співпадають");
            }
            //var identity = GetIdentity(username, password);

            //if (identity == null)
            //{
            //    Response.StatusCode = 400;
            //    await Response.WriteAsync("Логін або пароль не вірний!");
            //    return;
            //}

            //var now = DateTime.UtcNow;
            //var jwt = new JwtSecurityToken(
            //    issuer: AuthOptions.ISSUER,
            //    audience: AuthOptions.AUDIENCE,
            //    notBefore: now,
            //    claims: identity.Claims,
            //    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            //    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            //var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            //var response = new
            //{
            //    access_token = encodedJwt,
            //    username = identity.Name,
            //    role = identity.Claims.ToList()[1].Value
            //};

            //Response.ContentType = "application/json";
            await Response.WriteAsync("All done");
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var userService = new UserService();
            User user = userService.GetUserByUserName(username);

            //if (user != null && Convert.ToBase64String(Encoding.UTF8.GetBytes(password)) == user.PasswordHash)
            if (user != null && password.Equals(user.PasswordHash))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }

            return null;
        }

        private bool ChangePassword(string username, string newPassword)
        {
            var newPasswordHash = Convert.ToBase64String(Encoding.UTF8.GetBytes(newPassword));
            var userService = new UserService();

            return userService.ChangePassword(username, newPasswordHash);
        }
    }
}