using System.ComponentModel.DataAnnotations;

namespace Restaurante_API.Models
{
    public class Restaurante
    {
        [Key]
        public int restaurante_id { get; set; }
        public string? nombre { get; set; }
        public string? ubicacion { get; set; }
        public string? horario { get; set; }
        public string? descripcion { get; set; }
        public string? link_red_social { get; set; }
    }

}
