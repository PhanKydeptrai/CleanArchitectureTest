using Domain.Entities;

namespace Domain.Repository;

public interface IEmployeeRepository
{
    #region Usecase 
    Task CreateEmployee(Employee employee);
    Task UpdateEmployee(Employee employee);
    Task DeleteEmployee(int employeeId);
    Task<Employee> GetEmployeeByName(string employeeName);
    Task<Employee> GetEmployeeById(int employeeId);
    Task<IEnumerable<Employee>> GetEmployees(); 

    Task<bool> IsEmployeeNameUnique(string employeeName);
    #endregion
}
