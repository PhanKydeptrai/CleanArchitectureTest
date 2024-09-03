using System.Diagnostics.CodeAnalysis;
using Domain.Entities;
using Domain.Repository;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeDbContext _context;
    public EmployeeRepository(EmployeeDbContext context) { _context = context; }

    public async Task CreateEmployee(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
    }

    public async Task DeleteEmployee(int employeeId)
    {
        var employee = await GetEmployeeById(employeeId);
        _context.Employees.Remove(employee);
    }

    
    public async Task<Employee> GetEmployeeById(int employeeId)
    {
        return await _context.Employees.FindAsync(employeeId);
    }

    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task UpdateEmployee(Employee employee)
    {
        _context.Employees.Update(employee);
    }

    public async Task<Employee> GetEmployeeByName(string employeeName)
    {
        return await _context.Employees.FirstOrDefaultAsync(e => e.Name == employeeName);
    }

    public async Task<bool> IsEmployeeNameUnique(string employeeName)
    {
        var employeeCheck = await _context.Employees.FirstOrDefaultAsync(e => e.Name == employeeName);
        if(employeeCheck != null)
        {
            return true;
        }
        return false;
    }
}
