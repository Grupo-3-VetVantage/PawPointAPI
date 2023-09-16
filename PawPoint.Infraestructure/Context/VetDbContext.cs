using Microsoft.EntityFrameworkCore;
using PawPoint.Infraestructure.Models;

namespace PawPoint.Infraestructure.Context;

public class VetDbContext:DbContext
{
    public VetDbContext(DbContextOptions<VetDbContext> options):base(options)
    {
        
    }
    public DbSet<Veterinary> Veterinaries { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Meeting> Meetings { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Review> Reviews { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
        optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=70162057;Database=PawPoint;", serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        
        // Configura la relación Cliente - Mascota
        modelBuilder.Entity<Pet>()
            .HasOne(m => m.User)
            .WithMany(c => c.Pets)
            .HasForeignKey(m => m.OwnerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // Opcional: si deseas eliminar mascotas al eliminar un cliente

        // Configura la relación Cita - Cliente
        modelBuilder.Entity<Meeting>()
            .HasOne(c => c.User)
            .WithMany(cli => cli.Meetings)
            .HasForeignKey(c => c.UserId)
            .IsRequired();

        // Configura la relación Cita - Veterinario
        modelBuilder.Entity<Meeting>()
            .HasOne(c => c.Veterinary)
            .WithMany(vet => vet.Meetings)
            .HasForeignKey(c => c.VetId)
            .IsRequired();

        // Configura la relación ServicioVeterinario - Veterinario
        modelBuilder.Entity<Service>()
            .HasOne(sv => sv.Veterinary)
            .WithMany(vet => vet.Services)
            .HasForeignKey(sv => sv.VeterinaryId)
            .IsRequired();
        
        // Configura la relación ProductoVeterinario - Veterinario
        modelBuilder.Entity<Product>()
            .HasOne(sv => sv.Veterinary)
            .WithMany(vet => vet.Products)
            .HasForeignKey(sv => sv.VeterinaryId)
            .IsRequired();
        
        // Configura la relación ReviewVeterinario - Veterinario
        modelBuilder.Entity<Review>()
            .HasOne(sv => sv.Veterinary)
            .WithMany(vet => vet.Reviews)
            .HasForeignKey(sv => sv.VeterinaryId)
            .IsRequired();
        
        // Configura la relación ReviewVeterinario - Usuario
        modelBuilder.Entity<Review>()
            .HasOne(sv => sv.User)
            .WithMany(vet => vet.Reviews)
            .HasForeignKey(sv => sv.UserId)
            .IsRequired();
        
        base.OnModelCreating(modelBuilder);
        
        


      
        
    }

    
}