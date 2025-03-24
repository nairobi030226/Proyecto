using Microsoft.EntityFrameworkCore;
using Proyecto.Entities;

namespace Proyecto.Data
{
    // Clase que representa el contexto de la base de datos en Entity Framework
    public class AddDbContext : DbContext
    {
        // Constructor que recibe opciones de configuración y las pasa a la base de DbContext
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options) { }

        // Define una tabla "PersonPhone" en la base de datos
        public DbSet<PersonPhone> PersonPhone { get; set; }
    }
}