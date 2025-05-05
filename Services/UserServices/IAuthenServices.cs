using FitNation.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Text;


public interface IAuthenServices
{
    Task<AuthenResultDto> RegisterAsync(RegisterReqDto reqDto);
    Task<AuthenResultDto> LoginAsync(LoginReqDTO request);

}

