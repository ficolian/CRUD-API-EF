using MediatR;
using Fish.Application.Model;
using System;

namespace Fish.Application.Usecase
{
    public class UpdateProductRequest : IRequest<ResponseOne<UpdateProductData>>
    {
        public int? productId { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
    }
}
