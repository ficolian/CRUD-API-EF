using Mapster;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fish.Data;
using Fish.Application.Model;
using Fish.Entity.SQL;
using System;

namespace Fish.Application.Usecase
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, ResponseOne<DeleteProductData>>
    {
        private readonly DataContext context;

        /// <summary>
        /// We injecting ISQLConnection from DI Container
        /// </summary>
        /// <param name="context"></param>
        public DeleteProductHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<ResponseOne<DeleteProductData>> Handle(DeleteProductRequest request, CancellationToken token)
        {
            var trx = System.Guid.NewGuid();
            var response = new ResponseOne<DeleteProductData>();
            var dbProduct = await context.Product.FindAsync(request.productId);
            if (dbProduct == null)
                return response.ResponseFail("Product not found.", new DeleteProductData { }, trx);

            context.Product.Remove(dbProduct);
            context.SaveChanges();

            response.ResponseFail("Delete Product", new DeleteProductData { }, trx);
            return response;
        }
    }
}