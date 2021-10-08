using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Models;
using TodoListApp.Models.Dto.Request;
using TodoListApp.Services;

namespace TodoListApp.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService auth;

        public AuthController( IAuthService auth)
        {
            this.auth = auth;
        }
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var loginResult = auth.Login(loginDto);
            if (loginResult.Result == null)
            {
                return Unauthorized();
            }
            return Ok(loginResult.Result);
        }
    }
}
