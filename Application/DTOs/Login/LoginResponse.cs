using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Login
{
    public record LoginResponse(bool FLag, string message = null!, string Token = null!);

}
