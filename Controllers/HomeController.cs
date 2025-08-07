using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06_schnaider.Models;

namespace TP06_schnaider.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        int? idUsuario = HttpContext.Session.GetInt32("idUsuario");
        if (idUsuario == null)
        {
            return RedirectToAction("Login", "Account");
        }

        List<Tarea> tareas = BD.DevolverTareas(idUsuario.Value);
        return View(tareas);
    }

    public IActionResult VerTarea(int id)
    {
        Tarea tarea = BD.DevolverTarea(id);
        return View(tarea);
    }

    public IActionResult CrearTarea()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CrearTareaGuardar(Tarea tarea)
    {
        tarea.idUsuario = HttpContext.Session.GetInt32("idUsuario").Value;
        BD.CrearTarea(tarea);
        return RedirectToAction("Index");
    }

    public IActionResult EditarTarea(int id)
    {
        Tarea tarea = BD.DevolverTarea(id);
        return View(tarea);
    }

    [HttpPost]
    public IActionResult EditarTareaGuardar(Tarea tarea)
    {
        BD.ModificarTarea(tarea);
        return RedirectToAction("Index");
    }

    public IActionResult EliminarTarea(int id)
    {
        BD.EliminarTarea(id);
        return RedirectToAction("Index");
    }

    public IActionResult FinalizarTarea(int id)
    {
        BD.FinalizarTarea(id);
        return RedirectToAction("Index");
    }
}
