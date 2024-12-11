using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sistema_vacaciones.Models
{
    public class Funcionarios {
        [Key]
        public string? Codigo { get; set; }
        public string Nombre {get;set;}
        public string Apellidos {get;set;}
        public Departamentos Departamento {get;set;}

        [ForeignKey("DepartamentoId")]
        public int DepartamentoId {get;set;}
        public TipoEmpleados TipoEmpleado {get;set;}
        [ForeignKey("TipoEmpleadosId")]
        public int TipoEmpleadoId {get;set;}
        public DateTime FechaIngreso {get;set;}
        public string CorreoElectronico {get;set;}
    }
}