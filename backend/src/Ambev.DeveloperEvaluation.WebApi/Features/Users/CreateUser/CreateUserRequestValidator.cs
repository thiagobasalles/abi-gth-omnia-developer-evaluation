﻿using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    
    public CreateUserRequestValidator()
    {
        RuleFor(user => user.Email).SetValidator(new EmailValidator());

        RuleFor(user => user.Name)
            .NotNull().WithMessage("Name is required");

        RuleFor(user => user.Name.Firstname)
            .NotEmpty().Length(3, 50)
            .When(user => user.Name != null);

        RuleFor(user => user.Name.Lastname)
            .NotEmpty().Length(3, 50)
            .When(user => user.Name != null);

        RuleFor(user => user.Password).SetValidator(new PasswordValidator());
        RuleFor(user => user.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        RuleFor(user => user.Status).NotEqual(UserStatus.Unknown);
        RuleFor(user => user.Role).NotEqual(UserRole.None);

        RuleFor(user => user.Address)
            .NotNull().WithMessage("Address cannot be null");

        RuleFor(user => user.Address.City)
            .NotEmpty().WithMessage("City is required")
            .When(user => user.Address != null);

        RuleFor(user => user.Address.Street)
            .NotEmpty().WithMessage("Street is required")
            .When(user => user.Address != null);

        RuleFor(user => user.Address.Number)
            .GreaterThan(0).WithMessage("Number must be greater than zero")
            .When(user => user.Address != null);

        RuleFor(user => user.Address.Zipcode)
            .NotEmpty().WithMessage("Zipcode is required")
            .When(user => user.Address != null);
    }
}