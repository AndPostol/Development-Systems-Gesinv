using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.UI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DevSys.Gesinv.UI;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using DevSys.Gesinv.Models;
using System.Numerics;

namespace DevSys.Gesinv.UI.Controllers
{
    public class AccesoController : Controller
    {
        private readonly IUsuarioService _service;
        public AccesoController(IUsuarioService service)
        {
            _service = service;
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IniciarSesion(UsuarioViewModel usuarioViewModel) 
        {
            try
            {
                Usuario usuario_encontrado = _service.GetUsuario(usuarioViewModel.Correo, usuarioViewModel.Password);

                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.Email, usuario_encontrado.Correo)
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
                return RedirectToAction("Index", "OrdenCompra");
            }
            catch (Exception ex)
            {
                return View();
            }
            
        }

        //public IActionResult Registrarse() 
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Registrarse(UsuarioViewModel usuarioViewModel)
        //{
        //    return View();
        //}



    }
}
