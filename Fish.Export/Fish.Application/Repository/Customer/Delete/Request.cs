using Kendo.Mvc.UI;
using MediatR;
using Fish.Application.Model;
using System;

namespace Fish.Application.Usecase
{
    public class DeleteCustomerRequest : IRequest<ResponseOne<DeleteCustomerData>>
    {
        public int? customerId { get; set; }
    }
}
