using Domain.Entities;
using MediatR;

namespace Application.Feature.GetEmployeeById;

public record GetEmployeeByIdQuery(int EmployeeId) : IRequest<Employee?>;

