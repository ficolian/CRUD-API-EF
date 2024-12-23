using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Fish.Data;
using Fish.Application.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fish.Application.Usecase
{
    public class GetProductHandler : IRequestHandler<GetProductRequest, ResponseOne<GetProductData>>
    {
        private readonly DataContext context;

        public GetProductHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<ResponseOne<GetProductData>> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var trx = System.Guid.NewGuid();
            var response = new ResponseOne<GetProductData>();
            var data = await context.Product
                                    .Where(x => x.productId == request.productId)
                                    .Select(x => new GetProductData { 
                                                                      productId = x.productId,
                                                                      productName = x.name,
                                                                      description = x.description, 
                                                                      price = x.price})
                                    .FirstOrDefaultAsync();
            
            response.ResponseSuccess("Get Product", data, trx);

            return response;
        }
    }
}