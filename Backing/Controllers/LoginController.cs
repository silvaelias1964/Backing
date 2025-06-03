using Backing.Data;
using Backing.Models;
using Backing.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backing.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class LoginController : Controller
    {
        public readonly IConfiguration configuration;        
        public readonly IUsuarioService usuarioService;

        public LoginController(IConfiguration configuration,  IUsuarioService usuarioService)
        {
            this.configuration = configuration;            
            this.usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Login _userData)
        {
            if (_userData != null && _userData.Correo != null && _userData.Clave != null)
            {                
                var user = usuarioService.GetUsuario(_userData.Correo, _userData.Clave);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        // claims privados, definidos por el proyecto
                        new Claim("UserId", user.UsrId.ToString()),
                        new Claim("DisplayName", user.UsrNombre),
                        new Claim("UserName", user.UsrUsuario),
                        new Claim("Email", user.UsrCorreo),
                        new Claim("Role", user.UsrRol.ToString())

                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        configuration["Jwt:Issuer"],
                        configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(60),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Credenciales inválidos");
                }
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
