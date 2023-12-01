using Azure.Core;
using Fish.Application.Model;
using Fish.Application.Usecase;
using Fish.Data;
using Fish.Entity.SQL;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Fish.Export.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : BaseController
    {
        //private readonly DataContext _context;

        //public CustomerController(DataContext context)
        //{
        //    _context = context;
        //}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Customer>> Get(int id)
        //{
        //    var customer = await _context.Customer.FindAsync(id);
        //    if (customer == null)
        //        return BadRequest("Customer not found.");
        //    return Ok(customer);
        //}

        [HttpPost("create")]
        public async Task<ActionResult<ResponseOne<CreateCustomerData>>> AddCustomer(CreateCustomerRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut("update")]
        public async Task<ActionResult<ResponseOne<UpdateCustomerData>>> UpdateCustomer(UpdateCustomerRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<ResponseOne<DeleteCustomerData>>> DeleteCustomer(DeleteCustomerRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("find")]
        public async Task<ActionResult<ResponseOne<FindCustomerData>>> FindUser()
        {
            FindCustomerRequest request = new FindCustomerRequest();
            return Ok(await Mediator.Send(request));
        }

    }
}
