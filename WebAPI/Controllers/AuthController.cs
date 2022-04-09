using Business.Abstact;
using Business.Constans;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("Login")]
        public ActionResult Login(UserLoginDto userLoginDto)
        {
            var userToLogin = authService.Login(userLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Register")]
        public ActionResult Register(UserRegisterDto userForRegisterDto)
        {
            if (userForRegisterDto != null)
            {
                var userExists = authService.IsUserExists(userForRegisterDto.Email);
                if (!userExists.Success)
                {
                    return BadRequest(userExists.Message);
                }

                var registerResult = authService.RegisterUser(userForRegisterDto);
                if (registerResult.Success)
                {
                    var result = authService.CreateAccessToken(registerResult.Data);
                    if (result.Success)
                    {
                        return Ok(result);
                    }

                    return BadRequest(result.Message);
                }
                return BadRequest(registerResult.Message);

            }
            return BadRequest("Dto cannot be null !");

        }
    }
}
