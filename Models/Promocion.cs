using System.ComponentModel.DataAnnotations;

namespace Restaurante_API.Models
{
    public class Promocion
    {
        [Key]
        public int promocion_id { get; set; }
        public int restaurante_id { get; set; }
        public string? titulo { get; set; }
        public string? descripcion { get; set; }
    }

}