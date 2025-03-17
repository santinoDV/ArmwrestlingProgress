using Application.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.Authentication;
using Microsoft.Extensions.Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using Application.DTOs.Login;

namespace Infrastructure.Repo
{
    internal class UserRepo : IUser
    {
        private readonly AppDbContext _dbContext;
        private readonly JwtService _jwtService;



        public UserRepo (AppDbContext appDbContext, IConfiguration configuration,JwtService jwtservice)
        {
            this._dbContext = appDbContext;
            this._jwtService = jwtservice;
        }

        public async Task<LoginResponse> LoginUserAsync(LoginDTO loginDTO)
        {
            var getUser = await FindUserByEmailAsync(loginDTO.Email!);

            if (getUser == null) return new LoginResponse(false, "Sorry user no found.");

            bool checkPassword = BCrypt.Net.BCrypt.Verify(loginDTO.Password, getUser.Password);

            if (checkPassword) return new LoginResponse(true, "Login succesful",
                _jwtService.GenerateJWToken(getUser));
            else return new LoginResponse(false, "password incorrect");
        }


        public async Task<RegisterUserResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO)
        {
            var getUser = await FindUserByEmailAsync(registerUserDTO.Email!);
            if (getUser != null) return new RegisterUserResponse(false, "usuario ya existente");

            _dbContext.Users.Add(new ApplicationUser()
            {
                Email = registerUserDTO.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.Password),    
                Name = registerUserDTO.Name,
            });

            await _dbContext.SaveChangesAsync();

            return new RegisterUserResponse(true, "user account Created");
        }

        private async Task<ApplicationUser> FindUserByEmailAsync(string email) =>
               await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

    }
}
