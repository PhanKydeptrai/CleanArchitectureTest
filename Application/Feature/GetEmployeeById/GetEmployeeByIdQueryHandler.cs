using Domain.Entities;
using Domain.Repository;
using MediatR;

namespace Application.Feature.GetEmployeeById;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee?>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    public async Task<Employee?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        Employee employee = await _employeeRepository.GetEmployeeById(request.EmployeeId);
        return employee;
    }
}
