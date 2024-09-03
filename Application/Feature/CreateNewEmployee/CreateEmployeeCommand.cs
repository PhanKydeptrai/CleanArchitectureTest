using Domain.Entities;
using MediatR;

namespace Application.Feature.CreateNewEmployee;

public class CreateEmployeeCommand : IRequest<TResult<bool>>
{
    public string Name { get; set; }
    public string Email { get; set; }
}
