using System.ComponentModel.DataAnnotations;

namespace Restaurante_API.Models
{
    public class Reseña
    {
        [Key]
        public int reseña_id { get; set; }
        public int restaurante_id { get; set; }
        public int usuario_id { get; set; }
        public int puntuacion { get; set; }
        public string? comentario { get; set; }
        public string? adicionales { get; set; }
    }

}