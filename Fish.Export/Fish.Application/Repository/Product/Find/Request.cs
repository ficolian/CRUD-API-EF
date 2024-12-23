using MediatR;
using Fish.Application.Model;
using System;
using Fish.Entity.SQL;

namespace Fish.Application.Usecase
{
    public class FindProductRequest : IRequest<Response<Product>>
    {
        public string? productName { get; set; }
        public decimal? priceMin { get; set; }
        public decimal? priceMax { get; set; }
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 10;
    }
}
