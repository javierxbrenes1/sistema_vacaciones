using Microsoft.AspNetCore.Mvc;
using sistema_vacaciones.Models;
using sistema_vacaciones.Repository;

namespace sistema_vacaciones.Controllers;


public class TiposController: Controller {

    private TipoEmpleadosRepository _repo;

    public TiposController(SistemaVacacionesContext context) {
        this._repo = new TipoEmpleadosRepository(context);
    }
    public IActionResult Index() {
        // ir por los tipos
        var tipos = this._repo.ObtenerTodos();
        ViewBag.tipos = tipos;
        return View();
        
    }

    [HttpGet]
    public IActionResult Nuevo() {
        return View();
    }

    [HttpGet]
    public IActionResult Editar(int id) {
        var tipo = this._repo.Obtener(id);
        if(tipo != null) {
            return View(tipo);
        }
        return RedirectToAction("Index");
    }

    public IActionResult Eliminar(int id) {
        var tipo = this._repo.Eliminar(id);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Editar(TipoEmpleados tipo)
    {
        if (ModelState.IsValid)
        {
            this._repo.Actualizar(tipo);
            return RedirectToAction("Index");
        }
        return View(tipo);
    }

    [HttpPost]
    public IActionResult Nuevo(TipoEmpleados tipo)
    {
        if (ModelState.IsValid)
        {
            this._repo.Agregar(tipo);
            return RedirectToAction("Index");
        }
        return View(tipo);
    }
}