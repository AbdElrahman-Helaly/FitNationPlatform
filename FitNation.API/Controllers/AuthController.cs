using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using FitNation.Core.Interfaces.Services;
using FitNation.Core.DTOS;
using FitNation.Core.Validators;
using FluentValidation;


namespace FitNation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenServices _authService;

        public AuthController(IAuthenServices authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("AuthController is working");
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterReqDto request)
        {
            var validtor = new CreateUserValidator();
            var validationResult = await validtor.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(new { Errors = validationResult.Errors });
            }
           
            var result = await _authService.RegisterAsync(request);

            if (!result.Success)
            {
                return BadRequest(new { Errors = result.Errors });
            }

            return Ok(new { Token = result.Token });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginReqDTO request)
        {
            var validtor = new LoginUserValiddator();
            var validationResult = await validtor.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(new { Errors = validationResult.Errors });
            }


            var result = await _authService.LoginAsync(request);

            if (!result.Success)
            {
                return Unauthorized(new { Errors = result.Errors });
            }

            return Ok(new { Token = result.Token });
        }
    }
}
