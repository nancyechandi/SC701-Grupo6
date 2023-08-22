using Microsoft.EntityFrameworkCore;
using Restaurante_API.Models;

namespace Restaurante_API.Data
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext> options) : base(options)
        {
        }

        public DbSet<Restaurante> Restaurante { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Reservacion> Reservacion { get; set; }
        public DbSet<Reseña> Reseña { get; set; }
        public DbSet<Promocion> Promocion { get; set; }
        public DbSet<Platillo> Platillo { get; set; }
        public DbSet<Evento> Evento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}

