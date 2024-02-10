using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace backEnd.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int cedula { get; set; }
        [Required]
        public string nombre { get; set; }
        public string foto { get; set; }
        [Required]
        public string fechaIngreso { get; set; }
        public int CargoId { get; set; }
        
        
    }
}
