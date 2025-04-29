using System;
using System.Collections.Generic;
using System.Text;

namespace FitNation.Core.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(string userId, string email);

    }
}
