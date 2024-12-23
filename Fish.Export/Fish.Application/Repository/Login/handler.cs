using Mapster;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fish.Application.Model;
using Fish.Entity.SQL;
using System;
using Fish.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Fish.Application.Usecase
{
    public class CreateUserHandler : IRequestHandler<UserCred, ResponseOne<UserCredData>>
    {
        private readonly DataContext context;
        private readonly JwtService jwtService;

        /// <summary>
        /// We injecting ISQLConnection from DI Container
        /// </summary>
        /// <param name="context"></param>
        public CreateUserHandler(DataContext context)
        {
            this.context = context;
            jwtService = new JwtService();
        }

        public async Task<ResponseOne<UserCredData>> Handle(UserCred request, CancellationToken cancellationToken)
        {
            var trx = System.Guid.NewGuid();
            var response = new ResponseOne<UserCredData>();
            var getUser = await context.MasterUser.FirstOrDefaultAsync(x => x.username == request.username);
            
            if(getUser != null)
            {
                var token = jwtService.GenerateJwtToken(request.username, getUser.gmail);
                return response.ResponseSuccess("Login Success", 
                                            new UserCredData { validFrom = DateTime.Now, 
                                                               validTo = DateTime.Now.AddMinutes(30), 
                                                               gmail = getUser.gmail, 
                                                               token = token }, trx);
            }

            response.ResponseSuccess("User not found", null, trx);
            return response;
        }
    }
}