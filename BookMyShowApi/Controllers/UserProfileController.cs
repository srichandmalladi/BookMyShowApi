using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMyShowApi.Data;
using BookMyShowApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/userProfile")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<User> UserManager;
        public UserProfileController(UserManager<User> userManager)
        {
            UserManager = userManager;
        }

        [HttpGet]
        [Authorize]
        //GET : /api/userProfile
        public async Task<object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await UserManager.FindByIdAsync(userId);
            return new
            {
                user.Id,
                user.FullName,
                user.Email,
                user.UserName
            };
        }
    }
}