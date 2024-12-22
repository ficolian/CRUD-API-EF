using MediatR;
using Fish.Application.Model;
using System;

namespace Fish.Application.Usecase
{
    public class CreateCustomerRequest : IRequest<ResponseOne<CreateCustomerData>>
    {
        public string customerCode { get; set; }
        public string customerName { get; set; }
        public string customerAddress { get; set; }
    }
}
