using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06_schnaider.Models;

namespace TP06_schnaider.Controllers;

public class AccountController : Controller
{
     public IActionResult Login()
    {
        int? idUsuario = HttpContext.Session.GetInt32("idUsuario");
        if (idUsuario != null)
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    [HttpPost]
    public IActionResult LoginGuardar(string username, string password)
    {
        Usuario usuario = BD.Login(username, password);

        if (usuario != null)
        {
            HttpContext.Session.SetInt32("idUsuario", usuario.idUsuario);
            BD.ActualizarLogin(usuario.idUsuario);
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.Mensaje = "Usuario o contraseña incorrectos";
            return View("Login");
        }
    }

    public IActionResult CerrarSesion()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }

    public IActionResult Registro()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegistroGuardar(Usuario nuevo)
    {
        BD.Registrar(nuevo);
        return RedirectToAction("Login");
    }
}
