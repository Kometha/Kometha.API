namespace Kometha.API.Controllers
{
    using Kometha.API.Models.DTOs;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<IdentityUser> UserManager { get; }

        // POST: api/Auth/Register        
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username,
            };

            var identityResult = await UserManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                //Add roles to this User
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await UserManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("Usuario registrado");
                    }

                }

                return BadRequest(identityResult.Errors);
            }
            else
            {
                return BadRequest(identityResult.Errors);
            }
        }

        // POST: api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDto)
        {
            var user = await UserManager.FindByEmailAsync(loginRequestDto.Username);

            if (user != null && await UserManager.CheckPasswordAsync(user, loginRequestDto.Password))
            {
                //Create TOKEN 

                return Ok("Usuario autenticado correctamente");
            }
            else
            {
                return Unauthorized("Credenciales inválidas");
            }
        }
    }
}
