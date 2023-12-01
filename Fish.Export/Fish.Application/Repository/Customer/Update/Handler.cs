using Kendo.Mvc.UI;
using Mapster;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fish.Data;
using Fish.Application.Model;
using Microsoft.EntityFrameworkCore;
using Fish.Entity.SQL;
using System;

namespace Fish.Application.Usecase
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, ResponseOne<UpdateCustomerData>>
    {
        private readonly DataContext context;

        /// <summary>
        /// We injecting ISQLConnection from DI Container
        /// </summary>
        /// <param name="context"></param>
        public UpdateCustomerHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<ResponseOne<UpdateCustomerData>> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            var trx = System.Guid.NewGuid();
            var response = new ResponseOne<UpdateCustomerData>();
            var dbCustomer = await context.Customer.FindAsync(request.customerId);
            if (dbCustomer == null)
                return response.SetResponse("Customer Not Found", new UpdateCustomerData { }, trx);

            dbCustomer.customerCode = request.customerCode;
            dbCustomer.customerName = request.customerName;
            dbCustomer.customerAddress = request.customerAddress;
            dbCustomer.modifiedBy = 1;
            dbCustomer.modifiedAt = DateTime.Now;
            await context.SaveChangesAsync();

            //return Ok(await context.Customer.ToListAsync());
            response.SetResponse("Update Customer", new UpdateCustomerData { }, trx);
            return response;
        }
    }
}