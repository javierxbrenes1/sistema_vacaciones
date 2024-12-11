using Microsoft.AspNetCore.Mvc;
using sistema_vacaciones.Models;
using sistema_vacaciones.Repository;
using sistema_vacaciones.DTOs;

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
    public IActionResult Editar(TipoEmpleadosDTO tipo)
    {
        if (ModelState.IsValid)
        {
            this._repo.Actualizar(new TipoEmpleados { Id = tipo.Id, Descripcion = tipo.Descripcion, NumeroDias = tipo.NumeroDias });
            return RedirectToAction("Index");
        }
        return View(tipo);
    }

    [HttpPost]
    public IActionResult Nuevo(TipoEmpleadosDTO tipo)
    {
        if (ModelState.IsValid)
        {
            this._repo.Agregar(new TipoEmpleados { Descripcion = tipo.Descripcion, NumeroDias = tipo.NumeroDias });
            return RedirectToAction("Index");
        }
        return View(tipo);
    }
}