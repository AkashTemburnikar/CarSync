using FluentValidation;
using ShopClickDrive.Application.DealerManagement.DTOs;

namespace ShopClickDrive.API.Validators;

public class CreateDealerDtoValidator : AbstractValidator<CreateDealerDto>
{
    public CreateDealerDtoValidator()
    {
        RuleFor(dealer => dealer.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters");
            
        RuleFor(dealer => dealer.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is invalid");
        
        RuleFor(dealer => dealer.Address)
            .NotEmpty().WithMessage("Address is required")
            .MaximumLength(200).WithMessage("Address must not exceed 200 characters");
    }
}