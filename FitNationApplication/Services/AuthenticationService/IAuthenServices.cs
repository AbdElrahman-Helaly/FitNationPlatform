using FitNationApplication.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitNationApplication.Services.AuthenthicationService
{
    public interface IAuthenServices
    {
        Task<AuthenResultDto> RegisterAsync(RegisterReqDto reqDto);
        Task<AuthenResultDto> LoginAsync(LoginReqDTO request);

    }
}
