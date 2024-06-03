using FluentValidation;
using WebApplication2.DTO_S;

namespace WebApplication2.Validators;

public class NewProductValidator : AbstractValidator<AddProductDTO>
{
    public NewProductValidator()
    {
        RuleFor(e => e.Name).NotEmpty().NotNull().MaximumLength(100);
        RuleFor(e => e.Weight).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(e => e.Width).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(e => e.Height).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(e => e.Depth).NotEmpty().NotNull().GreaterThan(0);
    }
    }
