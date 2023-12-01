using Kendo.Mvc.UI;
using MediatR;
using Fish.Application.Model;
using System;
using FluentValidation;

namespace Fish.Application.Usecase
{
    public class CreateCustomerValidation : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerValidation()
        {
            RuleFor(x => x.customerCode)
               .NotEmpty()
               .WithMessage("Customer Code field is required");

            RuleFor(x => x.customerAddress)
               .NotEmpty()
               .WithMessage("Customer Address field is required");

            RuleFor(x => x.customerName)
               .NotEmpty()
               .WithMessage("Customer Name field is required");
        }

    }
}
