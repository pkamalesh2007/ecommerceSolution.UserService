using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators;

public class LoginRequestValidator:AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x=>x.email).NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email Address is not in correct format"); 
        RuleFor(x=>x.password).NotEmpty().WithMessage("Password is required");
        
    }
}
