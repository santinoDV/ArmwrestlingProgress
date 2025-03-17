using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Login;

namespace Application.Contracts
{
    public interface IUser
    {
        Task<RegisterUserResponse> RegisterUserAsync(RegisterUserDTO register);
        Task<LoginResponse> LoginUserAsync(LoginDTO login);
    }
}
