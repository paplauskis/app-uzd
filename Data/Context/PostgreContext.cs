using app_project.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace app_project.Data.Context;

public class PostgreContext : DbContext
{
    private const string ConnectionString = "Host=localhost;Port=1234;Database=app-praktika;Username=kostaspaplauskas;Password=Paplauskis99@;";
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
    }
 
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Resident> Residents { get; set; }
    public DbSet<Community> Communities { get; set; }
    public DbSet<Service> Services { get; set; }
}