using Domain.Repository;

namespace Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly EmployeeDbContext _context;

    public UnitOfWork(EmployeeDbContext context)
    {
        _context = context;
    }   

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

}
