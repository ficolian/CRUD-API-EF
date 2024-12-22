using FluentValidation;

namespace Fish.Application.Usecase
{
    public class DeleteProductValidation : AbstractValidator<DeleteProductRequest>
    {
        public DeleteProductValidation()
        {
            RuleFor(x => x.productId)
               .NotNull()
               .WithMessage("Product Id field is required");

        }

    }
}
