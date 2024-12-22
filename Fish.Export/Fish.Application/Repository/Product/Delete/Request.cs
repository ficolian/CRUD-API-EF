using MediatR;
using Fish.Application.Model;
using System;

namespace Fish.Application.Usecase
{
    public class DeleteProductRequest : IRequest<ResponseOne<DeleteProductData>>
    {
        public int? productId { get; set; }
    }
}
