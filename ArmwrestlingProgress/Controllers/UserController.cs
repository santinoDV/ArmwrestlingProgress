using Application.Contracts;
using Application.DTOs.Login;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArmwrestlingProgressAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser user;
        public UserController(IUser _user) 
        { 
            this.user = _user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LogUserIn(LoginDTO loginDTO)
        {
            var result = await user.LoginUserAsync(loginDTO);

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginResponse>> RegisterUserIn(RegisterUserDTO registerDTO)
        {
            var result = await user.RegisterUserAsync(registerDTO);

            return Ok(result);
        } 
    }
}
