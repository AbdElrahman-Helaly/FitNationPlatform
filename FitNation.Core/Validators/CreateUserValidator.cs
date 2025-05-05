using FitNation.Core.DTOS;
using FitNation.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitNation.Core.Validators
{
    public class CreateUserValidator : AbstractValidator<RegisterReqDto>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Username is required.")
                .Length(3, 20)
                .WithMessage("Username must be between 3 and 20 characters long.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.");
        }
    }
  
}
