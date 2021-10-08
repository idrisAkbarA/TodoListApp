using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Data;

namespace TodoListApp.Controllers
{
    [Authorize]
    [Route("api/v1/user")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var user = this.dbContext.Users;
            return Ok(user);
        }
    }
}
