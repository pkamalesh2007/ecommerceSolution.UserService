using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator:AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.email).NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not in valid format");

        RuleFor(request => request.PersonName)
        .NotEmpty().WithMessage("PersonName is required")
        .MaximumLength(50).WithMessage("Person Name should be 1 to 50 characters long");

        RuleFor(x => x.password).NotEmpty().WithMessage("Password is required");

        RuleFor(x => x.Gender)
        .IsInEnum().WithMessage("Invalid gender option");
    }
}
