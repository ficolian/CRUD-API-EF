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
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest, ResponseOne<DeleteCustomerData>>
    {
        private readonly DataContext context;

        /// <summary>
        /// We injecting ISQLConnection from DI Container
        /// </summary>
        /// <param name="context"></param>
        public DeleteCustomerHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<ResponseOne<DeleteCustomerData>> Handle(DeleteCustomerRequest request, CancellationToken token)
        {
            var trx = System.Guid.NewGuid();
            var response = new ResponseOne<DeleteCustomerData>();
            var dbCustomer = await context.Customer.FindAsync(request.customerId);
            if (dbCustomer == null)
                return response.ResponseFail("Customer not found.", new DeleteCustomerData { }, trx);

            context.Customer.Remove(dbCustomer);
            context.SaveChanges();

            response.ResponseFail("Delete Customer", new DeleteCustomerData { }, trx);
            return response;
        }
    }
}