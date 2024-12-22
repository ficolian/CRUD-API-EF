using FluentValidation;

namespace Fish.Application.Usecase
{
    public class UpdateProductValidation : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductValidation()
        {
            RuleFor(x => x.productId)
               .NotNull()
               .WithMessage("Product Id field is required");

            RuleFor(x => x.productName)
               .NotEmpty()
               .WithMessage("Product Name field is required");

            RuleFor(x => x.description)
               .NotEmpty()
               .WithMessage("Description field is required");

            RuleFor(x => x.price)
               .NotEmpty()
               .WithMessage("Price field is required");
        }

    }
}
