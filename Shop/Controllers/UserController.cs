using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Host.DTOs.Users;
using Shop.Host.Models;
using Shop.Host.Models.Identity;
using Shop.Host.Security;

namespace Shop.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterDTO dto)
        {
            string userId = Guid.NewGuid().ToString();
            ApplicationUserRole userRole = new ApplicationUserRole()
            {
                RoleId = ApplicationRolesConst.ApplicationUserRoleId,
                UserId = userId
            };
            List<ApplicationUserRole> LST = new List<ApplicationUserRole>();
            LST.Add(userRole);
            ApplicationUser identityUser = new ApplicationUser()
            {
                Id = userId,
                UserName = dto.UserName,
                PasswordHash = HashGenerator.GenerateHash(dto.Password),
                UserRoles = LST
            };
            var user = _userManager.CreateAsync(identityUser).Result;
            if (user != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDTO dto)
        {
            var user = _userManager.FindByNameAsync(dto.UserName).Result;
            if (user.PasswordHash == HashGenerator.GenerateHash(dto.Password))
            {
                string token = TokenGenerator.GenerateEncodedToken(user);
                return Ok(token);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}