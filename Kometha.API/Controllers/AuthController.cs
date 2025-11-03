namespace Kometha.API.Controllers
{
    using Kometha.API.Models.DTOs;
    using Kometha.API.Repositories;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepo)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepo;
        }

        // POST: api/Auth/Register        
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username,
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("Usuario registrado");
                    }
                }

                return BadRequest(identityResult.Errors);
            }

            return BadRequest(identityResult.Errors);
        }

        // POST: api/Auth/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);

            if (user != null && await userManager.CheckPasswordAsync(user, loginRequestDto.Password))
            {
                var roles = await userManager.GetRolesAsync(user);

                if (roles != null && roles.Any())
                {
                    var jwt = tokenRepository.CreateJWToken(user, roles.ToList());

                    var response = new LoginResponseDTO
                    {
                        Jwt = jwt
                    };

                    return Ok(response);
                }
            }

            return Unauthorized("Credenciales inválidas");
        }
    }
}
