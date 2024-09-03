using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }
    public DbSet<Employee> Employees { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(k => k.EmployeeId);
        });
    }


}
