using System.ComponentModel.DataAnnotations;

namespace Restaurante_API.Models
{
    public class Evento
    {
        [Key]
        public int evento_id { get; set; }
        public int restaurante_id { get; set; }
        public string? titulo { get; set; }
        public string? descripcion { get; set; }
        public DateTime fecha_evento { get; set; }
    }

}