using MediatR;
using Fish.Application.Model;
using System;

namespace Fish.Application.Usecase
{
    public class CreateProductRequest : IRequest<ResponseOne<CreateProductData>>
    {
        public string productName { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
    }
}
