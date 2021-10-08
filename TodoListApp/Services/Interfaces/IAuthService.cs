using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Models.Dto.Request;

namespace TodoListApp.Services
{
    public interface IAuthService
    {
        Task<string> Login(LoginDto loginDto);
        void Logout();
    }
}
