using Application.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Application.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repo
{
    internal class UserRepo : IUser
    {
        private readonly AppDbContext _dbContext;
        
        private readonly IConfiguration _configuration;

        public UserRepo (AppDbContext appDbContext, IConfiguration configuration)
        {
            this._dbContext = appDbContext;
            this._configuration = configuration;

        }

        public async Task<LoginResponse> LoginUserAsync(LoginDTO loginDTO)
        {
            var getUser = await FindUserByEmailAsync(loginDTO.Email!);

            if (getUser == null) return new LoginResponse(false, "Sorry user no found.");

            bool checkPassword = BCrypt.Net.BCrypt.Verify(loginDTO.Password, getUser.Password);

            if (checkPassword) return new LoginResponse(true, "Login succesful", GenerateJWToken(loginDTO));
            else return new LoginResponse(false, "password incorrect");
        }

        private async Task<ApplicationUser> FindUserByEmailAsync(string email) =>
                await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
    }
}
