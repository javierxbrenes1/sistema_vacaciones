using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sistema_vacaciones.Models
{
    public class TipoEmpleados {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Descripcion { get; set; }
        public float NumeroDias {get; set;}

        public ICollection<Funcionarios> Funcionarios { get; }
    }
}