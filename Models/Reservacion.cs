using System.ComponentModel.DataAnnotations;

namespace Restaurante_API.Models
{
    public class Reservacion
    {
        [Key]
        public int reservacion_id { get; set; }
        public int restaurante_id { get; set; }
        public int usuario_id { get; set; }
        public DateTime fecha_reserva { get; set; }
        public TimeSpan fecha_hora { get; set; }
        public int personas { get; set; }
    }

}
