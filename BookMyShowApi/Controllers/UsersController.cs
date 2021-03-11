using BookMyShowApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShowApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserManager<User> UserManager;
        private readonly ApplicationSettings AppSettings;

        public UsersController(UserManager<User> userManager, IOptions<ApplicationSettings> appSettings)
        {
            this.UserManager = userManager;
            this.AppSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("register")]
        //POST: api/user/register
        public async Task<object> PostUser(UserModel model)
        {
            model.Role = "user";
            var newUser = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName
            };
            try
            {
                var result = await UserManager.CreateAsync(newUser, model.Password);
                await UserManager.AddToRoleAsync(newUser, model.Role);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("login")]
        //POST: api/user/login
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await UserManager.FindByNameAsync(model.UserName);
            var role = await UserManager.GetRolesAsync(user);
            IdentityOptions _options = new IdentityOptions();

            if (user != null && await UserManager.CheckPasswordAsync(user, model.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }
    }
}
