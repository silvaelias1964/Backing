using Backing.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebBacking.Models;
using WebBacking.Service.IService;

namespace WebBacking.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAutenticarApiService autenticarApiservice;

        public LoginController(IAutenticarApiService autenticarApiService) 
        { 
            this.autenticarApiservice = autenticarApiService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string correo, string clave) 
        {
            
            var usuario = await autenticarApiservice.GetLogin(correo, clave);

            if (usuario == null || usuario.token=="Credenciales inválidos")
            {
                ViewData["Mensaje"] = "Usuario no encontrado..";
                return View();
            }
            if(usuario.token=="Error") 
            {
                ViewData["Mensaje"] = "Error, la api no está activa..";
                return View();
            }

            var claims = new List<Claim>
            {            
            new Claim(CustomClaimTypes.EmailUser, usuario.correo),            
            new Claim(CustomClaimTypes.TokenId, usuario.token)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );


            return RedirectToAction("Index", "Home");

        }


    }
}
