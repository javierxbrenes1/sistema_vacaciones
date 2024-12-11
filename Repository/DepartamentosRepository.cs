using Microsoft.EntityFrameworkCore;
using sistema_vacaciones.Models;

namespace sistema_vacaciones.Repository;
public class DepartamentosRepository
{
    private SistemaVacacionesContext _db;
    public DepartamentosRepository(SistemaVacacionesContext db) {
        this._db = db;
    }

    public List<Departamentos>? ObtenerTodos() {
        var lista = this._db.Departamentos.ToList();
        return lista;
    }

    public Departamentos? Obtener(int id) {
        var elemento = this._db.Departamentos
        .Where(x => x.Id == id)
        .SingleOrDefault();
        
        return elemento;
    }

    public  Departamentos Agregar(Departamentos tipo) {
        this._db.Departamentos.Add(tipo);
        this._db.SaveChanges();
        return tipo;
    }

    public Departamentos Actualizar(Departamentos tipo) {
        this._db.Entry(tipo).State = EntityState.Modified;
        this._db.SaveChanges();
        return tipo;
    }

    public Departamentos Eliminar(int id) {
        var tipo = this._db.Departamentos.Find(id);
        if(tipo != null) {
            this._db.Remove(tipo);
            this._db.SaveChanges();
            return tipo;
        }
        return null;
    }
}