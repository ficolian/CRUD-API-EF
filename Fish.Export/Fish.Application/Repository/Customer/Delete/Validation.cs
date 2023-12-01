using Kendo.Mvc.UI;
using MediatR;
using Fish.Application.Model;
using System;
using FluentValidation;

namespace Fish.Application.Usecase
{
    public class DeleteCustomerValidation : AbstractValidator<DeleteCustomerRequest>
    {
        public DeleteCustomerValidation()
        {
            RuleFor(x => x.customerId)
               .NotNull()
               .WithMessage("Customer Id field is required");

        }

    }
}
