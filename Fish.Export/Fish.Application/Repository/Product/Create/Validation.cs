using FluentValidation;

namespace Fish.Application.Usecase
{
    public class CreateProductValidation : AbstractValidator<CreateProductRequest>
    {
        public CreateProductValidation()
        {
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
