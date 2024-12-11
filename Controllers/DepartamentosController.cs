using Microsoft.AspNetCore.Mvc;
using sistema_vacaciones.Models;
using sistema_vacaciones.Repository;

namespace sistema_vacaciones.Controllers;


public class DepartamentosController: Controller {

    private DepartamentosRepository _repo;

    public DepartamentosController(SistemaVacacionesContext context) {
        this._repo = new DepartamentosRepository(context);
    }
    public IActionResult Index() {
        var depts = this._repo.ObtenerTodos();
        ViewBag.depts = depts;
        return View();
        
    }

    [HttpGet]
    public IActionResult Nuevo() {
        return View();
    }

    [HttpGet]
    public IActionResult Editar(int id) {
        var dept = this._repo.Obtener(id);
        if(dept != null) {
            return View(dept);
        }
        return RedirectToAction("Index");
    }

    public IActionResult Eliminar(int id) {
        var dept = this._repo.Eliminar(id);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Editar(Departamentos dept)
    {
        if (ModelState.IsValid)
        {
            this._repo.Actualizar(dept);
            return RedirectToAction("Index");
        }
        return View(dept);
    }

    [HttpPost]
    public IActionResult Nuevo(Departamentos dept)
    {
        if (ModelState.IsValid)
        {
            this._repo.Agregar(dept);
            return RedirectToAction("Index");
        }
        return View(dept);
    }
}