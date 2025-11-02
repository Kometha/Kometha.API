namespace Kometha.API.Controllers
{
    using Kometha.API.Models.DTOs;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Defines the <see cref="AuthController" />
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Defines the userManager
        /// </summary>
        private readonly UserManager<IdentityUser> userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="userManager">The userManager<see cref="UserManager{IdentityUser}"/></param>
        public AuthController(UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
        }

        /// <summary>
        /// Gets the UserManager
        /// </summary>
        public UserManager<IdentityUser> UserManager { get; }

        // POST: api/Auth/Register

        /// <summary>
        /// The Register
        /// </summary>
        /// <param name="registerRequestDto">The registerRequestDto<see cref="RegisterRequestDto"/></param>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
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
    }
}
