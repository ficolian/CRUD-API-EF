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

namespace Fish.Application.Usecase
{
    public class FindCustomerHandler : IRequestHandler<FindCustomerRequest, Response<Customer>>
    {
        private readonly DataContext context;

        /// <summary>
        /// We injecting ISQLConnection from DI Container
        /// </summary>
        /// <param name="context"></param>
        public FindCustomerHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<Response<Customer>> Handle(FindCustomerRequest request, CancellationToken cancellationToken)
        {
            var trx = System.Guid.NewGuid();
            var response = new Response<Customer>();
            var data = await context.Customer.ToListAsync();
            response.SetResponse("Find Customer", data, trx);

            return response;
        }
    }
}