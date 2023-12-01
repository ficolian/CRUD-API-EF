using Kendo.Mvc.UI;
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
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, ResponseOne<CreateCustomerData>>
    {
        private readonly DataContext context;

        /// <summary>
        /// We injecting ISQLConnection from DI Container
        /// </summary>
        /// <param name="context"></param>
        public CreateCustomerHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<ResponseOne<CreateCustomerData>> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var trx = System.Guid.NewGuid();
            var response = new ResponseOne<CreateCustomerData>();
            var insert = request.Adapt<Customer>();
            insert.createdBy = 1;
            insert.createdAt = DateTime.Now;
            context.Customer.Add(insert);
            await context.SaveChangesAsync();

            //await context.Customer.ToListAsync();
            response.SetResponse("Save Customer", new CreateCustomerData { }, trx);
            return response;
        }
    }
}