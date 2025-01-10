using FluentValidation;
using ShopClickDrive.InventoryManagement.DTOs;

namespace ShopClickDrive.InventoryManagement.Validators;

public class CreateInventoryDtoValidator : AbstractValidator<CreateInventoryDto>
{
    public CreateInventoryDtoValidator()
    {
        RuleFor(dto => dto.CarModel)
            .NotEmpty().WithMessage("Car model is required.")
            .MaximumLength(100).WithMessage("Car model cannot exceed 100 characters.");

        RuleFor(dto => dto.Year)
            .InclusiveBetween(1886, DateTime.Now.Year + 1) // Earliest car invention year to next year
            .WithMessage($"Year must be between 1886 and {DateTime.Now.Year + 1}.");

        RuleFor(dto => dto.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

        RuleFor(dto => dto.DealerId)
            .NotEmpty().WithMessage("Dealer ID is required.");
    }
}