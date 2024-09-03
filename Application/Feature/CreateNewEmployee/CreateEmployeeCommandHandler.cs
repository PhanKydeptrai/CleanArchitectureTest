using Domain.Entities;
using Domain.Repository;
using FluentValidation.Results;
using MediatR;

namespace Application.Feature.CreateNewEmployee;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, TResult<bool>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<TResult<bool>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        CreateEmployeeCommandValidator validator = new CreateEmployeeCommandValidator();

        ValidationResult validationResult = await validator.ValidateAsync(request);

        TResult<bool> result = new TResult<bool>
        {
            Data = false,
            Errors = new List<string>()
        };

        if (!validationResult.IsValid) //nếu đầu vào không hợp lệ
        {
            foreach (var error in validationResult.Errors)
            {
                result.Errors.Add(error.ToString());
            }
            return result;
        }

        if (!await _employeeRepository.IsEmployeeNameUnique(request.Name))
        {
            var employee = new Employee
            {
                EmployeeId = 0,
                Email = request.Email,
                Name = request.Name
            };

            await _employeeRepository.CreateEmployee(employee);
            await _unitOfWork.SaveChangesAsync();
            result.Data = true;
            return result;
        }
        result.Errors.Add("Employee name is already exist");
        return result;

    }
}
