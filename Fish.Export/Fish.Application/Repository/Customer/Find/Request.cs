using Kendo.Mvc.UI;
using MediatR;
using Fish.Application.Model;
using System;
using Fish.Entity.SQL;

namespace Fish.Application.Usecase
{
    public class FindCustomerRequest : IRequest<Response<Customer>>
    {
    }
}
