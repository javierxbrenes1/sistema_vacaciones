using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sistema_vacaciones.Models
{
    public class Departamentos {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Funcionarios>? Funcionarios { get; }
    }
}