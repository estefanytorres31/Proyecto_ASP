using App_ventas_ds500.Models;
using Microsoft.EntityFrameworkCore;

namespace App_ventas_ds500.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Proyecto> Proyecto { get; set;}
    }
}
