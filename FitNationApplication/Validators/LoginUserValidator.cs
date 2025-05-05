
using FitNationApplication.DTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitNationApplication.Validators
{
    public class LoginUserValiddator : AbstractValidator<LoginReqDTO>
    {
        public LoginUserValiddator() {
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

