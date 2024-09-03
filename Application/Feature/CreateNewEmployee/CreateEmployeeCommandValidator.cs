using FluentValidation;

namespace Application.Feature.CreateNewEmployee;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(employee => employee.Name)
            .NotEmpty().WithMessage("Name is required");

        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email khong hop le");
    }
}
