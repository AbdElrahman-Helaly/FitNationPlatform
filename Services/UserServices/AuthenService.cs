
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;

using FitNation.Core.Interfaces.Services;
using FitNation.Core.Models;
using FitNation.Core.Interfaces.Services;
using FitNation.Core.DTOS;


namespace FitNation.Services.UserServices
{
    public class AuthenService : IAuthenServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthenService(UserManager<IdentityUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<AuthenResultDto> RegisterAsync(RegisterReqDto reqDto)
        {
            var user = await _userManager.FindByEmailAsync(reqDto.Email);
            if (user != null)
            {
                return new AuthenResultDto
                {
                    Success = false,
                    Errors = new[] { "User with this email already exists" }
                };
            }

            var newuser = new AspNetUser
            {

                Email = reqDto.Email,
                EmailConfirmed = true,
                PhoneNumber = reqDto.PhoneNumber,
                PhoneNumberConfirmed = true,
                LockoutEnabled = true,
                UserName = reqDto.Email

            };

            var result = await _userManager.CreateAsync(newuser,reqDto.Password);


            if (result.Succeeded)
            {
                var token = _tokenService.GenerateToken(newuser.Id,newuser.Email);
                return new AuthenResultDto
                {
                    Success = true,
                    Token = token
                };
            }
            else
            {
                return new AuthenResultDto
                {
                    Success = false,
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }

        }

        public async Task<AuthenResultDto> LoginAsync(LoginReqDTO request)

        {
            var exitingresult =  await _userManager.FindByEmailAsync(request.Email);
           
            if (exitingresult == null)
            {
                return new AuthenResultDto
                {
                    Success = false,
                    Errors = new List<string> { "User not found" }
                };
            }
            var IspassIsvalid = await _userManager.CheckPasswordAsync(exitingresult, request.Password);
           
            if (!IspassIsvalid)
            {
                return new AuthenResultDto
                {
                    Success = false,
                    Errors = new List<string> { "Password is not valid" }
                };
            }

            var token = _tokenService.GenerateToken(exitingresult.Id, exitingresult.Email);
            return new AuthenResultDto
            {
                Success = true,
                Token = token
            };
        }

     
    }
}
