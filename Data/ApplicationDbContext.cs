using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Parcial2_Frank.Models;

namespace Parcial2_Frank.Data;

public class ApplicationDbContext : IdentityDbContext
{

    public DbSet<Vitaminas> vitaminas { get; set; }
    public DbSet<Verduras> verduras { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Vitaminas>().HasData(
            new Vitaminas { VitaminasId = 1, Descripcion = "Vitamina C" },
            new Vitaminas { VitaminasId = 2, Descripcion = "Betaina"},
            new Vitaminas { VitaminasId = 3, Descripcion = "Vitamina K" },
            new Vitaminas { VitaminasId = 4, Descripcion = "Vitamina A" },
            new Vitaminas { VitaminasId = 5, Descripcion = "Vitamina E" },
            new Vitaminas { VitaminasId = 6, Descripcion = "Acido Folico(B9)" }


            );
    }
    
        
    
}
