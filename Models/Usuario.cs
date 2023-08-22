using System.ComponentModel.DataAnnotations;

namespace Restaurante_API.Models
{
    public class Usuario
    {
        [Key]
        public int usuario_id { get; set; }
        public string? nombre { get; set; }
        public string? clave { get; set; }
        public string? rol { get; set; }
    }
}
