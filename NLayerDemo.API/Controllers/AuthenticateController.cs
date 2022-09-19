using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using NLayerDemo.API.Abstraction;
using NLayerDemo.Core.DTOs.Authentication;

namespace NLayerDemo.API.Controllers
{
    [ApiController]
    [Route("Authenticate")]
    public class AuthenticateController : ControllerBase
    {

        private readonly IConfiguration configuration;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public AuthenticateController(IConfiguration configuration, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.configuration = configuration;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }


        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequestDto request)
        {
            if (request.UserName != configuration["Authentication:UserName"] || request.Password != configuration["Authentication:password"])
            {
                return Unauthorized();
            }
            else
            {
                var token = jwtAuthenticationManager.Authenticate(request.UserName, request.Password);

                if (token == null)
                    return Unauthorized();
                return Ok(token);
            }
        }
    }
}
