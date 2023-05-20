using FluentValidation;
using WebApplication1.Models;

namespace WebApplication1.Validators;

/// <summary>
/// 注文クラス用のバリデーター
/// </summary>
public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(model => model.CustomerName)
            .NotNull()
            .NotEmpty();

        RuleFor(model => model.CustomerEmail)
            .NotNull()
            .NotEmpty()
            .EmailAddress();

        RuleFor(model => model.Status)
            .NotNull()
            .NotEmpty()
            .IsInEnum();

        // ネストされた配列データに対するバリデーション
        RuleForEach(model => model.Product)
            .NotNull()
            .NotEmpty()
            .SetValidator(new ProductValidator());
    }
}
