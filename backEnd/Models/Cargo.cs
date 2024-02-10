using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backEnd.Models
{
    public class Cargo
    {
        [Key]
        public int Id { get; set; }
        public string nombre { get; set; }
    }
}
