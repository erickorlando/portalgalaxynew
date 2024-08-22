using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalGalaxy.Services.Interfaces;
using PortalGalaxy.Shared.Request;
using System.Security.Claims;

namespace PortalGalaxy.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService service, ILogger<UsersController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // POST: api/Usuarios/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginDtoRequest request)
        {
            var response = await _service.LoginAsync(request);

            _logger.LogInformation("Se inicio sesion desde {RequestID}", HttpContext.Connection.Id);

            return response.Success ? Ok(response) : Unauthorized(response);
        }

        // POST: api/Usuarios/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegistrarUsuarioDto request)
        {
            var response = await _service.RegisterAsync(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SendTokenToResetPassword(GenerateTokenToResetDtoRequest request)
        {
            var response = await _service.SendTokenToResetPasswordAsync(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDtoRequest request)
        {
            return Ok(await _service.ResetPasswordAsync(request));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordDtoRequest request)
        {
            // Recuperamos el email del usuario autenticado
            var email = HttpContext.User.Claims.First(p => p.Type == ClaimTypes.Email).Value;
            var response = await _service.ChangePasswordAsync(request, email);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateProfile(UpdateProfileDtoRequest request)
        {
            var response = await _service.UpdateProfileAsync(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            // Recuperamos el email del usuario autenticado
            var dto =  new BusquedaPerfilDtoRequest(HttpContext.User.Claims.First(p => p.Type == ClaimTypes.Email).Value);
            var response = await _service.GetProfileAsync(dto);
            return response.Success ? Ok(response) : NotFound(response);
        }
    }
}
