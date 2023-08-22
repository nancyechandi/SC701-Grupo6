using System.ComponentModel.DataAnnotations;

namespace Restaurante_API.Models
{
    public class Platillo
    {
        [Key]
        public int platillo_id { get; set; }
        public int restaurante_id { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }

        public int precio { get; set; }
        public bool vegano { get; set; }
        public bool gluten { get; set; }

        public int cantidad { get; set; }
    }

}
