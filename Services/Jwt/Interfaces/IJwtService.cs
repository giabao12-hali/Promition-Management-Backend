using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using promotion_net.Models.Users;

namespace promotion_net.Services.Jwt.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}