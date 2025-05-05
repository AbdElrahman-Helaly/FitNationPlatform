using System;
using System.Collections.Generic;
using System.Text;

namespace FitNationApplication.Services.AuthenthicationService
{
    public interface ITokenService
    {
        string GenerateToken(string userId, string email);

    }
}
