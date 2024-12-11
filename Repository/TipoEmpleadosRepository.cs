using Microsoft.EntityFrameworkCore;
using sistema_vacaciones.Models;

namespace sistema_vacaciones.Repository;
public class TipoEmpleadosRepository
{
    private SistemaVacacionesContext _db;
    public TipoEmpleadosRepository(SistemaVacacionesContext db) {
        this._db = db;
    }

    public List<TipoEmpleados>? ObtenerTodos() {
        var lista = this._db.TipoEmpleados.ToList();
        return lista;
    }

    public TipoEmpleados? Obtener(int id) {
        var elemento = this._db.TipoEmpleados
        .Where(x => x.Id == id)
        .SingleOrDefault();
        
        return elemento;
    }

    public  TipoEmpleados Agregar(TipoEmpleados tipo) {
        this._db.TipoEmpleados.Add(tipo);
        this._db.SaveChanges();
        return tipo;
    }

    public TipoEmpleados Actualizar(TipoEmpleados tipo) {
        this._db.Entry(tipo).State = EntityState.Modified;
        this._db.SaveChanges();
        return tipo;
    }

    public TipoEmpleados Eliminar(int id) {
        var tipo = this._db.TipoEmpleados.Find(id);
        if(tipo != null) {
            this._db.Remove(tipo);
            this._db.SaveChanges();
            return tipo;
        }
        return null;
    }
}