using Microsoft.EntityFrameworkCore;
using Proyecto.Entities;

namespace Proyecto.Data
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options) { }
        public DbSet<PersonPhone> PersonPhone { get; set; }
    }
}
