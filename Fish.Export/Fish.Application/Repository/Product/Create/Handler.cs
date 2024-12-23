using Mapster;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fish.Application.Model;
using Fish.Entity.SQL;
using System;
using Fish.Data;

namespace Fish.Application.Usecase
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, ResponseOne<CreateProductData>>
    {
        private readonly DataContext context;

        /// <summary>
        /// We injecting ISQLConnection from DI Container
        /// </summary>
        /// <param name="context"></param>
        public CreateProductHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<ResponseOne<CreateProductData>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var trx = System.Guid.NewGuid();
            var response = new ResponseOne<CreateProductData>();
            var insert = request.Adapt<Product>();
            insert.name = request.productName;
            insert.description = request.description;
            insert.price = request.price;
            insert.createdAt = DateTime.Now;
            context.Product.Add(insert);
            await context.SaveChangesAsync();

            //await context.Product.ToListAsync();
            response.ResponseSuccess("Save Product", new CreateProductData { }, trx);
            return response;
        }
    }
}