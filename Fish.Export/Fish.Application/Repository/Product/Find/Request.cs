using MediatR;
using Fish.Application.Model;
using System;
using Fish.Entity.SQL;

namespace Fish.Application.Usecase
{
    public class FindProductRequest : IRequest<Response<Product>>
    {
        public decimal price { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
    }
}
