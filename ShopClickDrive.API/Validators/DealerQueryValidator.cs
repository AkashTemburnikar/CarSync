using FluentValidation;
using ShopClickDrive.Application.DealerManagement.DTOs;

namespace ShopClickDrive.API.Validators;

public class DealerQueryValidator : AbstractValidator<DealerQueryDto>
{
    public DealerQueryValidator()
    {
        RuleFor(q => q.SortBy)
            .Must(sort => string.IsNullOrEmpty(sort) || sort.Equals("name", StringComparison.OrdinalIgnoreCase))
            .WithMessage("Invalid sort field. Only 'name' is supported.");
    }
}