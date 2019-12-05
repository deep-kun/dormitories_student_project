using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dormitories.Authentication;
using Dormitories.Models;
using Dormitories.Services;
using Dormitories.Services.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Dormitories.Loggers;

namespace Dormitories.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private IAdministratorService administratorService = new AdministratorService();
        private readonly ILogger _logger = new FileLogger();

        [HttpPost("register")]
        public async Task Register([FromBody]AdminCreateDto administrator)
        {
            _logger.LogInfo("API HttpPost api/Account/register");

            try
            {
                var rawPassword = administrator.PasswordHash;
                administrator.PasswordHash = GetHashFromString(administrator.PasswordHash);
                administratorService.AddAdministrator(administrator);
                var identity = GetIdentity(administrator.Username, rawPassword);
                var encodedJwt = GetToken(administrator.Username, rawPassword);

                var response = new
                {
                    access_token = encodedJwt,
                    username = identity.Name,
                    role = identity.Claims.ToList()[1].Value
                };

                Response.ContentType = "application/json";
                await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));

            }
            catch (Exception e)
            {
                _logger.LogError("API HttpPost api/Account/register " + e.Message);
                await Response.WriteAsync(JsonConvert.SerializeObject(new { error = e.Message}, new JsonSerializerSettings { Formatting = Formatting.Indented }));
            }
        }

        [HttpPost("token")]
        public async Task Token([FromBody]User user)
        {
            _logger.LogInfo("API HttpPost api/Account/token");

            try
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

                var encodedJwt = GetToken(username, password);

                var response = new
                {
                    access_token = encodedJwt,
                    username = identity.Name,
                    role = identity.Claims.ToList()[1].Value
                };

                Response.ContentType = "application/json";
                await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
            }
            catch (Exception e)
            {
                _logger.LogError("API HttpPost api/Account/token " + e.Message);
            }          
        }

        [HttpPost("changePassword")]
        public async Task Token([FromBody]ChangePasswordModel changePasswordModel)
        {
            _logger.LogInfo("API HttpPost api/Account/changePassword");

            var userService = new UserService();

            try
            {
                if (changePasswordModel.NewPassword == changePasswordModel.ConfirmationNewPassword)
                {
                    var user = userService.GetUserByUserName(changePasswordModel.Username);

                    if (user == null)
                    {
                        await Response.WriteAsync("Старий пароль не вірний");
                    }

                    ChangePassword(changePasswordModel.Username, changePasswordModel.NewPassword);
                }
                else
                {
                    await Response.WriteAsync("Паролі не співпадають");
                }

                await Response.WriteAsync("All done");
            }
            catch (Exception e)
            {
                _logger.LogError("API HttpPost api/Account/changePassword  " + e.Message);
            }
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var userService = new UserService();
            User user = userService.GetUserByUserName(username);

            if (user != null && Convert.ToBase64String(Encoding.UTF8.GetBytes(password)) == user.PasswordHash)
            //if (user != null && password.Equals(user.PasswordHash))
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

        private string GetToken(string userName, string password)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: GetIdentity(userName, password).Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        private string GetHashFromString(string value)
            => Convert.ToBase64String(Encoding.UTF8.GetBytes(value));

    }
}