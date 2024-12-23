using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Fish.Data;
using Fish.Application.Model;
using System;

namespace Fish.Application.Usecase
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, ResponseOne<UpdateProductData>>
    {
        private readonly DataContext context;

        /// <summary>
        /// We injecting ISQLConnection from DI Container
        /// </summary>
        /// <param name="context"></param>
        public UpdateProductHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<ResponseOne<UpdateProductData>> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var trx = System.Guid.NewGuid();
            var response = new ResponseOne<UpdateProductData>();
            var dbProduct = await context.Product.FindAsync(request.productId);
            if (dbProduct == null)
                return response.ResponseFail("Product Not Found", new UpdateProductData { }, trx);

            dbProduct.name = request.productName;
            dbProduct.description = request.description;
            dbProduct.price = request.price;
            await context.SaveChangesAsync();

            //return Ok(await context.Product.ToListAsync());
            response.ResponseSuccess("Update Product", new UpdateProductData { }, trx);
            return response;
        }
    }
}