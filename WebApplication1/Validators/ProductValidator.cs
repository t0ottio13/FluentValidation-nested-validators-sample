using FluentValidation;
using WebApplication1.Models;

namespace WebApplication1.Validators;

/// <summary>
/// 製品クラス用のバリデーター
/// </summary>
public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(model => model.Name)
            .NotNull()
            .NotEmpty();

        RuleFor(model => model.Price)
            .NotNull()
            .NotEmpty();
    }
}
