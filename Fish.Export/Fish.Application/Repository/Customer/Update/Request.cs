using Kendo.Mvc.UI;
using MediatR;
using Fish.Application.Model;
using System;

namespace Fish.Application.Usecase
{
    public class UpdateCustomerRequest : IRequest<ResponseOne<UpdateCustomerData>>
    {
        public int? customerId { get; set; }
        public string customerCode { get; set; }
        public string customerName { get; set; }
        public string customerAddress { get; set; }
    }
}
