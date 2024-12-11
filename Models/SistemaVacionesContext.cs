using Microsoft.EntityFrameworkCore;
using sistema_vacaciones.Models;

namespace sistema_vacaciones.Models
{
    public class SistemaVacacionesContext : DbContext
    {
        public SistemaVacacionesContext(DbContextOptions<SistemaVacacionesContext> options) : base(options)
        {
        }
        public DbSet<TipoEmpleados> TipoEmpleados { get; set; }
        public DbSet<Departamentos> Departamentos {get; set;}
    }

}