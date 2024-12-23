using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Fish.Data;
using Fish.Application.Model;
using Microsoft.EntityFrameworkCore;
using Fish.Entity.SQL;
using System.Drawing.Printing;
using System.Linq;

namespace Fish.Application.Usecase
{
    public class FindProductHandler : IRequestHandler<FindProductRequest, Response<Product>>
    {
        private readonly DataContext context;

        public FindProductHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<Response<Product>> Handle(FindProductRequest request, CancellationToken cancellationToken)
        {
            var trx = System.Guid.NewGuid();
            var response = new Response<Product>();
            var keyword = $"%{request.productName}%";
            var data = await context.Product
                                    .ToListAsync();
            if (!string.IsNullOrWhiteSpace(request.productName))
            {
                data = data.Where(x => x.name.Contains(request.productName)).ToList();
            }
            if (request.priceMin.HasValue && request.priceMin > 0)
            {
                data = data.Where(x => x.price >= request.priceMin).ToList();
            }

            if (request.priceMax.HasValue && request.priceMax > 0)
            {
                data = data.Where(x => x.price <= request.priceMax).ToList();
            }

            var products = data.Skip((request.page - 1) * request.pageSize)
                               .Take(request.pageSize).ToList();

            response.ResponseSucess("Find Product", products, request.page, 
                                     request.pageSize, data.Count(),
                                     trx);

            return response;
        }
    }
}