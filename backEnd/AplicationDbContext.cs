using backEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace backEnd
{
    public class AplicationDbContext: DbContext
    {
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        { 

        }
    }
}
