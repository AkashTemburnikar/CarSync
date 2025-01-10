using FluentValidation;
using ShopClickDrive.LeadManagement.DTOs;

namespace ShopClickDrive.LeadManagement.Validators;

public class CreateLeadDtoValidator : AbstractValidator<CreateLeadDto>
{
    public CreateLeadDtoValidator()
    {
        RuleFor(x => x.CustomerName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.CustomerContact).NotEmpty().MaximumLength(50);
        RuleFor(x => x.CarDetails).NotEmpty().MaximumLength(200);
        RuleFor(x => x.DealerId).GreaterThan(0);
    }
}